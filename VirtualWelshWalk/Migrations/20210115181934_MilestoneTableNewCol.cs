using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtualWelshWalk.Migrations
{
    public partial class MilestoneTableNewCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VirtualMilestonesTBL_PeoplesTBL_PeopleId",
                table: "VirtualMilestonesTBL");

            migrationBuilder.AlterColumn<int>(
                name: "PeopleId",
                table: "VirtualMilestonesTBL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VirtualMilestonesTBL_PeoplesTBL_PeopleId",
                table: "VirtualMilestonesTBL",
                column: "PeopleId",
                principalTable: "PeoplesTBL",
                principalColumn: "PeopleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VirtualMilestonesTBL_PeoplesTBL_PeopleId",
                table: "VirtualMilestonesTBL");

            migrationBuilder.AlterColumn<int>(
                name: "PeopleId",
                table: "VirtualMilestonesTBL",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_VirtualMilestonesTBL_PeoplesTBL_PeopleId",
                table: "VirtualMilestonesTBL",
                column: "PeopleId",
                principalTable: "PeoplesTBL",
                principalColumn: "PeopleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
