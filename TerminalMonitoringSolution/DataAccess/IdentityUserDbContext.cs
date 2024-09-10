using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static TerminalMonitoringSolution.Models.Constants;

namespace TerminalMonitoringSolution.DataAccess
{
    public class AdminIdentity : IdentityUser<long>
    {
        public AdminIdentity()
        {
            Created = DateTime.Now;
        }

        public DateTime Created { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

    }
    public class UserIdentityRole : IdentityRole<long>
    {

        public UserIdentityRole()
        {

        }

        public UserIdentityRole(string roleName)
        {
            new IdentityRole(roleName);
        }
    }

    public class IdentityUserDbContext : IdentityDbContext<AdminIdentity, UserIdentityRole, long>
    {
        public IdentityUserDbContext()
        {
        }
        public IdentityUserDbContext(DbContextOptions<IdentityUserDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserIdentityRole>().ToTable(TableConsts.IdentityRoles).HasKey(m => m.Id);
            builder.Entity<AdminIdentity>().ToTable(TableConsts.IdentityUsers).HasKey(m => m.Id);
        }

    }
}
