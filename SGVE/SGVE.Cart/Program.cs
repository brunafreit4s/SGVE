using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SGVE.Cart.Config;
using SGVE.Cart.Models.Context;
using Swashbuckle.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

/* Adiciona autenticação */ /* Configurações de segurança (relação 1-1) */
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = builder.Configuration["ServicesUrls:IdentityServer"];
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateAudience = false
        };
    });

/* Adiciona política de autorização */ /* Configurações de segurança (relação 1-1) */
builder.Services.AddAuthorization(options => {
    options.AddPolicy("ApiScope", policy => {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "scopeSGVE");
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
//builder.Services.AddScoped<IProdutosRepository, ProdutosRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "SGVE - Sistema Gerenciador de Vendas e Estoque", Version = "0.1" });
    c.EnableAnnotations();
    /* pop-up que solicita as configurações de segurança */
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = @"Enter 'Bearer' [space] and your token!",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {{
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header
        },
        new List<string>()}
    });
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
