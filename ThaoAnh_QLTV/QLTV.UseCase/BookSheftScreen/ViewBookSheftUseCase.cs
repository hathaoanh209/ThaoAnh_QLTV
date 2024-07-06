using QLTV.CoreBusiness.Models;
using QLTV.UseCase.BookSheftScreen.interfaces;
using QLTV.UseCase.PlugginInterfaces.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.UseCases.ShoppingCartScreen
{
    public class ViewBookSheftUseCase : IViewBookSheftUseCase
    {
        private readonly IBookSheft  bookSheft;

        public ViewBookSheftUseCase(IBookSheft bookSheft)
        {
            this.bookSheft = bookSheft;
        }
        public Task<BorrowingBookDetail> Execute()
        {
            return bookSheft.GetOrderAsync();
        }
    }
}
