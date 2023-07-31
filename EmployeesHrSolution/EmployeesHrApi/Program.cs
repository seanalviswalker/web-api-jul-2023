// This is main .net
using EmployeesHrApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var employeesConnectionString = builder.Configuration.GetConnectionString("employees") ?? throw new Exception("Need a Connection String");

builder.Services.AddDbContext<EmployeeDataContext>(options =>
{
    options.UseSqlServer(employeesConnectionString);
});

// above this is configureation for the "behind the scenes" thing in your API
var app = builder.Build();
// after this is setting up "Middleware" that's the code that recieves the HTTP Request and makes the response

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers(); // When we are doing "Controller Based" APIs, this is where it creates the "lookup table" (route table)

app.Run(); // this is when our api is up and running
