
Imports Core
Imports Mirage.Sharp.Asfw
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Friend Module S_Resource

#Region "Database"

    Sub SaveResource(resourceNum As Integer)
        Dim json As String = JsonConvert.SerializeObject(Resource(resourceNum)).ToString()

        If RowExists(resourceNum, "resource")
            UpdateRow(resourceNum, json, "resource", "data")
        Else
            InsertRow(resourceNum, json, "resource")
        End If
    End Sub

    Sub LoadResources()
        Dim i As Integer

        For i = 1 To MAX_RESOURCES
            LoadResource(i)
        Next

    End Sub

    Sub LoadResource(resourceNum As Integer)
        Dim data As JObject

        data = SelectRow(resourceNum, "resource", "data")

        If data Is Nothing Then
            ClearResource(resourceNum)
            Exit Sub
        End If

        Dim resourceData = JObject.FromObject(data).toObject(Of Types.ResourceStruct)()
        Resource(resourceNum) = resourceData
    End Sub

    Sub ClearResource(index As Integer)
        Resource(index).Name = ""
        Resource(index).EmptyMessage = ""
        Resource(index).SuccessMessage = ""
    End Sub

    Sub ClearResources()
        ReDim MapResource(MAX_MAPS)
        ReDim MapResource(MAX_MAPS).ResourceData(MAX_RESOURCES)

        For i = 1 To MAX_RESOURCES
            ClearResource(i)
        Next
    End Sub

    Friend Sub CacheResources(mapNum As Integer)
        Dim x As Integer, y As Integer, Resource_Count As Integer

        For X = 0 To Map(mapNum).MaxX
            For Y = 0 To Map(mapNum).MaxY

                If Map(mapNum).Tile(x, y).Type = TileType.Resource Or Map(mapNum).Tile(x, y).Type2 = TileType.Resource Then
                    Resource_Count += 1
                    ReDim Preserve MapResource(mapNum).ResourceData(Resource_Count)
                    MapResource(mapNum).ResourceData(Resource_Count).X = x
                    MapResource(mapNum).ResourceData(Resource_Count).Y = y
                    MapResource(mapNum).ResourceData(Resource_Count).Health = Resource(Map(mapNum).Tile(x, y).Data1).Health
                End If

            Next
        Next

        MapResource(mapNum).ResourceCount = Resource_Count
    End Sub

    Function ResourcesData() As Byte()
        Dim buffer As New ByteStream(4)
        For i = 1 To MAX_RESOURCES
            If Not Len(Trim$(Resource(i).Name)) > 0 Then Continue For
            buffer.WriteBlock(ResourceData(i))
        Next
        Return buffer.ToArray
    End Function

    Function ResourceData(ResourceNum As Integer) As Byte()
        Dim buffer As New ByteStream(4)
        buffer.WriteInt32(ResourceNum)
        buffer.WriteInt32(Resource(ResourceNum).Animation)
        buffer.WriteString((Resource(ResourceNum).EmptyMessage))
        buffer.WriteInt32(Resource(ResourceNum).ExhaustedImage)
        buffer.WriteInt32(Resource(ResourceNum).Health)
        buffer.WriteInt32(Resource(ResourceNum).ExpReward)
        buffer.WriteInt32(Resource(ResourceNum).ItemReward)
        buffer.WriteString((Resource(ResourceNum).Name))
        buffer.WriteInt32(Resource(ResourceNum).ResourceImage)
        buffer.WriteInt32(Resource(ResourceNum).ResourceType)
        buffer.WriteInt32(Resource(ResourceNum).RespawnTime)
        buffer.WriteString((Resource(ResourceNum).SuccessMessage))
        buffer.WriteInt32(Resource(ResourceNum).LvlRequired)
        buffer.WriteInt32(Resource(ResourceNum).ToolRequired)
        buffer.WriteInt32(Resource(ResourceNum).Walkthrough)
        Return buffer.ToArray
    End Function

#End Region

#Region "Gather Skills"
    Sub CheckResourceLevelUp(index As Integer, SkillSlot As Integer)
        Dim expRollover As Integer, level_count As Integer

        level_count = 0

        If GetPlayerGatherSkillLvl(index, SkillSlot) = MAX_LEVEL Then Exit Sub

        Do While GetPlayerGatherSkillExp(index, SkillSlot) >= GetPlayerGatherSkillMaxExp(index, SkillSlot)
            expRollover = GetPlayerGatherSkillExp(index, SkillSlot) - GetPlayerGatherSkillMaxExp(index, SkillSlot)
            SetPlayerGatherSkillLvl(index, SkillSlot, GetPlayerGatherSkillLvl(index, SkillSlot) + 1)
            SetPlayerGatherSkillExp(index, SkillSlot, expRollover)
            SetPlayerGatherSkillMaxExp(index, SkillSlot, GetSkillNextLevel(index, SkillSlot))
            level_count = level_count + 1
        Loop

        If level_count > 0 Then
            If level_count = 1 Then
                'singular
                PlayerMsg(index, String.Format("Your {0} has gone up a level!", GetResourceSkillName(SkillSlot)), ColorType.BrightGreen)
            Else
                'plural
                PlayerMsg(index, String.Format("Your {0} has gone up by {1} levels!", GetResourceSkillName(SkillSlot), level_count), ColorType.BrightGreen)
            End If

            SendPlayerData(index)
        End If
    End Sub

#End Region

#Region "Incoming Packets"

    Sub Packet_EditResource(index As Integer, ByRef data() As Byte)
        Dim Buffer As New ByteStream(4)

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Developer Then Exit Sub
        If TempPlayer(index).Editor > 0 Then Exit Sub

        Dim user As String

        user = IsEditorLocked(index, EditorType.Resource)

        If user <> "" Then 
            PlayerMsg(index, "The game editor is locked and being used by " + user + ".", ColorType.BrightRed)
            Exit Sub
        End If

        TempPlayer(index).Editor = EditorType.Resource

        SendItems(index)
        SendAnimations(index)
        SendResources(index)

        Buffer.WriteInt32(ServerPackets.SResourceEditor)
        Socket.SendDataTo(index, Buffer.Data, Buffer.Head)

        Buffer.Dispose()
    End Sub

    Sub Packet_SaveResource(index As Integer, ByRef data() As Byte)
        Dim resourcenum As Integer
        Dim buffer As New ByteStream(data)

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Developer Then Exit Sub

        resourcenum = buffer.ReadInt32

        ' Prevent hacking
        If resourcenum <= 0 Or resourcenum > MAX_RESOURCES Then Exit Sub

        Resource(resourcenum).Animation = buffer.ReadInt32()
        Resource(resourcenum).EmptyMessage = buffer.ReadString()
        Resource(resourcenum).ExhaustedImage = buffer.ReadInt32()
        Resource(resourcenum).Health = buffer.ReadInt32()
        Resource(resourcenum).ExpReward = buffer.ReadInt32()
        Resource(resourcenum).ItemReward = buffer.ReadInt32()
        Resource(resourcenum).Name = buffer.ReadString()
        Resource(resourcenum).ResourceImage = buffer.ReadInt32()
        Resource(resourcenum).ResourceType = buffer.ReadInt32()
        Resource(resourcenum).RespawnTime = buffer.ReadInt32()
        Resource(resourcenum).SuccessMessage = buffer.ReadString()
        Resource(resourcenum).LvlRequired = buffer.ReadInt32()
        Resource(resourcenum).ToolRequired = buffer.ReadInt32()
        Resource(resourcenum).Walkthrough = buffer.ReadInt32()

        ' Save it
        SendUpdateResourceToAll(resourcenum)
        SaveResource(resourcenum)

        Addlog(GetPlayerLogin(index) & " saved Resource #" & resourcenum & ".", ADMIN_LOG)

        buffer.Dispose()
    End Sub

    Sub Packet_RequestResource(index As Integer, ByRef data() As Byte)
        Dim Buffer = New ByteStream(data), n As Integer

        n = Buffer.ReadInt32

        If n <= 0 Or n > MAX_RESOURCES Then Exit Sub

        SendUpdateResourceTo(index, n)
    End Sub

#End Region

#Region "Outgoing Packets"

    Sub SendMapResourceTo(index As Integer, Resource_num As long)
        Dim i As Integer, mapnum As Integer
        Dim buffer As New ByteStream(4)

        mapnum = GetPlayerMap(index)

        buffer.WriteInt32(ServerPackets.SMapResource)
        buffer.WriteInt32(MapResource(mapnum).ResourceCount)

        If MapResource(mapnum).ResourceCount > 0 Then

            For i = 1 To MapResource(mapnum).ResourceCount
                buffer.WriteByte(MapResource(mapnum).ResourceData(i).State)
                buffer.WriteInt32(MapResource(mapnum).ResourceData(i).X)
                buffer.WriteInt32(MapResource(mapnum).ResourceData(i).Y)
            Next

        End If

        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendMapResourceToMap(mapNum As Integer, Resource_num As Integer)
        Dim i As Integer
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SMapResource)
        buffer.WriteInt32(MapResource(mapNum).ResourceCount)

        If MapResource(mapNum).ResourceCount > 0 Then

            For i = 1 To MapResource(mapNum).ResourceCount
                buffer.WriteByte(MapResource(mapNum).ResourceData(i).State)
                buffer.WriteInt32(MapResource(mapNum).ResourceData(i).X)
                buffer.WriteInt32(MapResource(mapNum).ResourceData(i).Y)
            Next

        End If

        SendDataToMap(mapNum, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendResources(index As Integer)
        Dim i As Integer

        For i = 1 To MAX_RESOURCES

            If Len(Trim$(Resource(i).Name)) > 0 Then
                SendUpdateResourceTo(index, i)
            End If

        Next

    End Sub

    Sub SendUpdateResourceTo(index As Integer, ResourceNum As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SUpdateResource)

        buffer.WriteBlock(ResourceData(ResourceNum))

        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendUpdateResourceToAll(ResourceNum As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SUpdateResource)

        buffer.WriteBlock(ResourceData(ResourceNum))

        SendDataToAll(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

#End Region

#Region "Functions"

    Sub CheckResource(index As Integer, x As Integer, y As Integer)
        Dim Resource_num As Integer, ResourceType As Byte
        Dim Resource_index As Integer
        Dim rX As Integer, rY As Integer
        Dim Damage As Integer
        Dim MapNum As Integer

        MapNum = GetPlayerMap(index)

        If Map(MapNum).Tile(x, y).Type = TileType.Resource Or Map(MapNum).Tile(x, y).Type2 = TileType.Resource Then
            Resource_num = 0
            Resource_index = Map(MapNum).Tile(x, y).Data1
            ResourceType = Resource(Resource_index).ResourceType

            ' Get the cache number
            For i = 1 To MapResource(MapNum).ResourceCount
                If MapResource(MapNum).ResourceData(i).X = x Then
                    If MapResource(MapNum).ResourceData(i).Y = y Then
                        Resource_num = i
                    End If
                End If
            Next

            If Resource_num > 0 Then
                If GetPlayerEquipment(index, EquipmentType.Weapon) > 0 Or Resource(Resource_index).ToolRequired = 0 Then
                    If Item(GetPlayerEquipment(index, EquipmentType.Weapon)).Data3 = Resource(Resource_index).ToolRequired Then

                        ' inv space?
                        If Resource(Resource_index).ItemReward > 0 Then
                            If FindOpenInvSlot(index, Resource(Resource_index).ItemReward) = 0 Then
                                PlayerMsg(index, "You have no inventory space.", ColorType.Yellow)
                                Exit Sub
                            End If
                        End If

                        'required lvl?
                        If Resource(Resource_index).LvlRequired > GetPlayerGatherSkillLvl(index, ResourceType) Then
                            PlayerMsg(index, "Your level is too low!", ColorType.Yellow)
                            Exit Sub
                        End If

                        ' check if already cut down
                        If MapResource(MapNum).ResourceData(Resource_num).State = 0 Then

                            rX = MapResource(MapNum).ResourceData(Resource_num).X
                            rY = MapResource(MapNum).ResourceData(Resource_num).Y

                            If Resource(Resource_index).ToolRequired = 0 Then
                                Damage = 1 * GetPlayerGatherSkillLvl(index, ResourceType)
                            Else
                                Damage = Item(GetPlayerEquipment(index, EquipmentType.Weapon)).Data2
                            End If

                            ' check if damage is more than health
                            If Damage > 0 Then
                                ' cut it down!
                                If MapResource(MapNum).ResourceData(Resource_num).Health - Damage <= 0 Then
                                    MapResource(MapNum).ResourceData(Resource_num).State = 1 ' Cut
                                    MapResource(MapNum).ResourceData(Resource_num).Timer = GetTimeMs()
                                    SendMapResourceToMap(MapNum, Resource_num)
                                    SendActionMsg(MapNum, Trim$(Resource(Resource_index).SuccessMessage), ColorType.BrightGreen, 1, (GetPlayerX(index) * 32), (GetPlayerY(index) * 32))
                                    GiveInvItem(index, Resource(Resource_index).ItemReward, 1)
                                    SendAnimation(MapNum, Resource(Resource_index).Animation, rX, rY)
                                    SetPlayerGatherSkillExp(index, ResourceType, GetPlayerGatherSkillExp(index, ResourceType) + Resource(Resource_index).ExpReward)
                                    'send msg
                                    PlayerMsg(index, String.Format("Your {0} has earned {1} experience. ({2}/{3})", GetResourceSkillName(ResourceType), Resource(Resource_index).ExpReward, GetPlayerGatherSkillExp(index, ResourceType), GetPlayerGatherSkillMaxExp(index, ResourceType)), ColorType.BrightGreen)
                                    SendPlayerData(index)

                                    CheckResourceLevelUp(index, ResourceType)
                                Else
                                    ' just do the damage
                                    MapResource(MapNum).ResourceData(Resource_num).Health = MapResource(MapNum).ResourceData(Resource_num).Health - Damage
                                    SendActionMsg(MapNum, "-" & Damage, ColorType.BrightRed, 1, (rX * 32), (rY * 32))
                                    SendAnimation(MapNum, Resource(Resource_index).Animation, rX, rY)
                                End If
                            Else
                                ' too weak
                                SendActionMsg(MapNum, "Miss!", ColorType.BrightRed, 1, (rX * 32), (rY * 32))
                            End If
                        Else
                            SendActionMsg(MapNum, Trim$(Resource(Resource_index).EmptyMessage), ColorType.BrightRed, 1, (GetPlayerX(index) * 32), (GetPlayerY(index) * 32))
                        End If
                    Else
                        PlayerMsg(index, "You have the wrong type of tool equiped.", ColorType.Yellow)
                    End If
                Else
                    PlayerMsg(index, "You need a tool to gather this resource.", ColorType.Yellow)
                End If
            End If
        End If
    End Sub

#End Region

End Module