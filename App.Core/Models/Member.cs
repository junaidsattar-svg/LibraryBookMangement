using System;

namespace App.Core.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string MemberStatus { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}