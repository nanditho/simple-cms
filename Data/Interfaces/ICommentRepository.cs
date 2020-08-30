using System.Collections.Generic;
using BlogApi.Models;

namespace simple_cms.Data.Interfaces
{
    public interface ICommentRepository
    {
        ICollection<Comment> GetComments();
        Comment GetComment(int id);
        ICollection<Comment> GetCommentsOfBlog(int id);
        ICollection<Comment> GetBlogForComments(int id);
        bool CommentExists(int comment);
        
    }
}