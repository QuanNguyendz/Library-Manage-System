using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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
    /// Interaction logic for BorrowingRecordsWindow.xaml
    /// </summary>
    public partial class BorrowingRecordsWindow : Window
    {
        private readonly IBorrowingRecordsService _borrowingService;
        private readonly IBookService _bookservice;

        public BorrowingRecordsWindow()
        {
            InitializeComponent();
            _borrowingService = new BorrowingRecordsService(new BorrowingRecordsRespository());
            _bookservice = new BookService(new BookRespository());
            LoadBorrowingRecords();
        }

        private void LoadBorrowingRecords()
        {
            var borrowing = _borrowingService.GetAllBorrowingRecords();
            borrowingDataGrid.ItemsSource = borrowing;
        }
        private void borrowingDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedBorrowing = borrowingDataGrid.SelectedItem as BorrowingRecord;

            if (selectedBorrowing != null)
            {
                recordidTextBox.Text = selectedBorrowing.RecordId.ToString();
                readeridTextBox.Text = selectedBorrowing.ReaderId.ToString();
                bookidTextBox.Text = selectedBorrowing.BookId.ToString();
                borrowdatePicker.SelectedDate = selectedBorrowing.BorrowDate;
                returndatePicker.SelectedDate = selectedBorrowing.ReturnDate ?? null;
                statusTextBox.Text = selectedBorrowing.Status;
            }
        }


        private void AddBorrowing_Click(object sender, RoutedEventArgs e)
        {
            var newBorrowings = new BorrowingRecord
            {
                RecordId = int.Parse(recordidTextBox.Text),
                ReaderId = int.Parse(readeridTextBox.Text),
                BookId = int.Parse(bookidTextBox.Text),
                BorrowDate = borrowdatePicker.SelectedDate ?? DateTime.Now,
                ReturnDate = null,
                Status = "Borrowed"
            };
            _borrowingService.AddBorrowingRecords(newBorrowings);
            _bookservice.UpdateBookQuantity(newBorrowings.BookId, -1);
            LoadBorrowingRecords();
        }
        private void UpdateBorrowing_Click(object sender, RoutedEventArgs e)
        {
            if (borrowingDataGrid.SelectedItem is BorrowingRecord selectedBorrowing)
            {
                selectedBorrowing.RecordId = int.Parse(recordidTextBox.Text);
                selectedBorrowing.ReaderId = int.Parse(bookidTextBox.Text);
                selectedBorrowing.BookId = int.Parse(bookidTextBox.Text);
                selectedBorrowing.BorrowDate = borrowdatePicker.SelectedDate ?? DateTime.Now;
                if (returndatePicker.SelectedDate.HasValue)
                {
                    selectedBorrowing.ReturnDate = returndatePicker.SelectedDate;

                    TimeSpan duration = selectedBorrowing.ReturnDate.Value - selectedBorrowing.BorrowDate;
                    if (duration.Days > 14)
                    {
                        selectedBorrowing.Status = "Overdue";
                    }
                    else if (duration.Days <= 14 && duration.Days > 0)
                    {
                        selectedBorrowing.Status = "Returned";
                        _bookservice.UpdateBookQuantity(selectedBorrowing.BookId, 1);
                    }
                }
                else
                {
                    selectedBorrowing.Status = "Borrowed";
                }

                _borrowingService.UpdateBorrowingRecords(selectedBorrowing);
                LoadBorrowingRecords();
            }
        }
        private void Books_Click(object sender, RoutedEventArgs e)
        {
            BookManageWindow record = new BookManageWindow();
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
