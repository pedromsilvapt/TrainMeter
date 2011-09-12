Public Class frm_init

    Private Sub kbtn_profiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kbtn_profiles.Click
        frm_profiles.Show()
    End Sub

    Private Sub kctmi_record_run_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles kctmi_record_run.Click
        frm_record_run.ShowDialog()
    End Sub

    Private Sub kbtn_runs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kbtn_runs.Click
        frm_runs.Show()
    End Sub

    Private Sub kbtn_quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kbtn_quit.Click
        Application.Exit()
    End Sub

    Private Sub frm_init_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DBAttachAndAuthenticate()
    End Sub
End Class
