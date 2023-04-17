using AutoMapper.Data;
using DriverAdapterSQL;
using DriverAdapterSQL.Gateway;
using DriverAdapterSQL.Repositories;
using EstacolNews.UseCases.Sql.UseCases;
using EstacolNewsSqlServer.Automapper;
using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.ContentCommands;
using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.EditorCommands;
using EstacolNews.UseCases.Sql.Gateway.Repositories.Commands.PublicationCommands;
using EstacolNews.UseCases.Sql.Gateway.IterfacesUseCase.Commands;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
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
builder.Services.AddCors(options =>
{

    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); ;
    });

});





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

app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();

app.Run();
