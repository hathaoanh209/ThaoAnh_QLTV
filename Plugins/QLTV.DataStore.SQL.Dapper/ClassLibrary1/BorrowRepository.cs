using QLTV.CoreBusiness.Models;
using QLTV.UseCase.PlugginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DataStore.SQL.Dapper
{
	public class BorrowRepository : IBorrowrepository
	{
		public int CreateBorrow(BorrowingBookDetail borrowingBookDetail)
		{
			throw new NotImplementedException();
		}

		public BorrowingBookDetail GetBorrow(int id)
		{
			throw new NotImplementedException();
		}

		public BorrowingBookDetail GetBorrowByUniqueId(string uniqueId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<BorrowingBookDetail> GetBorrows()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<LineItem> GetLineItemsByBorrowId(int loanId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<BorrowingBookDetail> GetOutstandingBorrows()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<BorrowingBookDetail> GetProcessedBorrows()
		{
			throw new NotImplementedException();
		}

		public void UpdateBorrow(BorrowingBookDetail borrowingBookDetail)
		{
			throw new NotImplementedException();
		}
	}
}
