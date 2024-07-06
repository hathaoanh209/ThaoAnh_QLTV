using QLTV.CoreBusiness.Models;

namespace QLTV.UseCase.BookSheftScreen.interfaces
{
    public interface IPlaceBorrowUseCase
    {
		Task<string> Execute(BorrowingBookDetail borrowingBookDetail);
	}
}