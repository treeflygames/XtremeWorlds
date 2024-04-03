Imports Core

Module C_General
    Friend Function GetTickCount() As Integer
        Return Environment.TickCount
    End Function

    Sub Startup()
        InMenu = True
        ClearGameData()
        LoadGame()
        GameLoop()
    End Sub

    Friend Sub LoadGame()
        Settings.Load()
        Languages.Load()
        Inputs.Load()
        MidiPlayer.Initialize()
        LoadGraphics()
        InitNetwork()
        InitInterface()
        Ping = -1
    End Sub

    Function GetResolutionSize(Resolution As Byte, ByRef Width As Long, ByRef Height As Long)
        Select Case Resolution
            Case 1
                Width = 1920
                Height = 1080
            Case 2
                Width = 1680
                Height = 1050
            Case 3
                Width = 1600
                Height = 900
            Case 4
                Width = 1440
                Height = 900
            Case 5
                Width = 1440
                Height = 1050
            Case 6
                Width = 1366
                Height = 768
            Case 7
                Width = 1360
                Height = 1024
            Case 8
                Width = 1360
                Height = 768
            Case 9
                Width = 1280
                Height = 1024
            Case 10
                Width = 1280
                Height = 800
            Case 11
                Width = 1280
                Height = 768
            Case 12
                Width = 1280
                Height = 720
            Case 13
                Width = 1024
                Height = 768
        End Select
    End Function

    Friend Sub LoadGraphics()
        Started = True
        CheckPaths()
        InitGraphics()
    End Sub

    Friend Sub ClearGameData()
        ClearMap()
        ClearMapNpcs()
        ClearMapItems()
        ClearNpcs()
        ClearResources()
        ClearItems()
        ClearShops()
        ClearSkills()
        ClearAnimations()
        ClearProjectile()
        ClearPets()
        ClearJobs()
        ClearMorals()
        ClearBank()
        ClearParty()

        For i = 1 To MAX_PLAYERS
            ClearPlayer(i)
        Next

        ClearAnimInstances()
        ClearAutotiles()
    End Sub

    Friend Sub CheckPaths()
        CacheMusic()
        CacheSound()
        CheckAnimations()
        CheckCharacters()
        CheckEmotes()
        CheckFog()
        CheckItems()
        CheckPanoramas()
        CheckPaperdolls()
        CheckParallax()
        CheckPictures()
        CheckProjectile()
        CheckResources()
        CheckSkills()
        CheckTilesets()
        ChecKInterface()
        CheckGradients()
        CheckDesigns()
    End Sub

    Sub GameInit()
        ' Send a request to the server to open the admin menu if the user wants it.
        If Types.Settings.OpenAdminPanelOnLogin = 1 Then
            If GetPlayerAccess(MyIndex) > 0 Then
                SendRequestAdmin()
            End If
        End If
    End Sub

    Friend Function ConnectToServer(i As Integer) As Boolean
        Dim until As Integer
        ConnectToServer = False

        ' Check to see if we are already connected, if so just exit
        If Socket.IsConnected() Then
            ConnectToServer = True
            Exit Function
        End If

        If i = 4 Then Exit Function
        until = GetTickCount() + 3500

        Connect()

        ' Wait until connected or a few seconds have passed and report the server being down
        Do While (Not Socket.IsConnected()) And (GetTickCount() <= until)
            Application.DoEvents()
        Loop

        ' return value
        If Socket.IsConnected() Then
            ConnectToServer = True
        End If

        If Not ConnectToServer Then
            ConnectToServer(i + 1)
        End If

    End Function

    Friend Sub DestroyGame()
        ' break out of GameLoop
        InGame = False
        Application.Exit()
        End
    End Sub

    Friend Function GetExceptionInfo(ex As Exception) As String
        Dim result As String
        Dim hr As Integer = Runtime.InteropServices.Marshal.GetHRForException(ex)
        result = ex.GetType.ToString & "(0x" & hr.ToString("X8") & "): " & ex.Message & Environment.NewLine & ex.StackTrace & Environment.NewLine
        Dim st As StackTrace = New StackTrace(ex, True)
        For Each sf As StackFrame In st.GetFrames
            If sf.GetFileLineNumber() > 0 Then
                result &= "Line:" & sf.GetFileLineNumber() & " Filename: " & IO.Path.GetFileName(sf.GetFileName) & Environment.NewLine
            End If
        Next
        Return result
    End Function

End Module