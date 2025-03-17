using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using BussinessLayer.Models;
using Microsoft.EntityFrameworkCore;
namespace DataAccessLayer
{
    public class UserDAO
    {
        private readonly LibraryManagementContext _context;
        public UserDAO()
        {
            _context = new LibraryManagementContext();
        }
        public User ValidateLogin(string username, string password)
        {
            string hashedPassword = SecurityHelper.HashPassword(password);
            return _context.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == hashedPassword);
        }

        public int? returnReaderID(int userid)
        {
            return _context.Users
                 .Where(u => u.UserId == userid && u.Role == "Reader")
                 .Select(u => u.ReaderId)
                 .FirstOrDefault();
        }

    }
}
