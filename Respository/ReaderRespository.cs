using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Models;
using DataAccessLayer;

namespace Respository
{
    public class ReaderRespository : IReaderRespository
    {
        private readonly ReaderDAO _readerDAO;

        public ReaderRespository()
        {
            _readerDAO = new ReaderDAO();
        }

        public List<Reader> GetAllReader() => _readerDAO.GetAllReader();
        public Reader GetReaderById(int id) => _readerDAO.GetReaderById(id);
        public void AddReader(Reader reader) => _readerDAO.AddReader(reader);
        public void UpdateReader(Reader reader) => _readerDAO.UpdateReader(reader);
        public void DeleteReader(int id) => _readerDAO.DeleteReader(id);
        public List<Reader> SearchReader(string name) => _readerDAO.SearchReaders(name);

    }
}
