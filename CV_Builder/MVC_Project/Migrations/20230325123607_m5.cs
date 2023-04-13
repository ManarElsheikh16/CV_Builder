using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Final.Migrations
{
    /// <inheritdoc />
    public partial class m5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CvTemplates",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CvTemplates",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "CvTemplates",
                columns: new[] { "Id", "Img", "Likes", "UserDataId", "isDeleted" },
                values: new object[,]
                {
                    { 7, "CV5.jpeg", 74, null, false },
                    { 8, "CV6.jpeg", 35, null, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CvTemplates",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CvTemplates",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.InsertData(
                table: "CvTemplates",
                columns: new[] { "Id", "Img", "Likes", "UserDataId", "isDeleted" },
                values: new object[,]
                {
                    { 5, "CV5.jpeg", 74, null, false },
                    { 6, "CV6.jpeg", 35, null, false }
                });
        }
    }
}
