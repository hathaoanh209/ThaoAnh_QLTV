using QLTV.CoreBusiness.Models;

namespace QLTV.UseCase.BookSheftScreen.interfaces
{
    public interface IUpdateQuantityUseCase
    {
        Task<BorrowingBookDetail> Execute(int bookId, int quantity);
    }
}