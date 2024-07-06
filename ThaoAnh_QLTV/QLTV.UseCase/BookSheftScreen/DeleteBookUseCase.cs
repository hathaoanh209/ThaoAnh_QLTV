using QLTV.UseCases.PluginInterfaces.StateStore;
using QLTV.UseCases.ShoppingCartScreen;
using QLTV.CoreBusiness.Models;
using QLTV.UseCase.PlugginInterfaces.UI;
using QLTV.UseCase.BookSheftScreen.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QLTV.UseCases.BookSheftScreen
{
    public class DeleteBookUseCase : IDeleteBookUseCase
    {
        private readonly IBookSheft bookSheft;
        private readonly IBookSheftStateStore booksheftStateSotre;
        public DeleteBookUseCase(IBookSheft bookSheft, IBookSheftStateStore booksheftStateSotre)
        {
            this.bookSheft = bookSheft;
            this.booksheftStateSotre = booksheftStateSotre;
        }
        public async Task<BorrowingBookDetail> Execute(int productId)
        {
            var order = await this.bookSheft.DeleteBookAsync(productId);
            this.booksheftStateSotre.UpdateLineItemsCount();
            return order;
        }
    }

}
