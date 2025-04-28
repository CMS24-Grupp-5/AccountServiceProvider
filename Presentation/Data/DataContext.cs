using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Data
{
    public class DataContext(DbContextOptions options) : IdentityDbContext(options)
    {
    }
}
