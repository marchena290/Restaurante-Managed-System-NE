using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementacion
{
    public class MenuAD: IMenuAD
    {
        // Asignar conexion a la base de datos atravez variable global
        private RDEntities gobjContextoRD;

        // Constructor que recibe la conexion de la base de datos
        public MenuAD(RDEntities _gobjContextoRD)
        {
            this.gobjContextoRD = _gobjContextoRD;
        }

        // Metodo para recuperar todos los menu
        public List<PA_recMenu_Result> recMenu()
        {
            // Creamos una instancia
            List<PA_recMenu_Result> lboRespuesta = new List<PA_recMenu_Result>();
            try
            {
                // Ejecuta el procedimiento almacenado y lo convierte en lista
                lboRespuesta = gobjContextoRD.PA_recMenu().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lboRespuesta;
        }

        // Metodo para recuperar todos los menu por Id
        public PA_recMenuXId_Result recMenuXId(int pID)
        {
            PA_recMenuXId_Result objRepuesta = new PA_recMenuXId_Result(); 
            try
            {
                // Ejecuta el procedimiento almacenado y solo obtiene uno
                objRepuesta = gobjContextoRD.PA_recMenuXId(pID).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRepuesta; 
        }

        // Método para insertar un nuevo menu
        public bool insMenu(Menu pobjMenu)
        {
            bool objRespuesta = false;
            try
            {
                int result = gobjContextoRD.PA_insMenu(pobjMenu.Descripcion, pobjMenu.Precio);

                objRespuesta = result == 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el Menu", ex);
            }
            return objRespuesta;
        }

        // Método para modificar un menu existente
        public bool modMenu(Menu pobjMenu)
        {
            bool objRespuesta = false;
            try
            {
                int result = gobjContextoRD.PA_modMenu(pobjMenu.IdMenu, pobjMenu.Descripcion, pobjMenu.Precio);

                objRespuesta = result == 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el Menu", ex);
            }
            return objRespuesta;
        }

        // Método para eliminar un menu
        public bool delMenu(int pID)
        {
            bool objRespuesta = false;
            try
            {
                int result = gobjContextoRD.PA_delMenu(pID);

                objRespuesta = result == 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el Menu", ex);
            }
            return objRespuesta;
        }
    }
}
