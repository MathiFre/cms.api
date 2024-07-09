using CMS.Domain.Common;
using CMS.Domain.Posts;

namespace CMS.Domain.Tags
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; } = default!;
        public ICollection<Post>? Posts { get; set; }
    }
}
