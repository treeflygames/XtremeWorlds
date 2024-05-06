Imports Core

Module S_GameLogic
    Function GetTotalMapPlayers(mapNum As Integer) As Integer
        Dim i As Integer, n As Integer
        n = 0

        For i = 1 To Socket.HighIndex()
            If GetPlayerMap(i) = mapNum Then
                n = n + 1
            End If
        Next

        GetTotalMapPlayers = n
    End Function

    Function GetNpcMaxVital(NpcNum As Integer, Vital As [Enum].VitalType) As Integer
        GetNpcMaxVital = 0

        ' Prevent subscript out of range
        If NpcNum <= 0 Or NpcNum > MAX_NPCS Then Exit Function

        Select Case Vital
            Case VitalType.HP
                GetNpcMaxVital = NPC(NpcNum).HP
            Case VitalType.SP
                GetNpcMaxVital = NPC(NpcNum).Stat(StatType.Intelligence) * 2
            Case VitalType.SP
                GetNpcMaxVital = NPC(NpcNum).Stat(StatType.Spirit) * 2
        End Select

    End Function

    Function FindPlayer(Name As String) As Integer
        Dim i As Integer

        For i = 1 To Socket.HighIndex()
            ' Trim and convert both names to uppercase for case-insensitive comparison
            If UCase$(Trim$(GetPlayerName(i))) = UCase$(Trim$(Name)) Then
                FindPlayer = i
                Exit Function
            End If
        Next

        FindPlayer = 0
    End Function

    Friend Function Random(low As Int32, high As Int32) As Integer
        Static randomNumGen As New Random
        Return randomNumGen.Next(low, high + 1)
    End Function

    Friend Function CheckGrammar(Word As String, Optional Caps As Byte = 0) As String
        Dim FirstLetter As String

        FirstLetter = LCase$(Left$(Word, 1))

        If FirstLetter = "$" Then
            CheckGrammar = (Mid$(Word, 2, Len(Word) - 1))
            Exit Function
        End If

        If FirstLetter Like "*[aeiou]*" Then
            If Caps Then CheckGrammar = "An " & Word Else CheckGrammar = "an " & Word
        Else
            If Caps Then CheckGrammar = "A " & Word Else CheckGrammar = "a " & Word
        End If
    End Function

End Module