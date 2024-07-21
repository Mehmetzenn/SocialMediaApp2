using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class PostManager : IPostService
    {
        IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public List<Post> GetAllPosts()
        {
            return _postDal.GetAll();
        }

        public Post GetPostById(int postId)
        {
            return _postDal.Get(p => p.PostId == postId);
        }
        public IDataResult<PostDetailDto> GetPostWithDetails(int postId)
        {
            return new SuccessDataResult<PostDetailDto>(_postDal.GetPostWithDetails(postId));
        }
        public void AddPost(PostDto postDto)
        {
            var post = new Post
            {
                MemberId = postDto.MemberId,
                Content = postDto.Content,
                ImageUrl = postDto.ImageUrl,
                CreatedAt = postDto.CreatedAt,
                UpdatedAt = postDto.UpdatedAt
            };
            _postDal.Add(post);
        }

        public void UpdatePost(PostDto postDto)
        {
            var post = _postDal.Get(p => p.PostId == postDto.PostId);
            if (post != null)
            {
                post.Content = postDto.Content;
                post.ImageUrl = postDto.ImageUrl;
                post.UpdatedAt = postDto.UpdatedAt;
                _postDal.Update(post);
            }
        }

        public void DeletePost(int postId)
        {
            var post = _postDal.Get(p => p.PostId == postId);
            if (post != null)
            {
                _postDal.Delete(post);
            }
        }
    }

}
