using QLTV.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QLTV.UseCase.SreachBookScreen.interfaces
{
    public interface IViewBookUseCase
    {
        BOOK Execute(int id);
    }
}
