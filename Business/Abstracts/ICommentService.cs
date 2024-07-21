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
    public interface ICommentService
    {
        IDataResult<List<Comment>> GetAllComments();
        IDataResult<Comment> GetCommentById(int commentId);
        IResult AddComment(CommentDto commentDto);
        IResult UpdateComment(CommentDto commentDto);
        IResult DeleteComment(int commentId);
    }
}
