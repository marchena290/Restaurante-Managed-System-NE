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
    public class MenuLN: IMenuLN
    {
        //Crear una instancia global del contexto de Entity Framework
        public static RDEntities _gobjContextoRD = new RDEntities();

        //para manejar las operaciones con la base de datos dentro de esta clase
        private readonly IMenuAD objMenuAD = new MenuAD(_gobjContextoRD);

        // Método para recuperar todos los menus
        public List<PA_recMenu_Result> recMenu()
        {
            List<PA_recMenu_Result> objRespuesta = new List<PA_recMenu_Result>();
            try
            {
                objRespuesta = objMenuAD.recMenu();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        // Método para recuperar menus por ID
        public PA_recMenuXId_Result recMenuXId(int pID)
        {
            PA_recMenuXId_Result objRespuesta = new PA_recMenuXId_Result();
            try
            {
                objRespuesta = objMenuAD.recMenuXId(pID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        // Método para insertar un menu
        public bool insMenu(Menu pobjMenu)
        {
            bool objRespuesta = false;
            try
            {
                objRespuesta = objMenuAD.insMenu(pobjMenu);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar menu en lógica de negocio", ex);
            }
            return objRespuesta;
        }

        // Método para modificar un menu
        public bool modMenu(Menu pobjMenu)
        {
            bool objRespuesta = false;
            try
            {
                objRespuesta = objMenuAD.modMenu(pobjMenu);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar menu en lógica de negocio", ex);
            }
            return objRespuesta;
        }

        // Método para eliminar un menu
        public bool delMenu(int pID)
        {
            bool objRespuesta = false;
            try
            {
                objRespuesta = objMenuAD.delMenu(pID);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar menu en lógica de negocio", ex);
            }
            return objRespuesta;
        }
    }
}
