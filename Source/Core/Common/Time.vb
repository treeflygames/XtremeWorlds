' MIT License
'
' Copyright (c) 2017 Robert Lodico
'
' Permission is hereby granted, free of charge, to any person obtaining a copy
' of this software and associated documentation files (the "Software"), to deal
' in the Software without restriction, including without limitation the rights
' to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
' copies of the Software, and to permit persons to whom the Software is
' furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all
' copies or substantial portions of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
' IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
' FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
' AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
' LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
' OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
' SOFTWARE.
Imports System.Timers

Public Enum TimeOfDay As Byte
    None = 0
    Day
    Night
    Dawn
    Dusk
End Enum

Public Delegate Sub HandleTimeEvent(ByRef source As Time)

Public Class Time
    Private Shared _mInstance As Time = Nothing

    Public Shared ReadOnly Property Instance As Time
        Get
            If (_mInstance Is Nothing) Then
                _mInstance = New Time()
            End If

            Return _mInstance
        End Get
    End Property

    Public Event OnTimeChanged As HandleTimeEvent
    Public Event OnTimeOfDayChanged As HandleTimeEvent
    Public Event OnTimeSync As HandleTimeEvent

    Private ReadOnly _mTimer As Timer

    Private _mTime As Date

    Public Property Time As Date
        Get
            Return _mTime
        End Get
        Set
            _mTime = Value

            Dim newTimeOfDay As TimeOfDay = GetTimeOfDay(Time.Hour)
            If (TimeOfDay <> newTimeOfDay) Then TimeOfDay = newTimeOfDay

            RaiseEvent OnTimeChanged(Me)
        End Set
    End Property

    Private _mGameSpeed As Double

    Public Property GameSpeed As Double
        Get
            Return _mGameSpeed
        End Get
        Set
            _mGameSpeed = Value
            RaiseEvent OnTimeSync(Me)
        End Set
    End Property

    Private mSyncInterval As Integer

    Public Property SyncInterval As Integer
        Get
            Return mSyncInterval
        End Get
        Set
            mSyncInterval = Value

            _mTimer.Stop()
            _mTimer.Interval = mSyncInterval
            _mTimer.Start()
            RaiseEvent OnTimeSync(Me)
        End Set
    End Property

    Private mTimeOfDay As TimeOfDay

    Public Property TimeOfDay As TimeOfDay
        Get
            Return mTimeOfDay
        End Get
        Set
            mTimeOfDay = Value
            RaiseEvent OnTimeOfDayChanged(Me)
        End Set
    End Property

    Public Sub New()
        mSyncInterval = 6000.0

        _mTimer = New Timer(SyncInterval)

        AddHandler _mTimer.Elapsed, AddressOf HandleTimerElapsed

        _mTimer.Start()
    End Sub

    Private Sub HandleTimerElapsed(sender As Object, e As ElapsedEventArgs)
        RaiseEvent OnTimeSync(Me)
    End Sub

    Public Overrides Function ToString() As String
        Return ToString("h:mm:ss tt")
    End Function

    Public Overloads Function ToString(ByRef format As String) As String
        Return Time.ToString(format)
    End Function

    Public Sub Reset()
        Time = New DateTime(0)
    End Sub

    Public Sub Tick()
        Time = Time.AddSeconds(GameSpeed)
    End Sub

    Public Shared Function GetTimeOfDay(ByRef hours As Integer) As TimeOfDay
        If (hours < 6) Then
            Return TimeOfDay.Night
        ElseIf (6 <= hours And hours <= 9) Then
            Return TimeOfDay.Dawn
        ElseIf (9 < hours And hours < 18) Then
            Return TimeOfDay.Day
        Else
            Return TimeOfDay.Dusk
        End If
    End Function
End Class