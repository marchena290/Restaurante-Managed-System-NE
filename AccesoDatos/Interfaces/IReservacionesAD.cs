using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IReservacionesAD
    {
        List<PA_recReservaciones_Result> recReservaciones();
        PA_recReservacionXId_Result recReservacionXId(int pID);
        bool insReservacion(Reservacione pobjReservacion);
        bool modReservacion(Reservacione pobjReservacion);
        bool delReservacion(int pID);
    }
}
