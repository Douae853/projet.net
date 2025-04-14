using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_asp_net.Migrations.Client
{
    /// <inheritdoc />
    public partial class AddTelephoneToClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Téléphone",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ville",
                table: "Clients",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Téléphone",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ville",
                table: "Clients");
        }
    }
}
