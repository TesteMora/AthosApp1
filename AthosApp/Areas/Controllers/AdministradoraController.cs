using AthosApp.Database;
using AthosApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AthosApp.Areas
{
    public class AdministradoraController : Controller
    {

        [HttpGet]
        public string ListarAdm()
        {
            try
            {
                var json = JsonConvert.SerializeObject(LiteDBClass.ListarTodasAdministradoras());
                return json;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        [HttpPost]
        public bool CreateAdm(string NomeAdministradora)
        {

            try
            {
                Administradora administradora = new Administradora();
                administradora.NomeAdministradora = NomeAdministradora;
                LiteDBClass.InsertObject(administradora, Objetos.Administradora);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                LiteDBClass.DeleteObject(id, Objetos.Administradora);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
