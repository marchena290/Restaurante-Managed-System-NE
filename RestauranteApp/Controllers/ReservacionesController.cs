using Entidades;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using RestauranteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestauranteApp.Controllers
{
    public class ReservacionesController : Controller
    {
        private IReservacionesLN objReservacionesAD = new ReservacionesLN();
        private IClientesLN objClientesAD = new ClientesLN();
        private IMesasLN objMesasAD = new MesasLN();
        private IMenuLN objMenuAD = new MenuLN();

        // Vistas 

        public ActionResult ListaReservaciones()
        {
            List<PA_recReservaciones_Result> lstReservaciones = new List<PA_recReservaciones_Result>();
            List<M_Reservacion> lstModeloReservacion = new List<M_Reservacion>();
            lstReservaciones = objReservacionesAD.recReservaciones();

            foreach (var reservacion in lstReservaciones)
            {
                M_Reservacion objModeloReservacion = new M_Reservacion();
                objModeloReservacion.IdReservaciones = reservacion.IdReservaciones;
                objModeloReservacion.IdCliente = reservacion.IdCliente;
                objModeloReservacion.IdMesa = reservacion.IdMesa;
                objModeloReservacion.IdMenu = reservacion.IdMenu;
                objModeloReservacion.Cantidad = reservacion.Cantidad;
                objModeloReservacion.FechaReservacion = reservacion.FechaReservacion;
                lstModeloReservacion.Add(objModeloReservacion);
            }
            return View(lstModeloReservacion);
        }

        public ActionResult AgregaReservacion()
        {
            var clientes = objClientesAD.recClientes().Select(c => new {
                IdCliente = c.IdCliente,                         // Valor que se enviará al backend
                NombreApellido = c.Nombre + " " + c.Apellido     // Concatenamos el nombre y apellido
            }).ToList();

            // Cargar los ViewBag con la opción seleccionada
            ViewBag.Clientes = new SelectList(clientes, "IdCliente", "NombreApellido");
            ViewBag.Mesas = new SelectList(objMesasAD.recMesas(), "IdMesa", "NumeroMesa");
            ViewBag.Menus = new SelectList(objMenuAD.recMenu(), "IdMenu", "Descripcion");
            return View();
        }

        public ActionResult ModificaReservaciones(int id)
        {
            // Obtener la reservación desde la base de datos
            PA_recReservacionXId_Result objReservacion = objReservacionesAD.recReservacionXId(id);

            // Crear el modelo intermedio
            M_Reservacion objReservacionEnt = new M_Reservacion();
            objReservacionEnt.IdReservaciones = objReservacion.IdReservaciones;
            objReservacionEnt.IdCliente = objReservacion.IdCliente;
            objReservacionEnt.IdMesa = objReservacion.IdMesa;
            objReservacionEnt.IdMenu = objReservacion.IdMenu;
            objReservacionEnt.Cantidad = objReservacion.Cantidad;
            objReservacionEnt.FechaReservacion = objReservacion.FechaReservacion;

            // Cargar los clientes con nombre completo concatenado
            var clientes = objClientesAD.recClientes().Select(c => new {
                IdCliente = c.IdCliente,
                NombreApellido = c.Nombre + " " + c.Apellido  // Concatenamos el nombre y apellido
            }).ToList();

            // Cargar los ViewBag con la opción seleccionada
            ViewBag.Clientes = new SelectList(clientes, "IdCliente", "NombreApellido", objReservacionEnt.IdCliente);
            ViewBag.Mesas = new SelectList(objMesasAD.recMesas(), "IdMesa", "NumeroMesa", objReservacionEnt.IdMesa);
            ViewBag.Menus = new SelectList(objMenuAD.recMenu(), "IdMenu", "Descripcion", objReservacionEnt.IdMenu);

            return View(objReservacionEnt);
        }

        public ActionResult EliminaReservaciones(int id)
        {   
            PA_recReservacionXId_Result objReservacion = objReservacionesAD.recReservacionXId(id);

            M_Reservacion objReservacionEnt = new M_Reservacion();
            objReservacionEnt.IdReservaciones = objReservacion.IdReservaciones;
            objReservacionEnt.IdCliente = objReservacion.IdCliente;
            objReservacionEnt.IdMesa = objReservacion.IdMesa;
            objReservacionEnt.IdMenu = objReservacion.IdMenu;
            objReservacionEnt.Cantidad = objReservacion.Cantidad;
            objReservacionEnt.FechaReservacion = objReservacion.FechaReservacion;

            return View(objReservacionEnt);
        }

        // Metodos 

        public ActionResult IngresarReservacion(Reservacione objReservacion)
        {
            List<PA_recReservaciones_Result> lstReservaciones = new List<PA_recReservaciones_Result>();
            List<M_Reservacion> lstModeloReservacion = new List<M_Reservacion>();
            try
            {
                if (objReservacionesAD.insReservacion(objReservacion)) 
                {
                    lstReservaciones = objReservacionesAD.recReservaciones();

                    foreach (var reservacion in lstReservaciones)
                    {
                        M_Reservacion objModeloReservacion = new M_Reservacion();
                        objModeloReservacion.IdReservaciones = reservacion.IdReservaciones;
                        objModeloReservacion.IdCliente = reservacion.IdCliente;
                        objModeloReservacion.IdMesa = reservacion.IdMesa;
                        objModeloReservacion.IdMenu = reservacion.IdMenu;
                        objModeloReservacion.Cantidad = reservacion.Cantidad;
                        objModeloReservacion.FechaReservacion = reservacion.FechaReservacion;
                        lstModeloReservacion.Add(objModeloReservacion);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Reservaciones", "IngresarReservacion"));
            }
            return View("ListaReservaciones", lstModeloReservacion);
        }

        public ActionResult ModificarReservacion(Reservacione objReservacion)
        {
            List<PA_recReservaciones_Result> lstReservaciones = new List<PA_recReservaciones_Result>();
            List<M_Reservacion> lstModeloReservacion = new List<M_Reservacion>();
            try
            {
                if (objReservacionesAD.modReservacion(objReservacion))
                {
                    lstReservaciones = objReservacionesAD.recReservaciones();

                    foreach (var reservacion in lstReservaciones)
                    {
                        M_Reservacion objModeloReservacion = new M_Reservacion();
                        objModeloReservacion.IdReservaciones = reservacion.IdReservaciones;
                        objModeloReservacion.IdCliente = reservacion.IdCliente;
                        objModeloReservacion.IdMesa = reservacion.IdMesa;
                        objModeloReservacion.IdMenu = reservacion.IdMenu;
                        objModeloReservacion.Cantidad = reservacion.Cantidad;
                        objModeloReservacion.FechaReservacion = reservacion.FechaReservacion;
                        lstModeloReservacion.Add(objModeloReservacion);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Reservaciones", "ModificarReservacion"));
            }
            return View("ListaReservaciones", lstModeloReservacion);
        }

        public ActionResult EliminarReservacion(int id)
        {
            List<PA_recReservaciones_Result> lstReservaciones = new List<PA_recReservaciones_Result>();
            List<M_Reservacion> lstModeloReservacion = new List<M_Reservacion>();
            try
            {
                if (objReservacionesAD.delReservacion(id))
                {
                    lstReservaciones = objReservacionesAD.recReservaciones();

                    foreach (var reservacion in lstReservaciones)
                    {
                        M_Reservacion objModeloReservacion = new M_Reservacion();
                        objModeloReservacion.IdReservaciones = reservacion.IdReservaciones;
                        objModeloReservacion.IdCliente = reservacion.IdCliente;
                        objModeloReservacion.IdMesa = reservacion.IdMesa;
                        objModeloReservacion.IdMenu = reservacion.IdMenu;
                        objModeloReservacion.Cantidad = reservacion.Cantidad;
                        objModeloReservacion.FechaReservacion = reservacion.FechaReservacion;
                        lstModeloReservacion.Add(objModeloReservacion);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Reservaciones", "EliminarReservacion"));
            }
            return View("ListaReservaciones", lstModeloReservacion);
        }

        [HttpPost]
        public ActionResult Acciones(string submitButton, M_Reservacion pReservacion)
        {
            try
            {
                Reservacione objRe = new Reservacione();
                objRe.IdReservaciones = pReservacion.IdReservaciones;
                objRe.IdCliente = pReservacion.IdCliente;
                objRe.IdMesa = pReservacion.IdMesa;
                objRe.IdMenu = pReservacion.IdMenu;
                objRe.Cantidad = pReservacion.Cantidad;
                objRe.FechaReservacion = pReservacion.FechaReservacion;

                switch (submitButton)
                {
                    case "Agregar":
                        return IngresarReservacion(objRe);
                    case "Actualizar":
                        return ModificarReservacion(objRe);
                    case "Eliminar":
                        return EliminarReservacion(objRe.IdReservaciones);
                    default:
                        return RedirectToAction("ListaReservaciones", "Reservaciones");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Reservaciones", "Acciones"));
            }
        }
    }
}