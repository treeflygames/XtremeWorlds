
Imports System.Windows.Forms.Design.AxImporter
Imports Core
Imports DarkUI.Config
Imports SFML.Graphics
Imports SFML.System

Module C_Text
    Friend Const MaxChatDisplayLines As Byte = 11
    Friend Const ChatLineSpacing As Byte = FontSize ' Should be same height as font
    Friend Const MyChatTextLimit As Integer = 40
    Friend Const MyAmountValueLimit As Integer = 3
    Friend Const AllChatLineWidth As Integer = 40
    Friend Const ChatboxPadding As Integer = 45 + 16 + 2 ' 10 = left and right border padding +2 each (3+2+3+2), 16 = scrollbar width, +2 for padding between scrollbar and text
    Friend Const ChatEntryPadding As Integer = 10 ' 5 on left and right
    Friend FirstLineindex As Integer = 0
    Friend LastLineindex As Integer = 0
    Friend ScrollMod As Integer = 0

    Function CensorText(input As String) As String
        Return New String("*"c, input.Length)
    End Function

    Friend Sub RenderText(text As String, ByRef target As RenderWindow, x As Integer, y As Integer, frontColor As Color, backColor As Color, Optional textSize As Byte = FontSize, Optional fontName As String = "Georgia.ttf")
        Dim backString As Text
        Dim frontString As Text

        Select Case fontName
            Case Georgia
                backString = New Text(text, Fonts(FontType.Georgia), textSize)
                frontString = New Text(text, Fonts(FontType.Georgia), textSize)

            Case Arial
                backString = New Text(text, Fonts(FontType.Arial), textSize)
                frontString = New Text(text, Fonts(FontType.Arial), textSize)

            Case Verdana
                backString = New Text(text, Fonts(FontType.Verdana), textSize)
                frontString = New Text(text, Fonts(FontType.Verdana), textSize)
        End Select

        ' Set properties for backString
        backString.Color = New Color(backColor.R, backColor.G, backColor.B, 190)
        backString.LetterSpacing = 2
        backString.Position = New Vector2f(x + 1, y + 1)

        ' Draw backString
        target.Draw(backString)

        ' Set properties for frontString
        frontString.Color = New Color (frontColor.R, frontColor.G, frontColor.B, 255)
        frontString.LetterSpacing = 2
        frontString.Position = New Vector2f(x, y)

        ' Draw frontString
        target.Draw(frontString)
    End Sub

    Friend Sub DrawNpcName(mapNpcNum As Integer)
        Dim textX As Integer
        Dim textY As Integer
        Dim color As Color, backcolor As Color
        Dim npcNum As Integer

        npcNum = MapNpc(mapNpcNum).Num

        Select Case NPC(npcNum).Behaviour
            Case 0 ' attack on sight
                color = Color.Red
                backcolor = Color.Black
            Case 1, 4 ' attack when attacked + guard
                color = Color.Green
                backcolor = Color.Black
            Case 2, 3, 5 ' friendly + shopkeeper + quest
                color = Color.Yellow
                backcolor = Color.Black
        End Select

        textX = ConvertMapX(MapNpc(mapNpcNum).X * PicX) + MapNpc(mapNpcNum).XOffset + (PicX \ 2) - (TextWidth((Trim$(NPC(npcNum).Name))) / 2) - 2
        If NPC(npcNum).Sprite < 1 OrElse NPC(npcNum).Sprite > NumCharacters Then
            textY = ConvertMapY(MapNpc(mapNpcNum).Y * PicY) + MapNpc(mapNpcNum).YOffset - 16
        Else
            textY = ConvertMapY(MapNpc(mapNpcNum).Y * PicY) + MapNpc(mapNpcNum).YOffset - (CharacterGfxInfo(NPC(npcNum).Sprite).Height / 4) + 16
        End If

        ' Draw name
        RenderText(NPC(npcNum).Name, Window, textX, textY, color, backcolor)
    End Sub

    Friend Sub DrawEventName(index As Integer)
        Dim textX As Integer
        Dim textY As Integer
        Dim color As Color, backcolor As Color
        Dim name As String

        color = Color.Yellow
        backcolor = Color.Black

        name = Trim$(MapEvents(index).Name)

        ' calc pos
        textX = ConvertMapX(MapEvents(index).X * PicX) + MapEvents(index).XOffset + (PicX \ 2) - (TextWidth(Trim$(name)) \ 2) - 2
        If MapEvents(index).GraphicType = 0 Then
            textY = ConvertMapY(MapEvents(index).Y * PicY) + MapEvents(index).YOffset - 16
        ElseIf MapEvents(index).GraphicType = 1 Then
            If MapEvents(index).Graphic < 1 OrElse MapEvents(index).Graphic > NumCharacters Then
                textY = ConvertMapY(MapEvents(index).Y * PicY) + MapEvents(index).YOffset - 16
            Else
                ' Determine location for text
                textY = ConvertMapY(MapEvents(index).Y * PicY) + MapEvents(index).YOffset - (CharacterGfxInfo(MapEvents(index).Graphic).Height \ 4) + 16
            End If
        ElseIf MapEvents(index).GraphicType = 2 Then
            If MapEvents(index).GraphicY2 > 0 Then
                textX = textX + (MapEvents(index).GraphicY2 * PicY) \ 2 - 16
                textY = ConvertMapY(MapEvents(index).Y * PicY) + MapEvents(index).YOffset - (MapEvents(index).GraphicY2 * PicY) + 16
            Else
                textY = ConvertMapY(MapEvents(index).Y * PicY) + MapEvents(index).YOffset - 32 + 16
            End If
        End If

        ' Draw name
        RenderText(name, Window, textX, textY, color, backcolor)
    End Sub

    Public Sub DrawMapAttributes()
        Dim X As Integer
        Dim y As Integer
        Dim tX As Integer
        Dim tY As Integer

        If frmEditor_Map.tabpages.SelectedTab Is frmEditor_Map.tpAttributes Then
            For X = TileView.Left To TileView.Right
                For y = TileView.Top To TileView.Bottom
                    If IsValidMapPoint(X, y) Then
                        With Map.Tile(X, y)
                            tX = ((ConvertMapX(X * PicX)) - 4) + (PicX * 0.5)
                            tY = ((ConvertMapY(y * PicY)) - 7) + (PicY * 0.5)
                            Select Case .Type
                                Case [Enum].TileType.Blocked
                                    RenderText("B", Window, tX, tY, (Color.Red), (Color.Black))
                                Case TileType.Warp
                                    RenderText("W", Window, tX, tY, (Color.Blue), (Color.Black))
                                Case TileType.Item
                                    RenderText("I", Window, tX, tY, (Color.White), (Color.Black))
                                Case TileType.NpcAvoid
                                    RenderText("N", Window, tX, tY, (Color.White), (Color.Black))
                                Case TileType.Resource
                                    RenderText("R", Window, tX, tY, (Color.Green), (Color.Black))
                                Case TileType.NpcSpawn
                                    RenderText("S", Window, tX, tY, (Color.Yellow), (Color.Black))
                                Case TileType.Shop
                                    RenderText("S", Window, tX, tY, (Color.Blue), (Color.Black))
                                Case TileType.Bank
                                    RenderText("B", Window, tX, tY, (Color.Blue), (Color.Black))
                                Case TileType.Heal
                                    RenderText("H", Window, tX, tY, (Color.Green), (Color.Black))
                                Case TileType.Trap
                                    RenderText("T", Window, tX, tY, (Color.Red), (Color.Black))
                                Case TileType.Light
                                    RenderText("L", Window, tX, tY, (Color.Yellow), (Color.Black))
                                Case TileType.Animation
                                    RenderText("A", Window, tX, tY, (Color.Red), (Color.Black))
                            End Select
                        End With
                    End If
                Next
            Next
        End If

    End Sub

    Sub DrawActionMsg(index As Integer)
        Dim x As Integer, y As Integer, i As Integer, time As Integer

        ' how long we want each message to appear
        Select Case ActionMsg(index).Type
            Case ActionMsgType.Static
                time = 1500

                If ActionMsg(index).Y > 0 Then
                    x = ActionMsg(index).X + Int(PicX \ 2) - ((Len(Trim$(ActionMsg(index).Message)) \ 2) * 8)
                    y = ActionMsg(index).Y - Int(PicY \ 2) - 2
                Else
                    x = ActionMsg(index).X + Int(PicX \ 2) - ((Len(Trim$(ActionMsg(index).Message)) \ 2) * 8)
                    y = ActionMsg(index).Y - Int(PicY \ 2) + 18
                End If

            Case ActionMsgType.Scroll
                time = 1500

                If ActionMsg(index).Y > 0 Then
                    x = ActionMsg(index).X + Int(PicX \ 2) - ((Len(Trim$(ActionMsg(index).Message)) \ 2) * 8)
                    y = ActionMsg(index).Y - Int(PicY \ 2) - 2 - (ActionMsg(index).Scroll * 0.6)
                    ActionMsg(index).Scroll = ActionMsg(index).Scroll + 1
                Else
                    x = ActionMsg(index).X + Int(PicX \ 2) - ((Len(Trim$(ActionMsg(index).Message)) \ 2) * 8)
                    y = ActionMsg(index).Y - Int(PicY \ 2) + 18 + (ActionMsg(index).Scroll * 0.6)
                    ActionMsg(index).Scroll = ActionMsg(index).Scroll + 1
                End If

            Case ActionMsgType.Screen
                time = 3000

                ' This will kill any action screen messages that there in the system
                For i = Byte.MaxValue To 1 Step -1
                    If ActionMsg(i).Type = ActionMsgType.Screen Then
                        If i <> index Then
                            ClearActionMsg(index)
                            index = i
                        End If
                    End If
                Next
                x = (ResolutionWidth \ 2) - ((Len(Trim$(ActionMsg(index).Message)) \ 2) * 8)
                y = 425

        End Select

        x = ConvertMapX(x)
        y = ConvertMapY(y)

        If GetTickCount() < ActionMsg(index).Created + time Then
            RenderText(ActionMsg(index).Message, Window, x, y, GetSfmlColor(ActionMsg(index).Color), (Color.Black))
        Else
            ClearActionMsg(index)
        End If

    End Sub

    Sub RenderChat()
        Dim xO As Long, yO As Long, Color As Integer, yOffset As Long, rLines As Integer, lineCount As Integer
        Dim tmpText As String, i As Long, isVisible As Boolean, topWidth As Integer, tmpArray() As String, x As Integer
        Dim Color2 As Color

        ' set the position
        xO = 19
        yO = ResolutionHeight - 40

        ' loop through chat
        rLines = 1
        i = 1 + ChatScroll

        Do While rLines <= 8
            If i > ChatLines Then Exit Do
            lineCount = 0

            ' exit out early if we come to a blank string
            If Len(Chat(i).Text) = 0 Then Exit Do

            ' get visible state
            isVisible = True
            If inSmallChat Then
                If Not Chat(i).Visible Then isVisible = False
            End If

            If Types.Settings.ChannelState(Chat(i).Channel) = 0 Then isVisible = False

            ' make sure it's visible
            If isVisible Then
                ' render line
                Color = Chat(i).Color
                Color2 = ToSfmlColor(Drawing.ColorTranslator.FromOle(QBColor(Color)))

                ' check if we need to word wrap
                If TextWidth(Chat(i).Text) > ChatWidth Then
                    ' word wrap
                    tmpText = WordWrap(Chat(i).Text, ChatWidth)

                    ' can't have it going offscreen.
                    If rLines + lineCount > 9 Then Exit Do

                    ' continue on
                    yOffset = yOffset - (14 * lineCount)
                    RenderText(tmpText, Window, xO, yO + yOffset, Color2, Color2)
                    rLines = rLines + lineCount

                    ' set the top width
                    tmpArray = Split(tmpText, vbNewLine)
                    For x = 0 To UBound(tmpArray)
                        If TextWidth(tmpArray(x)) > topWidth Then topWidth = TextWidth(tmpArray(x))
                    Next
                Else
                    ' normal
                    yOffset = yOffset - 14

                    RenderText(Chat(i).Text, Window, xO, yO + yOffset, Color2, Color2)
                    rLines = rLines + 1

                    ' set the top width
                    If TextWidth(Chat(i).Text) > topWidth Then topWidth = TextWidth(Chat(i).Text)
                End If
            End If
            ' increment chat pointer
            i = i + 1
        Loop

        ' get the height of the small chat box
        SetChatHeight(rLines * 14)
        SetChatWidth(topWidth)
    End Sub

    Private ReadOnly FontTester As Text = New Text("", Fonts(FontType.Georgia))

    Friend Function TextWidth(text As String, Optional textSize As Byte = FontSize) As Integer
        FontTester.DisplayedString = text
        FontTester.CharacterSize = textSize
        Return FontTester.GetLocalBounds().Width
    End Function

    Friend Function GetTextHeight(text As String, Optional textSize As Byte = FontSize) As Integer
        FontTester.DisplayedString = text
        FontTester.CharacterSize = textSize
        Return FontTester.GetLocalBounds().Height
    End Function

    Public Sub AddText(ByVal text As String, ByVal Color As Integer, Optional ByVal alpha As Long = 255, Optional channel As Byte = 1)
        Dim i As Long

        Chat_HighIndex = 0

        ' Move the rest of it up
        For i = (ChatLines - 1) To 1 Step -1
            If Len(Chat(i).Text) > 0 Then
                If i > Chat_HighIndex Then Chat_HighIndex = i + 1
            End If
            Chat(i + 1) = Chat(i)
        Next

        Chat(1).Text = text
        Chat(1).Color = Color
        Chat(1).Visible = True
        Chat(1).Timer = GetTickCount()
        Chat(1).Channel = channel
    End Sub

    Friend Function GetSfmlColor(color As Byte) As Color
        Select Case color
            Case ColorType.Black
                Return SFML.Graphics.Color.Black
            Case ColorType.Blue
                Return New Color(73, 151, 208)
            Case ColorType.Green
                Return New Color(102, 255, 0, 180)
            Case ColorType.Cyan
                Return New Color(0, 139, 139)
            Case ColorType.Red
                Return New Color(255, 0, 0, 180)
            Case ColorType.Magenta
                Return SFML.Graphics.Color.Magenta
            Case ColorType.Brown
                Return New Color(139, 69, 19)
            Case ColorType.Gray
                Return New Color(211, 211, 211)
            Case ColorType.DarkGray
                Return New Color(169, 169, 169)
            Case ColorType.BrightBlue
                Return New Color(0, 191, 255)
            Case ColorType.BrightGreen
                Return New Color(0, 255, 0)
            Case ColorType.BrightCyan
                Return New Color(0, 255, 255)
            Case ColorType.BrightRed
                Return New Color(255, 0, 0)
            Case ColorType.Pink
                Return New Color(255, 192, 203)
            Case ColorType.Yellow
                Return SFML.Graphics.Color.Yellow
            Case ColorType.White
                Return SFML.Graphics.Color.White
            Case Else
                Return SFML.Graphics.Color.White
        End Select
    End Function

    Friend SplitChars As Char() = New Char() {" "c, "-"c, ControlChars.Tab}

    Public Sub WordWrap_Array(ByVal text As String, ByVal MaxLineLen As Long, ByRef theArray() As String)
        Dim lineCount As Long, i As Long, size As Long, lastSpace As Long, b As Long, tmpNum As Long

        'Too small of text
        If Len(text) < 2 Then
            ReDim theArray(1)
            theArray(1) = text
            Exit Sub
        End If

        ' default values
        b = 1
        lastSpace = 1
        size = 0
        tmpNum = Len(text)

        For i = 1 To tmpNum

            ' if it's a space, store it
            Select Case Mid$(text, i, 1)
                Case " " : lastSpace = i
            End Select

            'Add up the size
            size = size + FontSize

            'Check for too large of a size
            If size > MaxLineLen Then
                'Check if the last space was too far back
                If i - lastSpace > FontSize Then
                    'Too far away to the last space, so break at the last character
                    lineCount = lineCount + 1
                    ReDim Preserve theArray(lineCount)
                    theArray(lineCount) = Trim$(Mid$(text, b, (i - 1) - b))
                    b = i - 1
                    size = 0
                Else
                    'Break at the last space to preserve the word
                    lineCount = lineCount + 1
                    ReDim Preserve theArray(lineCount)

                    ' Ensure b is within valid range
                    If b < 1 Then b = 1
                    If b > text.Length Then b = text.Length

                    ' Ensure the length parameter is not negative
                    Dim substringLength As Integer = lastSpace - b
                    If substringLength < 0 Then substringLength = 0

                    ' Extract the substring and assign it to the array
                    theArray(lineCount) = Trim$(Mid$(text, b, substringLength))

                    b = lastSpace + 1
                    'Count all the words we ignored (the ones that weren't printed, but are before "i")
                    size = TextWidth(Mid$(text, lastSpace, i - lastSpace))
                End If
            End If

            ' Remainder
            If i = Len(text) Then
                If b <> i Then
                    lineCount = lineCount + 1
                    ReDim Preserve theArray(lineCount)
                    theArray(lineCount) = theArray(lineCount) & Mid$(text, b, i)
                End If
            End If
        Next
    End Sub

    Public Function WordWrap(ByVal text As String, ByVal MaxLineLen As Integer, Optional ByRef lineCount As Long = 0) As String
        Dim TempSplit() As String, TSLoop As Long, lastSpace As Long, size As Long, i As Long, b As Long, tmpNum As Long, skipCount As Long

        'Too small of text
        If Len(text) < 2 Then
            WordWrap = text
            Exit Function
        End If

        'Check if there are any line breaks - if so, we will support them
        TempSplit = Split(text, vbNewLine)
        tmpNum = UBound(TempSplit)

        For TSLoop = 0 To tmpNum
            'Clear the values for the new line
            size = 0
            b = 1
            lastSpace = 1

            'Add back in the vbNewLines
            If TSLoop < UBound(TempSplit) Then TempSplit(TSLoop) = TempSplit(TSLoop) & vbNewLine

            'Only check lines with a space
            If InStr(1, TempSplit(TSLoop), " ") Then
                'Loop through all the characters
                tmpNum = Len(TempSplit(TSLoop))

                For i = 1 To tmpNum
                    'If it is a space, store it so we can easily break at it
                    Select Case Mid$(TempSplit(TSLoop), i, 1)
                        Case " "
                            lastSpace = i
                    End Select

                    If skipCount > 0 Then
                        skipCount = skipCount - 1
                    ElseIf TSLoop > 0 Then
                        'Add up the size
                        size = size + TextWidth(TempSplit(TSLoop))

                        'Check for too large of a size
                        If size > MaxLineLen Then
                            'Check if the last space was too far back
                            If i - lastSpace > 12 Then
                                'Too far away to the last space, so break at the last character
                                WordWrap = WordWrap & Trim$(Mid$(TempSplit(TSLoop), b, (i - 1) - b)) & vbNewLine
                                lineCount = lineCount + 1
                                b = i - 1
                                size = 0
                            Else
                                'Break at the last space to preserve the word
                                WordWrap = WordWrap & Trim$(Mid$(TempSplit(TSLoop), b, lastSpace - b)) & vbNewLine
                                lineCount = lineCount + 1
                                b = lastSpace + 1

                                'Count all the words we ignored (the ones that weren't printed, but are before "i")
                                size = TextWidth(Mid$(TempSplit(TSLoop), lastSpace, i - lastSpace))
                            End If
                        End If

                        'This handles the remainder
                        If i = Len(TempSplit(TSLoop)) Then
                            If b <> i Then
                                WordWrap = WordWrap & Mid$(TempSplit(TSLoop), b, i)
                                lineCount = lineCount + 1
                            End If
                        End If
                    End If
                Next i
            Else
                WordWrap = WordWrap & TempSplit(TSLoop)
            End If
        Next TSLoop
    End Function

    Friend Function Explode(str As String, splitChars As Char()) As String()

        Dim parts As New List(Of String)()
        Dim startindex As Integer = 0
        Explode = Nothing

        If str = Nothing Then Exit Function

        While True
            Dim index As Integer = str.IndexOfAny(splitChars, startindex)

            If index = -1 Then
                parts.Add(str.Substring(startindex))
                Return parts.ToArray()
            End If

            Dim word As String = str.Substring(startindex, index - startindex)
            Dim nextChar As Char = str.Substring(index, 1)(0)
            ' Dashes and the likes should stick to the word occuring before it. Whitespace doesn't have to.
            If Char.IsWhiteSpace(nextChar) Then
                parts.Add(word)
                parts.Add(nextChar.ToString())
            Else
                parts.Add(word + nextChar)
            End If

            startindex = index + 1
        End While

    End Function

End Module