namespace BookService
{
    public class Book
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        public int AuthorId { get; set; }
        public required string Genre { get; set; }
        public required string ISBN { get; set; }
        public int Quantity { get; set; }
    }
}