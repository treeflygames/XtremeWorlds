
Imports System.Diagnostics.Eventing.Reader
Imports System.Management
Imports System.Reflection.Metadata.Ecma335
Imports System.Runtime.Versioning
Imports System.Security.AccessControl
Imports System.Security.Principal
Imports System.Windows.Forms.Design.AxImporter
Imports Core
Imports Core.Enum
Imports Core.Types
Imports SFML.Graphics
Module C_Interface
    ' GUI
    Public Windows() As Types.WindowStruct
    Public WindowCount As Long
    Public activeWindow As Long

    ' GUI parts
    Public DragBox As EntityPartStruct

    ' Used for automatically the zOrder
    Private zOrder_Win As Long
    Private zOrder_Con As Long

    Public Sub CreateEntity(winNum As Long, zOrder As Long, name As String, color As Color, tType As EntityType, ByRef design() As Long, ByRef image() As Long, ByRef callback() As Action,
       Optional left As Long = 0, Optional top As Long = 0, Optional width As Long = 0, Optional height As Long = 0, Optional visible As Boolean = True, Optional canDrag As Boolean = False, Optional Max As Long = 0, Optional Min As Long = 0, Optional value As Long = 0, Optional text As String = "",
       Optional align As Byte = 0, Optional font As String = "Georgia.ttf", Optional alpha As Long = 255, Optional clickThrough As Boolean = False, Optional xOffset As Long = 0, Optional yOffset As Long = 0, Optional zChange As Byte = 0, Optional censor As Boolean = False, Optional icon As Long = 0,
       Optional onDraw As Action = Nothing, Optional isActive As Boolean = True, Optional tooltip As String = "", Optional group As Long = 0, Optional locked As Boolean = False)

        Dim i As Long

        ' check if it's a legal number
        If winNum <= 0 Or winNum > WindowCount Then
            Exit Sub
        End If

        ' re-dim the control array
        With Windows(winNum)
            .ControlCount = .ControlCount + 1
            ReDim Preserve .Controls(.ControlCount)
        End With

        ' Set the new control values
        With Windows(winNum).Controls(Windows(winNum).ControlCount)
            .Name = name
            .Type = tType

            ReDim .Design(EntState.Count - 1)
            ReDim .Image(EntState.Count - 1)
            ReDim .CallBack(EntState.Count - 1)

            ' loop through states
            For i = 0 To EntState.Count - 1
                .Design(i) = design(i)
                .Image(i) = image(i)
                .CallBack(i) = callback(i)
            Next

            .Left = left
            .Top = top
            .OrigLeft = left
            .OrigTop = top
            .Width = width
            .Height = height
            .Visible = visible
            .CanDrag = canDrag
            .Max = Max
            .Min = Min
            .Value = value
            .Text = text
            .Align = align
            .Font = font
            .Color = color
            .Alpha = alpha
            .ClickThrough = clickThrough
            .xOffset = xOffset
            .yOffset = yOffset
            .zChange = zChange
            .zOrder = zOrder
            .Enabled = True
            .OnDraw = onDraw
            .Tooltip = tooltip
            .Group = group
            .Censor = censor
            .Icon = icon
            .Locked = locked
            ReDim .List(0)
        End With

        ' set the active control
        If isActive Then Windows(winNum).ActiveControl = Windows(winNum).ControlCount

        ' set the zOrder
        zOrder_Con = zOrder_Con + 1
    End Sub

    Public Sub UpdateZOrder(winNum As Long, Optional forced As Boolean = False)
        Dim i As Long
        Dim oldZOrder As Long

        With Windows(winNum).Window

            If Not forced Then If .zChange = 0 Then Exit Sub
            If .zOrder = WindowCount Then Exit Sub
            oldZOrder = .zOrder

            For i = 1 To WindowCount

                If Windows(i).Window.zOrder > oldZOrder Then
                    Windows(i).Window.zOrder = Windows(i).Window.zOrder - 1
                End If

            Next

            .zOrder = WindowCount
        End With

    End Sub

    Public Sub SortWindows()
        Dim tempWindow As WindowStruct
        Dim i As Long, x As Long

        x = 1

        While x <> 0
            x = 0

            For i = 1 To WindowCount - 1

                If Windows(i).Window.zOrder > Windows(i + 1).Window.zOrder Then
                    tempWindow = Windows(i)
                    Windows(i) = Windows(i + 1)
                    Windows(i + 1) = tempWindow
                    x = 1
                End If

            Next

        End While

    End Sub

    Public Sub RenderEntities()
        Dim i As Long, x As Long, curZOrder As Long

        ' don't render anything if we don't have any containers
        If WindowCount = 0 Then Exit Sub

        ' reset zOrder
        curZOrder = 1

        ' loop through windows
        Do While curZOrder <= WindowCount
            For i = 1 To WindowCount
                If curZOrder = Windows(i).Window.zOrder Then
                    ' increment
                    curZOrder = curZOrder + 1
                    ' make sure it's visible
                    If Windows(i).Window.Visible Then
                        ' render container
                        RenderWindow(i)

                        ' render controls
                        For x = 1 To Windows(i).ControlCount
                            If Windows(i).Controls(x).Visible Then
                                RenderEntity(i, x)
                            End If
                        Next
                    End If
                End If
            Next
        Loop
    End Sub

    Public Sub RenderEntity(winNum As Long, entNum As Long)
        Dim xO As Long, yO As Long, hor_centre As Long, ver_centre As Long, height As Long, width As Long, left As Long, sprite As Sprite, xOffset As Long
        Dim textArray() As String, count As Long, yOffset As Long, i As Long, taddText As String

        ' check if the window exists
        If winNum <= 0 Or winNum > WindowCount Then
            Exit Sub
        End If

        ' check if the entity exists
        If entNum <= 0 Or entNum > Windows(winNum).ControlCount Then
            Exit Sub
        End If

        ' check the container's position
        xO = Windows(winNum).Window.Left
        yO = Windows(winNum).Window.Top

        With Windows(winNum).Controls(entNum)
            ' find the control type
            Select Case .Type
                ' picture box
                Case EntityType.PictureBox
                    ' render specific designs
                    If .Design(.State) > 0 Then
                        RenderDesign(.Design(.State), .Left + xO, .Top + yO, .Width, .Height, .Alpha)
                    End If

                    ' render image
                    If .Image(.State) > 0 Then
                        RenderTexture(InterfaceSprite(.Image(.State)), Window, .Left + xO, .Top + yO, 0, 0, .Width, .Height, .Width, .Height, .Alpha)
                    End If

                ' textbox
                Case EntityType.TextBox
                    ' render specific designs
                    If .Design(.State) > 0 Then
                        RenderDesign(.Design(.State), .Left + xO, .Top + yO, .Width, .Height, .Alpha)
                    End If

                    ' render image
                    If .Image(.State) > 0 Then
                        RenderTexture(InterfaceSprite(.Image(.State)), Window, .Left + xO, .Top + yO, 0, 0, .Width, .Height, .Width, .Height, .Alpha)
                    End If

                    If activeWindow = winNum And Windows(winNum).ActiveControl = entNum Then
                        taddText = chatShowLine
                    End If

                    ' render text
                    If Not .Censor Then
                        RenderText(.Text & taddText, Window, .Left + xO + .xOffset, .Top + yO + .yOffset, .Color, Color.Black)
                    Else
                        RenderText(CensorText(.Text) & taddText, Window, .Left + xO + .xOffset, .Top + yO + .yOffset, Color.White, Color.Black)
                    End If

                ' buttons
                Case EntityType.Button
                    ' render specific designs
                    If .Design(.State) > 0 Then
                        If .Design(.State) > 0 Then
                            RenderDesign(.Design(.State), .Left + xO, .Top + yO, .Width, .Height)
                        End If
                    End If

                    ' render image
                    If .Image(.State) > 0 Then
                        If .Image(.State) > 0 Then
                            RenderTexture(InterfaceSprite(.Image(.State)), Window, .Left + xO, .Top + yO, 0, 0, .Width, .Height, .Width, .Height)
                        End If
                    End If

                    ' render icon
                    If .Icon > 0 Then
                        Width =  ItemGfxInfo(.Icon).width
                        Height =  ItemGfxInfo(.Icon).height

                        ' render the icon
                        If ItemGfxInfo(.Icon).IsLoaded = False Then
                            LoadTexture(.Icon, 4)
                        End If

                        RenderTexture(ItemSprite(.Icon), Window, .Left + xO + .xOffset, .Top + yO + .yOffset, 0, 0, Width, Height, Width, Height)
                    End If

                    ' for changing the text space
                    xOffset = width

                    ' calculate the vertical centre
                    height = GetTextHeight(.Text)
                    If height > .Height Then
                        ver_centre = .Top + yO
                    Else
                        ver_centre = .Top + yO + ((.Height - height) \ 2) - 2
                    End If

                    ' calculate the horizontal centre
                    width = TextWidth(.Text)
                    If width > .Width Then
                        hor_centre = .Left + xO + xOffset
                    Else
                        hor_centre = .Left + xO + xOffset + ((.Width - width - xOffset) \ 2) - 2
                    End If

                    RenderText(.Text, Window, hor_centre, ver_centre, .Color, Color.Black)

                ' labels
                Case EntityType.Label
                    If Len(.Text) > 0 Then
                        Select Case .Align
                            Case AlignmentType.Left
                                ' check if need to word wrap
                                If TextWidth(.Text) > .Width Then
                                    ' wrap text
                                    WordWrap_Array(.Text, .Width, textArray)

                                    ' render text
                                    count = UBound(textArray)

                                    For i = 1 To count
                                        RenderText(textArray(i), Window, .Left - xO, .Top + yO + yOffset, .Color, Color.Black)
                                        yOffset = yOffset + 14
                                    Next
                                Else
                                    ' just one line
                                    RenderText(.Text, Window, .Left + xO, .Top + yO, .Color, Color.Black)
                                End If

                            Case AlignmentType.Right
                                ' check if need to word wrap
                                If TextWidth(.Text) > .Width Then
                                    ' wrap text
                                    WordWrap_Array(.Text, .Width, textArray)

                                    ' render text
                                    count = UBound(textArray)

                                    For i = 1 To count
                                        left = .Left + .Width - TextWidth(textArray(i))
                                        RenderText(textArray(i), Window, left + xO - FontSize, .Top + yO + yOffset, .Color, Color.Black)
                                        yOffset = yOffset + 14
                                    Next
                                Else
                                    ' just one line
                                    left = .Left + .Width - TextWidth(.Text)
                                    RenderText(.Text, Window, left + xO - FontSize, .Top + yO, .Color, Color.Black)
                                End If

                            Case AlignmentType.Center
                                ' Check if need to word wrap
                                If TextWidth(.Text) > .Width Then
                                    ' Wrap text
                                    WordWrap_Array(.Text, .Width, textArray)

                                    ' Render text
                                    count = UBound(textArray)

                                    For i = 1 To count
                                        left = .Left + (.Width \ 2) - (TextWidth(textArray(i)) \ 2) - 4
                                        RenderText(textArray(i), Window, left + xO, .Top + yO + yOffset, .Color, Color.Black)
                                        yOffset = yOffset + 14
                                    Next
                                Else
                                    ' Just one line
                                    left = .Left + (.Width \ 2) - (TextWidth(.Text) \ 2) - FontSize
                                    RenderText(.Text, Window, left + xO, .Top + yO, .Color, Color.Black)
                                End If
                        End Select
                    End If

                ' Checkboxes
                Case EntityType.Checkbox
                    Select Case .Design(0)
                        Case DesignType.ChkNorm
                            ' empty?
                            If .Value = 0 Then sprite = InterfaceSprite(2) Else sprite = InterfaceSprite(3)

                            ' render box
                            RenderTexture(sprite, Window, .Left + xO, .Top + yO, 0, 0, 16, 16, 16, 16)

                            ' find text position
                            Select Case .Align
                                Case AlignmentType.Left
                                    left = .Left + 18 + xO
                                Case AlignmentType.Right
                                    left = .Left + 18 + (.Width - 18) - TextWidth(.Text) + xO
                                Case AlignmentType.Center
                                    left = .Left + 18 + ((.Width - 18) / 2) - (TextWidth(.Text) / 2) + xO
                            End Select

                            ' render text
                            RenderText(.Text, Window, left, .Top + yO, .Color, Color.Black)

                        Case DesignType.ChkChat
                            If .Value = 0 Then .Alpha = 150 Else .Alpha = 255

                            ' render box
                            RenderTexture(InterfaceSprite(51), Window, .Left + xO, .Top + yO, 0, 0, 49, 23, 49, 23)

                            ' render text
                            left = .Left + 22 - (TextWidth(.Text) / 2) + xO
                            RenderText(.Text, Window, left, .Top + yO + 4, .Color, Color.Black)

                        Case DesignType.ChkCustom_Buying
                            If .Value = 0 Then sprite = InterfaceSprite(58) Else sprite = InterfaceSprite(56)
                            RenderTexture(sprite, Window, .Left + xO, .Top + yO, 0, 0, 49, 20, 49, 20)

                        Case DesignType.ChkCustom_Selling
                            If .Value = 0 Then sprite = InterfaceSprite(59) Else sprite = InterfaceSprite(57)
                            RenderTexture(sprite, Window, .Left + xO, .Top + yO, 0, 0, 49, 20, 49, 20)
                    End Select

                ' comboboxes
                Case EntityType.Combobox
                    Select Case .Design(0)
                        Case DesignType.ComboNorm
                            ' draw the background
                            RenderDesign(DesignType.TextBlack, .Left + xO, .Top + yO, .Width, .Height)

                            ' render the text
                            If .Value > 0 Then
                                If .Value <= UBound(.List) Then
                                    RenderText(.List(.Value), Window, .Left + xO, .Top + yO, .Color, Color.Black)
                                End If
                            End If

                            ' draw the little arow
                            RenderTexture(InterfaceSprite(66), Window, .Left + xO + .Width, .Top + yO, 0, 0, 5, 4, 5, 4)
                    End Select
            End Select

            If Not .OnDraw Is Nothing Then .OnDraw()

        End With

    End Sub

    Public Sub RenderWindow(winNum As Long)
        Dim x As Long, y As Long, i As Long, left As Long

        ' check if the window exists
        If winNum <= 0 Or winNum > WindowCount Then
            Exit Sub
        End If

        With Windows(winNum).Window
            If .Censor Then
                .Text = CensorText(.Text)
            Else
                .Text = .Text
            End If

            Select Case .Design(0)
                Case DesignType.ComboMenuNorm
                    RenderTexture(InterfaceSprite(1), Window, .Left, .Top, 0, 0, .Width, .Height, 157, 0, 0, 0)

                    ' text
                    If UBound(.List) > 0 Then
                        y = .Top + 2
                        x = .Left

                        For i = 1 To UBound(.List)
                            ' render select
                            If i = .Value Or i = .Group Then
                                RenderTexture(InterfaceSprite(1), Window, x, y - 1, 0, 0, .Width, 15, 255, 0, 0, 0)
                            End If

                            ' render text
                            left = x + (.Width \ 2) - (TextWidth(.List(i)) \ 2)

                            If i = .Value Or i = .Group Then
                                RenderText(.List(i), Window, left, y, Color.White, Color.Black)
                            Else
                                RenderText(.List(i), Window, left, y, Color.White, Color.Black)
                            End If
                            y = y + 16
                        Next
                    End If
                    Exit Sub
            End Select

            Select Case .Design(.State)

                Case DesignType.Win_Black
                    RenderTexture(InterfaceSprite(61), Window, .Left, .Top, 0, 0, .Width, .Height, 190, 255, 255, 255)

                Case DesignType.Win_Norm
                    ' render window
                    RenderDesign(DesignType.Wood, .Left, .Top, .Width, .Height)
                    RenderDesign(DesignType.Green, .Left, .Top, .Width, 23)

                    ' render the icon
                    If ItemGfxInfo(.Icon).IsLoaded = False Then
                        LoadTexture(.Icon, 4)
                    End If
                    RenderTexture(ItemSprite(.Icon), Window, .Left + .xOffset, .Top - 16 + .yOffset, 0, 0, .Width, .Height, .Width, .Height)

                    ' render the caption
                    RenderText(Trim$(.Text), Window, .Left + 32, .Top + 4, Color.White, Color.Black)

                Case DesignType.Win_NoBar
                    ' render window
                    RenderDesign(DesignType.Wood, .Left, .Top, .Width, .Height)

                Case DesignType.Win_Empty
                    ' render window
                    RenderDesign(DesignType.Wood_Empty, .Left, .Top, .Width, .Height)
                    RenderDesign(DesignType.Green, .Left, .Top, .Width, 23)

                    ' render the icon
                    If ItemGfxInfo(.Icon).IsLoaded = False Then
                        LoadTexture(.Icon, 4)
                    End If
                    RenderTexture(ItemSprite(.Icon), Window, .Left + .xOffset, .Top - 16 + .yOffset, 0, 0, .Width, .Height, .Width, .Height)

                    ' render the caption
                    RenderText(Trim$(.Text), Window, .Left + 32, .Top + 4, Color.White, Color.Black)

                Case DesignType.Win_Desc
                    RenderDesign(DesignType.Win_Desc, .Left, .Top, .Width, .Height)

                Case DesignType.Win_Shadow
                    RenderDesign(DesignType.Win_Shadow, .Left, .Top, .Width, .Height)

                Case DesignType.Win_Party
                    RenderDesign(DesignType.Win_Party, .Left, .Top, .Width, .Height)
            End Select

            If Not .OnDraw Is Nothing Then .OnDraw()
        End With

    End Sub

    Public Sub RenderDesign(design As Long, left As Long, top As Long, width As Long, height As Long, Optional alpha As Long = 255)
        Dim bs As Long

        Select Case design
            Case DesignType.MenuHeader
                ' render the header
                RenderTexture(InterfaceSprite(61), Window, left, top, 0, 0, width, height, width, height, 200, 47, 77, 29)

            Case DesignType.MenuOption
                ' render the option
                RenderTexture(InterfaceSprite(61), Window, left, top, 0, 0, width, height, width, height, 200, 98, 98, 98)

            Case DesignType.Wood
                bs = 4
                ' render the wood box
                RenderEntity_Square(DesignSprite(1), left, top, width, height, bs, alpha)

                ' render wood texture
                RenderTexture(InterfaceSprite(1), Window, Left + bs, Top + bs, 100, 100, Width - (bs * 2), Height - (bs * 2), Width - (bs * 2), Height - (bs * 2), alpha)

            Case DesignType.Wood_Small
                bs = 2
                ' render the wood box
                RenderEntity_Square(DesignSprite(8),Left + bs, Top + bs, width, height, bs, alpha)

                ' render wood texture
                RenderTexture(InterfaceSprite(1), Window, left + bs, top + bs, 100, 100, Width - (bs * 2), Height - (bs * 2), Width - (bs * 2), Height - (bs * 2))

            Case DesignType.Wood_Empty
                bs = 4
                ' render the wood box
                RenderEntity_Square(DesignSprite(9), left, top, width, height, bs, alpha)

            Case DesignType.Green
                bs = 2
                ' render the green box
                RenderEntity_Square(DesignSprite(2), left, top, width, height, bs, alpha)

                ' render green gradient overlay
                RenderTexture(GradientSprite(1), Window, left + bs, top + bs, 0, 0, width - (bs * 2), height - (bs * 2), 128, 128, alpha)

            Case DesignType.Green_Hover
                bs = 2
                ' render the green box
                RenderEntity_Square(DesignSprite(2), left, top, width, height, bs, alpha)

                ' render green gradient overlay
                RenderTexture(GradientSprite(2), Window, left + bs, top + bs, 0, 0, width - (bs * 2), height - (bs * 2), 128, 128, alpha)

            Case DesignType.Green_Click
                bs = 2
                ' render the green box
                RenderEntity_Square(DesignSprite(2), left, top, width, height, bs, alpha)

                ' render green gradient overlay
                RenderTexture(GradientSprite(3), Window, left + bs, top + bs, 0, 0, width - (bs * 2), height - (bs * 2), 128, 128, alpha)

            Case DesignType.Red
                bs = 2
                ' render the red box
                RenderEntity_Square(DesignSprite(3), left, top, width, height, bs, alpha)

                ' render red gradient overlay
                RenderTexture(GradientSprite(4), Window, left + bs, top + bs, 0, 0, width - (bs * 2), height - (bs * 2), 128, 128, alpha)

            Case DesignType.Red_Hover
                bs = 2
                ' render the red box
                RenderEntity_Square(DesignSprite(3), left, top, width, height, bs, alpha)

                ' render red gradient overlay
                RenderTexture(GradientSprite(5), Window, left + bs, top + bs, 0, 0, width - (bs * 2), height - (bs * 2), 128, 128, alpha)

            Case DesignType.Red_Click
                bs = 2
                ' render the red box
                RenderEntity_Square(DesignSprite(3), left, top, width, height, bs, alpha)

                ' render red gradient overlay
                RenderTexture(GradientSprite(6), Window, left + bs, top + bs, 0, 0, width - (bs * 2), height - (bs * 2), 128, 128, alpha)

            Case DesignType.Blue
                bs = 2
                ' render the Blue box
                RenderEntity_Square(DesignSprite(14), left, top, width, height, bs, alpha)

                ' render Blue gradient overlay
                RenderTexture(GradientSprite(8), Window, left + bs, top + bs, 0, 0, width - (bs * 2), height - (bs * 2), 128, 128, alpha)

            Case DesignType.Blue_Hover
                bs = 2
                ' render the Blue box
                RenderEntity_Square(DesignSprite(14), left, top, width, height, bs, alpha)

                ' render Blue gradient overlay
                RenderTexture(GradientSprite(9), Window, left + bs, top + bs, 0, 0, width - (bs * 2), height - (bs * 2), 128, 128, alpha)

            Case DesignType.Blue_Click
                bs = 2
                ' render the Blue box
                RenderEntity_Square(DesignSprite(14), left, top, width, height, bs, alpha)

                ' render Blue gradient overlay
                RenderTexture(GradientSprite(10), Window, left + bs, top + bs, 0, 0, width - (bs * 2), height - (bs * 2), 128, 128, alpha)

            Case DesignType.Orange
                bs = 2
                ' render the Orange box
                RenderEntity_Square(DesignSprite(15), left, top, width, height, bs, alpha)

                ' render Orange gradient overlay
                RenderTexture(GradientSprite(11), Window, left + bs, top + bs, 0, 0, width - (bs * 2), height - (bs * 2), 128, 128, alpha)

            Case DesignType.Orange_Hover
                bs = 2
                ' render the Orange box
                RenderEntity_Square(DesignSprite(15), left, top, width, height, bs, alpha)

                ' render Orange gradient overlay
                RenderTexture(GradientSprite(12), Window, left + bs, top + bs, 0, 0, width - (bs * 2), height - (bs * 2), 128, 128, alpha)

            Case DesignType.Orange_Click
                bs = 2
                ' render the Orange box
                RenderEntity_Square(DesignSprite(15), left, top, width, height, bs, alpha)

                ' render Orange gradient overlay
                RenderTexture(GradientSprite(13), Window, left + bs, top + bs, 0, 0, width - (bs * 2), height - (bs * 2), 128, 128, alpha)

            Case DesignType.Grey
                bs = 2
                ' render the Orange box
                RenderEntity_Square(DesignSprite(17), left, top, width, height, bs, alpha)

                ' render Orange gradient overlay
                RenderTexture(GradientSprite(14), Window, left + bs, top + bs, 0, 0, width - (bs * 2), height - (bs * 2), 128, 128, alpha)

            Case DesignType.Parchment
                bs = 20
                ' render the parchment box
                RenderEntity_Square(DesignSprite(4), left, top, width, height, bs, alpha)

            Case DesignType.BlackOval
                bs = 4
                ' render the black oval
                RenderEntity_Square(DesignSprite(5), left, top, width, height, bs, alpha)

            Case DesignType.TextBlack
                bs = 5
                ' render the black oval
                RenderEntity_Square(DesignSprite(6), left, top, width, height, bs, alpha)

            Case DesignType.TextWhite
                bs = 5
                ' render the black oval
                RenderEntity_Square(DesignSprite(7), left, top, width, height, bs, alpha)

            Case DesignType.TextBlack_Sq
                bs = 4
                ' render the black oval
                RenderEntity_Square(DesignSprite(10), left, top, width, height, bs, alpha)

            Case DesignType.Win_Desc
                bs = 8
                ' render black square
                RenderEntity_Square(DesignSprite(11), left, top, width, height, bs, alpha)

            Case DesignType.DescPic
                bs = 3
                ' render the green box
                RenderEntity_Square(DesignSprite(12), left, top, width, height, bs, alpha)

                ' render green gradient overlay
                RenderTexture(GradientSprite(7), Window, left + bs, top + bs, 0, 0, width - (bs * 2), height - (bs * 2), 128, 128, alpha)

            Case DesignType.Win_Shadow
                bs = 35
                ' render the green box
                RenderEntity_Square(DesignSprite(13), left - bs, top - bs, width + (bs * 2), height + (bs * 2), bs, alpha)

            Case DesignType.Win_Party
                bs = 12
                ' render black square
                RenderEntity_Square(DesignSprite(16), left, top, width, height, bs, alpha)

            Case DesignType.TileBox
                bs = 4
                ' render box
                RenderEntity_Square(DesignSprite(18), left, top, width, height, bs, alpha)
        End Select

    End Sub

    Public Sub RenderEntity_Square(sprite As Sprite, x As Long, y As Long, width As Long, height As Long, borderSize As Long, Optional alpha As Long = 255)
        Dim bs As Long

        ' Set the border size
        bs = borderSize

        ' Draw centre
        RenderTexture(sprite, Window, x + bs, y + bs, bs + 1, bs + 1, width - (bs * 2), height - (bs * 2), , , , alpha)

        ' Draw top side
        RenderTexture(sprite, Window, x + bs, y, bs, 0, width - (bs * 2), bs, 1, bs, alpha)

        ' Draw left side
        RenderTexture(sprite, Window, x, y + bs, 0, bs, bs, height - (bs * 2), bs, , alpha)

        ' Draw right side
        RenderTexture(sprite, Window, x + width - bs, y + bs, bs + 3, bs, bs, height - (bs * 2), bs, , alpha)

        ' Draw bottom side
        RenderTexture(sprite, Window, x + bs, y + height - bs, bs, bs + 3, width - (bs * 2), bs, 1, bs, alpha)

        ' Draw top left corner
        RenderTexture(sprite, Window, x, y, 0, 0, bs, bs, bs, bs, alpha)

        ' Draw top right corner
        RenderTexture(sprite, Window, x + width - bs, y, bs + 3, 0, bs, bs, bs, bs, alpha)

        ' Draw bottom left corner
        RenderTexture(sprite, Window, x, y + height - bs, 0, bs + 3, bs, bs, bs, bs, alpha)

        ' Draw bottom right corner
        RenderTexture(sprite, Window, x + width - bs, y + height - bs, bs + 3, bs + 3, bs, bs, bs, bs, alpha)
    End Sub

    Sub Combobox_AddItem(winIndex As Long, controlIndex As Long, text As String)
        Dim count As Long
        count = UBound(Windows(winIndex).Controls(controlIndex).List)
        ReDim Preserve Windows(winIndex).Controls(controlIndex).List(count + 1)
        Windows(winIndex).Controls(controlIndex).List(count + 1) = text
    End Sub

    Public Sub CreateWindow(name As String, caption As String, font As String, zOrder As Long, left As Long, top As Long, width As Long, height As Long, icon As Long,
       Optional visible As Boolean = True, Optional xOffset As Long = 0, Optional yOffset As Long = 0, Optional design_norm As Long = 0, Optional design_hover As Long = 0, Optional design_mousedown As Long = 0,
       Optional image_norm As Long = 0, Optional image_hover As Long = 0, Optional image_mousedown As Long = 0,
       Optional ByRef callback_norm As Action = Nothing, Optional ByRef callback_hover As Action = Nothing, Optional ByRef callback_mousemove As Action = Nothing, Optional ByRef callback_mousedown As Action = Nothing, Optional ByRef callback_dblclick As Action = Nothing, Optional onDraw As Action = Nothing,
       Optional canDrag As Boolean = True, Optional zChange As Byte = True, Optional isActive As Boolean = True, Optional clickThrough As Boolean = False)

        Dim i As Long
        Dim design(EntState.Count - 1) As Long
        Dim image(EntState.Count - 1) As Long
        Dim callback(EntState.Count - 1) As Action

        ' fill temp arrays
        design(EntState.Normal) = design_norm
        design(EntState.Hover) = design_hover
        design(EntState.MouseDown) = design_mousedown
        design(EntState.DblClick) = design_norm
        design(EntState.MouseUp) = design_norm
        image(EntState.Normal) = image_norm
        image(EntState.Hover) = image_hover
        image(EntState.MouseDown) = image_mousedown
        image(EntState.DblClick) = image_norm
        image(EntState.MouseUp) = image_norm
        callback(EntState.Normal) = callback_norm
        callback(EntState.Hover) = callback_hover
        callback(EntState.MouseDown) = callback_mousedown
        callback(EntState.MouseMove) = callback_mousemove
        callback(EntState.DblClick) = callback_dblclick

        ' redim the windows
        WindowCount = WindowCount + 1
        ReDim Preserve Windows(WindowCount)

        ' set the properties
        With Windows(WindowCount).Window
            .Name = name
            .Type = EntityType.Window

            ReDim .Design(EntState.Count - 1)
            ReDim .Image(EntState.Count - 1)
            ReDim .CallBack(EntState.Count - 1)

            ' loop through states
            For i = 0 To EntState.Count - 1
                .Design(i) = design(i)
                .Image(i) = image(i)
                .CallBack(i) = callback(i)
            Next

            .Left = left
            .Top = top
            .OrigLeft = left
            .OrigTop = top
            .Width = width
            .Height = height
            .Visible = visible
            .CanDrag = canDrag
            .Font = font
            .Text = caption
            .xOffset = xOffset
            .yOffset = yOffset
            .Icon = icon
            .Enabled = True
            .zChange = zChange
            .zOrder = zOrder
            .OnDraw = onDraw
            .ClickThrough = clickThrough

            ' set active
            If .Visible Then activeWindow = WindowCount
        End With

        ' set the zOrder
        zOrder_Win = zOrder_Win + 1
    End Sub

    Public Sub CreateTextbox(winNum As Long, name As String, left As Long, top As Long, width As Long, height As Long,
        Optional text As String = "", Optional font As String = "Georgia.ttf", Optional align As Byte = AlignmentType.Left, Optional visible As Boolean = True, Optional alpha As Long = 255, Optional isActive As Boolean = True, Optional xOffset As Long = 0, Optional yOffset As Long = 0, Optional image_norm As Long = 0,
        Optional image_hover As Long = 0, Optional image_mousedown As Long = 0, Optional design_norm As Long = 0, Optional design_hover As Long = 0, Optional design_mousedown As Long = 0, Optional censor As Boolean = False, Optional icon As Long = 0,
        Optional ByRef callback_norm As Action = Nothing, Optional ByRef callback_hover As Action = Nothing, Optional ByRef callback_mousedown As Action = Nothing, Optional ByRef callback_mousemove As Action = Nothing, Optional ByRef callback_dblclick As Action = Nothing, Optional ByRef callback_enter As Action = Nothing)

        Dim design(EntState.Count - 1) As Long
        Dim image(EntState.Count - 1) As Long
        Dim callback(EntState.Count - 1) As Action

        ' fill temp arrays
        design(EntState.Normal) = design_norm
        design(EntState.Hover) = design_hover
        design(EntState.MouseDown) = design_mousedown
        image(EntState.Normal) = image_norm
        image(EntState.Hover) = image_hover
        image(EntState.MouseDown) = image_mousedown
        callback(EntState.Normal) = callback_norm
        callback(EntState.Hover) = callback_hover
        callback(EntState.MouseDown) = callback_mousedown
        callback(EntState.MouseMove) = callback_mousemove
        callback(EntState.DblClick) = callback_dblclick
        callback(EntState.Enter) = callback_enter

        ' create the textbox
        CreateEntity(winNum, zOrder_Con, name, Color.White, EntityType.TextBox, design, image, callback, left, top, width, height, visible, , , , , text, align, font, alpha, , xOffset, yOffset,  , censor, icon, , isActive)
    End Sub

    Public Sub CreatePictureBox(winNum As Long, name As String, left As Long, top As Long, width As Long, height As Long,
       Optional visible As Boolean = True, Optional canDrag As Boolean = False, Optional alpha As Long = 255, Optional clickThrough As Boolean = True, Optional image_norm As Long = 0, Optional image_hover As Long = 0, Optional image_mousedown As Long = 0, Optional design_norm As Long = 0, Optional design_hover As Long = 0, Optional design_mousedown As Long = 0,
       Optional ByRef callback_norm As Action = Nothing, Optional ByRef callback_hover As Action = Nothing, Optional ByRef callback_mousedown As Action = Nothing,
       Optional ByRef callback_mousemove As Action = Nothing, Optional ByRef callback_dblclick As Action = Nothing, Optional ByRef onDraw As Action = Nothing)

        Dim design(EntState.Count - 1) As Long
        Dim image(EntState.Count - 1) As Long
        Dim callback(EntState.Count - 1) As Action

        ' fill temp arrays
        design(EntState.Normal) = design_norm
        design(EntState.Hover) = design_hover
        design(EntState.MouseDown) = design_mousedown
        image(EntState.Normal) = image_norm
        image(EntState.Hover) = image_hover
        image(EntState.MouseDown) = image_mousedown
        callback(EntState.Normal) = callback_norm
        callback(EntState.Hover) = callback_hover
        callback(EntState.MouseDown) = callback_mousedown
        callback(EntState.MouseMove) = callback_mousemove
        callback(EntState.DblClick) = callback_dblclick

        ' create the box
        CreateEntity(winNum, zOrder_Con, name, Color.White, EntityType.PictureBox, design, image, callback, left, top, width, height, visible, canDrag, , , , , , , , alpha, clickThrough, , , , , onDraw)
    End Sub

    Public Sub CreateButton(winNum As Long, name As String, left As Long, top As Long, width As Long, height As Long,
       Optional text As String = "", Optional font As String = "Georgia.ttf", Optional icon As Long = 0, Optional image_norm As Long = 0, Optional image_hover As Long = 0, Optional image_mousedown As Long = 0,
       Optional visible As Boolean = True, Optional alpha As Long = 255, Optional design_norm As Long = 0, Optional design_hover As Long = 0, Optional design_mousedown As Long = 0,
       Optional ByRef callback_norm As Action = Nothing, Optional ByRef callback_hover As Action = Nothing, Optional ByRef callback_mousedown As Action = Nothing, Optional ByRef callback_mousemove As Action = Nothing, Optional ByRef callback_dblclick As Action = Nothing,
       Optional xOffset As Long = 0, Optional yOffset As Long = 0, Optional tooltip As String = "", Optional censor As Boolean = False, Optional locked As Boolean = True)

        Dim design(EntState.Count - 1) As Long
        Dim image(EntState.Count - 1) As Long
        Dim callback(EntState.Count - 1) As Action

        ' fill temp arrays
        design(EntState.Normal) = design_norm
        design(EntState.Hover) = design_hover
        design(EntState.MouseDown) = design_mousedown
        image(EntState.Normal) = image_norm
        image(EntState.Hover) = image_hover
        image(EntState.MouseDown) = image_mousedown
        callback(EntState.Normal) = callback_norm
        callback(EntState.Hover) = callback_hover
        callback(EntState.MouseDown) = callback_mousedown
        callback(EntState.MouseMove) = callback_mousemove
        callback(EntState.DblClick) = callback_dblclick

        ' create the button 
        CreateEntity(winNum, zOrder_Con, name, Color.White, EntityType.Button, design, image, callback, left, top, width, height, visible, , , , , text, , font, , alpha, xOffset, yOffset, , censor, icon, , , tooltip, , locked)
    End Sub

    Public Sub CreateLabel(winNum As Long, name As String, left As Long, top As Long, width As Long, height As Long, text As String, font As String, color As Color,
       Optional align As Byte = AlignmentType.Left, Optional visible As Boolean = True, Optional alpha As Long = 255, Optional clickThrough As Boolean = False, Optional censor As Boolean = False,
       Optional ByRef callback_norm As Action = Nothing, Optional ByRef callback_hover As Action = Nothing, Optional ByRef callback_mousedown As Action = Nothing, Optional ByRef callback_mousemove As Action = Nothing, Optional ByRef callback_dblclick As Action = Nothing, Optional locked As Boolean = True)

        Dim design(EntState.Count - 1) As Long
        Dim image(EntState.Count - 1) As Long
        Dim callback(EntState.Count - 1) As Action

        ' fill temp arrays
        callback(EntState.Normal) = callback_norm
        callback(EntState.Hover) = callback_hover
        callback(EntState.MouseDown) = callback_mousedown
        callback(EntState.MouseMove) = callback_mousemove
        callback(EntState.DblClick) = callback_dblclick

        ' create the label
        CreateEntity(winNum, zOrder_Con, name, Color.White, EntityType.Label, design, image, callback, left, top, width, height, visible, , , , , text, align, font, , alpha, clickThrough, , , censor, , , , , , locked)
    End Sub

    Public Sub CreateCheckbox(winNum As Long, name As String, left As Long, top As Long, width As Long, Optional height As Long = 15, Optional value As Long = 0, Optional text As String = "", Optional font As String = Georgia,
        Optional align As Byte = AlignmentType.Left, Optional visible As Boolean = True, Optional alpha As Long = 255,
        Optional theDesign As Long = 0, Optional group As Long = 0, Optional censor As Boolean = False,
        Optional ByRef callback_norm As Action = Nothing, Optional ByRef callback_hover As Action = Nothing, Optional ByRef callback_mousedown As Action = Nothing, Optional ByRef callback_mousemove As Action = Nothing, Optional ByRef callback_dblclick As Action = Nothing)

        Dim design(EntState.Count - 1) As Long
        Dim image(EntState.Count - 1) As Long
        Dim callback(EntState.Count - 1) As Action

        design(0) = theDesign

        ' fill temp arrays
        callback(EntState.Normal) = callback_norm
        callback(EntState.Hover) = callback_hover
        callback(EntState.MouseDown) = callback_mousedown
        callback(EntState.MouseMove) = callback_mousemove
        callback(EntState.DblClick) = callback_dblclick

        ' create the box
        CreateEntity(winNum, zOrder_Con, name, Color.White, EntityType.Checkbox, design, image, callback, left, top, width, height, visible, , , , value, text, align, font, , alpha, , , , censor, , , , , group)
    End Sub

    Public Sub CreateComboBox(winNum As Long, name As String, left As Long, top As Long, width As Long, height As Long, design As Long)
        Dim theDesign(EntState.Count - 1) As Long
        Dim image(EntState.Count - 1) As Long
        Dim callback(EntState.Count - 1) As Action

        theDesign(0) = design

        ' create the box
        CreateEntity(winNum, zOrder_Con, name, Color.White, EntityType.Combobox, theDesign, image, callback, left, top, width, height)
    End Sub

    Public Function GetWindowIndex(winName As String) As Long
        Dim i As Long

        For i = 1 To WindowCount

            If LCase$(Windows(i).Window.Name) = LCase$(winName) Then
                GetWindowIndex = i
                Exit Function
            End If

        Next

        GetWindowIndex = 0
    End Function

    Public Function GetControlIndex(winName As String, controlName As String) As Long
        Dim i As Long, winIndex As Long

        winIndex = GetWindowIndex(winName)

        If Not winIndex > 0 Or Not winIndex <= WindowCount Then Exit Function

        For i = 1 To Windows(winIndex).ControlCount

            If LCase$(Windows(winIndex).Controls(i).Name) = LCase$(controlName) Then
                GetControlIndex = i
                Exit Function
            End If

        Next

        GetControlIndex = 0
    End Function

    Public Function SetActiveControl(curWindow As Long, curControl As Long) As Boolean
        If Windows(curWindow).Controls(curControl).Locked Then
            Exit Function
        End If

        ' make sure it's something which CAN be active
        Select Case Windows(curWindow).Controls(curControl).Type
            Case EntityType.TextBox
                Windows(curWindow).ActiveControl = curControl
                SetActiveControl = True
        End Select
    End Function

    Public Sub CentralizeWindow(curWindow As Long)
        With Windows(curWindow).Window
            .Left = (ResolutionWidth / 2) - (.Width / 2)
            .Top = (ResolutionHeight / 2) - (.Height / 2)
            .OrigLeft = .Left
            .OrigTop = .Top
        End With
    End Sub

    Public Sub HideWindows()
        Dim i As Long

        For i = 1 To WindowCount
            HideWindow(i)
        Next
    End Sub

    Public Sub ShowWindow(curWindow As Long, Optional forced As Boolean = False, Optional resetPosition As Boolean = True)
        Windows(curWindow).Window.Visible = True

        If forced Then
            UpdateZOrder(curWindow, forced)
            activeWindow = curWindow
        ElseIf Windows(curWindow).Window.zChange Then
            UpdateZOrder(curWindow)
            activeWindow = curWindow
        End If

        If resetPosition Then
            With Windows(curWindow).Window
                .Left = .OrigLeft
                .Top = .OrigTop
                .Visible = True
            End With
        End If
    End Sub

    Public Sub HideWindow(curWindow As Long)
        Dim i As Long

        Windows(curWindow).Window.Visible = False

        ' find next window to set as active
        For i = WindowCount To 1 Step -1
            If Windows(i).Window.Visible And Windows(i).Window.zChange Then
                activeWindow = i
                Exit For
            End If
        Next
    End Sub

    Public Sub CreateWindow_Login()
        ' Create the window
        CreateWindow("winLogin", "Login", Georgia, zOrder_Win, 0, 0, 276, 212, 45, , 3, 5, DesignType.Win_Norm, DesignType.Win_Norm, DesignType.Win_Norm)

        ' Centralize it
        CentralizeWindow(WindowCount)

        ' Set the index for spawning controls
        zOrder_Con = 1

        ' Parchment
        CreatePictureBox(WindowCount, "picParchment", 6, 26, 264, 180, , , , , , , , DesignType.Parchment, DesignType.Parchment, DesignType.Parchment)

        ' Shadows
        CreatePictureBox(WindowCount, "picShadow_1", 67, 43, 142, 9, , ,  , , , , , DesignType.BlackOval, DesignType.BlackOval, DesignType.BlackOval)
        CreatePictureBox(WindowCount, "picShadow_2", 67, 79, 142, 9, , , , , , , , DesignType.BlackOval, DesignType.BlackOval, DesignType.BlackOval)

        ' Close button
        CreateButton(WindowCount, "btnClose", Windows(WindowCount).Window.Width - 19, 5, 16, 16, , , , 8, 9, 10, , , , , , , , New Action(AddressOf DestroyGame))

        ' Buttons
        CreateButton(WindowCount, "btnAccept", 67, 134, 67, 22, "Accept", Arial, , , ,  , , , DesignType.Green, DesignType.Green_Hover, DesignType.Green_Click, , , New Action(AddressOf btnLogin_Click))
        CreateButton(WindowCount, "btnExit", 142, 134, 67, 22, "Exit", Arial, , , , , , , DesignType.Red, DesignType.Red_Hover, DesignType.Red_Click, , , New Action(AddressOf DestroyGame))

        ' Labels
        CreateLabel(WindowCount, "lblUsername", 72, 39, 142, FontSize, "Username", Arial, Color.White, AlignmentType.Center)
        CreateLabel(WindowCount, "lblPassword", 72, 75, 142, FontSize, "Password", Arial, Color.White, AlignmentType.Center)

        ' Textboxes
        CreateTextbox(WindowCount, "txtUsername", 67, 55, 142, 19, Types.Settings.Username, Arial, AlignmentType.Left, , , , 5, 3, , , , DesignType.TextWhite, DesignType.TextWhite, DesignType.TextWhite)
        CreateTextbox(WindowCount, "txtPassword", 67, 86, 142, 19, , Arial, AlignmentType.Left, , , , 5, 3, , , , DesignType.TextWhite, DesignType.TextWhite, DesignType.TextWhite, True)

        ' Checkbox
        CreateCheckbox(WindowCount, "chkSaveUsername", 67, 114, 142, , Types.Settings.SaveUsername, "Save Username?", Arial, , , , DesignType.ChkNorm, , , , , New Action(AddressOf chkSaveUser_Click))

        ' Register Button
        CreateButton(WindowCount, "btnRegister", 12, Windows(WindowCount).Window.Height - 35, 252, 22, "Create Account", Arial,  , , , , , , DesignType.Green, DesignType.Green_Hover, DesignType.Green_Click, , , New Action(AddressOf btnRegister_Click))

        ' Set the active control
        If Not Len(Windows(GetWindowIndex("winLogin")).Controls(GetControlIndex("winLogin", "txtUsername")).Text) > 0 Then
            SetActiveControl(GetWindowIndex("winLogin"), GetControlIndex("winLogin", "txtUsername"))
        Else
            SetActiveControl(GetWindowIndex("winLogin"), GetControlIndex("winLogin", "txtPassword"))
        End If
    End Sub

    Public Sub CreateWindow_Register()
        ' Create the window
        CreateWindow("winRegister", "Register Account", Georgia, zOrder_Win, 0, 0, 276, 202, 45, False, 3, 5, DesignType.Win_Norm, DesignType.Win_Norm, DesignType.Win_Norm)

        ' Centralize it
        CentralizeWindow(WindowCount)

        ' Set the index for spawning controls
        zOrder_Con = 1

        ' Close button
        CreateButton(WindowCount, "btnClose", Windows(WindowCount).Window.Width - 19, 5, 16, 16, , , , 8, 9, 10, , , , , , , , New Action(AddressOf btnReturnMain_Click))

        ' Parchment
        CreatePictureBox(WindowCount, "picParchment", 6, 26, 264, 170, , , , , , , , DesignType.Parchment, DesignType.Parchment, DesignType.Parchment)

        ' Shadows
        CreatePictureBox(WindowCount, "picShadow_1", 67, 43, 142, 9, , , , , , , , DesignType.BlackOval, DesignType.BlackOval, DesignType.BlackOval)
        CreatePictureBox(WindowCount, "picShadow_2", 67, 79, 142, 9, , , , , , , , DesignType.BlackOval, DesignType.BlackOval, DesignType.BlackOval)
        CreatePictureBox(WindowCount, "picShadow_3", 67, 115, 142, 9, , , , , , , , DesignType.BlackOval, DesignType.BlackOval, DesignType.BlackOval)
        'CreatePictureBox(WindowCount, "picShadow_4", 67, 151, 142, 9, , , , , , , , DesignType.BlackOval, DesignType.BlackOval, DesignType.BlackOval)
        'CreatePictureBox(WindowCount, "picShadow_5", 67, 187, 142, 9, , , , , , , , DesignType.BlackOval, DesignType.BlackOval, DesignType.BlackOval)


        ' Buttons
        CreateButton(WindowCount, "btnAccept", 68, 152, 67, 22, "Create", Arial, , , , , , , DesignType.Green, DesignType.Green_Hover, DesignType.Green_Click, , , New Action(AddressOf btnSendRegister_Click))
        CreateButton(WindowCount, "btnExit", 142, 152, 67, 22, "Back", Arial, , , , , , , DesignType.Red, DesignType.Red_Hover, DesignType.Red_Click, , , New Action(AddressOf btnReturnMain_Click))

        ' Labels
        CreateLabel(WindowCount, "lblUsername", 66, 39, 142, FontSize, "Username", Arial, Color.White, AlignmentType.Center)
        CreateLabel(WindowCount, "lblPassword", 66, 75, 142, FontSize, "Password", Arial, Color.White, AlignmentType.Center)
        CreateLabel(WindowCount, "lblRetypePassword", 66, 111, 142, FontSize, "Retype Password", Arial, Color.White, AlignmentType.Center)
        'CreateLabel(WindowCount, "lblCode", 66, 147, 142, FontSize, "Secret Code", Arial, AlignmentType.Center)
        'CreateLabel(WindowCount, "lblCaptcha", 66, 183, 142, FontSize, "Captcha", Arial, AlignmentType.Center)

        ' Textboxes
        CreateTextbox(WindowCount, "txtUsername", 67, 55, 142, 19, , Arial, AlignmentType.Left, , , , 5, 3, , , , DesignType.TextWhite, DesignType.TextWhite, DesignType.TextWhite)
        CreateTextbox(WindowCount, "txtPassword", 67, 127, 142, 19, , Arial, AlignmentType.Left, , , , 5, 3, , , , DesignType.TextWhite, DesignType.TextWhite, DesignType.TextWhite, True)
        CreateTextbox(WindowCount, "txtRetypePassword", 67, 91, 142, 19, , Arial, AlignmentType.Left, , , , 5, 3, , , , DesignType.TextWhite, DesignType.TextWhite, DesignType.TextWhite, True)
        'CreateTextbox(WindowCount, "txtCode", 67, 163, 142, 19, , Arial, , AlignmentType.Left, , , , , , DesignType.TextWhite, DesignType.TextWhite, DesignType.TextWhite, False)
        'CreateTextbox(WindowCount, "txtCaptcha", 67, 235, 142, 19, , Arial, , AlignmentType.Left, , , , , , DesignType.TextWhite, DesignType.TextWhite, DesignType.TextWhite, False)

        ' CreatePictureBox(WindowCount, "picCaptcha", 67, 199, 156, 30, , , , , Tex_Captcha(GlobalCaptcha), Tex_Captcha(GlobalCaptcha), Tex_Captcha(GlobalCaptcha), DesignType.BlackOval, DesignType.BlackOval, DesignType.BlackOval)

        SetActiveControl(GetWindowIndex("winRegister"), GetControlIndex("winRegister", "txtUsername"))
    End Sub

    Public Sub CreateWindow_NewChar()
        ' Create window
        CreateWindow("winNewChar", "Create Character", Georgia, zOrder_Win, 0, 0, 291, 172, 17, False, 2, 6, DesignType.Win_Norm, DesignType.Win_Norm, DesignType.Win_Norm)

        ' Centralize it
        CentralizeWindow(WindowCount)

        ' Set the index for spawning controls
        zOrder_Con = 1

        ' Close button
        CreateButton(WindowCount, "btnClose", Windows(WindowCount).Window.Width - 19, 5, 16, 16, , , , 8, 9, 10, , , , , , , , New Action(AddressOf btnNewChar_Cancel))

        ' Parchment
        CreatePictureBox(WindowCount, "picParchment", 6, 26, 278, 140, , , , , , , , DesignType.Parchment, DesignType.Parchment, DesignType.Parchment)

        ' Name
        CreatePictureBox(WindowCount, "picShadow_1", 29, 42, 124, 9, , , , , , , , DesignType.BlackOval, DesignType.BlackOval, DesignType.BlackOval)
        CreateLabel(WindowCount, "lblName", 29, 39, 124, FontSize, "Name", Arial, Color.White, AlignmentType.Center)

        ' Textbox
        CreateTextbox(WindowCount, "txtName", 29, 55, 124, 19, , Arial, AlignmentType.Left, , , , 5, 3, , , , DesignType.TextWhite, DesignType.TextWhite, DesignType.TextWhite)

        ' Sex
        CreatePictureBox(WindowCount, "picShadow_2", 29, 85, 124, 9, , , , , , , , DesignType.BlackOval, DesignType.BlackOval, DesignType.BlackOval)
        CreateLabel(WindowCount, "lblGender", 29, 82, 124, FontSize, "Gender", Arial, Color.White, AlignmentType.Center)

        ' Checkboxes
        CreateCheckbox(WindowCount, "chkMale", 29, 103, 55, , 1, "Male", Arial, AlignmentType.Center, , , DesignType.ChkNorm, , , , , New Action(AddressOf chkNewChar_Male))
        CreateCheckbox(WindowCount, "chkFemale", 90, 103, 62, , 0, "Female", Arial, AlignmentType.Center, , , DesignType.ChkNorm, , , , , New Action(AddressOf chkNewChar_Female))

        ' Buttons
        CreateButton(WindowCount, "btnAccept", 29, 127, 60, 24, "Accept", Arial, , , , , , , DesignType.Green, DesignType.Green_Hover, DesignType.Green_Click, , , New Action(AddressOf btnNewChar_Accept))
        CreateButton(WindowCount, "btnCancel", 93, 127, 60, 24, "Cancel", Arial, , , , , , , DesignType.Red, DesignType.Red_Hover, DesignType.Red_Click, , , New Action(AddressOf btnNewChar_Cancel))

        ' Sprite
        CreatePictureBox(WindowCount, "picShadow_3", 175, 42, 76, 9, , , , , , , , DesignType.BlackOval, DesignType.BlackOval, DesignType.BlackOval)
        CreateLabel(WindowCount, "lblSprite", 175, 39, 76, FontSize, "Sprite", Arial, Color.White, AlignmentType.Center)

        ' Scene
        CreatePictureBox(WindowCount, "picScene", 165, 55, 96, 96, , , , , 11, 11, 11, , , , , , , , , New Action(AddressOf NewChar_OnDraw))

        ' Buttons
        CreateButton(WindowCount, "btnLeft", 163, 40, 11, 13, ,  , , 12, 14, 16, , , , , , , , New Action(AddressOf btnNewChar_Left))
        CreateButton(WindowCount, "btnRight", 252, 40, 11, 13, , , , 13, 15, 17, , , , , , , , New Action(AddressOf btnNewChar_Right))

        ' Set the active control
        SetActiveControl(GetWindowIndex("winNewChar"), GetControlIndex("winNewChar", "txtName"))
    End Sub

    Public Sub CreateWindow_Chars()
        ' Create the window
        CreateWindow("winChars", "Characters", Georgia, zOrder_Win, 0, 0, 364, 229, 62, False, 3, 5, DesignType.Win_Norm, DesignType.Win_Norm, DesignType.Win_Norm)

        ' Centralize it
        CentralizeWindow(WindowCount)

        ' Set the index for spawning controls
        zOrder_Con = 1

        ' Close button
        CreateButton(WindowCount, "btnClose", Windows(WindowCount).Window.Width - 19, 5, 16, 16, , , , 8, 9, 10, , , , , , , , New Action(AddressOf btnCharacters_Close))

        ' Parchment
        CreatePictureBox(WindowCount, "picParchment", 6, 26, 352, 197, , , , , , , , DesignType.Parchment, DesignType.Parchment, DesignType.Parchment)

        ' Names
        CreatePictureBox(WindowCount, "picShadow_1", 22, 41, 98, 9, , , , , , , , DesignType.BlackOval, DesignType.BlackOval, DesignType.BlackOval)
        CreateLabel(WindowCount, "lblCharName_1", 22, 37, 98, FontSize, "Blank Slot", Arial, Color.White, AlignmentType.Center)
        CreatePictureBox(WindowCount, "picShadow_2", 132, 41, 98, 9, , , , , , , , DesignType.BlackOval, DesignType.BlackOval, DesignType.BlackOval)
        CreateLabel(WindowCount, "lblCharName_2", 132, 37, 98, FontSize, "Blank Slot", Arial, Color.White, AlignmentType.Center)
        CreatePictureBox(WindowCount, "picShadow_3", 242, 41, 98, 9, , , , , , , , DesignType.BlackOval, DesignType.BlackOval, DesignType.BlackOval)
        CreateLabel(WindowCount, "lblCharName_3", 242, 37, 98, FontSize, "Blank Slot", Arial, Color.White, AlignmentType.Center)

        ' Scenery Boxes
        CreatePictureBox(WindowCount, "picScene_1", 23, 55, 96, 96, , , , , 11, 11, 11)
        CreatePictureBox(WindowCount, "picScene_2", 133, 55, 96, 96, , , , , 11, 11, 11)
        CreatePictureBox(WindowCount, "picScene_3", 243, 55, 96, 96, , , , , 11, 11, 11, , , , , , , , , New Action(AddressOf Chars_OnDraw))

        ' Create Buttons
        CreateButton(WindowCount, "btnSelectChar_1", 22, 155, 98, 24, "Select", Arial, , , , , , , DesignType.Green, DesignType.Green_Hover, DesignType.Green_Click, , , New Action(AddressOf btnAcceptChar_1))
        CreateButton(WindowCount, "btnCreateChar_1", 22, 155, 98, 24, "Create", Arial, , , , , , , DesignType.Green, DesignType.Green_Hover, DesignType.Green_Click, , , New Action(AddressOf btnCreateChar_1))
        CreateButton(WindowCount, "btnDelChar_1", 22, 183, 98, 24, "Delete", Arial, , , , , , , DesignType.Red, DesignType.Red_Hover, DesignType.Red_Click, , , New Action(AddressOf btnDelChar_1))
        CreateButton(WindowCount, "btnSelectChar_2", 132, 155, 98, 24, "Select", Arial, , , , , , , DesignType.Green, DesignType.Green_Hover, DesignType.Green_Click, , , New Action(AddressOf btnAcceptChar_2))
        CreateButton(WindowCount, "btnCreateChar_2", 132, 155, 98, 24, "Create", Arial, , , , , , , DesignType.Green, DesignType.Green_Hover, DesignType.Green_Click, , , New Action(AddressOf btnCreateChar_2))
        CreateButton(WindowCount, "btnDelChar_2", 132, 183, 98, 24, "Delete", Arial, , , , , , , DesignType.Red, DesignType.Red_Hover, DesignType.Red_Click, , , New Action(AddressOf btnDelChar_2))
        CreateButton(WindowCount, "btnSelectChar_3", 242, 155, 98, 24, "Select", Arial, , , , , , , DesignType.Green, DesignType.Green_Hover, DesignType.Green_Click,, , New Action(AddressOf btnAcceptChar_3))
        CreateButton(WindowCount, "btnCreateChar_3", 242, 155, 98, 24, "Create", Arial, , , , , , , DesignType.Green, DesignType.Green_Hover, DesignType.Green_Click, , , New Action(AddressOf btnCreateChar_3))
        CreateButton(WindowCount, "btnDelChar_3", 242, 183, 98, 24, "Delete", Arial, , , , , , , DesignType.Red, DesignType.Red_Hover, DesignType.Red_Click, , , New Action(AddressOf btnDelChar_3))
    End Sub

    Public Sub CreateWindow_Jobs()
        ' Create window
        CreateWindow("winJob", "Select Job", Georgia, zOrder_Win, 0, 0, 364, 229, 17, False, 2, 6, DesignType.Win_Norm, DesignType.Win_Norm, DesignType.Win_Norm)

        ' Centralize it
        CentralizeWindow(WindowCount)

        ' Set the index for spawning controls
        zOrder_Con = 1

        ' Close button
        CreateButton(WindowCount, "btnClose", Windows(WindowCount).Window.Width - 19, 5, 16, 16, , , , 8, 9, 10, , , , , , , , New Action(AddressOf btnJobs_Close))

        ' Parchment
        CreatePictureBox(WindowCount, "picParchment", 6, 26, 352, 197, , , , , , , , DesignType.Parchment, DesignType.Parchment, DesignType.Parchment, , , , , , New Action(AddressOf Jobs_DrawFace))

        ' Job Name
        CreatePictureBox(WindowCount, "picShadow", 183, 42, 98, 9, , , , , , , , DesignType.BlackOval, DesignType.BlackOval, DesignType.BlackOval)
        CreateLabel(WindowCount, "lblClassName", 183, 39, 98, FontSize, "Warrior", Arial, Color.White, AlignmentType.Center)

        ' Select Buttons
        CreateButton(WindowCount, "btnLeft", 171, 40, 11, 13, , , , 12, 14, 16, , , , , , , , New Action(AddressOf btnJobs_Left))
        CreateButton(WindowCount, "btnRight", 282, 40, 11, 13, , , , 13, 15, 17, , , , , , , , New Action(AddressOf btnJobs_Right))

        ' Accept Button
        CreateButton(WindowCount, "btnAccept", 183, 185, 98, 22, "Accept", Arial, , , , ,  , , DesignType.Green, DesignType.Green_Hover, DesignType.Green_Click, , , New Action(AddressOf btnJobs_Accept))

        ' Text background
        CreatePictureBox(WindowCount, "picBackground", 127, 55, 210, 124, , , , , , , , DesignType.TextBlack, DesignType.TextBlack, DesignType.TextBlack)

        ' Overlay
        CreatePictureBox(WindowCount, "picOverlay", 6, 26, 0, 0, , , , , , , , , , , , , , , , New Action(AddressOf Jobs_DrawText))
    End Sub

    Public Sub CreateWindow_Dialogue()
        ' Create dialogue window
        CreateWindow("winDialogue", "Warning", Georgia, zOrder_Win, 0, 0, 348, 145, 38, False, 3, 5, DesignType.Win_Norm, DesignType.Win_Norm, DesignType.Win_Norm, , , , , , , , , , False)

        ' Centralise it
        CentralizeWindow(WindowCount)

        ' Set the index for spawning controls
        zOrder_Con = 1

        ' Close button
        CreateButton(WindowCount, "btnClose", Windows(WindowCount).Window.Width - 19, 5, 16, 16, , , , 8, 9, 10, , , , , , , , New Action(AddressOf btnDialogue_Close))

        ' Parchment
        CreatePictureBox(WindowCount, "picParchment", 6, 26, 335, 113, , , , , , , , DesignType.Parchment, DesignType.Parchment, DesignType.Parchment)

        ' Header
        CreatePictureBox(WindowCount, "picShadow", 103, 44, 144, 9, , , , , , , , DesignType.BlackOval, DesignType.BlackOval, DesignType.BlackOval)
        CreateLabel(WindowCount, "lblHeader", 103, 41, 144, FontSize, "Header", Arial, Color.White, AlignmentType.Center)

        ' Input
        CreateTextbox(WindowCount, "txtInput", 93, 75, 162, 18, , Arial, AlignmentType.Center, , , , , , , , , DesignType.TextBlack, DesignType.TextBlack, DesignType.TextBlack)

        ' Labels
        CreateLabel(WindowCount, "lblBody_1", 15, 60, 314, FontSize, "Invalid username or password.", Arial, Color.White, AlignmentType.Center)
        CreateLabel(WindowCount, "lblBody_2", 15, 75, 314, FontSize, "Please try again!", Arial, Color.White, AlignmentType.Center)

        ' Buttons
        CreateButton(WindowCount, "btnYes", 104, 98, 68, 24, "Yes", Arial, , , , , False, , DesignType.Green, DesignType.Green_Hover, DesignType.Green_Click, , , New Action(AddressOf Dialogue_Yes))
        CreateButton(WindowCount, "btnNo", 180, 98, 68, 24, "No", Arial, , ,  , , False, , DesignType.Red, DesignType.Red_Hover, DesignType.Red_Click, , , New Action(AddressOf Dialogue_No))
        CreateButton(WindowCount, "btnOkay", 140, 98, 68, 24, "Okay", Arial, ,  , , , , , DesignType.Green, DesignType.Green_Hover, DesignType.Green_Click, , , New Action(AddressOf Dialogue_Okay))

        ' Set active control
        SetActiveControl(WindowCount, GetControlIndex("winDialogue", "txtInput"))
    End Sub

    ' Rendering & Initialisation
    Public Sub InitInterface()
        ' Starter values
        zOrder_Win = 1
        zOrder_Con = 1

        ' Menu
        CreateWindow_Register()
        CreateWindow_Login()
        CreateWindow_NewChar()
        CreateWindow_Jobs()
        CreateWindow_Chars()
        CreateWindow_ChatSmall()
        CreateWindow_Chat()
        CreateWindow_Menu()
        CreateWindow_Description()
        CreateWindow_Inventory()
        CreateWindow_Skills()
        CreateWindow_Character()
        CreateWindow_Hotbar()
        CreateWindow_EscMenu()
        CreateWindow_Bars()
        CreateWindow_Dialogue()
        CreateWindow_DragBox()
        CreateWindow_Options()
        CreateWindow_Combobox()
    End Sub

    Public Function HandleInterfaceEvents(entState As EntState) As Boolean
        Dim i As Long, curWindow As Long, curControl As Long, callBack As Action, x As Long

        ' Find the container
        For i = 1 To WindowCount
            With Windows(i).Window
                If .Enabled And .Visible Then
                    If .State <> EntState.MouseDown Then .State = EntState.Normal
                    If CurMouseX >= .Left And CurMouseX <= .Width + .Left Then
                        If CurMouseY >= .Top And CurMouseY <= .Height + .Top Then
                            ' set the combomenu
                            If .Design(0) = DesignType.ComboMenuNorm Then
                                ' set the hover menu
                                If entState = EntState.MouseMove Or entState = EntState.Hover Then
                                    ComboMenu_MouseMove(i)
                                ElseIf entState = EntState.MouseDown Then
                                    ComboMenu_MouseDown(i)
                                End If
                            End If

                            ' everything else
                            If curWindow = 0 Then curWindow = i
                            If .zOrder > Windows(curWindow).Window.zOrder Then curWindow = i
                        End If
                    End If

                    If entState = EntState.MouseMove Then
                        If .CanDrag Then
                            If .State = EntState.MouseDown Then
                                .Left = Math.Clamp(.Left + ((CurMouseX - .Left) - .movedX), 0, ResolutionWidth - .Width)
                                .Top = Math.Clamp(.Top + ((CurMouseY - .Top) - .movedY), 0, ResolutionHeight - .Height)
                            End If
                        End If
                    End If
                End If
            End With
        Next

        ' Handle any controls first
        If curWindow Then
            ' reset /all other/ control mouse events
            For i = 1 To WindowCount
                If i <> curWindow Then
                    For x = 1 To Windows(i).ControlCount
                        Windows(i).Controls(x).State = EntState.Normal
                    Next
                End If
            Next

            For i = 1 To Windows(curWindow).ControlCount
                With Windows(curWindow).Controls(i)
                    If .Enabled And .Visible Then
                        If .State <> EntState.MouseDown Then .State = EntState.Normal
                        If CurMouseX >= .Left + Windows(curWindow).Window.Left And CurMouseX <= .Left + .Width + Windows(curWindow).Window.Left Then
                            If CurMouseY >= .Top + Windows(curWindow).Window.Top And CurMouseY <= .Top + .Height + Windows(curWindow).Window.Top Then
                                If curControl = 0 Then curControl = i
                                If .zOrder > Windows(curWindow).Controls(curControl).zOrder Then curControl = i
                            End If
                        End If

                        If entState = EntState.MouseMove Then
                            If .CanDrag Then
                                If .State = EntState.MouseDown Then
                                    .Left = Math.Clamp(.Left + ((CurMouseX - .Left) - .movedX), 0, Windows(curWindow).Window.Width - .Width)
                                    .Top = Math.Clamp(.Top + ((CurMouseY - .Top) - .movedY), 0, Windows(curWindow).Window.Height - .Height)
                                End If
                            End If
                        End If
                    End If
                End With
            Next

            ' Handle control
            If curControl Then
                With Windows(curWindow).Controls(curControl)
                    If .State <> EntState.MouseDown Then
                        If entState <> EntState.MouseMove Then
                            .State = entState
                        Else
                            .State = EntState.Hover
                        End If
                    End If

                    If entState = EntState.MouseDown Then
                        If .CanDrag Then
                            .movedX = CurMouseX - .Left
                            .movedY = CurMouseY - .Top
                        End If

                        ' toggle boxes
                        Select Case .Type
                            Case EntityType.Checkbox
                                ' grouped boxes
                                If .Group > 0 Then
                                    If .Value = 0 Then
                                        For i = 1 To Windows(curWindow).ControlCount
                                            If Windows(curWindow).Controls(i).Type = EntityType.Checkbox Then
                                                If Windows(curWindow).Controls(i).Group = .Group Then
                                                    Windows(curWindow).Controls(i).Value = 0
                                                End If
                                            End If
                                        Next
                                        .Value = 1
                                    End If
                                Else
                                    If .Value = 0 Then
                                        .Value = 1
                                    Else
                                        .Value = 0
                                    End If
                                End If
                            Case EntityType.Combobox
                                ShowComboMenu(curWindow, curControl)
                        End Select

                        ' set active input
                        SetActiveControl(curWindow, curControl)
                    End If
                    callBack = .CallBack(entState)
                End With
            Else
                ' Handle container
                With Windows(curWindow).Window
                    If .State <> EntState.MouseDown Then
                        If entState <> EntState.MouseMove Then
                            .State = entState
                        Else
                            .State = EntState.Hover
                        End If
                    End If

                    If entState = EntState.MouseDown Then
                        If .CanDrag Then
                            .movedX = CurMouseX - .Left
                            .movedY = CurMouseY - .Top
                        End If
                    End If
                    callBack = .CallBack(entState)
                End With
            End If

            ' bring to front
            If entState = EntState.MouseDown Then
                UpdateZOrder(curWindow)
                activeWindow = curWindow
            End If

            ' call back
            If Not callBack Is Nothing Then callBack()
        End If

        ' Reset
        If entState = EntState.MouseUp Then ResetMouseDown()
    End Function

    Public Sub ResetInterface()
        Dim i As Long, x As Long

        For i = 1 To WindowCount
            If Windows(i).Window.State <> EntState.MouseDown Then Windows(i).Window.State = EntState.Normal

            For x = 1 To Windows(i).ControlCount
                If Windows(i).Controls(x).State <> EntState.MouseDown Then Windows(i).Controls(x).State = EntState.Normal
            Next
        Next

    End Sub

    Public Sub ResetMouseDown()
        Dim callBack As Action
        Dim i As Long, x As Long

        For i = 1 To WindowCount

            With Windows(i)
                .Window.State = EntState.Normal
                callBack = .Window.CallBack(EntState.Normal)

                If Not callBack Is Nothing Then callBack()

                For x = 1 To .ControlCount
                    .Controls(x).State = EntState.Normal
                    callBack = .Controls(x).CallBack(EntState.Normal)

                    If Not callBack Is Nothing Then callBack()
                Next

            End With

        Next
    End Sub

    Sub CloseComboMenu()
        HideWindow(GetWindowIndex("winComboMenuBG"))
        HideWindow(GetWindowIndex("winComboMenu"))
    End Sub

    Sub ShowComboMenu(curWindow As Long, curControl As Long)
        Dim Top As Long

        With Windows(curWindow).Controls(curControl)
            ' linked to
            Windows(GetWindowIndex("winComboMenu")).Window.linkedToWin = curWindow
            Windows(GetWindowIndex("winComboMenu")).Window.linkedToCon = curControl
        
            ' set the size
            Windows(GetWindowIndex("winComboMenu")).Window.Height = 2 + (UBound(.list) * 16)
            Windows(GetWindowIndex("winComboMenu")).Window.Left = Windows(curWindow).Window.Left + .Left + 2
            Top = Windows(curWindow).Window.Top + .Top + .Height
            If Top + Windows(GetWindowIndex("winComboMenu")).Window.Height > ResolutionHeight Then Top = ResolutionHeight - Windows(GetWindowIndex("winComboMenu")).Window.Height
            Windows(GetWindowIndex("winComboMenu")).Window.Top = Top
            Windows(GetWindowIndex("winComboMenu")).Window.Width = .Width - 4
        
            ' set the values
            Windows(GetWindowIndex("winComboMenu")).Window.List = .List
            Windows(GetWindowIndex("winComboMenu")).Window.Value = .Value
            Windows(GetWindowIndex("winComboMenu")).Window.Group = 0
        
            ' load the menu
            Windows(GetWindowIndex("winComboMenu")).Window.Visible = True
            Windows(GetWindowIndex("winComboMenuBG")).Window.Visible = True
            ShowWindow(GetWindowIndex("winComboMenuBG"), True, False)
            ShowWindow(GetWindowIndex("winComboMenu"), True, False)
        End With
    End Sub

    Sub ComboMenu_MouseMove(curWindow As Long)
        Dim y As Long, i As Long
        With Windows(curWindow).Window
            y = curMouseY - .Top

            ' find the option we're hovering over
            If UBound(.list) > 0 Then
                For i = 1 To UBound(.list)
                    If y >= (16 * (i - 1)) And y <= (16 * (i)) Then
                        .group = i
                    End If
                Next
            End If
        End With
    End Sub

    Sub ComboMenu_MouseDown(curWindow As Long)
    Dim y As Long, i As Long
        With Windows(curWindow).Window
            y = curMouseY - .Top

            ' find the option we're hovering over
            If UBound(.list) > 0 Then
                For i = 1 To UBound(.list)
                    If y >= (16 * (i - 1)) And y <= (16 * (i)) Then
                        Windows(.linkedToWin).Controls(.linkedToCon).value = i
                        CloseComboMenu
                    End If
                Next
            End If
        End With
    End Sub

    Public Sub chkSaveUser_Click()
        With Windows(GetWindowIndex("winLogin")).Controls(GetControlIndex("winLogin", "chkSaveUsername"))
            If .Value = 0 Then ' set as false
                Types.Settings.SaveUsername = 0
                Types.Settings.Username = ""
                Types.Settings.Save()
            Else
                Types.Settings.SaveUsername = 1
                Types.Settings.Save()
            End If
        End With
    End Sub

    Public Sub btnRegister_Click()
        HideWindows()
        'RenCaptcha()
        ClearPasswordTexts()
        ShowWindow(GetWindowIndex("winRegister"))
    End Sub

    Sub ClearPasswordTexts()
        Dim I As Long
        With Windows(GetWindowIndex("winRegister"))
            '.Controls(GetControlIndex("winRegister", "txtUsername")).Text = ""
            .Controls(GetControlIndex("winRegister", "txtPassword")).Text = ""
            .Controls(GetControlIndex("winRegister", "txtRetypePassword")).Text = ""
            '.Controls(GetControlIndex("winRegister", "txtCode")).Text = ""
            '.Controls(GetControlIndex("winRegister", "txtCaptcha")).Text = ""
            'For I = 0 To 6
            '.Controls(GetControlIndex("winRegister", "picCaptcha")).Image(I) = Tex_Captcha(GlobalCaptcha)
            'Next
        End With

        With Windows(GetWindowIndex("winLogin"))
            .Controls(GetControlIndex("winLogin", "txtPassword")).Text = ""
        End With
    End Sub

    Public Sub btnSendRegister_Click()
        Dim User As String, Pass As String, pass2 As String 'Code As String, Captcha As String

        With Windows(GetWindowIndex("winRegister"))
            User = .Controls(GetControlIndex("winRegister", "txtUsername")).Text
            Pass = .Controls(GetControlIndex("winRegister", "txtPassword")).Text
            pass2 = .Controls(GetControlIndex("winRegister", "txtRetypePassword")).Text
            'Code = .Controls(GetControlIndex("winRegister", "txtCode")).Text
            'Captcha = .Controls(GetControlIndex("winRegister", "txtCaptcha")).Text

            If Pass <> pass2 Then
                Dialogue("Register", "Passwords don't match.", "Please try again.", DialogueType.Alert)
                ClearPasswordTexts()
                Exit Sub
            End If

            If Socket.IsConnected() Then
                SendRegister(User, Pass)
            Else
                InitNetwork()
                Dialogue("Connection Problem", "Cannot connect to game server.", "Please try again.", DialogueType.Alert)
            End If
        End With
    End Sub

    Public Sub btnReturnMain_Click()
        HideWindows()
        ShowWindow(GetWindowIndex("winLogin"))
    End Sub

    ' ##########
    ' ## Menu ##
    ' ##########
    Public Sub btnMenu_Char()
        Dim curWindow As Long

        curWindow = GetWindowIndex("winCharacter")

        If Windows(curWindow).Window.Visible Then
            HideWindow(curWindow)
        Else
            ShowWindow(curWindow, , False)
        End If
    End Sub

    Public Sub btnMenu_Inv()
        Dim curWindow As Long

        curWindow = GetWindowIndex("winInventory")

        If Windows(curWindow).Window.Visible Then
            HideWindow(curWindow)
        Else
            ShowWindow(curWindow, , False)
        End If
    End Sub

    Public Sub btnMenu_Skills()
        Dim curWindow As Long

        curWindow = GetWindowIndex("winSkills")

        If Windows(curWindow).Window.Visible Then
            HideWindow(curWindow)
        Else
            ShowWindow(curWindow, , False)
        End If
    End Sub

    Public Sub btnMenu_Map()
        Windows(GetWindowIndex("winCharacter")).Window.visible = Not Windows(GetWindowIndex("winCharacter")).Window.visible
    End Sub

    Public Sub btnMenu_Guild()
        Windows(GetWindowIndex("winCharacter")).Window.visible = Not Windows(GetWindowIndex("winCharacter")).Window.visible
    End Sub

    Public Sub btnMenu_Quest()
        Windows(GetWindowIndex("winCharacter")).Window.visible = Not Windows(GetWindowIndex("winCharacter")).Window.visible
    End Sub

    ' ##############
    ' ## Esc Menu ##
    ' ##############
    Public Sub btnEscMenu_Return()
        HideWindow(GetWindowIndex("winEscMenu"))
    End Sub

    Public Sub btnEscMenu_Options()
        HideWindow(GetWindowIndex("winEscMenu"))
        ShowWindow(GetWindowIndex("winOptions"), True, True)
    End Sub

    Public Sub btnEscMenu_MainMenu()
        HideWindows
        ShowWindow(GetWindowIndex("winLogin")) 
        LogoutGame
    End Sub

    Public Sub btnEscMenu_Exit()
        HideWindow(GetWindowIndex("winEscMenu"))
        DestroyGame
    End Sub

    ' ##########
    ' ## Bars ##
    ' ##########
    Public Sub Bars_OnDraw()
        Dim xO As Long, yO As Long, Width As Long

        xO = Windows(GetWindowIndex("winBars")).Window.Left
        yO = Windows(GetWindowIndex("winBars")).Window.Top

        ' Bars
        RenderTexture(InterfaceSprite(27), Window, xO + 15, yO + 15, 0, 0, BarWidth_GuiHP, 13, BarWidth_GuiHP, 13)
        RenderTexture(InterfaceSprite(28), Window, xO + 15, yO + 32, 0, 0, BarWidth_GuiSP, 13, BarWidth_GuiSP, 13)
        RenderTexture(InterfaceSprite(29), Window, xO + 15, yO + 49, 0, 0, BarWidth_GuiEXP, 13, BarWidth_GuiEXP, 13)
    End Sub

    ' #######################
    ' ## Characters Window ##
    ' #######################
    Public Sub Chars_OnDraw()
        Dim xO As Long, yO As Long, x As Long, I As Long

        xO = Windows(GetWindowIndex("WinChars")).Window.Left
        yO = Windows(GetWindowIndex("WinChars")).Window.Top

        x = xO + 24
        For I = 1 To MAX_CHARS
            If Trim$(CharName(I)) <> "" Then
                If CharSprite(I) > 0 Then
                    If CharacterGfxInfo(CharSprite(I)).IsLoaded = False Then
                        LoadTexture(CharSprite(I), 2)
                    End If

                    Dim rect = New Rectangle((CharacterGfxInfo(CharSprite(I)).Width / 4), (CharacterGfxInfo(CharSprite(I)).Height / 4),
                               (CharacterGfxInfo(CharSprite(I)).Width / 4), (CharacterGfxInfo(CharSprite(I)).Height / 4))

                    If Not CharSprite(I) > NumCharacters And Not CharSprite(I) > NumFaces Then
                        ' render char
                        RenderTexture(CharacterSprite(CharSprite(I)), Window, x + 24, yO + 100, 0, 0, rect.Width, rect.Height, rect.Width, rect.Height)
                    End If
                End If
            End If
            x = x + 110
        Next
    End Sub

    Public Sub btnAcceptChar_1()
        SendUseChar(1)
    End Sub

    Public Sub btnAcceptChar_2()
        SendUseChar(2)
    End Sub

    Public Sub btnAcceptChar_3()
        SendUseChar(3)
    End Sub

    Public Sub btnDelChar_1()
        Dialogue("Delete Character", "Deleting this character is permanent.", "Are you sure you want to delete this character?", DialogueType.DelChar, DialogueStyle.YesNo, 1)
    End Sub

    Public Sub btnDelChar_2()
        Dialogue("Delete Character", "Deleting this character is permanent.", "Are you sure you want to delete this character?", DialogueType.DelChar, DialogueStyle.YesNo, 2)
    End Sub

    Public Sub btnDelChar_3()
        Dialogue("Delete Character", "Deleting this character is permanent.", "Are you sure you want to delete this character?", DialogueType.DelChar, DialogueStyle.YesNo, 3)
    End Sub

    Public Sub btnCreateChar_1()
        CharNum = 1
        ShowJobs()
    End Sub

    Public Sub btnCreateChar_2()
        CharNum = 2
        ShowJobs()
    End Sub

    Public Sub btnCreateChar_3()
        CharNum = 3
        ShowJobs()
    End Sub

    Public Sub btnCharacters_Close()
        InitNetwork()
        HideWindows()
        ShowWindow(GetWindowIndex("winLogin"))
    End Sub

    ' ####################
    ' ## Jobs Window ##
    ' ####################
    Public Sub Jobs_DrawFace()
        Dim imageFace As Long, xO As Long, yO As Long

        xO = Windows(GetWindowIndex("winJob")).Window.Left
        yO = Windows(GetWindowIndex("winJob")).Window.Top

        If newCharJob = 0 Then newCharJob = 1

        Select Case newCharJob
            Case 1 ' Warrior
                imageFace = 1
            Case 2 ' Wizard
                imageFace = 2
            Case 3 ' Whisperer
                imageFace = 3
        End Select

        If FaceGfxInfo(imageFace).IsLoaded = False Then
            LoadTexture(imageFace, 7)
        End If

        ' render face
        RenderTexture(FaceSprite(imageFace), Window, xO + 30, yO + 75, 0, 0, FaceGfxInfo(imageFace).Width, FaceGfxInfo(imageFace).Height, FaceGfxInfo(imageFace).Width, FaceGfxInfo(imageFace).Height)
    End Sub

    Public Sub Jobs_DrawText()
        Dim image As Long, text As String, xO As Long, yO As Long, textArray() As String, I As Long, count As Long, y As Long, x As Long

        xO = Windows(GetWindowIndex("winJob")).Window.Left
        yO = Windows(GetWindowIndex("winJob")).Window.Top

        If Job(newCharJob).Desc = "" Then
            Select Case newCharJob
                Case 1 ' Warrior
                    text = "The way of a warrior has never been an easy one. Skilled use of a sword is not something learnt overnight. Being able to take a decent amount of hits is important for these characters and as such they weigh a lot of importance on endurance and strength."
                Case 2 ' Wizard
                    text = "Wizards are often mistrusted characters who have mastered the practice of using their own spirit to create elemental entities. Generally seen as playful and almost childish because of the huge amounts of pleasure they take from setting things on fire."
                Case 3 ' Whisperer
                    text = "The art of healing is one which comes with tremendous amounts of pressure and guilt. Constantly being put under high-pressure situations where their abilities could mean the difference between life and death leads many Whisperers to insanity."
            End Select
        Else
            text = Job(newCharJob).Desc
        End If

        ' wrap text
        WordWrap_Array(text, 330, textArray)

        ' render text
        count = UBound(textArray)
        y = yO + 60
        For I = 1 To count
            x = xO + 118 + (200 \ 2) - (TextWidth(textArray(I)) \ 2)
            RenderText(textArray(I), Window, x, y, Color.White, Color.White)
            y = y + 14
        Next
    End Sub

    Public Sub btnJobs_Left()
        Dim text As String

        newCharJob = newCharJob - 1
        If newCharJob <= 0 Then
            newCharJob = 1
        End If

        Windows(GetWindowIndex("winJob")).Controls(GetControlIndex("winJob", "lblClassName")).Text = Trim$(Job(newCharJob).Name)
    End Sub

    Public Sub btnJobs_Right()
        Dim text As String

        If newCharJob > MAX_JOBS Or (Job(newCharJob).Desc = "" And newCharJob >= 3) Then
            Exit Sub
        End If

        newCharJob = newCharJob + 1
        Windows(GetWindowIndex("winJob")).Controls(GetControlIndex("winJob", "lblClassName")).Text = Trim$(Job(newCharJob).Name)
    End Sub

    Public Sub btnJobs_Accept()
        HideWindow(GetWindowIndex("winJob"))
        ShowWindow(GetWindowIndex("winNewChar"))
    End Sub

    Public Sub btnJobs_Close()
        HideWindows()
        ShowWindow(GetWindowIndex("winChars"))
    End Sub

    ' Chat
    Public Sub btnSay_Click()
        HandlePressEnter()
    End Sub
    Public Sub Chat_OnDraw()
        Dim winIndex As Long, xO As Long, yO As Long

        winIndex = GetWindowIndex("winChat")
        xO = Windows(winIndex).Window.Left
        yO = Windows(winIndex).Window.Top + 16

        ' draw the box
        RenderDesign(DesignType.Win_Desc, xO, yO, 352, 152)

        ' draw the input box
        RenderTexture(InterfaceSprite(46), Window, xO + 7, yO + 123, 0, 0, 171, 22, 171, 22)
        RenderTexture(InterfaceSprite(46), Window, xO + 174, yO + 123, 0, 22, 171, 22, 171, 22)

        ' call the chat render
        RenderChat()
    End Sub

    Public Sub OnDraw_ChatSmall()
        Dim winIndex As Long, xO As Long, yO As Long

        winIndex = GetWindowIndex("winChatSmall")

        If actChatWidth < 160 Then actChatWidth = 160
        If actChatHeight < 10 Then actChatHeight = 10

        xO = Windows(winIndex).Window.Left + 10
        yO = ResolutionHeight - 10

        ' draw the background
        RenderDesign(DesignType.Win_Shadow, xO, yO, 160, 10)
    End Sub

    Public Sub chkChat_Game()
        Types.Settings.ChannelState(ChatChannel.Game) = Windows(GetWindowIndex("winChat")).Controls(GetControlIndex("winChat", "chkGame")).Value
        UpdateChat()
    End Sub

    Public Sub chkChat_Map()
        Types.Settings.ChannelState(ChatChannel.Map) = Windows(GetWindowIndex("winChat")).Controls(GetControlIndex("winChat", "chkMap")).Value
        UpdateChat()
    End Sub

    Public Sub chkChat_Global()
        Types.Settings.ChannelState(ChatChannel.Broadcast) = Windows(GetWindowIndex("winChat")).Controls(GetControlIndex("winChat", "chkGlobal")).Value
        UpdateChat()
    End Sub

    Public Sub chkChat_Party()
        Types.Settings.ChannelState(ChatChannel.Party) = Windows(GetWindowIndex("winChat")).Controls(GetControlIndex("winChat", "chkParty")).Value
        UpdateChat()
    End Sub

    Public Sub chkChat_Guild()
        Types.Settings.ChannelState(ChatChannel.Guild) = Windows(GetWindowIndex("winChat")).Controls(GetControlIndex("winChat", "chkGuild")).Value
        UpdateChat()
    End Sub

    Public Sub chkChat_Private()
        Types.Settings.ChannelState(ChatChannel.Whisper) = Windows(GetWindowIndex("winChat")).Controls(GetControlIndex("winChat", "chkPrivate")).Value
        UpdateChat()
    End Sub

    Public Sub btnChat_Up()
        ChatButtonUp = True
    End Sub

    Public Sub btnChat_Down()
        ChatButtonDown = True
    End Sub

    Public Sub btnChat_Up_MouseUp()
        ChatButtonUp = False
    End Sub

    Public Sub btnChat_Down_MouseUp()
        ChatButtonDown = False
    End Sub

    ' ###################
    ' ## New Character ##
    ' ###################
    Public Sub NewChar_OnDraw()
        Dim imageFace As Long, imageChar As Long, xO As Long, yO As Long

        xO = Windows(GetWindowIndex("winNewChar")).Window.Left
        yO = Windows(GetWindowIndex("winNewChar")).Window.Top

        If newCharGender = SexType.Male Then
            imageFace = Job(newCharJob).MaleSprite
            imageChar = Job(newCharJob).MaleSprite
        Else
            imageFace = Job(newCharJob).FemaleSprite
            imageChar = Job(newCharJob).FemaleSprite
        End If

        If CharacterGfxInfo(imageChar).IsLoaded = False Then
            LoadTexture(imageChar, 2)
        End If

        Dim rect = New Rectangle((CharacterGfxInfo(imageChar).Width / 4), (CharacterGfxInfo(imageChar).Height / 4),
                               (CharacterGfxInfo(imageChar).Width / 4), (CharacterGfxInfo(imageChar).Height / 4))


        ' render char
        RenderTexture(CharacterSprite(imageChar), Window, xO + 190, yO + 100, 0, 0, rect.Width, rect.Height, rect.Width, rect.Height)
    End Sub

    Public Sub btnNewChar_Left()
        Dim spriteCount As Long

        If newCharGender = SexType.Male Then
            spriteCount = Job(newCharJob).MaleSprite
        Else
            spriteCount = Job(newCharJob).FemaleSprite
        End If

        If newCharSprite <= 0 Then
            newCharSprite = spriteCount
        Else
            newCharSprite = newCharSprite - 1
        End If
    End Sub

    Public Sub btnNewChar_Right()
        Dim spriteCount As Long

        If newCharGender = SexType.Male Then
            spriteCount = Job(newCharJob).MaleSprite
        Else
            spriteCount = Job(newCharJob).FemaleSprite
        End If

        If newCharSprite >= spriteCount Then
            newCharSprite = 0
        Else
            newCharSprite = newCharSprite + 1
        End If
    End Sub

    Public Sub chkNewChar_Male()
        newCharSprite = 1
        newCharGender = SexType.Male
        If Windows(GetWindowIndex("winNewChar")).Controls(GetControlIndex("winNewChar", "chkMale")).Value = 1 Then
            Windows(GetWindowIndex("winNewChar")).Controls(GetControlIndex("winNewChar", "chkFemale")).Value = 0
        End If
    End Sub

    Public Sub chkNewChar_Female()
        newCharSprite = 1
        newCharGender = SexType.Female
        If Windows(GetWindowIndex("winNewChar")).Controls(GetControlIndex("winNewChar", "chkFemale")).Value = 1 Then
            Windows(GetWindowIndex("winNewChar")).Controls(GetControlIndex("winNewChar", "chkMale")).Value = 0
        End If
    End Sub

    Public Sub btnNewChar_Cancel()
        Windows(GetWindowIndex("winNewChar")).Controls(GetControlIndex("winNewChar", "txtName")).Text = ""
        Windows(GetWindowIndex("winNewChar")).Controls(GetControlIndex("winNewChar", "chkMale")).Value = 1
        Windows(GetWindowIndex("winNewChar")).Controls(GetControlIndex("winNewChar", "chkFemale")).Value = 0
        newCharSprite = 1
        newCharGender = SexType.Male
        HideWindows()
        ShowWindow(GetWindowIndex("winJob"))
    End Sub

    Public Sub btnNewChar_Accept()
        Dim name As String
        name = Windows(GetWindowIndex("winNewChar")).Controls(GetControlIndex("winNewChar", "txtName")).Text
        HideWindows()
        AddChar(name, newCharGender, newCharJob, newCharSprite)
    End Sub

    ' #####################
    ' ## Dialogue Window ##
    ' #####################
    Public Sub btnDialogue_Close()
        If diaStyle = DialogueStyle.Okay Then
            DialogueHandler(1)
        ElseIf diaStyle = DialogueStyle.YesNo Then
            DialogueHandler(3)
        End If
    End Sub

    ' ###############
    ' ## Inventory ##
    ' ###############
    Public Sub Inventory_MouseDown()
        Dim invNum As Long, winIndex As Long, I As Long

        ' is there an item?
        invNum = IsInv(Windows(GetWindowIndex("winInventory")).Window.Left, Windows(GetWindowIndex("winInventory")).Window.Top)

        If invNum Then
            ' exit out if we're offering that item
            If InTrade > 0 Then
                For I = 1 To MAX_INV
                    If TradeYourOffer(I).Num = invNum Then
                        ' is currency?
                        If Item(GetPlayerInvItemNum(Myindex, TradeYourOffer(I).Num)).Type = ItemType.Currency Then
                            ' only exit out if we're offering all of it
                            If TradeYourOffer(I).Value = GetPlayerInvItemValue(Myindex, TradeYourOffer(I).Num) Then
                                Exit Sub
                            End If
                        Else
                            Exit Sub
                        End If
                    End If
                Next

                ' currency handler
                If Item(GetPlayerInvItemNum(Myindex, invNum)).Type = ItemType.Currency Then
                    Dialogue("Select Amount", "Please choose how many to offer", "", DialogueType.TradeAmount, DialogueStyle.Input, invNum)
                    Exit Sub
                End If

                ' trade the normal item
                Call TradeItem(invNum, 0)
                Exit Sub
            End If

            ' drag it
            With DragBox
                .Type = PartType.Item
                .Value = GetPlayerInvItemNum(Myindex, invNum)
                .Origin = PartOriginType.Inventory
                .Slot = invNum
            End With

            winIndex = GetWindowIndex("winDragBox")
            With Windows(winIndex).Window
                .State = EntState.MouseDown
                .Left = CurMouseX - 16
                .Top = CurMouseY - 16
                .movedX = CurMouseX - .Left
                .movedY = CurMouseY - .Top
            End With

            ShowWindow(winIndex, , False)

            ' stop dragging inventory
            Windows(GetWindowIndex("winInventory")).Window.State = EntState.Normal
        End If

        ' show desc. if needed
        Inventory_MouseMove()
    End Sub

    Public Sub Inventory_DblClick()
        Dim itemNum As Long, I As Long

        If InTrade > 0 Then Exit Sub

        itemNum = IsInv(Windows(GetWindowIndex("winInventory")).Window.Left, Windows(GetWindowIndex("winInventory")).Window.Top)

        If itemNum > 0 Then
            SendUseItem(itemNum)
        End If

        ' show desc. if needed
        Inventory_MouseMove()
    End Sub

    Public Sub Inventory_MouseMove()
        Dim itemNum As Long, x As Long, y As Long, I As Long

        ' exit out early if dragging
        If DragBox.Type <> PartType.None Then Exit Sub

        itemNum = IsInv(Windows(GetWindowIndex("winInventory")).Window.Left, Windows(GetWindowIndex("winInventory")).Window.Top)

        If itemNum Then
            ' exit out if we're offering that item
            If InTrade > 0 Then
                For I = 1 To MAX_INV
                    If TradeYourOffer(I).Num = itemNum Then
                        ' is currency?
                        If Item(GetPlayerInvItemNum(Myindex, TradeYourOffer(I).Num)).Type = ItemType.Currency Then
                            ' only exit out if we're offering all of it
                            If TradeYourOffer(I).Value = GetPlayerInvItemValue(Myindex, TradeYourOffer(I).Num) Then
                                Exit Sub
                            End If
                        Else
                            Exit Sub
                        End If
                    End If
                Next
            End If

            ' make sure we're not dragging the item
            If DragBox.Type = PartType.Item And DragBox.Value = itemNum Then Exit Sub

            ' calc position
            x = Windows(GetWindowIndex("winInventory")).Window.Left - Windows(GetWindowIndex("winDescription")).Window.Width
            y = Windows(GetWindowIndex("winInventory")).Window.Top - 4

            ' offscreen?
            If x < 0 Then
                ' switch to right
                x = Windows(GetWindowIndex("winInventory")).Window.Left + Windows(GetWindowIndex("winInventory")).Window.Width
            End If

            ' go go go
            ShowInvDesc(x, y, itemNum)
        End If
    End Sub

' ##############
' ## Drag Box ##
' ##############
Public Sub DragBox_OnDraw()
    Dim xO As Long, yO As Long, texNum As Long, winIndex As Long

    winIndex = GetWindowIndex("winDragBox")
    xO = Windows(winIndex).Window.Left
    yO = Windows(winIndex).Window.Top
    
    ' get texture num
    With DragBox
        Select Case .Type
            Case PartType.Item
                If .value Then
                    texNum = Item(.value).Icon
                        
                    ' render the icon
                    If ItemGfxInfo(texNum).IsLoaded = False Then
                        LoadTexture(texNum, 4)
                    End If

                    RenderTexture(ItemSprite(texNum), Window, xO, yO, 0, 0, 32, 32, 32, 32)
                End If
            Case PartType.Skill
                If .value Then
                    texNum = Skill(.value).Icon

                    ' render the icon
                    If SkillGfxInfo(texNum).IsLoaded = False Then
                        LoadTexture(texNum, 9)
                    End If
                    RenderTexture(SkillSprite(texNum), Window, xO, yO, 0, 0, 32, 32, 32, 32)
                End If
        End Select
    End With
End Sub

Public Sub DragBox_Check()
    Dim winIndex As Long, I As Long, curWindow As Long, curControl As Long, tmpRec As RectStruct
    
    winIndex = GetWindowIndex("winDragBox")
    
    ' can't drag nuthin'
    If DragBox.Type = PartType.None Then Exit Sub
    
    ' check for other windows
    For I = 1 To WindowCount
        With Windows(I).Window
            If .visible Then
                ' can't drag to self
                If .name <> "winDragBox" Then
                    If CurMouseX >= .Left And CurMouseX <= .Left + .Width Then
                        If CurMouseY >= .Top And CurMouseY <= .Top + .Height Then
                            If curWindow = 0 Then curWindow = I
                            If .zOrder > Windows(curWindow).Window.zOrder Then curWindow = I
                        End If
                    End If
                End If
            End If
        End With
    Next
    
    ' we have a window - check if we can drop
    If curWindow Then
        Select Case Windows(curWindow).Window.name
            Case "winBank"
                If DragBox.Origin = PartOriginType.Bank Then
                    ' it's from the inventory!
                    If DragBox.Type = PartType.Item Then
                        ' find the slot to switch with
                        For I = 1 To MAX_BANK
                            With tmpRec
                                .Top = Windows(curWindow).Window.Top + BankTop + ((BankOffsetY + 32) * ((I - 1) \ BankColumns))
                                .bottom = .Top + 32
                                .Left = Windows(curWindow).Window.Left + BankLeft + ((BankOffsetX + 32) * (((I - 1) Mod BankColumns)))
                                .Right = .Left + 32
                            End With
    
                            If CurMouseX >= tmpRec.Left And CurMouseX <= tmpRec.Right Then
                                If CurMouseY >= tmpRec.Top And CurMouseY <= tmpRec.bottom Then
                                    ' switch the slots
                                    If DragBox.Slot <> I Then
                                        ChangeBankSlots(DragBox.Slot, I)
                                        Exit For
                                    End If
                                End If
                            End If
                        Next
                    End If
                End If
                
                If DragBox.Origin = PartOriginType.Inventory Then
                    If DragBox.Type = PartType.Item Then
    
                        If Item(GetPlayerInvItemNum(MyIndex, DragBox.Slot)).Type <> ItemType.Currency Then
                            DepositItem(DragBox.Slot, 1)
                        Else
                            Dialogue("Deposit Item", "Enter the deposit quantity.", "", DialogueType.DepositItem, DialogueStyle.Input, DragBox.Slot)
                        End If
    
                    End If
                End If
                
            Case "winInventory"
                If DragBox.Origin = PartOriginType.Inventory Then
                    ' it's from the inventory!
                    If DragBox.Type = PartType.Item Then
                        ' find the slot to switch with
                        For I = 1 To MAX_INV
                            With tmpRec
                                .Top = Windows(curWindow).Window.Top + InvTop + ((InvOffsetY + 32) * ((I - 1) \ InvColumns))
                                .bottom = .Top + 32
                                .Left = Windows(curWindow).Window.Left + InvLeft + ((InvOffsetX + 32) * (((I - 1) Mod InvColumns)))
                                .Right = .Left + 32
                            End With
                            
                            If CurMouseX >= tmpRec.Left And CurMouseX <= tmpRec.Right Then
                                If CurMouseY >= tmpRec.Top And CurMouseY <= tmpRec.bottom Then
                                    ' switch the slots
                                    If DragBox.Slot <> I Then SendChangeInvSlots(DragBox.Slot, I)
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                End If
                
                ' se o item saiu do bank
                If DragBox.Origin = PartOriginType.Bank Then
                    If DragBox.Type = PartType.Item Then
    
                        If Item(Bank.Item(DragBox.Slot).num).Type <> ItemType.Currency Then
                            WithdrawItem(DragBox.Slot, 0)
                        Else
                            Dialogue("Withdraw Item", "Enter the amount you wish to withdraw.", "", DialogueType.WithdrawItem, DialogueStyle.Input, DragBox.Slot)
                        End If
    
                    End If
                End If

            Case "winSkills"
                If DragBox.Origin = PartOriginType.Skill Then
                    ' it's from the Skills!
                    If DragBox.Type = PartType.Skill Then
                        ' find the slot to switch with
                        For I = 1 To MAX_PLAYER_SKILLS
                            With tmpRec
                                .Top = Windows(curWindow).Window.Top + SkillTop + ((SkillOffsetY + 32) * ((I - 1) \ SkillColumns))
                                .bottom = .Top + 32
                                .Left = Windows(curWindow).Window.Left + SkillLeft + ((SkillOffsetX + 32) * (((I - 1) Mod SkillColumns)))
                                .Right = .Left + 32
                            End With
                            
                            If CurMouseX >= tmpRec.Left And CurMouseX <= tmpRec.Right Then
                                If CurMouseY >= tmpRec.Top And CurMouseY <= tmpRec.bottom Then
                                    ' switch the slots
                                    If DragBox.Slot <> I Then SendChangeSkillSlots(DragBox.Slot, I)
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                End If

            Case "winHotbar"
                If DragBox.Origin <> PartOriginType.None Then
                    If DragBox.Type <> PartType.None Then
                        ' find the slot
                        For I = 1 To MAX_HOTBAR
                            With tmpRec
                                .Top = Windows(curWindow).Window.Top + HotbarTop
                                .bottom = .Top + 32
                                .Left = Windows(curWindow).Window.Left + HotbarLeft + ((I - 1) * HotbarOffsetX)
                                .Right = .Left + 32
                            End With
                            
                            If CurMouseX >= tmpRec.Left And CurMouseX <= tmpRec.Right Then
                                If CurMouseY >= tmpRec.Top And CurMouseY <= tmpRec.bottom Then
                                    ' set the hotbar slot
                                    If DragBox.Origin <> PartOriginType.Hotbar Then
                                        If DragBox.Type = PartType.Item Then
                                            SendSetHotbarSlot(1, DragBox.Slot, I)
                                        ElseIf DragBox.Type = PartType.Skill Then
                                            SendSetHotbarSlot(2, DragBox.Slot, I)
                                        End If
                                    Else
                                        If DragBox.Slot <> I Then SendSetHotbarSlot(3, DragBox.Slot, I)
                                    End If
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                End If
        End Select
    Else
        ' no windows found - dropping on bare map
        Select Case DragBox.Origin
            Case PartOriginType.Inventory
                If Item(GetPlayerInvItemNum(MyIndex, DragBox.Slot)).Type <> ItemType.Currency Then
                    SendDropItem(DragBox.Slot, GetPlayerInvItemNum(MyIndex, DragBox.Slot))
                Else
                    Dialogue("Drop Item", "Please choose how many to drop", "", DialogueType.DropItem, DialogueStyle.Input, GetPlayerInvItemNum(MyIndex, DragBox.Slot))
                End If
            Case PartOriginType.Skill
                ForgetSkill(DragBox.Slot)
            Case PartOriginType.Hotbar
                SendSetHotbarSlot(0, 0, DragBox.Slot)
        End Select
    End If
    
    ' close window
    HideWindow(winIndex)

    With DragBox
        .Type = PartType.None
        .Slot = 0
        .Origin = PartOriginType.None
        .value = 0
    End With
End Sub

    ' ############
    ' ## Skills ##
    ' ############
    Public Sub Skills_MouseDown()
    Dim slotNum As Long, winIndex As Long
    
        ' is there an item?
        slotNum = IsSkill(Windows(GetWindowIndex("winSkills")).Window.Left, Windows(GetWindowIndex("winSkills")).Window.Top)
    
        If slotNum Then
            With DragBox
                .Type = PartType.Skill
                .value = Player(Myindex).Skill(slotNum).Num
                .Origin = PartOriginType.Skill
                .Slot = slotNum
            End With
        
            winIndex = GetWindowIndex("winDragBox")
            With Windows(winIndex).Window
                .state = EntState.MouseDown
                .Left = CurMouseX - 16
                .Top = CurMouseY - 16
                .movedX = CurMouseX - .Left
                .movedY = CurMouseY - .Top
            End With

            ShowWindow(winIndex, , False)

            ' stop dragging inventory
            Windows(GetWindowIndex("winSkills")).Window.state = EntState.Normal
        End If

        ' show desc. if needed
        Skills_MouseMove
    End Sub

    Public Sub Skills_DblClick()
        Dim slotNum As Long

        slotNum = IsSkill(Windows(GetWindowIndex("winSkills")).Window.Left, Windows(GetWindowIndex("winSkills")).Window.Top)
    
        If slotNum Then
            PlayerCastSkill(slotNum)
        End If
    
        ' show desc. if needed
        Skills_MouseMove
    End Sub

    Public Sub Skills_MouseMove()
        Dim slotNum As Long, x As Long, y As Long

        ' exit out early if dragging
        If DragBox.Type <> PartType.None Then Exit Sub

        slotNum = IsSkill(Windows(GetWindowIndex("winSkills")).Window.Left, Windows(GetWindowIndex("winSkills")).Window.Top)
    
        If slotNum > 0 Then
            ' make sure we're not dragging the item
            If DragBox.Type = PartType.Item And DragBox.value = slotNum Then Exit Sub
            
            ' calc position
            x = Windows(GetWindowIndex("winSkills")).Window.Left - Windows(GetWindowIndex("winDescription")).Window.Width
            y = Windows(GetWindowIndex("winSkills")).Window.Top - 4
            
            ' offscreen?
            If x < 0 Then
                ' switch to right
                x = Windows(GetWindowIndex("winSkills")).Window.Left + Windows(GetWindowIndex("winSkills")).Window.Width
            End If

            ' go go go
            ShowSkillDesc(x, y, GetPlayerSkill(Myindex, slotNum), slotNum)
        End If
    End Sub

    ' ############
    ' ## Hotbar ##
    ' ############=
    Public Sub Hotbar_MouseDown()
        Dim slotNum As Long, winIndex As Long

        ' is there an item?
        slotNum = IsHotbar(Windows(GetWindowIndex("winHotbar")).Window.Left, Windows(GetWindowIndex("winHotbar")).Window.Top)

        If slotNum > 0 Then
            With DragBox
                If Player(Myindex).Hotbar(slotNum).SlotType = 1 Then ' inventory
                    .Type = PartOriginsType.Inventory
                ElseIf Player(Myindex).Hotbar(slotNum).SlotType = 2 Then ' Skill
                    .Type = PartOriginsType.Skill
                End If
                .Value = Player(Myindex).Hotbar(slotNum).Slot
                .Origin = PartOriginType.Hotbar
                .Slot = slotNum
            End With

            winIndex = GetWindowIndex("winDragBox")
            With Windows(winIndex).Window
                .State = EntState.MouseDown
                .Left = CurX - 16
                .Top = CurY - 16
                .movedX = CurX - .Left
                .movedY = CurY - .Top
            End With
            ShowWindow(winIndex, , False)

            ' stop dragging inventory
            Windows(GetWindowIndex("winHotbar")).Window.State = EntState.Normal
        End If

        ' show desc. if needed
        Hotbar_MouseMove()
    End Sub

    Public Sub Hotbar_DblClick()
        Dim slotNum As Long

        slotNum = IsHotbar(Windows(GetWindowIndex("winHotbar")).Window.Left, Windows(GetWindowIndex("winHotbar")).Window.Top)

        If slotNum > 0 Then
            SendUseHotbarSlot(slotNum)
        End If

        ' show desc. if needed
        Hotbar_MouseMove()
    End Sub

    Public Sub Hotbar_MouseMove()
        Dim slotNum As Long, x As Long, y As Long

        ' exit out early if dragging
        If DragBox.Type <> PartOriginsType.None Then Exit Sub

        slotNum = IsHotbar(Windows(GetWindowIndex("winHotbar")).Window.Left, Windows(GetWindowIndex("winHotbar")).Window.Top)

        If slotNum > 0 Then
            ' make sure we're not dragging the item
            If DragBox.Origin = PartOriginType.Hotbar And DragBox.Slot = slotNum Then Exit Sub

            ' calc position
            x = Windows(GetWindowIndex("winHotbar")).Window.Left - Windows(GetWindowIndex("winDescription")).Window.Width
            y = Windows(GetWindowIndex("winHotbar")).Window.Top - 4

            ' offscreen?
            If x < 0 Then
                ' switch to right
                x = Windows(GetWindowIndex("winHotbar")).Window.Left + Windows(GetWindowIndex("winHotbar")).Window.Width
            End If

            ' go go go
            Select Case Player(Myindex).Hotbar(slotNum).SlotType
                Case 1 ' inventory
                    ShowItemDesc(x, y, Player(Myindex).Hotbar(slotNum).Slot)
                Case 2 ' skill
                    ShowskillDesc(x, y, Player(Myindex).Hotbar(slotNum).Slot, 0)
            End Select
        End If
    End Sub

    Public Sub Dialogue_Okay()
        DialogueHandler(1)
    End Sub

    Public Sub Dialogue_Yes()
        DialogueHandler(2)
    End Sub

    Public Sub Dialogue_No()
        DialogueHandler(3)
    End Sub

    Sub UpdateStats_UI()
        ' set the bar labels
        With Windows(GetWindowIndex("winBars"))
            .Controls(GetControlIndex("winBars", "lblHP")).Text = GetPlayerVital(Myindex, VitalType.HP) & "/" & GetPlayerMaxVital(Myindex, VitalType.HP)
            .Controls(GetControlIndex("winBars", "lblMP")).Text = GetPlayerVital(Myindex, VitalType.MP) & "/" & GetPlayerMaxVital(Myindex, VitalType.MP)
            .Controls(GetControlIndex("winBars", "lblEXP")).Text = GetPlayerExp(Myindex) & "/" & NextlevelExp
        End With

        ' update character screen
        With Windows(GetWindowIndex("winCharacter"))
            .Controls(GetControlIndex("winCharacter", "lblHealth")).Text = "Health"
            .Controls(GetControlIndex("winCharacter", "lblSpirit")).Text = "Spirit"
            .Controls(GetControlIndex("winCharacter", "lblExperience")).Text = "Exp"
            .Controls(GetControlIndex("winCharacter", "lblHealth2")).Text = GetPlayerVital(Myindex, VitalType.HP) & "/" & GetPlayerMaxVital(Myindex, VitalType.HP)
            .Controls(GetControlIndex("winCharacter", "lblSpirit2")).Text = GetPlayerVital(Myindex, VitalType.MP) & "/" & GetPlayerMaxVital(Myindex, VitalType.MP)
            .Controls(GetControlIndex("winCharacter", "lblExperience2")).Text = Player(Myindex).Exp & "/" & NextlevelExp

        End With
    End Sub

    Public Sub CreateWindow_EscMenu()
        ' Create window
        CreateWindow("winEscMenu", "", Georgia, zOrder_Win, 0, 0, 210, 156, 0, False, , , DesignType.Win_NoBar, DesignType.Win_NoBar, DesignType.Win_NoBar, , , , , , , , , , False, , , False)

        ' Centralize it
        CentralizeWindow(WindowCount)
    
        ' Set the index for spawning controls
        zOrder_Con = 1
    
        ' Parchment
        CreatePictureBox(WindowCount, "picParchment", 6, 6, 198, 144, , , , , , , , DesignType.Parchment, DesignType.Parchment, DesignType.Parchment)
        
        ' Buttons
        CreateButton(WindowCount, "btnReturn", 16, 16, 178, 28, "Return to Game", Verdana, , , , , , , DesignType.Green, DesignType.Green_Hover, DesignType.Green_Click, , , New Action(AddressOf btnEscMenu_Return))
        CreateButton(WindowCount, "btnOptions", 16, 48, 178, 28, "Options", Verdana, , , , , , , DesignType.Orange, DesignType.Orange_Hover, DesignType.Orange_Click, , , New Action(AddressOf btnEscMenu_Options))
        CreateButton(WindowCount, "btnMainMenu", 16, 80, 178, 28, "Back to Main Menu", Verdana, , , , , , , DesignType.Blue, DesignType.Blue_Hover, DesignType.Blue_Click, , , New Action(AddressOf btnEscMenu_MainMenu))
        CreateButton(WindowCount, "btnExit", 16, 112, 178, 28, "Exit the Game", Verdana, , , , , , , DesignType.Red, DesignType.Red_Hover, DesignType.Red_Click, , , New Action(AddressOf btnEscMenu_Exit))
End Sub

    Public Sub CreateWindow_Bars()
        ' Create window
        CreateWindow("winBars", "", Georgia, zOrder_Win, 10, 10, 239, 77, 0, False, , , DesignType.Win_NoBar, DesignType.Win_NoBar, DesignType.Win_NoBar, , , , , , , , , , False, , , False)

        ' Set the index for spawning controls
        zOrder_Con = 1

        ' Parchment
        CreatePictureBox(WindowCount, "picParchment", 6, 6, 227, 65, , , , , , , , DesignType.Parchment, DesignType.Parchment, DesignType.Parchment)

        ' Blank Bars
        CreatePictureBox(WindowCount, "picHP_Blank", 15, 15, 209, 13, , , , , 24, 24, 24)
        CreatePictureBox(WindowCount, "picSP_Blank", 15, 32, 209, 13, , , , , 25, 25, 25)
        CreatePictureBox(WindowCount, "picEXP_Blank", 15, 49, 209, 13, , , , , 26, 26, 26)

        ' Draw the bars
        CreatePictureBox(WindowCount, "picBlank", 0, 0, 0, 0, , , , , , , , , , , , , , , , New Action(AddressOf Bars_OnDraw))

        ' Bar Labels
        CreatePictureBox(WindowCount, "picHealth", 16, 11, 44, 14, , , , , 21, 21, 21)
        CreatePictureBox(WindowCount, "picSpirit", 16, 28, 44, 14, , , , , 22, 22, 22)
        CreatePictureBox(WindowCount, "picExperience", 16, 45, 74, 14, , , , , 23, 23, 23)

        ' Labels
        CreateLabel(WindowCount, "lblHP", 15, 14, 209, FontSize, "999/999", Arial, Color.White, AlignmentType.Center)
        CreateLabel(WindowCount, "lblMP", 15, 31, 209, FontSize, "999/999", Arial, Color.White, AlignmentType.Center)
        CreateLabel(WindowCount, "lblEXP", 15, 48, 209, FontSize, "999/999", Arial, Color.White, AlignmentType.Center)
    End Sub

    Public Sub CreateWindow_Chat()
        ' Create window
        CreateWindow("winChat", "", Georgia, zOrder_Win, 8, ResolutionHeight - 178, 352, 152, 0, False, , , , , , , , , , , , , , , , False)

        ' Set the index for spawning controls
        zOrder_Con = 1

        ' Channel boxes
        CreateCheckbox(WindowCount, "chkGame", 10, 2, 49, 23, 1, "Game", Arial, , , , DesignType.ChkChat, , , , , New Action(AddressOf chkChat_Game))
        CreateCheckbox(WindowCount, "chkMap", 60, 2, 49, 23, 1, "Map", Arial, , , , DesignType.ChkChat, , , New Action(AddressOf chkChat_Map))
        CreateCheckbox(WindowCount, "chkGlobal", 110, 2, 49, 23, 1, "Global", Arial, , , , DesignType.ChkChat, , , , , New Action(AddressOf chkChat_Global))
        CreateCheckbox(WindowCount, "chkParty", 160, 2, 49, 23, 1, "Party", Arial, , , , DesignType.ChkChat, , , , , New Action(AddressOf chkChat_Party))
        CreateCheckbox(WindowCount, "chkGuild", 210, 2, 49, 23, 1, "Guild", Arial, , , , DesignType.ChkChat, , , , , New Action(AddressOf chkChat_Guild))
        CreateCheckbox(WindowCount, "chkPrivate", 260, 2, 49, 23, 1, "Private", Arial, , , , DesignType.ChkChat, , ,  , , New Action(AddressOf chkChat_Private))

        ' Blank picturebox - ondraw wrapper
        CreatePictureBox(WindowCount, "picNull", 0, 0, 0, 0, , , , , , , , , , , , , , , , New Action(AddressOf Chat_OnDraw))

        ' Chat button
        CreateButton(WindowCount, "btnChat", 296, 124 + 16, 48, 20, "Say", Arial, , , , , , , DesignType.Green, DesignType.Green_Hover, DesignType.Green_Click, , , New Action(AddressOf btnSay_Click))

        ' Chat Textbox
        CreateTextbox(WindowCount, "txtChat", 12, 127 + 16, 286, 25, , Verdana)

        ' buttons
        CreateButton(WindowCount, "btnUp", 328, 28, 11, 13, , , , 4, 52, 4, , , , , , , , New Action(AddressOf btnChat_Up))
        CreateButton(WindowCount, "btnDown", 327, 122, 11, 13, , , , 5, 53, 5, , , , , , , , New Action(AddressOf btnChat_Down))

        ' Custom Handlers for mouse up
        Windows(WindowCount).Controls(GetControlIndex("winChat", "btnUp")).CallBack(EntState.MouseUp) = New Action(AddressOf btnChat_Up_MouseUp)
        Windows(WindowCount).Controls(GetControlIndex("winChat", "btnDown")).CallBack(EntState.MouseUp) = New Action(AddressOf btnChat_Down_MouseUp)

        ' Set the active control
        SetActiveControl(GetWindowIndex("winChat"), GetControlIndex("winChat", "txtChat"))

        ' sort out the tabs
        With Windows(GetWindowIndex("winChat"))
            .Controls(GetControlIndex("winChat", "chkGame")).Value = Types.Settings.ChannelState(ChatChannel.Game)
            .Controls(GetControlIndex("winChat", "chkMap")).Value = Types.Settings.ChannelState(ChatChannel.Map)
            .Controls(GetControlIndex("winChat", "chkGlobal")).Value = Types.Settings.ChannelState(ChatChannel.Broadcast)
            .Controls(GetControlIndex("winChat", "chkParty")).Value = Types.Settings.ChannelState(ChatChannel.Party)
            .Controls(GetControlIndex("winChat", "chkGuild")).Value = Types.Settings.ChannelState(ChatChannel.Guild)
            .Controls(GetControlIndex("winChat", "chkPrivate")).Value = Types.Settings.ChannelState(ChatChannel.Whisper)
        End With
    End Sub

    Public Sub CreateWindow_ChatSmall()
        ' Create window
        CreateWindow("winChatSmall", "", Georgia, zOrder_Win, 8, 0, 0, 0, 0, False, , , , , , , , , , , , , , New Action(AddressOf OnDraw_ChatSmall), False, , , True)

        ' Set the index for spawning controls
        zOrder_Con = 1

        ' Chat Label
        CreateLabel(WindowCount, "lblMsg", 10, ResolutionHeight - 28, 160, FontSize, "Press 'Enter' to open chatbox.", Verdana, Color.White)
    End Sub

    Public Sub CreateWindow_Hotbar()
        ' Create window
        CreateWindow("winHotbar", "", Georgia, zOrder_Win, 372, 10, 418, 36, 0, False, , , , , , , , , , , New Action(AddressOf Hotbar_MouseMove), New Action(AddressOf Hotbar_MouseDown), New Action(AddressOf Hotbar_DblClick), New Action(AddressOf DrawHotbar), False, False)
    End Sub

    Public Sub CreateWindow_Menu()
        ' Create window
        CreateWindow("winMenu", "", Georgia, zOrder_Win, ResolutionWidth - 229, ResolutionHeight - 31, 229, 31, 0, False, , , , , , , , , , , , , , , , , False, False)

        ' Set the index for spawning controls
        zOrder_Con = 1

        ' Wood part
        CreatePictureBox(WindowCount, "picWood", 0, 5, 228, 21, , , , , , , , DesignType.Wood, DesignType.Wood, DesignType.Wood)
        ' Buttons
        CreateButton(WindowCount, "btnChar", 8, 1, 29, 29, , , 108, , , , , , DesignType.Green, DesignType.Green_Hover, DesignType.Green_Click, , , New Action(AddressOf btnMenu_Char), , , -1, -2, "Character (C)")
        CreateButton(WindowCount, "btnInv", 44, 1, 29, 29, , , 1, , , , , , DesignType.Green, DesignType.Green_Hover, DesignType.Green_Click, , , New Action(AddressOf btnMenu_Inv), , , -1, -2, "Inventory (I)")
        CreateButton(WindowCount, "btnSkills", 82, 1, 29, 29, , , 109, , , , , , DesignType.Green, DesignType.Green_Hover, DesignType.Green_Click, , , New Action(AddressOf btnMenu_Skills), , , -1, -2, "Skills (K)")
        'CreateButton WindowCount, "btnMap", 119, 1, 29, 29, , , , Tex_Item(106), , , , , , DesignType.desGreen, DesignType.desGreen_Hover, DesignType.desGreen_Click, , , New Action(AddressOf btnMenu_Map), , , -1, -2
        'CreateButton WindowCount, "btnGuild", 155, 1, 29, 29, , , , Tex_Item(107), , , , , , DesignType.desGreen, DesignType.desGreen_Hover, DesignType.desGreen_Click, , , New Action(AddressOf btnMenu_Guild), , , -1, -1
        'CreateButton WindowCount, "btnQuest", 191, 1, 29, 29, , , , Tex_Item(23), , , , , , DesignType.desGreen, DesignType.desGreen_Hover, DesignType.desGreen_Click, , , New Action(AddressOf btnMenu_Quest), , , -1, -2
        CreateButton(WindowCount, "btnMap", 119, 1, 29, 29, , , 106, , , , , , DesignType.Grey, DesignType.Grey, DesignType.Grey, , , New Action(AddressOf btnMenu_Map), , , -1, -2)
        CreateButton(WindowCount, "btnGuild", 155, 1, 29, 29, , , 107, , , , , , DesignType.Grey, DesignType.Grey, DesignType.Grey, , , New Action(AddressOf btnMenu_Guild), , , , , -1, -1)
        CreateButton(WindowCount, "btnQuest", 191, 1, 29, 29, , , 23, , , , , , DesignType.Grey, DesignType.Grey, DesignType.Grey, , , New Action(AddressOf btnMenu_Quest), , , -1, -2)
    End Sub

    Public Sub CreateWindow_Inventory()
        ' Create window
        CreateWindow("winInventory", "Inventory", Georgia, zOrder_Win, 0, 0, 202, 319, 1, False, 2, 7, DesignType.Win_Empty, DesignType.Win_Empty, DesignType.Win_Empty, , , , , , New Action(AddressOf Inventory_MouseMove), New Action(AddressOf Inventory_MouseDown), New Action(AddressOf Inventory_DblClick), New Action(AddressOf DrawInventory))

        ' Centralise it
        CentralizeWindow(WindowCount)

        ' Set the index for spawning controls
        zOrder_Con = 1

        ' Close button
        CreateButton(WindowCount, "btnClose", Windows(WindowCount).Window.Width - 19, 5, 16, 16, , , , 8, 9, 10, , , , , , , , New Action(AddressOf btnMenu_Inv))

        ' Gold amount
        CreatePictureBox(WindowCount, "picBlank", 8, 293, 186, 18, , , , , 67, 67, 67)
        'CreateLabel(WindowCount, "lblGold", 42, 296, 100, FontSize, "Gold", Verdana, Color.Yellow)

        ' Drop
        CreateButton(WindowCount, "btnDrop", 155, 294, 38, 16, "Drop" , , , , , , , , DesignType.Green, DesignType.Green_Hover, DesignType.Green_Click, , , , , , 5, 3)
    End Sub

    Public Sub CreateWindow_Character()
        ' Create window
        CreateWindow("winCharacter", "Character", Georgia, zOrder_Win, 0, 0, 174, 356, 62, False, 2, 6, DesignType.Win_Empty, DesignType.Win_Empty, DesignType.Win_Empty, , , , , , New Action(AddressOf Character_MouseMove), New Action(AddressOf Character_MouseDown), , New Action(AddressOf DrawCharacter))

        ' Centralise it
        CentralizeWindow(WindowCount)

        ' Set the index for spawning controls
        zOrder_Con = 1

        ' Close button
        CreateButton(WindowCount, "btnClose", Windows(WindowCount).Window.Width - 19, 5, 16, 16, , , , 8, 9, 10, , , , , , , , New Action(AddressOf btnMenu_Char))

        ' Parchment
        CreatePictureBox(WindowCount, "picParchment", 6, 26, 162, 287, , , , , , , , DesignType.Parchment, DesignType.Parchment, DesignType.Parchment)

        ' White boxes
        CreatePictureBox(WindowCount, "picWhiteBox", 13, 34, 148, 19, , , , , , , , DesignType.TextWhite, DesignType.TextWhite, DesignType.TextWhite)
        CreatePictureBox(WindowCount, "picWhiteBox", 13, 54, 148, 19, , , , , , , , DesignType.TextWhite, DesignType.TextWhite, DesignType.TextWhite)
        CreatePictureBox(WindowCount, "picWhiteBox", 13, 74, 148, 19, , , , , , , , DesignType.TextWhite, DesignType.TextWhite, DesignType.TextWhite)
        CreatePictureBox(WindowCount, "picWhiteBox", 13, 94, 148, 19, , , , , , , , DesignType.TextWhite, DesignType.TextWhite, DesignType.TextWhite)
        CreatePictureBox(WindowCount, "picWhiteBox", 13, 114, 148, 19, , , , , , , , DesignType.TextWhite, DesignType.TextWhite, DesignType.TextWhite)
        CreatePictureBox(WindowCount, "picWhiteBox", 13, 134, 148, 19, , , , , , , , DesignType.TextWhite, DesignType.TextWhite, DesignType.TextWhite)
        CreatePictureBox(WindowCount, "picWhiteBox", 13, 154, 148, 19, , , , , , , , DesignType.TextWhite, DesignType.TextWhite, DesignType.TextWhite)

        ' Labels
        CreateLabel(WindowCount, "lblName", 18, 36, 147, FontSize, "Name", Arial, Color.White)
        CreateLabel(WindowCount, "lblJob", 18, 56, 147, FontSize, "Job", Arial, Color.White)
        CreateLabel(WindowCount, "lblLevel", 18, 76, 147, FontSize, "Level", Arial, Color.White)
        CreateLabel(WindowCount, "lblGuild", 18, 96, 147, FontSize, "Guild", Arial, Color.White)
        CreateLabel(WindowCount, "lblHealth", 18, 116, 147, FontSize, "Health", Arial, Color.White)
        CreateLabel(WindowCount, "lblSpirit", 18, 136, 147, FontSize, "Spirit", Arial, Color.White)
        CreateLabel(WindowCount, "lblExperience", 18, 156, 147, FontSize, "Experience", Arial, Color.White)
        CreateLabel(WindowCount, "lblName2", 13, 36, 147, FontSize, "Name", Arial, Color.White, AlignmentType.Right)
        CreateLabel(WindowCount, "lblJob2", 13, 56, 147, FontSize, "", Arial, Color.White, AlignmentType.Right)
        CreateLabel(WindowCount, "lblLevel2", 13, 76, 147, FontSize, "Level", Arial, Color.White, AlignmentType.Right)
        CreateLabel(WindowCount, "lblGuild2", 13, 96, 147, FontSize, "Guild", Arial, Color.White, AlignmentType.Right)
        CreateLabel(WindowCount, "lblHealth2", 13, 116, 147, FontSize, "Health", Arial, Color.White, AlignmentType.Right)
        CreateLabel(WindowCount, "lblSpirit2", 13, 136, 147, FontSize, "Spirit", Arial, Color.White, AlignmentType.Right)
        CreateLabel(WindowCount, "lblExperience2", 13, 156, 147, FontSize, "Experience", Arial, Color.White, AlignmentType.Right)

        ' Attributes
        CreatePictureBox(WindowCount, "picShadow", 18, 176, 138, 9, , , , , , , , DesignType.BlackOval, DesignType.BlackOval, DesignType.BlackOval)
        CreateLabel(WindowCount, "lblLabel", 18, 173, 138, FontSize, "Attributes", Arial, Color.White, AlignmentType.Center)

        ' Black boxes
        CreatePictureBox(WindowCount, "picBlackBox", 13, 186, 148, 19, , , , , , , , DesignType.TextBlack, DesignType.TextBlack, DesignType.TextBlack)
        CreatePictureBox(WindowCount, "picBlackBox", 13, 206, 148, 19, , , , , , , , DesignType.TextBlack, DesignType.TextBlack, DesignType.TextBlack)
        CreatePictureBox(WindowCount, "picBlackBox", 13, 226, 148, 19, , , , , , , , DesignType.TextBlack, DesignType.TextBlack, DesignType.TextBlack)
        CreatePictureBox(WindowCount, "picBlackBox", 13, 246, 148, 19, , , , , , , , DesignType.TextBlack, DesignType.TextBlack, DesignType.TextBlack)
        CreatePictureBox(WindowCount, "picBlackBox", 13, 266, 148, 19, , , , , , , , DesignType.TextBlack, DesignType.TextBlack, DesignType.TextBlack)
        CreatePictureBox(WindowCount, "picBlackBox", 13, 286, 148, 19, , , , , , , , DesignType.TextBlack, DesignType.TextBlack, DesignType.TextBlack)

        ' Labels
        CreateLabel(WindowCount, "lblLabel", 18, 188, 138, FontSize, "Strength", Arial, Color.Yellow)
        CreateLabel(WindowCount, "lblLabel", 18, 208, 138, FontSize, "Vitality", Arial, Color.Yellow)
        CreateLabel(WindowCount, "lblLabel", 18, 228, 138, FontSize, "Intelligence", Arial, Color.Yellow)
        CreateLabel(WindowCount, "lblLabel", 18, 248, 138, FontSize, "Luck", Arial, Color.Yellow)
        CreateLabel(WindowCount, "lblLabel", 18, 268, 138, FontSize, "Spirit", Arial, Color.Yellow)
        CreateLabel(WindowCount, "lblLabel", 18, 288, 138, FontSize, "Stat Points", Arial, Color.Green)

        ' Buttons
        CreateButton(WindowCount, "btnStat_1", 144, 188, 15, 15, , , , 48, 49, 50, , , , , , , , New Action(AddressOf Character_SpendPoint1))
        CreateButton(WindowCount, "btnStat_2", 144, 208, 15, 15, , , , 48, 49, 50, , , , , , , , New Action(AddressOf Character_SpendPoint2))
        CreateButton(WindowCount, "btnStat_3", 144, 228, 15, 15, , , , 48, 49, 50, , , , , , , , New Action(AddressOf Character_SpendPoint3))
        CreateButton(WindowCount, "btnStat_4", 144, 248, 15, 15, , , , 48, 49, 50, , , , , , , , New Action(AddressOf Character_SpendPoint4))
        CreateButton(WindowCount, "btnStat_5", 144, 268, 15, 15, , , , 48, 49, 50, , , , , , , , New Action(AddressOf Character_SpendPoint5))

        ' fake buttons
        CreatePictureBox(WindowCount, "btnGreyStat_1", 144, 188, 15, 15, , , , , 47, 47, 47)
        CreatePictureBox(WindowCount, "btnGreyStat_2", 144, 208, 15, 15, , , , , 47, 47, 47)
        CreatePictureBox(WindowCount, "btnGreyStat_3", 144, 228, 15, 15, , , , , 47, 47, 47)
        CreatePictureBox(WindowCount, "btnGreyStat_4", 144, 248, 15, 15, , , , , 47, 47, 47)
        CreatePictureBox(WindowCount, "btnGreyStat_5", 144, 268, 15, 15, , , , , 47, 47, 47)

        ' Labels
        CreateLabel(WindowCount, "lblStat_1", 50, 188, 100, 15, "255", Arial, Color.White, AlignmentType.Right)
        CreateLabel(WindowCount, "lblStat_2", 50, 208, 100, 15, "255", Arial, Color.White, AlignmentType.Right)
        CreateLabel(WindowCount, "lblStat_3", 50, 228, 100, 15, "255", Arial, Color.White, AlignmentType.Right)
        CreateLabel(WindowCount, "lblStat_4", 50, 248, 100, 15, "255", Arial, Color.White, AlignmentType.Right)
        CreateLabel(WindowCount, "lblStat_5", 50, 268, 100, 15, "255", Arial, Color.White, AlignmentType.Right)
        CreateLabel(WindowCount, "lblPoints", 65, 288, 100, 15, "255", Arial, Color.White, AlignmentType.Right)
    End Sub


    ' ###############
    ' ## Character ##
    ' ###############
    Public Sub DrawCharacter()
        Dim xO As Long, yO As Long, Width As Long, Height As Long, i As Long, sprite As Long, itemNum As Long, ItemPic As Long

        xO = Windows(GetWindowIndex("winCharacter")).Window.Left
        yO = Windows(GetWindowIndex("winCharacter")).Window.Top

        ' Render bottom
        RenderTexture(InterfaceSprite(37), Window, xO + 4, yO + 314, 0, 0, 40, 38, 40, 38)
        RenderTexture(InterfaceSprite(37), Window, xO + 44, yO + 314, 0, 0, 40, 38, 40, 38)
        RenderTexture(InterfaceSprite(37), Window, xO + 84, yO + 314, 0, 0, 40, 38, 40, 38)
        RenderTexture(InterfaceSprite(37), Window, xO + 124, yO + 314, 0, 0, 46, 38, 46, 38)

        ' render top wood
        RenderTexture(InterfaceSprite(1), Window, xO + 4, yO + 23, 100, 100, 166, 291, 166, 291)

        ' loop through equipment
        For i = 1 To EquipmentType.Count - 1
            itemNum = GetPlayerEquipment(Myindex, i)

            ' get the item sprite
            If itemNum > 0 Then
                ItemPic = Item(itemNum).Icon
            Else
                ' no item equiped - use blank image
                ItemPic = 37 + i
            End If

            yO = Windows(GetWindowIndex("winCharacter")).Window.Top + EqTop
            xO = Windows(GetWindowIndex("winCharacter")).Window.Left + EqLeft + ((EqOffsetX + 32) * (((i - 1) Mod EqColumns)))

            RenderTexture(ItemSprite(ItemPic), Window, xO, yO, 0, 0, 32, 32, 32, 32)
        Next
    End Sub

    Public Sub Character_MouseDown()
        Dim itemNum As Long

        itemNum = IsEqItem(Windows(GetWindowIndex("winCharacter")).Window.Left, Windows(GetWindowIndex("winCharacter")).Window.Top)

        If itemNum Then
            SendUnequip(itemNum)
        End If

        ' show desc. if needed
        Character_MouseMove()
    End Sub

    Public Sub Character_MouseMove()
        Dim itemNum As Long, x As Long, y As Long

        ' exit out early if dragging
        If DragBox.Type <> PartType.None Then Exit Sub

        itemNum = IsEqItem(Windows(GetWindowIndex("winCharacter")).Window.Left, Windows(GetWindowIndex("winCharacter")).Window.Top)

        If itemNum Then
            ' calc position
            x = Windows(GetWindowIndex("winCharacter")).Window.Left - Windows(GetWindowIndex("winDescription")).Window.Width
            y = Windows(GetWindowIndex("winCharacter")).Window.Top - 4
            ' offscreen?
            If x < 0 Then
                ' switch to right
                x = Windows(GetWindowIndex("winCharacter")).Window.Left + Windows(GetWindowIndex("winCharacter")).Window.Width
            End If
            ' go go go
            'ShowEqDesc x, y, itemNum
        End If
    End Sub

    Public Sub Character_SpendPoint1()
        SendTrainStat(1)
    End Sub

    Public Sub Character_SpendPoint2()
        SendTrainStat(2)
    End Sub

    Public Sub Character_SpendPoint3()
        SendTrainStat(3)
    End Sub

    Public Sub Character_SpendPoint4()
        SendTrainStat(4)
    End Sub

    Public Sub Character_SpendPoint5()
        SendTrainStat(5)
    End Sub

    Public Sub DrawInventory()
        Dim xO As Long, yO As Long, Width As Long, Height As Long, i As Long, y As Long, itemNum As Long, ItemPic As Long, x As Long, Top As Long, Left As Long, Amount As String
        Dim Color As Color, skipItem As Boolean, amountModifier As Long, tmpItem As Long

        xO = Windows(GetWindowIndex("winInventory")).Window.Left
        yO = Windows(GetWindowIndex("winInventory")).Window.Top
        Width = Windows(GetWindowIndex("winInventory")).Window.Width
        Height = Windows(GetWindowIndex("winInventory")).Window.Height

        ' render green
        RenderTexture(InterfaceSprite(34), Window, xO + 4, yO + 23, 0, 0, Width - 8, Height - 27, 4, 4)

        Width = 76
        Height = 76

        y = yO + 23
        ' render grid - row
        For i = 1 To 4
            If i = 4 Then Height = 38
            RenderTexture(InterfaceSprite(35), Window, xO + 4, y, 0, 0, Width, Height, Width, Height)
            RenderTexture(InterfaceSprite(35), Window, xO + 80, y, 0, 0, Width, Height, Width, Height)
            RenderTexture(InterfaceSprite(35), Window, xO + 156, y, 0, 0, 42, Height, 42, Height)
            y = y + 76
        Next

        ' render bottom wood
        RenderTexture(InterfaceSprite(1), Window, xO + 4, yO + 289, 100, 100, 194, 26, 194, 26)

        ' actually draw the icons
        For i = 1 To MAX_INV
            itemNum = GetPlayerInvItemNum(Myindex, i)
            StreamItem(itemNum)

            If itemNum > 0 And itemNum <= MAX_ITEMS Then
                ' not dragging?
                If Not (DragBox.Origin = PartOriginType.Inventory And DragBox.Slot = i) Then
                    ItemPic = Item(itemNum).Icon

                    ' exit out if we're offering item in a trade.
                    amountModifier = 0
                    If InTrade > 0 Then
                        For x = 1 To MAX_INV
                            tmpItem = GetPlayerInvItemNum(Myindex, TradeYourOffer(x).Num)
                            If TradeYourOffer(x).Num = i Then
                                ' check if currency
                                If Not Item(tmpItem).Type = ItemType.Currency Then
                                    ' normal item, exit out
                                    skipItem = True
                                Else
                                    ' if amount = all currency, remove from inventory
                                    If TradeYourOffer(x).Value = GetPlayerInvItemValue(Myindex, i) Then
                                        skipItem = True
                                    Else
                                        ' not all, change modifier to show change in currency count
                                        amountModifier = TradeYourOffer(x).Value
                                    End If
                                End If
                            End If
                        Next
                    End If

                    If Not skipItem Then
                        If ItemPic > 0 And ItemPic <= NumItems Then
                            Top = yO + InvTop + ((InvOffsetY + 32) * ((i - 1) \ InvColumns))
                            Left = xO + InvLeft + ((InvOffsetX + 32) * (((i - 1) Mod InvColumns)))

                            ' draw icon
                            RenderTexture(ItemSprite(ItemPic), Window, Left, Top, 0, 0, 32, 32, 32, 32)

                            ' If item is a stack - draw the amount you have
                            If GetPlayerInvItemValue(Myindex, i) > 1 Then
                                y = Top + 21
                                x = Left + 1
                                Amount = GetPlayerInvItemValue(Myindex, i) - amountModifier

                                ' Draw currency but with k, m, b etc. using a convertion function
                                If CLng(Amount) < 1000000 Then
                                    Color = GetSfmlColor(ColorType.White)
                                ElseIf CLng(Amount) > 1000000 And CLng(Amount) < 10000000 Then
                                    Color = GetSfmlColor(ColorType.Yellow)
                                ElseIf CLng(Amount) > 10000000 Then
                                    Color = GetSfmlColor(ColorType.BrightGreen)
                                End If

                                RenderText(ConvertCurrency(Amount), Window, x, y, Color, Color, , Verdana)
                            End If
                        End If
                    End If
                    ' reset
                    skipItem = False
                End If
            End If
        Next
    End Sub

    Public Sub CreateWindow_Description()
        ' Create window
        CreateWindow("winDescription", "", Georgia, zOrder_Win, 0, 0, 193, 142, 0, False, , , , , DesignType.Win_Desc, DesignType.Win_Desc, DesignType.Win_Desc, , , , , , , , False)

        ' Set the index for spawning controls
        zOrder_Con = 1

        ' Name
        CreateLabel(WindowCount, "lblName", 8, 12, 177, FontSize, "Flame Sword", Arial, Color.Blue, AlignmentType.Center)

        ' Sprite box
        CreatePictureBox(WindowCount, "picSprite", 18, 32, 68, 68, , , , , , , , DesignType.DescPic, DesignType.DescPic, DesignType.DescPic, , , , , , New Action(AddressOf Description_OnDraw))

        ' Sep
        CreatePictureBox(WindowCount, "picSep", 96, 28, 1, 92, , , , , 44, 44, 44)

        ' Requirements
        CreateLabel(WindowCount, "lblClass", 5, 102, 92, FontSize, "Warrior", Verdana, Color.Green, AlignmentType.Center)
        CreateLabel(WindowCount, "lblLevel", 5, 114, 92, FontSize, "Level 20", Verdana, Color.Red, AlignmentType.Center)

        ' Bar
        CreatePictureBox(WindowCount, "picBar", 19, 114, 66, 12, False, , , , 45, 45, 45)
    End Sub

    ' #################
    ' ## Description ##
    ' #################
    Public Sub Description_OnDraw()
        Dim xO As Long, yO As Long, texNum As Long, y As Long, I As Long, count As Long

        ' exit out if we don't have a num
        If descItem = 0 Or descType = 0 Then Exit Sub

        xO = Windows(GetWindowIndex("winDescription")).Window.Left
        yO = Windows(GetWindowIndex("winDescription")).Window.Top

        Select Case descType
            Case 1 ' Inventory Item
                texNum = Item(descItem).Icon

                ' render sprite
                RenderTexture(ItemSprite(texNum), Window, xO + 20, yO + 34, 0, 0, 64, 64, 32, 32)
            Case 2 ' Skill Icon
                texNum = Skill(descItem).Icon
                ' render bar
                With Windows(GetWindowIndex("winDescription")).Controls(GetControlIndex("winDescription", "picBar"))
                    If .Visible Then RenderTexture(InterfaceSprite(45), Window, xO + .Left, yO + .Top, 0, 12, .Value, 12, .Value, 12)
                End With

                ' render sprite
                RenderTexture(SkillSprite(texNum), Window, xO + 20, yO + 34, 0, 0, 64, 64, 32, 32)
        End Select

        ' render text array
        y = 18
        count = UBound(descText)
        For I = 1 To count
            RenderText(descText(I).Text, Window, xO + 141 - (TextWidth(descText(I).Text) \ 2), yO + y, descText(I).Color, Color.Black)
            y = y + 12
        Next
    End Sub

    Public Sub CreateWindow_DragBox()
        ' Create window
        CreateWindow("winDragBox", "", Georgia, zOrder_Win, 0, 0, 32, 32, 0, false, , , , , , , , , , , , New Action(AddressOf DragBox_Check), , New Action(AddressOf DragBox_OnDraw))
        
        ' Need to set up unique mouseup event
        Windows(WindowCount).Window.CallBack(entState.MouseUp) = New Action(AddressOf DragBox_Check)
    End Sub

    Public Sub CreateWindow_Options()
        CreateWindow("winOptions", "", Georgia, zOrder_Win, 0, 0, 210, 212, 0, 0, , , DesignType.Win_NoBar, DesignType.Win_NoBar, DesignType.Win_NoBar, , , , , , , , , , , ,False, False)

        ' Centralize it
        CentralizeWindow(windowCount)

        ' Set the index for spawning controls
        zOrder_Con = 1

        ' Parchment
        CreatePictureBox(windowCount, "picParchment", 6, 6, 198, 200, , , , , , , , DesignType.Parchment, DesignType.Parchment, DesignType.Parchment)

        ' General
        CreatePictureBox(windowCount, "picBlank", 35, 25, 140, FontSize, , , , , , , , DesignType.Parchment, DesignType.Parchment, DesignType.Parchment)
        CreateLabel(windowCount, "lblBlank", 35, 22, 140, 0, "General Options", Verdana, Color.White, AlignmentType.Center)
    
        ' Check boxes
        CreateCheckbox(windowCount, "chkMusic", 35, 40, 80, , , "Music", Verdana, , , , DesignType.ChkNorm)
        CreateCheckbox(windowCount, "chkSound", 115, 40, 80, , , "Sound", Verdana, , , , DesignType.ChkNorm)
        CreateCheckbox(windowCount, "chkAutotile", 35, 60, 80, , , "Autotile", Verdana, , , , DesignType.ChkNorm)
        CreateCheckbox(windowCount, "chkFullscreen", 115, 60, 80, , , "Fullscreen", Verdana, , , , DesignType.ChkNorm)

        ' Resolution
        CreatePictureBox(windowCount, "picBlank", 35, 85, 140, FontSize, , , , , , , , DesignType.Parchment, DesignType.Parchment, DesignType.Parchment)
        CreateLabel(windowCount, "lblBlank", 35, 92, 140, FontSize, "Select Resolution", Verdana, Color.White, AlignmentType.Center)

        ' combobox
        CreateComboBox(windowCount, "cmbRes", 30, 100, 150, 18, DesignType.ComboNorm)

        ' Button
        CreateButton(windowCount, "btnConfirm", 65, 168, 80, 22, "Confirm", Verdana, , , , , , , DesignType.Green, DesignType.Green_Hover, DesignType.Green_Click, , , AddressOf btnOptions_Confirm)

        ' Populate the options screen
        SetOptionsScreen
    End Sub

    Public Sub CreateWindow_Combobox()
        ' background window
        CreateWindow("winComboMenuBG", "ComboMenuBG", Georgia, zOrder_Win, 0, 0, 800, 600, 0, False, , , , , , , , , , , , , New Action(AddressOf CloseComboMenu), , , False, False)

        ' window
        CreateWindow("winComboMenu", "ComboMenu", Georgia, zOrder_Win, 0, 0, 100, 100, 0, False, , , DesignType.ComboMenuNorm, , , , , , , , , , , , , , False, False)

        ' centralize it
        CentralizeWindow(windowCount)
End Sub

    Public Sub CreateWindow_Skills()
        ' Create window
        CreateWindow("winSkills", "Skills", Georgia, zOrder_Win, 0, 0, 202, 297, 109, False, 2, 7, DesignType.Win_Empty, DesignType.Win_Empty, DesignType.Win_Empty, , , , , , New Action(AddressOf Skills_MouseMove), New Action(AddressOf Skills_MouseDown), New Action(AddressOf Skills_DblClick), New Action(AddressOf DrawSkills))
    
        ' Centralize it
        CentralizeWindow(WindowCount)
    
        ' Set the index for spawning controls
        zOrder_Con = 1
    
        ' Close button
        CreateButton(WindowCount, "btnClose", Windows(WindowCount).Window.Width - 19, 5, 16, 16, , , , 8, 9, 10, , , , , , , , New Action(AddressOf btnMenu_Skills))
    End Sub

    Sub ResizeGUI()
        Dim Top As Long

        ' move hotbar
        Windows(GetWindowIndex("winHotbar")).Window.Left = Window.Size.X - 462

        ' move menu
        Windows(GetWindowIndex("winMenu")).Window.Left = Window.Size.X - 264
        Windows(GetWindowIndex("winMenu")).Window.Top = Window.Size.Y - 48

        ' move invitations
        Windows(GetWindowIndex("winInvite_Party")).Window.Left = Window.Size.X - 234
        Windows(GetWindowIndex("winInvite_Party")).Window.Top = Window.Size.Y - 80

        ' loop through
        Top = Window.Size.Y - 80

        If Windows(GetWindowIndex("winInvite_Party")).Window.visible Then
            Top = Top - 37
        End If

        Windows(GetWindowIndex("winInvite_Trade")).Window.Left = Window.Size.X - 234
        Windows(GetWindowIndex("winInvite_Trade")).Window.Top = Top

        ' re-size right-click background
        Windows(GetWindowIndex("winRightClickBG")).Window.Width = Window.Size.X
        Windows(GetWindowIndex("winRightClickBG")).Window.Height = Window.Size.Y

        ' re-size combo background
        Windows(GetWindowIndex("winComboMenuBG")).Window.Width = Window.Size.X
        Windows(GetWindowIndex("winComboMenuBG")).Window.Height = Window.Size.Y
    End Sub

    Public Sub DrawSkills()
        Dim xO As Long, yO As Long, Width As Long, Height As Long, i As Long, y As Long, Skillnum As Long, SkillPic As Long, x As Long, Top As Long, Left As Long

        xO = Windows(GetWindowIndex("winSkills")).Window.Left
        yO = Windows(GetWindowIndex("winSkills")).Window.Top
    
        Width = Windows(GetWindowIndex("winSkills")).Window.Width
        Height = Windows(GetWindowIndex("winSkills")).Window.Height
    
        ' render green
        RenderTexture(InterfaceSprite(34), Window, xO + 4, yO + 23, 0, 0, Width - 8, Height - 27, 4, 4)
    
        Width = 76
        Height = 76
    
        y = yO + 23
        ' render grid - row
        For i = 1 To 4
            If i = 4 Then Height = 42
            RenderTexture(InterfaceSprite(35), Window, xO + 4, y, 0, 0, Width, Height, Width, Height)
            RenderTexture(InterfaceSprite(35), Window, xO + 80, y, 0, 0, Width, Height, Width, Height)
            RenderTexture(InterfaceSprite(35), Window, xO + 156, y, 0, 0, 42, Height, 42, Height)
            y = y + 76
        Next
    
        ' actually draw the icons
        For i = 1 To MAX_PLAYER_SKILLS
            Skillnum = Player(Myindex).Skill(i).Num
            If Skillnum > 0 And Skillnum <= MAX_SKILLS Then
                StreamSkill(Skillnum)

                ' not dragging?
                If Not (DragBox.Origin = PartOriginType.Skill And DragBox.Slot = i) Then
                    SkillPic = Skill(Skillnum).Icon

                    If SkillPic > 0 And SkillPic <= NumSkills Then
                        If SkillGfxInfo(SkillPic).IsLoaded = False Then
                            LoadTexture(SkillPic, 9)
                        End If

                        Top = yO + SkillTop + ((SkillOffsetY + 32) * ((i - 1) \ SkillColumns))
                        Left = xO + SkillLeft + ((SkillOffsetX + 32) * (((i - 1) Mod SkillColumns)))
    
                        RenderTexture(SkillSprite(SkillPic), Window, Left, Top, 0, 0, 32, 32, 32, 32)
                    End If
                End If
            End If
        Next
    End Sub

    ' Options
    Public Sub btnOptions_Close()
        HideWindow(GetWindowIndex("winOptions"))
        ShowWindow(GetWindowIndex("winEscMenu"))
    End Sub

    Sub btnOptions_Confirm()
        Dim i As Long, Value As Long, Width As Long, Height As Long, message As Boolean, musicFile As String

        ' music
        Value = Windows(GetWindowIndex("winOptions")).Controls(GetControlIndex("winOptions", "chkMusic")).Value
        If Types.Settings.Music <> Value Then
            Types.Settings.Music = Value

            ' let them know
            If Value = 0 Then
                AddText("Music turned off.", ColorType.BrightGreen)
                StopMusic
            Else
                AddText("Music tured on.", ColorType.BrightGreen)
                ' play music
                If InGame Then musicFile = Trim$(Map.Music) Else musicFile = Trim$(Types.Settings.Music)
                If Not musicFile = "None." Then
                    PlayMusic(musicFile)
                Else
                    StopMusic
                End If
            End If
        End If
    
        ' sound
        Value = Windows(GetWindowIndex("winOptions")).Controls(GetControlIndex("winOptions", "chkSound")).Value
        If Types.Settings.Sound <> Value Then
            Types.Settings.Sound = Value
            ' let them know
            If Value = 0 Then
                AddText("Sound turned off.", ColorType.BrightGreen)
            Else
                AddText("Sound tured on.", ColorType.BrightGreen)
            End If
        End If
    
        ' autotiles
        Value = Windows(GetWindowIndex("winOptions")).Controls(GetControlIndex("winOptions", "chkAutotile")).Value
        If Types.Settings.Autotile <> Value Then
            Types.Settings.Autotile = Value
            ' let them know
            If Value = 0 Then
                If InGame Then
                    AddText("Autotiles turned off.", ColorType.BrightGreen)
                    initAutotiles
                End If
            Else
                If InGame Then
                    AddText("Autotiles turned on.", ColorType.BrightGreen)
                    initAutotiles
                End If
            End If
        End If
    
        ' fullscreen
        Value = Windows(GetWindowIndex("winOptions")).Controls(GetControlIndex("winOptions", "chkFullscreen")).Value
        If Types.Settings.Fullscreen <> Value Then
            Types.Settings.Fullscreen = Value
            message = True
        End If
    
        ' resolution
        With Windows(GetWindowIndex("winOptions")).Controls(GetControlIndex("winOptions", "cmbRes"))
            If .Value > 0 And .Value <= 13 Then
                message = True
            End If
        End With
    
        ' save options
        Types.Settings.Save()

        ' let them know
        If InGame Then
            If message Then AddText("Some changes will take effect next time you load the game.", ColorType.BrightGreen)
        End If

        ' close
        btnOptions_Close
    End Sub
End Module

