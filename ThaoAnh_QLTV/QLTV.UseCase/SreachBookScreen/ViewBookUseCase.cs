using System.Threading.Tasks;
using QLTV.CoreBusiness.Models;
using QLTV.UseCase.SreachBookScreen.interfaces;
using QLTV.UseCases.PluginInterfaces.DataStore;

namespace QLTV.UseCases
{
    public class ViewBookUseCase : IViewBookUseCase
    {
        private readonly IBookRespository bookRepository;

        public ViewBookUseCase(IBookRespository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public BOOK Execute(int id)
        {
            return bookRepository.GetBook(id);
        }
    }
}
