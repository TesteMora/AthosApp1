using AthosApp.Database;
using AthosApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AthosApp.Areas
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Criar()
        {
            return View();
        }
        
        public ActionResult Editar(string nome)
        {
            ViewData.Model = LiteDBClass.GetUsuario(nome);
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public void CriarUsuario (string nomeUsuario, string email, int condominio, int tipoUsuario)
        {
            try
            {
                LiteDBClass.InsertObject(new Usuario()
                {
                    Nome = nomeUsuario,
                    Email = email,
                    TipoUsuario = (TipoUsuario)tipoUsuario,
                    IdCondominio = condominio,
                }, Objetos.Usuario);
            }
            catch
            {
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
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

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
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
