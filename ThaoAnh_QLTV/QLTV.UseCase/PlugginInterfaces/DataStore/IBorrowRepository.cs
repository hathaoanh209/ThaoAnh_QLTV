using QLTV.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.UseCase.PlugginInterfaces.DataStore
{
	public  interface IBorrowrepository
	{
		BorrowingBookDetail GetBorrow(int id);
		BorrowingBookDetail GetBorrowByUniqueId(string uniqueId);
		int CreateBorrow(BorrowingBookDetail borrowingBookDetail);
		void UpdateBorrow(BorrowingBookDetail borrowingBookDetail);
		IEnumerable<BorrowingBookDetail> GetBorrows();
		IEnumerable<BorrowingBookDetail> GetOutstandingBorrows();
		IEnumerable<BorrowingBookDetail> GetProcessedBorrows();
		IEnumerable<LineItem> GetLineItemsByBorrowId(int loanId);
	}
}
