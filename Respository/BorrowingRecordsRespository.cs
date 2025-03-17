using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Models;
using DataAccessLayer;

namespace Respository
{
    public class BorrowingRecordsRespository : IBorrowingRecordsRespository
    {
        private readonly BorrowingRecordsDAO _borrowingDAO;

        public BorrowingRecordsRespository()
        {
            _borrowingDAO = new BorrowingRecordsDAO();
        }

        public void AddBorrowingRecords(BorrowingRecord borrowing) => _borrowingDAO.AddBorrowingRecords(borrowing);

        public List<BorrowingRecord> GetAllBorrowingRecords() => _borrowingDAO.GetAllBorrowingRecords();

        public BorrowingRecord GetBorrowingRecordsById(int id) => _borrowingDAO.GetBorrowingRecordsById(id);

        public void UpdateBorrowingRecords(BorrowingRecord borrowing) => _borrowingDAO.UpdateBorrowingRecords(borrowing);
    }
}
