
Imports System.IO
Imports System.Xml.Serialization
Imports Core
Imports SFML.Window

Public Class Inputs
    Public Shared Inputs As Inputs

    Public Class Input

        Public MoveUp As Keyboard.Key = Keyboard.Key.W
        Public MoveDown As Keyboard.Key = Keyboard.Key.S
        Public MoveLeft As Keyboard.Key = Keyboard.Key.A
        Public MoveRight As Keyboard.Key = Keyboard.Key.D
        Public MoveUp2 As Keyboard.Key = Keyboard.Key.Up
        Public MoveLeft2 As Keyboard.Key = Keyboard.Key.Left
        Public MoveRight2 As Keyboard.Key = Keyboard.Key.Right
        Public MoveDown2 As Keyboard.Key = Keyboard.Key.Down

        Public Attack As Keyboard.Key = Keyboard.Key.Z
        Public Run As Keyboard.Key = Keyboard.Key.LShift
        Public Loot As Keyboard.Key = Keyboard.Key.Space

        Public Hotbar1 As Keyboard.Key = Keyboard.Key.NumPad0
        Public Hotbar2 As Keyboard.Key = Keyboard.Key.NumPad1
        Public Hotbar3 As Keyboard.Key = Keyboard.Key.NumPad2
        Public Hotbar4 As Keyboard.Key = Keyboard.Key.NumPad3
        Public Hotbar5 As Keyboard.Key = Keyboard.Key.NumPad4
        Public Hotbar6 As Keyboard.Key = Keyboard.Key.NumPad5
        Public Hotbar7 As Keyboard.Key = Keyboard.Key.NumPad6

        Public Inventory As Keyboard.Key = Keyboard.Key.I
        Public Character As Keyboard.Key = Keyboard.Key.C
        Public Skill As Keyboard.Key = Keyboard.Key.K
        Public Settings As Keyboard.Key = Keyboard.Key.N

        Public HudToggle As Keyboard.Key = Keyboard.Key.F10
        Public Admin As Keyboard.Key = Keyboard.Key.Insert
    End Class

    Public Shared Primary As New Input
    Public Shared Secondary As New Input

    Public Shared Function MoveUp(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.MoveUp Or
               keyCode = Secondary.MoveUp Or
               keyCode = Primary.MoveUp2 Or
               keyCode = Secondary.MoveUp2
    End Function

    Public Shared Function MoveDown(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.MoveDown Or
               keyCode = Secondary.MoveDown Or
               keyCode = Primary.MoveDown2 Or
               keyCode = Secondary.MoveDown2
    End Function

    Public Shared Function MoveLeft(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.MoveLeft Or
               keyCode = Secondary.MoveLeft Or
               keyCode = Primary.MoveLeft2 Or
               keyCode = Secondary.MoveLeft2
    End Function

    Public Shared Function MoveRight(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.MoveRight Or
               keyCode = Secondary.MoveRight Or
               keyCode = Primary.MoveRight2 Or
               keyCode = Secondary.MoveRight2
    End Function

    Public Shared Function Attack(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.Attack Or
               keyCode = Secondary.Attack
    End Function

    Public Shared Function Run(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.Run Or
               keyCode = Secondary.Run
    End Function

    Public Shared Function Loot(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.Loot Or
               keyCode = Secondary.Loot
    End Function

    Public Shared Function HotBar1(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.HotBar1 Or
               keyCode = Secondary.HotBar1
    End Function

    Public Shared Function HotBar2(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.HotBar2 Or
               keyCode = Secondary.HotBar2
    End Function

    Public Shared Function HotBar3(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.HotBar3 Or
               keyCode = Secondary.HotBar3
    End Function

    Public Shared Function HotBar4(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.HotBar4 Or
               keyCode = Secondary.HotBar4
    End Function

    Public Shared Function HotBar5(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.HotBar5 Or
               keyCode = Secondary.HotBar5
    End Function

    Public Shared Function HotBar6(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.HotBar6 Or
               keyCode = Secondary.HotBar6
    End Function

    Public Shared Function HotBar7(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.HotBar7 Or
               keyCode = Secondary.HotBar7
    End Function

    Public Shared Function Inventory(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.Inventory Or
               keyCode = Secondary.Inventory
    End Function

    Public Shared Function Character(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.Character Or
               keyCode = Secondary.Character
    End Function

    Public Shared Function Skill(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.Skill Or
               keyCode = Secondary.Skill
    End Function

    Public Shared Function Settings(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.Settings Or
               keyCode = Secondary.Settings
    End Function

    Public Shared Function HudToggle(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.HudToggle Or
               keyCode = Secondary.HudToggle
    End Function

    Public Shared Function Admin(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.Admin Or
               keyCode = Secondary.Admin
    End Function

     Public Shared Sub Load()
        Dim cf As String = Paths.Config()
        Dim x As New XmlSerializer(GetType(Inputs), New XmlRootAttribute("Inputs"))

        Directory.CreateDirectory(cf)
        cf += "Inputs.xml"

        If Not File.Exists(cf) Then
            File.Create(cf).Dispose()
            Dim writer = New StreamWriter(cf)
            x.Serialize(writer, Inputs)
            writer.Close()
        End If

        Dim reader = New StreamReader(cf)
        Inputs = x.Deserialize(reader)
        reader.Close()
    End Sub

    Public Shared Sub Save()
        Dim cf As String = Paths.Config()

        Directory.CreateDirectory(cf)
        cf += "Inputs.xml"

        Dim x As New XmlSerializer(GetType(Inputs), New XmlRootAttribute("Inputs"))
        Dim writer = New StreamWriter(cf)

        x.Serialize(writer, Inputs)
        writer.Close()
    End Sub
End Class  