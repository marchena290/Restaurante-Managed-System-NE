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
    public class ClientesController : Controller
    {
        private IClientesLN objClientesAD = new ClientesLN();

        // Vistas 

        public ActionResult ListaClientes() 
        {
            List<PA_recClientes_Result> lstClientes = new List<PA_recClientes_Result>();
            List<M_Cliente> lstModeloCliente = new List<M_Cliente>();
            lstClientes = objClientesAD.recClientes();

            foreach(var cliente in lstClientes)
            {
                M_Cliente objModeloCliente = new M_Cliente();
                objModeloCliente.IdCliente = cliente.IdCliente;
                objModeloCliente.Nombre = cliente.Nombre;
                objModeloCliente.Apellido = cliente.Apellido;
                objModeloCliente.Telefono = cliente.Telefono;
                objModeloCliente.Correo = cliente.Correo;
                lstModeloCliente.Add(objModeloCliente);
            }
            return View(lstModeloCliente);
        }

        public ActionResult AgregaClientes()
        {
            return View();
        }

        public ActionResult ModificaClientes(int id)
        {
            PA_recClienteXId_Result objCliente = objClientesAD.recClientesXId(id);
            M_Cliente objClienteEnt = new M_Cliente();
            objClienteEnt.IdCliente = objCliente.IdCliente;
            objClienteEnt.Nombre = objCliente.Nombre;
            objClienteEnt.Apellido = objCliente.Apellido;
            objClienteEnt.Correo = objCliente.Correo;
            objClienteEnt.Telefono = objCliente.Telefono;
            return View(objClienteEnt);
        }

        public ActionResult EliminaClientes(int id)
        {
            PA_recClienteXId_Result objCliente = objClientesAD.recClientesXId(id);
            M_Cliente objClienteEnt = new M_Cliente();
            objClienteEnt.IdCliente = objCliente.IdCliente;
            objClienteEnt.Nombre = objCliente.Nombre;
            objClienteEnt.Apellido = objCliente.Apellido;
            objClienteEnt.Correo = objCliente.Correo;
            objClienteEnt.Telefono = objCliente.Telefono;
            return View(objClienteEnt);
        }

        // Metodos 
        public ActionResult IngresarCliente(Cliente objCliente)
        {
            List<PA_recClientes_Result> lstClientes = new List<PA_recClientes_Result>();
            List<M_Cliente> lstModeloCliente = new List<M_Cliente>();
            try
            {
                if (objClientesAD.insCliente(objCliente))
                {
                    lstClientes = objClientesAD.recClientes();

                    foreach(var cliente in lstClientes)
                    {
                        M_Cliente objModeloCliente = new M_Cliente();
                        objModeloCliente.IdCliente = cliente.IdCliente;
                        objModeloCliente.Nombre = cliente.Nombre;
                        objModeloCliente.Apellido = cliente.Apellido;
                        objModeloCliente.Telefono = cliente.Telefono;
                        objModeloCliente.Correo = cliente.Correo;
                        lstModeloCliente.Add(objModeloCliente);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Clientes", "IngresarCliente"));
            }
            return View("ListaClientes", lstModeloCliente);
        }

        public ActionResult ModificarCliente(Cliente objCliente)
        {
            List<PA_recClientes_Result> lstClientes = new List<PA_recClientes_Result>();
            List<M_Cliente> lstModeloCliente = new List<M_Cliente>();
            try
            {
                if (objClientesAD.ModCliente(objCliente))
                {
                    lstClientes = objClientesAD.recClientes();

                    foreach (var cliente in lstClientes)
                    {
                        M_Cliente objModeloCliente = new M_Cliente();
                        objModeloCliente.IdCliente = cliente.IdCliente;
                        objModeloCliente.Nombre = cliente.Nombre;
                        objModeloCliente.Apellido = cliente.Apellido;
                        objModeloCliente.Telefono = cliente.Telefono;
                        objModeloCliente.Correo = cliente.Correo;
                        lstModeloCliente.Add(objModeloCliente);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Clientes", "ModificarCliente"));
            }
            return View("ListaClientes", lstModeloCliente);
        }

        public ActionResult EliminarCliente(int id)
        {
            List<PA_recClientes_Result> lstClientes = new List<PA_recClientes_Result>();
            List<M_Cliente> lstModeloCliente = new List<M_Cliente>();
            try
            {
                if (objClientesAD.delCliente(id))
                {
                    lstClientes = objClientesAD.recClientes();

                    foreach (var cliente in lstClientes)
                    {
                        M_Cliente objModeloCliente = new M_Cliente();
                        objModeloCliente.IdCliente = cliente.IdCliente;
                        objModeloCliente.Nombre = cliente.Nombre;
                        objModeloCliente.Apellido = cliente.Apellido;
                        objModeloCliente.Telefono = cliente.Telefono;
                        objModeloCliente.Correo = cliente.Correo;
                        lstModeloCliente.Add(objModeloCliente);
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "No puedes eliminar este cliente porque está ligado a una reservación.";
                return View("ErrorPersonalizado");
            }
            return View("ListaClientes", lstModeloCliente);
        }

        [HttpPost]
        public ActionResult Acciones(String submitButton, M_Cliente pCliente)
        {
            try
            {
                Cliente objCli = new Cliente();
                objCli.IdCliente = pCliente.IdCliente;
                objCli.Nombre = pCliente.Nombre;
                objCli.Apellido = pCliente.Apellido;
                objCli.Telefono = pCliente.Telefono;
                objCli.Correo = pCliente.Correo;

                switch (submitButton)
                {
                    case "Agregar":
                        return IngresarCliente(objCli);
                    case "Actualizar":
                        return ModificarCliente(objCli);
                    case "Eliminar":
                        return EliminarCliente(objCli.IdCliente);
                    default:
                        return RedirectToAction("ListaClientes", "Clientes");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Clientes", "Acciones"));
            }
        }
    }
}