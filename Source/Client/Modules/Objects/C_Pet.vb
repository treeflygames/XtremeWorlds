Imports System.Drawing
Imports Core
Imports Mirage.Sharp.Asfw

Module C_Pets

#Region "Globals etc"

    Friend Pet() As PetStruct

    Friend Const PetbarTop As Byte = 2
    Friend Const PetbarLeft As Byte = 2
    Friend Const PetbarOffsetX As Byte = 4
    Friend Const MaxPetbar As Byte = 7
    Friend Const PetHpBarWidth As Integer = 129
    Friend Const PetMpBarWidth As Integer = 129

    Friend PetSkillBuffer As Integer
    Friend PetSkillBufferTimer As Integer
    Friend PetSkillCd() As Integer

    'Pet Constants
    Friend Const PetBehaviourFollow As Byte = 0 'The pet will attack all npcs around

    Friend Const PetBehaviourGoto As Byte = 1 'If attacked, the pet will fight back
    Friend Const PetAttackBehaviourAttackonsight As Byte = 2 'The pet will attack all npcs around
    Friend Const PetAttackBehaviourGuard As Byte = 3 'If attacked, the pet will fight back
    Friend Const PetAttackBehaviourDonothing As Byte = 4 'The pet will not attack even if attacked

#End Region

#Region "Database"

    Sub ClearPet(index As Integer)
        Pet(index) = Nothing
        Pet(index).Name = ""

        ReDim Pet(index).Stat(StatType.Count - 1)
        ReDim Pet(index).Skill(4)
        Pet_Loaded(index) = False
    End Sub

    Sub ClearPets()
        Dim i As Integer

        ReDim Pet(MAX_PETS)
        ReDim PetSkillCd(4)

        For i = 1 To MAX_PETS
            ClearPet(i)
        Next

    End Sub

    Sub StreamPet(petNum As Integer)
        If petNum > 0 And Pet(petNum).Name = "" Or Pet_Loaded(petNum) = False Then
            Pet_Loaded(petNum) = True
            SendRequestPet(petNum)
        End If
    End Sub

#End Region

#Region "Outgoing Packets"
    Sub SendRequestPet(petNum As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CRequestPet)

        buffer.WriteInt32(petNum)
        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub SendPetBehaviour(index As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CSetBehaviour)

        buffer.WriteInt32(index)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

    Sub SendTrainPetStat(statNum As Byte)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CPetUseStatPoint)

        buffer.WriteInt32(statNum)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

    Sub SendRequestPets()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CRequestPets)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

    Sub SendUsePetSkill(skill As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CPetSkill)
        buffer.WriteInt32(skill)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

        PetSkillBuffer = skill
        PetSkillBufferTimer = GetTickCount()
    End Sub

    Sub SendSummonPet()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CSummonPet)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

    Sub SendReleasePet()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CReleasePet)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

    Friend Sub SendRequestEditPet()
        Dim buffer As ByteStream
        buffer = New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CRequestEditPet)

        Socket.SendData(buffer.Data, buffer.Head)

        buffer.Dispose()

    End Sub

    Friend Sub SendSavePet(petNum As Integer)
        Dim buffer As ByteStream
        Dim i As Integer

        buffer = New ByteStream(4)
        buffer.WriteInt32(ClientPackets.CSavePet)
        buffer.WriteInt32(petNum)

        With Pet(petNum)
            buffer.WriteInt32(.Num)
            buffer.WriteString((Trim$(.Name)))
            buffer.WriteInt32(.Sprite)
            buffer.WriteInt32(.Range)
            buffer.WriteInt32(.Level)
            buffer.WriteInt32(.MaxLevel)
            buffer.WriteInt32(.ExpGain)
            buffer.WriteInt32(.LevelPnts)
            buffer.WriteInt32(.StatType)
            buffer.WriteInt32(.LevelingType)

            For i = 1 To StatType.Count - 1
                buffer.WriteInt32(.Stat(i))
            Next

            For i = 1 To 4
                buffer.WriteInt32(.Skill(i))
            Next

            buffer.WriteInt32(.Evolvable)
            buffer.WriteInt32(.EvolveLevel)
            buffer.WriteInt32(.EvolveNum)
        End With

        Socket.SendData(buffer.Data, buffer.Head)

        buffer.Dispose()

    End Sub
#End Region

#Region "Incoming Packets"

    Friend Sub Packet_UpdatePlayerPet(ByRef data() As Byte)
        Dim n As Integer, i As Integer
        Dim buffer As New ByteStream(data)
        n = buffer.ReadInt32

        'pet
        Player(n).Pet.Num = buffer.ReadInt32
        Player(n).Pet.Health = buffer.ReadInt32
        Player(n).Pet.Mana = buffer.ReadInt32
        Player(n).Pet.Level = buffer.ReadInt32

        For i = 1 To StatType.Count - 1
            Player(n).Pet.Stat(i) = buffer.ReadInt32
        Next

        For i = 1 To 4
            Player(n).Pet.Skill(i) = buffer.ReadInt32
        Next

        Player(n).Pet.X = buffer.ReadInt32
        Player(n).Pet.Y = buffer.ReadInt32
        Player(n).Pet.Dir = buffer.ReadInt32

        Player(n).Pet.MaxHp = buffer.ReadInt32
        Player(n).Pet.MaxMp = buffer.ReadInt32

        Player(n).Pet.Alive = buffer.ReadInt32

        Player(n).Pet.AttackBehaviour = buffer.ReadInt32
        Player(n).Pet.Points = buffer.ReadInt32
        Player(n).Pet.Exp = buffer.ReadInt32
        Player(n).Pet.Tnl = buffer.ReadInt32

        buffer.Dispose()
    End Sub

    Friend Sub Packet_UpdatePet(ByRef data() As Byte)
        Dim n As Integer, i As Integer
        Dim buffer As New ByteStream(data)
        n = buffer.ReadInt32

        With Pet(n)
            .Num = buffer.ReadInt32
            .Name = buffer.ReadString
            .Sprite = buffer.ReadInt32
            .Range = buffer.ReadInt32
            .Level = buffer.ReadInt32
            .MaxLevel = buffer.ReadInt32
            .ExpGain = buffer.ReadInt32
            .LevelPnts = buffer.ReadInt32
            .StatType = buffer.ReadInt32
            .LevelingType = buffer.ReadInt32

            For i = 1 To StatType.Count - 1
                .Stat(i) = buffer.ReadInt32
            Next

            For i = 1 To 4
                .Skill(i) = buffer.ReadInt32
            Next

            .Evolvable = buffer.ReadInt32
            .EvolveLevel = buffer.ReadInt32
            .EvolveNum = buffer.ReadInt32
        End With

        buffer.Dispose()

    End Sub

    Friend Sub Packet_PetMove(ByRef data() As Byte)
        Dim i As Integer, x As Integer, y As Integer
        Dim dir As Integer, movement As Integer
        Dim buffer As New ByteStream(data)
        i = buffer.ReadInt32
        x = buffer.ReadInt32
        y = buffer.ReadInt32
        dir = buffer.ReadInt32
        movement = buffer.ReadInt32

        With Player(i).Pet
            .X = x
            .Y = y
            .Dir = dir
            .XOffset = 0
            .YOffset = 0
            .Moving = movement

            Select Case .Dir
                Case DirectionType.Up
                    .YOffset = PicY
                Case DirectionType.Down
                    .YOffset = PicY * -1
                Case DirectionType.Left
                    .XOffset = PicX
                Case DirectionType.Right
                    .XOffset = PicX * -1
            End Select
        End With

        buffer.Dispose()
    End Sub

    Friend Sub Packet_PetDir(ByRef data() As Byte)
        Dim i As Integer
        Dim dir As Integer
        Dim buffer As New ByteStream(data)
        i = buffer.ReadInt32
        dir = buffer.ReadInt32

        Player(i).Pet.Dir = dir

        buffer.Dispose()
    End Sub

    Friend Sub Packet_PetVital(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)
        i = buffer.ReadInt32

        If buffer.ReadInt32 = 1 Then
            Player(i).Pet.MaxHp = buffer.ReadInt32
            Player(i).Pet.Health = buffer.ReadInt32
        Else
            Player(i).Pet.MaxMp = buffer.ReadInt32
            Player(i).Pet.Mana = buffer.ReadInt32
        End If

        buffer.Dispose()

    End Sub

    Friend Sub Packet_ClearPetSkillBuffer(ByRef data() As Byte)
        PetSkillBuffer = 0
        PetSkillBufferTimer = 0
    End Sub

    Friend Sub Packet_PetAttack(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)
        i = buffer.ReadInt32

        ' Set pet to attacking
        Player(i).Pet.Attacking = 1
        Player(i).Pet.AttackTimer = GetTickCount()

        buffer.Dispose()
    End Sub

    Friend Sub Packet_PetXY(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)

        Player(i).Pet.X = buffer.ReadInt32
        Player(i).Pet.Y = buffer.ReadInt32

        buffer.Dispose()
    End Sub

    Friend Sub Packet_PetExperience(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)

        Player(MyIndex).Pet.Exp = buffer.ReadInt32
        Player(MyIndex).Pet.Tnl = buffer.ReadInt32

        buffer.Dispose()
    End Sub

#End Region

#Region "Movement"

    Sub ProcessPetMovement(index As Integer)

        ' Check if pet is walking, and if so process moving them over

        If Player(index).Pet.Moving = MovementType.Walking Then

            Select Case Player(index).Pet.Dir
                Case DirectionType.Up
                    Player(index).Pet.YOffset = Player(index).Pet.YOffset - ((ElapsedTime / 1000) * (WalkSpeed * SizeY))
                    If Player(index).Pet.YOffset < 0 Then Player(index).Pet.YOffset = 0

                Case DirectionType.Down
                    Player(index).Pet.YOffset = Player(index).Pet.YOffset + ((ElapsedTime / 1000) * (WalkSpeed * SizeY))
                    If Player(index).Pet.YOffset > 0 Then Player(index).Pet.YOffset = 0

                Case DirectionType.Left
                    Player(index).Pet.XOffset = Player(index).Pet.XOffset - ((ElapsedTime / 1000) * (WalkSpeed * SizeX))
                    If Player(index).Pet.XOffset < 0 Then Player(index).Pet.XOffset = 0

                Case DirectionType.Right
                    Player(index).Pet.XOffset = Player(index).Pet.XOffset + ((ElapsedTime / 1000) * (WalkSpeed * SizeX))
                    If Player(index).Pet.XOffset > 0 Then Player(index).Pet.XOffset = 0

            End Select

            ' Check if completed walking over to the next tile
            If Player(index).Pet.Moving > 0 Then
                If Player(index).Pet.Dir = DirectionType.Right Or Player(index).Pet.Dir = DirectionType.Down Then
                    If (Player(index).Pet.XOffset >= 0) And (Player(index).Pet.YOffset >= 0) Then
                        Player(index).Pet.Moving = 0
                        If Player(index).Pet.Steps = 1 Then
                            Player(index).Pet.Steps = 2
                        Else
                            Player(index).Pet.Steps = 1
                        End If
                    End If
                Else
                    If (Player(index).Pet.XOffset <= 0) And (Player(index).Pet.YOffset <= 0) Then
                        Player(index).Pet.Moving = 0
                        If Player(index).Pet.Steps = 1 Then
                            Player(index).Pet.Steps = 2
                        Else
                            Player(index).Pet.Steps = 1
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Friend Sub PetMove(x As Integer, y As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CPetMove)

        buffer.WriteInt32(x)
        buffer.WriteInt32(y)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

#End Region

#Region "Drawing"

    Friend Sub DrawPet(index As Integer)
        Dim anim As Byte, x As Integer, y As Integer
        Dim spriteNum As Integer, spriteleft As Integer
        Dim rect As Rectangle
        Dim attackspeed As Integer

        StreamPet(Player(index).Pet.Num)

        spriteNum = Pet(Player(index).Pet.Num).Sprite

        If spriteNum < 1 Or spriteNum > NumCharacters Then Exit Sub

        attackspeed = 1000

        ' Reset frame
        If Player(index).Pet.Steps = 3 Then
            anim = 0
        ElseIf Player(index).Pet.Steps = 1 Then
            anim = 2
        ElseIf Player(index).Pet.Steps = 2 Then
            anim = 3
        End If

        ' Check for attacking animation
        If Player(index).Pet.AttackTimer + (attackspeed / 2) > GetTickCount() Then
            If Player(index).Pet.Attacking = 1 Then
                anim = 3
            End If
        Else
            ' If not attacking, walk normally
            Select Case Player(index).Pet.Dir
                Case DirectionType.Up
                    If (Player(index).Pet.YOffset > 8) Then anim = Player(index).Pet.Steps
                Case DirectionType.Down
                    If (Player(index).Pet.YOffset < -8) Then anim = Player(index).Pet.Steps
                Case DirectionType.Left
                    If (Player(index).Pet.XOffset > 8) Then anim = Player(index).Pet.Steps
                Case DirectionType.Right
                    If (Player(index).Pet.XOffset < -8) Then anim = Player(index).Pet.Steps
            End Select
        End If

        ' Check to see if we want to stop making him attack
        With Player(index).Pet
            If .AttackTimer + attackspeed < GetTickCount() Then
                .Attacking = 0
                .AttackTimer = 0
            End If
        End With

        ' Set the left
        Select Case Player(index).Pet.Dir
            Case DirectionType.Up
                spriteleft = 3
            Case DirectionType.Right
                spriteleft = 2
            Case DirectionType.Down
                spriteleft = 0
            Case DirectionType.Left
                spriteleft = 1
        End Select

        rect = New Rectangle((anim) * (CharacterGfxInfo(spriteNum).Width / 4), spriteleft * (CharacterGfxInfo(spriteNum).Height / 4), (CharacterGfxInfo(spriteNum).Width / 4), (CharacterGfxInfo(spriteNum).Height / 4))

        ' Calculate the X
        x = Player(index).Pet.X * PicX + Player(index).Pet.XOffset - ((CharacterGfxInfo(spriteNum).Width / 4 - 32) / 2)

        ' Is the player's height more than 32..?
        If (CharacterGfxInfo(spriteNum).Height / 4) > 32 Then
            ' Create a 32 pixel offset for larger sprites
            y = Player(index).Pet.Y * PicY + Player(index).Pet.YOffset - ((CharacterGfxInfo(spriteNum).Width / 4) - 32)
        Else
            ' Proceed as normal
            y = Player(index).Pet.Y * PicY + Player(index).Pet.YOffset
        End If

        ' render the actual sprite
        DrawCharacterSprite(spriteNum, x, y, rect)

    End Sub

    Friend Sub DrawPlayerPetName(index As Integer)
        Dim textX As Integer
        Dim textY As Integer
        Dim color As SFML.Graphics.Color, backcolor As SFML.Graphics.Color
        Dim name As String

        ' Check access level
        If GetPlayerPK(index) = False Then

            Select Case GetPlayerAccess(index)
                Case 0
                    color = SFML.Graphics.Color.Red
                    backcolor = SFML.Graphics.Color.Black
                Case 1
                    color = SFML.Graphics.Color.Black
                    backcolor = SFML.Graphics.Color.White
                Case 2
                    color = SFML.Graphics.Color.Cyan
                    backcolor = SFML.Graphics.Color.Black
                Case 3
                    color = SFML.Graphics.Color.Green
                    backcolor = SFML.Graphics.Color.Black
                Case 4
                    color = SFML.Graphics.Color.Yellow
                    backcolor = SFML.Graphics.Color.Black
            End Select
        Else
            color = SFML.Graphics.Color.Red
        End If

        name = Trim$(GetPlayerName(index)) & "'s " & Trim$(Pet(Player(index).Pet.Num).Name)

        ' calc pos
        textX = ConvertMapX(Player(index).Pet.X * PicX) + Player(index).Pet.XOffset + (PicX \ 2) - TextWidth(name) / 2
        If Pet(Player(index).Pet.Num).Sprite < 1 Or Pet(Player(index).Pet.Num).Sprite > NumCharacters Then
            textY = ConvertMapY(Player(index).Pet.Y * PicY) + Player(index).Pet.YOffset - 16
        Else
            ' Determine location for text
            textY = ConvertMapY(Player(index).Pet.Y * PicY) + Player(index).Pet.YOffset - (CharacterGfxInfo(Pet(Player(index).Pet.Num).Sprite).Height / 4) + 16
        End If

        ' Draw name
        RenderText(name, Window, textX, textY, color, backcolor)
    End Sub

#End Region

#Region "Misc"

    Friend Function PetAlive(index As Integer) As Boolean
        PetAlive = False

        If Player(index).Pet.Alive = 1 Then
            PetAlive = True
        End If

    End Function

#End Region

#Region "Editor"

    Friend Sub PetEditorInit()
        Dim i As Integer

        EditorIndex = frmEditor_Pet.lstIndex.SelectedIndex + 1

        With frmEditor_Pet
            'populate skill combo's
            .cmbSkill1.Items.Clear()
            .cmbSkill2.Items.Clear()
            .cmbSkill3.Items.Clear()
            .cmbSkill4.Items.Clear()

           For i = 1 To MAX_SKILLS
                .cmbSkill1.Items.Add(i & ": " & Skill(i).Name)
                .cmbSkill2.Items.Add(i & ": " & Skill(i).Name)
                .cmbSkill3.Items.Add(i & ": " & Skill(i).Name)
                .cmbSkill4.Items.Add(i & ": " & Skill(i).Name)
            Next
            .txtName.Text = Trim$(Pet(EditorIndex).Name)
            If Pet(EditorIndex).Sprite < 0 Or Pet(EditorIndex).Sprite > .nudSprite.Maximum Then Pet(EditorIndex).Sprite = 0

            .nudSprite.Value = Pet(EditorIndex).Sprite
            .EditorPet_DrawPet()

            .nudRange.Value = Pet(EditorIndex).Range

            .nudStrength.Value = Pet(EditorIndex).Stat(StatType.Strength)
            .nudVitality.Value = Pet(EditorIndex).Stat(StatType.Vitality)
            .nudLuck.Value = Pet(EditorIndex).Stat(StatType.Luck)
            .nudIntelligence.Value = Pet(EditorIndex).Stat(StatType.Intelligence)
            .nudSpirit.Value = Pet(EditorIndex).Stat(StatType.Spirit)
            .nudLevel.Value = Pet(EditorIndex).Level

            If Pet(EditorIndex).StatType = 1 Then
                .optCustomStats.Checked = True
                .pnlCustomStats.Visible = True
            Else
                .optAdoptStats.Checked = True
                .pnlCustomStats.Visible = False
            End If

            .nudPetExp.Value = Pet(EditorIndex).ExpGain

            .nudPetPnts.Value = Pet(EditorIndex).LevelPnts

            .nudMaxLevel.Value = Pet(EditorIndex).MaxLevel

            'Set skills
            .cmbSkill1.SelectedIndex = Pet(EditorIndex).Skill(1)

            .cmbSkill2.SelectedIndex = Pet(EditorIndex).Skill(2)

            .cmbSkill3.SelectedIndex = Pet(EditorIndex).Skill(3)

            .cmbSkill4.SelectedIndex = Pet(EditorIndex).Skill(4)

            If Pet(EditorIndex).LevelingType = 1 Then
                .optLevel.Checked = True

                .pnlPetlevel.Visible = True
                .pnlPetlevel.BringToFront()
                .nudPetExp.Value = Pet(EditorIndex).ExpGain
                If Pet(EditorIndex).MaxLevel > 0 Then .nudMaxLevel.Value = Pet(EditorIndex).MaxLevel
                .nudPetPnts.Value = Pet(EditorIndex).LevelPnts
            Else
                .optDoNotLevel.Checked = True

                .pnlPetlevel.Visible = False
                .nudPetExp.Value = Pet(EditorIndex).ExpGain
                .nudMaxLevel.Value = Pet(EditorIndex).MaxLevel
                .nudPetPnts.Value = Pet(EditorIndex).LevelPnts
            End If

            If Pet(EditorIndex).Evolvable = 1 Then
                .chkEvolve.Checked = True
            Else
                .chkEvolve.Checked = False
            End If

            .nudEvolveLvl.Value = Pet(EditorIndex).EvolveLevel
            .cmbEvolve.SelectedIndex = Pet(EditorIndex).EvolveNum

            .EditorPet_DrawPet()
        End With

        ClearChanged_Pet()
        Pet_Changed(EditorIndex) = True
    End Sub

    Friend Sub PetEditorOk()
        Dim i As Integer

       For i = 1 To MAX_PETS
            If Pet_Changed(i) Then
                SendSavePet(i)
            End If
        Next

        Editor = -1
        ClearChanged_Pet()
        SendCloseEditor()
    End Sub

    Friend Sub PetEditorCancel()
        Editor = -1
        ClearChanged_Pet()
        ClearPets()
        SendCloseEditor()
    End Sub

    Friend Sub ClearChanged_Pet()
        ReDim Pet_Changed(MAX_PETS)
    End Sub

#End Region

End Module