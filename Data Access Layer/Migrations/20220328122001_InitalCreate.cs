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
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "ContactNumber", "DateOfBirth", "Email", "FullName" },
                values: new object[,]
                {
                    { new Guid("7a14b93c-398d-49b1-9930-e4fa640ab03e"), "1", new DateTime(2022, 3, 28, 12, 20, 0, 679, DateTimeKind.Utc).AddTicks(7068), "email", "John Johnson" },
                    { new Guid("1a744aea-36b8-4504-84d9-fd8420f0fb4e"), "2", new DateTime(2022, 3, 28, 12, 20, 0, 679, DateTimeKind.Utc).AddTicks(7696), "email2", "Jack Jackson" },
                    { new Guid("16fdfc19-52ad-48ec-b175-b4ea66cc2a5e"), "3", new DateTime(2022, 3, 28, 12, 20, 0, 679, DateTimeKind.Utc).AddTicks(7717), "email3", "Johnny Joe" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("01e9345f-461c-4e3d-b467-788436e149b7"), "Skill A" },
                    { new Guid("9b79cd08-7333-44d4-a7bb-0d0fcfe2e30e"), "Skill B" },
                    { new Guid("a306ad86-110b-46ed-8b48-91b37b1339b7"), "Skill C" }
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
