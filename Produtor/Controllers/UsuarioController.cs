using Core.Model;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Buffers;
using System.Text;
using System.Text.Json;

namespace Produtor.Controllers
{
    [ApiController]
    [Route("/Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IBus _Bus;
        private readonly IConfiguration _Configuration;

        public UsuarioController(IBus bus, IConfiguration configuration)
        {
            _Bus = bus;
            _Configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(Usuario usuario)
        {
            var nameQueue = _Configuration.GetSection("MassTransit")["NomeFila"] ?? string.Empty;

            var endpoint = await _Bus.GetSendEndpoint(new Uri($"queue:{nameQueue}"));

            await endpoint.Send(usuario);

            return Ok();
        }
    }
}
