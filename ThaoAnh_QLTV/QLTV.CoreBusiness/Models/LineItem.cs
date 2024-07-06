using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.CoreBusiness.Models
{
	public  class LineItem
	{
		public int? LineItemId { get; set; }
		public int BookId {  get; set; }
		public int Quantity {  get; set; }
		public int? LoanId { get; set; }
		public BOOK BOOK { get; set; }

	}
}
