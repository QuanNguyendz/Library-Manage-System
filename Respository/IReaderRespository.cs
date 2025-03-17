using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Models;

namespace Respository
{
    public interface IReaderRespository
    {
        List<Reader> GetAllReader();
        Reader GetReaderById(int id);
        void AddReader(Reader reader);
        void UpdateReader(Reader reader);
        void DeleteReader(int id);
        List<Reader> SearchReader(string name);
    }
}
