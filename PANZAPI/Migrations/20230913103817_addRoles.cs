using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PANZAPI.Migrations
{
    /// <inheritdoc />
    public partial class addRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO AspNetRoles (Id, [Name], NormalizedName, ConcurrencyStamp)
                VALUES
                (NEWID(), 'SuperAdmin', 'Super Admin', 1),
                (NEWID(), 'Admin', 'Admin', 2),
                (NEWID(), 'Member', 'Member', 3)           
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
