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
    public class MenuController : Controller
    {
        private IMenuLN objMenuAD = new MenuLN();

        // Vistas 

        public ActionResult ListaMenus()
        {
            List<PA_recMenu_Result> lstMenus = new List<PA_recMenu_Result>();
            List<M_Menu> lstModeloMenu = new List<M_Menu>();
            lstMenus = objMenuAD.recMenu();

            foreach(var menu in lstMenus)
            {
                M_Menu objModeloMenu = new M_Menu();
                objModeloMenu.IdMenu = menu.IdMenu;
                objModeloMenu.Descripcion = menu.Descripcion;
                objModeloMenu.Precio = menu.Precio;
                lstModeloMenu.Add(objModeloMenu);
            }
            return View(lstModeloMenu);
        }

        public ActionResult AgregaMenu()
        {
            return View();
        }

        public ActionResult ModificaMenu(int id)
        {
            PA_recMenuXId_Result objMenu = objMenuAD.recMenuXId(id);
            M_Menu objMenuEnt = new M_Menu();
            objMenuEnt.IdMenu = objMenu.IdMenu;
            objMenuEnt.Descripcion = objMenu.Descripcion;
            objMenuEnt.Precio = objMenu.Precio;
            return View(objMenuEnt);
        }

        public ActionResult EliminaMenu(int id)
        {
            PA_recMenuXId_Result objMenu = objMenuAD.recMenuXId(id);
            M_Menu objMenuEnt = new M_Menu();
            objMenuEnt.IdMenu = objMenu.IdMenu;
            objMenuEnt.Descripcion = objMenu.Descripcion;
            objMenuEnt.Precio = objMenu.Precio;
            return View(objMenuEnt);
        }

        // Metodos

        public ActionResult IngresarMenu(Menu objMenu)
        {
            List<PA_recMenu_Result> lstMenus = new List<PA_recMenu_Result>();
            List<M_Menu> lstModeloMenu = new List<M_Menu>();
            try
            {
                if (objMenuAD.insMenu(objMenu))
                {
                    lstMenus = objMenuAD.recMenu();

                    foreach (var menu in lstMenus)
                    {
                        M_Menu objModeloMenu = new M_Menu();
                        objModeloMenu.IdMenu = menu.IdMenu;
                        objModeloMenu.Descripcion = menu.Descripcion;
                        objModeloMenu.Precio = menu.Precio;
                        lstModeloMenu.Add(objModeloMenu);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Menu", "IngresarMenu"));
            }
            return View("ListaMenus", lstModeloMenu);
        }

        public ActionResult ModificarMenu(Menu objMenu)
        {
            List<PA_recMenu_Result> lstMenus = new List<PA_recMenu_Result>();
            List<M_Menu> lstModeloMenu = new List<M_Menu>();
            try
            {
                if (objMenuAD.modMenu(objMenu))
                {
                    lstMenus = objMenuAD.recMenu();

                    foreach (var menu in lstMenus)
                    {
                        M_Menu objModeloMenu = new M_Menu();
                        objModeloMenu.IdMenu = menu.IdMenu;
                        objModeloMenu.Descripcion = menu.Descripcion;
                        objModeloMenu.Precio = menu.Precio;
                        lstModeloMenu.Add(objModeloMenu);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Menu", "ModificarMenu"));
            }
            return View("ListaMenus", lstModeloMenu);
        }

        public ActionResult EliminarMenu(int id)
        {
            List<PA_recMenu_Result> lstMenus = new List<PA_recMenu_Result>();
            List<M_Menu> lstModeloMenu = new List<M_Menu>();
            try
            {
                if(objMenuAD.delMenu(id))
                {
                    lstMenus = objMenuAD.recMenu();

                    foreach (var menu in lstMenus)
                    {
                        M_Menu objModeloMenu = new M_Menu();
                        objModeloMenu.IdMenu = menu.IdMenu;
                        objModeloMenu.Descripcion = menu.Descripcion;
                        objModeloMenu.Precio = menu.Precio;
                        lstModeloMenu.Add(objModeloMenu);
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "No puedes eliminar este menú porque está ligado a una reservación.";
                return View("ErrorPersonalizado");
            }
            return View("ListaMenus", lstModeloMenu);
        }


        [HttpPost]
        public ActionResult Acciones(string submitButton, M_Menu pMenu)
        {
            try
            {
                Menu objMe = new Menu();
                objMe.IdMenu = pMenu.IdMenu;
                objMe.Descripcion = pMenu.Descripcion;
                objMe.Precio = pMenu.Precio;

                switch (submitButton)
                {
                    case "Agregar":
                        return IngresarMenu(objMe);
                    case "Actualizar":
                        return ModificarMenu(objMe);
                    case "Eliminar":
                        return EliminarMenu(objMe.IdMenu);
                    default:
                        return RedirectToAction("ListaMenus", "Menu");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Menu", "Acciones"));
            }
        }
    }
}