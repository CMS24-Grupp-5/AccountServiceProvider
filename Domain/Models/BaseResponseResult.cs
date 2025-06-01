

namespace Domain.Models;

public class BaseResponseResult
{
   public bool Success { get; set; }
   public string? Message { get; set; }
   public int StatusCode { get; set; }
}
