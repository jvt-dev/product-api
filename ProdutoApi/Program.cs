using Microsoft.EntityFrameworkCore;
using ProdutoApi.Infraestructure.Context;
using ProdutoApi.Infraestructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddServices();
builder.Services.AddDbContext<ProductContext>(
                options => options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase")));

var app = builder.Build();
app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
