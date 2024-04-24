using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PedidosDetalle: EntityBase
    {

        public int PedidosId { get; set; }
        public int LibrosId { get; set; }

        [ForeignKey("PedidosId")]
        public Pedidos? Pedidos { get; set; }
        [ForeignKey("LibrosId")]
        public Libros? Libros { get; set; }
    }
}
