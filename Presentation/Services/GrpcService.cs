using Business.Intefaces;
using Business.Services;
using Domain.Models;
using Grpc.Core;

namespace Presentation.Services;

public class GrpcService(IAccountUserService accountService) : AccountGrpcService.AccountGrpcServiceBase
{
    public override async Task<CreateAccountReply> CreateAccount(CreateAccountRequest request, ServerCallContext context)
    {
        try
        {
            var result = await accountService.CreateUserAccount(request.Email, request.Password);
            return new CreateAccountReply
            {
                Succeeded = result.Success,
                Message = result.Message,
                UserId = result.UserId ?? string.Empty
            };
        }
        catch (Exception ex)
        {
            return new CreateAccountReply { Succeeded = false, Message = $"Error: {ex.Message}" };
        }
    }

    public override async Task<ValidateCredentialsReply> ValidateCredentials(ValidateCredentialsRequest request, ServerCallContext context)
    {
        try
        {
            var result = await accountService.ValidateCredentials(request.Email, request.Password);
            return new ValidateCredentialsReply
            {
                Succeeded = result.Success,
                Message = result.Message,
                UserId = (result as CreateResponseResult)?.UserId ?? string.Empty
            };
        }
        catch (Exception ex)
        {
            return new ValidateCredentialsReply { Succeeded = false, Message = $"Error: {ex.Message}" };
        }
    }

    public override async Task<GetAccountsReply> GetAccounts(GetAccountsRequest request, ServerCallContext context)
    {
        try
        {
            var result = await accountService.GetAllAccounts();
            var reply = new GetAccountsReply
            {
                Succeeded = result.Success,
                Message = result.Message
            };

            foreach (var acc in result.Accounts)
            {
                reply.Accounts.Add(new Account
                {
                    UserId = acc.UserId,
                    Email = acc.Email,
                    UserName = acc.UserName,
                    PhoneNumber = acc.PhoneNumber
                });
            }

            return reply;
        }
        catch (Exception ex)
        {
            return new GetAccountsReply { Succeeded = false, Message = $"Error: {ex.Message}" };
        }
    }

    public override async Task<GetAccountByIdReply> GetAccountById(GetAccountByIdRequest request, ServerCallContext context)
    {
        try
        {
            var result = await accountService.GetAccountById(request.UserId);
            return new GetAccountByIdReply
            {
                Succeeded = result.Success,
                Message = result.Message,
                Account = result.Account is null ? null : new Account
                {
                    UserId = result.Account.UserId,
                    Email = result.Account.Email,
                    UserName = result.Account.UserName,
                    PhoneNumber = result.Account.PhoneNumber
                }
            };
        }
        catch (Exception ex)
        {
            return new GetAccountByIdReply { Succeeded = false, Message = $"Error: {ex.Message}" };
        }
    }

    public override async Task<UpdatePhoneNumberReply> UpdatePhoneNumber(UpdatePhoneNumberRequest request, ServerCallContext context)
    {
        try
        {
            var result = await accountService.UpdatePhoneNumber(request.UserId, request.PhoneNumber);
            return new UpdatePhoneNumberReply { Succeeded = result.Success, Message = result.Message };
        }
        catch (Exception ex)
        {
            return new UpdatePhoneNumberReply { Succeeded = false, Message = $"Error: {ex.Message}" };
        }
    }

    public override async Task<DeleteAccountReply> DeleteAccount(DeleteAccountRequest request, ServerCallContext context)
    {
        try
        {
            var result = await accountService.DeleteAccount(request.UserId);
            return new DeleteAccountReply { Succeeded = result.Success, Message = result.Message };
        }
        catch (Exception ex)
        {
            return new DeleteAccountReply { Succeeded = false, Message = $"Error: {ex.Message}" };
        }
    }

    public override async Task<ConfirmAccountReply> ConfirmAccount(ConfirmAccountRequest request, ServerCallContext context)
    {
        try
        {
            var result = await accountService.ConfirmAccount(request.UserId, request.Token);
            return new ConfirmAccountReply { Succeeded = result.Success, Message = result.Message };
        }
        catch (Exception ex)
        {
            return new ConfirmAccountReply { Succeeded = false, Message = $"Error: {ex.Message}" };
        }
    }

    public override async Task<UpdateEmailReply> UpdateEmail(UpdateEmailRequest request, ServerCallContext context)
    {
        try
        {
            var result = await accountService.UpdateEmail(request.UserId, request.NewEmail);
            return new UpdateEmailReply { Succeeded = result.Success, Message = result.Message, Token = result.Token ?? string.Empty };
        }
        catch (Exception ex)
        {
            return new UpdateEmailReply { Succeeded = false, Message = $"Error: {ex.Message}" };
        }
    }

    public override async Task<ConfirmEmailChangeReply> ConfirmEmailChange(ConfirmEmailChangeRequest request, ServerCallContext context)
    {
        try
        {
            var result = await accountService.ConfirmEmailChange(request.UserId, request.NewEmail, request.Token);
            return new ConfirmEmailChangeReply { Succeeded = result.Success, Message = result.Message };
        }
        catch (Exception ex)
        {
            return new ConfirmEmailChangeReply { Succeeded = false, Message = $"Error: {ex.Message}" };
        }
    }

    public override async Task<ResetPasswordReply> ResetPassword(ResetPasswordRequest request, ServerCallContext context)
    {
        try
        {
            var result = await accountService.ResetPassword(request.UserId, request.Token, request.NewPassword);
            return new ResetPasswordReply { Succeeded = result.Success, Message = result.Message };
        }
        catch (Exception ex)
        {
            return new ResetPasswordReply { Succeeded = false, Message = $"Error: {ex.Message}" };
        }
    }

    public override async Task<GenerateTokenReply> GeneratePasswordResetToken(GenerateTokenRequest request, ServerCallContext context)
    {
        try
        {
            var result = await accountService.GeneratePasswordResetToken(request.UserId);
            return new GenerateTokenReply { Succeeded = result.Success, Message = result.Message, Token = result.Token ?? string.Empty };
        }
        catch (Exception ex)
        {
            return new GenerateTokenReply { Succeeded = false, Message = $"Error: {ex.Message}" };
        }
    }

    public override async Task<GenerateTokenReply> GenerateEmailConfirmationToken(GenerateTokenRequest request, ServerCallContext context)
    {
        try
        {
            var result = await accountService.GenerateEmailConfirmationToken(request.UserId);
            return new GenerateTokenReply { Succeeded = result.Success, Message = result.Message, Token = result.Token ?? string.Empty };
        }
        catch (Exception ex)
        {
            return new GenerateTokenReply { Succeeded = false, Message = $"Error: {ex.Message}" };
        }
    }
}
