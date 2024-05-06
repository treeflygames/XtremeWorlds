Imports Core
Imports Mirage.Sharp.Asfw
Imports SFML.Graphics
Imports SFML.System

Friend Module C_EventSystem

#Region "Globals"

    ' Temp event storage
    Friend TmpEvent As Types.EventStruct

    Friend IsEdit As Boolean

    Friend CurPageNum As Integer
    Friend CurCommand As Integer
    Friend GraphicSelX As Integer
    Friend GraphicSelY As Integer
    Friend GraphicSelX2 As Integer
    Friend GraphicSelY2 As Integer

    Friend EventTileX As Integer
    Friend EventTileY As Integer

    Friend EditorEvent As Integer

    Friend GraphicSelType As Integer
    Friend TempMoveRouteCount As Integer
    Friend TempMoveRoute() As MoveRouteStruct
    Friend IsMoveRouteCommand As Boolean
    Friend ListOfEvents() As Integer

    Friend EventReplyId As Integer
    Friend EventReplyPage As Integer
    Friend EventChatFace As Integer

    Friend RenameType As Integer
    Friend RenameIndex As Integer
    Friend EventChatTimer As Integer

    Friend EventChat As Boolean
    Friend EventText As String
    Friend ShowEventLbl As Boolean
    Friend EventChoices(4) As String
    Friend EventChoiceVisible(4) As Boolean
    Friend EventChatType As Integer
    Friend AnotherChat As Integer

    'constants
    Friend Switches(MAX_SWITCHES) As String
    Friend Variables(NAX_VARIABLES) As String

    Friend EventCopy As Boolean
    Friend EventPaste As Boolean
    Friend EventList() As EventListStruct
    Friend CopyEvent As EventStruct
    Friend CopyEventPage As EventPageStruct

    Friend InEvent As Boolean
    Friend HoldPlayer As Boolean
    Friend InitEventEditorForm As Boolean

    Friend Picture As PictureStruct

#End Region

#Region "EventEditor"
    Sub CopyEvent_Map(ByVal X As Integer, ByVal Y As Integer)
        Dim count As Integer, i As Integer

        count = Map.EventCount

        If count = 0 Then Exit Sub
        For i = 0 To count
            If Map.Events(i).X = X And Map.Events(i).Y = Y Then
                ' copy it
                CopyEvent = Map.Events(i)
                Exit Sub
            End If
        Next

    End Sub

    Sub PasteEvent_Map(ByVal X As Integer, ByVal Y As Integer)
        Dim count As Integer, i As Integer, EventNum As Integer

        count = Map.EventCount

        If count > 0 Then
            For i = 0 To count
                If Map.Events(i).X = X And Map.Events(i).Y = Y Then
                    ' already an event - paste over it
                    EventNum = i
                End If
            Next
        End If

        ' couldn't find one - create one
        If EventNum = 0 Then
            ' increment count
            AddEvent(X, Y, True)
            EventNum = count + 1
        End If

        ' copy it
        Map.Events(EventNum) = CopyEvent
        ' set position
        Map.Events(EventNum).X = X
        Map.Events(EventNum).Y = Y
    End Sub

   Sub DeleteEvent(ByVal X As Integer, ByVal Y As Integer)
    Dim i As Integer
    Dim lowIndex As Integer = -1
    Dim shifted As Boolean = False

    If Editor <> EditorType.Map Then Exit Sub
    If frmEditor_Events.Visible = True Then Exit Sub

    ' First pass: find all events to delete and shift others down
    For i = 1 To Map.EventCount
        If Map.Events(i).X = X And Map.Events(i).Y = Y Then
            ' Clear the event
            ClearEvent(i)
            lowIndex = i
            shifted = True
        ElseIf shifted Then
            ' Shift this event down to fill the gap
            Map.Events(lowIndex) = Map.Events(i)
            lowIndex = lowIndex + 1
        End If
    Next

    ' Adjust the event count if anything was deleted
    If lowIndex <> -1 Then
        ' Set the new count
        Map.EventCount = lowIndex - 1
        ReDim Preserve MapEvents(Map.EventCount)
        ReDim Preserve Map.Events(Map.EventCount)
        TmpEvent = Nothing
    End If
End Sub


    Sub AddEvent(ByVal X As Integer, ByVal Y As Integer, Optional ByVal cancelLoad As Boolean = False)
        Dim count As Integer, pageCount As Integer, i As Integer

        count = Map.EventCount

        ' make sure there's not already an event
        If count > 0 Then
            For i = 0 To count
                If Map.Events(i).X = X And Map.Events(i).Y = Y Then
                    ' already an event - edit it
                    If Not cancelLoad Then EventEditorInit(i)
                    Exit Sub
                End If
            Next
        End If

        ' increment count
        If count = 0 Then
            count = 2
        else
            count = count + 1
        End If

        Map.EventCount = count
        ReDim Preserve Map.Events(count)
        ' set the new event
        Map.Events(count).X = X
        Map.Events(count).Y = Y
        ' give it a new page
        pageCount = Map.Events(count).PageCount + 1
        Map.Events(count).PageCount = pageCount
        ReDim Preserve Map.Events(count).Pages(pageCount)
        ' load the editor
        If Not cancelLoad Then EventEditorInit(count)
    End Sub

    Sub ClearEvent(ByVal EventNum As Integer)
        If EventNum > Map.EventCount Or EventNum > UBound(Map.Events) Then Exit Sub
        
        With Map.Events(EventNum)
            .Name = ""
            .PageCount = 0
            ReDim .Pages(0)
            .Globals = 0
            .X = 0
            .Y = 0
        End With
    End Sub

    Sub EventEditorInit(ByVal EventNum As Integer)
        EditorEvent = EventNum
        TmpEvent = Map.Events(EventNum)
        InitEventEditorForm = True
        If TmpEvent.Pages(1).CommandListCount = 0 Then
            ReDim Preserve TmpEvent.Pages(1).CommandList(1)
            TmpEvent.Pages(1).CommandListCount = 1
            TmpEvent.Pages(1).CommandList(1).CommandCount = 1
            ReDim Preserve TmpEvent.Pages(1).CommandList(1).Commands(TmpEvent.Pages(1).CommandList(1).CommandCount)
        End If
    End Sub

    Sub EventEditorLoadPage(ByVal PageNum As Integer)
        With TmpEvent.Pages(PageNum)
            GraphicSelX = .GraphicX
            GraphicSelY = .GraphicY
            GraphicSelX2 = .GraphicX2
            GraphicSelY2 = .GraphicY2
            frmEditor_Events.cmbGraphic.SelectedIndex = .GraphicType
            frmEditor_Events.cmbHasItem.SelectedIndex = .HasItemIndex
            If .HasItemAmount = 0 Then
                frmEditor_Events.nudCondition_HasItem.Value = 1
            Else
                frmEditor_Events.nudCondition_HasItem.Value = .HasItemAmount
            End If
            frmEditor_Events.cmbMoveFreq.SelectedIndex = .MoveFreq
            frmEditor_Events.cmbMoveSpeed.SelectedIndex = .MoveSpeed
            frmEditor_Events.cmbMoveType.SelectedIndex = .MoveType
            frmEditor_Events.cmbPlayerVar.SelectedIndex = .VariableIndex
            frmEditor_Events.cmbPlayerSwitch.SelectedIndex = .SwitchIndex
            frmEditor_Events.cmbSelfSwitchCompare.SelectedIndex = .SelfSwitchCompare
            frmEditor_Events.cmbPlayerSwitchCompare.SelectedIndex = .SwitchCompare
            frmEditor_Events.cmbPlayervarCompare.SelectedIndex = .VariableCompare
            frmEditor_Events.chkGlobal.Checked = TmpEvent.Globals
            frmEditor_Events.cmbTrigger.SelectedIndex = .Trigger
            frmEditor_Events.chkDirFix.Checked = .DirFix
            frmEditor_Events.chkHasItem.Checked = .ChkHasItem
            frmEditor_Events.chkPlayerVar.Checked = .ChkVariable
            frmEditor_Events.chkPlayerSwitch.Checked = .ChkSwitch
            frmEditor_Events.chkSelfSwitch.Checked = .ChkSelfSwitch
            frmEditor_Events.chkWalkAnim.Checked = .WalkAnim
            frmEditor_Events.chkWalkThrough.Checked = .WalkThrough
            frmEditor_Events.chkShowName.Checked = .ShowName
            frmEditor_Events.nudPlayerVariable.Value = .VariableCondition
            frmEditor_Events.nudGraphic.Value = .Graphic

            If .ChkSelfSwitch = 0 Then
                frmEditor_Events.cmbSelfSwitch.Enabled = False
                frmEditor_Events.cmbSelfSwitchCompare.Enabled = False
            Else
                frmEditor_Events.cmbSelfSwitch.Enabled = True
                frmEditor_Events.cmbSelfSwitchCompare.Enabled = True
            End If
            If .ChkSwitch = 0 Then
                frmEditor_Events.cmbPlayerSwitch.Enabled = False
                frmEditor_Events.cmbPlayerSwitchCompare.Enabled = False
            Else
                frmEditor_Events.cmbPlayerSwitch.Enabled = True
                frmEditor_Events.cmbPlayerSwitchCompare.Enabled = True
            End If
            If .ChkVariable = 0 Then
                frmEditor_Events.cmbPlayerVar.Enabled = False
                frmEditor_Events.nudPlayerVariable.Enabled = False
                frmEditor_Events.cmbPlayervarCompare.Enabled = False
            Else
                frmEditor_Events.cmbPlayerVar.Enabled = True
                frmEditor_Events.nudPlayerVariable.Enabled = True
                frmEditor_Events.cmbPlayervarCompare.Enabled = True
            End If
            If frmEditor_Events.cmbMoveType.SelectedIndex = 2 Then
                frmEditor_Events.btnMoveRoute.Enabled = True
            Else
                frmEditor_Events.btnMoveRoute.Enabled = False
            End If
            frmEditor_Events.cmbPositioning.SelectedIndex = Integer.Parse(.Position)   
            EventListCommands()
            EditorEvent_DrawGraphic()
        End With

    End Sub

    Sub EventEditorOK()
        ' copy the event data from the temp event
        Map.Events(EditorEvent) = TmpEvent
        TmpEvent = Nothing

        ' unload the form
        frmEditor_Events.Dispose()
    End Sub

    Public Sub EventListCommands()
        Dim i As Integer, curlist As Integer, X As Integer, indent As String = "", listleftoff() As Integer, conditionalstage() As Integer

        frmEditor_Events.lstCommands.Items.Clear()

        If TmpEvent.Pages(CurPageNum).CommandListCount > 0 Then
            ReDim listleftoff(TmpEvent.Pages(CurPageNum).CommandListCount)
            ReDim conditionalstage(TmpEvent.Pages(CurPageNum).CommandListCount)
            curlist = 1
            X = 0
            ReDim Preserve EventList(X)
newlist:
            For i = 1 To TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount
                If listleftoff(curlist) > 0 Then
                    If (TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(listleftoff(curlist)).Index = EventType.Condition Or TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(listleftoff(curlist)).Index = EventType.ShowChoices) And conditionalstage(curlist) <> 0 Then
                        i = listleftoff(curlist)
                    ElseIf listleftoff(curlist) >= i Then
                        i = listleftoff(curlist) + 1
                    End If
                End If
                If i < TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount Then
                    If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Index = EventType.Condition Then
                        X = X + 1
                        ReDim Preserve EventList(X)
                        Select Case conditionalstage(curlist)
                            Case 0
                                EventList(X).CommandList = curlist
                                EventList(X).CommandNum = i
                                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Condition
                                    Case 0
                                        Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2
                                            Case 0
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player Variable [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Variables(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] == " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3)
                                            Case 1
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player Variable [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Variables(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] >= " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3)
                                            Case 2
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player Variable [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Variables(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] <= " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3)
                                            Case 3
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player Variable [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Variables(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] > " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3)
                                            Case 4
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player Variable [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Variables(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] < " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3)
                                            Case 5
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player Variable [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Variables(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] != " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3)
                                        End Select
                                    Case 1
                                        If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2 = 0 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player Switch [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Switches(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] == " & "True")
                                        ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2 = 1 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player Switch [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & ". " & Switches(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1) & "] == " & "False")
                                        End If
                                    Case 2
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player Has Item [" & Trim$(Item(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1).Name) & "] x" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2)
                                    Case 3
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player's Job Is [" & Trim$(Job(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1).Name) & "]")
                                    Case 4
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player Knows Skill [" & Trim$(Skill(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1).Name) & "]")
                                    Case 5
                                        Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2
                                            Case 0
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player's Level is == " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1)
                                            Case 1
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player's Level is >= " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1)
                                            Case 2
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player's Level is <= " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1)
                                            Case 3
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player's Level is > " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1)
                                            Case 4
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player's Level is < " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1)
                                            Case 5
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player's Level is NOT " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1)
                                        End Select
                                    Case 6
                                        If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2 = 0 Then
                                            Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1
                                                Case 0
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Self Switch [A] == " & "True")
                                                Case 1
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Self Switch [B] == " & "True")
                                                Case 2
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Self Switch [C] == " & "True")
                                                Case 3
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Self Switch [D] == " & "True")
                                            End Select
                                        ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2 = 1 Then
                                            Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1
                                                Case 0
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Self Switch [A] == " & "False")
                                                Case 1
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Self Switch [B] == " & "False")
                                                Case 2
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Self Switch [C] == " & "False")
                                                Case 3
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Self Switch [D] == " & "False")
                                            End Select
                                        End If
                                    Case 7
                                        If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2 = 0 Then
                                            Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3
                                                Case 0
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Quest [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & "] not started.")
                                                Case 1
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Quest [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & "] is started.")
                                                Case 2
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Quest [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & "] is completed.")
                                                Case 3
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Quest [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & "] can be started.")
                                                Case 4
                                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Quest [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & "] can be ended. (All tasks complete)")
                                            End Select
                                        ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data2 = 1 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Quest [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1 & "] in progress and on task #" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data3)
                                        End If
                                    Case 8
                                        Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1
                                            Case SexType.Male
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player's Gender is Male")
                                            Case SexType.Female
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Player's  Gender is Female")
                                        End Select
                                    Case 9
                                        Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.Data1
                                            Case TimeOfDay.Day
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Time of Day is Day")
                                            Case TimeOfDay.Night
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Time of Day is Night")
                                            Case TimeOfDay.Dawn
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Time of Day is Dawn")
                                            Case TimeOfDay.Dusk
                                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Conditional Branch: Time of Day is Dusk")
                                        End Select
                                End Select
                                indent = indent & "       "
                                listleftoff(curlist) = i
                                conditionalstage(curlist) = 1
                                curlist = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.CommandList
                                GoTo newlist
                            Case 1
                                EventList(X).CommandList = curlist
                                EventList(X).CommandNum = 0
                                frmEditor_Events.lstCommands.Items.Add(Mid(indent, 1, Len(indent) - 4) & " : " & "Else")
                                listleftoff(curlist) = i
                                conditionalstage(curlist) = 2
                                curlist = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).ConditionalBranch.ElseCommandList
                                GoTo newlist
                            Case 2
                                EventList(X).CommandList = curlist
                                EventList(X).CommandNum = 0
                                frmEditor_Events.lstCommands.Items.Add(Mid(indent, 1, Len(indent) - 4) & " : " & "End Branch")
                                indent = Mid(indent, 1, Len(indent) - 7)
                                listleftoff(curlist) = i
                                conditionalstage(curlist) = 0
                        End Select
                    ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Index = EventType.ShowChoices Then
                        X = X + 1
                        Select Case conditionalstage(curlist)
                            Case 0
                                ReDim Preserve EventList(X)
                                EventList(X).CommandList = curlist
                                EventList(X).CommandNum = i
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Show Choices - Prompt: " & Mid(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1, 1, 20))
                                indent = indent & "       "
                                listleftoff(curlist) = i
                                conditionalstage(curlist) = 1
                                GoTo newlist
                            Case 1
                                If Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text2) <> "" Then
                                    ReDim Preserve EventList(X)
                                    EventList(X).CommandList = curlist
                                    EventList(X).CommandNum = 0
                                    frmEditor_Events.lstCommands.Items.Add(Mid(indent, 1, Len(indent) - 4) & " : " & "When [" & Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text2) & "]")
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 2
                                    curlist = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1
                                    GoTo newlist
                                Else
                                    X = X - 1
                                    ReDim Preserve EventList(X)
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 2
                                    curlist = curlist
                                    GoTo newlist
                                End If
                            Case 2
                                If Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text3) <> "" Then
                                    ReDim Preserve EventList(X)
                                    EventList(X).CommandList = curlist
                                    EventList(X).CommandNum = 0
                                    frmEditor_Events.lstCommands.Items.Add(Mid(indent, 1, Len(indent) - 4) & " : " & "When [" & Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text3) & "]")
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 3
                                    curlist = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2
                                    GoTo newlist
                                Else
                                    X = X - 1
                                    ReDim Preserve EventList(X)
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 3
                                    curlist = curlist
                                    GoTo newlist
                                End If
                            Case 3
                                If Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text4) <> "" Then
                                    ReDim Preserve EventList(X)
                                    EventList(X).CommandList = curlist
                                    EventList(X).CommandNum = 0
                                    frmEditor_Events.lstCommands.Items.Add(Mid(indent, 1, Len(indent) - 4) & " : " & "When [" & Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text4) & "]")
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 4
                                    curlist = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3
                                    GoTo newlist
                                Else
                                    X = X - 1
                                    ReDim Preserve EventList(X)
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 4
                                    curlist = curlist
                                    GoTo newlist
                                End If
                            Case 4
                                If Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text5) <> "" Then
                                    ReDim Preserve EventList(X)
                                    EventList(X).CommandList = curlist
                                    EventList(X).CommandNum = 0
                                    frmEditor_Events.lstCommands.Items.Add(Mid(indent, 1, Len(indent) - 4) & " : " & "When [" & Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text5) & "]")
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 5
                                    curlist = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data4
                                    GoTo newlist
                                Else
                                    X = X - 1
                                    ReDim Preserve EventList(X)
                                    listleftoff(curlist) = i
                                    conditionalstage(curlist) = 5
                                    curlist = curlist
                                    GoTo newlist
                                End If
                            Case 5
                                ReDim Preserve EventList(X)
                                EventList(X).CommandList = curlist
                                EventList(X).CommandNum = 0
                                frmEditor_Events.lstCommands.Items.Add(Mid(indent, 1, Len(indent) - 4) & " : " & "Branch End")
                                indent = Mid(indent, 1, Len(indent) - 7)
                                listleftoff(curlist) = i
                                conditionalstage(curlist) = 0
                        End Select
                    Else
                        X = X + 1
                        ReDim Preserve EventList(X)
                        EventList(X).CommandList = curlist
                        EventList(X).CommandNum = i
                        Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Index
                            Case EventType.AddText
                                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2
                                    Case 0
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Add Text - " & Mid(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - Color: " & GetColorString(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & " - Chat Type: Player")
                                    Case 1
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Add Text - " & Mid(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - Color: " & GetColorString(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & " - Chat Type: Map")
                                    Case 2
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Add Text - " & Mid(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - Color: " & GetColorString(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & " - Chat Type: Global")
                                End Select
                            Case EventType.ShowText
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Show Text - " & Mid(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1, 1, 20))
                            Case EventType.PlayerVar
                                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2
                                    Case 0
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Variable [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & Variables(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & "] == " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3)
                                    Case 1
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Variable [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & Variables(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & "] + " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3)
                                    Case 2
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Variable [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & Variables(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & "] - " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3)
                                    Case 3
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Variable [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & Variables(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & "] Random Between " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3 & " and " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data4)
                                End Select
                            Case EventType.PlayerSwitch
                                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Switch [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & ". " & Switches(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & "] == True")
                                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Switch [" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & ". " & Switches(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & "] == False")
                                End If
                            Case EventType.SelfSwitch
                                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1
                                    Case 0
                                        If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Self Switch [A] to ON")
                                        ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Self Switch [A] to OFF")
                                        End If
                                    Case 1
                                        If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Self Switch [B] to ON")
                                        ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Self Switch [B] to OFF")
                                        End If
                                    Case 2
                                        If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Self Switch [C] to ON")
                                        ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Self Switch [C] to OFF")
                                        End If
                                    Case 3
                                        If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Self Switch [D] to ON")
                                        ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Self Switch [D] to OFF")
                                        End If
                                End Select
                            Case EventType.ExitProcess
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Exit Event Processing")
                            Case EventType.ChangeItems
                                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Item Amount of [" & Trim$(Item(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "] to " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3)
                                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Give Player " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3 & " " & Trim$(Item(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "(s)")
                                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 2 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Take " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3 & " " & Trim$(Item(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "(s) from Player.")
                                End If
                            Case EventType.RestoreHP
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Restore Player HP")
                            Case EventType.RestoreSP
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Restore Player MP")
                            Case EventType.LevelUp
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Level Up Player")
                            Case EventType.ChangeLevel
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Level to " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1)
                            Case EventType.ChangeSkills
                                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Teach Player Skill [" & Trim$(Skill(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "]")
                                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Remove Player Skill [" & Trim$(Skill(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "]")
                                End If
                            Case EventType.ChangeJob
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Job to " & Trim$(Job(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name))
                            Case EventType.ChangeSprite
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Sprite to " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1)
                            Case EventType.ChangeSex
                                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 = 0 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Sex to Male.")
                                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 = 1 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Sex to Female.")
                                End If
                            Case EventType.ChangePk
                                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 = 0 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player PK to No.")
                                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 = 1 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player PK to Yes.")
                                End If
                            Case EventType.WarpPlayer
                                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data4 = 0 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Warp Player To Map: " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " Tile(" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 & "," & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3 & ") while retaining direction.")
                                Else
                                    Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data4 - 1
                                        Case DirectionType.Up
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Warp Player To Map: " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " Tile(" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 & "," & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3 & ") facing upward.")
                                        Case DirectionType.Down
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Warp Player To Map: " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " Tile(" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 & "," & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3 & ") facing downward.")
                                        Case DirectionType.Left
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Warp Player To Map: " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " Tile(" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 & "," & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3 & ") facing left.")
                                        Case DirectionType.Right
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Warp Player To Map: " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " Tile(" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 & "," & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3 & ") facing right.")
                                    End Select
                                End If
                            Case EventType.SetMoveRoute
                                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 <= Map.EventCount Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Move Route for Event #" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " [" & Trim$(Map.Events(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "]")
                                Else
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Move Route for COULD NOT FIND EVENT!")
                                End If
                            Case EventType.PlayAnimation
                                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 0 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Play Animation " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " [" & Trim$(Animation(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "]" & " on Player")
                                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 1 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Play Animation " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " [" & Trim$(Animation(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "]" & " on Event #" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3 & " [" & Trim$(Map.Events(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3).Name) & "]")
                                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2 = 2 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Play Animation " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " [" & Trim$(Animation(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "]" & " on Tile(" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3 & "," & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data4 & ")")
                                End If
                            Case EventType.CustomScript
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Execute Custom Script Case: " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1)
                            Case EventType.PlayBgm
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Play BGM [" & Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1) & "]")
                            Case EventType.FadeoutBgm
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Fadeout BGM")
                            Case EventType.PlaySound
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Play Sound [" & Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1) & "]")
                            Case EventType.StopSound
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Stop Sound")
                            Case EventType.OpenBank
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Open Bank")
                            Case EventType.OpenShop
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Open Shop [" & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & ". " & Trim$(Shop(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "]")
                            Case EventType.SetAccess
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Player Access [" & frmEditor_Events.cmbSetAccess.Items(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & "]")
                            Case EventType.GiveExp
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Give Player " & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " Experience.")
                            Case EventType.ShowChatBubble
                                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1
                                    Case TargetType.Player
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Show Chat Bubble - " & Mid(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - On Player")
                                    Case TargetType.Npc
                                        If Map.Npc(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) <= 0 Then
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Show Chat Bubble - " & Mid(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - On NPC [" & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & ". ]")
                                        Else
                                            frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Show Chat Bubble - " & Mid(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - On NPC [" & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & ". " & Trim$(NPC(Map.Npc(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2)).Name) & "]")
                                        End If
                                    Case TargetType.Event
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Show Chat Bubble - " & Mid(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1, 1, 20) & "... - On Event [" & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & ". " & Trim$(Map.Events(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2).Name) & "]")
                                End Select
                            Case EventType.Label
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Label: [" & Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1) & "]")
                            Case EventType.GotoLabel
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Jump to Label: [" & Trim$(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Text1) & "]")
                            Case EventType.SpawnNpc
                                If Map.Npc(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) <= 0 Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Spawn NPC: [" & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & ". " & "]")
                                Else
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Spawn NPC: [" & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & ". " & Trim$(NPC(Map.Npc(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1)).Name) & "]")
                                End If
                            Case EventType.FadeIn
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Fade In")
                            Case EventType.FadeOut
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Fade Out")
                            Case EventType.FlashWhite
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Flash White")
                            Case EventType.SetFog
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Fog [Fog: " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & " Speed: " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & " Opacity: " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3) & "]")
                            Case EventType.SetWeather
                                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1
                                    Case Weather.None
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Weather [None]")
                                    Case Weather.Rain
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Weather [Rain - Intensity: " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & "]")
                                    Case Weather.Snow
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Weather [Snow - Intensity: " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & "]")
                                    Case Weather.Sandstorm
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Weather [Sand Storm - Intensity: " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & "]")
                                    Case Weather.Storm
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Weather [Storm - Intensity: " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & "]")
                                End Select
                            Case EventType.SetTint
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Set Map Tint RGBA [" & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & "," & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & "," & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data3) & "," & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data4) & "]")
                            Case EventType.Wait
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Wait " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & " Ms")
                            Case EventType.ShowPicture
                                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2
                                    Case 0
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Show Picture " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & ": Pic=" & Str(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & " Top Left, X: " & Str(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data4) & " Y: " & Str(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data5))
                                    Case 1
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Show Picture " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & ": Pic=" & Str(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & " Center Screen, X: " & Str(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data4) & " Y: " & Str(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data5))
                                    Case 2
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Show Picture " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & ": Pic=" & Str(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & " On Event, X: " & Str(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data4) & " Y: " & Str(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data5))
                                    Case 3
                                        frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Show Picture " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1) & ": Pic=" & Str(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data2) & " On Player, X: " & Str(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data4) & " Y: " & Str(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data5))
                                End Select
                            Case EventType.HidePicture
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Hide Picture " & CStr(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1))
                            Case EventType.WaitMovement
                                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 <= Map.EventCount Then
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Wait for Event #" & TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1 & " [" & Trim$(Map.Events(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i).Data1).Name) & "] to complete move route.")
                                Else
                                    frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Wait for COULD NOT FIND EVENT to complete move route.")
                                End If
                            Case EventType.HoldPlayer
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Hold Player [Do not allow player to move.]")
                            Case EventType.ReleasePlayer
                                frmEditor_Events.lstCommands.Items.Add(indent & "@>" & "Release Player [Allow player to turn and move again.]")
                            Case Else
                                'Ghost
                                X = X - 1
                                If X = -1 Then
                                    ReDim EventList(0)
                                Else
                                    ReDim Preserve EventList(X)
                                End If
                        End Select
                    End If
                End If
            Next

            If curlist > 1 Then
                X = X + 1
                ReDim Preserve EventList(X)
                EventList(X).CommandList = curlist
                EventList(X).CommandNum = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount + 1
                frmEditor_Events.lstCommands.Items.Add(indent & "@> ")
                curlist = TmpEvent.Pages(CurPageNum).CommandList(curlist).ParentList
                GoTo newlist
            End If
        End If
        frmEditor_Events.lstCommands.Items.Add(indent & "@> ")

        Dim z As Integer
        X = 0
        For i = 0 To frmEditor_Events.lstCommands.Items.Count
            If X > z Then z = X
        Next

    End Sub

    Sub AddCommand(ByVal Index As Integer)
        Dim curlist As Integer, i As Integer, X As Integer, curslot As Integer, p As Integer
        Dim oldCommandList As CommandListStruct

        If frmEditor_Events.lstCommands.SelectedIndex + 1 = frmEditor_Events.lstCommands.Items.Count Then
            curlist = 1
        Else
            curlist = EventList(frmEditor_Events.lstCommands.SelectedIndex + 1).CommandList
        End If
      
        TmpEvent.Pages(CurPageNum).CommandListCount = TmpEvent.Pages(CurPageNum).CommandListCount + 1
        ReDim Preserve TmpEvent.Pages(CurPageNum).CommandList(TmpEvent.Pages(CurPageNum).CommandListCount)
        TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount + 1
        p = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount
        ReDim Preserve TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(p)

        If frmEditor_Events.lstCommands.SelectedIndex + 1 = frmEditor_Events.lstCommands.Items.Count Then
            curslot = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount - 1
        Else
            oldCommandList = TmpEvent.Pages(CurPageNum).CommandList(curlist)
            TmpEvent.Pages(CurPageNum).CommandList(curlist).ParentList = oldCommandList.ParentList

            For i = 1 To p - 1
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(i) = oldCommandList.Commands(i)
            Next

            i = EventList(frmEditor_Events.lstCommands.SelectedIndex + 1).CommandNum
            If i <= TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount Then

                For X = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount To i
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(X + 1) = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(X)
                Next

                curslot = EventList(frmEditor_Events.lstCommands.SelectedIndex + 1).CommandNum
            Else
                curslot = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount
            End If

        End If

        Select Case Index
            Case EventType.AddText
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtAddText_Text.Text
                If frmEditor_Events.optAddText_Player.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf frmEditor_Events.optAddText_Map.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                ElseIf frmEditor_Events.optAddText_Global.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 2
                End If
            Case EventType.Condition
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandListCount = TmpEvent.Pages(CurPageNum).CommandListCount + 2
                ReDim Preserve TmpEvent.Pages(CurPageNum).CommandList(TmpEvent.Pages(CurPageNum).CommandListCount)
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.CommandList = TmpEvent.Pages(CurPageNum).CommandListCount - 1
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.ElseCommandList = TmpEvent.Pages(CurPageNum).CommandListCount
                TmpEvent.Pages(CurPageNum).CommandList(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.CommandList).ParentList = curlist
                TmpEvent.Pages(CurPageNum).CommandList(TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.ElseCommandList).ParentList = curlist

                If frmEditor_Events.optCondition0.Checked = True Then X = 0
                If frmEditor_Events.optCondition1.Checked = True Then X = 1
                If frmEditor_Events.optCondition2.Checked = True Then X = 2
                If frmEditor_Events.optCondition3.Checked = True Then X = 3
                If frmEditor_Events.optCondition4.Checked = True Then X = 4
                If frmEditor_Events.optCondition5.Checked = True Then X = 5
                If frmEditor_Events.optCondition6.Checked = True Then X = 6
                If frmEditor_Events.optCondition8.Checked = True Then X = 8
                If frmEditor_Events.optCondition9.Checked = True Then X = 9

                Select Case X
                    Case 0 'Player Var
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 0
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_PlayerVarIndex.SelectedIndex
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = frmEditor_Events.cmbCondition_PlayerVarCompare.SelectedIndex
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3 = frmEditor_Events.nudCondition_PlayerVarCondition.Value
                    Case 1 'Player Switch
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 1
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_PlayerSwitch.SelectedIndex
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = frmEditor_Events.cmbCondtion_PlayerSwitchCondition.SelectedIndex
                    Case 2 'Has Item
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 2
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_HasItem.SelectedIndex
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = frmEditor_Events.nudCondition_HasItem.Value
                    Case 3 'Job Is
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 3
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_JobIs.SelectedIndex
                    Case 4 'Learnt Skill
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 4
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_LearntSkill.SelectedIndex
                    Case 5 'Level Is
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 5
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.nudCondition_LevelAmount.Value
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = frmEditor_Events.cmbCondition_LevelCompare.SelectedIndex
                    Case 6 'Self Switch
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 6
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_SelfSwitch.SelectedIndex
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = frmEditor_Events.cmbCondition_SelfSwitchCondition.SelectedIndex
                    Case 7

                    Case 8 'Gender
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 8
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_Gender.SelectedIndex
                    Case 9 'Time
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 9
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_Time.SelectedIndex
                End Select

            Case EventType.ShowText
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                Dim tmptxt As String = ""
                For i = 0 To UBound(frmEditor_Events.txtShowText.Lines)
                    tmptxt = tmptxt & frmEditor_Events.txtShowText.Lines(i)
                Next
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = tmptxt

            Case EventType.ShowChoices
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtChoicePrompt.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text2 = frmEditor_Events.txtChoices1.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text3 = frmEditor_Events.txtChoices2.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text4 = frmEditor_Events.txtChoices3.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text5 = frmEditor_Events.txtChoices4.Text
                TmpEvent.Pages(CurPageNum).CommandListCount = TmpEvent.Pages(CurPageNum).CommandListCount + 4
                ReDim Preserve TmpEvent.Pages(CurPageNum).CommandList(TmpEvent.Pages(CurPageNum).CommandListCount)
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = TmpEvent.Pages(CurPageNum).CommandListCount - 3
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = TmpEvent.Pages(CurPageNum).CommandListCount - 2
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = TmpEvent.Pages(CurPageNum).CommandListCount - 1
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = TmpEvent.Pages(CurPageNum).CommandListCount
                TmpEvent.Pages(CurPageNum).CommandList(TmpEvent.Pages(CurPageNum).CommandListCount - 3).ParentList = curlist
                TmpEvent.Pages(CurPageNum).CommandList(TmpEvent.Pages(CurPageNum).CommandListCount - 2).ParentList = curlist
                TmpEvent.Pages(CurPageNum).CommandList(TmpEvent.Pages(CurPageNum).CommandListCount - 1).ParentList = curlist
                TmpEvent.Pages(CurPageNum).CommandList(TmpEvent.Pages(CurPageNum).CommandListCount).ParentList = curlist

            Case EventType.PlayerVar
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbVariable.SelectedIndex

                If frmEditor_Events.optVariableAction0.Checked = True Then i = 0
                If frmEditor_Events.optVariableAction1.Checked = True Then i = 1
                If frmEditor_Events.optVariableAction2.Checked = True Then i = 2
                If frmEditor_Events.optVariableAction3.Checked = True Then i = 3

                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = i
                If i = 3 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.nudVariableData3.Value
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = frmEditor_Events.nudVariableData4.Value
                ElseIf i = 0 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.nudVariableData0.Value
                ElseIf i = 1 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.nudVariableData1.Value
                ElseIf i = 2 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.nudVariableData2.Value
                End If

            Case EventType.PlayerSwitch
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbSwitch.SelectedIndex
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.cmbPlayerSwitchSet.SelectedIndex

            Case EventType.SelfSwitch
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbSetSelfSwitch.SelectedIndex
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.cmbSetSelfSwitchTo.SelectedIndex

            Case EventType.ExitProcess
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.ChangeItems
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbChangeItemIndex.SelectedIndex
                If frmEditor_Events.optChangeItemSet.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf frmEditor_Events.optChangeItemAdd.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                ElseIf frmEditor_Events.optChangeItemRemove.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 2
                End If
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.nudChangeItemsAmount.Value

            Case EventType.RestoreHP
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.RestoreSP
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.LevelUp
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.ChangeLevel
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.nudChangeLevel.Value

            Case EventType.ChangeSkills
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbChangeSkills.SelectedIndex
                If frmEditor_Events.optChangeSkillsAdd.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf frmEditor_Events.optChangeSkillsRemove.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                End If

            Case EventType.ChangeJob
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbChangeJob.SelectedIndex

            Case EventType.ChangeSprite
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.nudChangeSprite.Value

            Case EventType.ChangeSex
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                If frmEditor_Events.optChangeSexMale.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = SexType.Male
                ElseIf frmEditor_Events.optChangeSexFemale.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = SexType.Female
                End If

            Case EventType.ChangePk
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbSetPK.SelectedIndex

            Case EventType.WarpPlayer
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.nudWPMap.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.nudWPX.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.nudWPY.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = frmEditor_Events.cmbWarpPlayerDir.SelectedIndex

            Case EventType.SetMoveRoute
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = ListOfEvents(frmEditor_Events.cmbEvent.SelectedIndex)
                If frmEditor_Events.chkIgnoreMove.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                Else
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                End If

                If frmEditor_Events.chkRepeatRoute.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = 1
                Else
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = 0
                End If

                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).MoveRouteCount = TempMoveRouteCount
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).MoveRoute = TempMoveRoute

            Case EventType.PlayAnimation
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbPlayAnim.SelectedIndex
                If frmEditor_Events.cmbAnimTargetType.SelectedIndex = 0 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf frmEditor_Events.cmbAnimTargetType.SelectedIndex = 1 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.cmbPlayAnimEvent.SelectedIndex
                ElseIf frmEditor_Events.cmbAnimTargetType.SelectedIndex = 2 = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 2
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.nudPlayAnimTileX.Value
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = frmEditor_Events.nudPlayAnimTileY.Value
                End If

            Case EventType.CustomScript
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.nudCustomScript.Value

            Case EventType.PlayBgm
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = MusicCache(frmEditor_Events.cmbPlayBGM.SelectedIndex)

            Case EventType.FadeoutBgm
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.PlaySound
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = SoundCache(frmEditor_Events.cmbPlaySound.SelectedIndex)

            Case EventType.StopSound
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.OpenBank
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.OpenShop
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbOpenShop.SelectedIndex

            Case EventType.SetAccess
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbSetAccess.SelectedIndex + 1

            Case EventType.GiveExp
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.nudGiveExp.Value

            Case EventType.ShowChatBubble
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtChatbubbleText.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbChatBubbleTargetType.SelectedIndex + 1
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.cmbChatBubbleTarget.SelectedIndex

            Case EventType.Label
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtLabelName.Text

            Case EventType.GotoLabel
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtGotoLabel.Text

            Case EventType.SpawnNpc
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbSpawnNpc.SelectedIndex

            Case EventType.FadeIn
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.FadeOut
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.FlashWhite
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.SetFog
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.nudFogData0.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.nudFogData1.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.nudFogData2.Value

            Case EventType.SetWeather
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.CmbWeather.SelectedIndex
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.nudWeatherIntensity.Value

            Case EventType.SetTint
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.nudMapTintData0.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.nudMapTintData1.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.nudMapTintData2.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = frmEditor_Events.nudMapTintData3.Value

            Case EventType.Wait
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.nudWaitAmount.Value

            Case EventType.ShowPicture
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.nudShowPicture.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.cmbPicLoc.SelectedIndex
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.nudPicOffsetX.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = frmEditor_Events.nudPicOffsetY.Value

            Case EventType.HidePicture
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.WaitMovement
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = ListOfEvents(frmEditor_Events.cmbMoveWait.SelectedIndex)

            Case EventType.HoldPlayer
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index

            Case EventType.ReleasePlayer
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index = Index
        End Select

        EventListCommands()

    End Sub

    Public Sub EditEventCommand()
        Dim i As Integer, X As Integer, curlist As Integer, curslot As Integer

        i = frmEditor_Events.lstCommands.SelectedIndex + 1
        If i = -1 Then Exit Sub
        If i > UBound(EventList) Then Exit Sub

        frmEditor_Events.fraConditionalBranch.Visible = False
        frmEditor_Events.fraDialogue.BringToFront()

        curlist = EventList(i).CommandList
        curslot = EventList(i).CommandNum
        If curlist = 0 Then Exit Sub
        If curslot = 0 Then Exit Sub
        If curlist > TmpEvent.Pages(CurPageNum).CommandListCount Then Exit Sub
        If curslot > TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount Then Exit Sub

        Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index
            Case EventType.AddText
                IsEdit = True
                frmEditor_Events.txtAddText_Text.Text = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1
                'frmEditor_Events.scrlAddText_Color.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2
                    Case 0
                        frmEditor_Events.optAddText_Player.Checked = True
                    Case 1
                        frmEditor_Events.optAddText_Map.Checked = True
                    Case 2
                        frmEditor_Events.optAddText_Global.Checked = True
                End Select
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraAddText.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.Condition
                IsEdit = True
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraConditionalBranch.Visible = True
                frmEditor_Events.fraCommands.Visible = False
                frmEditor_Events.ClearConditionFrame()

                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition
                    Case 0
                        frmEditor_Events.optCondition0.Checked = True
                    Case 1
                        frmEditor_Events.optCondition1.Checked = True
                    Case 2
                        frmEditor_Events.optCondition2.Checked = True
                    Case 3
                        frmEditor_Events.optCondition3.Checked = True
                    Case 4
                        frmEditor_Events.optCondition4.Checked = True
                    Case 5
                        frmEditor_Events.optCondition5.Checked = True
                    Case 6
                        frmEditor_Events.optCondition6.Checked = True
                    Case 7

                    Case 8
                        frmEditor_Events.optCondition8.Checked = True
                    Case 9
                        frmEditor_Events.optCondition9.Checked = True
                End Select

                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition
                    Case 0
                        frmEditor_Events.cmbCondition_PlayerVarIndex.Enabled = True
                        frmEditor_Events.cmbCondition_PlayerVarCompare.Enabled = True
                        frmEditor_Events.nudCondition_PlayerVarCondition.Enabled = True
                        frmEditor_Events.cmbCondition_PlayerVarIndex.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 - 1
                        frmEditor_Events.cmbCondition_PlayerVarCompare.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2
                        frmEditor_Events.nudCondition_PlayerVarCondition.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3
                    Case 1
                        frmEditor_Events.cmbCondition_PlayerSwitch.Enabled = True
                        frmEditor_Events.cmbCondtion_PlayerSwitchCondition.Enabled = True
                        frmEditor_Events.cmbCondition_PlayerSwitch.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 - 1
                        frmEditor_Events.cmbCondtion_PlayerSwitchCondition.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2
                    Case 2
                        frmEditor_Events.cmbCondition_HasItem.Enabled = True
                        frmEditor_Events.nudCondition_HasItem.Enabled = True
                        frmEditor_Events.cmbCondition_HasItem.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 - 1
                        frmEditor_Events.nudCondition_HasItem.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2
                    Case 3
                        frmEditor_Events.cmbCondition_JobIs.Enabled = True
                        frmEditor_Events.cmbCondition_JobIs.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 - 1
                    Case 4
                        frmEditor_Events.cmbCondition_LearntSkill.Enabled = True
                        frmEditor_Events.cmbCondition_LearntSkill.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 - 1
                    Case 5
                        frmEditor_Events.cmbCondition_LevelCompare.Enabled = True
                        frmEditor_Events.nudCondition_LevelAmount.Enabled = True
                        frmEditor_Events.nudCondition_LevelAmount.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1
                        frmEditor_Events.cmbCondition_LevelCompare.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2
                    Case 6
                        frmEditor_Events.cmbCondition_SelfSwitch.Enabled = True
                        frmEditor_Events.cmbCondition_SelfSwitchCondition.Enabled = True
                        frmEditor_Events.cmbCondition_SelfSwitch.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1
                        frmEditor_Events.cmbCondition_SelfSwitchCondition.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2
                    Case 7

                    Case 8
                        frmEditor_Events.cmbCondition_Gender.Enabled = True
                        frmEditor_Events.cmbCondition_Gender.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1
                    Case 9
                        frmEditor_Events.cmbCondition_Time.Enabled = True
                        frmEditor_Events.cmbCondition_Time.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1
                End Select
            Case EventType.ShowText
                IsEdit = True
                frmEditor_Events.txtShowText.Text = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraShowText.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.ShowChoices
                IsEdit = True
                frmEditor_Events.txtChoicePrompt.Text = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1
                frmEditor_Events.txtChoices1.Text = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text2
                frmEditor_Events.txtChoices2.Text = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text3
                frmEditor_Events.txtChoices3.Text = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text4
                frmEditor_Events.txtChoices4.Text = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text5
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraShowChoices.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.PlayerVar
                IsEdit = True
                frmEditor_Events.cmbVariable.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2
                    Case 0
                        frmEditor_Events.optVariableAction0.Checked = True
                        frmEditor_Events.nudVariableData0.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3
                    Case 1
                        frmEditor_Events.optVariableAction1.Checked = True
                        frmEditor_Events.nudVariableData1.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3
                    Case 2
                        frmEditor_Events.optVariableAction2.Checked = True
                        frmEditor_Events.nudVariableData2.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3
                    Case 3
                        frmEditor_Events.optVariableAction3.Checked = True
                        frmEditor_Events.nudVariableData3.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3
                        frmEditor_Events.nudVariableData4.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4
                End Select
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraPlayerVariable.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.PlayerSwitch
                IsEdit = True
                frmEditor_Events.cmbSwitch.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                frmEditor_Events.cmbPlayerSwitchSet.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraPlayerSwitch.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.SelfSwitch
                IsEdit = True
                frmEditor_Events.cmbSetSelfSwitch.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.cmbSetSelfSwitchTo.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraSetSelfSwitch.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.ChangeItems
                IsEdit = True
                frmEditor_Events.cmbChangeItemIndex.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0 Then
                    frmEditor_Events.optChangeItemSet.Checked = True
                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1 Then
                    frmEditor_Events.optChangeItemAdd.Checked = True
                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 2 Then
                    frmEditor_Events.optChangeItemRemove.Checked = True
                End If
                frmEditor_Events.nudChangeItemsAmount.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraChangeItems.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.ChangeLevel
                IsEdit = True
                frmEditor_Events.nudChangeLevel.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraChangeLevel.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.ChangeSkills
                IsEdit = True
                frmEditor_Events.cmbChangeSkills.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0 Then
                    frmEditor_Events.optChangeSkillsAdd.Checked = True
                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1 Then
                    frmEditor_Events.optChangeSkillsRemove.Checked = True
                End If
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraChangeSkills.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.ChangeJob
                IsEdit = True
                frmEditor_Events.cmbChangeJob.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraChangeJob.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.ChangeSprite
                IsEdit = True
                frmEditor_Events.nudChangeSprite.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraChangeSprite.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.ChangeSex
                IsEdit = True
                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = 0 Then
                    frmEditor_Events.optChangeSexMale.Checked = True
                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = 1 Then
                    frmEditor_Events.optChangeSexFemale.Checked = True
                End If
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraChangeGender.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.ChangePk
                IsEdit = True

                frmEditor_Events.cmbSetPK.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1

                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraChangePK.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.WarpPlayer
                IsEdit = True
                frmEditor_Events.nudWPMap.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.nudWPX.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2
                frmEditor_Events.nudWPY.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3
                frmEditor_Events.cmbWarpPlayerDir.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraPlayerWarp.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.SetMoveRoute
                IsEdit = True
                frmEditor_Events.fraMoveRoute.Visible = True
                frmEditor_Events.fraMoveRoute.BringToFront()
                frmEditor_Events.lstMoveRoute.Items.Clear()
                ReDim ListOfEvents(0 To Map.EventCount)
                ListOfEvents(0) = EditorEvent
                For i = 0 To Map.EventCount 
                    If i <> EditorEvent Then
                        frmEditor_Events.cmbEvent.Items.Add(Trim$(Map.Events(i).Name))
                        X = X + 1
                        ListOfEvents(X) = i
                        If i = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 Then frmEditor_Events.cmbEvent.SelectedIndex = X
                    End If
                Next

                IsMoveRouteCommand = True
                frmEditor_Events.chkIgnoreMove.Checked = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2
                frmEditor_Events.chkRepeatRoute.Checked = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3
                TempMoveRouteCount = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).MoveRouteCount
                TempMoveRoute = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).MoveRoute
                For i = 0 To TempMoveRouteCount
                    Select Case TempMoveRoute(i).Index
                        Case 1
                            frmEditor_Events.lstMoveRoute.Items.Add("Move Up")
                        Case 2
                            frmEditor_Events.lstMoveRoute.Items.Add("Move Down")
                        Case 3
                            frmEditor_Events.lstMoveRoute.Items.Add("Move Left")
                        Case 4
                            frmEditor_Events.lstMoveRoute.Items.Add("Move Right")
                        Case 5
                            frmEditor_Events.lstMoveRoute.Items.Add("Move Randomly")
                        Case 6
                            frmEditor_Events.lstMoveRoute.Items.Add("Move Towards Player")
                        Case 7
                            frmEditor_Events.lstMoveRoute.Items.Add("Move Away From Player")
                        Case 8
                            frmEditor_Events.lstMoveRoute.Items.Add("Step Forward")
                        Case 9
                            frmEditor_Events.lstMoveRoute.Items.Add("Step Back")
                        Case 10
                            frmEditor_Events.lstMoveRoute.Items.Add("Wait 100ms")
                        Case 11
                            frmEditor_Events.lstMoveRoute.Items.Add("Wait 500ms")
                        Case 12
                            frmEditor_Events.lstMoveRoute.Items.Add("Wait 1000ms")
                        Case 13
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Up")
                        Case 14
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Down")
                        Case 15
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Left")
                        Case 16
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Right")
                        Case 17
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn 90 Degrees To the Right")
                        Case 18
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn 90 Degrees To the Left")
                        Case 19
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Around 180 Degrees")
                        Case 20
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Randomly")
                        Case 21
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Towards Player")
                        Case 22
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Away from Player")
                        Case 23
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Speed 8x Slower")
                        Case 24
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Speed 4x Slower")
                        Case 25
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Speed 2x Slower")
                        Case 26
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Speed to Normal")
                        Case 27
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Speed 2x Faster")
                        Case 28
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Speed 4x Faster")
                        Case 29
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Frequency Lowest")
                        Case 30
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Frequency Lower")
                        Case 31
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Frequency Normal")
                        Case 32
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Frequency Higher")
                        Case 33
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Frequency Highest")
                        Case 34
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn On Walking Animation")
                        Case 35
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Off Walking Animation")
                        Case 36
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn On Fixed Direction")
                        Case 37
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Off Fixed Direction")
                        Case 38
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn On Walk Through")
                        Case 39
                            frmEditor_Events.lstMoveRoute.Items.Add("Turn Off Walk Through")
                        Case 40
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Position Below Characters")
                        Case 41
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Position Same as Characters")
                        Case 42
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Position Above Characters")
                        Case 43
                            frmEditor_Events.lstMoveRoute.Items.Add("Set Graphic")
                    End Select
                Next
                frmEditor_Events.fraMoveRoute.Visible = True
                frmEditor_Events.fraDialogue.Visible = False
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.PlayAnimation
                IsEdit = True
                frmEditor_Events.lblPlayAnimX.Visible = False
                frmEditor_Events.lblPlayAnimY.Visible = False
                frmEditor_Events.nudPlayAnimTileX.Visible = False
                frmEditor_Events.nudPlayAnimTileY.Visible = False
                frmEditor_Events.cmbPlayAnimEvent.Visible = False
                frmEditor_Events.cmbPlayAnim.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                frmEditor_Events.cmbPlayAnimEvent.Items.Clear()
                For i = 0 To Map.EventCount 
                    frmEditor_Events.cmbPlayAnimEvent.Items.Add(i & ". " & Trim$(Map.Events(i).Name))
                Next
                frmEditor_Events.cmbPlayAnimEvent.SelectedIndex = 0
                If TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0 Then
                    frmEditor_Events.cmbAnimTargetType.SelectedIndex = 0
                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1 Then
                    frmEditor_Events.cmbAnimTargetType.SelectedIndex = 1
                    frmEditor_Events.cmbPlayAnimEvent.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 - 1
                ElseIf TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 2 Then
                    frmEditor_Events.cmbAnimTargetType.SelectedIndex = 2
                    frmEditor_Events.nudPlayAnimTileX.Maximum = Map.MaxX
                    frmEditor_Events.nudPlayAnimTileY.Maximum = Map.MaxY
                    frmEditor_Events.nudPlayAnimTileX.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3
                    frmEditor_Events.nudPlayAnimTileY.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4
                End If
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraPlayAnimation.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.CustomScript
                IsEdit = True
                frmEditor_Events.nudCustomScript.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraCustomScript.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.PlayBgm
                IsEdit = True
                For i = 1 To UBound(MusicCache)
                    If MusicCache(i) = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 Then
                        frmEditor_Events.cmbPlayBGM.SelectedIndex = i
                    End If
                Next
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraPlayBGM.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.PlaySound
                IsEdit = True
                For i = 0 To UBound(SoundCache)
                    If SoundCache(i) = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 Then
                        frmEditor_Events.cmbPlaySound.SelectedIndex = i
                    End If
                Next
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraPlaySound.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.OpenShop
                IsEdit = True
                frmEditor_Events.cmbOpenShop.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraOpenShop.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.SetAccess
                IsEdit = True
                frmEditor_Events.cmbSetAccess.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraSetAccess.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.GiveExp
                IsEdit = True
                frmEditor_Events.nudGiveExp.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraGiveExp.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.ShowChatBubble
                IsEdit = True
                frmEditor_Events.txtChatbubbleText.Text = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1
                frmEditor_Events.cmbChatBubbleTargetType.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                frmEditor_Events.cmbChatBubbleTarget.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 - 1

                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraShowChatBubble.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.Label
                IsEdit = True
                frmEditor_Events.txtLabelName.Text = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraCreateLabel.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.GotoLabel
                IsEdit = True
                frmEditor_Events.txtGotoLabel.Text = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraGoToLabel.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.SpawnNpc
                IsEdit = True
                frmEditor_Events.cmbSpawnNpc.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 - 1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraSpawnNpc.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.SetFog
                IsEdit = True
                frmEditor_Events.nudFogData0.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.nudFogData1.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2
                frmEditor_Events.nudFogData2.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraSetFog.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.SetWeather
                IsEdit = True
                frmEditor_Events.CmbWeather.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.nudWeatherIntensity.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraSetWeather.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.SetTint
                IsEdit = True
                frmEditor_Events.nudMapTintData0.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.nudMapTintData1.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2
                frmEditor_Events.nudMapTintData2.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3
                frmEditor_Events.nudMapTintData3.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraMapTint.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.Wait
                IsEdit = True
                frmEditor_Events.nudWaitAmount.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraSetWait.Visible = True
                frmEditor_Events.fraCommands.Visible = False
            Case EventType.ShowPicture
                IsEdit = True
                frmEditor_Events.nudShowPicture.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1

                frmEditor_Events.cmbPicLoc.SelectedIndex = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2

                frmEditor_Events.nudPicOffsetX.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3
                frmEditor_Events.nudPicOffsetY.Value = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraShowPic.Visible = True
                frmEditor_Events.fraCommands.Visible = False
                EditorEvent_DrawPicture()
            Case EventType.WaitMovement
                IsEdit = True
                frmEditor_Events.fraDialogue.Visible = True
                frmEditor_Events.fraMoveRouteWait.Visible = True
                frmEditor_Events.fraCommands.Visible = False
                frmEditor_Events.cmbMoveWait.Items.Clear()
                ReDim ListOfEvents(0 To Map.EventCount)
                ListOfEvents(0) = EditorEvent
                frmEditor_Events.cmbMoveWait.Items.Add("This Event")
                frmEditor_Events.cmbMoveWait.SelectedIndex = 0
                For i = 0 To Map.EventCount 
                    If i <> EditorEvent Then
                        frmEditor_Events.cmbMoveWait.Items.Add(Trim$(Map.Events(i).Name))
                        X = X + 1
                        ListOfEvents(X) = i
                        If i = TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 Then frmEditor_Events.cmbMoveWait.SelectedIndex = X
                    End If
                Next
        End Select

    End Sub

    Public Sub DeleteEventCommand()
        Dim i As Integer, X As Integer, curlist As Integer, curslot As Integer, p As Integer, oldCommandList As CommandListStruct

        i = frmEditor_Events.lstCommands.SelectedIndex + 1
        If i = -1 Then Exit Sub
        If i > UBound(EventList) Then Exit Sub

        curlist = EventList(i).CommandList
        curslot = EventList(i).CommandNum

        If curlist = 0 Then Exit Sub
        If curslot = 0 Then Exit Sub
        If curlist > TmpEvent.Pages(CurPageNum).CommandListCount Then Exit Sub
        If curslot > TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount Then Exit Sub

        If curslot = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount Then
            TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount - 1
            p = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount
            If p <= 0 Then
                ReDim TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(0)
            Else
                oldCommandList = TmpEvent.Pages(CurPageNum).CommandList(curlist)
                ReDim TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(p)
                X = 1
                TmpEvent.Pages(CurPageNum).CommandList(curlist).ParentList = oldCommandList.ParentList
                TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount = p
                For i = 1 To p + 1
                    If i <> curslot Then
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(X) = oldCommandList.Commands(i)
                        X = X + 1
                    End If
                Next
            End If
        Else
            TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount - 1
            p = TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount
            oldCommandList = TmpEvent.Pages(CurPageNum).CommandList(curlist)
            X = 1
            If p <= 0 Then
                ReDim TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(0)
            Else
                ReDim TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(p)
                TmpEvent.Pages(CurPageNum).CommandList(curlist).ParentList = oldCommandList.ParentList
                TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount = p
                For i = 1 To p + 1
                    If i <> curslot Then
                        TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(X) = oldCommandList.Commands(i)
                        X = X + 1
                    End If
                Next
            End If
        End If
        EventListCommands()

    End Sub

    Public Sub ClearEventCommands()
        ReDim TmpEvent.Pages(CurPageNum).CommandList(0)
        TmpEvent.Pages(CurPageNum).CommandListCount = 0
        EventListCommands()
    End Sub

    Public Sub EditCommand()
        Dim i As Integer, curlist As Integer, curslot As Integer

        i = frmEditor_Events.lstCommands.SelectedIndex + 1
        If i = -1 Then Exit Sub
        If i > UBound(EventList) Then Exit Sub

        curlist = EventList(i).CommandList
        curslot = EventList(i).CommandNum
        If curlist = 0 Then Exit Sub
        If curslot = 0 Then Exit Sub
        If curlist > TmpEvent.Pages(CurPageNum).CommandListCount Then Exit Sub
        If curslot > TmpEvent.Pages(CurPageNum).CommandList(curlist).CommandCount Then Exit Sub
        Select Case TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Index
            Case EventType.AddText
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtAddText_Text.Text
                'tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlAddText_Color.Value
                If frmEditor_Events.optAddText_Player.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf frmEditor_Events.optAddText_Map.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                ElseIf frmEditor_Events.optAddText_Global.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 2
                End If
            Case EventType.Condition
                If frmEditor_Events.optCondition0.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 0
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_PlayerVarIndex.SelectedIndex
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = frmEditor_Events.cmbCondition_PlayerVarCompare.SelectedIndex
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data3 = frmEditor_Events.nudCondition_PlayerVarCondition.Value
                ElseIf frmEditor_Events.optCondition1.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 1
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_PlayerSwitch.SelectedIndex
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = frmEditor_Events.cmbCondtion_PlayerSwitchCondition.SelectedIndex
                ElseIf frmEditor_Events.optCondition2.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 2
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_HasItem.SelectedIndex
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = frmEditor_Events.nudCondition_HasItem.Value
                ElseIf frmEditor_Events.optCondition3.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 3
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_JobIs.SelectedIndex
                ElseIf frmEditor_Events.optCondition4.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 4
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_LearntSkill.SelectedIndex
                ElseIf frmEditor_Events.optCondition5.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 5
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.nudCondition_LevelAmount.Value
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = frmEditor_Events.cmbCondition_LevelCompare.SelectedIndex
                ElseIf frmEditor_Events.optCondition6.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 6
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_SelfSwitch.SelectedIndex
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data2 = frmEditor_Events.cmbCondition_SelfSwitchCondition.SelectedIndex
                ElseIf frmEditor_Events.optCondition8.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 8
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_Gender.SelectedIndex
                ElseIf frmEditor_Events.optCondition9.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Condition = 9
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).ConditionalBranch.Data1 = frmEditor_Events.cmbCondition_Time.SelectedIndex
                End If
            Case EventType.ShowText
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtShowText.Text
            Case EventType.ShowChoices
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtChoicePrompt.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text2 = frmEditor_Events.txtChoices1.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text3 = frmEditor_Events.txtChoices2.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text4 = frmEditor_Events.txtChoices3.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text5 = frmEditor_Events.txtChoices4.Text
            Case EventType.PlayerVar
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbVariable.SelectedIndex 
                If frmEditor_Events.optVariableAction0.Checked = True Then i = 0
                If frmEditor_Events.optVariableAction1.Checked = True Then i = 1
                If frmEditor_Events.optVariableAction2.Checked = True Then i = 2
                If frmEditor_Events.optVariableAction3.Checked = True Then i = 3
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = i
                If i = 0 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.nudVariableData0.Value
                ElseIf i = 1 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.nudVariableData1.Value
                ElseIf i = 2 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.nudVariableData2.Value
                ElseIf i = 3 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.nudVariableData3.Value
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = frmEditor_Events.nudVariableData4.Value
                End If
            Case EventType.PlayerSwitch
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbSwitch.SelectedIndex 
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.cmbPlayerSwitchSet.SelectedIndex
            Case EventType.SelfSwitch
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbSetSelfSwitch.SelectedIndex
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.cmbSetSelfSwitchTo.SelectedIndex
            Case EventType.ChangeItems
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbChangeItemIndex.SelectedIndex 
                If frmEditor_Events.optChangeItemSet.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf frmEditor_Events.optChangeItemAdd.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                ElseIf frmEditor_Events.optChangeItemRemove.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 2
                End If
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.nudChangeItemsAmount.Value
            Case EventType.ChangeLevel
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.nudChangeLevel.Value
            Case EventType.ChangeSkills
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbChangeSkills.SelectedIndex 
                If frmEditor_Events.optChangeSkillsAdd.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf frmEditor_Events.optChangeSkillsRemove.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                End If
            Case EventType.ChangeJob
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbChangeJob.SelectedIndex 
            Case EventType.ChangeSprite
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.nudChangeSprite.Value
            Case EventType.ChangeSex
                If frmEditor_Events.optChangeSexMale.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = 0
                ElseIf frmEditor_Events.optChangeSexFemale.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = 1
                End If
            Case EventType.ChangePk
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbSetPK.SelectedIndex

            Case EventType.WarpPlayer
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.nudWPMap.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.nudWPX.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.nudWPY.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = frmEditor_Events.cmbWarpPlayerDir.SelectedIndex
            Case EventType.SetMoveRoute
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = ListOfEvents(frmEditor_Events.cmbEvent.SelectedIndex)
                If frmEditor_Events.chkIgnoreMove.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                Else
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                End If

                If frmEditor_Events.chkRepeatRoute.Checked = True Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = 1
                Else
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = 0
                End If
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).MoveRouteCount = TempMoveRouteCount
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).MoveRoute = TempMoveRoute
            Case EventType.PlayAnimation
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbPlayAnim.SelectedIndex 
                If frmEditor_Events.cmbAnimTargetType.SelectedIndex = 0 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 0
                ElseIf frmEditor_Events.cmbAnimTargetType.SelectedIndex = 1 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 1
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.cmbPlayAnimEvent.SelectedIndex 
                ElseIf frmEditor_Events.cmbAnimTargetType.SelectedIndex = 2 Then
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = 2
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.nudPlayAnimTileX.Value
                    TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = frmEditor_Events.nudPlayAnimTileY.Value
                End If
            Case EventType.CustomScript
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.nudCustomScript.Value
            Case EventType.PlayBgm
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = MusicCache(frmEditor_Events.cmbPlayBGM.SelectedIndex )
            Case EventType.PlaySound
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = SoundCache(frmEditor_Events.cmbPlaySound.SelectedIndex )
            Case EventType.OpenShop
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbOpenShop.SelectedIndex 
            Case EventType.SetAccess
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbSetAccess.SelectedIndex
            Case EventType.GiveExp
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.nudGiveExp.Value
            Case EventType.ShowChatBubble
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtChatbubbleText.Text
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbChatBubbleTargetType.SelectedIndex 
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.cmbChatBubbleTarget.SelectedIndex 
            Case EventType.Label
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtLabelName.Text
            Case EventType.GotoLabel
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Text1 = frmEditor_Events.txtGotoLabel.Text
            Case EventType.SpawnNpc
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.cmbSpawnNpc.SelectedIndex 
            Case EventType.SetFog
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.nudFogData0.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.nudFogData1.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.nudFogData2.Value
            Case EventType.SetWeather
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.CmbWeather.SelectedIndex
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.nudWeatherIntensity.Value
            Case EventType.SetTint
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.nudMapTintData0.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.nudMapTintData1.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.nudMapTintData2.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = frmEditor_Events.nudMapTintData3.Value
            Case EventType.Wait
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.nudWaitAmount.Value
            Case EventType.ShowPicture
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.nudShowPicture.Value

                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data2 = frmEditor_Events.cmbPicLoc.SelectedIndex 

                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data3 = frmEditor_Events.nudPicOffsetX.Value
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data4 = frmEditor_Events.nudPicOffsetY.Value
            Case EventType.WaitMovement
                TmpEvent.Pages(CurPageNum).CommandList(curlist).Commands(curslot).Data1 = ListOfEvents(frmEditor_Events.cmbMoveWait.SelectedIndex)
        End Select
        EventListCommands()

    End Sub

#End Region

#Region "Incoming Packets"

    Sub Packet_SpawnEvent(ByRef data() As Byte)
        Dim id As Integer
        Dim buffer As New ByteStream(data)

        id = buffer.ReadInt32

        If id > CurrentEvents Then
            CurrentEvents = id
            ReDim Preserve MapEvents(CurrentEvents)
        End If

        With MapEvents(id)
            .Name = buffer.ReadString
            .Dir = buffer.ReadInt32
            .ShowDir = .Dir
            .GraphicType = buffer.ReadByte
            .Graphic = buffer.ReadInt32
            .GraphicX = buffer.ReadInt32
            .GraphicX2 = buffer.ReadInt32
            .GraphicY = buffer.ReadInt32
            .GraphicY2 = buffer.ReadInt32
            .MovementSpeed = buffer.ReadInt32
            .Moving = 0
            .X = buffer.ReadInt32
            .Y = buffer.ReadInt32
            .XOffset = 0
            .YOffset = 0
            .Position = buffer.ReadByte
            .Visible = buffer.ReadInt32
            .WalkAnim = buffer.ReadInt32
            .DirFix = buffer.ReadInt32
            .WalkThrough = buffer.ReadInt32
            .ShowName = buffer.ReadInt32
            .QuestNum = buffer.ReadInt32
        End With

        buffer.Dispose()

    End Sub

    Sub Packet_EventMove(ByRef data() As Byte)
        Dim id As Integer
        Dim x As Integer
        Dim y As Integer
        Dim dir As Integer, showDir As Integer
        Dim movementSpeed As Integer
        Dim buffer As New ByteStream(data)

        id = buffer.ReadInt32
        x = buffer.ReadInt32
        y = buffer.ReadInt32
        dir = buffer.ReadInt32
        showDir = buffer.ReadInt32
        movementSpeed = buffer.ReadInt32

        If id > CurrentEvents Then Exit Sub

        With MapEvents(id)
            .X = x
            .Y = y
            .Dir = dir
            .XOffset = 0
            .YOffset = 0
            .Moving = 1
            .ShowDir = showDir
            .MovementSpeed = movementSpeed

            Select Case dir
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

    End Sub

    Sub Packet_EventDir(ByRef data() As Byte)
        Dim i As Integer
        Dim dir As Byte
        Dim buffer As New ByteStream(data)
        i = buffer.ReadInt32
        dir = buffer.ReadInt32

        If i > CurrentEvents Then Exit Sub

        With MapEvents(i)
            .Dir = dir
            .ShowDir = dir
            .XOffset = 0
            .YOffset = 0
            .Moving = 0
        End With

    End Sub

    Sub Packet_SwitchesAndVariables(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)
        For i = 1 To MAX_SWITCHES
            Switches(i) = buffer.ReadString
        Next
        For i = 1 To NAX_VARIABLES
            Variables(i) = buffer.ReadString
        Next

        buffer.Dispose()

    End Sub

    Sub Packet_MapEventData(ByRef data() As Byte)
        Dim i As Integer, x As Integer, y As Integer, z As Integer, w As Integer
        Dim buffer As New ByteStream(data)

        Map.EventCount = buffer.ReadInt32

        If Map.EventCount > 0 Then
            ReDim Map.Events(Map.EventCount)
            For i = 0 To Map.EventCount
                With Map.Events(i)
                    .Name = buffer.ReadString
                    .Globals = buffer.ReadByte
                    .X = buffer.ReadInt32
                    .Y = buffer.ReadInt32
                    .PageCount = buffer.ReadInt32
                End With

                If Map.Events(i).PageCount > 0 Then
                    ReDim Map.Events(i).Pages(Map.Events(i).PageCount)
                    For x = 0 To Map.Events(i).PageCount
                        With Map.Events(i).Pages(x)
                            .ChkVariable = buffer.ReadInt32
                            .VariableIndex = buffer.ReadInt32
                            .VariableCondition = buffer.ReadInt32
                            .VariableCompare = buffer.ReadInt32
                            .ChkSwitch = buffer.ReadInt32
                            .SwitchIndex = buffer.ReadInt32
                            .SwitchCompare = buffer.ReadInt32
                            .ChkHasItem = buffer.ReadInt32
                            .HasItemIndex = buffer.ReadInt32
                            .HasItemAmount = buffer.ReadInt32
                            .ChkSelfSwitch = buffer.ReadInt32
                            .SelfSwitchIndex = buffer.ReadInt32
                            .SelfSwitchCompare = buffer.ReadInt32
                            .GraphicType = buffer.ReadByte
                            .Graphic = buffer.ReadInt32
                            .GraphicX = buffer.ReadInt32
                            .GraphicY = buffer.ReadInt32
                            .GraphicX2 = buffer.ReadInt32
                            .GraphicY2 = buffer.ReadInt32

                            .MoveType = buffer.ReadByte
                            .MoveSpeed = buffer.ReadByte
                            .MoveFreq = buffer.ReadByte
                            .MoveRouteCount = buffer.ReadInt32
                            .IgnoreMoveRoute = buffer.ReadInt32
                            .RepeatMoveRoute = buffer.ReadInt32

                            If .MoveRouteCount > 0 Then
                                ReDim Map.Events(i).Pages(x).MoveRoute(.MoveRouteCount)
                                For y = 0 To .MoveRouteCount
                                    .MoveRoute(y).Index = buffer.ReadInt32
                                    .MoveRoute(y).Data1 = buffer.ReadInt32
                                    .MoveRoute(y).Data2 = buffer.ReadInt32
                                    .MoveRoute(y).Data3 = buffer.ReadInt32
                                    .MoveRoute(y).Data4 = buffer.ReadInt32
                                    .MoveRoute(y).Data5 = buffer.ReadInt32
                                    .MoveRoute(y).Data6 = buffer.ReadInt32
                                Next
                            End If

                            .WalkAnim = buffer.ReadInt32
                            .DirFix = buffer.ReadInt32
                            .WalkThrough = buffer.ReadInt32
                            .ShowName = buffer.ReadInt32
                            .Trigger = buffer.ReadByte
                            .CommandListCount = buffer.ReadInt32
                            .Position = buffer.ReadByte
                            .QuestNum = buffer.ReadInt32
                        End With

                        If Map.Events(i).Pages(x).CommandListCount > 0 Then
                            ReDim Map.Events(i).Pages(x).CommandList(Map.Events(i).Pages(x).CommandListCount)
                            For y = 0 To Map.Events(i).Pages(x).CommandListCount
                                Map.Events(i).Pages(x).CommandList(y).CommandCount = buffer.ReadInt32
                                Map.Events(i).Pages(x).CommandList(y).ParentList = buffer.ReadInt32
                                If Map.Events(i).Pages(x).CommandList(y).CommandCount > 0 Then
                                    ReDim Map.Events(i).Pages(x).CommandList(y).Commands(Map.Events(i).Pages(x).CommandList(y).CommandCount)
                                    For z = 0 To Map.Events(i).Pages(x).CommandList(y).CommandCount
                                        With Map.Events(i).Pages(x).CommandList(y).Commands(z)
                                            .Index = buffer.ReadByte
                                            .Text1 = buffer.ReadString
                                            .Text2 = buffer.ReadString
                                            .Text3 = buffer.ReadString
                                            .Text4 = buffer.ReadString
                                            .Text5 = buffer.ReadString
                                            .Data1 = buffer.ReadInt32
                                            .Data2 = buffer.ReadInt32
                                            .Data3 = buffer.ReadInt32
                                            .Data4 = buffer.ReadInt32
                                            .Data5 = buffer.ReadInt32
                                            .Data6 = buffer.ReadInt32
                                            .ConditionalBranch.CommandList = buffer.ReadInt32
                                            .ConditionalBranch.Condition = buffer.ReadInt32
                                            .ConditionalBranch.Data1 = buffer.ReadInt32
                                            .ConditionalBranch.Data2 = buffer.ReadInt32
                                            .ConditionalBranch.Data3 = buffer.ReadInt32
                                            .ConditionalBranch.ElseCommandList = buffer.ReadInt32
                                            .MoveRouteCount = buffer.ReadInt32

                                            If .MoveRouteCount > 0 Then
                                                ReDim .MoveRoute(.MoveRouteCount)
                                                For w = 0 To .MoveRouteCount
                                                    .MoveRoute(w).Index = buffer.ReadInt32
                                                    .MoveRoute(w).Data1 = buffer.ReadInt32
                                                    .MoveRoute(w).Data2 = buffer.ReadInt32
                                                    .MoveRoute(w).Data3 = buffer.ReadInt32
                                                    .MoveRoute(w).Data4 = buffer.ReadInt32
                                                    .MoveRoute(w).Data5 = buffer.ReadInt32
                                                    .MoveRoute(w).Data6 = buffer.ReadInt32
                                                Next
                                            End If
                                        End With
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        End If

        buffer.Dispose()

    End Sub

    Sub Packet_EventChat(ByRef data() As Byte)
        Dim i As Integer
        Dim choices As Integer
        Dim buffer As New ByteStream(data)
        EventReplyId = buffer.ReadInt32
        EventReplyPage = buffer.ReadInt32
        EventChatFace = buffer.ReadInt32
        EventText = buffer.ReadString
        If EventText = "" Then EventText = " "
        EventChat = True
        ShowEventLbl = True
        choices = buffer.ReadInt32
        InEvent = True
        For i = 1 To 4
            EventChoices(i) = ""
            EventChoiceVisible(i) = False
        Next
        EventChatType = 0
        If choices = 0 Then
        Else
            EventChatType = 1
            For i = 0 To choices
                EventChoices(i) = buffer.ReadString
                EventChoiceVisible(i) = True
            Next
        End If
        AnotherChat = buffer.ReadInt32

        buffer.Dispose()

    End Sub

    Sub Packet_EventStart(ByRef data() As Byte)
        InEvent = True
    End Sub

    Sub Packet_EventEnd(ByRef data() As Byte)
        InEvent = False
    End Sub

    Sub Packet_Picture(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
        Dim picIndex As Integer, spriteType As Integer, xOffset As Integer, yOffset As Integer, eventid As Integer

        eventid = buffer.ReadInt32
        picIndex = buffer.ReadByte

        If picIndex = 0 Then
            Picture.Index = 0
            Picture.EventId = 0
            Picture.SpriteType = 0
            Picture.xOffset = 0
            Picture.yOffset = 0
            Exit Sub
        End If

        spriteType = buffer.ReadByte
        xOffset = buffer.ReadByte
        yOffset = buffer.ReadByte

        Picture.Index = picIndex
        Picture.EventId = eventid
        Picture.SpriteType = spriteType
        Picture.xOffset = xOffset
        Picture.yOffset = yOffset

        buffer.Dispose()

    End Sub

    Sub Packet_HidePicture(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)

        Picture = Nothing
    End Sub

    Sub Packet_HoldPlayer(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
        If buffer.ReadInt32 = 0 Then
            HoldPlayer = True
        Else
            HoldPlayer = False
        End If

        buffer.Dispose()

    End Sub

    Sub Packet_PlayBGM(ByRef data() As Byte)
        Dim music As String
        Dim buffer As New ByteStream(data)

        music = buffer.ReadString
        Map.Music = music

        buffer.Dispose()
    End Sub

    Sub Packet_FadeOutBGM(ByRef data() As Byte)
        CurrentMusic = ""
        FadeOutSwitch = True
    End Sub

    Sub Packet_PlaySound(ByRef data() As Byte)
        Dim sound As String
        Dim buffer As New ByteStream(data)
        sound = buffer.ReadString

        PlaySound(sound)

        buffer.Dispose()
    End Sub

    Sub Packet_StopSound(ByRef data() As Byte)
        StopSound()
    End Sub

    Sub Packet_SpecialEffect(ByRef data() As Byte)
        Dim effectType As Integer
        Dim buffer As New ByteStream(data)
        effectType = buffer.ReadInt32

        Select Case effectType
            Case EffectTypeFadein
                UseFade = True
                FadeType = 1
                FadeAmount = 0
            Case EffectTypeFadeout
                UseFade = True
                FadeType = 0
                FadeAmount = 255
            Case EffectTypeFlash
                FlashTimer = GetTickCount() + 150
            Case EffectTypeFog
                CurrentFog = buffer.ReadInt32
                CurrentFogSpeed = buffer.ReadInt32
                CurrentFogOpacity = buffer.ReadInt32
            Case EffectTypeWeather
                CurrentWeather = buffer.ReadInt32
                CurrentWeatherIntensity = buffer.ReadInt32
            Case EffectTypeTint
                Map.MapTint = 1
                CurrentTintR = buffer.ReadInt32
                CurrentTintG = buffer.ReadInt32
                CurrentTintB = buffer.ReadInt32
                CurrentTintA = buffer.ReadInt32
        End Select

        buffer.Dispose()
    End Sub

#End Region

#Region "Outgoing Packets"

    Sub RequestSwitchesAndVariables()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CRequestSwitchesAndVariables)
        Socket.SendData(buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendSwitchesAndVariables()
        Dim i As Integer
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CSwitchesAndVariables)

        For i = 1 To MAX_SWITCHES
            buffer.WriteString((Trim$(Switches(i))))
        Next
        For i = 1 To NAX_VARIABLES
            buffer.WriteString((Trim$(Variables(i))))
        Next

        Socket.SendData(buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

#End Region

#Region "Drawing..."

    Public Sub EditorEvent_DrawGraphic()
        Dim sRect As RectStruct
        Dim dRect As RectStruct
        Dim targetBitmap As Bitmap 'Bitmap we draw to
        Dim sourceBitmap As Bitmap 'This is our sprite or tileset that we are drawing from
        Dim g As Graphics 'This is our graphics Job that helps us draw to the targetBitmap

        If frmEditor_Events.picGraphicSel.Visible Then
            Select Case frmEditor_Events.cmbGraphic.SelectedIndex
                Case 0
                    'None
                    frmEditor_Events.picGraphicSel.BackgroundImage = Nothing
                Case 1
                    If frmEditor_Events.nudGraphic.Value > 0 And frmEditor_Events.nudGraphic.Value <= NumCharacters Then
                        'Load character from Contents into our sourceBitmap
                        sourceBitmap = New Bitmap(Paths.Graphics & "\characters\" & frmEditor_Events.nudGraphic.Value & ".png")
                        targetBitmap = New Bitmap(sourceBitmap.Width, sourceBitmap.Height) 'Create our target Bitmap

                        g = Graphics.FromImage(targetBitmap)
                        'This is the section we are pulling from the source graphic
                        Dim sourceRect As New Rectangle(0, 0, sourceBitmap.Width / 4, sourceBitmap.Height / 4)
                        'This is the rectangle in the target graphic we want to render to
                        Dim destRect As New Rectangle(0, 0, targetBitmap.Width / 4, targetBitmap.Height / 4)

                        g.DrawImage(sourceBitmap, destRect, sourceRect, GraphicsUnit.Pixel)

                        g.DrawRectangle(Pens.Red, New Rectangle(GraphicSelX * PicX, GraphicSelY * PicY, GraphicSelX2 * PicX, GraphicSelY2 * PicY))

                        frmEditor_Events.picGraphic.BackgroundImage = targetBitmap
                        frmEditor_Events.picGraphicSel.BackgroundImage = Nothing

                        g.Dispose()
                    Else
                        frmEditor_Events.picGraphic.BackgroundImage = Nothing
                        frmEditor_Events.picGraphicSel.BackgroundImage = Nothing
                        Exit Sub
                    End If
                Case 2
                    If frmEditor_Events.nudGraphic.Value > 0 And frmEditor_Events.nudGraphic.Value <= NumTileSets Then
                        'Load tilesheet from Contents into our sourceBitmap
                        sourceBitmap = New Bitmap(Paths.Graphics & "\tilesets\" & frmEditor_Events.nudGraphic.Value & ".png")
                        targetBitmap = New Bitmap(sourceBitmap.Width, sourceBitmap.Height) 'Create our target Bitmap

                        If TmpEvent.Pages(CurPageNum).GraphicX2 = 0 And TmpEvent.Pages(CurPageNum).GraphicY2 = 0 Then
                            sRect.Top = TmpEvent.Pages(CurPageNum).GraphicY * 32
                            sRect.Left = TmpEvent.Pages(CurPageNum).GraphicX * 32
                            sRect.Bottom = sRect.Top + 32
                            sRect.Right = sRect.Left + 32

                            With dRect
                                dRect.Top = (193 / 2) - ((sRect.Bottom - sRect.Top) / 2)
                                dRect.Bottom = dRect.Top + (sRect.Bottom - sRect.Top)
                                dRect.Left = (120 / 2) - ((sRect.Right - sRect.Left) / 2)
                                dRect.Right = dRect.Left + (sRect.Right - sRect.Left)
                            End With
                        Else
                            sRect.Top = TmpEvent.Pages(CurPageNum).GraphicY * 32
                            sRect.Left = TmpEvent.Pages(CurPageNum).GraphicX * 32
                            sRect.Bottom = sRect.Top + ((TmpEvent.Pages(CurPageNum).GraphicY2 - TmpEvent.Pages(CurPageNum).GraphicY) * 32)
                            sRect.Right = sRect.Left + ((TmpEvent.Pages(CurPageNum).GraphicX2 - TmpEvent.Pages(CurPageNum).GraphicX) * 32)

                            With dRect
                                dRect.Top = (193 / 2) - ((sRect.Bottom - sRect.Top) / 2)
                                dRect.Bottom = dRect.Top + (sRect.Bottom - sRect.Top)
                                dRect.Left = (120 / 2) - ((sRect.Right - sRect.Left) / 2)
                                dRect.Right = dRect.Left + (sRect.Right - sRect.Left)
                            End With

                        End If

                        g = Graphics.FromImage(targetBitmap)

                        Dim sourceRect As New Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height)  'This is the section we are pulling from the source graphic
                        Dim destRect As New Rectangle(0, 0, targetBitmap.Width, targetBitmap.Height)     'This is the rectangle in the target graphic we want to render to

                        g.DrawImage(sourceBitmap, destRect, sourceRect, GraphicsUnit.Pixel)
                        g.DrawRectangle(Pens.Red, New Rectangle(GraphicSelX * PicX, GraphicSelY * PicY, (GraphicSelX2) * PicX, (GraphicSelY2) * PicY))
                        g.Dispose()

                        frmEditor_Events.picGraphicSel.BackgroundImage = targetBitmap
                        frmEditor_Events.picGraphic.BackgroundImage = Nothing
                    Else
                        frmEditor_Events.picGraphicSel.BackgroundImage = Nothing
                        frmEditor_Events.picGraphic.BackgroundImage = Nothing
                        Exit Sub
                    End If
            End Select
        Else
            If TmpEvent.PageCount > 0 Then
                Select Case TmpEvent.Pages(CurPageNum).GraphicType
                    Case 0
                        frmEditor_Events.picGraphicSel.BackgroundImage = Nothing
                    Case 1
                        If TmpEvent.Pages(CurPageNum).Graphic > 0 And TmpEvent.Pages(CurPageNum).Graphic <= NumCharacters Then
                            'Load character from Contents into our sourceBitmap
                            sourceBitmap = New Bitmap(Paths.Graphics & "\characters\" & TmpEvent.Pages(CurPageNum).Graphic & ".png")
                            targetBitmap = New Bitmap(sourceBitmap.Width, sourceBitmap.Height) 'Create our target Bitmap

                            g = Graphics.FromImage(targetBitmap)

                            Dim sourceRect As New Rectangle(0, 0, sourceBitmap.Width / 4, sourceBitmap.Height / 4)  'This is the section we are pulling from the source graphic
                            Dim destRect As New Rectangle(0, 0, targetBitmap.Width / 4, targetBitmap.Height / 4)     'This is the rectangle in the target graphic we want to render to

                            g.DrawImage(sourceBitmap, destRect, sourceRect, GraphicsUnit.Pixel)
                            g.Dispose()

                            frmEditor_Events.picGraphic.BackgroundImage = targetBitmap
                        Else
                            frmEditor_Events.picGraphic.BackgroundImage = Nothing
                            Exit Sub
                        End If
                    Case 2
                        If TmpEvent.Pages(CurPageNum).Graphic > 0 And TmpEvent.Pages(CurPageNum).Graphic <= NumTileSets Then
                            'Load tilesheet from Contents into our sourceBitmap
                            sourceBitmap = New Bitmap(Paths.Graphics & "tilesets\" & TmpEvent.Pages(CurPageNum).Graphic & ".png")
                            targetBitmap = New Bitmap(sourceBitmap.Width, sourceBitmap.Height) 'Create our target Bitmap

                            If TmpEvent.Pages(CurPageNum).GraphicX2 = 0 And TmpEvent.Pages(CurPageNum).GraphicY2 = 0 Then
                                sRect.Top = TmpEvent.Pages(CurPageNum).GraphicY * 32
                                sRect.Left = TmpEvent.Pages(CurPageNum).GraphicX * 32
                                sRect.Bottom = sRect.Top + 32
                                sRect.Right = sRect.Left + 32

                                With dRect
                                    dRect.Top = 0
                                    dRect.Bottom = PicY
                                    dRect.Left = 0
                                    dRect.Right = PicX
                                End With
                            Else
                                sRect.Top = TmpEvent.Pages(CurPageNum).GraphicY * 32
                                sRect.Left = TmpEvent.Pages(CurPageNum).GraphicX * 32
                                sRect.Bottom = TmpEvent.Pages(CurPageNum).GraphicY2 * 32
                                sRect.Right = TmpEvent.Pages(CurPageNum).GraphicX2 * 32

                                With dRect
                                    dRect.Top = 0
                                    dRect.Bottom = sRect.Bottom
                                    dRect.Left = 0
                                    dRect.Right = sRect.Right
                                End With

                            End If

                            g = Graphics.FromImage(targetBitmap)

                            Dim sourceRect As New Rectangle(sRect.Left, sRect.Top, sRect.Right, sRect.Bottom)  'This is the section we are pulling from the source graphic
                            Dim destRect As New Rectangle(dRect.Left, dRect.Top, dRect.Right, dRect.Bottom)     'This is the rectangle in the target graphic we want to render to

                            g.DrawImage(sourceBitmap, destRect, sourceRect, GraphicsUnit.Pixel)
                            g.Dispose()

                            frmEditor_Events.picGraphic.BackgroundImage = targetBitmap
                        End If
                End Select
            End If
        End If

    End Sub

    Friend Sub DrawEvents()
        Dim rec As Rectangle
        Dim width As Integer, height As Integer, i As Integer, x As Integer, y As Integer
        Dim tX As Integer
        Dim tY As Integer

        If Map.EventCount <= 0 Then Exit Sub
        For i = 1 To Map.EventCount
            width = 32
            height = 32
            x = Map.Events(i).X * 32
            y = Map.Events(i).Y * 32
            If Map.Events(i).PageCount <= 0 Then
                With rec
                    .Y = 0
                    .Height = PicY
                    .X = 0
                    .Width = PicX
                End With

                Dim rec2 As New RectangleShape With {
                    .OutlineColor = New SFML.Graphics.Color(SFML.Graphics.Color.Blue),
                    .OutlineThickness = 0.6,
                    .FillColor = New SFML.Graphics.Color(SFML.Graphics.Color.Transparent),
                    .Size = New Vector2f(rec.Width, rec.Height),
                    .Position = New Vector2f(ConvertMapX(CurX * PicX), ConvertMapY(CurY * PicY))
                }
                Window.Draw(rec2)
                GoTo nextevent
            End If
            x = ConvertMapX(x)
            y = ConvertMapY(y)
            If i > Map.EventCount Then Exit Sub
            If 1 > Map.Events(i).PageCount Then Exit Sub
            Select Case Map.Events(i).Pages(1).GraphicType
                Case 0
                    tX = ((x) - 4) + (PicX * 0.5)
                    tY = ((y) - 7) + (PicY * 0.5)
                    RenderText("E", Window, tX, tY, (SFML.Graphics.Color.Green), (SFML.Graphics.Color.Black))
                Case 1
                    If Map.Events(i).Pages(1).Graphic > 0 And Map.Events(i).Pages(1).Graphic <= NumCharacters Then
                        Dim gfxIndex As Integer = Map.Events(i).Pages(1).Graphic
                        Dim gfxInfo As GraphicInfo = CharacterGfxInfo(gfxIndex)
                        Dim gfxType As GfxType = GfxType.Character  ' Assuming the type here

                        ' Calculate source rectangle based on character graphics properties
                        Dim sX As Integer = Map.Events(i).Pages(1).GraphicX * (gfxInfo.Width / 4)
                        Dim sY As Integer = Map.Events(i).Pages(1).GraphicY * (gfxInfo.Height / 4)
                        Dim sW As Integer = gfxInfo.Width / 4

                        ' Adjust sH to capture more of the sprite, excluding the lower part, like the legs
                        Dim sH As Integer = (gfxInfo.Height / 4) * 3 / 4  ' Taking about 3/4 of the top part

                        ' Destination coordinates and dimensions to fit into a 32x32 square
                        Dim dX As Integer = ConvertMapX(Map.Events(i).X * PicX)
                        Dim dY As Integer = ConvertMapY(Map.Events(i).Y * PicY)
                        Dim dW As Integer = 32
                        Dim dH As Integer = 32

                        RenderTexture(gfxIndex, gfxType, Window, dX, dY, sX, sY, dW, dH, sW, sH)
                    Else
                        With rec
                            .Y = 0
                            .Height = PicY
                            .X = 0
                            .Width = PicX
                        End With

                        Dim rec2 As New RectangleShape With {
                            .OutlineColor = New SFML.Graphics.Color(SFML.Graphics.Color.Blue),
                            .OutlineThickness = 0.6,
                            .FillColor = New SFML.Graphics.Color(SFML.Graphics.Color.Transparent),
                            .Size = New Vector2f(rec.Width, rec.Height),
                            .Position = New Vector2f(ConvertMapX(CurX * PicX), ConvertMapY(CurY * PicY))
                        }
                        Window.Draw(rec2)
                    End If
                Case 2
                    If Map.Events(i).Pages(1).Graphic > 0 And Map.Events(i).Pages(1).Graphic <= NumTileSets Then
                        With rec
                            .X = Map.Events(i).Pages(1).GraphicX * 32
                            .Width = Map.Events(i).Pages(1).GraphicX2 * 32
                            .Y = Map.Events(i).Pages(1).GraphicY * 32
                            .Height = Map.Events(i).Pages(1).GraphicY2 * 32
                        End With

                        If rec.Height > 32 Then
                            RenderTexture(Map.Events(i).Pages(1).Graphic, GfxType.Tileset, Window, ConvertMapX(Map.Events(i).X * PicX), ConvertMapY(Map.Events(i).Y * PicY) - PicY, rec.X, rec.Y, rec.Width, rec.Height)
                        Else
                            RenderTexture(Map.Events(i).Pages(1).Graphic, GfxType.Tileset, Window, ConvertMapX(Map.Events(i).X * PicX), ConvertMapY(Map.Events(i).Y * PicY), rec.X, rec.Y, rec.Width, rec.Height)
                        End If
                    Else
                        With rec
                            .Y = 0
                            .Height = PicY
                            .X = 0
                            .Width = PicX
                        End With

                        Dim rec2 As New RectangleShape With {
                            .OutlineColor = New SFML.Graphics.Color(SFML.Graphics.Color.Blue),
                            .OutlineThickness = 0.6,
                            .FillColor = New SFML.Graphics.Color(SFML.Graphics.Color.Transparent),
                            .Size = New Vector2f(rec.Width, rec.Height),
                            .Position = New Vector2f(ConvertMapX(CurX * PicX), ConvertMapY(CurY * PicY))
                        }
                        Window.Draw(rec2)
                    End If
            End Select
nextevent:
        Next

    End Sub

    Friend Sub DrawEvent(id As Integer) ' draw on map, outside the editor
        Dim x As Integer, y As Integer, width As Integer, height As Integer, sRect As Rectangle, anim As Integer, spritetop As Integer

        If MapEvents(id).Visible = 0 Then Exit Sub

        Select Case MapEvents(id).GraphicType
            Case 0
                Exit Sub
            Case 1
                If MapEvents(id).Graphic <= 0 Or MapEvents(id).Graphic > NumCharacters Then Exit Sub

                ' Reset frame
                If MapEvents(id).Steps = 3 Then
                    anim = 0
                ElseIf MapEvents(id).Steps = 1 Then
                    anim = 2
                End If

                Select Case MapEvents(id).Dir
                    Case DirectionType.Up
                        If (MapEvents(id).YOffset > 8) Then anim = MapEvents(id).Steps
                    Case DirectionType.Down
                        If (MapEvents(id).YOffset < -8) Then anim = MapEvents(id).Steps
                    Case DirectionType.Left
                        If (MapEvents(id).XOffset > 8) Then anim = MapEvents(id).Steps
                    Case DirectionType.Right
                        If (MapEvents(id).XOffset < -8) Then anim = MapEvents(id).Steps
                End Select

                ' Set the left
                Select Case MapEvents(id).ShowDir
                    Case DirectionType.Up
                        spritetop = 3
                    Case DirectionType.Right
                        spritetop = 2
                    Case DirectionType.Down
                        spritetop = 0
                    Case DirectionType.Left
                        spritetop = 1
                End Select

                If MapEvents(id).WalkAnim = 1 Then anim = 0
                If MapEvents(id).Moving = 0 Then anim = MapEvents(id).GraphicX

                width = CharacterGfxInfo(MapEvents(id).Graphic).Width / 4
                height = CharacterGfxInfo(MapEvents(id).Graphic).Height / 4

                sRect = New Rectangle((anim) * (CharacterGfxInfo(MapEvents(id).Graphic).Width / 4), spritetop * (CharacterGfxInfo(MapEvents(id).Graphic).Height / 4), (CharacterGfxInfo(MapEvents(id).Graphic).Width / 4), (CharacterGfxInfo(MapEvents(id).Graphic).Height / 4))
                ' Calculate the X
                x = MapEvents(id).X * PicX + MapEvents(id).XOffset - ((CharacterGfxInfo(MapEvents(id).Graphic).Width / 4 - 32) / 2)

                ' Is the player's height more than 32..?
                If (CharacterGfxInfo(MapEvents(id).Graphic).Height * 4) > 32 Then
                    ' Create a 32 pixel offset for larger sprites
                    y = MapEvents(id).Y * PicY + MapEvents(id).YOffset - ((CharacterGfxInfo(MapEvents(id).Graphic).Height / 4) - 32)
                Else
                    ' Proceed as normal
                    y = MapEvents(id).Y * PicY + MapEvents(id).YOffset
                End If
                ' render the actual sprite
                DrawCharacterSprite(MapEvents(id).Graphic, x, y, sRect)
            Case 2
                If MapEvents(id).Graphic < 1 Or MapEvents(id).Graphic > NumTileSets Then Exit Sub
                If MapEvents(id).GraphicY2 > 0 Or MapEvents(id).GraphicX2 > 0 Then
                    With sRect
                        .X = MapEvents(id).GraphicX * 32
                        .Y = MapEvents(id).GraphicY * 32
                        .Width = MapEvents(id).GraphicX2 * 32
                        .Height = MapEvents(id).GraphicY2 * 32
                    End With
                Else
                    With sRect
                        .X = MapEvents(id).GraphicY * 32
                        .Height = .Top + 32
                        .Y = MapEvents(id).GraphicX * 32
                        .Width = .Left + 32
                    End With
                End If

                If TilesetGfxInfo(MapEvents(id).Graphic).IsLoaded = False Then
                    LoadTexture(MapEvents(id).Graphic, GfxType.Tileset)
                End If

                x = MapEvents(id).X * 32
                y = MapEvents(id).Y * 32
                x = x - ((sRect.Right - sRect.Left) / 2)
                y = y - (sRect.Bottom - sRect.Top) + 32

                If MapEvents(id).GraphicY2 > 1 Then
                    RenderTexture(MapEvents(id).Graphic, GfxType.Tileset, Window, ConvertMapX(MapEvents(id).X * PicX), ConvertMapY(MapEvents(id).Y * PicY) - PicY, sRect.Left, sRect.Top, sRect.Width, sRect.Height)
                Else
                    RenderTexture(MapEvents(id).Graphic, GfxType.Tileset, Window, ConvertMapX(MapEvents(id).X * PicX), ConvertMapY(MapEvents(id).Y * PicY), sRect.Left, sRect.Top, sRect.Width, sRect.Height)
                End If
        End Select

    End Sub


#End Region

#Region "Misc"

    Sub ProcessEventMovement(id As Integer)
        If Editor = EditorType.Map Then Exit Sub
        If id > Map.EventCount Then Exit Sub
        If id > MapEvents.Length Then Exit Sub

        If MapEvents(id).Moving = 1 Then
            Select Case MapEvents(id).Dir
                Case DirectionType.Up
                    MapEvents(id).YOffset = MapEvents(id).YOffset - ((ElapsedTime / 1000) * (MapEvents(id).MovementSpeed * SizeY))
                    If MapEvents(id).YOffset < 0 Then MapEvents(id).YOffset = 0
                Case DirectionType.Down
                    MapEvents(id).YOffset = MapEvents(id).YOffset + ((ElapsedTime / 1000) * (MapEvents(id).MovementSpeed * SizeY))
                    If MapEvents(id).YOffset > 0 Then MapEvents(id).YOffset = 0
                Case DirectionType.Left
                    MapEvents(id).XOffset = MapEvents(id).XOffset - ((ElapsedTime / 1000) * (MapEvents(id).MovementSpeed * SizeX))
                    If MapEvents(id).XOffset < 0 Then MapEvents(id).XOffset = 0
                Case DirectionType.Right
                    MapEvents(id).XOffset = MapEvents(id).XOffset + ((ElapsedTime / 1000) * (MapEvents(id).MovementSpeed * SizeX))
                    If MapEvents(id).XOffset > 0 Then MapEvents(id).XOffset = 0
            End Select
            ' Check if completed walking over to the next tile
            If MapEvents(id).Moving > 0 Then
                If MapEvents(id).Dir = DirectionType.Right Or MapEvents(id).Dir = DirectionType.Down Then
                    If (MapEvents(id).XOffset >= 0) And (MapEvents(id).YOffset >= 0) Then
                        MapEvents(id).Moving = 0
                        If MapEvents(id).Steps = 1 Then
                            MapEvents(id).Steps = 3
                        Else
                            MapEvents(id).Steps = 1
                        End If
                    End If
                Else
                    If (MapEvents(id).XOffset <= 0) And (MapEvents(id).YOffset <= 0) Then
                        MapEvents(id).Moving = 0
                        If MapEvents(id).Steps = 1 Then
                            MapEvents(id).Steps = 3
                        Else
                            MapEvents(id).Steps = 1
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Friend Function GetColorString(color As Integer)

        Select Case color
            Case 0
                GetColorString = "Black"
            Case 1
                GetColorString = "Blue"
            Case 2
                GetColorString = "Green"
            Case 3
                GetColorString = "Cyan"
            Case 4
                GetColorString = "Red"
            Case 5
                GetColorString = "Magenta"
            Case 6
                GetColorString = "Brown"
            Case 7
                GetColorString = "Grey"
            Case 8
                GetColorString = "Dark Grey"
            Case 9
                GetColorString = "Bright Blue"
            Case 10
                GetColorString = "Bright Green"
            Case 11
                GetColorString = "Bright Cyan"
            Case 12
                GetColorString = "Bright Red"
            Case 13
                GetColorString = "Pink"
            Case 14
                GetColorString = "Yellow"
            Case 15
                GetColorString = "White"
            Case Else
                GetColorString = "Black"
        End Select

    End Function

    Sub ClearEventChat()
        Dim i As Integer

        If AnotherChat = 1 Then
            For i = 1 To 4
                EventChoiceVisible(i) = False
            Next
            EventText = ""
            EventChatType = 1
            EventChatTimer = GetTickCount() + 100
        ElseIf AnotherChat = 2 Then
            For i = 1 To 4
                EventChoiceVisible(i) = False
            Next
            EventText = ""
            EventChatType = 1
            EventChatTimer = GetTickCount() + 100
        Else
            EventChat = False
        End If
    End Sub

#End Region

End Module