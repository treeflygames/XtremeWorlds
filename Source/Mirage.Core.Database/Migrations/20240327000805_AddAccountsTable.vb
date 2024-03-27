Imports Microsoft.EntityFrameworkCore.Migrations
Imports Microsoft.VisualBasic

Namespace Global.Mirage.Core.Database.Migrations
    ''' <inheritdoc />
    Partial Public Class AddAccountsTable
        Inherits Migration

        ''' <inheritdoc />
        Protected Overrides Sub Up(migrationBuilder As MigrationBuilder)
            migrationBuilder.CreateTable(
                name:="Accounts",
                columns:=Function(table) New With {
                    .Login = table.Column(Of String)(type:="TEXT", nullable:=False),
                    .Password = table.Column(Of String)(type:="TEXT", nullable:=True),
                    .Banned = table.Column(Of Boolean)(type:="INTEGER", nullable:=False)
                },
                constraints:=Sub(table)
                    table.PrimaryKey("PK_Accounts", Function(x) x.Login)
                End Sub)
        End Sub

        ''' <inheritdoc />
        Protected Overrides Sub Down(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropTable(
                name:="Accounts")
        End Sub
    End Class
End Namespace
