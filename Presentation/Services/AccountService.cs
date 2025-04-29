using Grpc.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Services;

public class AccountService(UserManager<IdentityUser> userManager) : AccountGrpcService.AccountGrpcServiceBase
{
    private readonly UserManager<IdentityUser> _userManager = userManager;

    public override async Task<CreateAccountReply> CreateAccount(CreateAccountRequest request, ServerCallContext context)
    {
        var user = new IdentityUser
        {
            UserName = request.Email,
            Email = request.Email,
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        var reply = new CreateAccountReply
        {
            Succeeded = result.Succeeded,
            Message = result.Succeeded ? "User created successfully" : string.Join(", ", result.Errors.Select(e => e.Description))
        };

        if (!result.Succeeded)
        {
            reply.UserId = user.Id;
        }

        return reply;
    }



    public override async Task<ValidateCredentialsReply> ValidateCredentials(ValidateCredentialsRequest request, ServerCallContext context)
    {
        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
        {
            return new ValidateCredentialsReply
            {
                Succeeded = false,
                Message = "Email and password cannot be empty"
            };
        }

        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            return new ValidateCredentialsReply
            {
                Succeeded = false,
                Message = "User not found"
            };
        }

        var isValid = await _userManager.CheckPasswordAsync(user, request.Password);
        if (isValid)
        {
            return new ValidateCredentialsReply
            {
                Succeeded = true,
                Message = "Login Successful",
                UserId = user.Id
            };
        }
        else
        {
            return new ValidateCredentialsReply
            {
                Succeeded = false,
                Message = "Invalid password"
            };
        }


    }

    public override async Task<GetAccountsReply> GetAccounts(GetAccountsRequest request, ServerCallContext context)
    {
        var users = await _userManager.Users.ToListAsync();

        var reply = new GetAccountsReply()
        {
            Succeeded = true,
            Message = users.Count > 0 ? "Users retrieved successfully" : "No users found"
        };

        foreach (var user in users)
        {
            reply.Accounts.Add(new Account
            {
                UserId = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
            });
        }

        return reply;
    }

    public override async Task<GetAccountByIdReply> GetAccountById(GetAccountByIdRequest request, ServerCallContext context)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);

        if (user == null)
        {
            return new GetAccountByIdReply
            {
                Succeeded = false,
                Message = "User not found"
            };
        }

        var reply = new GetAccountByIdReply
        {
            Succeeded = true,
            Message = "User retrieved successfully",
            Account = new Account
            {
                UserId = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            }
        };

        return reply;

    }

    public override async Task<UpdatePhoneNumberReply> UpdatePhoneNumber(UpdatePhoneNumberRequest request, ServerCallContext context)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null)
        {
            return new UpdatePhoneNumberReply
            {
                Succeeded = false,
                Message = "User not found"
            };
        }
        if (!string.Equals(request.PhoneNumber, user.PhoneNumber, StringComparison.Ordinal))

            user.PhoneNumber = request.PhoneNumber;


        var result = await _userManager.UpdateAsync(user);
        return new UpdatePhoneNumberReply
        {
            Succeeded = result.Succeeded,
            Message = result.Succeeded ? "Phone number updated successfully" : string.Join(", ", result.Errors.Select(e => e.Description))
        };
    }

    public override async Task<DeleteAccountReply> DeleteAccount(DeleteAccountRequest request, ServerCallContext context)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);

        if (user == null)
        {
            return new DeleteAccountReply
            {
                Succeeded = false,
                Message = "User not found"
            };
        }

        var result = await _userManager.DeleteAsync(user);
        return new DeleteAccountReply
        {
            Succeeded = result.Succeeded,
            Message = result.Succeeded ? "User deleted successfully" : string.Join(", ", result.Errors.Select(e => e.Description))
        };

    }

    public override async Task<ConfirmAccountReply> ConfirmAccount(ConfirmAccountRequest request, ServerCallContext context)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null)
        {
            return new ConfirmAccountReply
            {
                Succeeded = false,
                Message = "User not found"
            };
        }

        if (await _userManager.IsEmailConfirmedAsync(user))
        {
            return new ConfirmAccountReply
            {
                Succeeded = true,
                Message = "Account is already confirmed"
            };
        }

        var result = await _userManager.ConfirmEmailAsync(user, request.Token);
        return new ConfirmAccountReply
        {
            Succeeded = result.Succeeded,
            Message = result.Succeeded ? "Email confirmed successfully" : string.Join(", ", result.Errors.Select(e => e.Description))
        };
    }

    public override async Task<UpdateEmailReply> UpdateEmail(UpdateEmailRequest request, ServerCallContext context)
    {

        var user = await _userManager.FindByIdAsync(request.UserId);

        if (user == null)
        {
            return new UpdateEmailReply
            {
                Succeeded = false,
                Message = "User not found"
            };
        }

        if (string.Equals(request.NewEmail, user.Email, StringComparison.Ordinal))
        {
            return new UpdateEmailReply
            {
                Succeeded = false,
                Message = "New email cannot be the same as the current email"
            };
        }

        var token = await _userManager.GenerateChangeEmailTokenAsync(user, request.NewEmail);

        return new UpdateEmailReply
        {
            Succeeded = true,
            Message = "Email change token generated successfully",
            Token = token
        };
    }

    public override async Task<ConfirmEmailChangeReply> ConfirmEmailChange(ConfirmEmailChangeRequest request, ServerCallContext context)
    {

        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null)
        {
            return new ConfirmEmailChangeReply
            {
                Succeeded = false,
                Message = "User not found"
            };
        }
        var result = await _userManager.ChangeEmailAsync(user, request.NewEmail, request.Token);
        return new ConfirmEmailChangeReply
        {
            Succeeded = result.Succeeded,
            Message = result.Succeeded ? "Email changed successfully" : string.Join(", ", result.Errors.Select(e => e.Description))
        };
    }

    public override async Task<ResetPasswordReply> ResetPassword(ResetPasswordRequest request, ServerCallContext context)
    {
        var user = await _userManager.FindByEmailAsync(request.UserId);

        if (user == null)
        {
            return new ResetPasswordReply
            {
                Succeeded = false,
                Message = "User not found"
            };
        }


        var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);

        return new ResetPasswordReply
        {
            Succeeded = result.Succeeded,
            Message = result.Succeeded ? "Password reset successfully" : string.Join(", ", result.Errors.Select(e => e.Description))
        };


    }

    public override async Task<GenerateTokenReply> GeneratePasswordResetToken(GenerateTokenRequest request, ServerCallContext context)
    {
        var user = await _userManager.FindByEmailAsync(request.UserId);

        if (user == null)
        {
            return new GenerateTokenReply
            {
                Succeeded = false,
                Message = "User not found"
            };
        }


        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        return new GenerateTokenReply
        {
            Succeeded = true,
            Message = "Token generated successfully",
            Token = token
        };
    }

    public override async Task<GenerateTokenReply> GenerateEmailConfirmationToken(GenerateTokenRequest request, ServerCallContext context)
    {
        var user = await _userManager.FindByEmailAsync(request.UserId);
        if (user == null)
        {
            return new GenerateTokenReply
            {
                Succeeded = false,
                Message = "User not found"
            };
        }

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        return new GenerateTokenReply
        {
            Succeeded = true,
            Message = "Token generated successfully",
            Token = token
        };
    }

}

