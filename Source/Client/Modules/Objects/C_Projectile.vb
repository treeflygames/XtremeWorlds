Imports System.IO
Imports Mirage.Sharp.Asfw
Imports Core
Imports SFML.Graphics
Imports SFML.System

Friend Module C_Projectiles

#Region "Defines"
    Friend NumProjectiles As Integer
    Friend InitProjectileEditor As Boolean
    Friend Const EditorProjectile As Byte = 10
    Friend ProjectileChanged(MAX_PROJECTILES) As Boolean

#End Region

#Region "Sending"
    Sub SendRequestEditProjectile()
        Dim buffer As ByteStream

        buffer = New ByteStream(4)
        buffer.WriteInt32(Packets.ClientPackets.CRequestEditProjectiles)
        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

    Sub SendSaveProjectile(ProjectileNum As Integer)
        Dim buffer As ByteStream

        buffer = New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CSaveProjectile)
        buffer.WriteInt32(ProjectileNum)

        buffer.WriteString((Trim(Projectile(ProjectileNum).Name)))
        buffer.WriteInt32(Projectile(ProjectileNum).Sprite)
        buffer.WriteInt32(Projectile(ProjectileNum).Range)
        buffer.WriteInt32(Projectile(ProjectileNum).Speed)
        buffer.WriteInt32(Projectile(ProjectileNum).Damage)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

    Sub SendRequestProjectile()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CRequestProjectiles)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

    Sub SendClearProjectile(projectileNum As Integer, collisionindex As Integer, collisionType As Byte, collisionZone As Integer)
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(ClientPackets.CClearProjectile)
        buffer.WriteInt32(projectileNum)
        buffer.WriteInt32(collisionindex)
        buffer.WriteInt32(collisionType)
        buffer.WriteInt32(collisionZone)

        Socket.SendData(buffer.Data, buffer.Head)
        buffer.Dispose()

    End Sub

#End Region

#Region "Recieving"

    Friend Sub HandleUpdateProjectile(ByRef data() As Byte)
        Dim projectileNum As Integer
        Dim buffer As New ByteStream(data)
        projectileNum = buffer.ReadInt32

        Projectile(projectileNum).Name = buffer.ReadString
        Projectile(projectileNum).Sprite = buffer.ReadInt32
        Projectile(projectileNum).Range = buffer.ReadInt32
        Projectile(projectileNum).Speed = buffer.ReadInt32
        Projectile(projectileNum).Damage = buffer.ReadInt32

        buffer.Dispose()

    End Sub

    Friend Sub HandleMapProjectile(ByRef data() As Byte)
        Dim i As Integer
        Dim buffer As New ByteStream(data)
        i = buffer.ReadInt32

        With MapProjectile(Player(MyIndex).Map, i)
            .ProjectileNum = buffer.ReadInt32
            .Owner = buffer.ReadInt32
            .OwnerType = buffer.ReadInt32
            .Dir = buffer.ReadInt32
            .X = buffer.ReadInt32
            .Y = buffer.ReadInt32
            .Range = 0
            .Timer = GetTickCount() + 60000
        End With

        buffer.Dispose()

    End Sub

#End Region

#Region "Database"

    Sub ClearProjectile()
        Dim i As Integer

       For i = 1 To MAX_PROJECTILES
            ClearProjectile(i)
        Next

    End Sub

    Sub ClearProjectile(index As Integer)

        Projectile(index).Name = ""
        Projectile(index).Sprite = 0
        Projectile(index).Range = 0
        Projectile(index).Speed = 0
        Projectile(index).Damage = 0

    End Sub

    Sub ClearMapProjectile(projectileNum As Integer)

        MapProjectile(Player(MyIndex).Map, projectileNum).ProjectileNum = 0
        MapProjectile(Player(MyIndex).Map, projectileNum).Owner = 0
        MapProjectile(Player(MyIndex).Map, projectileNum).OwnerType = 0
        MapProjectile(Player(MyIndex).Map, projectileNum).X = 0
        MapProjectile(Player(MyIndex).Map, projectileNum).Y = 0
        MapProjectile(Player(MyIndex).Map, projectileNum).Dir = 0
        MapProjectile(Player(MyIndex).Map, projectileNum).Timer = 0

    End Sub

#End Region

#Region "Drawing"

    Friend Sub CheckProjectile()
        Dim i As Integer

        i = 1

        While File.Exists(Paths.Graphics & "projectiles\" & i & GfxExt)

            NumProjectiles = NumProjectiles + 1
            i = i + 1
        End While

    End Sub

    Friend Sub DrawProjectile(projectileNum As Integer)
        Dim rec As RectStruct
        Dim canClearProjectile As Boolean
        Dim collisionindex As Integer
        Dim collisionType As Byte
        Dim collisionZone As Integer
        Dim xOffset As Integer, yOffset As Integer
        Dim x As Integer, y As Integer
        Dim i As Integer
        Dim sprite As Integer

        ' check to see if it's time to move the Projectile
        If GetTickCount() > MapProjectile(Player(MyIndex).Map, projectileNum).TravelTime Then
            Select Case MapProjectile(Player(MyIndex).Map, projectileNum).Dir
                Case DirectionType.Up
                    MapProjectile(Player(MyIndex).Map, projectileNum).Y = MapProjectile(Player(MyIndex).Map, projectileNum).Y - 1
                Case DirectionType.Down
                    MapProjectile(Player(MyIndex).Map, projectileNum).Y = MapProjectile(Player(MyIndex).Map, projectileNum).Y + 1
                Case DirectionType.Left
                    MapProjectile(Player(MyIndex).Map, projectileNum).X = MapProjectile(Player(MyIndex).Map, projectileNum).X - 1
                Case DirectionType.Right
                    MapProjectile(Player(MyIndex).Map, projectileNum).X = MapProjectile(Player(MyIndex).Map, projectileNum).X + 1
            End Select
            MapProjectile(Player(MyIndex).Map, projectileNum).TravelTime = GetTickCount() + Projectile(MapProjectile(Player(MyIndex).Map, projectileNum).ProjectileNum).Speed
            MapProjectile(Player(MyIndex).Map, projectileNum).Range = MapProjectile(Player(MyIndex).Map, projectileNum).Range + 1
        End If

        x = MapProjectile(Player(MyIndex).Map, projectileNum).X
        y = MapProjectile(Player(MyIndex).Map, projectileNum).Y

        'Check if its been going for over 1 minute, if so clear.
        If MapProjectile(Player(MyIndex).Map, projectileNum).Timer < GetTickCount() Then canClearProjectile = True

        If x > Map.MaxX Or x < 0 Then canClearProjectile = True
        If y > Map.MaxY Or y < 0 Then canClearProjectile = True

        'Check for blocked wall collision
        If canClearProjectile = False Then 'Add a check to prevent crashing
            If Map.Tile(x, y).Type = TileType.Blocked Or Map.Tile(x, y).Type2 = TileType.Blocked Then
                canClearProjectile = True
            End If
        End If

        'Check for npc collision
       For i = 1 To MAX_MAP_NPCS
            If MapNpc(i).X = x And MapNpc(i).Y = y Then
                canClearProjectile = True
                collisionindex = i
                collisionType = TargetType.Npc
                collisionZone = -1
                Exit For
            End If
        Next

        'Check for player collision
       For i = 1 To MAX_PLAYERS
            If IsPlaying(i) And GetPlayerMap(i) = GetPlayerMap(MyIndex) Then
                If GetPlayerX(i) = x And GetPlayerY(i) = y Then
                    canClearProjectile = True
                    collisionindex = i
                    collisionType = TargetType.Player
                    collisionZone = -1
                    If MapProjectile(Player(MyIndex).Map, projectileNum).OwnerType = TargetType.Player Then
                        If MapProjectile(Player(MyIndex).Map, projectileNum).Owner = i Then canClearProjectile = False ' Reset if its the owner of projectile
                    End If
                    Exit For
                End If

            End If
        Next

        'Check if it has hit its maximum range
        If MapProjectile(Player(MyIndex).Map, projectileNum).Range >= Projectile(MapProjectile(Player(MyIndex).Map, projectileNum).ProjectileNum).Range + 1 Then canClearProjectile = True

        'Clear the projectile if possible
        If canClearProjectile = True Then
            'Only send the clear to the server if you're the projectile caster or the one hit (only if owner is not a player)
            If (MapProjectile(Player(MyIndex).Map, projectileNum).OwnerType = TargetType.Player And MapProjectile(Player(MyIndex).Map, projectileNum).Owner = MyIndex) Then
                SendClearProjectile(projectileNum, collisionindex, collisionType, collisionZone)
            End If

            ClearMapProjectile(projectileNum)
            Exit Sub
        End If

        sprite = Projectile(MapProjectile(Player(MyIndex).Map, projectileNum).ProjectileNum).Sprite
        If sprite < 1 Or sprite > NumProjectiles Then Exit Sub

        If ProjectileGfxInfo(sprite).IsLoaded = False Then
            LoadTexture(sprite, 10)
        End If

        'seeying we still use it, lets update timer
        With ProjectileGfxInfo(sprite)
            .TextureTimer = GetTickCount() + 100000
        End With

        ' src rect
        With rec
            .Top = 0
            .Bottom = ProjectileGfxInfo(sprite).Height
            .Left = MapProjectile(Player(MyIndex).Map, projectileNum).Dir * PicX
            .Right = .Left + PicX
        End With

        'Find the offset
        Select Case MapProjectile(Player(MyIndex).Map, projectileNum).Dir
            Case DirectionType.Up
                yOffset = ((MapProjectile(Player(MyIndex).Map, projectileNum).TravelTime - GetTickCount()) / Projectile(MapProjectile(Player(MyIndex).Map, projectileNum).ProjectileNum).Speed) * PicY
            Case DirectionType.Down
                yOffset = -((MapProjectile(Player(MyIndex).Map, projectileNum).TravelTime - GetTickCount()) / Projectile(MapProjectile(Player(MyIndex).Map, projectileNum).ProjectileNum).Speed) * PicY
            Case DirectionType.Left
                xOffset = ((MapProjectile(Player(MyIndex).Map, projectileNum).TravelTime - GetTickCount()) / Projectile(MapProjectile(Player(MyIndex).Map, projectileNum).ProjectileNum).Speed) * PicX
            Case DirectionType.Right
                xOffset = -((MapProjectile(Player(MyIndex).Map, projectileNum).TravelTime - GetTickCount()) / Projectile(MapProjectile(Player(MyIndex).Map, projectileNum).ProjectileNum).Speed) * PicX
        End Select

        x = ConvertMapX(x * PicX)
        y = ConvertMapY(y * PicY)

        Dim tmpSprite As Sprite = New Sprite(ProjectileTexture(sprite)) With {
            .TextureRect = New IntRect(rec.Left, rec.Top, 32, 32),
            .Position = New Vector2f(x, y)
        }
        Window.Draw(tmpSprite)

    End Sub

    Friend Sub EditorProjectile_DrawProjectile()
        Dim iconnum As Integer

        iconnum = frmEditor_Projectile.nudPic.Value

        If iconnum < 1 Or iconnum > NumProjectiles Then
            frmEditor_Projectile.picProjectile.BackgroundImage = Nothing
            Exit Sub
        End If

        If File.Exists(Paths.Graphics & "Projectiles\" & iconnum & GfxExt) Then
            frmEditor_Projectile.picProjectile.BackgroundImage = Drawing.Image.FromFile(Paths.Graphics & "Projectiles\" & iconnum & GfxExt)
        End If

    End Sub
#End Region

#Region "Projectile Editor"

    Friend Sub ProjectileEditorInit()
        EditorIndex = frmEditor_Projectile.lstIndex.SelectedIndex + 1

        With Projectile(EditorIndex)
            frmEditor_Projectile.txtName.Text = Trim$(.Name)
            frmEditor_Projectile.nudPic.Value = .Sprite
            frmEditor_Projectile.nudRange.Value = .Range
            frmEditor_Projectile.nudSpeed.Value = .Speed
            frmEditor_Projectile.nudDamage.Value = .Damage
        End With

        ProjectileChanged(EditorIndex) = True

    End Sub

    Friend Sub ProjectileEditorOk()
        Dim i As Integer

       For i = 1 To MAX_PROJECTILES
            If ProjectileChanged(i) Then
                Call SendSaveProjectile(i)
            End If
        Next

        Editor = -1
        ClearChanged_Projectile()
        SendCloseEditor()
    End Sub

    Friend Sub ProjectileEditorCancel()
        Editor = -1
        ClearChanged_Projectile()
        ClearProjectile()
        SendCloseEditor()
    End Sub

    Friend Sub ClearChanged_Projectile()
        Dim i As Integer

        For i = 1 To MAX_PROJECTILES
            ProjectileChanged(i) = False
        Next

    End Sub

#End Region

End Module