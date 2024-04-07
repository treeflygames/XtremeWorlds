Imports Microsoft.EntityFrameworkCore.Migrations
Imports Microsoft.VisualBasic

Namespace Global.Mirage.Core.Database.Migrations
    ''' <inheritdoc />
    Partial Public Class AddLocationDataToCharacter
        Inherits Migration

        ''' <inheritdoc />
        Protected Overrides Sub Up(migrationBuilder As MigrationBuilder)
            migrationBuilder.AddColumn(Of Byte)(
                name:="Location_Direction",
                table:="mirage_worlds_characters",
                type:="INTEGER",
                nullable:=True)

            migrationBuilder.AddColumn(Of Integer)(
                name:="Location_Map",
                table:="mirage_worlds_characters",
                type:="INTEGER",
                nullable:=True)

            migrationBuilder.AddColumn(Of Byte)(
                name:="Location_X",
                table:="mirage_worlds_characters",
                type:="INTEGER",
                nullable:=True)

            migrationBuilder.AddColumn(Of Byte)(
                name:="Location_Y",
                table:="mirage_worlds_characters",
                type:="INTEGER",
                nullable:=True)
        End Sub

        ''' <inheritdoc />
        Protected Overrides Sub Down(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropColumn(
                name:="Location_Direction",
                table:="mirage_worlds_characters")

            migrationBuilder.DropColumn(
                name:="Location_Map",
                table:="mirage_worlds_characters")

            migrationBuilder.DropColumn(
                name:="Location_X",
                table:="mirage_worlds_characters")

            migrationBuilder.DropColumn(
                name:="Location_Y",
                table:="mirage_worlds_characters")
        End Sub
    End Class
End Namespace
