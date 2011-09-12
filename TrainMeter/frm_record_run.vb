Public Class frm_record_run
    Private _Tracks As Tracks = New Tracks
    Private _Profiles As Profiles = New Profiles
    Private _Runs As Runs = New Runs

    Private cron As Stopwatch = New Stopwatch

    Dim hours As Integer = 0
    Dim minutes As Integer = 0
    Dim seconds As Integer = 0

    Dim s_minutes As String = ""
    Dim s_seconds As String = ""

    Public Sub RefreshDistance()
        Me.klbl_distance.Text = _Tracks.GetDistance(_Tracks.GetTrackID(Me.kdud_tracks.Text), Me.knud_laps.Value)
    End Sub

    Public Sub RefreshProfiles()
        Me.kdud_profiles.Items.Clear()

        Dim allprofiles As QATDB.QATResult = Me._Profiles.GetProfiles()


        For Each _Profile As DataRow In allprofiles.GetDataTable.Rows
            If (Me._Tracks.TracksCount(_Profile.Item("ID")) > 0) Then
                Me.kdud_profiles.Items.Add(_Profile.Item("name"))
            End If
        Next

        If (Me.kdud_profiles.Items.Count = 0) Then
            Me.CloseNoTracks()
        End If

        Me.kdud_profiles.SelectedIndex = 0
    End Sub

    Public Sub RefreshTracks()
        Me.kdud_tracks.Items.Clear()

        Dim allTracks As QATDB.QATResult = Me._Tracks.GetAllTracks(Me._Profiles.GetProfileID(Me.kdud_profiles.Text))

        If (allTracks.HasNothing) Then
            Me.Close()
        End If

        For Each _Track As DataRow In allTracks.GetDataTable.Rows
            Me.kdud_tracks.Items.Add(_Track.Item("name"))
        Next

        Me.kdud_tracks.SelectedIndex = 0
        Me.RefreshDistance()
    End Sub

    Private Sub frm_record_run_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (Me._Profiles.ProfilesCount() = 0) Then
            Me.CloseNoProfiles()
        ElseIf (Me._Tracks.TracksCount() = 0) Then
            Me.CloseNoTracks()
        End If

        'Loads Profiles and Tracks
        Me.RefreshProfiles()
        Me.RefreshTracks()
    End Sub

    Public Sub CloseNoProfiles()
        MessageBox.Show("Não tem nenhum perfil definido. O gravador de corridas necessita que tenha algum perfil criado.", "Sem perfis", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Me.Close()
    End Sub

    Public Sub CloseNoTracks()
        MessageBox.Show("Não tem nenhuma pista definida. O gravador de corridas necessita que tenha alguma pista criada.", "Sem pistas", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Me.Close()
    End Sub

    Private Sub kdud_profiles_SelectedItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kdud_profiles.SelectedItemChanged
        If (Not _Profiles.ProfileExist(Me._Profiles.GetProfileID(Me.kdud_profiles.Text))) Then
            Me.RefreshProfiles()
        End If
        Me.RefreshTracks()
    End Sub

    Private Sub kbtn_start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kbtn_start.Click
        If (Me.kbtn_start.Tag = 1) Then
            Me.Timer1.Start()
            Me.cron.Start()
            Me.kbtn_start.Tag = 2
            Me.klbl_cron.StateCommon.ShortText.Color1 = Color.White
        Else
            Me.klbl_cron.StateCommon.ShortText.Color1 = Color.Red
            Me.Timer1.Stop()
            Me.cron.Stop()
            Me.kbtn_start.Tag = 1
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.klbl_cron.Text = GetTimeFormated(cron.ElapsedMilliseconds)
    End Sub

    Public Function GetTimeFormated(ByVal Milliseconds As Integer) As String

        hours = Milliseconds / 3600000
        Milliseconds -= hours * 3600000

        minutes = Milliseconds / 60000
        Milliseconds = Milliseconds Mod 60000

        seconds = Milliseconds / 1000

        If (minutes < 10) Then
            s_minutes = "0" & minutes.ToString()
        Else
            s_minutes = minutes.ToString()
        End If
        If (seconds < 10) Then
            s_seconds = "0" & seconds.ToString()
        Else
            s_seconds = seconds.ToString()
        End If
        Return (hours & ":" & s_minutes & ":" & s_seconds)
    End Function

    Private Sub kbtn_stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kbtn_stop.Click
        Me.cron.Stop()
        Me.Timer1.Stop()
        Me.kbtn_start.Tag = 1

        Me.kbtn_stop.Enabled = False
        Me.kbtn_start.Enabled = False
        Me.kdud_profiles.Enabled = False
        Me.kdud_tracks.Enabled = False
        Me.knud_laps.Enabled = False

        Me.klbl_cron.StateCommon.ShortText.Color1 = Color.Lime

        Me._Runs.AddRun(_Profiles.GetProfileID(Me.kdud_profiles.Text),
                    Now,
                    Me.cron.ElapsedMilliseconds / 60,
                    klbl_distance.Text)

        Me.klbl_saved.Visible = True
    End Sub

    Private Sub knud_laps_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles knud_laps.ValueChanged
        Me.RefreshDistance()
    End Sub
End Class
