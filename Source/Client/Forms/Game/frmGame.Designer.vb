<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmGame
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing And components IsNot Nothing Then
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGame))
        picscreen = New PictureBox()
        CType(picscreen, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' picscreen
        ' 
        picscreen.Location = New Point(0, 0)
        picscreen.Margin = New Padding(9, 8, 9, 8)
        picscreen.Name = "picscreen"
        picscreen.Size = New Size(1785, 1389)
        picscreen.TabIndex = 4
        picscreen.TabStop = False
        ' 
        ' FrmGame
        ' 
        AutoScaleDimensions = New SizeF(17F, 41F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1799, 1411)
        Controls.Add(picscreen)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(9, 8, 9, 8)
        MaximizeBox = False
        Name = "FrmGame"
        Opacity = 0R
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmMainGame"
        CType(picscreen, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub
    Friend WithEvents picscreen As System.Windows.Forms.PictureBox
End Class
