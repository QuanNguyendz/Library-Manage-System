using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Models;
using Respository;

namespace DataAccessLayer
{
    public class BookRespository : IBookRespository
    {
        private readonly BookDAO _bookDAO;

        public BookRespository()
        {
            _bookDAO = new BookDAO();
        }

        public List<Book> GetAllBooks() => _bookDAO.GetAllBooks();
        public Book GetBookById(int id) => _bookDAO.GetBookById(id);
        public void AddBook(Book book) => _bookDAO.AddBook(book);
        public void UpdateBook(Book book) => _bookDAO.UpdateBook(book);
        public void DeleteBook(int id) => _bookDAO.DeleteBook(id);
        public List<Book> SearchBooks(string title, string author, string category) => _bookDAO.SearchBooks(title, author, category);
        public void UpdateBookQuantity(int id, int quantity) => _bookDAO.UpdateBookQuantity(id, quantity);
    }
}
