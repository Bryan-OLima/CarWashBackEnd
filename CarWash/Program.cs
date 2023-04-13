using CarWash.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("ConnectionMYSQL");

builder.Services.AddDbContext<CarWashDbContext>(options => options.UseMySql(
    connectionString,
    ServerVersion.Parse("8.0.32-MySQL")
    )
);

builder.Services.AddCors(options => 
    options.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .WithMethods("POST", "GET", "PUT", "DELETE")
        .AllowAnyHeader();
    })
    );
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

app.UseCors(builder => builder.WithOrigins("http://localhost:4200/").WithMethods("POST", "GET", "PUT", "DELETE").AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
