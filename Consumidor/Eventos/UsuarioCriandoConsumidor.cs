using Core.Model;
using MassTransit;

namespace Consumidor.Eventos
{
    public class UsuarioCriandoConsumidor : IConsumer<Usuario>
    {
        public Task Consume(ConsumeContext<Usuario> context)
        {
           Console.WriteLine($"Usuário consumido: Nome = {context.Message.Nome}");
           return Task.CompletedTask;
        }
    }
}
