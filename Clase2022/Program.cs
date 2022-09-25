using Clase2022.Entities;
using Clase2022.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DataBaseSettings>(
builder.Configuration.GetSection("ApiTasksDatabase"));

builder.Services.AddSingleton<TasksService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
