using System.Collections.Generic;
using App.Core.Models;

namespace App.Core.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetBookById(int bookId);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int bookId);
        List<Book> SearchBooks(string keyword);
        List<Category> GetAllCategories();
    }
}