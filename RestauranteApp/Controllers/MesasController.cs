using AccesoDatos;
using AccesoDatos.Implementacion;
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
    public class MesasController : Controller
    {
        private IMesasLN objMesasAD = new MesasLN();

        // Vistas

        public ActionResult ListaMesas()
        {
            List<PA_recMesas_Result> lstMesas = new List<PA_recMesas_Result>();
            List<M_Mesa> lstModeloMesa = new List<M_Mesa>();
            lstMesas = objMesasAD.recMesas();

            foreach (var mesa in lstMesas)
            {
                M_Mesa objModeloMesa = new M_Mesa();
                objModeloMesa.IdMesa = mesa.IdMesa;
                objModeloMesa.NumeroMesa = mesa.NumeroMesa;
                objModeloMesa.Capacidad = mesa.Capacidad;
                objModeloMesa.Estado = mesa.Estado;
                lstModeloMesa.Add(objModeloMesa);
            }
            return View(lstModeloMesa);
        }

        public ActionResult AgregaMesa()
        {
            return View();
        }

        public ActionResult ModificaMesas(int id)
        {
            PA_recMesaXId_Result objMesa = objMesasAD.recMesaXId(id);
            M_Mesa objMesaEnt = new M_Mesa();
            objMesaEnt.IdMesa = objMesa.IdMesa;
            objMesaEnt.NumeroMesa = objMesa.NumeroMesa;
            objMesaEnt.Capacidad = objMesa.Capacidad;
            objMesaEnt.Estado = objMesa.Estado;

            return View(objMesaEnt);
        }

        public ActionResult EliminaMesas(int id)
        {
            PA_recMesaXId_Result objMesa = objMesasAD.recMesaXId(id);
            M_Mesa objMesaEnt = new M_Mesa();
            objMesaEnt.IdMesa = objMesa.IdMesa;
            objMesaEnt.NumeroMesa = objMesa.NumeroMesa;
            objMesaEnt.Capacidad = objMesa.Capacidad;
            objMesaEnt.Estado = objMesa.Estado;

            return View(objMesaEnt);
        }

        // Metodos
        public ActionResult IngresarMesa(Mesa objMesa)
        {
            List<PA_recMesas_Result> lstMesas = new List<PA_recMesas_Result>();
            List<M_Mesa> lstModeloMesa = new List<M_Mesa>();
            try
            {
                if (objMesasAD.insMesa(objMesa))
                {
                    lstMesas = objMesasAD.recMesas();

                    foreach (var mesa in lstMesas)
                    {
                        M_Mesa objModeloMesa = new M_Mesa();
                        objModeloMesa.IdMesa = mesa.IdMesa;
                        objModeloMesa.NumeroMesa = mesa.NumeroMesa;
                        objModeloMesa.Capacidad = mesa.Capacidad;
                        objModeloMesa.Estado = mesa.Estado;
                        lstModeloMesa.Add(objModeloMesa);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Mesas", "IngresarMesa"));
            }
            return View("ListaMesas", lstModeloMesa);
        }

        public ActionResult ModificarMesa(Mesa objMesa)
        {
            List<PA_recMesas_Result> lstMesas = new List<PA_recMesas_Result>();
            List<M_Mesa> lstModeloMesa = new List<M_Mesa>();
            try
            {
                if (objMesasAD.modMesa(objMesa))
                {
                    lstMesas = objMesasAD.recMesas();

                    foreach (var mesa in lstMesas)
                    {
                        M_Mesa objModeloMesa = new M_Mesa();
                        objModeloMesa.IdMesa = mesa.IdMesa;
                        objModeloMesa.NumeroMesa = mesa.NumeroMesa;
                        objModeloMesa.Capacidad = mesa.Capacidad;
                        objModeloMesa.Estado = mesa.Estado;
                        lstModeloMesa.Add(objModeloMesa);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Mesas", "ModificarMesa"));
            }
            return View("ListaMesas", lstModeloMesa);
        }

        public ActionResult EliminarMesa(int id)
        {
            List<PA_recMesas_Result> lstMesas = new List<PA_recMesas_Result>();
            List<M_Mesa> lstModeloMesa = new List<M_Mesa>();
            try
            {
                if (objMesasAD.delMesa(id))
                {
                    lstMesas = objMesasAD.recMesas();

                    foreach (var mesa in lstMesas)
                    {
                        M_Mesa objModeloMesa = new M_Mesa();
                        objModeloMesa.IdMesa = mesa.IdMesa;
                        objModeloMesa.NumeroMesa = mesa.NumeroMesa;
                        objModeloMesa.Capacidad = mesa.Capacidad;
                        objModeloMesa.Estado = mesa.Estado;
                        lstModeloMesa.Add(objModeloMesa);
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "No puedes eliminar esta mesa porque está ligada a una reservación.";
                return View("ErrorPersonalizado");
            }
            return View("ListaMesas", lstModeloMesa);
        }

        [HttpPost]
        public ActionResult Acciones(string submitButton, M_Mesa pMesa)
        {
            try
            {
                Mesa objMe = new Mesa();
                objMe.IdMesa = pMesa.IdMesa;
                objMe.NumeroMesa = pMesa.NumeroMesa;
                objMe.Capacidad = pMesa.Capacidad;
                objMe.Estado = pMesa.Estado;

                switch(submitButton)
                {
                    case "Agregar":
                        return IngresarMesa(objMe);
                    case "Actualizar":
                        return ModificarMesa(objMe);
                    case "Eliminar":
                        return EliminarMesa(objMe.IdMesa);
                    default:
                        return RedirectToAction("ListaMesas", "Mesas");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Mesas", "Acciones"));
            }
        }
    }
}