
namespace CMS.Application.Posts.Models
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Content { get; set; } = default!;
        public string MainImage { get; set; } = default!;
        public DateTime PublishDate { get; set; } = default!;
        public int PersonId { get; set; }
        //public ICollection<Comment>? Comments { get; set; }
        public ICollection<PostTagDto> Tags { get; set; } = default!;
    }

    public class PostTagDto
    {
        public int Id { get; set; }
    }
}
