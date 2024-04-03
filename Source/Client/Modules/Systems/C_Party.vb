Imports System.Drawing
Imports Mirage.Sharp.Asfw
Imports Core
Imports SFML.Graphics
Imports SFML.System

Module C_Parties

#Region "Database"

    Sub ClearParty()
        Party = New PartyStruct With {
            .Leader = 0,
            .MemberCount = 0
        }
        ReDim Party.Member(MAX_PARTY_MEMBERS)
    End Sub

#End Region

#Region "Incoming Packets"

    Sub Packet_PartyInvite(ByRef data() As Byte)
        Dim name As String
        Dim buffer As New ByteStream(data)
        name = buffer.ReadString

        'DialogType = DialogueTypeParty

        DialogMsg1 = "Party Invite"
        DialogMsg2 = Trim$(name) & " has invited you to a party. Would you like to join?"

        UpdateDialog = True

        buffer.Dispose()
    End Sub

    Sub Packet_PartyUpdate(ByRef data() As Byte)
        Dim i As Integer, inParty As Integer
        Dim buffer As New ByteStream(data)
        inParty = buffer.ReadInt32

        ' exit out if we're not in a party
        If inParty = 0 Then
            ClearParty()
            ' exit out early
            buffer.Dispose()
            Exit Sub
        End If

        ' carry on otherwise
        Party.Leader = buffer.ReadInt32
        For i = 1 To MAX_PARTY_MEMBERS
            Party.Member(I) = buffer.ReadInt32
        Next
        Party.MemberCount = buffer.ReadInt32

        buffer.Dispose()
    End Sub

    Sub Packet_PartyVitals(ByRef data() As Byte)
        Dim playerNum As Integer, partyindex As Integer
        Dim buffer As New ByteStream(data)
        ' which player?
        playerNum = buffer.ReadInt32

        ' find the party number
        For i = 1 To MAX_PARTY_MEMBERS
            If Party.Member(I) = playerNum Then
                partyindex = I
            End If
        Next

        ' exit out if wrong data
        If partyindex < 0 Or partyindex > MAX_PARTY_MEMBERS Then Exit Sub

        ' set vitals
        For i = 1 To VitalType.Count - 1
            Player(playerNum).Vital(i) = buffer.ReadInt32
        Next

        buffer.Dispose()
    End Sub

#End Region

#Region "Outgoing Packets"

    Friend Sub SendPartyRequest(name As String)
        Dim buffer As New ByteStream(4)
        buffer.WriteInt32(ClientPackets.CRequestParty)
        buffer.WriteString((name))

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub SendAcceptParty()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CAcceptParty)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub SendDeclineParty()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CDeclineParty)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub SendLeaveParty()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CLeaveParty)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

    Friend Sub SendPartyChatMsg(text As String)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CPartyChatMsg)
        buffer.WriteString((text))

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()
    End Sub

#End Region

#Region "Drawing"

    Friend Sub DrawParty()
        Dim i As Integer, x As Integer, y As Integer, barwidth As Integer, playerNum As Integer, theName As String
        Dim rec(1) As Rectangle

        ' draw the bars
        If Party.Leader > 0 Then ' make sure we're in a party
            ' draw leader
            playerNum = Party.Leader
            ' name
            theName = Trim$(GetPlayerName(playerNum))
            ' draw name
            y = 100
            x = 10
            RenderText(theName, Window, x, y, SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black)

            ' draw hp
            If Player(playerNum).Vital(VitalType.HP) > 0 Then
                ' calculate the width to fill
                barwidth = ((Player(playerNum).Vital(VitalType.HP) / (GetPlayerMaxVital(playerNum, VitalType.HP)) * 64))
                ' draw bars
                rec(1) = New Rectangle(x, y, barwidth, 6)
                Dim rectShape As New RectangleShape(New Vector2f(barwidth, 6)) With {
                    .Position = New Vector2f(x, y + 15),
                    .FillColor = SFML.Graphics.Color.Red
                }
                Window.Draw(rectShape)
            End If
            ' draw mp
            If Player(playerNum).Vital(VitalType.MP) > 0 Then
                ' calculate the width to fill
                barwidth = ((Player(playerNum).Vital(VitalType.MP) / (GetPlayerMaxVital(playerNum, VitalType.MP)) * 64))
                ' draw bars
                rec(1) = New Rectangle(x, y, barwidth, 6)
                Dim rectShape2 As New RectangleShape(New Vector2f(barwidth, 6)) With {
                    .Position = New Vector2f(x, y + 24),
                    .FillColor = SFML.Graphics.Color.Blue
                }
                Window.Draw(rectShape2)
            End If

            ' draw members
            For i = 1 To MAX_PARTY_MEMBERS
                If Party.Member(I) > 0 Then
                    If Party.Member(I) <> Party.Leader Then
                        ' cache the index
                        playerNum = Party.Member(I)
                        ' name
                        theName = Trim$(GetPlayerName(playerNum))
                        ' draw name
                        y = 100 + ((I - 1) * 30)

                        RenderText(theName, Window, x, y, SFML.Graphics.Color.White, SFML.Graphics.Color.Black)
                        ' draw hp
                        y = 115 + ((I - 1) * 30)

                        ' make sure we actually have the data before rendering
                        If GetPlayerVital(playerNum, VitalType.HP) > 0 And GetPlayerMaxVital(playerNum, VitalType.HP) > 0 Then
                            barwidth = ((Player(playerNum).Vital(VitalType.HP) / (GetPlayerMaxVital(playerNum, VitalType.HP)) * 64))
                        End If
                        rec(1) = New Rectangle(x, y, barwidth, 6)
                        Dim rectShape As New RectangleShape(New Vector2f(barwidth, 6)) With {
                            .Position = New Vector2f(x, y),
                            .FillColor = SFML.Graphics.Color.Red
                        }
                        Window.Draw(rectShape)
                        ' draw mp
                        y = 115 + ((I - 1) * 30)
                        ' make sure we actually have the data before rendering
                        If GetPlayerVital(playerNum, VitalType.MP) > 0 And GetPlayerMaxVital(playerNum, VitalType.MP) > 0 Then
                            barwidth = ((Player(playerNum).Vital(VitalType.MP) / (GetPlayerMaxVital(playerNum, VitalType.MP)) * 64))
                        End If
                        rec(1) = New Rectangle(x, y, barwidth, 6)
                        Dim rectShape2 As New RectangleShape(New Vector2f(barwidth, 6)) With {
                            .Position = New Vector2f(x, y + 8),
                            .FillColor = SFML.Graphics.Color.Blue
                        }
                        Window.Draw(rectShape2)
                    End If
                End If
            Next
        End If
    End Sub

#End Region

End Module