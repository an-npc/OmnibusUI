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
                name: "Authors",
                columns: table => new
                {
                    authID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.authID);
                });

            migrationBuilder.CreateTable(
                name: "Bookhouse",
                columns: table => new
                {
                    isbn = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    publicationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    numPages = table.Column<int>(type: "int", nullable: false),
                    avgRating = table.Column<double>(type: "float", nullable: false),
                    isDigital = table.Column<bool>(type: "bit", nullable: false),
                    copiesAvail = table.Column<int>(type: "int", nullable: false),
                    authorID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookhouse", x => x.isbn);
                });

            migrationBuilder.CreateTable(
                name: "LibraryCards",
                columns: table => new
                {
                    libCardNum = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    issueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    expDate = table.Column<DateOnly>(type: "date", nullable: false),
                    fines = table.Column<double>(type: "float", nullable: false),
                    booksBorrowed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryCards", x => x.libCardNum);
                });

            migrationBuilder.CreateTable(
                name: "Patrons",
                columns: table => new
                {
                    libCardNum = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userFirst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userLast = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    homeAddress = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrons", x => x.libCardNum);
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
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Bookhouse");

            migrationBuilder.DropTable(
                name: "LibraryCards");

            migrationBuilder.DropTable(
                name: "Patrons");

            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
