using System.Collections.Generic;
using System.Threading.Tasks;
using QLTV.CoreBusiness.Models;

namespace QLTV.UseCases.PluginInterfaces.DataStore
{
    public interface IBookRespository
    {
        IEnumerable<BOOK> GetBooks(string filter = null);
        BOOK GetBook(int id);
    }
}
