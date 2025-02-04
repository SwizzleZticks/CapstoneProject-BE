using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone_BE.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserLocationOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false),
                    username = table.Column<string>(type: "varchar(55)", unicode: false, maxLength: 55, nullable: true),
                    password = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    first_name = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    last_name = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    email = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3213E83FD9756C82", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    locationId = table.Column<short>(type: "smallint", nullable: false),
                    city = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    state = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Location__30646B6EFE37B25B", x => x.locationId);
                    table.ForeignKey(
                        name: "FK_Locations_Users_locationId",
                        column: x => x.locationId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
