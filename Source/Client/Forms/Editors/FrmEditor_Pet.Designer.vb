<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_Pet
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
        DarkGroupBox6 = New DarkUI.Controls.DarkGroupBox()
        cmbSkill4 = New DarkUI.Controls.DarkComboBox()
        DarkLabel19 = New DarkUI.Controls.DarkLabel()
        cmbSkill3 = New DarkUI.Controls.DarkComboBox()
        DarkLabel18 = New DarkUI.Controls.DarkLabel()
        cmbSkill2 = New DarkUI.Controls.DarkComboBox()
        DarkLabel17 = New DarkUI.Controls.DarkLabel()
        cmbSkill1 = New DarkUI.Controls.DarkComboBox()
        DarkLabel16 = New DarkUI.Controls.DarkLabel()
        DarkGroupBox4 = New DarkUI.Controls.DarkGroupBox()
        pnlPetlevel = New Panel()
        DarkGroupBox5 = New DarkUI.Controls.DarkGroupBox()
        cmbEvolve = New DarkUI.Controls.DarkComboBox()
        DarkLabel15 = New DarkUI.Controls.DarkLabel()
        nudEvolveLvl = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel14 = New DarkUI.Controls.DarkLabel()
        chkEvolve = New DarkUI.Controls.DarkCheckBox()
        nudMaxLevel = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel12 = New DarkUI.Controls.DarkLabel()
        nudPetPnts = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel13 = New DarkUI.Controls.DarkLabel()
        nudPetExp = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel11 = New DarkUI.Controls.DarkLabel()
        optDoNotLevel = New DarkUI.Controls.DarkRadioButton()
        optLevel = New DarkUI.Controls.DarkRadioButton()
        DarkGroupBox3 = New DarkUI.Controls.DarkGroupBox()
        pnlCustomStats = New Panel()
        nudLevel = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel10 = New DarkUI.Controls.DarkLabel()
        nudSpirit = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel7 = New DarkUI.Controls.DarkLabel()
        nudIntelligence = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel8 = New DarkUI.Controls.DarkLabel()
        nudLuck = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel9 = New DarkUI.Controls.DarkLabel()
        nudVitality = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel6 = New DarkUI.Controls.DarkLabel()
        nudStrength = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel4 = New DarkUI.Controls.DarkLabel()
        optAdoptStats = New DarkUI.Controls.DarkRadioButton()
        optCustomStats = New DarkUI.Controls.DarkRadioButton()
        DarkLabel3 = New DarkUI.Controls.DarkLabel()
        nudRange = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel2 = New DarkUI.Controls.DarkLabel()
        nudSprite = New DarkUI.Controls.DarkNumericUpDown()
        picSprite = New PictureBox()
        txtName = New DarkUI.Controls.DarkTextBox()
        DarkLabel1 = New DarkUI.Controls.DarkLabel()
        btnSave = New DarkUI.Controls.DarkButton()
        btnCancel = New DarkUI.Controls.DarkButton()
        btnDelete = New DarkUI.Controls.DarkButton()
        DarkGroupBox1.SuspendLayout()
        DarkGroupBox2.SuspendLayout()
        DarkGroupBox6.SuspendLayout()
        DarkGroupBox4.SuspendLayout()
        pnlPetlevel.SuspendLayout()
        DarkGroupBox5.SuspendLayout()
        CType(nudEvolveLvl, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudMaxLevel, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudPetPnts, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudPetExp, ComponentModel.ISupportInitialize).BeginInit()
        DarkGroupBox3.SuspendLayout()
        pnlCustomStats.SuspendLayout()
        CType(nudLevel, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudSpirit, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudIntelligence, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudLuck, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudVitality, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudStrength, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudRange, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudSprite, ComponentModel.ISupportInitialize).BeginInit()
        CType(picSprite, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DarkGroupBox1
        ' 
        DarkGroupBox1.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox1.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox1.Controls.Add(lstIndex)
        DarkGroupBox1.ForeColor = Color.Gainsboro
        DarkGroupBox1.Location = New Point(2, 5)
        DarkGroupBox1.Margin = New Padding(6, 5, 6, 5)
        DarkGroupBox1.Name = "DarkGroupBox1"
        DarkGroupBox1.Padding = New Padding(6, 5, 6, 5)
        DarkGroupBox1.Size = New Size(348, 741)
        DarkGroupBox1.TabIndex = 0
        DarkGroupBox1.TabStop = False
        DarkGroupBox1.Text = "Pet List"
        ' 
        ' lstIndex
        ' 
        lstIndex.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        lstIndex.BorderStyle = BorderStyle.FixedSingle
        lstIndex.ForeColor = Color.Gainsboro
        lstIndex.FormattingEnabled = True
        lstIndex.ItemHeight = 25
        lstIndex.Location = New Point(10, 27)
        lstIndex.Margin = New Padding(6, 5, 6, 5)
        lstIndex.Name = "lstIndex"
        lstIndex.Size = New Size(329, 702)
        lstIndex.TabIndex = 1
        ' 
        ' DarkGroupBox2
        ' 
        DarkGroupBox2.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox2.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox2.Controls.Add(DarkGroupBox6)
        DarkGroupBox2.Controls.Add(DarkGroupBox4)
        DarkGroupBox2.Controls.Add(DarkGroupBox3)
        DarkGroupBox2.Controls.Add(DarkLabel3)
        DarkGroupBox2.Controls.Add(nudRange)
        DarkGroupBox2.Controls.Add(DarkLabel2)
        DarkGroupBox2.Controls.Add(nudSprite)
        DarkGroupBox2.Controls.Add(picSprite)
        DarkGroupBox2.Controls.Add(txtName)
        DarkGroupBox2.Controls.Add(DarkLabel1)
        DarkGroupBox2.ForeColor = Color.Gainsboro
        DarkGroupBox2.Location = New Point(360, 5)
        DarkGroupBox2.Margin = New Padding(6, 5, 6, 5)
        DarkGroupBox2.Name = "DarkGroupBox2"
        DarkGroupBox2.Padding = New Padding(6, 5, 6, 5)
        DarkGroupBox2.Size = New Size(683, 909)
        DarkGroupBox2.TabIndex = 1
        DarkGroupBox2.TabStop = False
        DarkGroupBox2.Text = "Properties"
        ' 
        ' DarkGroupBox6
        ' 
        DarkGroupBox6.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox6.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox6.Controls.Add(cmbSkill4)
        DarkGroupBox6.Controls.Add(DarkLabel19)
        DarkGroupBox6.Controls.Add(cmbSkill3)
        DarkGroupBox6.Controls.Add(DarkLabel18)
        DarkGroupBox6.Controls.Add(cmbSkill2)
        DarkGroupBox6.Controls.Add(DarkLabel17)
        DarkGroupBox6.Controls.Add(cmbSkill1)
        DarkGroupBox6.Controls.Add(DarkLabel16)
        DarkGroupBox6.ForeColor = Color.Gainsboro
        DarkGroupBox6.Location = New Point(10, 750)
        DarkGroupBox6.Margin = New Padding(6, 5, 6, 5)
        DarkGroupBox6.Name = "DarkGroupBox6"
        DarkGroupBox6.Padding = New Padding(6, 5, 6, 5)
        DarkGroupBox6.Size = New Size(663, 147)
        DarkGroupBox6.TabIndex = 10
        DarkGroupBox6.TabStop = False
        DarkGroupBox6.Text = "Start Skills"
        ' 
        ' cmbSkill4
        ' 
        cmbSkill4.DrawMode = DrawMode.OwnerDrawFixed
        cmbSkill4.FormattingEnabled = True
        cmbSkill4.Location = New Point(414, 88)
        cmbSkill4.Margin = New Padding(6, 5, 6, 5)
        cmbSkill4.Name = "cmbSkill4"
        cmbSkill4.Size = New Size(227, 32)
        cmbSkill4.TabIndex = 7
        ' 
        ' DarkLabel19
        ' 
        DarkLabel19.AutoSize = True
        DarkLabel19.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel19.Location = New Point(342, 95)
        DarkLabel19.Margin = New Padding(6, 0, 6, 0)
        DarkLabel19.Name = "DarkLabel19"
        DarkLabel19.Size = New Size(62, 25)
        DarkLabel19.TabIndex = 6
        DarkLabel19.Text = "Skill 4:"
        ' 
        ' cmbSkill3
        ' 
        cmbSkill3.DrawMode = DrawMode.OwnerDrawFixed
        cmbSkill3.FormattingEnabled = True
        cmbSkill3.Location = New Point(80, 88)
        cmbSkill3.Margin = New Padding(6, 5, 6, 5)
        cmbSkill3.Name = "cmbSkill3"
        cmbSkill3.Size = New Size(227, 32)
        cmbSkill3.TabIndex = 5
        ' 
        ' DarkLabel18
        ' 
        DarkLabel18.AutoSize = True
        DarkLabel18.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel18.Location = New Point(7, 95)
        DarkLabel18.Margin = New Padding(6, 0, 6, 0)
        DarkLabel18.Name = "DarkLabel18"
        DarkLabel18.Size = New Size(62, 25)
        DarkLabel18.TabIndex = 4
        DarkLabel18.Text = "Skill 3:"
        ' 
        ' cmbSkill2
        ' 
        cmbSkill2.DrawMode = DrawMode.OwnerDrawFixed
        cmbSkill2.FormattingEnabled = True
        cmbSkill2.Location = New Point(414, 37)
        cmbSkill2.Margin = New Padding(6, 5, 6, 5)
        cmbSkill2.Name = "cmbSkill2"
        cmbSkill2.Size = New Size(227, 32)
        cmbSkill2.TabIndex = 3
        ' 
        ' DarkLabel17
        ' 
        DarkLabel17.AutoSize = True
        DarkLabel17.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel17.Location = New Point(342, 41)
        DarkLabel17.Margin = New Padding(6, 0, 6, 0)
        DarkLabel17.Name = "DarkLabel17"
        DarkLabel17.Size = New Size(62, 25)
        DarkLabel17.TabIndex = 2
        DarkLabel17.Text = "Skill 2:"
        ' 
        ' cmbSkill1
        ' 
        cmbSkill1.DrawMode = DrawMode.OwnerDrawFixed
        cmbSkill1.FormattingEnabled = True
        cmbSkill1.Location = New Point(80, 37)
        cmbSkill1.Margin = New Padding(6, 5, 6, 5)
        cmbSkill1.Name = "cmbSkill1"
        cmbSkill1.Size = New Size(227, 32)
        cmbSkill1.TabIndex = 1
        ' 
        ' DarkLabel16
        ' 
        DarkLabel16.AutoSize = True
        DarkLabel16.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel16.Location = New Point(7, 41)
        DarkLabel16.Margin = New Padding(6, 0, 6, 0)
        DarkLabel16.Name = "DarkLabel16"
        DarkLabel16.Size = New Size(62, 25)
        DarkLabel16.TabIndex = 0
        DarkLabel16.Text = "Skill 1:"
        ' 
        ' DarkGroupBox4
        ' 
        DarkGroupBox4.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox4.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox4.Controls.Add(pnlPetlevel)
        DarkGroupBox4.Controls.Add(optDoNotLevel)
        DarkGroupBox4.Controls.Add(optLevel)
        DarkGroupBox4.ForeColor = Color.Gainsboro
        DarkGroupBox4.Location = New Point(10, 420)
        DarkGroupBox4.Margin = New Padding(6, 5, 6, 5)
        DarkGroupBox4.Name = "DarkGroupBox4"
        DarkGroupBox4.Padding = New Padding(6, 5, 6, 5)
        DarkGroupBox4.Size = New Size(663, 320)
        DarkGroupBox4.TabIndex = 9
        DarkGroupBox4.TabStop = False
        DarkGroupBox4.Text = "Leveling"
        ' 
        ' pnlPetlevel
        ' 
        pnlPetlevel.Controls.Add(DarkGroupBox5)
        pnlPetlevel.Controls.Add(nudMaxLevel)
        pnlPetlevel.Controls.Add(DarkLabel12)
        pnlPetlevel.Controls.Add(nudPetPnts)
        pnlPetlevel.Controls.Add(DarkLabel13)
        pnlPetlevel.Controls.Add(nudPetExp)
        pnlPetlevel.Controls.Add(DarkLabel11)
        pnlPetlevel.Location = New Point(10, 80)
        pnlPetlevel.Margin = New Padding(6, 5, 6, 5)
        pnlPetlevel.Name = "pnlPetlevel"
        pnlPetlevel.Size = New Size(643, 227)
        pnlPetlevel.TabIndex = 2
        ' 
        ' DarkGroupBox5
        ' 
        DarkGroupBox5.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox5.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox5.Controls.Add(cmbEvolve)
        DarkGroupBox5.Controls.Add(DarkLabel15)
        DarkGroupBox5.Controls.Add(nudEvolveLvl)
        DarkGroupBox5.Controls.Add(DarkLabel14)
        DarkGroupBox5.Controls.Add(chkEvolve)
        DarkGroupBox5.ForeColor = Color.Gainsboro
        DarkGroupBox5.Location = New Point(10, 73)
        DarkGroupBox5.Margin = New Padding(6, 5, 6, 5)
        DarkGroupBox5.Name = "DarkGroupBox5"
        DarkGroupBox5.Padding = New Padding(6, 5, 6, 5)
        DarkGroupBox5.Size = New Size(622, 145)
        DarkGroupBox5.TabIndex = 7
        DarkGroupBox5.TabStop = False
        DarkGroupBox5.Text = "Evolution"
        ' 
        ' cmbEvolve
        ' 
        cmbEvolve.DrawMode = DrawMode.OwnerDrawFixed
        cmbEvolve.FormattingEnabled = True
        cmbEvolve.Location = New Point(167, 87)
        cmbEvolve.Margin = New Padding(6, 5, 6, 5)
        cmbEvolve.Name = "cmbEvolve"
        cmbEvolve.Size = New Size(442, 32)
        cmbEvolve.TabIndex = 4
        ' 
        ' DarkLabel15
        ' 
        DarkLabel15.AutoSize = True
        DarkLabel15.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel15.Location = New Point(10, 91)
        DarkLabel15.Margin = New Padding(6, 0, 6, 0)
        DarkLabel15.Name = "DarkLabel15"
        DarkLabel15.Size = New Size(111, 25)
        DarkLabel15.TabIndex = 3
        DarkLabel15.Text = "Evolves into:"
        ' 
        ' nudEvolveLvl
        ' 
        nudEvolveLvl.Location = New Point(508, 41)
        nudEvolveLvl.Margin = New Padding(6, 5, 6, 5)
        nudEvolveLvl.Name = "nudEvolveLvl"
        nudEvolveLvl.Size = New Size(103, 31)
        nudEvolveLvl.TabIndex = 2
        ' 
        ' DarkLabel14
        ' 
        DarkLabel14.AutoSize = True
        DarkLabel14.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel14.Location = New Point(344, 45)
        DarkLabel14.Margin = New Padding(6, 0, 6, 0)
        DarkLabel14.Name = "DarkLabel14"
        DarkLabel14.Size = New Size(145, 25)
        DarkLabel14.TabIndex = 1
        DarkLabel14.Text = "Evolves on Level:"
        ' 
        ' chkEvolve
        ' 
        chkEvolve.AutoSize = True
        chkEvolve.Location = New Point(10, 37)
        chkEvolve.Margin = New Padding(6, 5, 6, 5)
        chkEvolve.Name = "chkEvolve"
        chkEvolve.Size = New Size(153, 29)
        chkEvolve.TabIndex = 0
        chkEvolve.Text = "Pet Can Evolve"
        ' 
        ' nudMaxLevel
        ' 
        nudMaxLevel.Location = New Point(542, 23)
        nudMaxLevel.Margin = New Padding(6, 5, 6, 5)
        nudMaxLevel.Name = "nudMaxLevel"
        nudMaxLevel.Size = New Size(78, 31)
        nudMaxLevel.TabIndex = 6
        nudMaxLevel.Value = New Decimal(New Integer() {100, 0, 0, 0})
        ' 
        ' DarkLabel12
        ' 
        DarkLabel12.AutoSize = True
        DarkLabel12.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel12.Location = New Point(433, 27)
        DarkLabel12.Margin = New Padding(6, 0, 6, 0)
        DarkLabel12.Name = "DarkLabel12"
        DarkLabel12.Size = New Size(93, 25)
        DarkLabel12.TabIndex = 5
        DarkLabel12.Text = "Max Level:"
        ' 
        ' nudPetPnts
        ' 
        nudPetPnts.Location = New Point(362, 23)
        nudPetPnts.Margin = New Padding(6, 5, 6, 5)
        nudPetPnts.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        nudPetPnts.Name = "nudPetPnts"
        nudPetPnts.Size = New Size(60, 31)
        nudPetPnts.TabIndex = 4
        nudPetPnts.Value = New Decimal(New Integer() {10, 0, 0, 0})
        ' 
        ' DarkLabel13
        ' 
        DarkLabel13.AutoSize = True
        DarkLabel13.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel13.Location = New Point(212, 27)
        DarkLabel13.Margin = New Padding(6, 0, 6, 0)
        DarkLabel13.Name = "DarkLabel13"
        DarkLabel13.Size = New Size(137, 25)
        DarkLabel13.TabIndex = 3
        DarkLabel13.Text = "Points Per Level:"
        ' 
        ' nudPetExp
        ' 
        nudPetExp.Location = New Point(123, 23)
        nudPetExp.Margin = New Padding(6, 5, 6, 5)
        nudPetExp.Name = "nudPetExp"
        nudPetExp.Size = New Size(78, 31)
        nudPetExp.TabIndex = 1
        nudPetExp.Value = New Decimal(New Integer() {100, 0, 0, 0})
        ' 
        ' DarkLabel11
        ' 
        DarkLabel11.AutoSize = True
        DarkLabel11.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel11.Location = New Point(7, 27)
        DarkLabel11.Margin = New Padding(6, 0, 6, 0)
        DarkLabel11.Name = "DarkLabel11"
        DarkLabel11.Size = New Size(104, 25)
        DarkLabel11.TabIndex = 0
        DarkLabel11.Text = "Exp Gain %:"
        ' 
        ' optDoNotLevel
        ' 
        optDoNotLevel.AutoSize = True
        optDoNotLevel.Location = New Point(440, 37)
        optDoNotLevel.Margin = New Padding(6, 5, 6, 5)
        optDoNotLevel.Name = "optDoNotLevel"
        optDoNotLevel.Size = New Size(180, 29)
        optDoNotLevel.TabIndex = 1
        optDoNotLevel.Text = "Does Not LevelUp"
        ' 
        ' optLevel
        ' 
        optLevel.AutoSize = True
        optLevel.Location = New Point(10, 37)
        optLevel.Margin = New Padding(6, 5, 6, 5)
        optLevel.Name = "optLevel"
        optLevel.Size = New Size(189, 29)
        optLevel.TabIndex = 0
        optLevel.Text = "Level by Experience"
        ' 
        ' DarkGroupBox3
        ' 
        DarkGroupBox3.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox3.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox3.Controls.Add(pnlCustomStats)
        DarkGroupBox3.Controls.Add(optAdoptStats)
        DarkGroupBox3.Controls.Add(optCustomStats)
        DarkGroupBox3.ForeColor = Color.Gainsboro
        DarkGroupBox3.Location = New Point(10, 148)
        DarkGroupBox3.Margin = New Padding(6, 5, 6, 5)
        DarkGroupBox3.Name = "DarkGroupBox3"
        DarkGroupBox3.Padding = New Padding(6, 5, 6, 5)
        DarkGroupBox3.Size = New Size(660, 259)
        DarkGroupBox3.TabIndex = 8
        DarkGroupBox3.TabStop = False
        DarkGroupBox3.Text = "Starting Stats"
        ' 
        ' pnlCustomStats
        ' 
        pnlCustomStats.Controls.Add(nudLevel)
        pnlCustomStats.Controls.Add(DarkLabel10)
        pnlCustomStats.Controls.Add(nudSpirit)
        pnlCustomStats.Controls.Add(DarkLabel7)
        pnlCustomStats.Controls.Add(nudIntelligence)
        pnlCustomStats.Controls.Add(DarkLabel8)
        pnlCustomStats.Controls.Add(nudLuck)
        pnlCustomStats.Controls.Add(DarkLabel9)
        pnlCustomStats.Controls.Add(nudVitality)
        pnlCustomStats.Controls.Add(DarkLabel6)
        pnlCustomStats.Controls.Add(nudStrength)
        pnlCustomStats.Controls.Add(DarkLabel4)
        pnlCustomStats.Location = New Point(10, 80)
        pnlCustomStats.Margin = New Padding(6, 5, 6, 5)
        pnlCustomStats.Name = "pnlCustomStats"
        pnlCustomStats.Size = New Size(640, 170)
        pnlCustomStats.TabIndex = 2
        ' 
        ' nudLevel
        ' 
        nudLevel.Location = New Point(99, 20)
        nudLevel.Margin = New Padding(6, 5, 6, 5)
        nudLevel.Name = "nudLevel"
        nudLevel.Size = New Size(90, 31)
        nudLevel.TabIndex = 13
        ' 
        ' DarkLabel10
        ' 
        DarkLabel10.AutoSize = True
        DarkLabel10.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel10.Location = New Point(7, 26)
        DarkLabel10.Margin = New Padding(6, 0, 6, 0)
        DarkLabel10.Name = "DarkLabel10"
        DarkLabel10.Size = New Size(55, 25)
        DarkLabel10.TabIndex = 12
        DarkLabel10.Text = "Level:"
        ' 
        ' nudSpirit
        ' 
        nudSpirit.Location = New Point(542, 66)
        nudSpirit.Margin = New Padding(6, 5, 6, 5)
        nudSpirit.Name = "nudSpirit"
        nudSpirit.Size = New Size(90, 31)
        nudSpirit.TabIndex = 11
        ' 
        ' DarkLabel7
        ' 
        DarkLabel7.AutoSize = True
        DarkLabel7.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel7.Location = New Point(450, 70)
        DarkLabel7.Margin = New Padding(6, 0, 6, 0)
        DarkLabel7.Name = "DarkLabel7"
        DarkLabel7.Size = New Size(57, 25)
        DarkLabel7.TabIndex = 10
        DarkLabel7.Text = "Spirit:"
        ' 
        ' nudIntelligence
        ' 
        nudIntelligence.Location = New Point(332, 66)
        nudIntelligence.Margin = New Padding(6, 5, 6, 5)
        nudIntelligence.Name = "nudIntelligence"
        nudIntelligence.Size = New Size(90, 31)
        nudIntelligence.TabIndex = 9
        ' 
        ' DarkLabel8
        ' 
        DarkLabel8.AutoSize = True
        DarkLabel8.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel8.Location = New Point(220, 70)
        DarkLabel8.Margin = New Padding(6, 0, 6, 0)
        DarkLabel8.Name = "DarkLabel8"
        DarkLabel8.Size = New Size(105, 25)
        DarkLabel8.TabIndex = 8
        DarkLabel8.Text = "Intelligence:"
        ' 
        ' nudLuck
        ' 
        nudLuck.Location = New Point(98, 66)
        nudLuck.Margin = New Padding(6, 5, 6, 5)
        nudLuck.Name = "nudLuck"
        nudLuck.Size = New Size(90, 31)
        nudLuck.TabIndex = 7
        ' 
        ' DarkLabel9
        ' 
        DarkLabel9.AutoSize = True
        DarkLabel9.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel9.Location = New Point(7, 70)
        DarkLabel9.Margin = New Padding(6, 0, 6, 0)
        DarkLabel9.Name = "DarkLabel9"
        DarkLabel9.Size = New Size(51, 25)
        DarkLabel9.TabIndex = 6
        DarkLabel9.Text = "Luck:"
        ' 
        ' nudVitality
        ' 
        nudVitality.Location = New Point(542, 16)
        nudVitality.Margin = New Padding(6, 5, 6, 5)
        nudVitality.Name = "nudVitality"
        nudVitality.Size = New Size(90, 31)
        nudVitality.TabIndex = 5
        ' 
        ' DarkLabel6
        ' 
        DarkLabel6.AutoSize = True
        DarkLabel6.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel6.Location = New Point(448, 20)
        DarkLabel6.Margin = New Padding(6, 0, 6, 0)
        DarkLabel6.Name = "DarkLabel6"
        DarkLabel6.Size = New Size(69, 25)
        DarkLabel6.TabIndex = 4
        DarkLabel6.Text = "Vitality:"
        ' 
        ' nudStrength
        ' 
        nudStrength.Location = New Point(334, 16)
        nudStrength.Margin = New Padding(6, 5, 6, 5)
        nudStrength.Name = "nudStrength"
        nudStrength.Size = New Size(90, 31)
        nudStrength.TabIndex = 1
        ' 
        ' DarkLabel4
        ' 
        DarkLabel4.AutoSize = True
        DarkLabel4.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel4.Location = New Point(242, 20)
        DarkLabel4.Margin = New Padding(6, 0, 6, 0)
        DarkLabel4.Name = "DarkLabel4"
        DarkLabel4.Size = New Size(83, 25)
        DarkLabel4.TabIndex = 0
        DarkLabel4.Text = "Strength:"
        ' 
        ' optAdoptStats
        ' 
        optAdoptStats.AutoSize = True
        optAdoptStats.Location = New Point(448, 37)
        optAdoptStats.Margin = New Padding(6, 5, 6, 5)
        optAdoptStats.Name = "optAdoptStats"
        optAdoptStats.Size = New Size(200, 29)
        optAdoptStats.TabIndex = 1
        optAdoptStats.TabStop = True
        optAdoptStats.Text = "Adopt Owner's Stats"
        ' 
        ' optCustomStats
        ' 
        optCustomStats.AutoSize = True
        optCustomStats.Location = New Point(10, 37)
        optCustomStats.Margin = New Padding(6, 5, 6, 5)
        optCustomStats.Name = "optCustomStats"
        optCustomStats.Size = New Size(142, 29)
        optCustomStats.TabIndex = 0
        optCustomStats.TabStop = True
        optCustomStats.Text = "Custom Stats"
        ' 
        ' DarkLabel3
        ' 
        DarkLabel3.AutoSize = True
        DarkLabel3.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel3.Location = New Point(10, 91)
        DarkLabel3.Margin = New Padding(6, 0, 6, 0)
        DarkLabel3.Name = "DarkLabel3"
        DarkLabel3.Size = New Size(66, 25)
        DarkLabel3.TabIndex = 7
        DarkLabel3.Text = "Range:"
        ' 
        ' nudRange
        ' 
        nudRange.Location = New Point(114, 88)
        nudRange.Margin = New Padding(6, 5, 6, 5)
        nudRange.Name = "nudRange"
        nudRange.Size = New Size(127, 31)
        nudRange.TabIndex = 6
        ' 
        ' DarkLabel2
        ' 
        DarkLabel2.AutoSize = True
        DarkLabel2.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel2.Location = New Point(374, 91)
        DarkLabel2.Margin = New Padding(6, 0, 6, 0)
        DarkLabel2.Name = "DarkLabel2"
        DarkLabel2.Size = New Size(62, 25)
        DarkLabel2.TabIndex = 5
        DarkLabel2.Text = "Sprite:"
        ' 
        ' nudSprite
        ' 
        nudSprite.Location = New Point(458, 88)
        nudSprite.Margin = New Padding(6, 5, 6, 5)
        nudSprite.Name = "nudSprite"
        nudSprite.Size = New Size(127, 31)
        nudSprite.TabIndex = 4
        ' 
        ' picSprite
        ' 
        picSprite.BackColor = Color.Black
        picSprite.Location = New Point(590, 45)
        picSprite.Margin = New Padding(6, 5, 6, 5)
        picSprite.Name = "picSprite"
        picSprite.Size = New Size(46, 53)
        picSprite.TabIndex = 3
        picSprite.TabStop = False
        ' 
        ' txtName
        ' 
        txtName.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtName.BorderStyle = BorderStyle.FixedSingle
        txtName.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtName.Location = New Point(114, 34)
        txtName.Margin = New Padding(6, 5, 6, 5)
        txtName.Name = "txtName"
        txtName.Size = New Size(464, 31)
        txtName.TabIndex = 1
        ' 
        ' DarkLabel1
        ' 
        DarkLabel1.AutoSize = True
        DarkLabel1.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel1.Location = New Point(10, 38)
        DarkLabel1.Margin = New Padding(6, 0, 6, 0)
        DarkLabel1.Name = "DarkLabel1"
        DarkLabel1.Size = New Size(63, 25)
        DarkLabel1.TabIndex = 0
        DarkLabel1.Text = "Name:"
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(13, 759)
        btnSave.Margin = New Padding(6, 5, 6, 5)
        btnSave.Name = "btnSave"
        btnSave.Padding = New Padding(8, 9, 8, 9)
        btnSave.Size = New Size(330, 45)
        btnSave.TabIndex = 2
        btnSave.Text = "Save"
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(13, 868)
        btnCancel.Margin = New Padding(6, 5, 6, 5)
        btnCancel.Name = "btnCancel"
        btnCancel.Padding = New Padding(8, 9, 8, 9)
        btnCancel.Size = New Size(330, 45)
        btnCancel.TabIndex = 3
        btnCancel.Text = "Cancel"
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(13, 813)
        btnDelete.Margin = New Padding(6, 5, 6, 5)
        btnDelete.Name = "btnDelete"
        btnDelete.Padding = New Padding(8, 9, 8, 9)
        btnDelete.Size = New Size(330, 45)
        btnDelete.TabIndex = 4
        btnDelete.Text = "Delete"
        ' 
        ' frmEditor_Pet
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        ClientSize = New Size(1052, 923)
        Controls.Add(btnDelete)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(DarkGroupBox2)
        Controls.Add(DarkGroupBox1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Margin = New Padding(6, 5, 6, 5)
        Name = "frmEditor_Pet"
        Text = "Pet Editor"
        DarkGroupBox1.ResumeLayout(False)
        DarkGroupBox2.ResumeLayout(False)
        DarkGroupBox2.PerformLayout()
        DarkGroupBox6.ResumeLayout(False)
        DarkGroupBox6.PerformLayout()
        DarkGroupBox4.ResumeLayout(False)
        DarkGroupBox4.PerformLayout()
        pnlPetlevel.ResumeLayout(False)
        pnlPetlevel.PerformLayout()
        DarkGroupBox5.ResumeLayout(False)
        DarkGroupBox5.PerformLayout()
        CType(nudEvolveLvl, ComponentModel.ISupportInitialize).EndInit()
        CType(nudMaxLevel, ComponentModel.ISupportInitialize).EndInit()
        CType(nudPetPnts, ComponentModel.ISupportInitialize).EndInit()
        CType(nudPetExp, ComponentModel.ISupportInitialize).EndInit()
        DarkGroupBox3.ResumeLayout(False)
        DarkGroupBox3.PerformLayout()
        pnlCustomStats.ResumeLayout(False)
        pnlCustomStats.PerformLayout()
        CType(nudLevel, ComponentModel.ISupportInitialize).EndInit()
        CType(nudSpirit, ComponentModel.ISupportInitialize).EndInit()
        CType(nudIntelligence, ComponentModel.ISupportInitialize).EndInit()
        CType(nudLuck, ComponentModel.ISupportInitialize).EndInit()
        CType(nudVitality, ComponentModel.ISupportInitialize).EndInit()
        CType(nudStrength, ComponentModel.ISupportInitialize).EndInit()
        CType(nudRange, ComponentModel.ISupportInitialize).EndInit()
        CType(nudSprite, ComponentModel.ISupportInitialize).EndInit()
        CType(picSprite, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents DarkGroupBox1 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents lstIndex As System.Windows.Forms.ListBox
    Friend WithEvents DarkGroupBox2 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents txtName As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel1 As DarkUI.Controls.DarkLabel
    Friend WithEvents picSprite As System.Windows.Forms.PictureBox
    Friend WithEvents DarkLabel2 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudSprite As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel3 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudRange As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkGroupBox3 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents optCustomStats As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optAdoptStats As DarkUI.Controls.DarkRadioButton
    Friend WithEvents pnlCustomStats As System.Windows.Forms.Panel
    Friend WithEvents nudVitality As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel6 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudStrength As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel4 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudSpirit As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel7 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudIntelligence As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel8 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudLuck As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel9 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudLevel As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel10 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkGroupBox4 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents optLevel As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optDoNotLevel As DarkUI.Controls.DarkRadioButton
    Friend WithEvents pnlPetlevel As System.Windows.Forms.Panel
    Friend WithEvents nudPetExp As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel11 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel13 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudMaxLevel As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel12 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudPetPnts As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkGroupBox5 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents chkEvolve As DarkUI.Controls.DarkCheckBox
    Friend WithEvents DarkLabel14 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudEvolveLvl As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel15 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbEvolve As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkGroupBox6 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents cmbSkill4 As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel19 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbSkill3 As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel18 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbSkill2 As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel17 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbSkill1 As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel16 As DarkUI.Controls.DarkLabel
    Friend WithEvents btnSave As DarkUI.Controls.DarkButton
    Friend WithEvents btnCancel As DarkUI.Controls.DarkButton
    Friend WithEvents btnDelete As DarkUI.Controls.DarkButton
End Class
