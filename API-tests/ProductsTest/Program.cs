using Microsoft.EntityFrameworkCore;
using ProductsTest.Domains;
using ProductsTest;
using ProductsTest.Context;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductsTestContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlDataBase"));
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Products",
        Description = "Backend API",
        Contact = new OpenApiContact
        {
            Name = "ProductsTest"
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();