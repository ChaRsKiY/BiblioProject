using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BiblioServer.Models;

namespace BiblioServer.Services
{

    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetCommentsAsync();
        Task CreateCommentAsync(Comment model);
        Task UpdateCommentAsync(Comment model);
        Task DeleteCommentAsync(Comment model);
    }
}

