using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtualWelshWalk.Migrations
{
    public partial class MilestoneTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VirtualMilestonesTBL",
                columns: table => new
                {
                    VirtualMilestoneId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VirtualWalkName = table.Column<string>(maxLength: 100, nullable: false),
                    Milestone1 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone2 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone3 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone4 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone5 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone6 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone7 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone8 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone9 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone10 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone11 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone12 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone13 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone14 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone15 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone16 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone17 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone18 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone19 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone20 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone21 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone22 = table.Column<ulong>(type: "bit", nullable: false),
                    Milestone23 = table.Column<ulong>(type: "bit", nullable: false),
                    PeopleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirtualMilestonesTBL", x => x.VirtualMilestoneId);
                    table.ForeignKey(
                        name: "FK_VirtualMilestonesTBL_PeoplesTBL_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "PeoplesTBL",
                        principalColumn: "PeopleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VirtualMilestonesTBL_PeopleId",
                table: "VirtualMilestonesTBL",
                column: "PeopleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VirtualMilestonesTBL");
        }
    }
}
