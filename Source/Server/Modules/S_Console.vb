Imports System.Threading
Imports Core

Module S_Console
    Private consoleExit As Boolean
    Private threadConsole As Thread

    Sub Main()
        threadConsole = New Thread(New ThreadStart(AddressOf ConsoleThread))
        threadConsole.Start()

        AddHandler AppDomain.CurrentDomain.ProcessExit, AddressOf ProcessExitHandler

        ' Spin up the server on the main thread
        InitServer()
    End Sub

    Private Sub ProcessExitHandler(ByVal sender As Object, ByVal e As EventArgs)
        UpdateSavePlayers()
        consoleExit = True
        threadConsole.Join()
    End Sub

    Private Sub ConsoleThread()
        Dim line As String, parts As String()

        Console.WriteLine("Initializing Console Loop")

        While (Not consoleExit)
            Try
                line = Console.ReadLine()
            Catch ex As Exception
                Exit While
            End Try

            parts = line.Split(" ") : If (parts.Length < 1) Then Continue While

            Select Case parts(0).Trim().ToLower()
                Case "/help"
#Region " Body "

                    Console.WriteLine("/help, Shows this message.")
                    Console.WriteLine("/exit, Closes down the server.")
                    Console.WriteLine("/access, Sets player access level, use with '/access playername level goes from 1 for Player, to 5 to Creator.")
                    Console.WriteLine("/kick, Kicks user from server, use with '/kick playername'")
                    Console.WriteLine("/ban, Bans user from server, use with '/ban playername'")
                    Console.WriteLine("/shutdown, Shuts down the server after 60 seconds or a value you specify")

#End Region

                Case "/shutdown"
#Region "Body"
                    If parts.Length < 2 Then
                        shutDownDuration = 60
                    Else
                        shutDownDuration = parts(1)
                    End If

                    If shutDownTimer.IsRunning Then
                        shutDownTimer.Stop()
                        shutDownDuration = 0
                        Console.WriteLine("Server shutdown has been cancelled!")
                        Call GlobalMsg("Server shutdown has been cancelled!")
                    Else
                        If shutDownTimer.ElapsedTicks > 0 Then
                            shutDownTimer.Restart()
                        Else
                            shutDownTimer.Start()
                        End If

                        Console.WriteLine("Server shutdown in " & shutDownDuration & " seconds!")
                        Call GlobalMsg("Server shutdown in " & shutDownDuration & " seconds!")
                    End If
#End Region

                Case "/exit"

#Region " Body "

                    DestroyServer()

#End Region

                Case "/access"
#Region "Body"
                    If parts.Length < 3 Then Continue While

                    Dim Name As String = parts(1)
                    Dim Pindex As Integer = FindPlayer(Name)
                    Dim Access As Integer : Integer.TryParse(parts(2), Access)

                    If Not Pindex > 0 Then
                        Console.WriteLine("Player name is empty or invalid. [Name not found]")
                    Else
                        Select Case Access
                            Case Core.AdminType.Player
                                SetPlayerAccess(Pindex, Access)
                                SendPlayerData(Pindex)
                                PlayerMsg(Pindex, "Your access has been set to Player!", ColorType.BrightCyan)
                                Console.WriteLine("Successfully set the access level to " & Access & " for player " & Name)
                            Case AdminType.Moderator
                                SetPlayerAccess(Pindex, Access)
                                SendPlayerData(Pindex)
                                PlayerMsg(Pindex, "Your access has been set to Moderator!", ColorType.BrightCyan)
                                Console.WriteLine("Successfully set the access level to " & Access & " for player " & Name)
                            Case AdminType.Mapper
                                SetPlayerAccess(Pindex, Access)
                                SendPlayerData(Pindex)
                                PlayerMsg(Pindex, "Your access has been set to Mapper!", ColorType.BrightCyan)
                                Console.WriteLine("Successfully set the access level to " & Access & " for player " & Name)
                            Case AdminType.Developer
                                SetPlayerAccess(Pindex, Access)
                                SendPlayerData(Pindex)
                                PlayerMsg(Pindex, "Your access has been set to Developer!", ColorType.BrightCyan)
                                Console.WriteLine("Successfully set the access level to " & Access & " for player " & Name)
                            Case AdminType.Creator
                                SetPlayerAccess(Pindex, Access)
                                SendPlayerData(Pindex)
                                PlayerMsg(Pindex, "Your access has been set to Creator!", ColorType.BrightCyan)
                                Console.WriteLine("Successfully set the access level to " & Access & " for player " & Name)
                            Case Else
                                Console.WriteLine("Failed to set the access level to " & Access & " for player " & Name)
                        End Select
                    End If

#End Region

                Case "/kick"
#Region "Body"
                    If parts.Length < 2 Then Continue While

                    Dim Name As String = parts(1)
                    Dim Pindex As Integer = FindPlayer(Name)
                    If Not Pindex > 0 Then
                        Console.WriteLine("Player name is empty or invalid.")
                    Else
                        AlertMsg(Pindex, DialogueMsg.KICKED)
                        LeftGame(Pindex)
                    End If
#End Region

                Case "/ban"
#Region "Body"
                    If parts.Length < 2 Then Continue While

                    Dim Name As String = parts(1)
                    Dim Pindex As Integer = FindPlayer(Name)
                    If Not Pindex > 0 Then : Console.WriteLine("Player name is empty or invalid. [Name not found]")
                    Else : ServerBanIndex(Pindex) : End If

#End Region

                Case "/timespeed"
#Region " Body "
                    If parts.Length < 2 Then Exit Sub

                    Dim speed As Double
                    Double.TryParse(parts(1), speed)
                    Core.Time.Instance.GameSpeed = speed
                    Types.Settings.TimeSpeed = speed
                    Settings.Save()
                    Console.WriteLine("Set GameSpeed to " & Core.Time.Instance.GameSpeed & " secs per seconds")

#End Region

                Case "" : Continue While
                Case Else : Console.WriteLine("Invalid Command. If you are unsure of the functions type '/help'.")
            End Select
        End While
    End Sub

End Module