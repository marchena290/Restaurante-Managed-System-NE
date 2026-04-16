using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementacion
{
    public class ReservacionesAD: IReservacionesAD
    {
        private RDEntities gobjContextoRD;

        public ReservacionesAD(RDEntities _gobjContextoRD)
        {
            this.gobjContextoRD = _gobjContextoRD;
        }

        public List<PA_recReservaciones_Result> recReservaciones()
        {
            List<PA_recReservaciones_Result> objRespuesta = new List<PA_recReservaciones_Result>();
            try
            {
                objRespuesta = gobjContextoRD.PA_recReservaciones().ToList();
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
                objRespuesta = gobjContextoRD.PA_recReservacionXId(pID).Single();
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
                int result = gobjContextoRD.PA_insReservacion(pobjReservacion.IdCliente, pobjReservacion.IdMesa, pobjReservacion.IdMenu, pobjReservacion.Cantidad, pobjReservacion.FechaReservacion);

                objRespuesta = result == 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la reservación", ex);
            }
            return objRespuesta;
        }

        public bool modReservacion(Reservacione pobjReservacion)
        {
            bool objRespuesta = false;
            try
            {
                int result = gobjContextoRD.PA_modReservacion(pobjReservacion.IdReservaciones, pobjReservacion.IdCliente, pobjReservacion.IdMesa, pobjReservacion.IdMenu, pobjReservacion.Cantidad, pobjReservacion.FechaReservacion);

                objRespuesta = result == 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modifcar la reservación", ex);
            }
            return objRespuesta;
        }

        public bool delReservacion(int pID)
        {
            bool objRespuesta = false;
            try
            {
                int result = gobjContextoRD.PA_delReservacion(pID);

                objRespuesta = result == 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la reservación", ex);
            }
            return objRespuesta;
        }

    }
}
