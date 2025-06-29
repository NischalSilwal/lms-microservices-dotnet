using Carter;
using System.Text.Json;

public class DashboardModule : CarterModule
{
    public DashboardModule() : base("/api/dashboard") { }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/summary", async (HttpClient client) =>
        {
            int totalStudents = 0;
            int totalBooks = 0;

            try
            {
                var studentRes = await client.GetAsync("http://localhost:5112/api/students");
                if (studentRes.IsSuccessStatusCode)
                {
                    var studentJson = await studentRes.Content.ReadAsStringAsync();
                    var students = JsonSerializer.Deserialize<List<object>>(studentJson);
                    totalStudents = students?.Count ?? 0;
                }

                var bookRes = await client.GetAsync("http://localhost:5115/api/books");
                if (bookRes.IsSuccessStatusCode)
                {
                    var bookJson = await bookRes.Content.ReadAsStringAsync();
                    var books = JsonSerializer.Deserialize<List<object>>(bookJson);
                    totalBooks = books?.Count ?? 0;
                }
            }
            catch (Exception ex)
            {
                return Results.Problem("Error fetching data: " + ex.Message);
            }

            return Results.Ok(new
            {
                totalStudents,
                totalBooks
            });
        });
    }
}
