Imports System.Linq
Imports System.Threading
Imports Core

Module S_Loop

    Sub ServerLoop()
        Dim tick As Integer
        Dim tmr25 As Integer, tmr300 As Integer
        Dim tmr500 As Integer, tmr1000 As Integer
        Dim lastUpdateSavePlayers As Integer
        Dim lastUpdateMapSpawnItems As Integer
        Dim lastUpdatePlayerVitals As Integer

        Do
            ' Update our current tick value.
            tick = GetTimeMs()

            ' Don't process anything else if we're going down.
            If ServerDestroyed Then Stop

            ' Get all our online players.
            Dim onlinePlayers = TempPlayer.Where(Function(player) player.InGame).Select(Function(player, index) New With {Key .Index = index + 1, player}).ToArray()

            CheckShutDownCountDown()

            If tick > tmr25 Then
                ' Check if any of our players has completed casting and get their skill going if they have.
                Dim playerskills = (
                    From p In onlinePlayers
                    Where p.player.SkillBuffer > 0 And GetTimeMs() > (p.player.SkillBufferTimer + Skill(p.player.SkillBuffer).CastTime * 1000)
                    Select New With {p.Index, Key .Success = HandleCastSkill(p.Index)}
                ).ToArray()

                ' Check if we need to clear any of our players from being stunned.
                Dim playerstuns = (
                    From p In onlinePlayers
                    Where p.player.StunDuration > 0 And p.player.StunTimer + (p.player.StunDuration * 1000)
                    Select New With {p.Index, Key .Success = HandleClearStun(p.Index)}
                ).ToArray()

                ' Check if any of our pets has completed casting and get their skill going if they have.
                Dim petskills = (
                From p In onlinePlayers
                Where Player(p.Index).Pet.Alive = 1 And TempPlayer(p.Index).PetskillBuffer.Skill > 0 And GetTimeMs() > p.player.PetskillBuffer.Timer + (Skill(Player(p.Index).Pet.Skill(p.player.PetskillBuffer.Skill)).CastTime * 1000)
                Select New With {p.Index, Key .Success = HandlePetSkill(p.Index)}
                ).ToArray()

                ' Check if we need to clear any of our pets from being stunned.
                Dim petstuns = (
                    From p In onlinePlayers
                    Where p.player.PetStunDuration > 0 And p.player.PetStunTimer + (p.player.PetStunDuration * 1000)
                    Select New With {p.Index, Key .Success = HandleClearPetStun(p.Index)}
                ).ToArray()

                ' check pet regen timer
                Dim petregen = (
                    From p In onlinePlayers
                    Where p.player.PetstopRegen = True And p.player.PetstopRegenTimer + 5000 < GetTimeMs()
                    Select New With {p.Index, Key .Success = HandleStopPetRegen(p.Index)}
                ).ToArray()

                ' HoT and DoT logic
                'For x = 1 To MAX_COTS
                '    HandleDoT_Pet i, x
                '        HandleHoT_Pet i, x
                '    Next

                ' Update all our available events.
                UpdateEventLogic()

                ' Move the timer up 25ms.
                tmr25 = GetTimeMs() + 25
            End If

            If tick > tmr1000 Then
                Core.Time.Instance.Tick()

                ' Move the timer up 1000ms.
                tmr1000 = GetTimeMs() + 1000
            End If

            If tick > tmr500 Then
                ' Move the timer up 500ms.
                tmr500 = GetTimeMs() + 500
            End If

            If GetTimeMs() > tmr300 Then
                UpdateNpcAi()
                UpdatePetAi()
                tmr300 = GetTimeMs() + 300
            End If

            ' Checks to update player vitals every 5 seconds
            If tick > lastUpdatePlayerVitals Then
                UpdatePlayerVitals()
                lastUpdatePlayerVitals = GetTimeMs() + 5000
            End If

            ' Checks to spawn map items every 1 minute
            If tick > lastUpdateMapSpawnItems Then
                UpdateMapSpawnItems()
                lastUpdateMapSpawnItems = GetTimeMs() + 60000
            End If

            ' Checks to save players every 5 minutes
            If tick > lastUpdateSavePlayers Then
                UpdateSavePlayers()
                lastUpdateSavePlayers = GetTimeMs() + 300000
            End If

            Thread.Sleep(1)
        Loop
    End Sub

    Sub UpdateSavePlayers()
        Dim i As Integer

        If Socket.HighIndex() > 0 Then
            Console.WriteLine("Saving all online players...")

            For i = 1 To Socket.HighIndex()
                SaveCharacter(i, TempPlayer(i).Slot)
                SaveBank(i)
            Next

        End If

    End Sub

    Private Sub UpdateMapSpawnItems()
        Dim x As Integer
        Dim y As Integer

        ' ///////////////////////////////////////////
        ' // This is used for respawning map items //
        ' ///////////////////////////////////////////
        For y = 1 To MAX_MAPS

            ' Make sure no one is on the map when it respawns
            If Not PlayersOnMap(y) Then

                ' Clear out unnecessary junk
                For x = 1 To MAX_MAP_ITEMS
                    ClearMapItem(x, y)
                Next

                ' Spawn the items
                SpawnMapItems(y)
                SendMapItemsToAll(y)
            End If

        Next

    End Sub

    Private Sub UpdatePlayerVitals()
        Dim i As Integer

        For i = 1 To Socket.HighIndex()
            For x = 0 To [Enum].VitalType.Count - 1
                If GetPlayerVital(i, x) <> GetPlayerMaxVital(i, x) Then
                    SetPlayerVital(i, x, GetPlayerVital(i, x) + GetPlayerVitalRegen(i, x))
                    SendVital(i, x)
                End If
            Next

            ' send vitals to party if in one
            If TempPlayer(i).InParty > 0 Then SendPartyVitals(TempPlayer(i).InParty, i)
        Next

    End Sub

    Private Sub UpdateNpcAi()
        Dim i As Integer, x As Integer, n As Integer, x1 As Integer, y1 As Integer
        Dim mapNum As Integer, tickCount As Integer
        Dim damage As Integer
        Dim distanceX As Integer, distanceY As Integer
        Dim npcNum As Integer
        Dim target As Integer, targetTypes As Byte, targetX As Integer, targetY As Integer, targetVerify As Boolean
        Dim resourceIndex As Integer

        For mapNum = 1 To MAX_MAPS

            If ServerDestroyed Then Exit Sub

            ' items appearing to everyone
            For i = 1 To MAX_MAP_ITEMS
                If MapItem(mapNum, i).Num > 0 Then
                    If MapItem(mapNum, i).PlayerName <> "" Then
                        ' make item public?
                        If MapItem(mapNum, i).PlayerTimer < GetTimeMs() Then
                            ' make it public
                            MapItem(mapNum, i).PlayerName = ""
                            MapItem(mapNum, i).PlayerTimer = 0
                            ' send updates to everyone
                            SendMapItemsToAll(mapNum)
                        End If
                        ' despawn item?
                        If MapItem(mapNum, i).CanDespawn Then
                            If MapItem(mapNum, i).DespawnTimer < GetTimeMs() Then
                                ' despawn it
                                ClearMapItem(i, mapNum)
                                ' send updates to everyone
                                SendMapItemsToAll(mapNum)
                            End If
                        End If
                    End If
                End If
            Next

            ' Respawning Resources
            If MapResource(mapNum).ResourceCount > 0 Then
                For i = 1 To MapResource(mapnum).ResourceCount

                    resourceIndex = Map(mapNum).Tile(MapResource(mapNum).ResourceData(i).X, MapResource(mapNum).ResourceData(i).Y).Data1

                    If resourceIndex > 0 Then
                        If MapResource(mapNum).ResourceData(i).State = 1 Or MapResource(mapNum).ResourceData(i).Health < 1 Then  ' dead or fucked up
                            If MapResource(mapNum).ResourceData(i).Timer + (Resource(resourceIndex).RespawnTime * 1000) < GetTimeMs() Then
                                MapResource(mapNum).ResourceData(i).Timer = GetTimeMs()
                                MapResource(mapNum).ResourceData(i).State = 0 ' normal
                                ' re-set health to resource root
                                MapResource(mapNum).ResourceData(i).Health = Resource(resourceIndex).Health
                                SendMapResourceToMap(mapNum, i)
                            End If
                        End If
                    End If
                Next
            End If

            If ServerDestroyed Then Exit Sub

            If PlayersOnMap(mapNum) = True Then
                tickCount = GetTimeMs()

                For x = 1 To MAX_MAP_NPCS
                    npcNum = MapNPC(mapNum).Npc(x).Num

                    ' check if they've completed casting, and if so set the actual skill going
                    If MapNPC(mapNum).Npc(x).SkillBuffer > 0 And Map(mapNum).Npc(x) > 0 And MapNPC(mapNum).Npc(x).Num > 0 Then
                        If GetTimeMs() > MapNPC(mapNum).Npc(x).SkillBufferTimer + (Skill(NPC(npcNum).Skill(MapNPC(mapNum).Npc(x).SkillBuffer)).CastTime * 1000) Then
                            CastNpcSkill(x, mapNum, MapNPC(mapNum).Npc(x).SkillBuffer)
                            MapNPC(mapNum).Npc(x).SkillBuffer = 0
                            MapNPC(mapNum).Npc(x).SkillBufferTimer = 0
                        End If
                    Else
                        ' /////////////////////////////////////////
                        ' // This is used for ATTACKING ON SIGHT //
                        ' /////////////////////////////////////////
                        ' Make sure theres a npc with the map
                        If Map(mapNum).Npc(x) > 0 And MapNPC(mapNum).Npc(x).Num > 0 Then

                            ' If the npc is a attack on sight, search for a player on the map
                            If NPC(npcNum).Behaviour = NpcBehavior.AttackOnSight Or NPC(npcNum).Behaviour = NpcBehavior.Guard Then

                                ' make sure it's not stunned
                                If Not MapNPC(mapNum).Npc(x).StunDuration > 0 Then

                                    For i = 1 To Socket.HighIndex()
                                        If IsPlaying(i) Then
                                            If GetPlayerMap(i) = mapNum And MapNPC(mapNum).Npc(x).Target = 0 And GetPlayerAccess(i) <= AdminType.Moderator Then
                                                If PetAlive(i) Then
                                                    n = NPC(npcNum).Range
                                                    distanceX = MapNPC(mapNum).Npc(x).X - Player(i).Pet.X
                                                    distanceY = MapNPC(mapNum).Npc(x).Y - Player(i).Pet.Y

                                                    ' Make sure we get a positive value
                                                    If distanceX < 0 Then distanceX *= -1
                                                    If distanceY < 0 Then distanceY *= -1

                                                    ' Are they in range?  if so GET'M!
                                                    If distanceX <= n And distanceY <= n Then
                                                        If NPC(npcNum).Behaviour = NpcBehavior.AttackOnSight Or GetPlayerPK(i) = i Then
                                                            If Len(Trim$(NPC(npcNum).AttackSay)) > 0 Then
                                                                PlayerMsg(i, Trim$(NPC(npcNum).Name) & " says: " & NPC(npcNum).AttackSay.Trim, ColorType.White)
                                                            End If
                                                            MapNPC(mapNum).Npc(x).TargetType = TargetType.Pet
                                                            MapNPC(mapNum).Npc(x).Target = i
                                                        End If
                                                    End If
                                                Else
                                                    n = NPC(npcNum).Range
                                                    distanceX = MapNPC(mapNum).Npc(x).X - GetPlayerX(i)
                                                    distanceY = MapNPC(mapNum).Npc(x).Y - GetPlayerY(i)

                                                    ' Make sure we get a positive value
                                                    If distanceX < 0 Then distanceX *= -1
                                                    If distanceY < 0 Then distanceY *= -1

                                                    ' Are they in range?  if so GET'M!
                                                    If distanceX <= n And distanceY <= n Then
                                                        If NPC(npcNum).Behaviour = NpcBehavior.AttackOnSight Or GetPlayerPK(i) = True Then
                                                            If NPC(npcNum).AttackSay.Trim.Length > 0 Then
                                                                PlayerMsg(i, CheckGrammar(NPC(npcNum).Name.Trim, 1) & " says, '" & NPC(npcNum).AttackSay.Trim & "' to you.", ColorType.Yellow)
                                                            End If
                                                            MapNPC(mapNum).Npc(x).TargetType = TargetType.Player
                                                            MapNPC(mapNum).Npc(x).Target = i
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Next

                                    ' Check if target was found for NPC targetting
                                    If MapNPC(mapNum).Npc(x).Target = 0 And NPC(npcNum).Faction > 0 Then
                                        ' search for npc of another faction to target
                                        For i = 1 To MAX_MAP_NPCS
                                            ' exist?
                                            If MapNPC(mapNum).Npc(i).Num > 0 Then
                                                ' different faction?
                                                If NPC(MapNPC(mapNum).Npc(i).Num).Faction > 0 And NPC(MapNPC(mapNum).Npc(i).Num).Faction <> NPC(npcNum).Faction Then
                                                    n = NPC(npcNum).Range
                                                    distanceX = MapNPC(mapNum).Npc(x).X - CLng(MapNPC(mapNum).Npc(i).X)
                                                    distanceY = MapNPC(mapNum).Npc(x).Y - CLng(MapNPC(mapNum).Npc(i).Y)

                                                    ' Make sure we get a positive value
                                                    If distanceX < 0 Then distanceX *= -1
                                                    If distanceY < 0 Then distanceY *= -1

                                                    ' Are they in range?  if so GET'M!
                                                    If distanceX <= n And distanceY <= n And NPC(npcNum).Behaviour = NpcBehavior.AttackOnSight Then
                                                        MapNPC(mapNum).Npc(x).TargetType = 2 ' npc
                                                        MapNPC(mapNum).Npc(x).Target = i
                                                    End If
                                                End If
                                            End If
                                        Next
                                    End If
                                End If
                            End If
                        End If

                        targetVerify = False

                        ' /////////////////////////////////////////////
                        ' // This is used for NPC walking/targetting //
                        ' /////////////////////////////////////////////
                        ' Make sure theres a npc with the map
                        If Map(mapNum).Npc(x) > 0 And MapNPC(mapNum).Npc(x).Num > 0 Then
                            If MapNPC(mapNum).Npc(x).StunDuration > 0 Then
                                ' check if we can unstun them
                                If GetTimeMs() > MapNPC(mapNum).Npc(x).StunTimer + (MapNPC(mapNum).Npc(x).StunDuration * 1000) Then
                                    MapNPC(mapNum).Npc(x).StunDuration = 0
                                    MapNPC(mapNum).Npc(x).StunTimer = 0
                                End If
                            Else

                                target = MapNPC(mapNum).Npc(x).Target
                                targetTypes = MapNPC(mapNum).Npc(x).TargetType

                                ' Check to see if its time for the npc to walk
                                If NPC(npcNum).Behaviour <> NpcBehavior.ShopKeeper And NPC(npcNum).Behaviour <> NpcBehavior.Quest Then
                                    If targetTypes = TargetType.Player Then ' player
                                        ' Check to see if we are following a player or not
                                        If target > 0 Then
                                            ' Check if the player is even playing, if so follow'm
                                            If IsPlaying(target) And GetPlayerMap(target) = mapNum Then
                                                targetVerify = True
                                                targetY = GetPlayerY(target)
                                                targetX = GetPlayerX(target)
                                            Else
                                                MapNPC(mapNum).Npc(x).TargetType = 0 ' clear
                                                MapNPC(mapNum).Npc(x).Target = 0
                                            End If
                                        End If
                                    ElseIf targetTypes = TargetType.Npc Then 'npc
                                        If target > 0 Then
                                            If MapNPC(mapNum).Npc(target).Num > 0 Then
                                                targetVerify = True
                                                targetY = MapNPC(mapNum).Npc(target).Y
                                                targetX = MapNPC(mapNum).Npc(target).X
                                            Else
                                                MapNPC(mapNum).Npc(x).TargetType = 0 ' clear
                                                MapNPC(mapNum).Npc(x).Target = 0
                                            End If
                                        End If
                                    ElseIf targetTypes = TargetType.Pet Then
                                        If target > 0 Then
                                            If IsPlaying(target) = True And GetPlayerMap(target) = mapNum And PetAlive(target) Then
                                                targetVerify = True
                                                targetY = Player(target).Pet.Y
                                                targetX = Player(target).Pet.X
                                            Else
                                                MapNPC(mapNum).Npc(x).TargetType = 0 ' clear
                                                MapNPC(mapNum).Npc(x).Target = 0
                                            End If
                                        End If
                                    End If

                                    If targetVerify Then
                                        'Gonna make the npcs smarter.. Implementing a pathfinding algorithm.. we shall see what happens.
                                        If IsOneBlockAway(targetX, targetY, CLng(MapNPC(mapNum).Npc(x).X), CLng(MapNPC(mapNum).Npc(x).Y)) = False Then

                                            i = FindNpcPath(mapNum, x, targetX, targetY)
                                            If i < 4 Then 'Returned an answer. Move the NPC
                                                If CanNpcMove(mapNum, x, i) Then
                                                    NpcMove(mapNum, x, i, MovementType.Walking)
                                                End If
                                            Else 'No good path found. Move randomly
                                                i = Random(1, 4)
                                                If i = 1 Then
                                                    i = Random(1, 4)

                                                    If CanNpcMove(mapNum, x, i) Then
                                                        NpcMove(mapNum, x, i, MovementType.Walking)
                                                    End If
                                                End If
                                            End If
                                        Else
                                            NpcDir(mapNum, x, GetNpcDir(targetX, targetY, CLng(MapNPC(mapNum).Npc(x).X), CLng(MapNPC(mapNum).Npc(x).Y)))
                                        End If
                                    Else
                                        i = Int(Rnd() * 4)

                                        If i = 1 Then
                                            i = Int(Rnd() * 4)

                                            If CanNpcMove(mapNum, x, i) Then
                                                NpcMove(mapNum, x, i, MovementType.Walking)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If

                    End If

                    ' /////////////////////////////////////////////
                    ' // This is used for npcs to attack targets //
                    ' /////////////////////////////////////////////
                    ' Make sure theres a npc with the map
                    If Map(mapNum).Npc(x) > 0 And MapNPC(mapNum).Npc(x).Num > 0 Then
                        target = MapNPC(mapNum).Npc(x).Target
                        targetTypes = MapNPC(mapNum).Npc(x).TargetType

                        ' Check if the npc can attack the targeted player player
                        If target > 0 Then

                            If targetTypes = TargetType.Player Then ' player

                                ' Is the target playing and on the same map?
                                If IsPlaying(target) And GetPlayerMap(target) = mapNum Then
                                    If IsPlaying(target) And GetPlayerMap(target) = mapNum Then
                                        If Random(1, 3) = 1 Then
                                            Dim skillnum As Integer = RandomNpcAttack(mapNum, x)
                                            If skillnum > 0 Then
                                                BufferNpcSkill(mapNum, x, skillnum)
                                            Else
                                                TryNpcAttackPlayer(x, target) ', Damage)
                                            End If
                                        Else
                                            TryNpcAttackPlayer(x, target)
                                        End If
                                    Else
                                        ' Player left map or game, set target to 0
                                        MapNPC(mapNum).Npc(x).Target = 0
                                        MapNPC(mapNum).Npc(x).TargetType = 0 ' clear

                                    End If
                                Else
                                    ' Player left map or game, set target to 0
                                    MapNPC(mapNum).Npc(x).Target = 0
                                    MapNPC(mapNum).Npc(x).TargetType = 0 ' clear
                                End If
                            ElseIf targetTypes = TargetType.Npc Then
                                If MapNPC(mapNum).Npc(target).Num > 0 Then ' npc exists
                                    'Can the npc attack the npc?
                                    If CanNpcAttackNpc(mapNum, x, target) Then
                                        damage = NPC(npcNum).Stat(StatType.Strength) - CLng(NPC(target).Stat(StatType.Luck))
                                        NpcAttackNpc(mapNum, x, target, damage)
                                    End If
                                Else
                                    ' npc is dead or non-existant
                                    MapNPC(mapNum).Npc(x).Target = 0
                                    MapNPC(mapNum).Npc(x).TargetType = 0 ' clear
                                End If
                            ElseIf targetTypes = TargetType.Pet Then
                                If IsPlaying(target) And GetPlayerMap(target) = mapNum And PetAlive(target) Then
                                    TryNpcAttackPet(x, target)
                                Else
                                    ' Player left map or game, set target to 0
                                    MapNPC(mapNum).Npc(x).Target = 0
                                    MapNPC(mapNum).Npc(x).TargetType = 0 ' clear
                                End If
                            End If
                        End If
                    End If

                    ' ////////////////////////////////////////////
                    ' // This is used for regenerating NPC's HP //
                    ' ////////////////////////////////////////////
                    ' Check to see if we want to regen some of the npc's hp
                    If MapNPC(mapNum).Npc(x).Num > 0 And tickCount > GiveNPCHPTimer + 10000 Then
                        If MapNPC(mapNum).Npc(x).Vital(VitalType.HP) > 0 Then
                            MapNPC(mapNum).Npc(x).Vital(VitalType.HP) = MapNPC(mapNum).Npc(x).Vital(VitalType.HP) + GetNpcVitalRegen(npcNum, VitalType.HP)

                            ' Check if they have more then they should and if so just set it to max
                            If MapNPC(mapNum).Npc(x).Vital(VitalType.HP) > GetNpcMaxVital(npcNum, VitalType.HP) Then
                                MapNPC(mapNum).Npc(x).Vital(VitalType.HP) = GetNpcMaxVital(npcNum, VitalType.HP)
                            End If
                        End If
                    End If

                    If MapNPC(mapNum).Npc(x).Num > 0 And tickCount > GiveNPCMPTimer + 10000 And MapNPC(mapNum).Npc(x).Vital(VitalType.MP) > 0 Then
                        MapNPC(mapNum).Npc(x).Vital(VitalType.MP) = MapNPC(mapNum).Npc(x).Vital(VitalType.MP) + GetNpcVitalRegen(npcNum, VitalType.MP)

                        ' Check if they have more then they should and if so just set it to max
                        If MapNPC(mapNum).Npc(x).Vital(VitalType.MP) > GetNpcMaxVital(npcNum, VitalType.MP) Then
                            MapNPC(mapNum).Npc(x).Vital(VitalType.MP) = GetNpcMaxVital(npcNum, VitalType.MP)
                        End If
                    End If

                    ' ////////////////////////////////////////////////////////
                    ' // This is used for checking if an NPC is dead or not //
                    ' ////////////////////////////////////////////////////////
                    ' Check if the npc is dead or not
                    If MapNPC(mapNum).Npc(x).Num > 0 And MapNPC(mapNum).Npc(x).Vital(VitalType.HP) < 0 And MapNPC(mapNum).Npc(x).SpawnWait > 0 Then
                        MapNPC(mapNum).Npc(x).Num = 0
                        MapNPC(mapNum).Npc(x).SpawnWait = GetTimeMs()
                        MapNPC(mapNum).Npc(x).Vital(VitalType.HP) = 0
                    End If

                    ' //////////////////////////////////////
                    ' // This is used for spawning an NPC //
                    ' //////////////////////////////////////
                    ' Check if we are supposed to spawn an npc or not
                    If MapNPC(mapNum).Npc(x).Num = 0 And Map(mapNum).Npc(x) > 0 And NPC(Map(mapNum).Npc(x)).SpawnSecs > 0 Then
                        If tickCount > MapNPC(mapNum).Npc(x).SpawnWait + (NPC(Map(mapNum).Npc(x)).SpawnSecs * 1000) Then
                            SpawnNpc(x, mapNum)
                        End If
                    End If
                Next
            End If

        Next

        ' Make sure we reset the timer for npc hp regeneration
        If GetTimeMs() > GiveNPCHPTimer + 10000 Then GiveNPCHPTimer = GetTimeMs()

        If GetTimeMs() > GiveNPCMPTimer + 10000 Then GiveNPCMPTimer = GetTimeMs()

        ' Make sure we reset the timer for door closing
        If GetTimeMs() > KeyTimer + 15000 Then KeyTimer = GetTimeMs()
    End Sub

    Function GetNpcVitalRegen(npcNum As Integer, vital As VitalType) As Integer
        Dim i As Integer

        GetNpcVitalRegen = 0

        'Prevent subscript out of range
        If npcNum <= 0 Or npcNum > MAX_NPCS Then
            Exit Function
        End If

        Select Case vital
            Case VitalType.HP
                i = NPC(npcNum).Stat(StatType.Vitality) \ 3

                If i < 0 Then i = 1
                GetNpcVitalRegen = i
            Case VitalType.MP
                i = NPC(npcNum).Stat(StatType.Intelligence) \ 3

                If i < 0 Then i = 1
                GetNpcVitalRegen = i
        End Select

    End Function

    Friend Function HandlePetSkill(index As Integer) As Boolean
        PetCastSkill(index, TempPlayer(index).PetskillBuffer.Skill, TempPlayer(index).PetskillBuffer.Target, TempPlayer(index).PetskillBuffer.TargetTypes, True)
        TempPlayer(index).PetskillBuffer.Skill = 0
        TempPlayer(index).PetskillBuffer.Timer = 0
        TempPlayer(index).PetskillBuffer.Target = 0
        TempPlayer(index).PetskillBuffer.TargetTypes = 0
        HandlePetSkill = True
    End Function

    Friend Function HandleClearStun(index As Integer) As Boolean
        TempPlayer(index).StunDuration = 0
        TempPlayer(index).StunTimer = 0
        SendStunned(index)
        HandleClearStun = True
    End Function

    Friend Function HandleClearPetStun(index As Integer) As Boolean
        TempPlayer(index).PetStunDuration = 0
        TempPlayer(index).PetStunTimer = 0
        HandleClearPetStun = True
    End Function

    Friend Function HandleStopPetRegen(index As Integer) As Boolean
        TempPlayer(index).PetstopRegen = False
        TempPlayer(index).PetstopRegenTimer = 0
        HandleStopPetRegen = True
    End Function

    Friend Function HandleCastSkill(index As Integer) As Boolean
        CastSkill(index, TempPlayer(index).SkillBuffer)
        TempPlayer(index).SkillBuffer = 0
        TempPlayer(index).SkillBufferTimer = 0
        HandleCastSkill = True
    End Function

    Friend Sub CastSkill(index As Integer, skillSlot As Integer)
        ' Set up some basic variables we'll be using.
        Dim skillId = GetPlayerSkill(index, skillSlot)

        ' Preventative checks
        If Not IsPlaying(index) Or skillSlot < 0 Or skillSlot > MAX_PLAYER_SKILLS Or Not HasSkill(index, skillId) Then Exit Sub

        ' Check if the player is able to cast the Skill.
        If GetPlayerVital(index, VitalType.MP) < Skill(skillId).MpCost Then
            PlayerMsg(index, "Not enough mana!", ColorType.BrightRed)
            Exit Sub
        ElseIf GetPlayerLevel(index) < Skill(skillId).LevelReq Then
            PlayerMsg(index, String.Format("You must be level {0} to use this skill.", Skill(skillId).LevelReq), ColorType.BrightRed)
            Exit Sub
        ElseIf GetPlayerAccess(index) < Skill(skillId).AccessReq Then
            PlayerMsg(index, "You must be an administrator to use this skill.", ColorType.BrightRed)
            Exit Sub
        ElseIf Not Skill(skillId).JobReq = 0 And GetPlayerJob(index) <> Skill(skillId).JobReq Then
            PlayerMsg(index, String.Format("Only {0} can use this skill.", CheckGrammar((Job(Skill(skillId).JobReq).Name.Trim()))), ColorType.BrightRed)
            Exit Sub
        ElseIf Skill(skillId).Range > 0 And Not IsTargetOnMap(index) Then
            Exit Sub
        ElseIf Skill(skillId).Range > 0 And Not IsInSkillRange(index, skillId) And Skill(skillId).IsProjectile = 0 Then
            PlayerMsg(index, "Target not in range.", ColorType.BrightRed)
            SendClearSkillBuffer(index)
            Exit Sub
        End If

        ' Determine what kind of Skill Type we're dealing with and move on to the appropriate methods.
        If Skill(skillId).IsProjectile = 1 Then
            PlayerFireProjectile(index, skillId)
        Else
            If Skill(skillId).Range = 0 And Not Skill(skillId).IsAoE Then HandleSelfCastSkill(index, skillId)
            If Skill(skillId).Range = 0 And Skill(skillId).IsAoE Then HandleSelfCastAoESkill(index, skillId)
            If Skill(skillId).Range > 0 And Skill(skillId).IsAoE Then HandleTargetedAoESkill(index, skillId)
            If Skill(skillId).Range > 0 And Not Skill(skillId).IsAoE Then HandleTargetedSkill(index, skillId)
        End If

        ' Do everything we need to do at the end of the cast.
        FinalizeCast(index, GetPlayerSkill(index, skillId), Skill(skillId).MpCost)
    End Sub

    Private Sub HandleSelfCastAoESkill(index As Integer, skillId As Integer)

        ' Set up some variables we'll definitely be using.
        Dim centerX = GetPlayerX(index)
        Dim centerY = GetPlayerY(index)

        ' Determine what kind of Skill we're dealing with and process it.
        Select Case Skill(skillId).Type
            Case SkillType.DamageHp, SkillType.DamageMp, SkillType.HealHp, SkillType.HealMp
                HandleAoE(index, skillId, centerX, centerY)

            Case Else
                Throw New NotImplementedException()
        End Select

    End Sub

    Private Sub HandleTargetedAoESkill(index As Integer, skillId As Integer)

        ' Set up some variables we'll definitely be using.
        Dim centerX As Integer
        Dim centerY As Integer
        Select Case TempPlayer(index).TargetType
            Case TargetType.Npc
                centerX = MapNPC(GetPlayerMap(index)).Npc(TempPlayer(index).Target).X
                centerY = MapNPC(GetPlayerMap(index)).Npc(TempPlayer(index).Target).Y

            Case TargetType.Player
                centerX = GetPlayerX(TempPlayer(index).Target)
                centerY = GetPlayerY(TempPlayer(index).Target)

            Case Else
                Throw New NotImplementedException()

        End Select

        ' Determine what kind of Skill we're dealing with and process it.
        Select Case Skill(skillId).Type
            Case SkillType.HealMp, SkillType.DamageHp, SkillType.DamageMp, SkillType.HealHp
                HandleAoE(index, skillId, centerX, centerY)

            Case Else
                Throw New NotImplementedException()
        End Select
    End Sub

    Private Sub HandleSelfCastSkill(index As Integer, skillId As Integer)
        ' Determine what kind of Skill we're dealing with and process it.
        Select Case Skill(skillId).Type
            Case SkillType.HealHp
                SkillPlayer_Effect(VitalType.HP, True, index, Skill(skillId).Vital, skillId)
            Case SkillType.HealMp
                SkillPlayer_Effect(VitalType.MP, True, index, Skill(skillId).Vital, skillId)
            Case SkillType.Warp
                SendAnimation(GetPlayerMap(index), Skill(skillId).SkillAnim, 0, 0, TargetType.Player, index)
                PlayerWarp(index, Skill(skillId).Map, Skill(skillId).X, Skill(skillId).Y)
        End Select

        ' Play our animation.
        SendAnimation(GetPlayerMap(index), Skill(skillId).SkillAnim, 0, 0, TargetType.Player, index)
    End Sub

    Private Sub HandleTargetedSkill(index As Integer, skillId As Integer)
        ' Set up some variables we'll definitely be using.
        Dim vital As VitalType
        Dim dealsDamage As Boolean
        Dim amount = Skill(skillId).Vital
        Dim target = TempPlayer(index).Target

        ' Determine what vital we need to adjust and how.
        Select Case Skill(skillId).Type
            Case SkillType.DamageHp
                vital = VitalType.HP
                dealsDamage = True

            Case SkillType.DamageMp
                vital = VitalType.MP
                dealsDamage = True

            Case SkillType.HealHp
                vital = VitalType.HP
                dealsDamage = False

            Case SkillType.HealMp
                vital = VitalType.MP
                dealsDamage = False

            Case Else
                Throw New NotImplementedException
        End Select

        Select Case TempPlayer(index).TargetType
            Case TargetType.Npc
                ' Deal with damaging abilities.
                If dealsDamage And CanPlayerAttackNpc(index, target, True) Then SkillNpc_Effect(vital, False, target, amount, skillId, GetPlayerMap(index))

                ' Deal with healing abilities
                If Not dealsDamage Then SkillNpc_Effect(vital, True, target, amount, skillId, GetPlayerMap(index))

                ' Handle our NPC death if it kills them
                If IsNpcDead(GetPlayerMap(index), TempPlayer(index).Target) Then
                    HandlePlayerKillNpc(GetPlayerMap(index), index, TempPlayer(index).Target)
                End If

            Case TargetType.Player

                ' Deal with damaging abilities.
                If dealsDamage And CanPlayerAttackPlayer(index, target, True) Then SkillPlayer_Effect(vital, False, target, amount, skillId)

                ' Deal with healing abilities
                If Not dealsDamage Then SkillPlayer_Effect(vital, True, target, amount, skillId)

                If IsPlayerDead(target) Then
                    ' Actually kill the player.
                    OnDeath(target)

                    ' Handle PK stuff.
                    HandlePlayerKilledPK(index, target)
                End If
            Case Else
                Throw New NotImplementedException()

        End Select

        ' Play our animation.
        SendAnimation(GetPlayerMap(index), Skill(skillId).SkillAnim, 0, 0, TempPlayer(index).TargetType, target)
    End Sub

    Private Sub HandleAoE(index As Integer, skillId As Integer, x As Integer, y As Integer)
        ' Get some basic things set up.
        Dim map = GetPlayerMap(index)
        Dim range = Skill(skillId).Range
        Dim amount = Skill(skillId).Vital
        Dim vital As VitalType
        Dim dealsDamage As Boolean

        ' Determine what vital we need to adjust and how.
        Select Case Skill(skillId).Type
            Case SkillType.DamageHp
                vital = VitalType.HP
                dealsDamage = True

            Case SkillType.DamageMp
                vital = VitalType.MP
                dealsDamage = True

            Case SkillType.HealHp
                vital = VitalType.HP
                dealsDamage = False

            Case SkillType.HealMp
                vital = VitalType.MP
                dealsDamage = False

            Case Else
                Throw New NotImplementedException
        End Select

        ' Loop through all online players on the current map.
        For Each id In TempPlayer.Where(Function(p) p.InGame).Select(Function(p, i) i + 1).Where(Function(i) GetPlayerMap(i) = map And i <> index).ToArray()
            If IsInRange(range, x, y, GetPlayerX(id), GetPlayerY(id)) Then

                ' Deal with damaging abilities.
                If dealsDamage And CanPlayerAttackPlayer(index, id, True) Then SkillPlayer_Effect(vital, False, id, amount, skillId)

                ' Deal with healing abilities
                If Not dealsDamage Then SkillPlayer_Effect(vital, True, id, amount, skillId)

                ' Send our animation to the map.
                SendAnimation(map, Skill(skillId).SkillAnim, 0, 0, TargetType.Player, id)

                If IsPlayerDead(id) Then
                    ' Actually kill the player.
                    OnDeath(id)

                    ' Handle PK stuff.
                    HandlePlayerKilledPK(index, id)
                End If
            End If
        Next

        ' Loop through all the NPCs on this map
        For Each id In MapNPC(map).Npc.Where(Function(n) n.Num > 0 And n.Vital(VitalType.HP) > 0).Select(Function(n, i) i + 1).ToArray()
            If IsInRange(range, x, y, MapNPC(map).Npc(id).X, MapNPC(map).Npc(id).Y) Then

                ' Deal with damaging abilities.
                If dealsDamage And CanPlayerAttackNpc(index, id, True) Then SkillNpc_Effect(vital, False, id, amount, skillId, map)

                ' Deal with healing abilities
                If Not dealsDamage Then SkillNpc_Effect(vital, True, id, amount, skillId, map)

                ' Send our animation to the map.
                SendAnimation(map, Skill(skillId).SkillAnim, 0, 0, TargetType.Npc, id)

                ' Handle our NPC death if it kills them
                If IsNpcDead(map, id) Then
                    HandlePlayerKillNpc(map, index, id)
                End If
            End If
        Next
    End Sub

    Private Sub FinalizeCast(index As Integer, skillSlot As Integer, skillCost As Integer)
        SetPlayerVital(index, VitalType.MP, GetPlayerVital(index, VitalType.MP) - skillCost)
        SendVital(index, VitalType.MP)
        TempPlayer(index).SkillCd(skillSlot) = GetTimeMs() + (Skill(skillSlot).CdTime * 1000)
        SendCooldown(index, skillSlot)
    End Sub

    Private Function IsTargetOnMap(index As Integer) As Boolean
        If TempPlayer(index).TargetType = TargetType.Player Then
            If GetPlayerMap(TempPlayer(index).Target) = GetPlayerMap(index) Then IsTargetOnMap = True
        ElseIf TempPlayer(index).TargetType = TargetType.Npc Then
            If TempPlayer(index).Target > 0 And TempPlayer(index).Target <= MAX_MAP_NPCS And MapNPC(GetPlayerMap(index)).Npc(TempPlayer(index).Target).Vital(VitalType.HP) > 0 Then IsTargetOnMap = True
        End If
    End Function

    Private Function IsInSkillRange(index As Integer, SkillId As Integer) As Boolean
        Dim targetX As Integer, targetY As Integer

        If TempPlayer(index).TargetType = TargetType.Player Then
            targetX = GetPlayerX(TempPlayer(index).Target)
            targetY = GetPlayerY(TempPlayer(index).Target)
        ElseIf TempPlayer(index).TargetType = TargetType.Npc Then
            targetX = MapNPC(GetPlayerMap(index)).Npc(TempPlayer(index).Target).X
            targetY = MapNPC(GetPlayerMap(index)).Npc(TempPlayer(index).Target).Y
        End If

        IsInSkillRange = IsInRange(Skill(SkillId).Range, GetPlayerX(index), GetPlayerY(index), targetX, targetY)
    End Function

    Friend Sub CastNpcSkill(npcNum As Integer, mapNum As Integer, skillslot As Integer)
        Dim skillnum As Integer, mpCost As Integer
        Dim vital As Integer, didCast As Boolean
        Dim i As Integer
        Dim aoe As Integer, range As Integer, vitalType As Byte
        Dim increment As Boolean, x As Integer, y As Integer

        Dim targetType As Byte
        Dim target As Integer
        Dim skillCastType As Integer

        didCast = False

        ' Prevent subscript out of range
        If skillslot < 0 Or skillslot > MAX_NPC_SKILLS Then Exit Sub

        skillnum = GetNpcSkill(MapNPC(mapNum).Npc(npcNum).Num, skillslot)

        mpCost = Skill(skillnum).MpCost

        ' Check if they have enough MP
        If MapNPC(mapNum).Npc(npcNum).Vital(Core.VitalType.MP) < mpCost Then Exit Sub

        ' find out what kind of skill it is! self cast, target or AOE
        If Skill(skillnum).IsProjectile = 1 Then
            skillCastType = 4 ' Projectile
        ElseIf Skill(skillnum).Range > 0 Then
            ' ranged attack, single target or aoe?
            If Not Skill(skillnum).IsAoE Then
                skillCastType = 2 ' targetted
            Else
                skillCastType = 3 ' targetted aoe
            End If
        Else
            If Not Skill(skillnum).IsAoE Then
                skillCastType = 0 ' self-cast
            Else
                skillCastType = 1 ' self-cast AoE
            End If
        End If

        ' set the Core.VitalType
        vital = Skill(skillnum).Vital
        aoe = Skill(skillnum).AoE
        range = Skill(skillnum).Range

        Select Case skillCastType
            Case 0 ' self-cast target
                'Select Case Skill(skillnum).Type
                '    Case SkillType.HEALHP
                '        SkillPlayer_Effect(VitalType.HP, True, NpcNum, Vital, skillnum)
                '        DidCast = True
                '    Case SkillType.HEALMP
                '        SkillPlayer_Effect(VitalType.MP, True, NpcNum, Vital, skillnum)
                '        DidCast = True
                '    Case SkillType.WARP
                '        SendAnimation(MapNum, Skill(skillnum).SkillAnim, 0, 0, TargetType.PLAYER, NpcNum)
                '        PlayerWarp(NpcNum, Skill(skillnum).Map, Skill(skillnum).x, Skill(skillnum).y)
                '        SendAnimation(GetPlayerMap(NpcNum), Skill(skillnum).SkillAnim, 0, 0, TargetType.PLAYER, NpcNum)
                '        DidCast = True
                'End Select

            Case 1, 3 ' self-cast AOE & targetted AOE
                If skillCastType = 1 Then
                    x = MapNPC(mapNum).Npc(npcNum).X
                    y = MapNPC(mapNum).Npc(npcNum).Y
                ElseIf skillCastType = 3 Then
                    targetType = MapNPC(mapNum).Npc(npcNum).TargetType
                    target = MapNPC(mapNum).Npc(npcNum).Target

                    If targetType = 0 Then Exit Sub
                    If target = 0 Then Exit Sub

                    If targetType = Core.TargetType.Player Then
                        x = GetPlayerX(target)
                        y = GetPlayerY(target)
                    Else
                        x = MapNPC(mapNum).Npc(target).X
                        y = MapNPC(mapNum).Npc(target).Y
                    End If

                    If Not IsInRange(range, x, y, GetPlayerX(npcNum), GetPlayerY(npcNum)) Then
                        Exit Sub
                    End If
                End If
                Select Case Skill(skillnum).Type
                    Case SkillType.DamageHp
                        didCast = True
                        For i = 1 To Socket.HighIndex()
                            If IsPlaying(i) Then
                                If GetPlayerMap(i) = mapNum Then
                                    If IsInRange(aoe, x, y, GetPlayerX(i), GetPlayerY(i)) Then
                                        If CanNpcAttackPlayer(npcNum, i) Then
                                            SendAnimation(mapNum, Skill(skillnum).SkillAnim, 0, 0, Core.TargetType.Player, i)
                                            PlayerMsg(i, Trim(NPC(MapNPC(mapNum).Npc(npcNum).Num).Name) & " uses " & Trim(Skill(skillnum).Name) & "!", ColorType.Yellow)
                                            SkillPlayer_Effect(Core.VitalType.HP, False, i, vital, skillnum)
                                        End If
                                    End If
                                End If
                            End If
                        Next

                        For i = 1 To MAX_MAP_NPCS
                            If MapNPC(mapNum).Npc(i).Num > 0 Then
                                If MapNPC(mapNum).Npc(i).Vital(Core.VitalType.HP) > 0 Then
                                    If IsInRange(aoe, x, y, MapNPC(mapNum).Npc(i).X, MapNPC(mapNum).Npc(i).Y) Then
                                        If CanPlayerAttackNpc(npcNum, i, True) Then
                                            SendAnimation(mapNum, Skill(skillnum).SkillAnim, 0, 0, Core.TargetType.Npc, i)
                                            SkillNpc_Effect(Core.VitalType.HP, False, i, vital, skillnum, mapNum)
                                            If Skill(skillnum).KnockBack = 1 Then
                                                KnockBackNpc(npcNum, target, skillnum)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    Case SkillType.HealHp, SkillType.HealMp, SkillType.DamageMp
                        If Skill(skillnum).Type = SkillType.HealHp Then
                            vital = Core.VitalType.HP
                            increment = True
                        ElseIf Skill(skillnum).Type = SkillType.HealMp Then
                            vital = Core.VitalType.MP
                            increment = True
                        ElseIf Skill(skillnum).Type = SkillType.DamageMp Then
                            vital = Core.VitalType.MP
                            increment = False
                        End If

                        didCast = True
                        For i = 1 To Socket.HighIndex()
                            If IsPlaying(i) And GetPlayerMap(i) = GetPlayerMap(npcNum) Then
                                If IsInRange(aoe, x, y, GetPlayerX(i), GetPlayerY(i)) Then
                                    SkillPlayer_Effect(vital, increment, i, vital, skillnum)
                                End If
                            End If
                        Next

                        For i = 1 To MAX_MAP_NPCS
                            If MapNPC(mapNum).Npc(i).Num > 0 And MapNPC(mapNum).Npc(i).Vital(Core.VitalType.HP) > 0 Then
                                If IsInRange(aoe, x, y, MapNPC(mapNum).Npc(i).X, MapNPC(mapNum).Npc(i).Y) Then
                                    SkillNpc_Effect(vital, increment, i, vital, skillnum, mapNum)
                                End If
                            End If
                        Next
                End Select

            Case 2 ' targetted

                targetType = MapNPC(mapNum).Npc(npcNum).TargetType
                target = MapNPC(mapNum).Npc(npcNum).Target

                If targetType = 0 Or target = 0 Then Exit Sub

                If MapNPC(mapNum).Npc(npcNum).TargetType = Core.TargetType.Player Then
                    x = GetPlayerX(target)
                    y = GetPlayerY(target)
                Else
                    x = MapNPC(mapNum).Npc(target).X
                    y = MapNPC(mapNum).Npc(target).Y
                End If

                If Not IsInRange(range, MapNPC(mapNum).Npc(npcNum).X, MapNPC(mapNum).Npc(npcNum).Y, x, y) Then Exit Sub

                Select Case Skill(skillnum).Type
                    Case SkillType.DamageHp
                        If MapNPC(mapNum).Npc(npcNum).TargetType = Core.TargetType.Player Then
                            If CanNpcAttackPlayer(npcNum, target) And vital > 0 Then
                                SendAnimation(mapNum, Skill(skillnum).SkillAnim, 0, 0, Core.TargetType.Player, target)
                                PlayerMsg(target, Trim(NPC(MapNPC(mapNum).Npc(npcNum).Num).Name) & " uses " & Trim(Skill(skillnum).Name) & "!", ColorType.Yellow)
                                SkillPlayer_Effect(Core.VitalType.HP, False, target, vital, skillnum)
                                didCast = True
                            End If
                        Else
                            If CanPlayerAttackNpc(npcNum, target, True) And vital > 0 Then
                                SendAnimation(mapNum, Skill(skillnum).SkillAnim, 0, 0, Core.TargetType.Npc, target)
                                SkillNpc_Effect(Core.VitalType.HP, False, i, vital, skillnum, mapNum)

                                If Skill(skillnum).KnockBack = 1 Then
                                    KnockBackNpc(npcNum, target, skillnum)
                                End If
                                didCast = True
                            End If
                        End If

                    Case SkillType.DamageMp, SkillType.HealMp, SkillType.HealHp
                        If Skill(skillnum).Type = SkillType.DamageMp Then
                            vital = Core.VitalType.MP
                            increment = False
                        ElseIf Skill(skillnum).Type = SkillType.HealMp Then
                            vital = Core.VitalType.MP
                            increment = True
                        ElseIf Skill(skillnum).Type = SkillType.HealHp Then
                            vital = Core.VitalType.HP
                            increment = True
                        End If

                        If TempPlayer(npcNum).TargetType = Core.TargetType.Player Then
                            If Skill(skillnum).Type = SkillType.DamageMp Then
                                If CanPlayerAttackPlayer(npcNum, target, True) Then
                                    SkillPlayer_Effect(vital, increment, target, vital, skillnum)
                                End If
                            Else
                                SkillPlayer_Effect(vital, increment, target, vital, skillnum)
                            End If
                        Else
                            If Skill(skillnum).Type = SkillType.DamageMp Then
                                If CanPlayerAttackNpc(npcNum, target, True) Then
                                    SkillNpc_Effect(vital, increment, target, vital, skillnum, mapNum)
                                End If
                            Else
                                SkillNpc_Effect(vital, increment, target, vital, skillnum, mapNum)
                            End If
                        End If
                End Select
            Case 4 ' Projectile
                PlayerFireProjectile(npcNum, skillnum)

                didCast = True
        End Select

        If didCast Then
            MapNPC(mapNum).Npc(npcNum).Vital(Core.VitalType.MP) = MapNPC(mapNum).Npc(npcNum).Vital(Core.VitalType.MP) - mpCost
            SendMapNpcVitals(mapNum, npcNum)
            MapNPC(mapNum).Npc(npcNum).SkillCd(skillslot) = GetTimeMs() + (Skill(skillnum).CdTime * 1000)
        End If
    End Sub

    Friend Sub SkillPlayer_Effect(vital As Byte, increment As Boolean, index As Integer, damage As Integer, skillnum As Integer)
        Dim sSymbol As String
        Dim Color As Integer

        If damage > 0 Then
            ' Calculate for Magic Resistance.
            damage -= ((GetPlayerStat(index, StatType.Spirit) * 2) + (GetPlayerLevel(index) * 3))

            If increment Then
                sSymbol = "+"
                If vital = VitalType.HP Then Color = ColorType.BrightGreen
                If vital = VitalType.MP Then Color = ColorType.BrightBlue
            Else
                sSymbol = "-"
                Color = ColorType.BrightRed
            End If

            ' Deal with stun effects.
            If Skill(skillnum).StunDuration > 0 Then StunPlayer(index, skillnum)

            SendActionMsg(GetPlayerMap(index), sSymbol & damage, Color, ActionMsgType.Scroll, GetPlayerX(index) * 32, GetPlayerY(index) * 32)
            If increment Then SetPlayerVital(index, vital, GetPlayerVital(index, vital) + damage)
            If Not increment Then SetPlayerVital(index, vital, GetPlayerVital(index, vital) - damage)
            SendVital(index, vital)
        End If
    End Sub

    Friend Sub SkillNpc_Effect(vital As Byte, increment As Boolean, index As Integer, damage As Integer, skillnum As Integer, mapNum As Integer)
        Dim sSymbol As String
        Dim color As Integer

        If index <= 0 Or index > MAX_MAP_NPCS Or damage <= 0 Or MapNPC(mapNum).Npc(index).Vital(vital) <= 0 Then Exit Sub

        If damage > 0 Then
            If increment Then
                sSymbol = "+"
                If vital = VitalType.HP Then color = ColorType.BrightGreen
                If vital = VitalType.MP Then color = ColorType.BrightBlue
            Else
                sSymbol = "-"
                color = ColorType.BrightRed
            End If

            ' Deal with Stun and Knockback effects.
            If Skill(skillnum).KnockBack = 1 Then KnockBackNpc(index, index, skillnum)
            If Skill(skillnum).StunDuration > 0 Then StunNPC(index, mapNum, skillnum)

            SendActionMsg(mapNum, sSymbol & damage, color, ActionMsgType.Scroll, MapNPC(mapNum).Npc(index).X * 32, MapNPC(mapNum).Npc(index).Y * 32)
            If increment Then MapNPC(mapNum).Npc(index).Vital(vital) = MapNPC(mapNum).Npc(index).Vital(vital) + damage
            If Not increment Then MapNPC(mapNum).Npc(index).Vital(vital) = MapNPC(mapNum).Npc(index).Vital(vital) - damage
            SendMapNpcVitals(mapNum, index)
        End If
    End Sub

End Module