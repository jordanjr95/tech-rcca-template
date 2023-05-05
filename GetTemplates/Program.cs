using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using GetTemplates.Context;
using GetTemplates.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("corsapp",
                      policy =>
                      {
                          policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                      });
});

builder.Services.AddDbContext<TemplateContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
//{
//    builder.WithOrigins("https://localhost:7209/api").AllowAnyMethod().AllowAnyHeader();
//}));



var app = builder.Build();


app.UseCors("corsapp");
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
