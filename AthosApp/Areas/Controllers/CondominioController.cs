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

        // GET: Condominio/Details/5
        public ActionResult Editar(int id)
        {
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
        public string ListarAdm()
        {
            try
            {
                var json = JsonConvert.SerializeObject(LiteDBClass.ListarTodasAdministradoras());
                return json;
            }
            catch(Exception e)
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
                LiteDBClass.DeleteObject(id, Objetos.Assunto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
