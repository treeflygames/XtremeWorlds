Imports System.Drawing
Imports System.Windows.Forms
Imports Mirage.Sharp.Asfw
Imports Core

Friend Module C_Gui

#Region "Support Functions"

   Public Function IsEq(StartX As Long, StartY As Long) As Long
        Dim tempRec As RectStruct
        Dim i As Long

        For i = 1 To EquipmentType.Count - 1
            If GetPlayerEquipment(MyIndex, i) Then
                With tempRec
                .Top = StartY + EqTop + (PicY * ((i - 1) \ EqColumns))
                .bottom = .Top + PicY
                .Left = StartX + EqLeft + ((EqOffsetX + PicX) * (((i - 1) Mod EqColumns)))
                .Right = .Left + PicX
                End With

                If CurMouseX >= tempRec.Left And CurMouseX <= tempRec.Right Then
                    If CurMouseY >= tempRec.Top And CurMouseY <= tempRec.bottom Then
                        IsEq = i
                        Exit Function
                    End If
                End If
            End If
        Next
    End Function

    Public Function IsInv(StartX As Long, StartY As Long) As Long
        Dim tempRec As RectStruct
        Dim i As Long

        For i = 1 To MAX_INV
            If GetPlayerInvItemNum(MyIndex, i) Then
                With tempRec
                    .Top = StartY + InvTop + ((InvOffsetY + PicY) * ((i - 1) \ InvColumns))
                    .bottom = .Top + PicY
                    .Left = StartX + InvLeft + ((InvOffsetX + PicX) * (((i - 1) Mod InvColumns)))
                    .Right = .Left + PicX
                End With

                If CurMouseX >= tempRec.Left And CurMouseX <= tempRec.Right Then
                    If CurMouseY >= tempRec.Top And CurMouseY <= tempRec.bottom Then
                        IsInv = i
                        Exit Function
                    End If
                End If
            End If
        Next
    End Function

    Public Function IsSkill(StartX As Long, StartY As Long) As Long
        Dim tempRec As RectStruct
        Dim i As Long

        For i = 1 To MAX_PLAYER_SKILLS
            If Player(MyIndex).Skill(i).Num Then
                With tempRec
                    .Top = StartY + SkillTop + ((SkillOffsetY + PicY) * ((i - 1) \ SkillColumns))
                    .bottom = .Top + PicY
                    .Left = StartX + SkillLeft + ((SkillOffsetX + PicX) * (((i - 1) Mod SkillColumns)))
                    .Right = .Left + PicX
                End With

                If CurMouseX >= tempRec.Left And CurMouseX <= tempRec.Right Then
                    If CurMouseY >= tempRec.Top And CurMouseY <= tempRec.bottom Then
                        IsSkill = i
                        Exit Function
                    End If
                End If
            End If
        Next
    End Function

    Public Function IsBank(StartX As Long, StartY As Long) As Long
        Dim tempRec As RectStruct
        Dim i As Long

        For i = 1 To MAX_BANK
            If Bank.Item(i).num > 0 Then
                With tempRec
                    .Top = StartY + BankTop + ((BankOffsetY + PicY) * ((i - 1) \ BankColumns))
                    .bottom = .Top + PicY
                    .Left = StartX + BankLeft + ((BankOffsetX + PicX) * (((i - 1) Mod BankColumns)))
                    .Right = .Left + PicX
                End With

                If CurMouseX >= tempRec.Left And CurMouseX <= tempRec.Right Then
                    If CurMouseY >= tempRec.Top And CurMouseY <= tempRec.bottom Then
                        IsBank = i
                        Exit Function
                    End If
                End If
            End If
        
        Next

    End Function

  Public Function IsShop(StartX As Long, StartY As Long) As Long
        Dim tempRec As RectStruct
        Dim i As Long

        For i = 1 To MAX_TRADES
            With tempRec
                .Top = StartY + ShopTop + ((ShopOffsetY + PicY) * ((i - 1) \ ShopColumns))
                .bottom = .Top + PicY
                .Left = StartX + ShopLeft + ((ShopOffsetX + PicX) * (((i - 1) Mod ShopColumns)))
                .Right = .Left + PicX
            End With

            If CurMouseX >= tempRec.Left And CurMouseX <= tempRec.Right Then
                If CurMouseY >= tempRec.Top And CurMouseY <= tempRec.bottom Then
                    IsShop = i
                    Exit Function
                End If
            End If
        Next
    End Function

    Public Function IsTrade(StartX As Long, StartY As Long) As Long
        Dim tempRec As RectStruct
        Dim i As Long

        For i = 1 To MAX_INV
            With tempRec
                .Top = StartY + TradeTop + ((TradeOffsetY + PicY) * ((i - 1) \ TradeColumns))
                .bottom = .Top + PicY
                .Left = StartX + TradeLeft + ((TradeOffsetX + PicX) * (((i - 1) Mod TradeColumns)))
                .Right = .Left + PicX
            End With

            If CurMouseX >= tempRec.Left And CurMouseX <= tempRec.Right Then
                If CurMouseY >= tempRec.Top And CurMouseY <= tempRec.bottom Then
                    IsTrade = i
                    Exit Function
                End If
            End If
        Next
    End Function

#End Region

End Module