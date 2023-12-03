using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailBar_App.Models
{
    public class Usuario
    {
        public string Id { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
    }
}
