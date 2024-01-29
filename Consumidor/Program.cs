using Consumidor;
using Consumidor.Data.Contexto;
using Consumidor.Eventos;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using MassTransit.RabbitMqTransport;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;

        var fila = configuration.GetSection("MassTransit")["NomeFila"] ?? string.Empty;
        var servidor = configuration.GetSection("MassTransit")["Servidor"] ?? string.Empty;
        var Usuario = configuration.GetSection("MassTransit")["Usuario"] ?? string.Empty;
        var Senha = configuration.GetSection("MassTransit")["Senha"] ?? string.Empty;

        services.AddHostedService<Worker>();


        services.AddMassTransit((x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(servidor, "/", h =>
                {
                    h.Username(Usuario);
                    h.Password(Senha);
                });

                cfg.ReceiveEndpoint(fila, e =>
                {
                    e.Consumer<UsuarioCriandoConsumidor>();
                });

                cfg.ConfigureEndpoints(context);
            });

            x.AddConsumer<UsuarioCriandoConsumidor>();
        }));
    })
.Build();

await host.RunAsync();
