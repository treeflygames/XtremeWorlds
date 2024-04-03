<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_Resource
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
        DarkGroupBox5 = New DarkUI.Controls.DarkGroupBox()
        nudRewardExp = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel13 = New DarkUI.Controls.DarkLabel()
        cmbRewardItem = New DarkUI.Controls.DarkComboBox()
        DarkLabel12 = New DarkUI.Controls.DarkLabel()
        DarkGroupBox4 = New DarkUI.Controls.DarkGroupBox()
        nudLvlReq = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel11 = New DarkUI.Controls.DarkLabel()
        cmbTool = New DarkUI.Controls.DarkComboBox()
        DarkLabel10 = New DarkUI.Controls.DarkLabel()
        cmbAnimation = New DarkUI.Controls.DarkComboBox()
        DarkLabel9 = New DarkUI.Controls.DarkLabel()
        nudRespawn = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel8 = New DarkUI.Controls.DarkLabel()
        DarkGroupBox3 = New DarkUI.Controls.DarkGroupBox()
        nudExhaustedPic = New DarkUI.Controls.DarkNumericUpDown()
        nudNormalPic = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel7 = New DarkUI.Controls.DarkLabel()
        DarkLabel6 = New DarkUI.Controls.DarkLabel()
        picExhaustedPic = New PictureBox()
        picNormalpic = New PictureBox()
        nudHealth = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel5 = New DarkUI.Controls.DarkLabel()
        cmbType = New DarkUI.Controls.DarkComboBox()
        DarkLabel4 = New DarkUI.Controls.DarkLabel()
        DarkLabel3 = New DarkUI.Controls.DarkLabel()
        txtMessage2 = New DarkUI.Controls.DarkTextBox()
        txtMessage = New DarkUI.Controls.DarkTextBox()
        DarkLabel2 = New DarkUI.Controls.DarkLabel()
        txtName = New DarkUI.Controls.DarkTextBox()
        DarkLabel1 = New DarkUI.Controls.DarkLabel()
        btnSave = New DarkUI.Controls.DarkButton()
        btnDelete = New DarkUI.Controls.DarkButton()
        btnCancel = New DarkUI.Controls.DarkButton()
        DarkGroupBox1.SuspendLayout()
        DarkGroupBox2.SuspendLayout()
        DarkGroupBox5.SuspendLayout()
        CType(nudRewardExp, ComponentModel.ISupportInitialize).BeginInit()
        DarkGroupBox4.SuspendLayout()
        CType(nudLvlReq, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudRespawn, ComponentModel.ISupportInitialize).BeginInit()
        DarkGroupBox3.SuspendLayout()
        CType(nudExhaustedPic, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudNormalPic, ComponentModel.ISupportInitialize).BeginInit()
        CType(picExhaustedPic, ComponentModel.ISupportInitialize).BeginInit()
        CType(picNormalpic, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudHealth, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DarkGroupBox1
        ' 
        DarkGroupBox1.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox1.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox1.Controls.Add(lstIndex)
        DarkGroupBox1.ForeColor = Color.Gainsboro
        DarkGroupBox1.Location = New Point(8, 4)
        DarkGroupBox1.Margin = New Padding(8, 6, 8, 6)
        DarkGroupBox1.Name = "DarkGroupBox1"
        DarkGroupBox1.Padding = New Padding(8, 6, 8, 6)
        DarkGroupBox1.Size = New Size(468, 815)
        DarkGroupBox1.TabIndex = 0
        DarkGroupBox1.TabStop = False
        DarkGroupBox1.Text = "Resource List"
        ' 
        ' lstIndex
        ' 
        lstIndex.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        lstIndex.BorderStyle = BorderStyle.FixedSingle
        lstIndex.ForeColor = Color.Gainsboro
        lstIndex.FormattingEnabled = True
        lstIndex.Location = New Point(18, 47)
        lstIndex.Margin = New Padding(8, 6, 8, 6)
        lstIndex.Name = "lstIndex"
        lstIndex.Size = New Size(422, 738)
        lstIndex.TabIndex = 1
        ' 
        ' DarkGroupBox2
        ' 
        DarkGroupBox2.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox2.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox2.Controls.Add(DarkGroupBox5)
        DarkGroupBox2.Controls.Add(DarkGroupBox4)
        DarkGroupBox2.Controls.Add(cmbAnimation)
        DarkGroupBox2.Controls.Add(DarkLabel9)
        DarkGroupBox2.Controls.Add(nudRespawn)
        DarkGroupBox2.Controls.Add(DarkLabel8)
        DarkGroupBox2.Controls.Add(DarkGroupBox3)
        DarkGroupBox2.Controls.Add(nudHealth)
        DarkGroupBox2.Controls.Add(DarkLabel5)
        DarkGroupBox2.Controls.Add(cmbType)
        DarkGroupBox2.Controls.Add(DarkLabel4)
        DarkGroupBox2.Controls.Add(DarkLabel3)
        DarkGroupBox2.Controls.Add(txtMessage2)
        DarkGroupBox2.Controls.Add(txtMessage)
        DarkGroupBox2.Controls.Add(DarkLabel2)
        DarkGroupBox2.Controls.Add(txtName)
        DarkGroupBox2.Controls.Add(DarkLabel1)
        DarkGroupBox2.ForeColor = Color.Gainsboro
        DarkGroupBox2.Location = New Point(486, 4)
        DarkGroupBox2.Margin = New Padding(8, 6, 8, 6)
        DarkGroupBox2.Name = "DarkGroupBox2"
        DarkGroupBox2.Padding = New Padding(8, 6, 8, 6)
        DarkGroupBox2.Size = New Size(791, 1030)
        DarkGroupBox2.TabIndex = 1
        DarkGroupBox2.TabStop = False
        DarkGroupBox2.Text = "Properties"
        ' 
        ' DarkGroupBox5
        ' 
        DarkGroupBox5.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox5.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox5.Controls.Add(nudRewardExp)
        DarkGroupBox5.Controls.Add(DarkLabel13)
        DarkGroupBox5.Controls.Add(cmbRewardItem)
        DarkGroupBox5.Controls.Add(DarkLabel12)
        DarkGroupBox5.ForeColor = Color.Gainsboro
        DarkGroupBox5.Location = New Point(18, 908)
        DarkGroupBox5.Margin = New Padding(8, 6, 8, 6)
        DarkGroupBox5.Name = "DarkGroupBox5"
        DarkGroupBox5.Padding = New Padding(8, 6, 8, 6)
        DarkGroupBox5.Size = New Size(750, 108)
        DarkGroupBox5.TabIndex = 16
        DarkGroupBox5.TabStop = False
        DarkGroupBox5.Text = "Rewards"
        ' 
        ' nudRewardExp
        ' 
        nudRewardExp.Location = New Point(522, 34)
        nudRewardExp.Margin = New Padding(8, 6, 8, 6)
        nudRewardExp.Name = "nudRewardExp"
        nudRewardExp.Size = New Size(212, 39)
        nudRewardExp.TabIndex = 3
        ' 
        ' DarkLabel13
        ' 
        DarkLabel13.AutoSize = True
        DarkLabel13.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel13.Location = New Point(373, 38)
        DarkLabel13.Margin = New Padding(8, 0, 8, 0)
        DarkLabel13.Name = "DarkLabel13"
        DarkLabel13.Size = New Size(134, 32)
        DarkLabel13.TabIndex = 2
        DarkLabel13.Text = "Exp:"
        ' 
        ' cmbRewardItem
        ' 
        cmbRewardItem.DrawMode = DrawMode.OwnerDrawFixed
        cmbRewardItem.FormattingEnabled = True
        cmbRewardItem.Location = New Point(91, 32)
        cmbRewardItem.Margin = New Padding(8, 6, 8, 6)
        cmbRewardItem.Name = "cmbRewardItem"
        cmbRewardItem.Size = New Size(256, 40)
        cmbRewardItem.TabIndex = 1
        ' 
        ' DarkLabel12
        ' 
        DarkLabel12.AutoSize = True
        DarkLabel12.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel12.Location = New Point(13, 38)
        DarkLabel12.Margin = New Padding(8, 0, 8, 0)
        DarkLabel12.Name = "DarkLabel12"
        DarkLabel12.Size = New Size(67, 32)
        DarkLabel12.TabIndex = 0
        DarkLabel12.Text = "Item:"
        ' 
        ' DarkGroupBox4
        ' 
        DarkGroupBox4.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox4.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox4.Controls.Add(nudLvlReq)
        DarkGroupBox4.Controls.Add(DarkLabel11)
        DarkGroupBox4.Controls.Add(cmbTool)
        DarkGroupBox4.Controls.Add(DarkLabel10)
        DarkGroupBox4.ForeColor = Color.Gainsboro
        DarkGroupBox4.Location = New Point(18, 785)
        DarkGroupBox4.Margin = New Padding(8, 6, 8, 6)
        DarkGroupBox4.Name = "DarkGroupBox4"
        DarkGroupBox4.Padding = New Padding(8, 6, 8, 6)
        DarkGroupBox4.Size = New Size(750, 108)
        DarkGroupBox4.TabIndex = 15
        DarkGroupBox4.TabStop = False
        DarkGroupBox4.Text = "Requirements"
        ' 
        ' nudLvlReq
        ' 
        nudLvlReq.Location = New Point(557, 34)
        nudLvlReq.Margin = New Padding(8, 6, 8, 6)
        nudLvlReq.Name = "nudLvlReq"
        nudLvlReq.Size = New Size(178, 39)
        nudLvlReq.TabIndex = 3
        ' 
        ' DarkLabel11
        ' 
        DarkLabel11.AutoSize = True
        DarkLabel11.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel11.Location = New Point(418, 38)
        DarkLabel11.Margin = New Padding(8, 0, 8, 0)
        DarkLabel11.Name = "DarkLabel11"
        DarkLabel11.Size = New Size(124, 32)
        DarkLabel11.TabIndex = 2
        DarkLabel11.Text = "Skill Level:"
        ' 
        ' cmbTool
        ' 
        cmbTool.DrawMode = DrawMode.OwnerDrawFixed
        cmbTool.FormattingEnabled = True
        cmbTool.Items.AddRange(New Object() {"None", "Hatchet", "Pickaxe", "Fishing Rod"})
        cmbTool.Location = New Point(182, 32)
        cmbTool.Margin = New Padding(8, 6, 8, 6)
        cmbTool.Name = "cmbTool"
        cmbTool.Size = New Size(217, 40)
        cmbTool.TabIndex = 1
        ' 
        ' DarkLabel10
        ' 
        DarkLabel10.AutoSize = True
        DarkLabel10.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel10.Location = New Point(13, 38)
        DarkLabel10.Margin = New Padding(8, 0, 8, 0)
        DarkLabel10.Name = "DarkLabel10"
        DarkLabel10.Size = New Size(156, 32)
        DarkLabel10.TabIndex = 0
        DarkLabel10.Text = "Tool Needed:"
        ' 
        ' cmbAnimation
        ' 
        cmbAnimation.DrawMode = DrawMode.OwnerDrawFixed
        cmbAnimation.FormattingEnabled = True
        cmbAnimation.Location = New Point(554, 300)
        cmbAnimation.Margin = New Padding(8, 6, 8, 6)
        cmbAnimation.Name = "cmbAnimation"
        cmbAnimation.Size = New Size(212, 40)
        cmbAnimation.TabIndex = 14
        ' 
        ' DarkLabel9
        ' 
        DarkLabel9.AutoSize = True
        DarkLabel9.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel9.Location = New Point(418, 305)
        DarkLabel9.Margin = New Padding(8, 0, 8, 0)
        DarkLabel9.Name = "DarkLabel9"
        DarkLabel9.Size = New Size(129, 32)
        DarkLabel9.TabIndex = 13
        DarkLabel9.Text = "Animation:"
        ' 
        ' nudRespawn
        ' 
        nudRespawn.Location = New Point(238, 300)
        nudRespawn.Margin = New Padding(8, 6, 8, 6)
        nudRespawn.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        nudRespawn.Name = "nudRespawn"
        nudRespawn.Size = New Size(167, 39)
        nudRespawn.TabIndex = 12
        ' 
        ' DarkLabel8
        ' 
        DarkLabel8.AutoSize = True
        DarkLabel8.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel8.Location = New Point(13, 305)
        DarkLabel8.Margin = New Padding(8, 0, 8, 0)
        DarkLabel8.Name = "DarkLabel8"
        DarkLabel8.Size = New Size(172, 32)
        DarkLabel8.TabIndex = 11
        DarkLabel8.Text = "Respawn Time:"
        ' 
        ' DarkGroupBox3
        ' 
        DarkGroupBox3.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox3.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox3.Controls.Add(nudExhaustedPic)
        DarkGroupBox3.Controls.Add(nudNormalPic)
        DarkGroupBox3.Controls.Add(DarkLabel7)
        DarkGroupBox3.Controls.Add(DarkLabel6)
        DarkGroupBox3.Controls.Add(picExhaustedPic)
        DarkGroupBox3.Controls.Add(picNormalpic)
        DarkGroupBox3.ForeColor = Color.Gainsboro
        DarkGroupBox3.Location = New Point(18, 367)
        DarkGroupBox3.Margin = New Padding(8, 6, 8, 6)
        DarkGroupBox3.Name = "DarkGroupBox3"
        DarkGroupBox3.Padding = New Padding(8, 6, 8, 6)
        DarkGroupBox3.Size = New Size(750, 404)
        DarkGroupBox3.TabIndex = 10
        DarkGroupBox3.TabStop = False
        DarkGroupBox3.Text = "Graphics"
        ' 
        ' nudExhaustedPic
        ' 
        nudExhaustedPic.Location = New Point(580, 337)
        nudExhaustedPic.Margin = New Padding(8, 6, 8, 6)
        nudExhaustedPic.Name = "nudExhaustedPic"
        nudExhaustedPic.Size = New Size(156, 39)
        nudExhaustedPic.TabIndex = 49
        ' 
        ' nudNormalPic
        ' 
        nudNormalPic.Location = New Point(186, 337)
        nudNormalPic.Margin = New Padding(8, 6, 8, 6)
        nudNormalPic.Name = "nudNormalPic"
        nudNormalPic.Size = New Size(156, 39)
        nudNormalPic.TabIndex = 48
        ' 
        ' DarkLabel7
        ' 
        DarkLabel7.AutoSize = True
        DarkLabel7.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel7.Location = New Point(401, 341)
        DarkLabel7.Margin = New Padding(8, 0, 8, 0)
        DarkLabel7.Name = "DarkLabel7"
        DarkLabel7.Size = New Size(159, 32)
        DarkLabel7.TabIndex = 47
        DarkLabel7.Text = "Empty Image:"
        ' 
        ' DarkLabel6
        ' 
        DarkLabel6.AutoSize = True
        DarkLabel6.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel6.Location = New Point(8, 341)
        DarkLabel6.Margin = New Padding(8, 0, 8, 0)
        DarkLabel6.Name = "DarkLabel6"
        DarkLabel6.Size = New Size(171, 32)
        DarkLabel6.TabIndex = 46
        DarkLabel6.Text = "Normal Image:"
        ' 
        ' picExhaustedPic
        ' 
        picExhaustedPic.BackColor = Color.Black
        picExhaustedPic.BackgroundImageLayout = ImageLayout.Zoom
        picExhaustedPic.Location = New Point(407, 47)
        picExhaustedPic.Margin = New Padding(8, 6, 8, 6)
        picExhaustedPic.Name = "picExhaustedPic"
        picExhaustedPic.Size = New Size(329, 276)
        picExhaustedPic.TabIndex = 45
        picExhaustedPic.TabStop = False
        ' 
        ' picNormalpic
        ' 
        picNormalpic.BackColor = Color.Black
        picNormalpic.BackgroundImageLayout = ImageLayout.Zoom
        picNormalpic.Location = New Point(13, 47)
        picNormalpic.Margin = New Padding(8, 6, 8, 6)
        picNormalpic.Name = "picNormalpic"
        picNormalpic.Size = New Size(329, 276)
        picNormalpic.TabIndex = 44
        picNormalpic.TabStop = False
        ' 
        ' nudHealth
        ' 
        nudHealth.Location = New Point(637, 236)
        nudHealth.Margin = New Padding(8, 6, 8, 6)
        nudHealth.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        nudHealth.Name = "nudHealth"
        nudHealth.Size = New Size(132, 39)
        nudHealth.TabIndex = 9
        ' 
        ' DarkLabel5
        ' 
        DarkLabel5.AutoSize = True
        DarkLabel5.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel5.Location = New Point(511, 241)
        DarkLabel5.Margin = New Padding(8, 0, 8, 0)
        DarkLabel5.Name = "DarkLabel5"
        DarkLabel5.Size = New Size(114, 32)
        DarkLabel5.TabIndex = 8
        DarkLabel5.Text = "HitPoints:"
        ' 
        ' cmbType
        ' 
        cmbType.DrawMode = DrawMode.OwnerDrawFixed
        cmbType.FormattingEnabled = True
        cmbType.Items.AddRange(New Object() {"None", "Herb", "Tree", "Mine", "Fishing Spot"})
        cmbType.Location = New Point(236, 235)
        cmbType.Margin = New Padding(8, 6, 8, 6)
        cmbType.Name = "cmbType"
        cmbType.Size = New Size(256, 40)
        cmbType.TabIndex = 7
        ' 
        ' DarkLabel4
        ' 
        DarkLabel4.AutoSize = True
        DarkLabel4.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel4.Location = New Point(13, 241)
        DarkLabel4.Margin = New Padding(8, 0, 8, 0)
        DarkLabel4.Name = "DarkLabel4"
        DarkLabel4.Size = New Size(70, 32)
        DarkLabel4.TabIndex = 6
        DarkLabel4.Text = "Type:"
        ' 
        ' DarkLabel3
        ' 
        DarkLabel3.AutoSize = True
        DarkLabel3.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel3.Location = New Point(13, 175)
        DarkLabel3.Margin = New Padding(8, 0, 8, 0)
        DarkLabel3.Name = "DarkLabel3"
        DarkLabel3.Size = New Size(155, 32)
        DarkLabel3.TabIndex = 5
        DarkLabel3.Text = "Fail Message:"
        ' 
        ' txtMessage2
        ' 
        txtMessage2.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtMessage2.BorderStyle = BorderStyle.FixedSingle
        txtMessage2.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtMessage2.Location = New Point(236, 171)
        txtMessage2.Margin = New Padding(8, 6, 8, 6)
        txtMessage2.Name = "txtMessage2"
        txtMessage2.Size = New Size(531, 39)
        txtMessage2.TabIndex = 4
        ' 
        ' txtMessage
        ' 
        txtMessage.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtMessage.BorderStyle = BorderStyle.FixedSingle
        txtMessage.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtMessage.Location = New Point(236, 107)
        txtMessage.Margin = New Padding(8, 6, 8, 6)
        txtMessage.Name = "txtMessage"
        txtMessage.Size = New Size(531, 39)
        txtMessage.TabIndex = 3
        ' 
        ' DarkLabel2
        ' 
        DarkLabel2.AutoSize = True
        DarkLabel2.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel2.Location = New Point(13, 111)
        DarkLabel2.Margin = New Padding(8, 0, 8, 0)
        DarkLabel2.Name = "DarkLabel2"
        DarkLabel2.Size = New Size(202, 32)
        DarkLabel2.TabIndex = 2
        DarkLabel2.Text = "Success Message:"
        ' 
        ' txtName
        ' 
        txtName.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtName.BorderStyle = BorderStyle.FixedSingle
        txtName.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtName.Location = New Point(236, 43)
        txtName.Margin = New Padding(8, 6, 8, 6)
        txtName.Name = "txtName"
        txtName.Size = New Size(531, 39)
        txtName.TabIndex = 1
        ' 
        ' DarkLabel1
        ' 
        DarkLabel1.AutoSize = True
        DarkLabel1.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel1.Location = New Point(13, 47)
        DarkLabel1.Margin = New Padding(8, 0, 8, 0)
        DarkLabel1.Name = "DarkLabel1"
        DarkLabel1.Size = New Size(83, 32)
        DarkLabel1.TabIndex = 0
        DarkLabel1.Text = "Name:"
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(26, 836)
        btnSave.Margin = New Padding(8, 6, 8, 6)
        btnSave.Name = "btnSave"
        btnSave.Padding = New Padding(11, 12, 11, 12)
        btnSave.Size = New Size(424, 58)
        btnSave.TabIndex = 2
        btnSave.Text = "Save"
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(26, 906)
        btnDelete.Margin = New Padding(8, 6, 8, 6)
        btnDelete.Name = "btnDelete"
        btnDelete.Padding = New Padding(11, 12, 11, 12)
        btnDelete.Size = New Size(424, 58)
        btnDelete.TabIndex = 3
        btnDelete.Text = "Delete"
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(26, 976)
        btnCancel.Margin = New Padding(8, 6, 8, 6)
        btnCancel.Name = "btnCancel"
        btnCancel.Padding = New Padding(11, 12, 11, 12)
        btnCancel.Size = New Size(422, 58)
        btnCancel.TabIndex = 4
        btnCancel.Text = "Cancel"
        ' 
        ' frmEditor_Resource
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        ClientSize = New Size(1286, 1047)
        Controls.Add(btnCancel)
        Controls.Add(btnDelete)
        Controls.Add(btnSave)
        Controls.Add(DarkGroupBox2)
        Controls.Add(DarkGroupBox1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Margin = New Padding(8, 6, 8, 6)
        Name = "frmEditor_Resource"
        Text = "Resource Editor"
        DarkGroupBox1.ResumeLayout(False)
        DarkGroupBox2.ResumeLayout(False)
        DarkGroupBox2.PerformLayout()
        DarkGroupBox5.ResumeLayout(False)
        DarkGroupBox5.PerformLayout()
        CType(nudRewardExp, ComponentModel.ISupportInitialize).EndInit()
        DarkGroupBox4.ResumeLayout(False)
        DarkGroupBox4.PerformLayout()
        CType(nudLvlReq, ComponentModel.ISupportInitialize).EndInit()
        CType(nudRespawn, ComponentModel.ISupportInitialize).EndInit()
        DarkGroupBox3.ResumeLayout(False)
        DarkGroupBox3.PerformLayout()
        CType(nudExhaustedPic, ComponentModel.ISupportInitialize).EndInit()
        CType(nudNormalPic, ComponentModel.ISupportInitialize).EndInit()
        CType(picExhaustedPic, ComponentModel.ISupportInitialize).EndInit()
        CType(picNormalpic, ComponentModel.ISupportInitialize).EndInit()
        CType(nudHealth, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents DarkGroupBox1 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents lstIndex As System.Windows.Forms.ListBox
    Friend WithEvents DarkGroupBox2 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents DarkLabel3 As DarkUI.Controls.DarkLabel
    Friend WithEvents txtMessage2 As DarkUI.Controls.DarkTextBox
    Friend WithEvents txtMessage As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel2 As DarkUI.Controls.DarkLabel
    Friend WithEvents txtName As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel1 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbType As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel4 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudHealth As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel5 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkGroupBox3 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents picExhaustedPic As System.Windows.Forms.PictureBox
    Friend WithEvents picNormalpic As System.Windows.Forms.PictureBox
    Friend WithEvents nudExhaustedPic As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudNormalPic As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel7 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel6 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudRespawn As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel8 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbAnimation As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel9 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkGroupBox4 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents cmbTool As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel10 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudLvlReq As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel11 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkGroupBox5 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents cmbRewardItem As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel12 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudRewardExp As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel13 As DarkUI.Controls.DarkLabel
    Friend WithEvents btnSave As DarkUI.Controls.DarkButton
    Friend WithEvents btnDelete As DarkUI.Controls.DarkButton
    Friend WithEvents btnCancel As DarkUI.Controls.DarkButton
End Class
