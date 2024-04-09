Imports Mirage.Core.Database.Types.Enumerations

Namespace Types.Components
    Public Class Stats
        Public Property Strength As Integer
        Public Property Vitality As Integer
        Public Property Luck As Integer
        Public Property Intelligence As Integer
        Public Property Spirit As Integer

        Public Property Points As Integer

        Public Sub New()
            Me.Strength = 0
            Me.Vitality = 0
            Me.Luck = 0
            Me.Intelligence = 0
            Me.Spirit = 0
        End Sub

        Public Sub New(strength As Integer, vitality As Integer, luck As Integer, intelligence As Integer, spirit As Integer)
            Me.Strength = strength
            Me.Vitality = vitality
            Me.Luck = luck
            Me.Intelligence = intelligence
            Me.Spirit = spirit
        End Sub

        Public Function GetStat(ByVal stat As Stat) As Integer
            Select Case stat
                Case Stat.Strength
                    Return Me.Strength
                Case Stat.Vitality
                    Return Me.Vitality
                Case Stat.Luck
                    Return Me.Luck
                Case Stat.Intelligence
                    Return Me.Intelligence
                Case Stat.Spirit
                    Return Me.Spirit
                Case Stat.All
                    Return Me.Strength + Me.Vitality + Me.Luck + Me.Intelligence + Me.Spirit
                Case Else
                    Return -0
            End Select
        End Function

        Public Sub SetStat(ByVal stat As Stat, ByVal value As Integer)
            Select Case stat
                Case Stat.Strength
                    Me.Strength = value
                Case Stat.Vitality
                    Me.Vitality = value
                Case Stat.Luck
                    Me.Luck = value
                Case Stat.Intelligence
                    Me.Intelligence = value
                Case Stat.Spirit
                    Me.Spirit = value
                Case Stat.All
                    Me.Strength = value
                    Me.Vitality = value
                    Me.Luck = value
                    Me.Intelligence = value
                    Me.Spirit = value
            End Select
        End Sub

        Public Function GetPoints() As Integer
            Return Me.Points
        End Function

        Public Sub SetPoints(ByVal value As Integer)
            Me.Points = value
        End Sub
    End Class
End Namespace