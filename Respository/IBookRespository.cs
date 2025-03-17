using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Models;

namespace Respository
{
    public interface IBookRespository
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        List<Book> SearchBooks(string title, string author, string category);
        void UpdateBookQuantity(int id, int quantity);
    }
}
