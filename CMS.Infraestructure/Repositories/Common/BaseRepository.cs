using CMS.Domain.Common;
using CMS.Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infraestructure.Repositories.Common
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly CmsContext _context;
        public BaseRepository(CmsContext context)
        {
            _context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity input)
        {
            await _context.Set<TEntity>().AddAsync(input);
            await _context.SaveChangesAsync();
            return input;
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            var entities = await _context.Set<TEntity>().ToListAsync();
            return entities;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FirstAsync(x => x.Id == id);
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity input)
        {
            _context.Set<TEntity>().Update(input);
            await _context.SaveChangesAsync();
            return input;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _context.Set<TEntity>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
