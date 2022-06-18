using FluentValidation.AspNetCore;
using WebApiMongoDB.Models;
using WebApiMongoDB.Services;
using WebApiMongoDB.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<CadastroDatabaseSettings>
    (builder.Configuration.GetSection("DevNetStoreDatabase"));

builder.Services.AddSingleton<CadastroServices>();

builder.Services.AddControllers();

builder.Services.AddControllers()
    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<AddStudentValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
