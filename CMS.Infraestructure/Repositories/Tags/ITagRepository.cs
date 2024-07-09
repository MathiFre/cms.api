using CMS.Domain.Tags;

namespace CMS.Infraestructure.Repositories.Tags
{
    public interface ITagRepository
    {
        Task<ICollection<Tag>> GetAllAsync();
        Task<Tag> GetByIdAsync(int id);
        Task<ICollection<Tag>> GetByIdsAsync(List<int> ids);
        Task<Tag> CreateAsync(Tag tag);
        Task<Tag> UpdateAsync(Tag tag);
        Task<bool> DeleteAsync(int id);
    }
}
