using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class PostDetailDto
    {
        public int PostId { get; set; }
        public int MemberId { get; set; }
        public string Content { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<LikeDto> Likes { get; set; }
    }
}
