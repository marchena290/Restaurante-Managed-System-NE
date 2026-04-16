using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementacion
{
    public class MesasAD: IMesasAD
    {
        private RDEntities gobjContextoRD;

        public MesasAD(RDEntities _gobjContextoRD)
        {
            this.gobjContextoRD = _gobjContextoRD;
        }

        public List<PA_recMesas_Result> recMesas()
        {
            List<PA_recMesas_Result> objRespuesta = new List<PA_recMesas_Result>();
            try
            {
                objRespuesta = gobjContextoRD.PA_recMesas().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        public PA_recMesaXId_Result recMesaXId(int pId)
        {
            PA_recMesaXId_Result objRespuesta = new PA_recMesaXId_Result();
            try
            {
                objRespuesta = gobjContextoRD.PA_recMesaXId(pId).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        public bool insMesa(Mesa pobjMesa)
        {
            bool objRespuesta = false;
            try
            {
                int result = gobjContextoRD.PA_insMesa(pobjMesa.NumeroMesa, pobjMesa.Capacidad, pobjMesa.Estado);

                objRespuesta = result == 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar Mesa", ex);
            }
            return objRespuesta;
        }

        public bool modMesa(Mesa pobjMesa)
        {
            bool objRespuesta = false;
            try
            {
                int result = gobjContextoRD.PA_modMesa(pobjMesa.IdMesa, pobjMesa.NumeroMesa, pobjMesa.Capacidad, pobjMesa.Estado);

                objRespuesta = result == 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modifcar Mesa", ex);
            }
            return objRespuesta;
        }

        public bool delMesa(int pID)
        {
            bool objRespuesta = false;
            try
            {
                int result = gobjContextoRD.PA_delMesa(pID);

                objRespuesta = result == 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar Mesa", ex);
            }
            return objRespuesta;
        }
    }
}
