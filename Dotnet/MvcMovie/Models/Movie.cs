using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;

public class Movie
{
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3, ErrorMessage = "Tytuł musi mieć od 3 do 60 znaków")]
    [Required(ErrorMessage = "Pole Tytuł jest wymagane")]
    [Display(Name = "Tytuł")]
    public string? Title { get; set; }

    [Display(Name = "Data wydania")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Pole Data wydania jest wymagane")]
    public DateTime ReleaseDate { get; set; }

    [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Używaj tylko liter")]
    [Required(ErrorMessage = "Pole Gatunek ist wymagane")]
    [StringLength(30)]
    [Display(Name = "Gatunek")]
    public string? Genre { get; set; }

    [Range(1, 100, ErrorMessage = "Cena musi być w przedziale od 1 do 100")]
    [Column(TypeName = "decimal(18, 2)")]
    [Required(ErrorMessage = "Pole Cena jest wymagane")]
    [Display(Name = "Cena")]
    public decimal Price { get; set; }

    [RegularExpression(@"^[a-zA-Z0-9""'\s-]*$", ErrorMessage = "Nieprawidłowy format formatu Rating")]
    [StringLength(5)]
    [Required(ErrorMessage = "Pole Rating jest wymagane")]
    [Display(Name = "Ocena")]
    public string? Rating { get; set; }
}