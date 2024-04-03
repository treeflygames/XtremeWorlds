
Imports Core

Friend Class frmEditor_Item

#Region "Form Code"

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ItemEditorOk()
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ItemEditorCancel()
        Dispose()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim tmpindex As Integer

        ClearItem(EditorIndex)

        tmpindex = lstIndex.SelectedIndex
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Item(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpindex

        ItemEditorInit()
    End Sub

    Private Sub lstIndex_Click(sender As Object, e As EventArgs) Handles lstIndex.Click
        ItemEditorInit()
    End Sub

    Private Sub frmEditor_Item_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nudIcon.Maximum = NumItems
        nudPaperdoll.Maximum = NumPaperdolls

        'populate combo boxes
        cmbAnimation.Items.Clear()
        For i = 1 To MAX_ANIMATIONS
            cmbAnimation.Items.Add(i & ": " & Animation(i).Name)
        Next

        cmbAmmo.Items.Clear()
        For i = 1 To MAX_ITEMS
            cmbAmmo.Items.Add(i & ": " & Item(i).Name)
        Next

        cmbProjectile.Items.Clear()
        For i = 1 To MAX_PROJECTILES
            cmbProjectile.Items.Add(i & ": " & Projectile(i).Name)
        Next

        cmbSkills.Items.Clear()
        For i = 1 To MAX_SKILLS
            cmbSkills.Items.Add(i & ": " & Skill(i).Name)
        Next

        cmbPet.Items.Clear()
        For i = 1 To MAX_PETS
            cmbPet.Items.Add(i & ": " & Pet(i).Name)
        Next

        lstIndex.Items.Clear()

        ' Add the names
        For i = 1 To MAX_ITEMS
            lstIndex.Items.Add(i & ": " & Trim$(Item(i).Name))
        Next
        nudPaperdoll.Maximum = NumPaperdolls
        nudSpanwAmount.Maximum = Integer.MaxValue
    End Sub

    Private Sub BtnBasics_Click(sender As Object, e As EventArgs) Handles btnBasics.Click
        fraBasics.Visible = True
        fraRequirements.Visible = False
    End Sub

    Private Sub BtnRequirements_Click(sender As Object, e As EventArgs) Handles btnRequirements.Click
        fraBasics.Visible = False
        fraRequirements.Visible = True
    End Sub

#End Region

#Region "Basics"

    Private Sub NudPic_Click(sender As Object, e As EventArgs) Handles nudIcon.Click
        Item(EditorIndex).Icon = nudIcon.Value
        EditorItem_DrawIcon()
    End Sub

    Private Sub CmbBind_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBind.SelectedIndexChanged
        Item(EditorIndex).BindType = cmbBind.SelectedIndex
    End Sub

    Private Sub NudRarity_ValueChanged(sender As Object, e As EventArgs) Handles nudRarity.Click
        Item(EditorIndex).Rarity = nudRarity.Value
    End Sub

    Private Sub CmbAnimation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAnimation.SelectedIndexChanged
        Item(EditorIndex).Animation = cmbAnimation.SelectedIndex
    End Sub

    Private Sub CmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged
        cmbSubType.Enabled = False

        If (cmbType.SelectedIndex = ItemType.Equipment) Then
            fraEquipment.Visible = True

            ' Build subtype cmb
            cmbSubType.Items.Clear()

            cmbSubType.Items.Add("Weapon")
            cmbSubType.Items.Add("Armor")
            cmbSubType.Items.Add("Helmet")
            cmbSubType.Items.Add("Shield")
            cmbSubType.Items.Add("Shoes")
            cmbSubType.Items.Add("Gloves")

            cmbSubType.Enabled = True
            cmbSubType.SelectedIndex = Item(EditorIndex).SubType

            If Item(EditorIndex).SubType = EquipmentType.Weapon Then
                fraProjectile.Visible = True
            Else
                fraProjectile.Visible = False
            End If
        Else
            fraEquipment.Visible = False
        End If

        If (cmbType.SelectedIndex = ItemType.Consumable) Then
            fraVitals.Visible = True

            ' Build subtype cmb
            cmbSubType.Items.Clear()

            cmbSubType.Items.Add("HP")
            cmbSubType.Items.Add("MP")
            cmbSubType.Items.Add("SP")
            cmbSubType.Items.Add("Exp")

            cmbSubType.Enabled = True
            cmbSubType.SelectedIndex = Item(EditorIndex).SubType
        Else
            fraVitals.Visible = False
        End If

        If (cmbType.SelectedIndex = ItemType.Skill) Then
            fraSkill.Visible = True
        Else
            fraSkill.Visible = False
        End If

        If (cmbType.SelectedIndex = ItemType.Projectile) Then
            fraProjectile.Visible = True
            fraEquipment.Visible = True
        Elseif cmbType.SelectedIndex <> ItemType.Equipment Then
            fraProjectile.Visible = False
        End If

        If cmbType.SelectedIndex = ItemType.Pet Then
            fraPet.Visible = True
            fraEquipment.Visible = True
        Else
            fraPet.Visible = False
        End If

        If cmbType.SelectedIndex = Itemtype.CommonEvent Then
            fraEvents.Visible = True

            ' Build subtype cmb
            cmbSubType.Items.Clear()

            cmbSubType.Items.Add("Switches")
            cmbSubType.Items.Add("Variables")
            cmbSubType.Items.Add("Custom Script")
            cmbSubType.Items.Add("Key")

            cmbSubType.Enabled = True
            cmbSubType.SelectedIndex = Item(EditorIndex).SubType
        Else
            fraEvents.Visible = false
        End If

        Item(EditorIndex).Type = cmbType.SelectedIndex
    End Sub

    Private Sub NudVitalMod_Click(sender As Object, e As EventArgs) Handles nudVitalMod.Click
        Item(EditorIndex).Data1 = nudVitalMod.Value
    End Sub

    Private Sub CmbSkills_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSkills.SelectedIndexChanged
        Item(EditorIndex).Data1 = cmbSkills.SelectedIndex
    End Sub

    Private Sub TxtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        Dim tmpindex As Integer

        tmpindex = lstIndex.SelectedIndex
        Item(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Item(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpindex
    End Sub

    Private Sub NudPrice_ValueChanged(sender As Object, e As EventArgs) Handles nudPrice.Click
        Item(EditorIndex).Price = nudPrice.Value
    End Sub

    Private Sub ChkStackable_CheckedChanged(sender As Object, e As EventArgs) Handles chkStackable.CheckedChanged
        If chkStackable.Checked = True Then
            Item(EditorIndex).Stackable = 1
        Else
            Item(EditorIndex).Stackable = 0
        End If
    End Sub

    Private Sub TxtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged
        Item(EditorIndex).Description = Trim$(txtDescription.Text)
    End Sub

    Private Sub CmbSubType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubType.SelectedIndexChanged
        Item(EditorIndex).SubType = cmbSubType.SelectedIndex

        If Item(EditorIndex).SubType = EquipmentType.Weapon Then
            fraProjectile.Visible = True
        Else
            fraProjectile.Visible = False
        End If
    End Sub

    Private Sub NudItemLvl_ValueChanged(sender As Object, e As EventArgs) Handles nudItemLvl.Click
        Item(EditorIndex).ItemLevel = nudItemLvl.Value
    End Sub

    Private Sub CmbPet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPet.SelectedIndexChanged
        Item(EditorIndex).Data1 = cmbPet.SelectedIndex
    End Sub

    Private Sub nudEvents_ValueChanged(sender As Object, e As EventArgs) Handles nudEvent.ValueChanged
        Item(EditorIndex).Data1 = nudVitalMod.Value
    End Sub

#End Region

#Region "Requirements"

    Private Sub CmbJobReq_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJobReq.SelectedIndexChanged
        Item(EditorIndex).JobReq = cmbJobReq.SelectedIndex
    End Sub

    Private Sub CmbAccessReq_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAccessReq.SelectedIndexChanged
        Item(EditorIndex).AccessReq = cmbAccessReq.SelectedIndex
    End Sub

    Private Sub NudLevelReq_ValueChanged(sender As Object, e As EventArgs) Handles nudLevelReq.Click
        Item(EditorIndex).LevelReq = nudLevelReq.Value
    End Sub

    Private Sub NudStrReq_ValueChanged(sender As Object, e As EventArgs) Handles nudStrReq.Click
        Item(EditorIndex).Stat_Req(StatType.Strength) = nudStrReq.Value
    End Sub

    Private Sub NudVitReq_ValueChanged(sender As Object, e As EventArgs) Handles nudVitReq.Click
        Item(EditorIndex).Stat_Req(StatType.Vitality) = nudVitReq.Value
    End Sub

    Private Sub NudLuckReq_ValueChanged(sender As Object, e As EventArgs) Handles nudLuckReq.Click
        Item(EditorIndex).Stat_Req(StatType.Luck) = nudLuckReq.Value
    End Sub

    Private Sub NudIntReq_ValueChanged(sender As Object, e As EventArgs) Handles nudIntReq.Click
        Item(EditorIndex).Stat_Req(StatType.Intelligence) = nudIntReq.Value
    End Sub

    Private Sub NudSprReq_ValueChanged(sender As Object, e As EventArgs) Handles nudSprReq.Click
        Item(EditorIndex).Stat_Req(StatType.Spirit) = nudSprReq.Value
    End Sub

#End Region

#Region "Equipment"

    Private Sub CmbTool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTool.SelectedIndexChanged
        Item(EditorIndex).Data3 = cmbTool.SelectedIndex
    End Sub

    Private Sub NudDamage_ValueChanged(sender As Object, e As EventArgs) Handles nudDamage.Click

        Item(EditorIndex).Data2 = nudDamage.Value
    End Sub

    Private Sub NudSpeed_ValueChanged(sender As Object, e As EventArgs) Handles nudSpeed.Click
        lblSpeed.Text = "Speed: " & nudSpeed.Value / 1000 & " sec"
        Item(EditorIndex).Speed = nudSpeed.Value
    End Sub

    Private Sub NudPaperdoll_ValueChanged(sender As Object, e As EventArgs) Handles nudPaperdoll.Click
        Item(EditorIndex).Paperdoll = nudPaperdoll.Value
        EditorItem_DrawPaperdoll()
    End Sub

    Private Sub NudStrength_ValueChanged(sender As Object, e As EventArgs) Handles nudStrength.Click
        Item(EditorIndex).Add_Stat(StatType.Strength) = nudStrength.Value
    End Sub

    Private Sub NudLuck_ValueChanged(sender As Object, e As EventArgs) Handles nudLuck.Click
        Item(EditorIndex).Add_Stat(StatType.Luck) = nudLuck.Value
    End Sub

    Private Sub NudIntelligence_ValueChanged(sender As Object, e As EventArgs) Handles nudIntelligence.Click
        Item(EditorIndex).Add_Stat(StatType.Intelligence) = nudIntelligence.Value
    End Sub

    Private Sub NudVitality_ValueChanged(sender As Object, e As EventArgs) Handles nudVitality.Click
        Item(EditorIndex).Add_Stat(StatType.Vitality) = nudVitality.Value
    End Sub

    Private Sub NudSpirit_ValueChanged(sender As Object, e As EventArgs) Handles nudSpirit.Click
        Item(EditorIndex).Add_Stat(StatType.Spirit) = nudSpirit.Value
    End Sub

    Private Sub ChkKnockBack_CheckedChanged(sender As Object, e As EventArgs) Handles chkKnockBack.CheckedChanged
        If chkKnockBack.Checked = True Then
            Item(EditorIndex).KnockBack = 1
        Else
            Item(EditorIndex).KnockBack = 0
        End If
    End Sub

    Private Sub CmbKnockBackTiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbKnockBackTiles.SelectedIndexChanged
        Item(EditorIndex).KnockBackTiles = cmbKnockBackTiles.SelectedIndex
    End Sub

    Private Sub ChkRandomize_CheckedChanged(sender As Object, e As EventArgs) Handles chkRandomize.CheckedChanged
        If chkRandomize.Checked = True Then
            Item(EditorIndex).Randomize = 1
        Else
            Item(EditorIndex).Randomize = 0
        End If
    End Sub

    Private Sub CmbProjectile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProjectile.SelectedIndexChanged
        Item(EditorIndex).Projectile = cmbProjectile.SelectedIndex
    End Sub

    Private Sub CmbAmmo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAmmo.SelectedIndexChanged
        Item(EditorIndex).Ammo = cmbAmmo.SelectedIndex
    End Sub

    Private Sub btnSpawn_Click(sender As Object, e As EventArgs) Handles btnSpawn.Click
        SendSpawnItem(EditorIndex, nudSpanwAmount.Value)
    End Sub

    Private Sub frmEditor_Item_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ItemEditorCancel()
    End Sub


#End Region

End Class