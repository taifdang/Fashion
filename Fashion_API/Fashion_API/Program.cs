using Fashion_API.Model;
using Fashion_API.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//#1_Add database
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));
//#2_Config CORs
builder.Services.AddCors(
     policy => policy.AddPolicy(
         "MYCORs",
         config =>
         {
             config.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
         }
     )          
    );
//#3_Add Scoped
builder.Services.AddScoped<IProductService, ProductService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//#2.1_use CORs

app.UseCors("MYCORs");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
