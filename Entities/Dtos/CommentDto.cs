namespace Entities.Dtos
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int MemberId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
