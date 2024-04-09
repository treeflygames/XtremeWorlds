Namespace Types.Components
    Public Class Leveling
        Public Property Level As Integer
        Public Property Experience As Integer

        Public Sub New()
            Me.Level = 1
            Me.Experience = 0
        End Sub

        Public Sub New(level As Integer, experience As Integer)
            Me.Level = Math.Max(level, 1)
            Me.Experience = experience
        End Sub

        Public Function GetLevel() As Integer
            Return Me.Level
        End Function

        Public Sub SetLevel(ByVal value As Integer)
            Me.Level = Math.Max(value, 1)
        End Sub

        Public Function GetExperience() As Integer
            Return Me.Experience
        End Function

        Public Sub SetExperience(ByVal value As Integer)
            Me.Experience = Math.Max(value, 1)
        End Sub

        Public Function CalculateNextLevel() As Integer
            Return CalculateNextLevel(Me.Level)
        End Function

        Public Shared Function CalculateNextLevel(ByVal level As Integer) As Integer
            Return 50 / 3 * (((level + 1) ^ 3) - (6 * ((level + 1) ^ 2)) + (17 * (level + 1)) - 12)
        End Function

        Public Sub AddExperience(ByVal value As Integer)
            Me.Experience += value

            If Me.Experience >= Me.CalculateNextLevel() Then
                Dim tmpExperience = Me.GetExperience()
                Dim tmpLevel = Me.GetLevel()
                Dim levels As Integer = 0

                Do While tmpExperience >= Me.CalculateNextLevel()
                    tmpExperience -= Me.CalculateNextLevel()
                    tmpLevel += 1
                    levels += 1
                Loop

                Me.Experience = tmpExperience
                Me.Level = tmpLevel
            End If
        End Sub

        Public Sub RemoveExperience(ByVal value As Integer)
            Me.Experience -= value

            If Me.Experience < 0 Then
                Dim tmpExperience = Me.GetExperience()
                Dim tmpLevel = Me.GetLevel()
                Dim levels As Integer = 0

                Do While tmpExperience < 0
                    tmpExperience += CalculateNextLevel(tmpLevel - 1)
                    tmpLevel -= 1
                    levels -= 1
                Loop

                Me.Experience = tmpExperience
                Me.Level = tmpLevel
            End If
        End Sub
    End Class
End Namespace