using Entities;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositorie
{
    public class LibrosRepository : RepositoryBase<Libros>, ILibrosRepository
    {
        public LibrosRepository(ApplicationDBContext context) : base(context)
        {

        }
    }
}
