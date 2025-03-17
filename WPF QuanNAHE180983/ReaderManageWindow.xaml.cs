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
using Respository;
using Service;

namespace WPF_QuanNAHE180983
{
    /// <summary>
    /// Interaction logic for ReaderManageWindow.xaml
    /// </summary>
    public partial class ReaderManageWindow : Window
    {
        private readonly IReaderService _readerService;

        public ReaderManageWindow()
        {
            InitializeComponent();
            _readerService = new ReaderService(new ReaderRespository());
            LoadReader();
        }

        private void LoadReader()
        {
            var reader = _readerService.GetAllReader();
            readerDataGrid.ItemsSource = reader;
        }
        private void readerDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedReader = readerDataGrid.SelectedItem as Reader;

            if (selectedReader != null)
            {
                fullnameTextBox.Text = selectedReader.FullName;
                emailTextBox.Text = selectedReader.Email;
                phonenumberTextBox.Text = selectedReader.PhoneNumber;
            }
        }

        private void AddReader_Click(object sender, RoutedEventArgs e)
        {
            var newReader = new Reader
            {
                FullName = fullnameTextBox.Text,
                Email = emailTextBox.Text,
                PhoneNumber = phonenumberTextBox.Text,
            };
            _readerService.AddReader(newReader);
            LoadReader();
        }
        private void UpdateReader_Click(object sender, RoutedEventArgs e)
        {
            if (readerDataGrid.SelectedItem is Reader selectedReader)
            {


                selectedReader.FullName = fullnameTextBox.Text;
                selectedReader.Email = emailTextBox.Text;
                selectedReader.PhoneNumber = phonenumberTextBox.Text;
                _readerService.UpdateReader(selectedReader);
                LoadReader();
            }
        }


        private void DeleteReader_Click(object sender, RoutedEventArgs e)
        {
            if (readerDataGrid.SelectedItem is Reader selectedReader)
            {
                _readerService.DeleteReader(selectedReader.ReaderId);
                LoadReader();
            }
        }

        private void SearchReader_Click(object sender, RoutedEventArgs e)
        {
            var reader = _readerService.SearchReader(searchName.Text);
            readerDataGrid.ItemsSource = reader;
        }

        private void Borrowing_Click(object sender, RoutedEventArgs e)
        {
            BorrowingRecordsWindow record = new BorrowingRecordsWindow();
            record.Show();
            this.Close();
        }
        private void Book_Click(object sender, RoutedEventArgs e)
        {
            BookManageWindow record = new BookManageWindow();
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
