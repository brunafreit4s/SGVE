using SGVE_web.Services;
using SGVE_web.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Injetando a classe Funcionario
builder.Services.AddHttpClient<IFuncionarioService, FuncionarioService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ServicesUrls:SGVEApi"])
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
