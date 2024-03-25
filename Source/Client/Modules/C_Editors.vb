Imports System.IO
Imports Core

Module C_Editors

#Region "Animation Editor"

    Friend Sub AnimationEditorInit()
        EditorIndex = frmEditor_Animation.lstIndex.SelectedIndex + 1

        With Animation(EditorIndex)
            If Trim$(Animation(EditorIndex).Sound) = "" Then
                frmEditor_Animation.cmbSound.SelectedIndex = 0
            Else
                For i = 0 To frmEditor_Animation.cmbSound.Items.Count
                    If frmEditor_Animation.cmbSound.GetItemText(i) = frmEditor_Animation.cmbSound.SelectedIndex Then
                        frmEditor_Animation.cmbSound.SelectedIndex = i
                        Exit For
                    End If
                Next
            End If
            frmEditor_Animation.txtName.Text = Trim$(.Name)

            frmEditor_Animation.nudSprite0.Value = .Sprite(0)
            frmEditor_Animation.nudFrameCount0.Value = .Frames(0)
            If Animation(EditorIndex).LoopCount(0) = 0 Then Animation(EditorIndex).LoopCount(0) = 1
            frmEditor_Animation.nudLoopCount0.Value = .LoopCount(0)
            If Animation(EditorIndex).LoopTime(0) = 0 Then Animation(EditorIndex).LoopTime(0) = 1
            frmEditor_Animation.nudLoopTime0.Value = .LoopTime(0)

            frmEditor_Animation.nudSprite1.Value = .Sprite(1)
            frmEditor_Animation.nudFrameCount1.Value = .Frames(1)
            If Animation(EditorIndex).LoopCount(1) = 0 Then Animation(EditorIndex).LoopCount(1) = 1
            frmEditor_Animation.nudLoopCount1.Value = .LoopCount(1)
            If Animation(EditorIndex).LoopTime(1) = 0 Then Animation(EditorIndex).LoopTime(1) = 1
            frmEditor_Animation.nudLoopTime1.Value = .LoopTime(1)
        End With

        Animation_Changed(EditorIndex) = True
    End Sub

    Friend Sub AnimationEditorOk()
        Dim i As Integer

       For i = 1 To MAX_ANIMATIONS
            If Animation_Changed(i) Then
                SendSaveAnimation(i)
            End If
        Next

        Editor = -1
        ClearChanged_Animation()
        SendCloseEditor()
    End Sub

    Friend Sub AnimationEditorCancel()
        Editor = -1
        ClearChanged_Animation()
        ClearAnimations()
        SendCloseEditor()
    End Sub

    Friend Sub ClearChanged_Animation()
        For i = 1 To MAX_ANIMATIONS
            Animation_Changed(i) = False
        Next
    End Sub

#End Region

#Region "Npc Editor"

    Friend Sub NpcEditorInit()
        With frmEditor_NPC
            EditorIndex = .lstIndex.SelectedIndex + 1

            .cmbDropSlot.SelectedIndex = 0

            .txtName.Text = NPC(EditorIndex).Name
            .txtAttackSay.Text = NPC(EditorIndex).AttackSay
            .nudSprite.Value = NPC(EditorIndex).Sprite
            .nudSpawnSecs.Value = NPC(EditorIndex).SpawnSecs
            .cmbBehaviour.SelectedIndex = NPC(EditorIndex).Behaviour
            .cmbFaction.SelectedIndex = NPC(EditorIndex).Faction
            .nudRange.Value = NPC(EditorIndex).Range
            .nudChance.Value = NPC(EditorIndex).DropChance(frmEditor_NPC.cmbDropSlot.SelectedIndex)
            .cmbItem.SelectedIndex = NPC(EditorIndex).DropItem(frmEditor_NPC.cmbDropSlot.SelectedIndex)

            .nudAmount.Value = NPC(EditorIndex).DropItemValue(frmEditor_NPC.cmbDropSlot.SelectedIndex)

            .nudHp.Value = NPC(EditorIndex).HP
            .nudExp.Value = NPC(EditorIndex).Exp
            .nudLevel.Value = NPC(EditorIndex).Level
            .nudDamage.Value = NPC(EditorIndex).Damage

            .cmbSpawnPeriod.SelectedIndex = NPC(EditorIndex).SpawnTime

            .cmbAnimation.SelectedIndex = NPC(EditorIndex).Animation

            .nudStrength.Value = NPC(EditorIndex).Stat(StatType.Strength)
            .nudIntelligence.Value = NPC(EditorIndex).Stat(StatType.Intelligence)
            .nudSpirit.Value = NPC(EditorIndex).Stat(StatType.Spirit)
            .nudLuck.Value = NPC(EditorIndex).Stat(StatType.Luck)
            .nudVitality.Value = NPC(EditorIndex).Stat(StatType.Vitality)

            .cmbSkill1.SelectedIndex = NPC(EditorIndex).Skill(1)
            .cmbSkill2.SelectedIndex = NPC(EditorIndex).Skill(2)
            .cmbSkill3.SelectedIndex = NPC(EditorIndex).Skill(3)
            .cmbSkill4.SelectedIndex = NPC(EditorIndex).Skill(4)
            .cmbSkill5.SelectedIndex = NPC(EditorIndex).Skill(5)
            .cmbSkill6.SelectedIndex = NPC(EditorIndex).Skill(6)
        End With

        EditorNpc_DrawSprite()
        NPC_Changed(EditorIndex) = True
    End Sub

    Friend Sub NpcEditorOk()
        Dim i As Integer

        For i = 1 To MAX_NPCS
            If NPC_Changed(i) Then
                SendSaveNpc(i)
            End If
        Next

        Editor = -1
        ClearChanged_NPC()
        SendCloseEditor()
    End Sub

    Friend Sub NpcEditorCancel()
        Editor = -1
        ClearChanged_NPC()
        ClearNpcs()
        SendCloseEditor()
    End Sub

    Friend Sub ClearChanged_NPC()
        For i = 1 To MAX_NPCS
            NPC_Changed(i) = False
        Next
    End Sub

#End Region

#Region "Resource Editor"
    Friend Sub ClearChanged_Resource()
        ReDim Resource_Changed(MAX_RESOURCES)
    End Sub

    Friend Sub ResourceEditorInit()
        Dim i As Integer

        EditorIndex = frmEditor_Resource.lstIndex.SelectedIndex + 1

        With frmEditor_Resource
            .txtName.Text = Trim$(Resource(EditorIndex).Name)
            .txtMessage.Text = Trim$(Resource(EditorIndex).SuccessMessage)
            .txtMessage2.Text = Trim$(Resource(EditorIndex).EmptyMessage)
            .cmbType.SelectedIndex = Resource(EditorIndex).ResourceType
            .nudNormalPic.Value = Resource(EditorIndex).ResourceImage
            .nudExhaustedPic.Value = Resource(EditorIndex).ExhaustedImage
            .cmbRewardItem.SelectedIndex = Resource(EditorIndex).ItemReward
            .nudRewardExp.Value = Resource(EditorIndex).ExpReward
            .cmbTool.SelectedIndex = Resource(EditorIndex).ToolRequired
            .nudHealth.Value = Resource(EditorIndex).Health
            .nudRespawn.Value = Resource(EditorIndex).RespawnTime
            .cmbAnimation.SelectedIndex = Resource(EditorIndex).Animation
            .nudLvlReq.Value = Resource(EditorIndex).LvlRequired
        End With

        frmEditor_Resource.Visible = True

        EditorResource_DrawSprite()

        Resource_Changed(EditorIndex) = True
    End Sub

    Friend Sub ResourceEditorOk()
        Dim i As Integer

        For i = 1 To MAX_RESOURCES
            If Resource_Changed(i) Then
                SendSaveResource(i)
            End If
        Next

        Editor = -1
        ClearChanged_Resource()
        SendCloseEditor()
    End Sub

    Friend Sub ResourceEditorCancel()
        Editor = -1
        ClearChanged_Resource()
        ClearResources()
        SendCloseEditor()
    End Sub

#End Region

#Region "Skill Editor"

    Friend Sub SkillEditorInit()
        With frmEditor_Skill
            EditorIndex = .lstIndex.SelectedIndex + 1

            .cmbAnimCast.SelectedIndex = 0
            .cmbAnim.SelectedIndex = 0

            ' set values
            .txtName.Text = Trim$(Skill(EditorIndex).Name)
            .cmbType.SelectedIndex = Skill(EditorIndex).Type
            .nudMp.Value = Skill(EditorIndex).MpCost
            .nudLevel.Value = Skill(EditorIndex).LevelReq
            .cmbAccessReq.SelectedIndex = Skill(EditorIndex).AccessReq
            .cmbJob.SelectedIndex = Skill(EditorIndex).JobReq
            .nudCast.Value = Skill(EditorIndex).CastTime
            .nudCool.Value = Skill(EditorIndex).CdTime
            .nudIcon.Value = Skill(EditorIndex).Icon
            .nudMap.Value = Skill(EditorIndex).Map
            .nudX.Value = Skill(EditorIndex).X
            .nudY.Value = Skill(EditorIndex).Y
            .cmbDir.SelectedIndex = Skill(EditorIndex).Dir
            .nudVital.Value = Skill(EditorIndex).Vital
            .nudDuration.Value = Skill(EditorIndex).Duration
            .nudInterval.Value = Skill(EditorIndex).Interval
            .nudRange.Value = Skill(EditorIndex).Range

            .chkAoE.Checked = Skill(EditorIndex).IsAoE

            .nudAoE.Value = Skill(EditorIndex).AoE
            .cmbAnimCast.SelectedIndex = Skill(EditorIndex).CastAnim
            .cmbAnim.SelectedIndex = Skill(EditorIndex).SkillAnim
            .nudStun.Value = Skill(EditorIndex).StunDuration

            If Skill(EditorIndex).IsProjectile = 1 Then
                .chkProjectile.Checked = True
            Else
                .chkProjectile.Checked = False
            End If
            .cmbProjectile.SelectedIndex = Skill(EditorIndex).Projectile

            If Skill(EditorIndex).KnockBack = 1 Then
                .chkKnockBack.Checked = True
            Else
                .chkKnockBack.Checked = False
            End If
            .cmbKnockBackTiles.SelectedIndex = Skill(EditorIndex).KnockBackTiles
        End With

        Skill_Changed(EditorIndex) = True
        EditorSkill_DrawIcon()
    End Sub

    Friend Sub SkillEditorOk()
        Dim i As Integer

        For i = 1 To MAX_SKILLS
            If Skill_Changed(i) Then
                SendSaveSkill(i)
            End If
        Next

        Editor = -1
        ClearChanged_Skill()
        SendCloseEditor()
    End Sub

    Friend Sub SkillEditorCancel()
        Editor = -1
        ClearChanged_Skill()
        ClearSkills()
        SendCloseEditor()
    End Sub

    Friend Sub ClearChanged_Skill()
        For i = 1 To MAX_SKILLS
            Skill_Changed(i) = False
        Next
    End Sub

#End Region

#Region "Shop editor"
    Friend Sub ShopEditorInit()
        EditorIndex = frmEditor_Shop.lstIndex.SelectedIndex + 1

        With frmEditor_Shop
            .txtName.Text = Trim$(Shop(EditorIndex).Name)

            If Shop(EditorIndex).BuyRate > 0 Then
                .nudBuy.Value = Shop(EditorIndex).BuyRate
            Else
                .nudBuy.Value = 100
            End If

            .nudFace.Value = Shop(EditorIndex).Face
            If File.Exists(Paths.Graphics & "Faces\" & Shop(EditorIndex).Face & GfxExt) Then
                .picFace.BackgroundImage = Drawing.Image.FromFile(Paths.Graphics & "Faces\" & Shop(EditorIndex).Face & GfxExt)
            Else
                .picFace.BackgroundImage = Nothing
            End If

            .cmbItem.SelectedIndex = 0
            .cmbCostItem.SelectedIndex = 0
        End With

        UpdateShopTrade()
        Shop_Changed(EditorIndex) = True
    End Sub

    Friend Sub UpdateShopTrade()
        Dim i As Integer

        frmEditor_Shop.lstTradeItem.Items.Clear()

        For i = 1 To MAX_TRADES
            With Shop(EditorIndex).TradeItem(i)
                ' if none, show as none
                If .Item = 0 AndAlso .CostItem = 0 Then
                    frmEditor_Shop.lstTradeItem.Items.Add("Empty Trade Slot")
                Else
                    frmEditor_Shop.lstTradeItem.Items.Add(i & ": " & .ItemValue & "x " & Trim$(Item(.Item).Name) & " for " & .CostValue & "x " & Trim$(Item(.CostItem).Name))
                End If
            End With
        Next

        frmEditor_Shop.lstTradeItem.SelectedIndex = 0
    End Sub

    Friend Sub ShopEditorOk()
        Dim i As Integer

        For i = 1 To MAX_SHOPS
            If Shop_Changed(i) Then
                SendSaveShop(i)
            End If
        Next

        Editor = -1
        ClearChanged_Shop()
        SendCloseEditor()
    End Sub

    Friend Sub ShopEditorCancel()
        Editor = -1
        ClearChanged_Shop()
        ClearShops()
        SendCloseEditor()
    End Sub

    Friend Sub ClearChanged_Shop()
        For i = 1 To MAX_SHOPS
            Shop_Changed(i) = False
        Next
    End Sub

#End Region

#Region "Job Editor"
    Friend Sub JobEditorOk()
        For i = 1 To MAX_JOBS
            If Job_Changed(i) Then
                SendSaveJob(i)
            End If
        Next
        Editor = -1
        SendCloseEditor()
    End Sub

    Friend Sub JobEditorCancel()
        Editor = -1
        ClearChanged_Job()
        ClearJobs()
        SendCloseEditor()
    End Sub

    Friend Sub JobEditorInit()
        Dim i As Integer

        With frmEditor_Job
            EditorIndex = .lstIndex.SelectedIndex + 1

            .txtName.Text = Job(EditorIndex).Name
            .txtDescription.Text = Job(EditorIndex).Desc

            If Job(EditorIndex).MaleSprite = 0 Then Job(EditorIndex).MaleSprite = 1
            .nudMaleSprite.Value = Job(EditorIndex).MaleSprite
            If Job(EditorIndex).FemaleSprite = 0 Then Job(EditorIndex).FemaleSprite = 1
            .nudFemaleSprite.Value = Job(EditorIndex).FemaleSprite

            .cmbItems.SelectedIndex = 0

            For i = 1 To StatType.Count - 1
                If Job(EditorIndex).Stat(i) = 0 Then Job(EditorIndex).Stat(i) = 1
            Next

            .nudStrength.Value = Job(EditorIndex).Stat(StatType.Strength)
            .nudLuck.Value = Job(EditorIndex).Stat(StatType.Luck)
            .nudIntelligence.Value = Job(EditorIndex).Stat(StatType.Intelligence)
            .nudVitality.Value = Job(EditorIndex).Stat(StatType.Vitality)
            .nudSpirit.Value = Job(EditorIndex).Stat(StatType.Spirit)
            .nudBaseExp.Value = Job(EditorIndex).BaseExp

            If Job(EditorIndex).StartMap = 0 Then Job(EditorIndex).StartMap = 1
            .nudStartMap.Value = Job(EditorIndex).StartMap
            .nudStartX.Value = Job(EditorIndex).StartX
            .nudStartY.Value = Job(EditorIndex).StartY

            Job_Changed(EditorIndex) = True
            .DrawPreview()
        End With
    End Sub

    Friend Sub ClearChanged_Job()
       For i = 1 To MAX_JOBS
            Job_Changed(i) = False
        Next
    End Sub


#End Region

#Region "Item"

    Friend Sub ItemEditorInit()
        Dim i As Integer

        EditorIndex = frmEditor_Item.lstIndex.SelectedIndex + 1

        With Item(EditorIndex)
            frmEditor_Item.txtName.Text = Trim$(.Name)
            frmEditor_Item.txtDescription.Text = Trim$(.Description)

            If .Icon > frmEditor_Item.nudPic.Maximum Then .Icon = 0
            frmEditor_Item.nudPic.Value = .Icon
            If .Type > ItemType.Count - 1 Then .Type = 0
            frmEditor_Item.cmbType.SelectedIndex = .Type
            frmEditor_Item.cmbAnimation.SelectedIndex = .Animation

            If .ItemLevel = 0 Then .ItemLevel = 1
            frmEditor_Item.nudItemLvl.Value = .ItemLevel

            ' Type specific settings
            If (frmEditor_Item.cmbType.SelectedIndex = ItemType.Equipment) Then
                frmEditor_Item.fraEquipment.Visible = True
                frmEditor_Item.nudDamage.Value = .Data2
                frmEditor_Item.cmbTool.SelectedIndex = .Data3

                frmEditor_Item.cmbSubType.SelectedIndex = .SubType

                If .Speed < 1000 Then .Speed = 100
                If .Speed > frmEditor_Item.nudSpeed.Maximum Then .Speed = frmEditor_Item.nudSpeed.Maximum
                frmEditor_Item.nudSpeed.Value = .Speed

                frmEditor_Item.nudStrength.Value = .Add_Stat(StatType.Strength)
                frmEditor_Item.nudIntelligence.Value = .Add_Stat(StatType.Intelligence)
                frmEditor_Item.nudVitality.Value = .Add_Stat(StatType.Vitality)
                frmEditor_Item.nudLuck.Value = .Add_Stat(StatType.Luck)
                frmEditor_Item.nudSpirit.Value = .Add_Stat(StatType.Spirit)

                If .KnockBack = 1 Then
                    frmEditor_Item.chkKnockBack.Checked = True
                Else
                    frmEditor_Item.chkKnockBack.Checked = False
                End If
                frmEditor_Item.cmbKnockBackTiles.SelectedIndex = .KnockBackTiles

                If .Randomize = 1 Then
                    frmEditor_Item.chkRandomize.Checked = True
                Else
                    frmEditor_Item.chkRandomize.Checked = False
                End If

                frmEditor_Item.nudPaperdoll.Value = .Paperdoll

                If .SubType = EquipmentType.Weapon Then
                    frmEditor_Item.fraProjectile.Visible = True
                Else
                     frmEditor_Item.fraProjectile.Visible = False
                End If
            Else
                frmEditor_Item.fraEquipment.Visible = False
            End If

            If (frmEditor_Item.cmbType.SelectedIndex = ItemType.Consumable) Then
                frmEditor_Item.fraVitals.Visible = True
                frmEditor_Item.nudVitalMod.Value = .Data1
            Else
                frmEditor_Item.fraVitals.Visible = False
            End If

            If (frmEditor_Item.cmbType.SelectedIndex = ItemType.Skill) Then
                frmEditor_Item.fraSkill.Visible = True
                frmEditor_Item.cmbSkills.SelectedIndex = .Data1
            Else
                frmEditor_Item.fraSkill.Visible = False
            End If

            if (frmEditor_Item.cmbType.SelectedIndex = ItemType.Projectile) Then
                frmEditor_Item.fraProjectile.Visible = True
                frmEditor_Item.fraEquipment.Visible = True
            Elseif .Type <> ItemType.Equipment Then
                frmEditor_Item.fraProjectile.Visible = False
            End If

            If frmEditor_Item.cmbType.SelectedIndex = ItemType.CommonEvent Then
                frmEditor_Item.fraEvents.Visible = True
                frmEditor_Item.nudEvent.Value = .Data1
                frmEditor_Item.nudEventValue.Value = .Data2
            Else
                frmEditor_Item.fraEvents.Visible = False
            End If

            If (frmEditor_Item.cmbType.SelectedIndex = ItemType.Pet) Then
                frmEditor_Item.fraPet.Visible = True
                frmEditor_Item.cmbPet.SelectedIndex = .Data1
            Else
                frmEditor_Item.fraPet.Visible = False
            End If

            ' Projectile
            frmEditor_Item.cmbProjectile.SelectedIndex = .Projectile
            frmEditor_Item.cmbAmmo.SelectedIndex = .Ammo

            ' Basic requirements
            frmEditor_Item.cmbAccessReq.SelectedIndex = .AccessReq
            frmEditor_Item.nudLevelReq.Value = .LevelReq

            frmEditor_Item.nudStrReq.Value = .Stat_Req(StatType.Strength)
            frmEditor_Item.nudVitReq.Value = .Stat_Req(StatType.Vitality)
            frmEditor_Item.nudLuckReq.Value = .Stat_Req(StatType.Luck)
            frmEditor_Item.nudIntReq.Value = .Stat_Req(StatType.Intelligence)
            frmEditor_Item.nudSprReq.Value = .Stat_Req(StatType.Spirit)

            ' Build cmbJobReq
            frmEditor_Item.cmbJobReq.Items.Clear()
           For i = 1 To MAX_JOBS
                frmEditor_Item.cmbJobReq.Items.Add(Job(i).Name)
            Next

            frmEditor_Item.cmbJobReq.SelectedIndex = .JobReq
            ' Info
            frmEditor_Item.nudPrice.Value = .Price
            frmEditor_Item.cmbBind.SelectedIndex = .BindType
            frmEditor_Item.nudRarity.Value = .Rarity

            If .Stackable = 1 Then
                frmEditor_Item.chkStackable.Checked = True
            Else
                frmEditor_Item.chkStackable.Checked = False
            End If
        End With

        Item_Changed(EditorIndex) = True
        EditorItem_DrawIcon()
        EditorItem_DrawPaperdoll()
    End Sub

    Friend Sub ItemEditorCancel()
        Editor = -1
        ClearChangedItem()
        ClearItems()
        SendCloseEditor()
    End Sub

    Friend Sub ItemEditorOk()
        Dim i As Integer

        For i = 1 To MAX_ITEMS
            If Item_Changed(i) Then
                SendSaveItem(i)
            End If
        Next

        Editor = -1
        ClearChangedItem()
        SendCloseEditor()
    End Sub

#End Region
End Module