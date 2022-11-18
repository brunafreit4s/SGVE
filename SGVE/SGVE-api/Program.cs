using Microsoft.EntityFrameworkCore;
using SGVE_models.Context;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add connection configurations
var connection = builder.Configuration.GetConnectionString("SqlServerConnection:SqlServerConnectionString"); 
//var connection = builder.Configuration.GetConnectionString("SqlServerConnection"); 
builder.Services.AddDbContext<SqlContext>(options => options.UseSqlServer(connection));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
