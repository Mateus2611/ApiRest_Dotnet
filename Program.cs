using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TarefasBackEnd.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//adicionando os serviços
builder.Services.AddControllers();

var key = Encoding.ASCII.GetBytes("UmTokenMuitoGrandeEDiferenteParaNinguemDescobrir");

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer( options => {
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("BDTarefas"));

builder.Services.AddTransient<ITarefaRepository, TarefaRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
