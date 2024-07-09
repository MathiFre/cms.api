using CMS.Application.Persons.Interfaces;
using CMS.Application.Persons.Models;
using CMS.Domain.Persons;
using CMS.Infraestructure.Repositories.Persons;

namespace CMS.Application.Persons
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<PersonDto> CreateAsync(PersonCreateDto input)
        {
            var entity = new Person
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Age = input.Age,
                CreatedBy = "API CALL", //TODO: Get User From context
            };

            entity = await _personRepository.CreateAsync(entity);

            return new PersonDto
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                Id = entity.Id,
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _personRepository.DeleteAsync(id);
            return result;
        }

        public async Task<List<PersonDto>> GetAllAsync()
        {
            var entities = await _personRepository.GetAllAsync();

            return entities.Select(x => new PersonDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age,
            }).ToList();
        }

        public async Task<PersonDto> GetByIdAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            return new PersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age,
            };
        }

        public async Task<PersonDto> UpdateAsync(PersonDto input)
        {
            var entity = await _personRepository.GetByIdAsync(input.Id);
            entity.FirstName = input.FirstName;
            entity.LastName = input.LastName;
            entity.Age = input.Age;
            
            entity = await _personRepository.UpdateAsync(entity);

            return new PersonDto
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                Id = entity.Id,
            };
        }
    }
}
