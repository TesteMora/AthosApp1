using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AthosApp.Models
{
    public enum TipoUsuario
    {
        Morador = 1,
        Sindico = 2,
        Administradora = 3,
        Zelador = 4
    }

    public enum TipoAssunto
    {
        Administrativo = 1,
        Condominal = 2
    }
}