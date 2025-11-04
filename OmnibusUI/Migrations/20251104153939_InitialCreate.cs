using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmnibusUI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patrons",
                columns: table => new
                {
                    patronID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    libCardNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userFirst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userLast = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    booksBorrowwed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrons", x => x.patronID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patrons");
        }
    }
}
