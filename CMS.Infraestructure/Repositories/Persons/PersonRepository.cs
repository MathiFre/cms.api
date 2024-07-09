using CMS.Domain.Persons;
using CMS.Infraestructure.Contexts;
using CMS.Infraestructure.Repositories.Common;

namespace CMS.Infraestructure.Repositories.Persons
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(CmsContext context) : base(context)
        {
            
        }
    }
}
