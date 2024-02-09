using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BiblioServer.Models;

namespace BiblioServer.Repositories
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetCommentsByBookId(int bookId);
        Task<IEnumerable<Comment>> GetCommentsAsync();
        Task CreateCommentAsync(Comment model);
        Task UpdateCommentAsync(Comment model);
        Task DeleteCommentAsync(Comment model);
    }
}

