using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAcces.Migrations
{
    public partial class Group : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spot_Group_GroupId",
                table: "Spot");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Group_GroupId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Group_GroupId1",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_GroupId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_GroupId1",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Spot_GroupId",
                table: "Spot");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "GroupId1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Spot");

            migrationBuilder.AddColumn<long>(
                name: "Created",
                table: "Group",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Group",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Group");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId1",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Spot",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_GroupId",
                table: "User",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_User_GroupId1",
                table: "User",
                column: "GroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_Spot_GroupId",
                table: "Spot",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Spot_Group_GroupId",
                table: "Spot",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Group_GroupId",
                table: "User",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Group_GroupId1",
                table: "User",
                column: "GroupId1",
                principalTable: "Group",
                principalColumn: "Id");
        }
    }
}
