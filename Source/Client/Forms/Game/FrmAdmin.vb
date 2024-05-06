
Imports Core

Friend Class FrmAdmin

    Private Sub FrmAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SendRequestMapReport()
        cmbAccess.SelectedIndex = 0
    End Sub

#Region "Moderation"

    Private Sub BtnAdminWarpTo_Click(sender As Object, e As EventArgs) Handles btnAdminWarpTo.Click

        If GetPlayerAccess(MyIndex) < [Enum].AccessType.Mapper Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        WarpTo(nudAdminMap.Value)
    End Sub

    Private Sub BtnAdminBan_Click(sender As Object, e As EventArgs) Handles btnAdminBan.Click
        If GetPlayerAccess(MyIndex) < AccessType.Mapper Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        SendBan(Trim$(txtAdminName.Text))
    End Sub

    Private Sub BtnAdminKick_Click(sender As Object, e As EventArgs) Handles btnAdminKick.Click
        If GetPlayerAccess(MyIndex) < AccessType.Mapper Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        SendKick(Trim$(txtAdminName.Text))
    End Sub

    Private Sub BtnAdminWarp2Me_Click(sender As Object, e As EventArgs) Handles btnAdminWarp2Me.Click
        If GetPlayerAccess(MyIndex) < AccessType.Mapper Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        If IsNumeric(Trim$(txtAdminName.Text)) Then Exit Sub

        WarpToMe(Trim$(txtAdminName.Text))
    End Sub

    Private Sub BtnAdminWarpMe2_Click(sender As Object, e As EventArgs) Handles btnAdminWarpMe2.Click
        If GetPlayerAccess(MyIndex) < AccessType.Mapper Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        If IsNumeric(Trim$(txtAdminName.Text)) Then
            Exit Sub
        End If

        WarpMeTo(Trim$(txtAdminName.Text))
    End Sub

    Private Sub BtnAdminSetAccess_Click(sender As Object, e As EventArgs) Handles btnAdminSetAccess.Click
        If GetPlayerAccess(MyIndex) < AccessType.Creator Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        If IsNumeric(Trim$(txtAdminName.Text)) Or cmbAccess.SelectedIndex < 0 Then
            Exit Sub
        End If

        SendSetAccess(Trim$(txtAdminName.Text), cmbAccess.SelectedIndex)
    End Sub

    Private Sub BtnAdminSetSprite_Click(sender As Object, e As EventArgs) Handles btnAdminSetSprite.Click
        If GetPlayerAccess(MyIndex) < AccessType.Mapper Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        SendSetSprite(nudAdminSprite.Value)
    End Sub

#End Region

#Region "Editors"

    Private Sub btnAnimationEditor_Click(sender As Object, e As EventArgs) Handles btnAnimationEditor.Click
        If Editor <> -1 Then
            MsgBox("You are already in an Editor. Please close the editor to use another one.")
            Exit Sub
        End If

        If GetPlayerAccess(MyIndex) < AccessType.Developer Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        SendRequestEditAnimation()
    End Sub

    Private Sub btnClassEditor_Click(sender As Object, e As EventArgs) Handles btnJobEditor.Click
        If Editor <> -1 Then
            MsgBox("You are already in an Editor. Please close the editor to use another one.")
            Exit Sub
        End If

        If GetPlayerAccess(MyIndex) < AccessType.Developer Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        SendRequestEditJob()
    End Sub

    Private Sub btnItemEditor_Click(sender As Object, e As EventArgs) Handles btnItemEditor.Click
        If Editor <> -1 Then
            MsgBox("You are already in an Editor. Please close the editor to use another one.")
            Exit Sub
        End If

        If GetPlayerAccess(MyIndex) < AccessType.Developer Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        SendRequestEditItem()
    End Sub

    Private Sub BtnMapEditor_Click(sender As Object, e As EventArgs) Handles btnMapEditor.Click
        If Editor <> -1 Then
            MsgBox("You are already in an Editor. Please close the editor to use another one.")
            Exit Sub
        End If

        If GetPlayerAccess(MyIndex) < AccessType.Mapper Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        SendRequestEditMap()
    End Sub

    Private Sub btnNPCEditor_Click(sender As Object, e As EventArgs) Handles btnNPCEditor.Click
        If Editor <> -1 Then
            MsgBox("You are already in an Editor. Please close the editor to use another one.")
            Exit Sub
        End If

        If GetPlayerAccess(MyIndex) < AccessType.Developer Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        SendRequestEditNpc()
    End Sub

    Private Sub btnPetEditor_Click(sender As Object, e As EventArgs) Handles btnPetEditor.Click
        If Editor <> -1 Then
            MsgBox("You are already in an Editor. Please close the editor to use another one.")
            Exit Sub
        End If

        If GetPlayerAccess(MyIndex) < AccessType.Developer Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        SendRequestEditPet()
    End Sub

    Private Sub btnProjectiles_Click(sender As Object, e As EventArgs) Handles btnProjectiles.Click
        If Editor <> -1 Then
            MsgBox("You are already in an Editor. Please close the editor to use another one.")
            Exit Sub
        End If

        If GetPlayerAccess(MyIndex) < AccessType.Developer Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        SendRequestEditProjectile()
    End Sub

    Private Sub btnResourceEditor_Click(sender As Object, e As EventArgs) Handles btnResourceEditor.Click
        If Editor <> -1 Then
            MsgBox("You are already in an Editor. Please close the editor to use another one.")
            Exit Sub
        End If

        If GetPlayerAccess(MyIndex) < AccessType.Developer Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        SendRequestEditResource()
    End Sub

    Private Sub btnShopEditor_Click(sender As Object, e As EventArgs) Handles btnShopEditor.Click
        If Editor <> -1 Then
            MsgBox("You are already in an Editor. Please close the editor to use another one.")
            Exit Sub
        End If

        If GetPlayerAccess(MyIndex) < AccessType.Developer Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        SendRequestEditShop()
    End Sub

    Private Sub btnSkillEditor_Click(sender As Object, e As EventArgs) Handles btnSkillEditor.Click
        If Editor <> -1 Then
            MsgBox("You are already in an Editor. Please close the editor to use another one.")
            Exit Sub
        End If

        If GetPlayerAccess(MyIndex) < AccessType.Developer Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        SendRequestEditSkill()
    End Sub

#End Region

#Region "Map Report"

    Private Sub BtnMapReport_Click(sender As Object, e As EventArgs) Handles btnMapReport.Click
        If GetPlayerAccess(MyIndex) < AccessType.Mapper Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If
        SendRequestMapReport()
    End Sub

    Private Sub LstMaps_DoubleClick(sender As Object, e As EventArgs) Handles lstMaps.DoubleClick
        If GetPlayerAccess(MyIndex) < AccessType.Mapper Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        If lstMaps.FocusedItem.Index = 0 Then Exit Sub
        WarpTo(lstMaps.FocusedItem.Index)
    End Sub

#End Region

#Region "Misc"
    Private Sub BtnLevelUp_Click(sender As Object, e As EventArgs) Handles btnLevelUp.Click
        If GetPlayerAccess(MyIndex) < AccessType.Developer Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        SendRequestLevelUp()
    End Sub

    Private Sub BtnALoc_Click(sender As Object, e As EventArgs) Handles btnALoc.Click
        If GetPlayerAccess(MyIndex) < AccessType.Mapper Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        BLoc = Not BLoc
    End Sub

    Private Sub BtnRespawn_Click(sender As Object, e As EventArgs) Handles btnRespawn.Click
        If GetPlayerAccess(MyIndex) < AccessType.Mapper Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        SendMapRespawn()
    End Sub

    Private Sub btnMoralEditor_Click(sender As Object, e As EventArgs) Handles btnMoralEditor.Click
        If Editor <> -1 Then
            MsgBox("You are already in an Editor. Please close the editor to use another one.")
            Exit Sub
        End If

        If GetPlayerAccess(MyIndex) < AccessType.Developer Then
            AddText("You need to be a high enough staff member to do this!", ColorType.BrightRed)
            Exit Sub
        End If

        SendRequestEditMoral()
    End Sub

#End Region

End Class