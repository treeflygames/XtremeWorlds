<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAdmin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAdmin))
        btnRespawn = New Button()
        btnMapReport = New Button()
        btnALoc = New Button()
        btnAdminSetSprite = New Button()
        btnAdminWarpTo = New Button()
        Label5 = New Label()
        Label4 = New Label()
        btnAdminSetAccess = New Button()
        btnAdminWarpMe2 = New Button()
        btnAdminWarp2Me = New Button()
        btnAdminBan = New Button()
        btnAdminKick = New Button()
        txtAdminName = New TextBox()
        Label3 = New Label()
        Label2 = New Label()
        lstMaps = New ListView()
        ColumnHeader1 = New ColumnHeader()
        ColumnHeader2 = New ColumnHeader()
        TabControl1 = New TabControl()
        tabModeration = New TabPage()
        nudAdminSprite = New NumericUpDown()
        nudAdminMap = New NumericUpDown()
        btnLevelUp = New Button()
        cmbAccess = New ComboBox()
        tabMapList = New TabPage()
        tabMapTools = New TabPage()
        tabEditors = New TabPage()
        btnPetEditor = New Button()
        btnJobEditor = New Button()
        btnProjectiles = New Button()
        btnMapEditor = New Button()
        btnItemEditor = New Button()
        btnResourceEditor = New Button()
        btnNPCEditor = New Button()
        btnSkillEditor = New Button()
        btnShopEditor = New Button()
        btnAnimationEditor = New Button()
        btnMoralEditor = New Button()
        TabControl1.SuspendLayout()
        tabModeration.SuspendLayout()
        CType(nudAdminSprite, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudAdminMap, ComponentModel.ISupportInitialize).BeginInit()
        tabMapList.SuspendLayout()
        tabMapTools.SuspendLayout()
        tabEditors.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnRespawn
        ' 
        btnRespawn.Location = New Point(227, 30)
        btnRespawn.Margin = New Padding(5, 5, 5, 5)
        btnRespawn.Name = "btnRespawn"
        btnRespawn.Size = New Size(177, 41)
        btnRespawn.TabIndex = 34
        btnRespawn.Text = "Respawn Map"
        btnRespawn.UseVisualStyleBackColor = True
        ' 
        ' btnMapReport
        ' 
        btnMapReport.Location = New Point(10, 402)
        btnMapReport.Margin = New Padding(5, 5, 5, 5)
        btnMapReport.Name = "btnMapReport"
        btnMapReport.Size = New Size(397, 41)
        btnMapReport.TabIndex = 33
        btnMapReport.Text = "Refresh List"
        btnMapReport.UseVisualStyleBackColor = True
        ' 
        ' btnALoc
        ' 
        btnALoc.Location = New Point(23, 30)
        btnALoc.Margin = New Padding(5, 5, 5, 5)
        btnALoc.Name = "btnALoc"
        btnALoc.Size = New Size(177, 41)
        btnALoc.TabIndex = 31
        btnALoc.Text = "Location"
        btnALoc.UseVisualStyleBackColor = True
        ' 
        ' btnAdminSetSprite
        ' 
        btnAdminSetSprite.Location = New Point(223, 391)
        btnAdminSetSprite.Margin = New Padding(5, 5, 5, 5)
        btnAdminSetSprite.Name = "btnAdminSetSprite"
        btnAdminSetSprite.Size = New Size(180, 47)
        btnAdminSetSprite.TabIndex = 16
        btnAdminSetSprite.Text = "Set Player Sprite"
        btnAdminSetSprite.UseVisualStyleBackColor = True
        ' 
        ' btnAdminWarpTo
        ' 
        btnAdminWarpTo.Location = New Point(223, 338)
        btnAdminWarpTo.Margin = New Padding(5, 5, 5, 5)
        btnAdminWarpTo.Name = "btnAdminWarpTo"
        btnAdminWarpTo.Size = New Size(180, 47)
        btnAdminWarpTo.TabIndex = 15
        btnAdminWarpTo.Text = "Warp To Map"
        btnAdminWarpTo.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(10, 403)
        Label5.Margin = New Padding(5, 0, 5, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(62, 25)
        Label5.TabIndex = 13
        Label5.Text = "Sprite:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(10, 350)
        Label4.Margin = New Padding(5, 0, 5, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(122, 25)
        Label4.TabIndex = 11
        Label4.Text = "Map Number:"
        ' 
        ' btnAdminSetAccess
        ' 
        btnAdminSetAccess.Location = New Point(15, 285)
        btnAdminSetAccess.Margin = New Padding(5, 5, 5, 5)
        btnAdminSetAccess.Name = "btnAdminSetAccess"
        btnAdminSetAccess.Size = New Size(388, 41)
        btnAdminSetAccess.TabIndex = 9
        btnAdminSetAccess.Text = "Set Access"
        btnAdminSetAccess.UseVisualStyleBackColor = True
        ' 
        ' btnAdminWarpMe2
        ' 
        btnAdminWarpMe2.Location = New Point(212, 120)
        btnAdminWarpMe2.Margin = New Padding(5, 5, 5, 5)
        btnAdminWarpMe2.Name = "btnAdminWarpMe2"
        btnAdminWarpMe2.Size = New Size(192, 41)
        btnAdminWarpMe2.TabIndex = 8
        btnAdminWarpMe2.Text = "Warp Me To Player"
        btnAdminWarpMe2.UseVisualStyleBackColor = True
        ' 
        ' btnAdminWarp2Me
        ' 
        btnAdminWarp2Me.Location = New Point(10, 120)
        btnAdminWarp2Me.Margin = New Padding(5, 5, 5, 5)
        btnAdminWarp2Me.Name = "btnAdminWarp2Me"
        btnAdminWarp2Me.Size = New Size(192, 41)
        btnAdminWarp2Me.TabIndex = 7
        btnAdminWarp2Me.Text = "Warp Player To Me"
        btnAdminWarp2Me.UseVisualStyleBackColor = True
        ' 
        ' btnAdminBan
        ' 
        btnAdminBan.Location = New Point(212, 65)
        btnAdminBan.Margin = New Padding(5, 5, 5, 5)
        btnAdminBan.Name = "btnAdminBan"
        btnAdminBan.Size = New Size(192, 41)
        btnAdminBan.TabIndex = 6
        btnAdminBan.Text = "Ban Player"
        btnAdminBan.UseVisualStyleBackColor = True
        ' 
        ' btnAdminKick
        ' 
        btnAdminKick.Location = New Point(10, 65)
        btnAdminKick.Margin = New Padding(5, 5, 5, 5)
        btnAdminKick.Name = "btnAdminKick"
        btnAdminKick.Size = New Size(192, 41)
        btnAdminKick.TabIndex = 5
        btnAdminKick.Text = "Kick Player"
        btnAdminKick.UseVisualStyleBackColor = True
        ' 
        ' txtAdminName
        ' 
        txtAdminName.Location = New Point(137, 15)
        txtAdminName.Margin = New Padding(5, 5, 5, 5)
        txtAdminName.Name = "txtAdminName"
        txtAdminName.Size = New Size(264, 31)
        txtAdminName.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(10, 238)
        Label3.Margin = New Padding(5, 0, 5, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(69, 25)
        Label3.TabIndex = 2
        Label3.Text = "Access:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(10, 22)
        Label2.Margin = New Padding(5, 0, 5, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(115, 25)
        Label2.TabIndex = 1
        Label2.Text = "Player Name:"
        ' 
        ' lstMaps
        ' 
        lstMaps.Columns.AddRange(New ColumnHeader() {ColumnHeader1, ColumnHeader2})
        lstMaps.FullRowSelect = True
        lstMaps.GridLines = True
        lstMaps.HeaderStyle = ColumnHeaderStyle.Nonclickable
        lstMaps.Location = New Point(10, 12)
        lstMaps.Margin = New Padding(5, 5, 5, 5)
        lstMaps.MultiSelect = False
        lstMaps.Name = "lstMaps"
        lstMaps.Size = New Size(396, 376)
        lstMaps.TabIndex = 4
        lstMaps.UseCompatibleStateImageBehavior = False
        lstMaps.View = View.Details
        ' 
        ' ColumnHeader1
        ' 
        ColumnHeader1.Text = "#"
        ColumnHeader1.Width = 30
        ' 
        ' ColumnHeader2
        ' 
        ColumnHeader2.Text = "Name"
        ColumnHeader2.Width = 200
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(tabModeration)
        TabControl1.Controls.Add(tabMapList)
        TabControl1.Controls.Add(tabMapTools)
        TabControl1.Controls.Add(tabEditors)
        TabControl1.Location = New Point(3, 3)
        TabControl1.Margin = New Padding(5, 5, 5, 5)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(430, 498)
        TabControl1.TabIndex = 38
        ' 
        ' tabModeration
        ' 
        tabModeration.Controls.Add(nudAdminSprite)
        tabModeration.Controls.Add(nudAdminMap)
        tabModeration.Controls.Add(btnLevelUp)
        tabModeration.Controls.Add(cmbAccess)
        tabModeration.Controls.Add(Label2)
        tabModeration.Controls.Add(Label3)
        tabModeration.Controls.Add(txtAdminName)
        tabModeration.Controls.Add(btnAdminKick)
        tabModeration.Controls.Add(btnAdminBan)
        tabModeration.Controls.Add(btnAdminWarp2Me)
        tabModeration.Controls.Add(btnAdminWarpMe2)
        tabModeration.Controls.Add(btnAdminSetAccess)
        tabModeration.Controls.Add(Label4)
        tabModeration.Controls.Add(Label5)
        tabModeration.Controls.Add(btnAdminWarpTo)
        tabModeration.Controls.Add(btnAdminSetSprite)
        tabModeration.Location = New Point(4, 34)
        tabModeration.Margin = New Padding(5, 5, 5, 5)
        tabModeration.Name = "tabModeration"
        tabModeration.Padding = New Padding(5, 5, 5, 5)
        tabModeration.Size = New Size(422, 460)
        tabModeration.TabIndex = 0
        tabModeration.Text = "Moderation"
        tabModeration.UseVisualStyleBackColor = True
        ' 
        ' nudAdminSprite
        ' 
        nudAdminSprite.Location = New Point(133, 400)
        nudAdminSprite.Margin = New Padding(5, 5, 5, 5)
        nudAdminSprite.Name = "nudAdminSprite"
        nudAdminSprite.Size = New Size(80, 31)
        nudAdminSprite.TabIndex = 33
        ' 
        ' nudAdminMap
        ' 
        nudAdminMap.Location = New Point(133, 341)
        nudAdminMap.Margin = New Padding(5, 5, 5, 5)
        nudAdminMap.Name = "nudAdminMap"
        nudAdminMap.Size = New Size(80, 31)
        nudAdminMap.TabIndex = 32
        ' 
        ' btnLevelUp
        ' 
        btnLevelUp.Location = New Point(53, 173)
        btnLevelUp.Margin = New Padding(5, 5, 5, 5)
        btnLevelUp.Name = "btnLevelUp"
        btnLevelUp.Size = New Size(313, 41)
        btnLevelUp.TabIndex = 31
        btnLevelUp.Text = "Level Up"
        btnLevelUp.UseVisualStyleBackColor = True
        ' 
        ' cmbAccess
        ' 
        cmbAccess.FormattingEnabled = True
        cmbAccess.Items.AddRange(New Object() {"Normal Player", "Moderator (GM)", "Mapper", "Developer", "Creator"})
        cmbAccess.Location = New Point(95, 234)
        cmbAccess.Margin = New Padding(5, 5, 5, 5)
        cmbAccess.Name = "cmbAccess"
        cmbAccess.Size = New Size(306, 33)
        cmbAccess.TabIndex = 17
        ' 
        ' tabMapList
        ' 
        tabMapList.Controls.Add(lstMaps)
        tabMapList.Controls.Add(btnMapReport)
        tabMapList.Location = New Point(4, 34)
        tabMapList.Margin = New Padding(5, 5, 5, 5)
        tabMapList.Name = "tabMapList"
        tabMapList.Padding = New Padding(5, 5, 5, 5)
        tabMapList.Size = New Size(422, 460)
        tabMapList.TabIndex = 2
        tabMapList.Text = "Map List"
        tabMapList.UseVisualStyleBackColor = True
        ' 
        ' tabMapTools
        ' 
        tabMapTools.Controls.Add(btnRespawn)
        tabMapTools.Controls.Add(btnALoc)
        tabMapTools.Location = New Point(4, 34)
        tabMapTools.Margin = New Padding(5, 5, 5, 5)
        tabMapTools.Name = "tabMapTools"
        tabMapTools.Padding = New Padding(5, 5, 5, 5)
        tabMapTools.Size = New Size(422, 460)
        tabMapTools.TabIndex = 3
        tabMapTools.Text = "Map Tools"
        tabMapTools.UseVisualStyleBackColor = True
        ' 
        ' tabEditors
        ' 
        tabEditors.Controls.Add(btnMoralEditor)
        tabEditors.Controls.Add(btnPetEditor)
        tabEditors.Controls.Add(btnJobEditor)
        tabEditors.Controls.Add(btnProjectiles)
        tabEditors.Controls.Add(btnMapEditor)
        tabEditors.Controls.Add(btnItemEditor)
        tabEditors.Controls.Add(btnResourceEditor)
        tabEditors.Controls.Add(btnNPCEditor)
        tabEditors.Controls.Add(btnSkillEditor)
        tabEditors.Controls.Add(btnShopEditor)
        tabEditors.Controls.Add(btnAnimationEditor)
        tabEditors.Location = New Point(4, 34)
        tabEditors.Margin = New Padding(5, 5, 5, 5)
        tabEditors.Name = "tabEditors"
        tabEditors.Padding = New Padding(5, 5, 5, 5)
        tabEditors.Size = New Size(422, 460)
        tabEditors.TabIndex = 4
        tabEditors.Text = "Editors"
        tabEditors.UseVisualStyleBackColor = True
        ' 
        ' btnPetEditor
        ' 
        btnPetEditor.Location = New Point(217, 10)
        btnPetEditor.Margin = New Padding(5, 5, 5, 5)
        btnPetEditor.Name = "btnPetEditor"
        btnPetEditor.Size = New Size(187, 48)
        btnPetEditor.TabIndex = 68
        btnPetEditor.Text = "Pet Editor"
        btnPetEditor.UseVisualStyleBackColor = True
        ' 
        ' btnJobEditor
        ' 
        btnJobEditor.Location = New Point(10, 68)
        btnJobEditor.Margin = New Padding(5, 5, 5, 5)
        btnJobEditor.Name = "btnJobEditor"
        btnJobEditor.Size = New Size(187, 48)
        btnJobEditor.TabIndex = 66
        btnJobEditor.Text = "Job Editor"
        btnJobEditor.UseVisualStyleBackColor = True
        ' 
        ' btnProjectiles
        ' 
        btnProjectiles.Location = New Point(217, 68)
        btnProjectiles.Margin = New Padding(5, 5, 5, 5)
        btnProjectiles.Name = "btnProjectiles"
        btnProjectiles.Size = New Size(187, 48)
        btnProjectiles.TabIndex = 64
        btnProjectiles.Text = "Projectile Editor"
        btnProjectiles.UseVisualStyleBackColor = True
        ' 
        ' btnMapEditor
        ' 
        btnMapEditor.Location = New Point(12, 302)
        btnMapEditor.Margin = New Padding(5, 5, 5, 5)
        btnMapEditor.Name = "btnMapEditor"
        btnMapEditor.Size = New Size(187, 48)
        btnMapEditor.TabIndex = 55
        btnMapEditor.Text = "Map Editor"
        btnMapEditor.UseVisualStyleBackColor = True
        ' 
        ' btnItemEditor
        ' 
        btnItemEditor.Location = New Point(12, 185)
        btnItemEditor.Margin = New Padding(5, 5, 5, 5)
        btnItemEditor.Name = "btnItemEditor"
        btnItemEditor.Size = New Size(187, 48)
        btnItemEditor.TabIndex = 56
        btnItemEditor.Text = "Item Editor"
        btnItemEditor.UseVisualStyleBackColor = True
        ' 
        ' btnResourceEditor
        ' 
        btnResourceEditor.Location = New Point(217, 127)
        btnResourceEditor.Margin = New Padding(5, 5, 5, 5)
        btnResourceEditor.Name = "btnResourceEditor"
        btnResourceEditor.Size = New Size(187, 48)
        btnResourceEditor.TabIndex = 57
        btnResourceEditor.Text = "Resource Editor"
        btnResourceEditor.UseVisualStyleBackColor = True
        ' 
        ' btnNPCEditor
        ' 
        btnNPCEditor.Location = New Point(12, 127)
        btnNPCEditor.Margin = New Padding(5, 5, 5, 5)
        btnNPCEditor.Name = "btnNPCEditor"
        btnNPCEditor.Size = New Size(187, 48)
        btnNPCEditor.TabIndex = 58
        btnNPCEditor.Text = "NPC Editor"
        btnNPCEditor.UseVisualStyleBackColor = True
        ' 
        ' btnSkillEditor
        ' 
        btnSkillEditor.Location = New Point(12, 243)
        btnSkillEditor.Margin = New Padding(5, 5, 5, 5)
        btnSkillEditor.Name = "btnSkillEditor"
        btnSkillEditor.Size = New Size(187, 48)
        btnSkillEditor.TabIndex = 59
        btnSkillEditor.Text = "Skill Editor"
        btnSkillEditor.UseVisualStyleBackColor = True
        ' 
        ' btnShopEditor
        ' 
        btnShopEditor.Location = New Point(12, 360)
        btnShopEditor.Margin = New Padding(5, 5, 5, 5)
        btnShopEditor.Name = "btnShopEditor"
        btnShopEditor.Size = New Size(187, 48)
        btnShopEditor.TabIndex = 60
        btnShopEditor.Text = "Shop Editor"
        btnShopEditor.UseVisualStyleBackColor = True
        ' 
        ' btnAnimationEditor
        ' 
        btnAnimationEditor.Location = New Point(12, 10)
        btnAnimationEditor.Margin = New Padding(5, 5, 5, 5)
        btnAnimationEditor.Name = "btnAnimationEditor"
        btnAnimationEditor.Size = New Size(187, 48)
        btnAnimationEditor.TabIndex = 61
        btnAnimationEditor.Text = "Animation Editor"
        btnAnimationEditor.UseVisualStyleBackColor = True
        ' 
        ' btnMoralEditor
        ' 
        btnMoralEditor.Location = New Point(217, 185)
        btnMoralEditor.Margin = New Padding(5)
        btnMoralEditor.Name = "btnMoralEditor"
        btnMoralEditor.Size = New Size(187, 48)
        btnMoralEditor.TabIndex = 69
        btnMoralEditor.Text = "Moral Editor"
        btnMoralEditor.UseVisualStyleBackColor = True
        ' 
        ' FrmAdmin
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(435, 498)
        Controls.Add(TabControl1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(5, 5, 5, 5)
        MaximizeBox = False
        MinimizeBox = False
        Name = "FrmAdmin"
        ShowIcon = False
        StartPosition = FormStartPosition.CenterParent
        Text = "Admin Panel"
        TabControl1.ResumeLayout(False)
        tabModeration.ResumeLayout(False)
        tabModeration.PerformLayout()
        CType(nudAdminSprite, ComponentModel.ISupportInitialize).EndInit()
        CType(nudAdminMap, ComponentModel.ISupportInitialize).EndInit()
        tabMapList.ResumeLayout(False)
        tabMapTools.ResumeLayout(False)
        tabEditors.ResumeLayout(False)
        ResumeLayout(False)

    End Sub
    Friend WithEvents btnRespawn As System.Windows.Forms.Button
    Friend WithEvents btnMapReport As System.Windows.Forms.Button
    Friend WithEvents btnALoc As System.Windows.Forms.Button
    Friend WithEvents btnAdminSetSprite As System.Windows.Forms.Button
    Friend WithEvents btnAdminWarpTo As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAdminSetAccess As System.Windows.Forms.Button
    Friend WithEvents btnAdminWarpMe2 As System.Windows.Forms.Button
    Friend WithEvents btnAdminWarp2Me As System.Windows.Forms.Button
    Friend WithEvents btnAdminBan As System.Windows.Forms.Button
    Friend WithEvents btnAdminKick As System.Windows.Forms.Button
    Friend WithEvents txtAdminName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lstMaps As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabModeration As System.Windows.Forms.TabPage
    Friend WithEvents tabMapList As System.Windows.Forms.TabPage
    Friend WithEvents tabMapTools As System.Windows.Forms.TabPage
    Friend WithEvents cmbAccess As System.Windows.Forms.ComboBox
    Friend WithEvents nudAdminSprite As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudAdminMap As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnLevelUp As System.Windows.Forms.Button
    Friend WithEvents tabEditors As System.Windows.Forms.TabPage
    Friend WithEvents btnPetEditor As System.Windows.Forms.Button
    Friend WithEvents btnJobEditor As System.Windows.Forms.Button
    Friend WithEvents btnProjectiles As System.Windows.Forms.Button
    Friend WithEvents btnMapEditor As System.Windows.Forms.Button
    Friend WithEvents btnItemEditor As System.Windows.Forms.Button
    Friend WithEvents btnResourceEditor As System.Windows.Forms.Button
    Friend WithEvents btnNPCEditor As System.Windows.Forms.Button
    Friend WithEvents btnSkillEditor As System.Windows.Forms.Button
    Friend WithEvents btnShopEditor As System.Windows.Forms.Button
    Friend WithEvents btnAnimationEditor As System.Windows.Forms.Button
    Friend WithEvents btnMoralEditor As Button
End Class
