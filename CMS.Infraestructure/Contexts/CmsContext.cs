using CMS.Domain.Comments;
using CMS.Domain.Persons;
using CMS.Domain.Posts;
using CMS.Domain.Tags;
using CMS.Infraestructure.Seeders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CMS.infraestructure.Seeders;

namespace CMS.Infraestructure.Contexts
{
    public class CmsContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public CmsContext(DbContextOptions options): base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TagSeeder());
            modelBuilder.ApplyConfiguration(new PersonSeeder());
            modelBuilder.ApplyConfiguration(new UserSeeder());
            modelBuilder.ApplyConfiguration(new RoleSeeder());
            modelBuilder.ApplyConfiguration(new UserRoleSeeder());
        }
    }
}
