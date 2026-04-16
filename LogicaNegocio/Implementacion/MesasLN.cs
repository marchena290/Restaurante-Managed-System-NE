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
    public class MesasLN: IMesasLN
    {
        //Crear una instancia global del contexto de Entity Framework
        public static RDEntities _gobjContextoRD = new RDEntities();

        //para manejar las operaciones con la base de datos dentro de esta clase
        private readonly IMesasAD objMesasAD = new MesasAD(_gobjContextoRD);

        // Método para recuperar todas las Mesas
        public List<PA_recMesas_Result> recMesas()
        {
            List<PA_recMesas_Result> objRespuesta = new List<PA_recMesas_Result>();
            try
            {
                objRespuesta = objMesasAD.recMesas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        // Método para recuperar todas las Mesas por ID
        public PA_recMesaXId_Result recMesaXId(int pID)
        {
            PA_recMesaXId_Result objRespuesta = new PA_recMesaXId_Result();
            try
            {
                objRespuesta = objMesasAD.recMesaXId(pID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        // Método para insertar una mesa
        public bool insMesa(Mesa pobjMesa)
        {
            bool objRespuesta = false;
            try
            {
                objRespuesta = objMesasAD.insMesa(pobjMesa);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la mesa en lógica de negocio", ex);
            }
            return objRespuesta;
        }

        // Método para modificar una mesa
        public bool modMesa(Mesa pobjMesa)
        {
            bool objRespuesta = false;
            try
            {
                objRespuesta = objMesasAD.modMesa(pobjMesa);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modifcar la mesa en lógica de negocio", ex);
            }
            return objRespuesta;
        }

        // Método para eliminar una mesa
        public bool delMesa(int pID)
        {
            bool objRespuesta = false;
            try
            {
                objRespuesta = objMesasAD.delMesa(pID);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la mesa en lógica de negocio", ex);
            }
            return objRespuesta;
        }
    }
}
