using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Request
{
    
    public class PedidosRequestDto
    {
        public DateTime FechaPedido { get; set; }

        public int ClienteId { get; set; }

        public List<int> LibrosId { get; set; }
    }
}
