using QLTV.CoreBusiness.Data;
using QLTV.CoreBusiness.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLTV.CoreBusiness.Services.interfaces;

namespace QLTV.CoreBusiness.Services
{
    public class UserService : IUserService
    {
        private readonly BookDbContext _dbContext;

        public UserService(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    
        public async Task<List<BOOK>> GetBookListAsync(int? id)
        {
            var query = _dbContext.BOOK.AsQueryable();

            if (id != null && id != 0)
            {
                query = query.Where(book => book.BookId == id);
            }

            return await query.OrderByDescending(book => book.BookId).ToListAsync();
        }

        public async Task AddNewBookAsync(BOOK book)
        {
            _dbContext.BOOK.Add(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateNewBookAsync(BOOK book, int id)
        {
            var resultUpdate = await _dbContext.BOOK.FindAsync(id);

            if (resultUpdate != null)
            {
                resultUpdate.Name = book.Name;
                resultUpdate.Author = book.Author;
                resultUpdate.TypeOfBook = book.TypeOfBook;
                resultUpdate.Description = book.Description;
                resultUpdate.ImageLink = book.ImageLink;
                resultUpdate.Available = book.Available;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteNewBookAsync(int id)
        {
            var result = await _dbContext.BOOK.FindAsync(id);

            if (result != null)
            {
                _dbContext.BOOK.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<BOOK> GetBookByIdAsync(int id)
        {
            return await _dbContext.BOOK.FindAsync(id);
        }

        public async Task<List<Customer>> GetUserListAsync()
        {
            return await _dbContext.Customer.OrderByDescending(customers => customers.CustomerId).ToListAsync();
        }

        public async Task AddNewUserAsync(Customer customers)
        {
            var existingUser = await _dbContext.Customer.FirstOrDefaultAsync(u => u.CustomerName == customers.CustomerName);

            if (existingUser == null)
            {
                _dbContext.Customer.Add(customers);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateNewUserAsync(Customer customers, int id)
        {
            var resultUpdate = await _dbContext.Customer.FindAsync(id);

            if (resultUpdate != null)
            {
                // Update properties of the customer object
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Customer> GetUserByIdAsync(int id)
        {
            return await _dbContext.Customer.FindAsync(id);
        }

        public async Task<List<BOOK>> GetBookListAvailableAsync()
        {
            return await _dbContext.BOOK
                .Where(book => book.Available)
                .OrderByDescending(book => book.BookId)
                .ToListAsync();
        }

        public async Task AddBookLoanAsync(BorrowingRecords borrowingRecord, string CustomerName, int BookId)
        {
            var getinfoUser = await _dbContext.Customer.FirstOrDefaultAsync(u => u.CustomerName == CustomerName );
            var getinfoBook = await _dbContext.BOOK.FirstOrDefaultAsync(b => b.BookId == BookId);
            // Set BorrowedDate to the current date
            borrowingRecord.BorrowedDate = DateTime.Today;

            var newRecord = new BorrowingRecords
            {
                CustomerId = getinfoUser.CustomerId,
                BookId = getinfoBook.BookId,
                BorrowedDate = borrowingRecord.BorrowedDate,
                ReturnedDate = borrowingRecord.ReturnedDate
             
            };

            _dbContext.BorrowingRecords.Add(newRecord);
            await _dbContext.SaveChangesAsync();
        
        }

        public async Task<List<BorrowingRecords>> GetLoanBookListAsync(string CustomerName)
        {
            IQueryable<BorrowingRecords> query = _dbContext.BorrowingRecords.Include(record => record.BOOK).Include(record => record.Customer);

            if (CustomerName != "admin")
            {
                var getinfoUser = await _dbContext.Customer.FirstOrDefaultAsync(u => u.CustomerName == CustomerName);
                query = query.Where(record => record.CustomerId == getinfoUser.CustomerId);
            }

            return await query.OrderByDescending(record => record.Id).ToListAsync();
        }

        public async Task UpdateReturnedDateAsync(BorrowingRecords book, int id)
        {
            var resultUpdate = await _dbContext.BorrowingRecords.FindAsync(id);

            if (resultUpdate != null)
            {
                resultUpdate.ReturnedDate = book.ReturnedDate;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async  Task DeleteNewUserAsync(int id)
        {
            var user = await _dbContext.Customer.FindAsync(id);

            if (user != null)
            {
                _dbContext.Customer.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task CheckoutBookAsync(int bookId)
        {
            var book = await _dbContext.BorrowingRecords.FindAsync(bookId);
            if (book != null)
            {
                // Thực hiện logic checkout sách ở đây (ví dụ: đánh dấu sách đã mượn)
                book.IsCheckOut = true; // Ví dụ giả sử có trường IsCheckedOut trong BorrowingRecords
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                // Xử lý trường hợp không tìm thấy sách
                throw new InvalidOperationException($"Không tìm thấy sách có ID = {bookId}");
            }
        }

        public async  Task<BorrowingRecords> GetBorrowingRecordByIdAsync(int id)
        {
                return await _dbContext.BorrowingRecords.FindAsync(id);
                // Lưu ý: Đây là ví dụ đơn giản, bạn cần điều chỉnh để phù hợp với thiết kế và cấu trúc của bạn.
            }

        public async Task<List<BorrowingRecords>> GetBorrowingRecordsForCustomerAsync(int customerId)
        {
            return await _dbContext.BorrowingRecords
            .Where(br => br.CustomerId == customerId)
            .ToListAsync();
        }

        public async Task<List<BorrowingRecords>> GetAllBorrowingRecordsAsync()
        {
            return await _dbContext.BorrowingRecords.ToListAsync();
        }
    }
    }

