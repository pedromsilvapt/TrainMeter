<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_record_run
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
        Me.KryptonPanel = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.kdud_tracks = New ComponentFactory.Krypton.Toolkit.KryptonDomainUpDown()
        Me.klbl_tracks = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.kdud_profiles = New ComponentFactory.Krypton.Toolkit.KryptonDomainUpDown()
        Me.klbl_cron = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.kbtn_stop = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.kbtn_start = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.klbl_laps = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.knud_laps = New ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown()
        Me.klbl_distance = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.klbl_distance_unit = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge1 = New ComponentFactory.Krypton.Toolkit.KryptonBorderEdge()
        Me.klbl_saved = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonPanel
        '
        Me.KryptonPanel.Controls.Add(Me.klbl_saved)
        Me.KryptonPanel.Controls.Add(Me.KryptonBorderEdge1)
        Me.KryptonPanel.Controls.Add(Me.klbl_distance_unit)
        Me.KryptonPanel.Controls.Add(Me.klbl_distance)
        Me.KryptonPanel.Controls.Add(Me.knud_laps)
        Me.KryptonPanel.Controls.Add(Me.klbl_laps)
        Me.KryptonPanel.Controls.Add(Me.kdud_tracks)
        Me.KryptonPanel.Controls.Add(Me.klbl_tracks)
        Me.KryptonPanel.Controls.Add(Me.kdud_profiles)
        Me.KryptonPanel.Controls.Add(Me.klbl_cron)
        Me.KryptonPanel.Controls.Add(Me.kbtn_stop)
        Me.KryptonPanel.Controls.Add(Me.kbtn_start)
        Me.KryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel.Name = "KryptonPanel"
        Me.KryptonPanel.Size = New System.Drawing.Size(528, 165)
        Me.KryptonPanel.TabIndex = 0
        '
        'kdud_tracks
        '
        Me.kdud_tracks.Location = New System.Drawing.Point(393, 130)
        Me.kdud_tracks.Name = "kdud_tracks"
        Me.kdud_tracks.Size = New System.Drawing.Size(120, 22)
        Me.kdud_tracks.TabIndex = 5
        '
        'klbl_tracks
        '
        Me.klbl_tracks.Location = New System.Drawing.Point(340, 130)
        Me.klbl_tracks.Name = "klbl_tracks"
        Me.klbl_tracks.Size = New System.Drawing.Size(44, 20)
        Me.klbl_tracks.TabIndex = 4
        Me.klbl_tracks.Values.Text = "Pistas:"
        '
        'kdud_profiles
        '
        Me.kdud_profiles.Location = New System.Drawing.Point(12, 128)
        Me.kdud_profiles.Name = "kdud_profiles"
        Me.kdud_profiles.Size = New System.Drawing.Size(120, 22)
        Me.kdud_profiles.TabIndex = 3
        '
        'klbl_cron
        '
        Me.klbl_cron.Location = New System.Drawing.Point(83, 25)
        Me.klbl_cron.Name = "klbl_cron"
        Me.klbl_cron.Size = New System.Drawing.Size(248, 83)
        Me.klbl_cron.StateCommon.LongText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.klbl_cron.StateCommon.ShortText.Color1 = System.Drawing.Color.White
        Me.klbl_cron.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.klbl_cron.TabIndex = 2
        Me.klbl_cron.Values.Text = "0:00:00"
        '
        'kbtn_stop
        '
        Me.kbtn_stop.Location = New System.Drawing.Point(12, 58)
        Me.kbtn_stop.Name = "kbtn_stop"
        Me.kbtn_stop.Size = New System.Drawing.Size(50, 50)
        Me.kbtn_stop.TabIndex = 1
        Me.kbtn_stop.Values.Text = "Guardar"
        '
        'kbtn_start
        '
        Me.kbtn_start.Location = New System.Drawing.Point(12, 3)
        Me.kbtn_start.Name = "kbtn_start"
        Me.kbtn_start.Size = New System.Drawing.Size(50, 50)
        Me.kbtn_start.TabIndex = 0
        Me.kbtn_start.Tag = "1"
        Me.kbtn_start.Values.Text = "Start"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Black
        '
        'Timer1
        '
        '
        'klbl_laps
        '
        Me.klbl_laps.Location = New System.Drawing.Point(340, 106)
        Me.klbl_laps.Name = "klbl_laps"
        Me.klbl_laps.Size = New System.Drawing.Size(44, 20)
        Me.klbl_laps.TabIndex = 6
        Me.klbl_laps.Values.Text = "Voltas"
        '
        'knud_laps
        '
        Me.knud_laps.Location = New System.Drawing.Point(393, 106)
        Me.knud_laps.Maximum = New Decimal(New Integer() {240, 0, 0, 0})
        Me.knud_laps.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.knud_laps.Name = "knud_laps"
        Me.knud_laps.Size = New System.Drawing.Size(120, 22)
        Me.knud_laps.TabIndex = 7
        Me.knud_laps.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'klbl_distance
        '
        Me.klbl_distance.AutoSize = False
        Me.klbl_distance.Location = New System.Drawing.Point(365, 9)
        Me.klbl_distance.Name = "klbl_distance"
        Me.klbl_distance.Size = New System.Drawing.Size(162, 64)
        Me.klbl_distance.StateCommon.ShortText.Color1 = System.Drawing.Color.Lime
        Me.klbl_distance.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.klbl_distance.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.klbl_distance.TabIndex = 8
        Me.klbl_distance.Values.Text = "100"
        '
        'klbl_distance_unit
        '
        Me.klbl_distance_unit.Location = New System.Drawing.Point(398, 58)
        Me.klbl_distance_unit.Name = "klbl_distance_unit"
        Me.klbl_distance_unit.Size = New System.Drawing.Size(104, 36)
        Me.klbl_distance_unit.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.klbl_distance_unit.StateCommon.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.klbl_distance_unit.TabIndex = 9
        Me.klbl_distance_unit.Values.Text = "metros"
        '
        'KryptonBorderEdge1
        '
        Me.KryptonBorderEdge1.AutoSize = False
        Me.KryptonBorderEdge1.Location = New System.Drawing.Point(330, 7)
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonBorderEdge1.Size = New System.Drawing.Size(1, 150)
        Me.KryptonBorderEdge1.StateCommon.Color1 = System.Drawing.Color.DimGray
        Me.KryptonBorderEdge1.Text = "KryptonBorderEdge1"
        '
        'klbl_saved
        '
        Me.klbl_saved.Location = New System.Drawing.Point(205, 133)
        Me.klbl_saved.Name = "klbl_saved"
        Me.klbl_saved.Size = New System.Drawing.Size(68, 20)
        Me.klbl_saved.StateCommon.ShortText.Color1 = System.Drawing.Color.Lime
        Me.klbl_saved.TabIndex = 11
        Me.klbl_saved.Values.Text = "Guardado!"
        Me.klbl_saved.Visible = False
        '
        'frm_record_run
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 165)
        Me.Controls.Add(Me.KryptonPanel)
        Me.Name = "frm_record_run"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gravar Corrida"
        CType(Me.KryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel.ResumeLayout(False)
        Me.KryptonPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonPanel As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents kbtn_start As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents kbtn_stop As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents klbl_cron As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents kdud_profiles As ComponentFactory.Krypton.Toolkit.KryptonDomainUpDown
    Friend WithEvents kdud_tracks As ComponentFactory.Krypton.Toolkit.KryptonDomainUpDown
    Friend WithEvents klbl_tracks As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents klbl_laps As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents klbl_distance_unit As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents klbl_distance As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents knud_laps As ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown
    Friend WithEvents KryptonBorderEdge1 As ComponentFactory.Krypton.Toolkit.KryptonBorderEdge
    Friend WithEvents klbl_saved As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
