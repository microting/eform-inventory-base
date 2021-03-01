using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormInventoryBase.Migrations
{
    public partial class ChangeForeignKeyCanBeNull : Migration
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
                name: "FK_ItemTypes_ItemGroups_ItemGroupId",
                table: "ItemTypes");

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

            migrationBuilder.AlterColumn<int>(
                name: "ItemGroupId",
                table: "ItemTypeVersions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ItemGroupId",
                table: "ItemTypes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTags_ItemTypeId",
                table: "InventoryTags",
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
                name: "FK_ItemTypes_ItemGroups_ItemGroupId",
                table: "ItemTypes");

            migrationBuilder.DropIndex(
                name: "IX_InventoryTags_ItemTypeId",
                table: "InventoryTags");

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

            migrationBuilder.AlterColumn<int>(
                name: "ItemGroupId",
                table: "ItemTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
                name: "FK_ItemTypes_ItemGroups_ItemGroupId",
                table: "ItemTypes",
                column: "ItemGroupId",
                principalTable: "ItemGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
