using Carter;
using Microsoft.EntityFrameworkCore;

namespace BookService
{
    public class BookModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/books");

            // GET: Get all books
            group.MapGet("/", async (ApplicationDbContext context) =>
            {
                var books = await context.Books.ToListAsync();
                return Results.Ok(books);
            });

            // GET: Get book by ID
            group.MapGet("/{id:int}", async (int id, ApplicationDbContext context) =>
            {
                var book = await context.Books.FindAsync(id);
                if (book == null)
                {
                    return Results.NotFound($"Book with ID {id} not found.");
                }
                return Results.Ok(book);
            });

            // POST: Create new book
            group.MapPost("/", async (Book book, ApplicationDbContext context) =>
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(book.Title) ||
                    string.IsNullOrWhiteSpace(book.Genre) ||
                    string.IsNullOrWhiteSpace(book.ISBN))
                {
                    return Results.BadRequest("Title, Genre, and ISBN are required fields.");
                }

                // Check if ISBN already exists
                var existingBook = await context.Books
                    .FirstOrDefaultAsync(b => b.ISBN == book.ISBN);
                if (existingBook != null)
                {
                    return Results.BadRequest("A book with this ISBN already exists.");
                }

                context.Books.Add(book);
                await context.SaveChangesAsync();

                return Results.Created($"/api/books/{book.BookId}", book);
            });

            // PUT: Update existing book
            group.MapPut("/{id:int}", async (int id, Book updatedBook, ApplicationDbContext context) =>
            {
                var book = await context.Books.FindAsync(id);
                if (book == null)
                {
                    return Results.NotFound($"Book with ID {id} not found.");
                }

                // Validate required fields
                if (string.IsNullOrWhiteSpace(updatedBook.Title) ||
                    string.IsNullOrWhiteSpace(updatedBook.Genre) ||
                    string.IsNullOrWhiteSpace(updatedBook.ISBN))
                {
                    return Results.BadRequest("Title, Genre, and ISBN are required fields.");
                }

                // Check if ISBN already exists for another book
                var existingBook = await context.Books
                    .FirstOrDefaultAsync(b => b.ISBN == updatedBook.ISBN && b.BookId != id);
                if (existingBook != null)
                {
                    return Results.BadRequest("A book with this ISBN already exists.");
                }

                // Update properties
                book.Title = updatedBook.Title;
                book.AuthorId = updatedBook.AuthorId;
                book.Genre = updatedBook.Genre;
                book.ISBN = updatedBook.ISBN;
                book.Quantity = updatedBook.Quantity;

                await context.SaveChangesAsync();

                return Results.Ok(book);
            });

            // DELETE: Delete book by ID
            group.MapDelete("/{id:int}", async (int id, ApplicationDbContext context) =>
            {
                var book = await context.Books.FindAsync(id);
                if (book == null)
                {
                    return Results.NotFound($"Book with ID {id} not found.");
                }

                context.Books.Remove(book);
                await context.SaveChangesAsync();

                return Results.Ok($"Book with ID {id} has been deleted.");
            });

            // GET: Search books by title or genre
            group.MapGet("/search", async (string? title, string? genre, ApplicationDbContext context) =>
            {
                var query = context.Books.AsQueryable();

                if (!string.IsNullOrWhiteSpace(title))
                {
                    query = query.Where(b => b.Title.Contains(title));
                }

                if (!string.IsNullOrWhiteSpace(genre))
                {
                    query = query.Where(b => b.Genre.Contains(genre));
                }

                var books = await query.ToListAsync();
                return Results.Ok(books);
            });

            // GET: Get books by author ID
            group.MapGet("/author/{authorId:int}", async (int authorId, ApplicationDbContext context) =>
            {
                var books = await context.Books
                    .Where(b => b.AuthorId == authorId)
                    .ToListAsync();
                return Results.Ok(books);
            });
        }
    }
}