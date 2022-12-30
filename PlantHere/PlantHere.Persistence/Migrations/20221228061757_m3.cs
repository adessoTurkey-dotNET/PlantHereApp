using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantHere.Persistence.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(4560), "8584768d-ac26-4a26-b8e4-b2bbc5348c59_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(4402) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(4572), "4af4e81e-8c43-4d52-b61a-ab57e971c2d0_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(4562) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(4580), "00b9d1a1-8e22-4be2-9487-6ccba4f1595f_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(4574) });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 8,
                column: "Url",
                value: "https://www.sukulentler.com/wp-content/uploads/2021/01/99c83396ec520b7bdf153b9da8c48d01.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5054), "0785a895-3f06-46e8-a899-8e203ab6fff2_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5054) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5071), "a34e63cf-38e1-4a01-b908-0d56a9d0c4ee_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5071) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5104), "72f62d58-ba8e-4413-bb29-867d4d6c4784_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5104) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5114), "da83ca80-a4a0-4d33-a0a5-996f314b6ef2_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5114) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5123), "965bb939-0ee8-472f-8ff3-5c33bc2ad662_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5123) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5135), "472e44e8-d99d-4565-9ec2-b4b94cdf1343_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5135) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5143), "4af40ce1-b805-4ea5-97e3-9773b49ee7ae_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5144) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5152), "0a6fbc8f-7933-4f88-bcc1-08b1a5c26338_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5153) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5161), "bb04d2ee-b72a-40af-b0a7-6ed2191c9b41_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5161) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5169), "2382e536-ab7d-40d8-8a24-71cc9d786ee1_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5170) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5179), "0dd1a33c-324c-4c4b-a467-11825049e28c_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5180) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5187), "2b1e27a5-d5a1-4c05-a004-f28c01007a25_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5188) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5196), "097479a3-4cec-4c72-a1f3-7f0394622152_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5196) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5206), "0f867559-57a5-4712-b96b-5885a6f810c6_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5206) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5214), "568afb89-5932-40ea-8b72-1884f1f26729_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5215) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5248), "e24f82e1-5ef8-4a0f-8959-bc0f83ef6f90_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5249) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5257), "b74d24a3-5d56-4f4c-8435-13532aadc32a_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5257) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5265), "bc9195e0-a4eb-4c37-bb08-137e86760ebf_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5266) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5274), "a2cb2b02-a214-420a-b90f-b8d2cb3e0c6d_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5274) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5282), "11cce02b-ecdd-4579-bc32-23a8688ad39e_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5283) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5291), "5d8c5010-78ec-4f45-8566-c329ae447ca1_2022122809175673", new DateTime(2022, 12, 28, 9, 17, 56, 732, DateTimeKind.Local).AddTicks(5291) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
