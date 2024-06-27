using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.DependencyInjection;
using Movies.API.Data;
using System.Drawing.Text;
var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddDbContext<MoviesAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesAPIContext") ?? throw new InvalidOperationException("Connection string 'MoviesAPIContext' not found.")));

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    {
        options.Authority = "https://localhost:7042";
        options.TokenValidationParameters = new()
        {
            ValidateAudience = false
        };
    }
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("clientIdPolicy", policy => policy.RequireClaim("client_id", "movieClient"));
});

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
app.UseRouting();
app.UseAuthentication();    

app.UseAuthorization();

app.MapControllers();

app.Run();


