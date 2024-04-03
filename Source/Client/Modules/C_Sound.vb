Imports System.IO
Imports SFML.Audio
Imports Core
Imports System.Runtime.Intrinsics.X86
Imports Core.Paths

Module C_Sound

    'Music + Sound Players
    Friend SoundPlayer As Sound

    Friend ExtraSoundPlayer As Sound
    Friend MusicPlayer As Music
    Friend PreviewPlayer As Music
    Friend MusicCache() As String
    Friend SoundCache() As String

    Friend FadeInSwitch As Boolean
    Friend FadeOutSwitch As Boolean
    Friend CurrentMusic As String
    Friend MaxVolume As Single

    Sub PlayMusic(fileName As String)
        if fileName = "None" Then
            Exit Sub
        End If

        If Types.Settings.Music = False Or Not File.Exists(Paths.Music & fileName) Then
            StopMusic()
            Exit Sub
        End If

        if fileName = CurrentMusic Then
            Exit Sub
        End If

        If Types.Settings.MusicExt = ".mid" Then
            MidiPlayer.Dispose()
            MidiPlayer.Load(Paths.Music & fileName)
            MidiPlayer.Play()
            CurrentMusic = fileName
            Exit Sub
        End If

        Dim luaVolume As Single = Convert.ToSingle(LuaScripting.Instance().ExecuteScript("AdjustMusicVolume", Types.Settings.Volume)(0))

        Try
            If MusicPlayer Is Nothing Then
                MusicPlayer = New Music(Paths.Music & fileName)
                MusicPlayer.Loop() = True
                MusicPlayer.Volume() = luaVolume
                MusicPlayer.Play()
                CurrentMusic = fileName
                FadeInSwitch = True
            Else
                CurrentMusic = fileName
                FadeOutSwitch = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub StopMusic()
        If Not MusicPlayer Is Nothing Then
            MusicPlayer.Stop()
            MusicPlayer.Dispose()
            MusicPlayer = Nothing
            CurrentMusic = ""
        End If

        If MidiPlayer.midiSequence Is Nothing Or MidiPlayer.midiSequencer Is Nothing Then
            Exit Sub
        Else
            MidiPlayer.Dispose()
            CurrentMusic = ""
        End If
    End Sub

    Sub PlayPreview(fileName As String)
        If Types.Settings.Music = 0 Or Not File.Exists(Paths.Music & fileName) Then Exit Sub

        If PreviewPlayer Is Nothing Then
            Try
                PreviewPlayer = New Music(Paths.Music & fileName)
                PreviewPlayer.Loop() = True
                PreviewPlayer.Volume() = Types.Settings.Volume
                PreviewPlayer.Play()
            Catch ex As Exception

            End Try
        Else
            Try
                StopPreview()
                PreviewPlayer = New Music(Paths.Music & fileName)
                PreviewPlayer.Loop() = True
                PreviewPlayer.Volume() = Types.Settings.Volume
                PreviewPlayer.Play()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Sub StopPreview()
        If PreviewPlayer Is Nothing Then Exit Sub
        PreviewPlayer.Stop()
        PreviewPlayer.Dispose()
        PreviewPlayer = Nothing
    End Sub

    Sub PlaySound(fileName As String, Optional looped As Boolean = False)
        If Types.Settings.Sound = 0 Or Not File.Exists(Paths.Sounds & fileName) Then Exit Sub

        Dim buffer As SoundBuffer
        If SoundPlayer Is Nothing Then
            SoundPlayer = New Sound()
            buffer = New SoundBuffer(Paths.Sounds & fileName)
            SoundPlayer.SoundBuffer = buffer
            If looped = True Then
                SoundPlayer.Loop() = True
            Else
                SoundPlayer.Loop() = False
            End If
            SoundPlayer.Volume() = MaxVolume
            SoundPlayer.Play()
        Else
            SoundPlayer.Stop()
            buffer = New SoundBuffer(Paths.Sounds & fileName)
            SoundPlayer.SoundBuffer = buffer
            If looped = True Then
                SoundPlayer.Loop() = True
            Else
                SoundPlayer.Loop() = False
            End If
            SoundPlayer.Volume() = MaxVolume
            SoundPlayer.Play()
        End If
    End Sub

    Sub StopSound()
        If SoundPlayer Is Nothing Then Exit Sub
        SoundPlayer.Dispose()
        SoundPlayer = Nothing
    End Sub

    Sub PlayExtraSound(fileName As String, Optional looped As Boolean = False)
        If Types.Settings.Sound = 0 Or Not File.Exists(Paths.Sounds & fileName) Then Exit Sub

        Dim buffer As SoundBuffer
        If ExtraSoundPlayer Is Nothing Then
            ExtraSoundPlayer = New Sound()
            buffer = New SoundBuffer(Paths.Sounds & fileName)
            ExtraSoundPlayer.SoundBuffer = buffer
            If looped = True Then
                ExtraSoundPlayer.Loop() = True
            Else
                ExtraSoundPlayer.Loop() = False
            End If
            ExtraSoundPlayer.Volume() = MaxVolume
            ExtraSoundPlayer.Play()
        Else
            ExtraSoundPlayer.Stop()
            buffer = New SoundBuffer(Paths.Sounds & fileName)
            ExtraSoundPlayer.SoundBuffer = buffer
            If looped = True Then
                ExtraSoundPlayer.Loop() = True
            Else
                ExtraSoundPlayer.Loop() = False
            End If
            ExtraSoundPlayer.Volume() = MaxVolume
            ExtraSoundPlayer.Play()
        End If
    End Sub

    Sub StopExtraSound()
        If ExtraSoundPlayer Is Nothing Then Exit Sub
        ExtraSoundPlayer.Dispose()
        ExtraSoundPlayer = Nothing
    End Sub

    Sub FadeIn()

        If MusicPlayer Is Nothing Then Exit Sub

        If MusicPlayer.Volume() >= MaxVolume Then FadeInSwitch = False
        MusicPlayer.Volume() = MusicPlayer.Volume() + 3

    End Sub

    Sub FadeOut()
        Dim tmpmusic As String
        If MusicPlayer Is Nothing Then Exit Sub

        If MusicPlayer.Volume() = 0 Or MusicPlayer.Volume() < 3 Then
            FadeOutSwitch = False
            If CurrentMusic = "" Then
                StopMusic()
            Else
                tmpmusic = CurrentMusic
                StopMusic()
                PlayMusic(tmpmusic)
            End If
        End If
        If MusicPlayer Is Nothing Then Exit Sub

        MusicPlayer.Volume() = MusicPlayer.Volume() - 3

    End Sub

End Module