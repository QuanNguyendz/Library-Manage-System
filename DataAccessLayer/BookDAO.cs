using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Models;

namespace DataAccessLayer
{
    public class BookDAO
    {
        private readonly LibraryManagementContext _context;
        public BookDAO()
        {
            _context = new LibraryManagementContext();
        }
        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(b => b.BookId == id);
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public List<Book> SearchBooks(string title, string author, string category)
        {
            return _context.Books
                .Where(b => (string.IsNullOrEmpty(title) || b.Title.Contains(title)) &&
                            (string.IsNullOrEmpty(author) || b.Author.Contains(author)) &&
                            (string.IsNullOrEmpty(category) || b.Category.Contains(category)))
                .ToList();
        }

        public void UpdateBookQuantity(int bookid, int quantitychange)
        {
            var book = _context.Books.FirstOrDefault(b => b.BookId == bookid);
            book.Quantity += quantitychange;
            if (book.Quantity < 0)
            {
                throw new Exception("Not enough boooks in the libary");
            }
            _context.SaveChanges();
        }
    }
}
