using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStormApi.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthFieldsToAgente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Agentes");

            migrationBuilder.DropColumn(
                name: "NombreAgente",
                table: "Agentes");

            migrationBuilder.RenameColumn(
                name: "rango",
                table: "Agentes",
                newName: "Rango");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Agentes",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Agentes",
                newName: "Email");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Agentes",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Agentes",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Agentes",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "Agentes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Agentes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "Agentes");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Agentes");

            migrationBuilder.RenameColumn(
                name: "Rango",
                table: "Agentes",
                newName: "rango");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Agentes",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Agentes",
                newName: "email");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "Agentes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Agentes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Agentes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Agentes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreAgente",
                table: "Agentes",
                type: "TEXT",
                nullable: true);
        }
    }
}
