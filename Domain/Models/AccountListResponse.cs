

namespace Domain.Models;


public class AccountListResponse : BaseResponseResult
{
    public List<AccountDto> Accounts { get; set; } = [];
}
