using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IMesasLN
    {
        List<PA_recMesas_Result> recMesas();
        PA_recMesaXId_Result recMesaXId(int pID);
        bool insMesa(Mesa pobjMesa);
        bool modMesa(Mesa pobjMesa);
        bool delMesa(int pID);
    }
}
