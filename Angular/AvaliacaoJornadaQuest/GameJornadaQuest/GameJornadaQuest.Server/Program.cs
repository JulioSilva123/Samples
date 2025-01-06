//using GameJornadaQuest.Server.Repositorio;
using GameJornadaQuest.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.SignalR;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<db_jornadaquest>(Opcoes => Opcoes.UseSqlServer(builder.Configuration.GetConnectionString("db_jornadaquest")));

builder.Services.AddCors();


builder.Services.AddSignalR(); //signalR ? kullanmak için servis olarak ekliyoruz


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(opcoes => opcoes.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();




app.UseSignalR(routes =>
{
    routes.MapHub<RodadasHub>("/RodadasHub");
});




app.MapFallbackToFile("/index.html");

app.Run();
