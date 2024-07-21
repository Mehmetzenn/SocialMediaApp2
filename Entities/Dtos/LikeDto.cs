using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class LikeDto
    {
        public int LikeId { get; set; }
        public int PostId { get; set; }
        public int MemberId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
