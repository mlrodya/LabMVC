using System.ComponentModel.DataAnnotations;

namespace CyfrowaBiblioteka.Models;

public class Wypozyczenie
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Pole Osoba wypożyczająca jest wymagane")]
    [StringLength(100)]
    [Display(Name = "Osoba wypożyczająca")]
    public string? OsobaWypozyczajaca { get; set; }

    [Required(ErrorMessage = "Data wypożyczenia jest wymagana")]
    [DataType(DataType.Date)]
    [Display(Name = "Data wypożyczenia")]
    public DateTime DataWypozyczenia { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Data zwrotu")]
    public DateTime? DataZwrotu { get; set; }

    // Klucz obcy do Książki
    [Display(Name = "Książka")]
    public int KsiazkaId { get; set; }

    // Właściwość nawigacyjna
    [Display(Name = "Książka")]
    public Ksiazka? Ksiazka { get; set; }
}