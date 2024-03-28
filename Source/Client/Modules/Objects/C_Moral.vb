Imports Core
Imports Mirage.Sharp.Asfw

Friend Module C_Moral
#Region "Database"

    Friend Sub ClearMoral(index As Integer)
        Moral(index) = Nothing

        Moral(index).Name = ""
        Moral_Loaded(index) = False
    End Sub

    Sub ClearMorals()
        Dim i As Integer

        ReDim Moral(MAX_MORALS)

        For i = 1 To MAX_MORALS
            ClearMoral(i)
        Next
    End Sub

    Friend Sub ClearChangedMoral()
        ReDim Moral_Changed(MAX_MORALS)
    End Sub

    Friend Sub StreamMoral(moralNum As Integer)
        If moralnum > 0 and Moral(moralNum).Name = "" Or Moral_Loaded(moralNum) = False Then
            Moral_Loaded(moralNum) = True
            SendRequestMoral(moralNum)
        End If
    End Sub

#End Region

#Region "Incoming Packets"

#End Region
End Module
