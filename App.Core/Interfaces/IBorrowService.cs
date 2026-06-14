using System.Collections.Generic;
using App.Core.Models;

namespace App.Core.Interfaces
{
    public interface IBorrowService
    {
        List<BorrowRecord> GetAllBorrows();
        List<BorrowRecord> GetActiveBorrows();
        void BorrowBook(BorrowRecord record);
        void ReturnBook(int borrowId);
        List<BorrowRecord> GetBorrowsByMember(int memberId);
        List<Fine> GetPendingFines();
        void PayFine(int fineId);
    }
}