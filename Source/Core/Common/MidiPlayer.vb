﻿Imports System.Runtime.InteropServices
Imports System.Text

Public Class MidiPlayer
    <DllImport("winmm.dll")>
    Private Shared Function mciSendString(command As String, returnValue As StringBuilder, returnLength As Integer, hwndCallback As IntPtr) As Integer
    End Function

    Public Shared Sub Play(filePath As String)
        Dim command As String = $"open ""{filePath}"" type sequencer alias MidiSeq"
        mciSendString("close MidiSeq", Nothing, 0, IntPtr.Zero)
        mciSendString(command, Nothing, 0, IntPtr.Zero)
        mciSendString("play MidiSeq", Nothing, 0, IntPtr.Zero)
    End Sub
End Class
