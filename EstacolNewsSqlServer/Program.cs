using AutoMapper.Data;
using DriverAdapterSQL;
using DriverAdapterSQL.Gateway;
using DriverAdapterSQL.Repositories;
using EstacolNews.UseCases.Sql.UseCases;
using EstacolNewsSqlServer.Automapper;
using EstacolNews.UseCases.Sql.Gateway;
using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.ContentCommands;
using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.EditorCommands;
using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.PublicationCommands;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(ConfigurationProfile));


builder.Services.AddScoped<IEditorUseCase, EditorUseCase>();
builder.Services.AddScoped<IEditorRepository, EditorRepository>();
builder.Services.AddScoped<IContentUseCase, ContentUseCase>();
builder.Services.AddScoped<IContentRepository, ContentRepository>();
builder.Services.AddScoped<IPublicationUseCase, PublicationUseCase>();
builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();





builder.Services.AddTransient<IDbConnectionBuilder>(e =>
{
    return new DbConnectionBuilder(builder.Configuration.GetConnectionString("DefaultConnection"));
});


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
