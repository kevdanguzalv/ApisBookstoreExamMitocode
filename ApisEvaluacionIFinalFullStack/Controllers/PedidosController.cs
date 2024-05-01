using Dto.Request;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace ApisEvaluacionIFinalFullStack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly ILogger<PedidosController> _logger;
        private readonly IPedidosService service;
        public PedidosController(ILogger<PedidosController> logger, IPedidosService service)
        {
            _logger = logger;
            this.service = service;
        }

        [HttpPost]

        public async Task<IActionResult> AddPedido(PedidosRequestDto p)
        {
            var response = await service.AddPedido(p);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string DNI)
        {
            var response = await service.FindPedido(DNI);
            return response != null ? Ok(response) : NotFound(response);
        }
    }
}
