using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthV4.Data
{
    public class AuthDbContext:IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options): base (options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "90695e07-5699-4e83-a56e-8ff02a3560e7";
            var writerRoleId = "e689692a-9829-4e7f-8fc5-7260ff89a064";



            var roles = new List<IdentityRole>
            {
              new IdentityRole
              {
                 Id  = readerRoleId,
                 ConcurrencyStamp = readerRoleId,
                 Name = "Reader",
                 NormalizedName = "Reader".ToUpper()
              },
              new IdentityRole
              {
                  Id = writerRoleId,
                  ConcurrencyStamp = writerRoleId,
                  Name  = "Writer",
                  NormalizedName = "Writer".ToUpper()
              }
            };
            builder.Entity<IdentityRole>().HasData(roles);
            builder.Entity<IdentityRole>().HasKey(r => r.Id).IsClustered(false);



        }    
        
    }
}
