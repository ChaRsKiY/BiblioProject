namespace BiblioServer.Models;

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

public class BookUpdateModel
{
    [Key]
    public int Id { get; set; }

    [MaxLength(60)]
    public string? Title { get; set; }

    [MaxLength(60)]
    public string? Author { get; set; }

    [ForeignKey("GenreId")]
    public int? GenreId { get; set; }

    public string? CoverImage { get; set; }

    [MaxLength(350)]
    public string? Description { get; set; }

    [DataType(DataType.Date)]
    public DateTime? Year { get; set; }
    
    //Text of the book / Content
    public string? Content { get; set; }

    public IFormFile? CoverImageFile { get; set; }

}