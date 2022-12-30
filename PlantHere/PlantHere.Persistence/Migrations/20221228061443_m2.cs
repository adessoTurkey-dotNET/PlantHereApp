using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantHere.Persistence.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5317), "3d201476-accf-44e1-9145-1d491a1e102f_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5149) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5329), "844f60f9-9eb9-45c6-a2b8-e800e136075d_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5319) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5338), "ca724e0e-1cce-416b-8f2b-b7e50c94f54a_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5331) });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 8,
                column: "Url",
                value: "https://preview.redd.it/6cvm0l28r3m61.jpg?width=640&crop=smart&auto=webp&s=34a25ebcd18e3782728c92fd112f165a9886dff9");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 23,
                column: "Url",
                value: "https://www.picturethisai.com/wiki-image/1080/153815058223202319.jpeg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 60,
                column: "Url",
                value: "https://www.panoramaweb.com.mx/u/fotografias/m/2022/10/12/f608x342-38506_68229_0.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 65,
                column: "Url",
                value: "https://cdn.shopify.com/s/files/1/0789/1541/products/FC40A1DF_1024x1024.jpg?v=1658344259");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 82,
                column: "Url",
                value: "https://i.pinimg.com/originals/06/64/62/066462828cc474586f4bbc7762075066.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5819), "83eb5df8-b29f-4d7a-9822-66cf8b642cbc_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5819) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5829), "dee49caf-707d-4029-a803-98a0d8933ce4_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5829) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5869), "26d0d683-5b2f-49ce-9dac-1a655a771442_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5869) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5878), "0f165800-6e0f-49d6-936b-84a0eb5d66d8_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5879) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5887), "bd5432ad-5422-447d-bbdf-995641d70ea6_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5887) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5900), "6673ef5f-67cb-4287-85eb-40818721fccb_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5900) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5908), "9486c34a-0b5d-4f4a-8593-721d01ac4246_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5909) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5917), "e064c2c9-8e5f-42ed-bee2-f9997cf3b9db_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5918) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5926), "f463deb3-f42c-450f-bf77-d5d1cf529886_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5926) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5934), "7170e2a8-f8af-4d68-b9dd-d05f10230d05_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5935) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5943), "6e8df388-e3ef-4eed-8635-b2ccf2995761_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5944) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5954), "61791bb0-8e74-4ba6-8f7b-7fd56f77053d_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5954) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5962), "62bae449-0941-48af-a0d2-94bf5a444666_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5963) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5973), "47fc98b8-c476-47ff-8175-5a4de7e7d868_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5973) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5981), "8527a2c8-bddc-45d7-a952-b1fd37ec4c8b_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5981) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5990), "0ce47e1e-e96e-46b1-a522-2cd364c06c2f_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5990) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5998), "f4e49369-3f97-4d81-8425-b57c6d3321e2_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(5998) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(6006), "12c49a4c-b9fe-446f-bee9-74319d8e74da_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(6007) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(6015), "ba7df6a3-bade-47d9-bea3-b9d2921f7289_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(6015) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(6023), "f6e5c879-2b61-4913-ad0c-751c3f3aeb5e_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(6024) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(6032), "02e8c548-d212-4bfc-ad7c-5e86d39d6a66_2022122809144348", new DateTime(2022, 12, 28, 9, 14, 43, 485, DateTimeKind.Local).AddTicks(6032) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(928), "3854cb96-0f38-4d11-8a65-ada9ce603c98_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(779) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(939), "e7f0a923-6aab-484c-81ad-cca911f5a56d_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(930) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(948), "5280a7c4-fd25-4729-97dd-7fa808b08bba_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(941) });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 8,
                column: "Url",
                value: "https://succulentcapital.com/wp-content/uploads/echeveria-lola-reproduccion-hijuelos.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 23,
                column: "Url",
                value: "https://images.squarespace-cdn.com/content/v1/5968af67414fb590cb8f77e3/1500201735590-B98Z7LVFP1QFUNYIBOE3/3628340497_972f5aba77_b.jpg?format=2500w");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 60,
                column: "Url",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRZXLNrM0M5L5F3jFTTwbLVQVDcxPTETSBHsYic0N4zEpDtmtL1zNW1zA24VBV_r3Zb-Sg&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 65,
                column: "Url",
                value: "https://cdn03.ciceksepeti.com/cicek/kc7927245-1/XL/tesbih-cicegi-inci-tanesi-sukulent-askili-saksida-kc7927245-1-08428c61393f4121b76a5facd9cb2329.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 82,
                column: "Url",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSUvPOepGIqvouZsCE5j5204_FThLWm8caKdA&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1446), "ff2b4103-53c2-43df-bd96-c7d7f7d6f849_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1447) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1456), "744cdbe0-9069-4c29-a6fd-cf75bfa286dc_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1457) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1492), "6bbdae46-8723-4b70-aa59-b34eadc4c1df_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1493) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1503), "ee2d4bbf-c3f6-4671-8367-a668cb4b52df_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1503) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1512), "e8fd7e63-14f5-4820-9c59-a1b4ab426840_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1512) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1524), "dfe9cf81-6ef5-4e0c-943b-f21298d1b1ab_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1525) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1533), "abcacae3-30de-4182-b590-869c19c8f91a_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1534) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1542), "ea13fa93-b5cc-497c-b8dc-a57806f88c4e_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1542) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1550), "fae42ee7-a6eb-4177-9108-bda0b289e29b_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1551) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1559), "6a94da2b-6157-4110-9412-34e9dc1cd3a4_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1560) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1569), "3389d29e-8aec-4e43-b954-27725cc0bbd4_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1570) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1578), "c46d363b-0456-434a-be03-09e45e9209a5_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1579) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1588), "a69f5b40-2c03-455f-9e59-3304380dc9ef_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1588) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1598), "51425a4e-bf54-4bc6-97b8-4a20a8902b3f_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1598) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1606), "e4ca9e75-e1d3-445c-a87c-f2631172666d_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1607) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1614), "8b6e87a0-34d0-4cc9-be48-69412ee4ced8_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1615) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1651), "f13f1117-a115-40bd-8b9d-7d0047fdfc5b_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1651) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1661), "7749ae16-ee9d-4ef5-9781-7a706ddc163e_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1662) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1670), "77b8a5c6-c067-44bf-a52d-3c2003c1b2a8_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1670) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1678), "80592445-cb97-4ff1-9a01-23c0da2f22a5_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1679) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1687), "ab36af0c-977f-46e4-ac1f-96119f4ceb1f_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1687) });
        }
    }
}
