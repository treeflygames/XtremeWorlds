Imports System.IO
Imports System.Xml.Serialization

Public Class Settings
    Public Language As String = "English"

    Public Username As String = ""
    Public SaveUsername As Boolean = False

    Public MenuMusic As String = "menu.mid"
    Public Music As Boolean = True
    Public Sound As Boolean = True
    Public Volume As Single = 100.0F

    Public MusicExt As String = ".mid"
    Public SoundExt As String = ".wav"

    Public Resolution As Byte = 13
    Public Vsync As Byte = 1
    Public ShowNpcBar As Byte = 1
    Public Fullscreen As Byte = 1
    Public CameraWidth As Byte = 32
    Public CameraHeight As Byte = 24
    Public OpenAdminPanelOnLogin As Byte = 1
    Public DynamicLightRendering As Byte = 1
    Public ChannelState(ChatChannel.Count - 1) As Byte
    Public Shadow As Byte = 0

    Public Ip As String = "127.0.0.1"
    Public Port As Integer = 7001

    <XmlIgnore()> Public GameName As String = "MirageWorlds"
    <XmlIgnore()> Public Website As String = "https://miragesource.net/"

    <XmlIgnore()> Public Version As String = "1.8.9"

    Public Welcome As String = "Welcome to MirageWorlds, enjoy your stay!"

    Public TimeSpeed As Integer = 1

    Public MaxFps As Integer = 60

    Public Autotile As Boolean = True

     Public Shared Sub Load()
        Dim configPath As String = Paths.Config()
        Dim configFile As String = Path.Combine(configPath, "Settings.xml")

        Directory.CreateDirectory(configPath)

        If Not File.Exists(configFile) Then
            Try
                Using writer As New StreamWriter(File.Create(configFile))
                    Dim serializer As New XmlSerializer(GetType(Settings), New XmlRootAttribute("Settings"))
                    serializer.Serialize(writer, New Settings()) ' Serialize default settings
                End Using
            Catch ex As IOException
                Console.WriteLine(ex.Message)
            Catch ex As UnauthorizedAccessException
                Console.WriteLine(ex.Message)
            End Try
        End If

        Try
            Using reader As New StreamReader(configFile)
                Dim serializer As New XmlSerializer(GetType(Settings), New XmlRootAttribute("Settings"))
                Types.Settings = CType(serializer.Deserialize(reader), Settings)
            End Using
        Catch ex As Exception
            Types.Settings = New Settings() ' Default to new settings if reading fails
        End Try
    End Sub

    Public Shared Sub Save()
        Dim configPath As String = Paths.Config()
        Dim configFile As String = Path.Combine(configPath, "Settings.xml")

        Directory.CreateDirectory(configPath)

        Try
            Using writer = New StreamWriter(configFile)
                Dim serializer As New XmlSerializer(GetType(Settings), New XmlRootAttribute("Settings"))
                serializer.Serialize(writer, Types.Settings)
            End Using
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
End Class
