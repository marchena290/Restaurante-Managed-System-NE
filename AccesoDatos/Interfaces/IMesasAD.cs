using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IMesasAD
    {
        List<PA_recMesas_Result> recMesas();
        PA_recMesaXId_Result recMesaXId(int pId);
        bool insMesa(Mesa pobjMesa);
        bool modMesa(Mesa pobjMesa);
        bool delMesa(int pID);
    }
}
