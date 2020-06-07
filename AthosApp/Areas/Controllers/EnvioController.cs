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

        // GET: Envio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Envio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Envio/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Envio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Envio/Edit/5
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

        // GET: Envio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Envio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
