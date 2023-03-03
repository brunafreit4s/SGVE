using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SGVE.IdentityServer.Configuration;
using SGVE.IdentityServer.Initializer;
using SGVE.IdentityServer.Models.Sql;
using SGVE.IdentityServer.Models.Sql.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add connection configurations
builder.Services.AddDbContext<SqlContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnectionString")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<SqlContext>().AddDefaultTokenProviders(); /* Injeção de dependência que é utilizana na classe AccountController.cs */

/* Configurações do Scope */
var builderServices = builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.EmitStaticAudienceClaim = true;
})
    .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
    .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
    .AddInMemoryClients(IdentityConfiguration.Clients)
    .AddAspNetIdentity<ApplicationUser>();

/* Adiciona independency injection */
builder.Services.AddScoped<IDbInitializer, DbInitializer>();

builderServices.AddDeveloperSigningCredential();

var app = builder.Build();

/* Declaração do initializer */
var vInitializer = app.Services.CreateScope().ServiceProvider.GetService<IDbInitializer>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection(); 
app.UseStaticFiles();

app.UseRouting();

/* Identity deve ser adicionado aqui */
app.UseIdentityServer();

app.UseAuthorization();

vInitializer.Initialize();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

/* Executa o initializer */

app.Run();
