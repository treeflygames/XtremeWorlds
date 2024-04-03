
Imports Core
Imports Mirage.Sharp.Asfw
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Friend Module S_Item

#Region "Database"

    Sub SaveItems()
        Dim i As Integer

       For i = 1 To MAX_ITEMS
            SaveItem(i)
        Next

    End Sub

    Sub SaveItem(itemNum As Integer)
        Dim json As String = JsonConvert.SerializeObject(Item(itemNum)).ToString()

        If RowExists(itemNum, "item")
            UpdateRow(itemNum, json, "item", "data")
        Else
            InsertRow(itemNum, json, "item")
        End If
    End Sub

    Sub LoadItems()
        Dim i As Integer

        For i = 1 To MAX_ITEMS
            LoadItem(i)
        Next

    End Sub

    Sub LoadItem(itemNum As Integer)
        Dim data As JObject

        data = SelectRow(itemNum, "item", "data")

        If data Is Nothing Then
            ClearItem(itemNum)
            Exit Sub
        End If

        Dim itemData = JObject.FromObject(data).toObject(Of Types.ItemStruct)()
        Item(itemNum) = itemData
    End Sub

    Sub ClearItem(index As Integer)
        Item(index).Name = ""
        Item(index).Description = ""

        For i = 1 To MAX_ITEMS
            ReDim Item(i).Add_Stat(StatType.Count - 1)
            ReDim Item(i).Stat_Req(StatType.Count - 1)
        Next
    End Sub

    Sub ClearItems()
        For i = 1 To MAX_ITEMS
            ClearItem(i)
        Next
    End Sub

    Function ItemData(itemNum As Integer) As Byte()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(itemNum)
        buffer.WriteInt32(Item(itemNum).AccessReq)

        For i = 1 To StatType.Count - 1
            buffer.WriteInt32(Item(itemNum).Add_Stat(i))
        Next

        buffer.WriteInt32(Item(itemNum).Animation)
        buffer.WriteInt32(Item(itemNum).BindType)
        buffer.WriteInt32(Item(itemNum).JobReq)
        buffer.WriteInt32(Item(itemNum).Data1)
        buffer.WriteInt32(Item(itemNum).Data2)
        buffer.WriteInt32(Item(itemNum).Data3)
        buffer.WriteInt32(Item(itemNum).TwoHanded)
        buffer.WriteInt32(Item(itemNum).LevelReq)
        buffer.WriteInt32(Item(itemNum).Mastery)
        buffer.WriteString((Trim$(Item(itemNum).Name)))
        buffer.WriteInt32(Item(itemNum).Paperdoll)
        buffer.WriteInt32(Item(itemNum).Icon)
        buffer.WriteInt32(Item(itemNum).Price)
        buffer.WriteInt32(Item(itemNum).Rarity)
        buffer.WriteInt32(Item(itemNum).Speed)

        buffer.WriteInt32(Item(itemNum).Randomize)
        buffer.WriteInt32(Item(itemNum).RandomMin)
        buffer.WriteInt32(Item(itemNum).RandomMax)

        buffer.WriteInt32(Item(itemNum).Stackable)
        buffer.WriteString((Trim$(Item(itemNum).Description)))

        For i = 1 To StatType.Count - 1
            buffer.WriteInt32(Item(itemNum).Stat_Req(i))
        Next

        buffer.WriteInt32(Item(itemNum).Type)
        buffer.WriteInt32(Item(itemNum).SubType)

        buffer.WriteInt32(Item(itemNum).ItemLevel)

        buffer.WriteInt32(Item(itemNum).KnockBack)
        buffer.WriteInt32(Item(itemNum).KnockBackTiles)
        buffer.WriteInt32(Item(itemNum).Projectile)
        buffer.WriteInt32(Item(itemNum).Ammo)
        Return buffer.ToArray
    End Function

#End Region

#Region "Map Items"
    Sub SendMapItemsTo(index As Integer, mapNum As Integer)
        Dim i As Integer
        Dim buffer As ByteStream
        buffer = New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SMapItemData)

        For i = 1 To MAX_MAP_ITEMS
            buffer.WriteInt32(MapItem(mapNum, i).Num)
            buffer.WriteInt32(MapItem(mapNum, i).Value)
            buffer.WriteInt32(MapItem(mapNum, i).X)
            buffer.WriteInt32(MapItem(mapNum, i).Y)
        Next

        Socket.SendDataTo(index, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SendMapItemsToAll(mapNum As Integer)
        Dim i As Integer
        Dim buffer As ByteStream
        buffer = New ByteStream(4)

        buffer.WriteInt32(ServerPackets.SMapItemData)

        For i = 1 To MAX_MAP_ITEMS
            buffer.WriteInt32(MapItem(mapNum, i).Num)
            buffer.WriteInt32(MapItem(mapNum, i).Value)
            buffer.WriteInt32(MapItem(mapNum, i).X)
            buffer.WriteInt32(MapItem(mapNum, i).Y)
        Next

        SendDataToMap(mapNum, buffer.Data, buffer.Head)

        buffer.Dispose()
    End Sub

    Sub SpawnItem(itemNum As Integer, ItemVal As Integer, mapNum As Integer, x As Integer, y As Integer)
        Dim i As Integer

        ' Check for subscript out of range
        If itemnum <= 0 Or itemNum > MAX_ITEMS Or mapNum <= 0 Or mapNum > MAX_MAPS Then Exit Sub

        ' Find open map item slot
        i = FindOpenMapItemSlot(mapNum)

        If i = 0 Then Exit Sub

        SpawnItemSlot(i, itemNum, ItemVal, mapNum, x, y)
    End Sub

    Sub SpawnItemSlot(MapItemSlot As Integer, itemNum As Integer, ItemVal As Integer, mapNum As Integer, x As Integer, y As Integer)
        Dim i As Integer
        Dim buffer As New ByteStream(4)

        ' Check for subscript out of range
        If MapItemSlot < 0 Or MapItemSlot > MAX_MAP_ITEMS Or itemnum < 0 Or itemNum > MAX_ITEMS Or mapNum <= 0 Or mapNum > MAX_MAPS Then Exit Sub

        i = MapItemSlot

        If i <> -1 Then
            MapItem(mapNum, i).Num = itemNum
            MapItem(mapNum, i).Value = ItemVal
            MapItem(mapNum, i).X = x
            MapItem(mapNum, i).Y = y

            buffer.WriteInt32(ServerPackets.SSpawnItem)
            buffer.WriteInt32(i)
            buffer.WriteInt32(itemNum)
            buffer.WriteInt32(ItemVal)
            buffer.WriteInt32(x)
            buffer.WriteInt32(y)

            SendDataToMap(mapNum, buffer.Data, buffer.Head)
        End If

        buffer.Dispose()
    End Sub

    Function FindOpenMapItemSlot(mapNum As Integer) As Integer
        Dim i As Integer

        ' Check for subscript out of range
        If mapNum <= 0 Or mapNum > MAX_MAPS Then Exit Function

        FindOpenMapItemSlot = 0

        For i = 1 To MAX_MAP_ITEMS
            If MapItem(mapNum, i).Num = 0 Then
                FindOpenMapItemSlot = i
                Exit Function
            End If
        Next

    End Function

    Sub SpawnAllMapsItems()
        Dim i As Integer

       For i = 1 To MAX_MAPS
            SpawnMapItems(i)
        Next

    End Sub

    Sub SpawnMapItems(mapNum As Integer)
        Dim x As Integer
        Dim y As Integer

        ' Check for subscript out of range
        If mapNum <= 0 Or mapNum > MAX_MAPS Then Exit Sub
        If Map(mapNum).NoRespawn Then Exit Sub

        ' Spawn what we have
        For x = 0 To Map(mapNum).MaxX
            For y = 0 To Map(mapNum).MaxY
                ' Check if the tile type is an item or a saved tile incase someone drops something
                If (Map(mapNum).Tile(x, y).Type = TileType.Item) Then

                    ' Check to see if its a currency and if they set the value to 0 set it to 1 automatically
                    If Item(Map(mapNum).Tile(x, y).Data1).Type = ItemType.Currency Or Item(Map(mapNum).Tile(x, y).Data1).Stackable = 1 Then
                        If Map(mapNum).Tile(x, y).Data2 <= 0 Then
                            SpawnItem(Map(mapNum).Tile(x, y).Data1, 1, mapNum, x, y)
                        Else
                            SpawnItem(Map(mapNum).Tile(x, y).Data1, Map(mapNum).Tile(x, y).Data2, mapNum, x, y)
                        End If
                    Else
                        SpawnItem(Map(mapNum).Tile(x, y).Data1, Map(mapNum).Tile(x, y).Data2, mapNum, x, y)
                    End If
                End If
            Next
        Next

    End Sub

#End Region

#Region "Incoming Packets"

    Sub Packet_RequestItem(index As Integer, ByRef data() As Byte)
        Dim Buffer = New ByteStream(data), n As Integer

        n = Buffer.ReadInt32

        If n <= 0 Or n > MAX_ITEMS Then Exit Sub

        SendUpdateItemTo(index, n)
    End Sub

    Sub Packet_EditItem(index As Integer, ByRef data() As Byte)
        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Mapper Then Exit Sub
        If TempPlayer(index).Editor > 0 Then  Exit Sub

        Dim user As String

        user = IsEditorLocked(index, EditorType.Item)

        If user <> "" Then 
            PlayerMsg(index, "The game editor is locked and being used by " + user + ".", ColorType.BrightRed)
            Exit Sub
        End If

        TempPlayer(index).Editor = EditorType.Item

        SendAnimations(index)
        SendProjectiles(index)
        SendJobs(index)
        SendItems(index)

        Dim Buffer = New ByteStream(4)

        Buffer.WriteInt32(ServerPackets.SItemEditor)
        Socket.SendDataTo(index, Buffer.Data, Buffer.Head)

        Buffer.Dispose()
    End Sub

    Sub Packet_SaveItem(index As Integer, ByRef data() As Byte)
        Dim n As Integer
        Dim buffer As New ByteStream(data)

        ' Prevent hacking
        If GetPlayerAccess(index) < AdminType.Developer Then Exit Sub

        n = buffer.ReadInt32

        If n <= 0 Or n > MAX_ITEMS Then Exit Sub

        ' Update the item
        Item(n).AccessReq = buffer.ReadInt32()

        For i = 1 To StatType.Count - 1
            Item(n).Add_Stat(i) = buffer.ReadInt32()
        Next

        Item(n).Animation = buffer.ReadInt32()
        Item(n).BindType = buffer.ReadInt32()
        Item(n).JobReq = buffer.ReadInt32()
        Item(n).Data1 = buffer.ReadInt32()
        Item(n).Data2 = buffer.ReadInt32()
        Item(n).Data3 = buffer.ReadInt32()
        Item(n).TwoHanded = buffer.ReadInt32()
        Item(n).LevelReq = buffer.ReadInt32()
        Item(n).Mastery = buffer.ReadInt32()
        Item(n).Name = Trim$(buffer.ReadString)
        Item(n).Paperdoll = buffer.ReadInt32()
        Item(n).Icon = buffer.ReadInt32()
        Item(n).Price = buffer.ReadInt32()
        Item(n).Rarity = buffer.ReadInt32()
        Item(n).Speed = buffer.ReadInt32()

        Item(n).Randomize = buffer.ReadInt32()
        Item(n).RandomMin = buffer.ReadInt32()
        Item(n).RandomMax = buffer.ReadInt32()

        Item(n).Stackable = buffer.ReadInt32()
        Item(n).Description = Trim$(buffer.ReadString)

        For i = 1 To StatType.Count - 1
            Item(n).Stat_Req(i) = buffer.ReadInt32()
        Next

        Item(n).Type = buffer.ReadInt32()
        Item(n).SubType = buffer.ReadInt32

        Item(n).ItemLevel = buffer.ReadInt32

        Item(n).KnockBack = buffer.ReadInt32()
        Item(n).KnockBackTiles = buffer.ReadInt32()

        Item(n).Projectile = buffer.ReadInt32()
        Item(n).Ammo = buffer.ReadInt32()

        ' Save it
        SaveItem(n)
        SendUpdateItemToAll(n)
        Addlog(GetPlayerLogin(index) & " saved item #" & n & ".", ADMIN_LOG)
        buffer.Dispose()
    End Sub

    Sub Packet_GetItem(index As Integer, ByRef data() As Byte)
        PlayerMapGetItem(index)
    End Sub

    Sub Packet_DropItem(index As Integer, ByRef data() As Byte)
        Dim invNum As Integer, amount As Integer
        Dim buffer As New ByteStream(data)
        
        invNum = buffer.ReadInt32
        amount = buffer.ReadInt32
        buffer.Dispose()

        If TempPlayer(index).InBank Or TempPlayer(index).InShop Then Exit Sub

        ' Prevent hacking
        If invNum <= 0 Or invNum > MAX_INV Then Exit Sub
        If GetPlayerInvItemNum(index, invNum) < 0 Or GetPlayerInvItemNum(index, invNum) > MAX_ITEMS Then Exit Sub
        If Item(GetPlayerInvItemNum(index, invNum)).Type = ItemType.Currency Or Item(GetPlayerInvItemNum(index, invNum)).Stackable = 1 Then
            If amount < 0 Or amount > GetPlayerInvItemValue(index, invNum) Then Exit Sub
        End If

        ' everything worked out fine
        PlayerMapDropItem(index, invNum, amount)
    End Sub

#End Region

#Region "Outgoing Packets"

    Sub SendItems(index As Integer)
        Dim i As Integer

       For i = 1 To MAX_ITEMS
            If Len(Trim$(Item(i).Name)) > 0 Then
                SendUpdateItemTo(index, i)
            End If
        Next

    End Sub

    Sub SendUpdateItemTo(index As Integer, itemNum As Integer)
        Dim buffer As ByteStream
        buffer = New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SUpdateItem)

        buffer.WriteBlock(ItemData(itemNum))

        Socket.SendDataTo(index, buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendUpdateItemToAll(itemNum As Integer)
        Dim buffer As ByteStream
        buffer = New ByteStream(4)
        buffer.WriteInt32(ServerPackets.SUpdateItem)

        buffer.WriteBlock(ItemData(itemNum))

        SendDataToAll(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

#End Region

End Module