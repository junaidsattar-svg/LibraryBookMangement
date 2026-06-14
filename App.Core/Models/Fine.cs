using System;

namespace App.Core.Models
{
    public class Fine
    {
        public int FineId { get; set; }
        public int BorrowId { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public decimal Amount { get; set; }
        public string FineStatus { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime? PaidDate { get; set; }
    }
}