using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookNest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatinProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FeedBack",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeedBack",
                table: "Ratings");
        }
    }
}
