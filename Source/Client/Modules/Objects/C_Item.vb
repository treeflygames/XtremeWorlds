Imports System.IO
Imports Mirage.Sharp.Asfw
Imports Core

Module C_Items

#Region "Database"

    Friend Sub CheckItems()
        Dim i As Integer
        i = 1

        While File.Exists(Paths.Graphics & "Items\" & i & GfxExt)
            NumItems = NumItems + 1
            i = i + 1
        End While
    End Sub

    Friend Sub ClearItem(index As Integer)
        Item(index) = Nothing
        For X = 0 To StatType.Count - 1
            ReDim Item(index).Add_Stat(x)
        Next

        For X = 0 To StatType.Count - 1
            ReDim Item(index).Stat_Req(x)
        Next

        Item(index).Name = ""
        Item(index).Description = ""
        Item_Loaded(index) = False
    End Sub

    Sub ClearItems()
        Dim i As Integer

        ReDim Item(MAX_ITEMS)

        For i = 1 To MAX_ITEMS
            ClearItem(i)
        Next

    End Sub

     Friend Sub ClearChangedItem()
        ReDim Item_Changed(MAX_ITEMS)
    End Sub

    Sub StreamItem(itemNum As Integer)
        If itemnum > 0 and Item(itemNum).Name = "" Or Item_Loaded(itemNum) = False Then
            Item_Loaded(itemNum) = True
            SendRequestItem(itemNum)
        End If
    End Sub

#End Region

#Region "Incoming Packets"

    Friend Sub Packet_UpdateItem(ByRef data() As Byte)
        Dim n As Integer, i As Integer
        Dim buffer As New ByteStream(data)
        n = buffer.ReadInt32

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
        Item(n).Name = Trim$(buffer.ReadString())
        Item(n).Paperdoll = buffer.ReadInt32()
        Item(n).Icon = buffer.ReadInt32()
        Item(n).Price = buffer.ReadInt32()
        Item(n).Rarity = buffer.ReadInt32()
        Item(n).Speed = buffer.ReadInt32()

        Item(n).Randomize = buffer.ReadInt32()
        Item(n).RandomMin = buffer.ReadInt32()
        Item(n).RandomMax = buffer.ReadInt32()

        Item(n).Stackable = buffer.ReadInt32()
        Item(n).Description = Trim$(buffer.ReadString())

        For i = 1 To StatType.Count - 1
            Item(n).Stat_Req(i) = buffer.ReadInt32()
        Next

        Item(n).Type = buffer.ReadInt32()
        Item(n).SubType = buffer.ReadInt32

        Item(n).KnockBack = buffer.ReadInt32()
        Item(n).KnockBackTiles = buffer.ReadInt32()

        Item(n).Projectile = buffer.ReadInt32()
        Item(n).Ammo = buffer.ReadInt32()

        buffer.Dispose()

        ' changes to inventory, need to clear any drop menu
        TmpCurrencyItem = 0
        CurrencyMenu = 0 ' clear
    End Sub

#End Region

#Region "Outgoing Packets"

    Sub SendRequestItem(itemNum As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CRequestItem)
        buffer.WriteInt32(itemNum)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

#End Region

End Module