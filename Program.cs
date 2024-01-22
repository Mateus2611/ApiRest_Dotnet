using Microsoft.EntityFrameworkCore;
using TarefasBackEnd.Repositories;

var builder = WebApplication.CreateBuilder(args);

//adicionando os serviços
builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("BDTarefas"));

builder.Services.AddTransient<ITarefaRepository, TarefaRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();
