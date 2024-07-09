using CMS.Domain.Tags;
using CMS.Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infraestructure.Repositories.Tags
{
    public class TagRepository : ITagRepository
    {
        private readonly CmsContext _context;
        public TagRepository(CmsContext cmsContext)
        {
            _context = cmsContext;
        }

        public async Task<Tag> CreateAsync(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
            _context.SaveChanges();
            return tag;
        }

        public async Task<bool> DeleteAsync(int id)
        {
           var tag = await GetByIdAsync(id);

            _context.Tags.Remove(tag);
            return _context.SaveChanges() > 0;
        }

        public async Task<ICollection<Tag>> GetAllAsync()
        {
            var tags = await _context.Tags.ToListAsync();
            return tags;
        }

        public async Task<Tag> GetByIdAsync(int id)
        {
            var tag = await _context.Tags.FirstAsync(x => x.Id == id);
            return tag;
        }

        public async Task<ICollection<Tag>> GetByIdsAsync(List<int> ids)
        {
            var tags = await _context.Tags.Where(x => ids.Contains(x.Id)).ToListAsync();
            return tags;
        }

        public async Task<Tag> UpdateAsync(Tag tag)
        {
            _context.Tags.Update(tag);
            await _context.SaveChangesAsync();

            return tag;
        }
    }
}
