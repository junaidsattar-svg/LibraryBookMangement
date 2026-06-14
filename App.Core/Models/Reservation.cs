using System;

namespace App.Core.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Status { get; set; }
    }
}