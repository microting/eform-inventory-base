using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormInventoryBase.Migrations
{
    public partial class RenameColumnsAndAddMissingColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemGroups_ItemGroups_ParentId",
                table: "ItemGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemTypes_ItemTypeId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypeDependencys_ItemGroups_ItemGroupId",
                table: "ItemTypeDependencys");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypeDependencys_ItemTypes_ItemTypeId",
                table: "ItemTypeDependencys");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypes_ItemGroups_ItemGroupId",
                table: "ItemTypes");

            migrationBuilder.DropIndex(
                name: "IX_ItemTypeDependencys_ItemGroupId",
                table: "ItemTypeDependencys");

            migrationBuilder.DropColumn(
                name: "Aviable",
                table: "ItemTypeVersions");

            migrationBuilder.DropColumn(
                name: "ProofitProcent",
                table: "ItemTypeVersions");

            migrationBuilder.DropColumn(
                name: "RiscDescription",
                table: "ItemTypeVersions");

            migrationBuilder.DropColumn(
                name: "Aviable",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "ProofitProcent",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "RiscDescription",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "ItemGroupId",
                table: "ItemTypeDependencyVersions");

            migrationBuilder.DropColumn(
                name: "ItemGroupId",
                table: "ItemTypeDependencys");

            migrationBuilder.AlterColumn<int>(
                name: "ItemTypeId",
                table: "ItemVersions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "ItemVersions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "ItemVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SN",
                table: "ItemVersions",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemGroupId",
                table: "ItemTypeVersions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "BaseUnitOfMeasure",
                table: "ItemTypeVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "ItemTypeVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EformId",
                table: "ItemTypeVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfitPercent",
                table: "ItemTypeVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RiskDescription",
                table: "ItemTypeVersions",
                nullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "ItemGroupId",
                table: "ItemTypes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "BaseUnitOfMeasure",
                table: "ItemTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "ItemTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EformId",
                table: "ItemTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfitPercent",
                table: "ItemTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RiskDescription",
                table: "ItemTypes",
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "DependItemTypeId",
                table: "ItemTypeDependencyVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DependItemTypeId",
                table: "ItemTypeDependencys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ItemTypeId",
                table: "Items",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Items",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SN",
                table: "Items",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "ItemGroupVersions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "ItemGroups",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ItemTypeId",
                table: "InventoryTags",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemGroupDependencys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    ItemTypeId = table.Column<int>(nullable: false),
                    ItemGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGroupDependencys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemGroupDependencys_ItemGroups_ItemGroupId",
                        column: x => x.ItemGroupId,
                        principalTable: "ItemGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemGroupDependencys_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemGroupDependencyVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    ItemGroupDependencyId = table.Column<int>(nullable: false),
                    ItemTypeId = table.Column<int>(nullable: false),
                    ItemGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGroupDependencyVersions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypeDependencys_DependItemTypeId",
                table: "ItemTypeDependencys",
                column: "DependItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTags_ItemTypeId",
                table: "InventoryTags",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroupDependencys_ItemGroupId",
                table: "ItemGroupDependencys",
                column: "ItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroupDependencys_ItemTypeId",
                table: "ItemGroupDependencys",
                column: "ItemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTags_ItemTypes_ItemTypeId",
                table: "InventoryTags",
                column: "ItemTypeId",
                principalTable: "ItemTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemGroups_ItemGroups_ParentId",
                table: "ItemGroups",
                column: "ParentId",
                principalTable: "ItemGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemTypes_ItemTypeId",
                table: "Items",
                column: "ItemTypeId",
                principalTable: "ItemTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypeDependencys_ItemTypes_DependItemTypeId",
                table: "ItemTypeDependencys",
                column: "DependItemTypeId",
                principalTable: "ItemTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypeDependencys_ItemTypes_ItemTypeId",
                table: "ItemTypeDependencys",
                column: "ItemTypeId",
                principalTable: "ItemTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypes_ItemGroups_ItemGroupId",
                table: "ItemTypes",
                column: "ItemGroupId",
                principalTable: "ItemGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTags_ItemTypes_ItemTypeId",
                table: "InventoryTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemGroups_ItemGroups_ParentId",
                table: "ItemGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemTypes_ItemTypeId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypeDependencys_ItemTypes_DependItemTypeId",
                table: "ItemTypeDependencys");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypeDependencys_ItemTypes_ItemTypeId",
                table: "ItemTypeDependencys");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypes_ItemGroups_ItemGroupId",
                table: "ItemTypes");

            migrationBuilder.DropTable(
                name: "ItemGroupDependencys");

            migrationBuilder.DropTable(
                name: "ItemGroupDependencyVersions");

            migrationBuilder.DropIndex(
                name: "IX_ItemTypeDependencys_DependItemTypeId",
                table: "ItemTypeDependencys");

            migrationBuilder.DropIndex(
                name: "IX_InventoryTags_ItemTypeId",
                table: "InventoryTags");

            migrationBuilder.DropColumn(
                name: "Available",
                table: "ItemVersions");

            migrationBuilder.DropColumn(
                name: "SN",
                table: "ItemVersions");

            migrationBuilder.DropColumn(
                name: "BaseUnitOfMeasure",
                table: "ItemTypeVersions");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "ItemTypeVersions");

            migrationBuilder.DropColumn(
                name: "EformId",
                table: "ItemTypeVersions");

            migrationBuilder.DropColumn(
                name: "ProfitPercent",
                table: "ItemTypeVersions");

            migrationBuilder.DropColumn(
                name: "RiskDescription",
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
                name: "Comment",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "EformId",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "ProfitPercent",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "RiskDescription",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "StandardCost",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "UnitCost",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "DependItemTypeId",
                table: "ItemTypeDependencyVersions");

            migrationBuilder.DropColumn(
                name: "DependItemTypeId",
                table: "ItemTypeDependencys");

            migrationBuilder.DropColumn(
                name: "Available",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SN",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemTypeId",
                table: "InventoryTags");

            migrationBuilder.AlterColumn<int>(
                name: "ItemTypeId",
                table: "ItemVersions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "ItemVersions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemGroupId",
                table: "ItemTypeVersions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "RiscDescription",
                table: "ItemTypeVersions",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemGroupId",
                table: "ItemTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "RiscDescription",
                table: "ItemTypes",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemGroupId",
                table: "ItemTypeDependencyVersions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemGroupId",
                table: "ItemTypeDependencys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ItemTypeId",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "ItemGroupVersions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "ItemGroups",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypeDependencys_ItemGroupId",
                table: "ItemTypeDependencys",
                column: "ItemGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemGroups_ItemGroups_ParentId",
                table: "ItemGroups",
                column: "ParentId",
                principalTable: "ItemGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemTypes_ItemTypeId",
                table: "Items",
                column: "ItemTypeId",
                principalTable: "ItemTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypeDependencys_ItemGroups_ItemGroupId",
                table: "ItemTypeDependencys",
                column: "ItemGroupId",
                principalTable: "ItemGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypeDependencys_ItemTypes_ItemTypeId",
                table: "ItemTypeDependencys",
                column: "ItemTypeId",
                principalTable: "ItemTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypes_ItemGroups_ItemGroupId",
                table: "ItemTypes",
                column: "ItemGroupId",
                principalTable: "ItemGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
