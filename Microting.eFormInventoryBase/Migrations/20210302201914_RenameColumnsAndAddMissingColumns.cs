using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormInventoryBase.Migrations
{
    public partial class RenameColumnsAndAddMissingColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aviable",
                table: "ItemVersions");

            migrationBuilder.DropColumn(
                name: "Aviable",
                table: "ItemTypeVersions");

            migrationBuilder.DropColumn(
                name: "ProofitProcent",
                table: "ItemTypeVersions");

            migrationBuilder.DropColumn(
                name: "Aviable",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "ProofitProcent",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "Aviable",
                table: "Items");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "ItemVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BaseUnitOfMeasure",
                table: "ItemTypeVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfitPercent",
                table: "ItemTypeVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StandardCost",
                table: "ItemTypeVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitCost",
                table: "ItemTypeVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BaseUnitOfMeasure",
                table: "ItemTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfitPercent",
                table: "ItemTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StandardCost",
                table: "ItemTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitCost",
                table: "ItemTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Items",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "ItemVersions");

            migrationBuilder.DropColumn(
                name: "BaseUnitOfMeasure",
                table: "ItemTypeVersions");

            migrationBuilder.DropColumn(
                name: "ProfitPercent",
                table: "ItemTypeVersions");

            migrationBuilder.DropColumn(
                name: "StandardCost",
                table: "ItemTypeVersions");

            migrationBuilder.DropColumn(
                name: "UnitCost",
                table: "ItemTypeVersions");

            migrationBuilder.DropColumn(
                name: "BaseUnitOfMeasure",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "ProfitPercent",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "StandardCost",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "UnitCost",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "Available",
                table: "Items");

            migrationBuilder.AddColumn<bool>(
                name: "Aviable",
                table: "ItemVersions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Aviable",
                table: "ItemTypeVersions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProofitProcent",
                table: "ItemTypeVersions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Aviable",
                table: "ItemTypes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProofitProcent",
                table: "ItemTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Aviable",
                table: "Items",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
