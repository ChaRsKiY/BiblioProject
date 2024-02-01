
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BiblioServer.Models;
using BiblioServer.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace BiblioServer.Services
{
	public class BookService : IBookService
	{
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<object> GetBooksAsync(BookQueryParameters queryParameters)
        {
            return await _bookRepository.GetBooksAsync(queryParameters);
        }

        public async Task<IEnumerable<Book>> GetPopularBooksAsync()
        {
            return await _bookRepository.GetPopularBooksAsync();
        }

        public async Task<IEnumerable<Book>> GetTrendingBooksAsync()
        {
            return await _bookRepository.GetTrendingBooksAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

        public async Task<IEnumerable<Book>> GetBookByUserIdAsync(int userId)
        {
            return await _bookRepository.GetBookByUserIdAsync(userId);
        }

        public async Task AddBookAsync(int userId, AddBookModel book)
        {
            var coverFileName = Guid.NewGuid().ToString() + Path.GetExtension(book.Image.FileName);
            var coverFilePath = Path.Combine("wwwroot/covers", coverFileName);

            using (var stream = new FileStream(coverFilePath, FileMode.Create))
            {
                await book.Image.CopyToAsync(stream);
            }

            var contentFileName = Guid.NewGuid().ToString() + Path.GetExtension(book.Content.FileName);
            var contentFilePath = Path.Combine("wwwroot/texts", contentFileName);

            using (var stream = new FileStream(contentFilePath, FileMode.Create))
            {
                await book.Content.CopyToAsync(stream);
            }

            var newBook = new Book
            {
                Author = book.Author,
                Title = book.Title,
                Year = book.Year,
                GenreId = book.GenreId,
                UserId = userId,
                Description = book.Description,
                CoverImage = coverFileName,
                PublicationDate = DateTime.Now,
                Content = coverFileName
            };

            await _bookRepository.AddBookAsync(newBook);
        }

        //Updates user data
        public async Task<string> RouteUpdateBookAsync(int bookId, BookUpdateModel updateModel)
        {
            var book = await _bookRepository.GetBookByIdAsync(bookId);

            if (book != null)
            {
                if (!string.IsNullOrEmpty(updateModel.Title))
                {
                    book.Title = updateModel.Title;
                }

                if (!string.IsNullOrEmpty(updateModel.Author))
                {
                    book.Author = updateModel.Author;
                }
                
                if (updateModel.GenreId != null)
                {
                    book.GenreId = (int)updateModel.GenreId;
                }

                if (!string.IsNullOrEmpty(updateModel.Description))
                {
                    book.Description = updateModel.Description;
                }
                
                if (updateModel.Year != null)
                {
                    book.Year = updateModel.Year;
                }

                if (!string.IsNullOrEmpty(updateModel.Content))
                {
                    book.Content = updateModel.Content;
                }

                if (updateModel.CoverImageFile != null)
                {
                    // Delete the previous cover if it exists
                    var previousCoverImagePath = Path.Combine("wwwroot/covers", book.CoverImage);
                    if (System.IO.File.Exists(previousCoverImagePath))
                    {
                        System.IO.File.Delete(previousCoverImagePath);
                    }

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(updateModel.CoverImageFile.FileName);
                    var filePath = Path.Combine("wwwroot/covers", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await updateModel.CoverImageFile.CopyToAsync(stream);
                    }

                    book.CoverImage = fileName;
                }

                await _bookRepository.UpdateBookAsync(updateModel.Id, book);

                return "";

            }
            else
            {
                return "bookExist";
            }
        }

        public async Task<Book> UpdateBookAsync(int id, Book book)
        {
            return await _bookRepository.UpdateBookAsync(id, book);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            return await _bookRepository.DeleteBookAsync(id);
        }
    }
}

