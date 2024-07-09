using CMS.application.Security;
using CMS.application.Security.Interfaces;
using CMS.Application.Persons;
using CMS.Application.Persons.Interfaces;
using CMS.Application.Posts;
using CMS.Application.Posts.Interfaces;
using CMS.Application.Tags;
using Microsoft.Extensions.DependencyInjection;

namespace CMS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
