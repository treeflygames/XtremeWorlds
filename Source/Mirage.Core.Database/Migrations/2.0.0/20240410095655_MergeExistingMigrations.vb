Imports Microsoft.EntityFrameworkCore.Migrations
Imports Microsoft.VisualBasic

Namespace Global.Mirage.Core.Database.Migrations
    ''' <inheritdoc />
    Partial Public Class MergeExistingMigrations
        Inherits Migration

        ''' <inheritdoc />
        Protected Overrides Sub Up(migrationBuilder As MigrationBuilder)
            migrationBuilder.CreateTable(
                name:="mirage_worlds_accounts",
                columns:=Function(table) New With {
                    .AccountId = table.Column(Of Integer)(type:="INTEGER", nullable:=False).
                        Annotation("Sqlite:Autoincrement", True),
                    .Login = table.Column(Of String)(type:="TEXT", nullable:=True),
                    .Password = table.Column(Of String)(type:="TEXT", nullable:=True),
                    .Banned = table.Column(Of Integer)(type:="INTEGER", nullable:=False)
                },
                constraints:=Sub(table)
                    table.PrimaryKey("PK_mirage_worlds_accounts", Function(x) x.AccountId)
                End Sub)

            migrationBuilder.CreateTable(
                name:="mirage_worlds_characters",
                columns:=Function(table) New With {
                    .CharacterId = table.Column(Of Integer)(type:="INTEGER", nullable:=False).
                        Annotation("Sqlite:Autoincrement", True),
                    .AccountId = table.Column(Of Integer)(type:="INTEGER", nullable:=False),
                    .Name = table.Column(Of String)(type:="TEXT", nullable:=True),
                    .Sex = table.Column(Of Byte)(type:="INTEGER", nullable:=False),
                    .JobId = table.Column(Of Integer)(type:="INTEGER", nullable:=False),
                    .SpriteId = table.Column(Of Integer)(type:="INTEGER", nullable:=False),
                    .Level_Level = table.Column(Of Integer)(type:="INTEGER", nullable:=True),
                    .Level_Experience = table.Column(Of Integer)(type:="INTEGER", nullable:=True),
                    .Vitals_Health = table.Column(Of Integer)(type:="INTEGER", nullable:=True),
                    .Vitals_Mana = table.Column(Of Integer)(type:="INTEGER", nullable:=True),
                    .Vitals_Stamina = table.Column(Of Integer)(type:="INTEGER", nullable:=True),
                    .Location_Map = table.Column(Of Integer)(type:="INTEGER", nullable:=True),
                    .Location_X = table.Column(Of Byte)(type:="INTEGER", nullable:=True),
                    .Location_Y = table.Column(Of Byte)(type:="INTEGER", nullable:=True),
                    .Location_Direction = table.Column(Of Byte)(type:="INTEGER", nullable:=True)
                },
                constraints:=Sub(table)
                    table.PrimaryKey("PK_mirage_worlds_characters", Function(x) x.CharacterId)
                End Sub)
        End Sub

        ''' <inheritdoc />
        Protected Overrides Sub Down(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropTable(
                name:="mirage_worlds_accounts")

            migrationBuilder.DropTable(
                name:="mirage_worlds_characters")
        End Sub
    End Class
End Namespace
