using QLTV.CoreBusiness.Models;

namespace QLTV.CoreBusiness.Services.interfaces
{
    public interface IBorrowService
    {
        bool ValidateCreateOrder(BorrowingBookDetail borrowingBookDetail);
        bool ValidateCustomerInformation(string name, string address, string city, string country);
        bool ValidateProcessOrder(BorrowingBookDetail borrowingBookDetail);
        bool ValidateUpdateOrder(BorrowingBookDetail borrowingBookDetail);
    }
}
