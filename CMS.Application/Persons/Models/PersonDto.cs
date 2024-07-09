namespace CMS.Application.Persons.Models
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public int Age { get; set; } = default!;
    }
}
