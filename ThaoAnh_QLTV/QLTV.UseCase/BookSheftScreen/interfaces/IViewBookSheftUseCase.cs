using QLTV.CoreBusiness.Models;

namespace QLTV.UseCase.BookSheftScreen.interfaces
{
    public interface IViewBookSheftUseCase
    {
        Task<BorrowingBookDetail> Execute();
    }
}