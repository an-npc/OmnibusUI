using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmnibusUI.Data;
using OmnibusUI.Models;
using Microsoft.EntityFrameworkCore;

namespace OmnibusUI.Tests;
[TestClass]
public sealed class Tests
{
    public DbContextOptions<OmnibusUI.Data.AppDbContext> getOptions()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        var connectionString = config.GetConnectionString("DefaultConnection");

        var options = new DbContextOptionsBuilder<AppDbContext>()
        .UseSqlServer(connectionString)
        .Options;

        return options;
    }
   
    /////////// TEST 1: CREATE BOOK ///////////
    [TestMethod]
    public async Task T1_BookCreate()
    { 
        var context = new AppDbContext(getOptions());
        var book = new Book
        {
            isbn = "123456789",
            title = "Intro to Databases",
            genre = "Drama",
            publicationDate = DateOnly.Parse("2025-12-01"),
            numPages = 100,
            avgRating = 5.0,
            isDigital = true,
            copiesAvail = 100,
            authorID = "987654321",
        };
        context.Bookhouse.Add(book);
        await context.SaveChangesAsync();
        var savedBook = await context.Bookhouse.FindAsync("123456789");
        Assert.IsNotNull(savedBook);
    }

    /////////// TEST 2: FIND BOOK BY TITLE ///////////
    [TestMethod]
    public async Task T2_BookFind_Title()
    {
        var context = new AppDbContext(getOptions());
        var book = await context.Bookhouse.FirstOrDefaultAsync(b => b.title == "Intro to Databases");
        Assert.IsNotNull(book);
    }

    /////////// TEST 3: UPDATE EXISTING BOOK ///////////
    [TestMethod]
    public async Task T3_BookUpdate()
    {
        var context = new AppDbContext(getOptions());
        var editPage = new OmnibusUI.Pages.Bookhouse.EditModel(context);
        editPage.Book = new Book
        {
            isbn = "123456789",
            title = "Introduction to Databases",
            genre = "Drama",
            publicationDate = DateOnly.Parse("1999-12-01"),
            numPages = 150,
            avgRating = 4.5,
            isDigital = false,
            copiesAvail = 1,
            authorID = "111111111"
        };
        var result = await editPage.OnPostAsync();

        var updatedBook = await context.Bookhouse.FindAsync("123456789");
        Assert.IsNotNull(updatedBook);
        Assert.AreEqual("Introduction to Databases", updatedBook.title);
        Assert.AreEqual("Drama", updatedBook.genre);
        Assert.AreEqual(DateOnly.Parse("1999-12-01"), updatedBook.publicationDate);
        Assert.AreEqual(150, updatedBook.numPages);
        Assert.AreEqual(4.5, updatedBook.avgRating);
        Assert.AreEqual(false, updatedBook.isDigital);
        Assert.AreEqual(1, updatedBook.copiesAvail);
        Assert.AreEqual("111111111", updatedBook.authorID);
    }

    /////////// TEST 4: DELETE BOOK ///////////
    [TestMethod]
    public async Task T4_BookDelete()
    {
        var context = new AppDbContext(getOptions());
        var book = await context.Bookhouse.FindAsync("123456789");
        if (book != null)
        {
            context.Bookhouse.Remove(book);
            await context.SaveChangesAsync();
        }
        var deletedBook = await context.Bookhouse.FindAsync("123456789");
        Assert.IsNull(deletedBook);
    }
}