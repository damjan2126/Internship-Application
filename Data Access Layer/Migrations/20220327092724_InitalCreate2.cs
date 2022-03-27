using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_Access_Layer.Migrations
{
    public partial class InitalCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("7be369da-0d1b-4544-b3cb-402828b5c95c"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("c793af7f-2a3c-4cd6-bff8-48805f7b8b06"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("f5aa3442-b05e-4dda-8e02-56a1ff778e76"));

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "ContactNumber", "DateOfBirth", "Email", "FullName", "SkillsId" },
                values: new object[] { new Guid("3285c03a-4a49-4029-bc86-660a582354f6"), "1", new DateTime(2022, 3, 27, 9, 27, 23, 912, DateTimeKind.Utc).AddTicks(4118), "email", "John Johnson", 1 });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "ContactNumber", "DateOfBirth", "Email", "FullName", "SkillsId" },
                values: new object[] { new Guid("cb5e4a31-12ed-4767-85a0-6ea1b9686109"), "2", new DateTime(2022, 3, 27, 9, 27, 23, 912, DateTimeKind.Utc).AddTicks(6150), "email2", "Jack Jackson", 2 });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "ContactNumber", "DateOfBirth", "Email", "FullName", "SkillsId" },
                values: new object[] { new Guid("7f537be3-5467-4312-ac4e-522251edf85d"), "3", new DateTime(2022, 3, 27, 9, 27, 23, 912, DateTimeKind.Utc).AddTicks(6180), "email3", "Johnny Joe", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("3285c03a-4a49-4029-bc86-660a582354f6"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("7f537be3-5467-4312-ac4e-522251edf85d"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("cb5e4a31-12ed-4767-85a0-6ea1b9686109"));

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "ContactNumber", "DateOfBirth", "Email", "FullName", "SkillsId" },
                values: new object[] { new Guid("7be369da-0d1b-4544-b3cb-402828b5c95c"), "1", new DateTime(2022, 3, 27, 9, 11, 5, 668, DateTimeKind.Utc).AddTicks(6761), "email", "John Johnson", 1 });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "ContactNumber", "DateOfBirth", "Email", "FullName", "SkillsId" },
                values: new object[] { new Guid("c793af7f-2a3c-4cd6-bff8-48805f7b8b06"), "2", new DateTime(2022, 3, 27, 9, 11, 5, 668, DateTimeKind.Utc).AddTicks(8000), "email2", "Jack Jackson", 2 });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "ContactNumber", "DateOfBirth", "Email", "FullName", "SkillsId" },
                values: new object[] { new Guid("f5aa3442-b05e-4dda-8e02-56a1ff778e76"), "3", new DateTime(2022, 3, 27, 9, 11, 5, 668, DateTimeKind.Utc).AddTicks(8023), "email3", "Johnny Joe", 3 });
        }
    }
}
