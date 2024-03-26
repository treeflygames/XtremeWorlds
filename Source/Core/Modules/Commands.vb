Public Module Commands
    Public Function GetPlayerLogin(index As Integer) As String
        GetPlayerLogin = Trim$(Accounts(index).Login)
    End Function

    Public Sub SetPlayerLogin(index As Integer, login As String)
        Accounts(index).Login = login.Trim
    End Sub

    Public Function GetPlayerPassword(index As Integer) As String
        GetPlayerPassword = Trim$(Accounts(index).Password)
    End Function

    Public Sub SetPlayerPassword(index As Integer, password As String)
        Accounts(index).Password = password.Trim
    End Sub

    Public Function GetPlayerMaxVital(index As Integer, Vital As VitalType) As Integer
        GetPlayerMaxVital = 0

        Select Case Vital
            Case VitalType.HP
                GetPlayerMaxVital = 100 + (Player(index).Level + (GetPlayerStat(index, StatType.Vitality) / 2)) * 2
            Case VitalType.MP
                GetPlayerMaxVital = 50 + (Player(index).Level + (GetPlayerStat(index, StatType.Intelligence) / 2)) * 2
            Case VitalType.SP
                GetPlayerMaxVital = 50 + (Player(index).Level + (GetPlayerStat(index, StatType.Spirit) / 2)) * 2
        End Select

    End Function

    Public Function GetPlayerStat(index As Integer, Stat As StatType) As Integer
        Dim x As Integer, i As Integer

        If index = 0 Then Exit Function

        x = Player(index).Stat(Stat)

        For i = 1 To EquipmentType.Count - 1
            If Player(index).Equipment(i) > 0 Then
                If Item(Player(index).Equipment(i)).Add_Stat(Stat) > 0 Then
                    x += Item(Player(index).Equipment(i)).Add_Stat(Stat)
                End If
            End If
        Next

        GetPlayerStat = x
    End Function

    Public Function GetPlayerAccess(index As Integer) As Integer
        GetPlayerAccess = Player(index).Access
    End Function

    Public Function GetPlayerX(index As Integer) As Integer
        GetPlayerX = Player(index).X
    End Function

    Public Function GetPlayerY(index As Integer) As Integer
        GetPlayerY = Player(index).Y
    End Function

    Public Function GetPlayerDir(index As Integer) As Integer
        GetPlayerDir = Player(index).Dir
    End Function

    Public Function GetPlayerPK(index As Integer) As Integer
        GetPlayerPK = Player(index).Pk
    End Function

    Public Sub SetPlayerVital(index As Integer, Vital As VitalType, Value As Integer)
        If index = 0 Then Exit Sub

        Player(index).Vital(Vital) = Value

        If GetPlayerVital(index, Vital) > GetPlayerMaxVital(index, Vital) Then
            Player(index).Vital(Vital) = GetPlayerMaxVital(index, Vital)
        End If

        If GetPlayerVital(index, Vital) < 0 Then
            Player(index).Vital(Vital) = 0
        End If
    End Sub

    Public Function IsDirBlocked(ByRef Blockvar As Byte, ByRef Dir As Byte) As Boolean
        Return Blockvar And (2 ^ Dir)
    End Function

    Public Function GetPlayerNextLevel(index As Integer) As Integer
        GetPlayerNextLevel = (50 / 3) * ((GetPlayerLevel(index) + 1) ^ 3 - (6 * (GetPlayerLevel(index) + 1) ^ 2) + 17 * (GetPlayerLevel(index) + 1) - 12)
    End Function

    Public Function GetPlayerExp(index As Integer) As Integer
        GetPlayerExp = Player(index).Exp
    End Function

    Public Function GetPlayerRawStat(index As Integer, Stat As StatType) As Integer
        GetPlayerRawStat = Player(index).Stat(Stat)
    End Function

    Public Sub SetPlayerGatherSkillLvl(index As Integer, SkillSlot As Integer, lvl As Integer)
        Player(index).GatherSkills(SkillSlot).SkillLevel = lvl
    End Sub

    Public Sub SetPlayerGatherSkillExp(index As Integer, SkillSlot As Integer, Exp As Integer)
        Player(index).GatherSkills(SkillSlot).SkillCurExp = Exp
    End Sub

    Public Sub SetPlayerGatherSkillMaxExp(index As Integer, SkillSlot As Integer, MaxExp As Integer)
        Player(index).GatherSkills(SkillSlot).SkillNextLvlExp = MaxExp
    End Sub

    Public Function GetResourceSkillName(skillNum As ResourceType) As String
        Select Case skillNum
            Case ResourceType.Herbing
                GetResourceSkillName = "Herbalism"
            Case ResourceType.Woodcutting
                GetResourceSkillName = "Woodcutting"
            Case ResourceType.Mining
                GetResourceSkillName = "Mining"
            Case ResourceType.Fishing
                GetResourceSkillName = "Fishing"
        End Select
    End Function

    Public Function GetSkillNextLevel(index As Integer, SkillSlot As Integer) As Integer
        GetSkillNextLevel = (50 / 3) * ((GetPlayerGatherSkillLvl(index, SkillSlot) + 1) ^ 3 - (6 * (GetPlayerGatherSkillLvl(index, SkillSlot) + 1) ^ 2) + 17 * (GetPlayerGatherSkillLvl(index, SkillSlot) + 1) - 12)
    End Function

    Public Function IsPlaying(index As Integer) As Boolean
        IsPlaying = False

        ' if the player doesn't exist, the name will equal 0
        If Len(GetPlayerName(index)) > 0 Then
            IsPlaying = True
        End If
    End Function

    Public Function GetPlayerName(index As Integer) As String
        GetPlayerName = Trim$(Player(index).Name)
    End Function

    Public Function GetPlayerGatherSkillLvl(index As Integer, skillSlot As Integer) As Integer
        GetPlayerGatherSkillLvl = Player(index).GatherSkills(skillSlot).SkillLevel
    End Function

    Public Function GetPlayerGatherSkillExp(index As Integer, skillSlot As Integer) As Integer
        GetPlayerGatherSkillExp = Player(index).GatherSkills(skillSlot).SkillCurExp
    End Function

    Public Function GetPlayerGatherSkillMaxExp(index As Integer, skillSlot As Integer) As Integer
        GetPlayerGatherSkillMaxExp = Player(index).GatherSkills(skillSlot).SkillNextLvlExp
    End Function

    Public Sub SetPlayerMap(index As Integer, mapNum As Integer)
        Player(index).Map = mapNum
    End Sub

    Public Function GetPlayerInvItemNum(index As Integer, invslot As Integer) As Integer
        GetPlayerInvItemNum = Player(index).Inv(invslot).Num
    End Function

    Public Sub SetPlayerName(index As Integer, name As String)
        Player(index).Name = name
    End Sub

    Public Sub SetPlayerJob(index As Integer, jobNum As Integer)
        Player(index).Job = jobNum
    End Sub

    Public Sub SetPlayerPoints(index As Integer, points As Integer)
        Player(index).Points = points
    End Sub

    Public Sub SetPlayerStat(index As Integer, stat As StatType, value As Integer)
        If value > MAX_POINTS Then value = MAX_POINTS
        Player(index).Stat(stat) = value
    End Sub

    Public Sub SetPlayerInvItemNum(index As Integer, invslot As Integer, itemnum As Integer)
        Player(index).Inv(invslot).Num = itemnum
    End Sub

    Public Function GetPlayerInvItemValue(index As Integer, invslot As Integer) As Integer
        GetPlayerInvItemValue = Player(index).Inv(invslot).Value
    End Function

    Public Sub SetPlayerInvItemValue(index As Integer, invslot As Integer, itemValue As Integer)
        Player(index).Inv(invslot).Value = itemValue
    End Sub

    Public Function GetPlayerPoints(index As Integer) As Integer
        GetPlayerPoints = Player(index).Points
    End Function

    Public Sub SetPlayerAccess(index As Integer, access As Integer)
        Player(index).Access = access
    End Sub

    Public Sub SetPlayerPk(index As Integer, pk As Integer)
        Player(index).Pk = pk
    End Sub

    Public Sub SetPlayerX(index As Integer, x As Integer)
        Player(index).X = x
    End Sub

    Public Sub SetPlayerY(index As Integer, y As Integer)
        Player(index).Y = y
    End Sub

    Public Sub SetPlayerSprite(index As Integer, sprite As Integer)
        Player(index).Sprite = sprite
    End Sub

    Public Sub SetPlayerExp(index As Integer, exp As Integer)
        Player(index).Exp = exp
    End Sub

    Public Sub SetPlayerLevel(index As Integer, level As Integer)
        Player(index).Level = level
    End Sub

    Public Sub SetPlayerDir(index As Integer, dir As Integer)
        Player(index).Dir = dir
    End Sub

    Public Function GetPlayerVital(index As Integer, vital As VitalType) As Integer
        If index = 0 Then Exit Function
        GetPlayerVital = Player(index).Vital(vital)
    End Function

    Function GetPlayerSprite(index As Integer) As Integer
        GetPlayerSprite = Player(index).Sprite
    End Function

    Public Function GetPlayerJob(index As Integer) As Integer
        GetPlayerJob = Player(index).Job
    End Function

    Public Function GetPlayerMap(index As Integer) As Integer
        GetPlayerMap = Player(index).Map
    End Function

    Function GetPlayerLevel(index As Integer) As Integer
        GetPlayerLevel = Player(index).Level
    End Function

    Public  Function GetPlayerEquipment(index As Integer, equipmentSlot As EquipmentType) As Integer
        GetPlayerEquipment = Player(index).Equipment(equipmentSlot)
    End Function

    Public Sub SetPlayerEquipment(index As Integer, invNum As Integer, equipmentSlot As EquipmentType)
        Player(index).Equipment(equipmentSlot) = invNum
    End Sub

    Public Function IsEditorLocked(index As Integer, id As Integer) As String
        For i = 1 To MAX_PLAYERS
            If IsPlaying(i) Then
                If i <> index Then
                    if TempPlayer(i).Editor = id Then
                        IsEditorLocked = GetPlayerName(i)
                        Exit Function
                    End if
                End If
            End If 
        Next

        IsEditorLocked = ""
    End Function

    Public Function FindOpenSkill(index As Integer) As Integer
        Dim i As Integer

        FindOpenSkill = 0

        For i = 1 To MAX_PLAYER_SKILLS

            If GetPlayerSkill(index, i) = 0 Then
                FindOpenSkill = i
                Exit Function
            End If

        Next

    End Function

    Public Function GetPlayerSkill(index As Integer, Skillslot As Integer) As Integer
        GetPlayerSkill = Player(index).Skill(Skillslot).Num
    End Function

    Public Function GetPlayerSkillCD(index As Integer, SkillSlot As Integer) As Integer
        GetPlayerSkillCD = Player(index).Skill(SkillSlot).CD
    End Function

    Public Sub SetPlayerSkillCD(index As Integer, SkillSlot As Integer, Value As Integer)
        Player(index).Skill(SkillSlot).CD = Value
    End Sub

    Public Function HasSkill(index As Integer, Skillnum As Integer) As Boolean
        Dim i As Integer

        HasSkill = 0

        For i = 1 To MAX_PLAYER_SKILLS

            If GetPlayerSkill(index, i) = Skillnum Then
                HasSkill = True
                Exit Function
            End If

        Next

    End Function

    Public Sub SetPlayerSkill(index As Integer, Skillslot As Integer, Skillnum As Integer)
        Player(index).Skill(Skillslot).Num = Skillnum
    End Sub

End Module
