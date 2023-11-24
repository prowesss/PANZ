using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PANZAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateFieldStripePriceIdInMembershipTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StripePriceId",
                table: "MembershipTypes",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StripePriceId",
                table: "MembershipTypes");
        }
    }
}
