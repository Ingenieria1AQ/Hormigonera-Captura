Imports System.Threading.Tasks

Public Module DelayHelper

    Public Async Function DelayMs(ms As Integer) As Task
        Await Task.Delay(ms)
    End Function

End Module
