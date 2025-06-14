using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$LVTGlp6xsqEXP3l86UwVA./bYUe9UgEB0PqSUrokvOf0O/cugko2K");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$nMmouPQppFuW7MNaKX4sf.gvLZ.0lc.F3UnRJklNFAKvycNg7MbW2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$Ua3dXdzp9MnCZpVwxfLe.ewHWaH1Op7D0mPIT72kj/4aEP9IB88c2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$XuaurGxsIKy9KHDRKf2tH.t02A669dr7NwN9p6PcXAQWHjeE96lwK");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "PhoneNumber", "Role" },
                values: new object[] { 1, "elpredio@gmail.com", "El Predio", "$2a$11$fUh8VQp6563Nk.0Md.hBc.QwK0CXN.Z83lCo1yZ5t1Bv473XvrBbO", "3412121111", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$LHOECe1DARxV3lRj3wBEaet3cSTZpHMaBnvwkptpgx5jIDFBJm0v6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$7jCp1YZJVc8PHZ8gByHqb.8NDvRFRFqfvydAPuHvls4a.IuO13O2q");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$GpBtsma3k2arR40TGv711.6vM4Wn1eQMQFplJbRisNyc2sTL2YllO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$HLs5dJ/tX.v.kDFkylWHI.cnWen0Tw4XPZC.eqY4RRmyTDkAL3Dtq");
        }
    }
}
