using Azure;
using Dto;
using Dto.Request;
using Dto.Response;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositorie
{

   
    public class PedidosRepository : IPedidosRepository
    {
        private readonly ApplicationDBContext db;
        private readonly ILogger<PedidosRepository> logger;

        public PedidosRepository(ApplicationDBContext context, ILogger<PedidosRepository> logger)
        {
            this.db = context;
            this.logger = logger;
        }
        public async Task<BaseResponse> AddPedido(PedidosRequestDto pedidos)
        {
            BaseResponse bp = new BaseResponse();


            try
            {
                Clientes clientes = new Clientes();
                clientes = await db.Clientes.FindAsync(pedidos.ClienteId);

                Pedidos p = new Pedidos();
                p.FechaPedido = pedidos.FechaPedido;
                p.Clientes = clientes;

                await db.Pedidos.AddAsync(p);
                await db.SaveChangesAsync();

                var Pedido = await db.Pedidos.OrderByDescending(x => x.Id).FirstOrDefaultAsync();


                List<PedidosDetalle> pd = new List<PedidosDetalle>();

                foreach (var li in pedidos.LibrosId)
                {
                    Libros l = new Libros();
                    l = await db.Libros.FindAsync(li);

                    pd.Add(new PedidosDetalle { Libros = l, Pedidos = Pedido });
                }

                await db.PedidosDetalle.AddRangeAsync(pd);
                await db.SaveChangesAsync();
            }
            catch (Exception ex )
            {

                bp.ErrorMessage = "Ocurrió un error al eliminar la información.";
                logger.LogError(ex, "{ErrorMessage} {Message}", bp.ErrorMessage, ex.Message);
            }
            return bp; 
        }

        public async Task<List<PedidosResponseDto>> FindPedido(string DNI)
        {
            
            List<PedidosResponseDto> response = new List<PedidosResponseDto> ();
            try
            {
               var Pd = await db.PedidosDetalle
                                .Include(x => x.Pedidos)
                                .Include(x => x.Pedidos.Clientes)
                                .Include(x => x.Libros)
                                .Where(x => x.Pedidos.Clientes.DNI == DNI)
                                .ToListAsync();

                foreach (var i in Pd)
                {
                    response.Add(new PedidosResponseDto
                    {
                        Pedido = i.Pedidos.Id,
                        Nombre = i.Pedidos.Clientes.Nombres,
                        Apellidos = i.Pedidos.Clientes.Apellidos,
                        Libro = i.Libros.Nombres,
                        Autor = i.Libros.Autor,
                        ISBN = i.Libros.ISBN,   
                    }); 
                }
                
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{ErrorMessage} {Message}", ex.Message);
            }

            return response;
        }
    }
}
