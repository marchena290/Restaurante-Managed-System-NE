using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IMenuAD
    {
        List<PA_recMenu_Result> recMenu();
        PA_recMenuXId_Result recMenuXId(int pID);
        bool insMenu(Menu pobjMenu);
        bool modMenu(Menu pobjMenu);
        bool delMenu(int pID);
    }
}
