<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_Projectile
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        DarkGroupBox1 = New DarkUI.Controls.DarkGroupBox()
        lstIndex = New ListBox()
        DarkGroupBox2 = New DarkUI.Controls.DarkGroupBox()
        DarkLabel5 = New DarkUI.Controls.DarkLabel()
        DarkLabel4 = New DarkUI.Controls.DarkLabel()
        nudDamage = New DarkUI.Controls.DarkNumericUpDown()
        nudSpeed = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel3 = New DarkUI.Controls.DarkLabel()
        nudRange = New DarkUI.Controls.DarkNumericUpDown()
        nudPic = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel2 = New DarkUI.Controls.DarkLabel()
        picProjectile = New PictureBox()
        txtName = New DarkUI.Controls.DarkTextBox()
        DarkLabel1 = New DarkUI.Controls.DarkLabel()
        btnSave = New DarkUI.Controls.DarkButton()
        btnCancel = New DarkUI.Controls.DarkButton()
        btnDelete = New DarkUI.Controls.DarkButton()
        DarkGroupBox1.SuspendLayout()
        DarkGroupBox2.SuspendLayout()
        CType(nudDamage, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudSpeed, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudRange, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudPic, ComponentModel.ISupportInitialize).BeginInit()
        CType(picProjectile, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DarkGroupBox1
        ' 
        DarkGroupBox1.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox1.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox1.Controls.Add(lstIndex)
        DarkGroupBox1.ForeColor = Color.Gainsboro
        DarkGroupBox1.Location = New Point(8, 6)
        DarkGroupBox1.Margin = New Padding(8, 6, 8, 6)
        DarkGroupBox1.Name = "DarkGroupBox1"
        DarkGroupBox1.Padding = New Padding(8, 6, 8, 6)
        DarkGroupBox1.Size = New Size(407, 460)
        DarkGroupBox1.TabIndex = 0
        DarkGroupBox1.TabStop = False
        DarkGroupBox1.Text = "Projectile List"
        ' 
        ' lstIndex
        ' 
        lstIndex.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        lstIndex.BorderStyle = BorderStyle.FixedSingle
        lstIndex.ForeColor = Color.Gainsboro
        lstIndex.FormattingEnabled = True
        lstIndex.Location = New Point(13, 43)
        lstIndex.Margin = New Padding(8, 6, 8, 6)
        lstIndex.Name = "lstIndex"
        lstIndex.Size = New Size(379, 386)
        lstIndex.TabIndex = 1
        ' 
        ' DarkGroupBox2
        ' 
        DarkGroupBox2.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox2.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox2.Controls.Add(DarkLabel5)
        DarkGroupBox2.Controls.Add(DarkLabel4)
        DarkGroupBox2.Controls.Add(nudDamage)
        DarkGroupBox2.Controls.Add(nudSpeed)
        DarkGroupBox2.Controls.Add(DarkLabel3)
        DarkGroupBox2.Controls.Add(nudRange)
        DarkGroupBox2.Controls.Add(nudPic)
        DarkGroupBox2.Controls.Add(DarkLabel2)
        DarkGroupBox2.Controls.Add(picProjectile)
        DarkGroupBox2.Controls.Add(txtName)
        DarkGroupBox2.Controls.Add(DarkLabel1)
        DarkGroupBox2.ForeColor = Color.Gainsboro
        DarkGroupBox2.Location = New Point(427, 6)
        DarkGroupBox2.Margin = New Padding(8, 6, 8, 6)
        DarkGroupBox2.Name = "DarkGroupBox2"
        DarkGroupBox2.Padding = New Padding(8, 6, 8, 6)
        DarkGroupBox2.Size = New Size(538, 672)
        DarkGroupBox2.TabIndex = 1
        DarkGroupBox2.TabStop = False
        DarkGroupBox2.Text = "Properties"
        ' 
        ' DarkLabel5
        ' 
        DarkLabel5.AutoSize = True
        DarkLabel5.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel5.Location = New Point(13, 480)
        DarkLabel5.Margin = New Padding(8, 0, 8, 0)
        DarkLabel5.Name = "DarkLabel5"
        DarkLabel5.Size = New Size(224, 32)
        DarkLabel5.TabIndex = 11
        DarkLabel5.Text = "Additional Damage:"
        ' 
        ' DarkLabel4
        ' 
        DarkLabel4.AutoSize = True
        DarkLabel4.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel4.Location = New Point(13, 416)
        DarkLabel4.Margin = New Padding(8, 0, 8, 0)
        DarkLabel4.Name = "DarkLabel4"
        DarkLabel4.Size = New Size(86, 32)
        DarkLabel4.TabIndex = 10
        DarkLabel4.Text = "Speed:"
        ' 
        ' nudDamage
        ' 
        nudDamage.Location = New Point(258, 476)
        nudDamage.Margin = New Padding(8, 6, 8, 6)
        nudDamage.Name = "nudDamage"
        nudDamage.Size = New Size(260, 39)
        nudDamage.TabIndex = 9
        ' 
        ' nudSpeed
        ' 
        nudSpeed.Location = New Point(258, 412)
        nudSpeed.Margin = New Padding(8, 6, 8, 6)
        nudSpeed.Name = "nudSpeed"
        nudSpeed.Size = New Size(260, 39)
        nudSpeed.TabIndex = 8
        ' 
        ' DarkLabel3
        ' 
        DarkLabel3.AutoSize = True
        DarkLabel3.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel3.Location = New Point(13, 352)
        DarkLabel3.Margin = New Padding(8, 0, 8, 0)
        DarkLabel3.Name = "DarkLabel3"
        DarkLabel3.Size = New Size(86, 32)
        DarkLabel3.TabIndex = 7
        DarkLabel3.Text = "Range:"
        ' 
        ' nudRange
        ' 
        nudRange.Location = New Point(258, 348)
        nudRange.Margin = New Padding(8, 6, 8, 6)
        nudRange.Name = "nudRange"
        nudRange.Size = New Size(260, 39)
        nudRange.TabIndex = 6
        ' 
        ' nudPic
        ' 
        nudPic.Location = New Point(258, 284)
        nudPic.Margin = New Padding(8, 6, 8, 6)
        nudPic.Name = "nudPic"
        nudPic.Size = New Size(260, 39)
        nudPic.TabIndex = 5
        ' 
        ' DarkLabel2
        ' 
        DarkLabel2.AutoSize = True
        DarkLabel2.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel2.Location = New Point(13, 288)
        DarkLabel2.Margin = New Padding(8, 0, 8, 0)
        DarkLabel2.Name = "DarkLabel2"
        DarkLabel2.Size = New Size(92, 32)
        DarkLabel2.TabIndex = 4
        DarkLabel2.Text = "Picture:"
        ' 
        ' picProjectile
        ' 
        picProjectile.BackColor = Color.Black
        picProjectile.Location = New Point(18, 111)
        picProjectile.Margin = New Padding(8, 6, 8, 6)
        picProjectile.Name = "picProjectile"
        picProjectile.Size = New Size(498, 158)
        picProjectile.TabIndex = 3
        picProjectile.TabStop = False
        ' 
        ' txtName
        ' 
        txtName.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtName.BorderStyle = BorderStyle.FixedSingle
        txtName.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtName.Location = New Point(208, 47)
        txtName.Margin = New Padding(8, 6, 8, 6)
        txtName.Name = "txtName"
        txtName.Size = New Size(306, 39)
        txtName.TabIndex = 1
        ' 
        ' DarkLabel1
        ' 
        DarkLabel1.AutoSize = True
        DarkLabel1.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel1.Location = New Point(13, 52)
        DarkLabel1.Margin = New Padding(8, 0, 8, 0)
        DarkLabel1.Name = "DarkLabel1"
        DarkLabel1.Size = New Size(83, 32)
        DarkLabel1.TabIndex = 0
        DarkLabel1.Text = "Name:"
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(21, 480)
        btnSave.Margin = New Padding(8, 6, 8, 6)
        btnSave.Name = "btnSave"
        btnSave.Padding = New Padding(11, 12, 11, 12)
        btnSave.Size = New Size(381, 58)
        btnSave.TabIndex = 2
        btnSave.Text = "Save"
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(21, 620)
        btnCancel.Margin = New Padding(8, 6, 8, 6)
        btnCancel.Name = "btnCancel"
        btnCancel.Padding = New Padding(11, 12, 11, 12)
        btnCancel.Size = New Size(381, 58)
        btnCancel.TabIndex = 3
        btnCancel.Text = "Cancel"
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(21, 550)
        btnDelete.Margin = New Padding(8, 6, 8, 6)
        btnDelete.Name = "btnDelete"
        btnDelete.Padding = New Padding(11, 12, 11, 12)
        btnDelete.Size = New Size(381, 58)
        btnDelete.TabIndex = 4
        btnDelete.Text = "Delete"
        ' 
        ' frmEditor_Projectile
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        ClientSize = New Size(979, 689)
        Controls.Add(btnDelete)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(DarkGroupBox2)
        Controls.Add(DarkGroupBox1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Margin = New Padding(8, 6, 8, 6)
        Name = "frmEditor_Projectile"
        Text = "Projectile Editor"
        DarkGroupBox1.ResumeLayout(False)
        DarkGroupBox2.ResumeLayout(False)
        DarkGroupBox2.PerformLayout()
        CType(nudDamage, ComponentModel.ISupportInitialize).EndInit()
        CType(nudSpeed, ComponentModel.ISupportInitialize).EndInit()
        CType(nudRange, ComponentModel.ISupportInitialize).EndInit()
        CType(nudPic, ComponentModel.ISupportInitialize).EndInit()
        CType(picProjectile, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents DarkGroupBox1 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents lstIndex As System.Windows.Forms.ListBox
    Friend WithEvents DarkGroupBox2 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents txtName As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel1 As DarkUI.Controls.DarkLabel
    Friend WithEvents picProjectile As System.Windows.Forms.PictureBox
    Friend WithEvents nudRange As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudPic As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel2 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel3 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudDamage As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudSpeed As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel4 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel5 As DarkUI.Controls.DarkLabel
    Friend WithEvents btnSave As DarkUI.Controls.DarkButton
    Friend WithEvents btnCancel As DarkUI.Controls.DarkButton
    Friend WithEvents btnDelete As DarkUI.Controls.DarkButton
End Class
