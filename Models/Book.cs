using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace BiblioServer.Models;

//Book model
public class Book
{
    [Key]
    public int Id { get; set; }

    //Book name
    [MaxLength(60)]
    public string? Title { get; set; }

    [MaxLength(60)]
    public string? Author { get; set; }

    [ForeignKey("UserId")]
    public int UserId { get; set; }

    [ForeignKey("GenreId")]
    public int GenreId { get; set; }

    public string? CoverImage { get; set; }

    [MaxLength(350)]
    public string? Description { get; set; }

    [Range(0, 10)]
    public double? Rating { get; set; } = 5;

    public int RatingTotal { get; set; } = 0;

    public int RatingCountTotal { get; set; } = 0;
    public int? ReadCounter { get; set; }

    public int? DownloadCount { get; set; }

    [DataType(DataType.Date)]
    public DateTime? PublicationDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? Year { get; set; }

    //Text of the book / Content
    public string? Content { get; set; }
}