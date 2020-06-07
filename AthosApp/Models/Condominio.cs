using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AthosApp.Models
{
    public class Condominio
    {
        public int Id { get; set; }
        public string NomeCondominio { get; set; }
        public Administradora Administradora { get; set; }
        public TipoUsuario Responsavel { get; set; }
    }
}