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

namespace WPF_QuanNAHE180983
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private UserDAO userDao;

        public LoginWindow()
        {
            InitializeComponent();
            userDao = new UserDAO();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Password;

            User user = userDao.ValidateLogin(username, password);

            if (user == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (user.Role == "Admin")
            {
                MessageBox.Show($"Đăng nhập thành công! Chào {user.Username}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                BookManageWindow bookManage = new BookManageWindow();
                bookManage.Show();
                this.Close();
            }
            else if (user.Role == "Reader")
            {
                int? readerid = userDao.returnReaderID(user.UserId);
                MessageBox.Show($"Đăng nhập thành công! Chào {user.Username}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ReaderViewWindow readerManage = new ReaderViewWindow(readerid.Value);
                readerManage.Show();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
