using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthServer.Persistence.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00b7c93b-8e9a-42ac-a3ef-2797b9919669");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "276ecf0f-bc5d-4d14-aae2-9e9175bf8f94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c97e7a5a-afb4-4d15-b8b7-c919e1b48ce4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4617dbb6-2ef3-4510-87f9-36ed2f56f6a4", "ccbedeee-ba25-4156-878b-b9d147947a9a", "superadmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9ba0b75-5eb4-4485-8517-abef34ec0739", "dee8c6b5-7aa3-4d22-9414-2388c2d6a752", "seller", "SELLER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e203df65-b6a5-4d55-8d50-2c77d8686665", "79be4e55-3453-4616-9e6d-e151d6b8d6a5", "customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4617dbb6-2ef3-4510-87f9-36ed2f56f6a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9ba0b75-5eb4-4485-8517-abef34ec0739");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e203df65-b6a5-4d55-8d50-2c77d8686665");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "00b7c93b-8e9a-42ac-a3ef-2797b9919669", "1fca9581-9f91-4168-8523-b6ac870385f6", "customer", "customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "276ecf0f-bc5d-4d14-aae2-9e9175bf8f94", "74d2d7f5-9302-4519-884c-5098f6b03385", "superadmin", "superadmin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c97e7a5a-afb4-4d15-b8b7-c919e1b48ce4", "4cba18bb-181d-4fec-aa14-8d7bfb506d98", "seller", "seller" });
        }
    }
}
