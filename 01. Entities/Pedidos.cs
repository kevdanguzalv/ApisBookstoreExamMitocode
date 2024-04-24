using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Pedidos : EntityBase
    {
        public DateTime FechaPedido { get; set; }

        public Clientes Clientes { get; set; }

        //public IEnumerable<PedidosDetalle>? PedidosDetalle { get; set; }

        
    }
}
