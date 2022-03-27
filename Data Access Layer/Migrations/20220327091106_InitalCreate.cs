using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_Access_Layer.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "ContactNumber", "DateOfBirth", "Email", "FullName", "SkillsId" },
                values: new object[,]
                {
                    { new Guid("7be369da-0d1b-4544-b3cb-402828b5c95c"), "1", new DateTime(2022, 3, 27, 9, 11, 5, 668, DateTimeKind.Utc).AddTicks(6761), "email", "John Johnson", 1 },
                    { new Guid("c793af7f-2a3c-4cd6-bff8-48805f7b8b06"), "2", new DateTime(2022, 3, 27, 9, 11, 5, 668, DateTimeKind.Utc).AddTicks(8000), "email2", "Jack Jackson", 2 },
                    { new Guid("f5aa3442-b05e-4dda-8e02-56a1ff778e76"), "3", new DateTime(2022, 3, 27, 9, 11, 5, 668, DateTimeKind.Utc).AddTicks(8023), "email3", "Johnny Joe", 3 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Skill A" },
                    { 2, "Skill B" },
                    { 3, "Skill C" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
