
using CMS.Domain.Posts;

namespace CMS.Infraestructure.Repositories.Posts
{
    public interface IPostRepository
    {
        public Task<List<Post>> GetAllAsync();
        public Task<Post> GetByIdAsync(int id);
        public Task<Post> CreateAsync(Post input);
        public Task<Post> UpdateAsync(Post input);
        public Task<bool> DeleteAsync(int id);
    }
}
