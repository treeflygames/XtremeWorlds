﻿Imports System.IO
Imports System.Runtime.InteropServices
Imports SFML.Graphics
Imports SFML.System
Imports Core
Imports SFML.Window

Module C_Graphics

#Region "Declarations"

    Friend GameWindow As RenderWindow
    Friend TilesetWindow As RenderWindow
    Friend WindowSettings As ContextSettings

    Friend EditorSkill_Icon As RenderWindow
    Friend EditorAnimation_Anim1 As RenderWindow
    Friend EditorAnimation_Anim2 As RenderWindow

    Friend Fonts([Enum].FontType.Count - 1) As Font

    'TileSets
    Friend TilesetTexture() As Texture
    Friend TilesetSprite() As Sprite
    Friend TilesetGfxInfo() As GraphicInfo

    'Characters
    Friend CharacterTexture() As Texture
    Friend CharacterSprite() As Sprite
    Friend CharacterGfxInfo() As GraphicInfo

    'Paperdolls
    Friend PaperdollTexture() As Texture
    Friend PaperdollSprite() As Sprite
    Friend PaperdollGfxInfo() As GraphicInfo

    'Items
    Friend ItemTexture() As Texture
    Friend ItemSprite() As Sprite
    Friend ItemGfxInfo() As GraphicInfo

    'Resources
    Friend ResourceTexture() As Texture
    Friend ResourceSprite() As Sprite
    Friend ResourceGfxInfo() As GraphicInfo

    'Animations
    Friend AnimationTexture() As Texture
    Friend AnimationSprite() As Sprite
    Friend AnimationGfxInfo() As GraphicInfo

    'Skills
    Friend SkillIconTexture() As Texture
    Friend SkillIconSprite() As Sprite
    Friend SkillIconGfxInfo() As GraphicInfo

    'Faces
    Friend FaceTexture() As Texture
    Friend FaceSprite() As Sprite
    Friend FaceGfxInfo() As GraphicInfo

    'Projectiles
    Friend ProjectileTexture() As Texture
    Friend ProjectileSprite() As Sprite
    Friend ProjectileGfxInfo() As GraphicInfo

    'Fogs
    Friend FogTexture() As Texture
    Friend FogSprite() As Sprite
    Friend FogGfxInfo() As GraphicInfo

    'Emotes
    Friend EmoteTexture() As Texture
    Friend EmoteSprite() As Sprite
    Friend EmoteGfxInfo() As GraphicInfo

    'Panoramas
    Friend PanoramaTexture() As Texture
    Friend PanoramaSprite() As Sprite
    Friend PanoramaGfxInfo() As GraphicInfo

    'Parallax
    Friend ParallaxTexture() As Texture
    Friend ParallaxSprite() As Sprite
    Friend ParallaxGfxInfo() As GraphicInfo

    'Pictures
    Friend PictureTexture() As Texture
    Friend PictureSprite() As Sprite
    Friend PictureGfxInfo() As GraphicInfo

    'Blood
    Friend BloodTexture As Texture
    Friend BloodSprite As Sprite
    Friend BloodGfxInfo As GraphicInfo

    'Directions
    Friend DirectionTexture As Texture
    Friend DirectionSprite As Sprite
    Friend DirectionGfxInfo As GraphicInfo

    'Weather
    Friend WeatherTexture As Texture
    Friend WeatherSprite As Sprite
    Friend WeatherGfxInfo As GraphicInfo

    'GUI
    Friend InterfaceTexture() As Texture
    Friend InterfaceSprite() As Sprite
    Friend InterfaceGfxInfo() As GraphicInfo
    Friend DesignTexture() As Texture
    Friend DesignSprite() As Sprite
    Friend DesignGfxInfo() As GraphicInfo
    Friend GradientTexture() As Texture
    Friend GradientSprite() As Sprite
    Friend GradientGfxInfo() As GraphicInfo

    'Bars
    Friend HpBarTextire As Texture
    Friend HpBarSprite As Sprite
    Friend HpBarGfxInfo As GraphicInfo
    Friend MpBarGfx As Texture
    Friend MpBarSprite As Sprite
    Friend MpBarGfxInfo As GraphicInfo

    Friend EventChatGfx As Texture
    Friend EventChatSprite As Sprite
    Friend EventChatGfxInfo As GraphicInfo

    Friend TargetGfx As Texture
    Friend TargetSprite As Sprite
    Friend TargetGfxInfo As GraphicInfo

    Friend ProgBarGfx As Texture
    Friend ProgBarSprite As Sprite
    Friend ProgBarGfxInfo As GraphicInfo

    Friend RClickGfx As Texture
    Friend RClickSprite As Sprite
    Friend RClickGfxInfo As GraphicInfo

    Friend ChatBubbleGfx As Texture
    Friend ChatBubbleSprite As Sprite
    Friend ChatBubbleGfxInfo As GraphicInfo

    Friend PetStatTexture As Texture
    Friend PetStatSprite As Sprite
    Friend PetStatGfxInfo As GraphicInfo

    Friend PetBarGfx As Texture
    Friend PetBarSprite As Sprite
    Friend PetbarGfxInfo As GraphicInfo

    Friend MapTintGfx As Texture
    Friend MapTintSprite As Sprite

    Friend MapFadeSprite As Sprite

    ' Number of graphic files
    Friend NumTileSets As Integer
    Friend NumCharacters As Integer
    Friend NumPaperdolls As Integer
    Friend NumItems As Integer
    Friend NumResources As Integer
    Friend NumAnimations As Integer
    Friend NumSkillIcons As Integer
    Friend NumFaces As Integer
    Friend NumFogs As Integer
    Friend NumEmotes As Integer
    Friend NumPanorama As Integer
    Friend NumParallax As Integer
    Friend NumPictures As Integer
    Friend NumInterface As Integer
    Friend NumGradients As Integer
    Friend NumDesigns As Integer

    ' Day/Night
    Friend NightGfx As Texture
    Friend NightSprite As Sprite
    Friend LightGfx As Texture
    Friend LightDynamicGfx As Texture
    Friend LightSprite As Sprite
    Friend LightDynamicSprite As Sprite
    Friend LightGfxInfo As GraphicInfo

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
    Private Sub GameWindow_GainedFocus(ByVal sender As Object, ByVal e As EventArgs)
        Console.WriteLine("Window Gained Focus")
    End Sub

    Private Sub GameWindow_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        Console.WriteLine("Window Lost Focus")
    End Sub

    Private Sub GameWindow_KeyPressed(ByVal sender As Object, ByVal e As SFML.Window.KeyEventArgs)
        Console.WriteLine("Key Pressed: " & e.Code.ToString())

        If Inputs.MoveUp(e.Code) Then VbKeyUp = True
        If Inputs.MoveDown(e.Code) Then VbKeyDown = True
        If Inputs.MoveLeft(e.Code) Then VbKeyLeft = True
        If Inputs.MoveRight(e.Code) Then VbKeyRight = True
        If Inputs.Attack(e.Code) Then VbKeyControl = True
        If Inputs.Run(e.Code) Then VbKeyShift = True

        Select Case e.Code
            Case Keyboard.Key.Escape
                if InMenu Then Exit Sub

                If Windows(GetWindowIndex("winEscMenu")).Window.visible Then
                    ' hide it
                    HideWindow(GetWindowIndex("winEscMenu"))
                Else
                    ' show them
                    ShowWindow(GetWindowIndex("winEscMenu"), True)
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
        End Select

        ' Check for active window
        If activeWindow > 0 Then
            ' Ensure it's visible
            If Windows(activeWindow).Window.Visible Then
                ' Check for active control
                If Windows(activeWindow).ActiveControl > 0 Then
                    ' Handle input
                    Select Case e.Code
                        Case Keyboard.Key.Escape
                            ' Hide options screen
                            'HideWindow("winOptions")
                            'CloseComboMenu()

                            ' hide/show chat window
                            If Windows(GetWindowIndex("winChat")).Window.Visible Then
                                Windows(GetWindowIndex("winChat")).Controls(GetControlIndex("winChat", "txtChat")).Text = ""
                                HideChat()
                            End If

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

    Private Sub GameWindow_KeyReleased(ByVal sender As Object, ByVal e As SFML.Window.KeyEventArgs)
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
            If GetPlayerAccess(Myindex) > 0 Then
                SendRequestAdmin()
            End If
        End If

        'HandleInterfaceEvents(EntState.KeyUp)
    End Sub

    Private Sub GameWindow_MouseButtonPressed(ByVal sender As Object, ByVal e As SFML.Window.MouseButtonEventArgs)
        Console.WriteLine("Mouse Button Pressed: " & e.Button.ToString())

        If e.Button = Mouse.Button.Left Then
            ' if we're in the middle of choose the trade target or not
            If Not TradeRequest Then
                If PetAlive(Myindex) Then
                    If IsInBounds() Then
                        PetMove(CurX, CurY)
                    End If
                End If
                ' targetting
                PlayerSearch(CurX, CurY, 0)
            Else
                ' trading
                SendTradeRequest(Player(MyTarget).Name)
            End If
            ShowPetStats = False

        ElseIf e.Button = Mouse.Button.Right Then
            If VbKeyShift = True Then
                ' admin warp if we're pressing shift and right clicking
                If GetPlayerAccess(Myindex) >= 2 Then AdminWarp(CurX, CurY)
            Else
                ' rightclick menu
                If PetAlive(Myindex) Then
                    If IsInBounds() AndAlso CurX = Player(Myindex).Pet.X And CurY = Player(Myindex).Pet.Y Then
                        ShowPetStats = True
                    End If
                Else
                    PlayerSearch(CurX, CurY, 1)
                End If
            End If
        End If

        If Editor = EditorType.Map Then
            frmEditor_Map.MapEditorMouseDown(e.Button, e.X, e.Y, False)
        End If

        HandleInterfaceEvents(EntState.MouseDown)
    End Sub

    Private Sub GameWindow_MouseButtonReleased(ByVal sender As Object, ByVal e As SFML.Window.MouseButtonEventArgs)
        Console.WriteLine("Mouse Button Released: " & e.Button.ToString())

        HandleInterfaceEvents(EntState.MouseUp)
    End Sub

    Private Sub GameWindow_MouseWheelScrolled(ByVal sender As Object, ByVal e As SFML.Window.MouseWheelScrollEventArgs)
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

    Private Sub GameWindow_MouseMoved(ByVal sender As Object, ByVal e As SFML.Window.MouseMoveEventArgs)
        Console.WriteLine("Mouse Moved: " & e.X.ToString() & ", " & e.Y.ToString())

        CurX = TileView.Left + ((e.X + Camera.Left) \ PicX)
        CurY = TileView.Top + ((e.Y + Camera.Top) \ PicY)
        CurMouseX = e.X
        CurMouseY = e.Y

        HandleInterfaceEvents(EntState.MouseMove)
    End Sub

    Private Sub GameWindow_TextEntered(sender As Object, e As TextEventArgs)
        ' e.Unicode is a string, so no conversion is needed
        Dim unicodeChar As String = e.Unicode

        ' Get the first character of the string as a Char
        Dim character As Char = unicodeChar(0)

        ' Ignore Backspace (ChrW(8)), Enter (ChrW(13)), Tab (ChrW(9)), and Escape (ChrW(27)) keys
        If character = ChrW(8) OrElse character = ChrW(13) OrElse character = ChrW(9) OrElse character = ChrW(27) Then
            Return
        End If

        ' Convert the character to its UInteger Unicode code point
        Dim unicodeValue As UInteger = Convert.ToUInt32(character)
        ' Ensure it's visible
        If Windows(activeWindow).Window.Visible Then
            If Windows(activeWindow).Controls(Windows(activeWindow).ActiveControl).Locked Then
                Exit Sub
            End If

            ' Append character to text of the active control
            Windows(activeWindow).Controls(Windows(activeWindow).ActiveControl).Text &= character
        End If

    End Sub

    Private Sub GameWindow_Closed(ByVal sender As Object, ByVal e As EventArgs)
        Console.WriteLine("Window Closed")
        DestroyGame()
        GameWindow.Close()
    End Sub

    Private Sub GameWindow_Resized(sender As Object, e As SizeEventArgs)
        Const AspectRatio As Single = 16.0F / 9.0F

        ' Calculate the aspect ratio of the new window size
        Dim windowAspectRatio As Single = e.Width / e.Height

        ' Calculate the viewport dimensions to maintain the aspect ratio
        Dim viewport As New FloatRect()

        If windowAspectRatio > AspectRatio Then
            ' Window is wider than the desired aspect ratio
            Dim scale As Single = e.Height / AspectRatio
            viewport.Top = 0.0F
            viewport.Height = 1.0F ' Use the full height
            viewport.Width = AspectRatio / windowAspectRatio
            viewport.Left = (1.0F - viewport.Width) / 2.0F ' Center horizontally
        Else
            ' Window is taller than the desired aspect ratio
            Dim scale As Single = e.Width * AspectRatio
            viewport.Left = 0.0F
            viewport.Width = 1.0F ' Use the full width
            viewport.Height = windowAspectRatio / AspectRatio
            viewport.Top = (1.0F - viewport.Height) / 2.0F ' Center vertically
        End If

        ' Create a new view with the same center and size but a new viewport
        Dim view As New View(GameWindow.GetView())
        view.Viewport = viewport

        ' Set the new view to the window
        GameWindow.SetView(view)
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
        Fonts(0) = New Font(Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\" + Georgia)
        Fonts(1) = New Font(Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\" + Arial)
        Fonts(2) = New Font(Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\" + Verdana)

        WindowSettings = New ContextSettings()
        WindowSettings.DepthBits = 24
        WindowSettings.StencilBits = 8
        WindowSettings.AntialiasingLevel = 4

        GameWindow = New RenderWindow(New VideoMode(Types.Settings.ScreenWidth, Types.Settings.ScreenHeight), Types.Settings.GameName, Styles.Default, WindowSettings)
        CenterWindow(GameWindow)
        GameWindow.SetVerticalSyncEnabled(Types.Settings.Vsync)
        GameWindow.SetFramerateLimit(Types.Settings.MaxFps)
        Dim iconImage As New Image(Paths.Gui + "icon.png")
        GameWindow.SetIcon(iconImage.Size.X, iconImage.Size.Y, iconImage.Pixels)

        RegisterEvents()
        
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

        ReDim SkillIconTexture(NumSkillIcons)
        ReDim SkillIconSprite(NumSkillIcons)
        ReDim SkillIconGfxInfo(NumSkillIcons)

        ReDim FaceTexture(NumFaces)
        ReDim FaceSprite(NumFaces)
        ReDim FaceGfxInfo(NumFaces)

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
            'Load texture first, dont care about memory streams (just use the filename)
            BloodTexture = New Texture(Paths.Graphics & "Misc\Blood" & GfxExt)
            BloodSprite = New Sprite(BloodTexture)

            'Cache the width and height
            BloodGfxInfo.Width = BloodTexture.Size.X
            BloodGfxInfo.Height = BloodTexture.Size.Y
        End If

        DirectionGfxInfo = New GraphicInfo
        If File.Exists(Paths.Graphics & "Misc\Direction" & GfxExt) Then
            'Load texture first, dont care about memory streams (just use the filename)
            DirectionTexture = New Texture(Paths.Graphics & "Misc\Direction" & GfxExt)
            DirectionSprite = New Sprite(DirectionTexture)

            'Cache the width and height
            DirectionGfxInfo.Width = DirectionTexture.Size.X
            DirectionGfxInfo.Height = DirectionTexture.Size.Y
        End If

        WeatherGfxInfo = New GraphicInfo
        If File.Exists(Paths.Graphics & "Misc\Weather" & GfxExt) Then
            'Load texture first, dont care about memory streams (just use the filename)
            WeatherTexture = New Texture(Paths.Graphics & "Misc\Weather" & GfxExt)
            WeatherSprite = New Sprite(WeatherTexture)

            'Cache the width and height
            WeatherGfxInfo.Width = WeatherTexture.Size.X
            WeatherGfxInfo.Height = WeatherTexture.Size.Y
        End If

        HpBarGfxInfo = New GraphicInfo
        If File.Exists(Paths.Gui & "HPBar" & GfxExt) Then
            HpBarTextire = New Texture(Paths.Gui & "HPBar" & GfxExt)
            HpBarSprite = New Sprite(HpBarTextire)

            'Cache the width and height
            HpBarGfxInfo.Width = HpBarTextire.Size.X
            HpBarGfxInfo.Height = HpBarTextire.Size.Y
        End If

        MpBarGfxInfo = New GraphicInfo
        If File.Exists(Paths.Gui & "MPBar" & GfxExt) Then
            MpBarGfx = New Texture(Paths.Gui & "MPBar" & GfxExt)
            MpBarSprite = New Sprite(MpBarGfx)

            'Cache the width and height
            MpBarGfxInfo.Width = MpBarGfx.Size.X
            MpBarGfxInfo.Height = MpBarGfx.Size.Y
        End If

        EventChatGfxInfo = New GraphicInfo
        If File.Exists(Paths.Gui & "Main\EventChat" & GfxExt) Then
            'Load texture first, dont care about memory streams (just use the filename)
            EventChatGfx = New Texture(Paths.Gui & "Main\EventChat" & GfxExt)
            EventChatSprite = New Sprite(EventChatGfx)

            'Cache the width and height
            EventChatGfxInfo.Width = EventChatGfx.Size.X
            EventChatGfxInfo.Height = EventChatGfx.Size.Y
        End If

        TargetGfxInfo = New GraphicInfo
        If File.Exists(Paths.Graphics & "Misc\Target" & GfxExt) Then
            'Load texture first, dont care about memory streams (just use the filename)
            TargetGfx = New Texture(Paths.Graphics & "Misc\Target" & GfxExt)
            TargetSprite = New Sprite(TargetGfx)

            'Cache the width and height
            TargetGfxInfo.Width = TargetGfx.Size.X
            TargetGfxInfo.Height = TargetGfx.Size.Y
        End If

        RClickGfxInfo = New GraphicInfo
        If File.Exists(Paths.Gui & "Main\" & "RightClick" & GfxExt) Then
            RClickGfx = New Texture(Paths.Gui & "Main\" & "RightClick" & GfxExt)
            RClickSprite = New Sprite(RClickGfx)

            'Cache the width and height
            RClickGfxInfo.Width = RClickGfx.Size.X
            RClickGfxInfo.Height = RClickGfx.Size.Y
        End If

        ProgBarGfxInfo = New GraphicInfo
        If File.Exists(Paths.Gui & "Main\" & "ProgBar" & GfxExt) Then
            ProgBarGfx = New Texture(Paths.Gui & "Main\" & "ProgBar" & GfxExt)
            ProgBarSprite = New Sprite(ProgBarGfx)

            'Cache the width and height
            ProgBarGfxInfo.Width = ProgBarGfx.Size.X
            ProgBarGfxInfo.Height = ProgBarGfx.Size.Y
        End If

        ChatBubbleGfxInfo = New GraphicInfo
        If File.Exists(Paths.Graphics & "Misc\ChatBubble" & GfxExt) Then
            ChatBubbleGfx = New Texture(Paths.Graphics & "Misc\ChatBubble" & GfxExt)
            ChatBubbleSprite = New Sprite(ChatBubbleGfx)
            'Cache the width and height
            ChatBubbleGfxInfo.Width = ChatBubbleGfx.Size.X
            ChatBubbleGfxInfo.Height = ChatBubbleGfx.Size.Y
        End If

        PetStatGfxInfo = New GraphicInfo
        If File.Exists(Paths.Gui & "Main\Pet" & GfxExt) Then
            'Load texture first, dont care about memory streams (just use the filename)
            PetStatTexture = New Texture(Paths.Gui & "Main\Pet" & GfxExt)
            PetStatSprite = New Sprite(PetStatTexture)

            'Cache the width and height
            PetStatGfxInfo.Width = PetStatTexture.Size.X
            PetStatGfxInfo.Height = PetStatTexture.Size.Y
        End If

        PetbarGfxInfo = New GraphicInfo
        If File.Exists(Paths.Gui & "Main\Petbar" & GfxExt) Then
            'Load texture first, dont care about memory streams (just use the filename)
            PetBarGfx = New Texture(Paths.Gui & "Main\Petbar" & GfxExt)
            PetBarSprite = New Sprite(PetBarGfx)

            'Cache the width and height
            PetbarGfxInfo.Width = PetBarGfx.Size.X
            PetbarGfxInfo.Height = PetBarGfx.Size.Y
        End If

        LightGfxInfo = New GraphicInfo
        If File.Exists(Paths.Graphics & "Misc\Light" & GfxExt) Then
            LightGfx = New Texture(Paths.Graphics & "Misc\Light" & GfxExt)
            LightSprite = New Sprite(LightGfx)

            'Cache the width and height
            LightGfxInfo.Width = LightGfx.Size.X
            LightGfxInfo.Height = LightGfx.Size.Y
        End If

        For i = 1 To NumInterface
            LoadTexture(i, 15)
        Next

        For i = 1 To NumGradients
            LoadTexture(i, 16)
        Next

        For i = 1 To NumDesigns
            LoadTexture(i, 17)
        Next
    End Sub

    Private Sub RegisterEvents()
        AddHandler GameWindow.Closed, AddressOf GameWindow_Closed
        AddHandler GameWindow.GainedFocus, AddressOf GameWindow_GainedFocus
        AddHandler GameWindow.LostFocus, AddressOf GameWindow_LostFocus
        AddHandler GameWindow.KeyPressed, AddressOf GameWindow_KeyPressed
        AddHandler GameWindow.KeyReleased, AddressOf GameWindow_KeyReleased
        AddHandler GameWindow.MouseButtonPressed, AddressOf GameWindow_MouseButtonPressed
        AddHandler GameWindow.MouseButtonReleased, AddressOf GameWindow_MouseButtonReleased
        AddHandler GameWindow.MouseMoved, AddressOf GameWindow_MouseMoved
        AddHandler GameWindow.TextEntered, AddressOf GameWindow_TextEntered
        AddHandler GameWindow.MouseWheelScrolled, AddressOf GameWindow_MouseWheelScrolled
        AddHandler GameWindow.Resized, AddressOf GameWindow_Resized
    End Sub

    Friend Sub LoadTexture(index As Integer, texType As Byte)

        If texType = 1 Then 'tilesets
            If index <= 0 OrElse index > NumTileSets Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            TilesetTexture(index) = New Texture(Paths.Graphics & "tilesets\" & index & GfxExt)
            TilesetSprite(index) = New Sprite(TilesetTexture(index))

            'Cache the width and height
            With TilesetGfxInfo(index)
                .Width = TilesetTexture(index).Size.X
                .Height = TilesetTexture(index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf texType = 2 Then 'characters
            If index <= 0 OrElse index > NumCharacters Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            CharacterTexture(index) = New Texture(Paths.Graphics & "characters\" & index & GfxExt)
            CharacterSprite(index) = New Sprite(CharacterTexture(index))

            'Cache the width and height
            With CharacterGfxInfo(index)
                .Width = CharacterTexture(index).Size.X
                .Height = CharacterTexture(index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf texType = 3 Then 'paperdoll
            If index <= 0 OrElse index > NumPaperdolls Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            PaperdollTexture(index) = New Texture(Paths.Graphics & "paperdolls\" & index & GfxExt)
            PaperdollSprite(index) = New Sprite(PaperdollTexture(index))

            'Cache the width and height
            With PaperdollGfxInfo(index)
                .Width = PaperdollTexture(index).Size.X
                .Height = PaperdollTexture(index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf texType = 4 Then 'items
            If index <= 0 OrElse index > NumItems Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            ItemTexture(index) = New Texture(Paths.Graphics & "items\" & index & GfxExt)
            ItemSprite(index) = New Sprite(ItemTexture(index))

            'Cache the width and height
            With ItemGfxInfo(index)
                .Width = ItemTexture(index).Size.X
                .Height = ItemTexture(index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf texType = 5 Then 'resources
            If index <= 0 OrElse index > NumResources Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            ResourceTexture(index) = New Texture(Paths.Graphics & "resources\" & index & GfxExt)
            ResourceSprite(index) = New Sprite(ResourceTexture(index))

            'Cache the width and height
            With ResourceGfxInfo(index)
                .Width = ResourceTexture(index).Size.X
                .Height = ResourceTexture(index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf texType = 6 Then 'animations
            If index <= 0 OrElse index > NumAnimations Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            AnimationTexture(index) = New Texture(Paths.Graphics & "animations\" & index & GfxExt)
            AnimationSprite(index) = New Sprite(AnimationTexture(index))

            'Cache the width and height
            With AnimationGfxInfo(index)
                .Width = AnimationTexture(index).Size.X
                .Height = AnimationTexture(index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf texType = 7 Then 'faces
            If index <= 0 OrElse index > NumFaces Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            FaceTexture(index) = New Texture(Paths.Graphics & "faces\" & index & GfxExt)
            FaceSprite(index) = New Sprite(FaceTexture(index))

            'Cache the width and height
            With FaceGfxInfo(index)
                .Width = FaceTexture(index).Size.X
                .Height = FaceTexture(index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf texType = 8 Then 'fogs
            If index <= 0 OrElse index > NumFogs Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            FogTexture(index) = New Texture(Paths.Graphics & "fogs\" & index & GfxExt)
            FogSprite(index) = New Sprite(FogTexture(index))

            'Cache the width and height
            With FogGfxInfo(index)
                .Width = FogTexture(index).Size.X
                .Height = FogTexture(index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf texType = 9 Then 'skill icons
            If index <= 0 OrElse index > NumSkillIcons Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            SkillIconTexture(index) = New Texture(Paths.Graphics & "skills\" & index & GfxExt)
            SkillIconSprite(index) = New Sprite(SkillIconTexture(index))

            'Cache the width and height
            With SkillIconGfxInfo(index)
                .Width = SkillIconTexture(index).Size.X
                .Height = SkillIconTexture(index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf texType = 10 Then 'projectiles
            If index <= 0 OrElse index > NumProjectiles Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            ProjectileTexture(index) = New Texture(Paths.Graphics & "projectiles\" & index & GfxExt)
            ProjectileSprite(index) = New Sprite(ProjectileTexture(index))

            'Cache the width and height
            With ProjectileGfxInfo(index)
                .Width = ProjectileTexture(index).Size.X
                .Height = ProjectileTexture(index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf texType = 11 Then 'emotes
            If index <= 0 OrElse index > NumEmotes Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            EmoteTexture(index) = New Texture(Paths.Graphics & "emotes\" & index & GfxExt)
            EmoteSprite(index) = New Sprite(EmoteTexture(index))

            'Cache the width and height
            With EmoteGfxInfo(index)
                .Width = EmoteTexture(index).Size.X
                .Height = EmoteTexture(index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With

        ElseIf texType = 12 Then 'Panoramas
            If index <= 0 OrElse index > NumPanorama Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            PanoramaTexture(index) = New Texture(Paths.Graphics & "panoramas\" & index & GfxExt)
            PanoramaSprite(index) = New Sprite(PanoramaTexture(index))

            'Cache the width and height
            With PanoramaGfxInfo(index)
                .Width = PanoramaTexture(index).Size.X
                .Height = PanoramaTexture(index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With
        ElseIf texType = 13 Then 'Parallax
            If index <= 0 OrElse index > NumParallax Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            ParallaxTexture(index) = New Texture(Paths.Graphics & "parallax\" & index & GfxExt)
            ParallaxSprite(index) = New Sprite(ParallaxTexture(index))

            'Cache the width and height
            With ParallaxGfxInfo(index)
                .Width = ParallaxTexture(index).Size.X
                .Height = ParallaxTexture(index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With
        ElseIf texType = 14 Then 'Pictures
            If index <= 0 OrElse index > NumPictures Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            PictureTexture(index) = New Texture(Paths.Graphics & "pictures\" & index & GfxExt)
            PictureSprite(index) = New Sprite(PictureTexture(index))

            'Cache the width and height
            With PictureGfxInfo(index)
                .Width = PictureTexture(index).Size.X
                .Height = PictureTexture(index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With
        ElseIf texType = 15 Then 'Interfaces
            If index <= 0 OrElse index > NumInterface Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            InterfaceTexture(index) = New Texture(Paths.Gui & index & GfxExt)
            InterfaceSprite(index) = New Sprite(InterfaceTexture(index))

            'Cache the width and height
            With InterfaceGfxInfo(index)
                .Width = InterfaceTexture(index).Size.X
                .Height = InterfaceTexture(index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With
        ElseIf texType = 16 Then 'Gradients
            If index <= 0 OrElse index > NumGradients Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            GradientTexture(index) = New Texture(Paths.Gui & "gradients\" & index & GfxExt)
            GradientSprite(index) = New Sprite(GradientTexture(index))

            'Cache the width and height
            With GradientGfxInfo(index)
                .Width = GradientTexture(index).Size.X
                .Height = GradientTexture(index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With
        ElseIf texType = 17 Then 'Designs
            If index <= 0 OrElse index > NumDesigns Then Exit Sub

            'Load texture first, dont care about memory streams (just use the filename)
            DesignTexture(index) = New Texture(Paths.Gui & "designs\" & index & GfxExt)
            DesignSprite(index) = New Sprite(DesignTexture(index))

            'Cache the width and height
            With DesignGfxInfo(index)
                .Width = DesignTexture(index).Size.X
                .Height = DesignTexture(index).Size.Y
                .IsLoaded = True
                .TextureTimer = GetTickCount() + 100000
            End With
        End If
    End Sub

#End Region

#Region "Drawing"
    Friend Sub DrawEmotes(x2 As Integer, y2 As Integer, sprite As Integer)
        Dim rec As Rectangle
        Dim x As Integer, y As Integer, anim As Integer

        If sprite < 1 OrElse sprite > NumEmotes Then Exit Sub

        If EmoteGfxInfo(sprite).IsLoaded = False Then
            LoadTexture(sprite, 11)
        End If

        With EmoteGfxInfo(sprite)
            .TextureTimer = GetTickCount() + 100000
        End With

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

        RenderTexture(EmoteSprite(sprite), GameWindow, x, y, rec.X, rec.Y, rec.Width, rec.Height)
    End Sub

    Friend Sub RenderTexture(tmpSprite As Sprite, target As RenderWindow, dX As Integer, dY As Integer,
                            sX As Integer, sY As Integer, dW As Integer, dH As Integer, Optional sW As Integer = 1, Optional sH As Integer = 1, Optional alpha As Byte = 255, Optional red As Byte = 255, Optional green As Byte = 255, Optional blue As Byte = 255)

        If tmpSprite Is Nothing Then Exit Sub

        tmpSprite.TextureRect = New IntRect(sX, sY, sW, sH)
        tmpSprite.Scale = New Vector2f(dW / sW, dH / sH)
        tmpSprite.Position = New Vector2f(dX, dY)
        tmpSprite.Color = New Color(red, green, blue, alpha)
        target.Draw(tmpSprite)
    End Sub

    Friend Sub RenderTextures(tex As Texture, target As RenderWindow, dX As Integer, dY As Integer, sX As Integer,
                              sY As Integer, dW As Integer, dH As Integer, Optional sW As Integer = 1, Optional sH As Integer = 1, Optional alpha As Byte = 255, Optional red As Byte = 255, Optional green As Byte = 255, Optional blue As Byte = 255)

        If tex Is Nothing Then Exit Sub

        Dim tmpImage = New Sprite(tex) With {
                .TextureRect = New IntRect(sX, sY, sW, sH),
                .Scale = New Vector2f(dW / sW, dH / sH),
                .Position = New Vector2f(dX, dY),
                .Color = New Color(red, green, blue, alpha)
                }
        target.Draw(tmpImage)
    End Sub

    Friend Sub DrawDirections(x As Integer, y As Integer)
        Dim rec As Rectangle, i As Integer

        ' render grid
        rec.Y = 24
        rec.X = 0
        rec.Width = 32
        rec.Height = 32

        RenderTexture(DirectionSprite, GameWindow, ConvertMapX(x * PicX), ConvertMapY(y * PicY), rec.X, rec.Y, rec.Width,
                     rec.Height, rec.Width, rec.Height)

        ' render dir blobs
        For i = 1 To 4
            rec.X = (i - 1) * 8
            rec.Width = 8

            ' find out whether render blocked or not
            If Not IsDirBlocked(Map.Tile(x, y).DirBlock, i) Then
                rec.Y = 8
            Else
                rec.Y = 16
            End If
            rec.Height = 8

            RenderTexture(DirectionSprite, GameWindow, ConvertMapX(x * PicX) + DirArrowX(i),
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

        If sprite < 1 OrElse sprite > NumPaperdolls Then Exit Sub

        If PaperdollGfxInfo(sprite).IsLoaded = False Then
            LoadTexture(sprite, 3)
        End If

        ' we use it, lets update timer
        With PaperdollGfxInfo(sprite)
            .TextureTimer = GetTickCount() + 100000
        End With

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

        RenderTexture(PaperdollSprite(sprite), GameWindow, x, y, rec.X, rec.Y, rec.Width, rec.Height)
    End Sub

    Friend Sub DrawNpc(mapNpcNum As Integer)
        Dim anim As Byte
        Dim x As Integer
        Dim y As Integer
        Dim sprite As Integer, spriteleft As Integer
        Dim rect As Rectangle
        Dim attackspeed As Integer

        If MapNpc(mapNpcNum).Num = 0 Then Exit Sub ' no npc set

        If MapNpc(mapNpcNum).X < TileView.Left OrElse MapNpc(mapNpcNum).X > TileView.Right Then Exit Sub
        If MapNpc(mapNpcNum).Y < TileView.Top OrElse MapNpc(mapNpcNum).Y > TileView.Bottom Then Exit Sub

        StreamNpc(MapNpc(mapNpcNum).Num)

        sprite = NPC(MapNpc(mapNpcNum).Num).Sprite

        If sprite < 1 OrElse sprite > NumCharacters Then Exit Sub

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

        DrawCharacterSprite(sprite, x, y, rect)
    End Sub

    Friend Sub DrawMapItem(itemnum As Integer)
        Dim srcrec As Rectangle, destrec As Rectangle
        Dim picNum As Integer
        Dim x As Integer, y As Integer

        StreamItem(MapItem(itemnum).Num)

        picNum = Item(MapItem(itemnum).Num).Pic

        If picNum < 1 OrElse picNum > NumItems Then Exit Sub

        If ItemGfxInfo(picNum).IsLoaded = False Then
            LoadTexture(picNum, 4)
        End If

        'seeying we still use it, lets update timer
        With ItemGfxInfo(picNum)
            .TextureTimer = GetTickCount() + 100000
        End With

        With MapItem(itemnum)
            If .X < TileView.Left OrElse .X > TileView.Right Then Exit Sub
            If .Y < TileView.Top OrElse .Y > TileView.Bottom Then Exit Sub
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

        RenderTexture(ItemSprite(picNum), GameWindow, x, y, srcrec.X, srcrec.Y, srcrec.Width, srcrec.Height, srcrec.Width, srcrec.Height)
    End Sub

    Friend Sub DrawCharacterSprite(sprite As Integer, x2 As Integer, y2 As Integer, sRECT As Rectangle)
        Dim x As Integer
        Dim y As Integer

        If sprite < 1 OrElse sprite > NumCharacters Then Exit Sub

        If CharacterGfxInfo(sprite).IsLoaded = False Then
            LoadTexture(sprite, 2)
        End If

        'seeying we still use it, lets update timer
        With CharacterGfxInfo(sprite)
            .TextureTimer = GetTickCount() + 100000
        End With

        x = ConvertMapX(x2)
        y = ConvertMapY(y2)

        RenderTexture(CharacterSprite(sprite), GameWindow, x, y, sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height, sRECT.Width, sRECT.Height)
    End Sub

    Friend Sub DrawBlood(index As Integer)
        Dim srcrec As Rectangle
        Dim destrec As Rectangle
        Dim x As Integer
        Dim y As Integer

        With Blood(index)
            If .X < TileView.Left OrElse .X > TileView.Right Then Exit Sub
            If .Y < TileView.Top OrElse .Y > TileView.Bottom Then Exit Sub

            ' check if we should be seeing it
            If .Timer + 20000 < GetTickCount() Then Exit Sub

            x = ConvertMapX(Blood(index).X * PicX)
            y = ConvertMapY(Blood(index).Y * PicY)

            srcrec = New Rectangle((.Sprite - 1) * PicX, 0, PicX, PicY)

            destrec = New Rectangle(ConvertMapX(.X * PicX), ConvertMapY(.Y * PicY), PicX, PicY)

            RenderTexture(BloodSprite, GameWindow, x, y, srcrec.X, srcrec.Y, srcrec.Width, srcrec.Height)

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
        Dim startX As Integer, startY As Integer
        Dim endX As Integer, endY As Integer

        offsetX = Player(Myindex).XOffset + PicX
        offsetY = Player(Myindex).YOffset + PicY

        If Types.Settings.CameraType = 1 Then
            startX = GetPlayerX(Myindex) - Types.Settings.CameraWidth
            startY = GetPlayerY(Myindex) - Types.Settings.CameraHeight
        Else
            startX = GetPlayerX(Myindex) - ((Types.Settings.CameraWidth) / 2)
            startY = GetPlayerY(Myindex) - ((Types.Settings.CameraHeight) / 2)
        End If

        If startX < 0 Then
            offsetX = 0

            If startX = -1 Then
                If Player(Myindex).XOffset > 0 Then
                    offsetX = Player(Myindex).XOffset
                End If
            End If

            startX = 0
        End If

        If startY < 0 Then
            offsetY = 0

            If startY = -1 Then
                If Player(Myindex).YOffset > 0 Then
                    offsetY = Player(Myindex).YOffset
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
            If Types.Settings.CameraType = 1 Then
                .Height = .Top + Types.Settings.CameraHeight + PicY
                .Width = .Left + Types.Settings.CameraWidth + PicX
            Else
                .Height = Types.Settings.CameraHeight + PicY
                .Width = Types.Settings.CameraWidth + PicX
            End If
        End With

        UpdateDrawMapName()
    End Sub

    Friend Sub Render_Graphics()
        Dim x As Integer, y As Integer, I As Integer

        'Don't Render if
        If GettingMap Then Exit Sub

        'update view around player
        UpdateCamera()

        'Clear each of our render targets
        GameWindow.Clear(Color.Black)

        'If CurMouseX > 0 AndAlso CurMouseX <= GameWindow.Size.X Then
        '    If CurMouseY > 0 AndAlso CurMouseY <= GameWindow.Size.Y Then
        '        GameWindow.SetMouseCursorVisible(False)
        '    End If
        'End If

        If NumPanorama > 0 AndAlso Map.Panorama > 0 Then
            DrawPanorama(Map.Panorama)
        End If

        If NumParallax > 0 AndAlso Map.Parallax > 0 Then
            DrawParallax(Map.Parallax)
        End If

        ' Draw lower tiles
        If NumTileSets > 0 Then
            For x = TileView.Left To TileView.Right + 1
                For y = TileView.Top To TileView.Bottom + 1
                    If IsValidMapPoint(x, y) Then
                        DrawMapTile(x, y)
                    End If
                Next
            Next
        End If

        ' events
        If Editor <> EditorType.Map Then
            If CurrentEvents > 0 AndAlso CurrentEvents <= Map.EventCount Then
                For I = 0 To CurrentEvents
                    If MapEvents(I).Position = 0 Then
                        DrawEvent(I)
                    End If
                Next
            End If
        End If

        ' blood
        For I = 0 To Byte.MaxValue
            DrawBlood(I)
        Next

        ' Draw out the items
        If NumItems > 0 Then
            For I = 1 To MAX_MAP_ITEMS
                If MapItem(I).Num > 0 Then
                    DrawMapItem(I)
                End If
            Next
        End If

        ' draw animations
        If NumAnimations > 0 Then
            For I = 0 To Byte.MaxValue
                If AnimInstance(I).Used(0) Then
                    DrawAnimation(I, 0)
                End If
            Next
        End If

        ' Y-based render. Renders Players, Npcs and Resources based on Y-axis.
        For y = 0 To Map.MaxY

            If NumCharacters > 0 Then
                ' Players
                For I = 1 To MAX_PLAYERS
                    If IsPlaying(I) AndAlso GetPlayerMap(I) = GetPlayerMap(Myindex) Then
                        If Player(I).Y = y Then
                            DrawPlayer(I)
                        End If

                        If PetAlive(I) Then
                            If Player(I).Pet.Y = y Then
                                DrawPet(I)
                            End If
                        End If
                    End If
                Next

                ' Npcs
                For I = 1 To MAX_MAP_NPCS
                    If MapNpc(I).Y = y Then
                        DrawNpc(I)
                    End If
                Next

                ' events
                If Editor <> EditorType.Map Then
                    If CurrentEvents > 0 AndAlso CurrentEvents <= Map.EventCount Then
                        For I = 0 To CurrentEvents
                            If MapEvents(I).Position = 1 Then
                                If y = MapEvents(I).Y Then
                                    DrawEvent(I)
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

                For I = 1 To MAX_PLAYERS
                    If IsPlaying(I) Then
                        If Player(I).Map = Player(Myindex).Map Then
                            If CurX = Player(I).X AndAlso CurY = Player(I).Y Then
                                If MyTargetType = TargetType.Player AndAlso MyTarget = I Then
                                    ' dont render lol
                                Else
                                    DrawHover(Player(I).X * 32 - 16, Player(I).Y * 32 + Player(I).YOffset)
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
                        For I = 0 To ResourceIndex
                            If MapResource(I).Y = y Then
                                DrawMapResource(I)
                            End If
                        Next
                    End If
                End If
            End If
        Next

        ' animations
        If NumAnimations > 0 Then
            For I = 0 To Byte.MaxValue
                If AnimInstance(I).Used(1) Then
                    DrawAnimation(I, 1)
                End If
            Next
        End If

        If NumProjectiles > 0 Then
            For I = 1 To MAX_PROJECTILES
                If MapProjectile(Player(Myindex).Map, I).ProjectileNum > 0 Then
                    DrawProjectile(I)
                End If
            Next
        End If

        If CurrentEvents > 0 AndAlso CurrentEvents <= Map.EventCount Then
            For I = 0 To CurrentEvents
                If MapEvents(I).Position = 2 Then
                    DrawEvent(I)
                End If
            Next
        End If

        If NumTileSets > 0 Then
            For x = TileView.Left To TileView.Right + 1
                For y = TileView.Top To TileView.Bottom + 1
                    If IsValidMapPoint(x, y) Then
                        DrawMapFringeTile(x, y)
                    End If
                Next
            Next
        End If

        DrawNight()
        DrawWeather()
        DrawThunderEffect()
        DrawMapTint()

        ' Draw out a square at mouse cursor
        If MapGrid = True AndAlso Editor = EditorType.Map Then
            DrawGrid()
        End If

        If Editor = EditorType.Map Then
            DrawTileOutline()
            If EyeDropper = True Then
                DrawEyeDropper()
            End If
        End If

        ' draw player names
        For I = 1 To MAX_PLAYERS
            If IsPlaying(I) AndAlso GetPlayerMap(I) = GetPlayerMap(Myindex) Then
                DrawPlayerName(I)
                If PetAlive(I) Then
                    DrawPlayerPetName(I)
                End If
            End If
        Next

        'draw event names
        For I = 0 To CurrentEvents
            If MapEvents(I).Visible = 1 Then
                If MapEvents(I).ShowName = 1 Then
                    DrawEventName(I)
                End If
            End If
        Next

        ' draw npc names
        For I = 1 To MAX_MAP_NPCS
            If MapNpc(I).Num > 0 Then
                DrawNpcName(I)
            End If
        Next

        If CurrentFog > 0 Then
            DrawFog()
        End If

        DrawPicture()

        'action msg
        For I = 1 To Byte.MaxValue
            DrawActionMsg(I)
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

        ' draw the messages
        For i = 1 To Byte.MaxValue
            If chatBubble(i).active Then
                DrawChatBubble(i)
            End If
        Next

        If Bfps Then
            Dim fps As String = Trim$("FPS: " & GameFps)
            Call RenderText(fps, GameWindow, Camera.Left - 24, Camera.Top + 60, Color.Yellow, Color.Black)
        End If

        ' draw cursor, player X and Y locations
        If BLoc Then
            Dim Cur As String = Trim$("Cur X: " & CurX & " Y: " & CurY)
            Dim Loc As String = Trim$("loc X: " & GetPlayerX(MyIndex) & " Y: " & GetPlayerY(MyIndex))
            Dim Map As String = Trim$(" (Map #" & GetPlayerMap(MyIndex) & ")")

            Call RenderText(Cur, GameWindow, Camera.Left  - 24, Camera.top + 75, Color.Yellow, Color.Black)
            Call RenderText(Loc, GameWindow, Camera.Left  - 24, Camera.top + 90, Color.Yellow, Color.Black)
            Call RenderText(Map, GameWindow, Camera.Left - 24, Camera.top + 105, Color.Yellow, Color.Black)
        End If

        DrawMapName()

        If Editor = EditorType.Map AndAlso frmEditor_Map.tabpages.SelectedTab Is frmEditor_Map.tpEvents Then
            DrawEvents()
            EditorEvent_DrawGraphic()
        End If

        If Editor = EditorType.Projectile Then
            EditorProjectile_DrawProjectile()
        End If

        If InGame Then
            DrawBars()
            DrawParty()
        End If

        DrawMapFade()

        If InGame = False Then
            DrawMenuBG()
        End If

        RenderEntities()

        GameWindow.Display()
    End Sub

    Friend Sub DrawPanorama(index As Integer)
        If Map.Indoors Then Exit Sub

        If index < 1 OrElse index > NumParallax Then Exit Sub

        If PanoramaGfxInfo(index).IsLoaded = False Then
            LoadTexture(index, 12)
        End If

        ' we use it, lets update timer
        With PanoramaGfxInfo(index)
            .TextureTimer = GetTickCount() + 100000
        End With

        PanoramaSprite(index).TextureRect = New IntRect(0, 0, GameWindow.Size.X, GameWindow.Size.Y)
        PanoramaSprite(index).Position = New Vector2f(0, 0)

        GameWindow.Draw(PanoramaSprite(index))
    End Sub

    Friend Sub DrawParallax(index As Integer)
        Dim horz = 0
        Dim vert = 0

        If Map.Moral = Map.Indoors Then Exit Sub

        If index < 1 OrElse index > NumParallax Then Exit Sub
        If ParallaxGfxInfo(index).IsLoaded = False Then
            LoadTexture(index, 14)
        End If

        ' we use it, lets update timer
        With ParallaxGfxInfo(index)
            .TextureTimer = GetTickCount() + 100000
        End With
        horz = ConvertMapX(GetPlayerX(Myindex))
        vert = ConvertMapY(GetPlayerY(Myindex))

        ParallaxSprite(index).Position = New Vector2f((horz * 2.5) - 50, (vert * 2.5) - 50)

        GameWindow.Draw(ParallaxSprite(index))
    End Sub

    Friend Sub DrawPicture(Optional index As Integer = 0, Optional type As Integer = 0)
        If index = 0 Then
            index = Picture.Index
        End If

        If type = 0 Then
            type = Picture.SpriteType
        End If

        If index < 1 Or index > NumPictures Then Exit Sub
        If type < 0 Or type > 2 Then Exit Sub

        If PictureGfxInfo(index).IsLoaded = False Then
            LoadTexture(index, 14)
        End If

        ' we use it, lets update timer
        With PictureGfxInfo(index)
            .TextureTimer = GetTickCount() + 100000
        End With

        PictureSprite(index).TextureRect = New IntRect(0, 0, GameWindow.Size.X, GameWindow.Size.Y)

        Select Case type
            Case 0 ' Top Left
                PictureSprite(index).Position = New Vector2f(0 - Picture.xOffset, 0 - Picture.yOffset)
            Case 1 ' Center Screen
                PictureSprite(index).Position = New Vector2f(GameWindow.Size.X / 2 - PictureGfxInfo(index).Width / 2 - Picture.xOffset, GameWindow.Size.Y / 2 - PictureGfxInfo(index).Height / 2)
            Case 2 ' Center Event
                If CurrentEvents < Picture.EventId Then
                    Picture.EventId = 0
                    Picture.Index = 0
                    Picture.SpriteType = 0
                    Picture.xOffset = 0
                    Picture.yOffset = 0
                    Exit Sub
                End If
                PictureSprite(index).Position = New Vector2f(ConvertMapX(MapEvents(Picture.EventId).X * 32) / 2 - Picture.xOffset, ConvertMapY(MapEvents(Picture.EventId).Y * 32) / 2 - Picture.yOffset)
            Case 3 ' Center Player
                PictureSprite(index).Position = New Vector2f(ConvertMapX(Player(Myindex).X * 32) / 2 - Picture.xOffset, ConvertMapY(Player(Myindex).Y * 32) / 2 - Picture.yOffset)
        End Select

        GameWindow.Draw(PictureSprite(index))
    End Sub

    Friend Sub DrawBars()
        Dim tmpY As Integer
        Dim tmpX As Integer
        Dim barWidth As Integer
        Dim rec(1) As Rectangle

        If GettingMap Then Exit Sub

        ' check for casting time bar
        If SkillBuffer > 0 Then
            ' lock to player
            tmpX = GetPlayerX(Myindex) * PicX + Player(Myindex).XOffset
            tmpY = GetPlayerY(Myindex) * PicY + Player(Myindex).YOffset + 35
            If Skill(Player(Myindex).Skill(SkillBuffer).Num).CastTime = 0 Then _
                Skill(Player(Myindex).Skill(SkillBuffer).Num).CastTime = 1
            ' calculate the width to fill
            barWidth =
                ((GetTickCount() - SkillBufferTimer) /
                 ((GetTickCount() - SkillBufferTimer) + (Skill(Player(Myindex).Skill(SkillBuffer).Num).CastTime * 1000)) *
                 64)
            ' draw bars
            rec(1) = New Rectangle(ConvertMapX(tmpX), ConvertMapY(tmpY), barWidth, 4)
            Dim rectShape As New RectangleShape(New Vector2f(barWidth, 4)) With {
                    .Position = New Vector2f(ConvertMapX(tmpX), ConvertMapY(tmpY)),
                    .FillColor = Color.Cyan
                    }
            GameWindow.Draw(rectShape)
        End If

        If Types.Settings.ShowNpcBar = 1 Then
            ' check for hp bar
            For i = 1 To MAX_MAP_NPCS
                If Map.Npc Is Nothing Then Exit Sub
                If Map.Npc(i) > 0 And Map.Npc(i) <= MAX_NPCS And MapNpc(i).Num > 0 And MapNpc(i).Num <= MAX_NPCS Then
                    If _
                        NPC(MapNpc(i).Num).Behaviour = NpcBehavior.AttackOnSight OrElse
                        NPC(MapNpc(i).Num).Behaviour = NpcBehavior.AttackWhenAttacked OrElse
                        NPC(MapNpc(i).Num).Behaviour = NpcBehavior.Guard Then
                        ' lock to npc
                        tmpX = MapNpc(i).X * PicX + MapNpc(i).XOffset
                        tmpY = MapNpc(i).Y * PicY + MapNpc(i).YOffset + 35
                        If MapNpc(i).Vital(VitalType.HP) > 0 Then
                            ' calculate the width to fill
                            barWidth = ((MapNpc(i).Vital(VitalType.HP) / (NPC(MapNpc(i).Num).HP) * 32))
                            ' draw bars
                            rec(1) = New Rectangle(ConvertMapX(tmpX), ConvertMapY(tmpY), barWidth, 4)
                            Dim rectShape As New RectangleShape(New Vector2f(barWidth, 4)) With {
                                    .Position = New Vector2f(ConvertMapX(tmpX), ConvertMapY(tmpY - 75)),
                                    .FillColor = Color.Red
                                    }
                            GameWindow.Draw(rectShape)

                            If MapNpc(i).Vital(VitalType.MP) > 0 Then
                                ' calculate the width to fill
                                barWidth =
                                    ((MapNpc(i).Vital(VitalType.MP) / (NPC(MapNpc(i).Num).Stat(StatType.Intelligence) * 2) *
                                      32))
                                ' draw bars
                                rec(1) = New Rectangle(ConvertMapX(tmpX), ConvertMapY(tmpY), barWidth, 4)
                                Dim rectShape2 As New RectangleShape(New Vector2f(barWidth, 4)) With {
                                        .Position = New Vector2f(ConvertMapX(tmpX), ConvertMapY(tmpY - 80)),
                                        .FillColor = Color.Blue
                                        }
                                GameWindow.Draw(rectShape2)
                            End If
                        End If
                    End If
                End If
            Next
        End If

        If PetAlive(Myindex) Then
            ' draw own health bar
            If Player(Myindex).Pet.Health > 0 AndAlso Player(Myindex).Pet.Health <= Player(Myindex).Pet.MaxHp Then
                'Debug.Print("pethealth:" & Player(Myindex).Pet.Health)
                ' lock to Player
                tmpX = Player(Myindex).Pet.X * PicX + Player(Myindex).Pet.XOffset
                tmpY = Player(Myindex).Pet.Y * PicX + Player(Myindex).Pet.YOffset + 35
                ' calculate the width to fill
                barWidth = ((Player(Myindex).Pet.Health) / (Player(Myindex).Pet.MaxHp)) * 32
                ' draw bars
                rec(1) = New Rectangle(ConvertMapX(tmpX), ConvertMapY(tmpY), barWidth, 4)
                Dim rectShape As New RectangleShape(New Vector2f(barWidth, 4)) With {
                        .Position = New Vector2f(ConvertMapX(tmpX), ConvertMapY(tmpY - 75)),
                        .FillColor = Color.Red
                        }
                GameWindow.Draw(rectShape)
            End If
        End If

        ' check for pet casting time bar
        If PetSkillBuffer > 0 Then
            If Skill(Pet(Player(Myindex).Pet.Num).Skill(PetSkillBuffer)).CastTime > 0 Then
                ' lock to pet
                tmpX = Player(Myindex).Pet.X * PicX + Player(Myindex).Pet.XOffset
                tmpY = Player(Myindex).Pet.Y * PicY + Player(Myindex).Pet.YOffset + 35

                ' calculate the width to fill
                barWidth = (GetTickCount() - PetSkillBufferTimer) /
                           ((Skill(Pet(Player(Myindex).Pet.Num).Skill(PetSkillBuffer)).CastTime * 1000)) * 64
                ' draw bar background
                rec(1) = New Rectangle(ConvertMapX(tmpX), ConvertMapY(tmpY), barWidth, 4)
                Dim rectShape As New RectangleShape(New Vector2f(barWidth, 4)) With {
                        .Position = New Vector2f(ConvertMapX(tmpX), ConvertMapY(tmpY)),
                        .FillColor = Color.Cyan
                        }
                GameWindow.Draw(rectShape)
            End If
        End If
    End Sub

    Sub DrawMapName()
        RenderText(Language.Game.MapName & Map.Name, GameWindow, DrawMapNameX, DrawMapNameY, DrawMapNameColor, Color.Black)
    End Sub

    Friend Sub DrawGrid()
        For x = TileView.Left To TileView.Right ' - 1
            For y = TileView.Top To TileView.Bottom ' - 1
                If IsValidMapPoint(x, y) Then

                    Dim rec As New RectangleShape With {
                            .OutlineColor = New Color(Color.White),
                            .OutlineThickness = 0.6,
                            .FillColor = New Color(Color.Transparent),
                            .Size = New Vector2f((x * PicX), (y * PicX)),
                            .Position = New Vector2f(ConvertMapX((x - 1) * PicX), ConvertMapY((y - 1) * PicY))
                            }

                    GameWindow.Draw(rec)
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
            If TilesetGfxInfo(frmEditor_Map.cmbTileSets.SelectedIndex + 1).IsLoaded = False Then
                LoadTexture(frmEditor_Map.cmbTileSets.SelectedIndex, 1)
            End If

            ' we use it, lets update timer
            With TilesetGfxInfo(frmEditor_Map.cmbTileSets.SelectedIndex + 1)
                .TextureTimer = GetTickCount() + 100000
            End With

            If EditorTileWidth = 1 AndAlso EditorTileHeight = 1 Then
                RenderTexture(TilesetSprite(frmEditor_Map.cmbTileSets.SelectedIndex + 1), GameWindow, ConvertMapX(CurX * PicX), ConvertMapY(CurY * PicY), EditorTileSelStart.X * PicX, EditorTileSelStart.Y * PicY, rec.Width, rec.Height, rec.Width, rec.Height)

                rec2.Size = New Vector2f(rec.Width, rec.Height)
            Else
                If frmEditor_Map.cmbAutoTile.SelectedIndex > 0 Then
                    RenderTexture(TilesetSprite(frmEditor_Map.cmbTileSets.SelectedIndex + 1), GameWindow, ConvertMapX(CurX * PicX), ConvertMapY(CurY * PicY), EditorTileSelStart.X * PicX, EditorTileSelStart.Y * PicY, rec.Width, rec.Height, rec.Width, rec.Height)

                    rec2.Size = New Vector2f(rec.Width, rec.Height)
                Else
                    RenderTexture(TilesetSprite(frmEditor_Map.cmbTileSets.SelectedIndex + 1), GameWindow, ConvertMapX(CurX * PicX), ConvertMapY(CurY * PicY), EditorTileSelStart.X * PicX, EditorTileSelStart.Y * PicY, EditorTileSelEnd.X * PicX, EditorTileSelEnd.Y * PicY, EditorTileSelEnd.X * PicX, EditorTileSelEnd.Y * PicY)

                    rec2.Size = New Vector2f(EditorTileSelEnd.X * PicX, EditorTileSelEnd.Y * PicY)
                End If

            End If

        End If

        rec2.Position = New Vector2f(ConvertMapX(CurX * PicX), ConvertMapY(CurY * PicY))
        GameWindow.Draw(rec2)
    End Sub

    Friend Sub DrawEyeDropper()
        Dim rec As New RectangleShape With {
        .OutlineColor = New Color(Color.Cyan),
        .OutlineThickness = 0.6,
        .FillColor = New Color(Color.Transparent),
        .Size = New Vector2f((PicX), (PicX)),
        .Position = New Vector2f(ConvertMapX((CurX) * PicX), ConvertMapY((CurY) * PicY))
        }

        GameWindow.Draw(rec)
    End Sub

    Friend Sub DrawMapTint()

        If Map.MapTint = 0 Then Exit Sub

        MapTintSprite = New Sprite(New Texture(New Image(GameWindow.Size.X, GameWindow.Size.Y, Color.Black))) With {
            .Color = New Color(CurrentTintR, CurrentTintG, CurrentTintB, CurrentTintA),
            .TextureRect = New IntRect(0, 0, GameWindow.Size.X, GameWindow.Size.Y),
            .Position = New Vector2f(0, 0)
            }

        GameWindow.Draw(MapTintSprite)
    End Sub

    Friend Sub DrawMapFade()
        If UseFade = False Then Exit Sub

        MapFadeSprite = New Sprite(New Texture(New Image(GameWindow.Size.X, GameWindow.Size.Y, Color.Black))) With {
            .Color = New Color(0, 0, 0, FadeAmount),
            .TextureRect = New IntRect(0, 0, GameWindow.Size.X, GameWindow.Size.Y),
            .Position = New Vector2f(0, 0)
            }

        GameWindow.Draw(MapFadeSprite)
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

        For i = 0 To NumSkillIcons
            If Not SkillIconTexture(i) Is Nothing Then SkillIconTexture(i).Dispose()
        Next

        For i = 0 To NumTileSets
            If Not TilesetTexture(i) Is Nothing Then TilesetTexture(i).Dispose()
        Next i

        For i = 0 To NumFaces
            If Not FaceTexture(i) Is Nothing Then FaceTexture(i).Dispose()
        Next

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
        If Not RClickGfx Is Nothing Then RClickGfx.Dispose()
        If Not ProgBarGfx Is Nothing Then ProgBarGfx.Dispose()
        If Not ChatBubbleGfx Is Nothing Then ChatBubbleGfx.Dispose()

        If Not HpBarTextire Is Nothing Then HpBarTextire.Dispose()
        If Not MpBarGfx Is Nothing Then MpBarGfx.Dispose()

        If Not LightGfx Is Nothing Then LightGfx.Dispose()
        If Not NightGfx Is Nothing Then NightGfx.Dispose()
    End Sub

    Friend Function ToSfmlColor(toConvert As Drawing.Color) As Color
        Return New Color(toConvert.R, toConvert.G, toConvert.G, toConvert.A)
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

        x = ConvertMapX(x2)
        y = ConvertMapY(y2)
        width = (rec.Right - rec.Left)
        height = (rec.Bottom - rec.Top)

        RenderTexture(TargetSprite, GameWindow, x, y, rec.X, rec.Y, rec.Width, rec.Height)
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

        x = ConvertMapX(x2)
        y = ConvertMapY(y2)
        width = (rec.Right - rec.Left)
        height = (rec.Bottom - rec.Top)

        RenderTexture(TargetSprite, GameWindow, x, y, rec.X, rec.Y, rec.Width, rec.Height)
    End Sub

    Friend Sub DrawRClick()
        'first render panel
        RenderTexture(RClickSprite, GameWindow, RClickX, RClickY, 0, 0, RClickGfxInfo.Width, RClickGfxInfo.Height)

        RenderText(RClickname, GameWindow, RClickX + (RClickGfxInfo.Width \ 2) - (TextWidth(RClickname) \ 2), RClickY + 10, Color.White,
                 Color.Black)

        RenderText("Invite to Trade", GameWindow, RClickX + (RClickGfxInfo.Width \ 2) - (TextWidth("Invite to Trade") \ 2), RClickY + 35,
                 Color.White, Color.White)

        RenderText("Invite to Party", GameWindow, RClickX + (RClickGfxInfo.Width \ 2) - (TextWidth("Invite to Party") \ 2), RClickY + 60,
                 Color.White, Color.White)

    End Sub

    Friend Sub EditorItem_DrawItem()
        Dim itemnum As Integer
        itemnum = frmEditor_Item.nudPic.Value

        If itemnum < 1 OrElse itemnum > NumItems Then
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

        If Sprite < 1 OrElse Sprite > NumPaperdolls Then
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

        If Sprite < 1 OrElse Sprite > NumCharacters Then
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

        If Sprite < 1 OrElse Sprite > NumResources Then
            frmEditor_Resource.picNormalpic.BackgroundImage = Nothing
        Else
            If File.Exists(Paths.Graphics & "resources\" & Sprite & GfxExt) Then
                frmEditor_Resource.picNormalpic.BackgroundImage =
                    Drawing.Image.FromFile(Paths.Graphics & "resources\" & Sprite & GfxExt)
            End If
        End If

        ' exhausted sprite
        Sprite = frmEditor_Resource.nudExhaustedPic.Value

        If Sprite < 1 OrElse Sprite > NumResources Then
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

        Sprite = FrmEditor_Events.nudShowPicture.Value

        If Sprite < 1 OrElse Sprite > NumPictures Then
            FrmEditor_Events.picShowPic.BackgroundImage = Nothing
            Exit Sub
        End If

        If File.Exists(Paths.Graphics & "pictures\" & Sprite & GfxExt) Then
            FrmEditor_Events.picShowPic.Width =
                Drawing.Image.FromFile(Paths.Graphics & "pictures\" & Sprite & GfxExt).Width
            FrmEditor_Events.picShowPic.Height =
                Drawing.Image.FromFile(Paths.Graphics & "pictures\" & Sprite & GfxExt).Height
            FrmEditor_Events.picShowPic.BackgroundImage =
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

        If tempTileLights Is Nothing Then
            tempTileLights = New List(Of LightTileStruct)()

            For x = 0 To Map.MaxX

                For y = 0 To Map.MaxY

                    If IsValidMapPoint(x, y) Then

                        If Map.Tile(x, y).Type = CByte(TileType.Light) Then

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
                                        GameWindow.Draw(LightSprite, New RenderStates(BlendMode.Multiply))
                                    Next

                                    tempTileLights.Add(New LightTileStruct() With {
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
                                        GameWindow.Draw(LightDynamicSprite, New RenderStates(BlendMode.Multiply))
                                    Next

                                    tempTileLights.Add(New LightTileStruct() With {
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
                                tempTileLights.Add(New LightTileStruct() With {
                                                      .Tiles = New List(Of Vector2i)() From {
                                                      New Vector2i(x, y)
                                                      },
.IsFlicker = Map.Tile(x, y).Data2 = 1,
                                                      .Scale =
                                                      New Vector2f(0.3F * Map.Tile(x, y).Data1, 0.3F * Map.Tile(x, y).Data1)
})
                                GameWindow.Draw(LightSprite, New RenderStates(BlendMode.Multiply))
                            End If
                        End If
                    End If
                Next
            Next
        Else

            For Each light As LightTileStruct In tempTileLights
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
                        GameWindow.Draw(LightSprite, New RenderStates(BlendMode.Multiply))
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
                        GameWindow.Draw(LightDynamicSprite, New RenderStates(BlendMode.Multiply))
                    End If
                Next
            Next
        End If

        Dim x2 = ConvertMapX(Player(Myindex).X * 32) + 56 + Player(Myindex).XOffset - CDbl(LightGfxInfo.Width) / 2
        Dim y2 = ConvertMapY(Player(Myindex).Y * 32) + 56 + Player(Myindex).YOffset - CDbl(LightGfxInfo.Height) / 2
        LightSprite.Position = New Vector2f(CSng(x2), CSng(y2))
        LightSprite.Color = Color.Red
        LightSprite.Scale = New Vector2f(0.7F, 0.7F)
        GameWindow.Draw(LightSprite, New RenderStates(BlendMode.Multiply))
        NightSprite = New Sprite(NightGfx)
        GameWindow.Draw(NightSprite)
    End Sub

    Friend Sub EditorSkill_DrawIcon()
        Dim iconnum As Integer
        Dim sRECT As Rectangle
        Dim dRECT As Rectangle

        iconnum = FrmEditor_Skill.nudIcon.Value

        If iconnum < 1 OrElse iconnum > NumSkillIcons Then
            EditorSkill_Icon.Clear(ToSfmlColor(FrmEditor_Skill.picSprite.BackColor))
            EditorSkill_Icon.Display()
            Exit Sub
        End If

        If SkillIconGfxInfo(iconnum).IsLoaded = False Then
            LoadTexture(iconnum, 9)
        End If

        'seeying we still use it, lets update timer
        With SkillIconGfxInfo(iconnum)
            .TextureTimer = GetTickCount() + 100000
        End With

        With sRECT
            .Y = 0
            .Height = PicY
            .X = 0
            .Width = PicX
        End With

        'drect is the same, so just copy it
        dRECT = sRECT

        EditorSkill_Icon.Clear(ToSfmlColor(FrmEditor_Skill.picSprite.BackColor))

        RenderTexture(SkillIconSprite(iconnum), EditorSkill_Icon, dRECT.X, dRECT.Y, sRECT.X, sRECT.Y, sRECT.Width,
                     sRECT.Height)

        EditorSkill_Icon.Display()
    End Sub

    Friend Sub EditorAnim_DrawAnim()
        Dim Animationnum As Integer
        Dim sRECT As Rectangle
        Dim dRECT As Rectangle
        Dim width As Integer, height As Integer
        Dim looptime As Integer
        Dim FrameCount As Integer
        Dim ShouldRender As Boolean

        Animationnum = FrmEditor_Animation.nudSprite0.Value

        If Animationnum < 1 OrElse Animationnum > NumAnimations Then
            EditorAnimation_Anim1.Clear(ToSfmlColor(FrmEditor_Animation.picSprite0.BackColor))
            EditorAnimation_Anim1.Display()
        Else
            If AnimationGfxInfo(Animationnum).IsLoaded = False Then
                LoadTexture(Animationnum, 6)
            End If

            'seeying we still use it, lets update timer
            With AnimationGfxInfo(Animationnum)
                .TextureTimer = GetTickCount() + 100000
            End With

            looptime = FrmEditor_Animation.nudLoopTime0.Value
            FrameCount = FrmEditor_Animation.nudFrameCount0.Value

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
                If FrmEditor_Animation.nudFrameCount0.Value > 0 Then
                    ' total width divided by frame count
                    height = AnimationGfxInfo(Animationnum).Height
                    width = AnimationGfxInfo(Animationnum).Width / FrmEditor_Animation.nudFrameCount0.Value
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

                    EditorAnimation_Anim1.Clear(ToSfmlColor(FrmEditor_Animation.picSprite0.BackColor))
                    RenderTexture(AnimationSprite(Animationnum), EditorAnimation_Anim1, dRECT.X, dRECT.Y, sRECT.X,
                                 sRECT.Y, sRECT.Width, sRECT.Height, dRECT.Width, dRECT.Height)
                    EditorAnimation_Anim1.Display()
                End If
            End If
        End If

        Animationnum = FrmEditor_Animation.nudSprite1.Value

        If Animationnum < 1 OrElse Animationnum > NumAnimations Then
            EditorAnimation_Anim2.Clear(ToSfmlColor(FrmEditor_Animation.picSprite1.BackColor))
            EditorAnimation_Anim2.Display()
        Else
            If AnimationGfxInfo(Animationnum).IsLoaded = False Then
                LoadTexture(Animationnum, 6)
            End If

            'seeying we still use it, lets update timer
            With AnimationGfxInfo(Animationnum)
                .TextureTimer = GetTickCount() + 100000
            End With

            looptime = FrmEditor_Animation.nudLoopTime1.Value
            FrameCount = FrmEditor_Animation.nudFrameCount1.Value
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
                If FrmEditor_Animation.nudFrameCount1.Value > 0 Then
                    ' total width divided by frame count
                    height = AnimationGfxInfo(Animationnum).Height
                    width = AnimationGfxInfo(Animationnum).Width / FrmEditor_Animation.nudFrameCount1.Value
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

                    EditorAnimation_Anim2.Clear(ToSfmlColor(FrmEditor_Animation.picSprite1.BackColor))
                    RenderTexture(AnimationSprite(Animationnum), EditorAnimation_Anim2, dRECT.X, dRECT.Y, sRECT.X,
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

            If x = xDestination AndAlso y = yDestination Then
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

        If Not _inFov.Contains(pos) AndAlso Not IsTransparent(x, y) Then
            If _
                (IsTransparent(x1, y1) AndAlso _inFov.Contains(New Vector2i(x1, y1))) OrElse
                (IsTransparent(x2, y2) AndAlso _inFov.Contains(New Vector2i(x2, y2))) OrElse
                (IsTransparent(x2, y1) AndAlso _inFov.Contains(New Vector2i(x2, y1))) Then
                _inFov.Add(pos)
            End If
        End If
    End Sub

    Private Function IsTransparent(x As Integer, y As Integer) As Boolean
        If Map.Tile(x, y).Type = TileType.Blocked Then
            Return False
        End If

        Return True
    End Function

    Private Function AddToHashSet(hashSet As HashSet(Of Vector2i), x As Integer, y As Integer, centerCell As Vector2i,
                                  <Out> ByRef cell As Vector2i) As Boolean
        cell = New Vector2i(x, y)

        If Not IsValidMapPoint(x, y) OrElse Map.Tile(x, y).Type = TileType.Blocked Then
            Return False
        End If

        If x = Player(Myindex).X AndAlso y = Player(Myindex).Y Then
            Return False
        End If

        If cell.Equals(centerCell) Then
            Return False
        End If

        Return hashSet.Add(cell)
    End Function

    Sub DrawMenuBG()
        For i = 1 To 12
            If PictureGfxInfo(i).IsLoaded = False Then
                LoadTexture(i, 14)
            End If

            ' we use it, lets update timer
            With PictureGfxInfo(i)
                .TextureTimer = GetTickCount() + 100000
            End With
        Next

        ' row 1
        RenderTexture(PictureSprite(1), GameWindow, Types.Settings.ScreenWidth - 512, Types.Settings.ScreenHeight - 512, 0, 0, 512, 512, 512, 512)
        RenderTexture(PictureSprite(2), GameWindow, Types.Settings.ScreenWidth - 1024, Types.Settings.ScreenHeight - 512, 0, 0, 512, 512, 512, 512)
        RenderTexture(PictureSprite(3), GameWindow, Types.Settings.ScreenWidth - 1536, Types.Settings.ScreenHeight - 512, 0, 0, 512, 512, 512, 512)
        RenderTexture(PictureSprite(4), GameWindow, Types.Settings.ScreenWidth - 2048, Types.Settings.ScreenHeight - 512, 0, 0, 512, 512, 512, 512)
        ' row 2
        RenderTexture(PictureSprite(5), GameWindow, Types.Settings.ScreenWidth - 512, Types.Settings.ScreenHeight - 1024, 0, 0, 512, 512, 512, 512)
        RenderTexture(PictureSprite(6), GameWindow, Types.Settings.ScreenWidth - 1024, Types.Settings.ScreenHeight - 1024, 0, 0, 512, 512, 512, 512)
        RenderTexture(PictureSprite(7), GameWindow, Types.Settings.ScreenWidth - 1536, Types.Settings.ScreenHeight - 1024, 0, 0, 512, 512, 512, 512)
        RenderTexture(PictureSprite(8), GameWindow, Types.Settings.ScreenWidth - 2048, Types.Settings.ScreenHeight - 1024, 0, 0, 512, 512, 512, 512)
        ' row 3
        RenderTexture(PictureSprite(9), GameWindow, Types.Settings.ScreenWidth - 512, Types.Settings.ScreenHeight - 1088, 0, 0, 512, 64, 512, 64)
        RenderTexture(PictureSprite(10), GameWindow, Types.Settings.ScreenWidth - 1024, Types.Settings.ScreenHeight - 1088, 0, 0, 512, 64, 512, 64)
        RenderTexture(PictureSprite(11), GameWindow, Types.Settings.ScreenWidth - 1536, Types.Settings.ScreenHeight - 1088, 0, 0, 512, 64, 512, 64)
        RenderTexture(PictureSprite(12), GameWindow, Types.Settings.ScreenWidth - 2048, Types.Settings.ScreenHeight - 1088, 0, 0, 512, 64, 512, 64)
    End Sub

    Public Sub DrawHotbar()
        Dim xO As Long, yO As Long, Width As Long, Height As Long, i As Long, t As Long, sS As String

        xO = Windows(GetWindowIndex("winHotbar")).Window.Left
        yO = Windows(GetWindowIndex("winHotbar")).Window.Top

        ' render start + end wood
        RenderTexture(InterfaceSprite(31), GameWindow, xO - 1, yO + 3, 0, 0, 11, 26, 11, 26)
        RenderTexture(InterfaceSprite(31), GameWindow, xO + 407, yO + 3, 0, 0, 11, 26, 11, 26)

        For i = 1 To MAX_HOTBAR
            xO = Windows(GetWindowIndex("winHotbar")).Window.Left + HotbarLeft + ((i - 1) * HotbarOffsetX)
            yO = Windows(GetWindowIndex("winHotbar")).Window.Top + HotbarTop
            Width = 36
            Height = 36

            ' don't render last one
            If i <> 10 Then
                ' render wood
                RenderTexture(InterfaceSprite(32), GameWindow, xO + 30, yO + 3, 0, 0, 13, 26, 13, 26)
            End If

            ' render box
            RenderTexture(InterfaceSprite(30), GameWindow, xO - 2, yO - 2, 0, 0, Width, Height, Width, Height)

            ' render icon
            If Not (DragBox.Origin = PartOriginType.Hotbar And DragBox.Slot = i) Then
                Select Case Hotbar(i).SlotType
                    Case 1 ' inventory
                        If Len(Item(Hotbar(i).Slot).Name) > 0 And Item(Hotbar(i).Slot).Pic > 0 Then
                            RenderTexture(ItemSprite(Item(Hotbar(i).Slot).Pic), GameWindow, xO, yO, 0, 0, 32, 32, 32, 32)
                        End If
                    Case 2 ' spell
                        If Len(Skill(Hotbar(i).Slot).Name) > 0 And Skill(Hotbar(i).Slot).Icon > 0 Then
                            RenderTexture(SkillIconSprite(Skill(Hotbar(i).Slot).Icon), GameWindow, xO, yO, 0, 0, 32, 32, 32, 32)
                            For t = 1 To MAX_PLAYER_SKILLS
                                If GetPlayerSkill(Myindex, t) > 0 Then
                                    If GetPlayerSkill(Myindex, t) = Hotbar(i).Slot And GetPlayerSkillCD(Myindex, t) > 0 Then
                                        RenderTexture(SkillIconSprite(Skill(Hotbar(i).Slot).Icon), GameWindow, xO, yO, 0, 0, 32, 32, 32, 32, 255, 100, 100, 100)
                                    End If
                                End If
                            Next
                        End If
                End Select
            End If

            ' draw the numbers
            sS = Str(i)
            If i = 10 Then sS = "0"
            RenderText(sS, GameWindow, xO + 4, yO + 19, Color.White, Color.White)
        Next
    End Sub

    Public Sub DrawChatBubble(ByVal Index As Long)
        Dim theArray() As String, x As Long, y As Long, i As Long, MaxWidth As Long, x2 As Long, y2 As Long, Colour As Integer, tmpNum As Long
    
        With chatBubble(Index)
            ' exit out early
            If .target = 0 Then Exit Sub

            Colour = .Color

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
            RenderTexture(InterfaceSprite(33), GameWindow, x2 - 9, y2 - 5, 0, 0, 9, 5, 9, 5)

            ' top right
            RenderTexture(InterfaceSprite(33), GameWindow, x2 + MaxWidth, y2 - 5, 119, 0, 9, 5, 9, 5)

            ' top
            RenderTexture(InterfaceSprite(33), GameWindow, x2, y2 - 5, 9, 0, MaxWidth, 5, 5, 5)

            ' bottom left
            RenderTexture(InterfaceSprite(33), GameWindow, x2 - 9, y, 0, 19, 9, 6, 9, 6)

            ' bottom right
            RenderTexture(InterfaceSprite(33), GameWindow, x2 + MaxWidth, y, 119, 19, 9, 6, 9, 6)

            ' bottom - left half
            RenderTexture(InterfaceSprite(33), GameWindow, x2, y, 9, 19, (MaxWidth \ 2) - 5, 6, 6, 6)

            ' bottom - right half
            RenderTexture(InterfaceSprite(33), GameWindow, x2 + (MaxWidth \ 2) + 6, y, 9, 19, (MaxWidth \ 2) - 5, 6, 9, 6)

            ' left
            RenderTexture(InterfaceSprite(33), GameWindow, x2 - 9, y2, 0, 6, 9, (UBound(theArray) * 12), 9, 6)

            ' right
            RenderTexture(InterfaceSprite(33), GameWindow, x2 + MaxWidth, y2, 119, 6, 9, (UBound(theArray) * 12), 9, 6)

            ' center
            RenderTexture(InterfaceSprite(33), GameWindow, x2, y2, 9, 5, MaxWidth, (UBound(theArray) * 12), 9, 5)

            ' little pointy bit
            RenderTexture(InterfaceSprite(33), GameWindow, x - 5, y, 58, 19, 11, 11, 11, 11)

            ' render each line centralised
            tmpNum = UBound(theArray)

            For i = 1 To tmpNum           
                RenderText(theArray(i), GameWindow, x - (theArray(i).Length / 2) - (TextWidth(theArray(i)) / 2), y2, GetSfmlColor(.Color), Color.Black)
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