namespace Entities.Dtos
{
    public class PostDto
    {
        public int PostId { get; set; } 
        public int MemberId { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
