Public Class frm_runs

    Public Enum CollapsingState As Integer
        Hiden = 0
        Hiding = 1
        Showing = 2
        Showed = 3
    End Enum

    Private ToolbarState As CollapsingState = CollapsingState.Showed

    Private WithEvents showAdd As Transitions.Transition
    Private WithEvents showAdd_mg As Transitions.Transition = New Transitions.Transition(New Transitions.TransitionType_Acceleration(300))
    Private WithEvents hideAdd As Transitions.Transition = New Transitions.Transition(New Transitions.TransitionType_Acceleration(300))
    Private WithEvents hideAdd_mg As Transitions.Transition = New Transitions.Transition(New Transitions.TransitionType_Acceleration(300))

    Private WithEvents showToolbar As Transitions.Transition
    Private WithEvents showToolbar_mg As Transitions.Transition = New Transitions.Transition(New Transitions.TransitionType_Acceleration(300))
    Private WithEvents hideToolbar As Transitions.Transition = New Transitions.Transition(New Transitions.TransitionType_Acceleration(300))
    Private WithEvents hideToolbar_mg As Transitions.Transition = New Transitions.Transition(New Transitions.TransitionType_Acceleration(300))

    Private WithEvents blink As Transitions.Transition

    Private _Profiles As Profiles
    Private ProfilesList As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
    Private _Tracks As Tracks = New Tracks
    Private TracksList As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)


    Public Sub RefreshTracks()
        Me.TracksList.Clear()
        Me.kltb_tracks.Items.Clear()

        Dim allTracks As Data.DataTable = Me._Tracks.GetAllTracks(Me.ProfilesList(Me.kdud_profiles.Text)).GetDataTable
        Dim item As ComponentFactory.Krypton.Toolkit.KryptonListItem

        For Each _Track As DataRow In allTracks.Rows
            Me.TracksList.Add(_Track.Item("name"), _Track.Item("ID"))
            item = New ComponentFactory.Krypton.Toolkit.KryptonListItem
            item.ShortText = _Track.Item("name")
            item.LongText = _Track.Item("size") & " metros"
            Me.kltb_tracks.Items.Add(item)
        Next
    End Sub

    Public Sub RefreshProfiles()
        Me._Profiles = New Profiles
        Me.ProfilesList.Clear()
        Me.kdud_profiles.Items.Clear()

        Dim allprofiles As QATDB.QATResult = Me._Profiles.GetProfiles()

        If (allprofiles.HasNothing) Then
            Me.Close()
        End If

        For Each _Profile As DataRow In allprofiles.GetDataTable.Rows
            Me.ProfilesList.Add(_Profile.Item("name"), _Profile.Item("ID"))
            Me.kdud_profiles.Items.Add(_Profile.Item("name"))
        Next
        Me.kdud_profiles.SelectedIndex = 0
    End Sub

    Private Sub frm_runs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Loads profiles
        Me.RefreshProfiles()

        'Makes sure the new run button is hiden
        Me.kcbtn_add_run.Visible = False

        'Toogles the Groups Visibility
        Me.khgp_runs.Visible = Me.kcbtn_runs.Checked
        Me.khgp_tracks.Visible = Me.kcbtn_tracks.Checked
        Me.khgp_add_run.Visible = Me.kcbtn_add_run.Checked

        'Toogles the Graphs Toolbar Visibility
        Me.kpnl_runs_weekly.Visible = Me.kcbtn_runs_weekly.Checked
        Me.kpnl_runs_monthly.Visible = Me.kcbtn_runs_monthly.Checked
        Me.kpnl_runs_anual.Visible = Me.kcbtn_runs_anual.Checked
        Me.kpnl_runs_complete.Visible = Me.kcbtn_runs_complete.Checked
        Me.kpnl_runs_custom.Visible = Me.kcbtn_runs_custom.Checked
    End Sub

    Private Sub kcbtn_runs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles kcbtn_runs.CheckedChanged
        Me.khgp_runs.Visible = Me.kcbtn_runs.Checked
        Me.kpnl_runs_switch_views.Visible = Me.kcbtn_runs.Checked
    End Sub

    Private Sub kcbtn_tracks_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles kcbtn_tracks.CheckedChanged
        Me.khgp_tracks.Visible = Me.kcbtn_tracks.Checked
    End Sub

    Private Sub kcbtn_add_run_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles kcbtn_add_run.CheckedChanged
        Me.khgp_add_run.Visible = Me.kcbtn_add_run.Checked
    End Sub

    Private Sub kcbtn_runs_weekly_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles kcbtn_runs_weekly.CheckedChanged
        Me.kpnl_runs_weekly.Visible = Me.kcbtn_runs_weekly.Checked
    End Sub

    Private Sub kcbtn_runs_monthly_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles kcbtn_runs_monthly.CheckedChanged
        Me.kpnl_runs_monthly.Visible = Me.kcbtn_runs_monthly.Checked
    End Sub

    Private Sub kcbtn_runs_anual_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles kcbtn_runs_anual.CheckedChanged
        Me.kpnl_runs_anual.Visible = Me.kcbtn_runs_anual.Checked
    End Sub

    Private Sub kcbtn_runs_complete_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles kcbtn_runs_complete.CheckedChanged
        Me.kpnl_runs_complete.Visible = Me.kcbtn_runs_complete.Checked
    End Sub

    Private Sub kcbtn_runs_custom_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles kcbtn_runs_custom.CheckedChanged
        Me.kpnl_runs_custom.Visible = Me.kcbtn_runs_custom.Checked
    End Sub

    Private Sub frm_runs_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.kpnl_runs_toolbar_center_container.Location = New Point(((Me.kpnl_runs_toolbar.Size.Width / 2) - (Me.kpnl_runs_toolbar_center_container.Size.Width / 2)), Me.kpnl_runs_toolbar_center_container.Location.Y)
    End Sub

    Private Sub KryptonButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton1.Click
        Dim r As Runs = New Runs
        MessageBox.Show(r.GoToWeek(Me.knud_runs_weekly_year.Value, Me.knud_runs_weekly_week.Value))
    End Sub

    Private Sub khgp_add_track_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles khgp_add_track.SizeChanged
        'Me.klbl_no_profiles.Location = New Point((Me.khgp_profiles.Size.Width / 2) - (Me.klbl_no_profiles.Size.Width / 2),
        '                                        (Me.khgp_profiles.Size.Height / 2) - (Me.klbl_no_profiles.Size.Height / 2))
        Me.pnl_add_track.Location = New Point((Me.khgp_add_track.Size.Width / 2) - (Me.pnl_add_track.Size.Width / 2), Me.pnl_add_track.Location.Y)
    End Sub


    Private Sub btnshg_add_track_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshg_add_track.Click
        If (Me.khgp_add_track.Visible = False) Then
            Me.khgp_add_track.Visible = True
            Me.khgp_add_track.Location = New Point(0, Me.Height)

            Me.showAdd = New Transitions.Transition(New Transitions.TransitionType_Acceleration(300))
            Me.showAdd_mg = New Transitions.Transition(New Transitions.TransitionType_Acceleration(300))

            Me.showAdd_mg.add(Me.khgp_tracks, "Height", Me.khgp_tracks.Height - 75)
            Me.showAdd.add(Me.khgp_add_track, "Top", Me.khgp_tracks.Size.Height - 76)

            Transitions.Transition.runChain(Me.showAdd_mg, Me.showAdd)
        End If
    End Sub


    Private Sub bhsg_add_track_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bhsg_add_track_cancel.Click
        If (Me.khgp_add_track.Visible = True) Then
            Me.hideAdd = New Transitions.Transition(New Transitions.TransitionType_Acceleration(300))
            Me.hideAdd_mg = New Transitions.Transition(New Transitions.TransitionType_Acceleration(300))

            Me.hideAdd_mg.add(Me.khgp_tracks, "Height", Me.khgp_tracks.Height + 75)
            Me.hideAdd.add(Me.khgp_add_track, "Top", Me.khgp_tracks.Size.Height + 76)

            Transitions.Transition.runChain(Me.hideAdd, Me.hideAdd_mg)
        End If
    End Sub

    Private Sub hideAdd_TransitionCompletedEvent(ByVal sender As Object, ByVal e As Transitions.Transition.Args) Handles hideAdd.TransitionCompletedEvent
        Me.khgp_add_track.Visible = False
        Me.pnl_add_track.BackColor = Color.White
        Me.pnl_add_track_background.BackColor = Color.White
        Me.ktxt_add_track_name.Text = ""
        Me.knud_add_track_size.Value = 1
    End Sub

    Private Sub bhsg_add_track_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bhsg_add_track_save.Click
        If (Me.ktxt_add_track_name.Text = "" Or Me.TracksList.ContainsKey(Me.ktxt_add_track_name.Text)) Then
            Me.blink = New Transitions.Transition(New Transitions.TransitionType_Flash(1, 600))
            Me.blink.add(Me.pnl_add_track, "BackColor", Color.FromArgb(255, 255, 160, 160))
            Me.blink.add(Me.pnl_add_track_background, "BackColor", Color.FromArgb(255, 255, 160, 160))
            Me.blink.run()
        Else
            Me._Tracks.AddTrack(Me.ProfilesList(Me.kdud_profiles.Text), Me.ktxt_add_track_name.Text, Me.knud_add_track_size.Value)
            Me.RefreshTracks()

            Me.hideAdd = New Transitions.Transition(New Transitions.TransitionType_Acceleration(300))
            Me.hideAdd_mg = New Transitions.Transition(New Transitions.TransitionType_Acceleration(300))

            Me.hideAdd_mg.add(Me.khgp_tracks, "Height", Me.khgp_tracks.Height + 75)
            Me.hideAdd.add(Me.khgp_add_track, "Top", Me.khgp_tracks.Size.Height + 76)

            Me.blink = New Transitions.Transition(New Transitions.TransitionType_Flash(1, 600))
            Me.blink.add(Me.pnl_add_track, "BackColor", Color.FromArgb(255, 173, 255, 160))
            Me.blink.add(Me.pnl_add_track_background, "BackColor", Color.FromArgb(255, 173, 255, 160))
            Transitions.Transition.runChain(Me.blink, Me.hideAdd, Me.hideAdd_mg)
        End If
    End Sub

    Private Sub khgp_tracks_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles khgp_tracks.VisibleChanged
        If khgp_tracks.Visible = True Then
            Me.RefreshTracks()
        End If
    End Sub

    Private Sub kdud_profiles_SelectedItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kdud_profiles.SelectedItemChanged
        If Not Me.ProfilesList.ContainsKey(Me.kdud_profiles.Text) Then
            Me.kdud_profiles.SelectedIndex = 0
        End If

        Me.RefreshTracks()
    End Sub

    Private Sub btnshg_remove_track_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshg_remove_track.Click
        If (Not Me.kltb_tracks.SelectedItem.ShortText = "") Then
            Me._Tracks.RemoveTrack(Me.TracksList(Me.kltb_tracks.SelectedItem.ShortText))
            Me.kltb_tracks.Items.RemoveAt(Me.kltb_tracks.SelectedIndex)
        End If
    End Sub

    Private Sub kbshg_minimize_runs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kbshg_minimize_runs.Click
        If (Me.ToolbarState = CollapsingState.Hiden) Then
            Me.ToolbarState = CollapsingState.Showing

            Me.showToolbar = New Transitions.Transition(New Transitions.TransitionType_Acceleration(300))
            Me.showToolbar_mg = New Transitions.Transition(New Transitions.TransitionType_Acceleration(300))


            Me.showToolbar_mg.add(Me.kpnl_runs_toolbar, "Height", 41)

            Me.showToolbar.add(Me.kpnl_runs_weekly, "Height", 38)
            Me.showToolbar.add(Me.kpnl_runs_monthly, "Height", 38)
            Me.showToolbar.add(Me.kpnl_runs_anual, "Height", 38)
            Me.showToolbar.add(Me.kpnl_runs_complete, "Height", 38)
            Me.showToolbar.add(Me.kpnl_runs_custom, "Height", 38)

            Transitions.Transition.runChain(Me.showToolbar_mg, Me.showToolbar)
        ElseIf (Me.ToolbarState = CollapsingState.Showed) Then
            Me.ToolbarState = CollapsingState.Hiding

            Me.hideToolbar = New Transitions.Transition(New Transitions.TransitionType_Acceleration(300))
            Me.hideToolbar_mg = New Transitions.Transition(New Transitions.TransitionType_Acceleration(300))


            Me.hideToolbar_mg.add(Me.kpnl_runs_toolbar, "Height", 0)

            Me.hideToolbar.add(Me.kpnl_runs_weekly, "Height", 0)
            Me.hideToolbar.add(Me.kpnl_runs_monthly, "Height", 0)
            Me.hideToolbar.add(Me.kpnl_runs_anual, "Height", 0)
            Me.hideToolbar.add(Me.kpnl_runs_complete, "Height", 0)
            Me.hideToolbar.add(Me.kpnl_runs_custom, "Height", 0)

            Transitions.Transition.runChain(Me.hideToolbar, Me.hideToolbar_mg)
        End If
    End Sub


    Private Sub hideToolbar_mg_TransitionCompletedEvent(ByVal sender As Object, ByVal e As Transitions.Transition.Args) Handles hideToolbar_mg.TransitionCompletedEvent
        Me.ToolbarState = CollapsingState.Hiden
    End Sub


    Private Sub showToolbar_TransitionCompletedEvent(ByVal sender As Object, ByVal e As Transitions.Transition.Args) Handles showToolbar.TransitionCompletedEvent
        Me.ToolbarState = CollapsingState.Showed
    End Sub

    Private Sub kcbx_add_run_track_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kcbx_add_run_track.CheckedChanged
        Me.klbl_add_run_laps.Enabled = Me.kcbx_add_run_track.Checked
        Me.klbl_add_run_track.Enabled = Me.kcbx_add_run_track.Checked
        Me.kcbb_add_run_track.Enabled = Me.kcbx_add_run_track.Checked
        Me.knud_add_run_laps.Enabled = Me.kcbx_add_run_track.Checked

        Me.klbl_add_run_distance.Enabled = Not Me.kcbx_add_run_track.Checked
        Me.knud_add_run_distance.Enabled = Not Me.kcbx_add_run_track.Checked
        Me.kdud_add_run_distance.Enabled = Not Me.kcbx_add_run_track.Checked
    End Sub

    Private Sub kbshg_add_run_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kbshg_add_run.Click
        Me.kcbtn_add_run.Visible = True
        Me.kcbtn_add_run.Checked = True
    End Sub

    Private Sub khgp_add_run_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles khgp_add_run.Paint

    End Sub

    Private Sub khgp_add_run_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles khgp_add_run.SizeChanged
        Me.pnl_add_run.Location = New Point((Me.khgp_add_run.Size.Width / 2) - (Me.pnl_add_run.Size.Width / 2),
                                              (Me.khgp_add_run.Size.Height / 2) - (Me.pnl_add_run.Size.Height / 2))
    End Sub

    Private Sub bshg_add_run_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bshg_add_run_close.Click
        Me.kcbtn_runs.Checked = True
        Me.kcbtn_add_run.Visible = False
        Me.kdtp_add_run_date.Value = Me.kdtp_add_run_date.CalendarTodayDate
        Me.knud_add_run_duration.Value = 0
        Me.kcbx_add_run_track.Checked = True
        Me.kcbb_add_run_track.Text = ""
        Me.knud_add_run_laps.Value = 1
        Me.knud_add_run_distance.Value = 0
    End Sub

    Private Sub bshg_add_run_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bshg_add_run_save.Click

    End Sub
End Class