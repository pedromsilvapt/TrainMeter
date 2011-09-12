Public Class frm_profiles
    Private _Profiles As Profiles = New Profiles
    Private UsersList As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
    Private EditUserID As Integer = 0

    Private WithEvents showAdd As Transitions.Transition
    Private WithEvents showAdd_mg As Transitions.Transition
    Private WithEvents hideAdd As Transitions.Transition
    Private WithEvents hideAdd_mg As Transitions.Transition
    Private WithEvents hideEdit_mg As Transitions.Transition
    Private WithEvents blink As Transitions.Transition

    Private Sub frm_profiles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.RefreshProfiles()
        Me.khgp_profiles_SizeChanged(Me.klbl_no_profiles, New EventArgs())
    End Sub

    Public Sub RefreshProfiles()
        Dim allprofiles As QATDB.QATResult = Me._Profiles.GetProfiles()
        Me.UsersList.Clear()
        Me.kltb_profiles.Items.Clear()

        If (allprofiles.HasNothing) Then
            Me.klbl_no_profiles.Visible = True
        Else
            Me.klbl_no_profiles.Visible = False

            For Each _ProfileRow As DataRow In allprofiles.GetDataTable.Rows
                Me.kltb_profiles.Items.Add(_ProfileRow.Item("name"))
                Me.UsersList.Add(_ProfileRow.Item("name"), _ProfileRow.Item("ID"))
            Next

        End If
    End Sub

    Private Sub khgp_profiles_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles khgp_profiles.SizeChanged
        Me.klbl_no_profiles.Location = New Point((Me.khgp_profiles.Size.Width / 2) - (Me.klbl_no_profiles.Size.Width / 2),
                                                (Me.khgp_profiles.Size.Height / 2) - (Me.klbl_no_profiles.Size.Height / 2))
        Me.pnl_add_profile.Location = New Point((Me.khgp_add_profile.Size.Width / 2) - (Me.pnl_add_profile.Size.Width / 2), Me.pnl_add_profile.Location.Y)
    End Sub

#Region "AddProfile Panel"

    Private Sub bshg_add_profile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bshg_add_profile.Click
        If (Me.khgp_add_profile.Visible = False And Me.khgp_edit_profile.Visible = False) Then
            Me.bhsg_add_profile_save.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
            Me.bhsg_add_profile_cancel.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
            Me.khgp_add_profile.Visible = True
            Me.khgp_add_profile.Location = New Point(2, Me.kpnl_window_background.Size.Height)

            Me.showAdd = New Transitions.Transition(New Transitions.TransitionType_Acceleration(100))
            Me.showAdd_mg = New Transitions.Transition(New Transitions.TransitionType_Acceleration(100))

            Me.showAdd.add(Me.khgp_add_profile, "Top", Me.kpnl_window_background.Size.Height - 76)
            Me.showAdd_mg.add(Me.khgp_profiles, "Height", Me.khgp_profiles.Size.Height - 75)
            Transitions.Transition.runChain(Me.showAdd_mg, Me.showAdd)
        End If
    End Sub

    Private Sub ktxt_add_profile_name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ktxt_add_profile_name.KeyPress
        If (Chr(13) = e.KeyChar) Then
            Me.bhsg_add_profile_save.PerformClick()
        End If
    End Sub

    Private Sub bhsg_add_profile_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bhsg_add_profile_save.Click
        Me.bhsg_add_profile_save.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False
        Me.bhsg_add_profile_cancel.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False
        If (Me.ktxt_add_profile_name.Text = "" Or Me.UsersList.ContainsKey(Me.ktxt_add_profile_name.Text)) Then
            Me.blink = New Transitions.Transition(New Transitions.TransitionType_Flash(1, 600))
            Me.blink.add(Me.pnl_add_profile, "BackColor", Color.FromArgb(255, 255, 160, 160))
            Me.blink.add(Me.pnl_add_profile_background, "BackColor", Color.FromArgb(255, 255, 160, 160))
            Me.blink.run()
            Me.bhsg_add_profile_save.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
            Me.bhsg_add_profile_cancel.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
        Else
            Me.UsersList.Add(Me.ktxt_add_profile_name.Text, QAT.GetTableAID("profiles"))
            Me._Profiles.AddProfile(Me.ktxt_add_profile_name.Text)
            Me.kltb_profiles.Items.Add(Me.ktxt_add_profile_name.Text)

            Me.hideAdd = New Transitions.Transition(New Transitions.TransitionType_Acceleration(100))
            Me.hideAdd_mg = New Transitions.Transition(New Transitions.TransitionType_Acceleration(100))

            Me.hideAdd.add(Me.khgp_add_profile, "Top", Me.kpnl_window_background.Size.Height + 76)
            Me.hideAdd_mg.add(Me.khgp_profiles, "Height", Me.khgp_profiles.Size.Height + 76)

            Me.blink = New Transitions.Transition(New Transitions.TransitionType_Flash(1, 600))
            Me.blink.add(Me.pnl_add_profile, "BackColor", Color.FromArgb(255, 173, 255, 160))
            Me.blink.add(Me.pnl_add_profile_background, "BackColor", Color.FromArgb(255, 173, 255, 160))
            Transitions.Transition.runChain(Me.blink, Me.hideAdd, Me.hideAdd_mg)
        End If
    End Sub

    Private Sub bhsg_add_profile_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bhsg_add_profile_cancel.Click
        If (Me.khgp_add_profile.Visible = True) Then

            Me.hideAdd = New Transitions.Transition(New Transitions.TransitionType_Acceleration(100))
            Me.hideAdd_mg = New Transitions.Transition(New Transitions.TransitionType_Acceleration(100))

            Me.hideAdd.add(Me.khgp_add_profile, "Top", Me.kpnl_window_background.Size.Height + 76)
            Me.hideAdd_mg.add(Me.khgp_profiles, "Height", Me.khgp_profiles.Size.Height + 76)
            Transitions.Transition.runChain(Me.hideAdd, Me.hideAdd_mg)
        End If
    End Sub

    Private Sub hideAdd_mg_TransitionCompletedEvent(ByVal sender As Object, ByVal e As Transitions.Transition.Args) Handles hideAdd_mg.TransitionCompletedEvent
        Me.ktxt_add_profile_name.Text = ""
        Me.pnl_add_profile.BackColor = Color.White
        Me.pnl_add_profile_background.BackColor = Color.White
        Me.khgp_add_profile.Visible = False
        Me.bhsg_add_profile_save.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
        Me.bhsg_add_profile_cancel.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
    End Sub

#End Region

#Region "EditProfile Panel"

    Private Sub bshg_edit_profile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bshg_edit_profile.Click
        If (Me.khgp_edit_profile.Visible = False And Me.kltb_profiles.SelectedIndex <> -1 And Me.khgp_add_profile.Visible = False) Then

            Me.EditUserID = Me.UsersList(Me.kltb_profiles.SelectedItem)
            Me.ktxt_edit_profile_name.Text = Me.kltb_profiles.SelectedItem

            Me.bshg_edit_profile_save.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
            Me.bshg_edit_profile_cancel.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
            Me.khgp_edit_profile.Visible = True
            Me.khgp_edit_profile.Location = New Point(2, Me.kpnl_window_background.Size.Height)

            Me.showAdd = New Transitions.Transition(New Transitions.TransitionType_Acceleration(100))
            Me.showAdd_mg = New Transitions.Transition(New Transitions.TransitionType_Acceleration(100))

            Me.showAdd.add(Me.khgp_edit_profile, "Top", Me.kpnl_window_background.Size.Height - 76)
            Me.showAdd_mg.add(Me.khgp_profiles, "Height", Me.khgp_profiles.Size.Height - 75)
            Transitions.Transition.runChain(Me.showAdd_mg, Me.showAdd)
        End If
    End Sub

    Private Sub ktxt_edit_profile_name_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ktxt_edit_profile_name.KeyPress
        If (Chr(13) = e.KeyChar) Then
            Me.bshg_edit_profile_save.PerformClick()
        End If
    End Sub

    Private Sub bhsg_edit_profile_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bshg_edit_profile_save.Click
        Me.bshg_edit_profile_save.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False
        Me.bshg_edit_profile_cancel.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False
        If (Me.ktxt_edit_profile_name.Text = "" Or Me.UsersList.ContainsKey(Me.ktxt_edit_profile_name.Text)) Then

            Me.blink = New Transitions.Transition(New Transitions.TransitionType_Flash(1, 600))
            Me.blink.add(Me.pnl_edit_profile, "BackColor", Color.FromArgb(255, 255, 160, 160))
            Me.blink.add(Me.pnl_edit_profile_background, "BackColor", Color.FromArgb(255, 255, 160, 160))
            Me.blink.run()

            Me.bshg_edit_profile_save.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
            Me.bshg_edit_profile_cancel.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
        Else
            Me._Profiles.EditProfile(Me.EditUserID, Me.ktxt_edit_profile_name.Text)
            Me.RefreshProfiles()

            Me.hideAdd = New Transitions.Transition(New Transitions.TransitionType_Acceleration(100))
            Me.hideEdit_mg = New Transitions.Transition(New Transitions.TransitionType_Acceleration(100))

            Me.hideAdd.add(Me.khgp_edit_profile, "Top", Me.kpnl_window_background.Size.Height + 76)
            Me.hideEdit_mg.add(Me.khgp_profiles, "Height", Me.khgp_profiles.Size.Height + 76)

            Me.blink = New Transitions.Transition(New Transitions.TransitionType_Flash(1, 600))
            Me.blink.add(Me.pnl_edit_profile, "BackColor", Color.FromArgb(255, 173, 255, 160))
            Me.blink.add(Me.pnl_edit_profile_background, "BackColor", Color.FromArgb(255, 173, 255, 160))
            Transitions.Transition.runChain(Me.blink, Me.hideAdd, Me.hideEdit_mg)
        End If
    End Sub

    Private Sub bhsg_edit_profile_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bshg_edit_profile_cancel.Click
        If (Me.khgp_edit_profile.Visible = True) Then

            Me.hideAdd = New Transitions.Transition(New Transitions.TransitionType_Acceleration(100))
            Me.hideEdit_mg = New Transitions.Transition(New Transitions.TransitionType_Acceleration(100))

            Me.hideAdd.add(Me.khgp_edit_profile, "Top", Me.kpnl_window_background.Size.Height + 76)
            Me.hideEdit_mg.add(Me.khgp_profiles, "Height", Me.khgp_profiles.Size.Height + 76)
            Transitions.Transition.runChain(Me.hideAdd, Me.hideEdit_mg)
        End If
    End Sub

    Private Sub hideEdit_mg_TransitionCompletedEvent(ByVal sender As Object, ByVal e As Transitions.Transition.Args) Handles hideEdit_mg.TransitionCompletedEvent
        Me.ktxt_edit_profile_name.Text = ""
        Me.pnl_edit_profile.BackColor = Color.White
        Me.pnl_edit_profile_background.BackColor = Color.White
        Me.khgp_edit_profile.Visible = False
        Me.bshg_edit_profile_save.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
        Me.bshg_edit_profile_cancel.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
    End Sub

#End Region

    

    

 

    Private Sub bshg_remove_profile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bshg_remove_profile.Click
        If Not Me.kltb_profiles.SelectedItem = Nothing Then
            If (Me.UsersList.ContainsKey(Me.kltb_profiles.SelectedItem)) Then
                Me._Profiles.RemoveProfile(Me.UsersList(Me.kltb_profiles.SelectedItem))
            End If
            Me.kltb_profiles.Items.Remove(Me.kltb_profiles.SelectedItem)
        End If
    End Sub

    Private Sub kltb_profiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kltb_profiles.SelectedIndexChanged
        If (Me.kltb_profiles.SelectedItem = Nothing) Then
            Me.bshg_edit_profile.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False
            Me.bshg_remove_profile.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False
        Else
            Me.bshg_edit_profile.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
            Me.bshg_remove_profile.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
        End If
    End Sub

    Private Sub bshg_refresh_profiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bshg_refresh_profiles.Click
        Me.RefreshProfiles()
    End Sub
End Class
