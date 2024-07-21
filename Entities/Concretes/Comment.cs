using Core.Entities;

namespace Entities.Concretes
{
    public class Comment : IEntity
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int MemberId { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Post Post { get; set; }
        public virtual Member Member{ get; set; }
    }
}
