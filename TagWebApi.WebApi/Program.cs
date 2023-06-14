using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TagWebApi.Domain;
using static ProjectRepository;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder.Services, builder.Configuration);


        // Add services to the container.

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
    }

    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        // Configure AppSettings
        services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        // Configure JWT authentication
        var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();
        var key = Encoding.ASCII.GetBytes(appSettings.Token);
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // Add other services...

        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<IMainTaskRepository, MainTaskRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserCommunicationChannelRepository, UserCommunicationChannelRepository>();
        services.AddScoped<ITaskAssignmentRepository, TaskAssignmentRepository>();
        services.AddScoped<IProjectAssignmentRepository, ProjectAssignmentRepository>();


    }
}
/*
/TagWebApi.Application
    /DTOs
        UserDto.cs
        ProjectDto.cs
        TaskDto.cs
    /Services
    /Interfaces
    /Mappings
        UserProfile.cs
        ProjectProfile.cs
        TaskProfile.cs

/TagWebApi.Domain
    /Entities
    /Interfaces

/TagWebApi.Infrastructure
    /Repositories
    /Data

/TagWebApi.WebApi
    /Controllers
    Program.cs
    Startup.cs

*/