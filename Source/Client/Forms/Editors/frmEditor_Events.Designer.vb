Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditor_Events
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim TreeNode1 As TreeNode = New TreeNode("Show Text")
        Dim TreeNode2 As TreeNode = New TreeNode("Show Choices")
        Dim TreeNode3 As TreeNode = New TreeNode("Add Chatbox Text")
        Dim TreeNode4 As TreeNode = New TreeNode("Show ChatBubble")
        Dim TreeNode5 As TreeNode = New TreeNode("Messages", New TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4})
        Dim TreeNode6 As TreeNode = New TreeNode("Set Player Variable")
        Dim TreeNode7 As TreeNode = New TreeNode("Set Player Switch")
        Dim TreeNode8 As TreeNode = New TreeNode("Set Self Switch")
        Dim TreeNode9 As TreeNode = New TreeNode("Event Processing", New TreeNode() {TreeNode6, TreeNode7, TreeNode8})
        Dim TreeNode10 As TreeNode = New TreeNode("Conditional Branch")
        Dim TreeNode11 As TreeNode = New TreeNode("Stop Event Processing")
        Dim TreeNode12 As TreeNode = New TreeNode("Label")
        Dim TreeNode13 As TreeNode = New TreeNode("GoTo Label")
        Dim TreeNode14 As TreeNode = New TreeNode("Flow Control", New TreeNode() {TreeNode10, TreeNode11, TreeNode12, TreeNode13})
        Dim TreeNode15 As TreeNode = New TreeNode("Change Items")
        Dim TreeNode16 As TreeNode = New TreeNode("Restore HP")
        Dim TreeNode17 As TreeNode = New TreeNode("Restore MP")
        Dim TreeNode18 As TreeNode = New TreeNode("Level Up")
        Dim TreeNode19 As TreeNode = New TreeNode("Change Level")
        Dim TreeNode20 As TreeNode = New TreeNode("Change Skills")
        Dim TreeNode21 As TreeNode = New TreeNode("Change Job")
        Dim TreeNode22 As TreeNode = New TreeNode("Change Sprite")
        Dim TreeNode23 As TreeNode = New TreeNode("Change Gender")
        Dim TreeNode24 As TreeNode = New TreeNode("Change PK")
        Dim TreeNode25 As TreeNode = New TreeNode("Give Experience")
        Dim TreeNode26 As TreeNode = New TreeNode("Player Options", New TreeNode() {TreeNode15, TreeNode16, TreeNode17, TreeNode18, TreeNode19, TreeNode20, TreeNode21, TreeNode22, TreeNode23, TreeNode24, TreeNode25})
        Dim TreeNode27 As TreeNode = New TreeNode("Warp Player")
        Dim TreeNode28 As TreeNode = New TreeNode("Set Move Route")
        Dim TreeNode29 As TreeNode = New TreeNode("Wait for Route Completion")
        Dim TreeNode30 As TreeNode = New TreeNode("Force Spawn Npc")
        Dim TreeNode31 As TreeNode = New TreeNode("Hold Player")
        Dim TreeNode32 As TreeNode = New TreeNode("Release Player")
        Dim TreeNode33 As TreeNode = New TreeNode("Movement", New TreeNode() {TreeNode27, TreeNode28, TreeNode29, TreeNode30, TreeNode31, TreeNode32})
        Dim TreeNode34 As TreeNode = New TreeNode("Animation")
        Dim TreeNode35 As TreeNode = New TreeNode("Animation", New TreeNode() {TreeNode34})
        Dim TreeNode36 As TreeNode = New TreeNode("Begin Quest")
        Dim TreeNode37 As TreeNode = New TreeNode("Complete Task")
        Dim TreeNode38 As TreeNode = New TreeNode("End Quest")
        Dim TreeNode39 As TreeNode = New TreeNode("Questing", New TreeNode() {TreeNode36, TreeNode37, TreeNode38})
        Dim TreeNode40 As TreeNode = New TreeNode("Set Fog")
        Dim TreeNode41 As TreeNode = New TreeNode("Set Weather")
        Dim TreeNode42 As TreeNode = New TreeNode("Set Map Tinting")
        Dim TreeNode43 As TreeNode = New TreeNode("Map Functions", New TreeNode() {TreeNode40, TreeNode41, TreeNode42})
        Dim TreeNode44 As TreeNode = New TreeNode("Play BGM")
        Dim TreeNode45 As TreeNode = New TreeNode("Stop BGM")
        Dim TreeNode46 As TreeNode = New TreeNode("Play Sound")
        Dim TreeNode47 As TreeNode = New TreeNode("Stop Sounds")
        Dim TreeNode48 As TreeNode = New TreeNode("Music and Sound", New TreeNode() {TreeNode44, TreeNode45, TreeNode46, TreeNode47})
        Dim TreeNode49 As TreeNode = New TreeNode("Wait...")
        Dim TreeNode50 As TreeNode = New TreeNode("Set Access")
        Dim TreeNode51 As TreeNode = New TreeNode("Custom Script")
        Dim TreeNode52 As TreeNode = New TreeNode("Etc...", New TreeNode() {TreeNode49, TreeNode50, TreeNode51})
        Dim TreeNode53 As TreeNode = New TreeNode("Open Bank")
        Dim TreeNode54 As TreeNode = New TreeNode("Open Shop")
        Dim TreeNode55 As TreeNode = New TreeNode("Shop and Bank", New TreeNode() {TreeNode53, TreeNode54})
        Dim TreeNode56 As TreeNode = New TreeNode("Fade In")
        Dim TreeNode57 As TreeNode = New TreeNode("Fade Out")
        Dim TreeNode58 As TreeNode = New TreeNode("Flash White")
        Dim TreeNode59 As TreeNode = New TreeNode("Show Picture")
        Dim TreeNode60 As TreeNode = New TreeNode("Hide Picture")
        Dim TreeNode61 As TreeNode = New TreeNode("Cutscene Options", New TreeNode() {TreeNode56, TreeNode57, TreeNode58, TreeNode59, TreeNode60})
        Dim ListViewGroup1 As ListViewGroup = New ListViewGroup("Movement", HorizontalAlignment.Left)
        Dim ListViewGroup2 As ListViewGroup = New ListViewGroup("Wait", HorizontalAlignment.Left)
        Dim ListViewGroup3 As ListViewGroup = New ListViewGroup("Turning", HorizontalAlignment.Left)
        Dim ListViewGroup4 As ListViewGroup = New ListViewGroup("Speed", HorizontalAlignment.Left)
        Dim ListViewGroup5 As ListViewGroup = New ListViewGroup("Walk Animation", HorizontalAlignment.Left)
        Dim ListViewGroup6 As ListViewGroup = New ListViewGroup("Fixed Direction", HorizontalAlignment.Left)
        Dim ListViewGroup7 As ListViewGroup = New ListViewGroup("WalkThrough", HorizontalAlignment.Left)
        Dim ListViewGroup8 As ListViewGroup = New ListViewGroup("Set Position", HorizontalAlignment.Left)
        Dim ListViewGroup9 As ListViewGroup = New ListViewGroup("Set Graphic", HorizontalAlignment.Left)
        Dim ListViewItem1 As ListViewItem = New ListViewItem("Move Up")
        Dim ListViewItem2 As ListViewItem = New ListViewItem("Move Down")
        Dim ListViewItem3 As ListViewItem = New ListViewItem("Move left")
        Dim ListViewItem4 As ListViewItem = New ListViewItem("Move Right")
        Dim ListViewItem5 As ListViewItem = New ListViewItem("Move Randomly")
        Dim ListViewItem6 As ListViewItem = New ListViewItem("Move To Player***")
        Dim ListViewItem7 As ListViewItem = New ListViewItem("Move from Player***")
        Dim ListViewItem8 As ListViewItem = New ListViewItem("Step Forwards")
        Dim ListViewItem9 As ListViewItem = New ListViewItem("Step Backwards")
        Dim ListViewItem10 As ListViewItem = New ListViewItem("Wait 100Ms")
        Dim ListViewItem11 As ListViewItem = New ListViewItem("Wait 500Ms")
        Dim ListViewItem12 As ListViewItem = New ListViewItem("Wait 1000Ms")
        Dim ListViewItem13 As ListViewItem = New ListViewItem("Turn Up")
        Dim ListViewItem14 As ListViewItem = New ListViewItem("Turn Down")
        Dim ListViewItem15 As ListViewItem = New ListViewItem("Turn Left")
        Dim ListViewItem16 As ListViewItem = New ListViewItem("Turn Right")
        Dim ListViewItem17 As ListViewItem = New ListViewItem("Turn 90DG Right")
        Dim ListViewItem18 As ListViewItem = New ListViewItem("Turn 90DG Left")
        Dim ListViewItem19 As ListViewItem = New ListViewItem("Turn 180DG")
        Dim ListViewItem20 As ListViewItem = New ListViewItem("Turn Randomly")
        Dim ListViewItem21 As ListViewItem = New ListViewItem("Turn To Player***")
        Dim ListViewItem22 As ListViewItem = New ListViewItem("Turn From Player***")
        Dim ListViewItem23 As ListViewItem = New ListViewItem("Set Speed 8x Slower")
        Dim ListViewItem24 As ListViewItem = New ListViewItem("Set Speed 4x Slower")
        Dim ListViewItem25 As ListViewItem = New ListViewItem("Set Speed 2x Slower")
        Dim ListViewItem26 As ListViewItem = New ListViewItem("Set Speed To Normal")
        Dim ListViewItem27 As ListViewItem = New ListViewItem("Set Speed 2x Faster")
        Dim ListViewItem28 As ListViewItem = New ListViewItem("Set Speed 4x Faster")
        Dim ListViewItem29 As ListViewItem = New ListViewItem("Set Freq. To Lowest")
        Dim ListViewItem30 As ListViewItem = New ListViewItem("Set Freq. To Lower")
        Dim ListViewItem31 As ListViewItem = New ListViewItem("Set Freq. To Normal")
        Dim ListViewItem32 As ListViewItem = New ListViewItem("Set Freq. To Higher")
        Dim ListViewItem33 As ListViewItem = New ListViewItem("Set Freq. To Highest")
        Dim ListViewItem34 As ListViewItem = New ListViewItem("Walking Animation ON")
        Dim ListViewItem35 As ListViewItem = New ListViewItem("Walking Animation OFF")
        Dim ListViewItem36 As ListViewItem = New ListViewItem("Fixed Direction ON")
        Dim ListViewItem37 As ListViewItem = New ListViewItem("Fixed Direction OFF")
        Dim ListViewItem38 As ListViewItem = New ListViewItem("Walkthrough ON")
        Dim ListViewItem39 As ListViewItem = New ListViewItem("Walkthrough ON")
        Dim ListViewItem40 As ListViewItem = New ListViewItem("Set Position Below Player")
        Dim ListViewItem41 As ListViewItem = New ListViewItem("Set PositionWith Player")
        Dim ListViewItem42 As ListViewItem = New ListViewItem("Set Position Above Player")
        Dim ListViewItem43 As ListViewItem = New ListViewItem("Set Graphic...")
        tvCommands = New TreeView()
        fraPageSetUp = New DarkUI.Controls.DarkGroupBox()
        chkGlobal = New DarkUI.Controls.DarkCheckBox()
        btnClearPage = New DarkUI.Controls.DarkButton()
        btnDeletePage = New DarkUI.Controls.DarkButton()
        btnPastePage = New DarkUI.Controls.DarkButton()
        btnCopyPage = New DarkUI.Controls.DarkButton()
        btnNewPage = New DarkUI.Controls.DarkButton()
        txtName = New DarkUI.Controls.DarkTextBox()
        DarkLabel1 = New DarkUI.Controls.DarkLabel()
        tabPages = New TabControl()
        TabPage1 = New TabPage()
        pnlTabPage = New Panel()
        DarkGroupBox2 = New DarkUI.Controls.DarkGroupBox()
        cmbPositioning = New DarkUI.Controls.DarkComboBox()
        fraGraphicPic = New DarkUI.Controls.DarkGroupBox()
        picGraphic = New PictureBox()
        DarkGroupBox6 = New DarkUI.Controls.DarkGroupBox()
        chkShowName = New DarkUI.Controls.DarkCheckBox()
        chkWalkThrough = New DarkUI.Controls.DarkCheckBox()
        chkDirFix = New DarkUI.Controls.DarkCheckBox()
        chkWalkAnim = New DarkUI.Controls.DarkCheckBox()
        DarkGroupBox5 = New DarkUI.Controls.DarkGroupBox()
        cmbTrigger = New DarkUI.Controls.DarkComboBox()
        DarkGroupBox4 = New DarkUI.Controls.DarkGroupBox()
        picGraphicSel = New PictureBox()
        DarkGroupBox3 = New DarkUI.Controls.DarkGroupBox()
        DarkLabel7 = New DarkUI.Controls.DarkLabel()
        cmbMoveFreq = New DarkUI.Controls.DarkComboBox()
        DarkLabel6 = New DarkUI.Controls.DarkLabel()
        cmbMoveSpeed = New DarkUI.Controls.DarkComboBox()
        btnMoveRoute = New DarkUI.Controls.DarkButton()
        cmbMoveType = New DarkUI.Controls.DarkComboBox()
        DarkLabel5 = New DarkUI.Controls.DarkLabel()
        DarkGroupBox1 = New DarkUI.Controls.DarkGroupBox()
        cmbSelfSwitchCompare = New DarkUI.Controls.DarkComboBox()
        DarkLabel4 = New DarkUI.Controls.DarkLabel()
        cmbSelfSwitch = New DarkUI.Controls.DarkComboBox()
        chkSelfSwitch = New DarkUI.Controls.DarkCheckBox()
        cmbHasItem = New DarkUI.Controls.DarkComboBox()
        chkHasItem = New DarkUI.Controls.DarkCheckBox()
        cmbPlayerSwitchCompare = New DarkUI.Controls.DarkComboBox()
        DarkLabel3 = New DarkUI.Controls.DarkLabel()
        cmbPlayerSwitch = New DarkUI.Controls.DarkComboBox()
        chkPlayerSwitch = New DarkUI.Controls.DarkCheckBox()
        nudPlayerVariable = New DarkUI.Controls.DarkNumericUpDown()
        cmbPlayervarCompare = New DarkUI.Controls.DarkComboBox()
        DarkLabel2 = New DarkUI.Controls.DarkLabel()
        cmbPlayerVar = New DarkUI.Controls.DarkComboBox()
        chkPlayerVar = New DarkUI.Controls.DarkCheckBox()
        DarkGroupBox8 = New DarkUI.Controls.DarkGroupBox()
        btnClearCommand = New DarkUI.Controls.DarkButton()
        btnDeleteCommand = New DarkUI.Controls.DarkButton()
        btnEditCommand = New DarkUI.Controls.DarkButton()
        btnAddCommand = New DarkUI.Controls.DarkButton()
        fraGraphic = New DarkUI.Controls.DarkGroupBox()
        btnGraphicOk = New DarkUI.Controls.DarkButton()
        btnGraphicCancel = New DarkUI.Controls.DarkButton()
        DarkLabel13 = New DarkUI.Controls.DarkLabel()
        nudGraphic = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel12 = New DarkUI.Controls.DarkLabel()
        cmbGraphic = New DarkUI.Controls.DarkComboBox()
        DarkLabel11 = New DarkUI.Controls.DarkLabel()
        fraCommands = New Panel()
        btnCancelCommand = New DarkUI.Controls.DarkButton()
        lstCommands = New ListBox()
        btnLabeling = New DarkUI.Controls.DarkButton()
        btnCancel = New DarkUI.Controls.DarkButton()
        btnOk = New DarkUI.Controls.DarkButton()
        fraMoveRoute = New DarkUI.Controls.DarkGroupBox()
        btnMoveRouteOk = New DarkUI.Controls.DarkButton()
        btnMoveRouteCancel = New DarkUI.Controls.DarkButton()
        chkRepeatRoute = New DarkUI.Controls.DarkCheckBox()
        chkIgnoreMove = New DarkUI.Controls.DarkCheckBox()
        DarkGroupBox10 = New DarkUI.Controls.DarkGroupBox()
        lstvwMoveRoute = New ListView()
        ColumnHeader3 = New ColumnHeader()
        ColumnHeader4 = New ColumnHeader()
        lstMoveRoute = New ListBox()
        cmbEvent = New DarkUI.Controls.DarkComboBox()
        pnlGraphicSel = New Panel()
        fraDialogue = New DarkUI.Controls.DarkGroupBox()
        fraShowChatBubble = New DarkUI.Controls.DarkGroupBox()
        btnShowChatBubbleOk = New DarkUI.Controls.DarkButton()
        btnShowChatBubbleCancel = New DarkUI.Controls.DarkButton()
        DarkLabel41 = New DarkUI.Controls.DarkLabel()
        cmbChatBubbleTarget = New DarkUI.Controls.DarkComboBox()
        cmbChatBubbleTargetType = New DarkUI.Controls.DarkComboBox()
        DarkLabel40 = New DarkUI.Controls.DarkLabel()
        txtChatbubbleText = New DarkUI.Controls.DarkTextBox()
        DarkLabel39 = New DarkUI.Controls.DarkLabel()
        fraOpenShop = New DarkUI.Controls.DarkGroupBox()
        btnOpenShopOk = New DarkUI.Controls.DarkButton()
        btnOpenShopCancel = New DarkUI.Controls.DarkButton()
        cmbOpenShop = New DarkUI.Controls.DarkComboBox()
        fraSetSelfSwitch = New DarkUI.Controls.DarkGroupBox()
        btnSelfswitchOk = New DarkUI.Controls.DarkButton()
        btnSelfswitchCancel = New DarkUI.Controls.DarkButton()
        DarkLabel47 = New DarkUI.Controls.DarkLabel()
        cmbSetSelfSwitchTo = New DarkUI.Controls.DarkComboBox()
        DarkLabel46 = New DarkUI.Controls.DarkLabel()
        cmbSetSelfSwitch = New DarkUI.Controls.DarkComboBox()
        fraPlaySound = New DarkUI.Controls.DarkGroupBox()
        btnPlaySoundOk = New DarkUI.Controls.DarkButton()
        btnPlaySoundCancel = New DarkUI.Controls.DarkButton()
        cmbPlaySound = New DarkUI.Controls.DarkComboBox()
        fraChangePK = New DarkUI.Controls.DarkGroupBox()
        btnChangePkOk = New DarkUI.Controls.DarkButton()
        btnChangePkCancel = New DarkUI.Controls.DarkButton()
        cmbSetPK = New DarkUI.Controls.DarkComboBox()
        fraCreateLabel = New DarkUI.Controls.DarkGroupBox()
        btnCreatelabelOk = New DarkUI.Controls.DarkButton()
        btnCreatelabelCancel = New DarkUI.Controls.DarkButton()
        txtLabelName = New DarkUI.Controls.DarkTextBox()
        lblLabelName = New DarkUI.Controls.DarkLabel()
        fraChangeJob = New DarkUI.Controls.DarkGroupBox()
        btnChangeJobOk = New DarkUI.Controls.DarkButton()
        btnChangeJobCancel = New DarkUI.Controls.DarkButton()
        cmbChangeJob = New DarkUI.Controls.DarkComboBox()
        DarkLabel38 = New DarkUI.Controls.DarkLabel()
        fraChangeSkills = New DarkUI.Controls.DarkGroupBox()
        btnChangeSkillsOk = New DarkUI.Controls.DarkButton()
        btnChangeSkillsCancel = New DarkUI.Controls.DarkButton()
        optChangeSkillsRemove = New DarkUI.Controls.DarkRadioButton()
        optChangeSkillsAdd = New DarkUI.Controls.DarkRadioButton()
        cmbChangeSkills = New DarkUI.Controls.DarkComboBox()
        DarkLabel37 = New DarkUI.Controls.DarkLabel()
        fraPlayerSwitch = New DarkUI.Controls.DarkGroupBox()
        btnSetPlayerSwitchOk = New DarkUI.Controls.DarkButton()
        btnSetPlayerswitchCancel = New DarkUI.Controls.DarkButton()
        cmbPlayerSwitchSet = New DarkUI.Controls.DarkComboBox()
        DarkLabel23 = New DarkUI.Controls.DarkLabel()
        cmbSwitch = New DarkUI.Controls.DarkComboBox()
        DarkLabel22 = New DarkUI.Controls.DarkLabel()
        fraSetWait = New DarkUI.Controls.DarkGroupBox()
        btnSetWaitOk = New DarkUI.Controls.DarkButton()
        btnSetWaitCancel = New DarkUI.Controls.DarkButton()
        DarkLabel74 = New DarkUI.Controls.DarkLabel()
        DarkLabel72 = New DarkUI.Controls.DarkLabel()
        DarkLabel73 = New DarkUI.Controls.DarkLabel()
        nudWaitAmount = New DarkUI.Controls.DarkNumericUpDown()
        fraMoveRouteWait = New DarkUI.Controls.DarkGroupBox()
        btnMoveWaitCancel = New DarkUI.Controls.DarkButton()
        btnMoveWaitOk = New DarkUI.Controls.DarkButton()
        DarkLabel79 = New DarkUI.Controls.DarkLabel()
        cmbMoveWait = New DarkUI.Controls.DarkComboBox()
        fraCustomScript = New DarkUI.Controls.DarkGroupBox()
        nudCustomScript = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel78 = New DarkUI.Controls.DarkLabel()
        btnCustomScriptCancel = New DarkUI.Controls.DarkButton()
        btnCustomScriptOk = New DarkUI.Controls.DarkButton()
        fraSpawnNpc = New DarkUI.Controls.DarkGroupBox()
        btnSpawnNpcOk = New DarkUI.Controls.DarkButton()
        btnSpawnNpcCancel = New DarkUI.Controls.DarkButton()
        cmbSpawnNpc = New DarkUI.Controls.DarkComboBox()
        fraSetWeather = New DarkUI.Controls.DarkGroupBox()
        btnSetWeatherOk = New DarkUI.Controls.DarkButton()
        btnSetWeatherCancel = New DarkUI.Controls.DarkButton()
        DarkLabel76 = New DarkUI.Controls.DarkLabel()
        nudWeatherIntensity = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel75 = New DarkUI.Controls.DarkLabel()
        CmbWeather = New DarkUI.Controls.DarkComboBox()
        fraGiveExp = New DarkUI.Controls.DarkGroupBox()
        btnGiveExpOk = New DarkUI.Controls.DarkButton()
        btnGiveExpCancel = New DarkUI.Controls.DarkButton()
        nudGiveExp = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel77 = New DarkUI.Controls.DarkLabel()
        fraSetAccess = New DarkUI.Controls.DarkGroupBox()
        btnSetAccessOk = New DarkUI.Controls.DarkButton()
        btnSetAccessCancel = New DarkUI.Controls.DarkButton()
        cmbSetAccess = New DarkUI.Controls.DarkComboBox()
        fraChangeGender = New DarkUI.Controls.DarkGroupBox()
        btnChangeGenderOk = New DarkUI.Controls.DarkButton()
        btnChangeGenderCancel = New DarkUI.Controls.DarkButton()
        optChangeSexFemale = New DarkUI.Controls.DarkRadioButton()
        optChangeSexMale = New DarkUI.Controls.DarkRadioButton()
        fraShowChoices = New DarkUI.Controls.DarkGroupBox()
        txtChoices4 = New DarkUI.Controls.DarkTextBox()
        txtChoices3 = New DarkUI.Controls.DarkTextBox()
        txtChoices2 = New DarkUI.Controls.DarkTextBox()
        txtChoices1 = New DarkUI.Controls.DarkTextBox()
        DarkLabel56 = New DarkUI.Controls.DarkLabel()
        DarkLabel57 = New DarkUI.Controls.DarkLabel()
        DarkLabel55 = New DarkUI.Controls.DarkLabel()
        DarkLabel54 = New DarkUI.Controls.DarkLabel()
        DarkLabel52 = New DarkUI.Controls.DarkLabel()
        txtChoicePrompt = New DarkUI.Controls.DarkTextBox()
        btnShowChoicesOk = New DarkUI.Controls.DarkButton()
        btnShowChoicesCancel = New DarkUI.Controls.DarkButton()
        fraChangeLevel = New DarkUI.Controls.DarkGroupBox()
        btnChangeLevelOk = New DarkUI.Controls.DarkButton()
        btnChangeLevelCancel = New DarkUI.Controls.DarkButton()
        DarkLabel65 = New DarkUI.Controls.DarkLabel()
        nudChangeLevel = New DarkUI.Controls.DarkNumericUpDown()
        fraPlayerVariable = New DarkUI.Controls.DarkGroupBox()
        nudVariableData2 = New DarkUI.Controls.DarkNumericUpDown()
        optVariableAction2 = New DarkUI.Controls.DarkRadioButton()
        btnPlayerVarOk = New DarkUI.Controls.DarkButton()
        btnPlayerVarCancel = New DarkUI.Controls.DarkButton()
        DarkLabel51 = New DarkUI.Controls.DarkLabel()
        DarkLabel50 = New DarkUI.Controls.DarkLabel()
        nudVariableData4 = New DarkUI.Controls.DarkNumericUpDown()
        nudVariableData3 = New DarkUI.Controls.DarkNumericUpDown()
        optVariableAction3 = New DarkUI.Controls.DarkRadioButton()
        optVariableAction1 = New DarkUI.Controls.DarkRadioButton()
        nudVariableData1 = New DarkUI.Controls.DarkNumericUpDown()
        nudVariableData0 = New DarkUI.Controls.DarkNumericUpDown()
        optVariableAction0 = New DarkUI.Controls.DarkRadioButton()
        cmbVariable = New DarkUI.Controls.DarkComboBox()
        DarkLabel49 = New DarkUI.Controls.DarkLabel()
        fraPlayAnimation = New DarkUI.Controls.DarkGroupBox()
        btnPlayAnimationOk = New DarkUI.Controls.DarkButton()
        btnPlayAnimationCancel = New DarkUI.Controls.DarkButton()
        lblPlayAnimY = New DarkUI.Controls.DarkLabel()
        lblPlayAnimX = New DarkUI.Controls.DarkLabel()
        cmbPlayAnimEvent = New DarkUI.Controls.DarkComboBox()
        DarkLabel62 = New DarkUI.Controls.DarkLabel()
        cmbAnimTargetType = New DarkUI.Controls.DarkComboBox()
        nudPlayAnimTileY = New DarkUI.Controls.DarkNumericUpDown()
        nudPlayAnimTileX = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel61 = New DarkUI.Controls.DarkLabel()
        cmbPlayAnim = New DarkUI.Controls.DarkComboBox()
        fraChangeSprite = New DarkUI.Controls.DarkGroupBox()
        btnChangeSpriteOk = New DarkUI.Controls.DarkButton()
        btnChangeSpriteCancel = New DarkUI.Controls.DarkButton()
        DarkLabel48 = New DarkUI.Controls.DarkLabel()
        nudChangeSprite = New DarkUI.Controls.DarkNumericUpDown()
        picChangeSprite = New PictureBox()
        fraGoToLabel = New DarkUI.Controls.DarkGroupBox()
        btnGoToLabelOk = New DarkUI.Controls.DarkButton()
        btnGoToLabelCancel = New DarkUI.Controls.DarkButton()
        txtGotoLabel = New DarkUI.Controls.DarkTextBox()
        DarkLabel60 = New DarkUI.Controls.DarkLabel()
        fraMapTint = New DarkUI.Controls.DarkGroupBox()
        btnMapTintOk = New DarkUI.Controls.DarkButton()
        btnMapTintCancel = New DarkUI.Controls.DarkButton()
        DarkLabel42 = New DarkUI.Controls.DarkLabel()
        nudMapTintData3 = New DarkUI.Controls.DarkNumericUpDown()
        nudMapTintData2 = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel43 = New DarkUI.Controls.DarkLabel()
        DarkLabel44 = New DarkUI.Controls.DarkLabel()
        nudMapTintData1 = New DarkUI.Controls.DarkNumericUpDown()
        nudMapTintData0 = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel45 = New DarkUI.Controls.DarkLabel()
        fraShowPic = New DarkUI.Controls.DarkGroupBox()
        btnShowPicOk = New DarkUI.Controls.DarkButton()
        btnShowPicCancel = New DarkUI.Controls.DarkButton()
        DarkLabel71 = New DarkUI.Controls.DarkLabel()
        DarkLabel70 = New DarkUI.Controls.DarkLabel()
        DarkLabel67 = New DarkUI.Controls.DarkLabel()
        DarkLabel68 = New DarkUI.Controls.DarkLabel()
        nudPicOffsetY = New DarkUI.Controls.DarkNumericUpDown()
        nudPicOffsetX = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel69 = New DarkUI.Controls.DarkLabel()
        cmbPicLoc = New DarkUI.Controls.DarkComboBox()
        nudShowPicture = New DarkUI.Controls.DarkNumericUpDown()
        picShowPic = New PictureBox()
        fraConditionalBranch = New DarkUI.Controls.DarkGroupBox()
        cmbCondition_Time = New DarkUI.Controls.DarkComboBox()
        optCondition9 = New DarkUI.Controls.DarkRadioButton()
        btnConditionalBranchOk = New DarkUI.Controls.DarkButton()
        btnConditionalBranchCancel = New DarkUI.Controls.DarkButton()
        cmbCondition_Gender = New DarkUI.Controls.DarkComboBox()
        optCondition8 = New DarkUI.Controls.DarkRadioButton()
        cmbCondition_SelfSwitchCondition = New DarkUI.Controls.DarkComboBox()
        DarkLabel17 = New DarkUI.Controls.DarkLabel()
        cmbCondition_SelfSwitch = New DarkUI.Controls.DarkComboBox()
        optCondition6 = New DarkUI.Controls.DarkRadioButton()
        nudCondition_LevelAmount = New DarkUI.Controls.DarkNumericUpDown()
        optCondition5 = New DarkUI.Controls.DarkRadioButton()
        cmbCondition_LevelCompare = New DarkUI.Controls.DarkComboBox()
        cmbCondition_LearntSkill = New DarkUI.Controls.DarkComboBox()
        optCondition4 = New DarkUI.Controls.DarkRadioButton()
        cmbCondition_JobIs = New DarkUI.Controls.DarkComboBox()
        optCondition3 = New DarkUI.Controls.DarkRadioButton()
        nudCondition_HasItem = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel16 = New DarkUI.Controls.DarkLabel()
        cmbCondition_HasItem = New DarkUI.Controls.DarkComboBox()
        optCondition2 = New DarkUI.Controls.DarkRadioButton()
        optCondition1 = New DarkUI.Controls.DarkRadioButton()
        DarkLabel15 = New DarkUI.Controls.DarkLabel()
        cmbCondtion_PlayerSwitchCondition = New DarkUI.Controls.DarkComboBox()
        cmbCondition_PlayerSwitch = New DarkUI.Controls.DarkComboBox()
        nudCondition_PlayerVarCondition = New DarkUI.Controls.DarkNumericUpDown()
        cmbCondition_PlayerVarCompare = New DarkUI.Controls.DarkComboBox()
        DarkLabel14 = New DarkUI.Controls.DarkLabel()
        cmbCondition_PlayerVarIndex = New DarkUI.Controls.DarkComboBox()
        optCondition0 = New DarkUI.Controls.DarkRadioButton()
        fraPlayBGM = New DarkUI.Controls.DarkGroupBox()
        btnPlayBgmOk = New DarkUI.Controls.DarkButton()
        btnPlayBgmCancel = New DarkUI.Controls.DarkButton()
        cmbPlayBGM = New DarkUI.Controls.DarkComboBox()
        fraPlayerWarp = New DarkUI.Controls.DarkGroupBox()
        btnPlayerWarpOk = New DarkUI.Controls.DarkButton()
        btnPlayerWarpCancel = New DarkUI.Controls.DarkButton()
        DarkLabel31 = New DarkUI.Controls.DarkLabel()
        cmbWarpPlayerDir = New DarkUI.Controls.DarkComboBox()
        nudWPY = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel32 = New DarkUI.Controls.DarkLabel()
        nudWPX = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel33 = New DarkUI.Controls.DarkLabel()
        nudWPMap = New DarkUI.Controls.DarkNumericUpDown()
        DarkLabel34 = New DarkUI.Controls.DarkLabel()
        fraSetFog = New DarkUI.Controls.DarkGroupBox()
        btnSetFogOk = New DarkUI.Controls.DarkButton()
        btnSetFogCancel = New DarkUI.Controls.DarkButton()
        DarkLabel30 = New DarkUI.Controls.DarkLabel()
        DarkLabel29 = New DarkUI.Controls.DarkLabel()
        DarkLabel28 = New DarkUI.Controls.DarkLabel()
        nudFogData2 = New DarkUI.Controls.DarkNumericUpDown()
        nudFogData1 = New DarkUI.Controls.DarkNumericUpDown()
        nudFogData0 = New DarkUI.Controls.DarkNumericUpDown()
        fraShowText = New DarkUI.Controls.DarkGroupBox()
        DarkLabel27 = New DarkUI.Controls.DarkLabel()
        txtShowText = New DarkUI.Controls.DarkTextBox()
        btnShowTextCancel = New DarkUI.Controls.DarkButton()
        btnShowTextOk = New DarkUI.Controls.DarkButton()
        fraAddText = New DarkUI.Controls.DarkGroupBox()
        btnAddTextOk = New DarkUI.Controls.DarkButton()
        btnAddTextCancel = New DarkUI.Controls.DarkButton()
        optAddText_Global = New DarkUI.Controls.DarkRadioButton()
        optAddText_Map = New DarkUI.Controls.DarkRadioButton()
        optAddText_Player = New DarkUI.Controls.DarkRadioButton()
        DarkLabel25 = New DarkUI.Controls.DarkLabel()
        txtAddText_Text = New DarkUI.Controls.DarkTextBox()
        DarkLabel24 = New DarkUI.Controls.DarkLabel()
        fraChangeItems = New DarkUI.Controls.DarkGroupBox()
        btnChangeItemsOk = New DarkUI.Controls.DarkButton()
        btnChangeItemsCancel = New DarkUI.Controls.DarkButton()
        nudChangeItemsAmount = New DarkUI.Controls.DarkNumericUpDown()
        optChangeItemRemove = New DarkUI.Controls.DarkRadioButton()
        optChangeItemAdd = New DarkUI.Controls.DarkRadioButton()
        optChangeItemSet = New DarkUI.Controls.DarkRadioButton()
        cmbChangeItemIndex = New DarkUI.Controls.DarkComboBox()
        DarkLabel21 = New DarkUI.Controls.DarkLabel()
        pnlVariableSwitches = New Panel()
        FraRenaming = New GroupBox()
        btnRename_Cancel = New Button()
        btnRename_Ok = New Button()
        fraRandom10 = New GroupBox()
        txtRename = New TextBox()
        lblEditing = New Label()
        fraLabeling = New DarkUI.Controls.DarkGroupBox()
        lstSwitches = New ListBox()
        lstVariables = New ListBox()
        btnLabel_Cancel = New DarkUI.Controls.DarkButton()
        lblRandomLabel36 = New DarkUI.Controls.DarkLabel()
        btnRenameVariable = New DarkUI.Controls.DarkButton()
        lblRandomLabel25 = New DarkUI.Controls.DarkLabel()
        btnRenameSwitch = New DarkUI.Controls.DarkButton()
        btnLabel_Ok = New DarkUI.Controls.DarkButton()
        fraPageSetUp.SuspendLayout()
        tabPages.SuspendLayout()
        pnlTabPage.SuspendLayout()
        DarkGroupBox2.SuspendLayout()
        fraGraphicPic.SuspendLayout()
        CType(picGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        DarkGroupBox6.SuspendLayout()
        DarkGroupBox5.SuspendLayout()
        DarkGroupBox4.SuspendLayout()
        CType(picGraphicSel, System.ComponentModel.ISupportInitialize).BeginInit()
        DarkGroupBox3.SuspendLayout()
        DarkGroupBox1.SuspendLayout()
        CType(nudPlayerVariable, System.ComponentModel.ISupportInitialize).BeginInit()
        DarkGroupBox8.SuspendLayout()
        fraGraphic.SuspendLayout()
        CType(nudGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        fraCommands.SuspendLayout()
        fraMoveRoute.SuspendLayout()
        DarkGroupBox10.SuspendLayout()
        fraDialogue.SuspendLayout()
        fraShowChatBubble.SuspendLayout()
        fraOpenShop.SuspendLayout()
        fraSetSelfSwitch.SuspendLayout()
        fraPlaySound.SuspendLayout()
        fraChangePK.SuspendLayout()
        fraCreateLabel.SuspendLayout()
        fraChangeJob.SuspendLayout()
        fraChangeSkills.SuspendLayout()
        fraPlayerSwitch.SuspendLayout()
        fraSetWait.SuspendLayout()
        CType(nudWaitAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        fraMoveRouteWait.SuspendLayout()
        fraCustomScript.SuspendLayout()
        CType(nudCustomScript, System.ComponentModel.ISupportInitialize).BeginInit()
        fraSpawnNpc.SuspendLayout()
        fraSetWeather.SuspendLayout()
        CType(nudWeatherIntensity, System.ComponentModel.ISupportInitialize).BeginInit()
        fraGiveExp.SuspendLayout()
        CType(nudGiveExp, System.ComponentModel.ISupportInitialize).BeginInit()
        fraSetAccess.SuspendLayout()
        fraChangeGender.SuspendLayout()
        fraShowChoices.SuspendLayout()
        fraChangeLevel.SuspendLayout()
        CType(nudChangeLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        fraPlayerVariable.SuspendLayout()
        CType(nudVariableData2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(nudVariableData4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(nudVariableData3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(nudVariableData1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(nudVariableData0, System.ComponentModel.ISupportInitialize).BeginInit()
        fraPlayAnimation.SuspendLayout()
        CType(nudPlayAnimTileY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(nudPlayAnimTileX, System.ComponentModel.ISupportInitialize).BeginInit()
        fraChangeSprite.SuspendLayout()
        CType(nudChangeSprite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(picChangeSprite, System.ComponentModel.ISupportInitialize).BeginInit()
        fraGoToLabel.SuspendLayout()
        fraMapTint.SuspendLayout()
        CType(nudMapTintData3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(nudMapTintData2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(nudMapTintData1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(nudMapTintData0, System.ComponentModel.ISupportInitialize).BeginInit()
        fraShowPic.SuspendLayout()
        CType(nudPicOffsetY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(nudPicOffsetX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(nudShowPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(picShowPic, System.ComponentModel.ISupportInitialize).BeginInit()
        fraConditionalBranch.SuspendLayout()
        CType(nudCondition_LevelAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(nudCondition_HasItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(nudCondition_PlayerVarCondition, System.ComponentModel.ISupportInitialize).BeginInit()
        fraPlayBGM.SuspendLayout()
        fraPlayerWarp.SuspendLayout()
        CType(nudWPY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(nudWPX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(nudWPMap, System.ComponentModel.ISupportInitialize).BeginInit()
        fraSetFog.SuspendLayout()
        CType(nudFogData2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(nudFogData1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(nudFogData0, System.ComponentModel.ISupportInitialize).BeginInit()
        fraShowText.SuspendLayout()
        fraAddText.SuspendLayout()
        fraChangeItems.SuspendLayout()
        CType(nudChangeItemsAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        pnlVariableSwitches.SuspendLayout()
        FraRenaming.SuspendLayout()
        fraRandom10.SuspendLayout()
        fraLabeling.SuspendLayout()
        SuspendLayout()
        ' 
        ' tvCommands
        ' 
        tvCommands.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        tvCommands.BorderStyle = BorderStyle.FixedSingle
        tvCommands.ForeColor = Color.Gainsboro
        tvCommands.Location = New Point(10, 5)
        tvCommands.Margin = New Padding(5)
        tvCommands.Name = "tvCommands"
        TreeNode1.Name = "Node1"
        TreeNode1.Text = "Show Text"
        TreeNode2.Name = "Node2"
        TreeNode2.Text = "Show Choices"
        TreeNode3.Name = "Node3"
        TreeNode3.Text = "Add Chatbox Text"
        TreeNode4.Name = "Node5"
        TreeNode4.Text = "Show ChatBubble"
        TreeNode5.Name = "NodeMessages"
        TreeNode5.Text = "Messages"
        TreeNode6.Name = "Node1"
        TreeNode6.Text = "Set Player Variable"
        TreeNode7.Name = "Node2"
        TreeNode7.Text = "Set Player Switch"
        TreeNode8.Name = "Node3"
        TreeNode8.Text = "Set Self Switch"
        TreeNode9.Name = "NodeProcessing"
        TreeNode9.Text = "Event Processing"
        TreeNode10.Name = "Node1"
        TreeNode10.Text = "Conditional Branch"
        TreeNode11.Name = "Node2"
        TreeNode11.Text = "Stop Event Processing"
        TreeNode12.Name = "Node3"
        TreeNode12.Text = "Label"
        TreeNode13.Name = "Node4"
        TreeNode13.Text = "GoTo Label"
        TreeNode14.Name = "NodeFlowControl"
        TreeNode14.Text = "Flow Control"
        TreeNode15.Name = "Node1"
        TreeNode15.Text = "Change Items"
        TreeNode16.Name = "Node2"
        TreeNode16.Text = "Restore HP"
        TreeNode17.Name = "Node3"
        TreeNode17.Text = "Restore MP"
        TreeNode18.Name = "Node4"
        TreeNode18.Text = "Level Up"
        TreeNode19.Name = "Node5"
        TreeNode19.Text = "Change Level"
        TreeNode20.Name = "Node6"
        TreeNode20.Text = "Change Skills"
        TreeNode21.Name = "Node7"
        TreeNode21.Text = "Change Job"
        TreeNode22.Name = "Node8"
        TreeNode22.Text = "Change Sprite"
        TreeNode23.Name = "Node9"
        TreeNode23.Text = "Change Gender"
        TreeNode24.Name = "Node10"
        TreeNode24.Text = "Change PK"
        TreeNode25.Name = "Node11"
        TreeNode25.Text = "Give Experience"
        TreeNode26.Name = "NodePlayerOptions"
        TreeNode26.Text = "Player Options"
        TreeNode27.Name = "Node1"
        TreeNode27.Text = "Warp Player"
        TreeNode28.Name = "Node2"
        TreeNode28.Text = "Set Move Route"
        TreeNode29.Name = "Node3"
        TreeNode29.Text = "Wait for Route Completion"
        TreeNode30.Name = "Node4"
        TreeNode30.Text = "Force Spawn Npc"
        TreeNode31.Name = "Node5"
        TreeNode31.Text = "Hold Player"
        TreeNode32.Name = "Node6"
        TreeNode32.Text = "Release Player"
        TreeNode33.Name = "NodeMovement"
        TreeNode33.Text = "Movement"
        TreeNode34.Name = "Node1"
        TreeNode34.Text = "Animation"
        TreeNode35.Name = "NodeAnimation"
        TreeNode35.Text = "Animation"
        TreeNode36.Name = "Node1"
        TreeNode36.Text = "Begin Quest"
        TreeNode37.Name = "Node2"
        TreeNode37.Text = "Complete Task"
        TreeNode38.Name = "Node3"
        TreeNode38.Text = "End Quest"
        TreeNode39.Name = "NodeQuesting"
        TreeNode39.Text = "Questing"
        TreeNode40.Name = "Node1"
        TreeNode40.Text = "Set Fog"
        TreeNode41.Name = "Node2"
        TreeNode41.Text = "Set Weather"
        TreeNode42.Name = "Node3"
        TreeNode42.Text = "Set Map Tinting"
        TreeNode43.Name = "NodeMapFunctions"
        TreeNode43.Text = "Map Functions"
        TreeNode44.Name = "Node1"
        TreeNode44.Text = "Play BGM"
        TreeNode45.Name = "Node2"
        TreeNode45.Text = "Stop BGM"
        TreeNode46.Name = "Node3"
        TreeNode46.Text = "Play Sound"
        TreeNode47.Name = "Node4"
        TreeNode47.Text = "Stop Sounds"
        TreeNode48.Name = "NodeSound"
        TreeNode48.Text = "Music and Sound"
        TreeNode49.Name = "Node1"
        TreeNode49.Text = "Wait..."
        TreeNode50.Name = "Node2"
        TreeNode50.Text = "Set Access"
        TreeNode51.Name = "Node3"
        TreeNode51.Text = "Custom Script"
        TreeNode52.Name = "NodeEtc"
        TreeNode52.Text = "Etc..."
        TreeNode53.Name = "Node1"
        TreeNode53.Text = "Open Bank"
        TreeNode54.Name = "Node2"
        TreeNode54.Text = "Open Shop"
        TreeNode55.Name = "NodeShopBank"
        TreeNode55.Text = "Shop and Bank"
        TreeNode56.Name = "Node1"
        TreeNode56.Text = "Fade In"
        TreeNode57.Name = "Node2"
        TreeNode57.Text = "Fade Out"
        TreeNode58.Name = "Node12"
        TreeNode58.Text = "Flash White"
        TreeNode59.Name = "Node13"
        TreeNode59.Text = "Show Picture"
        TreeNode60.Name = "Node14"
        TreeNode60.Text = "Hide Picture"
        TreeNode61.Name = "Node0"
        TreeNode61.Text = "Cutscene Options"
        tvCommands.Nodes.AddRange(New TreeNode() {TreeNode5, TreeNode9, TreeNode14, TreeNode26, TreeNode33, TreeNode35, TreeNode39, TreeNode43, TreeNode48, TreeNode52, TreeNode55, TreeNode61})
        tvCommands.Size = New Size(634, 850)
        tvCommands.TabIndex = 1
        ' 
        ' fraPageSetUp
        ' 
        fraPageSetUp.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraPageSetUp.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraPageSetUp.Controls.Add(chkGlobal)
        fraPageSetUp.Controls.Add(btnClearPage)
        fraPageSetUp.Controls.Add(btnDeletePage)
        fraPageSetUp.Controls.Add(btnPastePage)
        fraPageSetUp.Controls.Add(btnCopyPage)
        fraPageSetUp.Controls.Add(btnNewPage)
        fraPageSetUp.Controls.Add(txtName)
        fraPageSetUp.Controls.Add(DarkLabel1)
        fraPageSetUp.ForeColor = Color.Gainsboro
        fraPageSetUp.Location = New Point(5, 5)
        fraPageSetUp.Margin = New Padding(5)
        fraPageSetUp.Name = "fraPageSetUp"
        fraPageSetUp.Padding = New Padding(5)
        fraPageSetUp.Size = New Size(1318, 97)
        fraPageSetUp.TabIndex = 2
        fraPageSetUp.TabStop = False
        fraPageSetUp.Text = "General"
        ' 
        ' chkGlobal
        ' 
        chkGlobal.AutoSize = True
        chkGlobal.Location = New Point(467, 38)
        chkGlobal.Margin = New Padding(5)
        chkGlobal.Name = "chkGlobal"
        chkGlobal.Size = New Size(137, 29)
        chkGlobal.TabIndex = 7
        chkGlobal.Text = "Global Event"
        ' 
        ' btnClearPage
        ' 
        btnClearPage.Location = New Point(1178, 30)
        btnClearPage.Margin = New Padding(5)
        btnClearPage.Name = "btnClearPage"
        btnClearPage.Padding = New Padding(8, 10, 8, 10)
        btnClearPage.Size = New Size(125, 45)
        btnClearPage.TabIndex = 6
        btnClearPage.Text = "Clear Page"
        ' 
        ' btnDeletePage
        ' 
        btnDeletePage.Location = New Point(1037, 30)
        btnDeletePage.Margin = New Padding(5)
        btnDeletePage.Name = "btnDeletePage"
        btnDeletePage.Padding = New Padding(8, 10, 8, 10)
        btnDeletePage.Size = New Size(132, 45)
        btnDeletePage.TabIndex = 5
        btnDeletePage.Text = "Delete Page"
        ' 
        ' btnPastePage
        ' 
        btnPastePage.Location = New Point(902, 30)
        btnPastePage.Margin = New Padding(5)
        btnPastePage.Name = "btnPastePage"
        btnPastePage.Padding = New Padding(8, 10, 8, 10)
        btnPastePage.Size = New Size(125, 45)
        btnPastePage.TabIndex = 4
        btnPastePage.Text = "Paste Page"
        ' 
        ' btnCopyPage
        ' 
        btnCopyPage.Location = New Point(767, 30)
        btnCopyPage.Margin = New Padding(5)
        btnCopyPage.Name = "btnCopyPage"
        btnCopyPage.Padding = New Padding(8, 10, 8, 10)
        btnCopyPage.Size = New Size(125, 45)
        btnCopyPage.TabIndex = 3
        btnCopyPage.Text = "Copy Page"
        ' 
        ' btnNewPage
        ' 
        btnNewPage.Location = New Point(632, 30)
        btnNewPage.Margin = New Padding(5)
        btnNewPage.Name = "btnNewPage"
        btnNewPage.Padding = New Padding(8, 10, 8, 10)
        btnNewPage.Size = New Size(125, 45)
        btnNewPage.TabIndex = 2
        btnNewPage.Text = "New Page"
        ' 
        ' txtName
        ' 
        txtName.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtName.BorderStyle = BorderStyle.FixedSingle
        txtName.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtName.Location = New Point(140, 37)
        txtName.Margin = New Padding(5)
        txtName.Name = "txtName"
        txtName.Size = New Size(315, 31)
        txtName.TabIndex = 1
        ' 
        ' DarkLabel1
        ' 
        DarkLabel1.AutoSize = True
        DarkLabel1.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel1.Location = New Point(15, 40)
        DarkLabel1.Margin = New Padding(5, 0, 5, 0)
        DarkLabel1.Name = "DarkLabel1"
        DarkLabel1.Size = New Size(111, 25)
        DarkLabel1.TabIndex = 0
        DarkLabel1.Text = "Event Name:"
        ' 
        ' tabPages
        ' 
        tabPages.Controls.Add(TabPage1)
        tabPages.Location = New Point(20, 113)
        tabPages.Margin = New Padding(5)
        tabPages.Name = "tabPages"
        tabPages.SelectedIndex = 0
        tabPages.Size = New Size(1182, 37)
        tabPages.TabIndex = 3
        ' 
        ' TabPage1
        ' 
        TabPage1.BackColor = Color.DimGray
        TabPage1.Location = New Point(4, 34)
        TabPage1.Margin = New Padding(5)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(5)
        TabPage1.Size = New Size(1174, 0)
        TabPage1.TabIndex = 0
        TabPage1.Text = "1"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' pnlTabPage
        ' 
        pnlTabPage.Controls.Add(DarkGroupBox2)
        pnlTabPage.Controls.Add(fraGraphicPic)
        pnlTabPage.Controls.Add(DarkGroupBox6)
        pnlTabPage.Controls.Add(DarkGroupBox5)
        pnlTabPage.Controls.Add(DarkGroupBox4)
        pnlTabPage.Controls.Add(DarkGroupBox3)
        pnlTabPage.Controls.Add(DarkGroupBox1)
        pnlTabPage.Controls.Add(DarkGroupBox8)
        pnlTabPage.Controls.Add(fraGraphic)
        pnlTabPage.Controls.Add(fraCommands)
        pnlTabPage.Controls.Add(lstCommands)
        pnlTabPage.Location = New Point(5, 155)
        pnlTabPage.Margin = New Padding(5)
        pnlTabPage.Name = "pnlTabPage"
        pnlTabPage.Size = New Size(1318, 955)
        pnlTabPage.TabIndex = 4
        ' 
        ' DarkGroupBox2
        ' 
        DarkGroupBox2.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox2.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox2.Controls.Add(cmbPositioning)
        DarkGroupBox2.ForeColor = Color.Gainsboro
        DarkGroupBox2.Location = New Point(305, 734)
        DarkGroupBox2.Margin = New Padding(5)
        DarkGroupBox2.Name = "DarkGroupBox2"
        DarkGroupBox2.Padding = New Padding(5)
        DarkGroupBox2.Size = New Size(333, 95)
        DarkGroupBox2.TabIndex = 15
        DarkGroupBox2.TabStop = False
        DarkGroupBox2.Text = "Poisition"
        ' 
        ' cmbPositioning
        ' 
        cmbPositioning.DrawMode = DrawMode.OwnerDrawFixed
        cmbPositioning.FormattingEnabled = True
        cmbPositioning.Items.AddRange(New Object() {"Below Characters", "Same as Characters", "Above Characters"})
        cmbPositioning.Location = New Point(12, 37)
        cmbPositioning.Margin = New Padding(5)
        cmbPositioning.Name = "cmbPositioning"
        cmbPositioning.Size = New Size(312, 32)
        cmbPositioning.TabIndex = 1
        ' 
        ' fraGraphicPic
        ' 
        fraGraphicPic.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraGraphicPic.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraGraphicPic.Controls.Add(picGraphic)
        fraGraphicPic.ForeColor = Color.Gainsboro
        fraGraphicPic.Location = New Point(5, 260)
        fraGraphicPic.Margin = New Padding(5)
        fraGraphicPic.Name = "fraGraphicPic"
        fraGraphicPic.Padding = New Padding(5)
        fraGraphicPic.Size = New Size(288, 447)
        fraGraphicPic.TabIndex = 12
        fraGraphicPic.TabStop = False
        fraGraphicPic.Text = "Graphic"
        ' 
        ' picGraphic
        ' 
        picGraphic.BackgroundImageLayout = ImageLayout.None
        picGraphic.Location = New Point(10, 37)
        picGraphic.Margin = New Padding(5)
        picGraphic.Name = "picGraphic"
        picGraphic.Size = New Size(268, 398)
        picGraphic.TabIndex = 1
        picGraphic.TabStop = False
        ' 
        ' DarkGroupBox6
        ' 
        DarkGroupBox6.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox6.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox6.Controls.Add(chkShowName)
        DarkGroupBox6.Controls.Add(chkWalkThrough)
        DarkGroupBox6.Controls.Add(chkDirFix)
        DarkGroupBox6.Controls.Add(chkWalkAnim)
        DarkGroupBox6.ForeColor = Color.Gainsboro
        DarkGroupBox6.Location = New Point(5, 716)
        DarkGroupBox6.Margin = New Padding(5)
        DarkGroupBox6.Name = "DarkGroupBox6"
        DarkGroupBox6.Padding = New Padding(5)
        DarkGroupBox6.Size = New Size(293, 215)
        DarkGroupBox6.TabIndex = 10
        DarkGroupBox6.TabStop = False
        DarkGroupBox6.Text = "Options"
        ' 
        ' chkShowName
        ' 
        chkShowName.AutoSize = True
        chkShowName.Location = New Point(12, 170)
        chkShowName.Margin = New Padding(5)
        chkShowName.Name = "chkShowName"
        chkShowName.Size = New Size(134, 29)
        chkShowName.TabIndex = 3
        chkShowName.Text = "Show Name"
        ' 
        ' chkWalkThrough
        ' 
        chkWalkThrough.AutoSize = True
        chkWalkThrough.Location = New Point(12, 125)
        chkWalkThrough.Margin = New Padding(5)
        chkWalkThrough.Name = "chkWalkThrough"
        chkWalkThrough.Size = New Size(148, 29)
        chkWalkThrough.TabIndex = 2
        chkWalkThrough.Text = "Walk Through"
        ' 
        ' chkDirFix
        ' 
        chkDirFix.AutoSize = True
        chkDirFix.Location = New Point(12, 80)
        chkDirFix.Margin = New Padding(5)
        chkDirFix.Name = "chkDirFix"
        chkDirFix.Size = New Size(155, 29)
        chkDirFix.TabIndex = 1
        chkDirFix.Text = "Direction Fixed"
        ' 
        ' chkWalkAnim
        ' 
        chkWalkAnim.AutoSize = True
        chkWalkAnim.Location = New Point(12, 37)
        chkWalkAnim.Margin = New Padding(5)
        chkWalkAnim.Name = "chkWalkAnim"
        chkWalkAnim.Size = New Size(192, 29)
        chkWalkAnim.TabIndex = 0
        chkWalkAnim.Text = "No Walk Animation"
        ' 
        ' DarkGroupBox5
        ' 
        DarkGroupBox5.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox5.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox5.Controls.Add(cmbTrigger)
        DarkGroupBox5.ForeColor = Color.Gainsboro
        DarkGroupBox5.Location = New Point(310, 623)
        DarkGroupBox5.Margin = New Padding(5)
        DarkGroupBox5.Name = "DarkGroupBox5"
        DarkGroupBox5.Padding = New Padding(5)
        DarkGroupBox5.Size = New Size(333, 95)
        DarkGroupBox5.TabIndex = 4
        DarkGroupBox5.TabStop = False
        DarkGroupBox5.Text = "Trigger"
        ' 
        ' cmbTrigger
        ' 
        cmbTrigger.DrawMode = DrawMode.OwnerDrawFixed
        cmbTrigger.FormattingEnabled = True
        cmbTrigger.Items.AddRange(New Object() {"Action Button", "Player Touch", "Parallel Process"})
        cmbTrigger.Location = New Point(10, 37)
        cmbTrigger.Margin = New Padding(5)
        cmbTrigger.Name = "cmbTrigger"
        cmbTrigger.Size = New Size(312, 32)
        cmbTrigger.TabIndex = 0
        ' 
        ' DarkGroupBox4
        ' 
        DarkGroupBox4.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox4.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox4.Controls.Add(picGraphicSel)
        DarkGroupBox4.ForeColor = Color.Gainsboro
        DarkGroupBox4.Location = New Point(303, 513)
        DarkGroupBox4.Margin = New Padding(5)
        DarkGroupBox4.Name = "DarkGroupBox4"
        DarkGroupBox4.Padding = New Padding(5)
        DarkGroupBox4.Size = New Size(333, 91)
        DarkGroupBox4.TabIndex = 3
        DarkGroupBox4.TabStop = False
        DarkGroupBox4.Text = "Positioning"
        ' 
        ' picGraphicSel
        ' 
        picGraphicSel.BackgroundImageLayout = ImageLayout.None
        picGraphicSel.Location = New Point(-315, -563)
        picGraphicSel.Margin = New Padding(5)
        picGraphicSel.Name = "picGraphicSel"
        picGraphicSel.Size = New Size(1337, 988)
        picGraphicSel.TabIndex = 5
        picGraphicSel.TabStop = False
        ' 
        ' DarkGroupBox3
        ' 
        DarkGroupBox3.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox3.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox3.Controls.Add(DarkLabel7)
        DarkGroupBox3.Controls.Add(cmbMoveFreq)
        DarkGroupBox3.Controls.Add(DarkLabel6)
        DarkGroupBox3.Controls.Add(cmbMoveSpeed)
        DarkGroupBox3.Controls.Add(btnMoveRoute)
        DarkGroupBox3.Controls.Add(cmbMoveType)
        DarkGroupBox3.Controls.Add(DarkLabel5)
        DarkGroupBox3.ForeColor = Color.Gainsboro
        DarkGroupBox3.Location = New Point(305, 265)
        DarkGroupBox3.Margin = New Padding(5)
        DarkGroupBox3.Name = "DarkGroupBox3"
        DarkGroupBox3.Padding = New Padding(5)
        DarkGroupBox3.Size = New Size(333, 237)
        DarkGroupBox3.TabIndex = 2
        DarkGroupBox3.TabStop = False
        DarkGroupBox3.Text = "Movement"
        ' 
        ' DarkLabel7
        ' 
        DarkLabel7.AutoSize = True
        DarkLabel7.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel7.Location = New Point(10, 191)
        DarkLabel7.Margin = New Padding(5, 0, 5, 0)
        DarkLabel7.Name = "DarkLabel7"
        DarkLabel7.Size = New Size(93, 25)
        DarkLabel7.TabIndex = 6
        DarkLabel7.Text = "Frequency"
        ' 
        ' cmbMoveFreq
        ' 
        cmbMoveFreq.DrawMode = DrawMode.OwnerDrawFixed
        cmbMoveFreq.FormattingEnabled = True
        cmbMoveFreq.Items.AddRange(New Object() {"Lowest", "Lower", "Normal", "Higher", "Highest"})
        cmbMoveFreq.Location = New Point(115, 187)
        cmbMoveFreq.Margin = New Padding(5)
        cmbMoveFreq.Name = "cmbMoveFreq"
        cmbMoveFreq.Size = New Size(206, 32)
        cmbMoveFreq.TabIndex = 5
        ' 
        ' DarkLabel6
        ' 
        DarkLabel6.AutoSize = True
        DarkLabel6.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel6.Location = New Point(10, 140)
        DarkLabel6.Margin = New Padding(5, 0, 5, 0)
        DarkLabel6.Name = "DarkLabel6"
        DarkLabel6.Size = New Size(66, 25)
        DarkLabel6.TabIndex = 4
        DarkLabel6.Text = "Speed:"
        ' 
        ' cmbMoveSpeed
        ' 
        cmbMoveSpeed.DrawMode = DrawMode.OwnerDrawFixed
        cmbMoveSpeed.FormattingEnabled = True
        cmbMoveSpeed.Items.AddRange(New Object() {"8x Slower", "4x Slower", "2x Slower", "Normal", "2x Faster", "4x Faster"})
        cmbMoveSpeed.Location = New Point(115, 135)
        cmbMoveSpeed.Margin = New Padding(5)
        cmbMoveSpeed.Name = "cmbMoveSpeed"
        cmbMoveSpeed.Size = New Size(206, 32)
        cmbMoveSpeed.TabIndex = 3
        ' 
        ' btnMoveRoute
        ' 
        btnMoveRoute.Location = New Point(198, 78)
        btnMoveRoute.Margin = New Padding(5)
        btnMoveRoute.Name = "btnMoveRoute"
        btnMoveRoute.Padding = New Padding(8, 10, 8, 10)
        btnMoveRoute.Size = New Size(125, 45)
        btnMoveRoute.TabIndex = 2
        btnMoveRoute.Text = "Move Route"
        ' 
        ' cmbMoveType
        ' 
        cmbMoveType.DrawMode = DrawMode.OwnerDrawFixed
        cmbMoveType.FormattingEnabled = True
        cmbMoveType.Items.AddRange(New Object() {"Fixed Position", "Random", "Move Route"})
        cmbMoveType.Location = New Point(115, 27)
        cmbMoveType.Margin = New Padding(5)
        cmbMoveType.Name = "cmbMoveType"
        cmbMoveType.Size = New Size(206, 32)
        cmbMoveType.TabIndex = 1
        ' 
        ' DarkLabel5
        ' 
        DarkLabel5.AutoSize = True
        DarkLabel5.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel5.Location = New Point(10, 34)
        DarkLabel5.Margin = New Padding(5, 0, 5, 0)
        DarkLabel5.Name = "DarkLabel5"
        DarkLabel5.Size = New Size(53, 25)
        DarkLabel5.TabIndex = 0
        DarkLabel5.Text = "Type:"
        ' 
        ' DarkGroupBox1
        ' 
        DarkGroupBox1.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox1.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox1.Controls.Add(cmbSelfSwitchCompare)
        DarkGroupBox1.Controls.Add(DarkLabel4)
        DarkGroupBox1.Controls.Add(cmbSelfSwitch)
        DarkGroupBox1.Controls.Add(chkSelfSwitch)
        DarkGroupBox1.Controls.Add(cmbHasItem)
        DarkGroupBox1.Controls.Add(chkHasItem)
        DarkGroupBox1.Controls.Add(cmbPlayerSwitchCompare)
        DarkGroupBox1.Controls.Add(DarkLabel3)
        DarkGroupBox1.Controls.Add(cmbPlayerSwitch)
        DarkGroupBox1.Controls.Add(chkPlayerSwitch)
        DarkGroupBox1.Controls.Add(nudPlayerVariable)
        DarkGroupBox1.Controls.Add(cmbPlayervarCompare)
        DarkGroupBox1.Controls.Add(DarkLabel2)
        DarkGroupBox1.Controls.Add(cmbPlayerVar)
        DarkGroupBox1.Controls.Add(chkPlayerVar)
        DarkGroupBox1.ForeColor = Color.Gainsboro
        DarkGroupBox1.Location = New Point(5, 12)
        DarkGroupBox1.Margin = New Padding(5)
        DarkGroupBox1.Name = "DarkGroupBox1"
        DarkGroupBox1.Padding = New Padding(5)
        DarkGroupBox1.Size = New Size(633, 241)
        DarkGroupBox1.TabIndex = 0
        DarkGroupBox1.TabStop = False
        DarkGroupBox1.Text = "Conditions"
        ' 
        ' cmbSelfSwitchCompare
        ' 
        cmbSelfSwitchCompare.DrawMode = DrawMode.OwnerDrawFixed
        cmbSelfSwitchCompare.FormattingEnabled = True
        cmbSelfSwitchCompare.Items.AddRange(New Object() {"False = 0", "True = 1"})
        cmbSelfSwitchCompare.Location = New Point(372, 188)
        cmbSelfSwitchCompare.Margin = New Padding(5)
        cmbSelfSwitchCompare.Name = "cmbSelfSwitchCompare"
        cmbSelfSwitchCompare.Size = New Size(146, 32)
        cmbSelfSwitchCompare.TabIndex = 14
        ' 
        ' DarkLabel4
        ' 
        DarkLabel4.AutoSize = True
        DarkLabel4.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel4.Location = New Point(338, 195)
        DarkLabel4.Margin = New Padding(5, 0, 5, 0)
        DarkLabel4.Name = "DarkLabel4"
        DarkLabel4.Size = New Size(24, 25)
        DarkLabel4.TabIndex = 13
        DarkLabel4.Text = "is"
        ' 
        ' cmbSelfSwitch
        ' 
        cmbSelfSwitch.DrawMode = DrawMode.OwnerDrawFixed
        cmbSelfSwitch.FormattingEnabled = True
        cmbSelfSwitch.Items.AddRange(New Object() {"None", "1 - A", "2 - B", "3 - C", "4 - D"})
        cmbSelfSwitch.Location = New Point(180, 188)
        cmbSelfSwitch.Margin = New Padding(5)
        cmbSelfSwitch.Name = "cmbSelfSwitch"
        cmbSelfSwitch.Size = New Size(146, 32)
        cmbSelfSwitch.TabIndex = 12
        ' 
        ' chkSelfSwitch
        ' 
        chkSelfSwitch.AutoSize = True
        chkSelfSwitch.Location = New Point(10, 191)
        chkSelfSwitch.Margin = New Padding(5)
        chkSelfSwitch.Name = "chkSelfSwitch"
        chkSelfSwitch.Size = New Size(123, 29)
        chkSelfSwitch.TabIndex = 11
        chkSelfSwitch.Text = "Self Switch"
        ' 
        ' cmbHasItem
        ' 
        cmbHasItem.DrawMode = DrawMode.OwnerDrawFixed
        cmbHasItem.FormattingEnabled = True
        cmbHasItem.Location = New Point(180, 137)
        cmbHasItem.Margin = New Padding(5)
        cmbHasItem.Name = "cmbHasItem"
        cmbHasItem.Size = New Size(337, 32)
        cmbHasItem.TabIndex = 10
        ' 
        ' chkHasItem
        ' 
        chkHasItem.AutoSize = True
        chkHasItem.Location = New Point(10, 140)
        chkHasItem.Margin = New Padding(5)
        chkHasItem.Name = "chkHasItem"
        chkHasItem.Size = New Size(161, 29)
        chkHasItem.TabIndex = 9
        chkHasItem.Text = "Player Has Item"
        ' 
        ' cmbPlayerSwitchCompare
        ' 
        cmbPlayerSwitchCompare.DrawMode = DrawMode.OwnerDrawFixed
        cmbPlayerSwitchCompare.FormattingEnabled = True
        cmbPlayerSwitchCompare.Items.AddRange(New Object() {"False = 0", "True = 1"})
        cmbPlayerSwitchCompare.Location = New Point(372, 85)
        cmbPlayerSwitchCompare.Margin = New Padding(5)
        cmbPlayerSwitchCompare.Name = "cmbPlayerSwitchCompare"
        cmbPlayerSwitchCompare.Size = New Size(146, 32)
        cmbPlayerSwitchCompare.TabIndex = 8
        ' 
        ' DarkLabel3
        ' 
        DarkLabel3.AutoSize = True
        DarkLabel3.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel3.Location = New Point(338, 90)
        DarkLabel3.Margin = New Padding(5, 0, 5, 0)
        DarkLabel3.Name = "DarkLabel3"
        DarkLabel3.Size = New Size(24, 25)
        DarkLabel3.TabIndex = 7
        DarkLabel3.Text = "is"
        ' 
        ' cmbPlayerSwitch
        ' 
        cmbPlayerSwitch.DrawMode = DrawMode.OwnerDrawFixed
        cmbPlayerSwitch.FormattingEnabled = True
        cmbPlayerSwitch.Location = New Point(180, 85)
        cmbPlayerSwitch.Margin = New Padding(5)
        cmbPlayerSwitch.Name = "cmbPlayerSwitch"
        cmbPlayerSwitch.Size = New Size(146, 32)
        cmbPlayerSwitch.TabIndex = 6
        ' 
        ' chkPlayerSwitch
        ' 
        chkPlayerSwitch.AutoSize = True
        chkPlayerSwitch.Location = New Point(10, 88)
        chkPlayerSwitch.Margin = New Padding(5)
        chkPlayerSwitch.Name = "chkPlayerSwitch"
        chkPlayerSwitch.Size = New Size(141, 29)
        chkPlayerSwitch.TabIndex = 5
        chkPlayerSwitch.Text = "Player Switch"
        ' 
        ' nudPlayerVariable
        ' 
        nudPlayerVariable.Location = New Point(530, 35)
        nudPlayerVariable.Margin = New Padding(5)
        nudPlayerVariable.Name = "nudPlayerVariable"
        nudPlayerVariable.Size = New Size(93, 31)
        nudPlayerVariable.TabIndex = 4
        ' 
        ' cmbPlayervarCompare
        ' 
        cmbPlayervarCompare.DrawMode = DrawMode.OwnerDrawFixed
        cmbPlayervarCompare.FormattingEnabled = True
        cmbPlayervarCompare.Items.AddRange(New Object() {"Equal To", "Great Than Or Equal To", "Less Than or Equal To", "Greater Than", "Less Than", "Does Not Equal"})
        cmbPlayervarCompare.Location = New Point(372, 34)
        cmbPlayervarCompare.Margin = New Padding(5)
        cmbPlayervarCompare.Name = "cmbPlayervarCompare"
        cmbPlayervarCompare.Size = New Size(146, 32)
        cmbPlayervarCompare.TabIndex = 3
        ' 
        ' DarkLabel2
        ' 
        DarkLabel2.AutoSize = True
        DarkLabel2.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel2.Location = New Point(338, 45)
        DarkLabel2.Margin = New Padding(5, 0, 5, 0)
        DarkLabel2.Name = "DarkLabel2"
        DarkLabel2.Size = New Size(24, 25)
        DarkLabel2.TabIndex = 2
        DarkLabel2.Text = "is"
        ' 
        ' cmbPlayerVar
        ' 
        cmbPlayerVar.DrawMode = DrawMode.OwnerDrawFixed
        cmbPlayerVar.FormattingEnabled = True
        cmbPlayerVar.Location = New Point(180, 34)
        cmbPlayerVar.Margin = New Padding(5)
        cmbPlayerVar.Name = "cmbPlayerVar"
        cmbPlayerVar.Size = New Size(146, 32)
        cmbPlayerVar.TabIndex = 1
        ' 
        ' chkPlayerVar
        ' 
        chkPlayerVar.AutoSize = True
        chkPlayerVar.Location = New Point(10, 37)
        chkPlayerVar.Margin = New Padding(5)
        chkPlayerVar.Name = "chkPlayerVar"
        chkPlayerVar.Size = New Size(152, 29)
        chkPlayerVar.TabIndex = 0
        chkPlayerVar.Text = "Player Variable"
        ' 
        ' DarkGroupBox8
        ' 
        DarkGroupBox8.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox8.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox8.Controls.Add(btnClearCommand)
        DarkGroupBox8.Controls.Add(btnDeleteCommand)
        DarkGroupBox8.Controls.Add(btnEditCommand)
        DarkGroupBox8.Controls.Add(btnAddCommand)
        DarkGroupBox8.ForeColor = Color.Gainsboro
        DarkGroupBox8.Location = New Point(648, 845)
        DarkGroupBox8.Margin = New Padding(5)
        DarkGroupBox8.Name = "DarkGroupBox8"
        DarkGroupBox8.Padding = New Padding(5)
        DarkGroupBox8.Size = New Size(655, 95)
        DarkGroupBox8.TabIndex = 9
        DarkGroupBox8.TabStop = False
        DarkGroupBox8.Text = "Commands"
        ' 
        ' btnClearCommand
        ' 
        btnClearCommand.Location = New Point(520, 37)
        btnClearCommand.Margin = New Padding(5)
        btnClearCommand.Name = "btnClearCommand"
        btnClearCommand.Padding = New Padding(8, 10, 8, 10)
        btnClearCommand.Size = New Size(125, 45)
        btnClearCommand.TabIndex = 3
        btnClearCommand.Text = "Clear"
        ' 
        ' btnDeleteCommand
        ' 
        btnDeleteCommand.Location = New Point(353, 37)
        btnDeleteCommand.Margin = New Padding(5)
        btnDeleteCommand.Name = "btnDeleteCommand"
        btnDeleteCommand.Padding = New Padding(8, 10, 8, 10)
        btnDeleteCommand.Size = New Size(125, 45)
        btnDeleteCommand.TabIndex = 2
        btnDeleteCommand.Text = "Delete"
        ' 
        ' btnEditCommand
        ' 
        btnEditCommand.Location = New Point(180, 37)
        btnEditCommand.Margin = New Padding(5)
        btnEditCommand.Name = "btnEditCommand"
        btnEditCommand.Padding = New Padding(8, 10, 8, 10)
        btnEditCommand.Size = New Size(125, 45)
        btnEditCommand.TabIndex = 1
        btnEditCommand.Text = "Edit"
        ' 
        ' btnAddCommand
        ' 
        btnAddCommand.Location = New Point(10, 37)
        btnAddCommand.Margin = New Padding(5)
        btnAddCommand.Name = "btnAddCommand"
        btnAddCommand.Padding = New Padding(8, 10, 8, 10)
        btnAddCommand.Size = New Size(125, 45)
        btnAddCommand.TabIndex = 0
        btnAddCommand.Text = "Add"
        ' 
        ' fraGraphic
        ' 
        fraGraphic.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraGraphic.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraGraphic.Controls.Add(btnGraphicOk)
        fraGraphic.Controls.Add(btnGraphicCancel)
        fraGraphic.Controls.Add(DarkLabel13)
        fraGraphic.Controls.Add(nudGraphic)
        fraGraphic.Controls.Add(DarkLabel12)
        fraGraphic.Controls.Add(cmbGraphic)
        fraGraphic.Controls.Add(DarkLabel11)
        fraGraphic.ForeColor = Color.Gainsboro
        fraGraphic.Location = New Point(648, 10)
        fraGraphic.Margin = New Padding(5)
        fraGraphic.Name = "fraGraphic"
        fraGraphic.Padding = New Padding(5)
        fraGraphic.Size = New Size(655, 928)
        fraGraphic.TabIndex = 14
        fraGraphic.TabStop = False
        fraGraphic.Text = "Graphic Selection"
        fraGraphic.Visible = False
        ' 
        ' btnGraphicOk
        ' 
        btnGraphicOk.Location = New Point(1087, 1097)
        btnGraphicOk.Margin = New Padding(5)
        btnGraphicOk.Name = "btnGraphicOk"
        btnGraphicOk.Padding = New Padding(8, 10, 8, 10)
        btnGraphicOk.Size = New Size(125, 45)
        btnGraphicOk.TabIndex = 8
        btnGraphicOk.Text = "Ok"
        ' 
        ' btnGraphicCancel
        ' 
        btnGraphicCancel.Location = New Point(1222, 1097)
        btnGraphicCancel.Margin = New Padding(5)
        btnGraphicCancel.Name = "btnGraphicCancel"
        btnGraphicCancel.Padding = New Padding(8, 10, 8, 10)
        btnGraphicCancel.Size = New Size(125, 45)
        btnGraphicCancel.TabIndex = 7
        btnGraphicCancel.Text = "Cancel"
        ' 
        ' DarkLabel13
        ' 
        DarkLabel13.AutoSize = True
        DarkLabel13.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel13.Location = New Point(17, 1098)
        DarkLabel13.Margin = New Padding(5, 0, 5, 0)
        DarkLabel13.Name = "DarkLabel13"
        DarkLabel13.Size = New Size(272, 25)
        DarkLabel13.TabIndex = 6
        DarkLabel13.Text = "Hold Shift to select multiple tiles."
        ' 
        ' nudGraphic
        ' 
        nudGraphic.Location = New Point(173, 95)
        nudGraphic.Margin = New Padding(5)
        nudGraphic.Name = "nudGraphic"
        nudGraphic.Size = New Size(360, 31)
        nudGraphic.TabIndex = 3
        ' 
        ' DarkLabel12
        ' 
        DarkLabel12.AutoSize = True
        DarkLabel12.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel12.Location = New Point(35, 98)
        DarkLabel12.Margin = New Padding(5, 0, 5, 0)
        DarkLabel12.Name = "DarkLabel12"
        DarkLabel12.Size = New Size(81, 25)
        DarkLabel12.TabIndex = 2
        DarkLabel12.Text = "Number:"
        ' 
        ' cmbGraphic
        ' 
        cmbGraphic.DrawMode = DrawMode.OwnerDrawFixed
        cmbGraphic.FormattingEnabled = True
        cmbGraphic.Items.AddRange(New Object() {"None", "Character", "Tileset"})
        cmbGraphic.Location = New Point(173, 35)
        cmbGraphic.Margin = New Padding(5)
        cmbGraphic.Name = "cmbGraphic"
        cmbGraphic.Size = New Size(359, 32)
        cmbGraphic.TabIndex = 1
        ' 
        ' DarkLabel11
        ' 
        DarkLabel11.AutoSize = True
        DarkLabel11.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel11.Location = New Point(35, 40)
        DarkLabel11.Margin = New Padding(5, 0, 5, 0)
        DarkLabel11.Name = "DarkLabel11"
        DarkLabel11.Size = New Size(126, 25)
        DarkLabel11.TabIndex = 0
        DarkLabel11.Text = "Graphics Type:"
        ' 
        ' fraCommands
        ' 
        fraCommands.Controls.Add(btnCancelCommand)
        fraCommands.Controls.Add(tvCommands)
        fraCommands.Location = New Point(648, 12)
        fraCommands.Margin = New Padding(5)
        fraCommands.Name = "fraCommands"
        fraCommands.Size = New Size(655, 927)
        fraCommands.TabIndex = 6
        fraCommands.Visible = False
        ' 
        ' btnCancelCommand
        ' 
        btnCancelCommand.Location = New Point(520, 870)
        btnCancelCommand.Margin = New Padding(5)
        btnCancelCommand.Name = "btnCancelCommand"
        btnCancelCommand.Padding = New Padding(8, 10, 8, 10)
        btnCancelCommand.Size = New Size(125, 45)
        btnCancelCommand.TabIndex = 2
        btnCancelCommand.Text = "Cancel"
        ' 
        ' lstCommands
        ' 
        lstCommands.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        lstCommands.BorderStyle = BorderStyle.FixedSingle
        lstCommands.ForeColor = Color.Gainsboro
        lstCommands.FormattingEnabled = True
        lstCommands.ItemHeight = 25
        lstCommands.Location = New Point(648, 12)
        lstCommands.Margin = New Padding(5)
        lstCommands.Name = "lstCommands"
        lstCommands.Size = New Size(654, 827)
        lstCommands.TabIndex = 8
        ' 
        ' btnLabeling
        ' 
        btnLabeling.Location = New Point(10, 1097)
        btnLabeling.Margin = New Padding(5)
        btnLabeling.Name = "btnLabeling"
        btnLabeling.Padding = New Padding(8, 10, 8, 10)
        btnLabeling.Size = New Size(293, 45)
        btnLabeling.TabIndex = 6
        btnLabeling.Text = "Edit Variables/Switches"
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(1183, 1105)
        btnCancel.Margin = New Padding(5)
        btnCancel.Name = "btnCancel"
        btnCancel.Padding = New Padding(8, 10, 8, 10)
        btnCancel.Size = New Size(125, 45)
        btnCancel.TabIndex = 7
        btnCancel.Text = "Cancel"
        ' 
        ' btnOk
        ' 
        btnOk.Location = New Point(1048, 1105)
        btnOk.Margin = New Padding(5)
        btnOk.Name = "btnOk"
        btnOk.Padding = New Padding(8, 10, 8, 10)
        btnOk.Size = New Size(125, 45)
        btnOk.TabIndex = 8
        btnOk.Text = "Ok"
        ' 
        ' fraMoveRoute
        ' 
        fraMoveRoute.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraMoveRoute.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraMoveRoute.Controls.Add(btnMoveRouteOk)
        fraMoveRoute.Controls.Add(btnMoveRouteCancel)
        fraMoveRoute.Controls.Add(chkRepeatRoute)
        fraMoveRoute.Controls.Add(chkIgnoreMove)
        fraMoveRoute.Controls.Add(DarkGroupBox10)
        fraMoveRoute.Controls.Add(lstMoveRoute)
        fraMoveRoute.Controls.Add(cmbEvent)
        fraMoveRoute.ForeColor = Color.Gainsboro
        fraMoveRoute.Location = New Point(1333, 23)
        fraMoveRoute.Margin = New Padding(5)
        fraMoveRoute.Name = "fraMoveRoute"
        fraMoveRoute.Padding = New Padding(5)
        fraMoveRoute.Size = New Size(155, 163)
        fraMoveRoute.TabIndex = 0
        fraMoveRoute.TabStop = False
        fraMoveRoute.Text = "Move Route"
        fraMoveRoute.Visible = False
        ' 
        ' btnMoveRouteOk
        ' 
        btnMoveRouteOk.Location = New Point(1070, 828)
        btnMoveRouteOk.Margin = New Padding(5)
        btnMoveRouteOk.Name = "btnMoveRouteOk"
        btnMoveRouteOk.Padding = New Padding(8, 10, 8, 10)
        btnMoveRouteOk.Size = New Size(125, 45)
        btnMoveRouteOk.TabIndex = 7
        btnMoveRouteOk.Text = "Ok"
        ' 
        ' btnMoveRouteCancel
        ' 
        btnMoveRouteCancel.Location = New Point(1205, 828)
        btnMoveRouteCancel.Margin = New Padding(5)
        btnMoveRouteCancel.Name = "btnMoveRouteCancel"
        btnMoveRouteCancel.Padding = New Padding(8, 10, 8, 10)
        btnMoveRouteCancel.Size = New Size(125, 45)
        btnMoveRouteCancel.TabIndex = 6
        btnMoveRouteCancel.Text = "Cancel"
        ' 
        ' chkRepeatRoute
        ' 
        chkRepeatRoute.AutoSize = True
        chkRepeatRoute.Location = New Point(10, 873)
        chkRepeatRoute.Margin = New Padding(5)
        chkRepeatRoute.Name = "chkRepeatRoute"
        chkRepeatRoute.Size = New Size(143, 29)
        chkRepeatRoute.TabIndex = 5
        chkRepeatRoute.Text = "Repeat Route"
        ' 
        ' chkIgnoreMove
        ' 
        chkIgnoreMove.AutoSize = True
        chkIgnoreMove.Location = New Point(10, 828)
        chkIgnoreMove.Margin = New Padding(5)
        chkIgnoreMove.Name = "chkIgnoreMove"
        chkIgnoreMove.Size = New Size(245, 29)
        chkIgnoreMove.TabIndex = 4
        chkIgnoreMove.Text = "Ignore if event can't move"
        ' 
        ' DarkGroupBox10
        ' 
        DarkGroupBox10.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox10.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox10.Controls.Add(lstvwMoveRoute)
        DarkGroupBox10.ForeColor = Color.Gainsboro
        DarkGroupBox10.Location = New Point(338, 20)
        DarkGroupBox10.Margin = New Padding(5)
        DarkGroupBox10.Name = "DarkGroupBox10"
        DarkGroupBox10.Padding = New Padding(5)
        DarkGroupBox10.Size = New Size(992, 798)
        DarkGroupBox10.TabIndex = 3
        DarkGroupBox10.TabStop = False
        DarkGroupBox10.Text = "Commands"
        ' 
        ' lstvwMoveRoute
        ' 
        lstvwMoveRoute.AutoArrange = False
        lstvwMoveRoute.BackColor = Color.DimGray
        lstvwMoveRoute.BorderStyle = BorderStyle.None
        lstvwMoveRoute.Columns.AddRange(New ColumnHeader() {ColumnHeader3, ColumnHeader4})
        lstvwMoveRoute.Dock = DockStyle.Top
        lstvwMoveRoute.Font = New Font("Microsoft Sans Serif", 8.25F)
        lstvwMoveRoute.ForeColor = Color.Gainsboro
        ListViewGroup1.Header = "Movement"
        ListViewGroup1.Name = "lstVgMovement"
        ListViewGroup2.Header = "Wait"
        ListViewGroup2.Name = "lstVgWait"
        ListViewGroup3.Header = "Turning"
        ListViewGroup3.Name = "lstVgTurn"
        ListViewGroup4.Header = "Speed"
        ListViewGroup4.Name = "lstVgSpeed"
        ListViewGroup5.Header = "Walk Animation"
        ListViewGroup5.Name = "lstVgWalk"
        ListViewGroup6.Header = "Fixed Direction"
        ListViewGroup6.Name = "lstVgDirection"
        ListViewGroup7.Header = "WalkThrough"
        ListViewGroup7.Name = "lstVgWalkThrough"
        ListViewGroup8.Header = "Set Position"
        ListViewGroup8.Name = "lstVgSetposition"
        ListViewGroup9.Header = "Set Graphic"
        ListViewGroup9.Name = "lstVgSetGraphic"
        lstvwMoveRoute.Groups.AddRange(New ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3, ListViewGroup4, ListViewGroup5, ListViewGroup6, ListViewGroup7, ListViewGroup8, ListViewGroup9})
        lstvwMoveRoute.HeaderStyle = ColumnHeaderStyle.None
        ListViewItem1.Group = ListViewGroup1
        ListViewItem2.Group = ListViewGroup1
        ListViewItem2.IndentCount = 1
        ListViewItem3.Group = ListViewGroup1
        ListViewItem4.Group = ListViewGroup1
        ListViewItem4.IndentCount = 1
        ListViewItem5.Group = ListViewGroup1
        ListViewItem6.Group = ListViewGroup1
        ListViewItem7.Group = ListViewGroup1
        ListViewItem8.Group = ListViewGroup1
        ListViewItem9.Group = ListViewGroup1
        ListViewItem10.Group = ListViewGroup2
        ListViewItem11.Group = ListViewGroup2
        ListViewItem12.Group = ListViewGroup2
        ListViewItem13.Group = ListViewGroup3
        ListViewItem14.Group = ListViewGroup3
        ListViewItem15.Group = ListViewGroup3
        ListViewItem16.Group = ListViewGroup3
        ListViewItem17.Group = ListViewGroup3
        ListViewItem18.Group = ListViewGroup3
        ListViewItem19.Group = ListViewGroup3
        ListViewItem20.Group = ListViewGroup3
        ListViewItem21.Group = ListViewGroup3
        ListViewItem22.Group = ListViewGroup3
        ListViewItem23.Group = ListViewGroup4
        ListViewItem24.Group = ListViewGroup4
        ListViewItem25.Group = ListViewGroup4
        ListViewItem26.Group = ListViewGroup4
        ListViewItem27.Group = ListViewGroup4
        ListViewItem28.Group = ListViewGroup4
        ListViewItem29.Group = ListViewGroup4
        ListViewItem30.Group = ListViewGroup4
        ListViewItem31.Group = ListViewGroup4
        ListViewItem32.Group = ListViewGroup4
        ListViewItem33.Group = ListViewGroup4
        ListViewItem34.Group = ListViewGroup5
        ListViewItem35.Group = ListViewGroup5
        ListViewItem36.Group = ListViewGroup6
        ListViewItem37.Group = ListViewGroup6
        ListViewItem38.Group = ListViewGroup7
        ListViewItem39.Group = ListViewGroup7
        ListViewItem40.Group = ListViewGroup8
        ListViewItem41.Group = ListViewGroup8
        ListViewItem42.Group = ListViewGroup8
        ListViewItem43.Group = ListViewGroup9
        lstvwMoveRoute.Items.AddRange(New ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5, ListViewItem6, ListViewItem7, ListViewItem8, ListViewItem9, ListViewItem10, ListViewItem11, ListViewItem12, ListViewItem13, ListViewItem14, ListViewItem15, ListViewItem16, ListViewItem17, ListViewItem18, ListViewItem19, ListViewItem20, ListViewItem21, ListViewItem22, ListViewItem23, ListViewItem24, ListViewItem25, ListViewItem26, ListViewItem27, ListViewItem28, ListViewItem29, ListViewItem30, ListViewItem31, ListViewItem32, ListViewItem33, ListViewItem34, ListViewItem35, ListViewItem36, ListViewItem37, ListViewItem38, ListViewItem39, ListViewItem40, ListViewItem41, ListViewItem42, ListViewItem43})
        lstvwMoveRoute.LabelWrap = False
        lstvwMoveRoute.Location = New Point(5, 29)
        lstvwMoveRoute.Margin = New Padding(5)
        lstvwMoveRoute.MultiSelect = False
        lstvwMoveRoute.Name = "lstvwMoveRoute"
        lstvwMoveRoute.Size = New Size(982, 763)
        lstvwMoveRoute.TabIndex = 5
        lstvwMoveRoute.UseCompatibleStateImageBehavior = False
        lstvwMoveRoute.View = View.Tile
        ' 
        ' ColumnHeader3
        ' 
        ColumnHeader3.Text = ""
        ColumnHeader3.Width = 150
        ' 
        ' ColumnHeader4
        ' 
        ColumnHeader4.Text = ""
        ColumnHeader4.Width = 150
        ' 
        ' lstMoveRoute
        ' 
        lstMoveRoute.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        lstMoveRoute.BorderStyle = BorderStyle.FixedSingle
        lstMoveRoute.ForeColor = Color.Gainsboro
        lstMoveRoute.FormattingEnabled = True
        lstMoveRoute.ItemHeight = 25
        lstMoveRoute.Location = New Point(10, 88)
        lstMoveRoute.Margin = New Padding(5)
        lstMoveRoute.Name = "lstMoveRoute"
        lstMoveRoute.Size = New Size(317, 727)
        lstMoveRoute.TabIndex = 2
        ' 
        ' cmbEvent
        ' 
        cmbEvent.DrawMode = DrawMode.OwnerDrawFixed
        cmbEvent.FormattingEnabled = True
        cmbEvent.Location = New Point(10, 37)
        cmbEvent.Margin = New Padding(5)
        cmbEvent.Name = "cmbEvent"
        cmbEvent.Size = New Size(316, 32)
        cmbEvent.TabIndex = 0
        ' 
        ' pnlGraphicSel
        ' 
        pnlGraphicSel.AutoScroll = True
        pnlGraphicSel.Location = New Point(5, 153)
        pnlGraphicSel.Margin = New Padding(5)
        pnlGraphicSel.Name = "pnlGraphicSel"
        pnlGraphicSel.Size = New Size(1318, 955)
        pnlGraphicSel.TabIndex = 9
        ' 
        ' fraDialogue
        ' 
        fraDialogue.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraDialogue.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraDialogue.Controls.Add(fraShowChatBubble)
        fraDialogue.Controls.Add(fraOpenShop)
        fraDialogue.Controls.Add(fraSetSelfSwitch)
        fraDialogue.Controls.Add(fraPlaySound)
        fraDialogue.Controls.Add(fraChangePK)
        fraDialogue.Controls.Add(fraCreateLabel)
        fraDialogue.Controls.Add(fraChangeJob)
        fraDialogue.Controls.Add(fraChangeSkills)
        fraDialogue.Controls.Add(fraPlayerSwitch)
        fraDialogue.Controls.Add(fraSetWait)
        fraDialogue.Controls.Add(fraMoveRouteWait)
        fraDialogue.Controls.Add(fraCustomScript)
        fraDialogue.Controls.Add(fraSpawnNpc)
        fraDialogue.Controls.Add(fraSetWeather)
        fraDialogue.Controls.Add(fraGiveExp)
        fraDialogue.Controls.Add(fraSetAccess)
        fraDialogue.Controls.Add(fraChangeGender)
        fraDialogue.Controls.Add(fraShowChoices)
        fraDialogue.Controls.Add(fraChangeLevel)
        fraDialogue.Controls.Add(fraPlayerVariable)
        fraDialogue.Controls.Add(fraPlayAnimation)
        fraDialogue.Controls.Add(fraChangeSprite)
        fraDialogue.Controls.Add(fraGoToLabel)
        fraDialogue.Controls.Add(fraMapTint)
        fraDialogue.Controls.Add(fraShowPic)
        fraDialogue.Controls.Add(fraConditionalBranch)
        fraDialogue.Controls.Add(fraPlayBGM)
        fraDialogue.Controls.Add(fraPlayerWarp)
        fraDialogue.Controls.Add(fraSetFog)
        fraDialogue.Controls.Add(fraShowText)
        fraDialogue.Controls.Add(fraAddText)
        fraDialogue.Controls.Add(fraChangeItems)
        fraDialogue.ForeColor = Color.Gainsboro
        fraDialogue.Location = New Point(1508, 23)
        fraDialogue.Margin = New Padding(5)
        fraDialogue.Name = "fraDialogue"
        fraDialogue.Padding = New Padding(5)
        fraDialogue.Size = New Size(1108, 1145)
        fraDialogue.TabIndex = 10
        fraDialogue.TabStop = False
        fraDialogue.Visible = False
        ' 
        ' fraShowChatBubble
        ' 
        fraShowChatBubble.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraShowChatBubble.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraShowChatBubble.Controls.Add(btnShowChatBubbleOk)
        fraShowChatBubble.Controls.Add(btnShowChatBubbleCancel)
        fraShowChatBubble.Controls.Add(DarkLabel41)
        fraShowChatBubble.Controls.Add(cmbChatBubbleTarget)
        fraShowChatBubble.Controls.Add(cmbChatBubbleTargetType)
        fraShowChatBubble.Controls.Add(DarkLabel40)
        fraShowChatBubble.Controls.Add(txtChatbubbleText)
        fraShowChatBubble.Controls.Add(DarkLabel39)
        fraShowChatBubble.ForeColor = Color.Gainsboro
        fraShowChatBubble.Location = New Point(668, 348)
        fraShowChatBubble.Margin = New Padding(5)
        fraShowChatBubble.Name = "fraShowChatBubble"
        fraShowChatBubble.Padding = New Padding(5)
        fraShowChatBubble.Size = New Size(410, 272)
        fraShowChatBubble.TabIndex = 27
        fraShowChatBubble.TabStop = False
        fraShowChatBubble.Text = "Show ChatBubble"
        fraShowChatBubble.Visible = False
        ' 
        ' btnShowChatBubbleOk
        ' 
        btnShowChatBubbleOk.Location = New Point(140, 215)
        btnShowChatBubbleOk.Margin = New Padding(5)
        btnShowChatBubbleOk.Name = "btnShowChatBubbleOk"
        btnShowChatBubbleOk.Padding = New Padding(8, 10, 8, 10)
        btnShowChatBubbleOk.Size = New Size(125, 45)
        btnShowChatBubbleOk.TabIndex = 31
        btnShowChatBubbleOk.Text = "Ok"
        ' 
        ' btnShowChatBubbleCancel
        ' 
        btnShowChatBubbleCancel.Location = New Point(275, 215)
        btnShowChatBubbleCancel.Margin = New Padding(5)
        btnShowChatBubbleCancel.Name = "btnShowChatBubbleCancel"
        btnShowChatBubbleCancel.Padding = New Padding(8, 10, 8, 10)
        btnShowChatBubbleCancel.Size = New Size(125, 45)
        btnShowChatBubbleCancel.TabIndex = 30
        btnShowChatBubbleCancel.Text = "Cancel"
        ' 
        ' DarkLabel41
        ' 
        DarkLabel41.AutoSize = True
        DarkLabel41.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel41.Location = New Point(10, 170)
        DarkLabel41.Margin = New Padding(5, 0, 5, 0)
        DarkLabel41.Name = "DarkLabel41"
        DarkLabel41.Size = New Size(59, 25)
        DarkLabel41.TabIndex = 29
        DarkLabel41.Text = "Index:"
        ' 
        ' cmbChatBubbleTarget
        ' 
        cmbChatBubbleTarget.DrawMode = DrawMode.OwnerDrawFixed
        cmbChatBubbleTarget.FormattingEnabled = True
        cmbChatBubbleTarget.Location = New Point(135, 163)
        cmbChatBubbleTarget.Margin = New Padding(5)
        cmbChatBubbleTarget.Name = "cmbChatBubbleTarget"
        cmbChatBubbleTarget.Size = New Size(262, 32)
        cmbChatBubbleTarget.TabIndex = 28
        ' 
        ' cmbChatBubbleTargetType
        ' 
        cmbChatBubbleTargetType.DrawMode = DrawMode.OwnerDrawFixed
        cmbChatBubbleTargetType.FormattingEnabled = True
        cmbChatBubbleTargetType.Items.AddRange(New Object() {"Player", "Npc", "Event"})
        cmbChatBubbleTargetType.Location = New Point(135, 112)
        cmbChatBubbleTargetType.Margin = New Padding(5)
        cmbChatBubbleTargetType.Name = "cmbChatBubbleTargetType"
        cmbChatBubbleTargetType.Size = New Size(262, 32)
        cmbChatBubbleTargetType.TabIndex = 27
        ' 
        ' DarkLabel40
        ' 
        DarkLabel40.AutoSize = True
        DarkLabel40.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel40.Location = New Point(10, 116)
        DarkLabel40.Margin = New Padding(5, 0, 5, 0)
        DarkLabel40.Name = "DarkLabel40"
        DarkLabel40.Size = New Size(106, 25)
        DarkLabel40.TabIndex = 2
        DarkLabel40.Text = "Target Type:"
        ' 
        ' txtChatbubbleText
        ' 
        txtChatbubbleText.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtChatbubbleText.BorderStyle = BorderStyle.FixedSingle
        txtChatbubbleText.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtChatbubbleText.Location = New Point(10, 62)
        txtChatbubbleText.Margin = New Padding(5)
        txtChatbubbleText.Name = "txtChatbubbleText"
        txtChatbubbleText.Size = New Size(389, 31)
        txtChatbubbleText.TabIndex = 1
        ' 
        ' DarkLabel39
        ' 
        DarkLabel39.AutoSize = True
        DarkLabel39.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel39.Location = New Point(10, 30)
        DarkLabel39.Margin = New Padding(5, 0, 5, 0)
        DarkLabel39.Name = "DarkLabel39"
        DarkLabel39.Size = New Size(138, 25)
        DarkLabel39.TabIndex = 0
        DarkLabel39.Text = "ChatBubble Text"
        ' 
        ' fraOpenShop
        ' 
        fraOpenShop.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraOpenShop.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraOpenShop.Controls.Add(btnOpenShopOk)
        fraOpenShop.Controls.Add(btnOpenShopCancel)
        fraOpenShop.Controls.Add(cmbOpenShop)
        fraOpenShop.ForeColor = Color.Gainsboro
        fraOpenShop.Location = New Point(672, 416)
        fraOpenShop.Margin = New Padding(5)
        fraOpenShop.Name = "fraOpenShop"
        fraOpenShop.Padding = New Padding(5)
        fraOpenShop.Size = New Size(410, 152)
        fraOpenShop.TabIndex = 39
        fraOpenShop.TabStop = False
        fraOpenShop.Text = "Open Shop"
        fraOpenShop.Visible = False
        ' 
        ' btnOpenShopOk
        ' 
        btnOpenShopOk.Location = New Point(73, 90)
        btnOpenShopOk.Margin = New Padding(5)
        btnOpenShopOk.Name = "btnOpenShopOk"
        btnOpenShopOk.Padding = New Padding(8, 10, 8, 10)
        btnOpenShopOk.Size = New Size(125, 45)
        btnOpenShopOk.TabIndex = 27
        btnOpenShopOk.Text = "Ok"
        ' 
        ' btnOpenShopCancel
        ' 
        btnOpenShopCancel.Location = New Point(208, 90)
        btnOpenShopCancel.Margin = New Padding(5)
        btnOpenShopCancel.Name = "btnOpenShopCancel"
        btnOpenShopCancel.Padding = New Padding(8, 10, 8, 10)
        btnOpenShopCancel.Size = New Size(125, 45)
        btnOpenShopCancel.TabIndex = 26
        btnOpenShopCancel.Text = "Cancel"
        ' 
        ' cmbOpenShop
        ' 
        cmbOpenShop.DrawMode = DrawMode.OwnerDrawFixed
        cmbOpenShop.FormattingEnabled = True
        cmbOpenShop.Location = New Point(15, 38)
        cmbOpenShop.Margin = New Padding(5)
        cmbOpenShop.Name = "cmbOpenShop"
        cmbOpenShop.Size = New Size(374, 32)
        cmbOpenShop.TabIndex = 0
        ' 
        ' fraSetSelfSwitch
        ' 
        fraSetSelfSwitch.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraSetSelfSwitch.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraSetSelfSwitch.Controls.Add(btnSelfswitchOk)
        fraSetSelfSwitch.Controls.Add(btnSelfswitchCancel)
        fraSetSelfSwitch.Controls.Add(DarkLabel47)
        fraSetSelfSwitch.Controls.Add(cmbSetSelfSwitchTo)
        fraSetSelfSwitch.Controls.Add(DarkLabel46)
        fraSetSelfSwitch.Controls.Add(cmbSetSelfSwitch)
        fraSetSelfSwitch.ForeColor = Color.Gainsboro
        fraSetSelfSwitch.Location = New Point(668, 347)
        fraSetSelfSwitch.Margin = New Padding(5)
        fraSetSelfSwitch.Name = "fraSetSelfSwitch"
        fraSetSelfSwitch.Padding = New Padding(5)
        fraSetSelfSwitch.Size = New Size(410, 191)
        fraSetSelfSwitch.TabIndex = 29
        fraSetSelfSwitch.TabStop = False
        fraSetSelfSwitch.Text = "Self Switches"
        fraSetSelfSwitch.Visible = False
        ' 
        ' btnSelfswitchOk
        ' 
        btnSelfswitchOk.Location = New Point(140, 140)
        btnSelfswitchOk.Margin = New Padding(5)
        btnSelfswitchOk.Name = "btnSelfswitchOk"
        btnSelfswitchOk.Padding = New Padding(8, 10, 8, 10)
        btnSelfswitchOk.Size = New Size(125, 45)
        btnSelfswitchOk.TabIndex = 27
        btnSelfswitchOk.Text = "Ok"
        ' 
        ' btnSelfswitchCancel
        ' 
        btnSelfswitchCancel.Location = New Point(275, 140)
        btnSelfswitchCancel.Margin = New Padding(5)
        btnSelfswitchCancel.Name = "btnSelfswitchCancel"
        btnSelfswitchCancel.Padding = New Padding(8, 10, 8, 10)
        btnSelfswitchCancel.Size = New Size(125, 45)
        btnSelfswitchCancel.TabIndex = 26
        btnSelfswitchCancel.Text = "Cancel"
        ' 
        ' DarkLabel47
        ' 
        DarkLabel47.AutoSize = True
        DarkLabel47.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel47.Location = New Point(10, 95)
        DarkLabel47.Margin = New Padding(5, 0, 5, 0)
        DarkLabel47.Name = "DarkLabel47"
        DarkLabel47.Size = New Size(60, 25)
        DarkLabel47.TabIndex = 3
        DarkLabel47.Text = "Set To"
        ' 
        ' cmbSetSelfSwitchTo
        ' 
        cmbSetSelfSwitchTo.DrawMode = DrawMode.OwnerDrawFixed
        cmbSetSelfSwitchTo.FormattingEnabled = True
        cmbSetSelfSwitchTo.Items.AddRange(New Object() {"Off", "On"})
        cmbSetSelfSwitchTo.Location = New Point(120, 88)
        cmbSetSelfSwitchTo.Margin = New Padding(5)
        cmbSetSelfSwitchTo.Name = "cmbSetSelfSwitchTo"
        cmbSetSelfSwitchTo.Size = New Size(277, 32)
        cmbSetSelfSwitchTo.TabIndex = 2
        ' 
        ' DarkLabel46
        ' 
        DarkLabel46.AutoSize = True
        DarkLabel46.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel46.Location = New Point(10, 41)
        DarkLabel46.Margin = New Padding(5, 0, 5, 0)
        DarkLabel46.Name = "DarkLabel46"
        DarkLabel46.Size = New Size(101, 25)
        DarkLabel46.TabIndex = 1
        DarkLabel46.Text = "Self Switch:"
        ' 
        ' cmbSetSelfSwitch
        ' 
        cmbSetSelfSwitch.DrawMode = DrawMode.OwnerDrawFixed
        cmbSetSelfSwitch.FormattingEnabled = True
        cmbSetSelfSwitch.Location = New Point(120, 37)
        cmbSetSelfSwitch.Margin = New Padding(5)
        cmbSetSelfSwitch.Name = "cmbSetSelfSwitch"
        cmbSetSelfSwitch.Size = New Size(277, 32)
        cmbSetSelfSwitch.TabIndex = 0
        ' 
        ' fraPlaySound
        ' 
        fraPlaySound.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraPlaySound.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraPlaySound.Controls.Add(btnPlaySoundOk)
        fraPlaySound.Controls.Add(btnPlaySoundCancel)
        fraPlaySound.Controls.Add(cmbPlaySound)
        fraPlaySound.ForeColor = Color.Gainsboro
        fraPlaySound.Location = New Point(668, 345)
        fraPlaySound.Margin = New Padding(5)
        fraPlaySound.Name = "fraPlaySound"
        fraPlaySound.Padding = New Padding(5)
        fraPlaySound.Size = New Size(410, 147)
        fraPlaySound.TabIndex = 26
        fraPlaySound.TabStop = False
        fraPlaySound.Text = "Play Sound"
        fraPlaySound.Visible = False
        ' 
        ' btnPlaySoundOk
        ' 
        btnPlaySoundOk.Location = New Point(140, 88)
        btnPlaySoundOk.Margin = New Padding(5)
        btnPlaySoundOk.Name = "btnPlaySoundOk"
        btnPlaySoundOk.Padding = New Padding(8, 10, 8, 10)
        btnPlaySoundOk.Size = New Size(125, 45)
        btnPlaySoundOk.TabIndex = 27
        btnPlaySoundOk.Text = "Ok"
        ' 
        ' btnPlaySoundCancel
        ' 
        btnPlaySoundCancel.Location = New Point(275, 88)
        btnPlaySoundCancel.Margin = New Padding(5)
        btnPlaySoundCancel.Name = "btnPlaySoundCancel"
        btnPlaySoundCancel.Padding = New Padding(8, 10, 8, 10)
        btnPlaySoundCancel.Size = New Size(125, 45)
        btnPlaySoundCancel.TabIndex = 26
        btnPlaySoundCancel.Text = "Cancel"
        ' 
        ' cmbPlaySound
        ' 
        cmbPlaySound.DrawMode = DrawMode.OwnerDrawFixed
        cmbPlaySound.FormattingEnabled = True
        cmbPlaySound.Location = New Point(10, 37)
        cmbPlaySound.Margin = New Padding(5)
        cmbPlaySound.Name = "cmbPlaySound"
        cmbPlaySound.Size = New Size(387, 32)
        cmbPlaySound.TabIndex = 0
        ' 
        ' fraChangePK
        ' 
        fraChangePK.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraChangePK.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraChangePK.Controls.Add(btnChangePkOk)
        fraChangePK.Controls.Add(btnChangePkCancel)
        fraChangePK.Controls.Add(cmbSetPK)
        fraChangePK.ForeColor = Color.Gainsboro
        fraChangePK.Location = New Point(668, 200)
        fraChangePK.Margin = New Padding(5)
        fraChangePK.Name = "fraChangePK"
        fraChangePK.Padding = New Padding(5)
        fraChangePK.Size = New Size(410, 145)
        fraChangePK.TabIndex = 25
        fraChangePK.TabStop = False
        fraChangePK.Text = "Set Player PK"
        fraChangePK.Visible = False
        ' 
        ' btnChangePkOk
        ' 
        btnChangePkOk.Location = New Point(133, 88)
        btnChangePkOk.Margin = New Padding(5)
        btnChangePkOk.Name = "btnChangePkOk"
        btnChangePkOk.Padding = New Padding(8, 10, 8, 10)
        btnChangePkOk.Size = New Size(125, 45)
        btnChangePkOk.TabIndex = 27
        btnChangePkOk.Text = "Ok"
        ' 
        ' btnChangePkCancel
        ' 
        btnChangePkCancel.Location = New Point(268, 88)
        btnChangePkCancel.Margin = New Padding(5)
        btnChangePkCancel.Name = "btnChangePkCancel"
        btnChangePkCancel.Padding = New Padding(8, 10, 8, 10)
        btnChangePkCancel.Size = New Size(125, 45)
        btnChangePkCancel.TabIndex = 26
        btnChangePkCancel.Text = "Cancel"
        ' 
        ' cmbSetPK
        ' 
        cmbSetPK.DrawMode = DrawMode.OwnerDrawFixed
        cmbSetPK.FormattingEnabled = True
        cmbSetPK.Items.AddRange(New Object() {"No", "Yes"})
        cmbSetPK.Location = New Point(17, 37)
        cmbSetPK.Margin = New Padding(5)
        cmbSetPK.Name = "cmbSetPK"
        cmbSetPK.Size = New Size(374, 32)
        cmbSetPK.TabIndex = 18
        ' 
        ' fraCreateLabel
        ' 
        fraCreateLabel.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraCreateLabel.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraCreateLabel.Controls.Add(btnCreatelabelOk)
        fraCreateLabel.Controls.Add(btnCreatelabelCancel)
        fraCreateLabel.Controls.Add(txtLabelName)
        fraCreateLabel.Controls.Add(lblLabelName)
        fraCreateLabel.ForeColor = Color.Gainsboro
        fraCreateLabel.Location = New Point(668, 253)
        fraCreateLabel.Margin = New Padding(5)
        fraCreateLabel.Name = "fraCreateLabel"
        fraCreateLabel.Padding = New Padding(5)
        fraCreateLabel.Size = New Size(410, 141)
        fraCreateLabel.TabIndex = 24
        fraCreateLabel.TabStop = False
        fraCreateLabel.Text = "Create Label"
        fraCreateLabel.Visible = False
        ' 
        ' btnCreatelabelOk
        ' 
        btnCreatelabelOk.Location = New Point(140, 87)
        btnCreatelabelOk.Margin = New Padding(5)
        btnCreatelabelOk.Name = "btnCreatelabelOk"
        btnCreatelabelOk.Padding = New Padding(8, 10, 8, 10)
        btnCreatelabelOk.Size = New Size(125, 45)
        btnCreatelabelOk.TabIndex = 27
        btnCreatelabelOk.Text = "Ok"
        ' 
        ' btnCreatelabelCancel
        ' 
        btnCreatelabelCancel.Location = New Point(275, 87)
        btnCreatelabelCancel.Margin = New Padding(5)
        btnCreatelabelCancel.Name = "btnCreatelabelCancel"
        btnCreatelabelCancel.Padding = New Padding(8, 10, 8, 10)
        btnCreatelabelCancel.Size = New Size(125, 45)
        btnCreatelabelCancel.TabIndex = 26
        btnCreatelabelCancel.Text = "Cancel"
        ' 
        ' txtLabelName
        ' 
        txtLabelName.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtLabelName.BorderStyle = BorderStyle.FixedSingle
        txtLabelName.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtLabelName.Location = New Point(133, 37)
        txtLabelName.Margin = New Padding(5)
        txtLabelName.Name = "txtLabelName"
        txtLabelName.Size = New Size(265, 31)
        txtLabelName.TabIndex = 1
        ' 
        ' lblLabelName
        ' 
        lblLabelName.AutoSize = True
        lblLabelName.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        lblLabelName.Location = New Point(12, 40)
        lblLabelName.Margin = New Padding(5, 0, 5, 0)
        lblLabelName.Name = "lblLabelName"
        lblLabelName.Size = New Size(109, 25)
        lblLabelName.TabIndex = 0
        lblLabelName.Text = "Label Name:"
        ' 
        ' fraChangeJob
        ' 
        fraChangeJob.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraChangeJob.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraChangeJob.Controls.Add(btnChangeJobOk)
        fraChangeJob.Controls.Add(btnChangeJobCancel)
        fraChangeJob.Controls.Add(cmbChangeJob)
        fraChangeJob.Controls.Add(DarkLabel38)
        fraChangeJob.ForeColor = Color.Gainsboro
        fraChangeJob.Location = New Point(668, 210)
        fraChangeJob.Margin = New Padding(5)
        fraChangeJob.Name = "fraChangeJob"
        fraChangeJob.Padding = New Padding(5)
        fraChangeJob.Size = New Size(410, 147)
        fraChangeJob.TabIndex = 23
        fraChangeJob.TabStop = False
        fraChangeJob.Text = "Change Player Job"
        fraChangeJob.Visible = False
        ' 
        ' btnChangeJobOk
        ' 
        btnChangeJobOk.Location = New Point(140, 88)
        btnChangeJobOk.Margin = New Padding(5)
        btnChangeJobOk.Name = "btnChangeJobOk"
        btnChangeJobOk.Padding = New Padding(8, 10, 8, 10)
        btnChangeJobOk.Size = New Size(125, 45)
        btnChangeJobOk.TabIndex = 27
        btnChangeJobOk.Text = "Ok"
        ' 
        ' btnChangeJobCancel
        ' 
        btnChangeJobCancel.Location = New Point(275, 88)
        btnChangeJobCancel.Margin = New Padding(5)
        btnChangeJobCancel.Name = "btnChangeJobCancel"
        btnChangeJobCancel.Padding = New Padding(8, 10, 8, 10)
        btnChangeJobCancel.Size = New Size(125, 45)
        btnChangeJobCancel.TabIndex = 26
        btnChangeJobCancel.Text = "Cancel"
        ' 
        ' cmbChangeJob
        ' 
        cmbChangeJob.DrawMode = DrawMode.OwnerDrawFixed
        cmbChangeJob.FormattingEnabled = True
        cmbChangeJob.Location = New Point(82, 37)
        cmbChangeJob.Margin = New Padding(5)
        cmbChangeJob.Name = "cmbChangeJob"
        cmbChangeJob.Size = New Size(316, 32)
        cmbChangeJob.TabIndex = 1
        ' 
        ' DarkLabel38
        ' 
        DarkLabel38.AutoSize = True
        DarkLabel38.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel38.Location = New Point(13, 41)
        DarkLabel38.Margin = New Padding(5, 0, 5, 0)
        DarkLabel38.Name = "DarkLabel38"
        DarkLabel38.Size = New Size(44, 25)
        DarkLabel38.TabIndex = 0
        DarkLabel38.Text = "Job:"
        ' 
        ' fraChangeSkills
        ' 
        fraChangeSkills.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraChangeSkills.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraChangeSkills.Controls.Add(btnChangeSkillsOk)
        fraChangeSkills.Controls.Add(btnChangeSkillsCancel)
        fraChangeSkills.Controls.Add(optChangeSkillsRemove)
        fraChangeSkills.Controls.Add(optChangeSkillsAdd)
        fraChangeSkills.Controls.Add(cmbChangeSkills)
        fraChangeSkills.Controls.Add(DarkLabel37)
        fraChangeSkills.ForeColor = Color.Gainsboro
        fraChangeSkills.Location = New Point(668, 209)
        fraChangeSkills.Margin = New Padding(5)
        fraChangeSkills.Name = "fraChangeSkills"
        fraChangeSkills.Padding = New Padding(5)
        fraChangeSkills.Size = New Size(410, 188)
        fraChangeSkills.TabIndex = 22
        fraChangeSkills.TabStop = False
        fraChangeSkills.Text = "Change Player Skills"
        fraChangeSkills.Visible = False
        ' 
        ' btnChangeSkillsOk
        ' 
        btnChangeSkillsOk.Location = New Point(140, 128)
        btnChangeSkillsOk.Margin = New Padding(5)
        btnChangeSkillsOk.Name = "btnChangeSkillsOk"
        btnChangeSkillsOk.Padding = New Padding(8, 10, 8, 10)
        btnChangeSkillsOk.Size = New Size(125, 45)
        btnChangeSkillsOk.TabIndex = 27
        btnChangeSkillsOk.Text = "Ok"
        ' 
        ' btnChangeSkillsCancel
        ' 
        btnChangeSkillsCancel.Location = New Point(275, 128)
        btnChangeSkillsCancel.Margin = New Padding(5)
        btnChangeSkillsCancel.Name = "btnChangeSkillsCancel"
        btnChangeSkillsCancel.Padding = New Padding(8, 10, 8, 10)
        btnChangeSkillsCancel.Size = New Size(125, 45)
        btnChangeSkillsCancel.TabIndex = 26
        btnChangeSkillsCancel.Text = "Cancel"
        ' 
        ' optChangeSkillsRemove
        ' 
        optChangeSkillsRemove.AutoSize = True
        optChangeSkillsRemove.Location = New Point(245, 85)
        optChangeSkillsRemove.Margin = New Padding(5)
        optChangeSkillsRemove.Name = "optChangeSkillsRemove"
        optChangeSkillsRemove.Size = New Size(89, 29)
        optChangeSkillsRemove.TabIndex = 3
        optChangeSkillsRemove.TabStop = True
        optChangeSkillsRemove.Text = "Forget"
        ' 
        ' optChangeSkillsAdd
        ' 
        optChangeSkillsAdd.AutoSize = True
        optChangeSkillsAdd.Location = New Point(108, 85)
        optChangeSkillsAdd.Margin = New Padding(5)
        optChangeSkillsAdd.Name = "optChangeSkillsAdd"
        optChangeSkillsAdd.Size = New Size(80, 29)
        optChangeSkillsAdd.TabIndex = 2
        optChangeSkillsAdd.TabStop = True
        optChangeSkillsAdd.Text = "Teach"
        ' 
        ' cmbChangeSkills
        ' 
        cmbChangeSkills.DrawMode = DrawMode.OwnerDrawFixed
        cmbChangeSkills.FormattingEnabled = True
        cmbChangeSkills.Location = New Point(68, 34)
        cmbChangeSkills.Margin = New Padding(5)
        cmbChangeSkills.Name = "cmbChangeSkills"
        cmbChangeSkills.Size = New Size(327, 32)
        cmbChangeSkills.TabIndex = 1
        ' 
        ' DarkLabel37
        ' 
        DarkLabel37.AutoSize = True
        DarkLabel37.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel37.Location = New Point(10, 38)
        DarkLabel37.Margin = New Padding(5, 0, 5, 0)
        DarkLabel37.Name = "DarkLabel37"
        DarkLabel37.Size = New Size(47, 25)
        DarkLabel37.TabIndex = 0
        DarkLabel37.Text = "Skill:"
        ' 
        ' fraPlayerSwitch
        ' 
        fraPlayerSwitch.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraPlayerSwitch.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraPlayerSwitch.Controls.Add(btnSetPlayerSwitchOk)
        fraPlayerSwitch.Controls.Add(btnSetPlayerswitchCancel)
        fraPlayerSwitch.Controls.Add(cmbPlayerSwitchSet)
        fraPlayerSwitch.Controls.Add(DarkLabel23)
        fraPlayerSwitch.Controls.Add(cmbSwitch)
        fraPlayerSwitch.Controls.Add(DarkLabel22)
        fraPlayerSwitch.ForeColor = Color.Gainsboro
        fraPlayerSwitch.Location = New Point(355, 750)
        fraPlayerSwitch.Margin = New Padding(5)
        fraPlayerSwitch.Name = "fraPlayerSwitch"
        fraPlayerSwitch.Padding = New Padding(5)
        fraPlayerSwitch.Size = New Size(303, 191)
        fraPlayerSwitch.TabIndex = 2
        fraPlayerSwitch.TabStop = False
        fraPlayerSwitch.Text = "Change Items"
        fraPlayerSwitch.Visible = False
        ' 
        ' btnSetPlayerSwitchOk
        ' 
        btnSetPlayerSwitchOk.Location = New Point(33, 138)
        btnSetPlayerSwitchOk.Margin = New Padding(5)
        btnSetPlayerSwitchOk.Name = "btnSetPlayerSwitchOk"
        btnSetPlayerSwitchOk.Padding = New Padding(8, 10, 8, 10)
        btnSetPlayerSwitchOk.Size = New Size(125, 45)
        btnSetPlayerSwitchOk.TabIndex = 9
        btnSetPlayerSwitchOk.Text = "Ok"
        ' 
        ' btnSetPlayerswitchCancel
        ' 
        btnSetPlayerswitchCancel.Location = New Point(168, 138)
        btnSetPlayerswitchCancel.Margin = New Padding(5)
        btnSetPlayerswitchCancel.Name = "btnSetPlayerswitchCancel"
        btnSetPlayerswitchCancel.Padding = New Padding(8, 10, 8, 10)
        btnSetPlayerswitchCancel.Size = New Size(125, 45)
        btnSetPlayerswitchCancel.TabIndex = 8
        btnSetPlayerswitchCancel.Text = "Cancel"
        ' 
        ' cmbPlayerSwitchSet
        ' 
        cmbPlayerSwitchSet.DrawMode = DrawMode.OwnerDrawFixed
        cmbPlayerSwitchSet.FormattingEnabled = True
        cmbPlayerSwitchSet.Items.AddRange(New Object() {"False", "True"})
        cmbPlayerSwitchSet.Location = New Point(85, 78)
        cmbPlayerSwitchSet.Margin = New Padding(5)
        cmbPlayerSwitchSet.Name = "cmbPlayerSwitchSet"
        cmbPlayerSwitchSet.Size = New Size(206, 32)
        cmbPlayerSwitchSet.TabIndex = 3
        ' 
        ' DarkLabel23
        ' 
        DarkLabel23.AutoSize = True
        DarkLabel23.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel23.Location = New Point(10, 88)
        DarkLabel23.Margin = New Padding(5, 0, 5, 0)
        DarkLabel23.Name = "DarkLabel23"
        DarkLabel23.Size = New Size(59, 25)
        DarkLabel23.TabIndex = 2
        DarkLabel23.Text = "Set to"
        ' 
        ' cmbSwitch
        ' 
        cmbSwitch.DrawMode = DrawMode.OwnerDrawFixed
        cmbSwitch.FormattingEnabled = True
        cmbSwitch.Location = New Point(85, 25)
        cmbSwitch.Margin = New Padding(5)
        cmbSwitch.Name = "cmbSwitch"
        cmbSwitch.Size = New Size(206, 32)
        cmbSwitch.TabIndex = 1
        ' 
        ' DarkLabel22
        ' 
        DarkLabel22.AutoSize = True
        DarkLabel22.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel22.Location = New Point(10, 30)
        DarkLabel22.Margin = New Padding(5, 0, 5, 0)
        DarkLabel22.Name = "DarkLabel22"
        DarkLabel22.Size = New Size(63, 25)
        DarkLabel22.TabIndex = 0
        DarkLabel22.Text = "Switch"
        ' 
        ' fraSetWait
        ' 
        fraSetWait.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraSetWait.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraSetWait.Controls.Add(btnSetWaitOk)
        fraSetWait.Controls.Add(btnSetWaitCancel)
        fraSetWait.Controls.Add(DarkLabel74)
        fraSetWait.Controls.Add(DarkLabel72)
        fraSetWait.Controls.Add(DarkLabel73)
        fraSetWait.Controls.Add(nudWaitAmount)
        fraSetWait.ForeColor = Color.Gainsboro
        fraSetWait.Location = New Point(668, 509)
        fraSetWait.Margin = New Padding(5)
        fraSetWait.Name = "fraSetWait"
        fraSetWait.Padding = New Padding(5)
        fraSetWait.Size = New Size(413, 172)
        fraSetWait.TabIndex = 41
        fraSetWait.TabStop = False
        fraSetWait.Text = "Wait..."
        fraSetWait.Visible = False
        ' 
        ' btnSetWaitOk
        ' 
        btnSetWaitOk.Location = New Point(83, 112)
        btnSetWaitOk.Margin = New Padding(5)
        btnSetWaitOk.Name = "btnSetWaitOk"
        btnSetWaitOk.Padding = New Padding(8, 10, 8, 10)
        btnSetWaitOk.Size = New Size(125, 45)
        btnSetWaitOk.TabIndex = 37
        btnSetWaitOk.Text = "Ok"
        ' 
        ' btnSetWaitCancel
        ' 
        btnSetWaitCancel.Location = New Point(218, 112)
        btnSetWaitCancel.Margin = New Padding(5)
        btnSetWaitCancel.Name = "btnSetWaitCancel"
        btnSetWaitCancel.Padding = New Padding(8, 10, 8, 10)
        btnSetWaitCancel.Size = New Size(125, 45)
        btnSetWaitCancel.TabIndex = 36
        btnSetWaitCancel.Text = "Cancel"
        ' 
        ' DarkLabel74
        ' 
        DarkLabel74.AutoSize = True
        DarkLabel74.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel74.Location = New Point(117, 80)
        DarkLabel74.Margin = New Padding(5, 0, 5, 0)
        DarkLabel74.Name = "DarkLabel74"
        DarkLabel74.Size = New Size(187, 25)
        DarkLabel74.TabIndex = 35
        DarkLabel74.Text = "Hint: 1000 Ms = 1 Sec"
        ' 
        ' DarkLabel72
        ' 
        DarkLabel72.AutoSize = True
        DarkLabel72.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel72.Location = New Point(363, 45)
        DarkLabel72.Margin = New Padding(5, 0, 5, 0)
        DarkLabel72.Name = "DarkLabel72"
        DarkLabel72.Size = New Size(36, 25)
        DarkLabel72.TabIndex = 34
        DarkLabel72.Text = "Ms"
        ' 
        ' DarkLabel73
        ' 
        DarkLabel73.AutoSize = True
        DarkLabel73.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel73.Location = New Point(25, 45)
        DarkLabel73.Margin = New Padding(5, 0, 5, 0)
        DarkLabel73.Name = "DarkLabel73"
        DarkLabel73.Size = New Size(47, 25)
        DarkLabel73.TabIndex = 33
        DarkLabel73.Text = "Wait"
        ' 
        ' nudWaitAmount
        ' 
        nudWaitAmount.Location = New Point(83, 37)
        nudWaitAmount.Margin = New Padding(5)
        nudWaitAmount.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        nudWaitAmount.Name = "nudWaitAmount"
        nudWaitAmount.Size = New Size(272, 31)
        nudWaitAmount.TabIndex = 32
        ' 
        ' fraMoveRouteWait
        ' 
        fraMoveRouteWait.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraMoveRouteWait.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraMoveRouteWait.Controls.Add(btnMoveWaitCancel)
        fraMoveRouteWait.Controls.Add(btnMoveWaitOk)
        fraMoveRouteWait.Controls.Add(DarkLabel79)
        fraMoveRouteWait.Controls.Add(cmbMoveWait)
        fraMoveRouteWait.ForeColor = Color.Gainsboro
        fraMoveRouteWait.Location = New Point(668, 952)
        fraMoveRouteWait.Margin = New Padding(5)
        fraMoveRouteWait.Name = "fraMoveRouteWait"
        fraMoveRouteWait.Padding = New Padding(5)
        fraMoveRouteWait.Size = New Size(413, 145)
        fraMoveRouteWait.TabIndex = 48
        fraMoveRouteWait.TabStop = False
        fraMoveRouteWait.Text = "Move Route Wait"
        fraMoveRouteWait.Visible = False
        ' 
        ' btnMoveWaitCancel
        ' 
        btnMoveWaitCancel.Location = New Point(278, 88)
        btnMoveWaitCancel.Margin = New Padding(5)
        btnMoveWaitCancel.Name = "btnMoveWaitCancel"
        btnMoveWaitCancel.Padding = New Padding(8, 10, 8, 10)
        btnMoveWaitCancel.Size = New Size(125, 45)
        btnMoveWaitCancel.TabIndex = 26
        btnMoveWaitCancel.Text = "Cancel"
        ' 
        ' btnMoveWaitOk
        ' 
        btnMoveWaitOk.Location = New Point(143, 88)
        btnMoveWaitOk.Margin = New Padding(5)
        btnMoveWaitOk.Name = "btnMoveWaitOk"
        btnMoveWaitOk.Padding = New Padding(8, 10, 8, 10)
        btnMoveWaitOk.Size = New Size(125, 45)
        btnMoveWaitOk.TabIndex = 27
        btnMoveWaitOk.Text = "Ok"
        ' 
        ' DarkLabel79
        ' 
        DarkLabel79.AutoSize = True
        DarkLabel79.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel79.Location = New Point(12, 41)
        DarkLabel79.Margin = New Padding(5, 0, 5, 0)
        DarkLabel79.Name = "DarkLabel79"
        DarkLabel79.Size = New Size(59, 25)
        DarkLabel79.TabIndex = 1
        DarkLabel79.Text = "Event:"
        ' 
        ' cmbMoveWait
        ' 
        cmbMoveWait.DrawMode = DrawMode.OwnerDrawFixed
        cmbMoveWait.FormattingEnabled = True
        cmbMoveWait.Location = New Point(85, 37)
        cmbMoveWait.Margin = New Padding(5)
        cmbMoveWait.Name = "cmbMoveWait"
        cmbMoveWait.Size = New Size(316, 32)
        cmbMoveWait.TabIndex = 0
        ' 
        ' fraCustomScript
        ' 
        fraCustomScript.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraCustomScript.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraCustomScript.Controls.Add(nudCustomScript)
        fraCustomScript.Controls.Add(DarkLabel78)
        fraCustomScript.Controls.Add(btnCustomScriptCancel)
        fraCustomScript.Controls.Add(btnCustomScriptOk)
        fraCustomScript.ForeColor = Color.Gainsboro
        fraCustomScript.Location = New Point(668, 762)
        fraCustomScript.Margin = New Padding(5)
        fraCustomScript.Name = "fraCustomScript"
        fraCustomScript.Padding = New Padding(5)
        fraCustomScript.Size = New Size(413, 184)
        fraCustomScript.TabIndex = 47
        fraCustomScript.TabStop = False
        fraCustomScript.Text = "Execute Custom Script"
        fraCustomScript.Visible = False
        ' 
        ' nudCustomScript
        ' 
        nudCustomScript.Location = New Point(112, 37)
        nudCustomScript.Margin = New Padding(5)
        nudCustomScript.Name = "nudCustomScript"
        nudCustomScript.Size = New Size(282, 31)
        nudCustomScript.TabIndex = 1
        ' 
        ' DarkLabel78
        ' 
        DarkLabel78.AutoSize = True
        DarkLabel78.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel78.Location = New Point(17, 40)
        DarkLabel78.Margin = New Padding(5, 0, 5, 0)
        DarkLabel78.Name = "DarkLabel78"
        DarkLabel78.Size = New Size(53, 25)
        DarkLabel78.TabIndex = 0
        DarkLabel78.Text = "Case:"
        ' 
        ' btnCustomScriptCancel
        ' 
        btnCustomScriptCancel.Location = New Point(268, 87)
        btnCustomScriptCancel.Margin = New Padding(5)
        btnCustomScriptCancel.Name = "btnCustomScriptCancel"
        btnCustomScriptCancel.Padding = New Padding(8, 10, 8, 10)
        btnCustomScriptCancel.Size = New Size(125, 45)
        btnCustomScriptCancel.TabIndex = 24
        btnCustomScriptCancel.Text = "Cancel"
        ' 
        ' btnCustomScriptOk
        ' 
        btnCustomScriptOk.Location = New Point(133, 87)
        btnCustomScriptOk.Margin = New Padding(5)
        btnCustomScriptOk.Name = "btnCustomScriptOk"
        btnCustomScriptOk.Padding = New Padding(8, 10, 8, 10)
        btnCustomScriptOk.Size = New Size(125, 45)
        btnCustomScriptOk.TabIndex = 25
        btnCustomScriptOk.Text = "Ok"
        ' 
        ' fraSpawnNpc
        ' 
        fraSpawnNpc.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraSpawnNpc.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraSpawnNpc.Controls.Add(btnSpawnNpcOk)
        fraSpawnNpc.Controls.Add(btnSpawnNpcCancel)
        fraSpawnNpc.Controls.Add(cmbSpawnNpc)
        fraSpawnNpc.ForeColor = Color.Gainsboro
        fraSpawnNpc.Location = New Point(668, 791)
        fraSpawnNpc.Margin = New Padding(5)
        fraSpawnNpc.Name = "fraSpawnNpc"
        fraSpawnNpc.Padding = New Padding(5)
        fraSpawnNpc.Size = New Size(413, 148)
        fraSpawnNpc.TabIndex = 46
        fraSpawnNpc.TabStop = False
        fraSpawnNpc.Text = "Spawn Npc"
        fraSpawnNpc.Visible = False
        ' 
        ' btnSpawnNpcOk
        ' 
        btnSpawnNpcOk.Location = New Point(77, 90)
        btnSpawnNpcOk.Margin = New Padding(5)
        btnSpawnNpcOk.Name = "btnSpawnNpcOk"
        btnSpawnNpcOk.Padding = New Padding(8, 10, 8, 10)
        btnSpawnNpcOk.Size = New Size(125, 45)
        btnSpawnNpcOk.TabIndex = 27
        btnSpawnNpcOk.Text = "Ok"
        ' 
        ' btnSpawnNpcCancel
        ' 
        btnSpawnNpcCancel.Location = New Point(212, 90)
        btnSpawnNpcCancel.Margin = New Padding(5)
        btnSpawnNpcCancel.Name = "btnSpawnNpcCancel"
        btnSpawnNpcCancel.Padding = New Padding(8, 10, 8, 10)
        btnSpawnNpcCancel.Size = New Size(125, 45)
        btnSpawnNpcCancel.TabIndex = 26
        btnSpawnNpcCancel.Text = "Cancel"
        ' 
        ' cmbSpawnNpc
        ' 
        cmbSpawnNpc.DrawMode = DrawMode.OwnerDrawFixed
        cmbSpawnNpc.FormattingEnabled = True
        cmbSpawnNpc.Location = New Point(10, 37)
        cmbSpawnNpc.Margin = New Padding(5)
        cmbSpawnNpc.Name = "cmbSpawnNpc"
        cmbSpawnNpc.Size = New Size(387, 32)
        cmbSpawnNpc.TabIndex = 0
        ' 
        ' fraSetWeather
        ' 
        fraSetWeather.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraSetWeather.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraSetWeather.Controls.Add(btnSetWeatherOk)
        fraSetWeather.Controls.Add(btnSetWeatherCancel)
        fraSetWeather.Controls.Add(DarkLabel76)
        fraSetWeather.Controls.Add(nudWeatherIntensity)
        fraSetWeather.Controls.Add(DarkLabel75)
        fraSetWeather.Controls.Add(CmbWeather)
        fraSetWeather.ForeColor = Color.Gainsboro
        fraSetWeather.Location = New Point(668, 677)
        fraSetWeather.Margin = New Padding(5)
        fraSetWeather.Name = "fraSetWeather"
        fraSetWeather.Padding = New Padding(5)
        fraSetWeather.Size = New Size(413, 184)
        fraSetWeather.TabIndex = 44
        fraSetWeather.TabStop = False
        fraSetWeather.Text = "Set Weather"
        fraSetWeather.Visible = False
        ' 
        ' btnSetWeatherOk
        ' 
        btnSetWeatherOk.Location = New Point(77, 127)
        btnSetWeatherOk.Margin = New Padding(5)
        btnSetWeatherOk.Name = "btnSetWeatherOk"
        btnSetWeatherOk.Padding = New Padding(8, 10, 8, 10)
        btnSetWeatherOk.Size = New Size(125, 45)
        btnSetWeatherOk.TabIndex = 34
        btnSetWeatherOk.Text = "Ok"
        ' 
        ' btnSetWeatherCancel
        ' 
        btnSetWeatherCancel.Location = New Point(212, 127)
        btnSetWeatherCancel.Margin = New Padding(5)
        btnSetWeatherCancel.Name = "btnSetWeatherCancel"
        btnSetWeatherCancel.Padding = New Padding(8, 10, 8, 10)
        btnSetWeatherCancel.Size = New Size(125, 45)
        btnSetWeatherCancel.TabIndex = 33
        btnSetWeatherCancel.Text = "Cancel"
        ' 
        ' DarkLabel76
        ' 
        DarkLabel76.AutoSize = True
        DarkLabel76.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel76.Location = New Point(13, 85)
        DarkLabel76.Margin = New Padding(5, 0, 5, 0)
        DarkLabel76.Name = "DarkLabel76"
        DarkLabel76.Size = New Size(83, 25)
        DarkLabel76.TabIndex = 32
        DarkLabel76.Text = "Intensity:"
        ' 
        ' nudWeatherIntensity
        ' 
        nudWeatherIntensity.Location = New Point(145, 78)
        nudWeatherIntensity.Margin = New Padding(5)
        nudWeatherIntensity.Name = "nudWeatherIntensity"
        nudWeatherIntensity.Size = New Size(258, 31)
        nudWeatherIntensity.TabIndex = 31
        ' 
        ' DarkLabel75
        ' 
        DarkLabel75.AutoSize = True
        DarkLabel75.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel75.Location = New Point(10, 35)
        DarkLabel75.Margin = New Padding(5, 0, 5, 0)
        DarkLabel75.Name = "DarkLabel75"
        DarkLabel75.Size = New Size(119, 25)
        DarkLabel75.TabIndex = 1
        DarkLabel75.Text = "Weather Type"
        ' 
        ' CmbWeather
        ' 
        CmbWeather.DrawMode = DrawMode.OwnerDrawFixed
        CmbWeather.FormattingEnabled = True
        CmbWeather.Items.AddRange(New Object() {"None", "Rain", "Snow", "Hail", "Sand Storm", "Storm"})
        CmbWeather.Location = New Point(143, 28)
        CmbWeather.Margin = New Padding(5)
        CmbWeather.Name = "CmbWeather"
        CmbWeather.Size = New Size(256, 32)
        CmbWeather.TabIndex = 0
        ' 
        ' fraGiveExp
        ' 
        fraGiveExp.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraGiveExp.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraGiveExp.Controls.Add(btnGiveExpOk)
        fraGiveExp.Controls.Add(btnGiveExpCancel)
        fraGiveExp.Controls.Add(nudGiveExp)
        fraGiveExp.Controls.Add(DarkLabel77)
        fraGiveExp.ForeColor = Color.Gainsboro
        fraGiveExp.Location = New Point(668, 677)
        fraGiveExp.Margin = New Padding(5)
        fraGiveExp.Name = "fraGiveExp"
        fraGiveExp.Padding = New Padding(5)
        fraGiveExp.Size = New Size(413, 140)
        fraGiveExp.TabIndex = 45
        fraGiveExp.TabStop = False
        fraGiveExp.Text = "Give Experience"
        fraGiveExp.Visible = False
        ' 
        ' btnGiveExpOk
        ' 
        btnGiveExpOk.Location = New Point(83, 87)
        btnGiveExpOk.Margin = New Padding(5)
        btnGiveExpOk.Name = "btnGiveExpOk"
        btnGiveExpOk.Padding = New Padding(8, 10, 8, 10)
        btnGiveExpOk.Size = New Size(125, 45)
        btnGiveExpOk.TabIndex = 27
        btnGiveExpOk.Text = "Ok"
        ' 
        ' btnGiveExpCancel
        ' 
        btnGiveExpCancel.Location = New Point(218, 87)
        btnGiveExpCancel.Margin = New Padding(5)
        btnGiveExpCancel.Name = "btnGiveExpCancel"
        btnGiveExpCancel.Padding = New Padding(8, 10, 8, 10)
        btnGiveExpCancel.Size = New Size(125, 45)
        btnGiveExpCancel.TabIndex = 26
        btnGiveExpCancel.Text = "Cancel"
        ' 
        ' nudGiveExp
        ' 
        nudGiveExp.Location = New Point(128, 37)
        nudGiveExp.Margin = New Padding(5)
        nudGiveExp.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        nudGiveExp.Name = "nudGiveExp"
        nudGiveExp.Size = New Size(275, 31)
        nudGiveExp.TabIndex = 20
        ' 
        ' DarkLabel77
        ' 
        DarkLabel77.AutoSize = True
        DarkLabel77.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel77.Location = New Point(10, 40)
        DarkLabel77.Margin = New Padding(5, 0, 5, 0)
        DarkLabel77.Name = "DarkLabel77"
        DarkLabel77.Size = New Size(83, 25)
        DarkLabel77.TabIndex = 0
        DarkLabel77.Text = "Give Exp:"
        ' 
        ' fraSetAccess
        ' 
        fraSetAccess.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraSetAccess.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraSetAccess.Controls.Add(btnSetAccessOk)
        fraSetAccess.Controls.Add(btnSetAccessCancel)
        fraSetAccess.Controls.Add(cmbSetAccess)
        fraSetAccess.ForeColor = Color.Gainsboro
        fraSetAccess.Location = New Point(668, 678)
        fraSetAccess.Margin = New Padding(5)
        fraSetAccess.Name = "fraSetAccess"
        fraSetAccess.Padding = New Padding(5)
        fraSetAccess.Size = New Size(413, 153)
        fraSetAccess.TabIndex = 42
        fraSetAccess.TabStop = False
        fraSetAccess.Text = "Set Access"
        fraSetAccess.Visible = False
        ' 
        ' btnSetAccessOk
        ' 
        btnSetAccessOk.Location = New Point(77, 91)
        btnSetAccessOk.Margin = New Padding(5)
        btnSetAccessOk.Name = "btnSetAccessOk"
        btnSetAccessOk.Padding = New Padding(8, 10, 8, 10)
        btnSetAccessOk.Size = New Size(125, 45)
        btnSetAccessOk.TabIndex = 27
        btnSetAccessOk.Text = "Ok"
        ' 
        ' btnSetAccessCancel
        ' 
        btnSetAccessCancel.Location = New Point(212, 91)
        btnSetAccessCancel.Margin = New Padding(5)
        btnSetAccessCancel.Name = "btnSetAccessCancel"
        btnSetAccessCancel.Padding = New Padding(8, 10, 8, 10)
        btnSetAccessCancel.Size = New Size(125, 45)
        btnSetAccessCancel.TabIndex = 26
        btnSetAccessCancel.Text = "Cancel"
        ' 
        ' cmbSetAccess
        ' 
        cmbSetAccess.DrawMode = DrawMode.OwnerDrawFixed
        cmbSetAccess.FormattingEnabled = True
        cmbSetAccess.Items.AddRange(New Object() {"0: Player", "1: Moderator", "2: Mapper", "3: Developer", "4: Creator"})
        cmbSetAccess.Location = New Point(55, 37)
        cmbSetAccess.Margin = New Padding(5)
        cmbSetAccess.Name = "cmbSetAccess"
        cmbSetAccess.Size = New Size(311, 32)
        cmbSetAccess.TabIndex = 0
        ' 
        ' fraChangeGender
        ' 
        fraChangeGender.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraChangeGender.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraChangeGender.Controls.Add(btnChangeGenderOk)
        fraChangeGender.Controls.Add(btnChangeGenderCancel)
        fraChangeGender.Controls.Add(optChangeSexFemale)
        fraChangeGender.Controls.Add(optChangeSexMale)
        fraChangeGender.ForeColor = Color.Gainsboro
        fraChangeGender.Location = New Point(668, 700)
        fraChangeGender.Margin = New Padding(5)
        fraChangeGender.Name = "fraChangeGender"
        fraChangeGender.Padding = New Padding(5)
        fraChangeGender.Size = New Size(413, 138)
        fraChangeGender.TabIndex = 37
        fraChangeGender.TabStop = False
        fraChangeGender.Text = "Change Player Gender"
        fraChangeGender.Visible = False
        ' 
        ' btnChangeGenderOk
        ' 
        btnChangeGenderOk.Location = New Point(65, 80)
        btnChangeGenderOk.Margin = New Padding(5)
        btnChangeGenderOk.Name = "btnChangeGenderOk"
        btnChangeGenderOk.Padding = New Padding(8, 10, 8, 10)
        btnChangeGenderOk.Size = New Size(125, 45)
        btnChangeGenderOk.TabIndex = 27
        btnChangeGenderOk.Text = "Ok"
        ' 
        ' btnChangeGenderCancel
        ' 
        btnChangeGenderCancel.Location = New Point(200, 80)
        btnChangeGenderCancel.Margin = New Padding(5)
        btnChangeGenderCancel.Name = "btnChangeGenderCancel"
        btnChangeGenderCancel.Padding = New Padding(8, 10, 8, 10)
        btnChangeGenderCancel.Size = New Size(125, 45)
        btnChangeGenderCancel.TabIndex = 26
        btnChangeGenderCancel.Text = "Cancel"
        ' 
        ' optChangeSexFemale
        ' 
        optChangeSexFemale.AutoSize = True
        optChangeSexFemale.Location = New Point(235, 37)
        optChangeSexFemale.Margin = New Padding(5)
        optChangeSexFemale.Name = "optChangeSexFemale"
        optChangeSexFemale.Size = New Size(93, 29)
        optChangeSexFemale.TabIndex = 1
        optChangeSexFemale.TabStop = True
        optChangeSexFemale.Text = "Female"
        ' 
        ' optChangeSexMale
        ' 
        optChangeSexMale.AutoSize = True
        optChangeSexMale.Location = New Point(87, 37)
        optChangeSexMale.Margin = New Padding(5)
        optChangeSexMale.Name = "optChangeSexMale"
        optChangeSexMale.Size = New Size(75, 29)
        optChangeSexMale.TabIndex = 0
        optChangeSexMale.TabStop = True
        optChangeSexMale.Text = "Male"
        ' 
        ' fraShowChoices
        ' 
        fraShowChoices.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraShowChoices.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraShowChoices.Controls.Add(txtChoices4)
        fraShowChoices.Controls.Add(txtChoices3)
        fraShowChoices.Controls.Add(txtChoices2)
        fraShowChoices.Controls.Add(txtChoices1)
        fraShowChoices.Controls.Add(DarkLabel56)
        fraShowChoices.Controls.Add(DarkLabel57)
        fraShowChoices.Controls.Add(DarkLabel55)
        fraShowChoices.Controls.Add(DarkLabel54)
        fraShowChoices.Controls.Add(DarkLabel52)
        fraShowChoices.Controls.Add(txtChoicePrompt)
        fraShowChoices.Controls.Add(btnShowChoicesOk)
        fraShowChoices.Controls.Add(btnShowChoicesCancel)
        fraShowChoices.ForeColor = Color.Gainsboro
        fraShowChoices.Location = New Point(668, 198)
        fraShowChoices.Margin = New Padding(5)
        fraShowChoices.Name = "fraShowChoices"
        fraShowChoices.Padding = New Padding(5)
        fraShowChoices.Size = New Size(413, 640)
        fraShowChoices.TabIndex = 32
        fraShowChoices.TabStop = False
        fraShowChoices.Text = "Show Choices"
        fraShowChoices.Visible = False
        ' 
        ' txtChoices4
        ' 
        txtChoices4.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtChoices4.BorderStyle = BorderStyle.FixedSingle
        txtChoices4.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtChoices4.Location = New Point(235, 335)
        txtChoices4.Margin = New Padding(5)
        txtChoices4.Name = "txtChoices4"
        txtChoices4.Size = New Size(165, 31)
        txtChoices4.TabIndex = 34
        ' 
        ' txtChoices3
        ' 
        txtChoices3.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtChoices3.BorderStyle = BorderStyle.FixedSingle
        txtChoices3.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtChoices3.Location = New Point(10, 334)
        txtChoices3.Margin = New Padding(5)
        txtChoices3.Name = "txtChoices3"
        txtChoices3.Size = New Size(165, 31)
        txtChoices3.TabIndex = 33
        ' 
        ' txtChoices2
        ' 
        txtChoices2.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtChoices2.BorderStyle = BorderStyle.FixedSingle
        txtChoices2.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtChoices2.Location = New Point(235, 259)
        txtChoices2.Margin = New Padding(5)
        txtChoices2.Name = "txtChoices2"
        txtChoices2.Size = New Size(165, 31)
        txtChoices2.TabIndex = 32
        ' 
        ' txtChoices1
        ' 
        txtChoices1.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtChoices1.BorderStyle = BorderStyle.FixedSingle
        txtChoices1.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtChoices1.Location = New Point(10, 259)
        txtChoices1.Margin = New Padding(5)
        txtChoices1.Name = "txtChoices1"
        txtChoices1.Size = New Size(165, 31)
        txtChoices1.TabIndex = 31
        ' 
        ' DarkLabel56
        ' 
        DarkLabel56.AutoSize = True
        DarkLabel56.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel56.Location = New Point(230, 302)
        DarkLabel56.Margin = New Padding(5, 0, 5, 0)
        DarkLabel56.Name = "DarkLabel56"
        DarkLabel56.Size = New Size(80, 25)
        DarkLabel56.TabIndex = 30
        DarkLabel56.Text = "Choice 4"
        ' 
        ' DarkLabel57
        ' 
        DarkLabel57.AutoSize = True
        DarkLabel57.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel57.Location = New Point(12, 302)
        DarkLabel57.Margin = New Padding(5, 0, 5, 0)
        DarkLabel57.Name = "DarkLabel57"
        DarkLabel57.Size = New Size(80, 25)
        DarkLabel57.TabIndex = 29
        DarkLabel57.Text = "Choice 3"
        ' 
        ' DarkLabel55
        ' 
        DarkLabel55.AutoSize = True
        DarkLabel55.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel55.Location = New Point(230, 227)
        DarkLabel55.Margin = New Padding(5, 0, 5, 0)
        DarkLabel55.Name = "DarkLabel55"
        DarkLabel55.Size = New Size(80, 25)
        DarkLabel55.TabIndex = 28
        DarkLabel55.Text = "Choice 2"
        ' 
        ' DarkLabel54
        ' 
        DarkLabel54.AutoSize = True
        DarkLabel54.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel54.Location = New Point(10, 227)
        DarkLabel54.Margin = New Padding(5, 0, 5, 0)
        DarkLabel54.Name = "DarkLabel54"
        DarkLabel54.Size = New Size(80, 25)
        DarkLabel54.TabIndex = 27
        DarkLabel54.Text = "Choice 1"
        ' 
        ' DarkLabel52
        ' 
        DarkLabel52.AutoSize = True
        DarkLabel52.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel52.Location = New Point(12, 37)
        DarkLabel52.Margin = New Padding(5, 0, 5, 0)
        DarkLabel52.Name = "DarkLabel52"
        DarkLabel52.Size = New Size(72, 25)
        DarkLabel52.TabIndex = 26
        DarkLabel52.Text = "Prompt"
        ' 
        ' txtChoicePrompt
        ' 
        txtChoicePrompt.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtChoicePrompt.BorderStyle = BorderStyle.FixedSingle
        txtChoicePrompt.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtChoicePrompt.Location = New Point(15, 73)
        txtChoicePrompt.Margin = New Padding(5)
        txtChoicePrompt.Multiline = True
        txtChoicePrompt.Name = "txtChoicePrompt"
        txtChoicePrompt.Size = New Size(379, 147)
        txtChoicePrompt.TabIndex = 21
        ' 
        ' btnShowChoicesOk
        ' 
        btnShowChoicesOk.Location = New Point(140, 587)
        btnShowChoicesOk.Margin = New Padding(5)
        btnShowChoicesOk.Name = "btnShowChoicesOk"
        btnShowChoicesOk.Padding = New Padding(8, 10, 8, 10)
        btnShowChoicesOk.Size = New Size(125, 45)
        btnShowChoicesOk.TabIndex = 25
        btnShowChoicesOk.Text = "Ok"
        ' 
        ' btnShowChoicesCancel
        ' 
        btnShowChoicesCancel.Location = New Point(275, 587)
        btnShowChoicesCancel.Margin = New Padding(5)
        btnShowChoicesCancel.Name = "btnShowChoicesCancel"
        btnShowChoicesCancel.Padding = New Padding(8, 10, 8, 10)
        btnShowChoicesCancel.Size = New Size(125, 45)
        btnShowChoicesCancel.TabIndex = 24
        btnShowChoicesCancel.Text = "Cancel"
        ' 
        ' fraChangeLevel
        ' 
        fraChangeLevel.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraChangeLevel.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraChangeLevel.Controls.Add(btnChangeLevelOk)
        fraChangeLevel.Controls.Add(btnChangeLevelCancel)
        fraChangeLevel.Controls.Add(DarkLabel65)
        fraChangeLevel.Controls.Add(nudChangeLevel)
        fraChangeLevel.ForeColor = Color.Gainsboro
        fraChangeLevel.Location = New Point(668, 563)
        fraChangeLevel.Margin = New Padding(5)
        fraChangeLevel.Name = "fraChangeLevel"
        fraChangeLevel.Padding = New Padding(5)
        fraChangeLevel.Size = New Size(413, 138)
        fraChangeLevel.TabIndex = 38
        fraChangeLevel.TabStop = False
        fraChangeLevel.Text = "Change Level"
        fraChangeLevel.Visible = False
        ' 
        ' btnChangeLevelOk
        ' 
        btnChangeLevelOk.Location = New Point(77, 87)
        btnChangeLevelOk.Margin = New Padding(5)
        btnChangeLevelOk.Name = "btnChangeLevelOk"
        btnChangeLevelOk.Padding = New Padding(8, 10, 8, 10)
        btnChangeLevelOk.Size = New Size(125, 45)
        btnChangeLevelOk.TabIndex = 27
        btnChangeLevelOk.Text = "Ok"
        ' 
        ' btnChangeLevelCancel
        ' 
        btnChangeLevelCancel.Location = New Point(212, 87)
        btnChangeLevelCancel.Margin = New Padding(5)
        btnChangeLevelCancel.Name = "btnChangeLevelCancel"
        btnChangeLevelCancel.Padding = New Padding(8, 10, 8, 10)
        btnChangeLevelCancel.Size = New Size(125, 45)
        btnChangeLevelCancel.TabIndex = 26
        btnChangeLevelCancel.Text = "Cancel"
        ' 
        ' DarkLabel65
        ' 
        DarkLabel65.AutoSize = True
        DarkLabel65.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel65.Location = New Point(12, 40)
        DarkLabel65.Margin = New Padding(5, 0, 5, 0)
        DarkLabel65.Name = "DarkLabel65"
        DarkLabel65.Size = New Size(55, 25)
        DarkLabel65.TabIndex = 24
        DarkLabel65.Text = "Level:"
        ' 
        ' nudChangeLevel
        ' 
        nudChangeLevel.Location = New Point(100, 37)
        nudChangeLevel.Margin = New Padding(5)
        nudChangeLevel.Name = "nudChangeLevel"
        nudChangeLevel.Size = New Size(200, 31)
        nudChangeLevel.TabIndex = 23
        ' 
        ' fraPlayerVariable
        ' 
        fraPlayerVariable.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraPlayerVariable.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraPlayerVariable.Controls.Add(nudVariableData2)
        fraPlayerVariable.Controls.Add(optVariableAction2)
        fraPlayerVariable.Controls.Add(btnPlayerVarOk)
        fraPlayerVariable.Controls.Add(btnPlayerVarCancel)
        fraPlayerVariable.Controls.Add(DarkLabel51)
        fraPlayerVariable.Controls.Add(DarkLabel50)
        fraPlayerVariable.Controls.Add(nudVariableData4)
        fraPlayerVariable.Controls.Add(nudVariableData3)
        fraPlayerVariable.Controls.Add(optVariableAction3)
        fraPlayerVariable.Controls.Add(optVariableAction1)
        fraPlayerVariable.Controls.Add(nudVariableData1)
        fraPlayerVariable.Controls.Add(nudVariableData0)
        fraPlayerVariable.Controls.Add(optVariableAction0)
        fraPlayerVariable.Controls.Add(cmbVariable)
        fraPlayerVariable.Controls.Add(DarkLabel49)
        fraPlayerVariable.ForeColor = Color.Gainsboro
        fraPlayerVariable.Location = New Point(668, 541)
        fraPlayerVariable.Margin = New Padding(5)
        fraPlayerVariable.Name = "fraPlayerVariable"
        fraPlayerVariable.Padding = New Padding(5)
        fraPlayerVariable.Size = New Size(410, 297)
        fraPlayerVariable.TabIndex = 31
        fraPlayerVariable.TabStop = False
        fraPlayerVariable.Text = "Player Variable"
        fraPlayerVariable.Visible = False
        ' 
        ' nudVariableData2
        ' 
        nudVariableData2.Location = New Point(200, 138)
        nudVariableData2.Margin = New Padding(5)
        nudVariableData2.Name = "nudVariableData2"
        nudVariableData2.Size = New Size(200, 31)
        nudVariableData2.TabIndex = 29
        ' 
        ' optVariableAction2
        ' 
        optVariableAction2.AutoSize = True
        optVariableAction2.Location = New Point(10, 138)
        optVariableAction2.Margin = New Padding(5)
        optVariableAction2.Name = "optVariableAction2"
        optVariableAction2.Size = New Size(103, 29)
        optVariableAction2.TabIndex = 28
        optVariableAction2.TabStop = True
        optVariableAction2.Text = "Subtract"
        ' 
        ' btnPlayerVarOk
        ' 
        btnPlayerVarOk.Location = New Point(140, 238)
        btnPlayerVarOk.Margin = New Padding(5)
        btnPlayerVarOk.Name = "btnPlayerVarOk"
        btnPlayerVarOk.Padding = New Padding(8, 10, 8, 10)
        btnPlayerVarOk.Size = New Size(125, 45)
        btnPlayerVarOk.TabIndex = 27
        btnPlayerVarOk.Text = "Ok"
        ' 
        ' btnPlayerVarCancel
        ' 
        btnPlayerVarCancel.Location = New Point(275, 238)
        btnPlayerVarCancel.Margin = New Padding(5)
        btnPlayerVarCancel.Name = "btnPlayerVarCancel"
        btnPlayerVarCancel.Padding = New Padding(8, 10, 8, 10)
        btnPlayerVarCancel.Size = New Size(125, 45)
        btnPlayerVarCancel.TabIndex = 26
        btnPlayerVarCancel.Text = "Cancel"
        ' 
        ' DarkLabel51
        ' 
        DarkLabel51.AutoSize = True
        DarkLabel51.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel51.Location = New Point(125, 191)
        DarkLabel51.Margin = New Padding(5, 0, 5, 0)
        DarkLabel51.Name = "DarkLabel51"
        DarkLabel51.Size = New Size(48, 25)
        DarkLabel51.TabIndex = 16
        DarkLabel51.Text = "Low:"
        ' 
        ' DarkLabel50
        ' 
        DarkLabel50.AutoSize = True
        DarkLabel50.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel50.Location = New Point(263, 191)
        DarkLabel50.Margin = New Padding(5, 0, 5, 0)
        DarkLabel50.Name = "DarkLabel50"
        DarkLabel50.Size = New Size(54, 25)
        DarkLabel50.TabIndex = 15
        DarkLabel50.Text = "High:"
        ' 
        ' nudVariableData4
        ' 
        nudVariableData4.Location = New Point(327, 188)
        nudVariableData4.Margin = New Padding(5)
        nudVariableData4.Name = "nudVariableData4"
        nudVariableData4.Size = New Size(73, 31)
        nudVariableData4.TabIndex = 14
        ' 
        ' nudVariableData3
        ' 
        nudVariableData3.Location = New Point(185, 188)
        nudVariableData3.Margin = New Padding(5)
        nudVariableData3.Name = "nudVariableData3"
        nudVariableData3.Size = New Size(73, 31)
        nudVariableData3.TabIndex = 13
        ' 
        ' optVariableAction3
        ' 
        optVariableAction3.AutoSize = True
        optVariableAction3.Location = New Point(10, 188)
        optVariableAction3.Margin = New Padding(5)
        optVariableAction3.Name = "optVariableAction3"
        optVariableAction3.Size = New Size(105, 29)
        optVariableAction3.TabIndex = 12
        optVariableAction3.TabStop = True
        optVariableAction3.Text = "Random"
        ' 
        ' optVariableAction1
        ' 
        optVariableAction1.AutoSize = True
        optVariableAction1.Location = New Point(243, 88)
        optVariableAction1.Margin = New Padding(5)
        optVariableAction1.Name = "optVariableAction1"
        optVariableAction1.Size = New Size(71, 29)
        optVariableAction1.TabIndex = 11
        optVariableAction1.TabStop = True
        optVariableAction1.Text = "Add"
        ' 
        ' nudVariableData1
        ' 
        nudVariableData1.Location = New Point(327, 88)
        nudVariableData1.Margin = New Padding(5)
        nudVariableData1.Name = "nudVariableData1"
        nudVariableData1.Size = New Size(73, 31)
        nudVariableData1.TabIndex = 10
        ' 
        ' nudVariableData0
        ' 
        nudVariableData0.Location = New Point(103, 88)
        nudVariableData0.Margin = New Padding(5)
        nudVariableData0.Name = "nudVariableData0"
        nudVariableData0.Size = New Size(73, 31)
        nudVariableData0.TabIndex = 9
        ' 
        ' optVariableAction0
        ' 
        optVariableAction0.AutoSize = True
        optVariableAction0.Location = New Point(10, 88)
        optVariableAction0.Margin = New Padding(5)
        optVariableAction0.Name = "optVariableAction0"
        optVariableAction0.Size = New Size(62, 29)
        optVariableAction0.TabIndex = 2
        optVariableAction0.TabStop = True
        optVariableAction0.Text = "Set"
        ' 
        ' cmbVariable
        ' 
        cmbVariable.DrawMode = DrawMode.OwnerDrawFixed
        cmbVariable.FormattingEnabled = True
        cmbVariable.Location = New Point(100, 37)
        cmbVariable.Margin = New Padding(5)
        cmbVariable.Name = "cmbVariable"
        cmbVariable.Size = New Size(296, 32)
        cmbVariable.TabIndex = 1
        ' 
        ' DarkLabel49
        ' 
        DarkLabel49.AutoSize = True
        DarkLabel49.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel49.Location = New Point(10, 41)
        DarkLabel49.Margin = New Padding(5, 0, 5, 0)
        DarkLabel49.Name = "DarkLabel49"
        DarkLabel49.Size = New Size(78, 25)
        DarkLabel49.TabIndex = 0
        DarkLabel49.Text = "Variable:"
        ' 
        ' fraPlayAnimation
        ' 
        fraPlayAnimation.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraPlayAnimation.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraPlayAnimation.Controls.Add(btnPlayAnimationOk)
        fraPlayAnimation.Controls.Add(btnPlayAnimationCancel)
        fraPlayAnimation.Controls.Add(lblPlayAnimY)
        fraPlayAnimation.Controls.Add(lblPlayAnimX)
        fraPlayAnimation.Controls.Add(cmbPlayAnimEvent)
        fraPlayAnimation.Controls.Add(DarkLabel62)
        fraPlayAnimation.Controls.Add(cmbAnimTargetType)
        fraPlayAnimation.Controls.Add(nudPlayAnimTileY)
        fraPlayAnimation.Controls.Add(nudPlayAnimTileX)
        fraPlayAnimation.Controls.Add(DarkLabel61)
        fraPlayAnimation.Controls.Add(cmbPlayAnim)
        fraPlayAnimation.ForeColor = Color.Gainsboro
        fraPlayAnimation.Location = New Point(668, 495)
        fraPlayAnimation.Margin = New Padding(5)
        fraPlayAnimation.Name = "fraPlayAnimation"
        fraPlayAnimation.Padding = New Padding(5)
        fraPlayAnimation.Size = New Size(413, 312)
        fraPlayAnimation.TabIndex = 36
        fraPlayAnimation.TabStop = False
        fraPlayAnimation.Text = "Play Animation"
        fraPlayAnimation.Visible = False
        ' 
        ' btnPlayAnimationOk
        ' 
        btnPlayAnimationOk.Location = New Point(143, 253)
        btnPlayAnimationOk.Margin = New Padding(5)
        btnPlayAnimationOk.Name = "btnPlayAnimationOk"
        btnPlayAnimationOk.Padding = New Padding(8, 10, 8, 10)
        btnPlayAnimationOk.Size = New Size(125, 45)
        btnPlayAnimationOk.TabIndex = 36
        btnPlayAnimationOk.Text = "Ok"
        ' 
        ' btnPlayAnimationCancel
        ' 
        btnPlayAnimationCancel.Location = New Point(278, 253)
        btnPlayAnimationCancel.Margin = New Padding(5)
        btnPlayAnimationCancel.Name = "btnPlayAnimationCancel"
        btnPlayAnimationCancel.Padding = New Padding(8, 10, 8, 10)
        btnPlayAnimationCancel.Size = New Size(125, 45)
        btnPlayAnimationCancel.TabIndex = 35
        btnPlayAnimationCancel.Text = "Cancel"
        ' 
        ' lblPlayAnimY
        ' 
        lblPlayAnimY.AutoSize = True
        lblPlayAnimY.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        lblPlayAnimY.Location = New Point(218, 203)
        lblPlayAnimY.Margin = New Padding(5, 0, 5, 0)
        lblPlayAnimY.Name = "lblPlayAnimY"
        lblPlayAnimY.Size = New Size(98, 25)
        lblPlayAnimY.TabIndex = 34
        lblPlayAnimY.Text = "Map Tile Y:"
        ' 
        ' lblPlayAnimX
        ' 
        lblPlayAnimX.AutoSize = True
        lblPlayAnimX.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        lblPlayAnimX.Location = New Point(10, 203)
        lblPlayAnimX.Margin = New Padding(5, 0, 5, 0)
        lblPlayAnimX.Name = "lblPlayAnimX"
        lblPlayAnimX.Size = New Size(99, 25)
        lblPlayAnimX.TabIndex = 33
        lblPlayAnimX.Text = "Map Tile X:"
        ' 
        ' cmbPlayAnimEvent
        ' 
        cmbPlayAnimEvent.DrawMode = DrawMode.OwnerDrawFixed
        cmbPlayAnimEvent.FormattingEnabled = True
        cmbPlayAnimEvent.Location = New Point(138, 140)
        cmbPlayAnimEvent.Margin = New Padding(5)
        cmbPlayAnimEvent.Name = "cmbPlayAnimEvent"
        cmbPlayAnimEvent.Size = New Size(262, 32)
        cmbPlayAnimEvent.TabIndex = 32
        ' 
        ' DarkLabel62
        ' 
        DarkLabel62.AutoSize = True
        DarkLabel62.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel62.Location = New Point(7, 95)
        DarkLabel62.Margin = New Padding(5, 0, 5, 0)
        DarkLabel62.Name = "DarkLabel62"
        DarkLabel62.Size = New Size(102, 25)
        DarkLabel62.TabIndex = 31
        DarkLabel62.Text = "Target Type"
        ' 
        ' cmbAnimTargetType
        ' 
        cmbAnimTargetType.DrawMode = DrawMode.OwnerDrawFixed
        cmbAnimTargetType.FormattingEnabled = True
        cmbAnimTargetType.Items.AddRange(New Object() {"Player", "Event", "Tile"})
        cmbAnimTargetType.Location = New Point(138, 88)
        cmbAnimTargetType.Margin = New Padding(5)
        cmbAnimTargetType.Name = "cmbAnimTargetType"
        cmbAnimTargetType.Size = New Size(262, 32)
        cmbAnimTargetType.TabIndex = 30
        ' 
        ' nudPlayAnimTileY
        ' 
        nudPlayAnimTileY.Location = New Point(330, 200)
        nudPlayAnimTileY.Margin = New Padding(5)
        nudPlayAnimTileY.Name = "nudPlayAnimTileY"
        nudPlayAnimTileY.Size = New Size(73, 31)
        nudPlayAnimTileY.TabIndex = 29
        ' 
        ' nudPlayAnimTileX
        ' 
        nudPlayAnimTileX.Location = New Point(122, 200)
        nudPlayAnimTileX.Margin = New Padding(5)
        nudPlayAnimTileX.Name = "nudPlayAnimTileX"
        nudPlayAnimTileX.Size = New Size(73, 31)
        nudPlayAnimTileX.TabIndex = 28
        ' 
        ' DarkLabel61
        ' 
        DarkLabel61.AutoSize = True
        DarkLabel61.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel61.Location = New Point(10, 41)
        DarkLabel61.Margin = New Padding(5, 0, 5, 0)
        DarkLabel61.Name = "DarkLabel61"
        DarkLabel61.Size = New Size(98, 25)
        DarkLabel61.TabIndex = 1
        DarkLabel61.Text = "Animation:"
        ' 
        ' cmbPlayAnim
        ' 
        cmbPlayAnim.DrawMode = DrawMode.OwnerDrawFixed
        cmbPlayAnim.FormattingEnabled = True
        cmbPlayAnim.Location = New Point(103, 37)
        cmbPlayAnim.Margin = New Padding(5)
        cmbPlayAnim.Name = "cmbPlayAnim"
        cmbPlayAnim.Size = New Size(297, 32)
        cmbPlayAnim.TabIndex = 0
        ' 
        ' fraChangeSprite
        ' 
        fraChangeSprite.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraChangeSprite.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraChangeSprite.Controls.Add(btnChangeSpriteOk)
        fraChangeSprite.Controls.Add(btnChangeSpriteCancel)
        fraChangeSprite.Controls.Add(DarkLabel48)
        fraChangeSprite.Controls.Add(nudChangeSprite)
        fraChangeSprite.Controls.Add(picChangeSprite)
        fraChangeSprite.ForeColor = Color.Gainsboro
        fraChangeSprite.Location = New Point(668, 538)
        fraChangeSprite.Margin = New Padding(5)
        fraChangeSprite.Name = "fraChangeSprite"
        fraChangeSprite.Padding = New Padding(5)
        fraChangeSprite.Size = New Size(410, 225)
        fraChangeSprite.TabIndex = 30
        fraChangeSprite.TabStop = False
        fraChangeSprite.Text = "Change Sprite"
        fraChangeSprite.Visible = False
        ' 
        ' btnChangeSpriteOk
        ' 
        btnChangeSpriteOk.Location = New Point(140, 172)
        btnChangeSpriteOk.Margin = New Padding(5)
        btnChangeSpriteOk.Name = "btnChangeSpriteOk"
        btnChangeSpriteOk.Padding = New Padding(8, 10, 8, 10)
        btnChangeSpriteOk.Size = New Size(125, 45)
        btnChangeSpriteOk.TabIndex = 30
        btnChangeSpriteOk.Text = "Ok"
        ' 
        ' btnChangeSpriteCancel
        ' 
        btnChangeSpriteCancel.Location = New Point(275, 172)
        btnChangeSpriteCancel.Margin = New Padding(5)
        btnChangeSpriteCancel.Name = "btnChangeSpriteCancel"
        btnChangeSpriteCancel.Padding = New Padding(8, 10, 8, 10)
        btnChangeSpriteCancel.Size = New Size(125, 45)
        btnChangeSpriteCancel.TabIndex = 29
        btnChangeSpriteCancel.Text = "Cancel"
        ' 
        ' DarkLabel48
        ' 
        DarkLabel48.AutoSize = True
        DarkLabel48.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel48.Location = New Point(133, 128)
        DarkLabel48.Margin = New Padding(5, 0, 5, 0)
        DarkLabel48.Name = "DarkLabel48"
        DarkLabel48.Size = New Size(58, 25)
        DarkLabel48.TabIndex = 28
        DarkLabel48.Text = "Sprite"
        ' 
        ' nudChangeSprite
        ' 
        nudChangeSprite.Location = New Point(200, 122)
        nudChangeSprite.Margin = New Padding(5)
        nudChangeSprite.Name = "nudChangeSprite"
        nudChangeSprite.Size = New Size(200, 31)
        nudChangeSprite.TabIndex = 27
        ' 
        ' picChangeSprite
        ' 
        picChangeSprite.BackColor = Color.Black
        picChangeSprite.BackgroundImageLayout = ImageLayout.Zoom
        picChangeSprite.Location = New Point(10, 37)
        picChangeSprite.Margin = New Padding(5)
        picChangeSprite.Name = "picChangeSprite"
        picChangeSprite.Size = New Size(117, 178)
        picChangeSprite.TabIndex = 3
        picChangeSprite.TabStop = False
        ' 
        ' fraGoToLabel
        ' 
        fraGoToLabel.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraGoToLabel.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraGoToLabel.Controls.Add(btnGoToLabelOk)
        fraGoToLabel.Controls.Add(btnGoToLabelCancel)
        fraGoToLabel.Controls.Add(txtGotoLabel)
        fraGoToLabel.Controls.Add(DarkLabel60)
        fraGoToLabel.ForeColor = Color.Gainsboro
        fraGoToLabel.Location = New Point(668, 490)
        fraGoToLabel.Margin = New Padding(5)
        fraGoToLabel.Name = "fraGoToLabel"
        fraGoToLabel.Padding = New Padding(5)
        fraGoToLabel.Size = New Size(413, 140)
        fraGoToLabel.TabIndex = 35
        fraGoToLabel.TabStop = False
        fraGoToLabel.Text = "GoTo Label"
        fraGoToLabel.Visible = False
        ' 
        ' btnGoToLabelOk
        ' 
        btnGoToLabelOk.Location = New Point(143, 85)
        btnGoToLabelOk.Margin = New Padding(5)
        btnGoToLabelOk.Name = "btnGoToLabelOk"
        btnGoToLabelOk.Padding = New Padding(8, 10, 8, 10)
        btnGoToLabelOk.Size = New Size(125, 45)
        btnGoToLabelOk.TabIndex = 27
        btnGoToLabelOk.Text = "Ok"
        ' 
        ' btnGoToLabelCancel
        ' 
        btnGoToLabelCancel.Location = New Point(278, 85)
        btnGoToLabelCancel.Margin = New Padding(5)
        btnGoToLabelCancel.Name = "btnGoToLabelCancel"
        btnGoToLabelCancel.Padding = New Padding(8, 10, 8, 10)
        btnGoToLabelCancel.Size = New Size(125, 45)
        btnGoToLabelCancel.TabIndex = 26
        btnGoToLabelCancel.Text = "Cancel"
        ' 
        ' txtGotoLabel
        ' 
        txtGotoLabel.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtGotoLabel.BorderStyle = BorderStyle.FixedSingle
        txtGotoLabel.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtGotoLabel.Location = New Point(130, 35)
        txtGotoLabel.Margin = New Padding(5)
        txtGotoLabel.Name = "txtGotoLabel"
        txtGotoLabel.Size = New Size(272, 31)
        txtGotoLabel.TabIndex = 1
        ' 
        ' DarkLabel60
        ' 
        DarkLabel60.AutoSize = True
        DarkLabel60.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel60.Location = New Point(5, 38)
        DarkLabel60.Margin = New Padding(5, 0, 5, 0)
        DarkLabel60.Name = "DarkLabel60"
        DarkLabel60.Size = New Size(109, 25)
        DarkLabel60.TabIndex = 0
        DarkLabel60.Text = "Label Name:"
        ' 
        ' fraMapTint
        ' 
        fraMapTint.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraMapTint.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraMapTint.Controls.Add(btnMapTintOk)
        fraMapTint.Controls.Add(btnMapTintCancel)
        fraMapTint.Controls.Add(DarkLabel42)
        fraMapTint.Controls.Add(nudMapTintData3)
        fraMapTint.Controls.Add(nudMapTintData2)
        fraMapTint.Controls.Add(DarkLabel43)
        fraMapTint.Controls.Add(DarkLabel44)
        fraMapTint.Controls.Add(nudMapTintData1)
        fraMapTint.Controls.Add(nudMapTintData0)
        fraMapTint.Controls.Add(DarkLabel45)
        fraMapTint.ForeColor = Color.Gainsboro
        fraMapTint.Location = New Point(668, 348)
        fraMapTint.Margin = New Padding(5)
        fraMapTint.Name = "fraMapTint"
        fraMapTint.Padding = New Padding(5)
        fraMapTint.Size = New Size(410, 278)
        fraMapTint.TabIndex = 28
        fraMapTint.TabStop = False
        fraMapTint.Text = "Map Tinting"
        fraMapTint.Visible = False
        ' 
        ' btnMapTintOk
        ' 
        btnMapTintOk.Location = New Point(140, 222)
        btnMapTintOk.Margin = New Padding(5)
        btnMapTintOk.Name = "btnMapTintOk"
        btnMapTintOk.Padding = New Padding(8, 10, 8, 10)
        btnMapTintOk.Size = New Size(125, 45)
        btnMapTintOk.TabIndex = 45
        btnMapTintOk.Text = "Ok"
        ' 
        ' btnMapTintCancel
        ' 
        btnMapTintCancel.Location = New Point(275, 222)
        btnMapTintCancel.Margin = New Padding(5)
        btnMapTintCancel.Name = "btnMapTintCancel"
        btnMapTintCancel.Padding = New Padding(8, 10, 8, 10)
        btnMapTintCancel.Size = New Size(125, 45)
        btnMapTintCancel.TabIndex = 44
        btnMapTintCancel.Text = "Cancel"
        ' 
        ' DarkLabel42
        ' 
        DarkLabel42.AutoSize = True
        DarkLabel42.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel42.Location = New Point(8, 178)
        DarkLabel42.Margin = New Padding(5, 0, 5, 0)
        DarkLabel42.Name = "DarkLabel42"
        DarkLabel42.Size = New Size(77, 25)
        DarkLabel42.TabIndex = 43
        DarkLabel42.Text = "Opacity:"
        ' 
        ' nudMapTintData3
        ' 
        nudMapTintData3.Location = New Point(158, 172)
        nudMapTintData3.Margin = New Padding(5)
        nudMapTintData3.Name = "nudMapTintData3"
        nudMapTintData3.Size = New Size(240, 31)
        nudMapTintData3.TabIndex = 42
        ' 
        ' nudMapTintData2
        ' 
        nudMapTintData2.Location = New Point(158, 123)
        nudMapTintData2.Margin = New Padding(5)
        nudMapTintData2.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        nudMapTintData2.Name = "nudMapTintData2"
        nudMapTintData2.Size = New Size(240, 31)
        nudMapTintData2.TabIndex = 41
        ' 
        ' DarkLabel43
        ' 
        DarkLabel43.AutoSize = True
        DarkLabel43.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel43.Location = New Point(8, 127)
        DarkLabel43.Margin = New Padding(5, 0, 5, 0)
        DarkLabel43.Name = "DarkLabel43"
        DarkLabel43.Size = New Size(49, 25)
        DarkLabel43.TabIndex = 40
        DarkLabel43.Text = "Blue:"
        ' 
        ' DarkLabel44
        ' 
        DarkLabel44.AutoSize = True
        DarkLabel44.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel44.Location = New Point(7, 84)
        DarkLabel44.Margin = New Padding(5, 0, 5, 0)
        DarkLabel44.Name = "DarkLabel44"
        DarkLabel44.Size = New Size(62, 25)
        DarkLabel44.TabIndex = 39
        DarkLabel44.Text = "Green:"
        ' 
        ' nudMapTintData1
        ' 
        nudMapTintData1.Location = New Point(158, 75)
        nudMapTintData1.Margin = New Padding(5)
        nudMapTintData1.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        nudMapTintData1.Name = "nudMapTintData1"
        nudMapTintData1.Size = New Size(240, 31)
        nudMapTintData1.TabIndex = 38
        ' 
        ' nudMapTintData0
        ' 
        nudMapTintData0.Location = New Point(158, 27)
        nudMapTintData0.Margin = New Padding(5)
        nudMapTintData0.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        nudMapTintData0.Name = "nudMapTintData0"
        nudMapTintData0.Size = New Size(240, 31)
        nudMapTintData0.TabIndex = 37
        ' 
        ' DarkLabel45
        ' 
        DarkLabel45.AutoSize = True
        DarkLabel45.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel45.Location = New Point(8, 30)
        DarkLabel45.Margin = New Padding(5, 0, 5, 0)
        DarkLabel45.Name = "DarkLabel45"
        DarkLabel45.Size = New Size(46, 25)
        DarkLabel45.TabIndex = 36
        DarkLabel45.Text = "Red:"
        ' 
        ' fraShowPic
        ' 
        fraShowPic.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraShowPic.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraShowPic.Controls.Add(btnShowPicOk)
        fraShowPic.Controls.Add(btnShowPicCancel)
        fraShowPic.Controls.Add(DarkLabel71)
        fraShowPic.Controls.Add(DarkLabel70)
        fraShowPic.Controls.Add(DarkLabel67)
        fraShowPic.Controls.Add(DarkLabel68)
        fraShowPic.Controls.Add(nudPicOffsetY)
        fraShowPic.Controls.Add(nudPicOffsetX)
        fraShowPic.Controls.Add(DarkLabel69)
        fraShowPic.Controls.Add(cmbPicLoc)
        fraShowPic.Controls.Add(nudShowPicture)
        fraShowPic.Controls.Add(picShowPic)
        fraShowPic.ForeColor = Color.Gainsboro
        fraShowPic.Location = New Point(1, 0)
        fraShowPic.Margin = New Padding(5)
        fraShowPic.Name = "fraShowPic"
        fraShowPic.Padding = New Padding(5)
        fraShowPic.Size = New Size(1107, 1143)
        fraShowPic.TabIndex = 40
        fraShowPic.TabStop = False
        fraShowPic.Text = "Show Picture"
        fraShowPic.Visible = False
        ' 
        ' btnShowPicOk
        ' 
        btnShowPicOk.Location = New Point(833, 1085)
        btnShowPicOk.Margin = New Padding(5)
        btnShowPicOk.Name = "btnShowPicOk"
        btnShowPicOk.Padding = New Padding(8, 10, 8, 10)
        btnShowPicOk.Size = New Size(125, 45)
        btnShowPicOk.TabIndex = 55
        btnShowPicOk.Text = "Ok"
        ' 
        ' btnShowPicCancel
        ' 
        btnShowPicCancel.Location = New Point(970, 1085)
        btnShowPicCancel.Margin = New Padding(5)
        btnShowPicCancel.Name = "btnShowPicCancel"
        btnShowPicCancel.Padding = New Padding(8, 10, 8, 10)
        btnShowPicCancel.Size = New Size(125, 45)
        btnShowPicCancel.TabIndex = 54
        btnShowPicCancel.Text = "Cancel"
        ' 
        ' DarkLabel71
        ' 
        DarkLabel71.AutoSize = True
        DarkLabel71.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel71.Location = New Point(410, 45)
        DarkLabel71.Margin = New Padding(5, 0, 5, 0)
        DarkLabel71.Name = "DarkLabel71"
        DarkLabel71.Size = New Size(181, 25)
        DarkLabel71.TabIndex = 53
        DarkLabel71.Text = "Offset from Location:"
        ' 
        ' DarkLabel70
        ' 
        DarkLabel70.AutoSize = True
        DarkLabel70.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel70.Location = New Point(185, 109)
        DarkLabel70.Margin = New Padding(5, 0, 5, 0)
        DarkLabel70.Name = "DarkLabel70"
        DarkLabel70.Size = New Size(79, 25)
        DarkLabel70.TabIndex = 52
        DarkLabel70.Text = "Location"
        ' 
        ' DarkLabel67
        ' 
        DarkLabel67.AutoSize = True
        DarkLabel67.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel67.Location = New Point(622, 90)
        DarkLabel67.Margin = New Padding(5, 0, 5, 0)
        DarkLabel67.Name = "DarkLabel67"
        DarkLabel67.Size = New Size(26, 25)
        DarkLabel67.TabIndex = 51
        DarkLabel67.Text = "Y:"
        ' 
        ' DarkLabel68
        ' 
        DarkLabel68.AutoSize = True
        DarkLabel68.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel68.Location = New Point(410, 93)
        DarkLabel68.Margin = New Padding(5, 0, 5, 0)
        DarkLabel68.Name = "DarkLabel68"
        DarkLabel68.Size = New Size(27, 25)
        DarkLabel68.TabIndex = 50
        DarkLabel68.Text = "X:"
        ' 
        ' nudPicOffsetY
        ' 
        nudPicOffsetY.Location = New Point(695, 87)
        nudPicOffsetY.Margin = New Padding(5)
        nudPicOffsetY.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        nudPicOffsetY.Name = "nudPicOffsetY"
        nudPicOffsetY.Size = New Size(95, 31)
        nudPicOffsetY.TabIndex = 49
        ' 
        ' nudPicOffsetX
        ' 
        nudPicOffsetX.Location = New Point(480, 87)
        nudPicOffsetX.Margin = New Padding(5)
        nudPicOffsetX.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        nudPicOffsetX.Name = "nudPicOffsetX"
        nudPicOffsetX.Size = New Size(95, 31)
        nudPicOffsetX.TabIndex = 48
        ' 
        ' DarkLabel69
        ' 
        DarkLabel69.AutoSize = True
        DarkLabel69.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel69.Location = New Point(185, 43)
        DarkLabel69.Margin = New Padding(5, 0, 5, 0)
        DarkLabel69.Name = "DarkLabel69"
        DarkLabel69.Size = New Size(69, 25)
        DarkLabel69.TabIndex = 47
        DarkLabel69.Text = "Picture:"
        ' 
        ' cmbPicLoc
        ' 
        cmbPicLoc.DrawMode = DrawMode.OwnerDrawFixed
        cmbPicLoc.FormattingEnabled = True
        cmbPicLoc.Items.AddRange(New Object() {"Top Left of Screen", "Center Screen", "Centered on Event", "Centered on Player"})
        cmbPicLoc.Location = New Point(190, 143)
        cmbPicLoc.Margin = New Padding(5)
        cmbPicLoc.Name = "cmbPicLoc"
        cmbPicLoc.Size = New Size(204, 32)
        cmbPicLoc.TabIndex = 46
        ' 
        ' nudShowPicture
        ' 
        nudShowPicture.Location = New Point(265, 40)
        nudShowPicture.Margin = New Padding(5)
        nudShowPicture.Name = "nudShowPicture"
        nudShowPicture.Size = New Size(125, 31)
        nudShowPicture.TabIndex = 45
        ' 
        ' picShowPic
        ' 
        picShowPic.BackColor = Color.Black
        picShowPic.BackgroundImageLayout = ImageLayout.Stretch
        picShowPic.Location = New Point(13, 35)
        picShowPic.Margin = New Padding(5)
        picShowPic.Name = "picShowPic"
        picShowPic.Size = New Size(167, 178)
        picShowPic.TabIndex = 42
        picShowPic.TabStop = False
        ' 
        ' fraConditionalBranch
        ' 
        fraConditionalBranch.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraConditionalBranch.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraConditionalBranch.Controls.Add(cmbCondition_Time)
        fraConditionalBranch.Controls.Add(optCondition9)
        fraConditionalBranch.Controls.Add(btnConditionalBranchOk)
        fraConditionalBranch.Controls.Add(btnConditionalBranchCancel)
        fraConditionalBranch.Controls.Add(cmbCondition_Gender)
        fraConditionalBranch.Controls.Add(optCondition8)
        fraConditionalBranch.Controls.Add(cmbCondition_SelfSwitchCondition)
        fraConditionalBranch.Controls.Add(DarkLabel17)
        fraConditionalBranch.Controls.Add(cmbCondition_SelfSwitch)
        fraConditionalBranch.Controls.Add(optCondition6)
        fraConditionalBranch.Controls.Add(nudCondition_LevelAmount)
        fraConditionalBranch.Controls.Add(optCondition5)
        fraConditionalBranch.Controls.Add(cmbCondition_LevelCompare)
        fraConditionalBranch.Controls.Add(cmbCondition_LearntSkill)
        fraConditionalBranch.Controls.Add(optCondition4)
        fraConditionalBranch.Controls.Add(cmbCondition_JobIs)
        fraConditionalBranch.Controls.Add(optCondition3)
        fraConditionalBranch.Controls.Add(nudCondition_HasItem)
        fraConditionalBranch.Controls.Add(DarkLabel16)
        fraConditionalBranch.Controls.Add(cmbCondition_HasItem)
        fraConditionalBranch.Controls.Add(optCondition2)
        fraConditionalBranch.Controls.Add(optCondition1)
        fraConditionalBranch.Controls.Add(DarkLabel15)
        fraConditionalBranch.Controls.Add(cmbCondtion_PlayerSwitchCondition)
        fraConditionalBranch.Controls.Add(cmbCondition_PlayerSwitch)
        fraConditionalBranch.Controls.Add(nudCondition_PlayerVarCondition)
        fraConditionalBranch.Controls.Add(cmbCondition_PlayerVarCompare)
        fraConditionalBranch.Controls.Add(DarkLabel14)
        fraConditionalBranch.Controls.Add(cmbCondition_PlayerVarIndex)
        fraConditionalBranch.Controls.Add(optCondition0)
        fraConditionalBranch.ForeColor = Color.Gainsboro
        fraConditionalBranch.Location = New Point(10, 13)
        fraConditionalBranch.Margin = New Padding(5)
        fraConditionalBranch.Name = "fraConditionalBranch"
        fraConditionalBranch.Padding = New Padding(5)
        fraConditionalBranch.Size = New Size(648, 860)
        fraConditionalBranch.TabIndex = 0
        fraConditionalBranch.TabStop = False
        fraConditionalBranch.Text = "Conditional Branch"
        fraConditionalBranch.Visible = False
        ' 
        ' cmbCondition_Time
        ' 
        cmbCondition_Time.DrawMode = DrawMode.OwnerDrawVariable
        cmbCondition_Time.FormattingEnabled = True
        cmbCondition_Time.Items.AddRange(New Object() {"Day", "Night", "Dawn", "Dusk"})
        cmbCondition_Time.Location = New Point(398, 445)
        cmbCondition_Time.Margin = New Padding(5)
        cmbCondition_Time.Name = "cmbCondition_Time"
        cmbCondition_Time.Size = New Size(237, 32)
        cmbCondition_Time.TabIndex = 33
        ' 
        ' optCondition9
        ' 
        optCondition9.AutoSize = True
        optCondition9.Location = New Point(10, 447)
        optCondition9.Margin = New Padding(5)
        optCondition9.Name = "optCondition9"
        optCondition9.Size = New Size(154, 29)
        optCondition9.TabIndex = 32
        optCondition9.TabStop = True
        optCondition9.Text = "Time of Day is:"
        ' 
        ' btnConditionalBranchOk
        ' 
        btnConditionalBranchOk.Location = New Point(377, 800)
        btnConditionalBranchOk.Margin = New Padding(5)
        btnConditionalBranchOk.Name = "btnConditionalBranchOk"
        btnConditionalBranchOk.Padding = New Padding(8, 10, 8, 10)
        btnConditionalBranchOk.Size = New Size(125, 45)
        btnConditionalBranchOk.TabIndex = 31
        btnConditionalBranchOk.Text = "Ok"
        ' 
        ' btnConditionalBranchCancel
        ' 
        btnConditionalBranchCancel.Location = New Point(512, 800)
        btnConditionalBranchCancel.Margin = New Padding(5)
        btnConditionalBranchCancel.Name = "btnConditionalBranchCancel"
        btnConditionalBranchCancel.Padding = New Padding(8, 10, 8, 10)
        btnConditionalBranchCancel.Size = New Size(125, 45)
        btnConditionalBranchCancel.TabIndex = 30
        btnConditionalBranchCancel.Text = "Cancel"
        ' 
        ' cmbCondition_Gender
        ' 
        cmbCondition_Gender.DrawMode = DrawMode.OwnerDrawFixed
        cmbCondition_Gender.FormattingEnabled = True
        cmbCondition_Gender.Items.AddRange(New Object() {"Male", "Female"})
        cmbCondition_Gender.Location = New Point(398, 393)
        cmbCondition_Gender.Margin = New Padding(5)
        cmbCondition_Gender.Name = "cmbCondition_Gender"
        cmbCondition_Gender.Size = New Size(237, 32)
        cmbCondition_Gender.TabIndex = 29
        ' 
        ' optCondition8
        ' 
        optCondition8.AutoSize = True
        optCondition8.Location = New Point(10, 395)
        optCondition8.Margin = New Padding(5)
        optCondition8.Name = "optCondition8"
        optCondition8.Size = New Size(163, 29)
        optCondition8.TabIndex = 28
        optCondition8.TabStop = True
        optCondition8.Text = "Player Gender is"
        ' 
        ' cmbCondition_SelfSwitchCondition
        ' 
        cmbCondition_SelfSwitchCondition.DrawMode = DrawMode.OwnerDrawFixed
        cmbCondition_SelfSwitchCondition.FormattingEnabled = True
        cmbCondition_SelfSwitchCondition.Items.AddRange(New Object() {"False", "True"})
        cmbCondition_SelfSwitchCondition.Location = New Point(437, 352)
        cmbCondition_SelfSwitchCondition.Margin = New Padding(5)
        cmbCondition_SelfSwitchCondition.Name = "cmbCondition_SelfSwitchCondition"
        cmbCondition_SelfSwitchCondition.Size = New Size(199, 32)
        cmbCondition_SelfSwitchCondition.TabIndex = 23
        ' 
        ' DarkLabel17
        ' 
        DarkLabel17.AutoSize = True
        DarkLabel17.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel17.Location = New Point(390, 359)
        DarkLabel17.Margin = New Padding(5, 0, 5, 0)
        DarkLabel17.Name = "DarkLabel17"
        DarkLabel17.Size = New Size(24, 25)
        DarkLabel17.TabIndex = 22
        DarkLabel17.Text = "is"
        ' 
        ' cmbCondition_SelfSwitch
        ' 
        cmbCondition_SelfSwitch.DrawMode = DrawMode.OwnerDrawFixed
        cmbCondition_SelfSwitch.FormattingEnabled = True
        cmbCondition_SelfSwitch.Location = New Point(178, 352)
        cmbCondition_SelfSwitch.Margin = New Padding(5)
        cmbCondition_SelfSwitch.Name = "cmbCondition_SelfSwitch"
        cmbCondition_SelfSwitch.Size = New Size(199, 32)
        cmbCondition_SelfSwitch.TabIndex = 21
        ' 
        ' optCondition6
        ' 
        optCondition6.AutoSize = True
        optCondition6.Location = New Point(10, 353)
        optCondition6.Margin = New Padding(5)
        optCondition6.Name = "optCondition6"
        optCondition6.Size = New Size(122, 29)
        optCondition6.TabIndex = 20
        optCondition6.TabStop = True
        optCondition6.Text = "Self Switch"
        ' 
        ' nudCondition_LevelAmount
        ' 
        nudCondition_LevelAmount.Location = New Point(448, 302)
        nudCondition_LevelAmount.Margin = New Padding(5)
        nudCondition_LevelAmount.Name = "nudCondition_LevelAmount"
        nudCondition_LevelAmount.Size = New Size(188, 31)
        nudCondition_LevelAmount.TabIndex = 19
        ' 
        ' optCondition5
        ' 
        optCondition5.AutoSize = True
        optCondition5.Location = New Point(10, 302)
        optCondition5.Margin = New Padding(5)
        optCondition5.Name = "optCondition5"
        optCondition5.Size = New Size(93, 29)
        optCondition5.TabIndex = 18
        optCondition5.TabStop = True
        optCondition5.Text = "Level is"
        ' 
        ' cmbCondition_LevelCompare
        ' 
        cmbCondition_LevelCompare.DrawMode = DrawMode.OwnerDrawFixed
        cmbCondition_LevelCompare.FormattingEnabled = True
        cmbCondition_LevelCompare.Items.AddRange(New Object() {"Equal To", "Great Than Or Equal To", "Less Than or Equal To", "Greater Than", "Less Than", "Does Not Equal"})
        cmbCondition_LevelCompare.Location = New Point(178, 300)
        cmbCondition_LevelCompare.Margin = New Padding(5)
        cmbCondition_LevelCompare.Name = "cmbCondition_LevelCompare"
        cmbCondition_LevelCompare.Size = New Size(257, 32)
        cmbCondition_LevelCompare.TabIndex = 17
        ' 
        ' cmbCondition_LearntSkill
        ' 
        cmbCondition_LearntSkill.DrawMode = DrawMode.OwnerDrawFixed
        cmbCondition_LearntSkill.FormattingEnabled = True
        cmbCondition_LearntSkill.Location = New Point(178, 248)
        cmbCondition_LearntSkill.Margin = New Padding(5)
        cmbCondition_LearntSkill.Name = "cmbCondition_LearntSkill"
        cmbCondition_LearntSkill.Size = New Size(457, 32)
        cmbCondition_LearntSkill.TabIndex = 16
        ' 
        ' optCondition4
        ' 
        optCondition4.AutoSize = True
        optCondition4.Location = New Point(10, 250)
        optCondition4.Margin = New Padding(5)
        optCondition4.Name = "optCondition4"
        optCondition4.Size = New Size(125, 29)
        optCondition4.TabIndex = 15
        optCondition4.TabStop = True
        optCondition4.Text = "Knows Skill"
        ' 
        ' cmbCondition_JobIs
        ' 
        cmbCondition_JobIs.DrawMode = DrawMode.OwnerDrawFixed
        cmbCondition_JobIs.FormattingEnabled = True
        cmbCondition_JobIs.Location = New Point(178, 197)
        cmbCondition_JobIs.Margin = New Padding(5)
        cmbCondition_JobIs.Name = "cmbCondition_JobIs"
        cmbCondition_JobIs.Size = New Size(457, 32)
        cmbCondition_JobIs.TabIndex = 14
        ' 
        ' optCondition3
        ' 
        optCondition3.AutoSize = True
        optCondition3.Location = New Point(10, 198)
        optCondition3.Margin = New Padding(5)
        optCondition3.Name = "optCondition3"
        optCondition3.Size = New Size(83, 29)
        optCondition3.TabIndex = 13
        optCondition3.TabStop = True
        optCondition3.Text = "Job Is"
        ' 
        ' nudCondition_HasItem
        ' 
        nudCondition_HasItem.Location = New Point(437, 147)
        nudCondition_HasItem.Margin = New Padding(5)
        nudCondition_HasItem.Name = "nudCondition_HasItem"
        nudCondition_HasItem.Size = New Size(200, 31)
        nudCondition_HasItem.TabIndex = 12
        ' 
        ' DarkLabel16
        ' 
        DarkLabel16.AutoSize = True
        DarkLabel16.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel16.Location = New Point(390, 150)
        DarkLabel16.Margin = New Padding(5, 0, 5, 0)
        DarkLabel16.Name = "DarkLabel16"
        DarkLabel16.Size = New Size(23, 25)
        DarkLabel16.TabIndex = 11
        DarkLabel16.Text = "X"
        ' 
        ' cmbCondition_HasItem
        ' 
        cmbCondition_HasItem.DrawMode = DrawMode.OwnerDrawFixed
        cmbCondition_HasItem.FormattingEnabled = True
        cmbCondition_HasItem.Location = New Point(178, 145)
        cmbCondition_HasItem.Margin = New Padding(5)
        cmbCondition_HasItem.Name = "cmbCondition_HasItem"
        cmbCondition_HasItem.Size = New Size(199, 32)
        cmbCondition_HasItem.TabIndex = 10
        ' 
        ' optCondition2
        ' 
        optCondition2.AutoSize = True
        optCondition2.Location = New Point(10, 147)
        optCondition2.Margin = New Padding(5)
        optCondition2.Name = "optCondition2"
        optCondition2.Size = New Size(108, 29)
        optCondition2.TabIndex = 9
        optCondition2.TabStop = True
        optCondition2.Text = "Has Item"
        ' 
        ' optCondition1
        ' 
        optCondition1.AutoSize = True
        optCondition1.Location = New Point(10, 95)
        optCondition1.Margin = New Padding(5)
        optCondition1.Name = "optCondition1"
        optCondition1.Size = New Size(140, 29)
        optCondition1.TabIndex = 8
        optCondition1.TabStop = True
        optCondition1.Text = "Player Switch"
        ' 
        ' DarkLabel15
        ' 
        DarkLabel15.AutoSize = True
        DarkLabel15.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel15.Location = New Point(390, 98)
        DarkLabel15.Margin = New Padding(5, 0, 5, 0)
        DarkLabel15.Name = "DarkLabel15"
        DarkLabel15.Size = New Size(24, 25)
        DarkLabel15.TabIndex = 7
        DarkLabel15.Text = "is"
        ' 
        ' cmbCondtion_PlayerSwitchCondition
        ' 
        cmbCondtion_PlayerSwitchCondition.DrawMode = DrawMode.OwnerDrawFixed
        cmbCondtion_PlayerSwitchCondition.FormattingEnabled = True
        cmbCondtion_PlayerSwitchCondition.Items.AddRange(New Object() {"False", "True"})
        cmbCondtion_PlayerSwitchCondition.Location = New Point(437, 91)
        cmbCondtion_PlayerSwitchCondition.Margin = New Padding(5)
        cmbCondtion_PlayerSwitchCondition.Name = "cmbCondtion_PlayerSwitchCondition"
        cmbCondtion_PlayerSwitchCondition.Size = New Size(199, 32)
        cmbCondtion_PlayerSwitchCondition.TabIndex = 6
        ' 
        ' cmbCondition_PlayerSwitch
        ' 
        cmbCondition_PlayerSwitch.DrawMode = DrawMode.OwnerDrawFixed
        cmbCondition_PlayerSwitch.FormattingEnabled = True
        cmbCondition_PlayerSwitch.Location = New Point(178, 91)
        cmbCondition_PlayerSwitch.Margin = New Padding(5)
        cmbCondition_PlayerSwitch.Name = "cmbCondition_PlayerSwitch"
        cmbCondition_PlayerSwitch.Size = New Size(199, 32)
        cmbCondition_PlayerSwitch.TabIndex = 5
        ' 
        ' nudCondition_PlayerVarCondition
        ' 
        nudCondition_PlayerVarCondition.Location = New Point(558, 41)
        nudCondition_PlayerVarCondition.Margin = New Padding(5)
        nudCondition_PlayerVarCondition.Name = "nudCondition_PlayerVarCondition"
        nudCondition_PlayerVarCondition.Size = New Size(78, 31)
        nudCondition_PlayerVarCondition.TabIndex = 4
        ' 
        ' cmbCondition_PlayerVarCompare
        ' 
        cmbCondition_PlayerVarCompare.DrawMode = DrawMode.OwnerDrawFixed
        cmbCondition_PlayerVarCompare.FormattingEnabled = True
        cmbCondition_PlayerVarCompare.Items.AddRange(New Object() {"Equal To", "Great Than Or Equal To", "Less Than or Equal To", "Greater Than", "Less Than", "Does Not Equal"})
        cmbCondition_PlayerVarCompare.Location = New Point(393, 40)
        cmbCondition_PlayerVarCompare.Margin = New Padding(5)
        cmbCondition_PlayerVarCompare.Name = "cmbCondition_PlayerVarCompare"
        cmbCondition_PlayerVarCompare.Size = New Size(144, 32)
        cmbCondition_PlayerVarCompare.TabIndex = 3
        ' 
        ' DarkLabel14
        ' 
        DarkLabel14.AutoSize = True
        DarkLabel14.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel14.Location = New Point(360, 47)
        DarkLabel14.Margin = New Padding(5, 0, 5, 0)
        DarkLabel14.Name = "DarkLabel14"
        DarkLabel14.Size = New Size(24, 25)
        DarkLabel14.TabIndex = 2
        DarkLabel14.Text = "is"
        ' 
        ' cmbCondition_PlayerVarIndex
        ' 
        cmbCondition_PlayerVarIndex.DrawMode = DrawMode.OwnerDrawFixed
        cmbCondition_PlayerVarIndex.FormattingEnabled = True
        cmbCondition_PlayerVarIndex.Location = New Point(178, 40)
        cmbCondition_PlayerVarIndex.Margin = New Padding(5)
        cmbCondition_PlayerVarIndex.Name = "cmbCondition_PlayerVarIndex"
        cmbCondition_PlayerVarIndex.Size = New Size(169, 32)
        cmbCondition_PlayerVarIndex.TabIndex = 1
        ' 
        ' optCondition0
        ' 
        optCondition0.AutoSize = True
        optCondition0.Location = New Point(10, 41)
        optCondition0.Margin = New Padding(5)
        optCondition0.Name = "optCondition0"
        optCondition0.Size = New Size(151, 29)
        optCondition0.TabIndex = 0
        optCondition0.TabStop = True
        optCondition0.Text = "Player Variable"
        ' 
        ' fraPlayBGM
        ' 
        fraPlayBGM.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraPlayBGM.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraPlayBGM.Controls.Add(btnPlayBgmOk)
        fraPlayBGM.Controls.Add(btnPlayBgmCancel)
        fraPlayBGM.Controls.Add(cmbPlayBGM)
        fraPlayBGM.ForeColor = Color.Gainsboro
        fraPlayBGM.Location = New Point(668, 2)
        fraPlayBGM.Margin = New Padding(5)
        fraPlayBGM.Name = "fraPlayBGM"
        fraPlayBGM.Padding = New Padding(5)
        fraPlayBGM.Size = New Size(410, 145)
        fraPlayBGM.TabIndex = 21
        fraPlayBGM.TabStop = False
        fraPlayBGM.Text = "Play BGM"
        fraPlayBGM.Visible = False
        ' 
        ' btnPlayBgmOk
        ' 
        btnPlayBgmOk.Location = New Point(77, 88)
        btnPlayBgmOk.Margin = New Padding(5)
        btnPlayBgmOk.Name = "btnPlayBgmOk"
        btnPlayBgmOk.Padding = New Padding(8, 10, 8, 10)
        btnPlayBgmOk.Size = New Size(125, 45)
        btnPlayBgmOk.TabIndex = 27
        btnPlayBgmOk.Text = "Ok"
        ' 
        ' btnPlayBgmCancel
        ' 
        btnPlayBgmCancel.Location = New Point(212, 88)
        btnPlayBgmCancel.Margin = New Padding(5)
        btnPlayBgmCancel.Name = "btnPlayBgmCancel"
        btnPlayBgmCancel.Padding = New Padding(8, 10, 8, 10)
        btnPlayBgmCancel.Size = New Size(125, 45)
        btnPlayBgmCancel.TabIndex = 26
        btnPlayBgmCancel.Text = "Cancel"
        ' 
        ' cmbPlayBGM
        ' 
        cmbPlayBGM.DrawMode = DrawMode.OwnerDrawFixed
        cmbPlayBGM.FormattingEnabled = True
        cmbPlayBGM.Location = New Point(10, 37)
        cmbPlayBGM.Margin = New Padding(5)
        cmbPlayBGM.Name = "cmbPlayBGM"
        cmbPlayBGM.Size = New Size(386, 32)
        cmbPlayBGM.TabIndex = 0
        ' 
        ' fraPlayerWarp
        ' 
        fraPlayerWarp.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraPlayerWarp.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraPlayerWarp.Controls.Add(btnPlayerWarpOk)
        fraPlayerWarp.Controls.Add(btnPlayerWarpCancel)
        fraPlayerWarp.Controls.Add(DarkLabel31)
        fraPlayerWarp.Controls.Add(cmbWarpPlayerDir)
        fraPlayerWarp.Controls.Add(nudWPY)
        fraPlayerWarp.Controls.Add(DarkLabel32)
        fraPlayerWarp.Controls.Add(nudWPX)
        fraPlayerWarp.Controls.Add(DarkLabel33)
        fraPlayerWarp.Controls.Add(nudWPMap)
        fraPlayerWarp.Controls.Add(DarkLabel34)
        fraPlayerWarp.ForeColor = Color.Gainsboro
        fraPlayerWarp.Location = New Point(668, 12)
        fraPlayerWarp.Margin = New Padding(5)
        fraPlayerWarp.Name = "fraPlayerWarp"
        fraPlayerWarp.Padding = New Padding(5)
        fraPlayerWarp.Size = New Size(410, 187)
        fraPlayerWarp.TabIndex = 19
        fraPlayerWarp.TabStop = False
        fraPlayerWarp.Text = "Warp Player"
        fraPlayerWarp.Visible = False
        ' 
        ' btnPlayerWarpOk
        ' 
        btnPlayerWarpOk.Location = New Point(138, 130)
        btnPlayerWarpOk.Margin = New Padding(5)
        btnPlayerWarpOk.Name = "btnPlayerWarpOk"
        btnPlayerWarpOk.Padding = New Padding(8, 10, 8, 10)
        btnPlayerWarpOk.Size = New Size(125, 45)
        btnPlayerWarpOk.TabIndex = 46
        btnPlayerWarpOk.Text = "Ok"
        ' 
        ' btnPlayerWarpCancel
        ' 
        btnPlayerWarpCancel.Location = New Point(273, 130)
        btnPlayerWarpCancel.Margin = New Padding(5)
        btnPlayerWarpCancel.Name = "btnPlayerWarpCancel"
        btnPlayerWarpCancel.Padding = New Padding(8, 10, 8, 10)
        btnPlayerWarpCancel.Size = New Size(125, 45)
        btnPlayerWarpCancel.TabIndex = 45
        btnPlayerWarpCancel.Text = "Cancel"
        ' 
        ' DarkLabel31
        ' 
        DarkLabel31.AutoSize = True
        DarkLabel31.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel31.Location = New Point(13, 85)
        DarkLabel31.Margin = New Padding(5, 0, 5, 0)
        DarkLabel31.Name = "DarkLabel31"
        DarkLabel31.Size = New Size(87, 25)
        DarkLabel31.TabIndex = 44
        DarkLabel31.Text = "Direction:"
        ' 
        ' cmbWarpPlayerDir
        ' 
        cmbWarpPlayerDir.DrawMode = DrawMode.OwnerDrawFixed
        cmbWarpPlayerDir.FormattingEnabled = True
        cmbWarpPlayerDir.Items.AddRange(New Object() {"Retain Direction", "Up", "Down", "Left", "Right"})
        cmbWarpPlayerDir.Location = New Point(160, 78)
        cmbWarpPlayerDir.Margin = New Padding(5)
        cmbWarpPlayerDir.Name = "cmbWarpPlayerDir"
        cmbWarpPlayerDir.Size = New Size(236, 32)
        cmbWarpPlayerDir.TabIndex = 43
        ' 
        ' nudWPY
        ' 
        nudWPY.Location = New Point(333, 28)
        nudWPY.Margin = New Padding(5)
        nudWPY.Name = "nudWPY"
        nudWPY.Size = New Size(65, 31)
        nudWPY.TabIndex = 42
        ' 
        ' DarkLabel32
        ' 
        DarkLabel32.AutoSize = True
        DarkLabel32.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel32.Location = New Point(295, 34)
        DarkLabel32.Margin = New Padding(5, 0, 5, 0)
        DarkLabel32.Name = "DarkLabel32"
        DarkLabel32.Size = New Size(26, 25)
        DarkLabel32.TabIndex = 41
        DarkLabel32.Text = "Y:"
        ' 
        ' nudWPX
        ' 
        nudWPX.Location = New Point(217, 28)
        nudWPX.Margin = New Padding(5)
        nudWPX.Name = "nudWPX"
        nudWPX.Size = New Size(65, 31)
        nudWPX.TabIndex = 40
        ' 
        ' DarkLabel33
        ' 
        DarkLabel33.AutoSize = True
        DarkLabel33.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel33.Location = New Point(178, 34)
        DarkLabel33.Margin = New Padding(5, 0, 5, 0)
        DarkLabel33.Name = "DarkLabel33"
        DarkLabel33.Size = New Size(27, 25)
        DarkLabel33.TabIndex = 39
        DarkLabel33.Text = "X:"
        ' 
        ' nudWPMap
        ' 
        nudWPMap.Location = New Point(72, 28)
        nudWPMap.Margin = New Padding(5)
        nudWPMap.Name = "nudWPMap"
        nudWPMap.Size = New Size(97, 31)
        nudWPMap.TabIndex = 38
        ' 
        ' DarkLabel34
        ' 
        DarkLabel34.AutoSize = True
        DarkLabel34.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel34.Location = New Point(10, 34)
        DarkLabel34.Margin = New Padding(5, 0, 5, 0)
        DarkLabel34.Name = "DarkLabel34"
        DarkLabel34.Size = New Size(52, 25)
        DarkLabel34.TabIndex = 37
        DarkLabel34.Text = "Map:"
        ' 
        ' fraSetFog
        ' 
        fraSetFog.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraSetFog.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraSetFog.Controls.Add(btnSetFogOk)
        fraSetFog.Controls.Add(btnSetFogCancel)
        fraSetFog.Controls.Add(DarkLabel30)
        fraSetFog.Controls.Add(DarkLabel29)
        fraSetFog.Controls.Add(DarkLabel28)
        fraSetFog.Controls.Add(nudFogData2)
        fraSetFog.Controls.Add(nudFogData1)
        fraSetFog.Controls.Add(nudFogData0)
        fraSetFog.ForeColor = Color.Gainsboro
        fraSetFog.Location = New Point(668, 13)
        fraSetFog.Margin = New Padding(5)
        fraSetFog.Name = "fraSetFog"
        fraSetFog.Padding = New Padding(5)
        fraSetFog.Size = New Size(410, 185)
        fraSetFog.TabIndex = 18
        fraSetFog.TabStop = False
        fraSetFog.Text = "Set Fog"
        fraSetFog.Visible = False
        ' 
        ' btnSetFogOk
        ' 
        btnSetFogOk.Location = New Point(140, 128)
        btnSetFogOk.Margin = New Padding(5)
        btnSetFogOk.Name = "btnSetFogOk"
        btnSetFogOk.Padding = New Padding(8, 10, 8, 10)
        btnSetFogOk.Size = New Size(125, 45)
        btnSetFogOk.TabIndex = 41
        btnSetFogOk.Text = "Ok"
        ' 
        ' btnSetFogCancel
        ' 
        btnSetFogCancel.Location = New Point(275, 128)
        btnSetFogCancel.Margin = New Padding(5)
        btnSetFogCancel.Name = "btnSetFogCancel"
        btnSetFogCancel.Padding = New Padding(8, 10, 8, 10)
        btnSetFogCancel.Size = New Size(125, 45)
        btnSetFogCancel.TabIndex = 40
        btnSetFogCancel.Text = "Cancel"
        ' 
        ' DarkLabel30
        ' 
        DarkLabel30.AutoSize = True
        DarkLabel30.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel30.Location = New Point(207, 80)
        DarkLabel30.Margin = New Padding(5, 0, 5, 0)
        DarkLabel30.Name = "DarkLabel30"
        DarkLabel30.Size = New Size(113, 25)
        DarkLabel30.TabIndex = 39
        DarkLabel30.Text = "Fog Opacity:"
        ' 
        ' DarkLabel29
        ' 
        DarkLabel29.AutoSize = True
        DarkLabel29.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel29.Location = New Point(12, 80)
        DarkLabel29.Margin = New Padding(5, 0, 5, 0)
        DarkLabel29.Name = "DarkLabel29"
        DarkLabel29.Size = New Size(102, 25)
        DarkLabel29.TabIndex = 38
        DarkLabel29.Text = "Fog Speed:"
        ' 
        ' DarkLabel28
        ' 
        DarkLabel28.AutoSize = True
        DarkLabel28.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel28.Location = New Point(12, 28)
        DarkLabel28.Margin = New Padding(5, 0, 5, 0)
        DarkLabel28.Name = "DarkLabel28"
        DarkLabel28.Size = New Size(47, 25)
        DarkLabel28.TabIndex = 37
        DarkLabel28.Text = "Fog:"
        ' 
        ' nudFogData2
        ' 
        nudFogData2.Location = New Point(318, 75)
        nudFogData2.Margin = New Padding(5)
        nudFogData2.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        nudFogData2.Name = "nudFogData2"
        nudFogData2.Size = New Size(82, 31)
        nudFogData2.TabIndex = 36
        ' 
        ' nudFogData1
        ' 
        nudFogData1.Location = New Point(120, 77)
        nudFogData1.Margin = New Padding(5)
        nudFogData1.Name = "nudFogData1"
        nudFogData1.Size = New Size(80, 31)
        nudFogData1.TabIndex = 35
        ' 
        ' nudFogData0
        ' 
        nudFogData0.Location = New Point(162, 23)
        nudFogData0.Margin = New Padding(5)
        nudFogData0.Name = "nudFogData0"
        nudFogData0.Size = New Size(238, 31)
        nudFogData0.TabIndex = 34
        ' 
        ' fraShowText
        ' 
        fraShowText.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraShowText.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraShowText.Controls.Add(DarkLabel27)
        fraShowText.Controls.Add(txtShowText)
        fraShowText.Controls.Add(btnShowTextCancel)
        fraShowText.Controls.Add(btnShowTextOk)
        fraShowText.ForeColor = Color.Gainsboro
        fraShowText.Location = New Point(10, 585)
        fraShowText.Margin = New Padding(5)
        fraShowText.Name = "fraShowText"
        fraShowText.Padding = New Padding(5)
        fraShowText.Size = New Size(413, 547)
        fraShowText.TabIndex = 17
        fraShowText.TabStop = False
        fraShowText.Text = "Show Text"
        fraShowText.Visible = False
        ' 
        ' DarkLabel27
        ' 
        DarkLabel27.AutoSize = True
        DarkLabel27.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel27.Location = New Point(12, 37)
        DarkLabel27.Margin = New Padding(5, 0, 5, 0)
        DarkLabel27.Name = "DarkLabel27"
        DarkLabel27.Size = New Size(42, 25)
        DarkLabel27.TabIndex = 26
        DarkLabel27.Text = "Text"
        ' 
        ' txtShowText
        ' 
        txtShowText.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtShowText.BorderStyle = BorderStyle.FixedSingle
        txtShowText.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtShowText.Location = New Point(15, 73)
        txtShowText.Margin = New Padding(5)
        txtShowText.Multiline = True
        txtShowText.Name = "txtShowText"
        txtShowText.Size = New Size(379, 200)
        txtShowText.TabIndex = 21
        ' 
        ' btnShowTextCancel
        ' 
        btnShowTextCancel.Location = New Point(278, 485)
        btnShowTextCancel.Margin = New Padding(5)
        btnShowTextCancel.Name = "btnShowTextCancel"
        btnShowTextCancel.Padding = New Padding(8, 10, 8, 10)
        btnShowTextCancel.Size = New Size(125, 45)
        btnShowTextCancel.TabIndex = 24
        btnShowTextCancel.Text = "Cancel"
        ' 
        ' btnShowTextOk
        ' 
        btnShowTextOk.Location = New Point(143, 485)
        btnShowTextOk.Margin = New Padding(5)
        btnShowTextOk.Name = "btnShowTextOk"
        btnShowTextOk.Padding = New Padding(8, 10, 8, 10)
        btnShowTextOk.Size = New Size(125, 45)
        btnShowTextOk.TabIndex = 25
        btnShowTextOk.Text = "Ok"
        ' 
        ' fraAddText
        ' 
        fraAddText.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraAddText.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraAddText.Controls.Add(btnAddTextOk)
        fraAddText.Controls.Add(btnAddTextCancel)
        fraAddText.Controls.Add(optAddText_Global)
        fraAddText.Controls.Add(optAddText_Map)
        fraAddText.Controls.Add(optAddText_Player)
        fraAddText.Controls.Add(DarkLabel25)
        fraAddText.Controls.Add(txtAddText_Text)
        fraAddText.Controls.Add(DarkLabel24)
        fraAddText.ForeColor = Color.Gainsboro
        fraAddText.Location = New Point(10, 698)
        fraAddText.Margin = New Padding(5)
        fraAddText.Name = "fraAddText"
        fraAddText.Padding = New Padding(5)
        fraAddText.Size = New Size(388, 360)
        fraAddText.TabIndex = 3
        fraAddText.TabStop = False
        fraAddText.Text = "Add Text"
        fraAddText.Visible = False
        ' 
        ' btnAddTextOk
        ' 
        btnAddTextOk.Location = New Point(92, 300)
        btnAddTextOk.Margin = New Padding(5)
        btnAddTextOk.Name = "btnAddTextOk"
        btnAddTextOk.Padding = New Padding(8, 10, 8, 10)
        btnAddTextOk.Size = New Size(125, 45)
        btnAddTextOk.TabIndex = 9
        btnAddTextOk.Text = "Ok"
        ' 
        ' btnAddTextCancel
        ' 
        btnAddTextCancel.Location = New Point(227, 300)
        btnAddTextCancel.Margin = New Padding(5)
        btnAddTextCancel.Name = "btnAddTextCancel"
        btnAddTextCancel.Padding = New Padding(8, 10, 8, 10)
        btnAddTextCancel.Size = New Size(125, 45)
        btnAddTextCancel.TabIndex = 8
        btnAddTextCancel.Text = "Cancel"
        ' 
        ' optAddText_Global
        ' 
        optAddText_Global.AutoSize = True
        optAddText_Global.Location = New Point(288, 255)
        optAddText_Global.Margin = New Padding(5)
        optAddText_Global.Name = "optAddText_Global"
        optAddText_Global.Size = New Size(88, 29)
        optAddText_Global.TabIndex = 5
        optAddText_Global.TabStop = True
        optAddText_Global.Text = "Global"
        ' 
        ' optAddText_Map
        ' 
        optAddText_Map.AutoSize = True
        optAddText_Map.Location = New Point(202, 255)
        optAddText_Map.Margin = New Padding(5)
        optAddText_Map.Name = "optAddText_Map"
        optAddText_Map.Size = New Size(73, 29)
        optAddText_Map.TabIndex = 4
        optAddText_Map.TabStop = True
        optAddText_Map.Text = "Map"
        ' 
        ' optAddText_Player
        ' 
        optAddText_Player.AutoSize = True
        optAddText_Player.Location = New Point(102, 255)
        optAddText_Player.Margin = New Padding(5)
        optAddText_Player.Name = "optAddText_Player"
        optAddText_Player.Size = New Size(84, 29)
        optAddText_Player.TabIndex = 3
        optAddText_Player.TabStop = True
        optAddText_Player.Text = "Player"
        ' 
        ' DarkLabel25
        ' 
        DarkLabel25.AutoSize = True
        DarkLabel25.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel25.Location = New Point(10, 260)
        DarkLabel25.Margin = New Padding(5, 0, 5, 0)
        DarkLabel25.Name = "DarkLabel25"
        DarkLabel25.Size = New Size(79, 25)
        DarkLabel25.TabIndex = 2
        DarkLabel25.Text = "Channel:"
        ' 
        ' txtAddText_Text
        ' 
        txtAddText_Text.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtAddText_Text.BorderStyle = BorderStyle.FixedSingle
        txtAddText_Text.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtAddText_Text.Location = New Point(10, 60)
        txtAddText_Text.Margin = New Padding(5)
        txtAddText_Text.Multiline = True
        txtAddText_Text.Name = "txtAddText_Text"
        txtAddText_Text.Size = New Size(369, 182)
        txtAddText_Text.TabIndex = 1
        ' 
        ' DarkLabel24
        ' 
        DarkLabel24.AutoSize = True
        DarkLabel24.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel24.Location = New Point(10, 28)
        DarkLabel24.Margin = New Padding(5, 0, 5, 0)
        DarkLabel24.Name = "DarkLabel24"
        DarkLabel24.Size = New Size(42, 25)
        DarkLabel24.TabIndex = 0
        DarkLabel24.Text = "Text"
        ' 
        ' fraChangeItems
        ' 
        fraChangeItems.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraChangeItems.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraChangeItems.Controls.Add(btnChangeItemsOk)
        fraChangeItems.Controls.Add(btnChangeItemsCancel)
        fraChangeItems.Controls.Add(nudChangeItemsAmount)
        fraChangeItems.Controls.Add(optChangeItemRemove)
        fraChangeItems.Controls.Add(optChangeItemAdd)
        fraChangeItems.Controls.Add(optChangeItemSet)
        fraChangeItems.Controls.Add(cmbChangeItemIndex)
        fraChangeItems.Controls.Add(DarkLabel21)
        fraChangeItems.ForeColor = Color.Gainsboro
        fraChangeItems.Location = New Point(10, 750)
        fraChangeItems.Margin = New Padding(5)
        fraChangeItems.Name = "fraChangeItems"
        fraChangeItems.Padding = New Padding(5)
        fraChangeItems.Size = New Size(312, 230)
        fraChangeItems.TabIndex = 1
        fraChangeItems.TabStop = False
        fraChangeItems.Text = "Change Items"
        fraChangeItems.Visible = False
        ' 
        ' btnChangeItemsOk
        ' 
        btnChangeItemsOk.Location = New Point(42, 175)
        btnChangeItemsOk.Margin = New Padding(5)
        btnChangeItemsOk.Name = "btnChangeItemsOk"
        btnChangeItemsOk.Padding = New Padding(8, 10, 8, 10)
        btnChangeItemsOk.Size = New Size(125, 45)
        btnChangeItemsOk.TabIndex = 7
        btnChangeItemsOk.Text = "Ok"
        ' 
        ' btnChangeItemsCancel
        ' 
        btnChangeItemsCancel.Location = New Point(177, 175)
        btnChangeItemsCancel.Margin = New Padding(5)
        btnChangeItemsCancel.Name = "btnChangeItemsCancel"
        btnChangeItemsCancel.Padding = New Padding(8, 10, 8, 10)
        btnChangeItemsCancel.Size = New Size(125, 45)
        btnChangeItemsCancel.TabIndex = 6
        btnChangeItemsCancel.Text = "Cancel"
        ' 
        ' nudChangeItemsAmount
        ' 
        nudChangeItemsAmount.Location = New Point(15, 125)
        nudChangeItemsAmount.Margin = New Padding(5)
        nudChangeItemsAmount.Name = "nudChangeItemsAmount"
        nudChangeItemsAmount.Size = New Size(287, 31)
        nudChangeItemsAmount.TabIndex = 5
        ' 
        ' optChangeItemRemove
        ' 
        optChangeItemRemove.AutoSize = True
        optChangeItemRemove.Location = New Point(202, 80)
        optChangeItemRemove.Margin = New Padding(5)
        optChangeItemRemove.Name = "optChangeItemRemove"
        optChangeItemRemove.Size = New Size(71, 29)
        optChangeItemRemove.TabIndex = 4
        optChangeItemRemove.TabStop = True
        optChangeItemRemove.Text = "Take"
        ' 
        ' optChangeItemAdd
        ' 
        optChangeItemAdd.AutoSize = True
        optChangeItemAdd.Location = New Point(113, 80)
        optChangeItemAdd.Margin = New Padding(5)
        optChangeItemAdd.Name = "optChangeItemAdd"
        optChangeItemAdd.Size = New Size(71, 29)
        optChangeItemAdd.TabIndex = 3
        optChangeItemAdd.TabStop = True
        optChangeItemAdd.Text = "Give"
        ' 
        ' optChangeItemSet
        ' 
        optChangeItemSet.AutoSize = True
        optChangeItemSet.Location = New Point(15, 80)
        optChangeItemSet.Margin = New Padding(5)
        optChangeItemSet.Name = "optChangeItemSet"
        optChangeItemSet.Size = New Size(84, 29)
        optChangeItemSet.TabIndex = 2
        optChangeItemSet.TabStop = True
        optChangeItemSet.Text = "Set to"
        ' 
        ' cmbChangeItemIndex
        ' 
        cmbChangeItemIndex.DrawMode = DrawMode.OwnerDrawFixed
        cmbChangeItemIndex.FormattingEnabled = True
        cmbChangeItemIndex.Location = New Point(70, 25)
        cmbChangeItemIndex.Margin = New Padding(5)
        cmbChangeItemIndex.Name = "cmbChangeItemIndex"
        cmbChangeItemIndex.Size = New Size(229, 32)
        cmbChangeItemIndex.TabIndex = 1
        ' 
        ' DarkLabel21
        ' 
        DarkLabel21.AutoSize = True
        DarkLabel21.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel21.Location = New Point(10, 30)
        DarkLabel21.Margin = New Padding(5, 0, 5, 0)
        DarkLabel21.Name = "DarkLabel21"
        DarkLabel21.Size = New Size(52, 25)
        DarkLabel21.TabIndex = 0
        DarkLabel21.Text = "Item:"
        ' 
        ' pnlVariableSwitches
        ' 
        pnlVariableSwitches.Controls.Add(FraRenaming)
        pnlVariableSwitches.Controls.Add(fraLabeling)
        pnlVariableSwitches.Location = New Point(1333, 387)
        pnlVariableSwitches.Margin = New Padding(5)
        pnlVariableSwitches.Name = "pnlVariableSwitches"
        pnlVariableSwitches.Size = New Size(155, 175)
        pnlVariableSwitches.TabIndex = 11
        ' 
        ' FraRenaming
        ' 
        FraRenaming.Controls.Add(btnRename_Cancel)
        FraRenaming.Controls.Add(btnRename_Ok)
        FraRenaming.Controls.Add(fraRandom10)
        FraRenaming.ForeColor = Color.Gainsboro
        FraRenaming.Location = New Point(393, 825)
        FraRenaming.Margin = New Padding(5)
        FraRenaming.Name = "FraRenaming"
        FraRenaming.Padding = New Padding(5)
        FraRenaming.Size = New Size(607, 275)
        FraRenaming.TabIndex = 8
        FraRenaming.TabStop = False
        FraRenaming.Text = "Renaming Variable/Switch"
        FraRenaming.Visible = False
        ' 
        ' btnRename_Cancel
        ' 
        btnRename_Cancel.ForeColor = Color.Black
        btnRename_Cancel.Location = New Point(382, 197)
        btnRename_Cancel.Margin = New Padding(5)
        btnRename_Cancel.Name = "btnRename_Cancel"
        btnRename_Cancel.Size = New Size(125, 45)
        btnRename_Cancel.TabIndex = 2
        btnRename_Cancel.Text = "Cancel"
        btnRename_Cancel.UseVisualStyleBackColor = True
        ' 
        ' btnRename_Ok
        ' 
        btnRename_Ok.ForeColor = Color.Black
        btnRename_Ok.Location = New Point(90, 197)
        btnRename_Ok.Margin = New Padding(5)
        btnRename_Ok.Name = "btnRename_Ok"
        btnRename_Ok.Size = New Size(125, 45)
        btnRename_Ok.TabIndex = 1
        btnRename_Ok.Text = "Ok"
        btnRename_Ok.UseVisualStyleBackColor = True
        ' 
        ' fraRandom10
        ' 
        fraRandom10.Controls.Add(txtRename)
        fraRandom10.Controls.Add(lblEditing)
        fraRandom10.ForeColor = Color.Gainsboro
        fraRandom10.Location = New Point(10, 37)
        fraRandom10.Margin = New Padding(5)
        fraRandom10.Name = "fraRandom10"
        fraRandom10.Padding = New Padding(5)
        fraRandom10.Size = New Size(587, 148)
        fraRandom10.TabIndex = 0
        fraRandom10.TabStop = False
        fraRandom10.Text = "Editing Variable/Switch"
        ' 
        ' txtRename
        ' 
        txtRename.Location = New Point(10, 78)
        txtRename.Margin = New Padding(5)
        txtRename.Name = "txtRename"
        txtRename.Size = New Size(564, 31)
        txtRename.TabIndex = 1
        ' 
        ' lblEditing
        ' 
        lblEditing.AutoSize = True
        lblEditing.Location = New Point(5, 48)
        lblEditing.Margin = New Padding(5, 0, 5, 0)
        lblEditing.Name = "lblEditing"
        lblEditing.Size = New Size(168, 25)
        lblEditing.TabIndex = 0
        lblEditing.Text = "Naming Variable #1"
        ' 
        ' fraLabeling
        ' 
        fraLabeling.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        fraLabeling.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        fraLabeling.Controls.Add(lstSwitches)
        fraLabeling.Controls.Add(lstVariables)
        fraLabeling.Controls.Add(btnLabel_Cancel)
        fraLabeling.Controls.Add(lblRandomLabel36)
        fraLabeling.Controls.Add(btnRenameVariable)
        fraLabeling.Controls.Add(lblRandomLabel25)
        fraLabeling.Controls.Add(btnRenameSwitch)
        fraLabeling.Controls.Add(btnLabel_Ok)
        fraLabeling.ForeColor = Color.Gainsboro
        fraLabeling.Location = New Point(325, 55)
        fraLabeling.Margin = New Padding(5)
        fraLabeling.Name = "fraLabeling"
        fraLabeling.Padding = New Padding(5)
        fraLabeling.Size = New Size(760, 745)
        fraLabeling.TabIndex = 0
        fraLabeling.TabStop = False
        fraLabeling.Text = "Label Variables and  Switches   "
        ' 
        ' lstSwitches
        ' 
        lstSwitches.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        lstSwitches.BorderStyle = BorderStyle.FixedSingle
        lstSwitches.ForeColor = Color.Gainsboro
        lstSwitches.FormattingEnabled = True
        lstSwitches.ItemHeight = 25
        lstSwitches.Location = New Point(393, 75)
        lstSwitches.Margin = New Padding(5)
        lstSwitches.Name = "lstSwitches"
        lstSwitches.Size = New Size(340, 552)
        lstSwitches.TabIndex = 7
        ' 
        ' lstVariables
        ' 
        lstVariables.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        lstVariables.BorderStyle = BorderStyle.FixedSingle
        lstVariables.ForeColor = Color.Gainsboro
        lstVariables.FormattingEnabled = True
        lstVariables.ItemHeight = 25
        lstVariables.Location = New Point(23, 75)
        lstVariables.Margin = New Padding(5)
        lstVariables.Name = "lstVariables"
        lstVariables.Size = New Size(340, 552)
        lstVariables.TabIndex = 6
        ' 
        ' btnLabel_Cancel
        ' 
        btnLabel_Cancel.ForeColor = Color.Black
        btnLabel_Cancel.Location = New Point(393, 655)
        btnLabel_Cancel.Margin = New Padding(5)
        btnLabel_Cancel.Name = "btnLabel_Cancel"
        btnLabel_Cancel.Padding = New Padding(5)
        btnLabel_Cancel.Size = New Size(125, 45)
        btnLabel_Cancel.TabIndex = 12
        btnLabel_Cancel.Text = "Cancel"
        ' 
        ' lblRandomLabel36
        ' 
        lblRandomLabel36.AutoSize = True
        lblRandomLabel36.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        lblRandomLabel36.Location = New Point(488, 45)
        lblRandomLabel36.Margin = New Padding(5, 0, 5, 0)
        lblRandomLabel36.Name = "lblRandomLabel36"
        lblRandomLabel36.Size = New Size(132, 25)
        lblRandomLabel36.TabIndex = 5
        lblRandomLabel36.Text = "Player Switches"
        ' 
        ' btnRenameVariable
        ' 
        btnRenameVariable.ForeColor = Color.Black
        btnRenameVariable.Location = New Point(23, 655)
        btnRenameVariable.Margin = New Padding(5)
        btnRenameVariable.Name = "btnRenameVariable"
        btnRenameVariable.Padding = New Padding(5)
        btnRenameVariable.Size = New Size(177, 45)
        btnRenameVariable.TabIndex = 9
        btnRenameVariable.Text = "Rename Variable"
        ' 
        ' lblRandomLabel25
        ' 
        lblRandomLabel25.AutoSize = True
        lblRandomLabel25.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        lblRandomLabel25.Location = New Point(133, 40)
        lblRandomLabel25.Margin = New Padding(5, 0, 5, 0)
        lblRandomLabel25.Name = "lblRandomLabel25"
        lblRandomLabel25.Size = New Size(134, 25)
        lblRandomLabel25.TabIndex = 4
        lblRandomLabel25.Text = "Player Variables"
        ' 
        ' btnRenameSwitch
        ' 
        btnRenameSwitch.ForeColor = Color.Black
        btnRenameSwitch.Location = New Point(553, 655)
        btnRenameSwitch.Margin = New Padding(5)
        btnRenameSwitch.Name = "btnRenameSwitch"
        btnRenameSwitch.Padding = New Padding(5)
        btnRenameSwitch.Size = New Size(182, 45)
        btnRenameSwitch.TabIndex = 10
        btnRenameSwitch.Text = "Rename Switch"
        ' 
        ' btnLabel_Ok
        ' 
        btnLabel_Ok.ForeColor = Color.Black
        btnLabel_Ok.Location = New Point(240, 655)
        btnLabel_Ok.Margin = New Padding(5)
        btnLabel_Ok.Name = "btnLabel_Ok"
        btnLabel_Ok.Padding = New Padding(5)
        btnLabel_Ok.Size = New Size(125, 45)
        btnLabel_Ok.TabIndex = 11
        btnLabel_Ok.Text = "Ok"
        ' 
        ' frmEditor_Events
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        ClientSize = New Size(2718, 1182)
        Controls.Add(pnlVariableSwitches)
        Controls.Add(fraDialogue)
        Controls.Add(btnOk)
        Controls.Add(btnCancel)
        Controls.Add(btnLabeling)
        Controls.Add(tabPages)
        Controls.Add(fraPageSetUp)
        Controls.Add(pnlTabPage)
        Controls.Add(pnlGraphicSel)
        Controls.Add(fraMoveRoute)
        ForeColor = Color.Gainsboro
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Margin = New Padding(5)
        Name = "frmEditor_Events"
        Text = "Event Editor"
        fraPageSetUp.ResumeLayout(False)
        fraPageSetUp.PerformLayout()
        tabPages.ResumeLayout(False)
        pnlTabPage.ResumeLayout(False)
        DarkGroupBox2.ResumeLayout(False)
        fraGraphicPic.ResumeLayout(False)
        CType(picGraphic, System.ComponentModel.ISupportInitialize).EndInit()
        DarkGroupBox6.ResumeLayout(False)
        DarkGroupBox6.PerformLayout()
        DarkGroupBox5.ResumeLayout(False)
        DarkGroupBox4.ResumeLayout(False)
        CType(picGraphicSel, System.ComponentModel.ISupportInitialize).EndInit()
        DarkGroupBox3.ResumeLayout(False)
        DarkGroupBox3.PerformLayout()
        DarkGroupBox1.ResumeLayout(False)
        DarkGroupBox1.PerformLayout()
        CType(nudPlayerVariable, System.ComponentModel.ISupportInitialize).EndInit()
        DarkGroupBox8.ResumeLayout(False)
        fraGraphic.ResumeLayout(False)
        fraGraphic.PerformLayout()
        CType(nudGraphic, System.ComponentModel.ISupportInitialize).EndInit()
        fraCommands.ResumeLayout(False)
        fraMoveRoute.ResumeLayout(False)
        fraMoveRoute.PerformLayout()
        DarkGroupBox10.ResumeLayout(False)
        fraDialogue.ResumeLayout(False)
        fraShowChatBubble.ResumeLayout(False)
        fraShowChatBubble.PerformLayout()
        fraOpenShop.ResumeLayout(False)
        fraSetSelfSwitch.ResumeLayout(False)
        fraSetSelfSwitch.PerformLayout()
        fraPlaySound.ResumeLayout(False)
        fraChangePK.ResumeLayout(False)
        fraCreateLabel.ResumeLayout(False)
        fraCreateLabel.PerformLayout()
        fraChangeJob.ResumeLayout(False)
        fraChangeJob.PerformLayout()
        fraChangeSkills.ResumeLayout(False)
        fraChangeSkills.PerformLayout()
        fraPlayerSwitch.ResumeLayout(False)
        fraPlayerSwitch.PerformLayout()
        fraSetWait.ResumeLayout(False)
        fraSetWait.PerformLayout()
        CType(nudWaitAmount, System.ComponentModel.ISupportInitialize).EndInit()
        fraMoveRouteWait.ResumeLayout(False)
        fraMoveRouteWait.PerformLayout()
        fraCustomScript.ResumeLayout(False)
        fraCustomScript.PerformLayout()
        CType(nudCustomScript, System.ComponentModel.ISupportInitialize).EndInit()
        fraSpawnNpc.ResumeLayout(False)
        fraSetWeather.ResumeLayout(False)
        fraSetWeather.PerformLayout()
        CType(nudWeatherIntensity, System.ComponentModel.ISupportInitialize).EndInit()
        fraGiveExp.ResumeLayout(False)
        fraGiveExp.PerformLayout()
        CType(nudGiveExp, System.ComponentModel.ISupportInitialize).EndInit()
        fraSetAccess.ResumeLayout(False)
        fraChangeGender.ResumeLayout(False)
        fraChangeGender.PerformLayout()
        fraShowChoices.ResumeLayout(False)
        fraShowChoices.PerformLayout()
        fraChangeLevel.ResumeLayout(False)
        fraChangeLevel.PerformLayout()
        CType(nudChangeLevel, System.ComponentModel.ISupportInitialize).EndInit()
        fraPlayerVariable.ResumeLayout(False)
        fraPlayerVariable.PerformLayout()
        CType(nudVariableData2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(nudVariableData4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(nudVariableData3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(nudVariableData1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(nudVariableData0, System.ComponentModel.ISupportInitialize).EndInit()
        fraPlayAnimation.ResumeLayout(False)
        fraPlayAnimation.PerformLayout()
        CType(nudPlayAnimTileY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(nudPlayAnimTileX, System.ComponentModel.ISupportInitialize).EndInit()
        fraChangeSprite.ResumeLayout(False)
        fraChangeSprite.PerformLayout()
        CType(nudChangeSprite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(picChangeSprite, System.ComponentModel.ISupportInitialize).EndInit()
        fraGoToLabel.ResumeLayout(False)
        fraGoToLabel.PerformLayout()
        fraMapTint.ResumeLayout(False)
        fraMapTint.PerformLayout()
        CType(nudMapTintData3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(nudMapTintData2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(nudMapTintData1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(nudMapTintData0, System.ComponentModel.ISupportInitialize).EndInit()
        fraShowPic.ResumeLayout(False)
        fraShowPic.PerformLayout()
        CType(nudPicOffsetY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(nudPicOffsetX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(nudShowPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(picShowPic, System.ComponentModel.ISupportInitialize).EndInit()
        fraConditionalBranch.ResumeLayout(False)
        fraConditionalBranch.PerformLayout()
        CType(nudCondition_LevelAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(nudCondition_HasItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(nudCondition_PlayerVarCondition, System.ComponentModel.ISupportInitialize).EndInit()
        fraPlayBGM.ResumeLayout(False)
        fraPlayerWarp.ResumeLayout(False)
        fraPlayerWarp.PerformLayout()
        CType(nudWPY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(nudWPX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(nudWPMap, System.ComponentModel.ISupportInitialize).EndInit()
        fraSetFog.ResumeLayout(False)
        fraSetFog.PerformLayout()
        CType(nudFogData2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(nudFogData1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(nudFogData0, System.ComponentModel.ISupportInitialize).EndInit()
        fraShowText.ResumeLayout(False)
        fraShowText.PerformLayout()
        fraAddText.ResumeLayout(False)
        fraAddText.PerformLayout()
        fraChangeItems.ResumeLayout(False)
        fraChangeItems.PerformLayout()
        CType(nudChangeItemsAmount, System.ComponentModel.ISupportInitialize).EndInit()
        pnlVariableSwitches.ResumeLayout(False)
        FraRenaming.ResumeLayout(False)
        fraRandom10.ResumeLayout(False)
        fraRandom10.PerformLayout()
        fraLabeling.ResumeLayout(False)
        fraLabeling.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents tvCommands As TreeView
    Friend WithEvents fraPageSetUp As DarkUI.Controls.DarkGroupBox
    Friend WithEvents tabPages As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents txtName As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel1 As DarkUI.Controls.DarkLabel
    Friend WithEvents btnNewPage As DarkUI.Controls.DarkButton
    Friend WithEvents btnCopyPage As DarkUI.Controls.DarkButton
    Friend WithEvents btnPastePage As DarkUI.Controls.DarkButton
    Friend WithEvents btnClearPage As DarkUI.Controls.DarkButton
    Friend WithEvents btnDeletePage As DarkUI.Controls.DarkButton
    Friend WithEvents pnlTabPage As Panel
    Friend WithEvents DarkGroupBox1 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents chkPlayerVar As DarkUI.Controls.DarkCheckBox
    Friend WithEvents cmbPlayerVar As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel2 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbPlayervarCompare As DarkUI.Controls.DarkComboBox
    Friend WithEvents nudPlayerVariable As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents chkPlayerSwitch As DarkUI.Controls.DarkCheckBox
    Friend WithEvents cmbPlayerSwitch As DarkUI.Controls.DarkComboBox
    Friend WithEvents cmbPlayerSwitchCompare As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel3 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbHasItem As DarkUI.Controls.DarkComboBox
    Friend WithEvents chkHasItem As DarkUI.Controls.DarkCheckBox
    Friend WithEvents cmbSelfSwitch As DarkUI.Controls.DarkComboBox
    Friend WithEvents chkSelfSwitch As DarkUI.Controls.DarkCheckBox
    Friend WithEvents cmbSelfSwitchCompare As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel4 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkGroupBox3 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents chkGlobal As DarkUI.Controls.DarkCheckBox
    Friend WithEvents DarkLabel5 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbMoveType As DarkUI.Controls.DarkComboBox
    Friend WithEvents btnMoveRoute As DarkUI.Controls.DarkButton
    Friend WithEvents DarkLabel6 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbMoveSpeed As DarkUI.Controls.DarkComboBox
    Friend WithEvents cmbMoveFreq As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel7 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkGroupBox4 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents DarkGroupBox5 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents cmbTrigger As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel8 As DarkUI.Controls.DarkLabel
    Friend WithEvents lstCommands As ListBox
    Friend WithEvents DarkGroupBox8 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents btnAddCommand As DarkUI.Controls.DarkButton
    Friend WithEvents btnDeleteCommand As DarkUI.Controls.DarkButton
    Friend WithEvents btnEditCommand As DarkUI.Controls.DarkButton
    Friend WithEvents btnClearCommand As DarkUI.Controls.DarkButton
    Friend WithEvents fraCommands As Panel
    Friend WithEvents btnLabeling As DarkUI.Controls.DarkButton
    Friend WithEvents btnCancel As DarkUI.Controls.DarkButton
    Friend WithEvents btnOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnCancelCommand As DarkUI.Controls.DarkButton
    Friend WithEvents fraMoveRoute As DarkUI.Controls.DarkGroupBox
    Friend WithEvents cmbEvent As DarkUI.Controls.DarkComboBox
    Friend WithEvents lstMoveRoute As ListBox
    Friend WithEvents DarkGroupBox10 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents lstvwMoveRoute As ListView
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents chkRepeatRoute As DarkUI.Controls.DarkCheckBox
    Friend WithEvents chkIgnoreMove As DarkUI.Controls.DarkCheckBox
    Friend WithEvents btnMoveRouteOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnMoveRouteCancel As DarkUI.Controls.DarkButton
    Friend WithEvents picGraphicSel As PictureBox
    Friend WithEvents fraDialogue As DarkUI.Controls.DarkGroupBox
    Friend WithEvents fraConditionalBranch As DarkUI.Controls.DarkGroupBox
    Friend WithEvents optCondition0 As DarkUI.Controls.DarkRadioButton
    Friend WithEvents cmbCondition_PlayerVarIndex As DarkUI.Controls.DarkComboBox
    Friend WithEvents nudCondition_PlayerVarCondition As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents cmbCondition_PlayerVarCompare As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel14 As DarkUI.Controls.DarkLabel
    Friend WithEvents optCondition1 As DarkUI.Controls.DarkRadioButton
    Friend WithEvents DarkLabel15 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbCondtion_PlayerSwitchCondition As DarkUI.Controls.DarkComboBox
    Friend WithEvents cmbCondition_PlayerSwitch As DarkUI.Controls.DarkComboBox
    Friend WithEvents optCondition2 As DarkUI.Controls.DarkRadioButton
    Friend WithEvents nudCondition_HasItem As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel16 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbCondition_HasItem As DarkUI.Controls.DarkComboBox
    Friend WithEvents optCondition3 As DarkUI.Controls.DarkRadioButton
    Friend WithEvents cmbCondition_JobIs As DarkUI.Controls.DarkComboBox
    Friend WithEvents optCondition4 As DarkUI.Controls.DarkRadioButton
    Friend WithEvents cmbCondition_LearntSkill As DarkUI.Controls.DarkComboBox
    Friend WithEvents optCondition5 As DarkUI.Controls.DarkRadioButton
    Friend WithEvents cmbCondition_LevelCompare As DarkUI.Controls.DarkComboBox
    Friend WithEvents nudCondition_LevelAmount As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents optCondition6 As DarkUI.Controls.DarkRadioButton
    Friend WithEvents cmbCondition_SelfSwitchCondition As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel17 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbCondition_SelfSwitch As DarkUI.Controls.DarkComboBox
    Friend WithEvents optCondition8 As DarkUI.Controls.DarkRadioButton
    Friend WithEvents cmbCondition_Gender As DarkUI.Controls.DarkComboBox
    Friend WithEvents btnConditionalBranchOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnConditionalBranchCancel As DarkUI.Controls.DarkButton
    Friend WithEvents fraChangeItems As DarkUI.Controls.DarkGroupBox
    Friend WithEvents fraPlayerSwitch As DarkUI.Controls.DarkGroupBox
    Friend WithEvents cmbChangeItemIndex As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel21 As DarkUI.Controls.DarkLabel
    Friend WithEvents optChangeItemSet As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optChangeItemRemove As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optChangeItemAdd As DarkUI.Controls.DarkRadioButton
    Friend WithEvents nudChangeItemsAmount As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents btnChangeItemsOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnChangeItemsCancel As DarkUI.Controls.DarkButton
    Friend WithEvents cmbSwitch As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel22 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel23 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbPlayerSwitchSet As DarkUI.Controls.DarkComboBox
    Friend WithEvents btnSetPlayerSwitchOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnSetPlayerswitchCancel As DarkUI.Controls.DarkButton
    Friend WithEvents fraAddText As DarkUI.Controls.DarkGroupBox
    Friend WithEvents txtAddText_Text As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel24 As DarkUI.Controls.DarkLabel
    Friend WithEvents optAddText_Player As DarkUI.Controls.DarkRadioButton
    Friend WithEvents DarkLabel25 As DarkUI.Controls.DarkLabel
    Friend WithEvents optAddText_Map As DarkUI.Controls.DarkRadioButton
    Friend WithEvents btnAddTextOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnAddTextCancel As DarkUI.Controls.DarkButton
    Friend WithEvents optAddText_Global As DarkUI.Controls.DarkRadioButton
    Friend WithEvents btnShowTextOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnShowTextCancel As DarkUI.Controls.DarkButton
    Friend WithEvents txtShowText As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel27 As DarkUI.Controls.DarkLabel
    Friend WithEvents fraShowText As DarkUI.Controls.DarkGroupBox
    Friend WithEvents fraSetFog As DarkUI.Controls.DarkGroupBox
    Friend WithEvents btnSetFogOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnSetFogCancel As DarkUI.Controls.DarkButton
    Friend WithEvents DarkLabel30 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel29 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel28 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudFogData2 As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudFogData1 As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudFogData0 As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents fraPlayerWarp As DarkUI.Controls.DarkGroupBox
    Friend WithEvents btnPlayerWarpOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnPlayerWarpCancel As DarkUI.Controls.DarkButton
    Friend WithEvents DarkLabel31 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbWarpPlayerDir As DarkUI.Controls.DarkComboBox
    Friend WithEvents nudWPY As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel32 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudWPX As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel33 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudWPMap As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel34 As DarkUI.Controls.DarkLabel
    Friend WithEvents fraPlayBGM As DarkUI.Controls.DarkGroupBox
    Friend WithEvents cmbPlayBGM As DarkUI.Controls.DarkComboBox
    Friend WithEvents btnPlayBgmOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnPlayBgmCancel As DarkUI.Controls.DarkButton
    Friend WithEvents fraChangeSkills As DarkUI.Controls.DarkGroupBox
    Friend WithEvents cmbChangeSkills As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel37 As DarkUI.Controls.DarkLabel
    Friend WithEvents optChangeSkillsAdd As DarkUI.Controls.DarkRadioButton
    Friend WithEvents btnChangeSkillsOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnChangeSkillsCancel As DarkUI.Controls.DarkButton
    Friend WithEvents optChangeSkillsRemove As DarkUI.Controls.DarkRadioButton
    Friend WithEvents fraChangeJob As DarkUI.Controls.DarkGroupBox
    Friend WithEvents cmbChangeJob As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel38 As DarkUI.Controls.DarkLabel
    Friend WithEvents btnChangeJobOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnChangeJobCancel As DarkUI.Controls.DarkButton
    Friend WithEvents fraCreateLabel As DarkUI.Controls.DarkGroupBox
    Friend WithEvents lblLabelName As DarkUI.Controls.DarkLabel
    Friend WithEvents txtLabelName As DarkUI.Controls.DarkTextBox
    Friend WithEvents btnCreatelabelOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnCreatelabelCancel As DarkUI.Controls.DarkButton
    Friend WithEvents fraChangePK As DarkUI.Controls.DarkGroupBox
    Friend WithEvents btnChangePkOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnChangePkCancel As DarkUI.Controls.DarkButton
    Friend WithEvents cmbSetPK As DarkUI.Controls.DarkComboBox
    Friend WithEvents fraPlaySound As DarkUI.Controls.DarkGroupBox
    Friend WithEvents btnPlaySoundOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnPlaySoundCancel As DarkUI.Controls.DarkButton
    Friend WithEvents cmbPlaySound As DarkUI.Controls.DarkComboBox
    Friend WithEvents fraShowChatBubble As DarkUI.Controls.DarkGroupBox
    Friend WithEvents DarkLabel39 As DarkUI.Controls.DarkLabel
    Friend WithEvents txtChatbubbleText As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel40 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbChatBubbleTarget As DarkUI.Controls.DarkComboBox
    Friend WithEvents cmbChatBubbleTargetType As DarkUI.Controls.DarkComboBox
    Friend WithEvents btnShowChatBubbleOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnShowChatBubbleCancel As DarkUI.Controls.DarkButton
    Friend WithEvents DarkLabel41 As DarkUI.Controls.DarkLabel
    Friend WithEvents fraMapTint As DarkUI.Controls.DarkGroupBox
    Friend WithEvents btnMapTintOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnMapTintCancel As DarkUI.Controls.DarkButton
    Friend WithEvents DarkLabel42 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudMapTintData3 As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudMapTintData2 As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel43 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel44 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudMapTintData1 As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudMapTintData0 As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel45 As DarkUI.Controls.DarkLabel
    Friend WithEvents fraSetSelfSwitch As DarkUI.Controls.DarkGroupBox
    Friend WithEvents cmbSetSelfSwitch As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel46 As DarkUI.Controls.DarkLabel
    Friend WithEvents btnSelfswitchOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnSelfswitchCancel As DarkUI.Controls.DarkButton
    Friend WithEvents DarkLabel47 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbSetSelfSwitchTo As DarkUI.Controls.DarkComboBox
    Friend WithEvents fraChangeSprite As DarkUI.Controls.DarkGroupBox
    Friend WithEvents picChangeSprite As PictureBox
    Friend WithEvents btnChangeSpriteOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnChangeSpriteCancel As DarkUI.Controls.DarkButton
    Friend WithEvents DarkLabel48 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudChangeSprite As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents fraPlayerVariable As DarkUI.Controls.DarkGroupBox
    Friend WithEvents cmbVariable As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel49 As DarkUI.Controls.DarkLabel
    Friend WithEvents optVariableAction0 As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optVariableAction1 As DarkUI.Controls.DarkRadioButton
    Friend WithEvents nudVariableData1 As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudVariableData0 As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents optVariableAction3 As DarkUI.Controls.DarkRadioButton
    Friend WithEvents nudVariableData3 As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents optVariableAction2 As DarkUI.Controls.DarkRadioButton
    Friend WithEvents btnPlayerVarOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnPlayerVarCancel As DarkUI.Controls.DarkButton
    Friend WithEvents DarkLabel51 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel50 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudVariableData4 As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudVariableData2 As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents fraShowChoices As DarkUI.Controls.DarkGroupBox
    Friend WithEvents DarkLabel52 As DarkUI.Controls.DarkLabel
    Friend WithEvents txtChoicePrompt As DarkUI.Controls.DarkTextBox
    Friend WithEvents btnShowChoicesOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnShowChoicesCancel As DarkUI.Controls.DarkButton
    Friend WithEvents DarkLabel56 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel57 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel55 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel54 As DarkUI.Controls.DarkLabel
    Friend WithEvents txtChoices4 As DarkUI.Controls.DarkTextBox
    Friend WithEvents txtChoices3 As DarkUI.Controls.DarkTextBox
    Friend WithEvents txtChoices2 As DarkUI.Controls.DarkTextBox
    Friend WithEvents txtChoices1 As DarkUI.Controls.DarkTextBox
    Friend WithEvents fraGoToLabel As DarkUI.Controls.DarkGroupBox
    Friend WithEvents txtGotoLabel As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkLabel60 As DarkUI.Controls.DarkLabel
    Friend WithEvents btnGoToLabelOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnGoToLabelCancel As DarkUI.Controls.DarkButton
    Friend WithEvents fraPlayAnimation As DarkUI.Controls.DarkGroupBox
    Friend WithEvents DarkLabel61 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbPlayAnim As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel62 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbAnimTargetType As DarkUI.Controls.DarkComboBox
    Friend WithEvents nudPlayAnimTileY As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudPlayAnimTileX As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents cmbPlayAnimEvent As DarkUI.Controls.DarkComboBox
    Friend WithEvents btnPlayAnimationOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnPlayAnimationCancel As DarkUI.Controls.DarkButton
    Friend WithEvents lblPlayAnimY As DarkUI.Controls.DarkLabel
    Friend WithEvents lblPlayAnimX As DarkUI.Controls.DarkLabel
    Friend WithEvents fraChangeGender As DarkUI.Controls.DarkGroupBox
    Friend WithEvents btnChangeGenderOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnChangeGenderCancel As DarkUI.Controls.DarkButton
    Friend WithEvents optChangeSexFemale As DarkUI.Controls.DarkRadioButton
    Friend WithEvents optChangeSexMale As DarkUI.Controls.DarkRadioButton
    Friend WithEvents fraChangeLevel As DarkUI.Controls.DarkGroupBox
    Friend WithEvents btnChangeLevelOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnChangeLevelCancel As DarkUI.Controls.DarkButton
    Friend WithEvents DarkLabel65 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudChangeLevel As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents fraOpenShop As DarkUI.Controls.DarkGroupBox
    Friend WithEvents cmbOpenShop As DarkUI.Controls.DarkComboBox
    Friend WithEvents btnOpenShopOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnOpenShopCancel As DarkUI.Controls.DarkButton
    Friend WithEvents fraShowPic As DarkUI.Controls.DarkGroupBox
    Friend WithEvents DarkLabel67 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel68 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudPicOffsetY As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents nudPicOffsetX As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel69 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbPicLoc As DarkUI.Controls.DarkComboBox
    Friend WithEvents nudShowPicture As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents picShowPic As PictureBox
    Friend WithEvents btnShowPicOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnShowPicCancel As DarkUI.Controls.DarkButton
    Friend WithEvents DarkLabel71 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel70 As DarkUI.Controls.DarkLabel
    Friend WithEvents fraSetWait As DarkUI.Controls.DarkGroupBox
    Friend WithEvents btnSetWaitOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnSetWaitCancel As DarkUI.Controls.DarkButton
    Friend WithEvents DarkLabel74 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel72 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkLabel73 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudWaitAmount As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents fraSetAccess As DarkUI.Controls.DarkGroupBox
    Friend WithEvents btnSetAccessOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnSetAccessCancel As DarkUI.Controls.DarkButton
    Friend WithEvents cmbSetAccess As DarkUI.Controls.DarkComboBox
    Friend WithEvents fraSetWeather As DarkUI.Controls.DarkGroupBox
    Friend WithEvents DarkLabel75 As DarkUI.Controls.DarkLabel
    Friend WithEvents CmbWeather As DarkUI.Controls.DarkComboBox
    Friend WithEvents btnSetWeatherOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnSetWeatherCancel As DarkUI.Controls.DarkButton
    Friend WithEvents DarkLabel76 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudWeatherIntensity As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents fraGiveExp As DarkUI.Controls.DarkGroupBox
    Friend WithEvents DarkLabel77 As DarkUI.Controls.DarkLabel
    Friend WithEvents fraSpawnNpc As DarkUI.Controls.DarkGroupBox
    Friend WithEvents cmbSpawnNpc As DarkUI.Controls.DarkComboBox
    Friend WithEvents btnGiveExpOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnGiveExpCancel As DarkUI.Controls.DarkButton
    Friend WithEvents nudGiveExp As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents btnSpawnNpcOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnSpawnNpcCancel As DarkUI.Controls.DarkButton
    Friend WithEvents fraCustomScript As DarkUI.Controls.DarkGroupBox
    Friend WithEvents nudCustomScript As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel78 As DarkUI.Controls.DarkLabel
    Friend WithEvents btnCustomScriptCancel As DarkUI.Controls.DarkButton
    Friend WithEvents btnCustomScriptOk As DarkUI.Controls.DarkButton
    Friend WithEvents fraMoveRouteWait As DarkUI.Controls.DarkGroupBox
    Friend WithEvents btnMoveWaitCancel As DarkUI.Controls.DarkButton
    Friend WithEvents btnMoveWaitOk As DarkUI.Controls.DarkButton
    Friend WithEvents DarkLabel79 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbMoveWait As DarkUI.Controls.DarkComboBox
    Friend WithEvents pnlVariableSwitches As Panel
    Friend WithEvents fraLabeling As DarkUI.Controls.DarkGroupBox
    Friend WithEvents lstSwitches As ListBox
    Friend WithEvents lstVariables As ListBox
    Friend WithEvents FraRenaming As GroupBox
    Friend WithEvents btnRename_Cancel As Button
    Friend WithEvents btnRename_Ok As Button
    Friend WithEvents fraRandom10 As GroupBox
    Friend WithEvents txtRename As TextBox
    Friend WithEvents lblEditing As Label
    Friend WithEvents pnlGraphicSel As Panel
    Friend WithEvents cmbCondition_Time As DarkUI.Controls.DarkComboBox
    Friend WithEvents optCondition9 As DarkUI.Controls.DarkRadioButton
    Friend WithEvents DarkGroupBox6 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents chkShowName As DarkUI.Controls.DarkCheckBox
    Friend WithEvents chkWalkThrough As DarkUI.Controls.DarkCheckBox
    Friend WithEvents chkDirFix As DarkUI.Controls.DarkCheckBox
    Friend WithEvents chkWalkAnim As DarkUI.Controls.DarkCheckBox
    Friend WithEvents fraGraphicPic As DarkUI.Controls.DarkGroupBox
    Friend WithEvents picGraphic As PictureBox
    Friend WithEvents fraGraphic As DarkUI.Controls.DarkGroupBox
    Friend WithEvents btnGraphicOk As DarkUI.Controls.DarkButton
    Friend WithEvents btnGraphicCancel As DarkUI.Controls.DarkButton
    Friend WithEvents DarkLabel13 As DarkUI.Controls.DarkLabel
    Friend WithEvents nudGraphic As DarkUI.Controls.DarkNumericUpDown
    Friend WithEvents DarkLabel12 As DarkUI.Controls.DarkLabel
    Friend WithEvents cmbGraphic As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel11 As DarkUI.Controls.DarkLabel
    Friend WithEvents DarkGroupBox2 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents cmbPositioning As DarkUI.Controls.DarkComboBox
    Friend WithEvents lblRandomLabel36 As DarkUI.Controls.DarkLabel
    Friend WithEvents lblRandomLabel25 As DarkUI.Controls.DarkLabel
    Friend WithEvents btnLabel_Cancel As DarkUI.Controls.DarkButton
    Friend WithEvents btnRenameVariable As DarkUI.Controls.DarkButton
    Friend WithEvents btnRenameSwitch As DarkUI.Controls.DarkButton
    Friend WithEvents btnLabel_Ok As DarkUI.Controls.DarkButton
End Class
