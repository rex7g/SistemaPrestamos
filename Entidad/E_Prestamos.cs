using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class E_Prestamos
    {
        
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
        public int numeroId { get; set; }
        public string direccion { get; set; }


        public int pagoPrestamo { get; set; }
        public int interesPrestamo { get; set; }
        public int montoPrestamo { get; set; }
        public int tiempoPrestamo { get; set; }
        public int cuotaPrestamo { get; set; }


        
    }
}
