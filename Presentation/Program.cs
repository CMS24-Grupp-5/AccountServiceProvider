using Business.Intefaces;
using Business.Services;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Presentation.Services;



var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5001, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
        listenOptions.UseHttps();
    });
});

builder.Services.AddGrpc();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AccountService API", Version = "v1" });


    var apiScheme = new OpenApiSecurityScheme
    {
        Name = "x-Api-Key",
        Description = "Ange giltig API-nyckel",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme",
        Reference = new OpenApiReference
        {
            Id = "ApiKey",
            Type = ReferenceType.SecurityScheme
        }
    };
    c.AddSecurityDefinition("ApiKey", apiScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { apiScheme, Array.Empty<string>() }
    });
});

//if (builder.Environment.IsDevelopment())
//{
//    var inMemoryDb = Guid.NewGuid().ToString();
//    builder.Services.AddDbContext<DataContext>(x => x.UseInMemoryDatabase(inMemoryDb));
//}
//else
//{
//}


builder.Services.AddDbContext<DataContext>(x =>
      x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddIdentity<IdentityUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedEmail = true;
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();


builder.Services.AddScoped<IAccountUserService, AccountUserService>();

var app = builder.Build();


app.MapGrpcService<GrpcService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.").ExcludeFromDescription();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Ventixe AuthServiceProvider API");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.Run();

public partial class Program { }
