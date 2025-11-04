using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmnibusUI.Migrations
{
    /// <inheritdoc />
    public partial class AddBookhouseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookhouse",
                columns: table => new
                {
                    bookID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    authorFirst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    authorLast = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    publicationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numPages = table.Column<int>(type: "int", nullable: false),
                    avgRating = table.Column<float>(type: "real", nullable: false),
                    isDigital = table.Column<int>(type: "int", nullable: false),
                    copiesAvail = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookhouse", x => x.bookID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookhouse");
        }
    }
}
