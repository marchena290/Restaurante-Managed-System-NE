using AccesoDatos;
using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion
{
    public class ClientesLN: IClientesLN
    {
        //Crear una instancia global del contexto de Entity Framework
        public static RDEntities _gobjContextoRD = new RDEntities();

        //Se crear una instacia de ClientesAD desde interfaz
        private readonly IClientesAD objClientesAD = new ClientesAD(_gobjContextoRD);
        
        // Método para recuperar todos los clientes
        public List<PA_recClientes_Result> recClientes()
        {
            List<PA_recClientes_Result> objRespuesta = new List<PA_recClientes_Result>();
            try
            {
                objRespuesta = objClientesAD.recClientes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        // Método para recuperar todos los clientes por Id
        public PA_recClienteXId_Result recClientesXId(int pID)
        {

            try
            {
                var resultado = objClientesAD.recClienteXId(pID);

                // Si el resultado es nulo, evitamos que rompa el Controller
                if(resultado == null)
                {
                    return new PA_recClienteXId_Result();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo recuperar la información del cliente. Verifique la conexión con el servidor.", ex);
            }
        }

        // Método para insertar un cliente
        public bool insCliente(Cliente pobjCliente)
        {
            bool objRespuesta = false;
            try
            {
                objRespuesta = objClientesAD.insCliente(pobjCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar cliente en lógica de negocio", ex);
            }
            return objRespuesta;
        }

        // Método para modificar un cliente
        public bool ModCliente(Cliente pobjCliente)
        {
            bool objRespuesta = false;
            try
            {
                objRespuesta = objClientesAD.modCliente(pobjCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar cliente en lógica de negocio", ex);
            }
            return objRespuesta;
        }

        // Método para eliminar un cliente
        public bool delCliente(int pID)
        {
           
            try
            {
                return objClientesAD.delCliente(pID);
            }
            catch (Exception ex)
            {
                // Revisamos si el error viene de la base de datos por una llave foránea
                if (ex.ToString().Contains("FK_Reservacion_Cliente") || ex.InnerException?.ToString().Contains("REFERENCE constraint") == true)
                {
                   throw new Exception("No se puede eliminar el cliente porque tiene reservaciones activas en el sistema.");
                }

                throw new Exception("Error técnico al eliminar: " + ex.Message);
            }
        }
    }
}
