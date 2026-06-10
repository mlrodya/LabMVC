using CyfrowaBiblioteka.Models;
using System.ComponentModel.DataAnnotations;

namespace CyfrowaBiblioteka.Tests;

public class WypozyczeniaTests
{
    [Fact]
    public void Wypozyczenie_BezOsoby_NieJestPoprawne()
    {
        var wypozyczenie = new Wypozyczenie
        {
            OsobaWypozyczajaca = null,
            DataWypozyczenia = DateTime.Now,
            KsiazkaId = 1
        };
        var wyniki = new List<ValidationResult>();
        var kontekst = new ValidationContext(wypozyczenie);
        var jestPoprawne = Validator.TryValidateObject(wypozyczenie, kontekst, wyniki, true);
        Assert.False(jestPoprawne);
    }

    [Fact]
    public void Wypozyczenie_ZPoprawnymDanymi_JestPoprawne()
    {
        var wypozyczenie = new Wypozyczenie
        {
            OsobaWypozyczajaca = "Jan Kowalski",
            DataWypozyczenia = new DateTime(2025, 1, 10),
            DataZwrotu = null,
            KsiazkaId = 1
        };
        var wyniki = new List<ValidationResult>();
        var kontekst = new ValidationContext(wypozyczenie);
        var jestPoprawne = Validator.TryValidateObject(wypozyczenie, kontekst, wyniki, true);
        Assert.True(jestPoprawne);
    }

    [Fact]
    public void Wypozyczenie_DataZwrotu_MozeByćNull()
    {
        var wypozyczenie = new Wypozyczenie
        {
            OsobaWypozyczajaca = "Anna Nowak",
            DataWypozyczenia = DateTime.Now,
            DataZwrotu = null,
            KsiazkaId = 2
        };
        Assert.Null(wypozyczenie.DataZwrotu);
    }
}
