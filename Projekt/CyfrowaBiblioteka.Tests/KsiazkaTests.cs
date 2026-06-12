using CyfrowaBiblioteka.Models;
using System.ComponentModel.DataAnnotations;

namespace CyfrowaBiblioteka.Tests;

public class KsiazkaTests
{
    [Fact]
    public void Ksiazka_BezTytulu_NieJestPoprawna()
    {
        var ksiazka = new Ksiazka { Tytul = null, RokWydania = 1834, Gatunek = "Epos", AutorId = 1 };
        var wyniki = new List<ValidationResult>();
        var kontekst = new ValidationContext(ksiazka);
        var jestPoprawna = Validator.TryValidateObject(ksiazka, kontekst, wyniki, true);
        Assert.False(jestPoprawna);
    }

    [Fact]
    public void Ksiazka_ZRokiemPrzedRokiem1000_NieJestPoprawna()
    {
        var ksiazka = new Ksiazka { Tytul = "Pan Tadeusz", RokWydania = 500, Gatunek = "Epos", AutorId = 1 };
        var wyniki = new List<ValidationResult>();
        var kontekst = new ValidationContext(ksiazka);
        var jestPoprawna = Validator.TryValidateObject(ksiazka, kontekst, wyniki, true);
        Assert.False(jestPoprawna);
    }

    [Fact]
    public void Ksiazka_ZPoprawnymDanymi_JestPoprawna()
    {
        var ksiazka = new Ksiazka { Tytul = "Pan Tadeusz", RokWydania = 1834, Gatunek = "Epos", AutorId = 1 };
        var wyniki = new List<ValidationResult>();
        var kontekst = new ValidationContext(ksiazka);
        var jestPoprawna = Validator.TryValidateObject(ksiazka, kontekst, wyniki, true);
        Assert.True(jestPoprawna);
    }

    [Fact]
    public void Ksiazka_BezGatunku_NieJestPoprawna()
    {
        var ksiazka = new Ksiazka { Tytul = "Pan Tadeusz", RokWydania = 1834, Gatunek = null, AutorId = 1 };
        var wyniki = new List<ValidationResult>();
        var kontekst = new ValidationContext(ksiazka);
        var jestPoprawna = Validator.TryValidateObject(ksiazka, kontekst, wyniki, true);
        Assert.False(jestPoprawna);
    }
}
