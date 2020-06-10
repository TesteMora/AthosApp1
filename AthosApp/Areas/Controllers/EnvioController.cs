using AthosApp.Database;
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
        public bool Enviar(int idAssunto, int idUsuario, string corpoEmail)
        {
            try
            {
                LiteDBClass.EnviarEmail(idAssunto, idUsuario, corpoEmail);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
    }
}
