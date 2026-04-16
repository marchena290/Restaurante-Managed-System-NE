using Entidades;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestauranteApp.Controllers
{
    public class ClientesController : Controller
    {
        private IClientesLN objClientesAD = new ClientesLN();

        // Vistas

        public ActionResult ListaClientes()
        {
            List<PA_recClientes_Result> lstClientes = new List<PA_recClientes_Result>();
            lstClientes = objClientesAD.recClientes();
            return View(lstClientes);
        }

        public ActionResult AgregarCliente()
        {
            return View();
        }

        public ActionResult ModificaClientes(int id)
        {
            PA_recClienteXId_Result objCliente = objClientesAD.recClientesXId(id);
            Cliente objClienteEnt = new Cliente();
            objClienteEnt.IdCliente = id;
            objClienteEnt.Nombre = objCliente.Nombre;
            objClienteEnt.Correo = objCliente.Correo;
            objClienteEnt.Telefono = objCliente.Telefono;
            return View(objClienteEnt);
        }

        public ActionResult EliminaClientes(int id)
        {
            PA_recClienteXId_Result objCliente = objClientesAD.recClientesXId(id);
            Cliente objClienteEnt = new Cliente();
            objClienteEnt.IdCliente = id;
            objClienteEnt.Nombre = objCliente.Nombre;
            objClienteEnt.Correo = objCliente.Correo;
            objClienteEnt.Telefono = objCliente.Telefono;
            return View(objClienteEnt);
        }

        // Metodos 
        public ActionResult IngresarCliente(Cliente objCliente)
        {
            List<PA_recClientes_Result> lstClientes = new List<PA_recClientes_Result>();
            try
            {
                if (objClientesAD.insCliente(objCliente))
                {
                    lstClientes = objClientesAD.recClientes();
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaClientes", lstClientes);
        }

        public ActionResult ModificarCliente(Cliente objCliente)
        {
            List<PA_recClientes_Result> lstClientes = new List<PA_recClientes_Result>();
            try
            {
                if (objClientesAD.ModCliente(objCliente))
                {
                    lstClientes = objClientesAD.recClientes();
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaClientes", lstClientes);
        }

        public ActionResult EliminarCliente(int id)
        {
            List<PA_recClientes_Result> lstClientes = new List<PA_recClientes_Result>();
            try
            {
                if (objClientesAD.delCliente(id))
                {
                    lstClientes = objClientesAD.recClientes();
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "RegistroDecomiso", "AccionDecomiso"));
            }
            return View("ListaClientes", lstClientes);
        }

        [HttpPost]
        public ActionResult Acciones(String submitButton, Cliente pCliente)
        {
            try
            {
                switch (submitButton)
                {
                    case "Agregar":
                        return IngresarCliente(pCliente);
                    case "Actualizar":
                        return ModificarCliente(pCliente);
                    case "Eliminar":
                        return EliminarCliente(pCliente.IdCliente);
                    default:
                        return RedirectToAction("ListaClientes", "Cliente");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Cliente", "Acciones"));
            }
        }
    }
}