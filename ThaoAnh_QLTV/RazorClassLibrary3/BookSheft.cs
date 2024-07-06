using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using QLTV.CoreBusiness.Models;
using QLTV.UseCase.PlugginInterfaces.UI;
using QLTV.UseCases.PluginInterfaces.DataStore;

namespace QLTV.BookSheft.LocalStorage
{
	public class BookSheft : IBookSheft
	{
		private readonly IJSRuntime jSRuntime;
		private readonly IBookRespository bookRespository;
		private const string cstrBookSheft = "QLTV.BookSheft";

		public BookSheft(IJSRuntime jSRuntime, IBookRespository bookRespository)
		{
			this.jSRuntime = jSRuntime;
			this.bookRespository = bookRespository;
		}

		public async Task<BorrowingBookDetail> AddBookAsync(BOOK book)
		{
			var borrowBookDetail = await GetOrder();
			borrowBookDetail.AddBook(book.BookId, 1, book.Author);
			await SetBorrow(borrowBookDetail);
			return borrowBookDetail;
		}

		public async Task<BorrowingBookDetail> DeleteBookAsync(int BookId)
		{
			var borrow = await GetOrder();
			borrow.RemoveBook(BookId);
			await SetBorrow(borrow);
			return borrow;
		}

		
	
		public Task<BorrowingBookDetail> PlaceOrderAsync()
		{
			throw new NotImplementedException();
		}

		public Task EmptyAsync()
		{
			return this.SetBorrow(null);
		}

		public async Task<BorrowingBookDetail> UpdateOrderAsync(BorrowingBookDetail borrowingBookDetail)
		{
			await this.SetBorrow(borrowingBookDetail);
			return borrowingBookDetail;
		}

		public async Task<BorrowingBookDetail> UpdateQuantityAsync(int BookId, int quantity)
		{
			var borrow = await GetOrder();
			if (quantity < 0)
				return borrow;
			else if (quantity == 0)
			{
				return await DeleteBookAsync(BookId);
			}

			var lineItem = borrow.LineItems.SingleOrDefault(x => x.BookId == BookId);
			if (lineItem != null)
				lineItem.Quantity = quantity;

			await SetBorrow(borrow);
			return borrow;
		}

		private async Task<BorrowingBookDetail> GetOrder()
		{
			BorrowingBookDetail borrowingBookDetail = null;
			var strOrder = await jSRuntime.InvokeAsync<string>("localStorage.getItem", cstrBookSheft);
			if (!string.IsNullOrEmpty(strOrder) && strOrder.ToLower() != "null")
				borrowingBookDetail = JsonConvert.DeserializeObject<BorrowingBookDetail>(strOrder);
			else
			{
				borrowingBookDetail = new BorrowingBookDetail();
				await SetBorrow(borrowingBookDetail);
			}

			foreach (var item in borrowingBookDetail.LineItems)
			{
				item.BOOK = bookRespository.GetBook(item.BookId);
			}

			return borrowingBookDetail;
		}

		private async Task SetBorrow(BorrowingBookDetail borrowingBookDetail)
		{
			await jSRuntime.InvokeVoidAsync("localStorage.setItem", cstrBookSheft, JsonConvert.SerializeObject(borrowingBookDetail));
		}

		public async  Task<BorrowingBookDetail> GetOrderAsync()
		{
			return await GetOrder();
		}
		
	}
}
