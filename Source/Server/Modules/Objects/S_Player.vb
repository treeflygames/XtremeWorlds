Imports System.Linq
Imports Mirage.Sharp.Asfw
Imports Core

Module S_Player

#Region "PlayerCombat"

    Function CanPlayerAttackPlayer(Attacker As Integer, Victim As Integer, Optional IsSkill As Boolean = False) As Boolean

        If Not IsSkill Then
            ' Check attack timer
            If GetPlayerEquipment(Attacker, Core.EquipmentType.Weapon) > 0 Then
                If GetTimeMs() < TempPlayer(Attacker).AttackTimer + Item(GetPlayerEquipment(Attacker, EquipmentType.Weapon)).Speed Then Exit Function
            Else
                If GetTimeMs() < TempPlayer(Attacker).AttackTimer + 1000 Then Exit Function
            End If
        End If

        ' Check for subscript out of range
        If Not IsPlaying(Victim) Then Exit Function

        ' Make sure they are on the same map
        If Not GetPlayerMap(Attacker) = GetPlayerMap(Victim) Then Exit Function

        ' Make sure we dont attack the player if they are switching maps
        If TempPlayer(Victim).GettingMap = True Then Exit Function

        If Not IsSkill Then
            ' Check if at same coordinates
            Select Case GetPlayerDir(Attacker)
                Case DirectionType.Up

                    If Not ((GetPlayerY(Victim) + 1 = GetPlayerY(Attacker)) And (GetPlayerX(Victim) = GetPlayerX(Attacker))) Then Exit Function
                Case DirectionType.Down

                    If Not ((GetPlayerY(Victim) - 1 = GetPlayerY(Attacker)) And (GetPlayerX(Victim) = GetPlayerX(Attacker))) Then Exit Function
                Case DirectionType.Left

                    If Not ((GetPlayerY(Victim) = GetPlayerY(Attacker)) And (GetPlayerX(Victim) + 1 = GetPlayerX(Attacker))) Then Exit Function
                Case DirectionType.Right

                    If Not ((GetPlayerY(Victim) = GetPlayerY(Attacker)) And (GetPlayerX(Victim) - 1 = GetPlayerX(Attacker))) Then Exit Function
                Case Else
                    Exit Function
            End Select
        End If

        ' Check if map is attackable
        If Map(GetPlayerMap(attacker)).Moral > 0 Then
            If Not Moral(Map(GetPlayerMap(Attacker)).Moral).CanPK Then
                If GetPlayerPK(Victim) = False Then
                    PlayerMsg(Attacker, "This is a safe zone!", ColorType.BrightRed)
                    Exit Function
                End If
            End If
        End If

        ' Make sure they have more then 0 hp
        If GetPlayerVital(Victim, VitalType.HP) <= 0 Then Exit Function

        ' Check to make sure that they dont have access
        If GetPlayerAccess(Attacker) > AdminType.Moderator Then
            PlayerMsg(Attacker, "You cannot attack any player for thou art an admin!", ColorType.BrightRed)
            Exit Function
        End If

        ' Check to make sure the victim isn't an admin
        If GetPlayerAccess(Victim) > AdminType.Moderator Then
            PlayerMsg(Attacker, "You cannot attack " & GetPlayerName(Victim) & "!", ColorType.BrightRed)
            Exit Function
        End If

        ' Make sure attacker is high enough level
        If GetPlayerLevel(Attacker) < 10 Then
            PlayerMsg(Attacker, "You are below level 10, you cannot attack another player yet!", ColorType.BrightRed)
            Exit Function
        End If

        ' Make sure victim is high enough level
        If GetPlayerLevel(Victim) < 10 Then
            PlayerMsg(Attacker, GetPlayerName(Victim) & " is below level 10, you cannot attack this player yet!", ColorType.BrightRed)
            Exit Function
        End If

        CanPlayerAttackPlayer = True
    End Function

    Function CanPlayerBlockHit(index As Integer) As Boolean
        Dim i As Integer
        Dim n As Integer
        Dim ShieldSlot As Integer
        ShieldSlot = GetPlayerEquipment(index, EquipmentType.Shield)

        CanPlayerBlockHit = False

        If ShieldSlot > 0 Then
            n = Int(Rnd() * 2)

            If n = 1 Then
                i = (GetPlayerStat(index, StatType.Luck) \ 2) + (GetPlayerLevel(index) \ 2)
                n = Int(Rnd() * 100) + 1

                If n <= i Then
                    CanPlayerBlockHit = True
                End If
            End If
        End If

    End Function

    Function CanPlayerCriticalHit(index As Integer) As Boolean
        On Error Resume Next
        Dim i As Integer
        Dim n As Integer

        If GetPlayerEquipment(index, EquipmentType.Weapon) > 0 Then
            n = (Rnd()) * 2

            If n = 1 Then
                i = (GetPlayerStat(index, StatType.Strength) \ 2) + (GetPlayerLevel(index) \ 2)
                n = Int(Rnd() * 100) + 1

                If n <= i Then
                    CanPlayerCriticalHit = True
                End If
            End If
        End If

    End Function

    Function GetPlayerDamage(index As Integer) As Integer
        Dim weaponNum As Integer

        GetPlayerDamage = 0

        ' Check for subscript out of range
        If IsPlaying(index) = False Or index < 0 Or index > MAX_PLAYERS Then
            Exit Function
        End If

        If GetPlayerEquipment(index, EquipmentType.Weapon) > 0 Then
            weaponNum = GetPlayerEquipment(index, EquipmentType.Weapon)
            GetPlayerDamage = (GetPlayerStat(index, StatType.Strength) * 2) + (Item(weaponNum).Data2 * 2) + (GetPlayerLevel(index) * 3) + Random(0, 20)
        Else
            GetPlayerDamage = (GetPlayerStat(index, StatType.Strength) * 2) + (GetPlayerLevel(index) * 3) + Random(0, 20)
        End If

    End Function

    Function GetPlayerProtection(index As Integer) As Integer
        Dim Armor As Integer, Helm As Integer, Shoes As Integer, Gloves As Integer
        GetPlayerProtection = 0

        ' Check for subscript out of range
        If IsPlaying(index) = False Or index < 0 Or index > MAX_PLAYERS Then
            Exit Function
        End If

        Armor = GetPlayerEquipment(index, EquipmentType.Armor)
        Helm = GetPlayerEquipment(index, EquipmentType.Helmet)
        Shoes = GetPlayerEquipment(index, EquipmentType.Shoes)
        Gloves = GetPlayerEquipment(index, EquipmentType.Gloves)
        GetPlayerProtection = (GetPlayerStat(index, StatType.Luck) \ 5)

        If Armor > 0 Then
            GetPlayerProtection += Item(Armor).Data2
        End If

        If Helm > 0 Then
            GetPlayerProtection += Item(Helm).Data2
        End If

        If Shoes > 0 Then
            GetPlayerProtection += Item(Shoes).Data2
        End If

        If Gloves > 0 Then
            GetPlayerProtection += Item(Gloves).Data2
        End If

    End Function

    Sub AttackPlayer(attacker As Integer, victim As Integer, damage As Integer, Optional skillnum As Integer = 0, Optional npcnum As Integer = 0)
        Dim exp As Integer, mapNum As Integer
        Dim n As Integer
        Dim buffer As ByteStream

        If npcnum = 0 Then
            ' Check for subscript out of range
            If IsPlaying(attacker) = False Or IsPlaying(victim) = False Or damage < 0 Then
                Exit Sub
            End If

            ' Check for weapon
            If GetPlayerEquipment(attacker, EquipmentType.Weapon) > 0 Then
                n = GetPlayerEquipment(attacker, EquipmentType.Weapon)
            End If

            ' Send this packet so they can see the person attacking
            buffer = New ByteStream(4)
            buffer.WriteInt32(ServerPackets.SAttack)
            buffer.WriteInt32(attacker)
            SendDataToMapBut(attacker, GetPlayerMap(attacker), buffer.Data, buffer.Head)
            buffer.Dispose()

            If damage >= GetPlayerVital(victim, VitalType.HP) Then
                SendActionMsg(GetPlayerMap(victim), "-" & damage, ColorType.BrightRed, 1, (GetPlayerX(victim) * 32), (GetPlayerY(victim) * 32))

                ' Player is dead
                GlobalMsg(GetPlayerName(victim) & " has been killed by " & GetPlayerName(attacker))
                
                If Map(GetPlayerMap(victim)).Moral > 0 Then
                    If Moral(Map(GetPlayerMap(victim)).Moral).LoseExp Then
                        ' Calculate exp to give attacker
                        exp = Math.Round(GetPlayerExp(victim) \ 3)

                        ' Make sure we dont get less then 0
                        If exp < 0 Then
                            exp = 0
                        End If

                        If exp = 0 Then
                            PlayerMsg(victim, "You lost no exp.", ColorType.BrightGreen)
                            PlayerMsg(attacker, "You received no exp.", ColorType.BrightRed)
                        Else
                            SetPlayerExp(victim, GetPlayerExp(victim) - exp)
                            SendExp(victim)
                            PlayerMsg(victim, "You lost " & exp & " exp.", ColorType.BrightRed)
                            SetPlayerExp(attacker, GetPlayerExp(attacker) + exp)
                            SendExp(attacker)
                            PlayerMsg(attacker, "You received " & exp & " exp.", ColorType.BrightGreen)
                        End If

                        ' Check for a level up
                        CheckPlayerLevelUp(attacker)
                    End If
                End If

                ' Check if target is player who died and if so set target to 0
                If TempPlayer(attacker).TargetType = TargetType.Player Then
                    If TempPlayer(attacker).Target = victim Then
                        TempPlayer(attacker).Target = 0
                        TempPlayer(attacker).TargetType = 0
                    End If
                End If

                If GetPlayerPK(victim) = False Then
                    If GetPlayerPK(attacker) = False Then
                        SetPlayerPK(attacker, True)
                        SendPlayerData(attacker)
                        GlobalMsg(GetPlayerName(attacker) & " has been deemed a Player Killer!!!")
                    End If
                Else
                    GlobalMsg(GetPlayerName(victim) & " has paid the price for being a Player Killer!!!")
                End If

                OnDeath(victim)
            Else
                ' Player not dead, just do the damage
                SetPlayerVital(victim, VitalType.HP, GetPlayerVital(victim, VitalType.HP) - damage)
                SendVital(victim, VitalType.HP)
                SendActionMsg(GetPlayerMap(victim), "-" & damage, ColorType.BrightRed, 1, (GetPlayerX(victim) * 32), (GetPlayerY(victim) * 32))

                'if a stunning skill, stun the player
                If skillnum > 0 Then
                    If Skill(skillnum).StunDuration > 0 Then StunPlayer(victim, skillnum)
                End If
            End If

            ' Reset attack timer
            TempPlayer(attacker).AttackTimer = GetTimeMs()
        Else ' npc to player
            ' Check for subscript out of range
            If IsPlaying(victim) = False Or damage < 0 Then Exit Sub

            mapNum = GetPlayerMap(victim)

            ' Send this packet so they can see the person attacking
            buffer = New ByteStream(4)
            buffer.WriteInt32(ServerPackets.SNpcAttack)
            buffer.WriteInt32(attacker)
            SendDataToMap(mapNum, buffer.Data, buffer.Head)
            buffer.Dispose()

            If damage >= GetPlayerVital(victim, VitalType.HP) Then

                SendActionMsg(mapNum, "-" & damage, ColorType.BrightRed, 1, (GetPlayerX(victim) * 32), (GetPlayerY(victim) * 32))

                ' Player is dead
                GlobalMsg(GetPlayerName(victim) & " has been killed by " & NPC(MapNPC(mapNum).Npc(attacker).Num).Name)

                ' Check if target is player who died and if so set target to 0
                If TempPlayer(attacker).TargetType = TargetType.Player Then
                    If TempPlayer(attacker).Target = victim Then
                        TempPlayer(attacker).Target = 0
                        TempPlayer(attacker).TargetType = 0
                    End If
                End If

                OnDeath(victim)
            Else
                ' Player not dead, just do the damage
                SetPlayerVital(victim, VitalType.HP, GetPlayerVital(victim, VitalType.HP) - damage)
                SendVital(victim, VitalType.HP)
                SendActionMsg(mapNum, "-" & damage, ColorType.BrightRed, 1, (GetPlayerX(victim) * 32), (GetPlayerY(victim) * 32))

                'if a stunning skill, stun the player
                If skillnum > 0 Then
                    If Skill(skillnum).StunDuration > 0 Then StunPlayer(victim, skillnum)
                End If
            End If

            ' Reset attack timer
            MapNPC(mapNum).Npc(attacker).AttackTimer = GetTimeMs()
        End If

    End Sub

    Friend Sub StunPlayer(index As Integer, skillnum As Integer)
        ' check if it's a stunning skill
        If Skill(skillnum).StunDuration > 0 Then
            ' set the values on index
            TempPlayer(index).StunDuration = Skill(skillnum).StunDuration
            TempPlayer(index).StunTimer = GetTimeMs()
            ' send it to the index
            SendStunned(index)
            ' tell him he's stunned
            PlayerMsg(index, "You have been stunned!", ColorType.Yellow)
        End If
    End Sub

    Function CanPlayerAttackNpc(Attacker As Integer, MapNpcNum As Integer, Optional IsSkill As Boolean = False) As Boolean
        Dim mapNum As Integer
        Dim NpcNum As Integer
        Dim atkX As Integer
        Dim atkY As Integer
        Dim attackspeed As Integer

        ' Check for subscript out of range
        If IsPlaying(Attacker) = False Or MapNpcnum <= 0 Or MapNpcNum > MAX_MAP_NPCS Then
            Exit Function
        End If

        ' Check for subscript out of range
        If MapNPC(GetPlayerMap(Attacker)).Npc(MapNpcNum).num <= 0 Then
            Exit Function
        End If

        mapNum = GetPlayerMap(Attacker)
        NpcNum = MapNPC(mapNum).Npc(MapNpcNum).Num

        ' Make sure the npc isn't already dead
        If MapNPC(mapNum).Npc(MapNpcNum).Vital(VitalType.HP) <= 0 Then
            Exit Function
        End If

        ' Make sure they are on the same map

        ' attack speed from weapon
        If GetPlayerEquipment(Attacker, EquipmentType.Weapon) > 0 Then
            attackspeed = Item(GetPlayerEquipment(Attacker, EquipmentType.Weapon)).Speed
        Else
            attackspeed = 1000
        End If

        If NpcNum > 0 And GetTimeMs() > TempPlayer(Attacker).AttackTimer + attackspeed Then
            ' exit out early
            If IsSkill Then
                If NPC(NpcNum).Behaviour <> NpcBehavior.Friendly And NPC(NpcNum).Behaviour <> NpcBehavior.ShopKeeper Then
                    CanPlayerAttackNpc = True
                    Exit Function
                End If
            End If

            ' Check if at same coordinates
            Select Case GetPlayerDir(Attacker)
                Case DirectionType.Up
                    atkX = GetPlayerX(Attacker)
                    atkY = GetPlayerY(Attacker) - 1
                Case DirectionType.Down
                    atkX = GetPlayerX(Attacker)
                    atkY = GetPlayerY(Attacker) + 1
                Case DirectionType.Left
                    atkX = GetPlayerX(Attacker) - 1
                    atkY = GetPlayerY(Attacker)
                Case DirectionType.Right
                    atkX = GetPlayerX(Attacker) + 1
                    atkY = GetPlayerY(Attacker)
            End Select

            If atkX = MapNPC(mapNum).Npc(MapNpcNum).X Then
                If atkY = MapNPC(mapNum).Npc(MapNpcNum).Y Then
                    If NPC(NpcNum).Behaviour <> NpcBehavior.Friendly And NPC(NpcNum).Behaviour <> NpcBehavior.ShopKeeper And NPC(NpcNum).Behaviour <> NpcBehavior.Quest Then
                        CanPlayerAttackNpc = True
                    Else
                        If Len(Trim$(NPC(NpcNum).AttackSay)) > 0 Then
                            PlayerMsg(Attacker, Trim$(NPC(NpcNum).Name) & ": " & Trim$(NPC(NpcNum).AttackSay), ColorType.Yellow)
                        End If
                    End If
                End If
            End If
        End If

    End Function

    Friend Sub StunNPC(index As Integer, mapNum As Integer, skillnum As Integer)
        ' check if it's a stunning skill
        If Skill(skillnum).StunDuration > 0 Then
            ' set the values on index
            MapNPC(mapNum).Npc(index).StunDuration = Skill(skillnum).StunDuration
            MapNPC(mapNum).Npc(index).StunTimer = GetTimeMs()
        End If
    End Sub

    Sub PlayerAttackNpc(Attacker As Integer, MapNpcNum As Integer, Damage As Integer)
        ' Check for subscript out of range
        If IsPlaying(Attacker) = False Or MapNpcNum <= 0 Or MapNpcNum > MAX_MAP_NPCS Or Damage <= 0 Then Exit Sub

        Dim MapNum = GetPlayerMap(Attacker)
        Dim NpcNum = MapNPC(MapNum).Npc(MapNpcNum).Num
        Dim Name = NPC(NpcNum).Name.Trim()

        ' Check for weapon
        Dim Weapon = 0
        If GetPlayerEquipment(Attacker, EquipmentType.Weapon) > 0 Then
            Weapon = GetPlayerEquipment(Attacker, EquipmentType.Weapon)
        End If

        ' Deal damage to our NPC.
        MapNPC(MapNum).Npc(MapNpcNum).Vital(VitalType.HP) = MapNPC(MapNum).Npc(MapNpcNum).Vital(VitalType.HP) - Damage

        ' Set the NPC target to the player so they can come after them.
        MapNPC(MapNum).Npc(MapNpcNum).TargetType = TargetType.Player
        MapNPC(MapNum).Npc(MapNpcNum).Target = Attacker

        ' Check for any mobs on the map with the Guard behaviour so they can come after our player.
        If NPC(MapNPC(MapNum).Npc(MapNpcNum).Num).Behaviour = NpcBehavior.Guard Then
            For Each Guard In MapNPC(MapNum).Npc.Where(Function(x) x.Num = MapNPC(MapNum).Npc(MapNpcNum).Num).Select(Function(x, y) y + 1).ToArray()
                MapNPC(MapNum).Npc(Guard).Target = Attacker
                MapNPC(MapNum).Npc(Guard).TargetType = TargetType.Player
            Next
        End If

        ' Send our general visual stuff.
        SendActionMsg(MapNum, "-" & Damage, ColorType.BrightRed, 1, (MapNPC(MapNum).Npc(MapNpcNum).X * 32), (MapNPC(MapNum).Npc(MapNpcNum).Y * 32))
        SendBlood(GetPlayerMap(Attacker), MapNPC(MapNum).Npc(MapNpcNum).X, MapNPC(MapNum).Npc(MapNpcNum).Y)
        SendPlayerAttack(Attacker)
        If Weapon > 0 Then
            SendAnimation(MapNum, Item(GetPlayerEquipment(Attacker, EquipmentType.Weapon)).Animation, 0, 0, TargetType.Npc, MapNpcNum)
        End If

        ' Reset our attack timer.
        TempPlayer(Attacker).AttackTimer = GetTimeMs()

        If Not IsNpcDead(MapNum, MapNpcNum) Then
            ' Check if our NPC has something to share with our player.
            If MapNPC(MapNum).Npc(MapNpcNum).Target = 0 Then
                If Len(Trim$(NPC(NpcNum).AttackSay)) > 0 Then
                    PlayerMsg(Attacker, String.Format("{0} says: '{1}'", NPC(NpcNum).Name.Trim(), NPC(NpcNum).AttackSay.Trim()), ColorType.Yellow)
                End If
            End If

            SendMapNpcTo(MapNum, MapNpcNum)
        Else
            HandlePlayerKillNpc(MapNum, Attacker, MapNpcNum)
        End If
    End Sub

    Function IsInRange(range As Integer, x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer) As Boolean
        Dim nVal As Integer
        IsInRange = False
        nVal = Math.Sqrt((x1 - x2) ^ 2 + (y1 - y2) ^ 2)
        If nVal <= range Then IsInRange = True
    End Function

    Friend Function CanPlayerDodge(index As Integer) As Boolean
        Dim rate As Integer, rndNum As Integer

        CanPlayerDodge = False

        rate = GetPlayerStat(index, StatType.Luck) / 4
        rndNum = Random(1, 100)

        If rndNum <= rate Then
            CanPlayerDodge = True
        End If

    End Function

    Friend Function CanPlayerParry(index As Integer) As Boolean
        Dim rate As Integer, rndNum As Integer

        CanPlayerParry = False

        rate = GetPlayerStat(index, StatType.Luck) / 6
        rndNum = Random(1, 100)

        If rndNum <= rate Then
            CanPlayerParry = True
        End If

    End Function

    Friend Sub TryPlayerAttackPlayer(Attacker As Integer, Victim As Integer)
        Dim mapNum As Integer
        Dim Damage As Integer, i As Integer, armor As Integer

        Damage = 0

        ' Can we attack the player?
        If CanPlayerAttackPlayer(Attacker, Victim) Then

            mapNum = GetPlayerMap(Attacker)

            ' check if NPC can avoid the attack
            If CanPlayerDodge(Victim) Then
                SendActionMsg(mapNum, "Dodge!", ColorType.Pink, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))
                Exit Sub
            End If

            If CanPlayerParry(Victim) Then
                SendActionMsg(mapNum, "Parry!", ColorType.Pink, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))
                Exit Sub
            End If

            ' Get the damage we can do
            Damage = GetPlayerDamage(Attacker)

            If CanPlayerBlockHit(Victim) Then
                SendActionMsg(mapNum, "Block!", ColorType.BrightCyan, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))
                Damage = 0
                Exit Sub
            Else

                For i = 1 To EquipmentType.Count - 1
                    If GetPlayerEquipment(Victim, i) > 0 Then
                        armor += Item(GetPlayerEquipment(Victim, i)).Data2
                    End If
                Next

                ' take away armour
                Damage -= (GetPlayerStat(Victim, StatType.Spirit) * 2) + (GetPlayerLevel(Victim) * 3) + armor

                ' * 1.5 if it's a crit!
                If CanPlayerCriticalHit(Attacker) Then
                    Damage *= 1.5
                    SendActionMsg(mapNum, "Critical!", ColorType.BrightCyan, 1, GetPlayerX(Attacker) * 32, GetPlayerY(Attacker) * 32)
                End If
            End If

            If Damage > 0 Then
                PlayerAttackPlayer(Attacker, Victim, Damage)
            Else
                PlayerMsg(Attacker, "Your attack does nothing.", ColorType.BrightRed)
            End If

        End If

    End Sub

    Sub PlayerAttackPlayer(Attacker As Integer, Victim As Integer, Damage As Integer)
        ' Check for subscript out of range
        If IsPlaying(Attacker) = False Or IsPlaying(Victim) = False Or Damage < 0 Then
            Exit Sub
        End If

        ' Check if our assailant has a weapon.
        Dim Weapon = 0
        If GetPlayerEquipment(Attacker, EquipmentType.Weapon) > 0 Then
            Weapon = GetPlayerEquipment(Attacker, EquipmentType.Weapon)
        End If

        ' Stop our player's regeneration abilities.
        TempPlayer(Attacker).StopRegen = True
        TempPlayer(Attacker).StopRegenTimer = GetTimeMs()

        ' Deal damage to our player.
        SetPlayerVital(Victim, VitalType.HP, GetPlayerVital(Victim, VitalType.HP) - Damage)

        ' Send all the visuals to our player.
        If Weapon > 0 Then
            SendAnimation(GetPlayerMap(Victim), Item(Weapon).Animation, 0, 0, TargetType.Player, Victim)
        End If
        SendActionMsg(GetPlayerMap(Victim), "-" & Damage, ColorType.BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32))
        SendBlood(GetPlayerMap(Victim), GetPlayerX(Victim), GetPlayerY(Victim))

        ' set the regen timer
        TempPlayer(Victim).StopRegen = True
        TempPlayer(Victim).StopRegenTimer = GetTimeMs()

        ' Reset attack timer
        TempPlayer(Attacker).AttackTimer = GetTimeMs()

        If Not IsPlayerDead(Victim) Then
            ' Send our player's new vitals to everyone that needs them.
            SendVital(Victim, VitalType.HP)
            If TempPlayer(Victim).InParty > 0 Then SendPartyVitals(TempPlayer(Victim).InParty, Victim)
        Else
            ' Handle our dead player.
            HandlePlayerKillPlayer(Attacker, Victim)
        End If
    End Sub

    Friend Sub TryPlayerAttackNpc(index As Integer, mapnpcnum As Integer)

        Dim npcnum As Integer

        Dim mapNum As Integer

        Dim Damage As Integer

        Damage = 0

        ' Can we attack the npc?
        If CanPlayerAttackNpc(index, mapnpcnum) Then
            mapNum = GetPlayerMap(index)
            npcnum = MapNPC(mapNum).Npc(mapnpcnum).Num

            ' check if NPC can avoid the attack
            If CanNpcDodge(npcnum) Then
                SendActionMsg(mapNum, "Dodge!", ColorType.Pink, 1, (MapNPC(mapNum).Npc(mapnpcnum).X * 32), (MapNPC(mapNum).Npc(mapnpcnum).Y * 32))
                Exit Sub
            End If

            If CanNpcParry(npcnum) Then
                SendActionMsg(mapNum, "Parry!", ColorType.Pink, 1, (MapNPC(mapNum).Npc(mapnpcnum).X * 32), (MapNPC(mapNum).Npc(mapnpcnum).Y * 32))
                Exit Sub
            End If

            ' Get the damage we can do
            Damage = GetPlayerDamage(index)

            If CanNpcBlock(npcnum) Then
                SendActionMsg(mapNum, "Block!", ColorType.BrightCyan, 1, (MapNPC(mapNum).Npc(mapnpcnum).X * 32), (MapNPC(mapNum).Npc(mapnpcnum).Y * 32))
                Damage = 0
                Exit Sub
            Else

                Damage -= ((NPC(npcnum).Stat(StatType.Spirit) * 2) + (NPC(npcnum).Level * 3))

                ' * 1.5 if it's a crit!
                If CanPlayerCriticalHit(index) Then
                    Damage *= 1.5
                    SendActionMsg(mapNum, "Critical!", ColorType.BrightCyan, 1, (GetPlayerX(index) * 32), (GetPlayerY(index) * 32))
                End If

            End If

            TempPlayer(index).Target = mapnpcnum
            TempPlayer(index).TargetType = TargetType.Npc
            SendTarget(index, mapnpcnum, TargetType.Npc)

            If Damage > 0 Then
                PlayerAttackNpc(index, mapnpcnum, Damage)
            Else
                PlayerMsg(index, "Your attack does nothing.", ColorType.BrightRed)
            End If

        End If

    End Sub

    Friend Function IsPlayerDead(index As Integer)
        IsPlayerDead = False
        If index <= 0 Or index > MAX_PLAYERS Or Not TempPlayer(index).InGame Then Exit Function
        If GetPlayerVital(index, VitalType.HP) < 0 Then IsPlayerDead = True
    End Function

    Friend Sub HandlePlayerKillPlayer(Attacker As Integer, Victim As Integer)
        ' Notify everyone that our player has bit the dust.
        GlobalMsg(String.Format("{0} has been killed by {1}!", GetPlayerName(Victim), GetPlayerName(Attacker)))

        ' Hand out player experience
        HandlePlayerKillExperience(Attacker, Victim)

        ' Handle our PK outcomes.
        HandlePlayerKilledPK(Attacker, Victim)

        ' Remove our player from everyone's target list.
        For Each p In TempPlayer.Where(Function(x, i) x.InGame And GetPlayerMap(i + 1) = GetPlayerMap(Victim) And x.TargetType = TargetType.Player And x.Target = Victim).Select(Function(x, i) i + 1).ToArray()
            TempPlayer(p).Target = 0
            TempPlayer(p).TargetType = 0
            SendTarget(p, 0, 0)
        Next

        ' Actually kill the player.
        OnDeath(Victim)
    End Sub

    Friend Sub HandlePlayerKillNpc(mapNum As Integer, index As Integer, MapNpcNum As Integer)
        ' Set our attacker's target to nothing.
        SendTarget(index, 0, 0)

        ' Hand out player experience
        HandleNpcKillExperience(index, MapNPC(mapNum).Npc(MapNpcNum).Num)

        ' Drop items if we can.
        DropNpcItems(mapNum, MapNpcNum)

        ' Set our NPC's data to default so we know it's dead.
        MapNPC(mapNum).Npc(MapNpcNum).Num = 0
        MapNPC(mapNum).Npc(MapNpcNum).SpawnWait = GetTimeMs()
        MapNPC(mapNum).Npc(MapNpcNum).Vital(VitalType.HP) = 0

        ' Notify all our clients that the NPC has died.
        SendNpcDead(mapNum, MapNpcNum)

        ' Check if our dead NPC is targetted by another player and remove their targets.
        For Each p In TempPlayer.Where(Function(x, i) x.InGame And GetPlayerMap(i + 1) = mapNum And x.TargetType = TargetType.Npc And x.Target = MapNpcNum).Select(Function(x, i) i + 1).ToArray()
            TempPlayer(p).Target = 0
            TempPlayer(p).TargetType = 0
            SendTarget(p, 0, 0)
        Next
    End Sub

    Friend Sub HandlePlayerKilledPK(attacker As Integer, victim As Integer)
        ' TODO: Redo this method, it is horrendous.
        Dim z As Integer, eqcount As Integer, invcount, j As Integer
        If GetPlayerPK(victim) = 0 Then
            If GetPlayerPK(attacker) = 0 Then
                SetPlayerPK(attacker, 1)
                SendPlayerData(attacker)
                GlobalMsg(GetPlayerName(attacker) & " has been deemed a Player Killer!!!")
            End If
        Else
            GlobalMsg(GetPlayerName(victim) & " has paid the price for being a Player Killer!!!")
        End If

        If Map(GetPlayerMap(victim)).Moral > 0 Then
            If Moral(Map(GetPlayerMap(victim)).Moral).DropItems Then
                If GetPlayerLevel(victim) >= 10 Then

                    For z = 1 To MAX_INV
                        If GetPlayerInvItemNum(victim, z) > 0 Then
                            invcount += 1
                        End If
                    Next

                    For z = 0 To EquipmentType.Count - 1
                        If GetPlayerEquipment(victim, z) > 0 Then
                            eqcount += 1
                        End If
                    Next
                    z = Random(1, invcount + eqcount)

                    If z = 0 Then z = 1
                    If z > invcount + eqcount Then z = invcount + eqcount
                    If z > invcount Then
                        z -= invcount

                        For x = 0 To EquipmentType.Count - 1
                            If GetPlayerEquipment(victim, x) > 0 Then
                                j += 1

                                If j = z Then
                                    'Here it is, drop this piece of equipment!
                                    PlayerMsg(victim, "In death you lost grip on your " & Trim$(Item(GetPlayerEquipment(victim, x)).Name), ColorType.BrightRed)
                                    SpawnItem(GetPlayerEquipment(victim, x), 1, GetPlayerMap(victim), GetPlayerX(victim), GetPlayerY(victim))
                                    SetPlayerEquipment(victim, 0, x)
                                    SendWornEquipment(victim)
                                    SendMapEquipment(victim)
                                End If
                            End If
                        Next
                    Else

                        For x = 1 To MAX_INV
                            If GetPlayerInvItemNum(victim, x) > 0 Then
                                j += 1

                                If j = z Then
                                    'Here it is, drop this item!
                                    PlayerMsg(victim, "In death you lost grip on your " & Trim$(Item(GetPlayerInvItemNum(victim, x)).Name), ColorType.BrightRed)
                                    SpawnItem(GetPlayerInvItemNum(victim, x), GetPlayerInvItemValue(victim, x), GetPlayerMap(victim), GetPlayerX(victim), GetPlayerY(victim))
                                    SetPlayerInvItemNum(victim, x, 0)
                                    SetPlayerInvItemValue(victim, x, 0)
                                    SendInventory(victim)
                                End If
                            End If
                        Next
                    End If
                End If
            End If
        End If
    End Sub

#End Region

#Region "Data"

    Sub CheckPlayerLevelUp(index As Integer)
        Dim expRollover As Integer
        Dim level_count As Integer

        level_count = 0

        Do While GetPlayerExp(index) >= GetPlayerNextLevel(index)
            expRollover = GetPlayerExp(index) - GetPlayerNextLevel(index)
            SetPlayerLevel(index, GetPlayerLevel(index) + 1)
            SetPlayerPoints(index, GetPlayerPoints(index) + STAT_PER_LEVEL)
            SetPlayerExp(index, expRollover)
            level_count += 1
        Loop

        If level_count > 0 Then
            If level_count = 1 Then
                'singular
                GlobalMsg(GetPlayerName(index) & " has gained " & level_count & " level!")
            Else
                'plural
                GlobalMsg(GetPlayerName(index) & " has gained " & level_count & " levels!")
            End If
            SendActionMsg(GetPlayerMap(index), "Level Up", ColorType.Yellow, 1, (GetPlayerX(index) * 32), (GetPlayerY(index) * 32))
            SendExp(index)
            SendPlayerData(index)
        End If
    End Sub

    Function GetPlayerJob(index As Integer) As Integer
        If Player(index).Job = 0 Then Player(index).Job = 1
        GetPlayerJob = Player(index).Job
    End Function

    Sub SetPlayerPK(index As Integer, PK As Integer)
        Player(index).Pk = PK
    End Sub

#End Region

#Region "Incoming Packets"

    Friend Sub HandleUseChar(index As Integer)
        If Not IsPlaying(index) Then
            ' Send an ok to client to start receiving in game data
            SendLoginOK(index)
            JoinGame(index)
            Dim text = String.Format("{0} | {1} has began playing {2}.", GetPlayerLogin(index), GetPlayerName(index), Types.Settings.GameName)
            Addlog(text, PLAYER_LOG)
            Console.WriteLine(text)
        End If
    End Sub

#End Region

#Region "Outgoing Packets"

    Sub SendLeaveMap(index As Integer, mapNum As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SLeftMap)
        buffer.WriteInt32(index)
        SendDataToMapBut(index, mapNum, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

#End Region

#Region "Movement"
    Sub PlayerWarp(index As Integer, MapNum As Integer, X As Integer, Y As Integer, Optional NoInstance As Boolean = False)
        Dim OldMap As Integer
        Dim i As Integer
        Dim buffer As ByteStream

        ' Check for subscript out of range
        If IsPlaying(index) = False Or MapNum <= 0 Or MapNum > MAX_MAPS Then Exit Sub

        ' Check if you are out of bounds
        If X > Map(MapNum).MaxX Then X = Map(MapNum).MaxX
        If Y > Map(MapNum).MaxY Then Y = Map(MapNum).MaxY

        TempPlayer(index).EventProcessingCount = 0
        TempPlayer(index).EventMap.CurrentEvents = 0

        'clear target
        TempPlayer(index).Target = 0
        TempPlayer(index).TargetType = 0
        SendTarget(index, 0, 0)

        ' clear events
        TempPlayer(index).EventMap.CurrentEvents = 0

        ' Save old map to send erase player data to
        OldMap = GetPlayerMap(index)

        If OldMap <> MapNum Then
            SendLeaveMap(index, OldMap)
        End If

        SetPlayerMap(index, MapNum)
        SetPlayerX(index, X)
        SetPlayerY(index, Y)
        If PetAlive(index) Then
            SetPetX(index, X)
            SetPetY(index, Y)
            TempPlayer(index).PetTarget = 0
            TempPlayer(index).PetTargetType = 0
            SendPetXy(index, X, Y)
        End If

        SendPlayerXY(index)

        ' send equipment of all people on new map
        If GetTotalMapPlayers(MapNum) > 0 Then
            For i = 1 To Socket.HighIndex()
                If IsPlaying(i) Then
                    If GetPlayerMap(i) = MapNum Then
                        SendMapEquipmentTo(i, index)
                    End If
                End If
            Next
        End If

        ' Now we check if there were any players left on the map the player just left, and if not stop processing npcs
        If GetTotalMapPlayers(OldMap) = 0 Then
            PlayersOnMap(OldMap) = False

            ' Regenerate all NPCs' health
            For i = 1 To MAX_MAP_NPCS

                If MapNPC(OldMap).Npc(i).Num > 0 Then
                    MapNPC(OldMap).Npc(i).Vital(VitalType.HP) = GetNpcMaxVital(MapNPC(OldMap).Npc(i).Num, VitalType.HP)
                End If

            Next

        End If

        ' Sets it so we know to process npcs on the map
        PlayersOnMap(MapNum) = True
        TempPlayer(index).GettingMap = True

        SendUpdateMoralTo(index, Map(MapNum).Moral)

        buffer = New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SCheckForMap)
        buffer.WriteInt32(MapNum)
        buffer.WriteInt32(Map(MapNum).Revision)
        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()

    End Sub

    Sub PlayerMove(index As Integer, Dir As Integer, Movement As Integer, ExpectingWarp As Boolean)
        Dim mapNum As Integer
        Dim x As Integer, y As Integer, begineventprocessing As Boolean
        Dim Moved As Boolean, DidWarp As Boolean
        Dim NewMapX As Byte, NewMapY As Byte
        Dim VitalType As Integer, Color As Integer, amount As Integer

        ' Check for subscript out of range
        If Dir < DirectionType.Up Or Dir > DirectionType.Left Or Movement < MovementType.Standing Or Movement > MovementType.Running Then
            Exit Sub
        End If

        If TempPlayer(index).InShop > 0 Or TempPlayer(index).InBank Then
            Exit Sub
        End If

        SetPlayerDir(index, Dir)
        Moved = False
        mapNum = GetPlayerMap(index)

        Select Case Dir
            Case DirectionType.Up
                ' Check to make sure not outside of boundaries
                If GetPlayerY(index) > 0 Then
                    ' Check to make sure that the tile is walkable
                    If Not IsDirBlocked(Map(GetPlayerMap(index)).Tile(GetPlayerX(index), GetPlayerY(index)).DirBlock, DirectionType.Up) Then
                        If Map(GetPlayerMap(index)).Tile(GetPlayerX(index), GetPlayerY(index) - 1).Type <> TileType.Blocked And Map(GetPlayerMap(index)).Tile(GetPlayerX(index), GetPlayerY(index) - 1).Type2 <> TileType.Blocked Then
                            If Map(GetPlayerMap(index)).Tile(GetPlayerX(index), GetPlayerY(index) - 1).Type <> TileType.Resource And Map(GetPlayerMap(index)).Tile(GetPlayerX(index), GetPlayerY(index) - 1).Type2 <> TileType.Resource Then
                                SetPlayerY(index, GetPlayerY(index) - 1)
                                SendPlayerMove(index, Movement)
                                Moved = True

                                'check for event
                                For i = 1 To TempPlayer(index).EventMap.CurrentEvents
                                    TriggerEvent(index, i, 1, GetPlayerX(index), GetPlayerY(index))
                                Next
                            End If
                        End If
                    End If
                Else
                    If Map(GetPlayerMap(index)).Tile(GetPlayerX(index), GetPlayerY(index)).Type <> TileType.NoXing And Map(GetPlayerMap(index)).Tile(GetPlayerX(index), GetPlayerY(index)).Type2 <> TileType.NoXing Then 
                        ' Check to see if we can move them to the another map
                        If Map(GetPlayerMap(index)).Up > 0 Then
                            NewMapY = Map(Map(GetPlayerMap(index)).Up).MaxY
                            PlayerWarp(index, Map(GetPlayerMap(index)).Up, GetPlayerX(index), NewMapY)
                            DidWarp = True
                            Moved = True
                        End If
                    End If
                End If

            Case DirectionType.Down
                ' Check to make sure not outside of boundaries
                If GetPlayerY(index) < Map(mapNum).MaxY Then
                    ' Check to make sure that the tile is walkable
                    If Not IsDirBlocked(Map(GetPlayerMap(index)).Tile(GetPlayerX(index), GetPlayerY(index)).DirBlock, DirectionType.Down) Then
                        If Map(GetPlayerMap(index)).Tile(GetPlayerX(index), GetPlayerY(index) + 1).Type <> TileType.Blocked And Map(GetPlayerMap(index)).Tile(GetPlayerX(index), GetPlayerY(index) + 1).Type2 <> TileType.Blocked  Then
                            If Map(GetPlayerMap(index)).Tile(GetPlayerX(index), GetPlayerY(index) + 1).Type <> TileType.Resource And Map(GetPlayerMap(index)).Tile(GetPlayerX(index), GetPlayerY(index) + 1).Type2 <> TileType.Resource Then
                                SetPlayerY(index, GetPlayerY(index) + 1)
                                SendPlayerMove(index, Movement)
                                Moved = True

                                'check for event
                                For i = 1 To TempPlayer(index).EventMap.CurrentEvents
                                    TriggerEvent(index, i, 1, GetPlayerX(index), GetPlayerY(index))
                                Next
                            End If
                        End If
                    End If
                Else
                    If Map(GetPlayerMap(index)).Tile(GetPlayerX(index), GetPlayerY(index)).Type <> TileType.NoXing And Map(GetPlayerMap(index)).Tile(GetPlayerX(index), GetPlayerY(index)).Type2 <> TileType.NoXing Then 
                        ' Check to see if we can move them to the another map
                        If Map(GetPlayerMap(index)).Down > 0 Then
                            PlayerWarp(index, Map(GetPlayerMap(index)).Down, GetPlayerX(index), 0)
                            DidWarp = True
                            Moved = True
                        End If
                    End If
                End If

            Case DirectionType.Left
                ' Check to make sure not outside of boundaries
                If GetPlayerX(index) > 0 Then
                    ' Check to make sure that the tile is walkable
                    If Not IsDirBlocked(Map(GetPlayerMap(index)).Tile(GetPlayerX(index), GetPlayerY(index)).DirBlock, DirectionType.Left) Then
                        If Map(GetPlayerMap(index)).Tile(GetPlayerX(index) - 1, GetPlayerY(index)).Type <> TileType.Blocked And Map(GetPlayerMap(index)).Tile(GetPlayerX(index) - 1, GetPlayerY(index)).Type2 <> TileType.Blocked Then
                            If Map(GetPlayerMap(index)).Tile(GetPlayerX(index) - 1, GetPlayerY(index)).Type <> TileType.Resource And Map(GetPlayerMap(index)).Tile(GetPlayerX(index) - 1, GetPlayerY(index)).Type2 <> TileType.Resource  Then
                                SetPlayerX(index, GetPlayerX(index) - 1)
                                SendPlayerMove(index, Movement)
                                Moved = True

                                'check for event
                                For i = 1 To TempPlayer(index).EventMap.CurrentEvents
                                    TriggerEvent(index, i, 1, GetPlayerX(index), GetPlayerY(index))
                                Next
                            End If
                        End If
                    End If
                Else
                    If Map(GetPlayerMap(index)).Tile(GetPlayerX(index), GetPlayerY(index)).Type <> TileType.NoXing And Map(GetPlayerMap(index)).Tile(GetPlayerX(index), GetPlayerY(index)).Type2 <> TileType.NoXing Then 
                        ' Check to see if we can move them to the another map
                        If Map(GetPlayerMap(index)).Left > 0 Then
                            NewMapX = Map(Map(GetPlayerMap(index)).Left).MaxX
                            PlayerWarp(index, Map(GetPlayerMap(index)).Left, NewMapX, GetPlayerY(index))
                            DidWarp = True
                            Moved = True
                        End If
                    End If
                End If

            Case DirectionType.Right
                ' Check to make sure not outside of boundaries
                If GetPlayerX(index) < Map(mapNum).MaxX Then
                    ' Check to make sure that the tile is walkable
                    If Not IsDirBlocked(Map(GetPlayerMap(index)).Tile(GetPlayerX(index), GetPlayerY(index)).DirBlock, DirectionType.Right) Then
                        If Map(GetPlayerMap(index)).Tile(GetPlayerX(index) + 1, GetPlayerY(index)).Type <> TileType.Blocked And Map(GetPlayerMap(index)).Tile(GetPlayerX(index) + 1, GetPlayerY(index)).Type2 <> TileType.Blocked Then
                            If Map(GetPlayerMap(index)).Tile(GetPlayerX(index) + 1, GetPlayerY(index)).Type <> TileType.Resource And Map(GetPlayerMap(index)).Tile(GetPlayerX(index) + 1, GetPlayerY(index)).Type2 <> TileType.Resource Then
                                SetPlayerX(index, GetPlayerX(index) + 1)
                                SendPlayerMove(index, Movement)
                                Moved = True

                                'check for event
                                For i = 1 To TempPlayer(index).EventMap.CurrentEvents
                                    TriggerEvent(index, i, 1, GetPlayerX(index), GetPlayerY(index))
                                Next
                            End If
                        End If
                    End If
                Else
                    If Map(GetPlayerMap(index)).Tile(GetPlayerX(index), GetPlayerY(index)).Type <> TileType.NoXing And Map(GetPlayerMap(index)).Tile(GetPlayerX(index), GetPlayerY(index)).Type2 <> TileType.NoXing Then 
                        ' Check to see if we can move them to the another map
                        If Map(GetPlayerMap(index)).Right > 0 Then
                            PlayerWarp(index, Map(GetPlayerMap(index)).Right, 0, GetPlayerY(index))
                            DidWarp = True
                            Moved = True
                        End If
                    End If
                End If
        End Select

        With Map(GetPlayerMap(index)).Tile(GetPlayerX(index), GetPlayerY(index))
            mapNum = 0
            x = 0
            y = 0

            ' Check to see if the tile is a warp tile, and if so warp them
            If .Type = TileType.Warp Then
                mapNum = .Data1
                x = .Data2
                y = .Data3
            End If

            If .Type2 = TileType.Warp Then
                mapNum = .Data1_2
                x = .Data2_2
                y = .Data3_2
            End if

            If mapNum > 0 Then
                PlayerWarp(index, mapNum, x, y)

                DidWarp = True
                Moved = True
            End If

            mapNum = 0
            x = 0
            y = 0

            ' Check for a shop, and if so open it
            If .Type = TileType.Shop Then
                x = .Data1
            End If

            If .Type2 = TileType.Shop Then
                x = .Data1_2
            End If

            If x > 0 Then ' shop exists?
                If Len(Trim$(Shop(x).Name)) > 0 Then ' name exists?
                    SendOpenShop(index, x)
                    TempPlayer(index).InShop = x ' stops movement and the like
                End If
            End If

            ' Check to see if the tile is a bank, and if so send bank
            If .Type = TileType.Bank Or .Type2 = TileType.Bank Then
                SendBank(index)
                TempPlayer(index).InBank = True
                Moved = True
            End If

            ' Check if it's a heal tile
            If .Type = TileType.Heal Then
                VitalType = .Data1
                amount = .Data2
            End if

            If .Type2 = TileType.Heal
                VitalType = .Data1_2
                amount = .Data2_2
            End If

            If VitalType > 0 Then
                If Not GetPlayerVital(index, VitalType) = GetPlayerMaxVital(index, VitalType) Then
                    If VitalType = Core.VitalType.HP Then
                        Color = ColorType.BrightGreen
                    Else
                        Color = ColorType.BrightBlue
                    End If

                    SendActionMsg(GetPlayerMap(index), "+" & amount, Color, ActionMsgType.Scroll, GetPlayerX(index) * 32, GetPlayerY(index) * 32, 1)
                    SetPlayerVital(index, VitalType, GetPlayerVital(index, VitalType) + amount)
                    PlayerMsg(index, "You feel rejuvenating forces coursing through your body.", ColorType.BrightGreen)
                    SendVital(index, VitalType)

                    ' send vitals to party if in one
                    If TempPlayer(index).InParty > 0 Then SendPartyVitals(TempPlayer(index).InParty, index)
                End If
                Moved = True
            End If

            ' Check if it's a trap tile
            If .Type = TileType.Trap Then
                amount = .Data1
            End if

            If .Type2 = TileType.Trap Then
                amount = .Data1_2
            End If

            If amount > 0 Then
                SendActionMsg(GetPlayerMap(index), "-" & amount, ColorType.BrightRed, ActionMsgType.Scroll, GetPlayerX(index) * 32, GetPlayerY(index) * 32, 1)
                If GetPlayerVital(index, Core.VitalType.HP) - amount < 0 Then
                    KillPlayer(index)
                    PlayerMsg(index, "You've been killed by a trap.", ColorType.BrightRed)
                Else
                    SetPlayerVital(index, Core.VitalType.HP, GetPlayerVital(index, Core.VitalType.HP) - amount)
                    PlayerMsg(index, "You've been injured by a trap.", ColorType.BrightRed)
                    SendVital(index, Core.VitalType.HP)
                    ' send vitals to party if in one
                    If TempPlayer(index).InParty > 0 Then SendPartyVitals(TempPlayer(index).InParty, index)
                End If
                Moved = True
            End If

        End With

        ' They tried to hack
        If Moved = False Or (ExpectingWarp And Not DidWarp) Then
            PlayerWarp(index, GetPlayerMap(index), GetPlayerX(index), GetPlayerY(index))
        End If

        x = GetPlayerX(index)
        y = GetPlayerY(index)

        If Moved = True Then
            If TempPlayer(index).EventMap.CurrentEvents > 0 Then
                For i = 1 To TempPlayer(index).EventMap.CurrentEvents
                    If TempPlayer(index).EventMap.EventPages(i).EventId > 0 Then
                        If Map(GetPlayerMap(index)).Events(TempPlayer(index).EventMap.EventPages(i).EventId).Globals = 1 Then
                            If Map(GetPlayerMap(index)).Events(TempPlayer(index).EventMap.EventPages(i).EventId).X = x And Map(GetPlayerMap(index)).Events(TempPlayer(index).EventMap.EventPages(i).EventId).Y = y And Map(GetPlayerMap(index)).Events(TempPlayer(index).EventMap.EventPages(i).EventId).Pages(TempPlayer(index).EventMap.EventPages(i).PageId).Trigger = 1 And TempPlayer(index).EventMap.EventPages(i).Visible = 1 Then begineventprocessing = True
                        Else
                            If TempPlayer(index).EventMap.EventPages(i).X = x And TempPlayer(index).EventMap.EventPages(i).Y = y And Map(GetPlayerMap(index)).Events(TempPlayer(index).EventMap.EventPages(i).EventId).Pages(TempPlayer(index).EventMap.EventPages(i).PageId).Trigger = 1 And TempPlayer(index).EventMap.EventPages(i).Visible = 1 Then begineventprocessing = True
                        End If
                        begineventprocessing = False
                        If begineventprocessing = True Then
                            'Process this event, it is on-touch and everything checks out.
                            If Map(GetPlayerMap(index)).Events(TempPlayer(index).EventMap.EventPages(i).EventId).Pages(TempPlayer(index).EventMap.EventPages(i).PageId).CommandListCount > 0 Then
                                TempPlayer(index).EventProcessing(TempPlayer(index).EventMap.EventPages(i).EventId).Active = 1
                                TempPlayer(index).EventProcessing(TempPlayer(index).EventMap.EventPages(i).EventId).ActionTimer = GetTimeMs()
                                TempPlayer(index).EventProcessing(TempPlayer(index).EventMap.EventPages(i).EventId).CurList = 1
                                TempPlayer(index).EventProcessing(TempPlayer(index).EventMap.EventPages(i).EventId).CurSlot = 1
                                TempPlayer(index).EventProcessing(TempPlayer(index).EventMap.EventPages(i).EventId).EventId = TempPlayer(index).EventMap.EventPages(i).EventId
                                TempPlayer(index).EventProcessing(TempPlayer(index).EventMap.EventPages(i).EventId).PageId = TempPlayer(index).EventMap.EventPages(i).PageId
                                TempPlayer(index).EventProcessing(TempPlayer(index).EventMap.EventPages(i).EventId).WaitingForResponse = 0
                                ReDim TempPlayer(index).EventProcessing(TempPlayer(index).EventMap.EventPages(i).EventId).ListLeftOff(Map(GetPlayerMap(index)).Events(TempPlayer(index).EventMap.EventPages(i).EventId).Pages(TempPlayer(index).EventMap.EventPages(i).PageId).CommandListCount)
                            End If
                            begineventprocessing = False
                        End If
                    End If
                Next
            End If
        End If

    End Sub

#End Region

#Region "Inventory"

    Function HasItem(index As Integer, ItemNum As Integer) As Integer
        Dim i As Integer

        ' Check for subscript out of range
        If IsPlaying(index) = False Or Itemnum <= 0 Or ItemNum > MAX_ITEMS Then
            Exit Function
        End If

        For i = 1 To MAX_INV
            ' Check to see if the player has the item
            If GetPlayerInvItemNum(index, i) = ItemNum Then
                If Item(ItemNum).Type = ItemType.Currency Or Item(ItemNum).Stackable = 1 Then
                    HasItem += GetPlayerInvItemValue(index, i)
                Else
                    HasItem += 1
                End If
            End If
        Next

    End Function

    Function FindItemSlot(index As Integer, ItemNum As Integer) As Integer
        Dim i As Integer

        FindItemSlot = 0

        ' Check for subscript out of range
        If IsPlaying(index) = False Or Itemnum <= 0 Or ItemNum > MAX_ITEMS Then
            Exit Function
        End If

        For i = 1 To MAX_INV
            ' Check to see if the player has the item
            If GetPlayerInvItemNum(index, i) = ItemNum Then
                FindItemSlot = i
                Exit Function
            End If
        Next

    End Function

    Sub PlayerMapGetItem(index As Integer)
        Dim i As Integer, itemnum As Integer
        Dim n As Integer
        Dim mapNum As Integer
        Dim Msg As String

        If Not IsPlaying(index) Then Exit Sub

        mapNum = GetPlayerMap(index)

        For i = 1 To MAX_MAP_ITEMS

            ' See if theres even an item here
            If (MapItem(mapNum, i).Num > 0) And (MapItem(mapNum, i).Num <= MAX_ITEMS) Then
                ' our drop?
                If CanPlayerPickupItem(index, i) Then
                    ' Check if item is at the same location as the player
                    If (MapItem(mapNum, i).X = GetPlayerX(index)) Then
                        If (MapItem(mapNum, i).Y = GetPlayerY(index)) Then
                            ' Find open slot
                            n = FindOpenInvSlot(index, MapItem(mapNum, i).Num)

                            ' Open slot available?
                            If n <> -1 Then
                                ' Set item in players inventor
                                itemnum = MapItem(mapNum, i).Num

                                SetPlayerInvItemNum(index, n, MapItem(mapNum, i).Num)

                                If Item(GetPlayerInvItemNum(index, n)).Type = ItemType.Currency Or Item(GetPlayerInvItemNum(index, n)).Stackable = 1 Then
                                    SetPlayerInvItemValue(index, n, GetPlayerInvItemValue(index, n) + MapItem(mapNum, i).Value)
                                    Msg = MapItem(mapNum, i).Value & " " & Trim$(Item(GetPlayerInvItemNum(index, n)).Name)
                                Else
                                    SetPlayerInvItemValue(index, n, 1)
                                    Msg = Trim$(Item(GetPlayerInvItemNum(index, n)).Name)
                                End If

                                ' Erase item from the map
                                MapItem(mapNum, i).Num = 0
                                MapItem(mapNum, i).Value = 0
                                MapItem(mapNum, i).X = 0
                                MapItem(mapNum, i).Y = 0

                                SendInventoryUpdate(index, n)
                                SpawnItemSlot(i, 0, 0, GetPlayerMap(index), 0, 0)
                                SendActionMsg(GetPlayerMap(index), Msg, ColorType.White, ActionMsgType.Static, (GetPlayerX(index) * 32), (GetPlayerY(index) * 32))
                                Exit For
                            Else
                                PlayerMsg(index, "Your inventory is full.", ColorType.BrightRed)
                                Exit For
                            End If
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Function CanPlayerPickupItem(index As Integer, mapItemNum As Integer) As Boolean
        Dim mapNum As Integer

        mapNum = GetPlayerMap(index)

        If Map(mapNum).Moral > 0 Then
            If Moral(Map(mapNum).Moral).CanPickupItem Then
                ' no lock or locked to player?
                If MapItem(mapNum, mapItemNum).PlayerName = "" Or MapItem(mapNum, mapItemNum).PlayerName = GetPlayerName(index).Trim Then
                    CanPlayerPickupItem = True
                    Exit Function
                End If
            Else 
                Call PlayerMsg(index, "You can't pickup items here!", ColorType.BrightRed)
            End If
        End If

        CanPlayerPickupItem = False
    End Function

    Function FindOpenInvSlot(index As Integer, ItemNum As Integer) As Integer
        Dim i As Integer

        ' Check for subscript out of range
        If IsPlaying(index) = False Or Itemnum <= 0 Or ItemNum > MAX_ITEMS Then
            Exit Function
        End If

        If Item(ItemNum).Type = ItemType.Currency Or Item(ItemNum).Stackable = 1 Then
            ' If currency then check to see if they already have an instance of the item and add it to that
            For i = 1 To MAX_INV
                If GetPlayerInvItemNum(index, i) = ItemNum Then
                    FindOpenInvSlot = i
                    Exit Function
                End If
            Next
        End If

        For i = 1 To MAX_INV
            ' Try to find an open free slot
            If GetPlayerInvItemNum(index, i) = 0 Then
                FindOpenInvSlot = i
                Exit Function
            End If
        Next

        FindOpenInvSlot = -1
    End Function

    Function TakeInvItem(index As Integer, ItemNum As Integer, ItemVal As Integer) As Boolean
        Dim i As Integer

        TakeInvItem = False

        ' Check for subscript out of range
        If IsPlaying(index) = False Or Itemnum <= 0 Or ItemNum > MAX_ITEMS Then
            Exit Function
        End If

        For i = 1 To MAX_INV

            ' Check to see if the player has the item
            If GetPlayerInvItemNum(index, i) = ItemNum Then
                If Item(ItemNum).Type = ItemType.Currency Or Item(ItemNum).Stackable = 1 Then

                    ' Is what we are trying to take away more then what they have?  If so just set it to zero
                    If ItemVal >= GetPlayerInvItemValue(index, i) Then
                        TakeInvItem = True
                    Else
                        SetPlayerInvItemValue(index, i, GetPlayerInvItemValue(index, i) - ItemVal)
                        SendInventoryUpdate(index, i)
                    End If
                Else
                    TakeInvItem = True
                End If

                If TakeInvItem Then
                    SetPlayerInvItemNum(index, i, 0)
                    SetPlayerInvItemValue(index, i, 0)
                    ' Send the inventory update
                    SendInventoryUpdate(index, i)
                    Exit Function
                End If
            End If

        Next

    End Function

    Function GiveInvItem(index As Integer, ItemNum As Integer, ItemVal As Integer, Optional SendUpdate As Boolean = True) As Boolean
        Dim i As Integer

        ' Check for subscript out of range
        If IsPlaying(index) = False Or Itemnum <= 0 Or ItemNum > MAX_ITEMS Then
            GiveInvItem = False
            Exit Function
        End If

        i = FindOpenInvSlot(index, ItemNum)

        ' Check to see if inventory is full
        If i <> -1 Then
            SetPlayerInvItemNum(index, i, ItemNum)
            SetPlayerInvItemValue(index, i, GetPlayerInvItemValue(index, i) + ItemVal)
            If SendUpdate Then SendInventoryUpdate(index, i)
            GiveInvItem = True
        Else
            PlayerMsg(index, "Your inventory is full.", ColorType.BrightRed)
            GiveInvItem = False
        End If

    End Function

    Sub PlayerMapDropItem(index As Integer, invNum As Integer, amount As Integer)
        Dim i As Integer

        ' Check for subscript out of range
        If IsPlaying(index) = False Or invNum <= 0 Or invNum > MAX_INV Then
            Exit Sub
        End If

        ' check the player isn't doing something
        If TempPlayer(index).InBank Or TempPlayer(index).InShop Or TempPlayer(index).InTrade > 0 Then Exit Sub

        If Moral(GetPlayerMap(index)).CanDropItem = False Then
            Call PlayerMsg(index, "You can't drop items here!", ColorType.BrightRed)
            Exit Sub
        End If

        If (GetPlayerInvItemNum(index, invNum) > 0) Then
            If (GetPlayerInvItemNum(index, invNum) <= MAX_ITEMS) Then
                i = FindOpenMapItemSlot(GetPlayerMap(index))

                If i <> 0 Then
                    With MapItem(GetPlayerMap(index), i)
                        .Num = GetPlayerInvItemNum(index, invNum)
                        .X = GetPlayerX(index)
                        .Y = GetPlayerY(index)
                        .PlayerName = Trim$(GetPlayerName(index))
                        .PlayerTimer = GetTimeMs() + ITEM_SPAWN_TIME

                        .CanDespawn = True
                        .DespawnTimer = GetTimeMs() + ITEM_DESPAWN_TIME

                        If Item(GetPlayerInvItemNum(index, invNum)).Type = ItemType.Currency Or Item(GetPlayerInvItemNum(index, invNum)).Stackable = 1 Then
                            ' Check if its more then they have and if so drop it all
                            If amount >= GetPlayerInvItemValue(index, invNum) Then
                                amount = GetPlayerInvItemValue(index, invNum)
                                .Value = amount
                                SetPlayerInvItemNum(index, invNum, 0)
                                SetPlayerInvItemValue(index, invNum, 0)
                            Else
                                .Value = amount
                                SetPlayerInvItemValue(index, invNum, GetPlayerInvItemValue(index, invNum) - amount)
                            End If
                            MapMsg(GetPlayerMap(index), String.Format("{0} has dropped {1} ({2}x).", GetPlayerName(index), CheckGrammar(Trim$(Item(GetPlayerInvItemNum(index, invNum)).Name)), amount), ColorType.Yellow)
                        Else
                            ' It's not a currency object so this is easy
                            .Value = 1

                            ' send message
                            MapMsg(GetPlayerMap(index), String.Format("{0} has dropped {1}.", GetPlayerName(index), CheckGrammar(Trim$(Item(GetPlayerInvItemNum(index, invNum)).Name))), ColorType.Yellow)
                            SetPlayerInvItemNum(index, invNum, 0)
                            SetPlayerInvItemValue(index, invNum, 0)
                        End If

                        ' Send inventory update
                        SendInventoryUpdate(index, invNum)
                        ' Spawn the item before we set the num or we'll get a different free map item slot
                        SpawnItemSlot(i, .Num, amount, GetPlayerMap(index), GetPlayerX(index), GetPlayerY(index))
                    End With
                Else
                    PlayerMsg(index, "Too many items already on the ground.", ColorType.Yellow)
                End If
            End If
        End If

    End Sub

    Function TakeInvSlot(index As Integer, InvSlot As Integer, ItemVal As Integer) As Boolean
        Dim itemNum

        TakeInvSlot = False

        ' Check for subscript out of range
        If IsPlaying(index) = False Or InvSlot < 0 Or InvSlot > MAX_ITEMS Then Exit Function

        itemNum = GetPlayerInvItemNum(index, InvSlot)

        If Item(itemNum).Type = ItemType.Currency Or Item(itemNum).Stackable = 1 Then

            ' Is what we are trying to take away more then what they have?  If so just set it to zero
            If ItemVal >= GetPlayerInvItemValue(index, InvSlot) Then
                TakeInvSlot = True
            Else
                SetPlayerInvItemValue(index, InvSlot, GetPlayerInvItemValue(index, InvSlot) - ItemVal)
            End If
        Else
            TakeInvSlot = True
        End If

        If TakeInvSlot Then
            SetPlayerInvItemNum(index, InvSlot, 0)
            SetPlayerInvItemValue(index, InvSlot, 0)
            Exit Function
        End If

    End Function

    Function CanPlayerUseItem(Index As Integer, itemNum As Integer)
        Dim i As Integer

        If Map(GetPlayerMap(index)).Moral > 0 Then
            If Moral(Map(GetPlayerMap(index)).Moral).CanUseItem = False Then
                PlayerMsg(Index, "You can't use items here!", ColorType.BrightRed)
                Exit Function
            End If
        End If

        For i = 1 To StatType.Count - 1
            If GetPlayerStat(Index, i) < Item(itemNum).Stat_Req(i) Then
                PlayerMsg(Index, "You do not meet the stat requirements to use this item.", ColorType.BrightRed)
                Exit Function
            End If
        Next

        If Item(itemNum).LevelReq > GetPlayerLevel(Index) Then
            PlayerMsg(Index, "You do not meet the level requirements to use this item.", ColorType.BrightRed)
            Exit Function
        End If

        ' Make sure they are the right job
        If Not Item(itemNum).JobReq = GetPlayerJob(Index) And Not Item(itemNum).JobReq = 0 Then
            PlayerMsg(Index, "You do not meet the class requirements to use this item.", ColorType.BrightRed)
            Exit Function
        End If

        ' access requirement
        If Not GetPlayerAccess(Index) >= Item(itemNum).AccessReq Then
            PlayerMsg(Index, "You do not meet the access requirement to equip this item.", ColorType.BrightRed)
            Exit Function
        End If

        CanPlayerUseItem = True
    End Function

    Friend Sub UseItem(index As Integer, InvNum As Integer)
        Dim InvItemNum As Integer, i As Integer, n As Integer, tempitem As Integer
        Dim m As Integer, tempdata(StatType.Count + 3) As Integer, tempstr(2) As String

        ' Prevent hacking
        If InvNum <= 0 Or InvNum > MAX_INV Then Exit Sub

        InvItemNum = GetPlayerInvItemNum(index, InvNum)

        If InvItemnum <= 0 Or InvItemNum > MAX_ITEMS Then Exit Sub

        If CanPlayerUseItem(index, InvItemNum) = False Then Exit Sub

        ' Find out what kind of item it is
        Select Case Item(InvItemNum).Type
            Case ItemType.Equipment

                Select Case Item(InvItemNum).SubType
                    Case EquipmentType.Weapon

                        If Item(InvItemNum).TwoHanded > 0 Then
                            If GetPlayerEquipment(index, EquipmentType.Shield) > 0 Then
                                PlayerMsg(index, "This is a 2-Handed weapon! Please unequip shield first.", ColorType.BrightRed)
                                Exit Sub
                            End If
                        End If

                        If GetPlayerEquipment(index, EquipmentType.Weapon) > 0 Then
                            tempitem = GetPlayerEquipment(index, EquipmentType.Weapon)
                        End If

                        SetPlayerEquipment(index, InvItemNum, EquipmentType.Weapon)

                        If Item(InvItemNum).Randomize <> 0 Then
                            PlayerMsg(index, "You equip " & tempstr(1) & " " & CheckGrammar(Item(InvItemNum).Name) & " " & tempstr(2), ColorType.BrightGreen)
                        Else
                            PlayerMsg(index, "You equip " & CheckGrammar(Item(InvItemNum).Name), ColorType.BrightGreen)
                        End If

                        SetPlayerInvItemNum(index, InvNum, 0)
                        SetPlayerInvItemValue(index, InvNum, 0)

                        If tempitem > 0 Then ' give back the stored item
                            m = FindOpenInvSlot(index, tempitem)
                            SetPlayerInvItemNum(index, m, tempitem)
                            SetPlayerInvItemValue(index, m, 0)

                            tempitem = 0
                        End If

                        SendWornEquipment(index)
                        SendMapEquipment(index)
                        SendInventory(index)
                        SendInventoryUpdate(index, InvNum)
                        SendStats(index)

                        ' send vitals
                        SendVitals(index)

                        ' send vitals to party if in one
                        If TempPlayer(index).InParty > 0 Then SendPartyVitals(TempPlayer(index).InParty, index)

                    Case EquipmentType.Armor

                        If GetPlayerEquipment(index, EquipmentType.Armor) > 0 Then
                            tempitem = GetPlayerEquipment(index, EquipmentType.Armor)
                        End If

                        SetPlayerEquipment(index, InvItemNum, EquipmentType.Armor)

                        PlayerMsg(index, "You equip " & CheckGrammar(Item(InvItemNum).Name), ColorType.BrightGreen)
                        TakeInvItem(index, InvItemNum, 0)

                        If tempitem > 0 Then ' Return their old equipment to their inventory.
                            m = FindOpenInvSlot(index, tempitem)
                            SetPlayerInvItemNum(index, m, tempitem)
                            SetPlayerInvItemValue(index, m, 0)

                            tempitem = 0
                        End If

                        SendWornEquipment(index)
                        SendMapEquipment(index)

                        SendInventory(index)
                        SendStats(index)

                        ' send vitals
                        SendVitals(index)

                        ' send vitals to party if in one
                        If TempPlayer(index).InParty > 0 Then SendPartyVitals(TempPlayer(index).InParty, index)

                    Case EquipmentType.Helmet

                        If GetPlayerEquipment(index, EquipmentType.Helmet) > 0 Then
                            tempitem = GetPlayerEquipment(index, EquipmentType.Helmet)
                        End If

                        SetPlayerEquipment(index, InvItemNum, EquipmentType.Helmet)

                        PlayerMsg(index, "You equip " & CheckGrammar(Item(InvItemNum).Name), ColorType.BrightGreen)
                        TakeInvItem(index, InvItemNum, 1)

                        If tempitem > 0 Then ' give back the stored item
                            m = FindOpenInvSlot(index, tempitem)
                            SetPlayerInvItemNum(index, m, tempitem)
                            SetPlayerInvItemValue(index, m, 0)

                            tempitem = 0
                        End If

                        SendWornEquipment(index)
                        SendMapEquipment(index)
                        SendInventory(index)
                        SendStats(index)

                        ' send vitals
                        SendVitals(index)

                        ' send vitals to party if in one
                        If TempPlayer(index).InParty > 0 Then SendPartyVitals(TempPlayer(index).InParty, index)

                    Case EquipmentType.Shield
                        If Item(GetPlayerEquipment(index, EquipmentType.Weapon)).TwoHanded > 0 Then
                            PlayerMsg(index, "Please unequip your 2handed weapon first.", ColorType.BrightRed)
                            Exit Sub
                        End If

                        If GetPlayerEquipment(index, EquipmentType.Shield) > 0 Then
                            tempitem = GetPlayerEquipment(index, EquipmentType.Shield)
                        End If

                        SetPlayerEquipment(index, InvItemNum, EquipmentType.Shield)

                        PlayerMsg(index, "You equip " & CheckGrammar(Item(InvItemNum).Name), ColorType.BrightGreen)
                        TakeInvItem(index, InvItemNum, 1)

                        If tempitem > 0 Then ' give back the stored item
                            m = FindOpenInvSlot(index, tempitem)
                            SetPlayerInvItemNum(index, m, tempitem)
                            SetPlayerInvItemValue(index, m, 0)

                            tempitem = 0
                        End If

                        SendWornEquipment(index)
                        SendMapEquipment(index)
                        SendInventory(index)
                        SendStats(index)

                        ' send vitals
                        SendVitals(index)

                        ' send vitals to party if in one
                        If TempPlayer(index).InParty > 0 Then SendPartyVitals(TempPlayer(index).InParty, index)

                    Case EquipmentType.Shoes
                        If GetPlayerEquipment(index, EquipmentType.Shoes) > 0 Then
                            tempitem = GetPlayerEquipment(index, EquipmentType.Shoes)
                        End If

                        SetPlayerEquipment(index, InvItemNum, EquipmentType.Shoes)

                        PlayerMsg(index, "You equip " & CheckGrammar(Item(InvItemNum).Name), ColorType.BrightGreen)
                        TakeInvItem(index, InvItemNum, 1)

                        If tempitem > 0 Then ' give back the stored item
                            m = FindOpenInvSlot(index, tempitem)
                            SetPlayerInvItemNum(index, m, tempitem)
                            SetPlayerInvItemValue(index, m, 0)

                            tempitem = 0
                        End If

                        SendWornEquipment(index)
                        SendMapEquipment(index)
                        SendInventory(index)
                        SendStats(index)

                        ' send vitals
                        SendVitals(index)

                        ' send vitals to party if in one
                        If TempPlayer(index).InParty > 0 Then SendPartyVitals(TempPlayer(index).InParty, index)

                    Case EquipmentType.Gloves
                        If GetPlayerEquipment(index, EquipmentType.Gloves) > 0 Then
                            tempitem = GetPlayerEquipment(index, EquipmentType.Gloves)
                        End If

                        SetPlayerEquipment(index, InvItemNum, EquipmentType.Gloves)

                        PlayerMsg(index, "You equip " & CheckGrammar(Item(InvItemNum).Name), ColorType.BrightGreen)
                        TakeInvItem(index, InvItemNum, 1)

                        If tempitem > 0 Then ' give back the stored item
                            m = FindOpenInvSlot(index, tempitem)
                            SetPlayerInvItemNum(index, m, tempitem)
                            SetPlayerInvItemValue(index, m, 0)

                            tempitem = 0
                        End If

                        SendWornEquipment(index)
                        SendMapEquipment(index)
                        SendInventory(index)
                        SendStats(index)

                        ' send vitals
                        SendVitals(index)

                        ' send vitals to party if in one
                        If TempPlayer(index).InParty > 0 Then SendPartyVitals(TempPlayer(index).InParty, index)
                End Select

            Case ItemType.Consumable
                Select Case Item(InvItemNum).SubType
                    Case ConsumableType.HP
                        SendActionMsg(GetPlayerMap(index), "+" & Item(InvItemNum).Data1, ColorType.BrightGreen, ActionMsgType.Scroll, GetPlayerX(index) * 32, GetPlayerY(index) * 32)
                        SendAnimation(GetPlayerMap(index), Item(InvItemNum).Animation, 0, 0, TargetType.Player, index)
                        SetPlayerVital(index, VitalType.HP, GetPlayerVital(index, VitalType.HP) + Item(InvItemNum).Data1)
                        If Item(InvItemNum).Stackable = 1 Then
                            TakeInvItem(index, InvItemNum, 1)
                        Else
                            TakeInvItem(index, InvItemNum, 0)
                        End If
                        SendVital(index, VitalType.HP)

                        ' send vitals to party if in one
                        If TempPlayer(index).InParty > 0 Then SendPartyVitals(TempPlayer(index).InParty, index)

                    Case ConsumableType.MP
                        SendActionMsg(GetPlayerMap(index), "+" & Item(InvItemNum).Data1, ColorType.BrightBlue, ActionMsgType.Scroll, GetPlayerX(index) * 32, GetPlayerY(index) * 32)
                        SendAnimation(GetPlayerMap(index), Item(InvItemNum).Animation, 0, 0, TargetType.Player, index)
                        SetPlayerVital(index, VitalType.MP, GetPlayerVital(index, VitalType.MP) + Item(InvItemNum).Data1)
                        If Item(InvItemNum).Stackable = 1 Then
                            TakeInvItem(index, InvItemNum, 1)
                        Else
                            TakeInvItem(index, InvItemNum, 0)
                        End If
                        SendVital(index, VitalType.MP)

                        ' send vitals to party if in one
                        If TempPlayer(index).InParty > 0 Then SendPartyVitals(TempPlayer(index).InParty, index)

                    Case ConsumableType.SP
                        SendAnimation(GetPlayerMap(index), Item(InvItemNum).Animation, 0, 0, TargetType.Player, index)
                        SetPlayerVital(index, VitalType.SP, GetPlayerVital(index, VitalType.SP) + Item(InvItemNum).Data1)
                        If Item(InvItemNum).Stackable = 1 Then
                            TakeInvItem(index, InvItemNum, 1)
                        Else
                            TakeInvItem(index, InvItemNum, 0)
                        End If
                        SendVital(index, VitalType.SP)

                        ' send vitals to party if in one
                        If TempPlayer(index).InParty > 0 Then SendPartyVitals(TempPlayer(index).InParty, index)

                    Case ConsumableType.Exp
                        SendAnimation(GetPlayerMap(index), Item(InvItemNum).Animation, 0, 0, TargetType.Player, index)
                        SetPlayerExp(index, GetPlayerExp(index) + Item(InvItemNum).Data1)
                        If Item(InvItemNum).Stackable = 1 Then
                            TakeInvItem(index, InvItemNum, 1)
                        Else
                            TakeInvItem(index, InvItemNum, 0)
                        End If

                        ' send vitals to party if in one
                        If TempPlayer(index).InParty > 0 Then SendPartyVitals(TempPlayer(index).InParty, index)
                End Select

            Case ItemType.Projectile
                If Item(InvItemNum).Ammo > 0 Then
                    If HasItem(index, Item(InvItemNum).Ammo) Then
                        TakeInvItem(index, Item(InvItemNum).Ammo, 1)
                        PlayerFireProjectile(index)
                    Else
                        PlayerMsg(index, "No More " & Item(Item(GetPlayerEquipment(index, EquipmentType.Weapon)).Ammo).Name & " !", ColorType.BrightRed)
                        Exit Sub
                    End If
                Else
                    PlayerFireProjectile(index)
                    Exit Sub
                End If

            Case ItemType.CommonEvent
                n = Item(InvItemNum).Data1

                Select Case Item(InvItemNum).SubType
                    Case CommonEventType.Variable
                        Player(index).Variables(n) = Item(InvItemNum).Data2
                    Case CommonEventType.Switch
                        Player(index).Switches(n) = Item(InvItemNum).Data2
                    Case CommonEventType.Key
                        TriggerEvent(index, 1, 0, GetPlayerX(index), GetPlayerY(index))
                    Case CommonEventType.CustomScript
                        CustomScript(index, Item(InvItemNum).Data2, GetPlayerMap(index), n)
                End Select

            Case ItemType.Skill
                PlayerLearnSkill(index, InvItemNum)

            Case ItemType.Pet
                If Item(InvItemNum).Stackable = 1 Then
                    TakeInvItem(index, InvItemNum, 1)
                Else
                    TakeInvItem(index, InvItemNum, 0)
                End If
                n = Item(InvItemNum).Data1
                AdoptPet(index, n)
        End Select
    End Sub

    Sub PlayerLearnSkill(Index As Integer, InvItemNum As Integer, Optional SkillNum As Integer = 0)
        Dim n As Integer, i As Integer

        ' Get the skill num
        If SkillNum > 0 Then
            n = SkillNum
        Else
            n = Item(InvItemNum).Data1
        End If

        If n < 1 Or n > MAX_SKILLS Then Exit Sub

        If n > 0 Then
            ' Make sure they are the right class
            If Skill(n).JobReq = GetPlayerJob(index) Or Skill(n).JobReq = 0 Then
                ' Make sure they are the right level
                i = Skill(n).LevelReq

                If i <= GetPlayerLevel(index) Then
                    i = FindOpenSkill(index)

                    ' Make sure they have an open skill slot
                    If i > 0 Then

                        ' Make sure they dont already have the skill
                        If Not HasSkill(index, n) Then
                            SetPlayerSkill(index, i, n)
                            SendAnimation(GetPlayerMap(index), Item(InvItemNum).Animation, 0, 0, TargetType.Player, index)
                            TakeInvItem(index, InvItemNum, 0)
                            PlayerMsg(index, "You study the skill carefully.", ColorType.Yellow)
                            PlayerMsg(index, "You have learned a new skill!", ColorType.BrightGreen)
                            SendPlayerSkills(Index)
                        Else
                            PlayerMsg(index, "You have already learned this skill!", ColorType.BrightRed)
                        End If
                    Else
                        PlayerMsg(index, "You have learned all that you can learn!", ColorType.BrightRed)
                    End If
                Else
                    PlayerMsg(index, "You must be level " & i & " to learn this skill.", ColorType.Yellow)
                End If
            Else
                PlayerMsg(index, "This skill can only be learned by " & CheckGrammar(Job(Skill(n).JobReq).Name.Trim) & ".", ColorType.Yellow)
            End If
        Else
            PlayerMsg(index, "This scroll is not connected to a skill, please inform an admin!", ColorType.BrightRed)
        End If
    End Sub

    Sub PlayerSwitchInvSlots(index As Integer, OldSlot As Integer, NewSlot As Integer)
        Dim OldNum As Integer, OldValue As Integer, OldRarity As Integer, OldPrefix As String
        Dim OldSuffix As String, OldSpeed As Integer, OldDamage As Integer
        Dim NewNum As Integer, NewValue As Integer, NewRarity As Integer, NewPrefix As String
        Dim NewSuffix As String, NewSpeed As Integer, NewDamage As Integer

        If OldSlot = 0 Or NewSlot = 0 Then Exit Sub

        OldNum = GetPlayerInvItemNum(index, OldSlot)
        OldValue = GetPlayerInvItemValue(index, OldSlot)
        NewNum = GetPlayerInvItemNum(index, NewSlot)
        NewValue = GetPlayerInvItemValue(index, NewSlot)

        If OldNum = NewNum And Item(NewNum).Stackable = 1 Then ' same item, if we can stack it, lets do that :P
            SetPlayerInvItemNum(index, NewSlot, NewNum)
            SetPlayerInvItemValue(index, NewSlot, OldValue + NewValue)
            SetPlayerInvItemNum(index, OldSlot, 0)
            SetPlayerInvItemValue(index, OldSlot, 0)
        Else
            SetPlayerInvItemNum(index, NewSlot, OldNum)
            SetPlayerInvItemValue(index, NewSlot, OldValue)
            SetPlayerInvItemNum(index, OldSlot, NewNum)
            SetPlayerInvItemValue(index, OldSlot, NewValue)
        End If

        SendInventory(index)
    End Sub

     Sub PlayerSwitchSkillSlots(index As Integer, OldSlot As Integer, NewSlot As Integer)
        Dim OldNum As Integer, OldValue As Integer, OldRarity As Integer, OldPrefix As String
        Dim OldSuffix As String, OldSpeed As Integer, OldDamage As Integer
        Dim NewNum As Integer, NewValue As Integer, NewRarity As Integer, NewPrefix As String
        Dim NewSuffix As String, NewSpeed As Integer, NewDamage As Integer

        If OldSlot = 0 Or NewSlot = 0 Then Exit Sub

        OldNum = GetPlayerSkill(index, OldSlot)
        OldValue = GetPlayerSkillCD(index, OldSlot)
        NewNum = GetPlayerSkill(index, NewSlot)
        NewValue = GetPlayerSkillCD(index, NewSlot)

        If OldNum = NewNum And Item(NewNum).Stackable = 1 Then ' same item, if we can stack it, lets do that :P
            SetPlayerSkill(index, NewSlot, NewNum)
            SetPlayerSkillCD(index, NewSlot, NewValue)
            SetPlayerSkill(index, OldSlot, 0)
            SetPlayerSkillCD(index, OldSlot, 0)
        Else
            SetPlayerSkill(index, NewSlot, OldNum)
            SetPlayerSkillCD(index, NewSlot, OldValue)
            SetPlayerSkill(index, OldSlot, NewNum)
            SetPlayerSkillCD(index, OldSlot, NewValue)
        End If

        SendPlayerSkills(index)
    End Sub

#End Region

#Region "Equipment"

    Sub CheckEquippedItems(index As Integer)
        Dim itemNum As Integer
        Dim i As Integer

        ' We want to check incase an admin takes away an object but they had it equipped
        For i = 1 To EquipmentType.Count - 1
            itemNum = GetPlayerEquipment(index, i)

            If itemNum > 0 Then

                Select Case i
                    Case EquipmentType.Weapon

                        If Item(itemNum).SubType <> EquipmentType.Weapon Then SetPlayerEquipment(index, 0, i)
                    Case EquipmentType.Armor

                        If Item(itemNum).SubType <> EquipmentType.Armor Then SetPlayerEquipment(index, 0, i)
                    Case EquipmentType.Helmet

                        If Item(itemNum).SubType <> EquipmentType.Helmet Then SetPlayerEquipment(index, 0, i)
                    Case EquipmentType.Shield

                        If Item(itemNum).SubType <> EquipmentType.Shield Then SetPlayerEquipment(index, 0, i)
                    Case EquipmentType.Shoes

                        If Item(itemNum).SubType <> EquipmentType.Shoes Then SetPlayerEquipment(index, 0, i)
                    Case EquipmentType.Gloves

                        If Item(itemNum).SubType <> EquipmentType.Gloves Then SetPlayerEquipment(index, 0, i)
                End Select
            Else
                SetPlayerEquipment(index, 0, i)
            End If

        Next

    End Sub

    Sub PlayerUnequipItem(index As Integer, EqSlot As Integer)
        Dim i As Integer, m As Integer, itemnum As Integer

        If EqSlot < 1 Or EqSlot > EquipmentType.Count - 1 Then Exit Sub ' exit out early if error'd

        If FindOpenInvSlot(index, GetPlayerEquipment(index, EqSlot)) > 0 Then
            itemnum = GetPlayerEquipment(index, EqSlot)

            m = FindOpenInvSlot(index, Player(index).Equipment(EqSlot))
            SetPlayerInvItemNum(index, m, Player(index).Equipment(EqSlot))
            SetPlayerInvItemValue(index, m, 0)

            PlayerMsg(index, "You unequip " & CheckGrammar(Item(GetPlayerEquipment(index, EqSlot)).Name), ColorType.Yellow)

            ' remove equipment
            SetPlayerEquipment(index, 0, EqSlot)
            SendWornEquipment(index)
            SendMapEquipment(index)
            SendStats(index)
            SendInventory(index)

            ' send vitals
            SendVitals(index)

            ' send vitals to party if in one
            If TempPlayer(index).InParty > 0 Then SendPartyVitals(TempPlayer(index).InParty, index)
        Else
            PlayerMsg(index, "Your inventory is full.", ColorType.BrightRed)
        End If

    End Sub

#End Region

#Region "Misc"

    Sub JoinGame(index As Integer)
        Dim i As Integer

        ' Set the flag so we know the person is in the game
        TempPlayer(index).InGame = True

        ' Notify everyone that a player has joined the game.
        GlobalMsg(String.Format("{0} has joined {1}!", GetPlayerName(index), Types.Settings.GameName))

        ' Warp the player to his saved location
        PlayerWarp(index, GetPlayerMap(index), GetPlayerX(index), GetPlayerY(index))

        ' Send all the required game data to the user.
        CheckEquippedItems(index)
        SendInventory(index)
        SendWornEquipment(index)
        SendMapEquipment(index)
        SendExp(index)
        SendHotbar(index)
        SendPlayerSkills(index)
        SendStats(index)
        SendJoinMap(index)
        SendUpdatePlayerPet(index, True)
        SendTimeTo(index)
        SendGameClockTo(index)
        SendPets(index)
        SendProjectiles(index)

        ' Send welcome messages
        SendWelcome(index)

        ' Send the flag so they know they can start doing stuff
        SendInGame(index)

        UpdateCaption()
    End Sub

    Sub LeftGame(index As Integer)
        Dim i As Integer
        Dim tradeTarget As Integer

        If TempPlayer(index).InGame Then
            SendLeftMap(index)
            TempPlayer(index).InGame = False

            ' Check if the player was in a party, and if so cancel it out so the other player doesn't continue to get half exp
            ' leave party.
            Party_PlayerLeave(index)

            ' cancel any trade they're in
            If TempPlayer(index).InTrade > 0 Then
                tradeTarget = TempPlayer(index).InTrade
                PlayerMsg(tradeTarget, String.Format("{0} has declined the trade.", GetPlayerName(index)), ColorType.BrightRed)
                ' clear out trade
                For i = 1 To MAX_INV
                    TempPlayer(tradeTarget).TradeOffer(i).Num = 0
                    TempPlayer(tradeTarget).TradeOffer(i).Value = 0
                Next
                TempPlayer(tradeTarget).InTrade = 0
                SendCloseTrade(tradeTarget)
            End If

            ' Send a global message that he/she left
            GlobalMsg(String.Format("{0} has left {1}!", GetPlayerName(index), Types.Settings.GameName))

            Console.WriteLine(String.Format("{0} has left {1}!", GetPlayerName(index), Types.Settings.GameName))

            ReCallPet(index)
            SaveCharacter(index, TempPlayer(index).Slot)
            SaveBank(index)
        End If

        ClearAccount(index)
        UpdateCaption()
    End Sub

    Friend Sub KillPlayer(index As Integer)
        Dim exp As Integer

        ' Calculate exp to give attacker
        exp = GetPlayerExp(index) \ 3

        ' Make sure we dont get less then 0
        If exp < 0 Then exp = 0
        If exp = 0 Then
            PlayerMsg(index, "You've lost no experience.", ColorType.BrightGreen)
        Else
            SetPlayerExp(index, GetPlayerExp(index) - exp)
            SendExp(index)
            PlayerMsg(index, String.Format("You've lost {0} experience.", exp), ColorType.BrightRed)
        End If

        OnDeath(index)
    End Sub

    Sub OnDeath(index As Integer)
        'Dim i As Integer

        ' Set HP to nothing
        SetPlayerVital(index, VitalType.HP, 0)

        ' Warp player away
        SetPlayerDir(index, DirectionType.Down)

        With Map(GetPlayerMap(index))
            ' to the bootmap if it is set
            If .BootMap > 0 Then
                PlayerWarp(index, .BootMap, .BootX, .BootY)
            Else
                PlayerWarp(index, Job(GetPlayerJob(index)).StartMap, Job(GetPlayerJob(index)).StartX, Job(GetPlayerJob(index)).StartY)
            End If
        End With

        ' Clear skill casting
        TempPlayer(index).SkillBuffer = 0
        TempPlayer(index).SkillBufferTimer = 0
        SendClearSkillBuffer(index)

        ' Restore vitals
        For i = 1 To VitalType.Count - 1
            SetPlayerVital(index, i, GetPlayerMaxVital(index, i))
        Next
        SendVitals(index)

        ' send vitals to party if in one
        If TempPlayer(index).InParty > 0 Then SendPartyVitals(TempPlayer(index).InParty, index)

        ' If the player the attacker killed was a pk then take it away
        If GetPlayerPK(index) = True Then
            SetPlayerPK(index, False)
            SendPlayerData(index)
        End If

    End Sub

    Function GetPlayerVitalRegen(index As Integer, Vital As VitalType) As Integer
        Dim i As Integer

        ' Prevent subscript out of range
        If IsPlaying(index) = False Or index < 0 Or index > MAX_PLAYERS Then
            GetPlayerVitalRegen = 0
            Exit Function
        End If

        Select Case Vital
            Case VitalType.HP
                i = (GetPlayerStat(index, StatType.Vitality) \ 2)
            Case VitalType.MP
                i = (GetPlayerStat(index, StatType.Spirit) \ 2)
            Case VitalType.SP
                i = (GetPlayerStat(index, StatType.Spirit) \ 2)
        End Select

        If i < 2 Then i = 2
        GetPlayerVitalRegen = i
    End Function

    Friend Sub HandleNpcKillExperience(index As Integer, NpcNum As Integer)
        ' Get the experience we'll have to hand out. If it's negative, just ignore this method.
        Dim Experience = NPC(NpcNum).Exp
        If Experience < 0 Then Exit Sub

        ' Is our player in a party? If so, hand out exp to everyone.
        If IsPlayerInParty(index) Then
            Party_ShareExp(GetPlayerParty(index), Experience, index, GetPlayerMap(index))
        Else
            GivePlayerExp(index, Experience)
        End If
    End Sub

    Friend Sub HandlePlayerKillExperience(Attacker As Integer, Victim As Integer)
        ' Calculate exp to give attacker
        Dim exp = (GetPlayerExp(Victim) \ 10)

        ' Make sure we dont get less then 0
        If exp < 0 Then
            exp = 0
        End If

        If exp = 0 Then
            PlayerMsg(Victim, "You've lost no exp.", ColorType.BrightRed)
            PlayerMsg(Attacker, "You've received no exp.", ColorType.BrightBlue)
        Else
            SetPlayerExp(Victim, GetPlayerExp(Victim) - exp)
            SendExp(Victim)
            PlayerMsg(Victim, String.Format("You've lost {0} exp.", exp), ColorType.BrightRed)

            ' check if we're in a party
            If IsPlayerInParty(Attacker) > 0 Then
                ' pass through party exp share function
                Party_ShareExp(GetPlayerParty(Attacker), exp, Attacker, GetPlayerMap(Attacker))
            Else
                ' not in party, get exp for self
                GivePlayerExp(Attacker, exp)
            End If
        End If
    End Sub

#End Region

#Region "Skills"
    Friend Sub BufferSkill(index As Integer, Skillslot As Integer)
        Dim skillnum As Integer
        Dim MPCost As Integer
        Dim LevelReq As Integer
        Dim mapNum As Integer
        Dim SkillCastType As Integer
        Dim JobReq As Integer
        Dim AccessReq As Integer
        Dim range As Integer
        Dim HasBuffered As Boolean

        Dim TargetType As TargetType
        Dim Target As Integer

        ' Prevent subscript out of range
        If Skillslot < 0 Or Skillslot > MAX_PLAYER_SKILLS Then Exit Sub

        skillnum = GetPlayerSkill(index, Skillslot)
        mapNum = GetPlayerMap(index)

        If skillnum <= 0 Or skillnum > MAX_SKILLS Then Exit Sub

        ' Make sure player has the skill
        If Not HasSkill(index, skillnum) Then Exit Sub

        ' see if cooldown has finished
        If TempPlayer(index).SkillCd(Skillslot) > GetTimeMs() Then
            PlayerMsg(index, "Skill hasn't cooled down yet!", ColorType.Yellow)
            Exit Sub
        End If

        MPCost = Skill(skillnum).MpCost

        ' Check if they have enough MP
        If GetPlayerVital(index, VitalType.MP) < MPCost Then
            PlayerMsg(index, "Not enough mana!", ColorType.Yellow)
            Exit Sub
        End If

        LevelReq = Skill(skillnum).LevelReq

        ' Make sure they are the right level
        If LevelReq > GetPlayerLevel(index) Then
            PlayerMsg(index, "You must be level " & LevelReq & " to use this skill.", ColorType.BrightRed)
            Exit Sub
        End If

        AccessReq = Skill(skillnum).AccessReq

        ' make sure they have the right access
        If AccessReq > GetPlayerAccess(index) Then
            PlayerMsg(index, "You must be an administrator to use this skill.", ColorType.BrightRed)
            Exit Sub
        End If

        JobReq = Skill(skillnum).JobReq

        ' make sure the JobReq > 0
        If JobReq > 0 Then ' 0 = no req
            If JobReq <> GetPlayerJob(index) Then
                PlayerMsg(index, "Only " & CheckGrammar(Trim$(Job(JobReq).Name)) & " can use this skill.", ColorType.Yellow)
                Exit Sub
            End If
        End If

        ' find out what kind of skill it is! self cast, target or AOE
        If Skill(skillnum).Range > 0 Then
            ' ranged attack, single target or aoe?
            If Not Skill(skillnum).IsAoE Then
                SkillCastType = 2 ' targetted
            Else
                SkillCastType = 3 ' targetted aoe
            End If
        Else
            If Not Skill(skillnum).IsAoE Then
                SkillCastType = 0 ' self-cast
            Else
                SkillCastType = 1 ' self-cast AoE
            End If
        End If

        TargetType = TempPlayer(index).TargetType
        Target = TempPlayer(index).Target
        range = Skill(skillnum).Range
        HasBuffered = False

        Select Case SkillCastType
            Case 0, 1 ' self-cast & self-cast AOE
                HasBuffered = True
            Case 2, 3 ' targeted & targeted AOE
                ' check if have target
                If Not Target > 0 Then
                    PlayerMsg(index, "You do not have a target.", ColorType.BrightRed)
                End If
                If TargetType = TargetType.Player Then
                    ' if have target, check in range
                    If Not IsInRange(range, GetPlayerX(index), GetPlayerY(index), GetPlayerX(Target), GetPlayerY(Target)) Then
                        PlayerMsg(index, "Target not in range.", ColorType.BrightRed)
                    Else
                        ' go through skill types
                        If Skill(skillnum).Type <> SkillType.DamageHp And Skill(skillnum).Type <> SkillType.DamageMp Then
                            HasBuffered = True
                        Else
                            If CanPlayerAttackPlayer(index, Target, True) Then
                                HasBuffered = True
                            End If
                        End If
                    End If
                ElseIf TargetType = TargetType.Npc Then
                    ' if have target, check in range
                    If Not IsInRange(range, GetPlayerX(index), GetPlayerY(index), MapNPC(mapNum).Npc(Target).X, MapNPC(mapNum).Npc(Target).Y) Then
                        PlayerMsg(index, "Target not in range.", ColorType.BrightRed)
                        HasBuffered = False
                    Else
                        ' go through skill types
                        If Skill(skillnum).Type <> SkillType.DamageHp And Skill(skillnum).Type <> SkillType.DamageMp Then
                            HasBuffered = True
                        Else
                            If CanPlayerAttackNpc(index, Target, True) Then
                                HasBuffered = True
                            End If
                        End If
                    End If
                End If
        End Select

        If HasBuffered Then
            SendAnimation(mapNum, Skill(skillnum).CastAnim, 0, 0, TargetType.Player, index)
            TempPlayer(index).SkillBuffer = Skillslot
            TempPlayer(index).SkillBufferTimer = GetTimeMs()
            Exit Sub
        Else
            SendClearSkillBuffer(index)
        End If
    End Sub



#End Region

#Region "Bank"

    Sub GiveBankItem(index As Integer, InvSlot As Integer, Amount As Integer)
        Dim BankSlot As Integer, itemnum As Integer

        If InvSlot <= 0 Or InvSlot > MAX_INV Then Exit Sub

        If GetPlayerInvItemValue(index, InvSlot) < 0 Then Exit Sub
        If GetPlayerInvItemValue(index, InvSlot) < Amount And GetPlayerInvItemNum(index, InvSlot) = 0 Then Exit Sub

        BankSlot = FindOpenBankSlot(index, GetPlayerInvItemNum(index, InvSlot))
        itemnum = GetPlayerInvItemNum(index, InvSlot)

        If BankSlot > 0 Then
            If Item(GetPlayerInvItemNum(index, InvSlot)).Type = ItemType.Currency Or Item(GetPlayerInvItemNum(index, InvSlot)).Stackable = 1 Then
                If GetPlayerBankItemNum(index, BankSlot) = GetPlayerInvItemNum(index, InvSlot) Then
                    SetPlayerBankItemValue(index, BankSlot, GetPlayerBankItemValue(index, BankSlot) + Amount)
                    TakeInvItem(index, GetPlayerInvItemNum(index, InvSlot), Amount)
                Else
                    SetPlayerBankItemNum(index, BankSlot, GetPlayerInvItemNum(index, InvSlot))
                    SetPlayerBankItemValue(index, BankSlot, Amount)
                    TakeInvItem(index, GetPlayerInvItemNum(index, InvSlot), Amount)
                End If
            Else
                If GetPlayerBankItemNum(index, BankSlot) = GetPlayerInvItemNum(index, InvSlot) And Item(itemnum).Randomize = 0 Then
                    SetPlayerBankItemValue(index, BankSlot, GetPlayerBankItemValue(index, BankSlot) + 1)
                    TakeInvItem(index, GetPlayerInvItemNum(index, InvSlot), 0)
                Else
                    SetPlayerBankItemNum(index, BankSlot, itemnum)
                    SetPlayerBankItemValue(index, BankSlot, 1)
                    TakeInvItem(index, GetPlayerInvItemNum(index, InvSlot), 0)
                End If
            End If

            SendBank(index)
        End If

    End Sub

    Function GetPlayerBankItemNum(index As Integer, BankSlot As Byte) As Integer
        GetPlayerBankItemNum = Bank(index).Item(BankSlot).Num
    End Function

    Sub SetPlayerBankItemNum(index As Integer, BankSlot As Byte, ItemNum As Integer)
        Bank(index).Item(BankSlot).Num = ItemNum
    End Sub

    Function GetPlayerBankItemValue(index As Integer, BankSlot As Byte) As Integer
        GetPlayerBankItemValue = Bank(index).Item(BankSlot).Value
    End Function

    Sub SetPlayerBankItemValue(index As Integer, BankSlot As Byte, ItemValue As Integer)
        Bank(index).Item(BankSlot).Value = ItemValue
    End Sub

    Function FindOpenBankSlot(index As Integer, ItemNum As Integer) As Byte
        Dim i As Integer

        If Not IsPlaying(index) Then Exit Function
        If Itemnum <= 0 Or ItemNum > MAX_ITEMS Then Exit Function

        If Item(ItemNum).Type = ItemType.Currency Or Item(ItemNum).Stackable = 1 Then
            For i = 1 To MAX_BANK
                If GetPlayerBankItemNum(index, i) = ItemNum Then
                    FindOpenBankSlot = i
                    Exit Function
                End If
            Next
        End If

        For i = 1 To MAX_BANK
            If GetPlayerBankItemNum(index, i) = 0 Then
                FindOpenBankSlot = i
                Exit Function
            End If
        Next

    End Function

    Sub TakeBankItem(index As Integer, BankSlot As Integer, Amount As Integer)
        Dim invSlot

        If BankSlot <= 0 Or BankSlot > MAX_BANK Then Exit Sub

        If GetPlayerBankItemValue(index, BankSlot) <= 0 Then Exit Sub

        If GetPlayerBankItemValue(index, BankSlot) < Amount Then Exit Sub

        invSlot = FindOpenInvSlot(index, GetPlayerBankItemNum(index, BankSlot))

        If invSlot > 0 Then
            If Item(GetPlayerBankItemNum(index, BankSlot)).Type = ItemType.Currency Or Item(GetPlayerBankItemNum(index, BankSlot)).Stackable = 1 Then
                GiveInvItem(index, GetPlayerBankItemNum(index, BankSlot), Amount)
                SetPlayerBankItemValue(index, BankSlot, GetPlayerBankItemValue(index, BankSlot) - Amount)
                If GetPlayerBankItemValue(index, BankSlot) < 0 Then
                    SetPlayerBankItemNum(index, BankSlot, 0)
                    SetPlayerBankItemValue(index, BankSlot, 0)
                End If
            Else
                If GetPlayerBankItemNum(index, BankSlot) = GetPlayerInvItemNum(index, invSlot) And Item(GetPlayerBankItemNum(index, BankSlot)).Randomize = 0 Then
                    If GetPlayerBankItemValue(index, BankSlot) > 1 Then
                        GiveInvItem(index, GetPlayerBankItemNum(index, BankSlot), 0)
                        SetPlayerBankItemValue(index, BankSlot, GetPlayerBankItemValue(index, BankSlot) - 1)
                    End If
                Else
                    GiveInvItem(index, GetPlayerBankItemNum(index, BankSlot), 0)
                    SetPlayerBankItemNum(index, BankSlot, 0)
                    SetPlayerBankItemValue(index, BankSlot, 0)
                End If
            End If

        End If

        SendBank(index)
    End Sub

    Sub PlayerSwitchBankSlots(index As Integer, OldSlot As Integer, NewSlot As Integer)
        Dim OldNum As Integer, OldValue As Integer, NewNum As Integer, NewValue As Integer
        Dim i As Integer

        If OldSlot = 0 Or NewSlot = 0 Then Exit Sub

        OldNum = GetPlayerBankItemNum(index, OldSlot)
        OldValue = GetPlayerBankItemValue(index, OldSlot)
        NewNum = GetPlayerBankItemNum(index, NewSlot)
        NewValue = GetPlayerBankItemValue(index, NewSlot)

        SetPlayerBankItemNum(index, NewSlot, OldNum)
        SetPlayerBankItemValue(index, NewSlot, OldValue)

        SetPlayerBankItemNum(index, OldSlot, NewNum)
        SetPlayerBankItemValue(index, OldSlot, NewValue)

        SendBank(index)
    End Sub

#End Region

End Module