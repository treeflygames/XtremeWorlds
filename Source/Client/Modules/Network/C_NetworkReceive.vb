Imports System.Threading.Channels
Imports Core
Imports Mirage.Sharp.Asfw
Imports Mirage.Sharp.Asfw.IO

Module C_NetworkReceive

    Sub PacketRouter()
        Socket.PacketId(ServerPackets.SAlertMsg) = AddressOf Packet_AlertMsg
        Socket.PacketId(ServerPackets.SKeyPair) = AddressOf Packet_KeyPair
        Socket.PacketId(ServerPackets.SLoginOK) = AddressOf HandleLoginOk
        Socket.PacketId(ServerPackets.SPlayerChars) = AddressOf Packet_PlayerChars
        Socket.PacketId(ServerPackets.SUpdateJob) = AddressOf Packet_UpdateJob
        Socket.PacketId(ServerPackets.SJobData) = AddressOf Packet_JobData
        Socket.PacketId(ServerPackets.SInGame) = AddressOf Packet_InGame
        Socket.PacketId(ServerPackets.SPlayerInv) = AddressOf Packet_PlayerInv
        Socket.PacketId(ServerPackets.SPlayerInvUpdate) = AddressOf Packet_PlayerInvUpdate
        Socket.PacketId(ServerPackets.SPlayerWornEq) = AddressOf Packet_PlayerWornEquipment
        Socket.PacketId(ServerPackets.SPlayerHP) = AddressOf Packet_PlayerHP
        Socket.PacketId(ServerPackets.SPlayerMP) = AddressOf Packet_PlayerMP
        Socket.PacketId(ServerPackets.SPlayerSP) = AddressOf Packet_PlayerSP
        Socket.PacketId(ServerPackets.SPlayerStats) = AddressOf Packet_PlayerStats
        Socket.PacketId(ServerPackets.SPlayerData) = AddressOf Packet_PlayerData
        Socket.PacketId(ServerPackets.SPlayerMove) = AddressOf Packet_PlayerMove
        Socket.PacketId(ServerPackets.SNpcMove) = AddressOf Packet_NpcMove
        Socket.PacketId(ServerPackets.SPlayerDir) = AddressOf Packet_PlayerDir
        Socket.PacketId(ServerPackets.SNpcDir) = AddressOf Packet_NpcDir
        Socket.PacketId(ServerPackets.SPlayerXY) = AddressOf Packet_PlayerXY
        Socket.PacketId(ServerPackets.SAttack) = AddressOf Packet_Attack
        Socket.PacketId(ServerPackets.SNpcAttack) = AddressOf Packet_NpcAttack
        Socket.PacketId(ServerPackets.SCheckForMap) = AddressOf Packet_CheckMap
        Socket.PacketId(ServerPackets.SMapData) = AddressOf Packet_MapData
        Socket.PacketId(ServerPackets.SMapNpcData) = AddressOf Packet_MapNPCData
        Socket.PacketId(ServerPackets.SMapNpcUpdate) = AddressOf Packet_MapNPCUpdate
        Socket.PacketId(ServerPackets.SMapDone) = AddressOf Packet_MapDone
        Socket.PacketId(ServerPackets.SGlobalMsg) = AddressOf Packet_GlobalMessage
        Socket.PacketId(ServerPackets.SAdminMsg) = AddressOf Packet_AdminMsg
        Socket.PacketId(ServerPackets.SPlayerMsg) = AddressOf Packet_PlayerMsg
        Socket.PacketId(ServerPackets.SMapMsg) = AddressOf Packet_MapMessage
        Socket.PacketId(ServerPackets.SSpawnItem) = AddressOf Packet_SpawnItem
        Socket.PacketId(ServerPackets.SUpdateItem) = AddressOf Packet_UpdateItem
        Socket.PacketId(ServerPackets.SSpawnNpc) = AddressOf Packet_SpawnNPC
        Socket.PacketId(ServerPackets.SNpcDead) = AddressOf Packet_NpcDead
        Socket.PacketId(ServerPackets.SUpdateNpc) = AddressOf Packet_UpdateNPC
        Socket.PacketId(ServerPackets.SEditMap) = AddressOf Packet_EditMap
        Socket.PacketId(ServerPackets.SUpdateShop) = AddressOf Packet_UpdateShop
        Socket.PacketId(ServerPackets.SUpdateSkill) = AddressOf Packet_UpdateSkill
        Socket.PacketId(ServerPackets.SSkills) = AddressOf Packet_Skills
        Socket.PacketId(ServerPackets.SLeftMap) = AddressOf Packet_LeftMap
        Socket.PacketId(ServerPackets.SMapResource) = AddressOf Packet_MapResource
        Socket.PacketId(ServerPackets.SUpdateResource) = AddressOf Packet_UpdateResource
        Socket.PacketId(ServerPackets.SSendPing) = AddressOf Packet_Ping
        Socket.PacketId(ServerPackets.SActionMsg) = AddressOf Packet_ActionMessage
        Socket.PacketId(ServerPackets.SPlayerEXP) = AddressOf Packet_PlayerExp
        Socket.PacketId(ServerPackets.SBlood) = AddressOf Packet_Blood
        Socket.PacketId(ServerPackets.SUpdateAnimation) = AddressOf Packet_UpdateAnimation
        Socket.PacketId(ServerPackets.SAnimation) = AddressOf Packet_Animation
        Socket.PacketId(ServerPackets.SMapNpcVitals) = AddressOf Packet_NPCVitals
        Socket.PacketId(ServerPackets.SCooldown) = AddressOf Packet_Cooldown
        Socket.PacketId(ServerPackets.SClearSkillBuffer) = AddressOf Packet_ClearSkillBuffer
        Socket.PacketId(ServerPackets.SSayMsg) = AddressOf Packet_SayMessage
        Socket.PacketId(ServerPackets.SOpenShop) = AddressOf Packet_OpenShop
        Socket.PacketId(ServerPackets.SResetShopAction) = AddressOf Packet_ResetShopAction
        Socket.PacketId(ServerPackets.SStunned) = AddressOf Packet_Stunned
        Socket.PacketId(ServerPackets.SMapWornEq) = AddressOf Packet_MapWornEquipment
        Socket.PacketId(ServerPackets.SBank) = AddressOf Packet_OpenBank
        Socket.PacketId(ServerPackets.SLeftGame) = AddressOf Packet_LeftGame

        Socket.PacketId(ServerPackets.SClearTradeTimer) = AddressOf Packet_ClearTradeTimer
        Socket.PacketId(ServerPackets.STradeInvite) = AddressOf Packet_TradeInvite
        Socket.PacketId(ServerPackets.STrade) = AddressOf Packet_Trade
        Socket.PacketId(ServerPackets.SCloseTrade) = AddressOf Packet_CloseTrade
        Socket.PacketId(ServerPackets.STradeUpdate) = AddressOf Packet_TradeUpdate
        Socket.PacketId(ServerPackets.STradeStatus) = AddressOf Packet_TradeStatus

        Socket.PacketId(ServerPackets.SGameData) = AddressOf Packet_GameData
        Socket.PacketId(ServerPackets.SMapReport) = AddressOf Packet_MapReport
        Socket.PacketId(ServerPackets.STarget) = AddressOf Packet_Target

        Socket.PacketId(ServerPackets.SAdmin) = AddressOf Packet_Admin
        Socket.PacketId(ServerPackets.SMapNames) = AddressOf Packet_MapNames

        Socket.PacketId(ServerPackets.SCritical) = AddressOf Packet_Critical
        Socket.PacketId(ServerPackets.SrClick) = AddressOf Packet_RClick

        Socket.PacketId(ServerPackets.SHotbar) = AddressOf Packet_Hotbar

        Socket.PacketId(ServerPackets.SSpawnEvent) = AddressOf Packet_SpawnEvent
        Socket.PacketId(ServerPackets.SEventMove) = AddressOf Packet_EventMove
        Socket.PacketId(ServerPackets.SEventDir) = AddressOf Packet_EventDir
        Socket.PacketId(ServerPackets.SEventChat) = AddressOf Packet_EventChat
        Socket.PacketId(ServerPackets.SEventStart) = AddressOf Packet_EventStart
        Socket.PacketId(ServerPackets.SEventEnd) = AddressOf Packet_EventEnd
        Socket.PacketId(ServerPackets.SPlayBGM) = AddressOf Packet_PlayBGM
        Socket.PacketId(ServerPackets.SPlaySound) = AddressOf Packet_PlaySound
        Socket.PacketId(ServerPackets.SFadeoutBGM) = AddressOf Packet_FadeOutBGM
        Socket.PacketId(ServerPackets.SStopSound) = AddressOf Packet_StopSound
        Socket.PacketId(ServerPackets.SSwitchesAndVariables) = AddressOf Packet_SwitchesAndVariables
        Socket.PacketId(ServerPackets.SMapEventData) = AddressOf Packet_MapEventData
        Socket.PacketId(ServerPackets.SChatBubble) = AddressOf Packet_ChatBubble
        Socket.PacketId(ServerPackets.SSpecialEffect) = AddressOf Packet_SpecialEffect

        Socket.PacketId(ServerPackets.SPic) = AddressOf Packet_Picture
        Socket.PacketId(ServerPackets.SHoldPlayer) = AddressOf Packet_HoldPlayer

        Socket.PacketId(ServerPackets.SUpdateProjectile) = AddressOf HandleUpdateProjectile
        Socket.PacketId(ServerPackets.SMapProjectile) = AddressOf HandleMapProjectile

        Socket.PacketId(ServerPackets.SEmote) = AddressOf Packet_Emote

        Socket.PacketId(ServerPackets.SPartyInvite) = AddressOf Packet_PartyInvite
        Socket.PacketId(ServerPackets.SPartyUpdate) = AddressOf Packet_PartyUpdate
        Socket.PacketId(ServerPackets.SPartyVitals) = AddressOf Packet_PartyVitals

        Socket.PacketId(ServerPackets.SUpdatePet) = AddressOf Packet_UpdatePet
        Socket.PacketId(ServerPackets.SUpdatePlayerPet) = AddressOf Packet_UpdatePlayerPet
        Socket.PacketId(ServerPackets.SPetMove) = AddressOf Packet_PetMove
        Socket.PacketId(ServerPackets.SPetDir) = AddressOf Packet_PetDir
        Socket.PacketId(ServerPackets.SPetVital) = AddressOf Packet_PetVital
        Socket.PacketId(ServerPackets.SClearPetSkillBuffer) = AddressOf Packet_ClearPetSkillBuffer
        Socket.PacketId(ServerPackets.SPetAttack) = AddressOf Packet_PetAttack
        Socket.PacketId(ServerPackets.SPetXY) = AddressOf Packet_PetXY
        Socket.PacketId(ServerPackets.SPetExp) = AddressOf Packet_PetExperience

        Socket.PacketId(ServerPackets.SClock) = AddressOf Packet_Clock
        Socket.PacketId(ServerPackets.STime) = AddressOf Packet_Time

        Socket.PacketId(ServerPackets.SItemEditor) = AddressOf Packet_EditItem
        Socket.PacketId(ServerPackets.SNpcEditor) = AddressOf Packet_NPCEditor
        Socket.PacketId(ServerPackets.SShopEditor) = AddressOf Packet_EditShop
        Socket.PacketId(ServerPackets.SSkillEditor) = AddressOf Packet_EditSkill
        Socket.PacketId(ServerPackets.SResourceEditor) = AddressOf Packet_ResourceEditor
        Socket.PacketId(ServerPackets.SAnimationEditor) = AddressOf Packet_EditAnimation
        Socket.PacketId(ServerPackets.SProjectileEditor) = AddressOf HandleProjectileEditor
        Socket.PacketId(ServerPackets.SJobEditor) = AddressOf Packet_ClassEditor
        Socket.PacketId(ServerPackets.SPetEditor) = AddressOf Packet_PetEditor
        Socket.PacketId(ServerPackets.SUpdateMoral) = AddressOf Packet_UpdateMoral
        Socket.PacketId(ServerPackets.SMoralEditor) = AddressOf Packet_EditMoral

    End Sub

    Private Sub Packet_AlertMsg(ByRef data() As Byte)
        Dim dialogueIndex As Integer, menuReset As Integer, kick As Integer
        Dim buffer As New ByteStream(data)

        dialogueIndex = buffer.ReadInt32
        menuReset = buffer.ReadInt32()
        kick = buffer.ReadInt32()

        If menuReset > 0 Then
            HideWindows()

            Select Case menuReset
                Case MenuType.Login
                    ShowWindow(GetWindowIndex("winLogin"))
                Case MenuType.Chars
                    ShowWindow(GetWindowIndex("winChars"))
                Case MenuType.Job
                    ShowWindow(GetWindowIndex("winJob"))
                Case MenuType.NewChar
                    ShowWindow(GetWindowIndex("winNewChar"))
                Case MenuType.Main
                    ShowWindow(GetWindowIndex("winLogin"))
                Case MenuType.Register
                    ShowWindow(GetWindowIndex("winRegister"))
            End Select
        Else
            If kick > 0 Or InGame = False Then
                ShowWindow(GetWindowIndex("winLogin"))
                InitNetwork()
                DialogueAlert(dialogueIndex)
                Exit Sub
            End If
        End If

        DialogueAlert(dialogueIndex)
        buffer.Dispose()
    End Sub

    Private Sub Packet_KeyPair(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)

        EKeyPair.ImportKeyString(buffer.ReadString())
        buffer.Dispose()
    End Sub

    Private Sub HandleLoginOk(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)

        ' Now we can receive game data
        MyIndex = buffer.ReadInt32

        buffer.Dispose()
    End Sub

    Sub Packet_PlayerChars(ByRef data() As Byte)
        Dim buffer As New ByteStream(data), I As Long, winNum As Long, conNum As Long, isSlotEmpty(MAX_CHARS) As Boolean, x As Long

        Types.Settings.Username = Windows(GetWindowIndex("winLogin")).Controls(GetControlIndex("winLogin", "txtUsername")).Text
        Settings.Save()

        For I = 1 To MAX_CHARS
            CharName(I) = Trim$(buffer.ReadString)
            CharSprite(I) = buffer.ReadInt32
            CharAccess(I) = buffer.ReadInt32
            CharJob(I) = buffer.ReadInt32

            ' set as empty or not
            If Not Len(Trim$(CharName(I))) > 0 Then isSlotEmpty(I) = True
        Next

        buffer.Dispose()

        HideWindows()
        ShowWindow(GetWindowIndex("winChars"))

        ' set GUI window up
        winNum = GetWindowIndex("winChars")
        For I = 1 To MAX_CHARS
            conNum = GetControlIndex("winChars", "lblCharName_" & I)
            With Windows(winNum).Controls(conNum)
                If Not isSlotEmpty(I) Then
                    .Text = CharName(I)
                Else
                    .Text = "Blank Slot"
                End If
            End With

            ' hide/show buttons
            If isSlotEmpty(I) Then
                ' create button
                conNum = GetControlIndex("winChars", "btnCreateChar_" & I)
                Windows(winNum).Controls(conNum).Visible = True
                ' select button
                conNum = GetControlIndex("winChars", "btnSelectChar_" & I)
                Windows(winNum).Controls(conNum).Visible = False
                ' delete button
                conNum = GetControlIndex("winChars", "btnDelChar_" & I)
                Windows(winNum).Controls(conNum).Visible = False
            Else
                ' create button
                conNum = GetControlIndex("winChars", "btnCreateChar_" & I)
                Windows(winNum).Controls(conNum).Visible = False
                ' select button
                conNum = GetControlIndex("winChars", "btnSelectChar_" & I)
                Windows(winNum).Controls(conNum).Visible = True
                ' delete button
                conNum = GetControlIndex("winChars", "btnDelChar_" & I)
                Windows(winNum).Controls(conNum).Visible = True
            End If
        Next
    End Sub

    Sub Packet_UpdateJob(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)

        i = buffer.ReadInt32()
        buffer.WriteInt32(i)

        With Job(i)
            .Name = buffer.ReadString
            .Desc = buffer.ReadString

            .MaleSprite = buffer.ReadInt32
            .FemaleSprite = buffer.ReadInt32

            For q = 1 To StatType.Count - 1
                .Stat(q) = buffer.ReadInt32
            Next

            For q = 1 To 5
                .StartItem(q) = buffer.ReadInt32
                .StartValue(q) = buffer.ReadInt32
            Next

            .StartMap = buffer.ReadInt32
            .StartX = buffer.ReadByte
            .StartY = buffer.ReadByte
            .BaseExp = buffer.ReadInt32
        End With

        buffer.Dispose()
    End Sub

    Sub Packet_JobData(ByRef data() As Byte)
        Dim i As Integer, x As Integer
        Dim buffer As New ByteStream(data)

        For i = 1 To MAX_JOBS
            With Job(i)
                .Name = buffer.ReadString
                .Desc = buffer.ReadString

                .MaleSprite = buffer.ReadInt32
                .FemaleSprite = buffer.ReadInt32

                For x = 1 To StatType.Count - 1
                    .Stat(x) = buffer.ReadInt32()
                Next

                For q = 1 To 5
                    .StartItem(q) = buffer.ReadInt32
                    .StartValue(q) = buffer.ReadInt32
                Next

                .StartMap = buffer.ReadInt32
                .StartX = buffer.ReadByte
                .StartY = buffer.ReadByte
                .BaseExp = buffer.ReadInt32
            End With

        Next

        buffer.Dispose()
    End Sub

    Private Sub Packet_InGame(ByRef data() As Byte)
        InGame = True
        InMenu = False
        HideWindows()
        CanMoveNow = True
        Editor = -1

        ' show gui
        ShowWindow(GetWindowIndex("winHotbar"), , False)
        ShowWindow(GetWindowIndex("winMenu"), , False)
        ShowWindow(GetWindowIndex("winBars"), , False)
        HideChat()

        GameInit()
    End Sub

    Private Sub Packet_PlayerInv(ByRef data() As Byte)
        Dim i As Integer, invNum As Integer, amount As Integer
        Dim buffer As New ByteStream(data)

        For i = 1 To MAX_INV
            invNum = buffer.ReadInt32
            amount = buffer.ReadInt32
            SetPlayerInvItemNum(MyIndex, i, invNum)
            SetPlayerInvItemValue(MyIndex, i, amount)
        Next

        ' changes to inventory, need to clear any drop menu
        TmpCurrencyItem = 0
        CurrencyMenu = 0 ' clear

        buffer.Dispose()
    End Sub

    Private Sub Packet_PlayerInvUpdate(ByRef data() As Byte)
        Dim n As Integer, i As Integer
        Dim buffer As New ByteStream(data)

        n = buffer.ReadInt32()

        SetPlayerInvItemNum(MyIndex, n, buffer.ReadInt32)
        SetPlayerInvItemValue(MyIndex, n, buffer.ReadInt32)

        ' changes, clear drop menu
        TmpCurrencyItem = 0
        CurrencyMenu = 0 ' clear

        buffer.Dispose()
    End Sub

    Private Sub Packet_PlayerWornEquipment(ByRef data() As Byte)
        Dim i As Integer, n As Integer
        Dim buffer As New ByteStream(data)

        For i = 1 To EquipmentType.Count - 1
            SetPlayerEquipment(MyIndex, buffer.ReadInt32, i)
        Next

        ' changes to inventory, need to clear any drop menu
        TmpCurrencyItem = 0
        CurrencyMenu = 0 ' clear

        buffer.Dispose()
    End Sub

    Private Sub Packet_NpcMove(ByRef data() As Byte)
        Dim mapNpcNum As Integer, movement As Integer
        Dim x As Integer, y As Integer, dir As Integer
        Dim buffer As New ByteStream(data)

        mapNpcNum = buffer.ReadInt32
        x = buffer.ReadInt32
        y = buffer.ReadInt32
        dir = buffer.ReadInt32
        movement = buffer.ReadInt32

        With MapNpc(mapNpcNum)
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

    Private Sub Packet_NpcDir(ByRef data() As Byte)
        Dim dir As Integer, i As Integer
        Dim buffer As New ByteStream(data)

        i = buffer.ReadInt32
        dir = buffer.ReadInt32

        With MapNpc(i)
            .Dir = dir
            .XOffset = 0
            .YOffset = 0
            .Moving = 0
        End With

        buffer.Dispose()
    End Sub

    Private Sub Packet_Attack(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)

        i = buffer.ReadInt32

        ' Set player to attacking
        Player(i).Attacking = 1
        Player(i).AttackTimer = GetTickCount()

        buffer.Dispose()
    End Sub

    Private Sub Packet_NpcAttack(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)

        i = buffer.ReadInt32

        ' Set npc to attacking
        MapNpc(i).Attacking = 1
        MapNpc(i).AttackTimer = GetTickCount()

        buffer.Dispose()
    End Sub

    Private Sub Packet_GlobalMessage(ByRef data() As Byte)
        Dim msg As String
        Dim buffer As New ByteStream(data)

        msg = Trim(buffer.ReadString)

        buffer.Dispose()

        AddText(msg, ColorType.Yellow, , ChatChannel.Broadcast)
    End Sub

    Private Sub Packet_MapMessage(ByRef data() As Byte)
        Dim msg As String
        Dim buffer As New ByteStream(data)

        msg = Trim(buffer.ReadString)

        buffer.Dispose()

        AddText(msg, ColorType.White, , ChatChannel.Map)

    End Sub

    Private Sub Packet_AdminMsg(ByRef data() As Byte)
        Dim msg As String
        Dim buffer As New ByteStream(data)

        msg = Trim(buffer.ReadString)

        buffer.Dispose()

        AddText(msg, ColorType.BrightCyan, , ChatChannel.Broadcast)
    End Sub

    Private Sub Packet_PlayerMsg(ByRef data() As Byte)
        Dim msg As String
        Dim buffer As New ByteStream(data)

        msg = Trim(buffer.ReadString)

        buffer.Dispose()

        AddText(msg, ColorType.Pink, , ChatChannel.Player)
    End Sub

    Private Sub Packet_SpawnItem(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)

        i = buffer.ReadInt32

        With MapItem(i)
            .Num = buffer.ReadInt32
            .Value = buffer.ReadInt32
            .X = buffer.ReadInt32
            .Y = buffer.ReadInt32
        End With

        buffer.Dispose()
    End Sub

    Private Sub Packet_SpawnNPC(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)

        i = buffer.ReadInt32

        With MapNpc(i)
            .Num = buffer.ReadInt32
            .X = buffer.ReadInt32
            .Y = buffer.ReadInt32
            .Dir = buffer.ReadInt32

            For i = 1 To VitalType.Count - 1
                .Vital(i) = buffer.ReadInt32
            Next
            ' Client use only
            .XOffset = 0
            .YOffset = 0
            .Moving = 0
        End With

        buffer.Dispose()
    End Sub

    Private Sub Packet_NpcDead(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)

        i = buffer.ReadInt32
        ClearMapNpc(i)

        buffer.Dispose()
    End Sub

    Private Sub Packet_UpdateNPC(ByRef data() As Byte)
        Dim i As Integer, x As Integer
        Dim buffer As New ByteStream(data)

        i = buffer.ReadInt32

        ' Update the Npc
        NPC(i).Animation = buffer.ReadInt32()
        NPC(i).AttackSay = buffer.ReadString()
        NPC(i).Behaviour = buffer.ReadByte()

        For x = 1 To MAX_DROP_ITEMS
            NPC(i).DropChance(x) = buffer.ReadInt32()
            NPC(i).DropItem(x) = buffer.ReadInt32()
            NPC(i).DropItemValue(x) = buffer.ReadInt32()
        Next

        NPC(i).Exp = buffer.ReadInt32()
        NPC(i).Faction = buffer.ReadByte()
        NPC(i).HP = buffer.ReadInt32()
        NPC(i).Name = buffer.ReadString()
        NPC(i).Range = buffer.ReadByte()
        NPC(i).SpawnTime = buffer.ReadByte()
        NPC(i).SpawnSecs = buffer.ReadInt32()
        NPC(i).Sprite = buffer.ReadInt32()

        For x = 1 To StatType.Count - 1
            NPC(i).Stat(x) = buffer.ReadByte()
        Next

        For x = 1 To MAX_NPC_SKILLS
            NPC(i).Skill(x) = buffer.ReadByte()
        Next

        NPC(i).Level = buffer.ReadInt32()
        NPC(i).Damage = buffer.ReadInt32()

        buffer.Dispose()
    End Sub

    Private Sub Packet_UpdateSkill(ByRef data() As Byte)
        Dim skillnum As Integer
        Dim buffer As New ByteStream(data)
        skillnum = buffer.ReadInt32

        Skill(skillnum).AccessReq = buffer.ReadInt32()
        Skill(skillnum).AoE = buffer.ReadInt32()
        Skill(skillnum).CastAnim = buffer.ReadInt32()
        Skill(skillnum).CastTime = buffer.ReadInt32()
        Skill(skillnum).CdTime = buffer.ReadInt32()
        Skill(skillnum).JobReq = buffer.ReadInt32()
        Skill(skillnum).Dir = buffer.ReadInt32()
        Skill(skillnum).Duration = buffer.ReadInt32()
        Skill(skillnum).Icon = buffer.ReadInt32()
        Skill(skillnum).Interval = buffer.ReadInt32()
        Skill(skillnum).IsAoE = buffer.ReadInt32()
        Skill(skillnum).LevelReq = buffer.ReadInt32()
        Skill(skillnum).Map = buffer.ReadInt32()
        Skill(skillnum).MpCost = buffer.ReadInt32()
        Skill(skillnum).Name = Trim(buffer.ReadString())
        Skill(skillnum).Range = buffer.ReadInt32()
        Skill(skillnum).SkillAnim = buffer.ReadInt32()
        Skill(skillnum).StunDuration = buffer.ReadInt32()
        Skill(skillnum).Type = buffer.ReadInt32()
        Skill(skillnum).Vital = buffer.ReadInt32()
        Skill(skillnum).X = buffer.ReadInt32()
        Skill(skillnum).Y = buffer.ReadInt32()

        Skill(skillnum).IsProjectile = buffer.ReadInt32()
        Skill(skillnum).Projectile = buffer.ReadInt32()

        Skill(skillnum).KnockBack = buffer.ReadInt32()
        Skill(skillnum).KnockBackTiles = buffer.ReadInt32()

        buffer.Dispose()

    End Sub

    Private Sub Packet_Skills(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)

        For i = 1 To MAX_PLAYER_SKILLS
            Player(MyIndex).Skill(i).Num = buffer.ReadInt32
        Next

        buffer.Dispose()
    End Sub

    Private Sub Packet_LeftMap(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)

        ClearPlayer(buffer.ReadInt32)

        buffer.Dispose()
    End Sub

    Private Sub Packet_Ping(ByRef data() As Byte)
        PingEnd = GetTickCount()
        Ping = PingEnd - PingStart
    End Sub

    Private Sub Packet_ActionMessage(ByRef data() As Byte)
        Dim x As Integer, y As Integer, message As String, color As Integer, tmpType As Integer
        Dim buffer As New ByteStream(data)

        message = Trim(buffer.ReadString)
        color = buffer.ReadInt32
        tmpType = buffer.ReadInt32
        x = buffer.ReadInt32
        y = buffer.ReadInt32

        buffer.Dispose()

        CreateActionMsg(message, color, tmpType, x, y)
    End Sub

    Private Sub Packet_Blood(ByRef data() As Byte)
        Dim x As Integer, y As Integer, sprite As Integer
        Dim buffer As New ByteStream(data)

        x = buffer.ReadInt32
        y = buffer.ReadInt32

        ' randomise sprite
        sprite = Rand(1, 3)

        BloodIndex = BloodIndex + 1
        If BloodIndex >= Byte.MaxValue Then BloodIndex = 1

        With Blood(BloodIndex)
            .X = x
            .Y = y
            .Sprite = sprite
            .Timer = GetTickCount()
        End With

        buffer.Dispose()
    End Sub
    Private Sub Packet_NPCVitals(ByRef data() As Byte)
        Dim mapNpcNum As Integer
        Dim buffer As New ByteStream(data)

        mapNpcNum = buffer.ReadInt32
        For i = 1 To VitalType.Count - 1
            MapNpc(mapNpcNum).Vital(i) = buffer.ReadInt32
        Next

        buffer.Dispose()
    End Sub

    Private Sub Packet_Cooldown(ByRef data() As Byte)
        Dim slot As Integer
        Dim buffer As New ByteStream(data)

        slot = buffer.ReadInt32
        Player(MyIndex).Skill(slot).CD = GetTickCount()

        buffer.Dispose()
    End Sub

    Private Sub Packet_ClearSkillBuffer(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)

        SkillBuffer = 0
        SkillBufferTimer = 0

        buffer.Dispose()
    End Sub

    Private Sub Packet_SayMessage(ByRef data() As Byte)
        Dim access As Integer, name As String, message As String
        Dim header As String, pk As Integer, channelType As Byte, colorNum As Byte
        Dim buffer As New ByteStream(data)

        name = buffer.ReadString
        access = buffer.ReadInt32
        pk = buffer.ReadInt32
        message = buffer.ReadString
        header = buffer.ReadString

        ' Check access level
        colorNum = ColorType.White

        If access > 0 Then colorNum = ColorType.Pink
        If pk > 0 Then colorNum = ColorType.BrightRed

        ' find channel
        channelType = 0
        Select Case header
            Case "[Map]"
                channelType = ChatChannel.Map
            Case "[Global]"
                channelType = ChatChannel.Broadcast
        End Select

        ' add to the chat box
        AddText(header & name & ": " & message, colorNum, , channelType)

        buffer.Dispose()
    End Sub

    Private Sub Packet_Stunned(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)

        StunDuration = buffer.ReadInt32

        buffer.Dispose()
    End Sub

    Private Sub Packet_MapWornEquipment(ByRef data() As Byte)
        Dim playernum As Integer
        Dim buffer As New ByteStream(data)

        playernum = buffer.ReadInt32
        SetPlayerEquipment(playernum, buffer.ReadInt32, EquipmentType.Armor)
        SetPlayerEquipment(playernum, buffer.ReadInt32, EquipmentType.Weapon)
        SetPlayerEquipment(playernum, buffer.ReadInt32, EquipmentType.Helmet)
        SetPlayerEquipment(playernum, buffer.ReadInt32, EquipmentType.Shield)
        SetPlayerEquipment(playernum, buffer.ReadInt32, EquipmentType.Shoes)
        SetPlayerEquipment(playernum, buffer.ReadInt32, EquipmentType.Gloves)

        buffer.Dispose()
    End Sub

    Private Sub Packet_GameData(ByRef data() As Byte)
        Dim n As Integer, i As Integer, z As Integer, x As Integer
        Dim buffer As New ByteStream(Compression.DecompressBytes(data))

        For i = 1 To MAX_JOBS
            With Job(i)
                ReDim .Stat(StatType.Count - 1)

                .Name = Trim(buffer.ReadString)
                .Desc = Trim$(buffer.ReadString)

                .MaleSprite = buffer.ReadInt32
                .FemaleSprite = buffer.ReadInt32

                For q = 1 To StatType.Count - 1
                    .Stat(q) = buffer.ReadInt32
                Next

                For q = 1 To 5
                    .StartItem(q) = buffer.ReadInt32
                    .StartValue(q) = buffer.ReadInt32
                Next

                .StartMap = buffer.ReadInt32
                .StartX = buffer.ReadByte
                .StartY = buffer.ReadByte

                .BaseExp = buffer.ReadInt32
            End With

        Next

        i = 0
        x = 0
        n = 0
        z = 0

        x = buffer.ReadInt32

        For i = 0 To x
            n = buffer.ReadInt32

            ' Update the item
            Item(n).AccessReq = buffer.ReadInt32()

            For z = 1 To StatType.Count - 1
                Item(n).Add_Stat(z) = buffer.ReadInt32()
            Next

            Item(n).Animation = buffer.ReadInt32()
            Item(n).BindType = buffer.ReadInt32()
            Item(n).JobReq = buffer.ReadInt32()
            Item(n).Data1 = buffer.ReadInt32()
            Item(n).Data2 = buffer.ReadInt32()
            Item(n).Data3 = buffer.ReadInt32()
            Item(n).TwoHanded = buffer.ReadInt32()
            Item(n).LevelReq = buffer.ReadInt32()
            Item(n).Mastery = buffer.ReadInt32()
            Item(n).Name = Trim$(buffer.ReadString())
            Item(n).Paperdoll = buffer.ReadInt32()
            Item(n).Icon = buffer.ReadInt32()
            Item(n).Price = buffer.ReadInt32()
            Item(n).Rarity = buffer.ReadInt32()
            Item(n).Speed = buffer.ReadInt32()

            Item(n).Randomize = buffer.ReadInt32()
            Item(n).RandomMin = buffer.ReadInt32()
            Item(n).RandomMax = buffer.ReadInt32()

            Item(n).Stackable = buffer.ReadInt32()
            Item(n).Description = Trim$(buffer.ReadString())

            For z = 1 To StatType.Count - 1
                Item(n).Stat_Req(z) = buffer.ReadInt32()
            Next

            Item(n).Type = buffer.ReadInt32()
            Item(n).SubType = buffer.ReadInt32

            Item(n).ItemLevel = buffer.ReadInt32

            Item(n).KnockBack = buffer.ReadInt32()
            Item(n).KnockBackTiles = buffer.ReadInt32()

            Item(n).Projectile = buffer.ReadInt32()
            Item(n).Ammo = buffer.ReadInt32()
        Next

        ' changes to inventory, need to clear any drop menu
        TmpCurrencyItem = 0
        CurrencyMenu = 0 ' clear

        i = 0
        n = 0
        x = 0
        z = 0
        x = buffer.ReadInt32

        For i = 0 To x
            n = buffer.ReadInt32
            ' Update the Animation
            For z = 0 To UBound(Animation(n).Frames) - 1
                Animation(n).Frames(z) = buffer.ReadInt32()
            Next

            For z = 0 To UBound(Animation(n).LoopCount) - 1
                Animation(n).LoopCount(z) = buffer.ReadInt32()
            Next

            For z = 0 To UBound(Animation(n).LoopTime) - 1
                Animation(n).LoopTime(z) = buffer.ReadInt32()
            Next

            Animation(n).Name = Trim$(buffer.ReadString)
            Animation(n).Sound = Trim$(buffer.ReadString)

            If Animation(n).Name Is Nothing Then Animation(n).Name = ""
            If Animation(n).Sound Is Nothing Then Animation(n).Sound = ""

            For z = 0 To UBound(Animation(n).Sprite) - 1
                Animation(n).Sprite(z) = buffer.ReadInt32()
            Next
        Next

        i = 0
        n = 0
        x = 0
        z = 0

        x = buffer.ReadInt32
        For i = 0 To x
            n = buffer.ReadInt32
            ' Update the Npc
            NPC(n).Animation = buffer.ReadInt32()
            NPC(n).AttackSay = buffer.ReadString()
            NPC(n).Behaviour = buffer.ReadByte()

            For z = 0 To 5
                NPC(n).DropChance(z) = buffer.ReadInt32()
                NPC(n).DropItem(z) = buffer.ReadInt32()
                NPC(n).DropItemValue(z) = buffer.ReadInt32()
            Next

            NPC(n).Exp = buffer.ReadInt32()
            NPC(n).Faction = buffer.ReadByte()
            NPC(n).HP = buffer.ReadInt32()
            NPC(n).Name = buffer.ReadString()
            NPC(n).Range = buffer.ReadByte()
            NPC(n).SpawnTime = buffer.ReadByte()
            NPC(n).SpawnSecs = buffer.ReadInt32()
            NPC(n).Sprite = buffer.ReadInt32()

            For z = 1 To StatType.Count - 1
                NPC(n).Stat(z) = buffer.ReadByte()
            Next

            ReDim NPC(n).Skill(MAX_NPC_SKILLS)
            For z = 1 To MAX_NPC_SKILLS
                NPC(n).Skill(z) = buffer.ReadByte()
            Next

            NPC(i).Level = buffer.ReadInt32()
            NPC(i).Damage = buffer.ReadInt32()
        Next

        i = 0
        n = 0
        x = 0
        z = 0

        x = buffer.ReadInt32

        For i = 0 To x
            n = buffer.ReadInt32

            Shop(n).BuyRate = buffer.ReadInt32()
            Shop(n).Name = Trim(buffer.ReadString())
            Shop(n).Face = buffer.ReadInt32()

            For z = 1 To MAX_TRADES
                Shop(n).TradeItem(z).CostItem = buffer.ReadInt32()
                Shop(n).TradeItem(z).CostValue = buffer.ReadInt32()
                Shop(n).TradeItem(z).Item = buffer.ReadInt32()
                Shop(n).TradeItem(z).ItemValue = buffer.ReadInt32()
            Next

        Next

        i = 0
        n = 0
        x = 0
        z = 0

        x = buffer.ReadInt32

        For i = 0 To x
            n = buffer.ReadInt32

            Skill(n).AccessReq = buffer.ReadInt32()
            Skill(n).AoE = buffer.ReadInt32()
            Skill(n).CastAnim = buffer.ReadInt32()
            Skill(n).CastTime = buffer.ReadInt32()
            Skill(n).CdTime = buffer.ReadInt32()
            Skill(n).JobReq = buffer.ReadInt32()
            Skill(n).Dir = buffer.ReadInt32()
            Skill(n).Duration = buffer.ReadInt32()
            Skill(n).Icon = buffer.ReadInt32()
            Skill(n).Interval = buffer.ReadInt32()
            Skill(n).IsAoE = buffer.ReadInt32()
            Skill(n).LevelReq = buffer.ReadInt32()
            Skill(n).Map = buffer.ReadInt32()
            Skill(n).MpCost = buffer.ReadInt32()
            Skill(n).Name = Trim(buffer.ReadString())
            Skill(n).Range = buffer.ReadInt32()
            Skill(n).SkillAnim = buffer.ReadInt32()
            Skill(n).StunDuration = buffer.ReadInt32()
            Skill(n).Type = buffer.ReadInt32()
            Skill(n).Vital = buffer.ReadInt32()
            Skill(n).X = buffer.ReadInt32()
            Skill(n).Y = buffer.ReadInt32()

            Skill(n).IsProjectile = buffer.ReadInt32()
            Skill(n).Projectile = buffer.ReadInt32()

            Skill(n).KnockBack = buffer.ReadInt32()
            Skill(n).KnockBackTiles = buffer.ReadInt32()

        Next

        i = 0
        x = 0
        n = 0
        z = 0

        x = buffer.ReadInt32

        For i = 0 To x
            n = buffer.ReadInt32

            Resource(n).Animation = buffer.ReadInt32()
            Resource(n).EmptyMessage = Trim(buffer.ReadString())
            Resource(n).ExhaustedImage = buffer.ReadInt32()
            Resource(n).Health = buffer.ReadInt32()
            Resource(n).ExpReward = buffer.ReadInt32()
            Resource(n).ItemReward = buffer.ReadInt32()
            Resource(n).Name = Trim(buffer.ReadString())
            Resource(n).ResourceImage = buffer.ReadInt32()
            Resource(n).ResourceType = buffer.ReadInt32()
            Resource(n).RespawnTime = buffer.ReadInt32()
            Resource(n).SuccessMessage = Trim(buffer.ReadString())
            Resource(n).LvlRequired = buffer.ReadInt32()
            Resource(n).ToolRequired = buffer.ReadInt32()
            Resource(n).Walkthrough = buffer.ReadInt32()
        Next

        i = 0
        n = 0
        x = 0
        z = 0

        buffer.Dispose()
    End Sub

    Private Sub Packet_Target(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)

        MyTarget = buffer.ReadInt32
        MyTargetType = buffer.ReadInt32

        buffer.Dispose()
    End Sub

    Private Sub Packet_MapReport(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)

        For i = 1 To MAX_MAPS
            MapNames(i) = Trim(buffer.ReadString())
        Next

        buffer.Dispose()
    End Sub

    Private Sub Packet_Admin(ByRef data() As Byte)
        InitAdminForm = True
    End Sub

    Private Sub Packet_MapNames(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)
        For i = 1 To MAX_MAPS
            MapNames(i) = Trim(buffer.ReadString())
        Next

        buffer.Dispose()
    End Sub
    Private Sub Packet_Critical(ByRef data() As Byte)
        ShakeTimerEnabled = True
        ShakeTimer = GetTickCount()
    End Sub

    Private Sub Packet_RClick(ByRef data() As Byte)
        ShowRClick = True
    End Sub

    Private Sub Packet_Emote(ByRef data() As Byte)
        Dim index As Integer, emote As Integer
        Dim buffer As New ByteStream(data)
        index = buffer.ReadInt32
        emote = buffer.ReadInt32

        With Player(index)
            .Emote = emote
            .EmoteTimer = GetTickCount() + 5000
        End With

        buffer.Dispose()

    End Sub

    Private Sub Packet_ChatBubble(ByRef data() As Byte)
        Dim targetType As Integer, target As Integer, message As String, Color As Integer
        Dim buffer As New ByteStream(data)

        target = buffer.ReadInt32
        targetType = buffer.ReadInt32
        message = Trim(buffer.ReadString)
        Color = buffer.ReadInt32
        AddChatBubble(target, targetType, message, Color)

        buffer.Dispose()

    End Sub

    Private Sub Packet_LeftGame(ByRef data() As Byte)
        LogoutGame()
    End Sub

    '*****************
    '***  EDITORS  ***
    '*****************
    Private Sub Packet_EditAnimation(ByRef data() As Byte)
        InitAnimationEditor = True
    End Sub

    Private Sub Packet_ClassEditor(ByRef data() As Byte)
        InitJobEditor = True
    End Sub

    Sub Packet_EditItem(ByRef data() As Byte)
        InitItemEditor = True
    End Sub

    Private Sub Packet_NPCEditor(ByRef data() As Byte)
        InitNPCEditor = True
    End Sub

    Private Sub Packet_ResourceEditor(ByRef data() As Byte)
        InitResourceEditor = True
    End Sub

    Friend Sub Packet_PetEditor(ByRef data() As Byte)
        InitPetEditor = True
    End Sub

    Friend Sub HandleProjectileEditor(ByRef data() As Byte)
        InitProjectileEditor = True
    End Sub

    Private Sub Packet_EditShop(ByRef data() As Byte)
        InitShopEditor = True
    End Sub

    Private Sub Packet_EditSkill(ByRef data() As Byte)
        InitSkillEditor = True
    End Sub

    Private Sub Packet_Clock(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
        Time.Instance.GameSpeed = buffer.ReadInt32()
        Time.Instance.Time = New Date(BitConverter.ToInt64(buffer.ReadBytes(), 0))

        buffer.Dispose()
    End Sub

    Private Sub Packet_Time(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)

        Time.Instance.TimeOfDay = buffer.ReadByte

        Select Case Time.Instance.TimeOfDay
            Case TimeOfDay.Dawn
                AddText("A chilling, refreshing, breeze has come with the morning.", ColorType.BrightBlue)
                Exit Select

            Case TimeOfDay.Day
                AddText("Day has dawned in this region.", ColorType.Yellow)
                Exit Select

            Case TimeOfDay.Dusk
                AddText("Dusk has begun darkening the skies...", ColorType.BrightRed)
                Exit Select

            Case Else
                AddText("Night has fallen upon the weary travelers.", ColorType.DarkGray)
                Exit Select
        End Select

        buffer.Dispose()
    End Sub

    Friend Sub Packet_Hotbar(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)

        For i = 1 To MAX_HOTBAR
            Player(MyIndex).Hotbar(i).Slot = buffer.ReadInt32
            Player(MyIndex).Hotbar(i).SlotType = buffer.ReadInt32
        Next

        buffer.Dispose()
    End Sub

    Sub Packet_EditMoral(ByRef data() As Byte)
        InitMoralEditor = True
    End Sub

     Sub Packet_UpdateMoral(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)

        i = buffer.ReadInt32()

        With Moral(i)
            .Name = buffer.ReadString()
            .Color = buffer.ReadByte()
            .NPCBlock = buffer.ReadBoolean()
            .PlayerBlock = buffer.ReadBoolean()
            .DropItems = buffer.ReadBoolean()
            .CanCast = buffer.ReadBoolean()
            .CanDropItem = buffer.ReadBoolean()
            .CanPickupItem = buffer.ReadBoolean()
            .CanPK = buffer.ReadBoolean()
            .DropItems = buffer.ReadBoolean()
            .LoseExp = buffer.ReadBoolean()
        End With

        buffer.Dispose()
    End Sub

End Module