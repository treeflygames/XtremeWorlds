Imports System.Drawing
Imports Core

Public Module C_Constants
    Public LastLeftClickTime As Integer
    Public DoubleClickTImer As Integer = 500 ' Time in milliseconds for double-click detection

    Public Const ChatBubbleWidth As Integer = 300

    Public Const Chat_Timer As Long = 20000

    Public Const EffectTypeFadein As Integer = 1
    Public Const EffectTypeFadeout As Integer = 2
    Public Const EffectTypeFlash As Integer = 3
    Public Const EffectTypeFog As Integer = 4
    Public Const EffectTypeWeather As Integer = 5
    Public Const EffectTypeTint As Integer = 6

    ' Font variables
    Public Const Georgia As String = "Georgia.ttf"
    Public Const Arial As String = "Arial.ttf"
    Public Const Verdana As String = "Verdana.ttf"
    Public Const FontSize As Byte = 10

    ' Chat variables
    Public Const ChatLines As Long = 200
    Public Const ChatWidth As Long = 316

    ' Bank constants
    Public Const BankTop As Long = 28
    Public Const BankLeft As Long = 9
    Public Const BankOffsetY As Long = 6
    Public Const BankOffsetX As Long = 6
    Public Const BankColumns As Long = 10

    ' Inventory constants
    Public Const InvTop As Long = 28
    Public Const InvLeft As Long = 9
    Public Const InvOffsetY As Long = 6
    Public Const InvOffsetX As Long = 6
    Public Const InvColumns As Long = 5

    ' Character consts
    Public Const EqTop As Long = 315
    Public Const EqLeft As Long = 11
    Public Const EqOffsetX As Long = 8
    Public Const EqColumns As Long = 4

    ' Skill constants
    Public Const SkillTop As Long = 28
    Public Const SkillLeft As Long = 9
    Public Const SkillOffsetY As Long = 6
    Public Const SkillOffsetX As Long = 6
    Public Const SkillColumns As Long = 5

    ' Hotbar constants
    Public Const HotbarTop As Long = 0
    Public Const HotbarLeft As Long = 8
    Public Const HotbarOffsetX As Long = 41

    ' Shop constants
    Public Const ShopTop As Long = 28
    Public Const ShopLeft As Long = 9
    Public Const ShopOffsetY As Long = 6
    Public Const ShopOffsetX As Long = 6
    Public Const ShopColumns As Long = 7

    ' Trade
    Public Const TradeTop As Long = 0
    Public Const TradeLeft As Long = 0
    Public Const TradeOffsetY As Long = 6
    Public Const TradeOffsetX As Long = 6
    Public Const TradeColumns As Long = 5

    ' Gfx Path and variables
    Public Const GfxExt As String = ".png"

    Public MapGrid As Boolean
    Public EyeDropper As Boolean
    Public HistoryIndex As Integer
    Public HideLayers As Boolean
    Public Night As Boolean

    ' Speed moving vars
    Public Const WalkSpeed As Byte = 2
    Public Const RunSpeed As Byte = 4

    ' Tile size constants
    Public Const PicX As Integer = 32
    Public Const PicY As Integer = 32

    ' Sprite, item, skill size constants
    Public Const SizeX As Integer = 32
    Public Const SizeY As Integer = 32

    ' ********************************************************
    ' * The values below must match with the server's values *
    ' ********************************************************

    ' Map
    Public Const MaxTileHistory As Byte = 50
End Module