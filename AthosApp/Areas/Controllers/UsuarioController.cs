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

        [HttpPost]
        public string GetUsuario(int id)
        {
            return JsonConvert.SerializeObject(LiteDBClass.GetObject(id, Objetos.Usuario));
        }


        public ActionResult Editar(int id)
        {
            ViewData.Model = LiteDBClass.GetObject(id, Objetos.Usuario);
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public bool CriarUsuario (string nomeUsuario, string email, int condominio, int tipoUsuario)
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
                return true;
            }
            catch
            {
                return false;
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        [HttpGet]
        public string GetUsuarios(int id)
        {
            return JsonConvert.SerializeObject(LiteDBClass.GetObject(id, Objetos.Usuario));
        }

        [HttpPost]
        public bool Atualizar(int id, string nomeUsuario, string email, int condominio, int tipoUsuario)
        {
            try
            {
                LiteDBClass.UpdateObject(new Usuario()
                {
                    Id =id,
                    Nome = nomeUsuario,
                    Email = email,
                    TipoUsuario = (TipoUsuario)tipoUsuario,
                    IdCondominio = condominio,
                }, Objetos.Usuario);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpGet]
        public string ListarUsuarios()
        {
            try
            {
                var json = JsonConvert.SerializeObject(LiteDBClass.ListarTodosUsuario());
                return json;
            }
            catch (Exception e)
            {
                return "";
            }
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                LiteDBClass.DeleteObject(id, Objetos.Usuario);
                return View("Index");
            }
            catch
            {
                return View("Index");
            }
        }
    }
}
