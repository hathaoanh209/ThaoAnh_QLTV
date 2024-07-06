using QLTV.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.UseCase.PlugginInterfaces.UI
{
	public interface IBookSheft
	{
		Task<BorrowingBookDetail> GetOrderAsync();
		Task<BorrowingBookDetail> AddBookAsync(BOOK book);
		Task<BorrowingBookDetail> UpdateQuantityAsync(int BookId, int quantity);
		Task<BorrowingBookDetail> UpdateOrderAsync(BorrowingBookDetail borrowingBookDetail);
		Task<BorrowingBookDetail> DeleteBookAsync(int BookId);
		Task<BorrowingBookDetail> PlaceOrderAsync();
		Task EmptyAsync();
		
	}
}
