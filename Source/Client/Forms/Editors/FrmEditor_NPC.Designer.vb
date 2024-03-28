<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_NPC
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
        cmbSpawnPeriod = New DarkUI.Controls.DarkComboBox()
        DarkLabel30 = New DarkUI.Controls.DarkLabel()
        nudSpawnSecs = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel13 = New DarkUI.Controls.DarkLabel()
        nudDamage = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel12 = New DarkUI.Controls.DarkLabel()
        nudLevel = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel11 = New DarkUI.Controls.DarkLabel()
        nudExp = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel10 = New DarkUI.Controls.DarkLabel()
        nudHp = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel9 = New DarkUI.Controls.DarkLabel()
        cmbFaction = New DarkUI.Controls.DarkComboBox()
        DarkLabel8 = New DarkUI.Controls.DarkLabel()
        cmbBehaviour = New DarkUI.Controls.DarkComboBox()
        DarkLabel5 = New DarkUI.Controls.DarkLabel()
        cmbAnimation = New DarkUI.Controls.DarkComboBox()
        DarkLabel7 = New DarkUI.Controls.DarkLabel()
        DarkLabel4 = New DarkUI.Controls.DarkLabel()
        nudRange = New DarkUI.Controls.DarkNumericUpDown()
        nudSprite = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel3 = New DarkUI.Controls.DarkLabel()
        txtAttackSay = New DarkUI.Controls.DarkTextBox()
        DarkLabel2 = New DarkUI.Controls.DarkLabel()
        picSprite = New PictureBox()
        txtName = New DarkUI.Controls.DarkTextBox()
        DarkLabel1 = New DarkUI.Controls.DarkLabel()
        DarkGroupBox3 = New DarkUI.Controls.DarkGroupBox()
        cmbSkill6 = New DarkUI.Controls.DarkComboBox()
        DarkLabel17 = New DarkUI.Controls.DarkLabel()
        cmbSkill5 = New DarkUI.Controls.DarkComboBox()
        DarkLabel18 = New DarkUI.Controls.DarkLabel()
        cmbSkill4 = New DarkUI.Controls.DarkComboBox()
        DarkLabel19 = New DarkUI.Controls.DarkLabel()
        cmbSkill3 = New DarkUI.Controls.DarkComboBox()
        DarkLabel16 = New DarkUI.Controls.DarkLabel()
        cmbSkill2 = New DarkUI.Controls.DarkComboBox()
        DarkLabel15 = New DarkUI.Controls.DarkLabel()
        cmbSkill1 = New DarkUI.Controls.DarkComboBox()
        DarkLabel14 = New DarkUI.Controls.DarkLabel()
        DarkGroupBox4 = New DarkUI.Controls.DarkGroupBox()
        nudAmount = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel29 = New DarkUI.Controls.DarkLabel()
        cmbItem = New DarkUI.Controls.DarkComboBox()
        DarkLabel28 = New DarkUI.Controls.DarkLabel()
        cmbDropSlot = New DarkUI.Controls.DarkComboBox()
        nudChance = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel27 = New DarkUI.Controls.DarkLabel()
        DarkLabel26 = New DarkUI.Controls.DarkLabel()
        DarkGroupBox5 = New DarkUI.Controls.DarkGroupBox()
        nudSpirit = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel23 = New DarkUI.Controls.DarkLabel()
        nudIntelligence = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel24 = New DarkUI.Controls.DarkLabel()
        nudLuck = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel25 = New DarkUI.Controls.DarkLabel()
        nudVitality = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel22 = New DarkUI.Controls.DarkLabel()
        nudStrength = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel20 = New DarkUI.Controls.DarkLabel()
        btnCancel = New DarkUI.Controls.DarkButton()
        btnDelete = New DarkUI.Controls.DarkButton()
        btnSave = New DarkUI.Controls.DarkButton()
        DarkGroupBox1.SuspendLayout()
        DarkGroupBox2.SuspendLayout()
        CType(nudSpawnSecs, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudDamage, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudLevel, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudExp, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudHp, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudRange, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudSprite, ComponentModel.ISupportInitialize).BeginInit()
        CType(picSprite, ComponentModel.ISupportInitialize).BeginInit()
        DarkGroupBox3.SuspendLayout()
        DarkGroupBox4.SuspendLayout()
        CType(nudAmount, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudChance, ComponentModel.ISupportInitialize).BeginInit()
        DarkGroupBox5.SuspendLayout()
        CType(nudSpirit, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudIntelligence, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudLuck, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudVitality, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudStrength, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DarkGroupBox1
        ' 
        DarkGroupBox1.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox1.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox1.Controls.Add(lstIndex)
        DarkGroupBox1.ForeColor = Color.Gainsboro
        DarkGroupBox1.Location = New Point(6, 3)
        DarkGroupBox1.Margin = New Padding(6, 5, 6, 5)
        DarkGroupBox1.Name = "DarkGroupBox1"
        DarkGroupBox1.Padding = New Padding(6, 5, 6, 5)
        DarkGroupBox1.Size = New Size(378, 752)
        DarkGroupBox1.TabIndex = 0
        DarkGroupBox1.TabStop = False
        DarkGroupBox1.Text = "NPC List"
        ' 
        ' lstIndex
        ' 
        lstIndex.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        lstIndex.BorderStyle = BorderStyle.FixedSingle
        lstIndex.ForeColor = Color.Gainsboro
        lstIndex.FormattingEnabled = True
        lstIndex.ItemHeight = 25
        lstIndex.Location = New Point(7, 30)
        lstIndex.Margin = New Padding(6, 5, 6, 5)
        lstIndex.Name = "lstIndex"
        lstIndex.Size = New Size(364, 702)
        lstIndex.TabIndex = 2
        ' 
        ' DarkGroupBox2
        ' 
        DarkGroupBox2.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox2.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox2.Controls.Add(cmbSpawnPeriod)
        DarkGroupBox2.Controls.Add(DarkLabel30)
        DarkGroupBox2.Controls.Add(nudSpawnSecs)
        DarkGroupBox2.Controls.Add(DarkLabel13)
        DarkGroupBox2.Controls.Add(nudDamage)
        DarkGroupBox2.Controls.Add(DarkLabel12)
        DarkGroupBox2.Controls.Add(nudLevel)
        DarkGroupBox2.Controls.Add(DarkLabel11)
        DarkGroupBox2.Controls.Add(nudExp)
        DarkGroupBox2.Controls.Add(DarkLabel10)
        DarkGroupBox2.Controls.Add(nudHp)
        DarkGroupBox2.Controls.Add(DarkLabel9)
        DarkGroupBox2.Controls.Add(cmbFaction)
        DarkGroupBox2.Controls.Add(DarkLabel8)
        DarkGroupBox2.Controls.Add(cmbBehaviour)
        DarkGroupBox2.Controls.Add(DarkLabel5)
        DarkGroupBox2.Controls.Add(cmbAnimation)
        DarkGroupBox2.Controls.Add(DarkLabel7)
        DarkGroupBox2.Controls.Add(DarkLabel4)
        DarkGroupBox2.Controls.Add(nudRange)
        DarkGroupBox2.Controls.Add(nudSprite)
        DarkGroupBox2.Controls.Add(DarkLabel3)
        DarkGroupBox2.Controls.Add(txtAttackSay)
        DarkGroupBox2.Controls.Add(DarkLabel2)
        DarkGroupBox2.Controls.Add(picSprite)
        DarkGroupBox2.Controls.Add(txtName)
        DarkGroupBox2.Controls.Add(DarkLabel1)
        DarkGroupBox2.ForeColor = Color.Gainsboro
        DarkGroupBox2.Location = New Point(393, 3)
        DarkGroupBox2.Margin = New Padding(6, 5, 6, 5)
        DarkGroupBox2.Name = "DarkGroupBox2"
        DarkGroupBox2.Padding = New Padding(6, 5, 6, 5)
        DarkGroupBox2.Size = New Size(657, 445)
        DarkGroupBox2.TabIndex = 1
        DarkGroupBox2.TabStop = False
        DarkGroupBox2.Text = "Properties"
        ' 
        ' cmbSpawnPeriod
        ' 
        cmbSpawnPeriod.DrawMode = DrawMode.OwnerDrawVariable
        cmbSpawnPeriod.FormattingEnabled = True
        cmbSpawnPeriod.Items.AddRange(New Object() {"Always", "Day", "Night", "Dawn", "Dusk"})
        cmbSpawnPeriod.Location = New Point(474, 388)
        cmbSpawnPeriod.Margin = New Padding(6, 5, 6, 5)
        cmbSpawnPeriod.Name = "cmbSpawnPeriod"
        cmbSpawnPeriod.Size = New Size(166, 32)
        cmbSpawnPeriod.TabIndex = 38
        ' 
        ' DarkLabel30
        ' 
        DarkLabel30.AutoSize = True
        DarkLabel30.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel30.Location = New Point(392, 395)
        DarkLabel30.Margin = New Padding(6, 0, 6, 0)
        DarkLabel30.Name = "DarkLabel30"
        DarkLabel30.Size = New Size(77, 25)
        DarkLabel30.TabIndex = 37
        DarkLabel30.Text = "Spawns:"
        ' 
        ' nudSpawnSecs
        ' 
        nudSpawnSecs.Location = New Point(248, 391)
        nudSpawnSecs.Margin = New Padding(6, 5, 6, 5)
        nudSpawnSecs.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        nudSpawnSecs.Name = "nudSpawnSecs"
        nudSpawnSecs.Size = New Size(138, 31)
        nudSpawnSecs.TabIndex = 36
        ' 
        ' DarkLabel13
        ' 
        DarkLabel13.AutoSize = True
        DarkLabel13.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel13.Location = New Point(10, 395)
        DarkLabel13.Margin = New Padding(6, 0, 6, 0)
        DarkLabel13.Name = "DarkLabel13"
        DarkLabel13.Size = New Size(220, 25)
        DarkLabel13.TabIndex = 35
        DarkLabel13.Text = "Respawn Time in Seconds:"
        ' 
        ' nudDamage
        ' 
        nudDamage.Location = New Point(443, 341)
        nudDamage.Margin = New Padding(6, 5, 6, 5)
        nudDamage.Name = "nudDamage"
        nudDamage.Size = New Size(200, 31)
        nudDamage.TabIndex = 34
        ' 
        ' DarkLabel12
        ' 
        DarkLabel12.AutoSize = True
        DarkLabel12.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel12.Location = New Point(310, 345)
        DarkLabel12.Margin = New Padding(6, 0, 6, 0)
        DarkLabel12.Name = "DarkLabel12"
        DarkLabel12.Size = New Size(124, 25)
        DarkLabel12.TabIndex = 33
        DarkLabel12.Text = "Base Damage:"
        ' 
        ' nudLevel
        ' 
        nudLevel.Location = New Point(100, 341)
        nudLevel.Margin = New Padding(6, 5, 6, 5)
        nudLevel.Name = "nudLevel"
        nudLevel.Size = New Size(200, 31)
        nudLevel.TabIndex = 32
        ' 
        ' DarkLabel11
        ' 
        DarkLabel11.AutoSize = True
        DarkLabel11.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel11.Location = New Point(10, 345)
        DarkLabel11.Margin = New Padding(6, 0, 6, 0)
        DarkLabel11.Name = "DarkLabel11"
        DarkLabel11.Size = New Size(55, 25)
        DarkLabel11.TabIndex = 31
        DarkLabel11.Text = "Level:"
        ' 
        ' nudExp
        ' 
        nudExp.Location = New Point(397, 291)
        nudExp.Margin = New Padding(6, 5, 6, 5)
        nudExp.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        nudExp.Name = "nudExp"
        nudExp.Size = New Size(247, 31)
        nudExp.TabIndex = 30
        ' 
        ' DarkLabel10
        ' 
        DarkLabel10.AutoSize = True
        DarkLabel10.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel10.Location = New Point(288, 295)
        DarkLabel10.Margin = New Padding(6, 0, 6, 0)
        DarkLabel10.Name = "DarkLabel10"
        DarkLabel10.Size = New Size(93, 25)
        DarkLabel10.TabIndex = 29
        DarkLabel10.Text = "Exp Given:"
        ' 
        ' nudHp
        ' 
        nudHp.Location = New Point(100, 291)
        nudHp.Margin = New Padding(6, 5, 6, 5)
        nudHp.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        nudHp.Name = "nudHp"
        nudHp.Size = New Size(178, 31)
        nudHp.TabIndex = 28
        ' 
        ' DarkLabel9
        ' 
        DarkLabel9.AutoSize = True
        DarkLabel9.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel9.Location = New Point(10, 295)
        DarkLabel9.Margin = New Padding(6, 0, 6, 0)
        DarkLabel9.Name = "DarkLabel9"
        DarkLabel9.Size = New Size(67, 25)
        DarkLabel9.TabIndex = 27
        DarkLabel9.Text = "Health:"
        ' 
        ' cmbFaction
        ' 
        cmbFaction.DrawMode = DrawMode.OwnerDrawFixed
        cmbFaction.FormattingEnabled = True
        cmbFaction.Items.AddRange(New Object() {"None", "Good", "Bad"})
        cmbFaction.Location = New Point(432, 238)
        cmbFaction.Margin = New Padding(6, 5, 6, 5)
        cmbFaction.Name = "cmbFaction"
        cmbFaction.Size = New Size(210, 32)
        cmbFaction.TabIndex = 26
        ' 
        ' DarkLabel8
        ' 
        DarkLabel8.AutoSize = True
        DarkLabel8.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel8.Location = New Point(342, 245)
        DarkLabel8.Margin = New Padding(6, 0, 6, 0)
        DarkLabel8.Name = "DarkLabel8"
        DarkLabel8.Size = New Size(72, 25)
        DarkLabel8.TabIndex = 25
        DarkLabel8.Text = "Faction:"
        ' 
        ' cmbBehaviour
        ' 
        cmbBehaviour.DrawMode = DrawMode.OwnerDrawFixed
        cmbBehaviour.FormattingEnabled = True
        cmbBehaviour.Items.AddRange(New Object() {"Attack on sight", "Attack when attacked", "Friendly", "Shop keeper", "Guard", "Quest"})
        cmbBehaviour.Location = New Point(100, 238)
        cmbBehaviour.Margin = New Padding(6, 5, 6, 5)
        cmbBehaviour.Name = "cmbBehaviour"
        cmbBehaviour.Size = New Size(230, 32)
        cmbBehaviour.TabIndex = 24
        ' 
        ' DarkLabel5
        ' 
        DarkLabel5.AutoSize = True
        DarkLabel5.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel5.Location = New Point(10, 245)
        DarkLabel5.Margin = New Padding(6, 0, 6, 0)
        DarkLabel5.Name = "DarkLabel5"
        DarkLabel5.Size = New Size(84, 25)
        DarkLabel5.TabIndex = 23
        DarkLabel5.Text = "Behavior:"
        ' 
        ' cmbAnimation
        ' 
        cmbAnimation.DrawMode = DrawMode.OwnerDrawFixed
        cmbAnimation.FormattingEnabled = True
        cmbAnimation.Location = New Point(120, 188)
        cmbAnimation.Margin = New Padding(6, 5, 6, 5)
        cmbAnimation.Name = "cmbAnimation"
        cmbAnimation.Size = New Size(177, 32)
        cmbAnimation.TabIndex = 21
        ' 
        ' DarkLabel7
        ' 
        DarkLabel7.AutoSize = True
        DarkLabel7.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel7.Location = New Point(10, 191)
        DarkLabel7.Margin = New Padding(6, 0, 6, 0)
        DarkLabel7.Name = "DarkLabel7"
        DarkLabel7.Size = New Size(98, 25)
        DarkLabel7.TabIndex = 20
        DarkLabel7.Text = "Animation:"
        ' 
        ' DarkLabel4
        ' 
        DarkLabel4.AutoSize = True
        DarkLabel4.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel4.Location = New Point(10, 141)
        DarkLabel4.Margin = New Padding(6, 0, 6, 0)
        DarkLabel4.Name = "DarkLabel4"
        DarkLabel4.Size = New Size(66, 25)
        DarkLabel4.TabIndex = 15
        DarkLabel4.Text = "Range:"
        ' 
        ' nudRange
        ' 
        nudRange.Location = New Point(100, 137)
        nudRange.Margin = New Padding(6, 5, 6, 5)
        nudRange.Name = "nudRange"
        nudRange.Size = New Size(180, 31)
        nudRange.TabIndex = 14
        ' 
        ' nudSprite
        ' 
        nudSprite.Location = New Point(362, 137)
        nudSprite.Margin = New Padding(6, 5, 6, 5)
        nudSprite.Name = "nudSprite"
        nudSprite.Size = New Size(160, 31)
        nudSprite.TabIndex = 13
        ' 
        ' DarkLabel3
        ' 
        DarkLabel3.AutoSize = True
        DarkLabel3.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel3.Location = New Point(290, 141)
        DarkLabel3.Margin = New Padding(6, 0, 6, 0)
        DarkLabel3.Name = "DarkLabel3"
        DarkLabel3.Size = New Size(62, 25)
        DarkLabel3.TabIndex = 12
        DarkLabel3.Text = "Sprite:"
        ' 
        ' txtAttackSay
        ' 
        txtAttackSay.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtAttackSay.BorderStyle = BorderStyle.FixedSingle
        txtAttackSay.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtAttackSay.Location = New Point(100, 87)
        txtAttackSay.Margin = New Padding(6, 5, 6, 5)
        txtAttackSay.Name = "txtAttackSay"
        txtAttackSay.Size = New Size(420, 31)
        txtAttackSay.TabIndex = 11
        ' 
        ' DarkLabel2
        ' 
        DarkLabel2.AutoSize = True
        DarkLabel2.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel2.Location = New Point(10, 91)
        DarkLabel2.Margin = New Padding(6, 0, 6, 0)
        DarkLabel2.Name = "DarkLabel2"
        DarkLabel2.Size = New Size(79, 25)
        DarkLabel2.TabIndex = 10
        DarkLabel2.Text = "SayMsg:"
        ' 
        ' picSprite
        ' 
        picSprite.BackColor = Color.Black
        picSprite.BackgroundImageLayout = ImageLayout.None
        picSprite.Location = New Point(532, 37)
        picSprite.Margin = New Padding(6, 5, 6, 5)
        picSprite.Name = "picSprite"
        picSprite.Size = New Size(46, 53)
        picSprite.TabIndex = 9
        picSprite.TabStop = False
        ' 
        ' txtName
        ' 
        txtName.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtName.BorderStyle = BorderStyle.FixedSingle
        txtName.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtName.Location = New Point(100, 37)
        txtName.Margin = New Padding(6, 5, 6, 5)
        txtName.Name = "txtName"
        txtName.Size = New Size(420, 31)
        txtName.TabIndex = 1
        ' 
        ' DarkLabel1
        ' 
        DarkLabel1.AutoSize = True
        DarkLabel1.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel1.Location = New Point(10, 41)
        DarkLabel1.Margin = New Padding(6, 0, 6, 0)
        DarkLabel1.Name = "DarkLabel1"
        DarkLabel1.Size = New Size(63, 25)
        DarkLabel1.TabIndex = 0
        DarkLabel1.Text = "Name:"
        ' 
        ' DarkGroupBox3
        ' 
        DarkGroupBox3.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox3.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox3.Controls.Add(cmbSkill6)
        DarkGroupBox3.Controls.Add(DarkLabel17)
        DarkGroupBox3.Controls.Add(cmbSkill5)
        DarkGroupBox3.Controls.Add(DarkLabel18)
        DarkGroupBox3.Controls.Add(cmbSkill4)
        DarkGroupBox3.Controls.Add(DarkLabel19)
        DarkGroupBox3.Controls.Add(cmbSkill3)
        DarkGroupBox3.Controls.Add(DarkLabel16)
        DarkGroupBox3.Controls.Add(cmbSkill2)
        DarkGroupBox3.Controls.Add(DarkLabel15)
        DarkGroupBox3.Controls.Add(cmbSkill1)
        DarkGroupBox3.Controls.Add(DarkLabel14)
        DarkGroupBox3.ForeColor = Color.Gainsboro
        DarkGroupBox3.Location = New Point(393, 459)
        DarkGroupBox3.Margin = New Padding(6, 5, 6, 5)
        DarkGroupBox3.Name = "DarkGroupBox3"
        DarkGroupBox3.Padding = New Padding(6, 5, 6, 5)
        DarkGroupBox3.Size = New Size(657, 137)
        DarkGroupBox3.TabIndex = 2
        DarkGroupBox3.TabStop = False
        DarkGroupBox3.Text = "Skills"
        ' 
        ' cmbSkill6
        ' 
        cmbSkill6.DrawMode = DrawMode.OwnerDrawFixed
        cmbSkill6.FormattingEnabled = True
        cmbSkill6.Location = New Point(474, 77)
        cmbSkill6.Margin = New Padding(6, 5, 6, 5)
        cmbSkill6.Name = "cmbSkill6"
        cmbSkill6.Size = New Size(172, 32)
        cmbSkill6.TabIndex = 11
        ' 
        ' DarkLabel17
        ' 
        DarkLabel17.AutoSize = True
        DarkLabel17.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel17.Location = New Point(443, 84)
        DarkLabel17.Margin = New Padding(6, 0, 6, 0)
        DarkLabel17.Name = "DarkLabel17"
        DarkLabel17.Size = New Size(22, 25)
        DarkLabel17.TabIndex = 10
        DarkLabel17.Text = "6"
        ' 
        ' cmbSkill5
        ' 
        cmbSkill5.DrawMode = DrawMode.OwnerDrawFixed
        cmbSkill5.FormattingEnabled = True
        cmbSkill5.Location = New Point(258, 77)
        cmbSkill5.Margin = New Padding(6, 5, 6, 5)
        cmbSkill5.Name = "cmbSkill5"
        cmbSkill5.Size = New Size(172, 32)
        cmbSkill5.TabIndex = 9
        ' 
        ' DarkLabel18
        ' 
        DarkLabel18.AutoSize = True
        DarkLabel18.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel18.Location = New Point(227, 84)
        DarkLabel18.Margin = New Padding(6, 0, 6, 0)
        DarkLabel18.Name = "DarkLabel18"
        DarkLabel18.Size = New Size(22, 25)
        DarkLabel18.TabIndex = 8
        DarkLabel18.Text = "5"
        ' 
        ' cmbSkill4
        ' 
        cmbSkill4.DrawMode = DrawMode.OwnerDrawFixed
        cmbSkill4.FormattingEnabled = True
        cmbSkill4.Location = New Point(42, 77)
        cmbSkill4.Margin = New Padding(6, 5, 6, 5)
        cmbSkill4.Name = "cmbSkill4"
        cmbSkill4.Size = New Size(172, 32)
        cmbSkill4.TabIndex = 7
        ' 
        ' DarkLabel19
        ' 
        DarkLabel19.AutoSize = True
        DarkLabel19.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel19.Location = New Point(10, 84)
        DarkLabel19.Margin = New Padding(6, 0, 6, 0)
        DarkLabel19.Name = "DarkLabel19"
        DarkLabel19.Size = New Size(22, 25)
        DarkLabel19.TabIndex = 6
        DarkLabel19.Text = "4"
        ' 
        ' cmbSkill3
        ' 
        cmbSkill3.DrawMode = DrawMode.OwnerDrawFixed
        cmbSkill3.FormattingEnabled = True
        cmbSkill3.Location = New Point(474, 25)
        cmbSkill3.Margin = New Padding(6, 5, 6, 5)
        cmbSkill3.Name = "cmbSkill3"
        cmbSkill3.Size = New Size(172, 32)
        cmbSkill3.TabIndex = 5
        ' 
        ' DarkLabel16
        ' 
        DarkLabel16.AutoSize = True
        DarkLabel16.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel16.Location = New Point(443, 30)
        DarkLabel16.Margin = New Padding(6, 0, 6, 0)
        DarkLabel16.Name = "DarkLabel16"
        DarkLabel16.Size = New Size(22, 25)
        DarkLabel16.TabIndex = 4
        DarkLabel16.Text = "3"
        ' 
        ' cmbSkill2
        ' 
        cmbSkill2.DrawMode = DrawMode.OwnerDrawFixed
        cmbSkill2.FormattingEnabled = True
        cmbSkill2.Location = New Point(258, 25)
        cmbSkill2.Margin = New Padding(6, 5, 6, 5)
        cmbSkill2.Name = "cmbSkill2"
        cmbSkill2.Size = New Size(172, 32)
        cmbSkill2.TabIndex = 3
        ' 
        ' DarkLabel15
        ' 
        DarkLabel15.AutoSize = True
        DarkLabel15.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel15.Location = New Point(227, 30)
        DarkLabel15.Margin = New Padding(6, 0, 6, 0)
        DarkLabel15.Name = "DarkLabel15"
        DarkLabel15.Size = New Size(22, 25)
        DarkLabel15.TabIndex = 2
        DarkLabel15.Text = "2"
        ' 
        ' cmbSkill1
        ' 
        cmbSkill1.DrawMode = DrawMode.OwnerDrawFixed
        cmbSkill1.FormattingEnabled = True
        cmbSkill1.Location = New Point(42, 25)
        cmbSkill1.Margin = New Padding(6, 5, 6, 5)
        cmbSkill1.Name = "cmbSkill1"
        cmbSkill1.Size = New Size(172, 32)
        cmbSkill1.TabIndex = 1
        ' 
        ' DarkLabel14
        ' 
        DarkLabel14.AutoSize = True
        DarkLabel14.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel14.Location = New Point(10, 30)
        DarkLabel14.Margin = New Padding(6, 0, 6, 0)
        DarkLabel14.Name = "DarkLabel14"
        DarkLabel14.Size = New Size(22, 25)
        DarkLabel14.TabIndex = 0
        DarkLabel14.Text = "1"
        ' 
        ' DarkGroupBox4
        ' 
        DarkGroupBox4.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox4.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox4.Controls.Add(nudAmount)
        DarkGroupBox4.Controls.Add(DarkLabel29)
        DarkGroupBox4.Controls.Add(cmbItem)
        DarkGroupBox4.Controls.Add(DarkLabel28)
        DarkGroupBox4.Controls.Add(cmbDropSlot)
        DarkGroupBox4.Controls.Add(nudChance)
        DarkGroupBox4.Controls.Add(DarkLabel27)
        DarkGroupBox4.Controls.Add(DarkLabel26)
        DarkGroupBox4.ForeColor = Color.Gainsboro
        DarkGroupBox4.Location = New Point(393, 770)
        DarkGroupBox4.Margin = New Padding(6, 5, 6, 5)
        DarkGroupBox4.Name = "DarkGroupBox4"
        DarkGroupBox4.Padding = New Padding(6, 5, 6, 5)
        DarkGroupBox4.Size = New Size(657, 148)
        DarkGroupBox4.TabIndex = 3
        DarkGroupBox4.TabStop = False
        DarkGroupBox4.Text = "Drop Items"
        ' 
        ' nudAmount
        ' 
        nudAmount.Location = New Point(447, 84)
        nudAmount.Margin = New Padding(6, 5, 6, 5)
        nudAmount.Name = "nudAmount"
        nudAmount.Size = New Size(200, 31)
        nudAmount.TabIndex = 7
        ' 
        ' DarkLabel29
        ' 
        DarkLabel29.AutoSize = True
        DarkLabel29.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel29.Location = New Point(342, 88)
        DarkLabel29.Margin = New Padding(6, 0, 6, 0)
        DarkLabel29.Name = "DarkLabel29"
        DarkLabel29.Size = New Size(81, 25)
        DarkLabel29.TabIndex = 6
        DarkLabel29.Text = "Amount:"
        ' 
        ' cmbItem
        ' 
        cmbItem.DrawMode = DrawMode.OwnerDrawFixed
        cmbItem.FormattingEnabled = True
        cmbItem.Location = New Point(110, 84)
        cmbItem.Margin = New Padding(6, 5, 6, 5)
        cmbItem.Name = "cmbItem"
        cmbItem.Size = New Size(198, 32)
        cmbItem.TabIndex = 5
        ' 
        ' DarkLabel28
        ' 
        DarkLabel28.AutoSize = True
        DarkLabel28.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel28.Location = New Point(10, 88)
        DarkLabel28.Margin = New Padding(6, 0, 6, 0)
        DarkLabel28.Name = "DarkLabel28"
        DarkLabel28.Size = New Size(52, 25)
        DarkLabel28.TabIndex = 4
        DarkLabel28.Text = "Item:"
        ' 
        ' cmbDropSlot
        ' 
        cmbDropSlot.DrawMode = DrawMode.OwnerDrawFixed
        cmbDropSlot.FormattingEnabled = True
        cmbDropSlot.Items.AddRange(New Object() {"Slot 1", "Slot 2", "Slot 3", "Slot 4", "Slot 5"})
        cmbDropSlot.Location = New Point(110, 25)
        cmbDropSlot.Margin = New Padding(6, 5, 6, 5)
        cmbDropSlot.Name = "cmbDropSlot"
        cmbDropSlot.Size = New Size(198, 32)
        cmbDropSlot.TabIndex = 3
        ' 
        ' nudChance
        ' 
        nudChance.Location = New Point(490, 27)
        nudChance.Margin = New Padding(6, 5, 6, 5)
        nudChance.Name = "nudChance"
        nudChance.Size = New Size(157, 31)
        nudChance.TabIndex = 2
        ' 
        ' DarkLabel27
        ' 
        DarkLabel27.AutoSize = True
        DarkLabel27.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel27.Location = New Point(342, 30)
        DarkLabel27.Margin = New Padding(6, 0, 6, 0)
        DarkLabel27.Name = "DarkLabel27"
        DarkLabel27.Size = New Size(138, 25)
        DarkLabel27.TabIndex = 1
        DarkLabel27.Text = "Chance 1 out of"
        ' 
        ' DarkLabel26
        ' 
        DarkLabel26.AutoSize = True
        DarkLabel26.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel26.Location = New Point(10, 30)
        DarkLabel26.Margin = New Padding(6, 0, 6, 0)
        DarkLabel26.Name = "DarkLabel26"
        DarkLabel26.Size = New Size(93, 25)
        DarkLabel26.TabIndex = 0
        DarkLabel26.Text = "Drop Slot:"
        ' 
        ' DarkGroupBox5
        ' 
        DarkGroupBox5.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox5.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox5.Controls.Add(nudSpirit)
        DarkGroupBox5.Controls.Add(DarkLabel23)
        DarkGroupBox5.Controls.Add(nudIntelligence)
        DarkGroupBox5.Controls.Add(DarkLabel24)
        DarkGroupBox5.Controls.Add(nudLuck)
        DarkGroupBox5.Controls.Add(DarkLabel25)
        DarkGroupBox5.Controls.Add(nudVitality)
        DarkGroupBox5.Controls.Add(DarkLabel22)
        DarkGroupBox5.Controls.Add(nudStrength)
        DarkGroupBox5.Controls.Add(DarkLabel20)
        DarkGroupBox5.ForeColor = Color.Gainsboro
        DarkGroupBox5.Location = New Point(393, 609)
        DarkGroupBox5.Margin = New Padding(6, 5, 6, 5)
        DarkGroupBox5.Name = "DarkGroupBox5"
        DarkGroupBox5.Padding = New Padding(6, 5, 6, 5)
        DarkGroupBox5.Size = New Size(657, 150)
        DarkGroupBox5.TabIndex = 4
        DarkGroupBox5.TabStop = False
        DarkGroupBox5.Text = "Stats"
        ' 
        ' nudSpirit
        ' 
        nudSpirit.Location = New Point(537, 41)
        nudSpirit.Margin = New Padding(6, 5, 6, 5)
        nudSpirit.Name = "nudSpirit"
        nudSpirit.Size = New Size(106, 31)
        nudSpirit.TabIndex = 11
        ' 
        ' DarkLabel23
        ' 
        DarkLabel23.AutoSize = True
        DarkLabel23.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel23.Location = New Point(447, 45)
        DarkLabel23.Margin = New Padding(6, 0, 6, 0)
        DarkLabel23.Name = "DarkLabel23"
        DarkLabel23.Size = New Size(57, 25)
        DarkLabel23.TabIndex = 10
        DarkLabel23.Text = "Spirit:"
        ' 
        ' nudIntelligence
        ' 
        nudIntelligence.Location = New Point(328, 87)
        nudIntelligence.Margin = New Padding(6, 5, 6, 5)
        nudIntelligence.Name = "nudIntelligence"
        nudIntelligence.Size = New Size(106, 31)
        nudIntelligence.TabIndex = 9
        ' 
        ' DarkLabel24
        ' 
        DarkLabel24.AutoSize = True
        DarkLabel24.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel24.Location = New Point(214, 91)
        DarkLabel24.Margin = New Padding(6, 0, 6, 0)
        DarkLabel24.Name = "DarkLabel24"
        DarkLabel24.Size = New Size(105, 25)
        DarkLabel24.TabIndex = 8
        DarkLabel24.Text = "Intelligence:"
        ' 
        ' nudLuck
        ' 
        nudLuck.Location = New Point(100, 87)
        nudLuck.Margin = New Padding(6, 5, 6, 5)
        nudLuck.Name = "nudLuck"
        nudLuck.Size = New Size(106, 31)
        nudLuck.TabIndex = 7
        ' 
        ' DarkLabel25
        ' 
        DarkLabel25.AutoSize = True
        DarkLabel25.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel25.Location = New Point(10, 91)
        DarkLabel25.Margin = New Padding(6, 0, 6, 0)
        DarkLabel25.Name = "DarkLabel25"
        DarkLabel25.Size = New Size(51, 25)
        DarkLabel25.TabIndex = 6
        DarkLabel25.Text = "Luck:"
        ' 
        ' nudVitality
        ' 
        nudVitality.Location = New Point(329, 39)
        nudVitality.Margin = New Padding(6, 5, 6, 5)
        nudVitality.Name = "nudVitality"
        nudVitality.Size = New Size(106, 31)
        nudVitality.TabIndex = 5
        ' 
        ' DarkLabel22
        ' 
        DarkLabel22.AutoSize = True
        DarkLabel22.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel22.Location = New Point(239, 43)
        DarkLabel22.Margin = New Padding(6, 0, 6, 0)
        DarkLabel22.Name = "DarkLabel22"
        DarkLabel22.Size = New Size(69, 25)
        DarkLabel22.TabIndex = 4
        DarkLabel22.Text = "Vitality:"
        ' 
        ' nudStrength
        ' 
        nudStrength.Location = New Point(100, 37)
        nudStrength.Margin = New Padding(6, 5, 6, 5)
        nudStrength.Name = "nudStrength"
        nudStrength.Size = New Size(106, 31)
        nudStrength.TabIndex = 1
        ' 
        ' DarkLabel20
        ' 
        DarkLabel20.AutoSize = True
        DarkLabel20.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel20.Location = New Point(10, 41)
        DarkLabel20.Margin = New Padding(6, 0, 6, 0)
        DarkLabel20.Name = "DarkLabel20"
        DarkLabel20.Size = New Size(83, 25)
        DarkLabel20.TabIndex = 0
        DarkLabel20.Text = "Strength:"
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(17, 874)
        btnCancel.Margin = New Padding(6, 5, 6, 5)
        btnCancel.Name = "btnCancel"
        btnCancel.Padding = New Padding(8, 9, 8, 9)
        btnCancel.Size = New Size(364, 45)
        btnCancel.TabIndex = 5
        btnCancel.Text = "Cancel"
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(17, 819)
        btnDelete.Margin = New Padding(6, 5, 6, 5)
        btnDelete.Name = "btnDelete"
        btnDelete.Padding = New Padding(8, 9, 8, 9)
        btnDelete.Size = New Size(364, 45)
        btnDelete.TabIndex = 6
        btnDelete.Text = "Delete"
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(17, 764)
        btnSave.Margin = New Padding(6, 5, 6, 5)
        btnSave.Name = "btnSave"
        btnSave.Padding = New Padding(8, 9, 8, 9)
        btnSave.Size = New Size(364, 45)
        btnSave.TabIndex = 7
        btnSave.Text = "Save"
        ' 
        ' frmEditor_NPC
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        ClientSize = New Size(1059, 929)
        Controls.Add(btnSave)
        Controls.Add(btnDelete)
        Controls.Add(btnCancel)
        Controls.Add(DarkGroupBox5)
        Controls.Add(DarkGroupBox4)
        Controls.Add(DarkGroupBox3)
        Controls.Add(DarkGroupBox2)
        Controls.Add(DarkGroupBox1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Margin = New Padding(6, 5, 6, 5)
        Name = "frmEditor_NPC"
        Text = "NPC Editor"
        DarkGroupBox1.ResumeLayout(False)
        DarkGroupBox2.ResumeLayout(False)
        DarkGroupBox2.PerformLayout()
        CType(nudSpawnSecs, ComponentModel.ISupportInitialize).EndInit()
        CType(nudDamage, ComponentModel.ISupportInitialize).EndInit()
        CType(nudLevel, ComponentModel.ISupportInitialize).EndInit()
        CType(nudExp, ComponentModel.ISupportInitialize).EndInit()
        CType(nudHp, ComponentModel.ISupportInitialize).EndInit()
        CType(nudRange, ComponentModel.ISupportInitialize).EndInit()
        CType(nudSprite, ComponentModel.ISupportInitialize).EndInit()
        CType(picSprite, ComponentModel.ISupportInitialize).EndInit()
        DarkGroupBox3.ResumeLayout(False)
        DarkGroupBox3.PerformLayout()
        DarkGroupBox4.ResumeLayout(False)
        DarkGroupBox4.PerformLayout()
        CType(nudAmount, ComponentModel.ISupportInitialize).EndInit()
        CType(nudChance, ComponentModel.ISupportInitialize).EndInit()
        DarkGroupBox5.ResumeLayout(False)
        DarkGroupBox5.PerformLayout()
        CType(nudSpirit, ComponentModel.ISupportInitialize).EndInit()
        CType(nudIntelligence, ComponentModel.ISupportInitialize).EndInit()
        CType(nudLuck, ComponentModel.ISupportInitialize).EndInit()
        CType(nudVitality, ComponentModel.ISupportInitialize).EndInit()
        CType(nudStrength, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents DarkGroupBox1 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents lstIndex As System.Windows.Forms.ListBox
    Friend WithEvents DarkGroupBox2 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents txtName As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel1 As DarkUI.Controls.DarkLabel
    Friend WithEvents picSprite As System.Windows.Forms.PictureBox
    Friend WithEvents txtAttackSay As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel2 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudSprite As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel3 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel4 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudRange As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents cmbAnimation As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel7 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbFaction As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel8 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbBehaviour As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel5 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudHp As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel9 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudExp As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel10 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudDamage As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel12 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudLevel As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel11 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudSpawnSecs As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel13 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkGroupBox3 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents DarkGroupBox4 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents DarkGroupBox5 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents cmbSkill1 As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel14 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbSkill6 As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel17 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbSkill5 As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel18 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbSkill4 As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel19 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbSkill3 As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel16 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbSkill2 As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel15 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudStrength As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel20 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudSpirit As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel23 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudIntelligence As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel24 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudLuck As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel25 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudVitality As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel22 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel26 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbDropSlot As DarkUI.Controls.DarkComboBox
    Friend WithEvents nudChance As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel27 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudAmount As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel29 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbItem As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel28 As DarkUI.Controls.DarkLabel
    Friend WithEvents btnCancel As DarkUI.Controls.DarkButton
    Friend WithEvents btnDelete As DarkUI.Controls.DarkButton
    Friend WithEvents btnSave As DarkUI.Controls.DarkButton
    Friend WithEvents cmbSpawnPeriod As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel30 As DarkUI.Controls.DarkLabel
End Class
