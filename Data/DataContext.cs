using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext(DbContextOptions options) : IdentityDbContext(options)
    {
    }
}
