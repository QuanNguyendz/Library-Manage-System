using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BussinessLayer.Models;
using DataAccessLayer;
using Respository;
using Service;

namespace WPF_QuanNAHE180983
{
    /// <summary>
    /// Interaction logic for ReaderViewWindow.xaml
    /// </summary>
    public partial class ReaderViewWindow : Window
    {
        private readonly IBookService _bookService;
        private readonly IBorrowingRecordsService _borrowingService;
        private int _readerId;
        public ReaderViewWindow(int readerId)
        {
            InitializeComponent();
            _readerId = readerId;
            _bookService = new BookService(new BookRespository());
            _borrowingService = new BorrowingRecordsService(new BorrowingRecordsRespository());
            LoadBooks();
        }

        private void LoadBooks()
        {
            var books = _bookService.GetAllBooks();
            bookDataGrid.ItemsSource = books;
        }
        private void bookDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Lấy dòng đang được chọn
            var selectedBook = bookDataGrid.SelectedItem as Book;

            if (selectedBook != null)
            {
                bookidTextBox.Text = selectedBook.BookId.ToString();
                titleTextBox.Text = selectedBook.Title;
                authorTextBox.Text = selectedBook.Author;
                categoryTextBox.Text = selectedBook.Category;
                quantityTextBox.Text = selectedBook.Quantity.ToString();
                priceTextBox.Text = selectedBook.Price.ToString();
            }
        }

        private void BorrowBook_Click(object sender, RoutedEventArgs e)
        {
            var newBorrowings = new BorrowingRecord
            {
                ReaderId = _readerId,
                BookId = int.Parse(bookidTextBox.Text),
                BorrowDate = DateTime.Now,
                ReturnDate = null,
                Status = "Borrowed"
            };
            _borrowingService.AddBorrowingRecords(newBorrowings);
            _bookService.UpdateBookQuantity(newBorrowings.BookId, -1);
            LoadBooks();
        }

        private void SearchBook_Click(object sender, RoutedEventArgs e)
        {
            var books = _bookService.SearchBooks(searchTitle.Text, searchAuthor.Text, searchCategory.Text);
            bookDataGrid.ItemsSource = books;
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow LG = new LoginWindow();
            LG.Show();
            this.Close();
        }
    }
}
