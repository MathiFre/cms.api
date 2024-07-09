using CMS.Domain.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infraestructure.Seeders
{
    public class TagSeeder : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasData(
                new Tag
                {
                    Id = 1,
                    Name = "Undefined"
                }
                );
        }
    }
}
