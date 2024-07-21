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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public IDataResult<List<Comment>> GetAllComments()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll());
        }

        public IDataResult<Comment> GetCommentById(int commentId)
        {
            return new SuccessDataResult<Comment>(_commentDal.Get(c => c.CommentId == commentId));
        }

        public IResult AddComment(CommentDto commentDto)
        {
            var comment = new Comment
            {
                PostId = commentDto.PostId,
                MemberId = commentDto.MemberId,
                Content = commentDto.Content,
                CreatedAt = commentDto.CreatedAt
            };
            _commentDal.Add(comment);
            return new SuccessResult();
        }

        public IResult UpdateComment(CommentDto commentDto)
        {
            var comment = _commentDal.Get(c => c.CommentId == commentDto.CommentId);
            if (comment != null)
            {
                comment.Content = commentDto.Content;
                comment.CreatedAt = commentDto.CreatedAt;
                _commentDal.Update(comment);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult DeleteComment(int commentId)
        {
            var comment = _commentDal.Get(c => c.CommentId == commentId);
            if (comment != null)
            {
                _commentDal.Delete(comment);
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
