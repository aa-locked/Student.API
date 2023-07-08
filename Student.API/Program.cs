using Microsoft.EntityFrameworkCore;
using Student.API.Data;
using Student.API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Injecting DBContext



builder.Services.AddDbContext<StudentDBContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("dbCon")));



builder.Services.AddControllers();

builder.Services.AddScoped<IStudent,SQLStudent>();

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
