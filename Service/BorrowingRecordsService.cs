using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Models;
using Respository;

namespace Service
{
    public class BorrowingRecordsService : IBorrowingRecordsService
    {
        private readonly IBorrowingRecordsRespository _borrowingRepository;

        public BorrowingRecordsService(IBorrowingRecordsRespository borrowingRepository)
        {
            _borrowingRepository = borrowingRepository;
        }

        public void AddBorrowingRecords(BorrowingRecord borrowing) => _borrowingRepository.AddBorrowingRecords(borrowing);

        public List<BorrowingRecord> GetAllBorrowingRecords() => _borrowingRepository.GetAllBorrowingRecords();

        public BorrowingRecord GetBorrowingRecordsById(int id) => _borrowingRepository.GetBorrowingRecordsById(id);

        public void UpdateBorrowingRecords(BorrowingRecord borrowing) => _borrowingRepository.UpdateBorrowingRecords(borrowing);
    }
}
