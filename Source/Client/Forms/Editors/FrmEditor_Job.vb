Imports System.IO
Imports Core

Friend Class frmEditor_Job

#Region "Frm Controls"

    Private Sub frmEditor_Job_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nudMaleSprite.Maximum = NumCharacters
        nudFemaleSprite.Maximum = NumCharacters

        cmbItems.Items.Clear()

        For i = 1 To MAX_ITEMS
            cmbItems.Items.Add(i & ": " & Trim(Item(i).Name))
        Next

        lstIndex.Items.Clear()

        For i = 1 To MAX_JOBS
            lstIndex.Items.Add(i & ": " & Trim(Job(i).Name))
        Next

        lstStartItems.Items.Clear()

        For i = 1 To MAX_DROP_ITEMS
            lstStartItems.Items.Add(Item(Job(EditorIndex).StartItem(i)).Name & " X " & Job(EditorIndex).StartValue(i))
        Next

        lstStartItems.SelectedIndex = 0
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        JobEditorOk()
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        JobEditorCancel()
        Dispose()
    End Sub

    Private Sub TxtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged
        Job(EditorIndex).Desc = txtDescription.Text
    End Sub

    Private Sub TxtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        Dim tmpindex As Integer

        tmpindex = lstIndex.SelectedIndex
        Job(EditorIndex).Name = Trim$(txtName.Text)
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Job(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpindex
    End Sub

#End Region

#Region "Sprites"

    Sub DrawPreview()

        If File.Exists(Paths.Graphics & "Characters\" & nudMaleSprite.Value & GfxExt) Then
            picMale.Width = Image.FromFile(Paths.Graphics & "characters\" & nudMaleSprite.Value & GfxExt).Width \ 4
            picMale.Height = Image.FromFile(Paths.Graphics & "characters\" & nudMaleSprite.Value & GfxExt).Height \ 4
            picMale.BackgroundImage = Image.FromFile(Paths.Graphics & "Characters\" & nudMaleSprite.Value & GfxExt)
        Else
            picMale.BackgroundImage = Nothing
        End If

        If File.Exists(Paths.Graphics & "Characters\" & nudFemaleSprite.Value & GfxExt) Then
            picFemale.Width = Image.FromFile(Paths.Graphics & "characters\" & nudFemaleSprite.Value & GfxExt).Width \ 4
            picFemale.Height = Image.FromFile(Paths.Graphics & "characters\" & nudFemaleSprite.Value & GfxExt).Height \ 4
            picFemale.BackgroundImage = Image.FromFile(Paths.Graphics & "Characters\" & nudFemaleSprite.Value & GfxExt)
        Else
            picFemale.BackgroundImage = Nothing
        End If

    End Sub

#End Region

#Region "Stats"

    Private Sub NumStrength_ValueChanged(sender As Object, e As EventArgs) Handles nudStrength.Click
        Job(EditorIndex).Stat(StatType.Strength) = nudStrength.Value
    End Sub

    Private Sub NumLuck_ValueChanged(sender As Object, e As EventArgs) Handles nudLuck.Click
        Job(EditorIndex).Stat(StatType.Luck) = nudLuck.Value
    End Sub

    Private Sub NumEndurance_ValueChanged(sender As Object, e As EventArgs)
        Job(EditorIndex).Stat(StatType.Luck) = nudEndurance.Value
    End Sub

    Private Sub NumIntelligence_ValueChanged(sender As Object, e As EventArgs) Handles nudIntelligence.Click
        Job(EditorIndex).Stat(StatType.Intelligence) = nudIntelligence.Value
    End Sub

    Private Sub NumVitality_ValueChanged(sender As Object, e As EventArgs) Handles nudVitality.Click
        Job(EditorIndex).Stat(StatType.Vitality) = nudVitality.Value
    End Sub

    Private Sub NumSpirit_ValueChanged(sender As Object, e As EventArgs) Handles nudSpirit.Click
        Job(EditorIndex).Stat(StatType.Spirit) = nudSpirit.Value
    End Sub

    Private Sub NumBaseExp_ValueChanged(sender As Object, e As EventArgs) Handles nudBaseExp.Click
        Job(EditorIndex).BaseExp = nudBaseExp.Value
    End Sub

#End Region

#Region "Start Items"

    Private Sub BtnItemAdd_Click(sender As Object, e As EventArgs) Handles btnItemAdd.Click
        If lstStartItems.SelectedIndex < 0 Then Exit Sub

        Job(EditorIndex).StartItem(lstStartItems.SelectedIndex + 1) = cmbItems.SelectedIndex + 1
        Job(EditorIndex).StartValue(lstStartItems.SelectedIndex + 1) = nudItemAmount.Value

        lstStartItems.Items.Clear()
        For i = 1 To MAX_DROP_ITEMS
            lstStartItems.Items.Add(Item(Job(EditorIndex).StartItem(i)).Name & " X " & Job(EditorIndex).StartValue(i))
        Next
        lstStartItems.SelectedIndex = 0
    End Sub

#End Region

#Region "Starting Point"

    Private Sub NumStartMap_Click(sender As Object, e As EventArgs) Handles nudStartMap.Click
        Job(EditorIndex).StartMap = nudStartMap.Value
    End Sub

    Private Sub NumStartX_Click(sender As Object, e As EventArgs) Handles nudStartX.Click
        Job(EditorIndex).StartX = nudStartX.Value
    End Sub

    Private Sub NumStartY_Click(sender As Object, e As EventArgs) Handles nudStartY.Click
        Job(EditorIndex).StartY = nudStartY.Value
    End Sub

    Private Sub lstIndex_Click(sender As Object, e As EventArgs) Handles lstIndex.Click
        JobEditorInit()
    End Sub

    Private Sub frmEditor_Job_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        JobEditorCancel
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim tmpindex As Integer

        ClearJob(EditorIndex)

        tmpindex = lstIndex.SelectedIndex
        lstIndex.Items.RemoveAt(EditorIndex - 1)
        lstIndex.Items.Insert(EditorIndex - 1, EditorIndex & ": " & Job(EditorIndex).Name)
        lstIndex.SelectedIndex = tmpindex

        JobEditorInit()
    End Sub

    Private Sub nudFemaleSprite_Click(sender As Object, e As EventArgs) Handles nudFemaleSprite.Click
        Job(EditorIndex).FemaleSprite = nudFemaleSprite.Value
        DrawPreview
    End Sub

    Private Sub nudMaleSprite_Click(sender As Object, e As EventArgs) Handles nudMaleSprite.Click
        Job(EditorIndex).MaleSprite = nudMaleSprite.Value
        DrawPreview
    End Sub

#End Region

End Class