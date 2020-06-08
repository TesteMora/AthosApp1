using AthosApp.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AthosApp.Database
{
    public static class LiteDBClass
    {
        public static bool InsertObject(Object insert, Objetos type)
        {
            bool sucesso = false;
            // Abre ou cria database
            using (var db = new LiteDatabase(@"DatabaseAthos.db"))
            {
                try
                {
                    switch (type)
                    {
                        case Objetos.Assunto:
                            var assuntos = db.GetCollection<Assunto>("Assuntos");
                            Assunto assunto = (Assunto)insert;
                            //Id é auto incremento
                            assuntos.Insert(assunto);
                            sucesso = true;
                            break;
                        case Objetos.Condominio:
                            var condomonios = db.GetCollection<Condominio>("Condominios");
                            Condominio condo = (Condominio)insert;
                            //Id é auto incremento
                            condomonios.Insert(condo);
                            sucesso = true;
                            break;
                        case Objetos.Usuario:
                            var usuarios = db.GetCollection<Usuario>("Usuarios");
                            Usuario usu = (Usuario)insert;
                            //Id é auto incremento
                            usuarios.Insert(usu);
                            sucesso = true;
                            break;
                        case Objetos.Administradora:
                            var administradoras = db.GetCollection<Administradora>("Administradoras");
                            Administradora adm = (Administradora)insert;
                            //Id é auto incremento
                            administradoras.Insert(adm);
                            sucesso = true;
                            break;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return sucesso;
        }

        public static List<Assunto> ListarTodosAssunto()
        {

            using (var db = new LiteDatabase(@"DatabaseAthos.db"))
            {
                try
                {

                    var assuntos = db.GetCollection<Assunto>("Assuntos");
                    return assuntos.FindAll().ToList();
                    
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public static List<Condominio> ListarTodosCondominio()
        {

            using (var db = new LiteDatabase(@"DatabaseAthos.db"))
            {
                try
                {

                    var condominios= db.GetCollection<Condominio>("Condominios");
                    return condominios.FindAll().ToList();

                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public static List<Usuario> ListarTodosUsuario()
        {

            using (var db = new LiteDatabase(@"DatabaseAthos.db"))
            {
                try
                {

                    var usuarios = db.GetCollection<Usuario>("Usuarios");
                    return usuarios.FindAll().ToList();

                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public static List<Administradora> ListarTodasAdministradoras()
        {
            using (var db = new LiteDatabase(@"DatabaseAthos.db"))
            {
                try
                {
                    var adm = db.GetCollection<Administradora>("Administradoras");
                    return adm.FindAll().ToList();

                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public static object GetObject(int id, Objetos type)
        {
            using (var db = new LiteDatabase(@"DatabaseAthos.db"))
            {
                try
                {
                    switch (type)
                    {
                        case Objetos.Assunto:

                            var assuntos = db.GetCollection<Assunto>("Assuntos");
                            var resultA = assuntos.Find(x => x.Id == id).FirstOrDefault();
                            return resultA;

                        case Objetos.Condominio:

                            var condomonios = db.GetCollection<Condominio>("Condominios");
                            var resultC = condomonios.Find(x => x.Id == id).FirstOrDefault();
                            return resultC;

                        case Objetos.Administradora:
                            var administradoras = db.GetCollection<Administradora>("Administradoras");
                            var resultAd = administradoras.Find(x => x.Id == id).FirstOrDefault();
                            return resultAd;
                    }
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return null;
        }

        public static Usuario GetUsuario(string nome)
        {

            using (var db = new LiteDatabase(@"DatabaseAthos.db"))
            {
                try
                {
                    var usuarios = db.GetCollection<Usuario>("Usuarios");
                    var result = usuarios.Find(x => x.Nome == nome).FirstOrDefault();
                    return result;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public static bool UpdateObject(Object update, Objetos type)
        {
            bool sucesso = false;
            // Abre ou cria database
            using (var db = new LiteDatabase(@"DatabaseAthos.db"))
            {
                try
                {
                    switch (type)
                    {
                        case Objetos.Assunto:

                            Assunto assunto = (Assunto)update;
                            var assuntos = db.GetCollection<Assunto>("Assuntos");
                            var resultA = assuntos.Find(x => x.Id == assunto.Id).FirstOrDefault();
                            resultA.TipoAssunto = assunto.TipoAssunto;

                            assuntos.Update(resultA);
                            sucesso = true;
                            break;

                        case Objetos.Condominio:

                            Condominio condo = (Condominio)update;
                            var condomonios = db.GetCollection<Condominio>("Condominios");
                            var resultC = condomonios.Find(x => x.Id == condo.Id).FirstOrDefault();
                            resultC.NomeCondominio = condo.NomeCondominio;
                            resultC.IdAdministradora = condo.IdAdministradora;
                            resultC.Responsavel = condo.Responsavel;

                            condomonios.Update(resultC);
                            sucesso = true;
                            break;

                        case Objetos.Usuario:

                            Usuario usu = (Usuario)update;
                            var usuarios = db.GetCollection<Usuario>("Usuarios");
                            var resultU = usuarios.Find(x => x.Nome == usu.Nome).FirstOrDefault();
                            resultU.IdCondominio = usu.IdCondominio;
                            resultU.Email = usu.Email;
                            resultU.TipoUsuario = usu.TipoUsuario;

                            usuarios.Update(resultU);
                            sucesso = true;
                            break;
                        case Objetos.Administradora:
                            Administradora adm = (Administradora)update;
                            var administradoras = db.GetCollection<Administradora>("Administradoras");
                            var resultAd = administradoras.Find(x => x.Id == adm.Id).FirstOrDefault();
                            resultAd.NomeAdministradora = adm.NomeAdministradora;
                            administradoras.Update(resultAd);
                            sucesso = true;
                            break;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return sucesso;
        }

        public static bool DeleteObject(int id, Objetos type)
        {
            var sucesso = false;
            using (var db = new LiteDatabase(@"DatabaseAthos.db"))
            {
                try
                {
                    switch (type)
                    {
                        case Objetos.Assunto:

                            var assuntos = db.GetCollection<Assunto>("Assuntos");
                            assuntos.Delete(id);
                            sucesso = true;
                            break;

                        case Objetos.Condominio:

                            var condomonios = db.GetCollection<Condominio>("Condominios");
                            condomonios.Delete(id);
                            sucesso = true;
                            break;

                        case Objetos.Administradora:
                            var administradoras = db.GetCollection<Administradora>("Administradoras");
                            administradoras.Delete(id);
                            sucesso = true;
                            break;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return sucesso;
        }

        public static bool DeleteUsuarioByNome(string nome)
        {
            var sucesso = false;
            using (var db = new LiteDatabase(@"DatabaseAthos.db"))
            {
                try
                {
                    var usuarios = db.GetCollection<Usuario>("Usuarios");
                    usuarios.DeleteMany("$.Usuarios[@.Nome = " + nome + "]");
                    sucesso = true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return sucesso;
        }
    }
}