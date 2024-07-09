using CMS.Domain.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Globalization;

namespace CMS.Infraestructure.Seeders
{
    public class PersonSeeder : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            var culture = CultureInfo.InvariantCulture;
            builder.HasData(
                new Person
                {
                    Id = 1,
                    FirstName = "Administrator",
                    LastName = "Administrator",
                    Age = 30,
                    CreatedBy = "Seeder",
                    CreatedAt = DateTime.Parse("2024-05-09", culture),
                }
                );
        }
    }
}
