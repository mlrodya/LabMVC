using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyfrowaBiblioteka.Models;

public class Ksiazka
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Pole Tytuł jest wymagane")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Tytuł musi mieć od 2 do 100 znaków")]
    [Display(Name = "Tytuł")]
    public string? Tytul { get; set; }

    [Required(ErrorMessage = "Pole Rok wydania jest wymagane")]
    [Range(1000, 2100, ErrorMessage = "Podaj poprawny rok wydania")]
    [Display(Name = "Rok wydania")]
    public int RokWydania { get; set; }

    [Required(ErrorMessage = "Pole Gatunek jest wymagane")]
    [StringLength(50)]
    [Display(Name = "Gatunek")]
    public string? Gatunek { get; set; }

    // Klucz obcy (Foreign Key)
    [Display(Name = "Autor")]
    public int AutorId { get; set; }
    
    // Właściwość nawigacyjna
    [Display(Name = "Autor")]
    public Autor? Autor { get; set; }

    // Relacja: Jedna książka może mieć wiele wypożyczeń (historia)
    public ICollection<Wypozyczenie>? Wypozyczenia { get; set; }
}