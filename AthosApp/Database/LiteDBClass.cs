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

                    db.Dispose();
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
            List<Assunto> assList = null; //( ͡° ͜ʖ ͡°)
            using (var db = new LiteDatabase(@"DatabaseAthos.db"))
            {
                try
                {

                    var assuntos = db.GetCollection<Assunto>("Assuntos");
                    assList = assuntos.FindAll().ToList();

                }
                catch (Exception e)
                {
                    return null;
                }
                db.Dispose();
            }
            return assList;
        }

        public static List<Condominio> ListarTodosCondominio()
        {
            List<Condominio> condominiosList = null;
            using (var db = new LiteDatabase(@"DatabaseAthos.db"))
            {
                try
                {

                    var condominios = db.GetCollection<Condominio>("Condominios");
                    condominiosList = condominios.FindAll().ToList();

                }
                catch (Exception e)
                {
                    return null;
                }
                db.Dispose();
            }
            return condominiosList;
        }

        public static List<Usuario> ListarTodosUsuario()
        {
            List<Usuario> usuariosList = null;
            using (var db = new LiteDatabase(@"DatabaseAthos.db"))
            {
                try
                {

                    var usuarios = db.GetCollection<Usuario>("Usuarios");
                    usuariosList = usuarios.FindAll().ToList();

                }
                catch (Exception e)
                {
                    return null;
                }
                db.Dispose();
            }
            return usuariosList;
        }

        public static List<Administradora> ListarTodasAdministradoras()
        {
            List<Administradora> admList = null;
            using (var db = new LiteDatabase(@"DatabaseAthos.db"))
            {
                try
                {
                    var adm = db.GetCollection<Administradora>("Administradoras");
                    admList = adm.FindAll().ToList();

                }
                catch (Exception e)
                {
                    return null;
                }

                db.Dispose();
            }
            return admList;
        }

        public static object GetObject(int id, Objetos type)
        {
            object resultObject = null;
            using (var db = new LiteDatabase(@"DatabaseAthos.db"))
            {
                try
                {
                    switch (type)
                    {
                        case Objetos.Assunto:

                            var assuntos = db.GetCollection<Assunto>("Assuntos");
                            resultObject = assuntos.Find(x => x.Id == id).FirstOrDefault();
                            break;

                        case Objetos.Condominio:

                            var condomonios = db.GetCollection<Condominio>("Condominios");
                            resultObject = condomonios.Find(x => x.Id == id).FirstOrDefault();
                            break;

                        case Objetos.Administradora:
                            var administradoras = db.GetCollection<Administradora>("Administradoras");
                            resultObject = administradoras.Find(x => x.Id == id).FirstOrDefault();
                            break;

                        case Objetos.Usuario:
                            var usuarios = db.GetCollection<Usuario>("Usuarios");
                            resultObject = usuarios.Find(x => x.Id == id).FirstOrDefault();
                            break;
                    }
                    db.Dispose();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return resultObject;
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
                            var resultU = usuarios.Find(x => x.Id == usu.Id).FirstOrDefault();
                            resultU.IdCondominio = usu.IdCondominio;
                            resultU.Email = usu.Email;
                            resultU.TipoUsuario = usu.TipoUsuario;
                            resultU.Nome = usu.Nome;
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

                    db.Dispose();
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

                        case Objetos.Usuario:
                            var usuarios = db.GetCollection<Usuario>("Usuarios");
                            usuarios.Delete(id);
                            sucesso = true;
                            break;
                    }

                    db.Dispose();
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return sucesso;
        }

        public static bool EnviarEmail(int idAssunto, int idUsuario, string corpoEmail)
        {
            var sucesso = false;
            using (var db = new LiteDatabase(@"DatabaseAthos.db"))
            {
                try
                {

                    var assuntos = db.GetCollection<Assunto>("Assuntos");
                    var assunto = assuntos.FindById(idAssunto);

                    var usuarios = db.GetCollection<Usuario>("Usuarios");
                    var usuario = usuarios.FindById(idUsuario);
                    
                    var condomonios = db.GetCollection<Condominio>("Condominios");
                    var condominio = condomonios.FindById(usuario.IdCondominio);

                    string destinatario = "";

                    if (assunto.TipoAssunto == TipoAssunto.Administrativo)
                    {
                        var administradoras = db.GetCollection<Administradora>("Administradoras");
                        var administradora = administradoras.FindById(condominio.IdAdministradora);

                        destinatario = administradora.NomeAdministradora;
                    }
                    else //Tipo 
                    {
                        //Aqui teria o if de responsavel ser Sindico ou Zelador, porém condominio salva TipoUsuario no responsável
                        destinatario = condominio.Responsavel.ToString();
                    }

                    //"Enviar" email
                    var emails = db.GetCollection<Email>("LogEmails");
                    Email email = new Email()
                    {
                        Remetente = usuario.Email,
                        Destinatario = destinatario,
                        Assunto = assunto.TipoAssunto.ToString(),
                        Corpo = corpoEmail,
                    };
                    emails.Insert(email);
                    sucesso = true;
                    db.Dispose();
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