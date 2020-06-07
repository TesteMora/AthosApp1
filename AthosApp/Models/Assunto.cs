using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AthosApp.Models
{
    public class Assunto
    {
        public int Id { get; set; }
        public TipoAssunto TipoAssunto { get; set; }
    }
}