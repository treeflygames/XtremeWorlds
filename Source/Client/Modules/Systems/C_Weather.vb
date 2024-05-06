Imports System.IO
Imports Core
Imports SFML.Audio
Imports SFML.Graphics
Imports SFML.System

Friend Module C_Weather

#Region "Types and Globals"

    Friend Const MaxWeatherParticles As Integer = 100

    Friend WeatherParticle(MaxWeatherParticles) As WeatherParticleRec
    Friend WeatherSoundPlayer As Sound
    Friend CurWeatherMusic As String

    Public Structure WeatherParticleRec
        Dim Type As Integer
        Dim X As Integer
        Dim Y As Integer
        Dim Velocity As Integer
        Dim InUse As Integer
    End Structure

    Friend FogOffsetX As Integer
    Friend FogOffsetY As Integer

    Friend CurrentWeather As Integer
    Friend CurrentWeatherIntensity As Integer
    Friend CurrentFog As Integer
    Friend CurrentFogSpeed As Integer
    Friend CurrentFogOpacity As Integer
    Friend CurrentTintR As Integer
    Friend CurrentTintG As Integer
    Friend CurrentTintB As Integer
    Friend CurrentTintA As Integer
    Friend DrawThunder As Integer

#End Region

#Region "Drawing"

    Friend Sub DrawThunderEffect()

        If DrawThunder > 0 Then
            Dim tmpSprite As Sprite
            tmpSprite = New Sprite(New Texture(New SFML.Graphics.Image(Window.Size.X, Window.Size.Y, SFML.Graphics.Color.White))) With {
                .Color = New Color(255, 255, 255, 150),
                .TextureRect = New IntRect(0, 0, Window.Size.X, Window.Size.Y),
                .Position = New Vector2f(0, 0)
            }

            Window.Draw(tmpSprite) '

            DrawThunder = DrawThunder - 1

            tmpSprite.Dispose()
        End If
    End Sub

    Friend Sub DrawWeather()
        Dim i As Integer, spriteLeft As Integer

        For i = 1 To MaxWeatherParticles
            If WeatherParticle(i).InUse Then
                If WeatherParticle(i).Type = Weather.Storm Then
                    spriteLeft = 0
                Else
                    spriteLeft = WeatherParticle(i).Type - 1
                End If

                RenderTexture(WeatherSprite, Window, ConvertMapX(WeatherParticle(i).X), ConvertMapY(WeatherParticle(i).Y), spriteLeft * 32, 0, 32, 32, 32, 32)
            End If
        Next

    End Sub

    Friend Sub DrawFog()
        Dim fogNum As Integer = CurrentFog

        If fogNum <= 0 Or fogNum > NumFogs Then Exit Sub

        ' Load and prepare texture if not already set up elsewhere in your code
        LoadTexture(fogNum, GfxType.Fog) ' Assuming LoadTexture handles setting `Repeated` and `Smooth`
        FogTexture(fogNum).Repeated = True
        FogTexture(fogNum).Smooth = True

        Dim sX As Integer = 0
        Dim sY As Integer = 0
        Dim sW As Integer = FogGfxInfo(fogNum).Width  ' Using the full width of the fog texture
        Dim sH As Integer = FogGfxInfo(fogNum).Height ' Using the full height of the fog texture

        ' These should match the scale calculations for full coverage plus extra area
        Dim dX As Integer = (FogOffsetX * 2.5) - 50
        Dim dY As Integer = (FogOffsetY * 3.5) - 50
        Dim dW As Integer = Window.Size.X + 200
        Dim dH As Integer = Window.Size.Y + 200

        RenderTexture(fogNum, GfxType.Fog, Window, dX, dY, sX, sY, dW, dH, sW, sH, CurrentFogOpacity)
    End Sub

#End Region

#Region "Functions"

    Sub ProcessWeather()
        Dim i As Integer, x As Integer

        If CurrentWeather > 0 And CurrentWeather < Weather.Fog Then
            If CurrentWeather = Weather.Rain Or CurrentWeather = Weather.Storm Then
                PlayWeatherSound("Rain.ogg", True)
            End If
            x = Rand(1, 101 - CurrentWeatherIntensity)
            If x = 1 Then
                'Add a new particle
                For i = 0 To MaxWeatherParticles
                    If WeatherParticle(i).InUse = 0 Then
                        If Rand(1, 3) = 1 Then
                            WeatherParticle(i).InUse = 1
                            WeatherParticle(i).Type = CurrentWeather
                            WeatherParticle(i).Velocity = Rand(8, 14)
                            WeatherParticle(i).X = (TileView.Left * 32) - 32
                            WeatherParticle(i).Y = ((TileView.Top * 32) + Rand(-32, Window.Size.Y))
                        Else
                            WeatherParticle(i).InUse = 1
                            WeatherParticle(i).Type = CurrentWeather
                            WeatherParticle(i).Velocity = Rand(10, 15)
                            WeatherParticle(i).X = ((TileView.Left * 32) + Rand(-32, Window.Size.X))
                            WeatherParticle(i).Y = (TileView.Top * 32) - 32
                        End If
                        'Exit For
                    End If
                Next
            End If
        Else
            StopWeatherSound()
        End If
        If CurrentWeather = Weather.Storm Then
            x = Rand(1, 400 - CurrentWeatherIntensity)
            If x = 1 Then
                'Draw Thunder
                DrawThunder = Rand(15, 22)
                PlayExtraSound("Thunder.ogg")
            End If
        End If
        For i = 0 To MaxWeatherParticles
            If WeatherParticle(i).InUse = 1 Then
                If WeatherParticle(i).X > TileView.Right * 32 Or WeatherParticle(i).Y > TileView.Bottom * 32 Then
                    WeatherParticle(i).InUse = 0
                Else
                    WeatherParticle(i).X = WeatherParticle(i).X + WeatherParticle(i).Velocity
                    WeatherParticle(i).Y = WeatherParticle(i).Y + WeatherParticle(i).Velocity
                End If
            End If
        Next

    End Sub

#End Region

#Region "Sound"

    Sub PlayWeatherSound(fileName As String, Optional looped As Boolean = False)
        If Not Types.Settings.Sound = 1 Or Not File.Exists(Paths.Sounds & fileName) Then Exit Sub
        If CurWeatherMusic = fileName Then Exit Sub

        Dim buffer As SoundBuffer
        If WeatherSoundPlayer Is Nothing Then
            WeatherSoundPlayer = New Sound()
        Else
            WeatherSoundPlayer.Stop()
        End If

        buffer = New SoundBuffer(Paths.Sounds & fileName)
        WeatherSoundPlayer.SoundBuffer = buffer
        If looped = True Then
            WeatherSoundPlayer.Loop() = True
        Else
            WeatherSoundPlayer.Loop() = False
        End If
        WeatherSoundPlayer.Volume() = MaxVolume
        WeatherSoundPlayer.Play()

        CurWeatherMusic = fileName
    End Sub

    Sub StopWeatherSound()
        If WeatherSoundPlayer Is Nothing Then Exit Sub
        WeatherSoundPlayer.Dispose()
        WeatherSoundPlayer = Nothing

        CurWeatherMusic = ""
    End Sub

#End Region

End Module