using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IClientesAD
    {
        List<PA_recClientes_Result> recClientes();
        PA_recClienteXId_Result recClienteXId(int pID);
        bool insCliente(Cliente pobjCliente);
        bool modCliente(Cliente pobjCliente);
        bool delCliente(int pID);
    }
}
