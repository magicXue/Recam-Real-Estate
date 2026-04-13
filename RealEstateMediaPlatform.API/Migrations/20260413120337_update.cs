using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateMediaPlatform.API.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListingCases_Agents_AgentId",
                table: "ListingCases");

            migrationBuilder.DropIndex(
                name: "IX_ListingCases_AgentId",
                table: "ListingCases");

            migrationBuilder.AlterColumn<string>(
                name: "AgentId",
                table: "ListingCases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AgentId1",
                table: "ListingCases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListingCases_AgentId1",
                table: "ListingCases",
                column: "AgentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ListingCases_Agents_AgentId1",
                table: "ListingCases",
                column: "AgentId1",
                principalTable: "Agents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListingCases_Agents_AgentId1",
                table: "ListingCases");

            migrationBuilder.DropIndex(
                name: "IX_ListingCases_AgentId1",
                table: "ListingCases");

            migrationBuilder.DropColumn(
                name: "AgentId1",
                table: "ListingCases");

            migrationBuilder.AlterColumn<int>(
                name: "AgentId",
                table: "ListingCases",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ListingCases_AgentId",
                table: "ListingCases",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListingCases_Agents_AgentId",
                table: "ListingCases",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id");
        }
    }
}
