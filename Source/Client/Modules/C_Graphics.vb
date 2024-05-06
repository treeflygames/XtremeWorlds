Imports System.IO
Imports System.Runtime.InteropServices
Imports SFML.Graphics
Imports SFML.System
Imports Core
Imports SFML.Window
Imports Microsoft.Win32
Imports System.Net.Mime

Module C_Graphics

#Region "Declarations"

    Friend Window As RenderWindow
    Friend TilesetWindow As RenderWindow
    Friend WindowSettings As ContextSettings
    Friend RefreshWindow As Boolean

    Friend EditorAnimation_Anim1 As RenderWindow
    Friend EditorAnimation_Anim2 As RenderWindow

    Friend Fonts([Enum].FontType.Count - 1) As Font

    Friend TilesetTexture() As Texture
    Friend TilesetSprite() As Sprite
    Friend TilesetGfxInfo() As GraphicInfo

    Friend CharacterTexture() As Texture
    Friend CharacterSprite() As Sprite
    Friend CharacterGfxInfo() As GraphicInfo

    Friend PaperdollTexture() As Texture
    Friend PaperdollSprite() As Sprite
    Friend PaperdollGfxInfo() As GraphicInfo

    Friend ItemTexture() As Texture
    Friend ItemSprite() As Sprite
    Friend ItemGfxInfo() As GraphicInfo

    Friend ResourceTexture() As Texture
    Friend ResourceSprite() As Sprite
    Friend ResourceGfxInfo() As GraphicInfo

    Friend AnimationTexture() As Texture
    Friend AnimationSprite() As Sprite
    Friend AnimationGfxInfo() As GraphicInfo

    Friend SkillTexture() As Texture
    Friend SkillSprite() As Sprite
    Friend SkillGfxInfo() As GraphicInfo

    Friend ProjectileTexture() As Texture
    Friend ProjectileSprite() As Sprite
    Friend ProjectileGfxInfo() As GraphicInfo

    Friend FogTexture() As Texture
    Friend FogSprite() As Sprite
    Friend FogGfxInfo() As GraphicInfo

    Friend EmoteTexture() As Texture
    Friend EmoteSprite() As Sprite
    Friend EmoteGfxInfo() As GraphicInfo

    Friend PanoramaTexture() As Texture
    Friend PanoramaSprite() As Sprite
    Friend PanoramaGfxInfo() As GraphicInfo

    Friend ParallaxTexture() As Texture
    Friend ParallaxSprite() As Sprite
    Friend ParallaxGfxInfo() As GraphicInfo

    Friend PictureTexture() As Texture
    Friend PictureSprite() As Sprite
    Friend PictureGfxInfo() As GraphicInfo

    Friend BloodTexture As Texture
    Friend BloodSprite As Sprite
    Friend BloodGfxInfo As GraphicInfo

    Friend DirectionTexture As Texture
    Friend DirectionSprite As Sprite
    Friend DirectionGfxInfo As GraphicInfo

    Friend WeatherTexture As Texture
    Friend WeatherSprite As Sprite
    Friend WeatherGfxInfo As GraphicInfo

    Friend InterfaceTexture() As Texture
    Friend InterfaceSprite() As Sprite
    Friend InterfaceGfxInfo() As GraphicInfo
    Friend DesignTexture() As Texture
    Friend DesignSprite() As Sprite
    Friend DesignGfxInfo() As GraphicInfo
    Friend GradientTexture() As Texture
    Friend GradientSprite() As Sprite
    Friend GradientGfxInfo() As GraphicInfo

    Friend EventChatGfx As Texture
    Friend EventChatSprite As Sprite
    Friend EventChatGfxInfo As GraphicInfo

    Friend TargetGfx As Texture
    Friend TargetSprite As Sprite
    Friend TargetGfxInfo As GraphicInfo

    Friend ChatBubbleGfx As Texture
    Friend ChatBubbleSprite As Sprite
    Friend ChatBubbleGfxInfo As GraphicInfo

    Friend MapTintGfx As Texture
    Friend MapTintSprite As Sprite
    Friend MapFadeSprite As Sprite

    Friend NightGfx As Texture
    Friend NightSprite As Sprite
    Friend LightGfx As Texture
    Friend LightDynamicGfx As Texture
    Friend LightSprite As Sprite
    Friend LightDynamicSprite As Sprite
    Friend LightGfxInfo As GraphicInfo
    Friend CursorGfx As Texture
    Friend CursorSprite As Sprite
    Friend CursorGfxInfo As GraphicInfo

    Friend ShadowGfx As Texture
    Friend ShadowSprite As Sprite
    Friend ShadowGfxInfo As GraphicInfo

    Friend BarGfx As Texture
    Friend BarSprite As Sprite
    Friend BarGfxInfo As GraphicInfo

    ' Number of graphic files
    Friend NumTileSets As Integer
    Friend NumCharacters As Integer
    Friend NumPaperdolls As Integer
    Friend NumItems As Integer
    Friend NumResources As Integer
    Friend NumAnimations As Integer
    Friend NumSkills As Integer
    Friend NumFogs As Integer
    Friend NumEmotes As Integer
    Friend NumPanorama As Integer
    Friend NumParallax As Integer
    Friend NumPictures As Integer
    Friend NumInterface As Integer
    Friend NumGradients As Integer
    Friend NumDesigns As Integer

#End Region

#Region "Types"

    Public Structure GraphicInfo
        Dim Width As Integer
        Dim Height As Integer
        Dim IsLoaded As Boolean
        Dim TextureTimer As Integer
    End Structure

#End Region

#Region "initialization"
    Private Sub Window_GainedFocus(ByVal sender As Object, ByVal e As EventArgs)
        Console.WriteLine("Window Gained Focus")
    End Sub

    Private Sub Window_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        Console.WriteLine("Window Lost Focus")
    End Sub

    Private Sub Window_KeyPressed(ByVal sender As Object, ByVal e As SFML.Window.KeyEventArgs)
        Console.WriteLine("Key Pressed: " & e.Code.ToString())

        If InGame Then
            If Inputs.MoveUp(e.Code) Then VbKeyUp = True
            If Inputs.MoveDown(e.Code) Then VbKeyDown = True
            If Inputs.MoveLeft(e.Code) Then VbKeyLeft = True
            If Inputs.MoveRight(e.Code) Then VbKeyRight = True
            If Inputs.Attack(e.Code) Then VbKeyControl = True
            If Inputs.Run(e.Code) Then VbKeyShift = True

            Select Case e.Code
                Case Keyboard.Key.Escape
                    if InMenu Then Exit Sub

                    ' Hide options screen
                    If Windows(GetWindowIndex("winOptions")).Window.visible Then
                        HideWindow(GetWindowIndex("winOptions"))
                        CloseComboMenu()
                        Exit Sub
                    End If

                    ' hide/show chat window
                    If Windows(GetWindowIndex("winChat")).Window.Visible Then
                        Windows(GetWindowIndex("winChat")).Controls(GetControlIndex("winChat", "txtChat")).Text = ""
                        HideChat()
                        Exit Sub
                    End If

                    If Windows(GetWindowIndex("winEscMenu")).Window.visible Then
                        HideWindow(GetWindowIndex("winEscMenu"))
                        Exit Sub
                    Else
                        ' show them
                        If Windows(GetWindowIndex("winChat")).Window.Visible = False Then
                            ShowWindow(GetWindowIndex("winEscMenu"), True)
                            Exit Sub
                        End If
                    End If

                Case Keyboard.Key.Enter
                    If Windows(GetWindowIndex("winChatSmall")).Window.Visible Then
                        ShowChat()
                        inSmallChat = False
                        Exit Sub
                    End If

                    HandlePressEnter()
            
                Case Keyboard.Key.Space
                    CheckMapGetItem()
        
                Case Keyboard.Key.I
                    ' hide/show inventory
                    If Not Windows(GetWindowIndex("winChat")).Window.visible Then btnMenu_Inv
            
                Case Keyboard.Key.C
                    ' hide/show char
                    If Not Windows(GetWindowIndex("winChat")).Window.visible Then btnMenu_Char
           
                Case Keyboard.Key.K
                    ' hide/show skills
                    If Not Windows(GetWindowIndex("winChat")).Window.visible Then btnMenu_Skills
            End Select
    
            ' handles hotbar
            If inSmallChat Then
                For i = 1 To MAX_HOTBAR - 1
                    If e.Code = 26 + i Then
                        SendUseHotbarSlot(i)
                    End If
                    If e.Code = 26 Then SendUseHotbarSlot(MAX_HOTBAR)
                Next
            End If

            If Windows(GetWindowIndex("winEscMenu")).Window.visible Then Exit Sub
        End If

        ' Check for active window
        If activeWindow > 0 Then
            ' Ensure it's visible
            If Windows(activeWindow).Window.Visible Then
                ' Check for active control
                If Windows(activeWindow).ActiveControl > 0 Then
                    ' Handle input
                    Select Case e.Code
                        Case Keyboard.Key.Escape

                        Case Keyboard.Key.Backspace
                            If Windows(activeWindow).Controls(Windows(activeWindow).ActiveControl).Text.Length > 0 Then
                                Windows(activeWindow).Controls(Windows(activeWindow).ActiveControl).Text = Windows(activeWindow).Controls(Windows(activeWindow).ActiveControl).Text.Substring(0, Windows(activeWindow).Controls(Windows(activeWindow).ActiveControl).Text.Length - 1)
                            End If

                        Case Keyboard.Key.Enter
                            ' Override for function callbacks
                            If Not Windows(activeWindow).Controls(Windows(activeWindow).ActiveControl).CallBack(EntState.Enter) IsNot Nothing Then
                                Windows(activeWindow).Controls(Windows(activeWindow).ActiveControl).CallBack(EntState.Enter) = Nothing
                            Else
                                Dim n As Integer = 0
                                For i As Integer = Windows(activeWindow).ControlCount To 1 Step -1
                                    If i > Windows(activeWindow).ActiveControl Then
                                        If SetActiveControl(activeWindow, i) Then n = i
                                    End If
                                Next

                                If n = 0 Then
                                    For i As Integer = Windows(activeWindow).ControlCount To 1 Step -1
                                        SetActiveControl(activeWindow, i)
                                    Next
                                End If
                            End If

                        Case Keyboard.Key.Tab
                            Dim n As Integer = 0
                            For i As Integer = Windows(activeWindow).ControlCount To 1 Step -1
                                If i > Windows(activeWindow).ActiveControl Then
                                    If SetActiveControl(activeWindow, i) Then n = i
                                End If
                            Next

                            If n = 0 Then
                                For i As Integer = Windows(activeWindow).ControlCount To 1 Step -1
                                    SetActiveControl(activeWindow, i)
                                Next
                            End If

                        Case Else

                    End Select
                End If
            End If
        End If

        'HandleInterfaceEvents(EntState.KeyDown)
    End Sub

    Private Sub Window_KeyReleased(ByVal sender As Object, ByVal e As SFML.Window.KeyEventArgs)
        Dim skillnum As Integer

        Console.WriteLine("Key Released: " & e.Code.ToString())

        If Inputs.MoveUp(e.Code) Then VbKeyUp = False
        If Inputs.MoveDown(e.Code) Then VbKeyDown = False
        If Inputs.MoveLeft(e.Code) Then VbKeyLeft = False
        If Inputs.MoveRight(e.Code) Then VbKeyRight = False
        If Inputs.Attack(e.Code) Then VbKeyControl = False
        If Inputs.Run(e.Code) Then VbKeyShift = False

        'admin
        If e.Code = Keyboard.Key.Insert Then
            If GetPlayerAccess(MyIndex) > 0 Then
                SendRequestAdmin()
            End If
        End If

        'HandleInterfaceEvents(EntState.KeyUp)
    End Sub

    Private Sub Window_MouseButtonPressed(ByVal sender As Object, ByVal e As SFML.Window.MouseButtonEventArgs)
        Console.WriteLine("Mouse Button Pressed: " & e.Button.ToString())

        If e.Button = Mouse.Button.Left Then
            Dim currentTime As Integer = Environment.TickCount

            If currentTime - LastLeftClickTime <= DoubleClickTImer Then
                HandleInterfaceEvents(EntState.DblClick)
                LastLeftClickTime = 0 ' Reset the last click time to avoid triple-clicks registering as another double-click
            Else
                ' Update the last click time
                LastLeftClickTime = currentTime
            End If

            ' if we're in the middle of choose the trade target or not
            If PetAlive(MyIndex) Then
                If IsInBounds() Then
                    PetMove(CurX, CurY)
                End If
            End If

            ' targetting
            PlayerSearch(CurX, CurY, 0)

        ElseIf e.Button = Mouse.Button.Right Then
            If VbKeyShift = True Then
                ' admin warp if we're pressing shift and right clicking
                If GetPlayerAccess(MyIndex) >= AccessType.Moderator Then AdminWarp(CurX, CurY)
            Else
                ' right-click menu
                For i = 1 To MAX_PLAYERS
                    If IsPlaying(i) Then
                        If GetPlayerMap(i) = GetPlayerMap(MyIndex) Then
                            If GetPlayerX(i) = CurX And GetPlayerY(i) = CurY Then
                                ShowPlayerMenu(i, CurMouseX, CurMouseY)
                            End If
                        End If
                    End If
                Next
                PlayerSearch(CurX, CurY, 1)
            End If
        End If

        If Editor = EditorType.Map Then
            frmEditor_Map.MapEditorMouseDown(e.Button, e.X, e.Y, False)
        End If

        HandleInterfaceEvents(EntState.MouseDown)
    End Sub

    Private Sub Window_MouseButtonReleased(ByVal sender As Object, ByVal e As SFML.Window.MouseButtonEventArgs)
        Console.WriteLine("Mouse Button Released: " & e.Button.ToString())

        HandleInterfaceEvents(EntState.MouseUp)
    End Sub

    Private Sub Window_MouseWheelScrolled(ByVal sender As Object, ByVal e As SFML.Window.MouseWheelScrollEventArgs)
        Console.WriteLine("Mouse Wheel Scrolled: " & e.Delta.ToString())

        If Editor = EditorType.Map Then
            If e.Delta > 0 Then
                If Control.ModifierKeys = Keys.Shift Then
                    If frmEditor_Map.cmbLayers.SelectedIndex + 1 < LayerType.Count - 1 Then
                        frmEditor_Map.cmbLayers.SelectedIndex = frmEditor_Map.cmbLayers.SelectedIndex + 1
                    End If

                Else
                    If frmEditor_Map.cmbTileSets.SelectedIndex > 0 Then
                        frmEditor_Map.cmbTileSets.SelectedIndex = frmEditor_Map.cmbTileSets.SelectedIndex - 1
                    End If
                End If

            Else
                If Control.ModifierKeys = Keys.Shift Then
                    If frmEditor_Map.cmbLayers.SelectedIndex > 0 Then
                        frmEditor_Map.cmbLayers.SelectedIndex = frmEditor_Map.cmbLayers.SelectedIndex - 1
                    End If
                Else
                    If frmEditor_Map.cmbTileSets.SelectedIndex + 1 < NumTileSets Then
                        frmEditor_Map.cmbTileSets.SelectedIndex = frmEditor_Map.cmbTileSets.SelectedIndex + 1
                    End If
                End If
            End If
        End If

        If e.Delta > 0 Then
            ScrollChatBox(0)
        Else
            ScrollChatBox(1)
        End If

        HandleInterfaceEvents(EntState.MouseScroll)
    End Sub

    Private Sub Window_MouseMoved(ByVal sender As Object, ByVal e As SFML.Window.MouseMoveEventArgs)
        ' Convert adjusted coordinates to game world coordinates
        CurX = TileView.Left + Math.Floor((e.X + Camera.Left) / PicX)
        CurY = TileView.Top + Math.Floor((e.Y + Camera.Top) / PicY)

        ' Store raw mouse coordinates for interface interactions
        CurMouseX = e.X
        CurMouseY = e.Y

        ' Editor interactions
        If Editor = EditorType.Map Then
            If Mouse.IsButtonPressed(Mouse.Button.Left) Then
                frmEditor_Map.MapEditorMouseDown(Mouse.Button.Left, CurMouseX, CurMouseY, True)
            End If

            If Mouse.IsButtonPressed(Mouse.Button.Right) Then
                frmEditor_Map.MapEditorMouseDown(Mouse.Button.Right, CurMouseX, CurMouseY, True)
            End If
        End If

        HandleInterfaceEvents(EntState.MouseMove)
    End Sub

    Private Sub Window_TextEntered(sender As Object, e As TextEventArgs)
        ' e.Unicode is a string, so no conversion is needed
        Dim unicodeChar As String = e.Unicode

        ' Get the first character of the string as a Char
        Dim character As Char = unicodeChar(0)

        ' Ignore Backspace (ChrW(8)), Enter (ChrW(13)), Tab (ChrW(9)), and Escape (ChrW(27)) keys
        If character = ChrW(8) Or character = ChrW(13) Or character = ChrW(9) Or character = ChrW(27) Then
            Return
        End If

        ' Ensure it's visible
        If Windows(activeWindow).Window.Visible And Windows(activeWindow).ActiveControl > 0 Then
            If Windows(activeWindow).Controls(Windows(activeWindow).ActiveControl).Locked Then
                Exit Sub
            End If

            ' Append character to text of the active control
            Windows(activeWindow).Controls(Windows(activeWindow).ActiveControl).Text &= character
        End If

    End Sub

    Private Sub Window_Closed(ByVal sender As Object, ByVal e As EventArgs)
        Console.WriteLine("Window Closed")
        DestroyGame()
        Window.Close()
    End Sub

    Private Sub Window_Resized(sender As Object, e As SizeEventArgs)
        ResolutionWidth = e.Width - (e.Width Mod PicX)
        ResolutionHeight = e.Height - (e.Height Mod PicY)
        Types.Settings.CameraWidth = ResolutionWidth / PicX
        Types.Settings.CameraHeight = ResolutionHeight / PicY
        Settings.Save()

        RefreshWindow = True
    End Sub

    Public Sub CenterWindow(ByVal window As RenderWindow)
        ' Get the working area of the primary screen (excluding taskbar)
        Dim workingArea As Rectangle = Screen.PrimaryScreen.WorkingArea

        ' Calculate the position to center the window within the working area
        Dim windowPosX As Integer = workingArea.Left + (workingArea.Width - window.Size.X) \ 2
        Dim windowPosY As Integer = (workingArea.Top + (workingArea.Height - window.Size.Y) \ 2) - GetTitleBarHeight / 2

        ' Set the window's position
        window.Position = New Vector2i(windowPosX, windowPosY)
    End Sub

    Public Function GetTitleBarHeight() As Integer
        Return SystemInformation.CaptionHeight
    End Function

    Sub InitGraphics()
        GetResolutionSize(Types.Settings.Resolution, ResolutionWidth, ResolutionHeight)

        Fonts(0) = New Font(Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\" + Georgia)
        Fonts(1) = New Font(Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\" + Arial)
        Fonts(2) = New Font(Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\" + Verdana)

        RefreshWindow = True
        UpdateWindow()
        
        ReDim TilesetTexture(NumTileSets)
        ReDim TilesetSprite(NumTileSets)
        ReDim TilesetGfxInfo(NumTileSets)

        ReDim CharacterTexture(NumCharacters)
        ReDim CharacterSprite(NumCharacters)
        ReDim CharacterGfxInfo(NumCharacters)

        ReDim PaperdollTexture(NumPaperdolls)
        ReDim PaperdollSprite(NumPaperdolls)
        ReDim PaperdollGfxInfo(NumPaperdolls)

        ReDim ItemTexture(NumItems)
        ReDim ItemSprite(NumItems)
        ReDim ItemGfxInfo(NumItems)

        ReDim ResourceTexture(NumResources)
        ReDim ResourceSprite(NumResources)
        ReDim ResourceGfxInfo(NumResources)

        ReDim AnimationTexture(NumAnimations)
        ReDim AnimationSprite(NumAnimations)
        ReDim AnimationGfxInfo(NumAnimations)

        ReDim SkillTexture(NumSkills)
        ReDim SkillSprite(NumSkills)
        ReDim SkillGfxInfo(NumSkills)

        ReDim ProjectileTexture(NumProjectiles)
        ReDim ProjectileSprite(NumProjectiles)
        ReDim ProjectileGfxInfo(NumProjectiles)

        ReDim FogTexture(NumFogs)
        ReDim FogSprite(NumFogs)
        ReDim FogGfxInfo(NumFogs)

        ReDim EmoteTexture(NumEmotes)
        ReDim EmoteSprite(NumEmotes)
        ReDim EmoteGfxInfo(NumEmotes)

        ReDim PanoramaTexture(NumPanorama)
        ReDim PanoramaSprite(NumPanorama)
        ReDim PanoramaGfxInfo(NumPanorama)

        ReDim ParallaxTexture(NumParallax)
        ReDim ParallaxSprite(NumParallax)
        ReDim ParallaxGfxInfo(NumParallax)

        ReDim PictureTexture(NumPictures)
        ReDim PictureSprite(NumPictures)
        ReDim PictureGfxInfo(NumPictures)

        ReDim InterfaceTexture(NumInterface)
        ReDim InterfaceSprite(NumInterface)
        ReDim InterfaceGfxInfo(NumInterface)

        ReDim DesignTexture(NumDesigns)
        ReDim DesignSprite(NumDesigns)
        ReDim DesignGfxInfo(NumDesigns)

        ReDim GradientTexture(NumGradients)
        ReDim GradientSprite(NumGradients)
        ReDim GradientGfxInfo(NumGradients)

        BloodGfxInfo = New GraphicInfo
        If File.Exists(Paths.Graphics & "Misc\Blood" & GfxExt) Then
            BloodTexture = New Texture(Paths.Graphics & "Misc\Blood" & GfxExt)
            BloodSprite = New Sprite(BloodTexture)
            BloodGfxInfo.Width = BloodTexture.Size.X
            BloodGfxInfo.Height = BloodTexture.Size.Y
        End If

        DirectionGfxInfo = New GraphicInfo
        If File.Exists(Paths.Graphics & "Misc\Direction" & GfxExt) Then
            DirectionTexture = New Texture(Paths.Graphics & "Misc\Direction" & GfxExt)
            DirectionSprite = New Sprite(DirectionTexture)
            DirectionGfxInfo.Width = DirectionTexture.Size.X
            DirectionGfxInfo.Height = DirectionTexture.Size.Y
        End If

        WeatherGfxInfo = New GraphicInfo
        If File.Exists(Paths.Graphics & "Misc\Weather" & GfxExt) Then
            WeatherTexture = New Texture(Paths.Graphics & "Misc\Weather" & GfxExt)
            WeatherSprite = New Sprite(WeatherTexture)
            WeatherGfxInfo.Width = WeatherTexture.Size.X
            WeatherGfxInfo.Height = WeatherTexture.Size.Y
        End If

        EventChatGfxInfo = New GraphicInfo
        If File.Exists(Paths.Gui & "Main\EventChat" & GfxExt) Then
            EventChatGfx = New Texture(Paths.Gui & "Main\EventChat" & GfxExt)
            EventChatSprite = New Sprite(EventChatGfx)
            EventChatGfxInfo.Width = EventChatGfx.Size.X
            EventChatGfxInfo.Height = EventChatGfx.Size.Y
        End If

        TargetGfxInfo = New GraphicInfo
        If File.Exists(Paths.Graphics & "Misc\Target" & GfxExt) Then
            TargetGfx = New Texture(Paths.Graphics & "Misc\Target" & GfxExt)
            TargetSprite = New Sprite(TargetGfx)
            TargetGfxInfo.Width = TargetGfx.Size.X
            TargetGfxInfo.Height = TargetGfx.Size.Y
        End If

        ChatBubbleGfxInfo = New GraphicInfo
        If File.Exists(Paths.Graphics & "Misc\ChatBubble" & GfxExt) Then
            ChatBubbleGfx = New Texture(Paths.Graphics & "Misc\ChatBubble" & GfxExt)
            ChatBubbleSprite = New Sprite(ChatBubbleGfx)
            ChatBubbleGfxInfo.Width = ChatBubbleGfx.Size.X
            ChatBubbleGfxInfo.Height = ChatBubbleGfx.Size.Y
        End If

        LightGfxInfo = New GraphicInfo
        If File.Exists(Paths.Graphics & "Misc\Light" & GfxExt) Then
            LightGfx = New Texture(Paths.Graphics & "Misc\Light" & GfxExt)
            LightSprite = New Sprite(LightGfx)
            LightGfxInfo.Width = LightGfx.Size.X
            LightGfxInfo.Height = LightGfx.Size.Y
        End If

        CursorGfxInfo = New GraphicInfo
        If File.Exists(Paths.Graphics & "Misc\Cursor" & GfxExt) Then
            CursorGfx = New Texture(Paths.Graphics & "Misc\Cursor" & GfxExt)
            CursorSprite = New Sprite(CursorGfx)
            CursorGfxInfo.Width = CursorGfx.Size.X
            CursorGfxInfo.Height = CursorGfx.Size.Y
        End If

        ShadowGfxInfo = New GraphicInfo
        If File.Exists(Paths.Graphics & "Misc\Shadow" & GfxExt) Then
            ShadowGfx = New Texture(Paths.Graphics & "Misc\Shadow" & GfxExt)
            ShadowSprite = New Sprite(ShadowGfx)
            ShadowGfxInfo.Width = ShadowGfx.Size.X
            ShadowGfxInfo.Height = ShadowGfx.Size.Y
        End If

        BarGfxInfo = New GraphicInfo
        If File.Exists(Paths.Graphics & "Misc\Bars" & GfxExt) Then
            BarGfx = New Texture(Paths.Graphics & "Misc\Bars" & GfxExt)
            BarSprite = New Sprite(BarGfx)
            BarGfxInfo.Width = BarGfx.Size.X
            BarGfxInfo.Height = BarGfx.Size.Y
        End If
    End Sub

    Public Sub UpdateWindow()
        If RefreshWindow Then
            WindowSettings = New ContextSettings()
            WindowSettings.DepthBits = 24
            WindowSettings.StencilBits = 8
            WindowSettings.AntialiasingLevel = 4

            ' Destroy Previous window if there was one
            If Window IsNot Nothing Then
                Window.Close()
                Window.Dispose()
                Window = Nothing
            End If

            Window = New RenderWindow(New VideoMode(ResolutionWidth, ResolutionHeight), Types.Settings.GameName, Styles.Default, WindowSettings)
            
            CenterWindow(Window)
            Window.SetVerticalSyncEnabled(Types.Settings.Vsync)
            If Types.Settings.Vsync = 0 Then
                Window.SetFramerateLimit(Types.Settings.MaxFps)
            End If

            Window.SetMouseCursorVisible(False)

            Dim iconImage As New Image(Paths.Gui + "icon.png")
            Window.SetIcon(iconImage.Size.X, iconImage.Size.Y, iconImage.Pixels)

            Window.SetActive(true)
            RefreshWindow = False
            RegisterEvents()
        End If
    End Sub

    Private Sub RegisterEvents()
        AddHandler Window.Closed, AddressOf Window_Closed
        AddHandler Window.GainedFocus, AddressOf Window_GainedFocus
        AddHandler Window.LostFocus, AddressOf Window_LostFocus
        AddHandler Window.KeyPressed, AddressOf Window_KeyPressed
        AddHandler Window.KeyReleased, AddressOf Window_KeyReleased
        AddHandler Window.MouseButtonPressed, AddressOf Window_MouseButtonPressed
        AddHandler Window.MouseButtonReleased, AddressOf Window_MouseButtonReleased
        AddHandler Window.MouseMoved, AddressOf Window_MouseMoved
        AddHandler Window.TextEntered, AddressOf Window_TextEntered
        AddHandler Window.MouseWheelScrolled, AddressOf Window_MouseWheelScrolled
        AddHandler Window.Resized, AddressOf Window_Resized
    End Sub

    Friend Sub LoadTexture(index As Integer, texType As GfxType)
        If index <= 0 Then Exit Sub

        Dim basePath As String
        Dim numAssets As Integer
        Dim textureArray() As Texture = Nothing
        Dim spriteArray() As Sprite = Nothing
        Dim gfxInfoArray() As GraphicInfo = Nothing

        ' Setup parameters based on GfxType
        Select Case texType
            Case GfxType.Tileset
                numAssets = NumTileSets
                textureArray = TilesetTexture
                spriteArray = TilesetSprite
                gfxInfoArray = TilesetGfxInfo
                basePath = Paths.Graphics & "tilesets\"

            Case GfxType.Character
                numAssets = NumCharacters
                textureArray = CharacterTexture
                spriteArray = CharacterSprite
                gfxInfoArray = CharacterGfxInfo
                basePath = Paths.Graphics & "characters\"

            Case GfxType.Paperdoll
                numAssets = NumPaperdolls
                textureArray = ItemTexture
                spriteArray = ItemSprite
                gfxInfoArray = ItemGfxInfo
                basePath = Paths.Graphics & "paperdolls\"

            Case GfxType.Item
                numAssets = NumItems
                textureArray = ItemTexture
                spriteArray = ItemSprite
                gfxInfoArray = ItemGfxInfo
                basePath = Paths.Graphics & "items\"

            Case GfxType.Resource
                numAssets = NumResources
                textureArray = ResourceTexture
                spriteArray = ResourceSprite
                gfxInfoArray = ResourceGfxInfo
                basePath = Paths.Graphics & "resources\"

            Case GfxType.Animation
                numAssets = NumAnimations
                textureArray = AnimationTexture
                spriteArray = AnimationSprite
                gfxInfoArray = AnimationGfxInfo
                basePath = Paths.Graphics & "animations\"

            Case GfxType.Fog
                numAssets = NumFogs
                textureArray = FogTexture
                spriteArray = FogSprite
                gfxInfoArray = FogGfxInfo
                basePath = Paths.Graphics & "fogs\"

            Case GfxType.Skill
                numAssets = NumSkills
                textureArray = SkillTexture
                spriteArray = SkillSprite
                gfxInfoArray = SkillGfxInfo
                basePath = Paths.Graphics & "skills\"

            Case GfxType.Projectile
                numAssets = NumProjectiles
                textureArray = ProjectileTexture
                spriteArray = ProjectileSprite
                gfxInfoArray = ProjectileGfxInfo
                basePath = Paths.Graphics & "projectiles\"

            Case GfxType.Emote
                numAssets = NumEmotes
                textureArray = EmoteTexture
                spriteArray = EmoteSprite
                gfxInfoArray = EmoteGfxInfo
                basePath = Paths.Graphics & "emotes\"

            Case GfxType.Panorama
                numAssets = NumPanorama
                textureArray = PanoramaTexture
                spriteArray = PanoramaSprite
                gfxInfoArray = PanoramaGfxInfo
                basePath = Paths.Graphics & "panoramas\"

            Case GfxType.Parallax
                numAssets = NumParallax
                textureArray = ParallaxTexture
                spriteArray = ParallaxSprite
                gfxInfoArray = ParallaxGfxInfo
                basePath = Paths.Graphics & "parallax\"

            Case GfxType.Picture
                numAssets = NumPictures
                textureArray = PictureTexture
                spriteArray = PictureSprite
                gfxInfoArray = PictureGfxInfo
                basePath = Paths.Graphics & "pictures\" 

            Case GfxType.GUI
                numAssets = NumInterface
                textureArray = InterfaceTexture
                spriteArray = InterfaceSprite
                gfxInfoArray = InterfaceGfxInfo
                basePath = Paths.Gui

            Case GfxType.Gradient
                numAssets = NumGradients
                textureArray = GradientTexture
                spriteArray = GradientSprite
                gfxInfoArray = GradientGfxInfo
                basePath = Paths.Gui & "gradients\"

            Case GfxType.Design
                numAssets = NumDesigns
                textureArray = DesignTexture
                spriteArray = DesignSprite
                gfxInfoArray = DesignGfxInfo
                basePath = Paths.Gui & "designs\"

            Case Else
                ' Log unrecognized type or handle accordingly
                Exit Sub
        End Select

        If index > numAssets Then Exit Sub ' Validate index range

        ' Load the texture and create the sprite
        textureArray(index) = New Texture(basePath & index & GfxExt)
        spriteArray(index) = New Sprite(textureArray(index))

        ' Cache the width, height, and other properties
        With gfxInfoArray(index)
            .Width = textureArray(index).Size.X
            .Height = textureArray(index).Size.Y
            .IsLoaded = True
            .TextureTimer = GetTickCount() + 100000
        End With
    End Sub

#End Region

#Region "Drawing"
    Friend Sub DrawEmote(x2 As Integer, y2 As Integer, sprite As Integer)
        Dim rec As Rectangle
        Dim x As Integer, y As Integer, anim As Integer

        If sprite < 1 Or sprite > NumEmotes Then Exit Sub

        If ShowAnimLayers = True Then
            anim = 1
        Else
            anim = 0
        End If

        With rec
            .Y = 0
            .Height = PicX
            .X = anim * (EmoteGfxInfo(sprite).Width / 2)
            .Width = (EmoteGfxInfo(sprite).Width / 2)
        End With

        x = ConvertMapX(x2)
        y = ConvertMapY(y2) - (PicY + 16)

        RenderTexture(sprite, GfxType.Emote, Window, x, y, rec.X, rec.Y, rec.Width, rec.Height)
    End Sub

    Friend Sub RenderTexture(tmpSprite As Sprite, target As RenderWindow, dX As Integer, dY As Integer,
                            sX As Integer, sY As Integer, dW As Integer, dH As Integer, Optional sW As Integer = 1, Optional sH As Integer = 1, Optional alpha As Byte = 255, Optional red As Byte = 255, Optional green As Byte = 255, Optional blue As Byte = 255)
        
        If tmpSprite Is Nothing Then Exit Sub
        If target Is Nothing Then Exit Sub

        tmpSprite.TextureRect = New IntRect(sX, sY, sW, sH)
        tmpSprite.Scale = New Vector2f(dW / sW, dH / sH)
        tmpSprite.Position = New Vector2f(dX, dY)
        tmpSprite.Color = New Color(red, green, blue, alpha)

        target.Draw(tmpSprite)
    End Sub

    Friend Sub RenderTexture(index As Integer, gfxType As GfxType, ByRef target As RenderWindow, 
                             dX As Integer, dY As Integer, sX As Integer, sY As Integer, 
                             dW As Integer, dH As Integer, 
                             Optional sW As Integer = 1, Optional sH As Integer = 1, 
                             Optional alpha As Byte = 255, Optional red As Byte = 255, 
                             Optional green As Byte = 255, Optional blue As Byte = 255)

        Dim textureArray() As Texture = Nothing
        Dim spriteArray() As Sprite = Nothing
        Dim gfxInfoArray() As GraphicInfo = Nothing

        If gfxType = GfxType.None Then Exit Sub
        If target Is Nothing Then Exit Sub

        ResolveTextureArrays(gfxType, textureArray, spriteArray, gfxInfoArray)

        If index <= 0 OrElse index >= textureArray.Length OrElse gfxInfoArray Is Nothing Then
            Console.WriteLine("Invalid index or gfxInfo array.")
            Exit Sub
        End If

        ' Check if the texture is loaded, if not, load it
        If gfxInfoArray(index).IsLoaded = False Then
            LoadTexture(index, gfxType)
        End If

        ' Use the texture
        Dim tmpSprite As Sprite = spriteArray(index)
        tmpSprite.TextureRect = New IntRect(sX, sY, sW, sH)
        tmpSprite.Scale = New Vector2f(dW / sW, dH / sH)
        tmpSprite.Position = New Vector2f(dX, dY)
        tmpSprite.Color = New Color(red, green, blue, alpha)

        target.Draw(tmpSprite)
    End Sub

    Private Sub ResolveTextureArrays(gfxType As GfxType, ByRef textureArray() As Texture, 
                                     ByRef spriteArray() As Sprite, ByRef gfxInfoArray() As GraphicInfo)
        Select Case gfxType
            Case GfxType.Tileset
                textureArray = TilesetTexture
                spriteArray = TilesetSprite
                gfxInfoArray = TilesetGfxInfo

            Case GfxType.Character
                textureArray = CharacterTexture
                spriteArray = CharacterSprite
                gfxInfoArray = CharacterGfxInfo

            Case GfxType.Paperdoll
                textureArray = PaperdollTexture
                spriteArray = PaperdollSprite
                gfxInfoArray = PaperdollGfxInfo

            Case GfxType.Item
                textureArray = ItemTexture
                spriteArray = ItemSprite
                gfxInfoArray = ItemGfxInfo

            Case GfxType.Resource
                textureArray = ResourceTexture
                spriteArray = ResourceSprite
                gfxInfoArray = ResourceGfxInfo

            Case GfxType.Animation
                textureArray = AnimationTexture
                spriteArray = AnimationSprite
                gfxInfoArray = AnimationGfxInfo

            Case GfxType.Fog
                textureArray = FogTexture
                spriteArray = FogSprite
                gfxInfoArray = FogGfxInfo

            Case GfxType.Skill
                textureArray = SkillTexture
                spriteArray = SkillSprite
                gfxInfoArray = SkillGfxInfo

            Case GfxType.Projectile
                textureArray = ProjectileTexture
                spriteArray = ProjectileSprite
                gfxInfoArray = ProjectileGfxInfo

            Case GfxType.Emote
                textureArray = EmoteTexture
                spriteArray = EmoteSprite
                gfxInfoArray = EmoteGfxInfo

            Case GfxType.Panorama
                textureArray = PanoramaTexture
                spriteArray = PanoramaSprite
                gfxInfoArray = PanoramaGfxInfo

            Case GfxType.Parallax
                textureArray = ParallaxTexture
                spriteArray = ParallaxSprite
                gfxInfoArray = ParallaxGfxInfo

            Case GfxType.Picture
                textureArray = PictureTexture
                spriteArray = PictureSprite
                gfxInfoArray = PictureGfxInfo

            Case GfxType.GUI
                textureArray = InterfaceTexture
                spriteArray = InterfaceSprite
                gfxInfoArray = InterfaceGfxInfo

            Case GfxType.Gradient
                textureArray = GradientTexture
                spriteArray = GradientSprite
                gfxInfoArray = GradientGfxInfo

            Case GfxType.Design
                textureArray = DesignTexture
                spriteArray = DesignSprite
                gfxInfoArray = DesignGfxInfo
        End Select
    End Sub

    Friend Sub DrawDirections(x As Integer, y As Integer)
        Dim rec As Rectangle, i As Integer

        ' render grid
        rec.Y = 24
        rec.X = 0
        rec.Width = 32
        rec.Height = 32

        RenderTexture(DirectionSprite, Window, ConvertMapX(x * PicX), ConvertMapY(y * PicY), rec.X, rec.Y, rec.Width,
                     rec.Height, rec.Width, rec.Height)

        ' render dir blobs
        For i = 1 To 4
            rec.X = (i - 1) * 8
            rec.Width = 8

            ' find out whether render blocked or not
            If Not IsDirBlocked(Map.Tile(x, y).DirBlock, CByte(i)) Then
                rec.Y = 8
            Else
                rec.Y = 16
            End If
            rec.Height = 8

            RenderTexture(DirectionSprite, Window, ConvertMapX(x * PicX) + DirArrowX(i),
                         ConvertMapY(y * PicY) + DirArrowY(i), rec.X, rec.Y, rec.Width, rec.Height, rec.Width, rec.Height)
        Next
    End Sub

    Friend Function ConvertMapX(x As Integer) As Integer
        ConvertMapX = x - (TileView.Left * PicX) - Camera.Left
    End Function

    Friend Function ConvertMapY(y As Integer) As Integer
        ConvertMapY = y - (TileView.Top * PicY) - Camera.Top
    End Function

    Friend Sub DrawPaperdoll(x2 As Integer, y2 As Integer, sprite As Integer, anim As Integer, spritetop As Integer)
        Dim rec As Rectangle
        Dim x As Integer, y As Integer
        Dim width As Integer, height As Integer

        If sprite < 1 Or sprite > NumPaperdolls Then Exit Sub

        With rec
            .Y = spritetop * (PaperdollGfxInfo(sprite).Height / 4)
            .Height = (PaperdollGfxInfo(sprite).Height / 4)
            .X = anim * (PaperdollGfxInfo(sprite).Width / 4)
            .Width = (PaperdollGfxInfo(sprite).Width / 4)
        End With

        x = ConvertMapX(x2)
        y = ConvertMapY(y2)
        width = (rec.Right - rec.Left)
        height = (rec.Bottom - rec.Top)

        RenderTexture(sprite, GfxType.Paperdoll, Window, x, y, rec.X, rec.Y, rec.Width, rec.Height)
    End Sub

    Friend Sub DrawNpc(mapNpcNum As Integer)
        Dim anim As Byte
        Dim x As Integer
        Dim y As Integer
        Dim sprite As Integer, spriteleft As Integer
        Dim rect As Rectangle
        Dim attackspeed As Integer

        If MapNpc(mapNpcNum).Num = 0 Then Exit Sub

        If MapNpc(mapNpcNum).X < TileView.Left Or MapNpc(mapNpcNum).X > TileView.Right Then Exit Sub
        If MapNpc(mapNpcNum).Y < TileView.Top Or MapNpc(mapNpcNum).Y > TileView.Bottom Then Exit Sub

        StreamNpc(MapNpc(mapNpcNum).Num)

        sprite = NPC(MapNpc(mapNpcNum).Num).Sprite

        If sprite < 1 Or sprite > NumCharacters Then Exit Sub

        attackspeed = 1000

        ' Reset frame
        anim = 0

        ' Check for attacking animation
        If MapNpc(mapNpcNum).AttackTimer + (attackspeed / 2) > GetTickCount() Then
            If MapNpc(mapNpcNum).Attacking = 1 Then
                anim = 3
            End If
        Else
            ' If not attacking, walk normally
            Select Case MapNpc(mapNpcNum).Dir
                Case DirectionType.Up
                    If (MapNpc(mapNpcNum).YOffset > 8) Then anim = MapNpc(mapNpcNum).Steps
                Case DirectionType.Down
                    If (MapNpc(mapNpcNum).YOffset < -8) Then anim = MapNpc(mapNpcNum).Steps
                Case DirectionType.Left
                    If (MapNpc(mapNpcNum).XOffset > 8) Then anim = MapNpc(mapNpcNum).Steps
                Case DirectionType.Right
                    If (MapNpc(mapNpcNum).XOffset < -8) Then anim = MapNpc(mapNpcNum).Steps
            End Select
        End If

        ' Check to see if we want to stop making him attack
        With MapNpc(mapNpcNum)
            If .AttackTimer + attackspeed < GetTickCount() Then
                .Attacking = 0
                .AttackTimer = 0
            End If
        End With

        ' Set the left
        Select Case MapNpc(mapNpcNum).Dir
            Case DirectionType.Up
                spriteleft = 3
            Case DirectionType.Right
                spriteleft = 2
            Case DirectionType.Down
                spriteleft = 0
            Case DirectionType.Left
                spriteleft = 1
        End Select

        rect = New Rectangle((anim) * (CharacterGfxInfo(sprite).Width / 4), spriteleft * (CharacterGfxInfo(sprite).Height / 4),
                               (CharacterGfxInfo(sprite).Width / 4), (CharacterGfxInfo(sprite).Height / 4))

        ' Calculate the X
        x = MapNpc(mapNpcNum).X * PicX + MapNpc(mapNpcNum).XOffset - ((CharacterGfxInfo(sprite).Width / 4 - 32) / 2)

        ' Is the player's height more than 32..?
        If (CharacterGfxInfo(sprite).Height / 4) > 32 Then
            ' Create a 32 pixel offset for larger sprites
            y = MapNpc(mapNpcNum).Y * PicY + MapNpc(mapNpcNum).YOffset - ((CharacterGfxInfo(sprite).Height / 4) - 32)
        Else
            ' Proceed as normal
            y = MapNpc(mapNpcNum).Y * PicY + MapNpc(mapNpcNum).YOffset
        End If

        DrawShadow(x, y + 16)
        DrawCharacterSprite(sprite, x, y, rect)
    End Sub

    Friend Sub DrawMapItem(itemnum As Integer)
        Dim srcrec As Rectangle, destrec As Rectangle
        Dim picNum As Integer
        Dim x As Integer, y As Integer

        StreamItem(MapItem(itemnum).Num)

        picNum = Item(MapItem(itemnum).Num).Icon

        If picNum < 1 Or picNum > NumItems Then Exit Sub

        With MapItem(itemnum)
            If .X < TileView.Left Or .X > TileView.Right Then Exit Sub
            If .Y < TileView.Top Or .Y > TileView.Bottom Then Exit Sub
        End With

        If ItemGfxInfo(picNum).Width > 32 Then ' has more than 1 frame
            srcrec = New Rectangle((MapItem(itemnum).Frame * 32), 0, 32, 32)
            destrec = New Rectangle(ConvertMapX(MapItem(itemnum).X * PicX), ConvertMapY(MapItem(itemnum).Y * PicY), 32, 32)
        Else
            srcrec = New Rectangle(0, 0, PicX, PicY)
            destrec = New Rectangle(ConvertMapX(MapItem(itemnum).X * PicX), ConvertMapY(MapItem(itemnum).Y * PicY), PicX, PicY)
        End If

        x = ConvertMapX(MapItem(itemnum).X * PicX)
        y = ConvertMapY(MapItem(itemnum).Y * PicY)

        RenderTexture(picNum, GfxType.Item, Window, x, y, srcrec.X, srcrec.Y, srcrec.Width, srcrec.Height, srcrec.Width, srcrec.Height)
    End Sub

    Friend Sub DrawCharacterSprite(sprite As Integer, x2 As Integer, y2 As Integer, sRECT As Rectangle)
        Dim x As Integer
        Dim y As Integer

        If sprite < 1 Or sprite > NumCharacters Then Exit Sub

        x = ConvertMapX(x2)
        y = ConvertMapY(y2)

        RenderTexture(sprite, GfxType.Character, Window, x, y, sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height, sRECT.Width, sRECT.Height)
    End Sub

    Friend Sub DrawShadow(x2 As Integer, y2 As Integer)
        Dim x As Integer
        Dim y As Integer
        Dim srcrec As Rectangle
        Dim destrec As Rectangle

        If Types.Settings.Shadow = 0 Then Exit Sub

        'seeying we still use it, lets update timer
        With ShadowGfxInfo
            .TextureTimer = GetTickCount() + 100000
        End With

        x = ConvertMapX(x2)
        y = ConvertMapY(y2)
        srcrec = New Rectangle(0, 0, PicX, PicY)
        destrec = New Rectangle(ConvertMapX(x * PicX), ConvertMapY(y * PicY), PicX, PicY)

        RenderTexture(ShadowSprite, Window, x, y, srcrec.X, srcrec.Y, destrec.Width, destrec.Height, destrec.Width, destrec.Height)
    End Sub

    Friend Sub DrawBlood(index As Integer)
        Dim srcrec As Rectangle
        Dim destrec As Rectangle
        Dim x As Integer
        Dim y As Integer

        With Blood(index)
            If .X < TileView.Left Or .X > TileView.Right Then Exit Sub
            If .Y < TileView.Top Or .Y > TileView.Bottom Then Exit Sub

            ' check if we should be seeing it
            If .Timer + 20000 < GetTickCount() Then Exit Sub

            x = ConvertMapX(Blood(index).X * PicX)
            y = ConvertMapY(Blood(index).Y * PicY)

            srcrec = New Rectangle((.Sprite - 1) * PicX, 0, PicX, PicY)
            destrec = New Rectangle(ConvertMapX(.X * PicX), ConvertMapY(.Y * PicY), PicX, PicY)

            RenderTexture(BloodSprite, Window, x, y, srcrec.X, srcrec.Y, srcrec.Width, srcrec.Height)

        End With
    End Sub

    Friend Function IsValidMapPoint(x As Integer, y As Integer) As Boolean
        IsValidMapPoint = False

        If x < 0 Then Exit Function
        If y < 0 Then Exit Function
        If x > Map.MaxX Then Exit Function
        If y > Map.MaxY Then Exit Function

        IsValidMapPoint = True
    End Function

    Friend Sub UpdateCamera()
        Dim offsetX As Integer, offsetY As Integer
        Dim startX As Double, startY As Double
        Dim endX As Integer, endY As Integer

        offsetX = Player(MyIndex).XOffset + PicX
        offsetY = Player(MyIndex).YOffset + PicY
        startX = GetPlayerX(MyIndex) - (Types.Settings.CameraWidth / 2)
        startY = GetPlayerY(MyIndex) - (Types.Settings.CameraHeight / 2)

        If startX < 0 Then
            offsetX = 0

            If startX = -1 Then
                If Player(MyIndex).XOffset > 0 Then
                    offsetX = Player(MyIndex).XOffset
                End If
            End If

            startX = 0
        End If

        If startY < 0 Then
            offsetY = 0

            If startY = -1 Then
                If Player(MyIndex).YOffset > 0 Then
                    offsetY = Player(MyIndex).YOffset
                End If
            End If

            startY = 0
        End If

        If Not Map.MaxX = Types.Settings.CameraWidth Then
            If Player(MyIndex).xOffset > 0 Then
                EndX = StartX + (Types.Settings.CameraWidth + 1) + 1
            Else
                EndX = StartX + (Types.Settings.CameraWidth + 1)
            End If
        Else
            EndX = StartX + (Types.Settings.CameraWidth + 1)
        End If

        If Not Map.MaxY = Types.Settings.CameraHeight Then
            If Player(MyIndex).yOffset > 0 Then
                EndY = StartY + (Types.Settings.CameraHeight + 1) + 1
            Else
                EndY = StartY + (Types.Settings.CameraHeight + 1)
            End If
        Else
            EndY = StartY + (Types.Settings.CameraHeight + 1)
        End If

        If EndX - 1 >= Map.MaxX Then
            offsetX = 32
            EndX = Map.MaxX
        
            If EndX > Map.MaxX Then
                If Player(MyIndex).xOffset < 0 Then
                    offsetX = Player(MyIndex).xOffset + PicX
                End If
            End If
        
            If Map.MaxX = Types.Settings.CameraWidth Then
                If offsetX <> 0 Then
                    StartX = EndX - Types.Settings.CameraWidth
                Else
                    StartX = EndX - Types.Settings.CameraWidth - 1
                End If
            Else
                StartX = EndX - Types.Settings.CameraWidth - 1
            End If
        End If

        If EndY - 1 >= Map.MaxY Then
            offsetY = 32
            EndY = Map.MaxY
        
            If EndY > Map.MaxY Then
                If Player(MyIndex).yOffset < 0 Then
                    offsetY = Player(MyIndex).yOffset + PicY
                End If
            End If

            If Map.MaxY = Types.Settings.CameraHeight Then
                If offsetY <> 0 Then
                    StartY = EndY - Types.Settings.CameraHeight
                Else
                    StartY = EndY - Types.Settings.CameraHeight - 1
                End If
            Else
                StartY = EndY - Types.Settings.CameraHeight - 1
            End If
        End If

        If Types.Settings.CameraWidth > Map.MaxX Then
            If EndX + 1 < Types.Settings.CameraWidth Then
                StartX = StartX + ((Types.Settings.CameraWidth - EndX) / 2)
            End If
        End If

        If Types.Settings.CameraHeight > Map.MaxY Then
            If EndY + 1 < Types.Settings.CameraHeight Then
                StartY = StartY + ((Types.Settings.CameraHeight - EndY) / 2)
            End If
        End If
            
        If Types.Settings.CameraWidth = Map.MaxX Then
            offsetX = 0
        End If

        If Types.Settings.CameraHeight = Map.MaxY Then
            offsetY = 0
        End If

        With TileView
            .Top = startY
            .Bottom = endY
            .Left = startX
            .Right = endX
        End With

        With Camera
            .Y = offsetY
            .X = offsetX
            .Height = .Top + Types.Settings.CameraHeight * PicY
            .Width = .Left + Types.Settings.CameraWidth * PicX
        End With

        UpdateDrawMapName()
    End Sub

    Friend Sub Render_Graphics()
        Dim x As Integer, y As Integer, i As Integer

        If GettingMap Then Exit Sub

        UpdateCamera()
        Window.Clear(Color.Black)

        If NumPanorama > 0 And Map.Panorama > 0 Then
            DrawPanorama(Map.Panorama)
        End If

        If NumParallax > 0 And Map.Parallax > 0 Then
            DrawParallax(Map.Parallax)
        End If

        ' Draw lower tiles
        If NumTileSets > 0 Then
            For x = TileView.Left To TileView.Right
                For y = TileView.Top To TileView.Bottom
                    If IsValidMapPoint(x, y) Then
                        DrawMapLowerTile(x, y)
                    End If
                Next
            Next
        End If

        ' events
        If Editor <> EditorType.Map Then
            If CurrentEvents > 0 And CurrentEvents <= Map.EventCount Then
                For i = 1 To CurrentEvents
                    If MapEvents(i).Position = 0 Then
                        DrawEvent(i)
                    End If
                Next
            End If
        End If

        ' blood
        For i = 0 To Byte.MaxValue
            DrawBlood(i)
        Next

        ' Draw out the items
        If NumItems > 0 Then
            For i = 1 To MAX_MAP_ITEMS
                If MapItem(i).Num > 0 Then
                    DrawMapItem(i)
                End If
            Next
        End If

        ' draw animations
        If NumAnimations > 0 Then
            For i = 0 To Byte.MaxValue
                If AnimInstance(i).Used(0) Then
                    DrawAnimation(i, 0)
                End If
            Next
        End If

        ' Y-based render. Renders Players, Npcs and Resources based on Y-axis.
        For y = 0 To Map.MaxY
            If NumCharacters > 0 Then
                ' Players
                For i = 1 To MAX_PLAYERS
                    If IsPlaying(i) And GetPlayerMap(i) = GetPlayerMap(MyIndex) Then
                        If Player(i).Y = y Then
                            DrawPlayer(i)
                        End If

                        If PetAlive(i) Then
                            If Player(i).Pet.Y = y Then
                                DrawPet(i)
                            End If
                        End If
                    End If
                Next

                ' Npcs
                For i = 1 To MAX_MAP_NPCS
                    If MapNpc(i).Y = y Then
                        DrawNpc(i)
                    End If
                Next

                ' events
                If Editor <> EditorType.Map Then
                    If CurrentEvents > 0 And CurrentEvents <= Map.EventCount Then
                        For i = 1 To CurrentEvents
                            If MapEvents(i).Position = 1 Then
                                If y = MapEvents(i).Y Then
                                    DrawEvent(i)
                                End If
                            End If
                        Next
                    End If
                End If

                ' Draw the target icon
                If MyTarget > 0 Then
                    If MyTargetType = TargetType.Player Then
                        DrawTarget(Player(MyTarget).X * 32 - 16 + Player(MyTarget).XOffset,
                                   Player(MyTarget).Y * 32 + Player(MyTarget).YOffset)
                    ElseIf MyTargetType = TargetType.Npc Then
                        DrawTarget(MapNpc(MyTarget).X * 32 - 16 + MapNpc(MyTarget).XOffset,
                                   MapNpc(MyTarget).Y * 32 + MapNpc(MyTarget).YOffset)
                    ElseIf MyTargetType = TargetType.Pet Then
                        DrawTarget(Player(MyTarget).Pet.X * 32 - 16 + Player(MyTarget).Pet.XOffset,
                                   (Player(MyTarget).Pet.Y * 32) + Player(MyTarget).Pet.YOffset)
                    End If
                End If

                For i = 1 To MAX_PLAYERS
                    If IsPlaying(i) Then
                        If Player(i).Map = Player(MyIndex).Map Then
                            If CurX = Player(i).X And CurY = Player(i).Y Then
                                If MyTargetType = TargetType.Player And MyTarget = i Then
                                Else
                                    DrawHover(Player(i).X * 32 - 16, Player(i).Y * 32 + Player(i).YOffset)
                                End If
                            End If

                        End If
                    End If
                Next
            End If

            ' Resources
            If NumResources > 0 Then
                If ResourcesInit Then
                    If ResourceIndex > 0 Then
                        For i = 0 To ResourceIndex
                            If MapResource(i).Y = y Then
                                DrawMapResource(i)
                            End If
                        Next
                    End If
                End If
            End If
        Next

        ' animations
        If NumAnimations > 0 Then
            For i = 0 To Byte.MaxValue
                If AnimInstance(i).Used(1) Then
                    DrawAnimation(i, 1)
                End If
            Next
        End If

        If NumProjectiles > 0 Then
            For i = 1 To MAX_PROJECTILES
                If MapProjectile(Player(MyIndex).Map, i).ProjectileNum > 0 Then
                    DrawProjectile(i)
                End If
            Next
        End If

        If CurrentEvents > 0 And CurrentEvents <= Map.EventCount Then
            For i = 1 To CurrentEvents
                If MapEvents(i).Position = 2 Then
                    DrawEvent(i)
                End If
            Next
        End If

        If NumTileSets > 0 Then
            For x = TileView.Left To TileView.Right
                For y = TileView.Top To TileView.Bottom
                    If IsValidMapPoint(x, y) Then
                        DrawMapUpperTile(x, y)
                    End If
                Next
            Next
        End If

        DrawNight()
        DrawWeather()
        DrawThunderEffect()
        DrawMapTint()

        ' Draw out a square at mouse cursor
        If MapGrid = True And Editor = EditorType.Map Then
            DrawGrid()
        End If

        If Editor = EditorType.Map Then
            DrawTileOutline()
            If EyeDropper = True Then
                DrawEyeDropper()
            End If
        End If

        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) And GetPlayerMap(i) = GetPlayerMap(MyIndex) Then
                DrawPlayerName(i)
                If PetAlive(i) Then
                    DrawPlayerPetName(i)
                End If
            End If
        Next

        If CurrentEvents > 0 AndAlso Map.EventCount >= CurrentEvents Then
            For i = 1 To CurrentEvents
                If MapEvents(i).Visible = 1 Then
                    If MapEvents(i).ShowName = 1 Then
                        DrawEventName(i)
                    End If
                End If
            Next
        End If

        For i = 1 To MAX_MAP_NPCS
            If MapNpc(i).Num > 0 Then
                DrawNpcName(i)
            End If
        Next

        DrawFog()
        DrawPicture()

        For i = 1 To Byte.MaxValue
            DrawActionMsg(i)
        Next

        If Editor = EditorType.Map Then
            If frmEditor_Map.tabpages.SelectedTab Is frmEditor_Map.tpDirBlock Then
                For x = TileView.Left To TileView.Right
                    For y = TileView.Top To TileView.Bottom
                        If IsValidMapPoint(x, y) Then
                            Call DrawDirections(x, y)
                        End If
                    Next
                Next
            End If

            DrawMapAttributes()
        End If

        For i = 1 To Byte.MaxValue
            If chatBubble(i).active Then
                DrawChatBubble(i)
            End If
        Next

        If Bfps Then
            Dim fps As String = Trim$("FPS: " & GameFps)
            Call RenderText(fps, Window, Camera.Left - 24, Camera.Top + 60, Color.Yellow, Color.Black)
        End If

        ' draw cursor, player X and Y locations
        If BLoc Then
            Dim Cur As String = Trim$("Cur X: " & CurX & " Y: " & CurY)
            Dim Loc As String = Trim$("loc X: " & GetPlayerX(MyIndex) & " Y: " & GetPlayerY(MyIndex))
            Dim Map As String = Trim$(" (Map #" & GetPlayerMap(MyIndex) & ")")

            Call RenderText(Cur, Window, DrawLocX, DrawLocY + 105, Color.Yellow, Color.Black)
            Call RenderText(Loc, Window, DrawLocX,  DrawLocY + 120, Color.Yellow, Color.Black)
            Call RenderText(Map, Window, DrawLocX, DrawLocY + 135, Color.Yellow, Color.Black)
        End If

        DrawMapName()

        If Editor = EditorType.Map And frmEditor_Map.tabpages.SelectedTab Is frmEditor_Map.tpEvents Then
            DrawEvents()
            EditorEvent_DrawGraphic()
        End If

        If Editor = EditorType.Projectile Then
            EditorProjectile_DrawProjectile()
        End If

        DrawBars()
        DrawMapFade()
        RenderEntities()
        RenderTexture(CursorSprite, Window, CurMouseX, CurMouseY, 0, 0, 16, 16, 32, 32)

        Window.Display()
    End Sub

    Friend Sub Render_Menu()
        Window.Clear(Color.Black)

        DrawMenuBG()
        RenderEntities()
        RenderTexture(CursorSprite, Window, CurMouseX, CurMouseY, 0, 0, 16, 16, 32, 32)

        Window.Display()
    End Sub

    Friend Sub DrawPanorama(index As Integer)
        If Map.Indoors Then Exit Sub

        If index < 1 Or index > NumPanorama Then Exit Sub

        RenderTexture(index, GfxType.Panorama, Window, 
                      0, 0, 0, 0, 
                      Window.Size.X, Window.Size.Y, 
                      Window.Size.X, Window.Size.Y)
    End Sub

    Friend Sub DrawParallax(index As Integer)
        Dim horz As Single = 0
        Dim vert As Single = 0

        If Map.Moral = Map.Indoors Then Exit Sub
        If index < 1 Or index > NumParallax Then Exit Sub

        ' Calculate horizontal and vertical offsets based on player position
        horz = ConvertMapX(GetPlayerX(MyIndex)) * 2.5F - 50
        vert = ConvertMapY(GetPlayerY(MyIndex)) * 2.5F - 50

        RenderTexture(index, GfxType.Parallax, Window, 
                      CInt(horz), CInt(vert), 0, 0, 
                      Window.Size.X, Window.Size.Y, 
                      Window.Size.X, Window.Size.Y)
    End Sub

    Friend Sub DrawPicture(Optional index As Integer = 0, Optional type As Integer = 0)
        If index = 0 Then
            index = Picture.Index
        End If

        If type = 0 Then
            type = Picture.SpriteType
        End If

        If index < 1 Or index > NumPictures Then Exit Sub
        If type < 0 Or type >= PictureType.Count Then Exit Sub

        Dim posX As Integer = 0
        Dim posY As Integer = 0

        ' Determine position based on type
        Select Case type
            Case PictureType.TopLeft
                posX = 0 - Picture.xOffset
                posY = 0 - Picture.yOffset

            Case PictureType.CenterScreen
                posX = Window.Size.X / 2 - PictureGfxInfo(index).Width / 2 - Picture.xOffset
                posY = Window.Size.Y / 2 - PictureGfxInfo(index).Height / 2 - Picture.yOffset

            Case PictureType.CenterEvent
                If CurrentEvents < Picture.EventId Then
                    ' Reset picture details and exit if event is invalid
                    Picture.EventId = 0
                    Picture.Index = 0
                    Picture.SpriteType = 0
                    Picture.xOffset = 0
                    Picture.yOffset = 0
                    Exit Sub
                End If
                posX = ConvertMapX(MapEvents(Picture.EventId).X * 32) / 2 - Picture.xOffset
                posY = ConvertMapY(MapEvents(Picture.EventId).Y * 32) / 2 - Picture.yOffset

            Case PictureType.CenterPlayer
                posX = ConvertMapX(Player(MyIndex).X * 32) / 2 - Picture.xOffset
                posY = ConvertMapY(Player(MyIndex).Y * 32) / 2 - Picture.yOffset
        End Select

        RenderTexture(index, GfxType.Picture, Window, posX, posY, 0, 0, 
                      Window.Size.X, Window.Size.Y, Window.Size.X, Window.Size.Y)
    End Sub

    Public Sub DrawBars()
        Dim Left As Long, Top As Long, Width As Long, Height As Long
        Dim tmpX As Long, tmpY As Long, barWidth As Long, i As Long, NpcNum As Long

        ' dynamic bar calculations
        Width = BarGfxInfo.Width
        Height = BarGfxInfo.Height / 4
    
        ' render npc health bars
        For i = 1 To MAX_MAP_NPCS
            NpcNum = MapNpc(i).Num

            ' exists?
            If NpcNum > 0 Then
                ' alive?
                If MapNpc(i).Vital(VitalType.HP) > 0 And MapNpc(i).Vital(VitalType.HP) < Npc(NpcNum).HP Then
                    ' lock to npc
                    tmpX = MapNpc(i).X * PicX + MapNpc(i).xOffset + 16 - (Width / 2)
                    tmpY = MapNpc(i).Y * PicY + MapNpc(i).yOffset + 35
                
                    ' calculate the width to fill
                    If Width > 0 Then BarWidth_NpcHP_Max(i) = ((MapNpc(i).Vital(VitalType.HP) / Width) / (Npc(NpcNum).HP / Width)) * Width
                
                    ' draw bar background
                    Top = Height * 3 ' HP bar background
                    Left = 0
                    RenderTexture(BarSprite, Window, ConvertMapX(tmpX), ConvertMapY(tmpY), Left, Top, Width, Height, Width, Height)
                
                    ' draw the bar proper
                    Top = 0 ' HP bar
                    Left = 0
                    RenderTexture(BarSprite, Window, ConvertMapX(tmpX), ConvertMapY(tmpY), Left, Top, BarWidth_NpcHP(i), Height, BarWidth_NpcHP(i), Height)
                End If
            End If
        Next

        For i = 1 To MAX_PLAYERS
            If GetPlayerMap(i) = GetPlayerMap(i) Then               
                If GetPlayerVital(i, VitalType.HP) > 0 And GetPlayerVital(i, VitalType.HP) < GetPlayerMaxVital(i, VitalType.HP) Then
                    ' lock to Player
                    tmpX = GetPlayerX(i) * PicX + Player(i).xOffset + 16 - (Width / 2)
                    tmpY = GetPlayerY(i) * PicY + Player(i).yOffset + 35
       
                    ' calculate the width to fill
                    If Width > 0 Then BarWidth_PlayerHP_Max(i) = ((GetPlayerVital(i, VitalType.HP) / Width) / (GetPlayerMaxVital(i, VitalType.HP) / Width)) * Width
       
                    ' draw bar background
                    Top = Height * 3 ' HP bar background
                    Left = 0
                    RenderTexture(BarSprite, Window, ConvertMapX(tmpX), ConvertMapY(tmpY), Left, Top, Width, Height, Width, Height)
       
                    ' draw the bar proper
                    Top = 0 ' HP bar
                    Left = 0
                    RenderTexture(BarSprite, Window, ConvertMapX(tmpX), ConvertMapY(tmpY), Left, Top, BarWidth_PlayerHP(i), Height, BarWidth_PlayerHP(i), Height)
                End If

                If GetPlayerVital(i, VitalType.SP) > 0 And GetPlayerVital(i, VitalType.SP) < GetPlayerMaxVital(i, VitalType.SP) Then
                    ' lock to Player
                    tmpX = GetPlayerX(i) * PicX + Player(i).xOffset + 16 - (Width / 2)
                    tmpY = GetPlayerY(i) * PicY + Player(i).yOffset + 35 + Height 
       
                    ' calculate the width to fill
                    If Width > 0 Then BarWidth_PlayerSP_Max(i) = ((GetPlayerVital(i, VitalType.SP) / Width) / (GetPlayerMaxVital(i, VitalType.SP) / Width)) * Width
       
                    ' draw bar background
                    Top = Height * 3 ' SP bar background
                    Left = 0
                    RenderTexture(BarSprite, Window, ConvertMapX(tmpX), ConvertMapY(tmpY), Left, Top, Width, Height, Width, Height)
       
                    ' draw the bar proper
                    Top = Height * 1 ' SP bar
                    Left = 0
                    RenderTexture(BarSprite, Window, ConvertMapX(tmpX), ConvertMapY(tmpY), Left, Top, BarWidth_PlayerSP(i), Height, BarWidth_PlayerSP(i), Height)
                End If

                If SkillBuffer > 0 Then
                    If Skill(Player(i).Skill(SkillBuffer).Num).CastTime > 0 Then
                        ' lock to player
                        tmpX = GetPlayerX(i) * PicX + Player(i).xOffset + 16 - (Width / 2)
                        tmpY = GetPlayerY(i) * PicY + Player(i).yOffset + 35 + Height
            
                        ' calculate the width to fill
                        If Width > 0 Then barWidth = (GetTickCount - SkillBufferTimer) / ((Skill(Player(i).Skill(SkillBuffer).Num).CastTime * 1000)) * Width
            
                        ' draw bar background
                        Top = Height * 3 ' cooldown bar background
                        Left = 0
                        RenderTexture(BarSprite, Window, ConvertMapX(tmpX), ConvertMapY(tmpY), Left, Top, Width, Height, Width, Height)
             
                        ' draw the bar proper
                        Top = Height * 2 ' cooldown bar
                        Left = 0
                        RenderTexture(BarSprite, Window, ConvertMapX(tmpX), ConvertMapY(tmpY), Left, Top, barWidth, Height, barWidth, Height)
                    End If
                End If
            End If
        Next
    End Sub

    Sub DrawMapName()
        RenderText(Language.Game.MapName & Map.Name, Window, ResolutionWidth / 2 - TextWidth(Map.Name), FontSize, DrawMapNameColor, Color.Black)
    End Sub

    Friend Sub DrawGrid()
        For x = TileView.Left To TileView.Right
            For y = TileView.Top To TileView.Bottom
                If IsValidMapPoint(x, y) Then

                    Dim rec As New RectangleShape With {
                            .OutlineColor = New Color(Color.White),
                            .OutlineThickness = 0.6,
                            .FillColor = New Color(Color.Transparent),
                            .Size = New Vector2f((x * PicX), (y * PicX)),
                            .Position = New Vector2f(ConvertMapX((x - 1) * PicX), ConvertMapY((y - 1) * PicY))
                            }

                    Window.Draw(rec)
                End If
            Next
        Next
    End Sub

    Friend Sub DrawTileOutline()
        Dim rec As Rectangle

        If frmEditor_Map.tabpages.SelectedTab Is frmEditor_Map.tpDirBlock Then Exit Sub

        With rec
            .Y = 0
            .Height = PicY
            .X = 0
            .Width = PicX
        End With

        Dim rec2 As New RectangleShape With {
            .OutlineColor = New SFML.Graphics.Color(SFML.Graphics.Color.Blue),
            .OutlineThickness = 0.6,
            .FillColor = New SFML.Graphics.Color(SFML.Graphics.Color.Transparent)
        }

        If frmEditor_Map.tabpages.SelectedTab Is frmEditor_Map.tpAttributes Then
            rec2.Size = New Vector2f(rec.Width, rec.Height)
        Else
            If EditorTileWidth = 1 And EditorTileHeight = 1 Then
                RenderTexture(frmEditor_Map.cmbTileSets.SelectedIndex + 1, GfxType.Tileset, Window, ConvertMapX(CurX * PicX), ConvertMapY(CurY * PicY), EditorTileSelStart.X * PicX, EditorTileSelStart.Y * PicY, rec.Width, rec.Height, rec.Width, rec.Height)

                rec2.Size = New Vector2f(rec.Width, rec.Height)
            Else
                If frmEditor_Map.cmbAutoTile.SelectedIndex > 0 Then
                    RenderTexture(frmEditor_Map.cmbTileSets.SelectedIndex + 1, GfxType.Tileset, Window, ConvertMapX(CurX * PicX), ConvertMapY(CurY * PicY), EditorTileSelStart.X * PicX, EditorTileSelStart.Y * PicY, rec.Width, rec.Height, rec.Width, rec.Height)

                    rec2.Size = New Vector2f(rec.Width, rec.Height)
                Else
                    RenderTexture(frmEditor_Map.cmbTileSets.SelectedIndex + 1, GfxType.Tileset, Window, ConvertMapX(CurX * PicX), ConvertMapY(CurY * PicY), EditorTileSelStart.X * PicX, EditorTileSelStart.Y * PicY, EditorTileSelEnd.X * PicX, EditorTileSelEnd.Y * PicY, EditorTileSelEnd.X * PicX, EditorTileSelEnd.Y * PicY)

                    rec2.Size = New Vector2f(EditorTileSelEnd.X * PicX, EditorTileSelEnd.Y * PicY)
                End If

            End If

        End If

        rec2.Position = New Vector2f(ConvertMapX(CurX * PicX), ConvertMapY(CurY * PicY))
        Window.Draw(rec2)
    End Sub

    Friend Sub DrawEyeDropper()
        Dim rec As New RectangleShape With {
        .OutlineColor = New Color(Color.Cyan),
        .OutlineThickness = 0.6,
        .FillColor = New Color(Color.Transparent),
        .Size = New Vector2f((PicX), (PicX)),
        .Position = New Vector2f(ConvertMapX((CurX) * PicX), ConvertMapY((CurY) * PicY))
        }

        Window.Draw(rec)
    End Sub

    Friend Sub DrawMapTint()

        If Map.MapTint = 0 Then Exit Sub

        MapTintSprite = New Sprite(New Texture(New Image(Window.Size.X, Window.Size.Y, Color.Black))) With {
            .Color = New Color(CurrentTintR, CurrentTintG, CurrentTintB, CurrentTintA),
            .TextureRect = New IntRect(0, 0, Window.Size.X, Window.Size.Y),
            .Position = New Vector2f(0, 0)
            }

        Window.Draw(MapTintSprite)
    End Sub

    Friend Sub DrawMapFade()
        If UseFade = False Then Exit Sub

        MapFadeSprite = New Sprite(New Texture(New Image(Window.Size.X, Window.Size.Y, Color.Black))) With {
            .Color = New Color(0, 0, 0, FadeAmount),
            .TextureRect = New IntRect(0, 0, Window.Size.X, Window.Size.Y),
            .Position = New Vector2f(0, 0)
            }

        Window.Draw(MapFadeSprite)
    End Sub

    Sub DestroyGraphics()
        For i = 0 To NumAnimations
            If Not AnimationTexture(i) Is Nothing Then AnimationTexture(i).Dispose()
        Next i

        For i = 0 To NumCharacters
            If Not CharacterTexture(i) Is Nothing Then CharacterTexture(i).Dispose()
        Next

        For i = 0 To NumItems
            If Not ItemTexture(i) Is Nothing Then ItemTexture(i).Dispose()
        Next

        For i = 0 To NumPaperdolls
            If Not PaperdollTexture(i) Is Nothing Then PaperdollTexture(i).Dispose()
        Next

        For i = 0 To NumResources
            If Not ResourceTexture(i) Is Nothing Then ResourceTexture(i).Dispose()
        Next

        For i = 0 To NumSkills
            If Not SkillTexture(i) Is Nothing Then SkillTexture(i).Dispose()
        Next

        For i = 0 To NumTileSets
            If Not TilesetTexture(i) Is Nothing Then TilesetTexture(i).Dispose()
        Next i

        For i = 0 To NumFogs
            If Not FogTexture(i) Is Nothing Then FogTexture(i).Dispose()
        Next

        For i = 0 To NumProjectiles
            If Not PaperdollTexture(i) Is Nothing Then PaperdollTexture(i).Dispose()
        Next

        For i = 0 To NumEmotes
            If Not EmoteTexture(i) Is Nothing Then EmoteTexture(i).Dispose()
        Next

        For i = 0 To NumPanorama
            If Not PanoramaTexture(i) Is Nothing Then PanoramaTexture(i).Dispose()
        Next

        For i = 0 To NumParallax
            If Not ParallaxTexture(i) Is Nothing Then ParallaxTexture(i).Dispose()
        Next

        For i = 0 To NumPictures
            If Not PictureTexture(i) Is Nothing Then PictureTexture(i).Dispose()
        Next

        For i = 0 To NumInterface
            If Not InterfaceTexture(i) Is Nothing Then InterfaceTexture(i).Dispose()
        Next

        For i = 0 To NumGradients
            If Not GradientTexture(i) Is Nothing Then GradientTexture(i).Dispose()
        Next

        For i = 0 To NumDesigns
            If Not DesignTexture(i) Is Nothing Then DesignTexture(i).Dispose()
        Next

        If Not BloodTexture Is Nothing Then BloodTexture.Dispose()
        If Not DirectionTexture Is Nothing Then DirectionTexture.Dispose()
        If Not TargetGfx Is Nothing Then TargetGfx.Dispose()
        If Not WeatherTexture Is Nothing Then WeatherTexture.Dispose()
        If Not EventChatGfx Is Nothing Then EventChatGfx.Dispose()
        If Not ChatBubbleGfx Is Nothing Then ChatBubbleGfx.Dispose()

        If Not LightGfx Is Nothing Then LightGfx.Dispose()
        If Not NightGfx Is Nothing Then NightGfx.Dispose()

        If Not CursorGfx Is Nothing Then CursorGfx.Dispose()
    End Sub

    Friend Function ToSfmlColor(toConvert As Drawing.Color) As Color
        Return New Color(toConvert.R, toConvert.G, toConvert.B, toConvert.A)
    End Function

    Friend Sub DrawTarget(x2 As Integer, y2 As Integer)
        Dim rec As Rectangle
        Dim x As Integer, y As Integer
        Dim width As Integer, height As Integer

        With rec
            .Y = 0
            .Height = TargetGfxInfo.Height
            .X = 0
            .Width = TargetGfxInfo.Width / 2
        End With

        x = ConvertMapX(x2 + 4)
        y = ConvertMapY(y2 - 32)
        width = (rec.Right - rec.Left)
        height = (rec.Bottom - rec.Top)

        RenderTexture(TargetSprite, Window, x, y, rec.X, rec.Y, rec.Width, rec.Height, rec.Width, rec.Height)
    End Sub

    Friend Sub DrawHover(x2 As Integer, y2 As Integer)
        Dim rec As Rectangle
        Dim x As Integer, y As Integer
        Dim width As Integer, height As Integer

        With rec
            .Y = 0
            .Height = TargetGfxInfo.Height
            .X = TargetGfxInfo.Width / 2
            .Width = TargetGfxInfo.Width / 2 + TargetGfxInfo.Width / 2
        End With

        x = ConvertMapX(x2 + 4)
        y = ConvertMapY(y2 - 32)
        width = (rec.Right - rec.Left)
        height = (rec.Bottom - rec.Top)

        RenderTexture(TargetSprite, Window, x, y, rec.X, rec.Y, rec.Width, rec.Height, rec.Width, rec.Height)
    End Sub

    Friend Sub EditorItem_DrawIcon()
        Dim itemnum As Integer
        itemnum = frmEditor_Item.nudIcon.Value

        If itemnum < 1 Or itemnum > NumItems Then
            frmEditor_Item.picItem.BackgroundImage = Nothing
            Exit Sub
        End If

        If File.Exists(Paths.Graphics & "items\" & itemnum & GfxExt) Then
            frmEditor_Item.picItem.BackgroundImage = Drawing.Image.FromFile(Paths.Graphics & "items\" & itemnum & GfxExt)
        Else
            frmEditor_Item.picItem.BackgroundImage = Nothing
        End If
    End Sub

    Friend Sub EditorItem_DrawPaperdoll()
        Dim Sprite As Integer

        Sprite = frmEditor_Item.nudPaperdoll.Value

        If Sprite < 1 Or Sprite > NumPaperdolls Then
            frmEditor_Item.picPaperdoll.BackgroundImage = Nothing
            Exit Sub
        End If

        If File.Exists(Paths.Graphics & "paperdolls\" & Sprite & GfxExt) Then
            frmEditor_Item.picPaperdoll.BackgroundImage =
                Drawing.Image.FromFile(Paths.Graphics & "paperdolls\" & Sprite & GfxExt)
        End If
    End Sub

    Friend Sub EditorNpc_DrawSprite()
        Dim Sprite As Integer

        Sprite = frmEditor_NPC.nudSprite.Value

        If Sprite < 1 Or Sprite > NumCharacters Then
            frmEditor_NPC.picSprite.BackgroundImage = Nothing
            Exit Sub
        End If

        If File.Exists(Paths.Graphics & "characters\" & Sprite & GfxExt) Then
            frmEditor_NPC.picSprite.Width =
                Drawing.Image.FromFile(Paths.Graphics & "characters\" & Sprite & GfxExt).Width / 4
            frmEditor_NPC.picSprite.Height =
                Drawing.Image.FromFile(Paths.Graphics & "characters\" & Sprite & GfxExt).Height / 4
            frmEditor_NPC.picSprite.BackgroundImage =
                Drawing.Image.FromFile(Paths.Graphics & "characters\" & Sprite & GfxExt)
        End If
    End Sub

    Friend Sub EditorResource_DrawSprite()
        Dim Sprite As Integer

        ' normal sprite
        Sprite = frmEditor_Resource.nudNormalPic.Value

        If Sprite < 1 Or Sprite > NumResources Then
            frmEditor_Resource.picNormalpic.BackgroundImage = Nothing
        Else
            If File.Exists(Paths.Graphics & "resources\" & Sprite & GfxExt) Then
                frmEditor_Resource.picNormalpic.BackgroundImage =
                    Drawing.Image.FromFile(Paths.Graphics & "resources\" & Sprite & GfxExt)
            End If
        End If

        ' exhausted sprite
        Sprite = frmEditor_Resource.nudExhaustedPic.Value

        If Sprite < 1 Or Sprite > NumResources Then
            frmEditor_Resource.picExhaustedPic.BackgroundImage = Nothing
        Else
            If File.Exists(Paths.Graphics & "resources\" & Sprite & GfxExt) Then
                frmEditor_Resource.picExhaustedPic.BackgroundImage =
                    Drawing.Image.FromFile(Paths.Graphics & "resources\" & Sprite & GfxExt)
            End If
        End If
    End Sub

    Friend Sub EditorEvent_DrawPicture()
        Dim Sprite As Integer

        Sprite = frmEditor_Events.nudShowPicture.Value

        If Sprite < 1 Or Sprite > NumPictures Then
            frmEditor_Events.picShowPic.BackgroundImage = Nothing
            Exit Sub
        End If

        If File.Exists(Paths.Graphics & "pictures\" & Sprite & GfxExt) Then
            frmEditor_Events.picShowPic.Width =
                Drawing.Image.FromFile(Paths.Graphics & "pictures\" & Sprite & GfxExt).Width
            frmEditor_Events.picShowPic.Height =
                Drawing.Image.FromFile(Paths.Graphics & "pictures\" & Sprite & GfxExt).Height
            frmEditor_Events.picShowPic.BackgroundImage =
                Drawing.Image.FromFile(Paths.Graphics & "pictures\" & Sprite & GfxExt)
        End If
    End Sub

    Public Sub DrawNight()
        Dim x = 0
        Dim y = 0

        If InGame = False Then Exit Sub
        If NightGfx Is Nothing Then Exit Sub
        If GettingMap Then Exit Sub
        If Editor = EditorType.Map And Night = False Then Exit Sub

        If Map.Indoors Then
            Exit Sub
        End If

        If TileLights Is Nothing Then
            TileLights = New List(Of LightTileStruct)()

            For x = 0 To Map.MaxX

                For y = 0 To Map.MaxY

                    If IsValidMapPoint(x, y) Then

                        If Map.Tile(x, y).Type = TileType.Light Or Map.Tile(x, y).Type2 = TileType.Light Then

                            If Map.Tile(x, y).Data3 = 1 Then
                                Dim tiles As List(Of Vector2i) = AppendFov(x, y, Map.Tile(x, y).Data1, True)
                                tiles.Add(New Vector2i(x, y))
                                Dim scale = New Vector2f()

                                If Map.Tile(x, y).Data2 = 1 Then
                                    Dim r = CSng(RandomNumberBetween(-0.01F, 0.01F))
                                    scale = New Vector2f(0.35F + r, 0.35F + r)
                                Else
                                    scale = New Vector2f(0.35F, 0.35F)
                                End If

                                If Types.Settings.DynamicLightRendering Then

                                    For Each tile As Vector2i In tiles
                                        LightSprite.Scale = scale
                                        LightSprite.Position =
                                            New Vector2f(
                                                (ConvertMapX(tile.X * 32) - (LightGfx.Size.X / 2 * LightSprite.Scale.X) + 16),
                                                (ConvertMapY(tile.Y * 32) - (LightGfx.Size.Y / 2 * LightSprite.Scale.Y) + 16))
                                        Dim dist = CByte(((Math.Abs(x - tile.X) + Math.Abs(y - tile.Y))))
                                        LightSprite.Color = New Color(0, 0, 0, 255)
                                        Window.Draw(LightSprite, New RenderStates(BlendMode.Multiply))
                                    Next

                                    TileLights.Add(New LightTileStruct() With {
.Tiles = tiles,
.IsFlicker = Map.Tile(x, y).Data2 = 1,
                                                          .Scale = New Vector2f(0.35F, 0.35F)
                                                          })
                                Else
                                    Dim alphaBump As Byte

                                    If Map.Tile(x, y).Data1 = 0 Then
                                        alphaBump = 255
                                    Else
                                        alphaBump = CByte((255 / (Map.Tile(x, y).Data1)))
                                    End If

                                    For Each tile As Vector2i In tiles
                                        LightDynamicSprite.Scale = scale
                                        LightDynamicSprite.Position = New Vector2f((ConvertMapX(tile.X * 32)),
                                                                                   (ConvertMapY(tile.Y * 32)))
                                        Dim dist = CByte(((Math.Abs(x - tile.X) + Math.Abs(y - tile.Y))))
                                        LightDynamicSprite.Color = New Color(0, 0, 0,
                                                                             CByte(Clamp((alphaBump * dist), 0, 255)))
                                        Window.Draw(LightDynamicSprite, New RenderStates(BlendMode.Multiply))
                                    Next

                                    TileLights.Add(New LightTileStruct() With {
                                                            .Tiles = tiles,
                                                            .IsFlicker = Map.Tile(x, y).Data2 = 1,
                                                            .Scale = New Vector2f(0.35F, 0.35F)
                                                            })
                                End If
                            Else
                                LightSprite.Color = Color.Red
                                Dim scale = New Vector2f()

                                If Map.Tile(x, y).Data2 = 1 Then
                                    Dim r = CSng(RandomNumberBetween(-0.01F, 0.01F))
                                    scale = New Vector2f(0.3F * Map.Tile(x, y).Data1 + r, 0.3F * Map.Tile(x, y).Data1 + r)
                                Else
                                    scale = New Vector2f(0.3F * Map.Tile(x, y).Data1, 0.3F * Map.Tile(x, y).Data1)
                                End If

                                LightSprite.Scale = scale
                                Dim x1 = (ConvertMapX(x * 32) + 16 - CDbl((LightGfxInfo.Width * scale.X)) / 2)
                                Dim y1 = (ConvertMapY(y * 32) + 16 - CDbl((LightGfxInfo.Height * scale.Y)) / 2)
                                LightSprite.Position = New Vector2f(CSng(x1), CSng(y1))
                                TileLights.Add(New LightTileStruct() With { .Tiles = New List(Of Vector2i)() From { New Vector2i(x, y)}, .IsFlicker = Map.Tile(x, y).Data2 = 1, .Scale = New Vector2f(0.3F * Map.Tile(x, y).Data1, 0.3F * Map.Tile(x, y).Data1)})
                                Window.Draw(LightSprite, New RenderStates(BlendMode.Multiply))
                            End If
                        End If
                    End If
                Next
            Next
        Else

            For Each light As LightTileStruct In TileLights
                Dim scale = New Vector2f()

                If light.IsFlicker Then
                    Dim r = CSng(RandomNumberBetween(-0.004F, 0.004F))
                    scale = New Vector2f(light.Scale.X + r, light.Scale.Y + r)
                Else
                    scale = light.Scale
                End If

                For Each tile As Vector2i In light.Tiles

                    If light.IsSmooth = False Then
                        LightSprite.Scale = scale
                        LightSprite.Position =
                            New Vector2f((ConvertMapX(tile.X * 32) - (LightGfx.Size.X / 2 * LightSprite.Scale.X) + 16),
                                         (ConvertMapY(tile.Y * 32) - (LightGfx.Size.Y / 2 * LightSprite.Scale.Y) + 16))
                        Dim dist = CByte(((Math.Abs(x - tile.X) + Math.Abs(y - tile.Y))))
                        LightSprite.Color = New Color(0, 0, 0, 255)
                        Window.Draw(LightSprite, New RenderStates(BlendMode.Multiply))
                    Else
                        Dim alphaBump As Byte

                        If Map.Tile(x, y).Data1 = 0 Then
                            alphaBump = 255
                        Else
                            alphaBump = CByte((255 / (Map.Tile(x, y).Data1)))
                        End If

                        LightDynamicSprite = New Sprite
                        LightDynamicSprite.Scale = scale
                        LightDynamicSprite.Position = New Vector2f((ConvertMapX(tile.X * 32)), (ConvertMapY(tile.Y * 32)))
                        Dim dist = CByte(((Math.Abs(x - tile.X) + Math.Abs(y - tile.Y))))
                        LightDynamicSprite.Color = New Color(0, 0, 0, CByte(Clamp((alphaBump * dist), 0, 255)))
                        Window.Draw(LightDynamicSprite, New RenderStates(BlendMode.Multiply))
                    End If
                Next
            Next
        End If

        Dim x2 = ConvertMapX(Player(MyIndex).X * 32) + 56 + Player(MyIndex).XOffset - CDbl(LightGfxInfo.Width) / 2
        Dim y2 = ConvertMapY(Player(MyIndex).Y * 32) + 56 + Player(MyIndex).YOffset - CDbl(LightGfxInfo.Height) / 2
        LightSprite.Position = New Vector2f(CSng(x2), CSng(y2))
        LightSprite.Color = Color.Red
        LightSprite.Scale = New Vector2f(0.7F, 0.7F)
        Window.Draw(LightSprite, New RenderStates(BlendMode.Multiply))
        NightSprite = New Sprite(NightGfx)
        Window.Draw(NightSprite)
    End Sub

    Friend Sub EditorSkill_DrawIcon()
        Dim skillNum As Integer
        skillNum = frmEditor_Skill.nudIcon.Value

        If skillNum < 1 Or skillNum > NumItems Then
            frmEditor_Skill.picSprite.BackgroundImage = Nothing
            Exit Sub
        End If

        If File.Exists(Paths.Graphics & "Skills\" & skillNum & GfxExt) Then
            frmEditor_Skill.picSprite.BackgroundImage = Drawing.Image.FromFile(Paths.Graphics & "Skills\" & skillNum & GfxExt)
        Else
            frmEditor_Skill.picSprite.BackgroundImage = Nothing
        End If
    End Sub

    Friend Sub EditorAnim_DrawAnim()
        Dim animationNum As Integer
        Dim sRECT As Rectangle
        Dim dRECT As Rectangle
        Dim width As Integer, height As Integer
        Dim looptime As Integer
        Dim FrameCount As Integer
        Dim ShouldRender As Boolean

        animationNum = frmEditor_Animation.nudSprite0.Value

        If animationNum < 1 Or animationNum > NumAnimations Then
            EditorAnimation_Anim1.Clear(ToSfmlColor(frmEditor_Animation.picSprite0.BackColor))
            EditorAnimation_Anim1.Display()
        Else
            looptime = frmEditor_Animation.nudLoopTime0.Value
            FrameCount = frmEditor_Animation.nudFrameCount0.Value

            ShouldRender = False

            ' check if we need to render new frame
            If AnimEditorTimer(0) + looptime <= GetTickCount() Then
                ' check if out of range
                If AnimEditorFrame(0) >= FrameCount Then
                    AnimEditorFrame(0) = 1
                Else
                    AnimEditorFrame(0) = AnimEditorFrame(0) + 1
                End If
                AnimEditorTimer(0) = GetTickCount()
                ShouldRender = True
            End If

            If ShouldRender Then
                If frmEditor_Animation.nudFrameCount0.Value > 0 Then
                    ' total width divided by frame count
                    height = AnimationGfxInfo(animationNum).Height
                    width = AnimationGfxInfo(animationNum).Width / frmEditor_Animation.nudFrameCount0.Value
                    With sRECT
                        .Y = 0
                        .Height = height
                        .X = (AnimEditorFrame(0) - 1) * width
                        .Width = width
                    End With

                    With dRECT
                        .Y = 0
                        .Height = height
                        .X = 0
                        .Width = width
                    End With

                    EditorAnimation_Anim1.Clear(ToSfmlColor(frmEditor_Animation.picSprite0.BackColor))
                    RenderTexture(animationNum, GfxType.Animation, EditorAnimation_Anim1, dRECT.X, dRECT.Y, sRECT.X,
                                 sRECT.Y, sRECT.Width, sRECT.Height, dRECT.Width, dRECT.Height)
                    EditorAnimation_Anim1.Display()
                End If
            End If
        End If

        animationNum = frmEditor_Animation.nudSprite1.Value

        If animationNum < 1 Or animationNum > NumAnimations Then
            EditorAnimation_Anim2.Clear(ToSfmlColor(frmEditor_Animation.picSprite1.BackColor))
            EditorAnimation_Anim2.Display()
        Else
            looptime = frmEditor_Animation.nudLoopTime1.Value
            FrameCount = frmEditor_Animation.nudFrameCount1.Value
            ShouldRender = False

            ' check if we need to render new frame
            If AnimEditorTimer(1) + looptime <= GetTickCount() Then
                ' check if out of range
                If AnimEditorFrame(1) >= FrameCount Then
                    AnimEditorFrame(1) = 1
                Else
                    AnimEditorFrame(1) = AnimEditorFrame(1) + 1
                End If
                AnimEditorTimer(1) = GetTickCount()
                ShouldRender = True
            End If

            If ShouldRender Then
                If frmEditor_Animation.nudFrameCount1.Value > 0 Then
                    ' total width divided by frame count
                    height = AnimationGfxInfo(animationNum).Height
                    width = AnimationGfxInfo(animationNum).Width / frmEditor_Animation.nudFrameCount1.Value
                    With sRECT
                        .Y = 0
                        .Height = height
                        .X = (AnimEditorFrame(1) - 1) * width
                        .Width = width
                    End With

                    With dRECT
                        .Y = 0
                        .Height = height
                        .X = 0
                        .Width = width
                    End With

                    EditorAnimation_Anim2.Clear(ToSfmlColor(frmEditor_Animation.picSprite1.BackColor))
                    RenderTexture(animationNum, GfxType.Animation, EditorAnimation_Anim2, dRECT.X, dRECT.Y, sRECT.X,
                                 sRECT.Y, sRECT.Width, sRECT.Height, dRECT.Height, dRECT.Width)
                    EditorAnimation_Anim2.Display()
                End If
            End If
        End If
    End Sub

    Public flickerRandom As Random = New Random()

    Private Function RandomNumberBetween(minValue As Double, maxValue As Double) As Double
        Dim [next] = flickerRandom.NextDouble()
        Return minValue + ([next] * (maxValue - minValue))
    End Function

    Private Function Clamp(value As Integer, min As Integer, max As Integer) As Integer
        Return If((value < min), min, If((value > max), max, value))
    End Function

    Private Function GetCellsInSquare(xCenter As Integer, yCenter As Integer, distance As Integer) As List(Of Vector2i)
        Dim xMin As Integer = Math.Max(0, xCenter - distance)
        Dim xMax As Integer = Math.Min(Map.MaxX, xCenter + distance)
        Dim yMin As Integer = Math.Max(0, yCenter - distance)
        Dim yMax As Integer = Math.Min(Map.MaxY, yCenter + distance)
        Dim cells = New List(Of Vector2i)()

        For y As Integer = yMin To yMax
            For x As Integer = xMin To xMax
                cells.Add(New Vector2i(x, y))
            Next
        Next
        Return cells
    End Function

    Private Function GetBorderCellsInSquare(xCenter As Integer, yCenter As Integer, distance As Integer) _
        As List(Of Vector2i)
        Dim xMin As Integer = Math.Max(0, xCenter - distance)
        Dim xMax As Integer = Math.Min(Map.MaxX, xCenter + distance)
        Dim yMin As Integer = Math.Max(0, yCenter - distance)
        Dim yMax As Integer = Math.Min(Map.MaxY, yCenter + distance)
        Dim borderCells = New List(Of Vector2i)()

        For x As Integer = xMin To xMax
            borderCells.Add(New Vector2i(x, yMin))
            borderCells.Add(New Vector2i(x, yMax))
        Next

        For y As Integer = yMin + 1 To yMax - 1
            borderCells.Add(New Vector2i(xMin, y))
            borderCells.Add(New Vector2i(xMax, y))
        Next

        Dim centerCell = New Vector2i(xCenter, yCenter)
        borderCells.Remove(centerCell)
        Return borderCells
    End Function

    Private Function line(x As Integer, y As Integer, xDestination As Integer, yDestination As Integer) _
        As List(Of Vector2i)
        Dim discovered = New HashSet(Of Vector2i)()
        Dim litTiles = New List(Of Vector2i)()
        Dim dx As Integer = Math.Abs(xDestination - x)
        Dim dy As Integer = Math.Abs(yDestination - y)
        Dim sx As Integer = If(x < xDestination, 1, -1)
        Dim sy As Integer = If(y < yDestination, 1, -1)
        Dim err As Integer = dx - dy

        While True
            Dim pos = New Vector2i(x, y)

            If discovered.Add(pos) Then
                litTiles.Add(pos)
            End If

            If x = xDestination And y = yDestination Then
                Exit While
            End If

            Dim e2 As Integer = 2 * err

            If e2 > -dy Then
                err = err - dy
                x = x + sx
            ElseIf e2 < dx Then
                err = err + dx
                y = y + sy
            End If
        End While

        Return litTiles
    End Function

    Private Function AppendFov(xOrigin As Integer, yOrigin As Integer, radius As Integer, lightWalls As Boolean) _
        As List(Of Vector2i)
        Dim _inFov = New List(Of Vector2i)()

        For Each borderCell As Vector2i In GetBorderCellsInSquare(xOrigin, yOrigin, radius)

            For Each cell As Vector2i In line(xOrigin, yOrigin, borderCell.X, borderCell.Y)

                If (Math.Abs(cell.X - xOrigin) + Math.Abs(cell.Y - yOrigin)) > radius Then
                    Exit For
                End If

                If IsTransparent(cell.X, cell.Y) Then
                    _inFov.Add(cell)
                Else

                    If lightWalls Then
                        _inFov.Add(cell)
                    End If

                    Exit For
                End If
            Next
        Next

        If lightWalls Then

            For Each cell As Vector2i In GetCellsInSquare(xOrigin, yOrigin, radius)

                If cell.X > xOrigin Then

                    If cell.Y > yOrigin Then
                        PostProcessFovQuadrant(_inFov, cell.X, cell.Y, QuadrantType.SE)
                    ElseIf cell.Y < yOrigin Then
                        PostProcessFovQuadrant(_inFov, cell.X, cell.Y, QuadrantType.NE)
                    End If
                ElseIf cell.X < xOrigin Then

                    If cell.Y > yOrigin Then
                        PostProcessFovQuadrant(_inFov, cell.X, cell.Y, QuadrantType.SW)
                    ElseIf cell.Y < yOrigin Then
                        PostProcessFovQuadrant(_inFov, cell.X, cell.Y, QuadrantType.NW)
                    End If
                End If
            Next
        End If

        Return _inFov
    End Function

    Private Sub PostProcessFovQuadrant(ByRef _inFov As List(Of Vector2i), x As Integer, y As Integer,
                                       quadrant As QuadrantType)
        Dim x1 As Integer = x
        Dim y1 As Integer = y
        Dim x2 As Integer = x
        Dim y2 As Integer = y
        Dim pos = New Vector2i(x, y)

        Select Case quadrant
            Case quadrant.NE
                y1 = y + 1
                x2 = x - 1
                Exit Select
            Case quadrant.SE
                y1 = y - 1
                x2 = x - 1
                Exit Select
            Case quadrant.SW
                y1 = y - 1
                x2 = x + 1
                Exit Select
            Case quadrant.NW
                y1 = y + 1
                x2 = x + 1
                Exit Select
        End Select

        If Not _inFov.Contains(pos) And Not IsTransparent(x, y) Then
            If _
                (IsTransparent(x1, y1) And _inFov.Contains(New Vector2i(x1, y1))) Or
                (IsTransparent(x2, y2) And _inFov.Contains(New Vector2i(x2, y2))) Or
                (IsTransparent(x2, y1) And _inFov.Contains(New Vector2i(x2, y1))) Then
                _inFov.Add(pos)
            End If
        End If
    End Sub

    Private Function IsTransparent(x As Integer, y As Integer) As Boolean
        If Map.Tile(x, y).Type = TileType.Blocked Or Map.Tile(x, y).Type2 = TileType.Blocked Then
            Return False
        End If

        Return True
    End Function

    Private Function AddToHashSet(hashSet As HashSet(Of Vector2i), x As Integer, y As Integer, centerCell As Vector2i,
                                  <Out> ByRef cell As Vector2i) As Boolean
        cell = New Vector2i(x, y)

        If Not IsValidMapPoint(x, y) Or Map.Tile(x, y).Type = TileType.Blocked Or Map.Tile(x, y).Type2 = TileType.Blocked Then
            Return False
        End If

        If x = Player(MyIndex).X And y = Player(MyIndex).Y Then
            Return False
        End If

        If cell.Equals(centerCell) Then
            Return False
        End If

        Return hashSet.Add(cell)
    End Function

    Sub DrawMenuBG()
        ' row 1
        RenderTexture(1, GfxType.Picture, Window, ResolutionWidth - 512, ResolutionHeight - 512, 0, 0, 512, 512, 512, 512)
        RenderTexture(2, GfxType.Picture, Window, ResolutionWidth - 1024, ResolutionHeight - 512, 0, 0, 512, 512, 512, 512)
        RenderTexture(3, GfxType.Picture, Window, ResolutionWidth - 1536, ResolutionHeight - 512, 0, 0, 512, 512, 512, 512)
        RenderTexture(4, GfxType.Picture, Window, ResolutionWidth - 2048, ResolutionHeight - 512, 0, 0, 512, 512, 512, 512)
       
        ' row 2
        RenderTexture(5, GfxType.Picture, Window, ResolutionWidth - 512, ResolutionHeight - 1024, 0, 0, 512, 512, 512, 512)
        RenderTexture(6, GfxType.Picture, Window, ResolutionWidth - 1024, ResolutionHeight - 1024, 0, 0, 512, 512, 512, 512)
        RenderTexture(7, GfxType.Picture, Window, ResolutionWidth - 1536, ResolutionHeight - 1024, 0, 0, 512, 512, 512, 512)
        RenderTexture(8, GfxType.Picture, Window, ResolutionWidth - 2048, ResolutionHeight - 1024, 0, 0, 512, 512, 512, 512)
        
        ' row 3
        RenderTexture(9, GfxType.Picture, Window, ResolutionWidth - 512, ResolutionHeight - 1088, 0, 0, 512, 64, 512, 64)
        RenderTexture(10, GfxType.Picture, Window, ResolutionWidth - 1024, ResolutionHeight - 1088, 0, 0, 512, 64, 512, 64)
        RenderTexture(11, GfxType.Picture, Window, ResolutionWidth - 1536, ResolutionHeight - 1088, 0, 0, 512, 64, 512, 64)
        RenderTexture(12, GfxType.Picture, Window, ResolutionWidth - 2048, ResolutionHeight - 1088, 0, 0, 512, 64, 512, 64)
    End Sub

    Public Sub DrawHotbar()
        Dim xO As Long, yO As Long, Width As Long, Height As Long, i As Long, t As Long, sS As String

        xO = Windows(GetWindowIndex("winHotbar")).Window.Left
        yO = Windows(GetWindowIndex("winHotbar")).Window.Top

        ' Render start + end wood
        RenderTexture(31, GfxType.GUI, Window, xO - 1, yO + 3, 0, 0, 11, 26, 11, 26)
        RenderTexture(31, GfxType.GUI, Window, xO + 407, yO + 3, 0, 0, 11, 26, 11, 26)

        For i = 1 To MAX_HOTBAR
            xO = Windows(GetWindowIndex("winHotbar")).Window.Left + HotbarLeft + ((i - 1) * HotbarOffsetX)
            yO = Windows(GetWindowIndex("winHotbar")).Window.Top + HotbarTop
            Width = 36
            Height = 36

            ' Don't render last one
            If i <> MAX_HOTBAR Then
                ' Render wood
                RenderTexture(32, GfxType.GUI, Window, xO + 30, yO + 3, 0, 0, 13, 26, 13, 26)
            End If

            ' Render box
            RenderTexture(30, GfxType.GUI, Window, xO - 2, yO - 2, 0, 0, Width, Height, Width, Height)

            ' Render icon
            If Not (DragBox.Origin = PartOriginType.Hotbar And DragBox.Slot = i) Then
                Select Case Player(MyIndex).Hotbar(i).SlotType
                    Case PartOriginType.Inventory
                        StreamItem(Player(MyIndex).Hotbar(i).Slot)
                        If Len(Item(Player(MyIndex).Hotbar(i).Slot).Name) > 0 And Item(Player(MyIndex).Hotbar(i).Slot).Icon > 0 Then
                            RenderTexture(Item(Player(MyIndex).Hotbar(i).Slot).Icon, GfxType.Item, Window, xO, yO, 0, 0, 32, 32, 32, 32)
                        End If

                    Case PartOriginType.Skill
                        StreamSkill(Player(MyIndex).Hotbar(i).Slot)
                        If Len(Skill(Player(MyIndex).Hotbar(i).Slot).Name) > 0 And Skill(Player(MyIndex).Hotbar(i).Slot).Icon > 0 Then
                            RenderTexture(Skill(Player(MyIndex).Hotbar(i).Slot).Icon, GfxType.Skill, Window, xO, yO, 0, 0, 32, 32, 32, 32)
                            For t = 1 To MAX_PLAYER_SKILLS
                                If GetPlayerSkill(MyIndex, t) > 0 Then
                                    If GetPlayerSkill(MyIndex, t) = Player(MyIndex).Hotbar(i).Slot And GetPlayerSkillCD(MyIndex, t) > 0 Then
                                        RenderTexture(Skill(Player(MyIndex).Hotbar(i).Slot).Icon, GfxType.Skill, Window, xO, yO, 0, 0, 32, 32, 32, 32, 255, 100, 100, 100)
                                    End If
                                End If
                            Next
                        End If
                End Select
            End If

            ' Draw the numbers
            sS = Str(i)
            If i = MAX_HOTBAR Then sS = "0"
            RenderText(sS, Window, xO + 4, yO + 19, Color.White, Color.White)
        Next
    End Sub

    Public Sub DrawChatBubble(ByVal Index As Long)
        Dim theArray() As String, x As Long, y As Long, i As Long, MaxWidth As Long, x2 As Long, y2 As Long, Color As Integer, tmpNum As Long
    
        With chatBubble(Index)
            ' exit out early
            If .target = 0 Then Exit Sub

            Color = .Color

            ' calculate position
            Select Case .TargetType
                Case TargetType.Player
                    ' it's a player
                    If Not GetPlayerMap(.target) = GetPlayerMap(MyIndex) Then Exit Sub

                    ' it's on our map - get co-ords
                    x = ConvertMapX((Player(.target).x * 32) + Player(.target).xOffset) + 16
                    y = ConvertMapY((Player(.target).y * 32) + Player(.target).yOffset) - 32
                Case TargetType.Event
                    x = ConvertMapX(map.Events(.target).x * 32) + 16
                    y = ConvertMapY(map.Events(.target).y * 32) - 16
                Case Else
                    Exit Sub
            End Select
        
            ' word wrap
            WordWrap_Array(.Msg, ChatBubbleWidth, theArray)

            ' find max width
            tmpNum = UBound(theArray)

            For i = 1 To tmpNum
                If TextWidth(theArray(i), 15) > MaxWidth Then MaxWidth = TextWidth(theArray(i), 15)
            Next

            ' calculate the new position
            x2 = x - (MaxWidth \ 2)
            y2 = y - (UBound(theArray) * 12)

            ' render bubble - top left
            RenderTexture(33, GfxType.GUI, Window, x2 - 9, y2 - 5, 0, 0, 9, 5, 9, 5)

            ' top right
            RenderTexture(33, GfxType.GUI, Window, x2 + MaxWidth, y2 - 5, 119, 0, 9, 5, 9, 5)

            ' top
            RenderTexture(33, GfxType.GUI, Window, x2, y2 - 5, 9, 0, MaxWidth, 5, 5, 5)

            ' bottom left
            RenderTexture(33, GfxType.GUI, Window, x2 - 9, y, 0, 19, 9, 6, 9, 6)

            ' bottom right
            RenderTexture(33, GfxType.GUI, Window, x2 + MaxWidth, y, 119, 19, 9, 6, 9, 6)

            ' bottom - left half
            RenderTexture(33, GfxType.GUI, Window, x2, y, 9, 19, (MaxWidth \ 2) - 5, 6, 6, 6)

            ' bottom - right half
            RenderTexture(33, GfxType.GUI, Window, x2 + (MaxWidth \ 2) + 6, y, 9, 19, (MaxWidth \ 2) - 5, 6, 9, 6)

            ' left
            RenderTexture(33, GfxType.GUI, Window, x2 - 9, y2, 0, 6, 9, (UBound(theArray) * 12), 9, 6)

            ' right
            RenderTexture(33, GfxType.GUI, Window, x2 + MaxWidth, y2, 119, 6, 9, (UBound(theArray) * 12), 9, 6)

            ' center
            RenderTexture(33, GfxType.GUI, Window, x2, y2, 9, 5, MaxWidth, (UBound(theArray) * 12), 9, 5)

            ' little pointy bit
            RenderTexture(33, GfxType.GUI, Window, x - 5, y, 58, 19, 11, 11, 11, 11)

            ' render each line centralized
            tmpNum = UBound(theArray)

            For i = 1 To tmpNum           
                RenderText(theArray(i), Window, x - (theArray(i).Length / 2) - (TextWidth(theArray(i)) / 2), y2, GetSfmlColor(.Color), SFML.Graphics.Color.Black)
                y2 = y2 + 12
            Next

            ' check if it's timed out - close it if so
            If .timer + 5000 < GetTickCount Then
                .active = False
            End If
        End With
    End Sub
#End Region

End Module