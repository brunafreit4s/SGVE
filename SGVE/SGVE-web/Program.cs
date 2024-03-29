using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Logging;
using SGVE_web.Services;
using SGVE_web.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/* Adiciona autenticação */ /* Configurações de segurança (relação 1-1) */
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc"; // oidc = open id conection
})
    .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
    .AddOpenIdConnect("oidc", options => {
        options.Authority = builder.Configuration["ServicesUrls:IdentityServer"];
        options.GetClaimsFromUserInfoEndpoint = true;
        options.ClientId = "scopeSGVE"; /* ClientId criada em IdentityConfiguration */
        options.ClientSecret = "my_super_scret"; /* ClientSecret criada em IdentityConfiguration */
        options.ResponseType = "code";
        options.ClaimActions.MapJsonKey("role", "role", "role");
        options.ClaimActions.MapJsonKey("sub", "sub", "sub");
        options.TokenValidationParameters.NameClaimType = "name";
        options.TokenValidationParameters.RoleClaimType = "role";
        options.Scope.Add("scopeSGVE");
        options.SaveTokens = true;
    });

//Injetando a classe Funcionario
builder.Services.AddHttpClient<IFuncionarioService, FuncionarioService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ServicesUrls:SGVEApi"])
);

//Injetando a classe Produtos
builder.Services.AddHttpClient<IProdutosService, ProdutosService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ServicesUrls:SGVEApi"])
);

//Injetando a classe Vendas
builder.Services.AddHttpClient<IVendasService, VendasService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ServicesUrls:CartApi"])
);

//Injetando a classe Carrinho
builder.Services.AddHttpClient<ICarrinhoService, CarrinhoService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ServicesUrls:CartApi"])
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    IdentityModelEventSource.ShowPII = true;
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

/* inicializa configurações de autenticação */
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
