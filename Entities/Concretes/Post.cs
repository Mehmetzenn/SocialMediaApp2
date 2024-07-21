using Core.Entities;

namespace Entities.Concretes
{
    public class Post : IEntity
    {
        public int PostId { get; set; }
        public int MemberId { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Member Member { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}
