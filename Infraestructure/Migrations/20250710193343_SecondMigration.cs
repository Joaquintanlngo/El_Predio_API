using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PreferenceId",
                table: "Reservations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$1Dm5IVEO0MfqrjW4XRqbne2yFJ8Gbx6qEW.ldvdlHDEyyTmTRRLRS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$txDwjcao//qN3bZ.rWonfO36lQxTlTHWa6l3Uvsn/tORGMx8QtLRi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$NYA9lCD9JSOIQ9udtHej/.Dlsh/0t.i7BhnCyTNkj92qldjSDKxKy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$W8sWh0lw8x/cuY0/SrjZtOBWpIy44gFPkjUT6tzLNEM24qWrZ0AW.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$GwAsS4X5x.0sye1k7XKPSuTFT3kuopIUQ1ZENWCpW6jJCXIIwwo5C");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreferenceId",
                table: "Reservations");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$tNgtGW7xiqCkEwcZChWMGuVUnKT.0HGRH/8zvdFe8SodfUUA9FWR6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$Pinc2b4Cp/AMVsLQsXZviOl6Gtn3tFwPOa01V8rYNtcTuA30gTLkO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$nmYl1GetcLyCZu1q6Q6yzeniwlWdQgEdTtwl2QqJXSgMl1xqy5tEm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$7QEmyyqJel/NSklxQ615JOLBlatw1/WzoE/Sy1uBSH27Zd72qiYCG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$A.arBjyt5PhYHPMcWDlZ9eLACVdlh7RLXO8a2hJL9F1MgkEd5zx3e");
        }
    }
}
