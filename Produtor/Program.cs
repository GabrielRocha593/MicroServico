using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Adicione a configuração da porta aqui
string port = Environment.GetEnvironmentVariable("PORT") ?? "80";
var uri = new UriBuilder("https://0.0.0.0:" + port);
var baseAddress = uri.Uri.ToString();
builder.Configuration["BaseAddress"] = baseAddress;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var configuration = builder.Configuration;
var servidor = Environment.GetEnvironmentVariable("MassTransit__Servidor") ?? "localhost";
var Usuario = Environment.GetEnvironmentVariable("MassTransit__Usuario") ?? "guest";
var Senha = Environment.GetEnvironmentVariable("MassTransit__Senha") ?? "guest";

builder.Services.AddMassTransit((x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(servidor, "/", h => 
        {
            h.Username(Usuario);
            h.Password(Senha);
        });

        cfg.ConfigureEndpoints(context);
    });
}));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
