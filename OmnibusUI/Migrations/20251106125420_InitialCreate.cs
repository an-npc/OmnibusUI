using System;
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
                name: "Bookhouse",
                columns: table => new
                {
                    bookID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    authorFirst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    authorLast = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    publicationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numPages = table.Column<int>(type: "int", nullable: false),
                    avgRating = table.Column<double>(type: "float", nullable: false),
                    isDigital = table.Column<bool>(type: "bit", nullable: false),
                    copiesAvail = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookhouse", x => x.bookID);
                });

            migrationBuilder.CreateTable(
                name: "Patrons",
                columns: table => new
                {
                    patronID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    libCardNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userFirst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userLast = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    booksBorrowed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrons", x => x.patronID);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    bookID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    authorFirst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    authorLast = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.bookID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookhouse");

            migrationBuilder.DropTable(
                name: "Patrons");

            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
