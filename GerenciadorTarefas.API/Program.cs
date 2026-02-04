using GerenciadorTarefas.Application.UseCases.Task.Delete;
using GerenciadorTarefas.Application.UseCases.Task.GetAll;
using GerenciadorTarefas.Application.UseCases.Task.GetById;
using GerenciadorTarefas.Application.UseCases.Task.Register;
using GerenciadorTarefas.Application.UseCases.Task.Update;
using GerenciadorTarefas.Communication.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

builder.Services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();
builder.Services.AddScoped<RegisterTaskUseCase>();
builder.Services.AddScoped<GetAllTasksUseCase>();
builder.Services.AddScoped<GetTaskByIdUseCase>();
builder.Services.AddScoped<UpdateTaskUseCase>();
builder.Services.AddScoped<DeleteTaskUseCase>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "Gerenciador de Tarefas API",
        Version = "v1",
        Description = "API REST para gerenciamento de tarefas.."
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Gerenciador de Tarefas API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
