Public Class Profiles

    Public Function GetProfiles() As QATDB.QATResult
        Return QAT.Execute("LIST ID, name FROM profiles")
    End Function

    Public Function GetProfileID(ByVal ProfileName As String) As Integer
        QAT.AddParameter(New QATDB.QATCore.QATParameter("name", ProfileName))
        Return QAT.Execute("LIST ID FROM profiles WHERE name=@name@").GetFirst("ID")
    End Function

    Public Function GetProfileName(ByVal ProfileID As Integer) As String
        QAT.AddParameter(New QATDB.QATCore.QATParameter("id", ProfileID))
        Return QAT.Execute("LIST name FROM profiles WHERE ID=@id@").GetFirst("name")
    End Function

    Public Function ProfilesCount() As Integer
        Return QAT.Execute("COUNT profiles").RowCount
    End Function

    Public Function ProfilesExist(ByVal ProfileID As Integer) As Boolean
        QAT.AddParameter(New QATDB.QATCore.QATParameter("id", ProfileID))
        If (QAT.Execute("LIST name FROM profiles WHERE id=@id@").RowCount = 0) Then
            Return False
        Else
            Return True
        End If
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
