<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor_Moral
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
        DarkGroupBox1 = New DarkUI.Controls.DarkGroupBox()
        btnDelete = New DarkUI.Controls.DarkButton()
        btnSave = New DarkUI.Controls.DarkButton()
        btnCancel = New DarkUI.Controls.DarkButton()
        lstIndex = New ListBox()
        DarkLabel6 = New DarkUI.Controls.DarkLabel()
        txtName = New DarkUI.Controls.DarkTextBox()
        DarkGroupBox2 = New DarkUI.Controls.DarkGroupBox()
        chkNPCBlock = New DarkUI.Controls.DarkCheckBox()
        chkPlayerBlock = New DarkUI.Controls.DarkCheckBox()
        chkLoseExp = New DarkUI.Controls.DarkCheckBox()
        chkDropItems = New DarkUI.Controls.DarkCheckBox()
        chkCanUseItem = New DarkUI.Controls.DarkCheckBox()
        chkCanDropItem = New DarkUI.Controls.DarkCheckBox()
        chkCanPickupItem = New DarkUI.Controls.DarkCheckBox()
        chkCanPK = New DarkUI.Controls.DarkCheckBox()
        chkCanCast = New DarkUI.Controls.DarkCheckBox()
        cmbColor = New DarkUI.Controls.DarkComboBox()
        DarkLabel11 = New DarkUI.Controls.DarkLabel()
        DarkGroupBox1.SuspendLayout()
        DarkGroupBox2.SuspendLayout()
        SuspendLayout()
        ' 
        ' DarkGroupBox1
        ' 
        DarkGroupBox1.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox1.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox1.Controls.Add(btnDelete)
        DarkGroupBox1.Controls.Add(btnSave)
        DarkGroupBox1.Controls.Add(btnCancel)
        DarkGroupBox1.Controls.Add(lstIndex)
        DarkGroupBox1.ForeColor = Color.Gainsboro
        DarkGroupBox1.Location = New Point(3, 0)
        DarkGroupBox1.Margin = New Padding(5)
        DarkGroupBox1.Name = "DarkGroupBox1"
        DarkGroupBox1.Padding = New Padding(5)
        DarkGroupBox1.Size = New Size(288, 486)
        DarkGroupBox1.TabIndex = 1
        DarkGroupBox1.TabStop = False
        DarkGroupBox1.Text = "Moral List"
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(10, 376)
        btnDelete.Margin = New Padding(5)
        btnDelete.Name = "btnDelete"
        btnDelete.Padding = New Padding(8, 10, 8, 10)
        btnDelete.Size = New Size(265, 45)
        btnDelete.TabIndex = 9
        btnDelete.Text = "Delete"
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(10, 320)
        btnSave.Margin = New Padding(5)
        btnSave.Name = "btnSave"
        btnSave.Padding = New Padding(8, 10, 8, 10)
        btnSave.Size = New Size(265, 45)
        btnSave.TabIndex = 8
        btnSave.Text = "Save"
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(10, 431)
        btnCancel.Margin = New Padding(5)
        btnCancel.Name = "btnCancel"
        btnCancel.Padding = New Padding(8, 10, 8, 10)
        btnCancel.Size = New Size(265, 45)
        btnCancel.TabIndex = 7
        btnCancel.Text = "Cancel"
        ' 
        ' lstIndex
        ' 
        lstIndex.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        lstIndex.BorderStyle = BorderStyle.FixedSingle
        lstIndex.ForeColor = Color.Gainsboro
        lstIndex.FormattingEnabled = True
        lstIndex.ItemHeight = 25
        lstIndex.Location = New Point(10, 33)
        lstIndex.Margin = New Padding(5)
        lstIndex.Name = "lstIndex"
        lstIndex.Size = New Size(265, 277)
        lstIndex.TabIndex = 1
        ' 
        ' DarkLabel6
        ' 
        DarkLabel6.AutoSize = True
        DarkLabel6.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel6.Location = New Point(13, 43)
        DarkLabel6.Margin = New Padding(6, 0, 6, 0)
        DarkLabel6.Name = "DarkLabel6"
        DarkLabel6.Size = New Size(63, 25)
        DarkLabel6.TabIndex = 0
        DarkLabel6.Text = "Name:"
        ' 
        ' txtName
        ' 
        txtName.BackColor = Color.FromArgb(CByte(69), CByte(73), CByte(74))
        txtName.BorderStyle = BorderStyle.FixedSingle
        txtName.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        txtName.Location = New Point(100, 37)
        txtName.Margin = New Padding(6, 5, 6, 5)
        txtName.Name = "txtName"
        txtName.Size = New Size(229, 31)
        txtName.TabIndex = 1
        ' 
        ' DarkGroupBox2
        ' 
        DarkGroupBox2.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DarkGroupBox2.BorderColor = Color.FromArgb(CByte(90), CByte(90), CByte(90))
        DarkGroupBox2.Controls.Add(chkNPCBlock)
        DarkGroupBox2.Controls.Add(chkPlayerBlock)
        DarkGroupBox2.Controls.Add(chkLoseExp)
        DarkGroupBox2.Controls.Add(chkDropItems)
        DarkGroupBox2.Controls.Add(chkCanUseItem)
        DarkGroupBox2.Controls.Add(chkCanDropItem)
        DarkGroupBox2.Controls.Add(chkCanPickupItem)
        DarkGroupBox2.Controls.Add(chkCanPK)
        DarkGroupBox2.Controls.Add(chkCanCast)
        DarkGroupBox2.Controls.Add(cmbColor)
        DarkGroupBox2.Controls.Add(DarkLabel11)
        DarkGroupBox2.Controls.Add(txtName)
        DarkGroupBox2.Controls.Add(DarkLabel6)
        DarkGroupBox2.ForeColor = Color.Gainsboro
        DarkGroupBox2.Location = New Point(302, 0)
        DarkGroupBox2.Margin = New Padding(6, 5, 6, 5)
        DarkGroupBox2.Name = "DarkGroupBox2"
        DarkGroupBox2.Padding = New Padding(6, 5, 6, 5)
        DarkGroupBox2.Size = New Size(350, 486)
        DarkGroupBox2.TabIndex = 31
        DarkGroupBox2.TabStop = False
        DarkGroupBox2.Text = "Properties"
        ' 
        ' chkNPCBlock
        ' 
        chkNPCBlock.AutoSize = True
        chkNPCBlock.Location = New Point(201, 237)
        chkNPCBlock.Margin = New Padding(6, 5, 6, 5)
        chkNPCBlock.Name = "chkNPCBlock"
        chkNPCBlock.Size = New Size(119, 29)
        chkNPCBlock.TabIndex = 20
        chkNPCBlock.Text = "NPC Block"
        ' 
        ' chkPlayerBlock
        ' 
        chkPlayerBlock.AutoSize = True
        chkPlayerBlock.Location = New Point(201, 198)
        chkPlayerBlock.Margin = New Padding(6, 5, 6, 5)
        chkPlayerBlock.Name = "chkPlayerBlock"
        chkPlayerBlock.Size = New Size(132, 29)
        chkPlayerBlock.TabIndex = 19
        chkPlayerBlock.Text = "Player Block"
        ' 
        ' chkLoseExp
        ' 
        chkLoseExp.AutoSize = True
        chkLoseExp.Location = New Point(201, 159)
        chkLoseExp.Margin = New Padding(6, 5, 6, 5)
        chkLoseExp.Name = "chkLoseExp"
        chkLoseExp.Size = New Size(107, 29)
        chkLoseExp.TabIndex = 18
        chkLoseExp.Text = "Lose Exp"
        ' 
        ' chkDropItems
        ' 
        chkDropItems.AutoSize = True
        chkDropItems.Location = New Point(201, 120)
        chkDropItems.Margin = New Padding(6, 5, 6, 5)
        chkDropItems.Name = "chkDropItems"
        chkDropItems.Size = New Size(128, 29)
        chkDropItems.TabIndex = 17
        chkDropItems.Text = "Drop Items"
        ' 
        ' chkCanUseItem
        ' 
        chkCanUseItem.AutoSize = True
        chkCanUseItem.Location = New Point(13, 276)
        chkCanUseItem.Margin = New Padding(6, 5, 6, 5)
        chkCanUseItem.Name = "chkCanUseItem"
        chkCanUseItem.Size = New Size(143, 29)
        chkCanUseItem.TabIndex = 16
        chkCanUseItem.Text = "Can Use Item"
        ' 
        ' chkCanDropItem
        ' 
        chkCanDropItem.AutoSize = True
        chkCanDropItem.Location = New Point(13, 237)
        chkCanDropItem.Margin = New Padding(6, 5, 6, 5)
        chkCanDropItem.Name = "chkCanDropItem"
        chkCanDropItem.Size = New Size(155, 29)
        chkCanDropItem.TabIndex = 15
        chkCanDropItem.Text = "Can Drop Item"
        ' 
        ' chkCanPickupItem
        ' 
        chkCanPickupItem.AutoSize = True
        chkCanPickupItem.Location = New Point(13, 198)
        chkCanPickupItem.Margin = New Padding(6, 5, 6, 5)
        chkCanPickupItem.Name = "chkCanPickupItem"
        chkCanPickupItem.Size = New Size(166, 29)
        chkCanPickupItem.TabIndex = 14
        chkCanPickupItem.Text = "Can Pickup Item"
        ' 
        ' chkCanPK
        ' 
        chkCanPK.AutoSize = True
        chkCanPK.Location = New Point(13, 159)
        chkCanPK.Margin = New Padding(6, 5, 6, 5)
        chkCanPK.Name = "chkCanPK"
        chkCanPK.Size = New Size(93, 29)
        chkCanPK.TabIndex = 13
        chkCanPK.Text = "Can PK"
        ' 
        ' chkCanCast
        ' 
        chkCanCast.AutoSize = True
        chkCanCast.Location = New Point(13, 120)
        chkCanCast.Margin = New Padding(6, 5, 6, 5)
        chkCanCast.Name = "chkCanCast"
        chkCanCast.Size = New Size(107, 29)
        chkCanCast.TabIndex = 12
        chkCanCast.Text = "Can Cast"
        ' 
        ' cmbColor
        ' 
        cmbColor.DrawMode = DrawMode.OwnerDrawFixed
        cmbColor.FormattingEnabled = True
        cmbColor.Items.AddRange(New Object() {"Black", "Blue", "Green", "Cyan", "Red", "Magenta", "Brown", "Gray", "DarkGray", "Bright Blue", "Bright Green", "Bright Cyan", "Bright Red", "Pink", "Yellow", "White"})
        cmbColor.Location = New Point(100, 78)
        cmbColor.Margin = New Padding(5)
        cmbColor.Name = "cmbColor"
        cmbColor.Size = New Size(229, 32)
        cmbColor.TabIndex = 11
        ' 
        ' DarkLabel11
        ' 
        DarkLabel11.AutoSize = True
        DarkLabel11.ForeColor = Color.FromArgb(CByte(220), CByte(220), CByte(220))
        DarkLabel11.Location = New Point(13, 81)
        DarkLabel11.Margin = New Padding(5, 0, 5, 0)
        DarkLabel11.Name = "DarkLabel11"
        DarkLabel11.Size = New Size(59, 25)
        DarkLabel11.TabIndex = 10
        DarkLabel11.Text = "Color:"
        ' 
        ' frmEditor_Moral
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        ClientSize = New Size(660, 491)
        Controls.Add(DarkGroupBox2)
        Controls.Add(DarkGroupBox1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "frmEditor_Moral"
        Text = "Moral Editor"
        DarkGroupBox1.ResumeLayout(False)
        DarkGroupBox2.ResumeLayout(False)
        DarkGroupBox2.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents DarkGroupBox1 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents lstIndex As ListBox
    Friend WithEvents DarkLabel6 As DarkUI.Controls.DarkLabel
    Friend WithEvents txtName As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkGroupBox2 As DarkUI.Controls.DarkGroupBox
    Friend WithEvents cmbColor As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkLabel11 As DarkUI.Controls.DarkLabel
    Friend WithEvents chkCanPickupItem As DarkUI.Controls.DarkCheckBox
    Friend WithEvents chkCanPK As DarkUI.Controls.DarkCheckBox
    Friend WithEvents chkCanCast As DarkUI.Controls.DarkCheckBox
    Friend WithEvents chkNPCBlock As DarkUI.Controls.DarkCheckBox
    Friend WithEvents chkPlayerBlock As DarkUI.Controls.DarkCheckBox
    Friend WithEvents chkLoseExp As DarkUI.Controls.DarkCheckBox
    Friend WithEvents chkDropItems As DarkUI.Controls.DarkCheckBox
    Friend WithEvents chkCanUseItem As DarkUI.Controls.DarkCheckBox
    Friend WithEvents chkCanDropItem As DarkUI.Controls.DarkCheckBox
    Friend WithEvents btnDelete As DarkUI.Controls.DarkButton
    Friend WithEvents btnSave As DarkUI.Controls.DarkButton
    Friend WithEvents btnCancel As DarkUI.Controls.DarkButton
End Class
