using QLTV.CoreBusiness.Models;
using QLTV.UseCase.BookSheftScreen.interfaces;
using QLTV.UseCase.PlugginInterfaces.UI;
using QLTV.UseCases.PluginInterfaces.StateStore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.UseCases.BookSheftScreen
{
    public class UpdateQuantityUseCase : IUpdateQuantityUseCase
    {
        private readonly IBookSheft bookSheft;
        private readonly IBookSheftStateStore booksheftStateSotre;
        public UpdateQuantityUseCase(IBookSheft bookSheft,
            IBookSheftStateStore booksheftStateSotre)
        {
            this.bookSheft = bookSheft;
            this.booksheftStateSotre = booksheftStateSotre;
        }
        public async Task<BorrowingBookDetail> Execute(int bookId, int quantity)
        {
            var order = await bookSheft.UpdateQuantityAsync(bookId, quantity);
			booksheftStateSotre.UpdateBookQuantity();
            return order;
        }
    }
}
