using QLTV.UseCase.PlugginInterfaces.UI;
using QLTV.UseCases.PluginInterfaces.StateStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.StateStore.DI
{
	public  class BookSheftStateStore : StateStoreBase, IBookSheftStateStore
	{
		private readonly IBookSheft bookSheft;
		public BookSheftStateStore(IBookSheft bookSheft)
		{
			this.bookSheft = bookSheft;
		}

		public async Task<int> GetItemsCount()
		{
			var borrow = await bookSheft.GetOrderAsync();
			if (borrow != null && borrow.LineItems != null & borrow.LineItems.Count > 0)

				return borrow.LineItems.Count;

			return 0;
		}

		public void UpdateBookQuantity()
		{
			base.BroadCastStateChange();
		}

		public void UpdateLineItemsCount()
		{
			base.BroadCastStateChange();
		}
	}
}
