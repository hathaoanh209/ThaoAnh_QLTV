using QLTV.CoreBusiness.Models;

namespace QLTV.UseCase.BookSheftScreen.interfaces
{
    public interface IDeleteBookUseCase
    {
        Task<BorrowingBookDetail> Execute(int BookId);
    }
}