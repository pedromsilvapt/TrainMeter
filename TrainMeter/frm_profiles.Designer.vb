<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_profiles
    Inherits ComponentFactory.Krypton.Toolkit.KryptonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_profiles))
        Me.kpnl_window_background = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.khgp_add_profile = New ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup()
        Me.bhsg_add_profile_save = New ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup()
        Me.bhsg_add_profile_cancel = New ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup()
        Me.pnl_add_profile_background = New System.Windows.Forms.Panel()
        Me.pnl_add_profile = New System.Windows.Forms.Panel()
        Me.ktxt_add_profile_name = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.klbl_add_profile_name = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.khgp_profiles = New ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup()
        Me.bshg_add_profile = New ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup()
        Me.bshg_refresh_profiles = New ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup()
        Me.bshg_edit_profile = New ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup()
        Me.bshg_remove_profile = New ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup()
        Me.klbl_no_profiles = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.kltb_profiles = New ComponentFactory.Krypton.Toolkit.KryptonListBox()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        CType(Me.kpnl_window_background, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kpnl_window_background.SuspendLayout()
        CType(Me.khgp_add_profile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.khgp_add_profile.Panel.SuspendLayout()
        Me.khgp_add_profile.SuspendLayout()
        Me.pnl_add_profile_background.SuspendLayout()
        Me.pnl_add_profile.SuspendLayout()
        CType(Me.khgp_profiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.khgp_profiles.Panel.SuspendLayout()
        Me.khgp_profiles.SuspendLayout()
        Me.SuspendLayout()
        '
        'kpnl_window_background
        '
        Me.kpnl_window_background.Controls.Add(Me.khgp_add_profile)
        Me.kpnl_window_background.Controls.Add(Me.khgp_profiles)
        Me.kpnl_window_background.Dock = System.Windows.Forms.DockStyle.Fill
        Me.kpnl_window_background.Location = New System.Drawing.Point(0, 0)
        Me.kpnl_window_background.Name = "kpnl_window_background"
        Me.kpnl_window_background.Size = New System.Drawing.Size(362, 288)
        Me.kpnl_window_background.TabIndex = 0
        '
        'khgp_add_profile
        '
        Me.khgp_add_profile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.khgp_add_profile.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup() {Me.bhsg_add_profile_save, Me.bhsg_add_profile_cancel})
        Me.khgp_add_profile.HeaderVisibleSecondary = False
        Me.khgp_add_profile.Location = New System.Drawing.Point(2, 210)
        Me.khgp_add_profile.Name = "khgp_add_profile"
        '
        'khgp_add_profile.Panel
        '
        Me.khgp_add_profile.Panel.Controls.Add(Me.pnl_add_profile_background)
        Me.khgp_add_profile.Size = New System.Drawing.Size(360, 76)
        Me.khgp_add_profile.TabIndex = 1
        Me.khgp_add_profile.ValuesPrimary.Heading = "Adicionar Perfil"
        Me.khgp_add_profile.ValuesPrimary.Image = CType(resources.GetObject("khgp_add_profile.ValuesPrimary.Image"), System.Drawing.Image)
        Me.khgp_add_profile.Visible = False
        '
        'bhsg_add_profile_save
        '
        Me.bhsg_add_profile_save.Image = CType(resources.GetObject("bhsg_add_profile_save.Image"), System.Drawing.Image)
        Me.bhsg_add_profile_save.UniqueName = "AE3D49526EE54AACD28AEF6300B26AA3"
        '
        'bhsg_add_profile_cancel
        '
        Me.bhsg_add_profile_cancel.Image = CType(resources.GetObject("bhsg_add_profile_cancel.Image"), System.Drawing.Image)
        Me.bhsg_add_profile_cancel.UniqueName = "4DEBC9106A99440EBC91D9A8CC5FEEA6"
        '
        'pnl_add_profile_background
        '
        Me.pnl_add_profile_background.BackColor = System.Drawing.Color.White
        Me.pnl_add_profile_background.Controls.Add(Me.pnl_add_profile)
        Me.pnl_add_profile_background.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_add_profile_background.Location = New System.Drawing.Point(0, 0)
        Me.pnl_add_profile_background.Name = "pnl_add_profile_background"
        Me.pnl_add_profile_background.Size = New System.Drawing.Size(358, 44)
        Me.pnl_add_profile_background.TabIndex = 3
        '
        'pnl_add_profile
        '
        Me.pnl_add_profile.BackColor = System.Drawing.Color.White
        Me.pnl_add_profile.Controls.Add(Me.ktxt_add_profile_name)
        Me.pnl_add_profile.Controls.Add(Me.klbl_add_profile_name)
        Me.pnl_add_profile.Location = New System.Drawing.Point(63, 6)
        Me.pnl_add_profile.Name = "pnl_add_profile"
        Me.pnl_add_profile.Size = New System.Drawing.Size(202, 35)
        Me.pnl_add_profile.TabIndex = 2
        '
        'ktxt_add_profile_name
        '
        Me.ktxt_add_profile_name.Location = New System.Drawing.Point(71, 8)
        Me.ktxt_add_profile_name.Name = "ktxt_add_profile_name"
        Me.ktxt_add_profile_name.Size = New System.Drawing.Size(100, 20)
        Me.ktxt_add_profile_name.TabIndex = 1
        '
        'klbl_add_profile_name
        '
        Me.klbl_add_profile_name.Location = New System.Drawing.Point(26, 8)
        Me.klbl_add_profile_name.Name = "klbl_add_profile_name"
        Me.klbl_add_profile_name.Size = New System.Drawing.Size(47, 20)
        Me.klbl_add_profile_name.TabIndex = 0
        Me.klbl_add_profile_name.Values.Text = "Nome:"
        '
        'khgp_profiles
        '
        Me.khgp_profiles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.khgp_profiles.ButtonSpecs.AddRange(New ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup() {Me.bshg_add_profile, Me.bshg_refresh_profiles, Me.bshg_edit_profile, Me.bshg_remove_profile})
        Me.khgp_profiles.HeaderVisibleSecondary = False
        Me.khgp_profiles.Location = New System.Drawing.Point(2, 2)
        Me.khgp_profiles.Name = "khgp_profiles"
        '
        'khgp_profiles.Panel
        '
        Me.khgp_profiles.Panel.Controls.Add(Me.klbl_no_profiles)
        Me.khgp_profiles.Panel.Controls.Add(Me.kltb_profiles)
        Me.khgp_profiles.Size = New System.Drawing.Size(360, 286)
        Me.khgp_profiles.TabIndex = 0
        Me.khgp_profiles.ValuesPrimary.Heading = "Perfis"
        Me.khgp_profiles.ValuesPrimary.Image = CType(resources.GetObject("khgp_profiles.ValuesPrimary.Image"), System.Drawing.Image)
        '
        'bshg_add_profile
        '
        Me.bshg_add_profile.Image = CType(resources.GetObject("bshg_add_profile.Image"), System.Drawing.Image)
        Me.bshg_add_profile.Text = "Novo Perfil"
        Me.bshg_add_profile.UniqueName = "C99D0863DF364ADE75863B3B78DD76CA"
        '
        'bshg_refresh_profiles
        '
        Me.bshg_refresh_profiles.Image = CType(resources.GetObject("bshg_refresh_profiles.Image"), System.Drawing.Image)
        Me.bshg_refresh_profiles.UniqueName = "243EB21FA8AF46C4958B130AD63C25BC"
        '
        'bshg_edit_profile
        '
        Me.bshg_edit_profile.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.[False]
        Me.bshg_edit_profile.Image = CType(resources.GetObject("bshg_edit_profile.Image"), System.Drawing.Image)
        Me.bshg_edit_profile.UniqueName = "85DFC44C4DD4425F9EBF03E504EFC59E"
        '
        'bshg_remove_profile
        '
        Me.bshg_remove_profile.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.[False]
        Me.bshg_remove_profile.Image = CType(resources.GetObject("bshg_remove_profile.Image"), System.Drawing.Image)
        Me.bshg_remove_profile.UniqueName = "C313D617A305473C42AC197F77FFA5F2"
        '
        'klbl_no_profiles
        '
        Me.klbl_no_profiles.Location = New System.Drawing.Point(134, 80)
        Me.klbl_no_profiles.Name = "klbl_no_profiles"
        Me.klbl_no_profiles.Size = New System.Drawing.Size(86, 20)
        Me.klbl_no_profiles.TabIndex = 1
        Me.klbl_no_profiles.Values.Text = "Não há perfis."
        Me.klbl_no_profiles.Visible = False
        '
        'kltb_profiles
        '
        Me.kltb_profiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.kltb_profiles.Location = New System.Drawing.Point(0, 0)
        Me.kltb_profiles.Name = "kltb_profiles"
        Me.kltb_profiles.Size = New System.Drawing.Size(358, 254)
        Me.kltb_profiles.TabIndex = 0
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Black
        '
        'frm_profiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(362, 288)
        Me.Controls.Add(Me.kpnl_window_background)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frm_profiles"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Perfis"
        CType(Me.kpnl_window_background, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kpnl_window_background.ResumeLayout(False)
        Me.khgp_add_profile.Panel.ResumeLayout(False)
        CType(Me.khgp_add_profile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.khgp_add_profile.ResumeLayout(False)
        Me.pnl_add_profile_background.ResumeLayout(False)
        Me.pnl_add_profile.ResumeLayout(False)
        Me.pnl_add_profile.PerformLayout()
        Me.khgp_profiles.Panel.ResumeLayout(False)
        Me.khgp_profiles.Panel.PerformLayout()
        CType(Me.khgp_profiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.khgp_profiles.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents kpnl_window_background As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents khgp_profiles As ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup
    Friend WithEvents kltb_profiles As ComponentFactory.Krypton.Toolkit.KryptonListBox
    Friend WithEvents klbl_no_profiles As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents bshg_add_profile As ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup
    Friend WithEvents bshg_edit_profile As ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup
    Friend WithEvents bshg_remove_profile As ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup
    Friend WithEvents khgp_add_profile As ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup
    Friend WithEvents bhsg_add_profile_save As ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup
    Friend WithEvents klbl_add_profile_name As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents ktxt_add_profile_name As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents pnl_add_profile As System.Windows.Forms.Panel
    Friend WithEvents bhsg_add_profile_cancel As ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup
    Friend WithEvents pnl_add_profile_background As System.Windows.Forms.Panel
    Friend WithEvents bshg_refresh_profiles As ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup
End Class
