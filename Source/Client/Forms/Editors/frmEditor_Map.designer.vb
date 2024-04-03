<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditor_Map
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditor_Map))
        btnClearAttribute = New Button()
        optTrap = New RadioButton()
        optHeal = New RadioButton()
        optBank = New RadioButton()
        optShop = New RadioButton()
        optNPCSpawn = New RadioButton()
        optResource = New RadioButton()
        optNPCAvoid = New RadioButton()
        optItem = New RadioButton()
        optWarp = New RadioButton()
        optBlocked = New RadioButton()
        pnlBack = New Panel()
        picBackSelect = New PictureBox()
        Label1 = New Label()
        pnlAttributes = New Panel()
        fraMapLight = New GroupBox()
        lblRadius = New Label()
        scrlLight = New HScrollBar()
        chkShadow = New CheckBox()
        chkFlicker = New CheckBox()
        btnLight = New Button()
        fraAnimation = New GroupBox()
        cmbAnimation = New ComboBox()
        brnAnimation = New Button()
        fraMapWarp = New GroupBox()
        btnMapWarp = New Button()
        scrlMapWarpY = New HScrollBar()
        scrlMapWarpX = New HScrollBar()
        scrlMapWarpMap = New HScrollBar()
        lblMapWarpY = New Label()
        lblMapWarpX = New Label()
        lblMapWarpMap = New Label()
        fraNpcSpawn = New GroupBox()
        lstNpc = New ComboBox()
        btnNpcSpawn = New Button()
        scrlNpcDir = New HScrollBar()
        lblNpcDir = New Label()
        fraHeal = New GroupBox()
        scrlHeal = New HScrollBar()
        lblHeal = New Label()
        cmbHeal = New ComboBox()
        btnHeal = New Button()
        fraShop = New GroupBox()
        cmbShop = New ComboBox()
        btnShop = New Button()
        fraResource = New GroupBox()
        btnResourceOk = New Button()
        scrlResource = New HScrollBar()
        lblResource = New Label()
        fraMapItem = New GroupBox()
        picMapItem = New PictureBox()
        btnMapItem = New Button()
        scrlMapItemValue = New HScrollBar()
        scrlMapItem = New HScrollBar()
        lblMapItem = New Label()
        fraTrap = New GroupBox()
        btnTrap = New Button()
        scrlTrap = New HScrollBar()
        lblTrap = New Label()
        ToolStrip = New ToolStrip()
        tsbSave = New ToolStripButton()
        tsbDiscard = New ToolStripButton()
        ToolStripSeparator1 = New ToolStripSeparator()
        tsbMapGrid = New ToolStripButton()
        tsbOpacity = New ToolStripButton()
        tsbLight = New ToolStripButton()
        ToolStripSeparator2 = New ToolStripSeparator()
        tsbFill = New ToolStripButton()
        tsbClear = New ToolStripButton()
        tsbEyeDropper = New ToolStripButton()
        tsbCopyMap = New ToolStripButton()
        tsbDeleteMap = New ToolStripButton()
        tsbUndo = New ToolStripButton()
        tsbRedo = New ToolStripButton()
        tsbScreenshot = New ToolStripButton()
        tabpages = New TabControl()
        tpTiles = New TabPage()
        cmbAutoTile = New ComboBox()
        Label11 = New Label()
        Label10 = New Label()
        cmbLayers = New ComboBox()
        Label9 = New Label()
        cmbTileSets = New ComboBox()
        tpAttributes = New TabPage()
        optNoXing = New RadioButton()
        optInfo = New RadioButton()
        Label23 = New Label()
        cmbAttribute = New ComboBox()
        optAnimation = New RadioButton()
        optLight = New RadioButton()
        tpNpcs = New TabPage()
        fraNpcs = New GroupBox()
        Label18 = New Label()
        Label17 = New Label()
        cmbNpcList = New ComboBox()
        lstMapNpc = New ListBox()
        ComboBox23 = New ComboBox()
        tpSettings = New TabPage()
        fraMapSettings = New GroupBox()
        Label22 = New Label()
        lstShop = New ComboBox()
        Label8 = New Label()
        lstMoral = New ComboBox()
        fraMapLinks = New GroupBox()
        txtDown = New TextBox()
        txtLeft = New TextBox()
        lblMap = New Label()
        txtRight = New TextBox()
        txtUp = New TextBox()
        fraBootSettings = New GroupBox()
        chkIndoors = New CheckBox()
        chkNoMapRespawn = New CheckBox()
        txtBootMap = New TextBox()
        Label5 = New Label()
        txtBootY = New TextBox()
        Label3 = New Label()
        txtBootX = New TextBox()
        Label4 = New Label()
        fraMaxSizes = New GroupBox()
        txtMaxY = New TextBox()
        Label2 = New Label()
        txtMaxX = New TextBox()
        Label7 = New Label()
        GroupBox2 = New GroupBox()
        btnPreview = New Button()
        lstMusic = New ListBox()
        txtName = New TextBox()
        Label6 = New Label()
        tpDirBlock = New TabPage()
        Label12 = New Label()
        tpEvents = New TabPage()
        lblPasteMode = New Label()
        lblCopyMode = New Label()
        btnPasteEvent = New Button()
        Label16 = New Label()
        btnCopyEvent = New Button()
        Label15 = New Label()
        Label13 = New Label()
        tpEffects = New TabPage()
        GroupBox6 = New GroupBox()
        lblMapBrightness = New Label()
        scrlMapBrightness = New HScrollBar()
        GroupBox5 = New GroupBox()
        Label20 = New Label()
        cmbParallax = New ComboBox()
        GroupBox4 = New GroupBox()
        Label19 = New Label()
        cmbPanorama = New ComboBox()
        GroupBox3 = New GroupBox()
        chkTint = New CheckBox()
        lblMapAlpha = New Label()
        lblMapBlue = New Label()
        lblMapGreen = New Label()
        lblMapRed = New Label()
        scrlMapAlpha = New HScrollBar()
        scrlMapBlue = New HScrollBar()
        scrlMapGreen = New HScrollBar()
        scrlMapRed = New HScrollBar()
        GroupBox1 = New GroupBox()
        scrlFogOpacity = New HScrollBar()
        lblFogOpacity = New Label()
        scrlFogSpeed = New HScrollBar()
        lblFogSpeed = New Label()
        scrlIntensity = New HScrollBar()
        lblIntensity = New Label()
        scrlFog = New HScrollBar()
        lblFogIndex = New Label()
        Label14 = New Label()
        cmbWeather = New ComboBox()
        pnlBack.SuspendLayout()
        CType(picBackSelect, ComponentModel.ISupportInitialize).BeginInit()
        pnlAttributes.SuspendLayout()
        fraMapLight.SuspendLayout()
        fraAnimation.SuspendLayout()
        fraMapWarp.SuspendLayout()
        fraNpcSpawn.SuspendLayout()
        fraHeal.SuspendLayout()
        fraShop.SuspendLayout()
        fraResource.SuspendLayout()
        fraMapItem.SuspendLayout()
        CType(picMapItem, ComponentModel.ISupportInitialize).BeginInit()
        fraTrap.SuspendLayout()
        ToolStrip.SuspendLayout()
        tabpages.SuspendLayout()
        tpTiles.SuspendLayout()
        tpAttributes.SuspendLayout()
        tpNpcs.SuspendLayout()
        fraNpcs.SuspendLayout()
        tpSettings.SuspendLayout()
        fraMapSettings.SuspendLayout()
        fraMapLinks.SuspendLayout()
        fraBootSettings.SuspendLayout()
        fraMaxSizes.SuspendLayout()
        GroupBox2.SuspendLayout()
        tpDirBlock.SuspendLayout()
        tpEvents.SuspendLayout()
        tpEffects.SuspendLayout()
        GroupBox6.SuspendLayout()
        GroupBox5.SuspendLayout()
        GroupBox4.SuspendLayout()
        GroupBox3.SuspendLayout()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnClearAttribute
        ' 
        btnClearAttribute.Location = New Point(492, 948)
        btnClearAttribute.Margin = New Padding(6, 5, 6, 5)
        btnClearAttribute.Name = "btnClearAttribute"
        btnClearAttribute.Size = New Size(274, 48)
        btnClearAttribute.TabIndex = 14
        btnClearAttribute.Text = "Clear All Attributes"
        btnClearAttribute.UseVisualStyleBackColor = True
        ' 
        ' optTrap
        ' 
        optTrap.AutoSize = True
        optTrap.Location = New Point(533, 97)
        optTrap.Margin = New Padding(6, 5, 6, 5)
        optTrap.Name = "optTrap"
        optTrap.Size = New Size(70, 29)
        optTrap.TabIndex = 12
        optTrap.Text = "Trap"
        optTrap.UseVisualStyleBackColor = True
        ' 
        ' optHeal
        ' 
        optHeal.AutoSize = True
        optHeal.Location = New Point(394, 97)
        optHeal.Margin = New Padding(6, 5, 6, 5)
        optHeal.Name = "optHeal"
        optHeal.Size = New Size(72, 29)
        optHeal.TabIndex = 11
        optHeal.Text = "Heal"
        optHeal.UseVisualStyleBackColor = True
        ' 
        ' optBank
        ' 
        optBank.AutoSize = True
        optBank.Location = New Point(169, 97)
        optBank.Margin = New Padding(6, 5, 6, 5)
        optBank.Name = "optBank"
        optBank.Size = New Size(75, 29)
        optBank.TabIndex = 10
        optBank.Text = "Bank"
        optBank.UseVisualStyleBackColor = True
        ' 
        ' optShop
        ' 
        optShop.AutoSize = True
        optShop.Location = New Point(681, 27)
        optShop.Margin = New Padding(6, 5, 6, 5)
        optShop.Name = "optShop"
        optShop.Size = New Size(79, 29)
        optShop.TabIndex = 9
        optShop.Text = "Shop"
        optShop.UseVisualStyleBackColor = True
        ' 
        ' optNPCSpawn
        ' 
        optNPCSpawn.AutoSize = True
        optNPCSpawn.Location = New Point(533, 27)
        optNPCSpawn.Margin = New Padding(6, 5, 6, 5)
        optNPCSpawn.Name = "optNPCSpawn"
        optNPCSpawn.Size = New Size(129, 29)
        optNPCSpawn.TabIndex = 8
        optNPCSpawn.Text = "NPC Spawn"
        optNPCSpawn.UseVisualStyleBackColor = True
        ' 
        ' optResource
        ' 
        optResource.AutoSize = True
        optResource.Location = New Point(17, 97)
        optResource.Margin = New Padding(6, 5, 6, 5)
        optResource.Name = "optResource"
        optResource.Size = New Size(108, 29)
        optResource.TabIndex = 6
        optResource.Text = "Resource"
        optResource.UseVisualStyleBackColor = True
        ' 
        ' optNPCAvoid
        ' 
        optNPCAvoid.AutoSize = True
        optNPCAvoid.Location = New Point(394, 27)
        optNPCAvoid.Margin = New Padding(6, 5, 6, 5)
        optNPCAvoid.Name = "optNPCAvoid"
        optNPCAvoid.Size = New Size(123, 29)
        optNPCAvoid.TabIndex = 3
        optNPCAvoid.Text = "NPC Avoid"
        optNPCAvoid.UseVisualStyleBackColor = True
        ' 
        ' optItem
        ' 
        optItem.AutoSize = True
        optItem.Location = New Point(289, 27)
        optItem.Margin = New Padding(6, 5, 6, 5)
        optItem.Name = "optItem"
        optItem.Size = New Size(73, 29)
        optItem.TabIndex = 2
        optItem.Text = "Item"
        optItem.UseVisualStyleBackColor = True
        ' 
        ' optWarp
        ' 
        optWarp.AutoSize = True
        optWarp.Location = New Point(169, 27)
        optWarp.Margin = New Padding(6, 5, 6, 5)
        optWarp.Name = "optWarp"
        optWarp.Size = New Size(79, 29)
        optWarp.TabIndex = 1
        optWarp.Text = "Warp"
        optWarp.UseVisualStyleBackColor = True
        ' 
        ' optBlocked
        ' 
        optBlocked.AutoSize = True
        optBlocked.Checked = True
        optBlocked.Location = New Point(17, 27)
        optBlocked.Margin = New Padding(6, 5, 6, 5)
        optBlocked.Name = "optBlocked"
        optBlocked.Size = New Size(99, 29)
        optBlocked.TabIndex = 0
        optBlocked.TabStop = True
        optBlocked.Text = "Blocked"
        optBlocked.UseVisualStyleBackColor = True
        ' 
        ' pnlBack
        ' 
        pnlBack.Controls.Add(picBackSelect)
        pnlBack.Location = New Point(10, 15)
        pnlBack.Margin = New Padding(6, 5, 6, 5)
        pnlBack.Name = "pnlBack"
        pnlBack.Size = New Size(751, 887)
        pnlBack.TabIndex = 9
        ' 
        ' picBackSelect
        ' 
        picBackSelect.BackColor = Color.Black
        picBackSelect.Location = New Point(16, 5)
        picBackSelect.Margin = New Padding(6, 5, 6, 5)
        picBackSelect.Name = "picBackSelect"
        picBackSelect.Size = New Size(731, 853)
        picBackSelect.TabIndex = 22
        picBackSelect.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(11, 907)
        Label1.Margin = New Padding(6, 0, 6, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(291, 25)
        Label1.TabIndex = 11
        Label1.Text = "Drag Mouse to Select Multiple Tiles"
        ' 
        ' pnlAttributes
        ' 
        pnlAttributes.Controls.Add(fraMapLight)
        pnlAttributes.Controls.Add(fraAnimation)
        pnlAttributes.Controls.Add(fraMapWarp)
        pnlAttributes.Controls.Add(fraNpcSpawn)
        pnlAttributes.Controls.Add(fraHeal)
        pnlAttributes.Controls.Add(fraShop)
        pnlAttributes.Controls.Add(fraResource)
        pnlAttributes.Controls.Add(fraMapItem)
        pnlAttributes.Controls.Add(fraTrap)
        pnlAttributes.Location = New Point(793, 93)
        pnlAttributes.Margin = New Padding(6, 5, 6, 5)
        pnlAttributes.Name = "pnlAttributes"
        pnlAttributes.Size = New Size(837, 945)
        pnlAttributes.TabIndex = 12
        pnlAttributes.Visible = False
        ' 
        ' fraMapLight
        ' 
        fraMapLight.Controls.Add(lblRadius)
        fraMapLight.Controls.Add(scrlLight)
        fraMapLight.Controls.Add(chkShadow)
        fraMapLight.Controls.Add(chkFlicker)
        fraMapLight.Controls.Add(btnLight)
        fraMapLight.Location = New Point(563, 245)
        fraMapLight.Margin = New Padding(6, 5, 6, 5)
        fraMapLight.Name = "fraMapLight"
        fraMapLight.Padding = New Padding(6, 5, 6, 5)
        fraMapLight.Size = New Size(246, 230)
        fraMapLight.TabIndex = 19
        fraMapLight.TabStop = False
        fraMapLight.Text = "Light"
        fraMapLight.Visible = False
        ' 
        ' lblRadius
        ' 
        lblRadius.AutoSize = True
        lblRadius.Location = New Point(11, 27)
        lblRadius.Margin = New Padding(6, 0, 6, 0)
        lblRadius.Name = "lblRadius"
        lblRadius.Size = New Size(84, 25)
        lblRadius.TabIndex = 41
        lblRadius.Text = "Radius: 0"
        ' 
        ' scrlLight
        ' 
        scrlLight.Location = New Point(10, 52)
        scrlLight.Name = "scrlLight"
        scrlLight.Size = New Size(236, 17)
        scrlLight.TabIndex = 40
        ' 
        ' chkShadow
        ' 
        chkShadow.AutoSize = True
        chkShadow.Location = New Point(10, 122)
        chkShadow.Margin = New Padding(4, 5, 4, 5)
        chkShadow.Name = "chkShadow"
        chkShadow.Size = New Size(110, 29)
        chkShadow.TabIndex = 39
        chkShadow.Text = "Shadows"
        chkShadow.UseVisualStyleBackColor = True
        ' 
        ' chkFlicker
        ' 
        chkFlicker.AutoSize = True
        chkFlicker.Location = New Point(10, 85)
        chkFlicker.Margin = New Padding(4, 5, 4, 5)
        chkFlicker.Name = "chkFlicker"
        chkFlicker.Size = New Size(87, 29)
        chkFlicker.TabIndex = 38
        chkFlicker.Text = "Flicker"
        chkFlicker.UseVisualStyleBackColor = True
        ' 
        ' btnLight
        ' 
        btnLight.Location = New Point(49, 163)
        btnLight.Margin = New Padding(6, 5, 6, 5)
        btnLight.Name = "btnLight"
        btnLight.Size = New Size(150, 53)
        btnLight.TabIndex = 6
        btnLight.Text = "Accept"
        btnLight.UseVisualStyleBackColor = True
        ' 
        ' fraAnimation
        ' 
        fraAnimation.Controls.Add(cmbAnimation)
        fraAnimation.Controls.Add(brnAnimation)
        fraAnimation.Location = New Point(306, 485)
        fraAnimation.Margin = New Padding(6, 5, 6, 5)
        fraAnimation.Name = "fraAnimation"
        fraAnimation.Padding = New Padding(6, 5, 6, 5)
        fraAnimation.Size = New Size(290, 217)
        fraAnimation.TabIndex = 17
        fraAnimation.TabStop = False
        fraAnimation.Text = "Animation"
        fraAnimation.Visible = False
        ' 
        ' cmbAnimation
        ' 
        cmbAnimation.DropDownStyle = ComboBoxStyle.DropDownList
        cmbAnimation.FormattingEnabled = True
        cmbAnimation.Items.AddRange(New Object() {"Heal HP", "Heal MP"})
        cmbAnimation.Location = New Point(10, 37)
        cmbAnimation.Margin = New Padding(6, 5, 6, 5)
        cmbAnimation.Name = "cmbAnimation"
        cmbAnimation.Size = New Size(255, 33)
        cmbAnimation.TabIndex = 37
        ' 
        ' brnAnimation
        ' 
        brnAnimation.Location = New Point(61, 147)
        brnAnimation.Margin = New Padding(6, 5, 6, 5)
        brnAnimation.Name = "brnAnimation"
        brnAnimation.Size = New Size(150, 53)
        brnAnimation.TabIndex = 6
        brnAnimation.Text = "Accept"
        brnAnimation.UseVisualStyleBackColor = True
        ' 
        ' fraMapWarp
        ' 
        fraMapWarp.Controls.Add(btnMapWarp)
        fraMapWarp.Controls.Add(scrlMapWarpY)
        fraMapWarp.Controls.Add(scrlMapWarpX)
        fraMapWarp.Controls.Add(scrlMapWarpMap)
        fraMapWarp.Controls.Add(lblMapWarpY)
        fraMapWarp.Controls.Add(lblMapWarpX)
        fraMapWarp.Controls.Add(lblMapWarpMap)
        fraMapWarp.Location = New Point(14, 712)
        fraMapWarp.Margin = New Padding(6, 5, 6, 5)
        fraMapWarp.Name = "fraMapWarp"
        fraMapWarp.Padding = New Padding(6, 5, 6, 5)
        fraMapWarp.Size = New Size(420, 228)
        fraMapWarp.TabIndex = 0
        fraMapWarp.TabStop = False
        fraMapWarp.Text = "Map Warp"
        ' 
        ' btnMapWarp
        ' 
        btnMapWarp.Location = New Point(133, 170)
        btnMapWarp.Margin = New Padding(6, 5, 6, 5)
        btnMapWarp.Name = "btnMapWarp"
        btnMapWarp.Size = New Size(150, 53)
        btnMapWarp.TabIndex = 6
        btnMapWarp.Text = "Accept"
        btnMapWarp.UseVisualStyleBackColor = True
        ' 
        ' scrlMapWarpY
        ' 
        scrlMapWarpY.Location = New Point(103, 122)
        scrlMapWarpY.Name = "scrlMapWarpY"
        scrlMapWarpY.Size = New Size(269, 18)
        scrlMapWarpY.TabIndex = 5
        ' 
        ' scrlMapWarpX
        ' 
        scrlMapWarpX.Location = New Point(103, 78)
        scrlMapWarpX.Name = "scrlMapWarpX"
        scrlMapWarpX.Size = New Size(269, 18)
        scrlMapWarpX.TabIndex = 4
        ' 
        ' scrlMapWarpMap
        ' 
        scrlMapWarpMap.Location = New Point(103, 38)
        scrlMapWarpMap.Name = "scrlMapWarpMap"
        scrlMapWarpMap.Size = New Size(269, 18)
        scrlMapWarpMap.TabIndex = 3
        ' 
        ' lblMapWarpY
        ' 
        lblMapWarpY.AutoSize = True
        lblMapWarpY.Location = New Point(11, 128)
        lblMapWarpY.Margin = New Padding(6, 0, 6, 0)
        lblMapWarpY.Name = "lblMapWarpY"
        lblMapWarpY.Size = New Size(41, 25)
        lblMapWarpY.TabIndex = 2
        lblMapWarpY.Text = "Y: 1"
        ' 
        ' lblMapWarpX
        ' 
        lblMapWarpX.AutoSize = True
        lblMapWarpX.Location = New Point(11, 88)
        lblMapWarpX.Margin = New Padding(6, 0, 6, 0)
        lblMapWarpX.Name = "lblMapWarpX"
        lblMapWarpX.Size = New Size(42, 25)
        lblMapWarpX.TabIndex = 1
        lblMapWarpX.Text = "X: 1"
        ' 
        ' lblMapWarpMap
        ' 
        lblMapWarpMap.AutoSize = True
        lblMapWarpMap.Location = New Point(10, 48)
        lblMapWarpMap.Margin = New Padding(6, 0, 6, 0)
        lblMapWarpMap.Name = "lblMapWarpMap"
        lblMapWarpMap.Size = New Size(67, 25)
        lblMapWarpMap.TabIndex = 0
        lblMapWarpMap.Text = "Map: 1"
        ' 
        ' fraNpcSpawn
        ' 
        fraNpcSpawn.Controls.Add(lstNpc)
        fraNpcSpawn.Controls.Add(btnNpcSpawn)
        fraNpcSpawn.Controls.Add(scrlNpcDir)
        fraNpcSpawn.Controls.Add(lblNpcDir)
        fraNpcSpawn.Location = New Point(6, 12)
        fraNpcSpawn.Margin = New Padding(6, 5, 6, 5)
        fraNpcSpawn.Name = "fraNpcSpawn"
        fraNpcSpawn.Padding = New Padding(6, 5, 6, 5)
        fraNpcSpawn.Size = New Size(290, 217)
        fraNpcSpawn.TabIndex = 11
        fraNpcSpawn.TabStop = False
        fraNpcSpawn.Text = "Npc Spawn"
        ' 
        ' lstNpc
        ' 
        lstNpc.DropDownStyle = ComboBoxStyle.DropDownList
        lstNpc.FormattingEnabled = True
        lstNpc.Location = New Point(10, 30)
        lstNpc.Margin = New Padding(6, 5, 6, 5)
        lstNpc.Name = "lstNpc"
        lstNpc.Size = New Size(255, 33)
        lstNpc.TabIndex = 37
        ' 
        ' btnNpcSpawn
        ' 
        btnNpcSpawn.Location = New Point(66, 147)
        btnNpcSpawn.Margin = New Padding(6, 5, 6, 5)
        btnNpcSpawn.Name = "btnNpcSpawn"
        btnNpcSpawn.Size = New Size(150, 53)
        btnNpcSpawn.TabIndex = 6
        btnNpcSpawn.Text = "Accept"
        btnNpcSpawn.UseVisualStyleBackColor = True
        ' 
        ' scrlNpcDir
        ' 
        scrlNpcDir.LargeChange = 1
        scrlNpcDir.Location = New Point(13, 105)
        scrlNpcDir.Maximum = 3
        scrlNpcDir.Name = "scrlNpcDir"
        scrlNpcDir.Size = New Size(254, 18)
        scrlNpcDir.TabIndex = 3
        ' 
        ' lblNpcDir
        ' 
        lblNpcDir.AutoSize = True
        lblNpcDir.Location = New Point(9, 77)
        lblNpcDir.Margin = New Padding(6, 0, 6, 0)
        lblNpcDir.Name = "lblNpcDir"
        lblNpcDir.Size = New Size(115, 25)
        lblNpcDir.TabIndex = 0
        lblNpcDir.Text = "Direction: Up"
        ' 
        ' fraHeal
        ' 
        fraHeal.Controls.Add(scrlHeal)
        fraHeal.Controls.Add(lblHeal)
        fraHeal.Controls.Add(cmbHeal)
        fraHeal.Controls.Add(btnHeal)
        fraHeal.Location = New Point(6, 483)
        fraHeal.Margin = New Padding(6, 5, 6, 5)
        fraHeal.Name = "fraHeal"
        fraHeal.Padding = New Padding(6, 5, 6, 5)
        fraHeal.Size = New Size(290, 217)
        fraHeal.TabIndex = 15
        fraHeal.TabStop = False
        fraHeal.Text = "Heal"
        ' 
        ' scrlHeal
        ' 
        scrlHeal.Location = New Point(7, 108)
        scrlHeal.Name = "scrlHeal"
        scrlHeal.Size = New Size(259, 17)
        scrlHeal.TabIndex = 39
        ' 
        ' lblHeal
        ' 
        lblHeal.AutoSize = True
        lblHeal.Location = New Point(6, 83)
        lblHeal.Margin = New Padding(6, 0, 6, 0)
        lblHeal.Name = "lblHeal"
        lblHeal.Size = New Size(96, 25)
        lblHeal.TabIndex = 38
        lblHeal.Text = "Amount: 0"
        ' 
        ' cmbHeal
        ' 
        cmbHeal.DropDownStyle = ComboBoxStyle.DropDownList
        cmbHeal.FormattingEnabled = True
        cmbHeal.Items.AddRange(New Object() {"Heal HP", "Heal MP"})
        cmbHeal.Location = New Point(10, 37)
        cmbHeal.Margin = New Padding(6, 5, 6, 5)
        cmbHeal.Name = "cmbHeal"
        cmbHeal.Size = New Size(255, 33)
        cmbHeal.TabIndex = 37
        ' 
        ' btnHeal
        ' 
        btnHeal.Location = New Point(61, 147)
        btnHeal.Margin = New Padding(6, 5, 6, 5)
        btnHeal.Name = "btnHeal"
        btnHeal.Size = New Size(150, 53)
        btnHeal.TabIndex = 6
        btnHeal.Text = "Accept"
        btnHeal.UseVisualStyleBackColor = True
        ' 
        ' fraShop
        ' 
        fraShop.Controls.Add(cmbShop)
        fraShop.Controls.Add(btnShop)
        fraShop.Location = New Point(563, 15)
        fraShop.Margin = New Padding(6, 5, 6, 5)
        fraShop.Name = "fraShop"
        fraShop.Padding = New Padding(6, 5, 6, 5)
        fraShop.Size = New Size(246, 230)
        fraShop.TabIndex = 12
        fraShop.TabStop = False
        fraShop.Text = "Shop"
        ' 
        ' cmbShop
        ' 
        cmbShop.DropDownStyle = ComboBoxStyle.DropDownList
        cmbShop.FormattingEnabled = True
        cmbShop.Location = New Point(10, 37)
        cmbShop.Margin = New Padding(6, 5, 6, 5)
        cmbShop.Name = "cmbShop"
        cmbShop.Size = New Size(218, 33)
        cmbShop.TabIndex = 37
        ' 
        ' btnShop
        ' 
        btnShop.Location = New Point(49, 163)
        btnShop.Margin = New Padding(6, 5, 6, 5)
        btnShop.Name = "btnShop"
        btnShop.Size = New Size(150, 53)
        btnShop.TabIndex = 6
        btnShop.Text = "Accept"
        btnShop.UseVisualStyleBackColor = True
        ' 
        ' fraResource
        ' 
        fraResource.Controls.Add(btnResourceOk)
        fraResource.Controls.Add(scrlResource)
        fraResource.Controls.Add(lblResource)
        fraResource.Location = New Point(306, 12)
        fraResource.Margin = New Padding(6, 5, 6, 5)
        fraResource.Name = "fraResource"
        fraResource.Padding = New Padding(6, 5, 6, 5)
        fraResource.Size = New Size(246, 217)
        fraResource.TabIndex = 10
        fraResource.TabStop = False
        fraResource.Text = "Resource"
        ' 
        ' btnResourceOk
        ' 
        btnResourceOk.Location = New Point(47, 147)
        btnResourceOk.Margin = New Padding(6, 5, 6, 5)
        btnResourceOk.Name = "btnResourceOk"
        btnResourceOk.Size = New Size(150, 53)
        btnResourceOk.TabIndex = 6
        btnResourceOk.Text = "Accept"
        btnResourceOk.UseVisualStyleBackColor = True
        ' 
        ' scrlResource
        ' 
        scrlResource.Location = New Point(6, 70)
        scrlResource.Name = "scrlResource"
        scrlResource.Size = New Size(227, 18)
        scrlResource.TabIndex = 3
        ' 
        ' lblResource
        ' 
        lblResource.AutoSize = True
        lblResource.Location = New Point(0, 30)
        lblResource.Margin = New Padding(6, 0, 6, 0)
        lblResource.Name = "lblResource"
        lblResource.Size = New Size(68, 25)
        lblResource.TabIndex = 0
        lblResource.Text = "Object:"
        ' 
        ' fraMapItem
        ' 
        fraMapItem.Controls.Add(picMapItem)
        fraMapItem.Controls.Add(btnMapItem)
        fraMapItem.Controls.Add(scrlMapItemValue)
        fraMapItem.Controls.Add(scrlMapItem)
        fraMapItem.Controls.Add(lblMapItem)
        fraMapItem.Location = New Point(6, 228)
        fraMapItem.Margin = New Padding(6, 5, 6, 5)
        fraMapItem.Name = "fraMapItem"
        fraMapItem.Padding = New Padding(6, 5, 6, 5)
        fraMapItem.Size = New Size(290, 228)
        fraMapItem.TabIndex = 7
        fraMapItem.TabStop = False
        fraMapItem.Text = "Map Item"
        ' 
        ' picMapItem
        ' 
        picMapItem.BackColor = Color.Black
        picMapItem.Location = New Point(221, 70)
        picMapItem.Margin = New Padding(6, 5, 6, 5)
        picMapItem.Name = "picMapItem"
        picMapItem.Size = New Size(53, 62)
        picMapItem.TabIndex = 7
        picMapItem.TabStop = False
        ' 
        ' btnMapItem
        ' 
        btnMapItem.Location = New Point(66, 162)
        btnMapItem.Margin = New Padding(6, 5, 6, 5)
        btnMapItem.Name = "btnMapItem"
        btnMapItem.Size = New Size(150, 53)
        btnMapItem.TabIndex = 6
        btnMapItem.Text = "Accept"
        btnMapItem.UseVisualStyleBackColor = True
        ' 
        ' scrlMapItemValue
        ' 
        scrlMapItemValue.Location = New Point(14, 113)
        scrlMapItemValue.Name = "scrlMapItemValue"
        scrlMapItemValue.Size = New Size(200, 18)
        scrlMapItemValue.TabIndex = 4
        ' 
        ' scrlMapItem
        ' 
        scrlMapItem.Location = New Point(14, 72)
        scrlMapItem.Name = "scrlMapItem"
        scrlMapItem.Size = New Size(200, 18)
        scrlMapItem.TabIndex = 3
        ' 
        ' lblMapItem
        ' 
        lblMapItem.AutoSize = True
        lblMapItem.Location = New Point(10, 42)
        lblMapItem.Margin = New Padding(6, 0, 6, 0)
        lblMapItem.Name = "lblMapItem"
        lblMapItem.Size = New Size(78, 25)
        lblMapItem.TabIndex = 0
        lblMapItem.Text = "None x0"
        ' 
        ' fraTrap
        ' 
        fraTrap.Controls.Add(btnTrap)
        fraTrap.Controls.Add(scrlTrap)
        fraTrap.Controls.Add(lblTrap)
        fraTrap.Location = New Point(306, 240)
        fraTrap.Margin = New Padding(6, 5, 6, 5)
        fraTrap.Name = "fraTrap"
        fraTrap.Padding = New Padding(6, 5, 6, 5)
        fraTrap.Size = New Size(246, 230)
        fraTrap.TabIndex = 16
        fraTrap.TabStop = False
        fraTrap.Text = "Trap"
        ' 
        ' btnTrap
        ' 
        btnTrap.Location = New Point(47, 163)
        btnTrap.Margin = New Padding(6, 5, 6, 5)
        btnTrap.Name = "btnTrap"
        btnTrap.Size = New Size(150, 53)
        btnTrap.TabIndex = 42
        btnTrap.Text = "Accept"
        btnTrap.UseVisualStyleBackColor = True
        ' 
        ' scrlTrap
        ' 
        scrlTrap.Location = New Point(19, 63)
        scrlTrap.Name = "scrlTrap"
        scrlTrap.Size = New Size(213, 17)
        scrlTrap.TabIndex = 41
        ' 
        ' lblTrap
        ' 
        lblTrap.AutoSize = True
        lblTrap.Location = New Point(10, 30)
        lblTrap.Margin = New Padding(6, 0, 6, 0)
        lblTrap.Name = "lblTrap"
        lblTrap.Size = New Size(96, 25)
        lblTrap.TabIndex = 40
        lblTrap.Text = "Amount: 0"
        ' 
        ' ToolStrip
        ' 
        ToolStrip.ImageScalingSize = New Size(24, 24)
        ToolStrip.Items.AddRange(New ToolStripItem() {tsbSave, tsbDiscard, ToolStripSeparator1, tsbMapGrid, tsbOpacity, tsbLight, ToolStripSeparator2, tsbFill, tsbClear, tsbEyeDropper, tsbCopyMap, tsbDeleteMap, tsbUndo, tsbRedo, tsbScreenshot})
        ToolStrip.Location = New Point(0, 0)
        ToolStrip.Name = "ToolStrip"
        ToolStrip.Padding = New Padding(0, 0, 3, 0)
        ToolStrip.Size = New Size(789, 33)
        ToolStrip.TabIndex = 13
        ToolStrip.Text = "ToolStrip1"
        ' 
        ' tsbSave
        ' 
        tsbSave.Image = My.Resources.Resources.Save
        tsbSave.ImageTransparentColor = Color.Magenta
        tsbSave.Name = "tsbSave"
        tsbSave.Size = New Size(34, 28)
        tsbSave.ToolTipText = "Save"
        ' 
        ' tsbDiscard
        ' 
        tsbDiscard.Image = My.Resources.Resources._Exit
        tsbDiscard.ImageTransparentColor = Color.Magenta
        tsbDiscard.Name = "tsbDiscard"
        tsbDiscard.Size = New Size(34, 28)
        tsbDiscard.ToolTipText = "Discard"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 33)
        ' 
        ' tsbMapGrid
        ' 
        tsbMapGrid.Image = My.Resources.Resources.Grid
        tsbMapGrid.ImageTransparentColor = Color.Magenta
        tsbMapGrid.Name = "tsbMapGrid"
        tsbMapGrid.Size = New Size(34, 28)
        tsbMapGrid.Tag = "Map Grid"
        ' 
        ' tsbOpacity
        ' 
        tsbOpacity.DisplayStyle = ToolStripItemDisplayStyle.Image
        tsbOpacity.Image = My.Resources.Resources.Opacity
        tsbOpacity.ImageTransparentColor = Color.Magenta
        tsbOpacity.Name = "tsbOpacity"
        tsbOpacity.Size = New Size(34, 28)
        tsbOpacity.Text = "ToolStripButton1"
        tsbOpacity.ToolTipText = "Opacity"
        ' 
        ' tsbLight
        ' 
        tsbLight.DisplayStyle = ToolStripItemDisplayStyle.Image
        tsbLight.Image = CType(resources.GetObject("tsbLight.Image"), Image)
        tsbLight.ImageTransparentColor = Color.Magenta
        tsbLight.Name = "tsbLight"
        tsbLight.Size = New Size(34, 28)
        tsbLight.ToolTipText = "Light"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(6, 33)
        ' 
        ' tsbFill
        ' 
        tsbFill.Image = My.Resources.Resources.Fill
        tsbFill.ImageTransparentColor = Color.Magenta
        tsbFill.Name = "tsbFill"
        tsbFill.Size = New Size(34, 28)
        tsbFill.Tag = "Fill"
        tsbFill.ToolTipText = "Fill Layer"
        ' 
        ' tsbClear
        ' 
        tsbClear.Image = My.Resources.Resources.Clear
        tsbClear.ImageTransparentColor = Color.Magenta
        tsbClear.Name = "tsbClear"
        tsbClear.Size = New Size(34, 28)
        tsbClear.ToolTipText = "Erase"
        ' 
        ' tsbEyeDropper
        ' 
        tsbEyeDropper.Image = My.Resources.Resources.Wand
        tsbEyeDropper.ImageTransparentColor = Color.Magenta
        tsbEyeDropper.Name = "tsbEyeDropper"
        tsbEyeDropper.Size = New Size(34, 28)
        tsbEyeDropper.ToolTipText = "Eye Dropper"
        ' 
        ' tsbCopyMap
        ' 
        tsbCopyMap.DisplayStyle = ToolStripItemDisplayStyle.Image
        tsbCopyMap.Image = My.Resources.Resources.Clipboard
        tsbCopyMap.ImageTransparentColor = Color.Magenta
        tsbCopyMap.Name = "tsbCopyMap"
        tsbCopyMap.Size = New Size(34, 28)
        tsbCopyMap.ToolTipText = "Copy"
        ' 
        ' tsbDeleteMap
        ' 
        tsbDeleteMap.DisplayStyle = ToolStripItemDisplayStyle.Image
        tsbDeleteMap.Image = My.Resources.Resources.Delete
        tsbDeleteMap.ImageTransparentColor = Color.Magenta
        tsbDeleteMap.Name = "tsbDeleteMap"
        tsbDeleteMap.Size = New Size(34, 28)
        ' 
        ' tsbUndo
        ' 
        tsbUndo.DisplayStyle = ToolStripItemDisplayStyle.Image
        tsbUndo.Image = My.Resources.Resources.Undo
        tsbUndo.ImageTransparentColor = Color.Magenta
        tsbUndo.Name = "tsbUndo"
        tsbUndo.Size = New Size(34, 28)
        tsbUndo.ToolTipText = "Undo"
        ' 
        ' tsbRedo
        ' 
        tsbRedo.DisplayStyle = ToolStripItemDisplayStyle.Image
        tsbRedo.Image = My.Resources.Resources.Redo
        tsbRedo.ImageTransparentColor = Color.Magenta
        tsbRedo.Name = "tsbRedo"
        tsbRedo.Size = New Size(34, 28)
        tsbRedo.ToolTipText = "Redo"
        ' 
        ' tsbScreenshot
        ' 
        tsbScreenshot.DisplayStyle = ToolStripItemDisplayStyle.Image
        tsbScreenshot.Image = My.Resources.Resources.ScreenShot
        tsbScreenshot.ImageTransparentColor = Color.Magenta
        tsbScreenshot.Name = "tsbScreenshot"
        tsbScreenshot.Size = New Size(34, 28)
        tsbScreenshot.ToolTipText = "Screenshot"
        ' 
        ' tabpages
        ' 
        tabpages.Controls.Add(tpTiles)
        tabpages.Controls.Add(tpAttributes)
        tabpages.Controls.Add(tpNpcs)
        tabpages.Controls.Add(tpSettings)
        tabpages.Controls.Add(tpDirBlock)
        tabpages.Controls.Add(tpEvents)
        tabpages.Controls.Add(tpEffects)
        tabpages.Location = New Point(7, 53)
        tabpages.Margin = New Padding(6, 5, 6, 5)
        tabpages.Name = "tabpages"
        tabpages.SelectedIndex = 0
        tabpages.Size = New Size(786, 1048)
        tabpages.TabIndex = 14
        ' 
        ' tpTiles
        ' 
        tpTiles.Controls.Add(cmbAutoTile)
        tpTiles.Controls.Add(Label11)
        tpTiles.Controls.Add(Label10)
        tpTiles.Controls.Add(cmbLayers)
        tpTiles.Controls.Add(Label9)
        tpTiles.Controls.Add(cmbTileSets)
        tpTiles.Controls.Add(pnlBack)
        tpTiles.Controls.Add(Label1)
        tpTiles.Location = New Point(4, 34)
        tpTiles.Margin = New Padding(6, 5, 6, 5)
        tpTiles.Name = "tpTiles"
        tpTiles.Padding = New Padding(6, 5, 6, 5)
        tpTiles.Size = New Size(778, 1010)
        tpTiles.TabIndex = 0
        tpTiles.Text = "Tiles"
        tpTiles.UseVisualStyleBackColor = True
        ' 
        ' cmbAutoTile
        ' 
        cmbAutoTile.DropDownStyle = ComboBoxStyle.DropDownList
        cmbAutoTile.FormattingEnabled = True
        cmbAutoTile.Items.AddRange(New Object() {"Normal", "AutoTile (VX)", "Fake (VX)", "Animated (VX)", "Cliff (VX)", "Waterfall (VX)"})
        cmbAutoTile.Location = New Point(611, 943)
        cmbAutoTile.Margin = New Padding(6, 5, 6, 5)
        cmbAutoTile.Name = "cmbAutoTile"
        cmbAutoTile.Size = New Size(155, 33)
        cmbAutoTile.TabIndex = 17
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(520, 950)
        Label11.Margin = New Padding(6, 0, 6, 0)
        Label11.Name = "Label11"
        Label11.Size = New Size(78, 25)
        Label11.TabIndex = 16
        Label11.Text = "Autotile:"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(239, 950)
        Label10.Margin = New Padding(6, 0, 6, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(57, 25)
        Label10.TabIndex = 15
        Label10.Text = "Layer:"
        ' 
        ' cmbLayers
        ' 
        cmbLayers.DropDownStyle = ComboBoxStyle.DropDownList
        cmbLayers.FormattingEnabled = True
        cmbLayers.Items.AddRange(New Object() {"Ground", "Mask", "Mask 2 Anim", "Cover", "Cover 2 Anim", "Fringe", "Fringe Anim", "Roof", "Roof Anim"})
        cmbLayers.Location = New Point(309, 943)
        cmbLayers.Margin = New Padding(6, 5, 6, 5)
        cmbLayers.Name = "cmbLayers"
        cmbLayers.Size = New Size(158, 33)
        cmbLayers.TabIndex = 14
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(11, 950)
        Label9.Margin = New Padding(6, 0, 6, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(65, 25)
        Label9.TabIndex = 13
        Label9.Text = "Tileset:"
        ' 
        ' cmbTileSets
        ' 
        cmbTileSets.DropDownStyle = ComboBoxStyle.DropDownList
        cmbTileSets.FormattingEnabled = True
        cmbTileSets.Location = New Point(90, 943)
        cmbTileSets.Margin = New Padding(6, 5, 6, 5)
        cmbTileSets.Name = "cmbTileSets"
        cmbTileSets.Size = New Size(95, 33)
        cmbTileSets.TabIndex = 12
        ' 
        ' tpAttributes
        ' 
        tpAttributes.Controls.Add(optNoXing)
        tpAttributes.Controls.Add(optInfo)
        tpAttributes.Controls.Add(Label23)
        tpAttributes.Controls.Add(cmbAttribute)
        tpAttributes.Controls.Add(optAnimation)
        tpAttributes.Controls.Add(optLight)
        tpAttributes.Controls.Add(btnClearAttribute)
        tpAttributes.Controls.Add(optTrap)
        tpAttributes.Controls.Add(optBlocked)
        tpAttributes.Controls.Add(optHeal)
        tpAttributes.Controls.Add(optWarp)
        tpAttributes.Controls.Add(optBank)
        tpAttributes.Controls.Add(optItem)
        tpAttributes.Controls.Add(optShop)
        tpAttributes.Controls.Add(optNPCAvoid)
        tpAttributes.Controls.Add(optNPCSpawn)
        tpAttributes.Controls.Add(optResource)
        tpAttributes.Location = New Point(4, 34)
        tpAttributes.Margin = New Padding(6, 5, 6, 5)
        tpAttributes.Name = "tpAttributes"
        tpAttributes.Padding = New Padding(6, 5, 6, 5)
        tpAttributes.Size = New Size(778, 1010)
        tpAttributes.TabIndex = 3
        tpAttributes.Text = "Attributes"
        tpAttributes.UseVisualStyleBackColor = True
        ' 
        ' optNoXing
        ' 
        optNoXing.AutoSize = True
        optNoXing.Checked = True
        optNoXing.Location = New Point(17, 165)
        optNoXing.Margin = New Padding(6, 5, 6, 5)
        optNoXing.Name = "optNoXing"
        optNoXing.Size = New Size(102, 29)
        optNoXing.TabIndex = 23
        optNoXing.TabStop = True
        optNoXing.Text = "No Xing"
        optNoXing.UseVisualStyleBackColor = True
        ' 
        ' optInfo
        ' 
        optInfo.AutoSize = True
        optInfo.Location = New Point(196, 958)
        optInfo.Margin = New Padding(6, 5, 6, 5)
        optInfo.Name = "optInfo"
        optInfo.Size = New Size(69, 29)
        optInfo.TabIndex = 22
        optInfo.Text = "Info"
        optInfo.UseVisualStyleBackColor = True
        ' 
        ' Label23
        ' 
        Label23.AutoSize = True
        Label23.Location = New Point(12, 960)
        Label23.Margin = New Padding(6, 0, 6, 0)
        Label23.Name = "Label23"
        Label23.Size = New Size(53, 25)
        Label23.TabIndex = 21
        Label23.Text = "Type:"
        ' 
        ' cmbAttribute
        ' 
        cmbAttribute.DropDownStyle = ComboBoxStyle.DropDownList
        cmbAttribute.FormattingEnabled = True
        cmbAttribute.Items.AddRange(New Object() {"Layer 1", "Layer 2"})
        cmbAttribute.Location = New Point(89, 957)
        cmbAttribute.Margin = New Padding(6, 5, 6, 5)
        cmbAttribute.Name = "cmbAttribute"
        cmbAttribute.Size = New Size(95, 33)
        cmbAttribute.TabIndex = 20
        ' 
        ' optAnimation
        ' 
        optAnimation.AutoSize = True
        optAnimation.Location = New Point(640, 97)
        optAnimation.Margin = New Padding(6, 5, 6, 5)
        optAnimation.Name = "optAnimation"
        optAnimation.Size = New Size(119, 29)
        optAnimation.TabIndex = 19
        optAnimation.Text = "Animation"
        optAnimation.UseVisualStyleBackColor = True
        ' 
        ' optLight
        ' 
        optLight.AutoSize = True
        optLight.Location = New Point(289, 97)
        optLight.Margin = New Padding(6, 5, 6, 5)
        optLight.Name = "optLight"
        optLight.Size = New Size(76, 29)
        optLight.TabIndex = 18
        optLight.Text = "Light"
        optLight.UseVisualStyleBackColor = True
        ' 
        ' tpNpcs
        ' 
        tpNpcs.Controls.Add(fraNpcs)
        tpNpcs.Location = New Point(4, 34)
        tpNpcs.Margin = New Padding(6, 5, 6, 5)
        tpNpcs.Name = "tpNpcs"
        tpNpcs.Padding = New Padding(6, 5, 6, 5)
        tpNpcs.Size = New Size(778, 1010)
        tpNpcs.TabIndex = 1
        tpNpcs.Text = "NPCs"
        tpNpcs.UseVisualStyleBackColor = True
        ' 
        ' fraNpcs
        ' 
        fraNpcs.Controls.Add(Label18)
        fraNpcs.Controls.Add(Label17)
        fraNpcs.Controls.Add(cmbNpcList)
        fraNpcs.Controls.Add(lstMapNpc)
        fraNpcs.Controls.Add(ComboBox23)
        fraNpcs.Location = New Point(10, 15)
        fraNpcs.Margin = New Padding(6, 5, 6, 5)
        fraNpcs.Name = "fraNpcs"
        fraNpcs.Padding = New Padding(6, 5, 6, 5)
        fraNpcs.Size = New Size(799, 820)
        fraNpcs.TabIndex = 11
        fraNpcs.TabStop = False
        fraNpcs.Text = "NPCs"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Location = New Point(326, 55)
        Label18.Margin = New Padding(6, 0, 6, 0)
        Label18.Name = "Label18"
        Label18.Size = New Size(116, 25)
        Label18.TabIndex = 72
        Label18.Text = "2. Select NPC"
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Location = New Point(10, 55)
        Label17.Margin = New Padding(6, 0, 6, 0)
        Label17.Name = "Label17"
        Label17.Size = New Size(97, 25)
        Label17.TabIndex = 71
        Label17.Text = "1. NPC LIst"
        ' 
        ' cmbNpcList
        ' 
        cmbNpcList.FormattingEnabled = True
        cmbNpcList.Location = New Point(326, 87)
        cmbNpcList.Margin = New Padding(6, 5, 6, 5)
        cmbNpcList.Name = "cmbNpcList"
        cmbNpcList.Size = New Size(425, 33)
        cmbNpcList.TabIndex = 70
        ' 
        ' lstMapNpc
        ' 
        lstMapNpc.FormattingEnabled = True
        lstMapNpc.ItemHeight = 25
        lstMapNpc.Location = New Point(14, 87)
        lstMapNpc.Margin = New Padding(6, 5, 6, 5)
        lstMapNpc.Name = "lstMapNpc"
        lstMapNpc.Size = New Size(298, 704)
        lstMapNpc.TabIndex = 69
        ' 
        ' ComboBox23
        ' 
        ComboBox23.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox23.FormattingEnabled = True
        ComboBox23.Location = New Point(569, 902)
        ComboBox23.Margin = New Padding(6, 5, 6, 5)
        ComboBox23.Name = "ComboBox23"
        ComboBox23.Size = New Size(218, 33)
        ComboBox23.TabIndex = 68
        ' 
        ' tpSettings
        ' 
        tpSettings.Controls.Add(fraMapSettings)
        tpSettings.Controls.Add(fraMapLinks)
        tpSettings.Controls.Add(fraBootSettings)
        tpSettings.Controls.Add(fraMaxSizes)
        tpSettings.Controls.Add(GroupBox2)
        tpSettings.Controls.Add(txtName)
        tpSettings.Controls.Add(Label6)
        tpSettings.Location = New Point(4, 34)
        tpSettings.Margin = New Padding(6, 5, 6, 5)
        tpSettings.Name = "tpSettings"
        tpSettings.Padding = New Padding(6, 5, 6, 5)
        tpSettings.Size = New Size(778, 1010)
        tpSettings.TabIndex = 2
        tpSettings.Text = "Settings"
        tpSettings.UseVisualStyleBackColor = True
        ' 
        ' fraMapSettings
        ' 
        fraMapSettings.Controls.Add(Label22)
        fraMapSettings.Controls.Add(lstShop)
        fraMapSettings.Controls.Add(Label8)
        fraMapSettings.Controls.Add(lstMoral)
        fraMapSettings.Location = New Point(10, 62)
        fraMapSettings.Margin = New Padding(6, 5, 6, 5)
        fraMapSettings.Name = "fraMapSettings"
        fraMapSettings.Padding = New Padding(6, 5, 6, 5)
        fraMapSettings.Size = New Size(387, 132)
        fraMapSettings.TabIndex = 15
        fraMapSettings.TabStop = False
        fraMapSettings.Text = "Settings"
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.Location = New Point(6, 69)
        Label22.Margin = New Padding(6, 0, 6, 0)
        Label22.Name = "Label22"
        Label22.Size = New Size(58, 25)
        Label22.TabIndex = 40
        Label22.Text = "Shop:"
        ' 
        ' lstShop
        ' 
        lstShop.DropDownStyle = ComboBoxStyle.DropDownList
        lstShop.FormattingEnabled = True
        lstShop.Location = New Point(74, 66)
        lstShop.Margin = New Padding(6, 5, 6, 5)
        lstShop.Name = "lstShop"
        lstShop.Size = New Size(298, 33)
        lstShop.TabIndex = 39
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(6, 28)
        Label8.Margin = New Padding(6, 0, 6, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(62, 25)
        Label8.TabIndex = 38
        Label8.Text = "Moral:"
        ' 
        ' lstMoral
        ' 
        lstMoral.DropDownStyle = ComboBoxStyle.DropDownList
        lstMoral.FormattingEnabled = True
        lstMoral.Location = New Point(74, 23)
        lstMoral.Margin = New Padding(6, 5, 6, 5)
        lstMoral.Name = "lstMoral"
        lstMoral.Size = New Size(298, 33)
        lstMoral.TabIndex = 37
        ' 
        ' fraMapLinks
        ' 
        fraMapLinks.Controls.Add(txtDown)
        fraMapLinks.Controls.Add(txtLeft)
        fraMapLinks.Controls.Add(lblMap)
        fraMapLinks.Controls.Add(txtRight)
        fraMapLinks.Controls.Add(txtUp)
        fraMapLinks.Location = New Point(10, 203)
        fraMapLinks.Margin = New Padding(6, 5, 6, 5)
        fraMapLinks.Name = "fraMapLinks"
        fraMapLinks.Padding = New Padding(6, 5, 6, 5)
        fraMapLinks.Size = New Size(387, 215)
        fraMapLinks.TabIndex = 14
        fraMapLinks.TabStop = False
        fraMapLinks.Text = "Borders"
        ' 
        ' txtDown
        ' 
        txtDown.Location = New Point(150, 165)
        txtDown.Margin = New Padding(6, 5, 6, 5)
        txtDown.Name = "txtDown"
        txtDown.Size = New Size(81, 31)
        txtDown.TabIndex = 6
        txtDown.Text = "0"
        ' 
        ' txtLeft
        ' 
        txtLeft.Location = New Point(11, 90)
        txtLeft.Margin = New Padding(6, 5, 6, 5)
        txtLeft.Name = "txtLeft"
        txtLeft.Size = New Size(70, 31)
        txtLeft.TabIndex = 5
        txtLeft.Text = "0"
        ' 
        ' lblMap
        ' 
        lblMap.AutoSize = True
        lblMap.Location = New Point(149, 96)
        lblMap.Margin = New Padding(6, 0, 6, 0)
        lblMap.Name = "lblMap"
        lblMap.Size = New Size(67, 25)
        lblMap.TabIndex = 4
        lblMap.Text = "Map: 0"
        ' 
        ' txtRight
        ' 
        txtRight.Location = New Point(294, 90)
        txtRight.Margin = New Padding(6, 5, 6, 5)
        txtRight.Name = "txtRight"
        txtRight.Size = New Size(81, 31)
        txtRight.TabIndex = 3
        txtRight.Text = "0"
        ' 
        ' txtUp
        ' 
        txtUp.Location = New Point(149, 20)
        txtUp.Margin = New Padding(6, 5, 6, 5)
        txtUp.Name = "txtUp"
        txtUp.Size = New Size(81, 31)
        txtUp.TabIndex = 1
        txtUp.Text = "0"
        ' 
        ' fraBootSettings
        ' 
        fraBootSettings.Controls.Add(chkIndoors)
        fraBootSettings.Controls.Add(chkNoMapRespawn)
        fraBootSettings.Controls.Add(txtBootMap)
        fraBootSettings.Controls.Add(Label5)
        fraBootSettings.Controls.Add(txtBootY)
        fraBootSettings.Controls.Add(Label3)
        fraBootSettings.Controls.Add(txtBootX)
        fraBootSettings.Controls.Add(Label4)
        fraBootSettings.Location = New Point(10, 430)
        fraBootSettings.Margin = New Padding(6, 5, 6, 5)
        fraBootSettings.Name = "fraBootSettings"
        fraBootSettings.Padding = New Padding(6, 5, 6, 5)
        fraBootSettings.Size = New Size(387, 209)
        fraBootSettings.TabIndex = 13
        fraBootSettings.TabStop = False
        fraBootSettings.Text = "Respawn Settings"
        ' 
        ' chkIndoors
        ' 
        chkIndoors.AutoSize = True
        chkIndoors.Location = New Point(12, 167)
        chkIndoors.Margin = New Padding(6, 5, 6, 5)
        chkIndoors.Name = "chkIndoors"
        chkIndoors.Size = New Size(100, 29)
        chkIndoors.TabIndex = 42
        chkIndoors.Text = "Indoors"
        chkIndoors.UseVisualStyleBackColor = True
        ' 
        ' chkNoMapRespawn
        ' 
        chkNoMapRespawn.AutoSize = True
        chkNoMapRespawn.Location = New Point(197, 163)
        chkNoMapRespawn.Margin = New Padding(6, 5, 6, 5)
        chkNoMapRespawn.Name = "chkNoMapRespawn"
        chkNoMapRespawn.Size = New Size(178, 29)
        chkNoMapRespawn.TabIndex = 19
        chkNoMapRespawn.Text = "No Map Respawn"
        chkNoMapRespawn.UseVisualStyleBackColor = True
        ' 
        ' txtBootMap
        ' 
        txtBootMap.Location = New Point(293, 22)
        txtBootMap.Margin = New Padding(6, 5, 6, 5)
        txtBootMap.Name = "txtBootMap"
        txtBootMap.Size = New Size(81, 31)
        txtBootMap.TabIndex = 5
        txtBootMap.Text = "0"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(10, 30)
        Label5.Margin = New Padding(6, 0, 6, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(52, 25)
        Label5.TabIndex = 4
        Label5.Text = "Map:"
        ' 
        ' txtBootY
        ' 
        txtBootY.Location = New Point(293, 122)
        txtBootY.Margin = New Padding(6, 5, 6, 5)
        txtBootY.Name = "txtBootY"
        txtBootY.Size = New Size(81, 31)
        txtBootY.TabIndex = 3
        txtBootY.Text = "0"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(10, 125)
        Label3.Margin = New Padding(6, 0, 6, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(26, 25)
        Label3.TabIndex = 2
        Label3.Text = "Y:"
        ' 
        ' txtBootX
        ' 
        txtBootX.Location = New Point(293, 72)
        txtBootX.Margin = New Padding(6, 5, 6, 5)
        txtBootX.Name = "txtBootX"
        txtBootX.Size = New Size(81, 31)
        txtBootX.TabIndex = 1
        txtBootX.Text = "0"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(10, 72)
        Label4.Margin = New Padding(6, 0, 6, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(27, 25)
        Label4.TabIndex = 0
        Label4.Text = "X:"
        ' 
        ' fraMaxSizes
        ' 
        fraMaxSizes.Controls.Add(txtMaxY)
        fraMaxSizes.Controls.Add(Label2)
        fraMaxSizes.Controls.Add(txtMaxX)
        fraMaxSizes.Controls.Add(Label7)
        fraMaxSizes.Location = New Point(407, 430)
        fraMaxSizes.Margin = New Padding(6, 5, 6, 5)
        fraMaxSizes.Name = "fraMaxSizes"
        fraMaxSizes.Padding = New Padding(6, 5, 6, 5)
        fraMaxSizes.Size = New Size(356, 150)
        fraMaxSizes.TabIndex = 12
        fraMaxSizes.TabStop = False
        fraMaxSizes.Text = "Size Settings"
        ' 
        ' txtMaxY
        ' 
        txtMaxY.Location = New Point(207, 80)
        txtMaxY.Margin = New Padding(6, 5, 6, 5)
        txtMaxY.Name = "txtMaxY"
        txtMaxY.Size = New Size(81, 31)
        txtMaxY.TabIndex = 3
        txtMaxY.Text = "0"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(10, 87)
        Label2.Margin = New Padding(6, 0, 6, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(64, 25)
        Label2.TabIndex = 2
        Label2.Text = "Max Y:"
        ' 
        ' txtMaxX
        ' 
        txtMaxX.Location = New Point(207, 30)
        txtMaxX.Margin = New Padding(6, 5, 6, 5)
        txtMaxX.Name = "txtMaxX"
        txtMaxX.Size = New Size(81, 31)
        txtMaxX.TabIndex = 1
        txtMaxX.Text = "0"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(10, 37)
        Label7.Margin = New Padding(6, 0, 6, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(65, 25)
        Label7.TabIndex = 0
        Label7.Text = "Max X:"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(btnPreview)
        GroupBox2.Controls.Add(lstMusic)
        GroupBox2.Location = New Point(407, 5)
        GroupBox2.Margin = New Padding(6, 5, 6, 5)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Padding = New Padding(6, 5, 6, 5)
        GroupBox2.Size = New Size(401, 415)
        GroupBox2.TabIndex = 11
        GroupBox2.TabStop = False
        GroupBox2.Text = "Music"
        ' 
        ' btnPreview
        ' 
        btnPreview.Image = CType(resources.GetObject("btnPreview.Image"), Image)
        btnPreview.ImageAlign = ContentAlignment.MiddleLeft
        btnPreview.Location = New Point(81, 347)
        btnPreview.Margin = New Padding(6, 5, 6, 5)
        btnPreview.Name = "btnPreview"
        btnPreview.Size = New Size(231, 55)
        btnPreview.TabIndex = 4
        btnPreview.Text = "Preview Music"
        btnPreview.UseVisualStyleBackColor = True
        ' 
        ' lstMusic
        ' 
        lstMusic.FormattingEnabled = True
        lstMusic.ItemHeight = 25
        lstMusic.Location = New Point(10, 37)
        lstMusic.Margin = New Padding(6, 5, 6, 5)
        lstMusic.Name = "lstMusic"
        lstMusic.ScrollAlwaysVisible = True
        lstMusic.Size = New Size(344, 304)
        lstMusic.TabIndex = 3
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(89, 12)
        txtName.Margin = New Padding(6, 5, 6, 5)
        txtName.Name = "txtName"
        txtName.Size = New Size(305, 31)
        txtName.TabIndex = 10
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(10, 17)
        Label6.Margin = New Padding(6, 0, 6, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(63, 25)
        Label6.TabIndex = 9
        Label6.Text = "Name:"
        ' 
        ' tpDirBlock
        ' 
        tpDirBlock.Controls.Add(Label12)
        tpDirBlock.Location = New Point(4, 34)
        tpDirBlock.Margin = New Padding(6, 5, 6, 5)
        tpDirBlock.Name = "tpDirBlock"
        tpDirBlock.Padding = New Padding(6, 5, 6, 5)
        tpDirBlock.Size = New Size(778, 1010)
        tpDirBlock.TabIndex = 4
        tpDirBlock.Text = "Directional Block"
        tpDirBlock.UseVisualStyleBackColor = True
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(37, 45)
        Label12.Margin = New Padding(6, 0, 6, 0)
        Label12.Name = "Label12"
        Label12.Size = New Size(404, 25)
        Label12.TabIndex = 0
        Label12.Text = "Just press the arrows to block that side of the tile."
        ' 
        ' tpEvents
        ' 
        tpEvents.Controls.Add(lblPasteMode)
        tpEvents.Controls.Add(lblCopyMode)
        tpEvents.Controls.Add(btnPasteEvent)
        tpEvents.Controls.Add(Label16)
        tpEvents.Controls.Add(btnCopyEvent)
        tpEvents.Controls.Add(Label15)
        tpEvents.Controls.Add(Label13)
        tpEvents.Location = New Point(4, 34)
        tpEvents.Margin = New Padding(6, 5, 6, 5)
        tpEvents.Name = "tpEvents"
        tpEvents.Padding = New Padding(6, 5, 6, 5)
        tpEvents.Size = New Size(778, 1010)
        tpEvents.TabIndex = 5
        tpEvents.Text = "Events"
        tpEvents.UseVisualStyleBackColor = True
        ' 
        ' lblPasteMode
        ' 
        lblPasteMode.AutoSize = True
        lblPasteMode.Location = New Point(173, 328)
        lblPasteMode.Margin = New Padding(6, 0, 6, 0)
        lblPasteMode.Name = "lblPasteMode"
        lblPasteMode.Size = New Size(131, 25)
        lblPasteMode.TabIndex = 6
        lblPasteMode.Text = "PasteMode Off"
        ' 
        ' lblCopyMode
        ' 
        lblCopyMode.AutoSize = True
        lblCopyMode.Location = New Point(173, 215)
        lblCopyMode.Margin = New Padding(6, 0, 6, 0)
        lblCopyMode.Name = "lblCopyMode"
        lblCopyMode.Size = New Size(132, 25)
        lblCopyMode.TabIndex = 5
        lblCopyMode.Text = "CopyMode Off"
        ' 
        ' btnPasteEvent
        ' 
        btnPasteEvent.Location = New Point(39, 320)
        btnPasteEvent.Margin = New Padding(6, 5, 6, 5)
        btnPasteEvent.Name = "btnPasteEvent"
        btnPasteEvent.Size = New Size(126, 45)
        btnPasteEvent.TabIndex = 4
        btnPasteEvent.Text = "Paste Event"
        btnPasteEvent.UseVisualStyleBackColor = True
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Location = New Point(33, 287)
        Label16.Margin = New Padding(6, 0, 6, 0)
        Label16.Name = "Label16"
        Label16.Size = New Size(653, 25)
        Label16.TabIndex = 3
        Label16.Text = "To paste a copied Event, press the paste button, then click on the map to place it."
        ' 
        ' btnCopyEvent
        ' 
        btnCopyEvent.Location = New Point(39, 205)
        btnCopyEvent.Margin = New Padding(6, 5, 6, 5)
        btnCopyEvent.Name = "btnCopyEvent"
        btnCopyEvent.Size = New Size(126, 45)
        btnCopyEvent.TabIndex = 2
        btnCopyEvent.Text = "Copy Event"
        btnCopyEvent.UseVisualStyleBackColor = True
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Location = New Point(33, 167)
        Label15.Margin = New Padding(6, 0, 6, 0)
        Label15.Name = "Label15"
        Label15.Size = New Size(511, 25)
        Label15.TabIndex = 1
        Label15.Text = "To copy a existing Event, press the copy button, then the event."
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(33, 40)
        Label13.Margin = New Padding(6, 0, 6, 0)
        Label13.Name = "Label13"
        Label13.Size = New Size(399, 25)
        Label13.TabIndex = 0
        Label13.Text = "Click on the map where you want to add a event."
        ' 
        ' tpEffects
        ' 
        tpEffects.Controls.Add(GroupBox6)
        tpEffects.Controls.Add(GroupBox5)
        tpEffects.Controls.Add(GroupBox4)
        tpEffects.Controls.Add(GroupBox3)
        tpEffects.Controls.Add(GroupBox1)
        tpEffects.Location = New Point(4, 34)
        tpEffects.Margin = New Padding(6, 5, 6, 5)
        tpEffects.Name = "tpEffects"
        tpEffects.Padding = New Padding(6, 5, 6, 5)
        tpEffects.Size = New Size(778, 1010)
        tpEffects.TabIndex = 6
        tpEffects.Text = "Effects"
        tpEffects.UseVisualStyleBackColor = True
        ' 
        ' GroupBox6
        ' 
        GroupBox6.Controls.Add(lblMapBrightness)
        GroupBox6.Controls.Add(scrlMapBrightness)
        GroupBox6.Location = New Point(19, 432)
        GroupBox6.Margin = New Padding(6, 5, 6, 5)
        GroupBox6.Name = "GroupBox6"
        GroupBox6.Padding = New Padding(6, 5, 6, 5)
        GroupBox6.Size = New Size(393, 75)
        GroupBox6.TabIndex = 22
        GroupBox6.TabStop = False
        GroupBox6.Text = "Brightness"
        ' 
        ' lblMapBrightness
        ' 
        lblMapBrightness.AutoSize = True
        lblMapBrightness.Location = New Point(1, 32)
        lblMapBrightness.Margin = New Padding(6, 0, 6, 0)
        lblMapBrightness.Name = "lblMapBrightness"
        lblMapBrightness.Size = New Size(113, 25)
        lblMapBrightness.TabIndex = 14
        lblMapBrightness.Text = "Brightness: 0"
        ' 
        ' scrlMapBrightness
        ' 
        scrlMapBrightness.LargeChange = 1
        scrlMapBrightness.Location = New Point(140, 32)
        scrlMapBrightness.Maximum = 255
        scrlMapBrightness.Name = "scrlMapBrightness"
        scrlMapBrightness.Size = New Size(241, 17)
        scrlMapBrightness.TabIndex = 10
        ' 
        ' GroupBox5
        ' 
        GroupBox5.Controls.Add(Label20)
        GroupBox5.Controls.Add(cmbParallax)
        GroupBox5.Location = New Point(421, 320)
        GroupBox5.Margin = New Padding(6, 5, 6, 5)
        GroupBox5.Name = "GroupBox5"
        GroupBox5.Padding = New Padding(6, 5, 6, 5)
        GroupBox5.Size = New Size(393, 102)
        GroupBox5.TabIndex = 21
        GroupBox5.TabStop = False
        GroupBox5.Text = "Parallax"
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Location = New Point(0, 42)
        Label20.Margin = New Padding(6, 0, 6, 0)
        Label20.Name = "Label20"
        Label20.Size = New Size(74, 25)
        Label20.TabIndex = 1
        Label20.Text = "Parallax:"
        ' 
        ' cmbParallax
        ' 
        cmbParallax.FormattingEnabled = True
        cmbParallax.Location = New Point(76, 35)
        cmbParallax.Margin = New Padding(6, 5, 6, 5)
        cmbParallax.Name = "cmbParallax"
        cmbParallax.Size = New Size(264, 33)
        cmbParallax.TabIndex = 0
        ' 
        ' GroupBox4
        ' 
        GroupBox4.Controls.Add(Label19)
        GroupBox4.Controls.Add(cmbPanorama)
        GroupBox4.Location = New Point(10, 320)
        GroupBox4.Margin = New Padding(6, 5, 6, 5)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Padding = New Padding(6, 5, 6, 5)
        GroupBox4.Size = New Size(401, 102)
        GroupBox4.TabIndex = 20
        GroupBox4.TabStop = False
        GroupBox4.Text = "Panorama"
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Location = New Point(10, 42)
        Label19.Margin = New Padding(6, 0, 6, 0)
        Label19.Name = "Label19"
        Label19.Size = New Size(95, 25)
        Label19.TabIndex = 1
        Label19.Text = "Panorama:"
        ' 
        ' cmbPanorama
        ' 
        cmbPanorama.FormattingEnabled = True
        cmbPanorama.Location = New Point(117, 37)
        cmbPanorama.Margin = New Padding(6, 5, 6, 5)
        cmbPanorama.Name = "cmbPanorama"
        cmbPanorama.Size = New Size(273, 33)
        cmbPanorama.TabIndex = 0
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(chkTint)
        GroupBox3.Controls.Add(lblMapAlpha)
        GroupBox3.Controls.Add(lblMapBlue)
        GroupBox3.Controls.Add(lblMapGreen)
        GroupBox3.Controls.Add(lblMapRed)
        GroupBox3.Controls.Add(scrlMapAlpha)
        GroupBox3.Controls.Add(scrlMapBlue)
        GroupBox3.Controls.Add(scrlMapGreen)
        GroupBox3.Controls.Add(scrlMapRed)
        GroupBox3.Location = New Point(421, 12)
        GroupBox3.Margin = New Padding(6, 5, 6, 5)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Padding = New Padding(6, 5, 6, 5)
        GroupBox3.Size = New Size(393, 297)
        GroupBox3.TabIndex = 19
        GroupBox3.TabStop = False
        GroupBox3.Text = "Tint"
        ' 
        ' chkTint
        ' 
        chkTint.AutoSize = True
        chkTint.Location = New Point(10, 37)
        chkTint.Margin = New Padding(6, 5, 6, 5)
        chkTint.Name = "chkTint"
        chkTint.Size = New Size(90, 29)
        chkTint.TabIndex = 18
        chkTint.Text = "Enable"
        chkTint.UseVisualStyleBackColor = True
        ' 
        ' lblMapAlpha
        ' 
        lblMapAlpha.AutoSize = True
        lblMapAlpha.Location = New Point(13, 185)
        lblMapAlpha.Margin = New Padding(6, 0, 6, 0)
        lblMapAlpha.Name = "lblMapAlpha"
        lblMapAlpha.Size = New Size(77, 25)
        lblMapAlpha.TabIndex = 17
        lblMapAlpha.Text = "Alpha: 0"
        ' 
        ' lblMapBlue
        ' 
        lblMapBlue.AutoSize = True
        lblMapBlue.Location = New Point(13, 148)
        lblMapBlue.Margin = New Padding(6, 0, 6, 0)
        lblMapBlue.Name = "lblMapBlue"
        lblMapBlue.Size = New Size(64, 25)
        lblMapBlue.TabIndex = 16
        lblMapBlue.Text = "Blue: 0"
        ' 
        ' lblMapGreen
        ' 
        lblMapGreen.AutoSize = True
        lblMapGreen.Location = New Point(13, 112)
        lblMapGreen.Margin = New Padding(6, 0, 6, 0)
        lblMapGreen.Name = "lblMapGreen"
        lblMapGreen.Size = New Size(77, 25)
        lblMapGreen.TabIndex = 15
        lblMapGreen.Text = "Green: 0"
        ' 
        ' lblMapRed
        ' 
        lblMapRed.AutoSize = True
        lblMapRed.Location = New Point(10, 75)
        lblMapRed.Margin = New Padding(6, 0, 6, 0)
        lblMapRed.Name = "lblMapRed"
        lblMapRed.Size = New Size(61, 25)
        lblMapRed.TabIndex = 14
        lblMapRed.Text = "Red: 0"
        ' 
        ' scrlMapAlpha
        ' 
        scrlMapAlpha.LargeChange = 1
        scrlMapAlpha.Location = New Point(106, 182)
        scrlMapAlpha.Maximum = 255
        scrlMapAlpha.Name = "scrlMapAlpha"
        scrlMapAlpha.Size = New Size(241, 17)
        scrlMapAlpha.TabIndex = 13
        ' 
        ' scrlMapBlue
        ' 
        scrlMapBlue.LargeChange = 1
        scrlMapBlue.Location = New Point(106, 147)
        scrlMapBlue.Maximum = 255
        scrlMapBlue.Name = "scrlMapBlue"
        scrlMapBlue.Size = New Size(241, 17)
        scrlMapBlue.TabIndex = 12
        ' 
        ' scrlMapGreen
        ' 
        scrlMapGreen.LargeChange = 1
        scrlMapGreen.Location = New Point(106, 107)
        scrlMapGreen.Maximum = 255
        scrlMapGreen.Name = "scrlMapGreen"
        scrlMapGreen.Size = New Size(241, 17)
        scrlMapGreen.TabIndex = 11
        ' 
        ' scrlMapRed
        ' 
        scrlMapRed.LargeChange = 1
        scrlMapRed.Location = New Point(106, 77)
        scrlMapRed.Maximum = 255
        scrlMapRed.Name = "scrlMapRed"
        scrlMapRed.Size = New Size(241, 17)
        scrlMapRed.TabIndex = 10
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(scrlFogOpacity)
        GroupBox1.Controls.Add(lblFogOpacity)
        GroupBox1.Controls.Add(scrlFogSpeed)
        GroupBox1.Controls.Add(lblFogSpeed)
        GroupBox1.Controls.Add(scrlIntensity)
        GroupBox1.Controls.Add(lblIntensity)
        GroupBox1.Controls.Add(scrlFog)
        GroupBox1.Controls.Add(lblFogIndex)
        GroupBox1.Controls.Add(Label14)
        GroupBox1.Controls.Add(cmbWeather)
        GroupBox1.Location = New Point(10, 12)
        GroupBox1.Margin = New Padding(6, 5, 6, 5)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(6, 5, 6, 5)
        GroupBox1.Size = New Size(401, 297)
        GroupBox1.TabIndex = 18
        GroupBox1.TabStop = False
        GroupBox1.Text = "Weather"
        ' 
        ' scrlFogOpacity
        ' 
        scrlFogOpacity.LargeChange = 1
        scrlFogOpacity.Location = New Point(150, 238)
        scrlFogOpacity.Maximum = 255
        scrlFogOpacity.Name = "scrlFogOpacity"
        scrlFogOpacity.Size = New Size(241, 17)
        scrlFogOpacity.TabIndex = 9
        ' 
        ' lblFogOpacity
        ' 
        lblFogOpacity.AutoSize = True
        lblFogOpacity.Location = New Point(10, 242)
        lblFogOpacity.Margin = New Padding(6, 0, 6, 0)
        lblFogOpacity.Name = "lblFogOpacity"
        lblFogOpacity.Size = New Size(133, 25)
        lblFogOpacity.TabIndex = 8
        lblFogOpacity.Text = "Fog Alpha: 255"
        ' 
        ' scrlFogSpeed
        ' 
        scrlFogSpeed.LargeChange = 1
        scrlFogSpeed.Location = New Point(150, 195)
        scrlFogSpeed.Name = "scrlFogSpeed"
        scrlFogSpeed.Size = New Size(241, 17)
        scrlFogSpeed.TabIndex = 7
        ' 
        ' lblFogSpeed
        ' 
        lblFogSpeed.AutoSize = True
        lblFogSpeed.Location = New Point(10, 202)
        lblFogSpeed.Margin = New Padding(6, 0, 6, 0)
        lblFogSpeed.Name = "lblFogSpeed"
        lblFogSpeed.Size = New Size(132, 25)
        lblFogSpeed.TabIndex = 6
        lblFogSpeed.Text = "FogSpeed: 100"
        ' 
        ' scrlIntensity
        ' 
        scrlIntensity.LargeChange = 1
        scrlIntensity.Location = New Point(150, 98)
        scrlIntensity.Name = "scrlIntensity"
        scrlIntensity.Size = New Size(241, 17)
        scrlIntensity.TabIndex = 5
        ' 
        ' lblIntensity
        ' 
        lblIntensity.AutoSize = True
        lblIntensity.Location = New Point(10, 102)
        lblIntensity.Margin = New Padding(6, 0, 6, 0)
        lblIntensity.Name = "lblIntensity"
        lblIntensity.Size = New Size(118, 25)
        lblIntensity.TabIndex = 4
        lblIntensity.Text = "Intensity: 100"
        ' 
        ' scrlFog
        ' 
        scrlFog.LargeChange = 1
        scrlFog.Location = New Point(150, 155)
        scrlFog.Name = "scrlFog"
        scrlFog.Size = New Size(241, 17)
        scrlFog.TabIndex = 3
        ' 
        ' lblFogIndex
        ' 
        lblFogIndex.AutoSize = True
        lblFogIndex.Location = New Point(10, 158)
        lblFogIndex.Margin = New Padding(6, 0, 6, 0)
        lblFogIndex.Name = "lblFogIndex"
        lblFogIndex.Size = New Size(62, 25)
        lblFogIndex.TabIndex = 2
        lblFogIndex.Text = "Fog: 1"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(10, 48)
        Label14.Margin = New Padding(6, 0, 6, 0)
        Label14.Name = "Label14"
        Label14.Size = New Size(123, 25)
        Label14.TabIndex = 1
        Label14.Text = "Weather Type:"
        ' 
        ' cmbWeather
        ' 
        cmbWeather.FormattingEnabled = True
        cmbWeather.Items.AddRange(New Object() {"None", "Rain", "Snow", "Hail", "Sand Storm", "Storm", "Fog"})
        cmbWeather.Location = New Point(150, 42)
        cmbWeather.Margin = New Padding(6, 5, 6, 5)
        cmbWeather.Name = "cmbWeather"
        cmbWeather.Size = New Size(238, 33)
        cmbWeather.TabIndex = 0
        ' 
        ' frmEditor_Map
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = SystemColors.Control
        ClientSize = New Size(789, 1097)
        Controls.Add(tabpages)
        Controls.Add(ToolStrip)
        Controls.Add(pnlAttributes)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Margin = New Padding(6, 5, 6, 5)
        MaximizeBox = False
        Name = "frmEditor_Map"
        Text = "Map Editor"
        pnlBack.ResumeLayout(False)
        CType(picBackSelect, ComponentModel.ISupportInitialize).EndInit()
        pnlAttributes.ResumeLayout(False)
        fraMapLight.ResumeLayout(False)
        fraMapLight.PerformLayout()
        fraAnimation.ResumeLayout(False)
        fraMapWarp.ResumeLayout(False)
        fraMapWarp.PerformLayout()
        fraNpcSpawn.ResumeLayout(False)
        fraNpcSpawn.PerformLayout()
        fraHeal.ResumeLayout(False)
        fraHeal.PerformLayout()
        fraShop.ResumeLayout(False)
        fraResource.ResumeLayout(False)
        fraResource.PerformLayout()
        fraMapItem.ResumeLayout(False)
        fraMapItem.PerformLayout()
        CType(picMapItem, ComponentModel.ISupportInitialize).EndInit()
        fraTrap.ResumeLayout(False)
        fraTrap.PerformLayout()
        ToolStrip.ResumeLayout(False)
        ToolStrip.PerformLayout()
        tabpages.ResumeLayout(False)
        tpTiles.ResumeLayout(False)
        tpTiles.PerformLayout()
        tpAttributes.ResumeLayout(False)
        tpAttributes.PerformLayout()
        tpNpcs.ResumeLayout(False)
        fraNpcs.ResumeLayout(False)
        fraNpcs.PerformLayout()
        tpSettings.ResumeLayout(False)
        tpSettings.PerformLayout()
        fraMapSettings.ResumeLayout(False)
        fraMapSettings.PerformLayout()
        fraMapLinks.ResumeLayout(False)
        fraMapLinks.PerformLayout()
        fraBootSettings.ResumeLayout(False)
        fraBootSettings.PerformLayout()
        fraMaxSizes.ResumeLayout(False)
        fraMaxSizes.PerformLayout()
        GroupBox2.ResumeLayout(False)
        tpDirBlock.ResumeLayout(False)
        tpDirBlock.PerformLayout()
        tpEvents.ResumeLayout(False)
        tpEvents.PerformLayout()
        tpEffects.ResumeLayout(False)
        GroupBox6.ResumeLayout(False)
        GroupBox6.PerformLayout()
        GroupBox5.ResumeLayout(False)
        GroupBox5.PerformLayout()
        GroupBox4.ResumeLayout(False)
        GroupBox4.PerformLayout()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents pnlBack As System.Windows.Forms.Panel
    Friend WithEvents optTrap As System.Windows.Forms.RadioButton
    Friend WithEvents optHeal As System.Windows.Forms.RadioButton
    Friend WithEvents optBank As System.Windows.Forms.RadioButton
    Friend WithEvents optShop As System.Windows.Forms.RadioButton
    Friend WithEvents optNPCSpawn As System.Windows.Forms.RadioButton
    Friend WithEvents optResource As System.Windows.Forms.RadioButton
    Friend WithEvents optNPCAvoid As System.Windows.Forms.RadioButton
    Friend WithEvents optItem As System.Windows.Forms.RadioButton
    Friend WithEvents optWarp As System.Windows.Forms.RadioButton
    Friend WithEvents optBlocked As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClearAttribute As System.Windows.Forms.Button
    Friend WithEvents pnlAttributes As System.Windows.Forms.Panel
    Friend WithEvents fraMapWarp As System.Windows.Forms.GroupBox
    Friend WithEvents lblMapWarpY As System.Windows.Forms.Label
    Friend WithEvents lblMapWarpX As System.Windows.Forms.Label
    Friend WithEvents lblMapWarpMap As System.Windows.Forms.Label
    Friend WithEvents scrlMapWarpY As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlMapWarpX As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlMapWarpMap As System.Windows.Forms.HScrollBar
    Friend WithEvents btnMapWarp As System.Windows.Forms.Button
    Friend WithEvents fraMapItem As System.Windows.Forms.GroupBox
    Friend WithEvents btnMapItem As System.Windows.Forms.Button
    Friend WithEvents scrlMapItemValue As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlMapItem As System.Windows.Forms.HScrollBar
    Friend WithEvents lblMapItem As System.Windows.Forms.Label
    Friend WithEvents picMapItem As System.Windows.Forms.PictureBox
    Friend WithEvents fraResource As System.Windows.Forms.GroupBox
    Friend WithEvents btnResourceOk As System.Windows.Forms.Button
    Friend WithEvents scrlResource As System.Windows.Forms.HScrollBar
    Friend WithEvents lblResource As System.Windows.Forms.Label
    Friend WithEvents fraNpcSpawn As System.Windows.Forms.GroupBox
    Friend WithEvents btnNpcSpawn As System.Windows.Forms.Button
    Friend WithEvents scrlNpcDir As System.Windows.Forms.HScrollBar
    Friend WithEvents lblNpcDir As System.Windows.Forms.Label
    Friend WithEvents lstNpc As System.Windows.Forms.ComboBox
    Friend WithEvents fraShop As System.Windows.Forms.GroupBox
    Friend WithEvents cmbShop As System.Windows.Forms.ComboBox
    Friend WithEvents btnShop As System.Windows.Forms.Button
    Friend WithEvents fraHeal As System.Windows.Forms.GroupBox
    Friend WithEvents lblHeal As System.Windows.Forms.Label
    Friend WithEvents cmbHeal As System.Windows.Forms.ComboBox
    Friend WithEvents btnHeal As System.Windows.Forms.Button
    Friend WithEvents scrlHeal As System.Windows.Forms.HScrollBar
    Friend WithEvents fraTrap As System.Windows.Forms.GroupBox
    Friend WithEvents btnTrap As System.Windows.Forms.Button
    Friend WithEvents scrlTrap As System.Windows.Forms.HScrollBar
    Friend WithEvents lblTrap As System.Windows.Forms.Label
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDiscard As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabpages As System.Windows.Forms.TabControl
    Friend WithEvents tpTiles As System.Windows.Forms.TabPage
    Friend WithEvents tpNpcs As System.Windows.Forms.TabPage
    Friend WithEvents tpSettings As System.Windows.Forms.TabPage
    Friend WithEvents fraNpcs As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox23 As System.Windows.Forms.ComboBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents fraMapLinks As System.Windows.Forms.GroupBox
    Friend WithEvents txtDown As System.Windows.Forms.TextBox
    Friend WithEvents txtLeft As System.Windows.Forms.TextBox
    Friend WithEvents lblMap As System.Windows.Forms.Label
    Friend WithEvents txtRight As System.Windows.Forms.TextBox
    Friend WithEvents txtUp As System.Windows.Forms.TextBox
    Friend WithEvents fraBootSettings As System.Windows.Forms.GroupBox
    Friend WithEvents txtBootMap As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBootY As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBootX As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents fraMaxSizes As System.Windows.Forms.GroupBox
    Friend WithEvents txtMaxY As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMaxX As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lstMusic As System.Windows.Forms.ListBox
    Friend WithEvents fraMapSettings As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lstMoral As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbNpcList As System.Windows.Forms.ComboBox
    Friend WithEvents lstMapNpc As System.Windows.Forms.ListBox
    Friend WithEvents tpAttributes As System.Windows.Forms.TabPage
    Friend WithEvents cmbTileSets As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAutoTile As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbLayers As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tpDirBlock As System.Windows.Forms.TabPage
    Friend WithEvents tpEvents As System.Windows.Forms.TabPage
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tsbMapGrid As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents tsbFill As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEyeDropper As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents optLight As System.Windows.Forms.RadioButton
    Friend WithEvents btnPasteEvent As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnCopyEvent As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblPasteMode As System.Windows.Forms.Label
    Friend WithEvents lblCopyMode As System.Windows.Forms.Label
    Friend WithEvents tpEffects As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkTint As System.Windows.Forms.CheckBox
    Friend WithEvents lblMapAlpha As System.Windows.Forms.Label
    Friend WithEvents lblMapBlue As System.Windows.Forms.Label
    Friend WithEvents lblMapGreen As System.Windows.Forms.Label
    Friend WithEvents lblMapRed As System.Windows.Forms.Label
    Friend WithEvents scrlMapAlpha As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlMapBlue As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlMapGreen As System.Windows.Forms.HScrollBar
    Friend WithEvents scrlMapRed As System.Windows.Forms.HScrollBar
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents scrlFogOpacity As System.Windows.Forms.HScrollBar
    Friend WithEvents lblFogOpacity As System.Windows.Forms.Label
    Friend WithEvents scrlFogSpeed As System.Windows.Forms.HScrollBar
    Friend WithEvents lblFogSpeed As System.Windows.Forms.Label
    Friend WithEvents scrlIntensity As System.Windows.Forms.HScrollBar
    Friend WithEvents lblIntensity As System.Windows.Forms.Label
    Friend WithEvents scrlFog As System.Windows.Forms.HScrollBar
    Friend WithEvents lblFogIndex As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbWeather As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmbParallax As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbPanorama As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents lblMapBrightness As Label
    Friend WithEvents scrlMapBrightness As HScrollBar
    Friend WithEvents picBackSelect As PictureBox
    Friend WithEvents tsbClear As ToolStripButton
    Friend WithEvents tsbCopyMap As ToolStripButton
    Friend WithEvents tsbUndo As ToolStripButton
    Friend WithEvents tsbRedo As ToolStripButton
    Friend WithEvents tsbOpacity As ToolStripButton
    Friend WithEvents tsbLight As ToolStripButton
    Friend WithEvents tsbScreenshot As ToolStripButton
    Friend WithEvents optAnimation As RadioButton
    Friend WithEvents fraAnimation As GroupBox
    Friend WithEvents cmbAnimation As ComboBox
    Friend WithEvents brnAnimation As Button
    Friend WithEvents fraMapLight As GroupBox
    Friend WithEvents btnLight As Button
    Friend WithEvents scrlLight As HScrollBar
    Friend WithEvents chkShadow As CheckBox
    Friend WithEvents chkFlicker As CheckBox
    Friend WithEvents Label21 As Label
    Friend WithEvents lblRadius As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents lstShop As ComboBox
    Friend WithEvents chkNoMapRespawn As CheckBox
    Friend WithEvents chkIndoors As CheckBox
    Friend WithEvents Label23 As Label
    Friend WithEvents cmbAttribute As ComboBox
    Friend WithEvents tsbDeleteMap As ToolStripButton
    Friend WithEvents optInfo As RadioButton
    Friend WithEvents optNoXing As RadioButton
End Class
