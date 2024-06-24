using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BPS_Ecom_Shop.Migrations
{
    /// <inheritdoc />
    public partial class M22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PieGiftOrders",
                columns: table => new
                {
                    PieGiftOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PieId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieGiftOrders", x => x.PieGiftOrderId);
                    table.ForeignKey(
                        name: "FK_PieGiftOrders_Pies_PieId",
                        column: x => x.PieId,
                        principalTable: "Pies",
                        principalColumn: "PieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PieGiftOrders_PieId",
                table: "PieGiftOrders",
                column: "PieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PieGiftOrders");
        }
    }
}
