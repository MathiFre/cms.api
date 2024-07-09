using CMS.infraestructure.Repositories.Security;
using CMS.Infraestructure.Contexts;
using CMS.Infraestructure.Repositories.Persons;
using CMS.Infraestructure.Repositories.Posts;
using CMS.Infraestructure.Repositories.Security.Interfaces;
using CMS.Infraestructure.Repositories.Tags;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CMS.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CmsContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentityCore<IdentityUser<Guid>>()
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<CmsContext>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
