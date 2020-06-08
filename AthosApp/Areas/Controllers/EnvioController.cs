using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AthosApp.Areas
{
    public class EnvioController : Controller
    {
        // GET: Envio
        public ActionResult Index()
        {
            return View();
        }
        
        // POST: Envio/Create
        [HttpPost]
        public ActionResult Enviar()
        {
            try
            {
                // TODO: inserir metodo de Litedb

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
    }
}
