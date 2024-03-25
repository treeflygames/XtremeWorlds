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
    Public CameraType As Byte = 0
    Public Fullscreen As Byte = 1
    Public CameraWidth As Byte = 32
    Public CameraHeight As Byte = 24
    Public OpenAdminPanelOnLogin As Byte = 1
    Public DynamicLightRendering As Byte = 1
    Public ChannelState(ChatChannel.Count - 1) As Byte

    Public Ip As String = "127.0.0.1"
    Public Port As Integer = 7001

    <XmlIgnore()> Public GameName As String = "MirageWorlds"
    <XmlIgnore()> Public Website As String = "https://giamon.com/"

    <XmlIgnore()> Public Version As String = "1.6.2"

    Public Welcome As String = "Welcome to MirageWorlds, enjoy your stay!"

    Public TimeSpeed As Integer = 1

    Public MaxFps As Integer = 60

    Public Autotile As Boolean = True

    Public Shared Sub Load()
        Dim cf As String = Paths.Config()
        Dim x As New XmlSerializer(GetType(Settings), New XmlRootAttribute("Settings"))

        Directory.CreateDirectory(cf)
        cf += "Settings.xml"

        If Not File.Exists(cf) Then
            File.Create(cf).Dispose()
            Dim writer = New StreamWriter(cf)
            x.Serialize(writer, New Settings)
            writer.Close()
        End If

        Try
            Dim reader = New StreamReader(cf)
            Types.Settings = x.Deserialize(reader)
            reader.Close()
        Catch ex As Exception
            Types.Settings = New Settings()
        End Try
    End Sub

    Public Shared Sub Save()
        Dim cf As String = Paths.Config()

        Directory.CreateDirectory(cf)
        cf += "Settings.xml"

        Dim x As New XmlSerializer(GetType(Settings), New XmlRootAttribute("Settings"))
        Try
            Using writer = New StreamWriter(cf)
                x.Serialize(writer, Types.Settings)
            End Using ' This ensures the writer is properly disposed and the file is closed
        Catch ex As Exception
            Threading.Thread.Sleep(1000) ' Wait for 1 second
            File.Delete(cf)
        End Try

    End Sub
End Class
