Imports System.Windows.Forms
Imports SFML.Window

Public Structure ChatCursor
    Friend X As Integer
    Friend Y As Integer
End Structure

Public Structure ChatData
    Friend Active As Boolean
    Friend HistoryLimit As Integer
    Friend MessageLimit As Integer

    Friend History As List(Of String)
    Friend CachedMessage As String
    Friend CurrentMessage As String
    Friend Cursor As ChatCursor

    Friend Function ProcessCharacter(ByRef evt As SFML.Window.TextEventArgs) As Boolean
        If Not Active Then
            Return False
        End If

        If CurrentMessage Is Nothing Then CurrentMessage = ""

        Select Case evt.Unicode
            Case ChrW(&H8) ' Backspace key
                ' Ignore backspace in this function, handle it in ProcessKey
                Exit Select

            Case Else
                CurrentMessage += evt.Unicode
                If CurrentMessage.Length > MessageLimit Then
                    CurrentMessage = CurrentMessage.Substring(0, MessageLimit)
                End If
        End Select

        Return True
    End Function


    Friend Function ProcessKey(ByRef e As SFML.Window.KeyEventArgs) As Boolean
        If Not Active Then
            If e.Code = SFML.Window.Keyboard.Key.Enter Then
                Active = True
                Return True
            End If
            Return False
        End If

        If CurrentMessage Is Nothing Then CurrentMessage = ""

        Select Case e.Code
            Case SFML.Window.Keyboard.Key.Enter
                History.Add(CurrentMessage)
                If History.Count > HistoryLimit Then
                    History.RemoveRange(0, History.Count - HistoryLimit)
                End If
                Cursor.Y = History.Count
                Active = False

            Case SFML.Window.Keyboard.Key.Backspace
                If CurrentMessage.Length > 0 Then
                    CurrentMessage = CurrentMessage.Remove(CurrentMessage.Length - 1)
                End If

            Case SFML.Window.Keyboard.Key.Left
                Cursor.X = Math.Max(0, Cursor.X - 1)

            Case SFML.Window.Keyboard.Key.Right
                Cursor.X = Math.Min(CurrentMessage.Length, Cursor.X + 1)

            Case SFML.Window.Keyboard.Key.Down
                If History.Count = 0 Then Exit Select
                Cursor.Y = Math.Min(History.Count, Cursor.Y + 1)
                CurrentMessage = If(Cursor.Y = History.Count, CachedMessage, History(Cursor.Y))

            Case SFML.Window.Keyboard.Key.Up
                If History.Count = 0 Then Exit Select
                If Cursor.Y = History.Count Then
                    CachedMessage = CurrentMessage
                End If
                Cursor.Y = Math.Max(0, Cursor.Y - 1)
                CurrentMessage = History(Cursor.Y)

            Case SFML.Window.Keyboard.Key.V
                If SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.LControl) OrElse
                   SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.RControl) Then
                    CurrentMessage += Clipboard.Contents()
                End If

            Case Else
                ' Handle other keys if needed
        End Select

        Return True
    End Function


End Structure

Module ChatModule
    Friend ChatInput As ChatData = New ChatData With {.Active = False, .HistoryLimit = 10, .MessageLimit = 100, .History = New List(Of String)(.HistoryLimit + 1), .CurrentMessage = "", .Cursor = New ChatCursor() With {.X = 0, .Y = 0}}
End Module