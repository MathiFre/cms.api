using CMS.Domain.Posts;
using CMS.Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infraestructure.Repositories.Posts
{

    public class PostRepository : IPostRepository
    {
        private readonly CmsContext _context;
        public PostRepository(CmsContext context)
        {
            _context = context;
        }

        public async Task<Post> CreateAsync(Post input)
        {
            await _context.Posts.AddAsync(input);
            await _context.SaveChangesAsync();
            return input;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var post = await GetByIdAsync(id);
            _context.Posts.Remove(post);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            var posts = await _context.Posts
                .Include(x => x.Tags)
                .ToListAsync();
            return posts;
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            var post = await _context.Posts
                .Include(x => x.Tags)
                .FirstAsync(x => x.Id == id );
            return post;
        }

        public async Task<Post> UpdateAsync(Post input)
        {
            _context.Posts.Update(input);
            await _context.SaveChangesAsync();
            return input;
        }
    }
}
