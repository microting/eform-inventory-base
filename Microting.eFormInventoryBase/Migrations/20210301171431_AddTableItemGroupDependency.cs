using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormInventoryBase.Migrations
{
    public partial class AddTableItemGroupDependency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypeDependencys_ItemGroups_ItemGroupId",
                table: "ItemTypeDependencys");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypeDependencys_ItemTypes_ItemTypeId",
                table: "ItemTypeDependencys");

            migrationBuilder.DropIndex(
                name: "IX_ItemTypeDependencys_ItemGroupId",
                table: "ItemTypeDependencys");

            migrationBuilder.DropColumn(
                name: "ItemGroupId",
                table: "ItemTypeDependencyVersions");

            migrationBuilder.DropColumn(
                name: "ItemGroupId",
                table: "ItemTypeDependencys");

            migrationBuilder.AddColumn<bool>(
                name: "Aviable",
                table: "ItemVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SN",
                table: "ItemVersions",
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
                name: "DependItemTypeId",
                table: "ItemTypeDependencyVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DependItemTypeId",
                table: "ItemTypeDependencys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Aviable",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SN",
                table: "Items",
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
                name: "IX_ItemGroupDependencys_ItemGroupId",
                table: "ItemGroupDependencys",
                column: "ItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroupDependencys_ItemTypeId",
                table: "ItemGroupDependencys",
                column: "ItemTypeId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypeDependencys_ItemTypes_DependItemTypeId",
                table: "ItemTypeDependencys");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypeDependencys_ItemTypes_ItemTypeId",
                table: "ItemTypeDependencys");

            migrationBuilder.DropTable(
                name: "ItemGroupDependencys");

            migrationBuilder.DropTable(
                name: "ItemGroupDependencyVersions");

            migrationBuilder.DropIndex(
                name: "IX_ItemTypeDependencys_DependItemTypeId",
                table: "ItemTypeDependencys");

            migrationBuilder.DropColumn(
                name: "Aviable",
                table: "ItemVersions");

            migrationBuilder.DropColumn(
                name: "SN",
                table: "ItemVersions");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "ItemTypeVersions");

            migrationBuilder.DropColumn(
                name: "EformId",
                table: "ItemTypeVersions");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "EformId",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "DependItemTypeId",
                table: "ItemTypeDependencyVersions");

            migrationBuilder.DropColumn(
                name: "DependItemTypeId",
                table: "ItemTypeDependencys");

            migrationBuilder.DropColumn(
                name: "Aviable",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SN",
                table: "Items");

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

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypeDependencys_ItemGroupId",
                table: "ItemTypeDependencys",
                column: "ItemGroupId");

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
        }
    }
}
