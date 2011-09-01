Module QATDataBase
    Public QAT As QATDB.QATCore = New QATDB.QATCore


    Public Function DBAttachAndAuthenticate()
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\trainmeter.QAT") Then
            If (Not QAT.AttachedAndAuthenticated) Then
                If (QAT.AttachAndAuthenticate(Application.StartupPath & "\trainmeter.QAT", "1", "1")) Then
                    Return True
                Else
                    Return False
                End If
            End If
        Else
            If (Not QAT.CreateDatabase("TrainMeter", "1", "1", Application.StartupPath & "\trainmeter.QAT")) Then
                Return False
            End If
            If (QAT.ExecuteScript(My.Resources.DBStructure, False)) Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

End Module
