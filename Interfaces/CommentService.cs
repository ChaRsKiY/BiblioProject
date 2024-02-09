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
        private readonly IBookService _bookService;

        public CommentService(ICommentRepository commentRepository, IBookService bookService)
        {
            _commentRepository = commentRepository;
            _bookService = bookService;
        }
        public async Task<IEnumerable<Comment>> GetCommentsByBookId(int bookId)
        {
            return await _commentRepository.GetCommentsByBookId(bookId);
        }
        public async Task<IEnumerable<Comment>> GetCommentsAsync()
        {
            return await _commentRepository.GetCommentsAsync();
        }
        public async Task CreateCommentAsync(Comment model)
        {
            await _bookService.UpdateRatingAsync(model.Rating, model.IdBook);
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

