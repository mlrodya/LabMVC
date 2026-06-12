using CyfrowaBiblioteka.Models;
using System.ComponentModel.DataAnnotations;

namespace CyfrowaBiblioteka.Tests;

public class AutorTests
{
    [Fact]
    public void PelneImie_ZwracaPoprawnePelneImie()
    {
        var autor = new Autor { Imie = "Adam", Nazwisko = "Mickiewicz" };
        Assert.Equal("Adam Mickiewicz", autor.PelneImie);
    }

    [Fact]
    public void Autor_BezImienia_NieJestPoprawny()
    {
        var autor = new Autor { Imie = null, Nazwisko = "Mickiewicz" };
        var wyniki = new List<ValidationResult>();
        var kontekst = new ValidationContext(autor);
        var jestPoprawny = Validator.TryValidateObject(autor, kontekst, wyniki, true);
        Assert.False(jestPoprawny);
    }

    [Fact]
    public void Autor_BezNazwiska_NieJestPoprawny()
    {
        var autor = new Autor { Imie = "Adam", Nazwisko = null };
        var wyniki = new List<ValidationResult>();
        var kontekst = new ValidationContext(autor);
        var jestPoprawny = Validator.TryValidateObject(autor, kontekst, wyniki, true);
        Assert.False(jestPoprawny);
    }

    [Fact]
    public void Autor_ZPoprawnymDanymi_JestPoprawny()
    {
        var autor = new Autor { Imie = "Adam", Nazwisko = "Mickiewicz" };
        var wyniki = new List<ValidationResult>();
        var kontekst = new ValidationContext(autor);
        var jestPoprawny = Validator.TryValidateObject(autor, kontekst, wyniki, true);
        Assert.True(jestPoprawny);
    }
}
