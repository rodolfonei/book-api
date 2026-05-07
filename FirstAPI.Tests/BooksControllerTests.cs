using FirstAPI.Controllers;
using FirstAPI.Data;
using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FirstAPI.Tests
{
    public class BooksControllerTests
    {
        private BooksController CreateController(FirstAPIContext context)
        {
            var controller = new BooksController(context);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "testuser"),
                new Claim(ClaimTypes.Role, UserRoles.Admin)
            };
            var identity = new ClaimsIdentity(claims, "TestAuth");
            var principal = new ClaimsPrincipal(identity);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = principal }
            };

            return controller;
        }

        [Fact]
        public async Task GetBooks_ReturnsOkResult_WithListOfBooks()
        {
            var books = new List<Book>
            {
                new Book { Id = 1, Title = "Book 1", Author = "Author 1", YearPublished = 2020 },
                new Book { Id = 2, Title = "Book 2", Author = "Author 2", YearPublished = 2021 }
            };

            var options = new DbContextOptionsBuilder<FirstAPIContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new FirstAPIContext(options);
            context.Books.AddRange(books);
            await context.SaveChangesAsync();

            var controller = CreateController(context);

            var result = await controller.GetBooks();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedBooks = Assert.IsType<List<Book>>(okResult.Value);
            Assert.Equal(2, returnedBooks.Count);
            Assert.Equal("Book 1", returnedBooks[0].Title);
        }

        [Fact]
        public async Task GetBooks_ReturnsEmptyList_WhenNoBooks()
        {
            var options = new DbContextOptionsBuilder<FirstAPIContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new FirstAPIContext(options);

            var controller = CreateController(context);

            var result = await controller.GetBooks();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedBooks = Assert.IsType<List<Book>>(okResult.Value);
            Assert.Empty(returnedBooks);
        }
    }
}