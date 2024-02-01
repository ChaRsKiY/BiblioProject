using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BiblioServer.Models;
using BiblioServer.Repositories;

namespace BiblioServer.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync()
        {
            return await _commentRepository.GetCommentsAsync();
        }
        public async Task CreateCommentAsync(Comment model)
        {
            await _commentRepository.CreateCommentAsync(model);
        }
        public async Task UpdateCommentAsync(Comment model)
        {
            await _commentRepository.UpdateCommentAsync(model);
        }
        public async Task DeleteCommentAsync(Comment model)
        {
            await _commentRepository.DeleteCommentAsync(model);
        }
    }
}

