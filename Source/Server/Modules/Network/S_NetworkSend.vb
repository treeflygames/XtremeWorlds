Imports Mirage.Sharp.Asfw
Imports Mirage.Sharp.Asfw.IO
Imports Core
Imports Npgsql.Replication.PgOutput
Imports System.Buffers

Module S_NetworkSend

    Sub AlertMsg(ByVal index As Long, ByVal menuNo As Integer, Optional ByVal menuReset As Integer = 0, Optional ByVal kick As Boolean = True)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(Packets.ServerPackets.SAlertMsg)
        buffer.WriteInt32(menuNo)
        buffer.WriteInt32(menuReset)
        If kick Then
            buffer.WriteInt32(1)
        Else
            buffer.WriteInt32(0)
        End If
        ClearAccount(index)
        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub GlobalMsg(msg As String)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SGlobalMsg)
        buffer.WriteString((msg))
        SendDataToAll(buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub PlayerMsg(index As Integer, msg As String, color As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SPlayerMsg)
        buffer.WriteString((msg))
        buffer.WriteInt32(color)

        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendPlayerChars(ByVal index As Long)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SPlayerChars)

        ' loop through each character. clear, load, add. repeat.
        For i = 1 To MAX_CHARS
            LoadCharacter(index, i)

            buffer.WriteString(Trim$(Player(index).Name))
            buffer.WriteInt32(Player(index).Sprite)
            buffer.WriteInt32(Player(index).Access)
            buffer.WriteInt32(Player(index).Job)

            ClearCharacter(index)
        Next

        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendUpdateJob(index As Integer, jobNum As Integer)
        Dim i As Integer, n As Integer
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SUpdateJob)
        buffer.WriteInt32(jobNum)

        buffer.WriteString((Job(jobNum).Name))
        buffer.WriteString((Job(jobNum).Desc))

        buffer.WriteInt32(Job(jobNum).MaleSprite)
        buffer.WriteInt32(Job(jobNum).FemaleSprite)

        For q = 1 To StatType.Count - 1
            buffer.WriteInt32(Job(jobNum).Stat(q))
        Next

        For q = 1 To 5
            buffer.WriteInt32(Job(jobNum).StartItem(q))
            buffer.WriteInt32(Job(jobNum).StartValue(q))
        Next

        buffer.WriteInt32(Job(jobNum).StartMap)
        buffer.WriteByte(Job(jobNum).StartX)
        buffer.WriteByte(Job(jobNum).StartY)
        buffer.WriteInt32(Job(jobNum).BaseExp)
 
        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendCloseTrade(index As Integer)
        Dim buffer As New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SCloseTrade)
        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendExp(index As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SPlayerEXP)
        buffer.WriteInt32(index)
        buffer.WriteInt32(GetPlayerExp(index))
        buffer.WriteInt32(GetPlayerNextLevel(index))

        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendLoginOK(index As Integer)
        Dim Buffer As New ByteStream(4)

        Buffer.WriteInt32(ServerPackets.SLoginOK)
        Buffer.WriteInt32(index)
        Socket.SendDataTo(index, Buffer.Data, Buffer.Head)

        Buffer.Dispose()
    End Sub

    Sub SendInGame(index As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SInGame)
        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendJobs(index As Integer)
        Dim i As Integer
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SJobData)

        For i = 1 To MAX_JOBS
            buffer.WriteBlock(JobData(i))
        Next

        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendJobToAll(jobNum As Integer)
        Dim i As Integer
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SJobData)
        buffer.WriteBlock(JobData(jobNum))
        SendDataToAll(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendUpdateJobTo(index As Integer, jobNum As Integer)
        Dim buffer As ByteStream
        buffer = New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SUpdateJob)

        buffer.WriteBlock(JobData(jobNum))

        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendUpdateJobToAll(jobNum As Integer)
        Dim buffer As ByteStream
        buffer = New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SUpdateJob)

        buffer.WriteBlock(JobData(jobNum))

        SendDataToAll(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendInventory(index As Integer)
        Dim i As Integer, n As Integer
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SPlayerInv)

        For i = 1 To MAX_INV
            buffer.WriteInt32(GetPlayerInvItemNum(index, i))
            buffer.WriteInt32(GetPlayerInvItemValue(index, i))
        Next

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendLeftMap(index As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SLeftMap)
        buffer.WriteInt32(index)
        SendDataToAllBut(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendLeftGame(index As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SLeftGame)

        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendMapEquipment(index As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SMapWornEq)
        buffer.WriteInt32(index)
        buffer.WriteInt32(GetPlayerEquipment(index, EquipmentType.Armor))
        buffer.WriteInt32(GetPlayerEquipment(index, EquipmentType.Weapon))
        buffer.WriteInt32(GetPlayerEquipment(index, EquipmentType.Helmet))
        buffer.WriteInt32(GetPlayerEquipment(index, EquipmentType.Shield))
        buffer.WriteInt32(GetPlayerEquipment(index, EquipmentType.Shoes))
        buffer.WriteInt32(GetPlayerEquipment(index, EquipmentType.Gloves))

        SendDataToMap(GetPlayerMap(index), buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendMapEquipmentTo(PlayerNum As Integer, index As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SMapWornEq)
        buffer.WriteInt32(PlayerNum)
        buffer.WriteInt32(GetPlayerEquipment(PlayerNum, EquipmentType.Armor))
        buffer.WriteInt32(GetPlayerEquipment(PlayerNum, EquipmentType.Weapon))
        buffer.WriteInt32(GetPlayerEquipment(PlayerNum, EquipmentType.Helmet))
        buffer.WriteInt32(GetPlayerEquipment(PlayerNum, EquipmentType.Shield))
        buffer.WriteInt32(GetPlayerEquipment(index, EquipmentType.Shoes))
        buffer.WriteInt32(GetPlayerEquipment(index, EquipmentType.Gloves))

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendShops(index As Integer)
        Dim i As Integer

        For i = 1 To MAX_SHOPS
            If Shop(i).Name.Trim.Length > 0 Then
                SendUpdateShopTo(index, i)
            End If
        Next

    End Sub

    Sub SendUpdateShopTo(index As Integer, shopNum As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SUpdateShop)

        buffer.WriteInt32(shopNum)

        buffer.WriteInt32(Shop(shopNum).BuyRate)
        buffer.WriteString((Shop(shopNum).Name.Trim))
        buffer.WriteInt32(Shop(shopNum).Face)

        For i = 1 To MAX_TRADES
            buffer.WriteInt32(Shop(shopNum).TradeItem(i).CostItem)
            buffer.WriteInt32(Shop(shopNum).TradeItem(i).CostValue)
            buffer.WriteInt32(Shop(shopNum).TradeItem(i).Item)
            buffer.WriteInt32(Shop(shopNum).TradeItem(i).ItemValue)
        Next

        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendUpdateShopToAll(shopNum As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SUpdateShop)

        buffer.WriteInt32(shopNum)
        buffer.WriteInt32(Shop(shopNum).BuyRate)
        buffer.WriteString(Shop(shopNum).Name.Trim)
        buffer.WriteInt32(Shop(shopNum).Face)

        For i = 1 To MAX_TRADES
            buffer.WriteInt32(Shop(shopNum).TradeItem(i).CostItem)
            buffer.WriteInt32(Shop(shopNum).TradeItem(i).CostValue)
            buffer.WriteInt32(Shop(shopNum).TradeItem(i).Item)
            buffer.WriteInt32(Shop(shopNum).TradeItem(i).ItemValue)
        Next

        SendDataToAll(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendSkills(index As Integer)
        Dim i As Integer

        For i = 1 To MAX_SKILLS

            If Skill(i).Name.Trim.Length > 0 Then
                SendUpdateSkillTo(index, i)
            End If

        Next

    End Sub

    Sub SendUpdateSkillTo(index As Integer, skillnum As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SUpdateSkill)
        buffer.WriteInt32(skillnum)
        buffer.WriteInt32(Skill(skillnum).AccessReq)
        buffer.WriteInt32(Skill(skillnum).AoE)
        buffer.WriteInt32(Skill(skillnum).CastAnim)
        buffer.WriteInt32(Skill(skillnum).CastTime)
        buffer.WriteInt32(Skill(skillnum).CdTime)
        buffer.WriteInt32(Skill(skillnum).JobReq)
        buffer.WriteInt32(Skill(skillnum).Dir)
        buffer.WriteInt32(Skill(skillnum).Duration)
        buffer.WriteInt32(Skill(skillnum).Icon)
        buffer.WriteInt32(Skill(skillnum).Interval)
        buffer.WriteInt32(Skill(skillnum).IsAoE)
        buffer.WriteInt32(Skill(skillnum).LevelReq)
        buffer.WriteInt32(Skill(skillnum).Map)
        buffer.WriteInt32(Skill(skillnum).MpCost)
        buffer.WriteString(Skill(skillnum).Name.Trim)
        buffer.WriteInt32(Skill(skillnum).Range)
        buffer.WriteInt32(Skill(skillnum).SkillAnim)
        buffer.WriteInt32(Skill(skillnum).StunDuration)
        buffer.WriteInt32(Skill(skillnum).Type)
        buffer.WriteInt32(Skill(skillnum).Vital)
        buffer.WriteInt32(Skill(skillnum).X)
        buffer.WriteInt32(Skill(skillnum).Y)

        'projectiles
        buffer.WriteInt32(Skill(skillnum).IsProjectile)
        buffer.WriteInt32(Skill(skillnum).Projectile)

        buffer.WriteInt32(Skill(skillnum).KnockBack)
        buffer.WriteInt32(Skill(skillnum).KnockBackTiles)

        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendUpdateSkillToAll(skillnum As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SUpdateSkill)
        buffer.WriteInt32(skillnum)
        buffer.WriteInt32(Skill(skillnum).AccessReq)
        buffer.WriteInt32(Skill(skillnum).AoE)
        buffer.WriteInt32(Skill(skillnum).CastAnim)
        buffer.WriteInt32(Skill(skillnum).CastTime)
        buffer.WriteInt32(Skill(skillnum).CdTime)
        buffer.WriteInt32(Skill(skillnum).JobReq)
        buffer.WriteInt32(Skill(skillnum).Dir)
        buffer.WriteInt32(Skill(skillnum).Duration)
        buffer.WriteInt32(Skill(skillnum).Icon)
        buffer.WriteInt32(Skill(skillnum).Interval)
        buffer.WriteInt32(Skill(skillnum).IsAoE)
        buffer.WriteInt32(Skill(skillnum).LevelReq)
        buffer.WriteInt32(Skill(skillnum).Map)
        buffer.WriteInt32(Skill(skillnum).MpCost)
        buffer.WriteString(Skill(skillnum).Name.Trim)
        buffer.WriteInt32(Skill(skillnum).Range)
        buffer.WriteInt32(Skill(skillnum).SkillAnim)
        buffer.WriteInt32(Skill(skillnum).StunDuration)
        buffer.WriteInt32(Skill(skillnum).Type)
        buffer.WriteInt32(Skill(skillnum).Vital)
        buffer.WriteInt32(Skill(skillnum).X)
        buffer.WriteInt32(Skill(skillnum).Y)

        buffer.WriteInt32(Skill(skillnum).IsProjectile)
        buffer.WriteInt32(Skill(skillnum).Projectile)

        buffer.WriteInt32(Skill(skillnum).KnockBack)
        buffer.WriteInt32(Skill(skillnum).KnockBackTiles)

        SendDataToAll(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendStats(index As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SPlayerStats)
        buffer.WriteInt32(index)

        For i = 1 To StatType.Count - 1
            buffer.WriteInt32(GetPlayerStat(index, i))
        Next

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendVitals(index As Integer)
        For i = 1 To VitalType.Count - 1
            SendVital(index, i)
        Next
    End Sub

    Sub SendVital(index As Integer, Vital As VitalType)
        Dim buffer As New ByteStream(4)

        ' Get our packet type.
        Select Case Vital
            Case VitalType.HP
                buffer.WriteInt32(ServerPackets.SPlayerHP)
            Case VitalType.MP
                buffer.WriteInt32(ServerPackets.SPlayerMP)
            Case VitalType.SP
                buffer.WriteInt32(ServerPackets.SPlayerSP)
        End Select

        ' Set and send related data.
        buffer.WriteInt32(GetPlayerVital(index, Vital))
        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendWelcome(index As Integer)

        ' Send them welcome
        If Types.Settings.Welcome.Trim.Length > 0 Then
            PlayerMsg(index, Types.Settings.Welcome, ColorType.BrightCyan)
        End If

        ' Send whos online
        SendWhosOnline(index)
    End Sub

    Sub SendWhosOnline(index As Integer)
        Dim s As String = ""
        Dim n As Integer
        Dim i As Integer

        If GetPlayerAccess(index) < AdminType.Moderator Then Exit Sub

        For i = 1 To Socket.HighIndex()

            If i <> index Then
                s = s & GetPlayerName(i) & ", "
                n = n + 1
            End If

        Next

        If n = 0 Then
            s = "There are no other players online."
        Else
            s = Mid$(s, 1, Len(s) - 2)
            s = "There are " & n & " other players online: " & s & "."
        End If

        PlayerMsg(index, s, ColorType.White)
    End Sub

    Sub SendWornEquipment(index As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SPlayerWornEq)

        For i = 1 To EquipmentType.Count - 1
            buffer.WriteInt32(GetPlayerEquipment(index, i))
        Next

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendMapData(index As Integer, mapNum As Integer, SendMap As Boolean)
        Dim buffer As New ByteStream(4)
        Dim data() As Byte

        If SendMap Then
            buffer.WriteInt32(1)
            buffer.WriteInt32(mapNum)
            buffer.WriteString((Map(mapNum).Name.Trim))
            buffer.WriteString((Map(mapNum).Music.Trim))
            buffer.WriteInt32(Map(mapNum).Revision)
            buffer.WriteInt32(Map(mapNum).Moral)
            buffer.WriteInt32(Map(mapNum).Tileset)
            buffer.WriteInt32(Map(mapNum).Up)
            buffer.WriteInt32(Map(mapNum).Down)
            buffer.WriteInt32(Map(mapNum).Left)
            buffer.WriteInt32(Map(mapNum).Right)
            buffer.WriteInt32(Map(mapNum).BootMap)
            buffer.WriteInt32(Map(mapNum).BootX)
            buffer.WriteInt32(Map(mapNum).BootY)
            buffer.WriteInt32(Map(mapNum).MaxX)
            buffer.WriteInt32(Map(mapNum).MaxY)
            buffer.WriteInt32(Map(mapNum).Weather)
            buffer.WriteInt32(Map(mapNum).Fog)
            buffer.WriteInt32(Map(mapNum).WeatherIntensity)
            buffer.WriteInt32(Map(mapNum).FogOpacity)
            buffer.WriteInt32(Map(mapNum).FogSpeed)
            buffer.WriteInt32(Map(mapNum).MapTint)
            buffer.WriteInt32(Map(mapNum).MapTintR)
            buffer.WriteInt32(Map(mapNum).MapTintG)
            buffer.WriteInt32(Map(mapNum).MapTintB)
            buffer.WriteInt32(Map(mapNum).MapTintA)
            buffer.WriteByte(Map(mapNum).Panorama)
            buffer.WriteByte(Map(mapNum).Parallax)
            buffer.WriteByte(Map(mapNum).Brightness)
            buffer.WriteInt32(Map(mapNum).NoRespawn)
            buffer.WriteInt32(Map(mapNum).Indoors)
            buffer.WriteInt32(Map(mapNum).Shop)

            For i = 1 To MAX_MAP_NPCS
                buffer.WriteInt32(Map(mapNum).Npc(i))
            Next

            For X = 0 To Map(mapNum).MaxX
                For Y = 0 To Map(mapNum).MaxY
                    buffer.WriteInt32(Map(mapNum).Tile(X, Y).Data1)
                    buffer.WriteInt32(Map(mapNum).Tile(X, Y).Data2)
                    buffer.WriteInt32(Map(mapNum).Tile(X, Y).Data3)
                    buffer.WriteInt32(Map(mapNum).Tile(X, Y).Data1_2)
                    buffer.WriteInt32(Map(mapNum).Tile(X, Y).Data2_2)
                    buffer.WriteInt32(Map(mapNum).Tile(X, Y).Data3_2)
                    buffer.WriteInt32(Map(mapNum).Tile(X, Y).DirBlock)
                    For i = 1 To LayerType.Count - 1
                        buffer.WriteInt32(Map(mapNum).Tile(X, Y).Layer(i).Tileset)
                        buffer.WriteInt32(Map(mapNum).Tile(X, Y).Layer(i).X)
                        buffer.WriteInt32(Map(mapNum).Tile(X, Y).Layer(i).Y)
                        buffer.WriteInt32(Map(mapNum).Tile(X, Y).Layer(i).AutoTile)
                    Next
                    buffer.WriteInt32(Map(mapNum).Tile(X, Y).Type)
                    buffer.WriteInt32(Map(mapNum).Tile(X, Y).Type2)
                Next
            Next

            buffer.WriteInt32(Map(mapNum).EventCount)

            If Map(mapNum).EventCount > 0 Then
                For i = 0 To Map(mapNum).EventCount
                    With Map(mapNum).Events(i)
                        buffer.WriteString((.Name.Trim))
                        buffer.WriteByte(.Globals)
                        buffer.WriteInt32(.X)
                        buffer.WriteInt32(.Y)
                        buffer.WriteInt32(.PageCount)
                    End With

                    If Map(mapNum).Events(i).PageCount > 0 Then
                        For X = 0 To Map(mapNum).Events(i).PageCount
                            With Map(mapNum).Events(i).Pages(X)
                                buffer.WriteInt32(.ChkVariable)
                                buffer.WriteInt32(.Variableindex)
                                buffer.WriteInt32(.VariableCondition)
                                buffer.WriteInt32(.VariableCompare)
                                buffer.WriteInt32(.ChkSwitch)
                                buffer.WriteInt32(.Switchindex)
                                buffer.WriteInt32(.SwitchCompare)
                                buffer.WriteInt32(.ChkHasItem)
                                buffer.WriteInt32(.HasItemindex)
                                buffer.WriteInt32(.HasItemAmount)
                                buffer.WriteInt32(.ChkSelfSwitch)
                                buffer.WriteInt32(.SelfSwitchindex)
                                buffer.WriteInt32(.SelfSwitchCompare)
                                buffer.WriteByte(.GraphicType)
                                buffer.WriteInt32(.Graphic)
                                buffer.WriteInt32(.GraphicX)
                                buffer.WriteInt32(.GraphicY)
                                buffer.WriteInt32(.GraphicX2)
                                buffer.WriteInt32(.GraphicY2)
                                buffer.WriteByte(.MoveType)
                                buffer.WriteByte(.MoveSpeed)
                                buffer.WriteByte(.MoveFreq)
                                buffer.WriteInt32(.MoveRouteCount)
                                buffer.WriteInt32(.IgnoreMoveRoute)
                                buffer.WriteInt32(.RepeatMoveRoute)

                                If .MoveRouteCount > 0 Then
                                    For Y = 0 To .MoveRouteCount
                                        buffer.WriteInt32(.MoveRoute(Y).Index)
                                        buffer.WriteInt32(.MoveRoute(Y).Data1)
                                        buffer.WriteInt32(.MoveRoute(Y).Data2)
                                        buffer.WriteInt32(.MoveRoute(Y).Data3)
                                        buffer.WriteInt32(.MoveRoute(Y).Data4)
                                        buffer.WriteInt32(.MoveRoute(Y).Data5)
                                        buffer.WriteInt32(.MoveRoute(Y).Data6)
                                    Next
                                End If

                                buffer.WriteInt32(.WalkAnim)
                                buffer.WriteInt32(.DirFix)
                                buffer.WriteInt32(.WalkThrough)
                                buffer.WriteInt32(.ShowName)
                                buffer.WriteByte(.Trigger)
                                buffer.WriteInt32(.CommandListCount)
                                buffer.WriteByte(.Position)
                                buffer.WriteInt32(.QuestNum)
                            End With

                            If Map(mapNum).Events(i).Pages(X).CommandListCount > 0 Then
                                For Y = 0 To Map(mapNum).Events(i).Pages(X).CommandListCount
                                    buffer.WriteInt32(Map(mapNum).Events(i).Pages(X).CommandList(Y).CommandCount)
                                    buffer.WriteInt32(Map(mapNum).Events(i).Pages(X).CommandList(Y).ParentList)
                                    If Map(mapNum).Events(i).Pages(X).CommandList(Y).CommandCount > 0 Then
                                        For z = 0 To Map(mapNum).Events(i).Pages(X).CommandList(Y).CommandCount
                                            With Map(mapNum).Events(i).Pages(X).CommandList(Y).Commands(z)
                                                buffer.WriteByte(.Index)
                                                buffer.WriteString((.Text1.Trim))
                                                buffer.WriteString((.Text2.Trim))
                                                buffer.WriteString((.Text3.Trim))
                                                buffer.WriteString((.Text4.Trim))
                                                buffer.WriteString((.Text5.Trim))
                                                buffer.WriteInt32(.Data1)
                                                buffer.WriteInt32(.Data2)
                                                buffer.WriteInt32(.Data3)
                                                buffer.WriteInt32(.Data4)
                                                buffer.WriteInt32(.Data5)
                                                buffer.WriteInt32(.Data6)
                                                buffer.WriteInt32(.ConditionalBranch.CommandList)
                                                buffer.WriteInt32(.ConditionalBranch.Condition)
                                                buffer.WriteInt32(.ConditionalBranch.Data1)
                                                buffer.WriteInt32(.ConditionalBranch.Data2)
                                                buffer.WriteInt32(.ConditionalBranch.Data3)
                                                buffer.WriteInt32(.ConditionalBranch.ElseCommandList)
                                                buffer.WriteInt32(.MoveRouteCount)
                                                If .MoveRouteCount > 0 Then
                                                    For w = 0 To .MoveRouteCount
                                                        buffer.WriteInt32(.MoveRoute(w).Index)
                                                        buffer.WriteInt32(.MoveRoute(w).Data1)
                                                        buffer.WriteInt32(.MoveRoute(w).Data2)
                                                        buffer.WriteInt32(.MoveRoute(w).Data3)
                                                        buffer.WriteInt32(.MoveRoute(w).Data4)
                                                        buffer.WriteInt32(.MoveRoute(w).Data5)
                                                        buffer.WriteInt32(.MoveRoute(w).Data6)
                                                    Next
                                                End If
                                            End With
                                        Next
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            End If
        Else
            buffer.WriteInt32(0)
        End If

        For i = 1 To MAX_MAP_ITEMS
            buffer.WriteInt32(MapItem(mapNum, i).Num)
            buffer.WriteInt32(MapItem(mapNum, i).Value)
            buffer.WriteInt32(MapItem(mapNum, i).X)
            buffer.WriteInt32(MapItem(mapNum, i).Y)
        Next

        For i = 1 To MAX_MAP_NPCS
            buffer.WriteInt32(MapNPC(mapNum).Npc(i).Num)
            buffer.WriteInt32(MapNPC(mapNum).Npc(i).X)
            buffer.WriteInt32(MapNPC(mapNum).Npc(i).Y)
            buffer.WriteInt32(MapNPC(mapNum).Npc(i).Dir)
            buffer.WriteInt32(MapNPC(mapNum).Npc(i).Vital(VitalType.HP))
            buffer.WriteInt32(MapNPC(mapNum).Npc(i).Vital(VitalType.MP))
        Next

        If MapResource(GetPlayerMap(index)).ResourceCount > 0 Then
            buffer.WriteInt32(1)
            buffer.WriteInt32(MapResource(GetPlayerMap(index)).ResourceCount)

            For i = 0 To MapResource(GetPlayerMap(index)).ResourceCount
                buffer.WriteByte(MapResource(GetPlayerMap(index)).ResourceData(i).State)
                buffer.WriteInt32(MapResource(GetPlayerMap(index)).ResourceData(i).X)
                buffer.WriteInt32(MapResource(GetPlayerMap(index)).ResourceData(i).Y)
            Next
        Else
            buffer.WriteInt32(0)
        End If

        data = Compression.CompressBytes(buffer.ToArray)
        buffer = New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SMapData)
        buffer.WriteBlock(data)
        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendJoinMap(index As Integer)
        Dim i As Integer
        Dim data As Byte()

        ' Send all players on current map to index
        For i = i To Socket.HighIndex()
            If IsPlaying(i) Then
                If GetPlayerMap(i) = GetPlayerMap(index) Then
                    data = PlayerData(i)
                    Socket.SendDataTo(index, data, data.Length)
                End If
            End If
        Next

        ' Send index's player data to everyone on the map including himself
        data = PlayerData(index)
        SendDataToMapBut(index, GetPlayerMap(index), data, data.Length)
        SendVitals(index)
    End Sub

    Function PlayerData(index As Integer) As Byte()
        Dim buffer As New ByteStream(4), i As Integer

        buffer.WriteInt32(ServerPackets.SPlayerData)
        buffer.WriteInt32(index)
        buffer.WriteString(GetPlayerName(index))
        buffer.WriteInt32(GetPlayerJob(index))
        buffer.WriteInt32(GetPlayerLevel(index))
        buffer.WriteInt32(GetPlayerPoints(index))
        buffer.WriteInt32(GetPlayerSprite(index))
        buffer.WriteInt32(GetPlayerMap(index))
        buffer.WriteInt32(GetPlayerAccess(index))
        buffer.WriteInt32(GetPlayerPK(index))

        For i = 1 To StatType.Count - 1
            buffer.WriteInt32(GetPlayerStat(index, i))
        Next

        For i = 1 To ResourceType.Count - 1
            buffer.WriteInt32(GetPlayerGatherSkillLvl(index, i))
            buffer.WriteInt32(GetPlayerGatherSkillExp(index, i))
            buffer.WriteInt32(GetPlayerGatherSkillMaxExp(index, i))
        Next

        PlayerData = buffer.ToArray()

        buffer.Dispose()
    End Function

    Sub SendPlayerXY(index As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SPlayerXY)
        buffer.WriteInt32(GetPlayerX(index))
        buffer.WriteInt32(GetPlayerY(index))
        buffer.WriteInt32(GetPlayerDir(index))

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendPlayerMove(index As Integer, Movement As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SPlayerMove)
        buffer.WriteInt32(index)
        buffer.WriteInt32(GetPlayerX(index))
        buffer.WriteInt32(GetPlayerY(index))
        buffer.WriteInt32(GetPlayerDir(index))
        buffer.WriteInt32(Movement)

        SendDataToMapBut(index, GetPlayerMap(index), buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub MapMsg(mapNum As Integer, Msg As String, Color As Byte)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SMapMsg)
        buffer.WriteString((Msg.Trim))

        SendDataToMap(mapNum, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub AdminMsg(mapNum As Integer, Msg As String, Color As Byte)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SAdminMsg)
        buffer.WriteString((Msg.Trim))

        For i = 1 To Socket.HighIndex
            If GetPlayerAccess(i) >= AdminType.Moderator Then
                SendDataTo(i, buffer.Data, buffer.Head)
            End If
        Next

        buffer.Dispose()
    End Sub

    Sub SendActionMsg(mapNum As Integer, Message As String, Color As Integer, MsgType As Integer, X As Integer, Y As Integer, Optional PlayerOnlyNum As Integer = 0)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SActionMsg)
        buffer.WriteString((Message.Trim))
        buffer.WriteInt32(Color)
        buffer.WriteInt32(MsgType)
        buffer.WriteInt32(X)
        buffer.WriteInt32(Y)

        If PlayerOnlyNum > 0 Then
            Socket.SendDataTo(PlayerOnlyNum, buffer.Data, buffer.Head)
        Else
            SendDataToMap(mapNum, buffer.Data, buffer.Head)
        End If

        buffer.Dispose()
    End Sub

    Sub SayMsg_Map(mapNum As Integer, index As Integer, Message As String, SayColor As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SSayMsg)
        buffer.WriteString(GetPlayerName(index))
        buffer.WriteInt32(GetPlayerAccess(index))
        buffer.WriteInt32(GetPlayerPK(index))
        buffer.WriteString(Message.Trim)
        buffer.WriteString(("[Map]"))
        buffer.WriteInt32(SayColor)

        SendDataToMap(mapNum, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SayMsg_Global(index As Integer, Message As String, SayColor As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SSayMsg)
        buffer.WriteString(GetPlayerName(index))
        buffer.WriteInt32(GetPlayerAccess(index))
        buffer.WriteInt32(GetPlayerPK(index))
        buffer.WriteString(Message.Trim)
        buffer.WriteString(("[Global]"))
        buffer.WriteInt32(SayColor)

        SendDataToAll(buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendPlayerData(index As Integer)
        Dim data = PlayerData(index)
        SendDataToMap(GetPlayerMap(index), data, data.Length)
    End Sub

    Sub SendInventoryUpdate(index As Integer, InvSlot As Integer)
        Dim buffer As New ByteStream(4), n As Integer

        buffer.WriteInt32(ServerPackets.SPlayerInvUpdate)

        buffer.WriteInt32(InvSlot)

        buffer.WriteInt32(GetPlayerInvItemNum(index, InvSlot))
        buffer.WriteInt32(GetPlayerInvItemValue(index, InvSlot))

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendOpenShop(index As Integer, ShopNum As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SOpenShop)
        buffer.WriteInt32(ShopNum)
        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub ResetShopAction(index As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SResetShopAction)

        SendDataToAll(buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendBank(index As Integer)
        Dim buffer As New ByteStream(4)
        Dim i As Integer

        buffer.WriteInt32(ServerPackets.SBank)

        For i = 1 To MAX_BANK
            buffer.WriteInt32(Bank(index).Item(i).Num)
            buffer.WriteInt32(Bank(index).Item(i).Value)
        Next

        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendClearSkillBuffer(index As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SClearSkillBuffer)

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendClearTradeTimer(index As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SClearTradeTimer)
        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendTradeInvite(index As Integer, Tradeindex As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.STradeInvite)
        buffer.WriteInt32(Tradeindex)
        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendTrade(index As Integer, TradeTarget As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.STrade)
        buffer.WriteInt32(TradeTarget)

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendTradeUpdate(index As Integer, DataType As Byte)
        Dim buffer As New ByteStream(4)
        Dim i As Integer
        Dim tradeTarget As Integer
        Dim totalWorth As Integer

        tradeTarget = TempPlayer(index).InTrade

        buffer.WriteInt32(ServerPackets.STradeUpdate)
        buffer.WriteInt32(DataType)

        If DataType = 0 Then ' own inventory

            For i = 1 To MAX_INV
                buffer.WriteInt32(TempPlayer(index).TradeOffer(i).Num)
                buffer.WriteInt32(TempPlayer(index).TradeOffer(i).Value)

                ' add total worth
                If TempPlayer(index).TradeOffer(i).Num > 0 Then
                    ' currency?
                    If Item(TempPlayer(index).TradeOffer(i).Num).Type = ItemType.Currency Or Item(TempPlayer(index).TradeOffer(i).Num).Stackable = 1 Then
                        If TempPlayer(index).TradeOffer(i).Value = 0 Then TempPlayer(index).TradeOffer(i).Value = 1
                        totalWorth = totalWorth + (Item(GetPlayerInvItemNum(index, TempPlayer(index).TradeOffer(i).Num)).Price * TempPlayer(index).TradeOffer(i).Value)
                    Else
                        totalWorth = totalWorth + Item(GetPlayerInvItemNum(index, TempPlayer(index).TradeOffer(i).Num)).Price
                    End If
                End If
            Next
        ElseIf DataType = 1 Then ' other inventory

            For i = 1 To MAX_INV
                buffer.WriteInt32(GetPlayerInvItemNum(tradeTarget, TempPlayer(tradeTarget).TradeOffer(i).Num))
                buffer.WriteInt32(TempPlayer(tradeTarget).TradeOffer(i).Value)

                ' add total worth
                If GetPlayerInvItemNum(tradeTarget, TempPlayer(tradeTarget).TradeOffer(i).Num) > 0 Then
                    ' currency?
                    If Item(GetPlayerInvItemNum(tradeTarget, TempPlayer(tradeTarget).TradeOffer(i).Num)).Type = ItemType.Currency Or Item(GetPlayerInvItemNum(tradeTarget, TempPlayer(tradeTarget).TradeOffer(i).Num)).Stackable = 1 Then
                        If TempPlayer(tradeTarget).TradeOffer(i).Value = 0 Then TempPlayer(tradeTarget).TradeOffer(i).Value = 1
                        totalWorth = totalWorth + (Item(GetPlayerInvItemNum(tradeTarget, TempPlayer(tradeTarget).TradeOffer(i).Num)).Price * TempPlayer(tradeTarget).TradeOffer(i).Value)
                    Else
                        totalWorth = totalWorth + Item(GetPlayerInvItemNum(tradeTarget, TempPlayer(tradeTarget).TradeOffer(i).Num)).Price
                    End If
                End If
            Next
        End If

        ' send total worth of trade
        buffer.WriteInt32(totalWorth)

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendTradeStatus(index As Integer, Status As Byte)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.STradeStatus)
        buffer.WriteInt32(Status)
        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendStunned(index As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SStunned)
        buffer.WriteInt32(TempPlayer(index).StunDuration)

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendBlood(mapNum As Integer, X As Integer, Y As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SBlood)
        buffer.WriteInt32(X)
        buffer.WriteInt32(Y)

        SendDataToMap(mapNum, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendPlayerSkills(index As Integer)
        Dim i As Integer
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SSkills)

        For i = 1 To MAX_PLAYER_SKILLS
            buffer.WriteInt32(GetPlayerSkill(index, i))
        Next

        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendCooldown(index As Integer, Slot As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SCooldown)
        buffer.WriteInt32(Slot)

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendTarget(index As Integer, Target As Integer, TargetType As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.STarget)
        buffer.WriteInt32(Target)
        buffer.WriteInt32(TargetType)

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendMapReport(index As Integer)
        Dim buffer As New ByteStream(4), I As Integer

        buffer.WriteInt32(ServerPackets.SMapReport)

        For i = 1 To MAX_MAPS
            buffer.WriteString(Map(I).Name.Trim)
        Next

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendAdminPanel(index As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SAdmin)

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendMapNames(index As Integer)
        Dim buffer As New ByteStream(4), I As Integer

        buffer.WriteInt32(ServerPackets.SMapNames)

        For i = 1 To MAX_MAPS
            buffer.WriteString(Map(I).Name)
        Next

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendHotbar(index As Integer)
        Dim buffer As New ByteStream(4), i As Integer

        buffer.WriteInt32(ServerPackets.SHotbar)

        For i = 1 To MAX_HOTBAR
            buffer.WriteInt32(Player(index).Hotbar(i).Slot)
            buffer.WriteInt32(Player(index).Hotbar(i).SlotType)
        Next

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendCritical(index As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SCritical)

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendKeyPair(index As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SKeyPair)
        buffer.WriteString(EKeyPair.ExportKeyString(False).Trim)
        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendRightClick(index As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SrClick)

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendClassEditor(index As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SJobEditor)

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendEmote(index As Integer, Emote As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SEmote)

        buffer.WriteInt32(index)
        buffer.WriteInt32(Emote)

        SendDataToMap(GetPlayerMap(index), buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendChatBubble(mapNum As Integer, Target As Integer, TargetType As Integer, Message As String, Color As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SChatBubble)

        buffer.WriteInt32(Target)
        buffer.WriteInt32(TargetType)
        buffer.WriteString(Message.Trim)
        buffer.WriteInt32(Color)
        SendDataToMap(mapNum, buffer.Data, buffer.Head)

        buffer.Dispose()

    End Sub

    Sub SendPlayerAttack(index As Integer)
        Dim Buffer As New ByteStream(4)

        Buffer.WriteInt32(ServerPackets.SAttack)

        Buffer.WriteInt32(index)
        SendDataToMapBut(index, GetPlayerMap(index), Buffer.Data, Buffer.Head)
        Buffer.Dispose()
    End Sub

End Module