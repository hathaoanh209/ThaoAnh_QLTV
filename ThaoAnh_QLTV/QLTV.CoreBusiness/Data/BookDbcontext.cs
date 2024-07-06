using Microsoft.EntityFrameworkCore;
using QLTV.CoreBusiness.Models;

namespace QLTV.CoreBusiness.Data
{
    public class BookDbContext : DbContext
    {
            public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
            {
            }

            public DbSet<BOOK> BOOK { get; set; } = null!;
            public DbSet<Customer> Customer { get; set; } = null!;
            public DbSet<BorrowingRecords> BorrowingRecords { get; set; } = null!;

            // Các cấu hình khác
        }

    }


