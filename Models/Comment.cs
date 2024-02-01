using System.ComponentModel.DataAnnotations;

namespace BiblioServer.Models;

//Comment model
public class Comment
{
    [Key]
    public int Id { get; set; }

    //Comment text
    [Required(ErrorMessage = "Comment content is required.")]
    [MaxLength(500, ErrorMessage = "Comment content cannot exceed 500 characters.")]
    public string Content { get; set; }

    [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10.")]
    public int? Rating { get; set; }
    
    public int IdUser { get; set; }

    public int IdBook { get; set; }
}