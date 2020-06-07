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

        // GET: Condominio/Details/5
        public ActionResult Editar(int id)
        {
            return View();
        }

        // POST: Condominio/Create
        [HttpPost]
        public ActionResult CriarCondominio(int idCondo, string nomeCondominio, int resposavel, int administradora)
        {
            try
            {
                // TODO: Inserir num arquivo json?

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Condominio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Condominio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Condominio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
