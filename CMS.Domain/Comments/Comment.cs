using CMS.Domain.Common;
using CMS.Domain.Posts;

namespace CMS.Domain.Comments
{
    public class Comment : AuditEntity
    {
        public string Content { get; set; } = default!;
        public string PublishDate { get; set; } = default!;
        public int PostId { get; set; }
        public Post Post { get; set; } = default!;
    }
}
