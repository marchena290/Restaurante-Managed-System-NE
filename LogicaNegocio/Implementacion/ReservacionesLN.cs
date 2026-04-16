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
    public class ReservacionesLN: IReservacionesLN
    {
        public static RDEntities _gobjContextoRD = new RDEntities();

        private readonly IReservacionesAD objReservacionesAD = new ReservacionesAD(_gobjContextoRD);

        public List<PA_recReservaciones_Result> recReservaciones()
        {
            List<PA_recReservaciones_Result> objRespuesta = new List<PA_recReservaciones_Result>();
            try
            {
                objRespuesta = objReservacionesAD.recReservaciones();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        public PA_recReservacionXId_Result recReservacionXId(int pID)
        {
            PA_recReservacionXId_Result objRespuesta = new PA_recReservacionXId_Result();
            try
            {
                objRespuesta = objReservacionesAD.recReservacionXId(pID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        public bool insReservacion(Reservacione pobjReservacion)
        {
            bool objRespuesta = false;
            try
            {
                objRespuesta = objReservacionesAD.insReservacion(pobjReservacion);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la reservacion en lógica de negocio", ex);
            }
            return objRespuesta;
        }

        public bool modReservacion(Reservacione pobjReservacion)
        {
            bool objRespuesta = false;
            try
            {
                objRespuesta = objReservacionesAD.modReservacion(pobjReservacion);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modficar la reservacion en lógica de negocio", ex);
            }
            return objRespuesta;
        }

        public bool delReservacion(int pID)
        {
            bool objRespuesta = false;
            try
            {
                objRespuesta = objReservacionesAD.delReservacion(pID);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la reservacion en lógica de negocio", ex);
            }
            return objRespuesta;
        }
    }
}
