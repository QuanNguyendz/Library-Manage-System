using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BussinessLayer.Models;
using DataAccessLayer;
using Service;

namespace WPF_QuanNAHE180983
{
    public partial class BookManageWindow : Window
    {
        private readonly IBookService _bookService;

        public BookManageWindow()
        {
            InitializeComponent();
            _bookService = new BookService(new BookRespository());
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
                titleTextBox.Text = selectedBook.Title;
                authorTextBox.Text = selectedBook.Author;
                categoryTextBox.Text = selectedBook.Category;
                quantityTextBox.Text = selectedBook.Quantity.ToString();
                priceTextBox.Text = selectedBook.Price.ToString();
            }
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            var newBook = new Book
            {
                Title = titleTextBox.Text,
                Author = authorTextBox.Text,
                Category = categoryTextBox.Text,
                Quantity = int.Parse(quantityTextBox.Text),
                Price = decimal.Parse(priceTextBox.Text),
            };
            _bookService.AddBook(newBook);
            LoadBooks();
        }
        private void UpdateBook_Click(object sender, RoutedEventArgs e)
        {
            if (bookDataGrid.SelectedItem is Book selectedBook)
            {
                if (!int.TryParse(quantityTextBox.Text, out int quantity) || !decimal.TryParse(priceTextBox.Text, out decimal price))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng số cho Số lượng và Giá!", "Lỗi nhập liệu", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                selectedBook.Title = titleTextBox.Text;
                selectedBook.Author = authorTextBox.Text;
                selectedBook.Category = categoryTextBox.Text;
                selectedBook.Quantity = quantity;
                selectedBook.Price = price;

                _bookService.UpdateBook(selectedBook);
                LoadBooks();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một quyển sách để cập nhật!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            if (bookDataGrid.SelectedItem is Book selectedBook)
            {
                _bookService.DeleteBook(selectedBook.BookId);
                LoadBooks();
            }
        }

        private void SearchBook_Click(object sender, RoutedEventArgs e)
        {
            var books = _bookService.SearchBooks(searchTitle.Text, searchAuthor.Text, searchCategory.Text);
            bookDataGrid.ItemsSource = books;
        }
        private void BorrowingBook_Click(object sender, RoutedEventArgs e)
        {
            BorrowingRecordsWindow record = new BorrowingRecordsWindow();
            record.Show();
            this.Close();
        }
        private void Reader_Click(object sender, RoutedEventArgs e)
        {
            ReaderManageWindow record = new ReaderManageWindow();
            record.Show();
            this.Close();
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow LG = new LoginWindow();
            LG.Show();
            this.Close();
        }
    }
}