using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.RateLimiting;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfPostDal : EfEntityRepositoryBase<Post, SocialMediaContext>, IPostDal
    {
        public PostDetailDto GetPostWithDetails(int postId)
        {
            using (var context = new SocialMediaContext())
            {
                var post = context.posts
                    .Where(p => p.PostId == postId)
                    .Select(p => new PostDetailDto
                    {
                        PostId = p.PostId,
                        MemberId = p.MemberId,
                        Content = p.Content,
                        Comments = p.Comments.Select(c => new CommentDto
                        {
                            CommentId = c.CommentId,
                            PostId = c.PostId,
                            MemberId = c.MemberId,
                            Content = c.Content,
                        }).ToList(),
                        Likes = p.Likes.Select(l => new LikeDto
                        {
                            LikeId = l.LikeId,
                            PostId = l.PostId,
                            MemberId = l.MemberId
                        }).ToList()
                    })
                    .FirstOrDefault();

                return post;
            }
        }
    }
}
