
using Microsoft.EntityFrameworkCore;
using Orders.Data;

//using OrderWebAPI.Models;
var builder = WebApplication.CreateBuilder(args);



// Add services to the container.



builder.Services.AddControllers();



builder.Services.AddDbContext<OrderContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("OrderCon")));



var app = builder.Build();



// Configure the HTTP request pipeline.



app.UseHttpsRedirection();



app.UseAuthorization();



app.MapControllers();



app.Run();

