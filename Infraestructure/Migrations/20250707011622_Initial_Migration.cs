using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Duration = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<float>(type: "REAL", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExternalReference = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    CourtId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Time = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Time = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourtId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Courts_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Courts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "Id", "Category", "Description", "Duration", "IsAvailable", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Techada", "Cancha techada con cesped cintetico y caucho", "60 min", false, "5A", 40000f },
                    { 2, "Techada", "Cancha techada con cesped cintetico y caucho", "60 min", false, "5B", 45000f },
                    { 3, "Techada", "Cancha techada con cesped cintetico y caucho", "60 min", false, "6A", 60000f },
                    { 4, "Techada", "Cancha techada con cesped cintetico y caucho", "60 min", false, "6C", 60000f },
                    { 5, "Techada", "Cancha techada con cesped cintetico y caucho", "60 min", false, "7T", 70000f },
                    { 6, "Aire Libre", "Cancha al aire libre con cesped cintetico y caucho", "60 min", false, "7AL", 70000f },
                    { 7, "Aire Libre", "Cancha al aire libre con cesped cintetico y caucho", "60 min", false, "8AL", 83000f }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, "elpredio@gmail.com", "El Predio", "$2a$11$tNgtGW7xiqCkEwcZChWMGuVUnKT.0HGRH/8zvdFe8SodfUUA9FWR6", "3412121111", 0 },
                    { 2, "joako.tanlon@gmail.com", "Joaquin Tanlongo", "$2a$11$Pinc2b4Cp/AMVsLQsXZviOl6Gtn3tFwPOa01V8rYNtcTuA30gTLkO", "3412122907", 1 },
                    { 3, "marmax0504@gmail.com", "Maximo Martin", "$2a$11$nmYl1GetcLyCZu1q6Q6yzeniwlWdQgEdTtwl2QqJXSgMl1xqy5tEm", "3412122908", 1 },
                    { 4, "marucomass@gmail.com", "Mario Massonnat", "$2a$11$7QEmyyqJel/NSklxQ615JOLBlatw1/WzoE/Sy1uBSH27Zd72qiYCG", "3412122909", 1 },
                    { 5, "frandepe7@gmail.com", "Francisco Depetrini", "$2a$11$A.arBjyt5PhYHPMcWDlZ9eLACVdlh7RLXO8a2hJL9F1MgkEd5zx3e", "3412122910", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CourtId",
                table: "Reservations",
                column: "CourtId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Courts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
