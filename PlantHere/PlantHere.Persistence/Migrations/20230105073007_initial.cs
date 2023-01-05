﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantHere.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "basketing");

            migrationBuilder.EnsureSchema(
                name: "ordering");

            migrationBuilder.CreateTable(
                name: "Baskets",
                schema: "basketing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UniqueId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "ordering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address_Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Line = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyerId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                schema: "basketing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    BasketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalSchema: "basketing",
                        principalTable: "Baskets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Care = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                schema: "ordering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "ordering",
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedDate", "NameEn", "NameTr", "UniqueId", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(6445), "Cactus", "Kaktus", "50b0ccf5-919a-4690-a3f4-a333a02b285f_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(6255) });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedDate", "NameEn", "NameTr", "UniqueId", "UpdatedDate" },
                values: new object[] { 2, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(6463), "Succulent", "Sukulent", "eb7a8de0-6c2d-476a-b26f-27844376cadb_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(6447) });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedDate", "NameEn", "NameTr", "UniqueId", "UpdatedDate" },
                values: new object[] { 3, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(6489), "Orchid", "Orkide", "1eb2b303-6813-44d3-b60e-5ac132de7296_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(6464) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Care", "CategoryId", "CreatedDate", "Description", "Discount", "Name", "Price", "SellerId", "Stock", "UniqueId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Make sure to keep your plant in a sunny place where it gets enough sunlight. Water the in-container Pachyphytum Oviferum only when you feel it soil dry to a depth of 4 inches. Avoid watering it when the soil still feels moist or else your fragile succulent will be damaged.", 2, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8101), "Badem Şekeri", 0, "Pachyphytum Oviferum", 50m, "d8a07002-0c3a-4add-874b-dd2b1e33aaae", 5, "e4e0cb12-5031-4fe5-90cc-41b5b40d3045_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8102) },
                    { 2, "Being drought tolerant plants, Lola's (like almost all echeverias) like a deep watering and then allowing their soil dry out completely in between waterings. I advise you plant your Lola's in well-draining Succulent & Cactus blend soils, because they do not like their roots to remain in damp soil.", 2, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8119), "Beyaz Renk Muhteşem Form", 15, "Echeveria Lola", 75m, "d8a07002-0c3a-4add-874b-dd2b1e33aaae", 2, "86bff94b-69bf-46ab-a2b9-7d8e5b57f04b_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8119) },
                    { 3, "These succulents need bright light and well-draining soil. Place indoor plants near a southern or western window but not so close to the glass that they will sunburn. Outdoors, plant in pots around the patio or in the ground around pavers, border edges, and even in rockeries.", 2, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8132), "Güneşte Rengi Koyulaşır", 0, "Cremnosedum Little Gem", 150m, "d8a07002-0c3a-4add-874b-dd2b1e33aaae", 2, "bb676b06-aea9-4d41-8fc3-f748716c5aab_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8133) },
                    { 4, "Because Callisia is semi-succulent, she doesn't need too much water. Soak the soil thoroughly when watering, then make sure to let the top 5-10cm of soil dry out completely before watering again. If you are potting up, use a potting mix suitable for cacti/succulents. As with all plants, drainage is essential.", 2, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8146), "Pembe Yapraklı Telgraf Çiçeği", 25, "Callisia Repens (Pink Lady)", 100m, "d8a07002-0c3a-4add-874b-dd2b1e33aaae", 3, "1c4736a7-a1e8-45ef-8682-cbba5fcc4e9a_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8146) },
                    { 5, "Because Callisia is semi-succulent, she doesn't need too much water. Soak the soil thoroughly when watering, then make sure to let the top 5-10cm of soil dry out completely before watering again. If you are potting up, use a potting mix suitable for cacti/succulents. As with all plants, drainage is essential.", 2, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8158), "Zebra Bitkisi", 20, "Haworthia Fasciata Hibrid", 45m, "d8a07002-0c3a-4add-874b-dd2b1e33aaae", 2, "78ac2474-62b9-4d60-9050-a660c2f74e8a_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8158) },
                    { 6, "The Yellow Tower Cactus, botanical name Parodia leninghausii, is a succulent plant found in the wild in Argentina. It is also known as the Leninghausii Cactus, the Lemon Cactus, and the Golden Ball Cactus. The Yellow Tower Cactus is a medium-sized columnar cactus that can reach a height of up to three feet tall, with a trunk that is about an inch thick. Each column sports around 30 ribs with soft white-gold spines emerging from the areolas. The spines are soft to the touch, unlike most cacti, making handling easy.", 1, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8175), "Sarı Çiçek Açan Kaktüs", 50, "Parodia Leninghausii", 78m, "d8a07002-0c3a-4add-874b-dd2b1e33aaae", 4, "09a49d94-e42c-43c3-923c-17286afaf0cd_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8175) },
                    { 7, "Paphiopedilum henryanum is a small species that originates from China and Vietnam. It was discovered relatively recently in 1987. Selective breeding has improved the form and color. Today’s flowers are larger, flatter and more intensely colored than the original specimens.This species is found growing on rocks in mixed forests. The summers are warm and rainy while the winters are cooler and drier. Winter temperatures can drop into the upper 40’s F. More details about its natural habitat can be found at the Internet Orchid Species Encyclopedia.\r\n\r\nWe find these easy to grow. They flower from late summer through early winter for us. You can find cultural tips on our care and feeding page.  We grow them along with our complex hybrids.", 3, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8188), "Kaplan Orkide", 10, "Phaphiopedilum Henryanum", 500m, "d8a07002-0c3a-4add-874b-dd2b1e33aaae", 4, "583452c8-4a55-45db-8774-3e55e649185a_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8188) },
                    { 8, "While Paphiopedilum delenatii was for many years considered difficult to grow, years and generations of selection of good-growing parental stock have led to this species being quite easy. The plants seem to respond well to a variety of conditions, but will grow well with other mottled-leaved paphiopedilums, or with the brachypetalum or parvisepalum types. As always, water low in salts is a must. Plants should be kept evenly moist, approaching dryness, and provided with moderate light as for phalaenopsis. As with all paphiopedilums, Paph. delenatii does best with a fertilizing regime of 1/4-strength balanced plant food applied every week", 3, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8203), "Beyaz Orkide", 0, "Paphiopedilum Delenatii", 150m, "d8a07002-0c3a-4add-874b-dd2b1e33aaae", 4, "853c802b-a526-4d75-be60-4ff7480153c9_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8204) },
                    { 9, "Chlorophytum comosum “Bonnie” requires loose, neutral soil with good drainage. The growing medium also needs to provide good aeration for the roots to avoid fungal infections or root rot. A mix of coconut coir, houseplant compost, and sand or perlite is ideal.", 2, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8217), "Kurdele Çiçeği", 0, "Chlorophytum Comosum", 15m, "d8a07002-0c3a-4add-874b-dd2b1e33aaae", 4, "726ac3d0-04ff-4eb1-b36e-e348fda18303_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8217) },
                    { 10, "Houseplant care: Aichryson laxum is a fast growing plant, but tends to lose their lower leaves. In order to promote vegetative growth, the inflorescence should be cut off in time, otherwise this species will naturally grow as a biannual, dieing after flowering. Light: Provide bright light with some direct sunlight.", 2, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8229), "Aşk Ağacı", 0, "Aichryson Laxum", 150m, "d8a07002-0c3a-4add-874b-dd2b1e33aaae", 4, "26063297-b6e9-416b-8bd9-d852254825aa_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8230) },
                    { 11, "The Pilea Peperomioides, also known as the Chinese Money Plant, is a fast-growing succulent-like houseplant that's great for beginning plant owners. The Pilea might seem like a succulent, with its fleshy leaves, but you shouldn't mistake it for one, as it has very different needs.In this plant care guide for the Pilea Peperomioides, we'll explore what this plant needs to thrive in your home. It's quite an easy plant to take care of, but it does have a few things you should be aware of.", 2, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8244), "Çin Para Ağacı", 0, "Pilea Peperomioides", 23m, "d8a07002-0c3a-4add-874b-dd2b1e33aaae", 4, "f2cb0084-7839-4e8b-876c-0d1f1cbf3fdb_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8244) },
                    { 12, "Care Instructions To keep your watermelon peperomia happy and thriving there are a few simple rules to follow: Keep them in a bright room but out of direct sunlight. Do not overwater them, water them just enough to make the soil slightly damp.", 2, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8257), "Karpuz Sukulent", 0, "Peperomia Watermelon", 150m, "d8a07002-0c3a-4add-874b-dd2b1e33aaae", 4, "58527ae2-0bc8-4fc5-85e7-840cedf20668_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8257) },
                    { 13, "Caring For Monanthes: Monanthes Polyphylla grows naturally on shaded cliffs and damp rocks.They do not require much water to thrive. 2) Monanthes requires well draining soil, they do not thrive in waterlogged soil. 3) They require a period of winter to rest, where watering is reduced to a bare minimum.", 2, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8269), "Nadir Tür", 0, "Monanthes Polyphylla ", 150m, "d8a07002-0c3a-4add-874b-dd2b1e33aaae", 4, "aecd69ea-b840-4a49-a8a7-68a0c40d0114_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8270) },
                    { 14, "he Echeveria Minima plant brings charm, beauty, and magic in its compact form, whether indoors or outdoors. Growing small Echeveria species like the Minima succulent plant is a great way to incorporate greenery into tight spaces with ease and elegance.Succulent collectors often find growing Echeveria Minima quite easy, as long as its roots remain relatively safe in potting soils with some gardening sand mixed in. It’s no wonder many growers propagate Echeveria Minima for its enthralling looks and ease of care!", 2, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8289), "Nadir Tür Kırmizi Kenarlı", 0, "Echeveria Minima Red Edge", 150m, "d8a07002-0c3a-4add-874b-dd2b1e33aaae", 4, "c27773ce-1889-4fe4-84ae-b859ac86c21c_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8290) },
                    { 15, "The leaves of Echeveria Cubic Frost are different from other Echeveria species. It possesses thick, fleshy, and upturned leaves.The tubular-shaped leaves grow in the form of the rosette that offsets to form clusters. Apart from its peculiar shape and texture, its distinctiveness is enhanced due to its unique purple color.", 2, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8302), "Kıvrık Yapraklı", 0, "Echeveria Cubic Blue", 150m, "d8a07002-0c3a-4add-874b-dd2b1e33aaae", 4, "5cc15c43-5713-4f59-96ff-6d6d2a60cff0_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8303) },
                    { 16, "Delosperma Echinatum can be quite beautiful when it is well-taken care of. This succulent type needs typical watering as the other succulents. The watering method is very important to keep your Pickle Plant healthy. It should not sit on the water, and an excess amount of water should be avoided.", 2, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8315), "Tombul Tüylü Yapraklı Sukulent", 0, "Delosperma Echinatum", 150m, "d8a07002-0c3a-4add-874b-dd2b1e33aaae", 4, "2117366d-57ab-4337-80b2-f04ba6bf5fa4_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8315) },
                    { 17, "asin of Senecio herreianus generally needs to double every two years in soil. Peat soil, coarse sand mixed matrix are available, and usually it needs to be put in sunlight for careful maintenance. In the winter, control the temperature in 5 ~ 10 ℃, complete the anti-freezing measures are good.", 2, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8327), "String of Beads", 0, "Senecio Herreianus", 150m, "d8a07002-0c3a-4add-874b-dd2b1e33aaae", 4, "6abd534b-821a-4526-b4bf-f501d8627b43_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8328) },
                    { 18, "The succulent plant surprisingly is easy to look after. They can grow a bit during spring and summer. But they are carefree indoor plants from winter to spring. So we recommend placing your starfish flowers outdoors in summer and keeping them in a bright spot indoors in winter.", 1, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8340), "Leş Kaktüsü", 0, "Stapelia Variegata", 150m, "d8a07002-0c3a-4add-874b-dd2b1e33aaae", 4, "d3a98ac9-3ee0-482a-ab17-d4c069347bd2_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8341) },
                    { 19, "Plants in the Sedum genus are super diverse, and are native to regions all over the world. Horticulturalists have bred them to create even more variietes that come in all manner of shapes and colors! Their succulent leaves help store water, and they are incredibly easy to propagate. Just gently pop off one of the leaves and with water and sunlight it will grow into a whole new plant.", 2, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8353), "Obesum", 0, "Sedum Lucidum", 150m, "d8a07002-0c3a-4add-874b-dd2b1e33aaae", 4, "15913fb7-dc19-4885-bbd0-fad38e153eca_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8353) },
                    { 20, "Echeveria Perle von Nürnberg can experience attacks from mealybugs. Inspect plants regularly and remove dead leaves left at the base of the plant. In addition to this, it is also important to never let this plant stand in water or else the chances of root rot and other fungal diseases will increase.", 2, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8406), "Güneşte Mor Tonları Çoğalır", 0, "Echeveria Perle Von Nurnberg", 150m, "d8a07002-0c3a-4add-874b-dd2b1e33aaae", 4, "ea776ff1-50cc-4022-aaab-5b2347d985b2_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8407) },
                    { 21, "It’s best for the Gymnocalycium mihanovichii (Moon Cactus) to grow in temperatures between 68° – 80° Fahrenheit (20 – 27°C), but it can handle temperatures as low as 35° Fahrenheit (2° C). The Moon Cacti are hardy plants but should never be exposed to temperatures below freezing, because this may kill the plant.", 1, new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8420), "Mor ve Bordo Renkli", 0, "Gymnocalycium Mihanovichii Purple Moon", 150m, "d8a07002-0c3a-4add-874b-dd2b1e33aaae", 4, "6598a4de-ff87-435b-8736-5bf69fda8a20_2023010510300773", new DateTime(2023, 1, 5, 10, 30, 7, 738, DateTimeKind.Local).AddTicks(8420) }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "http://cdn.shopify.com/s/files/1/0284/2450/products/Pachyphytum_Oviferum_-Moonstones_1024x.jpg?v=1571438584" },
                    { 2, 1, "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8f/%28MHNT%29_Pachyphytum_oviferum_-_Habitus.jpg/800px-%28MHNT%29_Pachyphytum_oviferum_-_Habitus.jpg" },
                    { 3, 1, "https://www.insukuland.com/storage/plants/cover/large/pachyphytum-oviferum-402781.jpg" },
                    { 4, 1, "https://i.ytimg.com/vi/uWfjMLX0Xrg/hq720.jpg?sqp=-oaymwEhCK4FEIIDSFryq4qpAxMIARUAAAAAGAElAADIQj0AgKJD&rs=AOn4CLAuw0DF0hhsG765LYz2Nlgb0hwNHw" },
                    { 5, 2, "https://cdn11.bigcommerce.com/s-oqm1pc/images/stencil/1280x1280/products/1317/20250/Echeveria_Lola_December__91300.1653687383.jpg?c=2" },
                    { 6, 2, "https://m.media-amazon.com/images/I/513pKjTT6KL._AC_SY580_.jpg" },
                    { 7, 2, "https://i.pinimg.com/originals/8c/a6/71/8ca671dc56325ab3445488a7b8069dcd.jpg" },
                    { 8, 2, "https://www.sukulentler.com/wp-content/uploads/2021/01/99c83396ec520b7bdf153b9da8c48d01.jpg" },
                    { 9, 3, "https://worldofsucculents.com/wp-content/uploads/2018/01/Cremnosedum-Little-Gem4.jpg" },
                    { 10, 3, "https://cdn.shopify.com/s/files/1/2986/8756/products/cremnosedumlittlegem_12_600x.jpg?v=1610330960" },
                    { 11, 3, "https://cdn.shopify.com/s/files/1/2541/4208/products/cremnosedum-little-gem-rare-for-sale-by-succy-crafts-340321_1500x.jpg?v=1671185283" },
                    { 12, 3, "https://cdn.shopify.com/s/files/1/0140/1526/6902/products/Cremnosedum_cv._Little_Gem_900x.png?v=1566762171" },
                    { 13, 4, "http://cdn.shopify.com/s/files/1/0520/0209/5278/articles/D5FEA48C-6F85-4588-AE00-549DBD94C4F6.png?v=1618008678" },
                    { 14, 4, "https://m.media-amazon.com/images/I/512bFkK572L._SX466_.jpg" },
                    { 15, 4, "https://wildroots.in/wp-content/uploads/2021/10/Untitled-design-2021-10-13T164954.953.jpg" },
                    { 16, 4, "https://cdn.shopify.com/s/files/1/1800/3399/products/calissiacloseup_1024x1024.jpg?v=1666450578" },
                    { 17, 5, "https://cdn11.bigcommerce.com/s-oqm1pc/products/3020/images/19308/Haworthia_Super_White__09085.1652214347.555.555.jpg?c=2" },
                    { 18, 5, "http://cdn.shopify.com/s/files/1/0284/2450/products/IMG_9955_1024x.jpg?v=1594117399" },
                    { 19, 5, "https://thesucculenteclectic.com/wp-content/uploads/2017/11/Haworthia-attentuata-1024x678.jpg" },
                    { 20, 5, "https://cdn.shopify.com/s/files/1/0279/8865/6226/products/Planta_Plantique_Haworthia_fasciata1_1024x1024@2x.jpg?v=1601607464" },
                    { 21, 6, "https://images.squarespace-cdn.com/content/v1/5968af67414fb590cb8f77e3/1500201738053-SUOSYJDNQ1E5LQ0H9OBR/6991174011_41e1068fe8_b.jpg?format=1500w" },
                    { 22, 6, "https://worldofsucculents.com/wp-content/uploads/2017/11/Parodia-leninghausii-Yellow-Tower3-788x591.jpg" },
                    { 23, 6, "https://www.picturethisai.com/wiki-image/1080/153815058223202319.jpeg" },
                    { 24, 6, "https://www.deco.fr/sites/default/files/styles/article_970x500/public/2022-04/shutterstock_2099004502.jpg?itok=6eE1BHrd" },
                    { 25, 7, "https://i.ebayimg.com/images/g/uj0AAOSwtG9bInf1/s-l1600.jpg" },
                    { 26, 7, "https://p0.pikist.com/photos/451/999/orchid-tropical-flowers-greenhouses-orchidophilia-colour-yellow-and-brown-tiger-beautiful-fascinating-mysterious.jpg" },
                    { 27, 7, "https://bluenanta.com/static/utils/images/species/spc_000147120_000023395.jpg" },
                    { 28, 7, "https://upload.wikimedia.org/wikipedia/commons/e/ec/Paphiopedilum_henryanum_Orchi_001.jpg" },
                    { 29, 8, "https://cicekambari.com/wp-content/uploads/2020/12/beyaz-orkide-cicegi-e1607005633825.jpg" },
                    { 30, 8, "https://adanavipcicek.com/img/urunler/1106/orginal/dekoratif-camda-yapay-beyaz-orkide-adana-vip-cicekcilik1.jpg" },
                    { 31, 8, "https://cicekambari.com/wp-content/uploads/2020/12/beyaz-orkide-1024x640.jpg" },
                    { 32, 8, "https://cicekambari.com/wp-content/uploads/2020/12/beyaz-orkide-hakkinda-e1607005655293.jpg" },
                    { 33, 9, "https://cdn.shopify.com/s/files/1/0073/7191/5333/products/gabriella-plants-4-spider-plant-variegated-regular-variegated-30252499173563.jpg?v=1633545657" },
                    { 34, 9, "https://3.bp.blogspot.com/-eJ3JQzLLMGw/W1tUY-anBdI/AAAAAAACtoU/KFsUaeNtdD0Kd3jfu-tpinL48Mgtd9PrgCKgBGAs/s1600/IMG_6939.JPG" },
                    { 35, 9, "https://evterapisi.com/wp-content/uploads/2021/02/kurdele-cicegi-5.jpg" },
                    { 36, 9, "https://i.nefisyemektarifleri.com/2020/08/19/kurdele-cicegi-bakimi-cogaltilmasi-faydalari-3.jpg" },
                    { 37, 10, "https://images.squarespace-cdn.com/content/v1/56091b78e4b09e2b03426d22/1584442195074-Z235QWUQ77F10KFUZ4F8/Aeonium+Laxum.jpg?format=2500w" },
                    { 38, 10, "https://i.pinimg.com/originals/58/c3/db/58c3db9c37a7048988a1897e1c63b9a4.jpg" },
                    { 39, 10, "https://i.redd.it/ya94ttfr1lw71.jpg" },
                    { 40, 10, "https://i.pinimg.com/originals/2d/dd/56/2ddd56dc9c5e25442cb449916f682327.jpg" },
                    { 41, 11, "https://www.cocodema.com/wp-content/uploads/2019/01/pilea_edit.jpg" },
                    { 42, 11, "https://images.immediate.co.uk/production/volatile/sites/10/2021/03/2048x1365-Pilea-Peperomioides-SEO-GettyImages-1225860485-79b134d.jpg?resize=768,574" }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { 43, 11, "https://www.botanikamo.com/content/images/gallery/ayakl%C4%B1%20saks%C4%B1da%20dev%20pilea%20.JPG" },
                    { 44, 11, "https://yesilmimar.net/wp-content/uploads/2022/08/Pilea-Peperomioides-Para-Bitkisi-Bakimi-ve-Cogaltilmasi-2-768x1024.jpg" },
                    { 45, 12, "https://cdn.diys.com/wp-content/uploads/2020/10/Watermelon-Peperomia-Peperomia-argyreia.jpg" },
                    { 46, 12, "https://balconygardenweb-lhnfx0beomqvnhspx.netdna-ssl.com/wp-content/uploads/2020/04/How-to-Grow-Watermelon-Peperomia.jpg" },
                    { 47, 12, "https://i.etsystatic.com/21427386/r/il/448bed/2902621052/il_1080xN.2902621052_d3e4.jpg" },
                    { 48, 12, "https://cdn.hortzone.com/wp-content/uploads/2022/01/Watermelon-Peperomia-Peperomia-argyreia-in-hanging-Baskets.jpg" },
                    { 49, 13, "https://worldofsucculents.com/wp-content/uploads/2013/12/Monanthes-polyphylla1.jpg" },
                    { 50, 13, "https://www.sukulentler.com/wp-content/uploads/2021/01/117363/monanthes-polyphylla-sukulent.jpg" },
                    { 51, 13, "https://cdn.shopify.com/s/files/1/0140/1526/6902/products/Monanthes_polyphylla1_900x.png?v=1561203971" },
                    { 52, 13, "https://cdn.shopify.com/s/files/1/0271/9432/7138/products/images_30_839f9e90-50ce-43ec-bb88-b3c5ae5a2acc_554x.jpg?v=1618303310" },
                    { 53, 14, "https://i.pinimg.com/736x/98/b9/e6/98b9e6006e0c9e67b7f6dda54bc3d7d7.jpg" },
                    { 54, 14, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTu49BoGmXycNOuCuZtiXug0kqvP-phwEFOY1a04CXYji5Tym4TtVYUuN0SRqjpqUkvtOo&usqp=CAU" },
                    { 55, 14, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRsp6SpeuYLRUOwZv815BKJheqhMqmTEfoIQw&usqp=CAU" },
                    { 56, 14, "https://cdn.shopify.com/s/files/1/1758/4539/products/il_570xN.1649385779_t0pv_800x.jpg?v=1543327830" },
                    { 57, 15, "https://media.giromagi.com/prodotti/full/202105/IMG_20210511_104811.jpg" },
                    { 58, 15, "https://cdn.shopify.com/s/files/1/2203/9263/products/641f5023dcedba92d7bf90710069e335.jpg?v=1571616461" },
                    { 59, 15, "https://debraleebaldwin.com/wp-content/uploads/IMG_9400.jpg" },
                    { 60, 15, "https://www.panoramaweb.com.mx/u/fotografias/m/2022/10/12/f608x342-38506_68229_0.jpg" },
                    { 61, 16, "https://static1.s123-cdn-static-a.com/uploads/1826974/2000_603ce1ec4b95d.jpg" },
                    { 62, 16, "https://st4.depositphotos.com/19966820/24306/i/450/depositphotos_243065704-stock-photo-barrel-shaped-green-leaves-with.jpg" },
                    { 63, 16, "https://cdn.dsmcdn.com/ty570/product/media/images/20221019/21/197528384/333594503/1/1_org_zoom.jpg" },
                    { 64, 16, "https://feelslike-home.co.uk/wp-content/uploads/2020/12/131508647_714870976128126_8510697134910715586_n-scaled.jpg" },
                    { 65, 17, "https://cdn.shopify.com/s/files/1/0789/1541/products/FC40A1DF_1024x1024.jpg?v=1658344259" },
                    { 66, 17, "https://images.squarespace-cdn.com/content/v1/57543493859fd0803020890f/1624972713842-RYKPNQR13CIS9JEVPKQQ/20210624_132443.jpg?format=1000w" },
                    { 67, 17, "https://www.cocaflora.com/userdata/public/gfx/13964/Senecio-herreianus---Starzec---Sznur-korali.jpg" },
                    { 68, 17, "https://m.media-amazon.com/images/I/71T1PQmmVWL._AC_SL1000_.jpg" },
                    { 69, 18, "https://live.staticflickr.com/65535/52025117074_dc22e3621a_b.jpg" },
                    { 70, 18, "https://www.insukuland.com/storage/plants/cover/large/orbea-variegata-991162.jpg" },
                    { 71, 18, "https://cdn.shopify.com/s/files/1/0284/2450/products/Orbea-variegata-Stapelia-variegata_800x.jpg?v=1571438671" },
                    { 72, 18, "https://s.ecrater.com/stores/59305/5cec3a1f7a63f_59305b.jpg" },
                    { 73, 19, "http://cdn.shopify.com/s/files/1/0268/0681/2787/products/20220607_121700_1200x1200.jpg?v=1661779056" },
                    { 74, 19, "https://cdn.shopify.com/s/files/1/0268/0681/2787/products/20220510_144542_6243ab15-63ea-4599-a7ea-1a2c1b0d245f_grande.jpg?v=1661779056" },
                    { 75, 19, "https://www.kenthurstsucculents.com.au/wp-content/uploads/2018/08/Sedum-Lucidum-2.jpg" },
                    { 76, 19, "https://i.pinimg.com/736x/59/7c/72/597c720e0b54fba809471ab7975e6937--passion-horticulture.jpg" },
                    { 77, 20, "https://cdn11.bigcommerce.com/s-oqm1pc/images/stencil/1280x1280/products/1492/4654/echeveria_perle_von_august__83133.1646858054.jpg?c=2" },
                    { 78, 20, "https://i.etsystatic.com/13687258/r/il/cc2011/3509113567/il_570xN.3509113567_8n9d.jpg" },
                    { 79, 20, "https://www.sublimesucculents.com/wp-content/uploads/2019/04/7-echeveria-perle.jpg" },
                    { 80, 20, "https://succulentsnetwork.com/wp-content/uploads/2020/05/Screenshot-2020-11-07-at-15.48.57.png" },
                    { 81, 21, "https://i.pinimg.com/736x/fe/a4/ee/fea4ee293d51d97d361981455a409039.jpg" },
                    { 82, 21, "https://i.pinimg.com/originals/06/64/62/066462828cc474586f4bbc7762075066.jpg" },
                    { 83, 21, "https://qph.cf2.quoracdn.net/main-qimg-86086f72424e6dde31d4ed232d778759-lq" },
                    { 84, 21, "https://garden-tags-live.s3-accelerate.amazonaws.com/112884_prettyandprickle_1590158587568_1080.jpeg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketId",
                schema: "basketing",
                table: "BasketItems",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductId",
                table: "Image",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                schema: "ordering",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems",
                schema: "basketing");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "OrderItems",
                schema: "ordering");

            migrationBuilder.DropTable(
                name: "Baskets",
                schema: "basketing");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "ordering");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
