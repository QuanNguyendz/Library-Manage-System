using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Models;
using Respository;

namespace Service
{
    public class BookService : IBookService
    {
        private readonly IBookRespository _bookRepository;

        public BookService(IBookRespository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> GetAllBooks() => _bookRepository.GetAllBooks();
        public Book GetBookById(int id) => _bookRepository.GetBookById(id);
        public void AddBook(Book book) => _bookRepository.AddBook(book);
        public void UpdateBook(Book book) => _bookRepository.UpdateBook(book);
        public void DeleteBook(int id) => _bookRepository.DeleteBook(id);
        public List<Book> SearchBooks(string title, string author, string category) => _bookRepository.SearchBooks(title, author, category);
        public void UpdateBookQuantity(int id, int quantity) => _bookRepository.UpdateBookQuantity(id, quantity);
    }
}
