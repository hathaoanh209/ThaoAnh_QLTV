using QLTV.UseCases.PluginInterfaces.DataStore;
using QLTV.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLTV.UseCase.SreachBookScreen.interfaces;

namespace QLTV.UseCases.SreachBookScreen
{

    public class SreachBookUseCase : ISreachBookUseCase
	{
		public  readonly IBookRespository bookRepository;
        public SreachBookUseCase(IBookRespository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public IEnumerable<BOOK> Execute(string id)
        {
            return bookRepository.GetBooks(id);
        }
        
    }
}
