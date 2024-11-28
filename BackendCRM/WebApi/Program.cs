using Infrastructure.AppDbContext;
using Infrastructure.Commands;
using Infrastructure.Querys;
using Microsoft.EntityFrameworkCore;

using System.Text.Json.Serialization;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Build.Execution;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

using Application.UseCase;
using Application.Interfaces.Client;
using Application.Interfaces.CampaignType;
using Application.Interfaces.Interaction;
using Application.Interfaces.InteractionType;
using Application.Interfaces.Project;
using Application.Interfaces.Tasks;
using Application.Interfaces.TaskStatus;
using Application.Interfaces.User;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 39))));
builder.Services.AddScoped<IProjectServices, ProjectServices>();
builder.Services.AddScoped<IProjectQuery, ProjectQuery>();
builder.Services.AddScoped<IProjectCommand, ProjectCommand>();

builder.Services.AddScoped<IClientService, ClientServices>();
builder.Services.AddScoped<IClientQuery, ClientQuery>();
builder.Services.AddScoped<IClientCommand, ClientCommand>();

builder.Services.AddScoped<ITaskService, TaskServices>();
builder.Services.AddScoped<ITaskCommand, TaskCommand>();
builder.Services.AddScoped<ITaskQuery, TaskQuery>();

builder.Services.AddScoped<IInteractionService, InteractionServices>();
builder.Services.AddScoped<IInteractionCommand, InteractionCommand>();
builder.Services.AddScoped<IInteractionQuery, InteractionQuery>();

builder.Services.AddScoped<IInteractionTypeService, InteractionTypeServices>();
builder.Services.AddScoped<IInteractionTypeQuery, InteractionTypeQuery>();

builder.Services.AddScoped<IUserService, UserServices>();
builder.Services.AddScoped<IUserQuery, UserQuery>();

builder.Services.AddScoped<ITaskStatusService, TaskStatusServices>();
builder.Services.AddScoped<ITaskStatusQuery, TaskStatusQuery>();

builder.Services.AddScoped<ICampaignTypeService, CampaignTypeServices>();
builder.Services.AddScoped<ICampaignTypeQuery, CampaignTypeQuery>();



builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Marketing CRM", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
