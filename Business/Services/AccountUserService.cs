using Business.Intefaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class AccountUserService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) : IAccountUserService
{
    private readonly UserManager<IdentityUser> _userManager = userManager;
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;

    public async Task<CreateResponseResult> CreateUserAccount(string email, string password, string roleName = "user")
    {
        var user = new IdentityUser { Email = email, UserName = email };
        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            await AddUserToRoleAsync(user.Id, roleName);
        }

        return new CreateResponseResult
        {
            UserId = user.Id,
            Success = result.Succeeded,
            Message = result.Succeeded ? "User created successfully" : string.Join(", ", result.Errors.Select(e => e.Description)),
            StatusCode = result.Succeeded ? 201 : 400
        };
    }

    public async Task<BaseResponseResult> ValidateCredentials(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return new BaseResponseResult { Success = false, Message = "User not found", StatusCode = 404 };

        if (await _userManager.CheckPasswordAsync(user, password))
            return new CreateResponseResult { Success = true, Message = "Login Successful", UserId = user.Id, StatusCode = 200 };

        return new BaseResponseResult { Success = false, Message = "Invalid password", StatusCode = 401 };
    }

    public async Task<AccountListResponse> GetAllAccounts()
    {
        var users = await _userManager.Users.ToListAsync();
        return new AccountListResponse
        {
            Success = true,
            Message = users.Count > 0 ? "Users retrieved successfully" : "No users found",
            Accounts = users.Select(u => new AccountDto
            {
                UserId = u.Id,
                Email = u.Email!,
                UserName = u.UserName,
                PhoneNumber = u.PhoneNumber
            }).ToList(),
            StatusCode = 200
        };
    }

    public async Task<AccountResponse> GetAccountById(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return new AccountResponse { Success = false, Message = "User not found", StatusCode = 404 };

        return new AccountResponse
        {
            Success = true,
            Message = "User retrieved successfully",
            Account = new AccountDto
            {
                UserId = user.Id,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName
            },
            StatusCode = 200
        };
    }

    public async Task<BaseResponseResult> UpdatePhoneNumber(string userId, string phoneNumber)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return new BaseResponseResult { Success = false, Message = "User not found", StatusCode = 404 };

        if (!string.Equals(phoneNumber, user.PhoneNumber, StringComparison.Ordinal))
            user.PhoneNumber = phoneNumber;

        var result = await _userManager.UpdateAsync(user);
        return new BaseResponseResult
        {
            Success = result.Succeeded,
            Message = result.Succeeded ? "Phone number updated successfully" : string.Join(", ", result.Errors.Select(e => e.Description)),
            StatusCode = result.Succeeded ? 200 : 400
        };
    }

    public async Task<BaseResponseResult> DeleteAccount(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return new BaseResponseResult { Success = false, Message = "User not found", StatusCode = 404 };

        var result = await _userManager.DeleteAsync(user);
        return new BaseResponseResult
        {
            Success = result.Succeeded,
            Message = result.Succeeded ? "User deleted successfully" : string.Join(", ", result.Errors.Select(e => e.Description)),
            StatusCode = result.Succeeded ? 200 : 400
        };
    }

    public async Task<TokenResponseResult> UpdateEmail(string userId, string newEmail)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return new TokenResponseResult { Success = false, Message = "User not found", StatusCode = 404 };

        if (string.Equals(newEmail, user.Email, StringComparison.Ordinal))
            return new TokenResponseResult { Success = false, Message = "New email cannot be the same as current", StatusCode = 400 };

        var token = await _userManager.GenerateChangeEmailTokenAsync(user, newEmail);
        return new TokenResponseResult { Success = true, Message = "Token generated", Token = token, StatusCode = 200 };
    }

    public async Task<BaseResponseResult> ConfirmEmailChange(string userId, string newEmail, string token)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return new BaseResponseResult { Success = false, Message = "User not found", StatusCode = 404 };

        var result = await _userManager.ChangeEmailAsync(user, newEmail, token);
        return new BaseResponseResult
        {
            Success = result.Succeeded,
            Message = result.Succeeded ? "Email changed successfully" : string.Join(", ", result.Errors.Select(e => e.Description)),
            StatusCode = result.Succeeded ? 200 : 400
        };
    }

    public async Task<BaseResponseResult> ConfirmAccount(string userId, string token)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return new BaseResponseResult { Success = false, Message = "User not found", StatusCode = 404 };

        if (await _userManager.IsEmailConfirmedAsync(user))
            return new BaseResponseResult { Success = true, Message = "Account already confirmed", StatusCode = 200 };

        var result = await _userManager.ConfirmEmailAsync(user, token);
        return new BaseResponseResult
        {
            Success = result.Succeeded,
            Message = result.Succeeded ? "Email confirmed successfully" : string.Join(", ", result.Errors.Select(e => e.Description)),
            StatusCode = result.Succeeded ? 200 : 400
        };
    }

    public async Task<TokenResponseResult> GeneratePasswordResetToken(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return new TokenResponseResult { Success = false, Message = "User not found", StatusCode = 404 };

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        return new TokenResponseResult { Success = true, Message = "Token generated", Token = token, StatusCode = 200 };
    }

    public async Task<BaseResponseResult> ResetPassword(string email, string token, string newPassword)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return new BaseResponseResult { Success = false, Message = "User not found", StatusCode = 404 };

        var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
        return new BaseResponseResult
        {
            Success = result.Succeeded,
            Message = result.Succeeded ? "Password reset successfully" : string.Join(", ", result.Errors.Select(e => e.Description)),
            StatusCode = result.Succeeded ? 200 : 400
        };
    }

    public async Task<TokenResponseResult> GenerateEmailConfirmationToken(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return new TokenResponseResult { Success = false, Message = "User not found", StatusCode = 404 };

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        return new TokenResponseResult { Success = true, Message = "Token generated", Token = token, StatusCode = 200 };
    }

    public async Task<BaseResponseResult> ExistAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        return user == null
            ? new BaseResponseResult { Success = false, Message = "User not found", StatusCode = 404 }
            : new BaseResponseResult { Success = true, Message = "User exists", StatusCode = 200 };
    }

    public async Task<BaseResponseResult> AddUserToRoleAsync(string userId, string roleName)
    {
        var roleExists = await _roleManager.RoleExistsAsync(roleName);
        if (!roleExists)
            return new BaseResponseResult { Success = false, Message = "Role does not exist", StatusCode = 404 };

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return new BaseResponseResult { Success = false, Message = "User does not exist", StatusCode = 404 };

        var userRoles = await _userManager.GetRolesAsync(user);
        if (userRoles.Contains(roleName))
            return new BaseResponseResult { Success = true, StatusCode = 200 };

        var roleResult = await _userManager.AddToRoleAsync(user, roleName);
        return new BaseResponseResult
        {
            Success = roleResult.Succeeded,
            Message = roleResult.Succeeded ? "Role assigned" : "Failed to assign role",
            StatusCode = roleResult.Succeeded ? 200 : 400
        };
    }

    public async Task<RoleResponse<string>> GetRoleAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return new RoleResponse<string> { Success = false, Message = "User not found", Roles = [], StatusCode = 404 };

        var roles = await _userManager.GetRolesAsync(user);
        return new RoleResponse<string> { Success = true, Message = "Roles retrieved successfully", Roles = roles.ToList(), StatusCode = 200 };
    }
}
