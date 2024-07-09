using CMS.Application.Persons.Models;

namespace CMS.Application.Persons.Interfaces
{
    public interface IPersonService
    {
        public Task<List<PersonDto>> GetAllAsync();
        public Task<PersonDto> GetByIdAsync(int id);
        public Task<PersonDto> CreateAsync(PersonCreateDto input);
        public Task<PersonDto> UpdateAsync(PersonDto input);
        public Task<bool> DeleteAsync(int id);
    }
}
