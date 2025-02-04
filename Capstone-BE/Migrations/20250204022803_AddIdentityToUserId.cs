using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone_BE.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityToUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "id",
                table: "Users",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint")
                .Annotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "id",
                table: "Users",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
