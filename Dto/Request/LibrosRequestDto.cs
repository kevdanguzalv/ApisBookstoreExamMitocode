using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Request
{
    public class LibrosRequestDto
    {

        public string Nombres { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }

        public bool Status { get; set; } = true;
    }
}
