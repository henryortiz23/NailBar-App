using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailBar_App.Models
{
    public class Cita
    {
        public string Id { get; set; }
        public string IdAgente { get; set; }
        public string IdCliente { get; set; }
        public string Agente { get; set; }
        public string Cliente { get; set; }
        public string Telefono { get; set; }
        public string Tipo { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Estado { get; set; }
        public string Extra { get; set; }
        public string Precio { get; set; }
        public string Calificacion { get; set; }
    }
}
