

using Business.Intefaces;
using Business.Services;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Tests.Extentions;

namespace Tests.Business;



public class AccountUserService_Tests(Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory<Program> webApplicationFactory) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory<Program> _webApplicationFactory = webApplicationFactory;

    // WebApplicationFactory<Program> starts up your app in a test environment according to Program.cs, and IClassFixture reuses it in tests;
    // via factory.Services.GetRequiredService you can retrieve services like IAccountUserService – just as the app would in production. //
    private IAccountUserService? _service;
    private UserManager<IdentityUser>? _userManager;
    private RoleManager<IdentityRole>? _roleManager;

    private void SetupServices()
    {
        var factory = new CustomWebApplicationFactory();
        var scope = factory.Services.CreateScope();
        _service = scope.ServiceProvider.GetRequiredService<IAccountUserService>();
        _userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    }

    [Fact]
    public async Task CreateUserAccount_Should_Return_Succeed()
    {
        SetupServices();
        var result = await _service!.CreateUserAccount("Yaarub.n@gmail.com", "Test.123");

        Assert.True(result.Success);
        Assert.NotNull(result.UserId);
    }

    [Fact]
    public async Task ValidateCredentials_Should_return_Succeed()
    {
        SetupServices();
        var create = await _service!.CreateUserAccount("Yaarub@gmail.com", "Test.123");
        var validate = await _service.ValidateCredentials("Yaarub@gmail.com", "Test.123");

        Assert.True(validate.Success);
    }

    [Fact]
    public async Task ValidateCredentials_Should_return_False()
    {
        SetupServices();
        var create = await _service!.CreateUserAccount("Yaarub@gmail.com", "Test.123");
        var validate = await _service.ValidateCredentials("Yaarub@gmail.com", "Test.456");

        Assert.False(validate.Success);
    }

    [Fact]
    public async Task GetAllAccounts__Should_Return_AllAccounts()
    {
        SetupServices();
        await _service!.CreateUserAccount("Yaarub@gmail.com", "Test.123");
        await _service.CreateUserAccount("Hadil@gmail.com", "Test.123");
        await _service.CreateUserAccount("Rashell@gmail.com", "Test.123");

        var result = _service.GetAllAccounts();

        Assert.NotNull(result);
        Assert.True(result.IsCompletedSuccessfully);
    }

    [Fact]
    public async Task GetAccountById__Should_Return_AccountWith_theSameId()
    {
        SetupServices();
        var account = await _service!.CreateUserAccount("Yaarub@gmail.com", "Test.123");

        var result = await _service.GetAccountById(account.UserId!);

        Assert.NotNull(result);
        Assert.True(result.Success);
        Assert.Equal(account.UserId, result.Account!.UserId);
    }

    [Fact]
    public async Task UpdatePhoneNumber__Should_UpdatePhoneNumber_AndReturn_true()
    {
        SetupServices();
        var user = new IdentityUser
        {
            UserName = "Yaarub.nasser@yahoo.com",
            Email = "Yaarub.nasser@yahoo.com",
            PhoneNumber = "0700295829",
            Id = "10"
        };
        var createResult = await _userManager!.CreateAsync(user);

        var updatePhone = await _service!.UpdatePhoneNumber("10", "0736526723");

        var getResult = await _userManager.GetPhoneNumberAsync(user);

        Assert.True(createResult.Succeeded);
        Assert.True(updatePhone.Success);
        Assert.Equal("0736526723", getResult);
    }


    [Fact]
    public async Task DeleteAccount_Should_DeleteAccountAnd_Return_Succeed()
    {
        SetupServices();
        var result = await _service!.CreateUserAccount("Yaarub.n@gmail.com", "Test.123");



        var delete = await _service.DeleteAccount(result.UserId!);
        Assert.True(result.Success);
        Assert.NotNull(result.UserId);
        Assert.True(delete.Success);

        var getUser = await _service.GetAccountById(result.UserId);

        Assert.False(getUser.Success);
    }


    [Fact]
    public async Task UpdateEmail_Should_UpdateEmailAnd_Return_Succeed()
    {
        SetupServices();
        var result = await _service!.CreateUserAccount("Yaarub.n@gmail.com", "Test.123");


        var updateEmail = await _service.UpdateEmail(result.UserId!,"Hadillinda@gmail.com");
        var confirmResult = await _service.ConfirmEmailChange(result.UserId!, "Hadillinda@gmail.com", updateEmail.Token!);



        var getUser = await _service.GetAccountById(result.UserId!);

        Assert.True(getUser.Success);

        Assert.True(result.Success);
        Assert.True(updateEmail.Success);
        Assert.Equal("Hadillinda@gmail.com", getUser.Account!.Email);
        Assert.Equal(result.UserId, getUser.Account.UserId);
    }


    [Fact]
    public async Task ConfirmAccount_Should_ConfirmAccountAnd_Return_Succeed()
    {
        SetupServices();
        var result = await _service!.CreateUserAccount("Yaarub.n@gmail.com", "Test.123");


        var token = await _service.GenerateEmailConfirmationToken("Yaarub.n@gmail.com");
       
        var confirmAccount = await _service.ConfirmAccount(result.UserId!, token.Token!);

        Assert.True(result.Success);
        Assert.True(token.Success);
        Assert.True(confirmAccount.Success);
        Assert.True(token.Success);
        Assert.Equal("Email confirmed successfully", confirmAccount.Message);
  
    }

    [Fact]
    public async Task ResetPassword_Should_ResetPasswordAnd_Return_Succeed()
    {
        SetupServices();
        var result = await _service!.CreateUserAccount("Yaarub.n@gmail.com", "Test.123");


        var passwordResetToken = await _service.GeneratePasswordResetToken("Yaarub.n@gmail.com");
        var confirmResult = await _service.ResetPassword("Yaarub.n@gmail.com", passwordResetToken.Token!,"Test2.456");



        var getUser = await _service.ValidateCredentials("Yaarub.n@gmail.com", "Test2.456");

        Assert.True(confirmResult.Success);

        Assert.True(result.Success);
        Assert.True(passwordResetToken.Success);
    
    }

    [Fact]
    public async Task ExistAsync__Should_Retrurn_TrueIfAccount_Exist()
    {
        SetupServices();
        var user = await _service!.CreateUserAccount("HadilLinda@gmail.com", "Test.123");
        var result = await _service.ExistAsync(user.UserId!);

        Assert.True(user.Success);
        Assert.True(result.Success);
    }

    [Fact]
    public async Task AddUserToRoleAsync__Should_Return_True()
    {

        SetupServices();
        var user = await _service!.CreateUserAccount("HadilLinda@gmail.com", "Test.123");
       

        var addRole = await _roleManager!.CreateAsync(new IdentityRole("Admin"));
        var userRole = await _service.AddUserToRoleAsync(user.UserId!, "Admin");

        var role = await _service.GetRoleAsync(user.UserId!);

        Assert.True(user.Success);
        Assert.True(userRole.Success);
        Assert.Equal(new List<string> { "Admin" }, role.Roles!.ToList());
    }


    [Fact]
    public async Task GetRoleAsync__Should_Return_Role()
    {
        SetupServices();
        var user = await _service!.CreateUserAccount("RashellLinda@gmail.com", "Test.123");


        var addRole = await _roleManager!.CreateAsync(new IdentityRole("Manager"));
        var userRole = await _service.AddUserToRoleAsync(user.UserId!, "Manager");

        var role = await _service.GetRoleAsync(user.UserId!);

        Assert.True(user.Success);
        Assert.True(userRole.Success);
        Assert.Equal(new List<string> { "Manager" }, role.Roles!.ToList());
    }



}
