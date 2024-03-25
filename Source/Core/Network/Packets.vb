Public Module Packets

    ' Packets sent by client to server
    Public Enum ClientPackets
        None = 0
        CLogin
        CRegister
        CAddChar
        CUseChar
        CDelChar
        CSayMsg
        CBroadcastMsg
        CPlayerMsg
        CPlayerMove
        CPlayerDir
        CUseItem
        CAttack
        CPlayerInfoRequest
        CWarpMeTo
        CWarpToMe
        CWarpTo
        CSetSprite
        CGetStats
        CRequestNewMap
        CNeedMap
        CMapGetItem
        CMapDropItem
        CKickPlayer
        CBanList
        CBanDestroy
        CBanPlayer
        CRequestEditMap

        CSetAccess
        CWhosOnline
        CSetMotd
        CSearch
        CSkills
        CCast
        CQuit
        CSwapInvSlots
        CSwapSkillSlots

        CCheckPing
        CUnequip
        CRequestPlayerData
        CRequestItem
        CRequestNPC
        CRequestResource
        CSpawnItem
        CTrainStat

        CRequestAnimation
        CRequestSkill
        CRequestShop
        CRequestLevelUp
        CForgetSkill
        CCloseShop
        CBuyItem
        CSellItem
        CChangeBankSlots
        CDepositItem
        CWithdrawItem
        CCloseBank
        CAdminWarp

        CTradeInvite
        CTradeInviteAccept
        CAcceptTrade
        CDeclineTrade
        CTradeItem
        CUntradeItem

        CAdmin

        'quests
        CRequestQuests
        CQuestLogUpdate
        CPlayerHandleQuest
        CQuestReset

        'Hotbar
        CSetHotbarSlot
        CDeleteHotbarSlot
        CUseHotbarSlot

        'Events
        CEventChatReply
        CEvent
        CSwitchesAndVariables
        CRequestSwitchesAndVariables

        CRequestProjectiles
        CClearProjectile  

        'emotes
        CEmote

        'party
        CRequestParty
        CAcceptParty
        CDeclineParty
        CLeaveParty
        CPartyChatMsg

        'pets
        CRequestPets
        CSummonPet
        CPetMove
        CSetBehaviour
        CReleasePet
        CPetSkill
        CPetUseStatPoint
        CRequestPet

        CSkillLearn

        '*************************
        '***   EDITOR PACKETS  ***
        '*************************

        ' Mapper Packets
        CMapRespawn
        CMapReport
        CSaveMap

        ' ####################
        ' ### Dev+ Packets ###
        ' ####################

        'animations
        CRequestEditAnimation
        CSaveAnimation

        'job
        CRequestEditJob
        CSaveJob

        'items
        CRequestEditItem
        CSaveItem

        'npc's
        CRequestEditNpc
        CSaveNpc

        'pets
        CRequestEditPet
        CSavePet

        'projectiles
        CRequestEditProjectiles
        CSaveProjectile

        'quests
        CRequestEditQuest
        CSaveQuest

        'resources
        CRequestEditResource
        CSaveResource

        'shops
        CRequestEditShop
        CSaveShop

        'skills
        CRequestEditSkill
        CSaveSkill

        CCloseEditor

        ' Make sure COUNT is below everything else
        Count
    End Enum

    ' Packets sent by server to client
    Public Enum ServerPackets
        None = 0
        SAlertMsg
        SKeyPair
        SLoginOK
        SPlayerChars
        SNewCharJob
        SJobData
        SInGame
        SPlayerInv
        SPlayerInvUpdate
        SPlayerWornEq
        SPlayerHP
        SPlayerMP
        SPlayerSP
        SPlayerStats
        SPlayerData
        SPlayerMove
        SNpcMove
        SPlayerDir
        SNpcDir
        SPlayerXY
        SAttack
        SNpcAttack
        SCheckForMap
        SMapData
        SMapItemData
        SMapNpcData
        SMapNpcUpdate
        SMapDone
        SGlobalMsg
        SAdminMsg
        SPlayerMsg
        SMapMsg
        SSpawnItem
        SItemEditor
        SUpdateItem
        SREditor
        SSpawnNpc
        SNpcDead
        SNpcEditor
        SUpdateNpc
        SEditMap
        SShopEditor
        SUpdateShop
        SSkillEditor
        SUpdateSkill
        SSkills
        SLeftMap
        SMapResource
        SResourceEditor
        SUpdateResource
        SSendPing
        SActionMsg
        SPlayerEXP
        SBlood
        SAnimationEditor
        SUpdateAnimation
        SAnimation
        SMapNpcVitals
        SCooldown
        SClearSkillBuffer
        SSayMsg
        SOpenShop
        SResetShopAction
        SStunned
        SMapWornEq
        SBank
        SLeftGame

        SClearTradeTimer
        STradeInvite
        STrade
        SCloseTrade
        STradeUpdate
        STradeStatus

        SGameData
        SMapReport
        STarget
        SAdmin
        SMapNames
        SCritical
        SrClick

        'quests
        SQuestEditor
        SUpdateQuest
        SPlayerQuest
        SPlayerQuests
        SQuestMessage

        'hotbar
        SHotbar

        'Events
        SSpawnEvent
        SEventMove
        SEventDir
        SEventChat
        SEventStart
        SEventEnd
        SPlayBGM
        SPlaySound
        SFadeoutBGM
        SStopSound
        SSwitchesAndVariables
        SMapEventData
        SChatBubble
        SSpecialEffect
        SPic
        SHoldPlayer

        SProjectileEditor
        SUpdateProjectile
        SMapProjectile

        'Class Editor
        SJobEditor
        SUpdateJob

        'emotes
        SEmote

        'Parties
        SPartyInvite
        SPartyUpdate
        SPartyVitals

        'pets
        SPetEditor
        SUpdatePet
        SUpdatePlayerPet
        SPetMove
        SPetDir
        SPetVital
        SClearPetSkillBuffer
        SPetAttack
        SPetXY
        SPetExp

        STime
        SClock

        ' Make sure COUNT is below everything else
        COUNT
    End Enum

End Module