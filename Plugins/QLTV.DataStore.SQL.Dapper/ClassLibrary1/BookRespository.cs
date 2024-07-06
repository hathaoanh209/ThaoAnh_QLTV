using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLTV.CoreBusiness.Models;
using QLTV.DataStore.SQL.Dapper.Helpers;
using QLTV.UseCases.PluginInterfaces.DataStore;
using Dapper;

namespace QLTV.DataStore.SQL.Dapper
{
    public class BookRespository : IBookRespository
    {
        private readonly IDataAccess dataAccess;

        public BookRespository(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        BOOK IBookRespository.GetBook(int id)
        {

      return  dataAccess.QuerySingle<BOOK, dynamic>("Select * from BOOK  where BookId = @BookId",
                new { BookId = id });
        }

        IEnumerable<BOOK> IBookRespository.GetBooks(string filter)
        {
            List<BOOK> list;
            if (string.IsNullOrWhiteSpace(filter))
                list = dataAccess.Query<BOOK, dynamic>("Select * from BOOK", new { });
            else
                list = dataAccess.Query<BOOK, dynamic>("Select * from BOOK where Name like '%' + @Filter + '%'", new { Filter = filter });
            return list.AsEnumerable();
        }
    }
}
