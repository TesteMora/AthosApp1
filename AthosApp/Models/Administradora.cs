using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AthosApp.Models
{
    public class Administradora
    {
        public int Id { get; set; }
        public string NomeAdministradora { get; set; }

        public Administradora getById(int id)
        {
            return this;
        }

        public Administradora(string nome)
        {
            this.Id = 1;
            this.NomeAdministradora = nome;
        }

        public Administradora(int id, string nome)
        {
            this.Id = id;
            this.NomeAdministradora = nome;
        }


    }
}