using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.CoreBusiness.Models
{
	public  class BorrowingBookDetail
	{
		public BorrowingBookDetail()
		{
			//code
			LineItems = new List<LineItem>();
		}
		public int? LoanId  { get; set; }
		public DateTime? BorrowDate  { get; set; }
		public DateTime? DueDate  { get; set; }
		public DateTime? DateProcessed  { get; set; }
		public string CustomerName { get; set; }
		public string CustomerAddress { get; set; }
		public string CustomerCity { get; set; }
		public string CustomerCountry { get; set; }
		public string AdminUser { get; set; }
		public List<LineItem> LineItems { get; set; }
		public string UniqueId { get; set; }


		public void AddBook(int bookId, int qty, string? author)
		{
			var item = LineItems.FirstOrDefault(x => x.BookId == bookId);
			if (item != null)
				item.Quantity += qty;
			else
				LineItems.Add(new LineItem 
				{
					BookId = bookId,
					Quantity = qty,
				
					LoanId = LoanId
				});
		}

		public void RemoveBook(int bookId)
		{
			var item = LineItems.FirstOrDefault(x => x.BookId == bookId);
			if (item != null)
				LineItems.Remove(item);
		}

	}
}
