using QLTV.CoreBusiness.Models;
using QLTV.CoreBusiness.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.CoreBusiness.Services
{
    public  class BorrowService: IBorrowService 
	{
		public bool ValidateCustomerInformation(string name, string address, string city, string country)
		{
			if (string.IsNullOrWhiteSpace(name) ||
				string.IsNullOrWhiteSpace(address) ||
				string.IsNullOrWhiteSpace(city) ||
				string.IsNullOrWhiteSpace(country))
				return false;
			return true;
		}
		public bool ValidateCreateOrder(BorrowingBookDetail borrowingBookDetail)
		{
			//Phải tồn tại 1 order
			if (borrowingBookDetail == null) return false;

			if (borrowingBookDetail.LineItems == null || borrowingBookDetail.LineItems.Count <= 0) return false;
			foreach (var item in borrowingBookDetail.LineItems)
			{
				if (item.BookId <= 0 ||
					
					item.Quantity <= 0) return false;
			}

			//validate customer info 
			if (!ValidateCustomerInformation(borrowingBookDetail.CustomerName,
				borrowingBookDetail.CustomerAddress,
				borrowingBookDetail.CustomerCity,
				borrowingBookDetail	.CustomerCountry)) return false;
			return true;
		}

		public bool ValidateUpdateOrder(BorrowingBookDetail borrowingBookDetail)
		{
			if (borrowingBookDetail == null) return false;
			if (!borrowingBookDetail.LoanId.HasValue) return false;

			//order has to have order line items 
			if (borrowingBookDetail.LineItems == null || borrowingBookDetail.LineItems.Count <= 0) return false;

			//Placed Date has to be populated 
			if (!borrowingBookDetail.BorrowDate.HasValue) return false;

			//other date 
			if (borrowingBookDetail.DateProcessed.HasValue || borrowingBookDetail.DateProcessed.HasValue) return false;

			//valiate uniqueId
			if (string.IsNullOrEmpty(borrowingBookDetail.UniqueId)) return false;

			//validating line items 
			foreach (var item in borrowingBookDetail.LineItems)
			{
				if (item.BookId <= 0 ||
					
					item.Quantity <= 0 ||
					item.LoanId == borrowingBookDetail.LoanId) return false;
			}


			//validate customer info 
			if (!ValidateCustomerInformation(borrowingBookDetail.CustomerName,
				borrowingBookDetail.CustomerAddress,
				borrowingBookDetail.CustomerCity,
			
				borrowingBookDetail.CustomerCountry)) return false;

			return false;
		}
		public bool ValidateProcessOrder(BorrowingBookDetail borrowingBookDetail)
		{
			if (!borrowingBookDetail.DateProcessed.HasValue ||
				string.IsNullOrWhiteSpace(borrowingBookDetail.AdminUser)) return false;
			return true;
		}
	}
}
