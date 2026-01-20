using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.Migrations
{
    /// <inheritdoc />
    public partial class afterconstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "ck_product_price_>0",
                table: "Product",
                sql: "[price] > 0");

            migrationBuilder.AddCheckConstraint(
                name: "ck_product_quantity> 0",
                table: "Product",
                sql: "[stockQty] > 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "ck_product_price_>0",
                table: "Product");

            migrationBuilder.DropCheckConstraint(
                name: "ck_product_quantity> 0",
                table: "Product");
        }
    }
}
