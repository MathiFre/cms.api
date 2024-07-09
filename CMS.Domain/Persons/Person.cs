using CMS.Domain.Common;
using CMS.Domain.Posts;

namespace CMS.Domain.Persons
{
    public class Person : AuditEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public int Age { get; set; } = default!;
        public ICollection<Post>? Posts { get; set;}
    }
}
