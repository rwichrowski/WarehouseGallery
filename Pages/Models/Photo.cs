using System.ComponentModel.DataAnnotations;

public class Photo
{
    public int Id { get; set; }

    [Required]
    public string FileName { get; set; } // �cie�ka lub nazwa pliku JPG

    public string Description { get; set; }
}