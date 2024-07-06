using QLTV.UseCase.BookSheftScreen.interfaces;
using QLTV.CoreBusiness.Services;
using QLTV.UseCases.PluginInterfaces.StateStore;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLTV.UseCase.PlugginInterfaces.UI;
using QLTV.CoreBusiness.Models;
using QLTV.UseCase.PlugginInterfaces.DataStore;

namespace QLTV.UseCases.ShoppingCartScreen
{
    public class PlaceBorrowUseCase : IPlaceBorrowUseCase
	{
		private readonly BorrowService borrowService;
		private readonly IBorrowrepository borrowrepository;
		private readonly IBookSheft bookSheft;
		private readonly IBookSheftStateStore booksheftStateStore;

		public PlaceBorrowUseCase(
			BorrowService borrowService,
			IBorrowrepository borrowrepository,
			IBookSheft bookSheft,
			IBookSheftStateStore booksheftStateSotre)
		{
			this.borrowService = borrowService;
			this.borrowrepository = borrowrepository;
			this.bookSheft = bookSheft;
			this.booksheftStateStore = booksheftStateSotre;


		}
		public async Task<string> Execute(BorrowingBookDetail borrowingBookDetail)
		{
			if (borrowService.ValidateCreateOrder(borrowingBookDetail))
			{
				borrowingBookDetail.BorrowDate = DateTime.Now;
				borrowingBookDetail.UniqueId = Guid.NewGuid().ToString();
				borrowrepository.CreateBorrow(borrowingBookDetail);

				await bookSheft.EmptyAsync();
				booksheftStateStore.UpdateLineItemsCount();

				return borrowingBookDetail.UniqueId;
			}
			return null;
		}
	}
}
