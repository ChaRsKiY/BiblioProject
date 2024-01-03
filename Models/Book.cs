using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioServer.Models;

public class Book
{
    //���� �����
    [Key]
    public int Id { get; set; }

    //�������� �����
    [Required]
    [MaxLength(60)]
    public string Title { get; set; }

    //����� �����
    [Required]
    [MaxLength(60)]
    public string Author { get; set; }

    //���� �����
    [ForeignKey("Genre")]
    public Genre Genre { get; set; }

    //���� � ������� �����
    public string CoverImage { get; set; }

    //�������� �����
    [MaxLength(255)]
    public string Description { get; set; }

    //������
    [Range(0, 10)]
    public double Rating { get; set; }

    //������� ��������� �����
    public int ReadCounter { get; set; }

    //������� �������� �����
    public int DownloadCount { get; set; }

    //���� ���������� �����
    [DataType(DataType.Date)]
    public DateOnly PublicationDate { get; set; }

    //��� ������� �����
    [DataType(DataType.Date)]
    public DateOnly Year { get; set; }

    //���������� �����(�� ��������)
    public string Content { get; set; }
}