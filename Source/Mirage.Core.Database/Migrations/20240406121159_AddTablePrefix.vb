Imports Microsoft.EntityFrameworkCore.Migrations
Imports Microsoft.VisualBasic

Namespace Global.Mirage.Core.Database.Migrations
    ''' <inheritdoc />
    Partial Public Class AddTablePrefix
        Inherits Migration

        ''' <inheritdoc />
        Protected Overrides Sub Up(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropPrimaryKey(
                name:="PK_Characters",
                table:="Characters")

            migrationBuilder.DropPrimaryKey(
                name:="PK_Accounts",
                table:="Accounts")

            migrationBuilder.RenameTable(
                name:="Characters",
                newName:="mirage_worlds_characters")

            migrationBuilder.RenameTable(
                name:="Accounts",
                newName:="mirage_worlds_accounts")

            migrationBuilder.AlterColumn(Of String)(
                name:="Name",
                table:="mirage_worlds_characters",
                type:="VARCHAR(255)",
                nullable:=False,
                oldClrType:=GetType(String),
                oldType:="TEXT")

            migrationBuilder.AlterColumn(Of String)(
                name:="Login",
                table:="mirage_worlds_accounts",
                type:="VARCHAR(255)",
                nullable:=False,
                oldClrType:=GetType(String),
                oldType:="TEXT")

            migrationBuilder.AddPrimaryKey(
                name:="PK_mirage_worlds_characters",
                table:="mirage_worlds_characters",
                column:="Name")

            migrationBuilder.AddPrimaryKey(
                name:="PK_mirage_worlds_accounts",
                table:="mirage_worlds_accounts",
                column:="Login")
        End Sub

        ''' <inheritdoc />
        Protected Overrides Sub Down(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropPrimaryKey(
                name:="PK_mirage_worlds_characters",
                table:="mirage_worlds_characters")

            migrationBuilder.DropPrimaryKey(
                name:="PK_mirage_worlds_accounts",
                table:="mirage_worlds_accounts")

            migrationBuilder.RenameTable(
                name:="mirage_worlds_characters",
                newName:="Characters")

            migrationBuilder.RenameTable(
                name:="mirage_worlds_accounts",
                newName:="Accounts")

            migrationBuilder.AlterColumn(Of String)(
                name:="Name",
                table:="Characters",
                type:="TEXT",
                nullable:=False,
                oldClrType:=GetType(String),
                oldType:="VARCHAR(255)")

            migrationBuilder.AlterColumn(Of String)(
                name:="Login",
                table:="Accounts",
                type:="TEXT",
                nullable:=False,
                oldClrType:=GetType(String),
                oldType:="VARCHAR(255)")

            migrationBuilder.AddPrimaryKey(
                name:="PK_Characters",
                table:="Characters",
                column:="Name")

            migrationBuilder.AddPrimaryKey(
                name:="PK_Accounts",
                table:="Accounts",
                column:="Login")
        End Sub
    End Class
End Namespace
