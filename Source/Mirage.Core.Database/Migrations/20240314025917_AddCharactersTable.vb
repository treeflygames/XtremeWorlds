Imports Microsoft.EntityFrameworkCore.Migrations
Imports Microsoft.VisualBasic

Namespace Global.Mirage.Core.Database.Migrations
    ''' <inheritdoc />
    Partial Public Class AddCharactersTable
        Inherits Migration

        ''' <inheritdoc />
        Protected Overrides Sub Up(migrationBuilder As MigrationBuilder)
            migrationBuilder.CreateTable(
                name:="Characters",
                columns:=Function(table) New With {
                    .Name = table.Column(Of String)(type:="TEXT", nullable:=False)
                },
                constraints:=Sub(table)
                    table.PrimaryKey("PK_Characters", Function(x) x.Name)
                End Sub)
        End Sub

        ''' <inheritdoc />
        Protected Overrides Sub Down(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropTable(
                name:="Characters")
        End Sub
    End Class
End Namespace
