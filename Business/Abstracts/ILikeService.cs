using Entities.Concretes;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ILikeService
    {
        List<Like> GetAllLikes();
        Like GetLikeById(int likeId);
        void AddLike(LikeDto likeDto);
        void DeleteLike(int likeId);
    }
}
