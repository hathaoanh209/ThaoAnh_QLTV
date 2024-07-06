using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLTV.UseCase.PlugginInterfaces.UI;
using QLTV.UseCase.SreachBookScreen.interfaces;
using QLTV.UseCases.PluginInterfaces.DataStore;
using QLTV.UseCases.PluginInterfaces.StateStore;

namespace QLTV.UseCase.SreachBookScreen
{
    public  class AddBookToSheftUseCase : IAddBookToSheftUseCase
    {
        private readonly IBookRespository bookReponsitory;
        private readonly IBookSheft bookSheft;
        private readonly IBookSheftStateStore bookSheftStateStore;

        public AddBookToSheftUseCase(
            IBookRespository bookReponsitory,
          IBookSheft bookSheft,
            IBookSheftStateStore bookSheftStateStore)
        {
            this.bookReponsitory = bookReponsitory;
            this.bookSheft = bookSheft;
            this.bookSheftStateStore = bookSheftStateStore;
        }
        public async void Execute(int productId)
        {
            var product = bookReponsitory.GetBook(productId);
            await bookSheft.AddBookAsync(product);

            bookSheftStateStore.UpdateLineItemsCount();
        }

    }
}
