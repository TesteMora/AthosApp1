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
    public class CondominioController : Controller
    {
        // GET: Condominio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Criar()
        {
            return View();
        }

        // GET: Condominio/Details/
        public ActionResult Editar(int id)
        {
            ViewData.Model = LiteDBClass.GetObject(id, Objetos.Condominio);
            return View();
        }

        // POST: Condominio/Create
        [HttpPost]
        public bool CriarCondominio(int idCondo, string nomeCondominio, int resposavel, int administradora)
        {
            try
            {
                LiteDBClass.InsertObject(new Condominio()
                {
                    IdAdministradora = administradora,
                    Responsavel = (TipoUsuario)resposavel,
                    NomeCondominio = nomeCondominio,
                }, Objetos.Condominio);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpGet]
        public string ListarCondos()
        {
            try
            {
                var json = JsonConvert.SerializeObject(LiteDBClass.ListarTodosCondominio());
                return json;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        // GET: Condominio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        
        [HttpPost]
        public string GetCondominio(int id)
        {
            return JsonConvert.SerializeObject(LiteDBClass.GetObject(id, Objetos.Condominio));
        }
        
        [HttpPost]
        public bool Edit(int idCondo, string nomeCondominio, int resposavel, int administradora)
        {
            try
            {
                LiteDBClass.UpdateObject(new Condominio()
                {
                    Id = idCondo,
                    IdAdministradora = administradora,
                    Responsavel = (TipoUsuario)resposavel,
                    NomeCondominio = nomeCondominio,
                }, Objetos.Condominio);
                Redirect("/Condominio");
                return true;
            }
            catch
            {
                return false;
            }
        }

        // POST: Condominio/Delete/5
        [HttpGet]
        public bool Delete(int id)
        {
            try
            {
                LiteDBClass.DeleteObject(id, Objetos.Condominio);
                Redirect("/Condominio");
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
