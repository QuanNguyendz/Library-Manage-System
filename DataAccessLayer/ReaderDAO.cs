using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using BussinessLayer.Models;
namespace DataAccessLayer
{
    public class ReaderDAO
    {
        private readonly LibraryManagementContext _context;
        public ReaderDAO()
        {
            _context = new LibraryManagementContext();
        }
        public List<Reader> GetAllReader()
        {
            return _context.Readers.ToList();
        }

        public Reader GetReaderById(int id)
        {
            return _context.Readers.FirstOrDefault(r => r.ReaderId == id);
        }

        public void AddReader(Reader reader)
        {
            _context.Readers.Add(reader);
            _context.SaveChanges();
        }

        public void UpdateReader(Reader reader)
        {
            _context.Readers.Update(reader);
            _context.SaveChanges();
        }

        public void DeleteReader(int id)
        {
            var reader = GetReaderById(id);
            if (reader != null)
            {
                _context.Readers.Remove(reader);
                _context.SaveChanges();
            }
        }

        public List<Reader> SearchReaders(string name)
        {
            return _context.Readers
                .Where(r => (string.IsNullOrEmpty(name) || r.FullName.Contains(name)))
                .ToList();
        }

    }
}
