namespace CMS.Application.Persons.Models
{
    public class PersonCreateDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public int Age { get; set; } = default!;
    }
}
