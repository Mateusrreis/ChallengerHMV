using ChallengerHMV.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ChallengerHMV.Infra.Data.Context
{
    public class HmvContext : DbContext
    {
        public HmvContext(DbContextOptions<HmvContext> options) : base(options)
        {
        }

        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set;}
    }
}
