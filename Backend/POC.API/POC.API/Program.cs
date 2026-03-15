using Microsoft.EntityFrameworkCore;
using POC.API.Infrastructure.Data;
using POC.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MyAllowAllOrigins = "_myAllowAllOrigins";
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowAllOrigins,
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    }
    );
});



var app = builder.Build();


app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();

app.MapControllers();

app.Run();
