using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public  class Libros : EntityBase
    {
        public string Nombres { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        //public IEnumerable<PedidosDetalle> PedidosDetalle { get; set; }
    }
}
