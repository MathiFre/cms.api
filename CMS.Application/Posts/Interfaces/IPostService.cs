using CMS.Application.Posts.Models;

namespace CMS.Application.Posts.Interfaces
{
    public interface IPostService
    {
        public Task<List<PostDto>> GetAllAsync();
        public Task<PostDto> GetByIdAsync(int id);
        public Task<PostDto> CreateAsync(PostCreateDto input);
        public Task<PostDto> UpdateAsync(PostDto input);
        public Task<bool> DeleteAsync(int id);
    }
}
