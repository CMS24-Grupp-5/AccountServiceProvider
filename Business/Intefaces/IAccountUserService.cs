using Domain.Models;

namespace Business.Intefaces
{
    public interface IAccountUserService
    {
        Task<BaseResponseResult> AddUserToRoleAsync(string userId, string roleName);
        Task<BaseResponseResult> ConfirmAccount(string userId, string token);
        Task<BaseResponseResult> ConfirmEmailChange(string userId, string newEmail, string token);
        Task<CreateResponseResult> CreateUserAccount(string email, string password, string roleName = "user");
        Task<BaseResponseResult> DeleteAccount(string userId);
        Task<BaseResponseResult> ExistAsync(string id);
        Task<TokenResponseResult> GenerateEmailConfirmationToken(string email);
        Task<TokenResponseResult> GeneratePasswordResetToken(string email);
        Task<AccountResponse> GetAccountById(string userId);
        Task<AccountListResponse> GetAllAccounts();
        Task<List<string>> GetRoleAsync(string userId);
        Task<BaseResponseResult> ResetPassword(string email, string token, string newPassword);
        Task<TokenResponseResult> UpdateEmail(string userId, string newEmail);
        Task<BaseResponseResult> UpdatePhoneNumber(string userId, string phoneNumber);
        Task<BaseResponseResult> ValidateCredentials(string email, string password);
    }
}