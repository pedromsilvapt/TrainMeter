Public Class Tracks

    Private tempQ As QATDB.QATResult

    Public Function GetAllTracks(ByVal profile As Integer) As QATDB.QATResult
        QAT.AddParameter(New QATDB.QATCore.QATParameter("profile", profile))
        Return QAT.Execute("LIST ID, name, size FROM tracks WHERE PROFILE_ID = @profile@")
    End Function

    Public Function GetTrackID(ByVal TrackName As String) As Integer
        QAT.AddParameter(New QATDB.QATCore.QATParameter("name", TrackName))
        tempQ = QAT.Execute("LIST ID FROM tracks WHERE name=@name@")
        If (tempQ.HasNothing) Then
            Return -1
        Else
            Return tempQ.GetFirst("ID")
        End If
    End Function

    Public Function GetTrackName(ByVal TrackID As Integer) As String
        QAT.AddParameter(New QATDB.QATCore.QATParameter("id", TrackID))
        tempQ = QAT.Execute("LIST name FROM tracks WHERE ID=@id@")
        If (tempQ.HasNothing) Then
            Return ""
        Else
            Return tempQ.GetFirst("name")
        End If
    End Function

    Public Function GetTrack(ByVal TrackID As Integer) As QATDB.QATResult
        QAT.AddParameter(New QATDB.QATCore.QATParameter("id", TrackID))
        Return QAT.Execute("LIST * FROM tracks WHERE ID=@id@")
    End Function

    Public Function TracksCount() As Integer
        Return QAT.Execute("COUNT tracks").RowCount
    End Function

    Public Function TracksCount(ByVal ProfileID As Integer) As Integer
        QAT.AddParameter(New QATDB.QATCore.QATParameter("profile_id", ProfileID))
        Return QAT.Execute("COUNT tracks WHERE PROFILE_ID=@profile_id@").RowCount
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

    Public Function GetDistance(ByVal TrackID As Integer, Optional ByVal Laps As Integer = 1) As Integer
        QAT.AddParameter(New QATDB.QATCore.QATParameter("id", TrackID))
        tempQ = QAT.Execute("LIST size FROM tracks WHERE ID=@id@")
        If (tempQ.HasNothing) Then
            Return (-1)
        Else
            Return tempQ.GetFirst("size") * Laps
        End If
    End Function

End Class
