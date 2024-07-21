using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class LikeManager : ILikeService
    {
        ILikeDal _likeDal;

        public LikeManager(ILikeDal likeDal)
        {
            _likeDal = likeDal;
        }

        public List<Like> GetAllLikes()
        {
            return _likeDal.GetAll();
        }

        public Like GetLikeById(int likeId)
        {
            return _likeDal.Get(l => l.LikeId == likeId);
        }

        public void AddLike(LikeDto likeDto)
        {
            var like = new Like
            {
                PostId = likeDto.PostId,
                MemberId = likeDto.MemberId,
            };
            _likeDal.Add(like);
        }

        public void DeleteLike(int likeId)
        {   
            var like = _likeDal.Get(l => l.LikeId == likeId);
            if (like != null)
            {
                _likeDal.Delete(like);
            }
        }
    }   
}
