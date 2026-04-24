using System.ComponentModel.DataAnnotations;

namespace CyfrowaBiblioteka.Models;

public class Autor
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Pole Imię jest wymagane")]
    [StringLength(50, ErrorMessage = "Imię nie może być dłuższe niż 50 znaków")]
    [Display(Name = "Imię")]
    public string? Imie { get; set; }

    [Required(ErrorMessage = "Pole Nazwisko jest wymagane")]
    [StringLength(50, ErrorMessage = "Nazwisko nie może być dłuższe niż 50 znaków")]
    [Display(Name = "Nazwisko")]
    public string? Nazwisko { get; set; }

    [Display(Name = "Imię i Nazwisko")]
    public string PelneImie => $"{Imie} {Nazwisko}";

    // Relacja: Jeden autor może mieć wiele książek
    public ICollection<Ksiazka>? Ksiazki { get; set; }
}