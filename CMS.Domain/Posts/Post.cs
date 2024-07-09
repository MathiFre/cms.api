using CMS.Domain.Comments;
using CMS.Domain.Common;
using CMS.Domain.Persons;
using CMS.Domain.Tags;

namespace CMS.Domain.Posts
{
    public class Post : AuditEntity
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Content { get; set; } = default!;
        public string MainImage { get; set; } = default!;
        public DateTime PublishDate { get; set; } = default!;
        public int PersonId { get; set; }
        public Person Person { get; set; } = default!;
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Tag> Tags { get; set; } = default!;

    }
}
