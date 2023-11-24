using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PANZAPI.Migrations
{
    /// <inheritdoc />
    public partial class changeToNullableInMemberTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<string>(
              name: "PaymentMethodId",
              table: "Members",
              nullable: true);
            migrationBuilder.AlterColumn<string>(
              name: "PaymentSessionId",
              table: "Members",
              nullable: true);
            migrationBuilder.AlterColumn<string>(
              name: "PaymentReference",
              table: "Members",
              nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
