Imports System.IO
Imports System.Reflection

Namespace Paths
    Public Module Paths

        ''' <summary> Gets the base directory of the executing assembly </summary>
        Private ReadOnly Property BaseDirectory As String
            Get
                Return Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)
            End Get
        End Property

        ''' <summary> Returns a combined path with the base directory </summary>
        Private Function GetPath(ParamArray parts() As String) As String
            Return Path.Combine(BaseDirectory, Path.Combine(parts)) & Path.DirectorySeparatorChar
        End Function

        ''' <summary> Returns contents directory </summary>
        Public ReadOnly Property Contents As String
            Get
                Return GetPath("Contents")
            End Get
        End Property

        ''' <summary> Returns database directory </summary>
        Public ReadOnly Property Database As String
            Get
                Return GetPath("Database")
            End Get
        End Property

        ''' <summary> Returns graphics directory </summary>
        Public ReadOnly Property Graphics As String
            Get
                Return GetPath("Contents", "Graphics")
            End Get
        End Property

        ''' <summary> Returns gui directory </summary>
        Public ReadOnly Property Gui As String
            Get
                Return GetPath("Contents", "Graphics", "Gui")
            End Get
        End Property

        ''' <summary> Returns music directory </summary>
        Public ReadOnly Property Music As String
            Get
                Return GetPath("Contents", "Music")
            End Get
        End Property

        ''' <summary> Returns sounds directory </summary>
        Public ReadOnly Property Sounds As String
            Get
                Return GetPath("Contents", "Sounds")
            End Get
        End Property

        ''' <summary> Returns accounts directory </summary>
        Public ReadOnly Property Accounts As String
            Get
                Return GetPath("Database", "Accounts")
            End Get
        End Property

        ''' <summary> Returns account file </summary>
        Public Function Account(index As Integer) As String
            Return Path.Combine(Accounts, $"{index}.dat")
        End Function

        ''' <summary> Returns animations directory </summary>
        Public ReadOnly Property Animations As String
            Get
                Return GetPath("Database", "Animations")
            End Get
        End Property

        ''' <summary> Returns animation file </summary>
        Public Function Animation(index As Integer) As String
            Return Path.Combine(Animations, $"{index}.dat")
        End Function

        ''' <summary> Returns items directory </summary>
        Public ReadOnly Property Items As String
            Get
                Return GetPath("Database", "Items")
            End Get
        End Property

        ''' <summary> Returns item file </summary>
        Public Function Item(index As Integer) As String
            Return Path.Combine(Items, $"{index}.dat")
        End Function

        ''' <summary> Returns logs directory </summary>
        Public ReadOnly Property Logs As String
            Get
                Return GetPath("Logs")
            End Get
        End Property

        ''' <summary> Returns maps directory </summary>
        Public ReadOnly Property Maps As String
            Get
                Return GetPath("Database", "Maps")
            End Get
        End Property

        ''' <summary> Returns map file </summary>
        Public Function Map(index As Integer) As String
            Return Path.Combine(Maps, $"{index}.dat")
        End Function

        ''' <summary> Returns event map file </summary>
        Public Function EventMap(index As Integer) As String
            Return Path.Combine(Maps, $"{index}_event.dat")
        End Function

        ''' <summary> Returns npcs directory </summary>
        Public ReadOnly Property Npcs As String
            Get
                Return GetPath("Database", "Npcs")
            End Get
        End Property

        ''' <summary> Returns npc file </summary>
        Public Function Npc(index As Integer) As String
            Return Path.Combine(Npcs, $"{index}.dat")
        End Function

        ''' <summary> Returns pets directory </summary>
        Public ReadOnly Property Pets As String
            Get
                Return GetPath("Database", "Pets")
            End Get
        End Property

        ''' <summary> Returns pet file </summary>
        Public Function Pet(index As Integer) As String
            Return Path.Combine(Pets, $"{index}.dat")
        End Function

        ''' <summary> Returns projectiles directory </summary>
        Public ReadOnly Property Projectiles As String
            Get
                Return GetPath("Database", "Projectiles")
            End Get
        End Property

        ''' <summary> Returns projectile file </summary>
        Public Function Projectile(index As Integer) As String
            Return Path.Combine(Projectiles, $"{index}.dat")
        End Function

        ''' <summary> Returns quests directory </summary>
        Public ReadOnly Property Quests As String
            Get
                Return GetPath("Database", "Quests")
            End Get
        End Property

        ''' <summary> Returns quest file </summary>
        Public Function Quest(index As Integer) As String
            Return Path.Combine(Quests, $"{index}.dat")
        End Function

        ''' <summary> Returns resources directory </summary>
        Public ReadOnly Property Resources As String
            Get
                Return GetPath("Database", "Resources")
            End Get
        End Property

        ''' <summary> Returns resource file </summary>
        Public Function Resource(index As Integer) As String
            Return Path.Combine(Resources, $"{index}.dat")
        End Function

        ''' <summary> Returns shops directory </summary>
        Public ReadOnly Property Shops As String
            Get
                Return GetPath("Database", "Shops")
            End Get
        End Property

        ''' <summary> Returns shop file </summary>
        Public Function Shop(index As Integer) As String
            Return Path.Combine(Shops, $"{index}.dat")
        End Function

        ''' <summary> Returns skills directory </summary>
        Public ReadOnly Property Skills As String
            Get
                Return GetPath("Database", "Skills")
            End Get
        End Property

        ''' <summary> Returns skill file </summary>
        Public Function Skill(index As Integer) As String
            Return Path.Combine(Skills, $"{index}.dat")
        End Function

        ''' <summary> Returns jobs directory </summary>
        Public ReadOnly Property Jobs As String
            Get
                Return GetPath("Database", "Jobs")
            End Get
        End Property

        ''' <summary> Returns job file </summary>
        Public Function Job(index As Integer) As String
            Return Path.Combine(Jobs, $"{index}.dat")
        End Function
        
        ''' <summary> Returns scripts directory </summary>
        Public ReadOnly Property Scripts As String
            Get
                Return GetPath("Database", "Scripts")
            End Get
        End Property
        
        ''' <summary> Returns script file </summary>
        Public Function Script(index As Integer) As String
            Return Path.Combine(Scripts, $"{index}.dat")
        End Function
        
        ''' <summary> Returns script file </summary>
        Public Function Config As String
            Return GetPath("Database", "Config")
        End Function
    End Module
End Namespace
