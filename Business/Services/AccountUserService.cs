using Business.Intefaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class AccountUserService(UserManager<IdentityUser> userManager) : IAccountUserService
{
    private readonly UserManager<IdentityUser> _userManager = userManager;

    public async Task<CreateResponseResult> CreateUserAccount(string email, string password)
    {
        var user = new IdentityUser { Email = email, UserName = email };
        var result = await _userManager.CreateAsync(user, password);

        return new CreateResponseResult
        {
            UserId = user.Id,
            Success = result.Succeeded,
            Message = result.Succeeded ? "User created successfully" : string.Join(", ", result.Errors.Select(e => e.Description))
        };
    }

    public async Task<BaseResponseResult> ValidateCredentials(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return new BaseResponseResult { Success = false, Message = "User not found" };

        if (await _userManager.CheckPasswordAsync(user, password))
            return new CreateResponseResult { Success = true, Message = "Login Successful", UserId = user.Id };

        return new BaseResponseResult { Success = false, Message = "Invalid password" };
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
            }).ToList()
        };
    }

    public async Task<AccountResponse> GetAccountById(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return new AccountResponse { Success = false, Message = "User not found" };

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
            }
        };
    }

    public async Task<BaseResponseResult> UpdatePhoneNumber(string userId, string phoneNumber)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return new BaseResponseResult { Success = false, Message = "User not found" };

        if (!string.Equals(phoneNumber, user.PhoneNumber, StringComparison.Ordinal))
            user.PhoneNumber = phoneNumber;

        var result = await _userManager.UpdateAsync(user);
        return new BaseResponseResult
        {
            Success = result.Succeeded,
            Message = result.Succeeded ? "Phone number updated successfully" : string.Join(", ", result.Errors.Select(e => e.Description))
        };
    }

    public async Task<BaseResponseResult> DeleteAccount(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return new BaseResponseResult { Success = false, Message = "User not found" };

        var result = await _userManager.DeleteAsync(user);
        return new BaseResponseResult
        {
            Success = result.Succeeded,
            Message = result.Succeeded ? "User deleted successfully" : string.Join(", ", result.Errors.Select(e => e.Description))
        };
    }

    public async Task<TokenResponseResult> UpdateEmail(string userId, string newEmail)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return new TokenResponseResult { Success = false, Message = "User not found" };

        if (string.Equals(newEmail, user.Email, StringComparison.Ordinal))
            return new TokenResponseResult { Success = false, Message = "New email cannot be the same as current" };

        var token = await _userManager.GenerateChangeEmailTokenAsync(user, newEmail);
        return new TokenResponseResult { Success = true, Message = "Token generated", Token = token };
    }

    public async Task<BaseResponseResult> ConfirmEmailChange(string userId, string newEmail, string token)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return new BaseResponseResult { Success = false, Message = "User not found" };

        var result = await _userManager.ChangeEmailAsync(user, newEmail, token);
        return new BaseResponseResult
        {
            Success = result.Succeeded,
            Message = result.Succeeded ? "Email changed successfully" : string.Join(", ", result.Errors.Select(e => e.Description))
        };
    }

    public async Task<BaseResponseResult> ConfirmAccount(string userId, string token)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return new BaseResponseResult { Success = false, Message = "User not found" };

        if (await _userManager.IsEmailConfirmedAsync(user))
            return new BaseResponseResult { Success = true, Message = "Account already confirmed" };

        var result = await _userManager.ConfirmEmailAsync(user, token);
        return new BaseResponseResult
        {
            Success = result.Succeeded,
            Message = result.Succeeded ? "Email confirmed successfully" : string.Join(", ", result.Errors.Select(e => e.Description))
        };
    }

    public async Task<TokenResponseResult> GeneratePasswordResetToken(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return new TokenResponseResult { Success = false, Message = "User not found" };

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        return new TokenResponseResult { Success = true, Message = "Token generated", Token = token };
    }

    public async Task<BaseResponseResult> ResetPassword(string email, string token, string newPassword)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return new BaseResponseResult { Success = false, Message = "User not found" };

        var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
        return new BaseResponseResult
        {
            Success = result.Succeeded,
            Message = result.Succeeded ? "Password reset successfully" : string.Join(", ", result.Errors.Select(e => e.Description))
        };
    }

    public async Task<TokenResponseResult> GenerateEmailConfirmationToken(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return new TokenResponseResult { Success = false, Message = "User not found" };

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        return new TokenResponseResult { Success = true, Message = "Token generated", Token = token };
    }

    public async Task<BaseResponseResult> ExistAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)   
            return new BaseResponseResult { Success = false, Message = "User not found" };
        return new BaseResponseResult { Success = true, Message = "User exists" };
    }

}
