using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Courts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Duration", "Name", "Price" },
                values: new object[] { "Techada", "60 min", "Cancha 5A (F5)", 40000f });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Duration", "Name", "Price" },
                values: new object[] { "Techada", "60 min", "Cancha 5B (F5)", 45000f });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Duration", "Name", "Price" },
                values: new object[] { "Techada", "60 min", "Cancha 6A (F6)", 60000f });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "Duration", "Name", "Price" },
                values: new object[] { "Techada", "60 min", "Cancha 6C (F6)", 60000f });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Category", "Duration", "Name", "Price" },
                values: new object[] { "Techada", "60 min", "Cancha 7T (F7)", 70000f });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "Duration", "Name", "Price" },
                values: new object[] { "Aire Libre", "60 min", "Cancha 7AL (F7)", 70000f });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "Duration", "Name", "Price" },
                values: new object[] { "Aire Libre", "60 min", "Cancha 8AL (F8)", 83000f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Courts");

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Duration", "Name", "Price" },
                values: new object[] { "1h", "5A", 40f });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Duration", "Name", "Price" },
                values: new object[] { "1h", "5B", 45f });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Duration", "Name", "Price" },
                values: new object[] { "1h", "6A", 60f });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Duration", "Name", "Price" },
                values: new object[] { "1h", "6C", 60f });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Duration", "Name", "Price" },
                values: new object[] { "1h", "7T", 70f });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Duration", "Name", "Price" },
                values: new object[] { "1h", "7AL", 70f });

            migrationBuilder.UpdateData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Duration", "Name", "Price" },
                values: new object[] { "1h", "8AL", 83f });
        }
    }
}
