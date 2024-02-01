using BiblioServer.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;

namespace BiblioServer.Context
{
    public class ApplicationDbContext : DbContext
    {
        //DbSet of Users
        public DbSet<User> Users { get; set; }

        //DbSet of Books
        public DbSet<Book> Books { get; set; }

        //DbSet of Genres
        public DbSet<Genre> Genres { get; set; }

        //DbSet of Comments
        public DbSet<Comment> Comments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    }
}
