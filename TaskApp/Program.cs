using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using TaskApp.Infrastructure.Filters;
using TaskApp.Infrastructure.Data;
using TaskApp.Core.Interfaces;
using TaskApp.Infrastructure.Repositories;
using TaskApp.Core.Services;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
    options.Filters.Add(typeof(FilterOfExcepcion));
});

// Cadena de Conexión para MySql
builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"))
);

// Dependencias propias - (Inyeccion de dependencias)
builder.Services.AddTransient<ITaskRepository, TaskRepository>();
builder.Services.AddTransient<ITaskService, TaskService>();


//   Para la configuración del Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Task.Api", Version = "v1" });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

// Validaciones y Filtros
builder.Services.AddMvc(options => { }
).AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});

builder.Services.AddCors();


var app = builder.Build();
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

// Configure the HTTP request pipeline.  IWebHostEnvironment
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task.Api v1"));


app.UseHttpsRedirection();

app.MapControllers();

app.Run();
