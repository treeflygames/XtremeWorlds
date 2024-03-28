Imports System.Drawing
Imports Mirage.Sharp.Asfw
Imports Core

Module C_Shops

#Region "Globals & Types"

    Friend InShop As Integer ' is the player in a shop?
    Friend ShopAction As Byte ' stores the current shop action

#End Region

#Region "Database"

    Sub ClearShop(index As Integer)
        Shop(index) = Nothing
        Shop(index).Name = ""
        ReDim Shop(index).TradeItem(MAX_TRADES)
        For x = 1 To MAX_TRADES
            ReDim Shop(index).TradeItem(x)
        Next
        Shop_Loaded(index) = False
    End Sub

    Sub ClearShops()
        Dim i As Integer

        ReDim Shop(MAX_SHOPS)

       For i = 1 To MAX_SHOPS
            ClearShop(i)
        Next

    End Sub

    Sub StreamShop(shopNum As Integer)
        If shopNum > 0 And Shop(shopNum).Name = "" Or Shop_Loaded(shopNum) = False Then
            Shop_Loaded(shopNum) = True
            SendRequestShop(shopNum)
        End If
    End Sub

#End Region

#Region "Incoming Packets"

    Friend Sub Packet_OpenShop(ByRef data() As Byte)
        Dim shopnum As Integer
        Dim buffer As New ByteStream(data)

        shopNum = buffer.ReadInt32

        OpenShop(shopNum)

        buffer.Dispose()
    End Sub

    Friend Sub Packet_ResetShopAction(ByRef data() As Byte)
        ShopAction = 0
    End Sub

    Friend Sub Packet_UpdateShop(ByRef data() As Byte)
        Dim shopnum As Integer
        Dim buffer As New ByteStream(data)
        shopnum = buffer.ReadInt32

        Shop(shopnum).BuyRate = buffer.ReadInt32()
        Shop(shopnum).Name = Trim(buffer.ReadString())
        Shop(shopnum).Face = buffer.ReadInt32()

        For i = 1 To MAX_TRADES
            Shop(shopnum).TradeItem(i).CostItem = buffer.ReadInt32()
            Shop(shopnum).TradeItem(i).CostValue = buffer.ReadInt32()
            Shop(shopnum).TradeItem(i).Item = buffer.ReadInt32()
            Shop(shopnum).TradeItem(i).ItemValue = buffer.ReadInt32()
        Next

        If Shop(shopnum).Name Is Nothing Then Shop(shopnum).Name = ""

        buffer.Dispose()
    End Sub

#End Region

#Region "Outgoing Packets"

    Friend Sub SendRequestShop(shopNum As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CRequestShop)
        buffer.WriteInt32(shopNum)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub BuyItem(shopSlot As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CBuyItem)
        buffer.WriteInt32(shopSlot)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub SellItem(invslot As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CSellItem)
        buffer.WriteInt32(invslot)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

#End Region

End Module