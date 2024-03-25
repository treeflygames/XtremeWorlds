Imports System.IO
Imports Core
Friend Class frmEditor_Pet

#Region "Basics"

    Private Sub frmEditor_Pet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nudSprite.Maximum = NumCharacters
        nudRange.Maximum = 50
        nudLevel.Maximum = MAX_LEVEL
        nudMaxLevel.Maximum = MAX_LEVEL

        lstIndex.Items.Clear()

        ' Add the names
        For i = 1 To MAX_PETS
            lstIndex.Items.Add(i & ": " & Trim$(Pet(i).Name))
        Next

        cmbEvolve.Items.Clear()
        cmbEvolve.Items.Add("None")
        ' Add the names
        For i = 1 To MAX_PETS
            cmbEvolve.Items.Add(i & ": " & Trim$(Pet(i).Name))
        Next
    End Sub

    Private Sub LstIndex_Click(sender As Object, e As EventArgs) Handles lstIndex.Click
        PetEditorInit()
    End Sub

    Private Sub TxtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        Dim tmpindex As Integer

        tmpindex = lstIndex.SelectedIndex
        Pet(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Pet(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpindex
    End Sub

    Private Sub NudSprite_Click(sender As Object, e As EventArgs) Handles nudSprite.Click
        Pet(EditorIndex).Sprite = nudSprite.Value

        EditorPet_DrawPet()
    End Sub

    Friend Sub EditorPet_DrawPet()
        Dim petnum As Integer

        petnum = nudSprite.Value

        If petnum <= 0 OrElse petnum > NumCharacters Then
            picSprite.BackgroundImage = Nothing
            Exit Sub
        End If

        If File.Exists(Paths.Graphics & "Characters\" & petnum & GfxExt) Then
            picSprite.Width = Drawing.Image.FromFile(Paths.Graphics & "characters\" & petnum & GfxExt).Width/4
            picSprite.Height = Drawing.Image.FromFile(Paths.Graphics & "characters\" & petnum & GfxExt).Height/4
            picSprite.BackgroundImage = Image.FromFile(Paths.Graphics & "Characters\" & petnum & GfxExt)
        Else
            picSprite.BackgroundImage = Nothing
        End If

    End Sub

    Private Sub NudRange_ValueChanged(sender As Object, e As EventArgs) Handles nudRange.Click
        Pet(EditorIndex).Range = nudRange.Value
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        PetEditorOk()
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        PetEditorCancel()
        Dispose()
End Sub





#End Region
#Region "Stats"

    Private Sub OptCustomStats_CheckedChanged(sender As Object, e As EventArgs) Handles optCustomStats.CheckedChanged
        If optCustomStats.Checked = True Then
            pnlCustomStats.Visible = True
            Pet(EditorIndex).StatType = 1
        Else
            pnlCustomStats.Visible = False
            Pet(EditorIndex).StatType = 0
        End If
    End Sub

    Private Sub OptAdoptStats_CheckedChanged(sender As Object, e As EventArgs) Handles optAdoptStats.CheckedChanged
        If optAdoptStats.Checked = True Then
            pnlCustomStats.Visible = False
            Pet(EditorIndex).StatType = 0
        Else
            pnlCustomStats.Visible = True
            Pet(EditorIndex).StatType = 1
        End If
    End Sub

    Private Sub NudStrength_ValueChanged(sender As Object, e As EventArgs) Handles nudStrength.ValueChanged
        Pet(EditorIndex).Stat(StatType.Strength) = nudStrength.Value
    End Sub

    Private Sub NudVitality_ValueChanged(sender As Object, e As EventArgs) Handles nudVitality.ValueChanged
        Pet(EditorIndex).Stat(StatType.Vitality) = nudVitality.Value
    End Sub

    Private Sub NudLuck_ValueChanged(sender As Object, e As EventArgs) Handles nudLuck.ValueChanged
        Pet(EditorIndex).Stat(StatType.Luck) = nudLuck.Value
    End Sub

    Private Sub NudIntelligence_ValueChanged(sender As Object, e As EventArgs) Handles nudIntelligence.ValueChanged
        Pet(EditorIndex).Stat(StatType.Intelligence) = nudIntelligence.Value
    End Sub

    Private Sub NudSpirit_ValueChanged(sender As Object, e As EventArgs) Handles nudSpirit.ValueChanged
        Pet(EditorIndex).Stat(StatType.Spirit) = nudSpirit.Value
    End Sub

    Private Sub NudLevel_ValueChanged(sender As Object, e As EventArgs) Handles nudLevel.ValueChanged
        Pet(EditorIndex).Level = nudLevel.Value
    End Sub




#End Region
#Region "Leveling"

    Private Sub NudPetExp_ValueChanged(sender As Object, e As EventArgs) Handles nudPetExp.Click
        Pet(EditorIndex).ExpGain = nudPetExp.Value
    End Sub

    Private Sub NudPetPnts_ValueChanged(sender As Object, e As EventArgs) Handles nudPetPnts.Click
        Pet(EditorIndex).LevelPnts = nudPetPnts.Value
    End Sub

    Private Sub NudMaxLevel_ValueChanged(sender As Object, e As EventArgs) Handles nudMaxLevel.Click
        Pet(EditorIndex).MaxLevel = nudMaxLevel.Value
    End Sub

    Private Sub OptLevel_CheckedChanged(sender As Object, e As EventArgs) Handles optLevel.Click
        If optLevel.Checked = True Then
            pnlPetlevel.Visible = True
            Pet(EditorIndex).LevelingType = 1
        End If
    End Sub

    Private Sub OptDoNotLevel_CheckedChanged(sender As Object, e As EventArgs) Handles optDoNotLevel.Click
        If optDoNotLevel.Checked = True Then
            pnlPetlevel.Visible = False
            Pet(EditorIndex).LevelingType = 0
End If
    End Sub




#End Region
#Region "Skills"

    Private Sub CmbSkill1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSkill1.SelectedIndexChanged
        Pet(EditorIndex).Skill(1) = cmbSkill1.SelectedIndex
    End Sub

    Private Sub CmbSkill2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSkill2.SelectedIndexChanged
        Pet(EditorIndex).Skill(2) = cmbSkill2.SelectedIndex
    End Sub

    Private Sub CmbSkill3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSkill3.SelectedIndexChanged
        Pet(EditorIndex).Skill(3) = cmbSkill3.SelectedIndex
    End Sub

    Private Sub CmbSkill4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSkill4.SelectedIndexChanged
        Pet(EditorIndex).Skill(4) = cmbSkill4.SelectedIndex
    End Sub




#End Region
#Region "Evolving"

    Private Sub ChkEvolve_CheckedChanged(sender As Object, e As EventArgs) Handles chkEvolve.CheckedChanged
        If chkEvolve.Checked = True Then
            Pet(EditorIndex).Evolvable = 1
        Else
            Pet(EditorIndex).Evolvable = 0
        End If
    End Sub

    Private Sub NudEvolveLvl_ValueChanged(sender As Object, e As EventArgs) Handles nudEvolveLvl.ValueChanged
        Pet(EditorIndex).EvolveLevel = nudEvolveLvl.Value
    End Sub

    Private Sub CmbEvolve_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEvolve.SelectedIndexChanged
        Pet(EditorIndex).EvolveNum = cmbEvolve.SelectedIndex
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim tmpindex As Integer

        ClearPet(EditorIndex)

        tmpindex = lstIndex.SelectedIndex
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Pet(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpindex

        PetEditorInit()
    End Sub

    Private Sub frmEditor_Pet_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        PetEditorCancel
    End Sub

#End Region

End Class