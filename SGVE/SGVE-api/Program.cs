using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SGVE_api.Config;
using SGVE_api.Repository;
using SGVE_models.Context;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

/* Adiciona autenticação */ /* Configurações de segurança (relação 1-1) */
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:4430/";
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateAudience = false
        };
    });

/* Adiciona política de autorização */ /* Configurações de segurança (relação 1-1) */
builder.Services.AddAuthorization(options => {
    options.AddPolicy("ApiScope", policy => {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "SGVE");
    });
});

// Add connection configurations
builder.Services.AddDbContext<SqlContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnectionString")));

/* Add configurations mapper */
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

/* Add Injection repository */
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "SGVE - Sistema Gerenciador de Vendas e Estoque" });
});

var app = builder.Build();

//var dbInicitializeService = app.Services.CreateScope().ServiceProvider.GetService<IFuncionarioRepository>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

/* inicializa configurações de autenticação */
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
