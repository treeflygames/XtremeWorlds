Imports Microsoft.EntityFrameworkCore.Migrations
Imports Microsoft.VisualBasic

Namespace Global.Mirage.Core.Database.Migrations
    ''' <inheritdoc />
    Partial Public Class AddCharacterSex
        Inherits Migration

        ''' <inheritdoc />
        Protected Overrides Sub Up(migrationBuilder As MigrationBuilder)
            migrationBuilder.AddColumn(Of Byte)(
                name:="Sex",
                table:="mirage_worlds_characters",
                type:="INTEGER",
                nullable:=False,
                defaultValue:=CByte(0))
        End Sub

        ''' <inheritdoc />
        Protected Overrides Sub Down(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropColumn(
                name:="Sex",
                table:="mirage_worlds_characters")
        End Sub
    End Class
End Namespace
