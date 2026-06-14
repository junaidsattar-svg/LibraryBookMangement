using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using App.Core.Models;
using App.Core.Interfaces;

namespace App.Core.Services
{
    public class DbBookService : IBookService
    {
        private readonly string _connectionString;

        public DbBookService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Book> GetAllBooks()
        {
            var list = new List<Book>();
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Books", con);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Book
                        {
                            BookId = (int)reader["BookId"],
                            Title = reader["Title"].ToString(),
                            Author = reader["Author"].ToString(),
                            ISBN = reader["ISBN"].ToString(),
                            CategoryId = (int)reader["CategoryId"],
                            TotalCopies = (int)reader["TotalCopies"],
                            AvailCopies = (int)reader["AvailCopies"],
                            Publisher = reader["Publisher"].ToString(),
                            Status = reader["Status"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public Book GetBookById(int bookId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Books WHERE BookId = @id", con);
                cmd.Parameters.AddWithValue("@id", bookId);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Book
                        {
                            BookId = (int)reader["BookId"],
                            Title = reader["Title"].ToString(),
                            Author = reader["Author"].ToString(),
                            ISBN = reader["ISBN"].ToString(),
                            CategoryId = (int)reader["CategoryId"],
                            TotalCopies = (int)reader["TotalCopies"],
                            AvailCopies = (int)reader["AvailCopies"],
                            Publisher = reader["Publisher"].ToString(),
                            Status = reader["Status"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public void AddBook(Book book)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"INSERT INTO Books 
                    (Title, Author, ISBN, CategoryId, TotalCopies, AvailCopies, Publisher, PublishYear, Status)
                    VALUES (@title, @author, @isbn, @cat, @total, @avail, @pub, @year, @status)", con);
                cmd.Parameters.AddWithValue("@title", book.Title);
                cmd.Parameters.AddWithValue("@author", book.Author);
                cmd.Parameters.AddWithValue("@isbn", book.ISBN);
                cmd.Parameters.AddWithValue("@cat", book.CategoryId);
                cmd.Parameters.AddWithValue("@total", book.TotalCopies);
                cmd.Parameters.AddWithValue("@avail", book.AvailCopies);
                cmd.Parameters.AddWithValue("@pub", book.Publisher);
                cmd.Parameters.AddWithValue("@year", book.PublishYear);
                cmd.Parameters.AddWithValue("@status", book.Status ?? "Available");
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateBook(Book book)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"UPDATE Books SET 
                    Title=@title, Author=@author, ISBN=@isbn, CategoryId=@cat,
                    TotalCopies=@total, AvailCopies=@avail, Publisher=@pub,
                    PublishYear=@year, Status=@status
                    WHERE BookId=@id", con);
                cmd.Parameters.AddWithValue("@title", book.Title);
                cmd.Parameters.AddWithValue("@author", book.Author);
                cmd.Parameters.AddWithValue("@isbn", book.ISBN);
                cmd.Parameters.AddWithValue("@cat", book.CategoryId);
                cmd.Parameters.AddWithValue("@total", book.TotalCopies);
                cmd.Parameters.AddWithValue("@avail", book.AvailCopies);
                cmd.Parameters.AddWithValue("@pub", book.Publisher);
                cmd.Parameters.AddWithValue("@year", book.PublishYear);
                cmd.Parameters.AddWithValue("@status", book.Status);
                cmd.Parameters.AddWithValue("@id", book.BookId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteBook(int bookId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("DELETE FROM Books WHERE BookId = @id", con);
                cmd.Parameters.AddWithValue("@id", bookId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Book> SearchBooks(string keyword)
        {
            var list = new List<Book>();
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Books WHERE Title LIKE @kw OR Author LIKE @kw", con);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Book
                        {
                            BookId = (int)reader["BookId"],
                            Title = reader["Title"].ToString(),
                            Author = reader["Author"].ToString(),
                            ISBN = reader["ISBN"].ToString(),
                            Status = reader["Status"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public List<Category> GetAllCategories()
        {
            var list = new List<Category>();
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Categories", con);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Category
                        {
                            CategoryId = (int)reader["CategoryId"],
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}