
using CMS.Application.Tags.Models;

namespace CMS.Application.Tags
{
    public interface ITagService
    {
        Task<ICollection<TagDto>> GetAllAsync();
        Task<TagDto> GetByIdAsync(int id);
        Task<TagDto> CreateAsync(TagCreateDto tag);
        Task<TagDto> UpdateAsync(TagDto tag);
        Task<bool> DeleteAsync(int id);
    }
}
