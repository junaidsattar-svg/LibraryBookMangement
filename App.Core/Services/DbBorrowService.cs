using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using App.Core.Models;
using App.Core.Interfaces;

namespace App.Core.Services
{
    public class DbBorrowService : IBorrowService
    {
        private readonly string _connectionString;

        public DbBorrowService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<BorrowRecord> GetAllBorrows()
        {
            var list = new List<BorrowRecord>();
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"SELECT br.*, b.Title AS BookTitle, m.FullName AS MemberName
                    FROM BorrowRecords br
                    JOIN Books b ON br.BookId = b.BookId
                    JOIN Members m ON br.MemberId = m.MemberId", con);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(MapBorrow(reader));
                }
            }
            return list;
        }

        public List<BorrowRecord> GetActiveBorrows()
        {
            var list = new List<BorrowRecord>();
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"SELECT br.*, b.Title AS BookTitle, m.FullName AS MemberName
                    FROM BorrowRecords br
                    JOIN Books b ON br.BookId = b.BookId
                    JOIN Members m ON br.MemberId = m.MemberId
                    WHERE br.Status = 'Borrowed'", con);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(MapBorrow(reader));
                }
            }
            return list;
        }

        public List<BorrowRecord> GetBorrowsByMember(int memberId)
        {
            var list = new List<BorrowRecord>();
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"SELECT br.*, b.Title AS BookTitle, m.FullName AS MemberName
                    FROM BorrowRecords br
                    JOIN Books b ON br.BookId = b.BookId
                    JOIN Members m ON br.MemberId = m.MemberId
                    WHERE br.MemberId = @id", con);
                cmd.Parameters.AddWithValue("@id", memberId);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(MapBorrow(reader));
                }
            }
            return list;
        }

        public void BorrowBook(BorrowRecord borrow)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                var cmd = new SqlCommand(@"INSERT INTO BorrowRecords (BookId, MemberId, BorrowDate, DueDate, Status)
                    VALUES (@bookId, @memberId, @borrow, @due, 'Borrowed')", con);
                cmd.Parameters.AddWithValue("@bookId", borrow.BookId);
                cmd.Parameters.AddWithValue("@memberId", borrow.MemberId);
                cmd.Parameters.AddWithValue("@borrow", borrow.BorrowDate);
                cmd.Parameters.AddWithValue("@due", borrow.DueDate);
                cmd.ExecuteNonQuery();

                var updateCmd = new SqlCommand("UPDATE Books SET AvailCopies = AvailCopies - 1 WHERE BookId = @id", con);
                updateCmd.Parameters.AddWithValue("@id", borrow.BookId);
                updateCmd.ExecuteNonQuery();
            }
        }

        public void ReturnBook(int borrowId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                int bookId = 0;
                DateTime dueDate = DateTime.Now;
                int memberId = 0;

                var getCmd = new SqlCommand("SELECT BookId, DueDate, MemberId FROM BorrowRecords WHERE BorrowId = @id", con);
                getCmd.Parameters.AddWithValue("@id", borrowId);
                using (var reader = getCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        bookId = (int)reader["BookId"];
                        dueDate = Convert.ToDateTime(reader["DueDate"]);
                        memberId = (int)reader["MemberId"];
                    }
                }

                var returnCmd = new SqlCommand("UPDATE BorrowRecords SET ReturnDate=@ret, Status='Returned' WHERE BorrowId=@id", con);
                returnCmd.Parameters.AddWithValue("@ret", DateTime.Now);
                returnCmd.Parameters.AddWithValue("@id", borrowId);
                returnCmd.ExecuteNonQuery();

                var availCmd = new SqlCommand("UPDATE Books SET AvailCopies = AvailCopies + 1 WHERE BookId = @id", con);
                availCmd.Parameters.AddWithValue("@id", bookId);
                availCmd.ExecuteNonQuery();

                if (DateTime.Now > dueDate)
                {
                    int days = (int)(DateTime.Now - dueDate).TotalDays;
                    decimal fine = days * 10;
                    var fineCmd = new SqlCommand(@"INSERT INTO Fines (BorrowId, MemberId, Amount, FineStatus, IssuedDate)
                        VALUES (@bid, @mid, @amount, 'Pending', GETDATE())", con);
                    fineCmd.Parameters.AddWithValue("@bid", borrowId);
                    fineCmd.Parameters.AddWithValue("@mid", memberId);
                    fineCmd.Parameters.AddWithValue("@amount", fine);
                    fineCmd.ExecuteNonQuery();
                }
            }
        }

        public List<Fine> GetPendingFines()
        {
            var list = new List<Fine>();
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"SELECT f.*, m.FullName AS MemberName FROM Fines f
                    JOIN Members m ON f.MemberId = m.MemberId
                    WHERE f.FineStatus = 'Pending'", con);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Fine
                        {
                            FineId = (int)reader["FineId"],
                            MemberId = (int)reader["MemberId"],
                            MemberName = reader["MemberName"].ToString(),
                            Amount = (decimal)reader["Amount"],
                            FineStatus = reader["FineStatus"].ToString(),
                            IssuedDate = Convert.ToDateTime(reader["IssuedDate"])
                        });
                    }
                }
            }
            return list;
        }

        public void PayFine(int fineId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("UPDATE Fines SET FineStatus='Paid', PaidDate=GETDATE() WHERE FineId=@id", con);
                cmd.Parameters.AddWithValue("@id", fineId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private BorrowRecord MapBorrow(System.Data.SqlClient.SqlDataReader reader)
        {
            return new BorrowRecord
            {
                BorrowId = (int)reader["BorrowId"],
                BookId = (int)reader["BookId"],
                MemberId = (int)reader["MemberId"],
                BookTitle = reader["BookTitle"].ToString(),
                MemberName = reader["MemberName"].ToString(),
                BorrowDate = Convert.ToDateTime(reader["BorrowDate"]),
                DueDate = Convert.ToDateTime(reader["DueDate"]),
                ReturnDate = reader["ReturnDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["ReturnDate"]),
                Status = reader["Status"].ToString()
            };
        }
    }
}