<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_init
    Inherits ComponentFactory.Krypton.Toolkit.KryptonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.kbtn_runs = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.kbtn_profiles = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.kbtn_quit = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonManager1 = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.SuspendLayout()
        '
        'kbtn_runs
        '
        Me.kbtn_runs.Location = New System.Drawing.Point(12, 12)
        Me.kbtn_runs.Name = "kbtn_runs"
        Me.kbtn_runs.Size = New System.Drawing.Size(121, 110)
        Me.kbtn_runs.TabIndex = 0
        Me.kbtn_runs.Values.Text = "Corridas"
        '
        'kbtn_profiles
        '
        Me.kbtn_profiles.Location = New System.Drawing.Point(139, 12)
        Me.kbtn_profiles.Name = "kbtn_profiles"
        Me.kbtn_profiles.Size = New System.Drawing.Size(121, 110)
        Me.kbtn_profiles.TabIndex = 2
        Me.kbtn_profiles.Values.Text = "Gerir Perfis"
        '
        'kbtn_quit
        '
        Me.kbtn_quit.Location = New System.Drawing.Point(266, 12)
        Me.kbtn_quit.Name = "kbtn_quit"
        Me.kbtn_quit.Size = New System.Drawing.Size(121, 110)
        Me.kbtn_quit.TabIndex = 3
        Me.kbtn_quit.Values.Text = "Sair"
        '
        'KryptonManager1
        '
        Me.KryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Black
        '
        'frm_init
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 134)
        Me.Controls.Add(Me.kbtn_quit)
        Me.Controls.Add(Me.kbtn_profiles)
        Me.Controls.Add(Me.kbtn_runs)
        Me.Name = "frm_init"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TrainMeter"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents kbtn_runs As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents kbtn_profiles As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents kbtn_quit As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonManager1 As ComponentFactory.Krypton.Toolkit.KryptonManager

End Class
