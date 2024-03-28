Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Numerics
Imports Core
Imports Core.Database
Imports Microsoft.EntityFrameworkCore
Imports Mirage.Core.Database.DbContexts
Imports Newtonsoft.Json.Linq

Module S_General
    Friend ServerDestroyed As Boolean
    Friend MyIPAddress As String
    Friend myStopWatch As New Stopwatch()
    Friend shutDownTimer As New Stopwatch()
    Friend shutDownLastTimer As Integer
    Friend shutDownDuration As Integer

    Friend Function GetTimeMs() As Integer
        Return myStopWatch.ElapsedMilliseconds
    End Function

    Sub InitServer()
        Dim i As Integer, F As Integer, x As Integer
        Dim time1 As Integer, time2 As Integer

        myStopWatch.Start()

        Settings.Load()

        Core.Time.Instance.GameSpeed = Types.Settings.TimeSpeed

        Console.Title = "MirageWorlds Server"

        time1 = GetTimeMs()

        ' Check if the directory is there, if its not make it
        CheckDir(Paths.Database)
        CheckDir(Paths.Jobs)
        CheckDir(Paths.Items)
        CheckDir(Paths.Maps)
        CheckDir(Paths.Npcs)
        CheckDir(Paths.Shops)
        CheckDir(Paths.Skills)
        CheckDir(Paths.Accounts)
        CheckDir(Paths.Resources)
        CheckDir(Paths.Animations)
        CheckDir(Paths.Logs)
        CheckDir(Paths.Pets)
        CheckDir(Paths.Projectiles)

        EKeyPair.GenerateKeys()
        InitNetwork()

        Console.WriteLine("Creating Database...")
        DatabaseContext = New MirageDbContext()
        DatabaseContext.Database.Migrate()
        CreateDatabase("mirage")

        Console.WriteLine("Creating Tables...")
        CreateTables()

        ClearGameData()
        LoadGameData()

        Console.WriteLine("Spawning Map Items...")
        SpawnAllMapsItems()
        Console.WriteLine("Spawning Map NPCs...")
        SpawnAllMapNpcs()

        InitTime()

        UpdateCaption()
        time2 = GetTimeMs()

        Console.Clear()
        Console.WriteLine("___  ____                       _    _            _     _     ")
        Console.WriteLine("|  \/  (_)                     | |  | |          | |   | |    ")
        Console.WriteLine("| .  . |_ _ __ __ _  __ _  ___ | |  | | ___  _ __| | __| |___ ")
        Console.WriteLine("| |\/| | | '__/ _` |/ _` |/ _ \| |/\| |/ _ \| '__| |/ _` / __|")
        Console.WriteLine("| |  | | | | | (_| | (_| |  __/\  /\  / (_) | |  | | (_| \__ \")
        Console.WriteLine("\_|  |_/_|_|  \__,_|\__, |\___| \/  \/ \___/|_|  |_|\__,_|___/")
        Console.WriteLine("                     __/ |                                    ")
        Console.WriteLine("                    |___/                                     ")

        Console.WriteLine("Initialization complete. Server loaded in " & time2 - time1 & "ms.")
        Console.WriteLine("")
        Console.WriteLine("Use /help for the available commands.")

        UpdateCaption()

        ' Start listener now that everything is loaded
        Socket.StartListening(Types.Settings.Port, 5)

        ' Starts the server loop
        ServerLoop()

    End Sub

    Private Function ConsoleEventCallback(eventType As Integer) As Boolean
        If eventType = 2 Then
            Console.WriteLine("Console window closing, death imminent")
            'cleanup and close
            DestroyServer()
        End If
    End Function

    Private handler As ConsoleEventDelegate

    ' Keeps it from getting garbage collected
    ' Pinvoke
    Private Delegate Function ConsoleEventDelegate(eventType As Integer) As Boolean

    Sub UpdateCaption()
        Try
            Console.Title = String.Format("{0} <IP {1}:{2}> ({3} Players Online) - Current Errors: {4} - Time: {5}", Types.Settings.GameName, MyIPAddress, Types.Settings.Port, Socket.HighIndex(), ErrorCount, Core.Time.Instance.ToString())
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Sub DestroyServer()
        Socket.StopListening()

        Console.WriteLine("Saving players online...")
        SaveAllPlayersOnline()

        Console.WriteLine("Unloading players...")
        For i As Integer = 1 To MAX_PLAYERS
            SendLeftGame(i)
            LeftGame(i)
        Next

        DestroyNetwork()
        ClearGameData()

        Environment.Exit(0)
    End Sub

    Friend Sub ClearGameData()
        Dim i As Integer

        ' Init all the player sockets
        Console.WriteLine("Clearing Players...")

        For i = 1 To MAX_PLAYERS
            ClearAccount(i)
            ClearPlayer(i)
        Next

        ClearParty()

        Console.WriteLine("Clearing Jobs...") : ClearJobs()
        Console.WriteLine("Clearing Morals...") : ClearMorals()
        Console.WriteLine("Clearing Maps...") : ClearMaps()
        Console.WriteLine("Clearing Map Items...") : ClearMapItems()
        Console.WriteLine("Clearing Map NPC's...") : ClearAllMapNpcs()
        Console.WriteLine("Clearing NPC's...") : ClearNpcs()
        Console.WriteLine("Clearing Resources...") : ClearResources()
        Console.WriteLine("Clearing Items...") : ClearItems()
        Console.WriteLine("Clearing Shops...") : ClearShops()
        Console.WriteLine("Clearing Skills...") : ClearSkills()
        Console.WriteLine("Clearing Animations...") : ClearAnimations()
        Console.WriteLine("Clearing Map Projectiles...") : ClearMapProjectile()
        Console.WriteLine("Clearing Projectiles...") : ClearProjectile()
        Console.WriteLine("Clearing Pets...") : ClearPets()
    End Sub

    Private Sub LoadGameData()
        Console.WriteLine("Loading Jobs...") : LoadJobs()
        Console.WriteLine("Loading Morals...") : LoadMorals()
        Console.WriteLine("Loading Maps...") : LoadMaps()
        Console.WriteLine("Loading Items...") : LoadItems()
        Console.WriteLine("Loading NPCs...") : LoadNpcs()
        Console.WriteLine("Loading Resources...") : LoadResources()
        Console.WriteLine("Loading Shops...") : LoadShops()
        Console.WriteLine("Loading Skills...") : LoadSkills()
        Console.WriteLine("Loading Animations...") : LoadAnimations()
        Console.WriteLine("Loading Switches...") : LoadSwitches()
        Console.WriteLine("Loading Variables...") : LoadVariables()
        Console.WriteLine("Spawning Global Events...") : SpawnAllMapGlobalEvents()
        Console.WriteLine("Loading Projectiles...") : LoadProjectiles()
        Console.WriteLine("Loading Pets...") : LoadPets()
    End Sub

    ' Used for checking validity of names
    Function IsNameLegal(sInput As Integer) As Boolean
        If (sInput >= 65 AndAlso sInput <= 90) OrElse (sInput >= 97 AndAlso sInput <= 122) OrElse (sInput = 95) OrElse (sInput = 32) OrElse (sInput >= 48 AndAlso sInput <= 57) Then
            Return True
        Else
            Return False
        End If
    End Function

    Friend Sub CheckDir(path As String)
        If Not Directory.Exists(path) Then Directory.CreateDirectory(path)
    End Sub

    Sub ErrorHandler(sender As Object, args As UnhandledExceptionEventArgs)
        Dim e As Exception = DirectCast(args.ExceptionObject, Exception)
        Dim myFilePath As String = Paths.Logs & "Errors.log"

        Using sw As New StreamWriter(File.Open(myFilePath, FileMode.Append))
            sw.WriteLine(DateTime.Now)
            sw.WriteLine(GetExceptionInfo(e))
        End Using

        ErrorCount = ErrorCount + 1

        UpdateCaption()
    End Sub

    Friend Function GetExceptionInfo(ex As Exception) As String
        Dim Result As String
        Dim hr As Integer = Runtime.InteropServices.Marshal.GetHRForException(ex)
        Result = ex.GetType.ToString & "(0x" & hr.ToString("X8") & "): " & ex.Message & Environment.NewLine & ex.StackTrace & Environment.NewLine
        Dim st As New StackTrace(ex, True)
        For Each sf As StackFrame In st.GetFrames
            If sf.GetFileLineNumber() > 0 Then
                Result &= "Line:" & sf.GetFileLineNumber() & " Filename: " & Path.GetFileName(sf.GetFileName) & Environment.NewLine
            End If
        Next
        Return Result
    End Function

    Friend Sub AddDebug(Msg As String)
        If DebugTxt = True Then
            Addlog(Msg, PACKET_LOG)
            Console.WriteLine(Msg)
        End If
    End Sub

    Friend Sub CheckShutDownCountDown()
        If shutDownDuration > 0 Then
            Dim time As Integer = shutDownTimer.Elapsed.Seconds

            If shutDownLastTimer <> time Then
                If shutDownDuration - time <= 10 Then
                    S_NetworkSend.GlobalMsg("Server shutdown in " & (shutDownDuration - time) & " seconds!")
                    Console.WriteLine("Server shutdown in " & (shutDownDuration - time) & " seconds!")
                End If

                If (shutDownDuration - time) = 1 Then
                    DestroyServer()
                End If

                shutDownLastTimer = time
            End If    
        End If
End Sub

End Module