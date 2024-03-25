Imports Core
Imports SFML.Graphics
Imports SFML.System

Public Module C_Types
    Public ActionMsg(Byte.MaxValue) As ActionMsgStruct
    Public Blood(Byte.MaxValue) As BloodStruct
    Public Chat(ChatLines) As ChatStruct
    Public TileLights As List(Of LightTileStruct)
    Public MapNames(MAX_MAPS) As String
    Public Tile(,) As TileStruct
    Public TileHistory() As TileHistoryStruct
    Public Autotile(,) As AutotileStruct
    Public MapEvents() As MapEventStruct

    Public Structure RectangleStruct
        Dim Top As Integer
        Dim Right As Integer
        Dim Bottom As Integer
        Dim Left As Integer
    End Structure

    Public Structure PointStruct
        Dim X As Integer
        Dim Y As Integer
    End Structure

    Public Structure QuarterTileStruct
        Dim QuarterTile() As PointStruct
        Dim RenderState As Byte
        Dim SrcX() As Integer
        Dim SrcY() As Integer
    End Structure

    Public Structure AutotileStruct
        Dim Layer() As QuarterTileStruct
        Dim ExLayer() As QuarterTileStruct
    End Structure

    ' autotiling
    Friend AutoIn(4) As PointStruct
    Friend AutoNw(4) As PointStruct
    Friend AutoNe(4) As PointStruct
    Friend AutoSw(4) As PointStruct
    Friend AutoSe(4) As PointStruct

    Public Structure ChatStruct
        Dim Text As String
        Dim Color As Integer
        Dim Channel As Byte
        Dim Visible As Boolean
        Dim Timer As Long
    End Structure

    Public Structure SkillAnimStruct
        Dim Skillnum As Integer
        Dim Timer As Integer
        Dim FramePointer As Integer
    End Structure

    Public Structure ChatBubbleStruct
        Dim Msg As String
        Dim Color As Integer
        Dim Target As Integer
        Dim TargetType As Byte
        Dim Timer As Integer
        Dim Active As Boolean
    End Structure

    Public Structure MapResourceStruct
        Dim X As Integer
        Dim Y As Integer
        Dim State As Byte
    End Structure

    Public Structure ActionMsgStruct
        Dim Message As String
        Dim Created As Integer
        Dim Type As Integer
        Dim Color As Integer
        Dim Scroll As Integer
        Dim X As Integer
        Dim Y As Integer
        Dim Timer As Integer
    End Structure

    Public Structure BloodStruct
        Dim Sprite As Integer
        Dim Timer As Integer
        Dim X As Integer
        Dim Y As Integer
    End Structure

    Public Structure LightTileStruct
        Public Tiles As List(Of Vector2i)
        Public IsFlicker As Boolean
        Public IsSmooth As Boolean
        Public Scale As Vector2f
    End Structure

    Public Structure TextStruct
        Public Text As String
        Public Color As Color
    End Structure

End Module