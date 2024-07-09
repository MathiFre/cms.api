namespace CMS.Infraestructure.Repositories.Common
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        public Task<ICollection<TEntity>> GetAllAsync();
        public Task<TEntity> GetByIdAsync(int id);
        public Task<TEntity> CreateAsync(TEntity input);
        public Task<TEntity> UpdateAsync(TEntity input);
        public Task<bool> DeleteAsync(int id);
    }
}
