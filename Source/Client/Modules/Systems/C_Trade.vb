Imports System.Drawing
Imports Mirage.Sharp.Asfw
Imports Core

Module C_Trade

#Region "Globals & Types"

    Friend TradeTimer As Integer
    Friend TradeRequest As Boolean
    Friend InTrade As Integer
    Friend TradeX As Integer
    Friend TradeY As Integer
    Friend TheirWorth As String
    Friend YourWorth As String

#End Region

#Region "Incoming Packets"

    Sub Packet_ClearTradeTimer(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)
        TradeRequest = False
        TradeTimer = 0

        buffer.Dispose()
    End Sub

    Sub Packet_TradeInvite(ByRef data() As Byte)
        Dim requester As Integer
        Dim buffer As New ByteStream(data)
        requester = buffer.ReadInt32

        'DialogType = DialogueTypeTrade

        DialogMsg1 = String.Format(Language.Trade.Request, Trim$((Player(requester).Name)))

        UpdateDialog = True

        buffer.Dispose()
    End Sub

    Sub Packet_Trade(ByRef data() As Byte)
        Dim buffer As New ByteStream(data)

        InTrade = buffer.ReadInt32

        ShowTrade()

        buffer.Dispose()
    End Sub

    Sub Packet_CloseTrade(ByRef data() As Byte)
        InTrade = 0
        HideWindow(GetWindowIndex("winTrade"))
    End Sub

    Sub Packet_TradeUpdate(ByRef data() As Byte)
        Dim datatype As Integer
        Dim buffer As New ByteStream(data)
        datatype = buffer.ReadInt32

        If datatype = 0 Then ' ours!
           For i = 1 To MAX_INV
                TradeYourOffer(i).Num = buffer.ReadInt32
                TradeYourOffer(i).Value = buffer.ReadInt32
            Next
            YourWorth = String.Format(Language.Trade.Value, buffer.ReadInt32) & "g"
        ElseIf datatype = 1 Then 'theirs
           For i = 1 To MAX_INV
                TradeTheirOffer(i).Num = buffer.ReadInt32
                TradeTheirOffer(i).Value = buffer.ReadInt32
            Next
            TheirWorth = String.Format(Language.Trade.Value, buffer.ReadInt32) & "g"
        End If

        buffer.Dispose()
    End Sub

    Sub Packet_TradeStatus(ByRef data() As Byte)
        Dim tradestatus As Integer
        Dim buffer As New ByteStream(data)
        tradestatus = buffer.ReadInt32

        Select Case tradestatus
            Case 0 ' clear
            Case 1 ' they've accepted
                AddText(Language.Trade.StatusOther, ColorType.White)
            Case 2 ' you've accepted
                AddText(Language.Trade.StatusSelf, ColorType.White)
        End Select

        buffer.Dispose()
    End Sub

#End Region

#Region "Outgoing Packets"

    Friend Sub SendAcceptTrade()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CAcceptTrade)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub SendDeclineTrade()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CDeclineTrade)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Sub SendTradeRequest(name As String)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CTradeInvite)
        buffer.WriteString((name))

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

    Sub SendTradeInviteAccept(awnser As Byte)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CTradeInviteAccept)
        buffer.WriteInt32(awnser)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

    Friend Sub TradeItem(invslot As Integer, amount As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CTradeItem)
        buffer.WriteInt32(invslot)
        buffer.WriteInt32(amount)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub UntradeItem(invslot As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CUntradeItem)
        buffer.WriteInt32(invslot)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

#End Region

End Module