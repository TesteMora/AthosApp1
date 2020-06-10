using AthosApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AthosApp.Database;
using Newtonsoft.Json;

namespace AthosApp.Areas
{
    public class AssuntoController : Controller
    {
        // GET: Assunto
        public ActionResult Index()
        {
            return View();
        }
        
        // POST: Assunto/Create
        [HttpPost]
        public bool Create(int tipoAssunto)
        {
            try
            {
                LiteDBClass.InsertObject(new Assunto()
                {
                    TipoAssunto = (TipoAssunto)tipoAssunto,
                }, Objetos.Assunto);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpGet]
        public string ListarAssuntos()
        {
            try
            {
                var json = JsonConvert.SerializeObject(LiteDBClass.ListarTodosAssunto());
                return json;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        // POST: Assunto/Delete/5
        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                LiteDBClass.DeleteObject(id, Objetos.Assunto);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
