using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BiblioServer.Context;
using BiblioServer.Models;
using Microsoft.EntityFrameworkCore;

namespace BiblioServer.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task CreateCommentAsync(Comment model)
        {
            await _context.Comments.AddAsync(model);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCommentAsync(Comment model)
        {
            _context.Comments.Update(model);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCommentAsync(Comment model)
        {
            _context.Comments.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}

