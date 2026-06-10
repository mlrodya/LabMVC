# Cyfrowa Biblioteka

## System zarządzania cyfrową biblioteką

---

## Spis treści

1. [Opis projektu](#opis-projektu)
2. [Zaimplementowane funkcjonalności](#zaimplementowane-funkcjonalności)
3. [Technologie i biblioteki](#technologie-i-biblioteki)
4. [Wymagania wstępne](#wymagania-wstępne)
5. [Instalacja i uruchomienie](#instalacja-i-uruchomienie)
6. [Uruchomienie w kontenerze Docker](#uruchomienie-w-kontenerze-docker)
7. [Testy jednostkowe](#testy-jednostkowe)
8. [Przykładowe dane](#przykładowe-dane)

---

## Opis projektu

**Cyfrowa Biblioteka** to aplikacja webowa zbudowana w oparciu o wzorzec architektoniczny **MVC** przy użyciu technologii **ASP.NET Core 10**. Umożliwia kompleksowe zarządzanie katalogiem książek, autorów oraz historią wypożyczeń. Baza danych oparta jest na **SQLite** z wykorzystaniem **Entity Framework Core** w podejściu Code-First.

---

## Zaimplementowane funkcjonalności

### Modele i relacje
- **Autor** – przechowuje imię i nazwisko autora; posiada wyliczaną właściwość `PełneImię`; powiązany z wieloma książkami (relacja jeden-do-wielu)
- **Książka** – przechowuje tytuł, rok wydania oraz gatunek; powiązana z jednym autorem (klucz obcy `AutorId`) i wieloma wypożyczeniami
- **Wypożyczenie** – przechowuje dane osoby wypożyczającej, datę wypożyczenia oraz datę zwrotu; powiązane z jedną książką (klucz obcy `KsiazkaId`)

### Pełny CRUD dla wszystkich modeli
- **Autorzy** – lista, szczegóły, dodawanie, edycja, usuwanie
- **Książki** – lista, szczegóły, dodawanie, edycja, usuwanie
- **Wypożyczenia** – lista, szczegóły, dodawanie, edycja, usuwanie

### Walidacja danych
- Walidacja po stronie serwera (`DataAnnotations`: `[Required]`, `[StringLength]`, `[Range]`, `[DataType]`)
- Walidacja po stronie klienta (jQuery Unobtrusive Validation)
- Wszystkie komunikaty błędów w języku polskim

### Wyszukiwanie i filtrowanie
- Wyszukiwanie książek po fragmencie tytułu
- Filtrowanie książek po wybranym autorze (lista rozwijana)

### Interfejs użytkownika
- Responsywny interfejs oparty na **Bootstrap 5**
- Ostylowane tabele z kolorowymi przyciskami akcji
- Dashboard na stronie głównej z kartami nawigacyjnymi

### Kontenery Docker
- Gotowy plik `Dockerfile` z wieloetapowym budowaniem obrazu
- Plik `docker-compose.yml` umożliwiający jednokomendowe uruchomienie aplikacji

### Testy jednostkowe
- Testy modelu `Autor` (właściwość `PełneImię`, walidacja pól)
- Testy modelu `Książka` (walidacja roku wydania, tytułu)
- Testy modelu `Wypożyczenie` (walidacja pola wymaganego)

---

## Technologie i biblioteki

| Technologia / Biblioteka | Wersja |
|---|---|
| ASP.NET Core MVC | 10.0 |
| Entity Framework Core | 10.0.7 |
| Microsoft.EntityFrameworkCore.Sqlite | 10.0.7 |
| Bootstrap | 5.x (CDN) |
| jQuery Validation Unobtrusive | via bundled scripts |
| xUnit | 2.9.3 |

---

## Wymagania wstępne

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Opcjonalnie: [Docker Desktop](https://www.docker.com/get-started/) do uruchomienia w kontenerze

---

## Instalacja i uruchomienie

### 1. Sklonuj repozytorium

```bash
git clone https://github.com/TWOJ_USERNAME/NAZWA_REPO.git
cd NAZWA_REPO
```

### 2. Przejdź do folderu projektu

```bash
cd CyfrowaBiblioteka
```

### 3. Zainstaluj wymagane paczki NuGet

```bash
dotnet restore
```

### 4. Zainstaluj narzędzie Entity Framework CLI (jeśli nie jest zainstalowane)

```bash
dotnet tool install --global dotnet-ef
```

### 5. Zastosuj migracje bazy danych

```bash
dotnet ef database update
```

### 6. Uruchom aplikację

```bash
dotnet run
```

Aplikacja będzie dostępna pod adresem: `http://localhost:5000` lub `https://localhost:5001`

---

## Uruchomienie w kontenerze Docker

### Wymagania
- [Docker Desktop](https://www.docker.com/get-started/)

### 1. Zbuduj obraz i uruchom kontener

W głównym folderze repozytorium wykonaj:

```bash
docker-compose up --build
```

Aplikacja będzie dostępna pod adresem: `http://localhost:8080`

Baza danych zostanie automatycznie utworzona przy pierwszym uruchomieniu.

### 2. Zatrzymaj i usuń kontener

```bash
docker-compose down
```

---

## Testy jednostkowe

### Uruchomienie testów

```bash
cd CyfrowaBiblioteka.Tests
dotnet test
```

### Zakres testów

| Klasa testowa | Opis |
|---|---|
| `AutorTests` | Testuje właściwość `PełneImię` oraz walidację pól `Imię` i `Nazwisko` |
| `KsiazkaTests` | Testuje walidację tytułu oraz zakresu roku wydania |
| `WypozyczeniaTests` | Testuje walidację wymaganego pola `OsobaWypożyczająca` |

---

## Przykładowe dane

Plik `dane_przykladowe.sql` zawiera przykładowe rekordy dla wszystkich trzech modeli.

### Ładowanie danych (SQLite CLI)

```bash
sqlite3 CyfrowaBiblioteka/Biblioteka.db < dane_przykladowe.sql
```

> **Uwaga:** Uruchom powyższe polecenie tylko na pustej bazie danych, po wykonaniu migracji.
