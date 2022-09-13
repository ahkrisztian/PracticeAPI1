using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeAPI1.Migrations
{
    public partial class AddTestPersonsAndAddresses2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Address_PersonId",
                table: "Address",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Person_PersonId",
                table: "Address",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Person_PersonId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_PersonId",
                table: "Address");

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "AddressLine", "City", "Country", "PersonId", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Holman-Weg 24", "Hannover", "Germany", 1, "30111" },
                    { 2, "Kolt Str. 75", "Berlin", "Germany", 2, "12111" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Tom", "Jones" },
                    { 2, "Loyd", "Philips" }
                });
        }
    }
}
