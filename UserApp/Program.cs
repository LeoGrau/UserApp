using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UserApp.Shared.Domain.Repositories;
using UserApp.Shared.Persistence.Context;
using UserApp.Shared.Persistence.Repositories;
using UserApp.UserApp.Authorization.Handlers.Implementations;
using UserApp.UserApp.Authorization.Handlers.Interfaces;
using UserApp.UserApp.Authorization.Middleware;
using UserApp.UserApp.Authorization.Settings;
using UserApp.UserApp.Domain.Models;
using UserApp.UserApp.Domain.Repositories;
using UserApp.UserApp.Domain.Services;
using UserApp.UserApp.Mapping;
using UserApp.UserApp.Repositories;
using UserApp.UserApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//AppSettings Configuration
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
//Open API Configuration
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v0", new OpenApiInfo
        {
            Version = "v0",
            Title = "UserApp API",
            Description = "UserApp v0. Just for testing some tools 💥"
        });
    }
);

//Connection String 
var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");

//Adding DbContext with Connection String
builder.Services.AddDbContext<AppDbContext>(
    optionsBuilder =>
    {
        optionsBuilder.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    });

//Lowercase Urls configuration
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// CORS Service addition
builder.Services.AddCors();

//Adding Scoped Services
//UserApp Services
//--User-- |Services and Repositories|
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
//--JwtHandler-- For Security
builder.Services.AddScoped<IJwtHandler, JwtHandler>();
//Shared Services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//--Inheritance
//--User--
builder.Services.AddScoped<IBaseRepository<User, long>, BaseRepository<User, long>>();
//Automapper Service
builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile));

var app = builder.Build();

//Validation for ensuring database tables are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context?.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v0/swagger.json", "v0");
        options.RoutePrefix = "swagger";
    });
}

// Set Middlewares
// Configure JwtMiddleware to intercepts every Http Request
app.UseMiddleware<JwtMiddleware>();
// Configure ErrorHandlingMiddleware for JwtMiddleware
app.UseMiddleware<ErrorHandlerMiddleware>();


//Using CORS
app.UseCors(corsPolicyBuilder => 
    corsPolicyBuilder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();