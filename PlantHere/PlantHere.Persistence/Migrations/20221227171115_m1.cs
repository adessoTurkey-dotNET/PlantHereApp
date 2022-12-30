using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantHere.Persistence.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: 2,
                column: "Url",
                value: "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8f/%28MHNT%29_Pachyphytum_oviferum_-_Habitus.jpg/800px-%28MHNT%29_Pachyphytum_oviferum_-_Habitus.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 8,
                column: "Url",
                value: "https://succulentcapital.com/wp-content/uploads/echeveria-lola-reproduccion-hijuelos.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 10,
                column: "Url",
                value: "https://cdn.shopify.com/s/files/1/2986/8756/products/cremnosedumlittlegem_12_600x.jpg?v=1610330960");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 18,
                column: "Url",
                value: "http://cdn.shopify.com/s/files/1/0284/2450/products/IMG_9955_1024x.jpg?v=1594117399");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 19,
                column: "Url",
                value: "https://thesucculenteclectic.com/wp-content/uploads/2017/11/Haworthia-attentuata-1024x678.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 20,
                column: "Url",
                value: "https://cdn.shopify.com/s/files/1/0279/8865/6226/products/Planta_Plantique_Haworthia_fasciata1_1024x1024@2x.jpg?v=1601607464");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 21,
                column: "Url",
                value: "https://images.squarespace-cdn.com/content/v1/5968af67414fb590cb8f77e3/1500201738053-SUOSYJDNQ1E5LQ0H9OBR/6991174011_41e1068fe8_b.jpg?format=1500w");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 22,
                column: "Url",
                value: "https://worldofsucculents.com/wp-content/uploads/2017/11/Parodia-leninghausii-Yellow-Tower3-788x591.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 26,
                column: "Url",
                value: "https://p0.pikist.com/photos/451/999/orchid-tropical-flowers-greenhouses-orchidophilia-colour-yellow-and-brown-tiger-beautiful-fascinating-mysterious.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 29,
                column: "Url",
                value: "https://cicekambari.com/wp-content/uploads/2020/12/beyaz-orkide-cicegi-e1607005633825.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 30,
                column: "Url",
                value: "https://adanavipcicek.com/img/urunler/1106/orginal/dekoratif-camda-yapay-beyaz-orkide-adana-vip-cicekcilik1.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 31,
                column: "Url",
                value: "https://cicekambari.com/wp-content/uploads/2020/12/beyaz-orkide-1024x640.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 32,
                column: "Url",
                value: "https://cicekambari.com/wp-content/uploads/2020/12/beyaz-orkide-hakkinda-e1607005655293.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 33,
                column: "Url",
                value: "https://cdn.shopify.com/s/files/1/0073/7191/5333/products/gabriella-plants-4-spider-plant-variegated-regular-variegated-30252499173563.jpg?v=1633545657");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 34,
                column: "Url",
                value: "https://3.bp.blogspot.com/-eJ3JQzLLMGw/W1tUY-anBdI/AAAAAAACtoU/KFsUaeNtdD0Kd3jfu-tpinL48Mgtd9PrgCKgBGAs/s1600/IMG_6939.JPG");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 35,
                column: "Url",
                value: "https://evterapisi.com/wp-content/uploads/2021/02/kurdele-cicegi-5.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 36,
                column: "Url",
                value: "https://i.nefisyemektarifleri.com/2020/08/19/kurdele-cicegi-bakimi-cogaltilmasi-faydalari-3.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 38,
                column: "Url",
                value: "https://i.pinimg.com/originals/58/c3/db/58c3db9c37a7048988a1897e1c63b9a4.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 51,
                column: "Url",
                value: "https://cdn.shopify.com/s/files/1/0140/1526/6902/products/Monanthes_polyphylla1_900x.png?v=1561203971");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 52,
                column: "Url",
                value: "https://cdn.shopify.com/s/files/1/0271/9432/7138/products/images_30_839f9e90-50ce-43ec-bb88-b3c5ae5a2acc_554x.jpg?v=1618303310");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 59,
                column: "Url",
                value: "https://debraleebaldwin.com/wp-content/uploads/IMG_9400.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 63,
                column: "Url",
                value: "https://cdn.dsmcdn.com/ty570/product/media/images/20221019/21/197528384/333594503/1/1_org_zoom.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 65,
                column: "Url",
                value: "https://cdn03.ciceksepeti.com/cicek/kc7927245-1/XL/tesbih-cicegi-inci-tanesi-sukulent-askili-saksida-kc7927245-1-08428c61393f4121b76a5facd9cb2329.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 68,
                column: "Url",
                value: "https://m.media-amazon.com/images/I/71T1PQmmVWL._AC_SL1000_.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 69,
                column: "Url",
                value: "https://live.staticflickr.com/65535/52025117074_dc22e3621a_b.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 71,
                column: "Url",
                value: "https://cdn.shopify.com/s/files/1/0284/2450/products/Orbea-variegata-Stapelia-variegata_800x.jpg?v=1571438671");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 72,
                column: "Url",
                value: "https://s.ecrater.com/stores/59305/5cec3a1f7a63f_59305b.jpg");

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
                columns: new[] { "Care", "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { "Caring For Monanthes: Monanthes Polyphylla grows naturally on shaded cliffs and damp rocks.They do not require much water to thrive. 2) Monanthes requires well draining soil, they do not thrive in waterlogged soil. 3) They require a period of winter to rest, where watering is reduced to a bare minimum.", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1588), "a69f5b40-2c03-455f-9e59-3304380dc9ef_2022122720111482", new DateTime(2022, 12, 27, 20, 11, 14, 826, DateTimeKind.Local).AddTicks(1588) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(8930), "2388adec-5116-4148-9534-6ae96f7bae2b_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(8819) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(8941), "1f9947ac-e684-4e35-9239-ffeda938f61e_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(8932) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(8949), "8b575376-93b1-487f-9dcf-6aafc6d26ad0_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(8942) });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 2,
                column: "Url",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSlkmDcqH11T3zsXYl31j-vpoYPvMJl6Csjvsc2UptNKSYSbVcyAoFDW5E-QxCnJx6Xk-M&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 8,
                column: "Url",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR4GY9P-9uQzgV0auCyW5KuRDWRYixvRxG-Zw&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 10,
                column: "Url",
                value: "https://cdn.shortpixel.ai/spai/q_glossy+w_656+h_525+to_webp+ret_img/https://surrealsucculents.co.uk/wp-content/uploads/2016/09/little-gem-6.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 18,
                column: "Url",
                value: "https://cdn.shopify.com/s/files/1/2203/9263/products/8683ceb17b3ba98d9eb5ed6ecd425242.jpg?v=1571616111");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 19,
                column: "Url",
                value: "https://www.livingconceptsbci.com/wp-content/uploads/2019/07/Haworthia-300x200.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 20,
                column: "Url",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR83zMaHrKiWm_dOUbfu2OjjsKEgS9DX6F-YraoBJQR2i1i-gyptIuoxA5oGsOyzhtjOt8&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 21,
                column: "Url",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1rIojg5vQ8hIVegk8RvZX76SM8VWn0gkPhg&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 22,
                column: "Url",
                value: "https://images.squarespace-cdn.com/content/v1/5968af67414fb590cb8f77e3/1500201738053-SUOSYJDNQ1E5LQ0H9OBR/6991174011_41e1068fe8_b.jpg?format=1500w");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 26,
                column: "Url",
                value: "https://static.wikia.nocookie.net/orchids/images/3/32/Paph._henryanum.jpg/revision/latest?cb=20090908044655&path-prefix=en");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 29,
                column: "Url",
                value: "http://cdn.shopify.com/s/files/1/0555/1033/5639/products/5017-a-pap.jpg?v=1667465888");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 30,
                column: "Url",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxYsEQ0jTyTDQ317A1eSqb6xAQ0U4-sQWZCC-KuRTPDyWUMaiIUTNi2rzP7bC9yw9Xqoo&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 31,
                column: "Url",
                value: "https://davesgarden.com/guides/pf/thumbnail.php?image=2008/02/22/DaylilySLP/f2f56d.jpg&widht=700&height=312");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 32,
                column: "Url",
                value: "https://preview.redd.it/i2np8la1v8w61.jpg?auto=webp&s=a49ff81985def5475f2f9e6708110c32ceb41908");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 33,
                column: "Url",
                value: "https://iis-akakce.akamaized.net/p.z?%2F%2Fcdn03%2Eciceksepeti%2Ecom%2Fcicek%2Fkcm32089798%2D1%2FM%2Fkurdele%2Dcicegi%2Dchlorophytum%2Dcomosum%2Daskili%2Dsaksida%2Dkcm32089798%2D1%2D1fcedb135aef4c35bc111079b35a7468%2Ejpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 34,
                column: "Url",
                value: "https://media.istockphoto.com/id/962808426/tr/foto%C4%9Fraf/chlorophytum-comosum-veya-%C3%B6r%C3%BCmcek-bitki-veya-u%C3%A7ak-bitki-veya-st-bernard%C4%B1n-lily-veya-%C3%B6r%C3%BCmcek.jpg?s=170667a&w=0&k=20&c=b32U1U_8zWYXL-McEOte52I1yo-LbGwYtFEeemiP1TQ=");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 35,
                column: "Url",
                value: "https://media.istockphoto.com/id/1173520069/tr/foto%C4%9Fraf/chlorophytum-comosum-beyaz-as%C4%B1l%C4%B1-pot-sepet-%C3%B6r%C3%BCmcek-bitki-ev-i%C3%A7in-hava-ar%C4%B1tma-tesisleri.jpg?s=612x612&w=0&k=20&c=qrW2_xdOWMsRoaSfchrct8ZqczmhzEHMkyPwk1m858Y=");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 36,
                column: "Url",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQZwKI59Jal63uzhuHyjCYtQ9MY-JDe6c6PAGQPYMCnj3KziaPnvHx6UgwqWEcT4-qwOMY&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 38,
                column: "Url",
                value: "https://i.etsystatic.com/9745001/r/il/93e241/4159450301/il_340x270.4159450301_smd9.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 51,
                column: "Url",
                value: "https://s3.amazonaws.com/media.jungledragon.com/images/651/29126_small.JPG?AWSAccessKeyId=05GMT0V3GWVNE7GGM1R2&Expires=1672876810&Signature=llyu1VMEGaLHXzsR8SmPoDuaOcs%3D");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 52,
                column: "Url",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT-UzsPcEc77Y2MazYNQJsueqDzTF-muYtPpc7tPktgxhqIwV7xUJ3z7GiFj1_ov1O_TSA&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 59,
                column: "Url",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRxlPKspiYavHOjaGmStqnlr_54TwtIumFsnQ&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 63,
                column: "Url",
                value: "https://www.modandmint.com/wp-content/uploads/2022/07/pickle-plant-care-fi.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 65,
                column: "Url",
                value: "https://m.media-amazon.com/images/I/71T1PQmmVWL._AC_SL1000_.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 68,
                column: "Url",
                value: "https://johnstowngardencentre.ie/pub/media/catalog/product/cache/9959ec196504ffddcda9bc0e1d4145ae/s/e/senecio_rowleyanus1.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 69,
                column: "Url",
                value: "https://cdn03.ciceksepeti.com/cicek/kcm94554399-1/L/ozen-cicekcilik-stapelia-orbea-variegata-succulent-cicek-acan-sukulent-bitkisi-kcm94554399-1-261e40de941342819dddf43fd473331c.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 71,
                column: "Url",
                value: "https://img.freepik.com/premium-photo/stapelia-variegata-flower-blooming_361360-2847.jpg?w=1380");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 72,
                column: "Url",
                value: "https://www.insukuland.com/storage/plants/cover/large/orbea-variegata-991162.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9480), "4758fd6b-eafb-4e5e-a8d5-687955fa2665_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9480) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9494), "c41abe1f-866d-440b-ab71-b138c7fac414_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9499) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9548), "bf634056-8ac9-485d-bc81-d46b092bf515_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9548) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9556), "3fe25462-5c2c-41e9-84ee-fd7f6a6debb0_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9557) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9576), "5a15d6bb-c6bb-4acc-8ac8-6a96197fda37_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9577) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9585), "34a00b35-d54b-48ea-af52-e9b30286acee_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9585) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9619), "e395d3b8-4fb7-4654-b836-48636755beb1_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9620) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9629), "9c994800-a5f1-4d95-92ba-f69c2b500306_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9629) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9638), "47a0a0ee-1ef8-4735-8d6b-a51283789de2_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9638) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9647), "dfb5c841-87d7-4369-b054-c7495b7bc367_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9648) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9656), "ff3d0b67-04bd-4a09-97b1-432b0d013407_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9658) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9667), "7b4ba251-56ea-4510-8c96-418a939ad124_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9667) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Care", "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { "Caring For Monanthes: 1) Monanthes Polyphylla grows naturally on shaded cliffs and damp rocks.They do not require much water to thrive. 2) Monanthes requires well draining soil, they do not thrive in waterlogged soil. 3) They require a period of winter to rest, where watering is reduced to a bare minimum.", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9678), "db1c650c-af2b-4d75-81eb-ac00fd9c7433_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9679) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9687), "5875b8ff-9cef-493b-a2f9-a1117214ac08_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9687) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9695), "58235d8c-9cf6-4f3b-954b-93805e429ccb_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9696) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9703), "ec697cd2-b7ec-4e09-bf5c-f5a76589031e_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9704) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9712), "2728dee5-86bf-4f69-82c5-4e4fa4dfc374_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9712) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9720), "22415395-a8a2-485a-b2bb-b5236ee26e4e_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9721) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9729), "bf5c20b6-e09b-487f-9d5b-1abb85f0d5bd_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9729) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9737), "c39854f6-1ffc-49b1-b998-8423ce196bff_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9738) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "UniqueId", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9747), "2d0ba28f-f055-43b0-8d1e-aee91e91fc07_2022122714035146", new DateTime(2022, 12, 27, 14, 3, 51, 460, DateTimeKind.Local).AddTicks(9748) });
        }
    }
}
