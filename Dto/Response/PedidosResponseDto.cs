using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Response
{
    public class PedidosResponseDto
    {
        public int Pedido { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Libro { get; set; }   
        public string Autor { get; set; }
        public string ISBN { get; set; }

    }
}
