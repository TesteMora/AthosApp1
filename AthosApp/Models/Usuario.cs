﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AthosApp.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int IdCondominio { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}