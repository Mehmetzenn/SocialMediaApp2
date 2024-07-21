using Core.Utilities.Results;
using Entities.Concretes;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IPostService
    {
        List<Post> GetAllPosts();
        Post GetPostById(int postId);
        IDataResult<PostDetailDto> GetPostWithDetails(int postId);
        void AddPost(PostDto postDto);
        void UpdatePost(PostDto postDto);
        void DeletePost(int postId);
    }
}
