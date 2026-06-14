namespace App.Core.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int TotalCopies { get; set; }
        public int AvailCopies { get; set; }
        public int PublishYear { get; set; }
        public string Publisher { get; set; }
        public string Status { get; set; }
    }
}