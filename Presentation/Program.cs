using Business.Intefaces;
using Business.Services;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Services;

var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.ListenLocalhost(5001, listenOptions =>
//    {
//        listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
//        listenOptions.UseHttps();
//    });
//});

builder.Services.AddGrpc();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment())
{
    var inMemoryDb = Guid.NewGuid().ToString();
    builder.Services.AddDbContext<DataContext>(x => x.UseInMemoryDatabase(inMemoryDb));
}
else
{
    builder.Services.AddDbContext<DataContext>(x =>
          x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

}

builder.Services.AddIdentity<IdentityUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedEmail = true;
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();


builder.Services.AddScoped<IAccountUserService, AccountUserService>();

var app = builder.Build();


app.MapGrpcService<GrpcService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");
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
