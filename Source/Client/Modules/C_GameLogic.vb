Imports Core
Imports Mirage.Sharp.Asfw
Imports SFML.Graphics
Imports Color = SFML.Graphics.Color

Module C_GameLogic
    Friend GameRand As New Random()

    Sub GameLoop()
        Dim i As Integer
        Dim tmr1000 As Integer, tick As Integer, fogtmr As Integer, chattmr As Integer
        Dim tmpfps As Integer, tmplps As Integer, walkTimer As Integer, frameTime As Integer
        Dim tmrweather As Integer, barTmr As Integer
        Dim tmr25 As Integer, tmr500 As Integer, tmr250 As Integer, tmrconnect As Integer, TickFPS As Integer
        Dim fadetmr As Integer, rendertmr As Integer
        Dim animationtmr(1) As Integer

        ' Main game loop
        While InGame Or InMenu
            If GameDestroyed Then End

            tick = GetTickCount()
            ElapsedTime = tick - frameTime ' Set the time difference for time-based movement

            frameTime = tick

            DirUp = VbKeyUp
            DirDown = VbKeyDown
            DirLeft = VbKeyLeft
            DirRight = VbKeyRight

            If GameStarted() Then
                'Calculate FPS
                If tmr1000 < tick Then
                    GetPing()
                    tmr1000 = tick + 1000
                End If

                If tmr25 < tick Then
                    PlayMusic(Map.Music)
                    tmr25 = tick + 25
                End If

                If ShowAnimTimer < tick Then
                    ShowAnimLayers = Not ShowAnimLayers
                    ShowAnimTimer = tick + 500
                End If

                For layer As Integer = 0 To 1
                    If animationtmr(layer) < tick Then
                        For x = 0 To Map.MaxX
                            For y = 0 To Map.MaxY
                                If IsValidMapPoint(x, y) Then   
                                    on Error GoTo mapsync
                                    If Map.Tile(x, y).Data1 > 0 And (Map.Tile(x, y).Type = TileType.Animation Or Map.Tile(x, y).Type2 = TileType.Animation)  Then
                                        Dim sprite As Integer = Animation(Map.Tile(x, y).Data1).Sprite(layer)

                                        If sprite > 0 Then
                                            LoadTexture(sprite, GfxType.Animation)
                                            Dim graphicInfo As GraphicInfo = AnimationGfxInfo(sprite)

                                            ' Get dimensions and column count from controls and graphic info
                                            Dim totalWidth As Integer = graphicInfo.Width
                                            Dim totalHeight As Integer = graphicInfo.Height
                                            Dim columns As Integer = Animation(Map.Tile(x, y).Data1).Frames(layer)
                                            Dim frameWidth As Integer

                                            ' Calculate frame dimensions
                                            If columns > 0 Then
                                                framewidth = totalWidth / columns
                                            End If

                                            Dim frameHeight As Integer = frameWidth
                                            Dim rows As Integer

                                            If frameHeight > 0 Then
                                                rows = totalHeight / frameHeight                                    
                                            End If

                                            Dim frameCount As Integer = rows * columns

                                            animationtmr(layer) = tick + Animation(Map.Tile(x, y).Data1).LoopTime(layer) * frameCount * Animation(Map.Tile(x, y).Data1).LoopCount(layer)
                                            CreateAnimation(Map.Tile(x, y).Data1, x, y)
                                        Else
                                            StreamAnimation(Map.Tile(x, y).Data1)
                                        End If
                                    End If
                                End If
                            Next
                        Next
                        mapsync:
                        
                    End If
                Next

                For i = 0 To Byte.MaxValue
                    CheckAnimInstance(i)
                Next

                If tick > EventChatTimer Then
                    If EventText = "" Then
                        If EventChat = True Then
                            EventChat = False
                        End If
                    End If
                End If

                ' screenshake
                If ShakeTimerEnabled Then
                    If ShakeTimer < tick Then
                        If ShakeCount < 10 Then
                            If LastDir = 0 Then
                                LastDir = 1
                            Else
                                LastDir = 0
                            End If
                        Else
                            ShakeCount = 0
                            ShakeTimerEnabled = False
                        End If

                        ShakeCount += 1

                        ShakeTimer = tick + 50
                    End If
                End If

                ' check if we need to end the CD icon
                If NumSkills > 0 Then
                    For i = 1 To MAX_PLAYER_SKILLS
                        If Player(MyIndex).Skill(i).Num > 0 Then
                            If Player(MyIndex).Skill(i).CD > 0 Then
                                If Player(MyIndex).Skill(i).CD + (Skill(Player(MyIndex).Skill(i).Num).CdTime * 1000) < tick Then
                                    Player(MyIndex).Skill(i).CD = 0
                                End If
                            End If
                        End If
                    Next
                End If

                ' check if we need to unlock the player's skill casting restriction
                If SkillBuffer > 0 Then
                    If SkillBufferTimer + (Skill(Player(MyIndex).Skill(SkillBuffer).Num).CastTime * 1000) < tick Then
                        SkillBuffer = 0
                        SkillBufferTimer = 0
                    End If
                End If

                ' check if we need to unlock the pets's Skill casting restriction
                If PetSkillBuffer > 0 Then
                    If PetSkillBufferTimer + (Skill(Pet(Player(MyIndex).Pet.Num).Skill(PetSkillBuffer)).CastTime * 1000) < tick Then
                        PetSkillBuffer = 0
                        PetSkillBufferTimer = 0
                    End If
                End If

                If CanMoveNow Then
                    CheckMovement() ' Check if player is trying to move
                    CheckAttack()   ' Check to see if player is trying to attack
                End If

                ' Process input before rendering, otherwise input will be behind by 1 frame
                If walkTimer < tick Then
                    For i = 1 To MAX_PLAYERS
                        If IsPlaying(i) Then
                            ProcessPlayerMovement(i)
                            If PetAlive(i) Then
                                ProcessPetMovement(i)
                            End If
                        End If
                    Next

                    ' Process npc movements (actually move them)
                    For i = 1 To MAX_MAP_NPCS
                        If Map.Npc(i) > 0 Then
                            ProcessNpcMovement(i)
                        End If
                    Next

                    For I = 1 To CurrentEvents
                        ProcessEventMovement(i)
                    Next

                    walkTimer = tick + 25 ' edit this value to change WalkTimer
                End If

                ' chat timer
                If chattmr < tick Then
                    ' scrolling
                    If ChatButtonUp Then
                        ScrollChatBox(0)
                    End If

                    If ChatButtonDown Then
                        ScrollChatBox(1)
                    End If

                    chattmr = tick + 50
                End If

                ' fog scrolling
                If fogtmr < tick Then
                    If CurrentFogSpeed > 0 Then
                        ' move
                        FogOffsetX = FogOffsetX - 1
                        FogOffsetY = FogOffsetY - 1

                        ' reset
                        If FogOffsetX < -255 Then FogOffsetX = 1
                        If FogOffsetY < -255 Then FogOffsetY = 1
                        fogtmr = tick + 255 - CurrentFogSpeed
                    End If
                End If

                If tmr500 < tick Then
                    ' animate waterfalls
                    Select Case WaterfallFrame
                        Case 0
                            WaterfallFrame = 1
                        Case 1
                            WaterfallFrame = 2
                        Case 2
                            WaterfallFrame = 0
                    End Select

                    ' animate autotiles
                    Select Case AutoTileFrame
                        Case 0
                            AutoTileFrame = 1
                        Case 1
                            AutoTileFrame = 2
                        Case 2
                            AutoTileFrame = 0
                    End Select

                    ' animate textbox
                    If chatShowLine = "|" Then
                        chatShowLine = ""
                    Else
                        chatShowLine = "|"
                    End If

                    tmr500 = tick + 500
                End If

                ' elastic bars
                If barTmr < tick Then
                    SetBarWidth(BarWidth_GuiHP_Max, BarWidth_GuiHP)
                    SetBarWidth(BarWidth_GuiSP_Max, BarWidth_GuiSP)
                    SetBarWidth(BarWidth_GuiEXP_Max, BarWidth_GuiEXP)
                    For i = 1 To MAX_MAP_NPCS
                        If MapNpc(i).num > 0 Then
                            SetBarWidth(BarWidth_NpcHP_Max(i), BarWidth_NpcHP(i))
                        End If
                    Next

                    For i = 1 To MAX_PLAYERS
                        If IsPlaying(i) And GetPlayerMap(i) = GetPlayerMap(MyIndex) Then
                            SetBarWidth(BarWidth_PlayerHP_Max(i), BarWidth_PlayerHP(i))
                            SetBarWidth(BarWidth_PlayerSP_Max(i), BarWidth_PlayerSP(i))
                        End If
                    Next

                    ' reset timer
                    barTmr = tick + 10
                End If

                ' Change map animation
                If tmr250 < tick Then
                    If MapAnim = 0 Then
                        MapAnim = 1
                    Else
                        MapAnim = 0
                    End If
                    tmr250 = tick + 250
                End If

                If FadeInSwitch = True Then
                    FadeIn()
                End If

                If FadeOutSwitch = True Then
                    FadeOut()
                End If
            Else
                If tmr500 < tick Then
                    ' animate textbox
                    If chatShowLine = "|" Then
                        chatShowLine = ""
                    Else
                        chatShowLine = "|"
                    End If

                    tmr500 = tick + 500
                End If

                If tmr25 < tick Then
                    PlayMusic(Types.Settings.MenuMusic)
                    tmr25 = tick + 25
                End If
            End If

            If tmrweather < tick Then
                ProcessWeather()
                tmrweather = tick + 50
            End If

            If fadetmr < tick Then
                If FadeType <> 2 Then
                    If FadeType = 1 Then
                        If FadeAmount = 255 Then
                        Else
                            FadeAmount = FadeAmount + 5
                        End If
                    ElseIf FadeType = 0 Then
                        If FadeAmount = 0 Then
                            UseFade = False
                        Else
                            FadeAmount = FadeAmount - 5
                        End If
                    End If
                End If
                fadetmr = tick + 30
            End If

            if InGame Then
                Render_Graphics()
            Else
                Render_Menu()
            End If

            ' Calculate fps
            If TickFPS < tick Then
                GameFps = Fps
                TickFPS = tick + 1000
                Fps = 0
            Else
                Fps += 1
            End If

            Window.DispatchEvents()
            UpdateWindow()
            ResizeGUI()
        End While
    End Sub

    Sub ProcessNpcMovement(mapNpcNum As Integer)

        ' Check if NPC is walking, and if so process moving them over
        If MapNpc(mapNpcNum).Moving = MovementType.Walking Then

            Select Case MapNpc(mapNpcNum).Dir
                Case DirectionType.Up
                    MapNpc(mapNpcNum).YOffset = MapNpc(mapNpcNum).YOffset - ((ElapsedTime / 1000) * (WalkSpeed * SizeY))
                    If MapNpc(mapNpcNum).YOffset < 0 Then MapNpc(mapNpcNum).YOffset = 0

                Case DirectionType.Down
                    MapNpc(mapNpcNum).YOffset = MapNpc(mapNpcNum).YOffset + ((ElapsedTime / 1000) * (WalkSpeed * SizeY))
                    If MapNpc(mapNpcNum).YOffset > 0 Then MapNpc(mapNpcNum).YOffset = 0

                Case DirectionType.Left
                    MapNpc(mapNpcNum).XOffset = MapNpc(mapNpcNum).XOffset - ((ElapsedTime / 1000) * (WalkSpeed * SizeX))
                    If MapNpc(mapNpcNum).XOffset < 0 Then MapNpc(mapNpcNum).XOffset = 0

                Case DirectionType.Right
                    MapNpc(mapNpcNum).XOffset = MapNpc(mapNpcNum).XOffset + ((ElapsedTime / 1000) * (WalkSpeed * SizeX))
                    If MapNpc(mapNpcNum).XOffset > 0 Then MapNpc(mapNpcNum).XOffset = 0

            End Select

            ' Check if completed walking over to the next tile
            If MapNpc(mapNpcNum).Moving > 0 Then
                If MapNpc(mapNpcNum).Dir = DirectionType.Right Or MapNpc(mapNpcNum).Dir = DirectionType.Down Then
                    If (MapNpc(mapNpcNum).XOffset >= 0) And (MapNpc(mapNpcNum).YOffset >= 0) Then
                        MapNpc(mapNpcNum).Moving = 0
                        If MapNpc(mapNpcNum).Steps = 1 Then
                            MapNpc(mapNpcNum).Steps = 3
                        Else
                            MapNpc(mapNpcNum).Steps = 1
                        End If
                    End If
                Else
                    If (MapNpc(mapNpcNum).XOffset <= 0) And (MapNpc(mapNpcNum).YOffset <= 0) Then
                        MapNpc(mapNpcNum).Moving = 0
                        If MapNpc(mapNpcNum).Steps = 1 Then
                            MapNpc(mapNpcNum).Steps = 3
                        Else
                            MapNpc(mapNpcNum).Steps = 1
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Friend Function IsInBounds()
        IsInBounds = False

        If (CurX >= 0) And (CurX <= Map.MaxX) Then
            If (CurY >= 0) And (CurY <= Map.MaxY) Then
                IsInBounds = True
            End If
        End If

    End Function

    Function GameStarted() As Boolean
        GameStarted = False
        If InGame = False Then Exit Function
        If MapData = False Then Exit Function
        If PlayerData = False Then Exit Function
        GameStarted = True
    End Function

    Friend Sub CreateActionMsg(message As String, color As Integer, msgType As Byte, x As Integer, y As Integer)

        ActionMsgIndex = ActionMsgIndex + 1
        If ActionMsgIndex >= Byte.MaxValue Then ActionMsgIndex = 1

        With ActionMsg(ActionMsgIndex)
            .Message = message
            .Color = color
            .Type = msgType
            .Created = GetTickCount()
            .Scroll = 1
            .X = x
            .Y = y
        End With

        If ActionMsg(ActionMsgIndex).Type = ActionMsgType.Scroll Then
            ActionMsg(ActionMsgIndex).Y = ActionMsg(ActionMsgIndex).Y + Rand(-2, 6)
            ActionMsg(ActionMsgIndex).X = ActionMsg(ActionMsgIndex).X + Rand(-8, 8)
        End If

    End Sub

    Friend Function Rand(maxNumber As Integer, Optional minNumber As Integer = 0) As Integer
        If minNumber > maxNumber Then
            Dim t As Integer = minNumber
            minNumber = maxNumber
            maxNumber = t
        End If

        Return GameRand.Next(minNumber, maxNumber)
    End Function

    ' BitWise Operators for directional blocking
    Friend Sub SetDirBlock(ByRef blockvar As Byte, ByRef dir As Byte, block As Boolean)
        If block Then
            blockvar = blockvar Or (2 ^ dir)
        Else
            blockvar = blockvar And Not (2 ^ dir)
        End If
    End Sub

    Friend Function IsDirBlocked(ByRef blockvar As Byte, ByRef dir As Byte) As Boolean
        Return blockvar And (2 ^ dir)
    End Function

    Friend Function ConvertCurrency(amount As Integer) As String

        If Int(amount) < 10000 Then
            ConvertCurrency = amount
        ElseIf Int(amount) < 999999 Then
            ConvertCurrency = Int(amount / 1000) & "k"
        ElseIf Int(amount) < 999999999 Then
            ConvertCurrency = Int(amount / 1000000) & "m"
        Else
            ConvertCurrency = Int(amount / 1000000000) & "b"
        End If

    End Function

    Sub HandlePressEnter()
        Dim chatText As String
        Dim name As String
        Dim i As Integer
        Dim n As Integer
        Dim command() As String
        Dim buffer As ByteStream

        If InGame Then
            chatText = Windows(GetWindowIndex("winChat")).Controls(GetControlIndex("winChat", "txtChat")).Text
        End If

        ' hide/show chat window
        If chatText = "" Then
            If Windows(GetWindowIndex("winChat")).Window.Visible Then
                Windows(GetWindowIndex("winChat")).Controls(GetControlIndex("winChat", "txtChat")).Text = ""
                HideChat()
                Exit Sub
            End If
        End If

        ' Admin message
        If Left$(chatText, 1) = "@" Then
            chatText = Mid$(chatText, 2, Len(chatText) - 1)

            If Len(chatText) > 0 Then
                AdminMsg(chatText)
            End If

            Windows(GetWindowIndex("winChat")).Controls(GetControlIndex("winChat", "txtChat")).text = ""
            Exit Sub
        End If

        ' Broadcast message
        If Left$(chatText, 1) = "'" Then
            chatText = Mid$(chatText, 2, Len(chatText) - 1)

            If Len(chatText) > 0 Then
                BroadcastMsg(chatText)
            End If

            Windows(GetWindowIndex("winChat")).Controls(GetControlIndex("winChat", "txtChat")).text = ""
            Exit Sub
        End If

        ' party message
        If Left$(chatText, 1) = "-" Then
            chatText = Mid$(chatText, 2, Len(chatText) - 1)

            If Len(chatText) > 0 Then
                SendPartyChatMsg(chatText)
            End If

            Windows(GetWindowIndex("winChat")).Controls(GetControlIndex("winChat", "txtChat")).text = ""
            Exit Sub
        End If

        ' Player message
        If Left$(chatText, 1) = "!" Then
            chatText = Mid$(chatText, 2, Len(chatText) - 1)
            name = ""

            ' Get the desired player from the user text
            For i = 0 To Len(chatText)

                If Mid$(chatText, i, 1) <> Space(1) Then
                    name = name & Mid$(chatText, i, 1)
                Else
                    Exit For
                End If

            Next

            chatText = Trim$(Mid$(chatText, i, Len(chatText) - 1))

            ' Make sure they are actually sending something
            If Len(chatText) > 0 Then
                ' Send the message to the player
                PlayerMsg(chatText, name)
            Else
                AddText(Language.Chat.PlayerMsg, ColorType.Yellow)
            End If

            GoTo Continue1
        End If

        If Left$(chatText, 1) = "/" Then
            command = Split(chatText, Space(1))

            Select Case command(0)
                Case "/emote"
                    ' Checks to make sure we have more than one string in the array
                    If UBound(command) < 1 OrElse Not IsNumeric(command(1)) Then
                        AddText(Language.Chat.Emote, ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendUseEmote(command(1))

                Case "/help"
                    AddText(Language.Chat.Help1, ColorType.Yellow)
                    AddText(Language.Chat.Help2, ColorType.Yellow)
                    AddText(Language.Chat.Help3, ColorType.Yellow)
                    AddText(Language.Chat.Help4, ColorType.Yellow)
                    AddText(Language.Chat.Help5, ColorType.Yellow)
                    AddText(Language.Chat.Help6, ColorType.Yellow)

                Case "/info"
                    If MyTarget > 0 Then
                        If MyTargetType = TargetType.Player Then
                            SendPlayerInfo(GetPlayerName(MyTarget))
                            GoTo Continue1
                        End If
                    End If

                    ' Checks to make sure we have more than one string in the array
                    If UBound(command) < 1 OrElse IsNumeric(command(1)) Then
                        AddText(Language.Chat.Info, ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendPlayerInfo(command(1))

                ' Whos Online
                Case "/who"
                    SendWhosOnline()

                ' Requets level up
                Case "/levelup"
                    SendRequestLevelUp()

                ' Checking fps
                Case "/fps"
                    Bfps = Not Bfps

                Case "/lps"
                    Blps = Not Blps

                ' Request stats
                Case "/stats"
                    buffer = New ByteStream(4)
                    buffer.WriteInt32(ClientPackets.CGetStats)
                    Socket.SendData(buffer.Data, buffer.Head)
                    buffer.Dispose()

                Case "/party"
                    If MyTarget > 0 Then
                        If MyTargetType = TargetType.Player Then
                            SendPartyRequest(GetPlayerName(MyTarget))
                            GoTo Continue1
                        End If
                    End If

                    ' Make sure they are actually sending something
                    If UBound(command) < 1 OrElse IsNumeric(command(1)) Then
                        AddText(Language.Chat.Party, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    SendPartyRequest(command(1))

                ' Join party
                Case "/join"
                    SendAcceptParty()

                ' Leave party
                Case "/leave"
                    SendLeaveParty()

                ' Trade
                Case "/trade"
                    If MyTarget > 0 Then
                        If MyTargetType = TargetType.Player Then
                            SendTradeRequest(GetPlayerName(MyTarget))
                            GoTo Continue1
                        End If
                    End If

                    ' Make sure they are actually sending something
                    If UBound(command) < 1 OrElse IsNumeric(command(1)) Then
                        AddText(Language.Chat.Trade, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    SendTradeRequest(command(1))

                ' // Moderator Admin Commands //
                ' Admin Help
                Case "/admin"
                    If GetPlayerAccess(MyIndex) < AccessType.Moderator Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    AddText(Language.Chat.Admin1, ColorType.Yellow)
                    AddText(Language.Chat.Admin2, ColorType.Yellow)
                    AddText(Language.Chat.AdminGblMsg, ColorType.Yellow)
                    AddText(Language.Chat.AdminPvtMsg, ColorType.Yellow)

                ' Kicking a player
                Case "/kick"

                    If GetPlayerAccess(MyIndex) < AccessType.Moderator Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    If UBound(command) < 1 OrElse IsNumeric(command(1)) Then
                        AddText(Language.Chat.Kick, ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendKick(command(1))

                ' // Mapper Admin Commands //
                ' Location
                Case "/loc"

                    If GetPlayerAccess(MyIndex) < AccessType.Mapper Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    BLoc = Not BLoc

                ' Warping to a player
                Case "/warpmeto"

                    If GetPlayerAccess(MyIndex) < AccessType.Mapper Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    If UBound(command) < 1 OrElse IsNumeric(command(1)) Then
                        AddText(Language.Chat.WarpMeTo, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    WarpMeTo(command(1))

                ' Warping a player to you
                Case "/warptome"

                    If GetPlayerAccess(MyIndex) < AccessType.Mapper Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    If UBound(command) < 1 OrElse IsNumeric(command(1)) Then
                        AddText(Language.Chat.WarpToMe, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    WarpToMe(command(1))

                ' Warping to a map
                Case "/warpto"

                    If GetPlayerAccess(MyIndex) < AccessType.Mapper Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    If UBound(command) < 1 OrElse Not IsNumeric(command(1)) Then
                        AddText(Language.Chat.WarpTo, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    n = command(1)

                    ' Check to make sure its a valid map #
                    If n > 0 And n <= MAX_MAPS Then
                        WarpTo(n)
                    Else
                        AddText(Language.Chat.InvalidMap, ColorType.BrightRed)
                    End If

                ' Setting sprite
                Case "/sprite"

                    If GetPlayerAccess(MyIndex) < AccessType.Mapper Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    If UBound(command) < 1 OrElse Not IsNumeric(command(1)) Then
                        AddText(Language.Chat.Sprite, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    SendSetSprite(command(1))

                ' Map report
                Case "/mapreport"

                    If GetPlayerAccess(MyIndex) < AccessType.Mapper Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    SendRequestMapReport()

                ' Respawn request
                Case "/respawn"

                    If GetPlayerAccess(MyIndex) < AccessType.Mapper Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    SendMapRespawn()

                Case "/editmap"

                    If GetPlayerAccess(MyIndex) < AccessType.Mapper Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    SendRequestEditMap()

                ' // Moderator Commands //
                ' Welcome change
                Case "/welcome"

                    If GetPlayerAccess(MyIndex) < AccessType.Moderator Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    If UBound(command) < 1 Then
                        AddText(Language.Chat.Welcome, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    SendMotdChange(Right$(chatText, Len(chatText) - 5))

                ' Check the ban list
                Case "/banlist"

                    If GetPlayerAccess(MyIndex) < AccessType.Moderator Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    SendBanList()

                ' Banning a player
                Case "/ban"

                    If GetPlayerAccess(MyIndex) < AccessType.Moderator Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    If UBound(command) < 1 Then
                        AddText(Language.Chat.Ban, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    SendBan(command(1))

                ' // Owner Admin Commands //
                ' Giving another player access
                Case "/bandestroy"

                    If GetPlayerAccess(MyIndex) < AccessType.Owner Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    SendBanDestroy()

                Case "/access"

                    If GetPlayerAccess(MyIndex) < AccessType.Owner Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    If UBound(command) < 2 OrElse
                        IsNumeric(command(1)) Or
                        Not IsNumeric(command(2)) Then
                        AddText(Language.Chat.Access, ColorType.Yellow)
                        GoTo Continue1
                    End If

                    SendSetAccess(command(1), CLng(command(2)))

                ' // Developer Admin Commands //
                Case "/editresource"

                    If GetPlayerAccess(MyIndex) < AccessType.Developer Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    SendRequestEditResource()

                Case "/editanimation"

                    If GetPlayerAccess(MyIndex) < AccessType.Developer Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    SendRequestEditAnimation()

                Case "/editpet"

                    If GetPlayerAccess(MyIndex) < AccessType.Developer Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    SendRequestEditPet()

                Case "/edititem"

                    If GetPlayerAccess(MyIndex) < AccessType.Developer Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    SendRequestEditItem()

                Case "/editprojectile"

                    If GetPlayerAccess(MyIndex) < AccessType.Developer Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    SendRequestEditProjectile()

                Case "/editnpc"

                    If GetPlayerAccess(MyIndex) < AccessType.Developer Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    SendRequestEditNpc()

                Case "/editjob"

                    If GetPlayerAccess(MyIndex) < AccessType.Developer Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    SendRequestEditJob()

                Case "/editskill"

                    If GetPlayerAccess(MyIndex) < AccessType.Developer Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    SendRequestEditSkill()

                Case "/editshop"
                    If GetPlayerAccess(MyIndex) < AccessType.Developer Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    SendRequestEditShop()

                    
                Case "/editmoral"
                    If GetPlayerAccess(MyIndex) < AccessType.Developer Then
                        AddText(Language.Chat.AccessAlert, ColorType.BrightRed)
                        GoTo Continue1
                    End If

                    SendRequestEditMoral()
                Case ""

                Case Else
                    AddText(Language.Chat.InvalidCmd, ColorType.BrightRed)
            End Select

        ElseIf Len(chatText) > 0 Then ' Say message
            SayMsg(chatText)
        End If

Continue1:
        Windows(GetWindowIndex("winChat")).Controls(GetControlIndex("winChat", "txtChat")).Text = ""
    End Sub

    Sub CheckMapGetItem()
        Dim buffer As New ByteStream(4)
        buffer = New ByteStream(4)

        If GetTickCount() > Player(MyIndex).MapGetTimer + 250 Then
            Player(MyIndex).MapGetTimer = GetTickCount()
            buffer.WriteInt32(ClientPackets.CMapGetItem)
            Socket.SendData(buffer.Data, buffer.Head)
        End If

        buffer.Dispose()
    End Sub

    Friend Sub ClearActionMsg(index As Byte)
        ActionMsg(index).Message = ""
        ActionMsg(index).Created = 0
        ActionMsg(index).Type = 0
        ActionMsg(index).Color = 0
        ActionMsg(index).Scroll = 0
        ActionMsg(index).X = 0
        ActionMsg(index).Y = 0
    End Sub

    Friend Sub UpdateDrawMapName()
        If Map.Moral > 0 Then
            DrawMapNameColor = GetSfmlColor(Moral(Map.Moral).Color)
        End If
    End Sub

    Friend Sub AddChatBubble(target As Integer, targetType As Byte, msg As String, Color As Integer)
        Dim i As Integer, index As Integer

        ' Set the global index
        ChatBubbleindex = ChatBubbleindex + 1
        If ChatBubbleindex < 1 Or ChatBubbleindex > Byte.MaxValue Then ChatBubbleindex = 1

        ' Default to new bubble
        index = ChatBubbleindex

        ' Loop through and see if that player/npc already has a chat bubble
        For i = 1 To Byte.MaxValue
            If ChatBubble(i).TargetType = targetType Then
                If ChatBubble(i).Target = target Then
                    ' Reset master index
                    If ChatBubbleindex > 1 Then ChatBubbleindex = ChatBubbleindex - 1

                    ' We use this one now, yes?
                    index = i
                    Exit For
                End If
            End If
        Next

        ' Set the bubble up
        With ChatBubble(index)
            .Target = target
            .TargetType = targetType
            .Msg = msg
            .Color = Color
            .Timer = GetTickCount()
            .Active = True
        End With

    End Sub

    Public Sub DialogueAlert(ByVal Index As Long)
        Dim header As String, body As String, body2 As String

        ' find the body/header
        Select Case Index

            Case DialogueMsg.Connection
                header = "Connection Problem"
                body = "You lost connection to the server."
                body2 = "Please try again later."

            Case DialogueMsg.Banned
                header = "Banned"
                body = "You have been banned, have a nice day!"
                body2 = "Please send all ban appeals to an administrator."

            Case DialogueMsg.Kicked
                header = "Kicked"
                body = "You have been kicked."
                body2 = "Please try and behave."

            Case DialogueMsg.Outdated
                header = "Wrong Version"
                body = "Your game client is the wrong version."
                body2 = "Please reload the game or wait for a patch."

            Case DialogueMsg.Maintenance
                header = "Connection Refused"
                body = "The server is currently going under maintenance."
                body2 = "Please try again soon."

            Case DialogueMsg.NameTaken
                header = "Invalid Name"
                body = "This name is already in use."
                body2 = "Please try another name."

            Case DialogueMsg.NameLength
                header = "Invalid Name"
                body = "This name is too short or too long."
                body2 = "Please try another name."

            Case DialogueMsg.NameIllegal
                header = "Invalid Name"
                body = "This name contains illegal characters."
                body2 = "Please try another name."

            Case DialogueMsg.Database
                header = "Connection Problem"
                body = "Cannot connect to database."
                body2 = "Please try again later."

            Case DialogueMsg.WrongPass
                header = "Invalid Login"
                body = "Invalid username or password."
                body2 = "Please try again."
                ClearPasswordTexts()

            Case DialogueMsg.Activate
                header = "Inactive Account"
                body = "Your account is not activated."
                body2 = "Please activate your account then try again."

            Case DialogueMsg.MaxChar
                header = "Cannot Merge"
                body = "You cannot merge a full account."
                body2 = "Please clear a character slot."

            Case DialogueMsg.DelChar
                header = "Deleted Character"
                body = "Your character was successfully deleted."
                body2 = "Please log on to continue playing."

            Case DialogueMsg.CreateAccount
                header = "Account Created"
                body = "Your account was successfully created."
                body2 = "Now, you can play!"

            Case DialogueMsg.MultiAccount
                header = "Multiple Accounts"
                body = "Using multiple accounts is not authorized."
                body2 = "Please logout of your other account and try again!"

            Case DialogueMsg.Login
                header = "Cannot Login"
                body = "This account does not exist."
                body2 = "Please try registering the account."

            Case DialogueMsg.Crash
                header = "Error"
                body = "There was a network error."
                body2 = "Check logs folder for details."

                HideWindows
                ShowWindow(GetWindowIndex("winLogin")) 
        End Select

        ' set the dialogue up!
        Dialogue(header, body, body2, DialogueType.Alert)
    End Sub

    Public Sub CloseDialogue()
        HideWindow(GetWindowIndex("winDialogue"))
    End Sub

    Public Sub Dialogue(ByVal header As String, ByVal body As String, ByVal body2 As String, ByVal Index As Byte, Optional ByVal style As Byte = 1, Optional ByVal Data1 As Long = 0, Optional ByVal Data2 As Long = 0, Optional ByVal Data3 As Long = 0, Optional ByVal Data4 As Long = 0, Optional ByVal Data5 As Long = 0)
        ' exit out if we've already got a dialogue open
        If GetWindowIndex("winDialogue") = 0 Then Exit Sub
        If Windows(GetWindowIndex("winDialogue")).Window.Visible Then Exit Sub

        ' set buttons
        With Windows(GetWindowIndex("winDialogue"))
            If style = DialogueStyle.YesNo Then
                .Controls(GetControlIndex("winDialogue", "btnYes")).Visible = True
                .Controls(GetControlIndex("winDialogue", "btnNo")).Visible = True
                .Controls(GetControlIndex("winDialogue", "btnOkay")).Visible = False
                .Controls(GetControlIndex("winDialogue", "txtInput")).Visible = False
                .Controls(GetControlIndex("winDialogue", "lblBody_2")).Visible = True
            ElseIf style = DialogueStyle.Okay Then
                .Controls(GetControlIndex("winDialogue", "btnYes")).Visible = False
                .Controls(GetControlIndex("winDialogue", "btnNo")).Visible = False
                .Controls(GetControlIndex("winDialogue", "btnOkay")).Visible = True
                .Controls(GetControlIndex("winDialogue", "txtInput")).Visible = False
                .Controls(GetControlIndex("winDialogue", "lblBody_2")).Visible = True
            ElseIf style = DialogueStyle.Input Then
                .Controls(GetControlIndex("winDialogue", "btnYes")).Visible = False
                .Controls(GetControlIndex("winDialogue", "btnNo")).Visible = False
                .Controls(GetControlIndex("winDialogue", "btnOkay")).Visible = True
                .Controls(GetControlIndex("winDialogue", "txtInput")).Visible = True
                .Controls(GetControlIndex("winDialogue", "lblBody_2")).Visible = False
            End If

            ' set labels
            .Controls(GetControlIndex("winDialogue", "lblHeader")).Text = header
            .Controls(GetControlIndex("winDialogue", "lblBody_1")).Text = body
            .Controls(GetControlIndex("winDialogue", "lblBody_2")).Text = body2
            .Controls(GetControlIndex("winDialogue", "txtInput")).Text = ""
        End With

        ' set it all up
        diaIndex = Index
        diaData1 = Data1
        diaData2 = Data2
        diaData3 = Data3
        diaData4 = Data4
        diaData5 = Data5
        diaStyle = style

        ' make the windows visible
        ShowWindow(GetWindowIndex("winDialogue"), True)
    End Sub

    Public Sub DialogueHandler(ByVal Index As Long)
        Dim value As Long, diaInput As String
        Dim X As Integer
        Dim Y As Integer

        diaInput = Trim$(Windows(GetWindowIndex("winDialogue")).Controls(GetControlIndex("winDialogue", "txtInput")).Text)

        ' Find out which button
        If Index = 1 Then ' Okay button
            ' Dialogue index
            Select Case diaIndex
                Case DialogueType.TradeAmount
                    value = Val(diaInput)
                    TradeItem(diaData1, value)

                Case DialogueType.DepositItem
                    value = Val(diaInput)
                    DepositItem(diaData1, value)

                Case DialogueType.WithdrawItem
                    value = Val(diaInput)
                    WithdrawItem(diaData1, value)

                Case DialogueType.DropItem
                    value = Val(diaInput)
                    SendDropItem(diaData1, value)
            End Select

        ElseIf Index = 2 Then ' Yes button
            ' Dialogue index
            Select Case diaIndex
                Case DialogueType.Trade
                    SendHandleTradeInvite(1)

                Case DialogueType.Forget
                    ForgetSkill(diaData1)

                Case DialogueType.Party
                    SendAcceptParty()

                Case DialogueType.LootItem
                    CheckMapGetItem()

                Case DialogueType.DelChar
                    SendDelChar(diaData1)

                Case DialogueType.FillLayer
                    If diaData2 > 1 Then
                        For X = 0 To Map.MaxX
                            For Y = 0 To Map.MaxY
                                Map.Tile(X, Y).Layer(diaData1).X = diaData3
                                Map.Tile(X, Y).Layer(diaData1).Y = diaData4
                                Map.Tile(X, Y).Layer(diaData1).Tileset = diaData5
                                Map.Tile(X, Y).Layer(diaData1).AutoTile = diaData2
                                CacheRenderState(X, Y, diaData1)
                            Next
                        Next

                        ' do a re-init so we can see our changes
                        InitAutotiles()
                    Else
                        For X = 0 To Map.MaxX
                            For Y = 0 To Map.MaxY
                                Map.Tile(X, Y).Layer(diaData1).X = diaData3
                                Map.Tile(X, Y).Layer(diaData1).Y = diaData4
                                Map.Tile(X, Y).Layer(diaData1).Tileset = diaData5
                                Map.Tile(X, Y).Layer(diaData1).AutoTile = 0
                                CacheRenderState(X, Y, diaData1)
                            Next
                        Next
                    End If

                Case DialogueType.ClearLayer
                    For X = 0 To Map.MaxX
                        For Y = 0 To Map.MaxY
                            With Map.Tile(X, Y)
                                .Layer(diaData1).X = 0
                                .Layer(diaData1).Y = 0
                                .Layer(diaData1).Tileset = 0
                                .Layer(diaData1).AutoTile = 0
                                CacheRenderState(X, Y, diaData1)
                            End With
                        Next
                    Next

                Case DialogueType.ClearAttributes
                    For X = 0 To Map.MaxX
                        For Y = 0 To Map.MaxY
                            Map.Tile(X, Y).Type = 0
                            Map.Tile(X, Y).Type2 = 0
                        Next
                    Next
            End Select

        ElseIf Index = 3 Then ' No button
            ' Dialogue index
            Select Case diaIndex
                Case DialogueType.Trade
                    SendHandleTradeInvite(0)

                Case DialogueType.Party
                    SendDeclineParty()
            End Select
        End If

        CloseDialogue()
        diaIndex = 0
        diaInput = ""
    End Sub

    Public Sub ShowJobs()
        HideWindows()
        newCharJob = 1
        newCharSprite = 1
        newCharGender = SexType.Male
        Windows(GetWindowIndex("winJob")).Controls(GetControlIndex("winJob", "lblClassName")).Text = Trim$(Job(newCharJob).Name)
        Windows(GetWindowIndex("winNewChar")).Controls(GetControlIndex("winNewChar", "txtName")).Text = ""
        Windows(GetWindowIndex("winNewChar")).Controls(GetControlIndex("winNewChar", "chkMale")).Value = 1
        Windows(GetWindowIndex("winNewChar")).Controls(GetControlIndex("winNewChar", "chkFemale")).Value = 0
        ShowWindow(GetWindowIndex("winJob"))
    End Sub

    Public Sub AddChar(name As String, sex As Integer, job As Integer, sprite As Integer)
        If Socket.IsConnected() Then
            Call SendAddChar(name, sex, job)
        Else
            InitNetwork()
            Dialogue("Connection Problem", "Cannot connect to game server.", "Please try again.", DialogueType.Alert)
        End If
    End Sub

    Public Sub ShowChat()
        ShowWindow(GetWindowIndex("winChat"), , False)
        HideWindow(GetWindowIndex("winChatSmall"))
        ' Set the active control
        activeWindow = GetWindowIndex("winChat")
        SetActiveControl(GetWindowIndex("winChat"), GetControlIndex("winChat", "txtChat"))
        inSmallChat = False
        ChatScroll = 0
    End Sub

    Public Sub HideChat()
        ShowWindow(GetWindowIndex("winChatSmall"), , False)
        HideWindow(GetWindowIndex("winChat"))

        ' Set the active control
        activeWindow = GetWindowIndex("winChat")
        SetActiveControl(GetWindowIndex("winChat"), GetControlIndex("winChat", "txtChat"))

        inSmallChat = True
        ChatScroll = 0
    End Sub

    Public Sub SetChatHeight(Height As Long)
        actChatHeight = Height
    End Sub

    Public Sub SetChatWidth(Width As Long)
        actChatWidth = Width
    End Sub

    Public Sub UpdateChat()
        Settings.Save()
    End Sub

    Public Sub ScrollChatBox(ByVal direction As Byte)
        If direction = 0 Then ' up
            If Len(Chat(ChatScroll + 7).Text) > 0 Then
                If ChatScroll < ChatLines Then
                    ChatScroll = ChatScroll + 1
                End If
            End If
        Else
            If ChatScroll > 0 Then
                ChatScroll = ChatScroll - 1
            End If
        End If
    End Sub

    Public Function IsHotbar(StartX As Long, StartY As Long) As Long
        Dim tempRec As RectangleStruct
        Dim i As Long

        For i = 1 To MAX_HOTBAR
            With tempRec
                .Top = StartY + HotbarTop
                .Left = StartX + ((i - 1) * HotbarOffsetX)
                .Right = .Left + PicX
                .Bottom = .Top + PicY
            End With

            If Player(MyIndex).Hotbar(i).Slot > 0 Then
                If CurMouseX >= tempRec.Left And CurMouseX <= tempRec.Right Then
                    If CurMouseY >= tempRec.Top And CurMouseY <= tempRec.Bottom Then
                        IsHotbar = i
                        Exit Function
                    End If
                End If
            End If
        Next
    End Function

    Public Sub ShowInvDesc(x As Long, y As Long, invNum As Long)
        Dim soulBound As Boolean

        If invNum <= 0 Or invNum > MAX_INV Then Exit Sub

        ' show
        If GetPlayerInv(MyIndex, invNum) > 0 Then
            If Item(GetPlayerInv(MyIndex, invNum)).BindType > 0 And Player(MyIndex).Inv(invNum).Bound > 0 Then soulBound = True
            ShowItemDesc(x, y, GetPlayerInv(MyIndex, invNum))
        End If
    End Sub

    Public Sub ShowItemDesc(x As Long, y As Long, itemNum As Long)
        Dim Color As Color, theName As String, jobName As String, levelTxt As String, i As Long

        ' set globals
        descType = PartType.Item ' inventory
        descItem = itemNum

        ' set position
        Windows(GetWindowIndex("winDescription")).Window.Left = x
        Windows(GetWindowIndex("winDescription")).Window.Top = y

        ' show the window
        ShowWindow(GetWindowIndex("winDescription"), , False)

        ' exit out early if last is same
        If (descLastType = descType) And (descLastItem = descItem) Then Exit Sub

        ' set last to this
        descLastType = descType
        descLastItem = descItem

        ' show req. labels
        Windows(GetWindowIndex("winDescription")).Controls(GetControlIndex("winDescription", "lblClass")).Visible = True
        Windows(GetWindowIndex("winDescription")).Controls(GetControlIndex("winDescription", "lblLevel")).Visible = True
        Windows(GetWindowIndex("winDescription")).Controls(GetControlIndex("winDescription", "picBar")).Visible = False

        ' set variables
        With Windows(GetWindowIndex("winDescription"))
            ' name
            'If Not soulBound Then
            theName = Trim$(Item(itemNum).Name)
            'Else
            'theName = "(SB) " & Trim$(Item(itemNum).Name)
            'End If
            .Controls(GetControlIndex("winDescription", "lblName")).Text = theName
            Select Case Item(itemNum).Rarity
                Case 0 ' white
                    Color = Color.White
                Case 1 ' green
                    Color = Color.Green
                Case 2 ' blue
                    Color = Color.Blue
                Case 3 ' maroon
                    Color = Color.Red
                Case 4 ' purple
                    Color = Color.Magenta
                Case 5 ' cyan
                    Color = Color.Cyan
            End Select
            .Controls(GetControlIndex("winDescription", "lblName")).Color = Color

            ' class req
            If Item(itemNum).JobReq > 0 Then
                jobName = Trim$(Job(Item(itemNum).JobReq).Name)
                ' do we match it?
                If GetPlayerJob(MyIndex) = Item(itemNum).JobReq Then
                    Color = Color.Green
                Else
                    Color = Color.Red
                End If
            Else
                jobName = "No Job Req."
                Color = Color.Green
            End If

            .Controls(GetControlIndex("winDescription", "lblClass")).Text = jobName
            .Controls(GetControlIndex("winDescription", "lblClass")).Color = Color
            
            ' level
            If Item(itemNum).LevelReq > 0 Then
                levelTxt = "Level " & Item(itemNum).LevelReq
                ' do we match it?
                If GetPlayerLevel(MyIndex) >= Item(itemNum).LevelReq Then
                    Color = Color.Green
                Else
                    Color = Color.Red
                End If
            Else
                levelTxt = "No Level Req."
                Color = Color.Green
            End If
            .Controls(GetControlIndex("winDescription", "lblLevel")).Text = levelTxt
            .Controls(GetControlIndex("winDescription", "lblLevel")).Color = Color
        End With

        ' clear
        ReDim descText(1)

        ' go through the rest of the text
        Select Case Item(itemNum).Type
            Case ItemType.None
                AddDescInfo("No Type", Color.White)
            Case ItemType.Equipment
                Select Case Item(itemNum).SubType
                    Case ItemSubType.Weapon
                        AddDescInfo("Weapon", Color.White)
                    Case ItemSubType.Armor
                        AddDescInfo("Armor", Color.White)
                    Case ItemSubType.Helmet
                        AddDescInfo("Helmet", Color.White)
                    Case ItemSubType.Shield
                        AddDescInfo("Shield", Color.White)
                    Case ItemSubType.Shoes
                        AddDescInfo("Shoes", Color.White)
                    Case ItemSubType.Gloves
                        AddDescInfo("Gloves", Color.White)
                End Select
            Case ItemType.Consumable
                AddDescInfo("Consumable", Color.White)
            Case ItemType.Currency
                AddDescInfo("Currency", Color.White)
            Case ItemType.Skill
                AddDescInfo("Skill", Color.White)
            Case ItemType.Projectile
                AddDescInfo("Projectile", Color.White)
            Case ItemType.Pet
                AddDescInfo("Pet", Color.White)
        End Select

        ' more info
        Select Case Item(itemNum).Type
            Case ItemType.None, ItemType.Currency
                ' binding
                If Item(itemNum).BindType = 1 Then
                    AddDescInfo("Bind on Pickup", Color.White)
                ElseIf Item(itemNum).BindType = 2 Then
                    AddDescInfo("Bind on Equip", Color.White)
                End If

                AddDescInfo("Value: " & Item(itemNum).Price & " g", Color.Yellow)
            Case ItemType.Equipment
                ' Damage/defense
                If Item(itemNum).SubType = EquipmentType.Weapon Then
                    AddDescInfo("Damage: " & Item(itemNum).Data2, Color.White)
                    AddDescInfo("Speed: " & (Item(itemNum).Speed / 1000) & "s", Color.White)
                Else
                    If Item(itemNum).Data2 > 0 Then
                        AddDescInfo("Defense: " & Item(itemNum).Data2, Color.White)
                    End If
                End If

                ' binding
                If Item(itemNum).BindType = 1 Then
                    AddDescInfo("Bind on Pickup", Color.White)
                ElseIf Item(itemNum).BindType = 2 Then
                    AddDescInfo("Bind on Equip", Color.White)
                End If

                AddDescInfo("Value: " & Item(itemNum).Price & " G", Color.Yellow)

                ' stat bonuses
                If Item(itemNum).Add_Stat(StatType.Strength) > 0 Then
                    AddDescInfo("+" & Item(itemNum).Add_Stat(StatType.Strength) & " Str", Color.White)
                End If

                If Item(itemNum).Add_Stat(StatType.Luck) > 0 Then
                    AddDescInfo("+" & Item(itemNum).Add_Stat(StatType.Luck) & " End", Color.White)
                End If

                If Item(itemNum).Add_Stat(StatType.Spirit) > 0 Then
                    AddDescInfo("+" & Item(itemNum).Add_Stat(StatType.Spirit) & " Spi", Color.White)
                End If

                If Item(itemNum).Add_Stat(StatType.Luck) > 0 Then
                    AddDescInfo("+" & Item(itemNum).Add_Stat(StatType.Luck) & " Luc", Color.White)
                End If

                If Item(itemNum).Add_Stat(StatType.Intelligence) > 0 Then
                    AddDescInfo("+" & Item(itemNum).Add_Stat(StatType.Intelligence) & " Int", Color.White)
                End If
            Case ItemType.Consumable
                If Item(itemNum).Add_Stat(StatType.Strength) > 0 Then
                    AddDescInfo("+" & Item(itemNum).Add_Stat(StatType.Strength) & " Str", Color.White)
                End If

                If Item(itemNum).Add_Stat(StatType.Luck) > 0 Then
                    AddDescInfo("+" & Item(itemNum).Add_Stat(StatType.Luck) & " End", Color.White)
                End If

                If Item(itemNum).Add_Stat(StatType.Spirit) > 0 Then
                    AddDescInfo("+" & Item(itemNum).Add_Stat(StatType.Spirit) & " Spi", Color.White)
                End If

                If Item(itemNum).Add_Stat(StatType.Luck) > 0 Then
                    AddDescInfo("+" & Item(itemNum).Add_Stat(StatType.Luck) & " Luc", Color.White)
                End If

                If Item(itemNum).Add_Stat(StatType.Intelligence) > 0 Then
                    AddDescInfo("+" & Item(itemNum).Add_Stat(StatType.Intelligence) & " Int", Color.White)
                End If

                If Item(itemNum).Data1 > 0 Then
                    Select Case Item(itemNum).SubType
                        Case ItemSubType.AddHP
                            AddDescInfo("+" & Item(itemNum).Data1 & " HP", Color.White)
                        Case ItemSubType.AddMP
                            AddDescInfo("+" & Item(itemNum).Data1 & " MP", Color.White)
                        Case ItemSubType.AddSP
                            AddDescInfo("+" & Item(itemNum).Data1 & " SP", Color.White)
                        Case ItemSubType.Exp
                            AddDescInfo("+" & Item(itemNum).Data1 & " EXP", Color.White)
                    End Select
                    
                End If

                AddDescInfo("Value: " & Item(itemNum).Price & " G", Color.Yellow)
            Case ItemType.Skill
                AddDescInfo("Value: " & Item(itemNum).Price & " G", Color.Yellow)
        End Select
    End Sub

    Public Sub ShowSkillDesc(x As Long, y As Long, Skillnum As Long, SkillSlot As Long)
        Dim Color As Long, theName As String, sUse As String, i As Long, barWidth As Long, tmpWidth As Long

        ' set globals
        descType = 2 ' Skill
        descItem = Skillnum
    
        ' set position
        Windows(GetWindowIndex("winDescription")).Window.Left = x
        Windows(GetWindowIndex("winDescription")).Window.Top = y
    
        ' show the window
        ShowWindow(GetWindowIndex("winDescription"), , False)
    
        ' exit out early if last is same
        If (descLastType = descType) And (descLastItem = descItem) Then Exit Sub
    
        ' clear
        ReDim descText(1)
    
        ' hide req. labels
        Windows(GetWindowIndex("winDescription")).Controls(GetControlIndex("winDescription", "lblLevel")).visible = False
        Windows(GetWindowIndex("winDescription")).Controls(GetControlIndex("winDescription", "picBar")).visible = True
    
        ' set variables
        With Windows(GetWindowIndex("winDescription"))
            ' set name
            .Controls(GetControlIndex("winDescription", "lblName")).Text = Trim$(Skill(Skillnum).name)
            .Controls(GetControlIndex("winDescription", "lblName")).Color =  SFML.Graphics.Color.White
        
            ' find ranks
            If SkillSlot > 0 Then
                ' draw the rank bar
                barWidth = 66
                'If Skill(Skillnum).rank > 0 Then
                    'tmpWidth = ((PlayerSkills(SkillSlot).Uses / barWidth) / (Skill(Skillnum).NextUses / barWidth)) * barWidth
                'Else
                    tmpWidth = 66
                'End If
                .Controls(GetControlIndex("winDescription", "picBar")).value = tmpWidth
                ' does it rank up?
                'If Skill(Skillnum).NextRank > 0 Then
                    Color = ColorType.White
                    'sUse = "Uses: " & PlayerSkills(SkillSlot).Uses & "/" & Skill(Skillnum).NextUses
                    'If PlayerSkills(SkillSlot).Uses = Skill(Skillnum).NextUses Then
                        'If Not GetPlayerLevel(MyIndex) >= Skill(Skill(Skillnum).NextRank).LevelReq Then
                            'Color = BrightRed
                            'sUse = "Lvl " & Skill(Skill(Skillnum).NextRank).LevelReq & " req."
                        'End If
                    'End If
                'Else
                    Color = ColorType.Gray
                    sUse = "Max Rank"
                'End If
                ' show controls
                .Controls(GetControlIndex("winDescription", "lblClass")).visible = True
                .Controls(GetControlIndex("winDescription", "picBar")).visible = True
                 'set vals
                .Controls(GetControlIndex("winDescription", "lblClass")).Text = sUse
                .Controls(GetControlIndex("winDescription", "lblClass")).Color = SFML.Graphics.Color.White
            Else
                ' hide some controls
                .Controls(GetControlIndex("winDescription", "lblClass")).visible = False
                .Controls(GetControlIndex("winDescription", "picBar")).visible = False
            End If
        End With
    
        Select Case Skill(Skillnum).Type
            Case SkillType.DamageHp
                AddDescInfo("Damage HP", SFML.Graphics.Color.White)
            Case SkillType.DamageMp
                AddDescInfo("Damage SP", SFML.Graphics.Color.White)
            Case SkillType.HealHp
                AddDescInfo("Heal HP", SFML.Graphics.Color.White)
            Case SkillType.HealMp
                AddDescInfo("Heal SP", SFML.Graphics.Color.White)
            Case SkillType.Warp
                AddDescInfo("Warp", SFML.Graphics.Color.White)
        End Select
    
        ' more info
        Select Case Skill(Skillnum).Type
            Case SkillType.DamageHp, SkillType.DamageMp, SkillType.HealHp, SkillType.HealMp
                ' damage
                AddDescInfo("Vital: " & Skill(Skillnum).Vital, SFML.Graphics.Color.White)
            
                ' mp cost
                AddDescInfo("Cost: " & Skill(Skillnum).MPCost & " SP", SFML.Graphics.Color.White)
            
                ' cast time
                AddDescInfo("Cast Time: " & Skill(Skillnum).CastTime & "s", SFML.Graphics.Color.White)
            
                ' cd time
                AddDescInfo("Cooldown: " & Skill(Skillnum).CDTime & "s", SFML.Graphics.Color.White)
            
                ' aoe
                If Skill(Skillnum).AoE > 0 Then
                    AddDescInfo("AoE: " & Skill(Skillnum).AoE, SFML.Graphics.Color.White)
                End If
            
                ' stun
                If Skill(Skillnum).StunDuration > 0 Then
                    AddDescInfo("Stun: " & Skill(Skillnum).StunDuration & "s", SFML.Graphics.Color.White)
                End If
            
                ' dot
                If Skill(Skillnum).Duration > 0 And Skill(Skillnum).Interval > 0 Then
                    AddDescInfo("DoT: " & (Skill(Skillnum).Duration / Skill(Skillnum).Interval) & " tick", SFML.Graphics.Color.White)
                End If
        End Select
    End Sub

    Public Sub ShowShopDesc(X As Long, Y As Long, ItemNum As Long)
        If ItemNum <= 0 Or ItemNum > MAX_ITEMS Then Exit Sub
        ' show
        ShowItemDesc(X, Y, ItemNum)
    End Sub

    Public Sub ShowEqDesc(x As Long, y As Long, eqNum As Long)
        Dim soulBound As Boolean

        ' rte9
        If eqNum <= 0 Or eqNum > EquipmentType.Count - 1 Then Exit Sub

        ' show
        If Player(MyIndex).Equipment(eqNum) Then
            If Item(Player(MyIndex).Equipment(eqNum)).BindType > 0 Then soulBound = True
            ShowItemDesc(x, y, Player(MyIndex).Equipment(eqNum))
        End If
    End Sub

    Public Sub AddDescInfo(text As String, color As Color)
        Dim count As Long
        count = UBound(descText)
        ReDim Preserve descText(count + 1)
        descText(count + 1).Text = text
        descText(count + 1).Color = color
    End Sub

    Public Sub LogoutGame()
        isLogging = True
        InGame = False
        InMenu = True

        DestroyNetwork()
        InitNetwork()
        ClearGameData()
    End Sub

    Sub SetOptionsScreen()
        ' clear the combolists
        Erase Windows(GetWindowIndex("winOptions")).Controls(GetControlIndex("winOptions", "cmbRes")).list
        ReDim Windows(GetWindowIndex("winOptions")).Controls(GetControlIndex("winOptions", "cmbRes")).list(0)

        ' Resolutions
        Combobox_AddItem(GetWindowIndex("winOptions"), GetControlIndex("winOptions", "cmbRes"), "1920x1080")
        Combobox_AddItem(GetWindowIndex("winOptions"), GetControlIndex("winOptions", "cmbRes"), "1680x1050")
        Combobox_AddItem(GetWindowIndex("winOptions"), GetControlIndex("winOptions", "cmbRes"), "1600x900")
        Combobox_AddItem(GetWindowIndex("winOptions"), GetControlIndex("winOptions", "cmbRes"), "1440x900")
        Combobox_AddItem(GetWindowIndex("winOptions"), GetControlIndex("winOptions", "cmbRes"), "1440x1050")
        Combobox_AddItem(GetWindowIndex("winOptions"), GetControlIndex("winOptions", "cmbRes"), "1366x768")
        Combobox_AddItem(GetWindowIndex("winOptions"), GetControlIndex("winOptions", "cmbRes"), "1360x1024")
        Combobox_AddItem(GetWindowIndex("winOptions"), GetControlIndex("winOptions", "cmbRes"), "1360x768")
        Combobox_AddItem(GetWindowIndex("winOptions"), GetControlIndex("winOptions", "cmbRes"), "1280x1024")
        Combobox_AddItem(GetWindowIndex("winOptions"), GetControlIndex("winOptions", "cmbRes"), "1280x800")
        Combobox_AddItem(GetWindowIndex("winOptions"), GetControlIndex("winOptions", "cmbRes"), "1280x768")
        Combobox_AddItem(GetWindowIndex("winOptions"), GetControlIndex("winOptions", "cmbRes"), "1280x720")
        Combobox_AddItem(GetWindowIndex("winOptions"), GetControlIndex("winOptions", "cmbRes"), "1120x864")    

        ' fill the options screen
        With Windows(GetWindowIndex("winOptions"))
            .Controls(GetControlIndex("winOptions", "chkMusic")).Value = Types.Settings.Music
            .Controls(GetControlIndex("winOptions", "chkSound")).Value = Types.Settings.Sound
            .Controls(GetControlIndex("winOptions", "chkAutotile")).Value = Types.Settings.Autotile
            .Controls(GetControlIndex("winOptions", "chkFullscreen")).Value = Types.Settings.Fullscreen
            .Controls(GetControlIndex("winOptions", "cmbRes")).Value = Types.Settings.Resolution
        End With
    End Sub

    Public Sub OpenShop(shopNum As Long)
        ' set globals
        InShop = shopNum
        shopSelectedSlot = 1
        shopSelectedItem = Shop(InShop).TradeItem(1).Item
        Windows(GetWindowIndex("winShop")).Controls(GetControlIndex("winShop", "chkSelling")).Value = 0
        Windows(GetWindowIndex("winShop")).Controls(GetControlIndex("winShop", "chkBuying")).Value = 1
        Windows(GetWindowIndex("winShop")).Controls(GetControlIndex("winShop", "btnSell")).visible = False
        Windows(GetWindowIndex("winShop")).Controls(GetControlIndex("winShop", "btnBuy")).visible = True
        shopIsSelling = False
    
        ' set the current item
        UpdateShop
    
        ' show the window
        ShowWindow(GetWindowIndex("winShop"))
    End Sub

    Public Sub CloseShop()
        SendCloseShop
        HideWindow(GetWindowIndex("winShop"))
        shopSelectedSlot = 0
        shopSelectedItem = 0
        shopIsSelling = False
        InShop = 0
    End Sub

    Sub UpdateShop()
        Dim i As Long, CostValue As Long

        If InShop = 0 Then Exit Sub
    
        ' make sure we have an item selected
        If shopSelectedSlot = 0 Then shopSelectedSlot = 1
    
        With Windows(GetWindowIndex("winShop"))
            ' buying items
            If Not shopIsSelling Then
                shopSelectedItem = Shop(InShop).TradeItem(shopSelectedSlot).Item
                ' labels
                If shopSelectedItem > 0 Then
                    .Controls(GetControlIndex("winShop", "lblName")).text = Trim$(Item(shopSelectedItem).Name)
                    ' check if it's gold
                    If Shop(InShop).TradeItem(shopSelectedSlot).CostItem = 1 Then
                        ' it's gold
                        .Controls(GetControlIndex("winShop", "lblCost")).text = Shop(InShop).TradeItem(shopSelectedSlot).CostValue & "g"
                    Else
                        ' if it's one then just print the name
                        If Shop(InShop).TradeItem(shopSelectedSlot).CostValue = 1 Then
                            .Controls(GetControlIndex("winShop", "lblCost")).text = Trim$(Item(Shop(InShop).TradeItem(shopSelectedSlot).CostItem).Name)
                        Else
                            .Controls(GetControlIndex("winShop", "lblCost")).text = Shop(InShop).TradeItem(shopSelectedSlot).CostValue & " " & Trim$(Item(Shop(InShop).TradeItem(shopSelectedSlot).CostItem).Name)
                        End If
                    End If

                    ' draw the item
                    For i = 0 To 5
                        .Controls(GetControlIndex("winShop", "picItem")).image(i) = Item(shopSelectedItem).Icon
                        .Controls(GetControlIndex("winShop", "picItem")).GfxType(i) = GfxType.Item
                    Next
                Else
                    .Controls(GetControlIndex("winShop", "lblName")).text = "Empty Slot"
                    .Controls(GetControlIndex("winShop", "lblCost")).text = ""
                    
                    ' draw the item
                    For i = 0 To 5
                        .Controls(GetControlIndex("winShop", "picItem")).image(i) = 0
                        .Controls(GetControlIndex("winShop", "picItem")).GfxType(i) = GfxType.None
                    Next
                End If
            Else
                shopSelectedItem = GetPlayerInv(MyIndex, shopSelectedSlot)
                ' labels
                If shopSelectedItem > 0 Then
                    .Controls(GetControlIndex("winShop", "lblName")).text = Trim$(Item(shopSelectedItem).Name)
                    ' calc cost
                    CostValue = (Item(shopSelectedItem).Price / 100) * Shop(InShop).BuyRate
                    .Controls(GetControlIndex("winShop", "lblCost")).text = CostValue & "g"
                    
                    ' draw the item
                    For i = 0 To 5
                        .Controls(GetControlIndex("winShop", "picItem")).image(i) = Item(shopSelectedItem).Icon
                        .Controls(GetControlIndex("winShop", "picItem")).GfxType(i) = GfxType.Item
                    Next
                Else
                    .Controls(GetControlIndex("winShop", "lblName")).text = "Empty Slot"
                    .Controls(GetControlIndex("winShop", "lblCost")).text = ""
                    
                    ' draw the item
                    For i = 0 To 5
                        .Controls(GetControlIndex("winShop", "picItem")).image(i) = 0
                        .Controls(GetControlIndex("winShop", "picItem")).GfxType(i) = GfxType.None
                    Next
                End If
            End If
        End With
    End Sub

    Sub UpdatePartyInterface()
        Dim i As Long, image(0 To 5) As Long, x As Long, pIndex As Long, Height As Long, cIn As Long

        ' unload it if we're not in a party
        If Party.Leader = 0 Then
            HideWindow(GetWindowIndex("winParty"))
            Exit Sub
        End If
    
        ' load the window
        ShowWindow(GetWindowIndex("winParty"))
        ' fill the controls
        With Windows(GetWindowIndex("winParty"))
            ' clear controls first
            For i = 1 To 3
                .Controls(GetControlIndex("winParty", "lblName" & i)).text = ""
                .Controls(GetControlIndex("winParty", "picEmptyBar_HP" & i)).visible = False
                .Controls(GetControlIndex("winParty", "picEmptyBar_SP" & i)).visible = False
                .Controls(GetControlIndex("winParty", "picBar_HP" & i)).visible = False
                .Controls(GetControlIndex("winParty", "picBar_SP" & i)).visible = False
                .Controls(GetControlIndex("winParty", "picShadow" & i)).visible = False
                .Controls(GetControlIndex("winParty", "picChar" & i)).visible = False
                .Controls(GetControlIndex("winParty", "picChar" & i)).value = 0
            Next

            ' labels
            cIn = 1
            For i = 1 To Party.MemberCount
                ' cache the index
                pIndex = Party.Member(i)
                If pIndex > 0 Then
                    If pIndex <> MyIndex Then
                        If IsPlaying(pIndex) Then
                            ' name and level
                            .Controls(GetControlIndex("winParty", "lblName" & cIn)).visible = True
                            .Controls(GetControlIndex("winParty", "lblName" & cIn)).text = Trim$(GetPlayerName(pIndex))
                            ' picture
                            .Controls(GetControlIndex("winParty", "picShadow" & cIn)).visible = True
                            .Controls(GetControlIndex("winParty", "picChar" & cIn)).visible = True
                            ' store the player's index as a value for later use
                            .Controls(GetControlIndex("winParty", "picChar" & cIn)).value = pIndex
                            For x = 0 To 5
                                .Controls(GetControlIndex("winParty", "picChar" & cIn)).image(x) = GetPlayerSprite(pIndex)
                                .Controls(GetControlIndex("winParty", "picChar" & cIn)).GfxType(x) = GfxType.Character
                            Next
                            ' bars
                            .Controls(GetControlIndex("winParty", "picEmptyBar_HP" & cIn)).visible = True
                            .Controls(GetControlIndex("winParty", "picEmptyBar_SP" & cIn)).visible = True
                            .Controls(GetControlIndex("winParty", "picBar_HP" & cIn)).visible = True
                            .Controls(GetControlIndex("winParty", "picBar_SP" & cIn)).visible = True
                            ' increment control usage
                            cIn = cIn + 1
                        End If
                    End If
                End If
            Next
            ' update the bars
            UpdatePartyBars
            ' set the window size
            Select Case Party.MemberCount
                Case 2: Height = 78
                Case 3: Height = 118
                Case 4: Height = 158
            End Select
            .Window.Height = Height
        End With
    End Sub

    Sub UpdatePartyBars()
        Dim i As Long, pIndex As Long, barWidth As Long, Width As Long

        ' unload it if we're not in a party
        If Party.Leader = 0 Then
            Exit Sub
        End If
    
        ' max bar width
        barWidth = 173
    
        ' make sure we're in a party
        With Windows(GetWindowIndex("winParty"))
            For i = 1 To 3
                ' get the pIndex from the control
                If .Controls(GetControlIndex("winParty", "picChar" & i)).visible = True Then
                    pIndex = .Controls(GetControlIndex("winParty", "picChar" & i)).value
                    ' make sure they exist
                    If pIndex > 0 Then
                        If IsPlaying(pIndex) Then
                            ' get their health
                            If GetPlayerVital(pIndex, VitalType.HP) > 0 And GetPlayerMaxVital(pIndex, VitalType.HP) > 0 Then
                                Width = ((GetPlayerVital(pIndex, VitalType.HP) / barWidth) / (GetPlayerMaxVital(pIndex, VitalType.HP) / barWidth)) * barWidth
                                .Controls(GetControlIndex("winParty", "picBar_HP" & i)).Width = Width
                            Else
                                .Controls(GetControlIndex("winParty", "picBar_HP" & i)).Width = 0
                            End If
                            ' get their spirit
                            If GetPlayerVital(pIndex, VitalType.SP) > 0 And GetPlayerMaxVital(pIndex, VitalType.SP) > 0 Then
                                Width = ((GetPlayerVital(pIndex, VitalType.SP) / barWidth) / (GetPlayerMaxVital(pIndex, VitalType.SP) / barWidth)) * barWidth
                                .Controls(GetControlIndex("winParty", "picBar_SP" & i)).Width = Width
                            Else
                                .Controls(GetControlIndex("winParty", "picBar_SP" & i)).Width = 0
                            End If
                        End If
                    End If
                End If
            Next
        End With
    End Sub

    Sub ShowTrade()
        ' show the window
        ShowWindow(GetWindowIndex("winTrade"))

        ' set the controls up
        With Windows(GetWindowIndex("winTrade"))
            .Window.text = "Trading with " & Trim$(GetPlayerName(InTrade))
            .Controls(GetControlIndex("winTrade", "lblYourTrade")).text = Trim$(GetPlayerName(MyIndex)) & "'s Offer"
            .Controls(GetControlIndex("winTrade", "lblTheirTrade")).text = Trim$(GetPlayerName(InTrade)) & "'s Offer"
            .Controls(GetControlIndex("winTrade", "lblYourValue")).text = "0g"
            .Controls(GetControlIndex("winTrade", "lblTheirValue")).text = "0g"
            .Controls(GetControlIndex("winTrade", "lblStatus")).text = "Choose items to offer."
        End With
    End Sub

    Sub ShowPlayerMenu(Index As Long, X As Long, Y As Long)
        PlayerMenuIndex = Index
        If PlayerMenuIndex = 0 Or PlayerMenuIndex = MyIndex Then Exit Sub
        Windows(GetWindowIndex("winPlayerMenu")).Window.Left = X - 5
        Windows(GetWindowIndex("winPlayerMenu")).Window.Top = Y - 5
        Windows(GetWindowIndex("winPlayerMenu")).Controls(GetControlIndex("winPlayerMenu", "btnName")).text = Trim$(GetPlayerName(PlayerMenuIndex))
        ShowWindow(GetWindowIndex("winRightClickBG"))
        ShowWindow(GetWindowIndex("winPlayerMenu"))
    End Sub

    Public Sub SetBarWidth(ByRef MaxWidth As Long, ByRef Width As Long)
        Dim barDifference As Long

        If MaxWidth < Width Then
            ' find out the amount to increase per loop
            barDifference = ((Width - MaxWidth) / 100) * 10

            ' if it's less than 1 then default to 1
            If barDifference < 1 Then barDifference = 1
            ' set the width
            Width = Width - barDifference
        ElseIf MaxWidth > Width Then
            ' find out the amount to increase per loop
            barDifference = ((MaxWidth - Width) / 100) * 10

            ' if it's less than 1 then default to 1
            If barDifference < 1 Then barDifference = 1
            ' set the width
            Width = Width + barDifference
        End If
    End Sub

    Public Sub SetGoldLabel()
        Dim i As Long, Amount As Long

        For i = 1 To MAX_INV
            If GetPlayerInv(MyIndex, i) = 1 Then
                Amount = GetPlayerInvValue(MyIndex, i)
            End If
        Next
        Windows(GetWindowIndex("winShop")).Controls(GetControlIndex("winShop", "lblGold")).text = Format$(Amount, "#,###,###,###") & "g"
        Windows(GetWindowIndex("winInventory")).Controls(GetControlIndex("winInventory", "lblGold")).text = Format$(Amount, "#,###,###,###") & "g"
    End Sub
End Module