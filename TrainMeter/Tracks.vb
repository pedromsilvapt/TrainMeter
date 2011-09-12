Public Class Tracks

    Public Function GetAllTracks(ByVal profile As Integer) As QATDB.QATResult
        QAT.AddParameter(New QATDB.QATCore.QATParameter("profile", profile))
        Return QAT.Execute("LIST ID, name, size FROM tracks WHERE PROFILE_ID = @profile@")
    End Function

    Public Function EditTrack(ByVal TrackID As Integer, ByVal Name As String, ByVal Distance As Single) As Boolean
        QAT.AddParameter(New QATDB.QATCore.QATParameter("ID", TrackID))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("name", Name))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("size", Distance))
        QAT.Execute("CHANGE name=@name@,size=@size@ FROM tracks WHERE ID = @ID@")
        Return True
    End Function

    Public Function AddTrack(ByVal profile As Integer, ByVal name As String, ByVal size As Double) As Boolean
        QAT.AddParameter(New QATDB.QATCore.QATParameter("profile", profile))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("name", name))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("size", size))
        QAT.Execute("ADD tracks ID=#?,PROFILE_ID=@profile@,name=@name@,size=@size@")
        Return True
    End Function

    Public Function RemoveTrack(ByVal trackID As Integer)
        QAT.AddParameter(New QATDB.QATCore.QATParameter("ID", trackID))
        QAT.Execute("DELETE tracks WHERE ID=@ID@")
    End Function

End Class
