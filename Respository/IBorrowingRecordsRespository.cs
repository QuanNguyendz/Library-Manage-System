using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Models;

namespace Respository
{
    public interface IBorrowingRecordsRespository
    {
        List<BorrowingRecord> GetAllBorrowingRecords();
        BorrowingRecord GetBorrowingRecordsById(int id);
        void AddBorrowingRecords(BorrowingRecord borrowing);
        void UpdateBorrowingRecords(BorrowingRecord borrowing);
    }
}
