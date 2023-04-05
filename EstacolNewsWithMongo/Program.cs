using AutoMapper.Data;
using DriverAdapterMongo;
using DriverAdapterMongo.Interfaces;
using DriverAdapterMongo.Repositories;
using EstacolNews.UseCases.NoSql.Gateway;
using EstacolNews.UseCases.NoSql.Gateway.Repositories.Commands;
using EstacolNews.UseCases.NoSql.UseCases;
using EstacolNewsWithMongo.Automapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(ConfigurationProfile));


builder.Services.AddScoped<IUserUseCase, UserUseCase>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddSingleton<IContext>(provider => new Context(builder.Configuration.GetConnectionString("urlConnection"), "EstacolNews"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
