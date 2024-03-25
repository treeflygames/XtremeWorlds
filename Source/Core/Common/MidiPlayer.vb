Imports Sanford.Multimedia.Midi

Public Module MidiPlayer
    Public OutputDevice As OutputDevice
    Public midiSequence As Sequence
    Public midiSequencer As Sequencer
    Public midiPath As String

    ' Initialize the MIDI sequence and sequencer
    Public Sub Initialize()
        midiSequence = New Sequence()
        midiSequencer = New Sequencer()

        AddHandler midiSequencer.PlayingCompleted, AddressOf OnPlayingCompleted
        AddHandler midiSequencer.ChannelMessagePlayed, AddressOf OnChannelMessagePlayed

        midiSequencer.Sequence = midiSequence
        OutputDevice?.Dispose

        ' Initialize the OutputDevice
        Try
            OutputDevice = New OutputDevice(0) ' Assumes device ID 0 is available
        Catch ex As Exception
            ' Handle error (e.g., no MIDI devices available)
            Throw New InvalidOperationException("Could not initialize MIDI output device.", ex)
        End Try
    End Sub

    ' Load a MIDI file
    Public Sub Load(filePath As String)
        Initialize()
        midiPath = filePath
        midiSequence?.Load(filePath)
    End Sub

    ' Play the loaded MIDI file
    Public Sub Play()
        If midiSequencer IsNot Nothing AndAlso midiSequence IsNot Nothing Then
            midiSequencer.Start()
        End If
    End Sub

    ' Stop playback
    Public Sub Dispose()
        midiSequence.Dispose
        midiSequencer.Dispose
        OutputDevice.Dispose
    End Sub

    ' Handle channel messages
    Private Sub OnChannelMessagePlayed(sender As Object, e As ChannelMessageEventArgs)
        OutputDevice.Send(e.Message)
    End Sub

    ' Handle playback completion
    Private Sub OnPlayingCompleted(sender As Object, e As EventArgs)
        MidiPlayer.Dispose()
        MidiPlayer.Load(midiPath)
        MidiPlayer.Play()
    End Sub
End Module
