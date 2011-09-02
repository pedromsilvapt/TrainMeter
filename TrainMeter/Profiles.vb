Public Class Profiles

    Public Function GetProfiles() As QATDB.QATResult
        Return QAT.Execute("LIST ID, name FROM profiles")
    End Function

    Public Function AddProfile(ByVal name As String) As Boolean
        QAT.AddParameter(New QATDB.QATCore.QATParameter("name", name))
        QAT.Execute("ADD profiles ID=#?,name=@name@")
        Return (True)
    End Function

    Public Function EditProfile(ByVal UserID As Integer, ByVal NewName As String)
        QAT.AddParameter(New QATDB.QATCore.QATParameter("ID", UserID))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("name", NewName))
        QAT.Execute("CHANGE name=@name@ FROM profiles WHERE ID = @ID@")
    End Function

    Public Function RemoveProfile(ByVal ProfileID As Integer) As Boolean
        QAT.AddParameter(New QATDB.QATCore.QATParameter("ID", ProfileID))
        QAT.Execute("DELETE profiles WHERE ID=@ID@")
        Return (True)
    End Function


End Class
