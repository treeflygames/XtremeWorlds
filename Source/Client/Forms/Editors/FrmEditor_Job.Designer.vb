<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_Job
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        DarkGroupBox1 = New DarkUI.Controls.DarkGroupBox()
        lstIndex = New ListBox()
        DarkGroupBox2 = New DarkUI.Controls.DarkGroupBox()
        DarkGroupBox7 = New DarkUI.Controls.DarkGroupBox()
        nudStartY = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel15 = New DarkUI.Controls.DarkLabel()
        nudStartX = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel14 = New DarkUI.Controls.DarkLabel()
        nudStartMap = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel13 = New DarkUI.Controls.DarkLabel()
        DarkGroupBox6 = New DarkUI.Controls.DarkGroupBox()
        btnItemAdd = New DarkUI.Controls.DarkButton()
        nudItemAmount = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel12 = New DarkUI.Controls.DarkLabel()
        cmbItems = New DarkUI.Controls.DarkComboBox()
        DarkLabel11 = New DarkUI.Controls.DarkLabel()
        lstStartItems = New ListBox()
        DarkGroupBox5 = New DarkUI.Controls.DarkGroupBox()
        nudBaseExp = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel10 = New DarkUI.Controls.DarkLabel()
        nudSpirit = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel8 = New DarkUI.Controls.DarkLabel()
        DarkLabel9 = New DarkUI.Controls.DarkLabel()
        nudVitality = New DarkUI.Controls.DarkNumericUpDown()
        nudLuck = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel6 = New DarkUI.Controls.DarkLabel()
        DarkLabel7 = New DarkUI.Controls.DarkLabel()
        nudIntelligence = New DarkUI.Controls.DarkNumericUpDown()
        nudStrength = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel5 = New DarkUI.Controls.DarkLabel()
        DarkLabel3 = New DarkUI.Controls.DarkLabel()
        DarkGroupBox4 = New DarkUI.Controls.DarkGroupBox()
        nudFemaleSprite = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel4 = New DarkUI.Controls.DarkLabel()
        picFemale = New PictureBox()
        DarkGroupBox3 = New DarkUI.Controls.DarkGroupBox()
        nudMaleSprite = New DarkUI.Controls.DarkNumericUpDown()
        lblMaleSprite = New DarkUI.Controls.DarkLabel()
        picMale = New PictureBox()
        txtDescription = New DarkUI.Controls.DarkTextBox()
        DarkLabel2 = New DarkUI.Controls.DarkLabel()
        txtName = New DarkUI.Controls.DarkTextBox()
        DarkLabel1 = New DarkUI.Controls.DarkLabel()
        btnCancel = New DarkUI.Controls.DarkButton()
        btnSave = New DarkUI.Controls.DarkButton()
        btnDelete = New DarkUI.Controls.DarkButton()
        DarkGroupBox1.SuspendLayout()
        DarkGroupBox2.SuspendLayout()
        DarkGroupBox7.SuspendLayout()
        CType(nudStartY, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudStartX, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudStartMap, ComponentModel.ISupportInitialize).BeginInit()
        DarkGroupBox6.SuspendLayout()
        CType(nudItemAmount, ComponentModel.ISupportInitialize).BeginInit()
        DarkGroupBox5.SuspendLayout()
        CType(nudBaseExp, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudSpirit, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudVitality, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudLuck, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudIntelligence, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudStrength, ComponentModel.ISupportInitialize).BeginInit()
        DarkGroupBox4.SuspendLayout()
        CType(nudFemaleSprite, ComponentModel.ISupportInitialize).BeginInit()
        CType(picFemale, ComponentModel.ISupportInitialize).BeginInit()
        DarkGroupBox3.SuspendLayout()
        CType(nudMaleSprite, ComponentModel.ISupportInitialize).BeginInit()
        CType(picMale, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DarkGroupBox1
        ' 
        DarkGroupBox1.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox1.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox1.Controls.Add(lstIndex)
        DarkGroupBox1.ForeColor = Color.Gainsboro
        DarkGroupBox1.Location = New Point(2, 3)
        DarkGroupBox1.Margin = New Padding(5, 5, 5, 5)
        DarkGroupBox1.Name = "DarkGroupBox1"
        DarkGroupBox1.Padding = New Padding(5, 5, 5, 5)
        DarkGroupBox1.Size = New Size(288, 742)
        DarkGroupBox1.TabIndex = 0
        DarkGroupBox1.TabStop = False
        DarkGroupBox1.Text = "Job List"
        ' 
        ' lstIndex
        ' 
        lstIndex.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        lstIndex.BorderStyle = BorderStyle.FixedSingle
        lstIndex.ForeColor = Color.Gainsboro
        lstIndex.FormattingEnabled = True
        lstIndex.ItemHeight = 25
        lstIndex.Location = New Point(10, 27)
        lstIndex.Margin = New Padding(5, 5, 5, 5)
        lstIndex.Name = "lstIndex"
        lstIndex.Size = New Size(265, 702)
        lstIndex.TabIndex = 0
        ' 
        ' DarkGroupBox2
        ' 
        DarkGroupBox2.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox2.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox2.Controls.Add(DarkGroupBox7)
        DarkGroupBox2.Controls.Add(DarkGroupBox6)
        DarkGroupBox2.Controls.Add(DarkGroupBox5)
        DarkGroupBox2.Controls.Add(DarkGroupBox4)
        DarkGroupBox2.Controls.Add(DarkGroupBox3)
        DarkGroupBox2.Controls.Add(txtDescription)
        DarkGroupBox2.Controls.Add(DarkLabel2)
        DarkGroupBox2.Controls.Add(txtName)
        DarkGroupBox2.Controls.Add(DarkLabel1)
        DarkGroupBox2.ForeColor = Color.Gainsboro
        DarkGroupBox2.Location = New Point(302, 3)
        DarkGroupBox2.Margin = New Padding(5, 5, 5, 5)
        DarkGroupBox2.Name = "DarkGroupBox2"
        DarkGroupBox2.Padding = New Padding(5, 5, 5, 5)
        DarkGroupBox2.Size = New Size(568, 909)
        DarkGroupBox2.TabIndex = 1
        DarkGroupBox2.TabStop = False
        DarkGroupBox2.Text = "Properties"
        ' 
        ' DarkGroupBox7
        ' 
        DarkGroupBox7.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox7.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox7.Controls.Add(nudStartY)
        DarkGroupBox7.Controls.Add(DarkLabel15)
        DarkGroupBox7.Controls.Add(nudStartX)
        DarkGroupBox7.Controls.Add(DarkLabel14)
        DarkGroupBox7.Controls.Add(nudStartMap)
        DarkGroupBox7.Controls.Add(DarkLabel13)
        DarkGroupBox7.ForeColor = Color.Gainsboro
        DarkGroupBox7.Location = New Point(10, 812)
        DarkGroupBox7.Margin = New Padding(5, 5, 5, 5)
        DarkGroupBox7.Name = "DarkGroupBox7"
        DarkGroupBox7.Padding = New Padding(5, 5, 5, 5)
        DarkGroupBox7.Size = New Size(547, 84)
        DarkGroupBox7.TabIndex = 8
        DarkGroupBox7.TabStop = False
        DarkGroupBox7.Text = "Starting Point"
        ' 
        ' nudStartY
        ' 
        nudStartY.Location = New Point(457, 27)
        nudStartY.Margin = New Padding(5, 5, 5, 5)
        nudStartY.Name = "nudStartY"
        nudStartY.Size = New Size(80, 31)
        nudStartY.TabIndex = 5
        ' 
        ' DarkLabel15
        ' 
        DarkLabel15.AutoSize = True
        DarkLabel15.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel15.Location = New Point(377, 30)
        DarkLabel15.Margin = New Padding(5, 0, 5, 0)
        DarkLabel15.Name = "DarkLabel15"
        DarkLabel15.Size = New Size(57, 25)
        DarkLabel15.TabIndex = 4
        DarkLabel15.Text = "Start :"
        ' 
        ' nudStartX
        ' 
        nudStartX.Location = New Point(280, 27)
        nudStartX.Margin = New Padding(5, 5, 5, 5)
        nudStartX.Name = "nudStartX"
        nudStartX.Size = New Size(80, 31)
        nudStartX.TabIndex = 3
        ' 
        ' DarkLabel14
        ' 
        DarkLabel14.AutoSize = True
        DarkLabel14.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel14.Location = New Point(200, 30)
        DarkLabel14.Margin = New Padding(5, 0, 5, 0)
        DarkLabel14.Name = "DarkLabel14"
        DarkLabel14.Size = New Size(68, 25)
        DarkLabel14.TabIndex = 2
        DarkLabel14.Text = "Start X:"
        ' 
        ' nudStartMap
        ' 
        nudStartMap.Location = New Point(113, 27)
        nudStartMap.Margin = New Padding(5, 5, 5, 5)
        nudStartMap.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudStartMap.Name = "nudStartMap"
        nudStartMap.Size = New Size(77, 31)
        nudStartMap.TabIndex = 1
        nudStartMap.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' DarkLabel13
        ' 
        DarkLabel13.AutoSize = True
        DarkLabel13.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel13.Location = New Point(10, 30)
        DarkLabel13.Margin = New Padding(5, 0, 5, 0)
        DarkLabel13.Name = "DarkLabel13"
        DarkLabel13.Size = New Size(93, 25)
        DarkLabel13.TabIndex = 0
        DarkLabel13.Text = "Start Map:"
        ' 
        ' DarkGroupBox6
        ' 
        DarkGroupBox6.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox6.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox6.Controls.Add(btnItemAdd)
        DarkGroupBox6.Controls.Add(nudItemAmount)
        DarkGroupBox6.Controls.Add(DarkLabel12)
        DarkGroupBox6.Controls.Add(cmbItems)
        DarkGroupBox6.Controls.Add(DarkLabel11)
        DarkGroupBox6.Controls.Add(lstStartItems)
        DarkGroupBox6.ForeColor = Color.Gainsboro
        DarkGroupBox6.Location = New Point(10, 597)
        DarkGroupBox6.Margin = New Padding(5, 5, 5, 5)
        DarkGroupBox6.Name = "DarkGroupBox6"
        DarkGroupBox6.Padding = New Padding(5, 5, 5, 5)
        DarkGroupBox6.Size = New Size(547, 203)
        DarkGroupBox6.TabIndex = 7
        DarkGroupBox6.TabStop = False
        DarkGroupBox6.Text = "Starting Items"
        ' 
        ' btnItemAdd
        ' 
        btnItemAdd.Location = New Point(305, 140)
        btnItemAdd.Margin = New Padding(5, 5, 5, 5)
        btnItemAdd.Name = "btnItemAdd"
        btnItemAdd.Padding = New Padding(8, 10, 8, 10)
        btnItemAdd.Size = New Size(232, 50)
        btnItemAdd.TabIndex = 6
        btnItemAdd.Text = "Update"
        ' 
        ' nudItemAmount
        ' 
        nudItemAmount.Location = New Point(392, 97)
        nudItemAmount.Margin = New Padding(5, 5, 5, 5)
        nudItemAmount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudItemAmount.Name = "nudItemAmount"
        nudItemAmount.Size = New Size(145, 31)
        nudItemAmount.TabIndex = 5
        nudItemAmount.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' DarkLabel12
        ' 
        DarkLabel12.AutoSize = True
        DarkLabel12.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel12.Location = New Point(305, 100)
        DarkLabel12.Margin = New Padding(5, 0, 5, 0)
        DarkLabel12.Name = "DarkLabel12"
        DarkLabel12.Size = New Size(81, 25)
        DarkLabel12.TabIndex = 4
        DarkLabel12.Text = "Amount:"
        ' 
        ' cmbItems
        ' 
        cmbItems.DrawMode = DrawMode.OwnerDrawFixed
        cmbItems.FormattingEnabled = True
        cmbItems.Location = New Point(305, 45)
        cmbItems.Margin = New Padding(5, 5, 5, 5)
        cmbItems.Name = "cmbItems"
        cmbItems.Size = New Size(229, 32)
        cmbItems.TabIndex = 3
        ' 
        ' DarkLabel11
        ' 
        DarkLabel11.AutoSize = True
        DarkLabel11.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel11.Location = New Point(305, 13)
        DarkLabel11.Margin = New Padding(5, 0, 5, 0)
        DarkLabel11.Name = "DarkLabel11"
        DarkLabel11.Size = New Size(89, 25)
        DarkLabel11.TabIndex = 2
        DarkLabel11.Text = "Start Item"
        ' 
        ' lstStartItems
        ' 
        lstStartItems.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        lstStartItems.BorderStyle = BorderStyle.FixedSingle
        lstStartItems.ForeColor = Color.Gainsboro
        lstStartItems.FormattingEnabled = True
        lstStartItems.ItemHeight = 25
        lstStartItems.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        lstStartItems.Location = New Point(10, 37)
        lstStartItems.Margin = New Padding(5, 5, 5, 5)
        lstStartItems.Name = "lstStartItems"
        lstStartItems.Size = New Size(284, 152)
        lstStartItems.TabIndex = 1
        ' 
        ' DarkGroupBox5
        ' 
        DarkGroupBox5.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox5.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox5.Controls.Add(nudBaseExp)
        DarkGroupBox5.Controls.Add(DarkLabel10)
        DarkGroupBox5.Controls.Add(nudSpirit)
        DarkGroupBox5.Controls.Add(DarkLabel8)
        DarkGroupBox5.Controls.Add(DarkLabel9)
        DarkGroupBox5.Controls.Add(nudVitality)
        DarkGroupBox5.Controls.Add(nudLuck)
        DarkGroupBox5.Controls.Add(DarkLabel6)
        DarkGroupBox5.Controls.Add(DarkLabel7)
        DarkGroupBox5.Controls.Add(nudIntelligence)
        DarkGroupBox5.Controls.Add(nudStrength)
        DarkGroupBox5.Controls.Add(DarkLabel5)
        DarkGroupBox5.Controls.Add(DarkLabel3)
        DarkGroupBox5.ForeColor = Color.Gainsboro
        DarkGroupBox5.Location = New Point(10, 391)
        DarkGroupBox5.Margin = New Padding(5, 5, 5, 5)
        DarkGroupBox5.Name = "DarkGroupBox5"
        DarkGroupBox5.Padding = New Padding(5, 5, 5, 5)
        DarkGroupBox5.Size = New Size(547, 191)
        DarkGroupBox5.TabIndex = 6
        DarkGroupBox5.TabStop = False
        DarkGroupBox5.Text = "Start Stats"
        ' 
        ' nudBaseExp
        ' 
        nudBaseExp.Location = New Point(170, 135)
        nudBaseExp.Margin = New Padding(5, 5, 5, 5)
        nudBaseExp.Name = "nudBaseExp"
        nudBaseExp.Size = New Size(172, 31)
        nudBaseExp.TabIndex = 13
        ' 
        ' DarkLabel10
        ' 
        DarkLabel10.AutoSize = True
        DarkLabel10.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel10.Location = New Point(10, 138)
        DarkLabel10.Margin = New Padding(5, 0, 5, 0)
        DarkLabel10.Name = "DarkLabel10"
        DarkLabel10.Size = New Size(85, 25)
        DarkLabel10.TabIndex = 12
        DarkLabel10.Text = "Base Exp:"
        ' 
        ' nudSpirit
        ' 
        nudSpirit.Location = New Point(462, 77)
        nudSpirit.Margin = New Padding(5, 5, 5, 5)
        nudSpirit.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudSpirit.Name = "nudSpirit"
        nudSpirit.Size = New Size(75, 31)
        nudSpirit.TabIndex = 11
        nudSpirit.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' DarkLabel8
        ' 
        DarkLabel8.AutoSize = True
        DarkLabel8.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel8.Location = New Point(352, 80)
        DarkLabel8.Margin = New Padding(5, 0, 5, 0)
        DarkLabel8.Name = "DarkLabel8"
        DarkLabel8.Size = New Size(57, 25)
        DarkLabel8.TabIndex = 9
        DarkLabel8.Text = "Spirit:"
        ' 
        ' DarkLabel9
        ' 
        DarkLabel9.AutoSize = True
        DarkLabel9.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel9.Location = New Point(352, 30)
        DarkLabel9.Margin = New Padding(5, 0, 5, 0)
        DarkLabel9.Name = "DarkLabel9"
        DarkLabel9.Size = New Size(98, 25)
        DarkLabel9.TabIndex = 8
        DarkLabel9.Text = "Endurance:"
        ' 
        ' nudVitality
        ' 
        nudVitality.Location = New Point(267, 77)
        nudVitality.Margin = New Padding(5, 5, 5, 5)
        nudVitality.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudVitality.Name = "nudVitality"
        nudVitality.Size = New Size(75, 31)
        nudVitality.TabIndex = 7
        nudVitality.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' nudLuck
        ' 
        nudLuck.Location = New Point(267, 27)
        nudLuck.Margin = New Padding(5, 5, 5, 5)
        nudLuck.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        nudLuck.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudLuck.Name = "nudLuck"
        nudLuck.Size = New Size(75, 31)
        nudLuck.TabIndex = 6
        nudLuck.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' DarkLabel6
        ' 
        DarkLabel6.AutoSize = True
        DarkLabel6.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel6.Location = New Point(200, 80)
        DarkLabel6.Margin = New Padding(5, 0, 5, 0)
        DarkLabel6.Name = "DarkLabel6"
        DarkLabel6.Size = New Size(69, 25)
        DarkLabel6.TabIndex = 5
        DarkLabel6.Text = "Vitality:"
        ' 
        ' DarkLabel7
        ' 
        DarkLabel7.AutoSize = True
        DarkLabel7.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel7.Location = New Point(200, 30)
        DarkLabel7.Margin = New Padding(5, 0, 5, 0)
        DarkLabel7.Name = "DarkLabel7"
        DarkLabel7.Size = New Size(51, 25)
        DarkLabel7.TabIndex = 4
        DarkLabel7.Text = "Luck:"
        ' 
        ' nudIntelligence
        ' 
        nudIntelligence.Location = New Point(115, 77)
        nudIntelligence.Margin = New Padding(5, 5, 5, 5)
        nudIntelligence.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudIntelligence.Name = "nudIntelligence"
        nudIntelligence.Size = New Size(75, 31)
        nudIntelligence.TabIndex = 3
        nudIntelligence.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' nudStrength
        ' 
        nudStrength.Location = New Point(115, 27)
        nudStrength.Margin = New Padding(5, 5, 5, 5)
        nudStrength.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        nudStrength.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudStrength.Name = "nudStrength"
        nudStrength.Size = New Size(75, 31)
        nudStrength.TabIndex = 2
        nudStrength.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' DarkLabel5
        ' 
        DarkLabel5.AutoSize = True
        DarkLabel5.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel5.Location = New Point(10, 80)
        DarkLabel5.Margin = New Padding(5, 0, 5, 0)
        DarkLabel5.Name = "DarkLabel5"
        DarkLabel5.Size = New Size(105, 25)
        DarkLabel5.TabIndex = 1
        DarkLabel5.Text = "Intelligence:"
        ' 
        ' DarkLabel3
        ' 
        DarkLabel3.AutoSize = True
        DarkLabel3.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel3.Location = New Point(10, 30)
        DarkLabel3.Margin = New Padding(5, 0, 5, 0)
        DarkLabel3.Name = "DarkLabel3"
        DarkLabel3.Size = New Size(83, 25)
        DarkLabel3.TabIndex = 0
        DarkLabel3.Text = "Strength:"
        ' 
        ' DarkGroupBox4
        ' 
        DarkGroupBox4.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox4.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox4.Controls.Add(nudFemaleSprite)
        DarkGroupBox4.Controls.Add(DarkLabel4)
        DarkGroupBox4.Controls.Add(picFemale)
        DarkGroupBox4.ForeColor = Color.Gainsboro
        DarkGroupBox4.Location = New Point(288, 166)
        DarkGroupBox4.Margin = New Padding(5, 5, 5, 5)
        DarkGroupBox4.Name = "DarkGroupBox4"
        DarkGroupBox4.Padding = New Padding(5, 5, 5, 5)
        DarkGroupBox4.Size = New Size(268, 213)
        DarkGroupBox4.TabIndex = 5
        DarkGroupBox4.TabStop = False
        DarkGroupBox4.Text = "Female Sprite"
        ' 
        ' nudFemaleSprite
        ' 
        nudFemaleSprite.Location = New Point(80, 162)
        nudFemaleSprite.Margin = New Padding(5, 5, 5, 5)
        nudFemaleSprite.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudFemaleSprite.Name = "nudFemaleSprite"
        nudFemaleSprite.Size = New Size(92, 31)
        nudFemaleSprite.TabIndex = 18
        nudFemaleSprite.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' DarkLabel4
        ' 
        DarkLabel4.AutoSize = True
        DarkLabel4.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel4.Location = New Point(12, 165)
        DarkLabel4.Margin = New Padding(5, 0, 5, 0)
        DarkLabel4.Name = "DarkLabel4"
        DarkLabel4.Size = New Size(62, 25)
        DarkLabel4.TabIndex = 17
        DarkLabel4.Text = "Sprite:"
        ' 
        ' picFemale
        ' 
        picFemale.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        picFemale.BackgroundImageLayout = ImageLayout.None
        picFemale.Location = New Point(178, 20)
        picFemale.Margin = New Padding(5, 5, 5, 5)
        picFemale.Name = "picFemale"
        picFemale.Size = New Size(80, 123)
        picFemale.TabIndex = 14
        picFemale.TabStop = False
        ' 
        ' DarkGroupBox3
        ' 
        DarkGroupBox3.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox3.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox3.Controls.Add(nudMaleSprite)
        DarkGroupBox3.Controls.Add(lblMaleSprite)
        DarkGroupBox3.Controls.Add(picMale)
        DarkGroupBox3.ForeColor = Color.Gainsboro
        DarkGroupBox3.Location = New Point(10, 166)
        DarkGroupBox3.Margin = New Padding(5, 5, 5, 5)
        DarkGroupBox3.Name = "DarkGroupBox3"
        DarkGroupBox3.Padding = New Padding(5, 5, 5, 5)
        DarkGroupBox3.Size = New Size(268, 213)
        DarkGroupBox3.TabIndex = 4
        DarkGroupBox3.TabStop = False
        DarkGroupBox3.Text = "Male Sprite"
        ' 
        ' nudMaleSprite
        ' 
        nudMaleSprite.Location = New Point(80, 162)
        nudMaleSprite.Margin = New Padding(5, 5, 5, 5)
        nudMaleSprite.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudMaleSprite.Name = "nudMaleSprite"
        nudMaleSprite.Size = New Size(92, 31)
        nudMaleSprite.TabIndex = 12
        nudMaleSprite.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' lblMaleSprite
        ' 
        lblMaleSprite.AutoSize = True
        lblMaleSprite.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        lblMaleSprite.Location = New Point(12, 165)
        lblMaleSprite.Margin = New Padding(5, 0, 5, 0)
        lblMaleSprite.Name = "lblMaleSprite"
        lblMaleSprite.Size = New Size(62, 25)
        lblMaleSprite.TabIndex = 11
        lblMaleSprite.Text = "Sprite:"
        ' 
        ' picMale
        ' 
        picMale.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        picMale.BackgroundImageLayout = ImageLayout.None
        picMale.Location = New Point(178, 20)
        picMale.Margin = New Padding(5, 5, 5, 5)
        picMale.Name = "picMale"
        picMale.Size = New Size(80, 123)
        picMale.TabIndex = 8
        picMale.TabStop = False
        ' 
        ' txtDescription
        ' 
        txtDescription.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtDescription.BorderStyle = BorderStyle.FixedSingle
        txtDescription.Font = New Font("Segoe UI", 8.25F)
        txtDescription.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtDescription.Location = New Point(125, 90)
        txtDescription.Margin = New Padding(5, 5, 5, 5)
        txtDescription.Multiline = True
        txtDescription.Name = "txtDescription"
        txtDescription.Size = New Size(430, 64)
        txtDescription.TabIndex = 3
        ' 
        ' DarkLabel2
        ' 
        DarkLabel2.AutoSize = True
        DarkLabel2.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel2.Location = New Point(12, 110)
        DarkLabel2.Margin = New Padding(5, 0, 5, 0)
        DarkLabel2.Name = "DarkLabel2"
        DarkLabel2.Size = New Size(106, 25)
        DarkLabel2.TabIndex = 2
        DarkLabel2.Text = "Description:"
        ' 
        ' txtName
        ' 
        txtName.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtName.BorderStyle = BorderStyle.FixedSingle
        txtName.Font = New Font("Segoe UI", 8.25F)
        txtName.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtName.Location = New Point(83, 27)
        txtName.Margin = New Padding(5, 5, 5, 5)
        txtName.Name = "txtName"
        txtName.Size = New Size(472, 29)
        txtName.TabIndex = 1
        ' 
        ' DarkLabel1
        ' 
        DarkLabel1.AutoSize = True
        DarkLabel1.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel1.Location = New Point(10, 30)
        DarkLabel1.Margin = New Padding(5, 0, 5, 0)
        DarkLabel1.Name = "DarkLabel1"
        DarkLabel1.Size = New Size(63, 25)
        DarkLabel1.TabIndex = 0
        DarkLabel1.Text = "Name:"
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(12, 867)
        btnCancel.Margin = New Padding(5, 5, 5, 5)
        btnCancel.Name = "btnCancel"
        btnCancel.Padding = New Padding(8, 10, 8, 10)
        btnCancel.Size = New Size(265, 45)
        btnCancel.TabIndex = 4
        btnCancel.Text = "Cancel"
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(12, 756)
        btnSave.Margin = New Padding(5, 5, 5, 5)
        btnSave.Name = "btnSave"
        btnSave.Padding = New Padding(8, 10, 8, 10)
        btnSave.Size = New Size(265, 45)
        btnSave.TabIndex = 5
        btnSave.Text = "Save"
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(12, 812)
        btnDelete.Margin = New Padding(5, 5, 5, 5)
        btnDelete.Name = "btnDelete"
        btnDelete.Padding = New Padding(8, 10, 8, 10)
        btnDelete.Size = New Size(265, 45)
        btnDelete.TabIndex = 6
        btnDelete.Text = "Delete"
        ' 
        ' frmEditor_Job
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        ClientSize = New Size(879, 920)
        Controls.Add(btnDelete)
        Controls.Add(btnSave)
        Controls.Add(btnCancel)
        Controls.Add(DarkGroupBox2)
        Controls.Add(DarkGroupBox1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Margin = New Padding(5, 5, 5, 5)
        Name = "frmEditor_Job"
        Text = "Job Editor"
        DarkGroupBox1.ResumeLayout(False)
        DarkGroupBox2.ResumeLayout(False)
        DarkGroupBox2.PerformLayout()
        DarkGroupBox7.ResumeLayout(False)
        DarkGroupBox7.PerformLayout()
        CType(nudStartY, ComponentModel.ISupportInitialize).EndInit()
        CType(nudStartX, ComponentModel.ISupportInitialize).EndInit()
        CType(nudStartMap, ComponentModel.ISupportInitialize).EndInit()
        DarkGroupBox6.ResumeLayout(False)
        DarkGroupBox6.PerformLayout()
        CType(nudItemAmount, ComponentModel.ISupportInitialize).EndInit()
        DarkGroupBox5.ResumeLayout(False)
        DarkGroupBox5.PerformLayout()
        CType(nudBaseExp, ComponentModel.ISupportInitialize).EndInit()
        CType(nudSpirit, ComponentModel.ISupportInitialize).EndInit()
        CType(nudVitality, ComponentModel.ISupportInitialize).EndInit()
        CType(nudLuck, ComponentModel.ISupportInitialize).EndInit()
        CType(nudIntelligence, ComponentModel.ISupportInitialize).EndInit()
        CType(nudStrength, ComponentModel.ISupportInitialize).EndInit()
        DarkGroupBox4.ResumeLayout(False)
        DarkGroupBox4.PerformLayout()
        CType(nudFemaleSprite, ComponentModel.ISupportInitialize).EndInit()
        CType(picFemale, ComponentModel.ISupportInitialize).EndInit()
        DarkGroupBox3.ResumeLayout(False)
        DarkGroupBox3.PerformLayout()
        CType(nudMaleSprite, ComponentModel.ISupportInitialize).EndInit()
        CType(picMale, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DarkGroupBox1 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents DarkGroupBox2 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents txtName As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel1 As DarkUI.Controls.DarkLabel
    Friend WithEvents txtDescription As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel2 As DarkUI.Controls.DarkLabel
    Friend WithEvents lstIndex As System.Windows.Forms.ListBox
    Friend WithEvents DarkGroupBox4 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents DarkGroupBox3 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents picMale As System.Windows.Forms.PictureBox
    Friend WithEvents DarkLabel4 As DarkUI.Controls.DarkLabel
    Friend WithEvents picFemale As System.Windows.Forms.PictureBox
    Friend WithEvents lblMaleSprite As DarkUI.Controls.DarkLabel
    Friend WithEvents btnCancel As DarkUI.Controls.DarkButton
    Friend WithEvents btnSave As DarkUI.Controls.DarkButton
    Friend WithEvents DarkGroupBox5 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents nudFemaleSprite As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudMaleSprite As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel5 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel3 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudIntelligence As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudStrength As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudVitality As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudLuck As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel6 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel7 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudSpirit As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudEndurance As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel8 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel9 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudBaseExp As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel10 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkGroupBox6 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents lstStartItems As System.Windows.Forms.ListBox
    Friend WithEvents cmbItems As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel11 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudItemAmount As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel12 As DarkUI.Controls.DarkLabel
    Friend WithEvents btnItemAdd As DarkUI.Controls.DarkButton
    Friend WithEvents DarkGroupBox7 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents nudStartMap As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel13 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudStartY As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel15 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudStartX As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel14 As DarkUI.Controls.DarkLabel
    Friend WithEvents btnDelete As DarkUI.Controls.DarkButton
End Class
