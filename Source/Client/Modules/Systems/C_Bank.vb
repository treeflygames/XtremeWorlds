Imports System.Drawing
Imports Core
Imports Mirage.Sharp.Asfw

Module C_Banks

#Region "Globals & Types"

    Friend Bank As Types.BankStruct

    ' Stores the last bank item we showed in desc
    Friend LastBankDesc As Integer

    Friend InBank As Boolean

    ' bank drag + drop
    Friend DragBankSlotNum As Integer

    Friend BankX As Integer
    Friend BankY As Integer

#End Region

#Region "Database"

    Sub ClearBank()
        ReDim Bank.Item(MAX_BANK)
    End Sub

#End Region

#Region "Incoming Packets"

    Friend Sub Packet_OpenBank(ByRef data() As Byte)
        Dim i As Integer, x As Integer
        Dim buffer As New ByteStream(data)

        For i = 1 To MAX_BANK
            Bank.Item(i).Num = buffer.ReadInt32
            Bank.Item(i).Value = buffer.ReadInt32
        Next

        InBank = True

        If Not Windows(GetWindowIndex("winBank")).Window.visible Then
            ShowWindow(GetWindowIndex("winBank"), , False)
        End If

        buffer.Dispose()
    End Sub

#End Region

#Region "Outgoing Packets"

    Friend Sub DepositItem(invslot As Integer, amount As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CDepositItem)
        buffer.WriteInt32(invslot)
        buffer.WriteInt32(amount)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub WithdrawItem(bankslot As Integer, amount As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CWithdrawItem)
        buffer.WriteInt32(bankslot)
        buffer.WriteInt32(amount)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub ChangeBankSlots(oldSlot As Integer, newSlot As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CChangeBankSlots)
        buffer.WriteInt32(oldSlot)
        buffer.WriteInt32(newSlot)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub CloseBank()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CCloseBank)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

        InBank = False
    End Sub

#End Region

End Module