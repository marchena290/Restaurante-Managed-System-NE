using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementacion
{
    public class ClientesAD: IClientesAD
    {
        // Asignar conexion a la base de datos
        private RDEntities gobjContextoRD;

        // Constructor que recibe la conexion de la base de datos
        public ClientesAD(RDEntities _gobjContextoRD)
        {
            this.gobjContextoRD = _gobjContextoRD;
        }

        // Metodo para recuperar todos los clientes
        public List<PA_recClientes_Result> recClientes()
        {   
            // Creamos una instancia
            List<PA_recClientes_Result> objRespuesta = new List<PA_recClientes_Result>();
            try
            {
                // Ejecuta el procedimiento almacenado y lo convierte en lista
                objRespuesta = gobjContextoRD.PA_recClientes().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        // Metodo para recuperar todos los clientes por Id
        public PA_recClienteXId_Result recClienteXId(int pID)
        {
            PA_recClienteXId_Result objRespuesta = new PA_recClienteXId_Result();
            try
            {
                // Ejecuta el procedimiento almacenado y solo obtiene uno
                objRespuesta = gobjContextoRD.PA_recClienteXId(pID).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        // Método para insertar un nuevo cliente
        public bool insCliente(Cliente pobjCliente)
        {
            bool objRespuesta = false;
            try
            {
                int result = gobjContextoRD.PA_insCliente(pobjCliente.Nombre, pobjCliente.Apellido, pobjCliente.Telefono, pobjCliente.Correo);

                objRespuesta = result == 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar Cliente", ex);
            }
            return objRespuesta;
        }

        // Método para modificar un cliente existente
        public bool modCliente(Cliente pobjCliente)
        {
            bool objRespuesta = false;
            try
            {
                int result = gobjContextoRD.PA_modCliente(pobjCliente.IdCliente, pobjCliente.Nombre, pobjCliente.Apellido, pobjCliente.Telefono, pobjCliente.Correo);

                objRespuesta = result == 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar un Cliente", ex);
            }
            return objRespuesta;
        }

        // Método para eliminar un cliente
        public bool delCliente(int pID)
        {
            bool objRespuesta = false;
            try
            {
                int result = gobjContextoRD.PA_delCliente(pID);

                objRespuesta = result == 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar un Cliente", ex);
            }
            return objRespuesta;
        }
    }
}
