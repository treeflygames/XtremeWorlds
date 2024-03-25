
Imports System.IO
Imports System.Xml.Serialization
Imports Core
Imports SFML.Window

Public Class InputSettings
    Public Shared Inputs As InputSettings

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
        Return keyCode = Primary.MoveUp OrElse
               keyCode = Secondary.MoveUp OrElse
               keyCode = Primary.MoveUp2 OrElse
               keyCode = Secondary.MoveUp2
    End Function

    Public Shared Function MoveDown(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.MoveDown OrElse
               keyCode = Secondary.MoveDown OrElse
               keyCode = Primary.MoveDown2 OrElse
               keyCode = Secondary.MoveDown2
    End Function

    Public Shared Function MoveLeft(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.MoveLeft OrElse
               keyCode = Secondary.MoveLeft OrElse
               keyCode = Primary.MoveLeft2 OrElse
               keyCode = Secondary.MoveLeft2
    End Function

    Public Shared Function MoveRight(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.MoveRight OrElse
               keyCode = Secondary.MoveRight OrElse
               keyCode = Primary.MoveRight2 OrElse
               keyCode = Secondary.MoveRight2
    End Function

    Public Shared Function Attack(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.Attack OrElse
               keyCode = Secondary.Attack
    End Function

    Public Shared Function Run(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.Run OrElse
               keyCode = Secondary.Run
    End Function

    Public Shared Function Loot(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.Loot OrElse
               keyCode = Secondary.Loot
    End Function

    Public Shared Function HotBar1(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.HotBar1 OrElse
               keyCode = Secondary.HotBar1
    End Function

    Public Shared Function HotBar2(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.HotBar2 OrElse
               keyCode = Secondary.HotBar2
    End Function

    Public Shared Function HotBar3(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.HotBar3 OrElse
               keyCode = Secondary.HotBar3
    End Function

    Public Shared Function HotBar4(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.HotBar4 OrElse
               keyCode = Secondary.HotBar4
    End Function

    Public Shared Function HotBar5(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.HotBar5 OrElse
               keyCode = Secondary.HotBar5
    End Function

    Public Shared Function HotBar6(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.HotBar6 OrElse
               keyCode = Secondary.HotBar6
    End Function

    Public Shared Function HotBar7(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.HotBar7 OrElse
               keyCode = Secondary.HotBar7
    End Function

    Public Shared Function Inventory(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.Inventory OrElse
               keyCode = Secondary.Inventory
    End Function

    Public Shared Function Character(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.Character OrElse
               keyCode = Secondary.Character
    End Function

    Public Shared Function Skill(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.Skill OrElse
               keyCode = Secondary.Skill
    End Function

    Public Shared Function Settings(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.Settings OrElse
               keyCode = Secondary.Settings
    End Function

    Public Shared Function HudToggle(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.HudToggle OrElse
               keyCode = Secondary.HudToggle
    End Function

    Public Shared Function Admin(keyCode As Keyboard.Key) As Boolean
        Return keyCode = Primary.Admin OrElse
               keyCode = Secondary.Admin
    End Function

     Public Shared Sub Load()
        Dim cf As String = Paths.Config()
        Dim x As New XmlSerializer(GetType(InputSettings), New XmlRootAttribute("Inputs"))

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

        Dim x As New XmlSerializer(GetType(InputSettings), New XmlRootAttribute("Inputs"))
        Dim writer = New StreamWriter(cf)

        x.Serialize(writer, Inputs)
        writer.Close()
    End Sub
End Class  