using QLTV.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLTV.CoreBusiness.Services.interfaces
{
    public interface IUserService
    {
        // Book functions
        Task<List<BOOK>> GetBookListAsync(int? id);
        Task AddNewBookAsync(BOOK book);
        Task<BOOK> GetBookByIdAsync(int id);
        Task UpdateNewBookAsync(BOOK book, int id);
        Task DeleteNewBookAsync(int id);
        Task<List<BOOK>> GetBookListAvailableAsync();

        // User functions
        Task<List<Customer>> GetUserListAsync();
        Task AddNewUserAsync(Customer customers);
        Task<Customer> GetUserByIdAsync(int id);
        Task UpdateNewUserAsync(Customer customers, int id);
        Task DeleteNewUserAsync(int id);

        // BorrowingRecords functions
        Task<List<BorrowingRecords>> GetLoanBookListAsync(string CustomerName);
        Task AddBookLoanAsync(BorrowingRecords borrowingRecord, string CustomerName, int BookId);
        Task UpdateReturnedDateAsync(BorrowingRecords book, int id);
        // Thêm phương thức CheckoutBookAsync
        Task CheckoutBookAsync(int bookId);

        Task<BorrowingRecords> GetBorrowingRecordByIdAsync(int id);

        Task<List<BorrowingRecords>> GetBorrowingRecordsForCustomerAsync(int customerId);
        Task<List<BorrowingRecords>> GetAllBorrowingRecordsAsync();
    }
}
