
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.UseCases.PluginInterfaces.StateStore
{
	public  interface IBookSheftStateStore : IStateStore
	{
		Task<int> GetItemsCount();
		void UpdateLineItemsCount();
		void UpdateBookQuantity();
	}
}
