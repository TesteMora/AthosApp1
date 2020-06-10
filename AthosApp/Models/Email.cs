using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AthosApp.Models
{
    public class Email
    {
        public int Id { get; set; }
        public string Remetente { get; set; }
        public string Destinatario { get; set; }
        public string Corpo { get; set; }
        public string Assunto { get; set; }
    }
}