Imports Mirage.Sharp.Asfw
Imports Core
Imports SFML.Graphics
Imports SFML.System
Imports Mirage.Core.Database.Types

Module C_Player
#Region "Database"
    Sub ClearPlayers()
        Dim i As Integer

        ReDim Accounts(MAX_PLAYERS)
        ReDim Player(MAX_PLAYERS)

        For i = 1 To MAX_PLAYERS
            ClearAccount(i)
            ClearPlayer(i)
        Next
    End Sub

    Sub ClearAccount(index As Integer)
        If Accounts(index) Is Nothing Then
            Accounts(index) = Nothing
        End If
        Accounts(index) = New Account()
    End Sub

    Sub ClearPlayer(index As Integer)
        ClearAccount(index)

        Player(index).Name = ""
        Player(index).Attacking = 0
        Player(index).AttackTimer = 0
        Player(index).Job = 1
        Player(index).Dir = 0
        Player(index).Access = AccessType.Player

        ReDim Player(index).Equipment(EquipmentType.Count - 1)
        For y = 0 To EquipmentType.Count - 1
            Player(index).Equipment(y) = -1
        Next

        Player(index).Exp = 0
        Player(index).Level = 0
        Player(index).Map = 1
        Player(index).MapGetTimer = 0
        Player(index).Moving = 0
        Player(index).Pk = 0
        Player(index).Points = 0
        Player(index).Sprite = 0

        ReDim Player(index).Inv(MAX_INV)
        For x = 1 To MAX_INV
            Player(index).Inv(x).Num = 0
            Player(index).Inv(x).Value = 0
        Next

        ReDim Player(index).Skill(MAX_PLAYER_SKILLS)
        For x = 1 To MAX_PLAYER_SKILLS
            Player(index).Skill(x).Num = 0
            Player(index).Skill(x).CD = 0
        Next

        ReDim Player(index).Stat(StatType.Count - 1)
        For x = 0 To StatType.Count - 1
            Player(index).Stat(x) = 0
        Next

        Player(index).Steps = 0

        ReDim Player(index).Vital(VitalType.Count - 1)
        For x = 0 To VitalType.Count - 1
            Player(index).Vital(x) = 0
        Next

        Player(index).X = 0
        Player(index).XOffset = 0
        Player(index).Y = 0
        Player(index).YOffset = 0

        ReDim Player(index).Hotbar(MAX_HOTBAR)
        ReDim Player(index).GatherSkills(ResourceType.Count - 1)
        ReDim Player(index).GatherSkills(ResourceType.Count - 1)

        Player(index).Pet.Num = 0
        Player(index).Pet.Health = 0
        Player(index).Pet.Mana = 0
        Player(index).Pet.Level = 0

        ReDim Player(index).Pet.Stat(StatType.Count - 1)
        For x = 0 To StatType.Count - 1
            Player(index).Pet.Stat(x) = 0
        Next

        ReDim Player(index).Pet.Skill(4)
        For x = 0 To 4
            Player(index).Pet.Skill(x) = 0
        Next

        Player(index).Pet.X = 0
        Player(index).Pet.Y = 0
        Player(index).Pet.Dir = 0
        Player(index).Pet.MaxHp = 0
        Player(index).Pet.MaxMp = 0
        Player(index).Pet.Alive = 0
        Player(index).Pet.AttackBehaviour = 0
        Player(index).Pet.Exp = 0
        Player(index).Pet.Tnl = 0
    End Sub
#End Region

#Region "Movement"
    Sub CheckMovement()
        If IsTryingToMove() And CanMove() Then
            ' Check if player has the shift key down for running
            If VbKeyShift Then
                Player(MyIndex).Moving = MovementType.Walking
            Else
                Player(MyIndex).Moving = MovementType.Running               
            End If

            Select Case GetPlayerDir(MyIndex)
                Case DirectionType.Up
                    SendPlayerMove()
                    Player(MyIndex).YOffset = PicY
                    SetPlayerY(MyIndex, GetPlayerY(MyIndex) - 1)
                Case DirectionType.Down
                    SendPlayerMove()
                    Player(MyIndex).YOffset = PicY * -1
                    SetPlayerY(MyIndex, GetPlayerY(MyIndex) + 1)
                Case DirectionType.Left
                    SendPlayerMove()
                    Player(MyIndex).XOffset = PicX
                    SetPlayerX(MyIndex, GetPlayerX(MyIndex) - 1)
                Case DirectionType.Right
                    SendPlayerMove()
                    Player(MyIndex).XOffset = PicX * -1
                    SetPlayerX(MyIndex, GetPlayerX(MyIndex) + 1)
            End Select

            If Player(MyIndex).XOffset = 0 And Player(MyIndex).YOffset = 0 Then
                If Map.Tile(GetPlayerX(MyIndex), GetPlayerY(MyIndex)).Type = TileType.Warp Or Map.Tile(GetPlayerX(MyIndex), GetPlayerY(MyIndex)).Type2 = TileType.Warp Then
                    GettingMap = True
                End If
            End If

        End If
    End Sub

    Function IsTryingToMove() As Boolean

        If DirUp Or DirDown Or DirLeft Or DirRight Then
            IsTryingToMove = True
        End If

    End Function

    Function CanMove() As Boolean
        Dim d As Integer
        CanMove = True

        If HoldPlayer = True Then
            CanMove = False
            Exit Function
        End If

        If GettingMap = True Then
            CanMove = False
            Exit Function
        End If

        ' Make sure they aren't trying to move when they are already moving
        If Player(MyIndex).Moving <> 0 Then
            CanMove = False
            Exit Function
        End If

        ' Make sure they haven't just casted a skill
        If SkillBuffer > 0 Then
            CanMove = False
            Exit Function
        End If

        ' make sure they're not stunned
        If StunDuration > 0 Then
            CanMove = False
            Exit Function
        End If

        If InBank Then
            CanMove = False
            Exit Function
        End If

        If InEvent Then
            CanMove = False
            Exit Function
        End If

        ' make sure they're not in a shop
        If InShop > 0 Then
            CanMove = False
            Exit Function
        End If

        If InTrade Then
            CanMove = False
            Exit Function
        End If

        If InBank Then
            CloseBank()
        End If

        If Not inSmallChat Then
            CanMove = False
            Exit Function
        End If

        d = GetPlayerDir(MyIndex)

        If DirUp Then
            SetPlayerDir(MyIndex, DirectionType.Up)

            ' Check to see if they are trying to go out of bounds
            If GetPlayerY(MyIndex) > 0 Then
                If CheckDirection(DirectionType.Up) Then
                    CanMove = False

                    ' Set the new direction if they weren't facing that direction
                    If d <> DirectionType.Up Then
                        SendPlayerDir()
                    End If

                    Exit Function
                End If
            Else

                ' Check if they can warp to a new map
                If Map.Up > 0 Then
                    SendPlayerRequestNewMap()
                End If

                CanMove = False
                Exit Function
            End If
        End If

        If DirDown Then
            SetPlayerDir(MyIndex, DirectionType.Down)

            ' Check to see if they are trying to go out of bounds
            If GetPlayerY(MyIndex) < Map.MaxY Then
                If CheckDirection(DirectionType.Down) Then
                    CanMove = False

                    ' Set the new direction if they weren't facing that direction
                    If d <> DirectionType.Down Then
                        SendPlayerDir()
                    End If

                    Exit Function
                End If
            Else

                ' Check if they can warp to a new map
                If Map.Down > 0 Then
                    SendPlayerRequestNewMap()
                End If

                CanMove = False
                Exit Function
            End If
        End If

        If DirLeft Then
            SetPlayerDir(MyIndex, DirectionType.Left)

            ' Check to see if they are trying to go out of bounds
            If GetPlayerX(MyIndex) > 0 Then
                If CheckDirection(DirectionType.Left) Then
                    CanMove = False

                    ' Set the new direction if they weren't facing that direction
                    If d <> DirectionType.Left Then
                        SendPlayerDir()
                    End If

                    Exit Function
                End If
            Else

                ' Check if they can warp to a new map
                If Map.Left > 0 Then
                    SendPlayerRequestNewMap()
                End If

                CanMove = False
                Exit Function
            End If
        End If

        If DirRight Then
            SetPlayerDir(MyIndex, DirectionType.Right)

            ' Check to see if they are trying to go out of bounds
            If GetPlayerX(MyIndex) < Map.MaxX Then
                If CheckDirection(DirectionType.Right) Then
                    CanMove = False

                    ' Set the new direction if they weren't facing that direction
                    If d <> DirectionType.Right Then
                        SendPlayerDir()
                    End If

                    Exit Function
                End If
            Else
                ' Check if they can warp to a new map
                If Map.Right > 0 Then
                    SendPlayerRequestNewMap()
                End If

                CanMove = False
                Exit Function
            End If
        End If

    End Function

    Function CheckDirection(direction As Byte) As Boolean
        Dim x As Integer, y As Integer
        Dim i As Integer

        CheckDirection = False

        ' check directional blocking
        If IsDirBlocked(Map.Tile(GetPlayerX(MyIndex), GetPlayerY(MyIndex)).DirBlock, direction) Then
            CheckDirection = True
            Exit Function
        End If

        Select Case direction
            Case DirectionType.Up
                x = GetPlayerX(MyIndex)
                y = GetPlayerY(MyIndex) - 1
            Case DirectionType.Down
                x = GetPlayerX(MyIndex)
                y = GetPlayerY(MyIndex) + 1
            Case DirectionType.Left
                x = GetPlayerX(MyIndex) - 1
                y = GetPlayerY(MyIndex)
            Case DirectionType.Right
                x = GetPlayerX(MyIndex) + 1
                y = GetPlayerY(MyIndex)
        End Select

        ' Check to see if the map tile is blocked or not
        If Map.Tile(x, y).Type = TileType.Blocked Or Map.Tile(x, y).Type2 = TileType.Blocked Then
            CheckDirection = True
            Exit Function
        End If

        ' Check to see if the map tile is tree or not
        If Map.Tile(x, y).Type = TileType.Resource Or Map.Tile(x, y).Type2 = TileType.Resource Then
            CheckDirection = True
            Exit Function
        End If

        ' Check to see if a player is already on that tile
        If Map.Moral > 0 Then
            If Moral(Map.Moral).PlayerBlock Then
                For i = 1 To MAX_PLAYERS
                    If IsPlaying(i) Then
                        If Player(i).X = x And Player(i).Y = y Then
                            CheckDirection = True
                            Exit Function
                        End If
                    End If
                Next
            End If

            ' Check to see if a npc is already on that tile
            If Moral(Map.Moral).NPCBlock Then
                For i = 1 To MAX_MAP_NPCS
                    If MapNpc(i).Num > 0 And MapNpc(i).X = x And MapNpc(i).Y = y Then
                        CheckDirection = True
                        Exit Function
                    End If
                Next
            End If
        End If

        For i = 1 To CurrentEvents
            If MapEvents(i).Visible = 1 Then
                If MapEvents(i).X = x And MapEvents(i).Y = y Then
                    If MapEvents(i).WalkThrough = 0 Then
                        CheckDirection = True
                        Exit Function
                    End If
                End If
            End If
        Next

    End Function

    Sub ProcessMovement(index As Integer)
        Dim movementSpeed As Integer

        ' Check if player is walking, and if so process moving them over
        Select Case Player(index).Moving
            Case MovementType.Walking : movementSpeed = ((ElapsedTime / 1000) * (WalkSpeed * SizeX))
            Case MovementType.Running : movementSpeed = ((ElapsedTime / 1000) * (RunSpeed * SizeX))
            Case Else : Exit Sub
        End Select

        Select Case GetPlayerDir(index)
            Case DirectionType.Up
                Player(index).YOffset = Player(index).YOffset - movementSpeed
                If Player(index).YOffset < 0 Then Player(index).YOffset = 0
            Case DirectionType.Down
                Player(index).YOffset = Player(index).YOffset + movementSpeed
                If Player(index).YOffset > 0 Then Player(index).YOffset = 0
            Case DirectionType.Left
                Player(index).XOffset = Player(index).XOffset - movementSpeed
                If Player(index).XOffset < 0 Then Player(index).XOffset = 0
            Case DirectionType.Right
                Player(index).XOffset = Player(index).XOffset + movementSpeed
                If Player(index).XOffset > 0 Then Player(index).XOffset = 0
        End Select

        ' Check if completed walking over to the next tile
        If Player(Index).Moving > 0 Then
            If GetPlayerDir(Index) = DirectionType.Right Or GetPlayerDir(Index) = DirectionType.Down Then
                If (Player(Index).XOffset >= 0) And (Player(Index).YOffset >= 0) Then
                    Player(Index).Moving = 0
                    If Player(Index).Steps = 1 Then
                        Player(Index).Steps = 3
                    Else
                        Player(index).Steps = 1
                    End If
                End If
            Else
                If (Player(Index).XOffset <= 0) And (Player(Index).YOffset <= 0) Then
                    Player(Index).Moving = 0
                    If Player(Index).Steps = 1 Then
                        Player(Index).Steps = 3
                    Else
                        Player(index).Steps = 1
                    End If
                End If
            End If
        End If

    End Sub

#End Region

#Region "Attacking"
    Sub CheckAttack()
        Dim attackspeed As Integer, x As Integer, y As Integer
        Dim buffer As New ByteStream(4)

        If VbKeyControl Then
            If InEvent = True Then Exit Sub
            If SkillBuffer > 0 Then Exit Sub ' currently casting a skill, can't attack
            If StunDuration > 0 Then Exit Sub ' stunned, can't attack

            ' speed from weapon
            If GetPlayerEquipment(MyIndex, EquipmentType.Weapon) > 0 Then
                attackspeed = Item(GetPlayerEquipment(MyIndex, EquipmentType.Weapon)).Speed * 1000
            Else
                attackspeed = 1000
            End If

            If Player(MyIndex).AttackTimer + attackspeed < GetTickCount() Then
                If Player(MyIndex).Attacking = 0 Then

                    With Player(MyIndex)
                        .Attacking = 1
                        .AttackTimer = GetTickCount()
                    End With

                    SendAttack()
                End If
            End If

            Select Case Player(MyIndex).Dir
                Case DirectionType.Up
                    x = GetPlayerX(MyIndex)
                    y = GetPlayerY(MyIndex) - 1
                Case DirectionType.Down
                    x = GetPlayerX(MyIndex)
                    y = GetPlayerY(MyIndex) + 1
                Case DirectionType.Left
                    x = GetPlayerX(MyIndex) - 1
                    y = GetPlayerY(MyIndex)
                Case DirectionType.Right
                    x = GetPlayerX(MyIndex) + 1
                    y = GetPlayerY(MyIndex)
            End Select

            If GetTickCount() > Player(MyIndex).EventTimer Then
                For i = 1 To CurrentEvents
                    If MapEvents(i).Visible = 1 Then
                        If MapEvents(i).X = x And MapEvents(i).Y = y Then
                            buffer = New ByteStream(4)
                            buffer.WriteInt32(ClientPackets.CEvent)
                            buffer.WriteInt32(i)
                            Socket.SendData(buffer.Data, buffer.Head)
                            buffer.Dispose()
                            Player(MyIndex).EventTimer = GetTickCount() + 200
                        End If
                    End If
                Next
            End If
        End If

    End Sub

    Friend Sub PlayerCastSkill(skillslot As Integer)
        Dim buffer As New ByteStream(4)

        ' Check for subscript out of range
        If skillslot <= 0 Or skillslot > MAX_PLAYER_SKILLS Then Exit Sub

        If Player(MyIndex).Skill(skillslot).CD > 0 Then
            AddText("Skill has not cooled down yet!", ColorType.BrightRed)
            Exit Sub
        End If

        ' Check if player has enough MP
        If GetPlayerVital(MyIndex, VitalType.SP) < Skill(Player(MyIndex).Skill(skillslot).Num).MpCost Then
            AddText("Not enough MP to cast " & Trim$(Skill(Player(MyIndex).Skill(skillslot).Num).Name) & ".", ColorType.BrightRed)
            Exit Sub
        End If

        If Player(MyIndex).Skill(skillslot).Num > 0 Then
            If GetTickCount() > Player(MyIndex).AttackTimer + 1000 Then
                If Player(MyIndex).Moving = 0 Then
                    If Map.Moral > 0 Then
                        If Moral(Map.Moral).CanCast Then
                            SendCast(skillSlot)
                        Else 
                            AddText("Cannot cast here!", ColorType.BrightRed)
                        End If
                    End If
                Else
                    AddText("Cannot cast while walking!", ColorType.BrightRed)
                End If
            End If
        Else
            AddText("No skill here.", ColorType.BrightRed)
        End If

    End Sub

    Function FindSkill(skillNum As Integer) As Integer
        Dim i As Integer

        FindSkill = 0

        ' Check for subscript out of range
        If skillNum <= 0 Or skillNum > MAX_SKILLS Then
            Exit Function
        End If

        For i = 1 To MAX_PLAYER_SKILLS
            ' Check to see if the player has the skill
            If GetPlayerSkill(Myindex, i) = skillNum Then
                FindSkill = i
                Exit Function
            End If
        Next

    End Function

#End Region

#Region "Drawing"
    Friend Sub DrawPlayer(index As Integer)
        Dim anim As Byte, x As Integer, y As Integer
        Dim spritenum As Integer, spriteleft As Integer
        Dim attackspeed As Integer
        Dim rect As Rectangle

        spritenum = GetPlayerSprite(index)

        If spritenum <= 0 Or spritenum > NumCharacters Then Exit Sub

        ' speed from weapon
        If GetPlayerEquipment(index, EquipmentType.Weapon) > 0 Then
            attackspeed = Item(GetPlayerEquipment(index, EquipmentType.Weapon)).Speed
        Else
            attackspeed = 1000
        End If

        ' Reset frame
        anim = 0

        ' Check for attacking animation
        If Player(index).AttackTimer + (attackspeed / 2) > GetTickCount() Then
            If Player(index).Attacking = 1 Then
                anim = 3
            End If
        Else
            ' If not attacking, walk normally
            Select Case GetPlayerDir(index)
                Case DirectionType.Up

                    If (Player(index).YOffset > 8) Then anim = Player(index).Steps
                Case DirectionType.Down

                    If (Player(index).YOffset < -8) Then anim = Player(index).Steps
                Case DirectionType.Left

                    If (Player(index).XOffset > 8) Then anim = Player(index).Steps
                Case DirectionType.Right

                    If (Player(index).XOffset < -8) Then anim = Player(index).Steps
            End Select

        End If

        ' Check to see if we want to stop making him attack
        With Player(index)
            If .AttackTimer + attackspeed < GetTickCount() Then
                .Attacking = 0
                .AttackTimer = 0
            End If

        End With

        ' Set the left
        Select Case GetPlayerDir(index)
            Case DirectionType.Up
                spriteleft = 3
            Case DirectionType.Right
                spriteleft = 2
            Case DirectionType.Down
                spriteleft = 0
            Case DirectionType.Left
                spriteleft = 1
        End Select

        ' Calculate the X
        x = Player(index).X * PicX + Player(index).XOffset - ((CharacterGfxInfo(spritenum).Width / 4 - 32) / 2)

        ' Is the player's height more than 32..?
        If (CharacterGfxInfo(spritenum).Height) > 32 Then
            ' Create a 32 pixel offset for larger sprites
            y = GetPlayerY(index) * PicY + Player(index).YOffset - ((CharacterGfxInfo(spritenum).Height / 4) - 32)
        Else
            ' Proceed as normal
            y = GetPlayerY(index) * PicY + Player(index).YOffset
        End If

        rect = New Rectangle((anim) * (CharacterGfxInfo(spritenum).Width / 4), spriteleft * (CharacterGfxInfo(spritenum).Height / 4),
                               (CharacterGfxInfo(spritenum).Width / 4), (CharacterGfxInfo(spritenum).Height / 4))

        ' render the actual sprite
        DrawShadow(x, y + 16)
        DrawCharacterSprite(spritenum, x, y, rect)

        'check for paperdolling
        For i = 1 To EquipmentType.Count - 1
            If GetPlayerEquipment(index, i) > 0 Then
                If Item(GetPlayerEquipment(index, i)).Paperdoll > 0 Then
                    DrawPaperdoll(x, y, Item(GetPlayerEquipment(index, i)).Paperdoll, anim, spriteleft)
                End If
            End If
        Next

        ' Check to see if we want to stop showing emote
        With Player(index)
            If .EmoteTimer < GetTickCount() Then
                .Emote = 0
                .EmoteTimer = 0
            End If
        End With

        'check for emotes
        If Player(MyIndex).Emote > 0 Then
            DrawEmote(x, y, Player(MyIndex).Emote)
        End If
    End Sub

    Friend Sub DrawPlayerName(index As Integer)
        Dim textX As Integer
        Dim textY As Integer
        Dim color As SFML.Graphics.Color, backcolor As SFML.Graphics.Color
        Dim name As String

        ' Check access level
        If GetPlayerPK(index) = False Then
            Select Case GetPlayerAccess(index)
                Case AccessType.Player
                    color = SFML.Graphics.Color.White
                    backcolor = SFML.Graphics.Color.Black
                Case AccessType.Moderator
                    color = SFML.Graphics.Color.Cyan
                    backcolor = SFML.Graphics.Color.White
                Case AccessType.Mapper
                    color = SFML.Graphics.Color.Green
                    backcolor = SFML.Graphics.Color.Black
                Case AccessType.Developer
                    color = SFML.Graphics.Color.Magenta
                    backcolor = SFML.Graphics.Color.Black
                Case AccessType.Creator
                    color = SFML.Graphics.Color.Yellow
                    backcolor = SFML.Graphics.Color.Black
            End Select
        Else
            color = SFML.Graphics.Color.Red
        End If

        name = Player(index).Name

        ' calc pos
        textX = ConvertMapX(GetPlayerX(index) * PicX) + Player(index).XOffset + (PicX \ 2) - 2
        textX = textX - (TextWidth((name)) / 2)

        If GetPlayerSprite(index) < 0 Or GetPlayerSprite(index) > NumCharacters Then
            textY = ConvertMapY(GetPlayerY(index) * PicY) + Player(MyIndex).YOffset - 16
        Else
            ' Determine location for text
            textY = ConvertMapY(GetPlayerY(index) * PicY) + Player(index).YOffset - (CharacterGfxInfo(GetPlayerSprite(index)).Height / 4) + 16
        End If

        ' Draw name
        RenderText(name, Window, textX, textY, color, backcolor)
    End Sub

#End Region

#Region "Outgoing Traffic"

#End Region

#Region "Incoming Traffic"
    Sub Packet_PlayerHP(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)

        SetPlayerVital(MyIndex, VitalType.HP, buffer.ReadInt32)

        ' set max width
        If GetPlayerVital(MyIndex, VitalType.HP) > 0 Then
            BarWidth_GuiHP_Max = ((GetPlayerVital(MyIndex, VitalType.HP) / 209) / (GetPlayerMaxVital(MyIndex, VitalType.HP) / 209)) * 209
        Else
            BarWidth_GuiHP_Max = 0
        End If

        UpdateStats_UI()

        buffer.Dispose()
    End Sub

    Sub Packet_PlayerMP(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)

        SetPlayerVital(MyIndex, VitalType.SP, buffer.ReadInt32)

        ' set max width
        If GetPlayerVital(MyIndex, VitalType.SP) > 0 Then
            BarWidth_GuiSP_Max = ((GetPlayerVital(MyIndex, VitalType.SP) / 209) / (GetPlayerMaxVital(MyIndex, VitalType.SP) / 209)) * 209
        Else
            BarWidth_GuiSP_Max = 0
        End If

        UpdateStats_UI()

        buffer.Dispose()
    End Sub

    Sub Packet_PlayerSP(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)

        SetPlayerVital(MyIndex, VitalType.SP, buffer.ReadInt32)

        buffer.Dispose()
    End Sub

    Sub Packet_PlayerStats(ByRef data() As Byte)
        Dim i As Integer, index As Integer
        Dim buffer As New ByteStream(data)

        index = buffer.ReadInt32

        For i = 1 To StatType.Count - 1
            SetPlayerStat(index, i, buffer.ReadInt32)
        Next

        buffer.Dispose()
    End Sub

    Sub Packet_PlayerData(ByRef data() As Byte)
        Dim i As Integer, x As Integer
        Dim buffer As New ByteStream(data)

        i = buffer.ReadInt32
        SetPlayerName(i, buffer.ReadString)
        SetPlayerJob(i, buffer.ReadInt32)
        SetPlayerLevel(i, buffer.ReadInt32)
        SetPlayerPoints(i, buffer.ReadInt32)
        SetPlayerSprite(i, buffer.ReadInt32)
        SetPlayerMap(i, buffer.ReadInt32)
        SetPlayerAccess(i, buffer.ReadInt32)
        SetPlayerPk(i, buffer.ReadInt32)

        For x = 1 To StatType.Count - 1
            SetPlayerStat(i, x, buffer.ReadInt32)
        Next

        For x = 1 To ResourceType.Count - 1
            Player(i).GatherSkills(x).SkillLevel = buffer.ReadInt32
            Player(i).GatherSkills(x).SkillCurExp = buffer.ReadInt32
            Player(i).GatherSkills(x).SkillNextLvlExp = buffer.ReadInt32
        Next

        ' Check if the player is the client player
        If i = MyIndex Then
            ' Reset directions
            DirUp = False
            DirDown = False
            DirLeft = False
            DirRight = False

            ' set form
            With Windows(GetWindowIndex("winCharacter"))
                .Controls(GetControlIndex("winCharacter", "lblName")).Text = "Name"
                .Controls(GetControlIndex("winCharacter", "lblClass")).Text = "Class"
                .Controls(GetControlIndex("winCharacter", "lblLevel")).Text = "Level"
                .Controls(GetControlIndex("winCharacter", "lblGuild")).Text = "Guild"
                .Controls(GetControlIndex("winCharacter", "lblName2")).Text = Trim$(GetPlayerName(MyIndex))
                .Controls(GetControlIndex("winCharacter", "lblClass2")).Text =Trim$(Job(GetPlayerJob(MyIndex)).Name)
                .Controls(GetControlIndex("winCharacter", "lblLevel2")).Text = GetPlayerLevel(MyIndex)
                .Controls(GetControlIndex("winCharacter", "lblGuild2")).Text = "None"
                UpdateStats_UI()

                ' stats
                For x = 1 To StatType.Count - 1
                    .Controls(GetControlIndex("winCharacter", "lblStat_" & x)).Text = GetPlayerStat(MyIndex, x)
                Next

                ' points
                .Controls(GetControlIndex("winCharacter", "lblPoints")).Text = GetPlayerPoints(MyIndex)

                ' grey out buttons
                If GetPlayerPoints(MyIndex) = 0 Then
                    For x = 1 To StatType.Count - 1
                        .Controls(GetControlIndex("winCharacter", "btnGreyStat_" & x)).Visible = True
                    Next
                Else
                    For x = 1 To StatType.Count - 1
                        .Controls(GetControlIndex("winCharacter", "btnGreyStat_" & x)).Visible = False
                    Next
                End If
            End With
            PlayerData = True
        End If

        buffer.Dispose()
    End Sub

    Sub Packet_PlayerMove(ByRef data() As Byte)
        Dim i As Integer, x As Integer, y As Integer
        Dim dir As Integer, n As Byte
        Dim buffer As New ByteStream(data)

        i = buffer.ReadInt32
        x = buffer.ReadInt32
        y = buffer.ReadInt32
        dir = buffer.ReadInt32
        n = buffer.ReadInt32

        SetPlayerX(i, x)
        SetPlayerY(i, y)
        SetPlayerDir(i, dir)
        Player(i).XOffset = 0
        Player(i).YOffset = 0
        Player(i).Moving = n

        Select Case GetPlayerDir(i)
            Case DirectionType.Up
                Player(i).YOffset = PicY
            Case DirectionType.Down
                Player(i).YOffset = PicY * -1
            Case DirectionType.Left
                Player(i).XOffset = PicX
            Case DirectionType.Right
                Player(i).XOffset = PicX * -1
        End Select

        buffer.Dispose()
    End Sub

    Sub Packet_PlayerDir(ByRef data() As Byte)
        Dim dir As Integer, i As Integer
        Dim buffer As New ByteStream(data)
        i = buffer.ReadInt32
        dir = buffer.ReadInt32

        SetPlayerDir(i, dir)

        With Player(i)
            .XOffset = 0
            .YOffset = 0
            .Moving = 0
        End With

        buffer.Dispose()
    End Sub

    Sub Packet_PlayerExp(ByRef data() As Byte)
        Dim index As Integer, tnl As Integer
        Dim buffer As New ByteStream(data)

        index = buffer.ReadInt32
        SetPlayerExp(index, buffer.ReadInt32)

        tnl = buffer.ReadInt32
        NextlevelExp = tnl

        ' set max width
        If GetPlayerLevel(MyIndex) <= MAX_LEVEL Then
            If GetPlayerExp(MyIndex) > 0 Then
                BarWidth_GuiEXP_Max = ((GetPlayerExp(MyIndex) / 209) / (tnl / 209)) * 209
            Else
                BarWidth_GuiEXP_Max = 0
            End If
        Else
            BarWidth_GuiEXP_Max = 209
        End If

        ' Update GUI
        UpdateStats_UI()

        buffer.Dispose()
    End Sub

    Sub Packet_PlayerXY(ByRef data() As Byte)
        Dim x As Integer, y As Integer, dir As Integer, index As Integer
        Dim buffer As New ByteStream(data)

        index = buffer.ReadInt32
        x = buffer.ReadInt32
        y = buffer.ReadInt32
        dir = buffer.ReadInt32

        SetPlayerX(index, x)
        SetPlayerY(index, y)
        SetPlayerDir(index, dir)

        ' Make sure they aren't walking
        Player(index).Moving = 0
        Player(index).XOffset = 0
        Player(index).YOffset = 0

        buffer.Dispose()
    End Sub
#End Region

End Module