

using Business.Intefaces;
using Business.Services;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Presentation.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();



if(builder.Environment.IsDevelopment())
{
    var inMemoryDb=Guid .NewGuid().ToString();
    builder.Services.AddDbContext<DataContext>(x => x.UseInMemoryDatabase(inMemoryDb));
}
else
{
    builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}



builder.Services.AddScoped<IAccountUserService, AccountUserService>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedEmail = true;  
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();



var app = builder.Build();

app.MapGrpcService<GrpcService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

app.Run();

//ChatGpt 4o Det för att Tests ska kunna hitta Program klassen.
public partial class Program { }