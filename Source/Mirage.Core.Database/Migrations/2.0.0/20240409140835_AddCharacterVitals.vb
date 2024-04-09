Imports Microsoft.EntityFrameworkCore.Migrations
Imports Microsoft.VisualBasic

Namespace Global.Mirage.Core.Database.Migrations
    ''' <inheritdoc />
    Partial Public Class AddCharacterVitals
        Inherits Migration

        ''' <inheritdoc />
        Protected Overrides Sub Up(migrationBuilder As MigrationBuilder)
            migrationBuilder.AddColumn(Of Integer)(
                name:="Vitals_Health",
                table:="mirage_worlds_characters",
                type:="INTEGER",
                nullable:=True)

            migrationBuilder.AddColumn(Of Integer)(
                name:="Vitals_Mana",
                table:="mirage_worlds_characters",
                type:="INTEGER",
                nullable:=True)

            migrationBuilder.AddColumn(Of Integer)(
                name:="Vitals_Stamina",
                table:="mirage_worlds_characters",
                type:="INTEGER",
                nullable:=True)
        End Sub

        ''' <inheritdoc />
        Protected Overrides Sub Down(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropColumn(
                name:="Vitals_Health",
                table:="mirage_worlds_characters")

            migrationBuilder.DropColumn(
                name:="Vitals_Mana",
                table:="mirage_worlds_characters")

            migrationBuilder.DropColumn(
                name:="Vitals_Stamina",
                table:="mirage_worlds_characters")
        End Sub
    End Class
End Namespace
