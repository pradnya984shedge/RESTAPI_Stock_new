using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stock_API.Migrations
{
    public partial class profitcenter1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_ProftCenter_ProftCenterId",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_ProftCenterId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "ProftCenterId",
                table: "Stock");

            migrationBuilder.AlterColumn<int>(
                name: "StockId",
                table: "Stock",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Stock",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                table: "Stock",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_Id",
                table: "Stock",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_ProftCenter_Id",
                table: "Stock",
                column: "Id",
                principalTable: "ProftCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_ProftCenter_Id",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_Id",
                table: "Stock");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Stock",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "StockId",
                table: "Stock",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ProftCenterId",
                table: "Stock",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                table: "Stock",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ProftCenterId",
                table: "Stock",
                column: "ProftCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_ProftCenter_ProftCenterId",
                table: "Stock",
                column: "ProftCenterId",
                principalTable: "ProftCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
