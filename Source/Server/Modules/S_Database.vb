Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports Core
Imports Core.Types
Imports Microsoft.Extensions.Configuration
Imports Mirage.Core.Database.DbContexts
Imports Mirage.Core.Database.Types
Imports Mirage.Sharp.Asfw
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Npgsql
Imports NpgsqlTypes

Module S_Database
    Dim connectionString As String = ReadConnectionStringFromConfiguration()

    Public Function ReadConnectionStringFromConfiguration() As String
        Dim builder As IConfigurationBuilder = New ConfigurationBuilder() _
                .SetBasePath(AppContext.BaseDirectory) _
                .AddJsonFile("appsettings.database.json", optional:=False, reloadOnChange:=True) _
                .AddJsonFile($"appsettings.database.{If(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), "Production")}.json", optional:=True, reloadOnChange:=True) _
                .AddUserSecrets(Of MirageDbContext)([optional]:=True, reloadOnChange:=True) _
                .AddEnvironmentVariables()

        Dim configuration = builder.Build()

        Dim connectionString = configuration("Database:ConnectionString")

        If String.IsNullOrWhiteSpace(connectionString) Then
            connectionString = "Data Source=Database/Mirage.db"
        End If

        If connectionString.Contains("Filename=") OrElse connectionString.Contains("Data Source=") Then
            Dim dbdir As String = Path.GetDirectoryName(connectionString.Replace("Filename=", "").Replace("Data Source=", ""))

            If Not String.IsNullOrWhiteSpace(dbdir) AndAlso Not Directory.Exists(dbdir) Then
                Dim unused = Directory.CreateDirectory(dbdir)
            End If
        End If

        Return connectionString
    End Function

    Public Sub ExecuteSql(connectionString As String, sql As String)
        Using connection As New NpgsqlConnection(connectionString)
            connection?.Open()

            Using command As New NpgsqlCommand(sql, connection)
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Function DatabaseExists(databaseName As String) As Boolean
        Try
            Dim sql As String = "SELECT 1 FROM pg_database WHERE datname = @databaseName;"

            Using connection As New NpgsqlConnection(connectionString)
                connection.Open()
                Using command As New NpgsqlCommand(sql, connection)
                    command.Parameters.AddWithValue("@databaseName", databaseName)

                    Using reader As NpgsqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            Return True
                        Else
                            Return False
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub CreateDatabase(databaseName As String)
        If Not DatabaseExists("mirage") Then
            Dim sql As String = $"CREATE DATABASE {databaseName};"

            ' Connect to the "postgres" maintenance database
            Dim builder As New NpgsqlConnectionStringBuilder(connectionString)
            builder.Database = "postgres"

            Dim maintenanceConnectionString As String = builder.ConnectionString

            ExecuteSql(maintenanceConnectionString, sql)
        End If
    End Sub

    Public Function RowExistsByColumn(columnName As String, value As Int64, tableName As String) As Boolean
        Dim sql As String = $"SELECT EXISTS (SELECT 1 FROM {tableName} WHERE {columnName} = @value);"

        Using connection As New NpgsqlConnection(connectionString)
            connection.Open()

            Using command As New NpgsqlCommand(sql, connection)
                command.Parameters.AddWithValue("@value", value)

                Dim exists As Boolean = command.ExecuteScalar()
                Return exists
            End Using
        End Using
    End Function

    Sub UpdateRow(id As Int64, data As String, table As String, columnName As String)
        Dim sqlCheck As String = $"SELECT column_name FROM information_schema.columns WHERE table_name='{table}' AND column_name='{columnName}';"

        Using connection As New NpgsqlConnection(connectionString)
            connection.Open()

            ' Check if column exists
            Using commandCheck As New NpgsqlCommand(sqlCheck, connection)
                Dim result As Object = commandCheck.ExecuteScalar()

                ' If column exists, then proceed with update
                If result IsNot Nothing Then
                    Dim sqlUpdate As String = $"UPDATE {table} SET {columnName} = @data WHERE id = @id;"

                    Using commandUpdate As New NpgsqlCommand(sqlUpdate, connection)
                        Dim jsonString As String = data.ToString()
                        commandUpdate.Parameters.AddWithValue("@data", NpgsqlDbType.Jsonb, jsonString)
                        commandUpdate.Parameters.AddWithValue("@id", id)

                        commandUpdate.ExecuteNonQuery()
                    End Using
                Else
                    Console.WriteLine($"Column '{columnName}' does not exist in table {table}.")
                End If
            End Using
        End Using
    End Sub

    Public Function StringToHex(input As String) As String
        Dim byteArray() As Byte = Encoding.UTF8.GetBytes(input)
        Dim hex As New StringBuilder(byteArray.Length * 2)

        For Each b As Byte In byteArray
            hex.AppendFormat("{0:x2}", b)
        Next

        Return hex.ToString()
    End Function

    Public Function HexToNumber(hexString As String) As Int64
        If String.IsNullOrWhiteSpace(hexString) Or Not Regex.IsMatch(hexString, "^[0-9a-fA-F]+$") Then
            Return 0
        End If

        Return Int64.Parse(hexString, NumberStyles.HexNumber)
    End Function

    Public Function GenerateIdFromString(input As String) As Int64
        Return HexToNumber(StringToHex(input))
    End Function

    Public Sub UpdateRowByColumn(columnName As String, value As Int64, targetColumn As String, newValue As String, tableName As String)
        Dim sql As String = $"UPDATE {tableName} SET {targetColumn} = @newValue::jsonb WHERE {columnName} = @value;"

        Dim jsonData As JObject = JObject.Parse(newValue) ' Parse the string into a JObject

        Using connection As New NpgsqlConnection(connectionString)
            connection.Open()

            Using command As New NpgsqlCommand(sql, connection)
                command.Parameters.AddWithValue("@value", value)
                command.Parameters.AddWithValue("@newValue", jsonData.ToString()) ' Convert JObject back to string

                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub CreateTables()
        Dim dataTable As String = "id SERIAL PRIMARY KEY, data jsonb"
        Dim playerTable As String = "id BIGINT PRIMARY KEY, data jsonb, bank jsonb"

        For i = 1 To MAX_CHARS
            playerTable += $", character{i} jsonb"
        Next

        Dim tableNames As String() = {"job", "item", "map", "npc", "shop", "skill", "resource", "animation", "pet", "projectile", "moral"}

        For Each tableName In tableNames
            CreateTable(tableName, dataTable)
        Next

        CreateTable("account", playerTable)
    End Sub

    Public Sub CreateTable(tableName As String, layout As String)
        Using conn As New NpgsqlConnection(connectionString)
            conn.Open()

            Using cmd As New NpgsqlCommand()
                cmd.Connection = conn
                cmd.CommandText = $"CREATE TABLE IF NOT EXISTS {tableName} ({layout});"
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Async Function GetData(tableName As String) As Task(Of List(Of Int64))
        Dim ids As New List(Of Int64)

        Using conn As New NpgsqlConnection(connectionString)
            Await conn.OpenAsync()

            ' Define a query
            Dim cmd As New NpgsqlCommand($"SELECT id FROM {tableName}", conn)

            ' Execute a query
            Using reader As NpgsqlDataReader = Await cmd.ExecuteReaderAsync()
                ' Read all rows and output the first column in each row
                While Await reader.ReadAsync()
                    Dim id = Await reader.GetFieldValueAsync(Of Int64)(0)
                    ids.Add(id)
                End While
            End Using
        End Using

        Return ids
    End Function

    Public Function RowExists(id As Int64, table As String) As Boolean
        Dim sql As String = $"SELECT EXISTS (SELECT 1 FROM {table} WHERE id = @id);"

        Using connection As New NpgsqlConnection(connectionString)
            connection.Open()

            Using command As New NpgsqlCommand(sql, connection)
                command.Parameters.AddWithValue("@id", id)

                Using reader As NpgsqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        Return reader.GetBoolean(0)
                    Else
                        Return False
                    End If
                End Using
            End Using
        End Using
    End Function

    Public Sub InsertRow(id As Int64, data As String, tableName As String)
        Dim jsonData As JObject = JObject.Parse(data) ' Parse the string into a JObject

        Using conn As New NpgsqlConnection(connectionString)
            conn.Open()

            Using cmd As New NpgsqlCommand()
                cmd.Connection = conn
                cmd.CommandText = $"INSERT INTO {tableName} (id, data) VALUES (@id, @data::jsonb);"
                cmd.Parameters.AddWithValue("@id", id)
                cmd.Parameters.AddWithValue("@data", jsonData.ToString()) ' Convert JObject back to string

                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub InsertRow(id As Int64, data As String, tableName As String, columnName As String)
        Dim jsonData As JObject = JObject.Parse(data) ' Parse the string into a JObject

        Using conn As New NpgsqlConnection(connectionString)
            conn.Open()

            Using cmd As New NpgsqlCommand()
                cmd.Connection = conn
                cmd.CommandText = $"INSERT INTO {tableName} (id, data) VALUES (@id, @data::jsonb);"
                cmd.Parameters.AddWithValue("@id", id)
                cmd.Parameters.AddWithValue("@" + columnName, jsonData.ToString()) ' Convert JObject back to string

                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub InsertRowByColumn(id As Int64, data As String, tableName As String, dataColumn As String, idColumn As String)
        Dim jsonData As JObject = JObject.Parse(data) ' Parse the string into a JObject

        Dim sql As String = $"INSERT INTO {tableName} ({idColumn}, {dataColumn}) VALUES (@id, @data::jsonb);"

        Using connection As New NpgsqlConnection(connectionString)
            connection.Open()

            Using command As New NpgsqlCommand(sql, connection)
                command.Parameters.AddWithValue("@id", id)
                command.Parameters.AddWithValue("@data", jsonData.ToString()) ' Convert JObject back to string

                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function SelectRow(id As Int64, tableName As String, columnName As String) As JObject
        Dim sql As String = $"SELECT {columnName} FROM {tableName} WHERE id = @id;"

        Using connection As New NpgsqlConnection(connectionString)
            connection.Open()

            Using command As New NpgsqlCommand(sql, connection)
                command.Parameters.AddWithValue("@id", id)

                Using reader As NpgsqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        Dim jsonbData As String = reader.GetString(0)
                        Dim jsonObject As JObject = JObject.Parse(jsonbData)
                        Return jsonObject
                    Else
                        Return Nothing
                    End If
                End Using
            End Using
        End Using
    End Function

    Public Function SelectRowByColumn(columnName As String, value As Int64, tableName As String, dataColumn As String) As JObject
        Dim sql As String = $"SELECT {dataColumn} FROM {tableName} WHERE {columnName} = @value;"

        Using connection As New NpgsqlConnection(connectionString)
            connection.Open()

            Using command As New NpgsqlCommand(sql, connection)
                command.Parameters.AddWithValue("@value", value)

                Using reader As NpgsqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        ' Check if the first column is not null
                        If Not reader.IsDBNull(0) Then
                            Dim jsonbData As String = reader.GetString(0)
                            Dim jsonObject As JObject = JObject.Parse(jsonbData)
                            Return jsonObject
                        Else
                            ' Handle null value or return null JObject...
                            Return Nothing
                        End If
                    Else
                        Return Nothing
                    End If
                End Using
            End Using
        End Using
    End Function

#Region "Var"

    Public Function GetVar(filePath As String, section As String, key As String) As String
        Dim isInSection As Boolean = False

        For Each line As String In File.ReadAllLines(filePath)
            If line.Trim().Equals("[" & section & "]", StringComparison.OrdinalIgnoreCase) Then
                isInSection = True
            ElseIf line.StartsWith("[") And line.EndsWith("]") Then
                isInSection = False
            ElseIf isInSection And line.Contains("=") Then
                Dim parts() As String = line.Split(New Char() {"="c}, 2)
                If parts(0).Trim().Equals(key, StringComparison.OrdinalIgnoreCase) Then
                    Return parts(1).Trim()
                End If
            End If
        Next

        Return String.Empty ' Key not found
    End Function

    Public Sub PutVar(filePath As String, section As String, key As String, value As String)
        Dim lines As New List(Of String)(File.ReadAllLines(filePath))
        Dim updated As Boolean = False
        Dim isInSection As Boolean = False
        Dim i As Integer = 0

        While i < lines.Count
            If lines(i).Trim().Equals("[" & section & "]", StringComparison.OrdinalIgnoreCase) Then
                isInSection = True
                i += 1
                While i < lines.Count And Not lines(i).StartsWith("[")
                    If lines(i).Contains("=") Then
                        Dim parts() As String = lines(i).Split(New Char() {"="c}, 2)
                        If parts(0).Trim().Equals(key, StringComparison.OrdinalIgnoreCase) Then
                            lines(i) = key & "=" & value
                            updated = True
                            Exit While
                        End If
                    End If
                    i += 1
                End While
                Exit While
            End If
            i += 1
        End While

        If Not updated Then
            ' Key not found, add it to the section
            lines.Add("[" & section & "]")
            lines.Add(key & "=" & value)
        End If

        File.WriteAllLines(filePath, lines)
    End Sub


#End Region

#Region "Job"

    Sub ClearJobs()
        Dim i As Integer

        ReDim Job(MAX_JOBS)

        For i = 1 To MAX_JOBS
            ClearJob(i)
        Next
    End Sub

    Sub ClearJob(jobNum As Integer)
        ReDim Job(jobNum).Stat(StatType.Count - 1)
        ReDim Job(jobNum).StartItem(5)
        ReDim Job(jobNum).StartValue(5)

        Job(jobNum).Name = ""
        Job(jobNum).Desc = ""
        Job(jobNum).StartMap = 1
        Job(jobNum).MaleSprite = 1
        Job(jobNum).FemaleSprite = 1
    End Sub

    Sub LoadJob(jobNum As Integer)
        Dim data As JObject

        data = SelectRow(jobNum, "job", "data")

        If data Is Nothing Then
            ClearJob(jobNum)
            Exit Sub
        End If

        Dim jobData = JObject.FromObject(data).ToObject(Of JobStruct)()
        Job(jobNum) = jobData
    End Sub

    Sub LoadJobs()
        Dim i As Integer

        For i = 1 To MAX_JOBS
            LoadJob(i)
        Next
    End Sub

    Sub SaveJob(jobNum As Integer)
        Dim json As String = JsonConvert.SerializeObject(Job(jobNum)).ToString()

        If RowExists(jobNum, "job") Then
            UpdateRow(jobNum, json, "job", "data")
        Else
            InsertRow(jobNum, "data", "job")
        End If
    End Sub

    Sub SaveJobs()
        Dim i As Integer

        For i = 1 To MAX_JOBS
            SaveJob(i)
        Next
    End Sub
#End Region

#Region "Maps"

    Sub ClearMaps()
        ReDim Map(MAX_MAPS)
        ReDim MapNPC(MAX_MAPS)

        For i = 1 To MAX_MAPS
            ReDim MapNPC(i).Npc(MAX_MAP_NPCS)
            ReDim Map(i).Npc(MAX_MAP_NPCS)
        Next

        ReDim Switches(MAX_SWITCHES)
        ReDim Variables(NAX_VARIABLES)
        ReDim TempEventMap(MAX_MAPS)

        For i = 1 To MAX_MAPS
            ClearMap(i)
        Next
    End Sub

    Sub ClearMap(mapNum As Integer)
        Dim x As Integer
        Dim y As Integer

        Map(mapNum).Tileset = 1
        Map(mapNum).Name = ""
        Map(mapNum).MaxX = MAX_MAPX
        Map(mapNum).MaxY = MAX_MAPY
        ReDim Map(mapNum).Npc(MAX_MAP_NPCS)
        ReDim Map(mapNum).Tile(Map(mapNum).MaxX, Map(mapNum).MaxY)

        For x = 0 To MAX_MAPX
            For y = 0 To MAX_MAPY
                ReDim Map(mapNum).Tile(x, y).Layer(LayerType.Count - 1)
            Next
        Next

        Map(mapNum).EventCount = 0
        ReDim Map(mapNum).Events(0)

        ' Reset the values for if a player is on the map or not
        PlayersOnMap(mapNum) = False
        Map(mapNum).Tileset = 1
        Map(mapNum).Name = ""
        Map(mapNum).Music = ""
        Map(mapNum).MaxX = MAX_MAPX
        Map(mapNum).MaxY = MAX_MAPY
    End Sub

    Public Sub SaveMap(mapNum As Integer)
        Dim json As String = JsonConvert.SerializeObject(Map(mapNum)).ToString()

        If RowExists(mapNum, "map") Then
            UpdateRow(mapNum, json, "map", "data")
        Else
            InsertRow(mapNum, json, "map")
        End If
    End Sub

    Sub LoadMaps()
        Dim i As Integer

        For i = 1 To MAX_MAPS
            LoadMap(i)
        Next
    End Sub

    Sub LoadMap(mapNum As Integer)
        ' Get the base directory of the application
        Dim baseDir As String = AppDomain.CurrentDomain.BaseDirectory

        ' Construct the path to the "maps" directory
        Dim mapsDir As String = Path.Combine(baseDir, "maps")
        Directory.CreateDirectory(mapsDir)

        CacheResources(mapNum)

        If File.Exists(mapsDir & "\cs\map" & mapNum & ".ini") Then
            Dim csMap As CSMapStruct = LoadCSMap(mapNum)
            Map(mapNum) = MapFromCSMap(csMap)
            Exit Sub
        End If

        If File.Exists(mapsDir & "\xw\map" & mapNum & ".dat") Then
            Dim xwMap As XWMapStruct = LoadXWMap(mapsDir & "\xw\map" & mapNum.ToString() & ".dat")
            Map(mapNum) = MapFromXWMap(xwMap)
            Exit Sub
        End If

        If File.Exists(mapsDir & "\sd\map" & MapNum & ".dat" )
            'Dim sdMap As SDMapStruct = loadsdmap(mapsDir & "\sd\map" & mapNum.ToString() & ".dat")
            'Map(mapNum) = MapFromSDMap(sdMap)
            Exit Sub
        End If

        Dim data As JObject

        data = SelectRow(mapNum, "map", "data")

        If data Is Nothing Then
            ClearMap(mapNum)
            Exit Sub
        End If

        Dim mapData = JObject.FromObject(data).ToObject(Of MapStruct)()
        Map(mapNum) = mapData
    End Sub

    Public Function LoadCSMap(MapNum As Long) As CSMapStruct
        Dim filename As String
        Dim i As Long
        Dim x As Long, y As Long
        Dim csMap As CSMapStruct

        ' Load map data
        filename = AppDomain.CurrentDomain.BaseDirectory & "\maps\cs\map" & MapNum & ".ini"

        ReDim csMap.MapData.Npc(MAX_MAP_NPCS)

        ' General
        With csMap.MapData
            .Name = GetVar(filename, "General", "Name")
            .Music = GetVar(filename, "General", "Music")
            .Moral = Val(GetVar(filename, "General", "Moral"))
            .Up = Val(GetVar(filename, "General", "Up"))
            .Down = Val(GetVar(filename, "General", "Down"))
            .Left = Val(GetVar(filename, "General", "Left"))
            .Right = Val(GetVar(filename, "General", "Right"))
            .BootMap = Val(GetVar(filename, "General", "BootMap"))
            .BootX = Val(GetVar(filename, "General", "BootX"))
            .BootY = Val(GetVar(filename, "General", "BootY"))
            .MaxX = Val(GetVar(filename, "General", "MaxX"))
            .MaxY = Val(GetVar(filename, "General", "MaxY"))

            .Weather = Val(GetVar(filename, "General", "Weather"))
            .WeatherIntensity = Val(GetVar(filename, "General", "WeatherIntensity"))

            .Fog = Val(GetVar(filename, "General", "Fog"))
            .FogSpeed = Val(GetVar(filename, "General", "FogSpeed"))
            .FogOpacity = Val(GetVar(filename, "General", "FogOpacity"))

            .Red = Val(GetVar(filename, "General", "Red"))
            .Green = Val(GetVar(filename, "General", "Green"))
            .Blue = Val(GetVar(filename, "General", "Blue"))
            .Alpha = Val(GetVar(filename, "General", "Alpha"))

            .BossNpc = Val(GetVar(filename, "General", "BossNpc"))
            For i = 1 To 30
                .Npc(i) = Val(GetVar(filename, "General", "Npc" & i))
            Next
        End With

        ' Redim the map
        ReDim csMap.Tile(csMap.MapData.MaxX, csMap.MapData.MaxY)

        filename = AppDomain.CurrentDomain.BaseDirectory & "\maps\cs\map" & MapNum & ".dat"

        Using fileStream As New FileStream(filename, FileMode.Open, FileAccess.Read),
            binaryReader As New BinaryReader(fileStream)

            With csMap
                ' Assuming MAX_X and MAX_Y are the dimensions of your map
                Dim MAX_X As Integer = csMap.MapData.MaxX
                Dim MAX_Y As Integer = csMap.MapData.MaxY

                For x = 0 To MAX_X
                    For y = 0 To MAX_Y
                        ' Resize arrays only once if possible
                        ReDim csMap.Tile(x, y).Autotile(LayerType.Count - 1)
                        ReDim csMap.Tile(x, y).Layer(LayerType.Count - 1)

                        With csMap.Tile(x, y)
                            .Type = binaryReader.ReadByte()
                            .Data1 = binaryReader.ReadInt32()
                            .Data2 = binaryReader.ReadInt32()
                            .Data3 = binaryReader.ReadInt32()
                            .Data4 = binaryReader.ReadInt32()
                            .Data5 = binaryReader.ReadInt32()

                            For i = 1 To LayerType.Count - 1
                                .Autotile(i) = binaryReader.ReadByte()
                            Next
                            .DirBlock = binaryReader.ReadByte()

                            For i = 1 To LayerType.Count - 1
                                .Layer(i).TileSet = binaryReader.ReadInt32()
                                .Layer(i).x = binaryReader.ReadInt32()
                                .Layer(i).y = binaryReader.ReadInt32()
                            Next
                        End With
                    Next
                Next
            End With
        End Using

        Return csMap
    End Function

    Sub ClearMapItem(index As Integer, mapNum As Integer)
        MapItem(mapNum, index).PlayerName = ""
    End Sub

    Sub ClearMapItems()
        Dim x As Integer
        Dim y As Integer

        For y = 1 To MAX_MAPS
            For x = 1 To MAX_MAP_ITEMS
                ClearMapItem(x, y)
            Next
        Next

    End Sub

    Public Function LoadXWMap(ByVal fileName As String) As XWMapStruct
        Dim encoding As New ASCIIEncoding()
        Dim xwMap As New XWMapStruct

        ReDim xwMap.Tile(15, 11)
        ReDim xwMap.NPC(14)

        Using fs As New FileStream(fileName, FileMode.Open)
            Using reader As New BinaryReader(fs)
                'OFFSET 0: The first 20 bytes are the map name.
                xwMap.Name = encoding.GetString(reader.ReadBytes(20))

                'OFFSET 20: The revision is stored here @ 4 bytes.
                xwMap.Revision = reader.ReadInt32()

                'OFFSET 24: Contains the map moral as a byte.
                xwMap.Moral = reader.ReadByte()

                'OFFSET 25: Stored as 2 bytes, the map UP.
                xwMap.Up = reader.ReadInt16()

                'OFFSET 27: Stored as 2 bytes, the map DOWN.
                xwMap.Down = reader.ReadInt16()

                'OFFSET 29: Stored as 2 bytes, the map LEFT.
                xwMap.Left = reader.ReadInt16()

                'OFFSET 31: Stored as 2 bytes, the map RIGHT.
                xwMap.Right = reader.ReadInt16()

                'OFFSET 33: Stored as 2 bytes, the map music.
                xwMap.Music = reader.ReadInt16()

                'OFFSET 35: Stored as 2 bytes, the Boot map.
                xwMap.BootMap = reader.ReadInt16()

                'OFFSET 37: Stored as a single byte, the boot X
                xwMap.BootX = reader.ReadByte()

                'OFFSET 38: Stored as a single byte, the boot Y
                xwMap.BootY = reader.ReadByte()

                'OFFSET 39: Stored as two bytes, the Shop ID.
                xwMap.Shop = reader.ReadInt16()

                'OFFSET 41: Stored as a single byte, is the map indoors?
                xwMap.Indoors = (reader.ReadByte() = 1)

                ' Now, we decode the Tiles
                For y As Integer = 0 To 11
                    For x As Integer = 0 To 15
                        xwMap.Tile(x, y).Ground = reader.ReadInt16() ' 42
                        xwMap.Tile(x, y).Mask = reader.ReadInt16() ' 44
                        xwMap.Tile(x, y).MaskAnim = reader.ReadInt16() ' 46
                        xwMap.Tile(x, y).Fringe = reader.ReadInt16() ' 48
                        xwMap.Tile(x, y).Type = CType(reader.ReadByte(), TileType) ' 50
                        xwMap.Tile(x, y).Data1 = reader.ReadInt16() ' 51
                        xwMap.Tile(x, y).Data2 = reader.ReadInt16() ' 53
                        xwMap.Tile(x, y).Data3 = reader.ReadInt16() ' 55
                        xwMap.Tile(x, y).Type2 = CType(reader.ReadByte(), TileType) ' 57
                        xwMap.Tile(x, y).Data1_2 = reader.ReadInt16() ' 59
                        xwMap.Tile(x, y).Data2_2 = reader.ReadInt16() ' 61
                        xwMap.Tile(x, y).Data3_2 = reader.ReadInt16() ' 63
                        xwMap.Tile(x, y).Mask2 = reader.ReadInt16() ' 64
                        xwMap.Tile(x, y).Mask2Anim = reader.ReadInt16() ' 66
                        xwMap.Tile(x, y).FringeAnim = reader.ReadInt16() ' 68
                        xwMap.Tile(x, y).Roof = reader.ReadInt16() ' 70
                        xwMap.Tile(x, y).Fringe2Anim = reader.ReadInt16() ' 72
                    Next
                Next

                For i As Integer = 1 To 14
                    xwMap.NPC(i) = reader.ReadInt32
                Next
            End Using
        End Using

        Return xwMap
    End Function

    Private Function ConvertXWTileToTile(ByVal xwTile As XWTileStruct) As TileStruct
        Dim tile As New TileStruct

        ' Constants for the new tileset
        Const TilesPerRow As Integer = 8
        Const RowsPerTileset As Integer = 16

        ' Initialize the layers
        ReDim tile.Layer(LayerType.Count - 1)

        ' Process each layer
        For i As Integer = LayerType.Ground To LayerType.Count - 1
            Dim tileNumber As Integer = 0

            ' Select the appropriate tile number for each layer
            Select Case i
                Case LayerType.Ground
                    tileNumber = xwTile.Ground
                Case LayerType.Mask
                    tileNumber = xwTile.Mask
                Case LayerType.MaskAnim
                    tileNumber = xwTile.MaskAnim
                Case LayerType.Cover
                    tileNumber = xwTile.Mask2
                Case LayerType.CoverAnim
                    tileNumber = xwTile.Mask2Anim
                Case LayerType.Fringe
                    tileNumber = xwTile.Fringe
                Case LayerType.FringeAnim
                    tileNumber = xwTile.FringeAnim
                Case LayerType.Roof
                    tileNumber = xwTile.Roof
                Case LayerType.RoofAnim
                    tileNumber = xwTile.Fringe2Anim
            End Select

            ' Ensure tileNumber is non-negative
            If tileNumber > 0 Then
                tile.Layer(i).Tileset = Math.Floor(tileNumber / TilesPerRow / RowsPerTileset) + 1
                tile.Layer(i).Y = Math.Floor(tileNumber / TilesPerRow) Mod RowsPerTileset
                tile.Layer(i).X = tileNumber Mod TilesPerRow
            End If
        Next

        ' Copy over additional data fields
        tile.Data1 = xwTile.Data1
        tile.Data2 = xwTile.Data2
        tile.Data3 = xwTile.Data3
        tile.Data1_2 = xwTile.Data1_2
        tile.Data2_2 = xwTile.Data2_2
        tile.Data3_2 = xwTile.Data3_2
        tile.Type = xwTile.Type
        tile.Type2 = xwTile.Type2

        SetXWTileType(tile.Type)
        SetXWTileType(tile.Type2)

        Return tile
    End Function

    Public Sub SetXWTileType(ByRef tileType As TileType)
        Select Case tileType
            Case XWTileType.Warp
                tileType = tileType.Warp
            Case XWTileType.Damage
                tileType = TileType.Trap
            Case XWTileType.Heal
                tileType = TileType.Heal
            Case XWTileType.Shop
                tileType = TileType.Shop
            Case XWTileType.No_Xing
                tileType = Tiletype.NoXing
            Case XWTileType.Key
                tileType = TileType.Key
            Case XWTileType.Key_Open
                tileType = TileType.KeyOpen
            Case XWTileType.Door
                tileType = TileType.Door
            Case XWTileType.Walkthru
                tileType = TileType.WalkThrough
            Case XWTileType.Arena
                tileType = TileType.Arena
            Case XWTileType.Roof
                tileType = TileType.Roof
            Case XWTileType.Direction_Block
        End Select
    End Sub

    Public Function MapFromXWMap(xwMap As XWMapStruct) As MapStruct
        Dim mwMap As New MapStruct

        ReDim mwMap.Tile(15, 11)
        ReDim mwMap.Npc(MAX_MAP_NPCS)

        mwMap.Name = xwMap.Name.Trim()
        mwMap.Music = "Music" & xwMap.Music.ToString() & ".mid"
        mwMap.Revision = CInt(xwMap.Revision)
        mwMap.Moral = xwMap.Moral
        mwMap.Up = xwMap.Up
        mwMap.Down = xwMap.Down
        mwMap.Left = xwMap.Left
        mwMap.Right = xwMap.Right
        mwMap.BootMap = xwMap.BootMap
        mwMap.BootX = xwMap.BootX
        mwMap.BootY = xwMap.BootY
        mwMap.Shop = xwMap.Shop

        ' Convert Byte to Boolean (False if 0, True otherwise)
        mwMap.Indoors = xwMap.Indoors <> 0

        ' Loop through each tile in xwMap and copy the data to map
        For y As Integer = 0 To 11
            For x As Integer = 0 To 15
                mwMap.Tile(x, y) = ConvertXWTileToTile(xwMap.Tile(x, y))
            Next
        Next

        ' NPC array conversion (Long to Integer), if necessary
        If xwMap.NPC IsNot Nothing Then
            mwMap.Npc = Array.ConvertAll(xwMap.NPC, Function(i) CInt(i))
        End If

        mwMap.Weather = xwMap.Weather
        mwMap.NoRespawn = xwMap.Respawn = 0
        mwMap.MaxX = 15
        mwMap.MaxY = 11

        Return mwMap
    End Function

    Public Function MapFromCSMap(csMap As CSMapStruct) As MapStruct
        Dim mwMap As MapStruct

        ReDim mwMap.Npc(MAX_MAP_NPCS)

        mwMap.Name = csMap.MapData.Name
        mwMap.MaxX = csMap.MapData.MaxX
        mwMap.MaxY = csMap.MapData.MaxY
        mwMap.BootMap = csMap.MapData.BootMap
        mwMap.BootX = csMap.MapData.BootX
        mwMap.BootY = csMap.MapData.BootY
        mwMap.Moral = csMap.MapData.Moral
        mwMap.Music = csMap.MapData.Music
        mwMap.Fog = csMap.MapData.Fog
        mwMap.Weather = csMap.MapData.Weather
        mwMap.WeatherIntensity = csMap.MapData.WeatherIntensity
        mwMap.Up = csMap.MapData.Up
        mwMap.Down = csMap.MapData.Down
        mwMap.Left = csMap.MapData.Left
        mwMap.Right = csMap.MapData.Right
        mwMap.MapTintA = csMap.MapData.Alpha
        mwMap.MapTintR = csMap.MapData.Red
        mwMap.MapTintG = csMap.MapData.Green
        mwMap.MapTintB = csMap.MapData.Blue
        mwMap.FogOpacity = csMap.MapData.FogOpacity
        mwMap.FogSpeed = csMap.MapData.FogSpeed

        ReDim mwMap.Tile(mwMap.MaxX, mwMap.MaxY)

        ' Loop through each tile in xwMap and copy the data to map
        For y As Integer = 0 To mwMap.MaxX
            For x As Integer = 0 To mwMap.MaxY
                ' Resize arrays only once if possible
                ReDim mwMap.Tile(x, y).Layer(LayerType.Count - 1)

                mwMap.Tile(x, y).Data1 = csMap.Tile(x, y).Data1
                mwMap.Tile(x, y).Data2 = csMap.Tile(x, y).Data2
                mwMap.Tile(x, y).Data3 = csMap.Tile(x, y).Data3
                mwMap.Tile(x, y).DirBlock = csMap.Tile(x, y).DirBlock

                For i As Integer = LayerType.Ground To LayerType.Count - 1
                    mwMap.Tile(x, y).Layer(i).X = csMap.Tile(x, y).Layer(i).x
                    mwMap.Tile(x, y).Layer(i).Y = csMap.Tile(x, y).Layer(i).y
                    mwMap.Tile(x, y).Layer(i).Tileset = csMap.Tile(x, y).Layer(i).TileSet
                    mwMap.Tile(x, y).Layer(i).AutoTile = csMap.Tile(x, y).Autotile(i)
                Next
            Next
        Next

        For i As Integer = 1 To 30
            mwMap.Npc(i) = csMap.MapData.Npc(i)
        Next

        Return mwMap
    End Function

    Private Function MapFromSDMap(sdMap As SDMapStruct) As MapStruct
        Dim mwMap As MapStruct

        mwMap.Name = sdMap.Name
        mwMap.Music = sdMap.Music
        mwMap.Revision = sdMap.Revision

        mwMap.Up = sdMap.Up
        mwMap.Down = sdMap.Down
        mwMap.Left = sdMap.Left
        mwMap.Right = sdMap.Right

        mwMap.Tileset = sdMap.Tileset
        mwMap.MaxX = sdMap.MaxX
        mwMap.MaxY = sdMap.MaxY

        Return mwMap
    End Function

#End Region

#Region "Npcs"

    Sub SaveNpc(npcNum As Integer)
        Dim json As String = JsonConvert.SerializeObject(NPC(npcNum)).ToString()

        If RowExists(npcNum, "npc") Then
            UpdateRow(npcNum, json, "npc", "data")
        Else
            InsertRow(npcNum, json, "npc")
        End If
    End Sub

    Sub LoadNpcs()
        Dim i As Integer

        For i = 1 To MAX_NPCS
            LoadNpc(i)
        Next
    End Sub

    Sub LoadNpc(npcNum As Integer)
        Dim data As JObject

        data = SelectRow(npcNum, "npc", "data")

        If data Is Nothing Then
            ClearNpc(npcNum)
            Exit Sub
        End If

        Dim npcData = JObject.FromObject(data).ToObject(Of NpcStruct)()
        NPC(npcNum) = npcData
    End Sub

    Sub ClearMapNpc(index As Integer, mapNum As Integer)
        MapNPC(mapNum).Npc(index).Num = 0
        ReDim MapNPC(mapNum).Npc(index).Vital(VitalType.Count - 1)
        ReDim MapNPC(mapNum).Npc(index).SkillCd(MAX_NPC_SKILLS)
    End Sub

    Sub ClearAllMapNpcs()
        Dim i As Integer

        For i = 1 To MAX_MAPS
            ClearMapNpcs(i)
        Next

    End Sub

    Sub ClearMapNpcs(mapNum As Integer)
        Dim x As Integer

        For x = 1 To MAX_MAP_NPCS
            ClearMapNpc(x, mapNum)
        Next

    End Sub

    Sub ClearNpc(index As Integer)
        NPC(index).Name = ""
        NPC(index).AttackSay = ""

        ReDim NPC(index).Stat(StatType.Count - 1)

        For i = 1 To MAX_DROP_ITEMS
            ReDim NPC(index).DropChance(5)
            ReDim NPC(index).DropItem(5)
            ReDim NPC(index).DropItemValue(5)
            ReDim NPC(index).Skill(MAX_NPC_SKILLS)
        Next
    End Sub

    Sub ClearNpcs()
        For i = 1 To MAX_NPCS
            ClearNpc(i)
        Next

    End Sub

#End Region

#Region "Shops"

    Sub SaveShop(shopNum As Integer)
        Dim json As String = JsonConvert.SerializeObject(Shop(shopNum)).ToString()

        If RowExists(shopNum, "shop") Then
            UpdateRow(shopNum, json, "shop", "data")
        Else
            InsertRow(shopNum, json, "shop")
        End If
    End Sub

    Sub LoadShops()
        Dim i As Integer

        For i = 1 To MAX_SHOPS
            LoadShop(i)
        Next

    End Sub

    Sub LoadShop(shopNum As Integer)
        Dim data As JObject

        data = SelectRow(shopNum, "shop", "data")

        If data Is Nothing Then
            ClearShop(shopNum)
            Exit Sub
        End If

        Dim shopData = JObject.FromObject(data).ToObject(Of ShopStruct)()
        Shop(shopNum) = shopData
    End Sub

    Sub ClearShop(index As Integer)
        Shop(index) = Nothing
        Shop(index).Name = ""

        For i = 1 To MAX_TRADES
            ReDim Shop(index).TradeItem(i)
        Next
    End Sub

    Sub ClearShops()
        For i = 1 To MAX_SHOPS      
            Call ClearShop(i)
        Next
    End Sub

#End Region

#Region "Skills"

    Sub SaveSkill(skillNum As Integer)
        Dim json As String = JsonConvert.SerializeObject(Skill(skillNum)).ToString()

        If RowExists(skillNum, "skill") Then
            UpdateRow(skillNum, json, "skill", "data")
        Else
            InsertRow(skillNum, json, "skill")
        End If
    End Sub

    Sub LoadSkills()
        Dim i As Integer

        For i = 1 To MAX_SKILLS
            LoadSkill(i)
        Next

    End Sub

    Sub LoadSkill(skillNum As Integer)
        Dim data As JObject

        data = SelectRow(skillNum, "skill", "data")

        If data Is Nothing Then
            ClearSkill(skillNum)
            Exit Sub
        End If

        Dim skillData = JObject.FromObject(data).ToObject(Of SkillStruct)()
        Skill(skillNum) = skillData
    End Sub

    Sub ClearSkill(index As Integer)
        Skill(index).Name = ""
        Skill(index).LevelReq = 1
    End Sub

    Sub ClearSkills()
        Dim i As Integer

        For i = 1 To MAX_SKILLS
            ClearSkill(i)
        Next

    End Sub

#End Region

#Region "Players"

    Sub SaveAllPlayersOnline()
        For i = 1 To Socket.HighIndex()
            If Not IsPlaying(i) Then Continue For
            SaveCharacter(i, TempPlayer(i).Slot)
            SaveBank(i)
        Next
    End Sub

    Function SaveAccount(ByVal index As Integer) As Boolean
        If FindAccount(Accounts(index).Login) IsNot Nothing Then
            Dim unused1 = DatabaseContext.Accounts.Update(Accounts(index))

            Return DatabaseContext.TrySaveChanges()
        Else
            Dim unused1 = DatabaseContext.Accounts.Add(Accounts(index))

            Return DatabaseContext.TrySaveChanges()
        End If

        Return False
    End Function

    Function RegisterAccount(ByVal index As Integer, ByVal username As String, ByVal password As String) As Boolean
        If FindAccount(username) Is Nothing Then
            Dim account As New Account With {
                .Login = username,
                .Password = password
            }

            Dim unused1 = DatabaseContext.Accounts.Add(account)

            Accounts(index) = account

            Return DatabaseContext.TrySaveChanges()
        End If

        Return False
    End Function

    Function FindAccount(ByVal username As String)
        Return (From a In DatabaseContext.Accounts.ToList()
                Where Trim$(a.Login.ToLower()) = Trim$(username.ToLower())
                Select a).FirstOrDefault()
    End Function

    Function LoadAccount(ByVal index As Integer, ByVal username As String)
        Dim account As Account = FindAccount(username)

        If account IsNot Nothing Then
            Accounts(index) = account

            Return True
        End If

        Return False
    End Function

    Sub ClearAccount(index As Integer)
        If Accounts(index) Is Nothing Then
            Accounts(index) = Nothing
        End If
        Accounts(index) = New Account()

        ClearPlayer(index)
    End Sub

    Sub ClearPlayer(index As Integer)
        Player(index).Access = AdminType.Player
        ReDim TempPlayer(MAX_PLAYERS)

        For i = 1 To MAX_PLAYERS
            ReDim TempPlayer(i).SkillCd(MAX_PLAYER_SKILLS)
            ReDim TempPlayer(i).PetSkillCd(4)
            ReDim TempPlayer(i).TradeOffer(MAX_INV)
        Next

        ReDim TempPlayer(index).SkillCd(MAX_PLAYER_SKILLS)
        ReDim TempPlayer(index).PetSkillCd(4)
        TempPlayer(index).Editor = -1

        ClearBank(index)
        ClearCharacter(index)
    End Sub

#End Region

#Region "Bank"
    Friend Sub LoadBank(index As Integer)
        Dim data As JObject
        data = SelectRowByColumn("id", GenerateIdFromString(GetPlayerLogin(index)), "account", "bank")

        If data Is Nothing Then
            ClearBank(index)
            Exit Sub
        End If

        Dim bankData = JObject.FromObject(data).ToObject(Of BankStruct)()
        Bank(index) = bankData
    End Sub

    Sub SaveBank(index As Integer)
        Dim json As String = JsonConvert.SerializeObject(Bank(index)).ToString()
        Dim username As String = GetPlayerLogin(index)
        Dim id As Int64 = GenerateIdFromString(username)

        If RowExistsByColumn("id", id, "account") Then
            UpdateRowByColumn("id", id, "bank", json, "account")
        Else
            InsertRowByColumn(id, json, "account", "bank", "id")
        End If
    End Sub

    Sub ClearBank(index As Integer)
        ReDim Bank(index).Item(MAX_BANK)

        For i = 1 To MAX_BANK
            Bank(index).Item(i).Num = 0
            Bank(index).Item(i).Value = 0
        Next
    End Sub

#End Region

#Region "Characters"
    Sub ClearCharacter(index As Integer)
        Player(index).Name = ""
        Player(index).Job = 0
        Player(index).Dir = 0

        ReDim Player(index).Equipment(EquipmentType.Count - 1)
        For i = 1 To EquipmentType.Count - 1
            Player(index).Equipment(i) = 0
        Next

        ReDim Player(index).Inv(MAX_INV)
        For i = 1 To MAX_INV
            Player(index).Inv(i).Num = 0
            Player(index).Inv(i).Value = 0
        Next

        Player(index).Exp = 0
        Player(index).Level = 0
        Player(index).Map = 1
        Player(index).Name = ""
        Player(index).Pk = 0
        Player(index).Points = 0
        Player(index).Sex = 0

        ReDim Player(index).Skill(MAX_PLAYER_SKILLS)
        For i = 1 To MAX_PLAYER_SKILLS
            Player(index).Skill(i).Num = 0
            Player(index).Skill(i).CD = 0
        Next

        Player(index).Sprite = 0

        ReDim Player(index).Stat(StatType.Count - 1)
        For i = 1 To StatType.Count - 1
            Player(index).Stat(i) = 0
        Next

        ReDim Player(index).Vital(VitalType.Count - 1)
        For i = 1 To VitalType.Count - 1
            Player(index).Vital(i) = 0
        Next

        Player(index).X = 0
        Player(index).Y = 0

        ReDim Player(index).Hotbar(MAX_HOTBAR)
        For i = 1 To MAX_HOTBAR
            Player(index).Hotbar(i).Slot = 0
            Player(index).Hotbar(i).SlotType = 0
        Next

        ReDim Player(index).Switches(MAX_SWITCHES)
        For i = 1 To MAX_SWITCHES
            Player(index).Switches(i) = 0
        Next
        ReDim Player(index).Variables(NAX_VARIABLES)
        For i = 1 To NAX_VARIABLES
            Player(index).Variables(i) = 0
        Next

        ReDim Player(index).GatherSkills(ResourceType.Count - 1)
        For i = 1 To ResourceType.Count - 1
            Player(index).GatherSkills(i).SkillLevel = 1
            Player(index).GatherSkills(i).SkillCurExp = 0
            SetPlayerGatherSkillMaxExp(index, i, GetSkillNextLevel(index, i))
        Next

        For i = 1 To EquipmentType.Count - 1
            Player(index).Equipment(i) = 0
        Next

        Player(index).Pet.Num = 0
        Player(index).Pet.Health = 0
        Player(index).Pet.Mana = 0
        Player(index).Pet.Level = 0

        ReDim Player(index).Pet.Stat(StatType.Count - 1)

        For i = 1 To StatType.Count - 1
            Player(index).Pet.Stat(i) = 0
        Next

        ReDim Player(index).Pet.Skill(4)
        For i = 1 To 4
            Player(index).Pet.Skill(i) = 0
        Next

        Player(index).Pet.X = 0
        Player(index).Pet.Y = 0
        Player(index).Pet.Dir = 0
        Player(index).Pet.Alive = 0
        Player(index).Pet.AttackBehaviour = 0
        Player(index).Pet.AdoptiveStats = 0
        Player(index).Pet.Points = 0
        Player(index).Pet.Exp = 0
    End Sub

    Function LoadCharacter(index As Integer, charNum As Integer) As Boolean
        Dim data As JObject

        data = SelectRowByColumn("id", GenerateIdFromString(GetPlayerLogin(index)), "account", "character" & charNum.ToString)

        If data Is Nothing Then
            Return False
        End If

        Dim characterData = JObject.FromObject(data).ToObject(Of PlayerStruct)()

        If characterData.Name = "" Then
            Return False
        End If

        Player(index) = characterData
        Return True
    End Function

    Sub SaveCharacter(index As Integer, slot As Integer)
        Dim json As String = JsonConvert.SerializeObject(Player(index)).ToString()
        Dim id As Int64 = GenerateIdFromString(GetPlayerLogin(index))

        If slot < 1 Or slot > MAX_CHARS Then Exit Sub

        If RowExistsByColumn("id", id, "account") Then
            UpdateRowByColumn("id", id, "character" & slot.ToString(), json, "account")
        Else
            InsertRowByColumn(id, json, "account", "character" & slot.ToString(), "id")
        End If
    End Sub

    Sub AddChar(index As Integer, slot As Integer, name As String, Sex As Byte, jobNum As Byte, sprite As Integer)
        Dim n As Integer, i As Integer

        If Len(Trim$(Player(index).Name)) = 0 Then
            Player(index).Name = name
            Player(index).Sex = Sex
            Player(index).Job = jobNum
            Player(index).Sprite = sprite

            Player(index).Level = 1

            For n = 1 To StatType.Count - 1
                Player(index).Stat(n) = Job(jobNum).Stat(n)
            Next

            Player(index).Dir = DirectionType.Down
            Player(index).Map = Job(jobNum).StartMap
            Player(index).X = Job(jobNum).StartX
            Player(index).Y = Job(jobNum).StartY
            Player(index).Dir = DirectionType.Down

            For i = 1 To VitalType.Count - 1
                Call SetPlayerVital(index, i, GetPlayerMaxVital(index, i))
            Next

            ' set starter equipment
            For n = 1 To 5
                If Job(jobNum).StartItem(n) > 0 Then
                    Player(index).Inv(n).Num = Job(jobNum).StartItem(n)
                    Player(index).Inv(n).Value = Job(jobNum).StartValue(n)
                End If
            Next

            ' set skills
            For i = 1 To ResourceType.Count - 1
                Player(index).GatherSkills(i).SkillLevel = 1
                Player(index).GatherSkills(i).SkillCurExp = 0
                SetPlayerGatherSkillMaxExp(index, i, GetSkillNextLevel(index, i))
            Next

            SaveCharacter(index, slot)
        End If

    End Sub

#End Region

#Region "Banning"

    Sub ServerBanIndex(BanPlayerindex As Integer)
        Dim filename As String
        Dim IP As String
        Dim F As Integer
        Dim i As Integer

        filename = Paths.Database & "banlist.txt"

        ' Make sure the file exists
        If Not File.Exists("data\banlist.txt") Then
            F = FreeFile()
        End If

        ' Cut off last portion of ip
        IP = Socket.ClientIp(BanPlayerindex)

        For i = Len(IP) To 1 Step -1

            If Mid$(IP, i, 1) = "." Then
                Exit For
            End If

        Next

        Accounts(BanPlayerindex).Banned = True

        IP = Mid$(IP, 1, i)
        AddTextToFile(IP, "banlist.txt")
        GlobalMsg(GetPlayerName(BanPlayerindex) & " has been banned from " & Types.Settings.GameName & " by " & "the Server" & "!")
        Addlog("The Server" & " has banned " & GetPlayerName(BanPlayerindex) & ".", ADMIN_LOG)
        AlertMsg(BanPlayerindex, DialogueMsg.Banned)
    End Sub

    Function IsBanned(index As Integer, IP As String) As Boolean
        Dim filename As String, line As String

        filename = Paths.Database & "banlist.txt"

        ' Check if file exists
        If Not File.Exists("data\banlist.txt") Then
            Return False
        End If

        Dim sr As StreamReader = New StreamReader(filename)

        Do While sr.Peek() >= 0
            ' Is banned?
            line = sr.ReadLine()
            If Trim$(LCase$(line)) = Trim$(LCase$(Mid$(IP, 1, Len(line)))) Then
                IsBanned = True
            End If
        Loop

        sr.Close()

        If Accounts(index).Banned Then
            IsBanned = True
        End If

    End Function

    Sub BanIndex(BanPlayerindex As Integer, BannedByindex As Integer)
        Dim filename As String = Paths.Database & "banlist.txt"
        Dim IP As String, i As Integer

        ' Make sure the file exists
        If Not File.Exists(filename) Then File.Create(filename).Dispose()

        ' Cut off last portion of ip
        IP = Socket.ClientIp(BanPlayerindex)

        For i = Len(IP) To 1 Step -1

            If Mid$(IP, i, 1) = "." Then
                Exit For
            End If

        Next

        Accounts(BanPlayerindex).Banned = True

        IP = Mid$(IP, 1, i)
        AddTextToFile(IP, "banlist.txt")
        GlobalMsg(GetPlayerName(BanPlayerindex) & " has been banned from " & Types.Settings.GameName & " by " & GetPlayerName(BannedByindex) & "!")
        Addlog(GetPlayerName(BannedByindex) & " has banned " & GetPlayerName(BanPlayerindex) & ".", ADMIN_LOG)
        AlertMsg(BanPlayerindex, DialogueMsg.Banned)
    End Sub

#End Region

#Region "Data Functions"
    Function JobData(jobNum As Integer) As Byte()
        Dim n As Integer, q As Integer
        Dim buffer As New ByteStream(4)

        buffer.WriteString((Job(jobNum).Name))
        buffer.WriteString((Job(jobNum).Desc))

        buffer.WriteInt32(Job(jobNum).MaleSprite)
        buffer.WriteInt32(Job(jobNum).FemaleSprite)

        For i = 1 To StatType.Count - 1
            buffer.WriteInt32(Job(jobNum).Stat(i))
        Next

        For q = 1 To 5
            buffer.WriteInt32(Job(jobNum).StartItem(q))
            buffer.WriteInt32(Job(jobNum).StartValue(q))
        Next

        buffer.WriteInt32(Job(jobNum).StartMap)
        buffer.WriteByte(Job(jobNum).StartX)
        buffer.WriteByte(Job(jobNum).StartY)
        buffer.WriteInt32(Job(jobNum).BaseExp)

        Return buffer.ToArray()
    End Function

    Function NpcsData() As Byte()
        Dim buffer As New ByteStream(4)

        For i = 1 To MAX_NPCS
            If Not Len(Trim$(NPC(i).Name)) > 0 Then Continue For
            buffer.WriteBlock(NpcData(i))
        Next
        Return buffer.ToArray
    End Function

    Function NpcData(NpcNum As Integer) As Byte()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(NpcNum)
        buffer.WriteInt32(NPC(NpcNum).Animation)
        buffer.WriteString(NPC(NpcNum).AttackSay)
        buffer.WriteByte(NPC(NpcNum).Behaviour)

        For i = 1 To MAX_DROP_ITEMS
            buffer.WriteInt32(NPC(NpcNum).DropChance(i))
            buffer.WriteInt32(NPC(NpcNum).DropItem(i))
            buffer.WriteInt32(NPC(NpcNum).DropItemValue(i))
        Next

        buffer.WriteInt32(NPC(NpcNum).Exp)
        buffer.WriteByte(NPC(NpcNum).Faction)
        buffer.WriteInt32(NPC(NpcNum).HP)
        buffer.WriteString((NPC(NpcNum).Name))
        buffer.WriteByte(NPC(NpcNum).Range)
        buffer.WriteByte(NPC(NpcNum).SpawnTime)
        buffer.WriteInt32(NPC(NpcNum).SpawnSecs)
        buffer.WriteInt32(NPC(NpcNum).Sprite)

        For i = 1 To StatType.Count - 1
            buffer.WriteByte(NPC(NpcNum).Stat(i))
        Next

        For i = 1 To MAX_NPC_SKILLS
            buffer.WriteByte(NPC(NpcNum).Skill(i))
        Next

        buffer.WriteInt32(NPC(NpcNum).Level)
        buffer.WriteInt32(NPC(NpcNum).Damage)
        Return buffer.ToArray
    End Function

    Function ShopsData() As Byte()
        Dim buffer As New ByteStream(4)

        For i = 1 To MAX_SHOPS
            If Not Len(Trim$(Shop(i).Name)) > 0 Then Continue For
            buffer.WriteBlock(ShopData(i))
        Next
        Return buffer.ToArray
    End Function

    Function ShopData(shopNum As Integer) As Byte()
        Dim buffer As New ByteStream(4)

        buffer.WriteInt32(shopNum)
        buffer.WriteInt32(Shop(shopNum).BuyRate)
        buffer.WriteString((Shop(shopNum).Name))
        buffer.WriteInt32(Shop(shopNum).Face)

        For i = 1 To MAX_TRADES
            buffer.WriteInt32(Shop(shopNum).TradeItem(i).CostItem)
            buffer.WriteInt32(Shop(shopNum).TradeItem(i).CostValue)
            buffer.WriteInt32(Shop(shopNum).TradeItem(i).Item)
            buffer.WriteInt32(Shop(shopNum).TradeItem(i).ItemValue)
        Next
        Return buffer.ToArray
    End Function

    Function SkillsData() As Byte()
        Dim buffer As New ByteStream(4)

        For i = 1 To MAX_SKILLS
            If Not Len(Trim$(Skill(i).Name)) > 0 Then Continue For
            buffer.WriteBlock(SkillData(i))
        Next
        Return buffer.ToArray
    End Function

    Function SkillData(skillnum As Integer) As Byte()
        Dim buffer As New ByteStream(4)

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
        buffer.WriteString((Skill(skillnum).Name))
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
        Return buffer.ToArray
    End Function


#End Region

End Module