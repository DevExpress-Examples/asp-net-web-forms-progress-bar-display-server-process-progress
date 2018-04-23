Option Infer On

Imports System
Imports System.Threading

Public Class Operation
    Private _progress As Int32
    Private _started As Boolean
    Private l_started As New Object()

    Public Property Progress() As Int32
        Get
            Return _progress
        End Get
        Private Set(ByVal value As Int32)
            _progress = value
        End Set
    End Property

    Public Property Started() As Boolean
        Get
            SyncLock l_started
                Return _started
            End SyncLock
        End Get
        Private Set(ByVal value As Boolean)
            SyncLock l_started
                _started = value
            End SyncLock
        End Set
    End Property

    Public Sub AsyncStart(ByVal interval As Int32)
        If Started Then
            Return
        End If
        Started = True
        Progress = 0
        Dim t = New Thread(AddressOf start)
        t.Start(interval)
    End Sub

    Private Sub start(ByVal interval As Object)
'        
'         * suggest long operations here
'         
        Dim time = DirectCast(interval, Int32)
        Const steps As Int32 = 100
        Dim period = time \ steps
        For i As Integer = 0 To steps - 1
            Thread.Sleep(period)
            Progress += 1
        Next i
        Started = False
    End Sub
End Class

