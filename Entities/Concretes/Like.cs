using Core.Entities;

namespace Entities.Concretes
{
    public class Like : IEntity
    {
        public int LikeId { get; set; }
        public int PostId { get; set; }
        public int MemberId { get; set; }

        public virtual Post Post { get; set; }
        public virtual Member Member { get; set; }
    }
}
