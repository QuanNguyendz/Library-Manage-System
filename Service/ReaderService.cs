using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Models;
using Respository;

namespace Service
{
    public class ReaderService : IReaderService
    {
        private readonly IReaderRespository _readerRespository;

        public ReaderService(IReaderRespository readerRespository)
        {
            _readerRespository = readerRespository;
        }

        public List<Reader> GetAllReader() => _readerRespository.GetAllReader();
        public Reader GetReaderById(int id) => _readerRespository.GetReaderById(id);
        public void AddReader(Reader reader) => _readerRespository.AddReader(reader);
        public void UpdateReader(Reader reader) => _readerRespository.UpdateReader(reader);
        public void DeleteReader(int id) => _readerRespository.DeleteReader(id);
        public List<Reader> SearchReader(string name) => _readerRespository.SearchReader(name);
    }
}
