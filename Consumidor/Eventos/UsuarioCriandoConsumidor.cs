using Core.Model;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumidor.Eventos
{
    public class UsuarioCriandoConsumidor : IConsumer<Usuario>
    {
        public Task Consume(ConsumeContext<Usuario> context)
        {
            Console.WriteLine(context.Message.Id + " - " + context.Message.Nome);
            return Task.CompletedTask;
        }
    }
}
