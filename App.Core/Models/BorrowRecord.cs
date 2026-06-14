using System;

namespace App.Core.Models
{
    public class BorrowRecord
    {
        public int BorrowId { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; }
        public int OverdueDays { get; set; }
    }
}