using QLTV.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.UseCase.SreachBookScreen.interfaces
{
    public interface ISreachBookUseCase
    {
        IEnumerable<BOOK> Execute(string filter = null);


    }
}
