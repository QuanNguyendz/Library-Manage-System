using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Models;

namespace DataAccessLayer
{
    public class BorrowingRecordsDAO
    {
        private readonly LibraryManagementContext _context;
        public BorrowingRecordsDAO()
        {
            _context = new LibraryManagementContext();
        }

        public List<BorrowingRecord> GetAllBorrowingRecords()
        {
            return _context.BorrowingRecords.ToList();
        }

        public BorrowingRecord GetBorrowingRecordsById(int id)
        {
            return _context.BorrowingRecords.FirstOrDefault(r => r.RecordId == id);
        }

        public void AddBorrowingRecords(BorrowingRecord borrowing)
        {
            _context.BorrowingRecords.Add(borrowing);
            var book = _context.Books.FirstOrDefault(b => b.BookId == borrowing.BookId);
            if (book != null & book.Quantity > 0)
            {
                book.Quantity -= 1;
            }
            _context.SaveChanges();
        }

        public void UpdateBorrowingRecords(BorrowingRecord borrowing)
        {
            _context.BorrowingRecords.Update(borrowing);
            var book = _context.Books.FirstOrDefault(b => b.BookId == borrowing.BookId);
            if (book == null)
            {
                throw new Exception($"Không tìm thấy sách với ID: {borrowing.BookId}. Vui lòng kiểm tra lại.");
            }
            else if (book != null)
            {

                if ((borrowing.ReturnDate.Value - borrowing.BorrowDate).Days <= 14)
                {
                    book.Quantity += 1;
                }

            }
            _context.SaveChanges();
        }
    }
}
