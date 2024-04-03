<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_Animation
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
        cmbSound = New DarkUI.Controls.DarkComboBox()
        DarkLabel2 = New DarkUI.Controls.DarkLabel()
        DarkGroupBox4 = New DarkUI.Controls.DarkGroupBox()
        nudLoopTime1 = New DarkUI.Controls.DarkNumericUpDown()
        nudFrameCount1 = New DarkUI.Controls.DarkNumericUpDown()
        nudLoopCount1 = New DarkUI.Controls.DarkNumericUpDown()
        nudSprite1 = New DarkUI.Controls.DarkNumericUpDown()
        lblLoopTime1 = New DarkUI.Controls.DarkLabel()
        lblFrameCount1 = New DarkUI.Controls.DarkLabel()
        lblLoopCount1 = New DarkUI.Controls.DarkLabel()
        lblSprite1 = New DarkUI.Controls.DarkLabel()
        picSprite1 = New PictureBox()
        DarkGroupBox3 = New DarkUI.Controls.DarkGroupBox()
        nudLoopTime0 = New DarkUI.Controls.DarkNumericUpDown()
        nudFrameCount0 = New DarkUI.Controls.DarkNumericUpDown()
        nudLoopCount0 = New DarkUI.Controls.DarkNumericUpDown()
        nudSprite0 = New DarkUI.Controls.DarkNumericUpDown()
        lblLoopTime0 = New DarkUI.Controls.DarkLabel()
        lblFrameCount0 = New DarkUI.Controls.DarkLabel()
        lblLoopCount0 = New DarkUI.Controls.DarkLabel()
        lblSprite0 = New DarkUI.Controls.DarkLabel()
        picSprite0 = New PictureBox()
        txtName = New DarkUI.Controls.DarkTextBox()
        DarkLabel1 = New DarkUI.Controls.DarkLabel()
        btnSave = New DarkUI.Controls.DarkButton()
        btnDelete = New DarkUI.Controls.DarkButton()
        btnCancel = New DarkUI.Controls.DarkButton()
        DarkGroupBox1.SuspendLayout()
        DarkGroupBox2.SuspendLayout()
        DarkGroupBox4.SuspendLayout()
        CType(nudLoopTime1, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudFrameCount1, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudLoopCount1, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudSprite1, ComponentModel.ISupportInitialize).BeginInit()
        CType(picSprite1, ComponentModel.ISupportInitialize).BeginInit()
        DarkGroupBox3.SuspendLayout()
        CType(nudLoopTime0, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudFrameCount0, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudLoopCount0, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudSprite0, ComponentModel.ISupportInitialize).BeginInit()
        CType(picSprite0, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DarkGroupBox1
        ' 
        DarkGroupBox1.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox1.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox1.Controls.Add(lstIndex)
        DarkGroupBox1.ForeColor = Color.Gainsboro
        DarkGroupBox1.Location = New Point(3, 5)
        DarkGroupBox1.Margin = New Padding(6, 5, 6, 5)
        DarkGroupBox1.Name = "DarkGroupBox1"
        DarkGroupBox1.Padding = New Padding(6, 5, 6, 5)
        DarkGroupBox1.Size = New Size(333, 716)
        DarkGroupBox1.TabIndex = 0
        DarkGroupBox1.TabStop = False
        DarkGroupBox1.Text = "Animation List"
        ' 
        ' lstIndex
        ' 
        lstIndex.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        lstIndex.BorderStyle = BorderStyle.None
        lstIndex.ForeColor = Color.Gainsboro
        lstIndex.FormattingEnabled = True
        lstIndex.ItemHeight = 25
        lstIndex.Location = New Point(10, 37)
        lstIndex.Margin = New Padding(6, 5, 6, 5)
        lstIndex.Name = "lstIndex"
        lstIndex.Size = New Size(313, 650)
        lstIndex.TabIndex = 0
        ' 
        ' DarkGroupBox2
        ' 
        DarkGroupBox2.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox2.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox2.Controls.Add(cmbSound)
        DarkGroupBox2.Controls.Add(DarkLabel2)
        DarkGroupBox2.Controls.Add(DarkGroupBox4)
        DarkGroupBox2.Controls.Add(DarkGroupBox3)
        DarkGroupBox2.Controls.Add(txtName)
        DarkGroupBox2.Controls.Add(DarkLabel1)
        DarkGroupBox2.ForeColor = Color.Gainsboro
        DarkGroupBox2.Location = New Point(347, 5)
        DarkGroupBox2.Margin = New Padding(6, 5, 6, 5)
        DarkGroupBox2.Name = "DarkGroupBox2"
        DarkGroupBox2.Padding = New Padding(6, 5, 6, 5)
        DarkGroupBox2.Size = New Size(730, 891)
        DarkGroupBox2.TabIndex = 1
        DarkGroupBox2.TabStop = False
        DarkGroupBox2.Text = "Properties"
        ' 
        ' cmbSound
        ' 
        cmbSound.DrawMode = DrawMode.OwnerDrawVariable
        cmbSound.FormattingEnabled = True
        cmbSound.Location = New Point(194, 103)
        cmbSound.Margin = New Padding(6, 5, 6, 5)
        cmbSound.Name = "cmbSound"
        cmbSound.Size = New Size(257, 32)
        cmbSound.TabIndex = 25
        ' 
        ' DarkLabel2
        ' 
        DarkLabel2.AutoSize = True
        DarkLabel2.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel2.Location = New Point(17, 106)
        DarkLabel2.Margin = New Padding(6, 0, 6, 0)
        DarkLabel2.Name = "DarkLabel2"
        DarkLabel2.Size = New Size(68, 25)
        DarkLabel2.TabIndex = 24
        DarkLabel2.Text = "Sound:"
        ' 
        ' DarkGroupBox4
        ' 
        DarkGroupBox4.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox4.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox4.Controls.Add(nudLoopTime1)
        DarkGroupBox4.Controls.Add(nudFrameCount1)
        DarkGroupBox4.Controls.Add(nudLoopCount1)
        DarkGroupBox4.Controls.Add(nudSprite1)
        DarkGroupBox4.Controls.Add(lblLoopTime1)
        DarkGroupBox4.Controls.Add(lblFrameCount1)
        DarkGroupBox4.Controls.Add(lblLoopCount1)
        DarkGroupBox4.Controls.Add(lblSprite1)
        DarkGroupBox4.Controls.Add(picSprite1)
        DarkGroupBox4.ForeColor = Color.Gainsboro
        DarkGroupBox4.Location = New Point(10, 534)
        DarkGroupBox4.Margin = New Padding(6, 5, 6, 5)
        DarkGroupBox4.Name = "DarkGroupBox4"
        DarkGroupBox4.Padding = New Padding(6, 5, 6, 5)
        DarkGroupBox4.Size = New Size(710, 347)
        DarkGroupBox4.TabIndex = 23
        DarkGroupBox4.TabStop = False
        DarkGroupBox4.Text = "Layer 1 - Above Player"
        ' 
        ' nudLoopTime1
        ' 
        nudLoopTime1.Location = New Point(146, 266)
        nudLoopTime1.Margin = New Padding(6, 5, 6, 5)
        nudLoopTime1.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        nudLoopTime1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudLoopTime1.Name = "nudLoopTime1"
        nudLoopTime1.Size = New Size(200, 31)
        nudLoopTime1.TabIndex = 33
        nudLoopTime1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' nudFrameCount1
        ' 
        nudFrameCount1.Location = New Point(146, 191)
        nudFrameCount1.Margin = New Padding(6, 5, 6, 5)
        nudFrameCount1.Name = "nudFrameCount1"
        nudFrameCount1.Size = New Size(200, 31)
        nudFrameCount1.TabIndex = 32
        ' 
        ' nudLoopCount1
        ' 
        nudLoopCount1.Location = New Point(146, 116)
        nudLoopCount1.Margin = New Padding(6, 5, 6, 5)
        nudLoopCount1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudLoopCount1.Name = "nudLoopCount1"
        nudLoopCount1.Size = New Size(200, 31)
        nudLoopCount1.TabIndex = 31
        nudLoopCount1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' nudSprite1
        ' 
        nudSprite1.Location = New Point(146, 47)
        nudSprite1.Margin = New Padding(6, 5, 6, 5)
        nudSprite1.Name = "nudSprite1"
        nudSprite1.Size = New Size(200, 31)
        nudSprite1.TabIndex = 30
        ' 
        ' lblLoopTime1
        ' 
        lblLoopTime1.AutoSize = True
        lblLoopTime1.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        lblLoopTime1.Location = New Point(17, 270)
        lblLoopTime1.Margin = New Padding(6, 0, 6, 0)
        lblLoopTime1.Name = "lblLoopTime1"
        lblLoopTime1.Size = New Size(100, 25)
        lblLoopTime1.TabIndex = 28
        lblLoopTime1.Text = "Loop Time:"
        ' 
        ' lblFrameCount1
        ' 
        lblFrameCount1.AutoSize = True
        lblFrameCount1.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        lblFrameCount1.Location = New Point(18, 195)
        lblFrameCount1.Margin = New Padding(6, 0, 6, 0)
        lblFrameCount1.Name = "lblFrameCount1"
        lblFrameCount1.Size = New Size(118, 25)
        lblFrameCount1.TabIndex = 26
        lblFrameCount1.Text = "Frame Count:"
        ' 
        ' lblLoopCount1
        ' 
        lblLoopCount1.AutoSize = True
        lblLoopCount1.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        lblLoopCount1.Location = New Point(18, 122)
        lblLoopCount1.Margin = New Padding(6, 0, 6, 0)
        lblLoopCount1.Name = "lblLoopCount1"
        lblLoopCount1.Size = New Size(110, 25)
        lblLoopCount1.TabIndex = 24
        lblLoopCount1.Text = "Loop Count:"
        ' 
        ' lblSprite1
        ' 
        lblSprite1.AutoSize = True
        lblSprite1.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        lblSprite1.Location = New Point(17, 50)
        lblSprite1.Margin = New Padding(6, 0, 6, 0)
        lblSprite1.Name = "lblSprite1"
        lblSprite1.Size = New Size(62, 25)
        lblSprite1.TabIndex = 22
        lblSprite1.Text = "Sprite:"
        ' 
        ' picSprite1
        ' 
        picSprite1.BackColor = Color.Black
        picSprite1.Location = New Point(366, 20)
        picSprite1.Margin = New Padding(6, 5, 6, 5)
        picSprite1.Name = "picSprite1"
        picSprite1.Size = New Size(342, 316)
        picSprite1.TabIndex = 21
        picSprite1.TabStop = False
        ' 
        ' DarkGroupBox3
        ' 
        DarkGroupBox3.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox3.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox3.Controls.Add(nudLoopTime0)
        DarkGroupBox3.Controls.Add(nudFrameCount0)
        DarkGroupBox3.Controls.Add(nudLoopCount0)
        DarkGroupBox3.Controls.Add(nudSprite0)
        DarkGroupBox3.Controls.Add(lblLoopTime0)
        DarkGroupBox3.Controls.Add(lblFrameCount0)
        DarkGroupBox3.Controls.Add(lblLoopCount0)
        DarkGroupBox3.Controls.Add(lblSprite0)
        DarkGroupBox3.Controls.Add(picSprite0)
        DarkGroupBox3.ForeColor = Color.Gainsboro
        DarkGroupBox3.Location = New Point(10, 177)
        DarkGroupBox3.Margin = New Padding(6, 5, 6, 5)
        DarkGroupBox3.Name = "DarkGroupBox3"
        DarkGroupBox3.Padding = New Padding(6, 5, 6, 5)
        DarkGroupBox3.Size = New Size(710, 347)
        DarkGroupBox3.TabIndex = 22
        DarkGroupBox3.TabStop = False
        DarkGroupBox3.Text = "Layer 0 - Beneath Player"
        ' 
        ' nudLoopTime0
        ' 
        nudLoopTime0.Location = New Point(146, 266)
        nudLoopTime0.Margin = New Padding(6, 5, 6, 5)
        nudLoopTime0.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        nudLoopTime0.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudLoopTime0.Name = "nudLoopTime0"
        nudLoopTime0.Size = New Size(200, 31)
        nudLoopTime0.TabIndex = 33
        nudLoopTime0.Value = New Decimal(New Integer() {100, 0, 0, 0})
        ' 
        ' nudFrameCount0
        ' 
        nudFrameCount0.Location = New Point(146, 191)
        nudFrameCount0.Margin = New Padding(6, 5, 6, 5)
        nudFrameCount0.Name = "nudFrameCount0"
        nudFrameCount0.Size = New Size(200, 31)
        nudFrameCount0.TabIndex = 32
        ' 
        ' nudLoopCount0
        ' 
        nudLoopCount0.Location = New Point(146, 116)
        nudLoopCount0.Margin = New Padding(6, 5, 6, 5)
        nudLoopCount0.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudLoopCount0.Name = "nudLoopCount0"
        nudLoopCount0.Size = New Size(200, 31)
        nudLoopCount0.TabIndex = 31
        nudLoopCount0.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' nudSprite0
        ' 
        nudSprite0.Location = New Point(146, 47)
        nudSprite0.Margin = New Padding(6, 5, 6, 5)
        nudSprite0.Name = "nudSprite0"
        nudSprite0.Size = New Size(200, 31)
        nudSprite0.TabIndex = 30
        ' 
        ' lblLoopTime0
        ' 
        lblLoopTime0.AutoSize = True
        lblLoopTime0.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        lblLoopTime0.Location = New Point(17, 270)
        lblLoopTime0.Margin = New Padding(6, 0, 6, 0)
        lblLoopTime0.Name = "lblLoopTime0"
        lblLoopTime0.Size = New Size(100, 25)
        lblLoopTime0.TabIndex = 28
        lblLoopTime0.Text = "Loop Time:"
        ' 
        ' lblFrameCount0
        ' 
        lblFrameCount0.AutoSize = True
        lblFrameCount0.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        lblFrameCount0.Location = New Point(18, 195)
        lblFrameCount0.Margin = New Padding(6, 0, 6, 0)
        lblFrameCount0.Name = "lblFrameCount0"
        lblFrameCount0.Size = New Size(118, 25)
        lblFrameCount0.TabIndex = 26
        lblFrameCount0.Text = "Frame Count:"
        ' 
        ' lblLoopCount0
        ' 
        lblLoopCount0.AutoSize = True
        lblLoopCount0.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        lblLoopCount0.Location = New Point(18, 122)
        lblLoopCount0.Margin = New Padding(6, 0, 6, 0)
        lblLoopCount0.Name = "lblLoopCount0"
        lblLoopCount0.Size = New Size(110, 25)
        lblLoopCount0.TabIndex = 24
        lblLoopCount0.Text = "Loop Count:"
        ' 
        ' lblSprite0
        ' 
        lblSprite0.AutoSize = True
        lblSprite0.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        lblSprite0.Location = New Point(17, 50)
        lblSprite0.Margin = New Padding(6, 0, 6, 0)
        lblSprite0.Name = "lblSprite0"
        lblSprite0.Size = New Size(62, 25)
        lblSprite0.TabIndex = 22
        lblSprite0.Text = "Sprite:"
        ' 
        ' picSprite0
        ' 
        picSprite0.BackColor = Color.Black
        picSprite0.Location = New Point(366, 20)
        picSprite0.Margin = New Padding(6, 5, 6, 5)
        picSprite0.Name = "picSprite0"
        picSprite0.Size = New Size(342, 316)
        picSprite0.TabIndex = 21
        picSprite0.TabStop = False
        ' 
        ' txtName
        ' 
        txtName.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtName.BorderStyle = BorderStyle.FixedSingle
        txtName.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtName.Location = New Point(194, 53)
        txtName.Margin = New Padding(6, 5, 6, 5)
        txtName.Name = "txtName"
        txtName.Size = New Size(524, 31)
        txtName.TabIndex = 1
        ' 
        ' DarkLabel1
        ' 
        DarkLabel1.AutoSize = True
        DarkLabel1.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel1.Location = New Point(17, 55)
        DarkLabel1.Margin = New Padding(6, 0, 6, 0)
        DarkLabel1.Name = "DarkLabel1"
        DarkLabel1.Size = New Size(63, 25)
        DarkLabel1.TabIndex = 0
        DarkLabel1.Text = "Name:"
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(13, 741)
        btnSave.Margin = New Padding(6, 5, 6, 5)
        btnSave.Name = "btnSave"
        btnSave.Padding = New Padding(8, 9, 8, 9)
        btnSave.Size = New Size(313, 45)
        btnSave.TabIndex = 2
        btnSave.Text = "Save"
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(13, 796)
        btnDelete.Margin = New Padding(6, 5, 6, 5)
        btnDelete.Name = "btnDelete"
        btnDelete.Padding = New Padding(8, 9, 8, 9)
        btnDelete.Size = New Size(313, 45)
        btnDelete.TabIndex = 3
        btnDelete.Text = "Delete"
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(13, 851)
        btnCancel.Margin = New Padding(6, 5, 6, 5)
        btnCancel.Name = "btnCancel"
        btnCancel.Padding = New Padding(8, 9, 8, 9)
        btnCancel.Size = New Size(313, 45)
        btnCancel.TabIndex = 4
        btnCancel.Text = "Cancel"
        ' 
        ' frmEditor_Animation
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        ClientSize = New Size(1083, 903)
        Controls.Add(btnCancel)
        Controls.Add(btnDelete)
        Controls.Add(btnSave)
        Controls.Add(DarkGroupBox2)
        Controls.Add(DarkGroupBox1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Margin = New Padding(6, 5, 6, 5)
        Name = "frmEditor_Animation"
        Text = "Animation Editor"
        DarkGroupBox1.ResumeLayout(False)
        DarkGroupBox2.ResumeLayout(False)
        DarkGroupBox2.PerformLayout()
        DarkGroupBox4.ResumeLayout(False)
        DarkGroupBox4.PerformLayout()
        CType(nudLoopTime1, ComponentModel.ISupportInitialize).EndInit()
        CType(nudFrameCount1, ComponentModel.ISupportInitialize).EndInit()
        CType(nudLoopCount1, ComponentModel.ISupportInitialize).EndInit()
        CType(nudSprite1, ComponentModel.ISupportInitialize).EndInit()
        CType(picSprite1, ComponentModel.ISupportInitialize).EndInit()
        DarkGroupBox3.ResumeLayout(False)
        DarkGroupBox3.PerformLayout()
        CType(nudLoopTime0, ComponentModel.ISupportInitialize).EndInit()
        CType(nudFrameCount0, ComponentModel.ISupportInitialize).EndInit()
        CType(nudLoopCount0, ComponentModel.ISupportInitialize).EndInit()
        CType(nudSprite0, ComponentModel.ISupportInitialize).EndInit()
        CType(picSprite0, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents DarkGroupBox1 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents DarkGroupBox2 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents lstIndex As System.Windows.Forms.ListBox
    Friend WithEvents txtName As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel1 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkGroupBox3 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents picSprite0 As System.Windows.Forms.PictureBox
    Friend WithEvents lblLoopCount0 As DarkUI.Controls.DarkLabel
    Friend WithEvents lblSprite0 As DarkUI.Controls.DarkLabel
    Friend WithEvents lblLoopTime0 As DarkUI.Controls.DarkLabel
    Friend WithEvents lblFrameCount0 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkGroupBox4 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents lblLoopTime1 As DarkUI.Controls.DarkLabel
    Friend WithEvents lblFrameCount1 As DarkUI.Controls.DarkLabel
    Friend WithEvents lblLoopCount1 As DarkUI.Controls.DarkLabel
    Friend WithEvents lblSprite1 As DarkUI.Controls.DarkLabel
    Friend WithEvents picSprite1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnSave As DarkUI.Controls.DarkButton
    Friend WithEvents btnDelete As DarkUI.Controls.DarkButton
    Friend WithEvents btnCancel As DarkUI.Controls.DarkButton
    Friend WithEvents nudLoopTime0 As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudFrameCount0 As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudLoopCount0 As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudSprite0 As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudLoopTime1 As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudFrameCount1 As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudLoopCount1 As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudSprite1 As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents cmbSound As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel2 As DarkUI.Controls.DarkLabel
End Class
