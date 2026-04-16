using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IClientesLN
    {
        List<PA_recClientes_Result> recClientes();
        PA_recClienteXId_Result recClientesXId(int pID);
        bool insCliente(Cliente pobjCliente);
        bool ModCliente(Cliente pobjCliente);
        bool delCliente(int pID);

    }
}
