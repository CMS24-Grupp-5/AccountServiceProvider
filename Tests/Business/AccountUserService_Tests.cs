

using Business.Intefaces;
using Business.Services;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Tests.Business;



public class AccountUserServiceTests : IClassFixture<WebApplicationFactory<Program>>
{

    //chat GPT40 
    // WebApplicationFactory<Program> startar upp din app i testmiljö enligt Program.cs, och IClassFixture återanvänder den i tester;
    // via factory.Services.GetRequiredService får du ut tjänster som t.ex. IAccountUserService – precis som appen själv skulle ha gjort i produktion. //
    private readonly IAccountUserService _service;

    public AccountUserServiceTests(WebApplicationFactory<Program> factory)
    {
        var scope = factory.Services.CreateScope();
        _service = scope.ServiceProvider.GetRequiredService<IAccountUserService>();
    }



    [Fact]
    public async Task CreateUserAccount_Should_Return_Succeed()
    {
        var result= await _service.CreateUserAccount("Yaarub.n@gmail.com","Test.123");


        Assert.True(result.Success);
        Assert.NotNull(result.UserId);
    }


    [Fact]
    public async Task ValidateCredentials_Should_return_Succed()
    {
        var Create= await _service.CreateUserAccount("Yaarub@gmail.com", "Test.123");
        var validate = await _service.ValidateCredentials("Yaarub@gmail.com", "Test.123");

        Assert.True(validate.Success);
       
    }
    [Fact]
    public async Task ValidateCredentials_Should_return_False()
    {
        var Create = await _service.CreateUserAccount("Yaarub@gmail.com", "Test.123");
        var validate = await _service.ValidateCredentials("Yaarub@gmail.com", "Test.456");

        Assert.False(validate.Success);

    }


}