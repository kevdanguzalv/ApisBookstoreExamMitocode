using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Clientes : EntityBase
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI {  get; set;  }
        public int Edad { get; set; }
    }
}
