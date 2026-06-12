# Plan prezentacji — Cyfrowa Biblioteka (5 min)

---

## 1. GitHub — 30 sek
- Pokaż repo: README, struktura folderów
- Powiedz: "Projekt spełnia wszystkie wymagania: README ze spisem treści, kod źródłowy, dane przykładowe"

---

## 2. Architektura MVC — 1 min
Otwórz w edytorze i pokaż 3 warstwy:

| Warstwa | Plik | Co powiedzieć |
|---------|------|---------------|
| **Model** | `Models/Ksiazka.cs` | "Dane + walidacja DataAnnotations — [Required], [Range]" |
| **Controller** | `Controllers/KsiazkiController.cs` | "Obsługuje żądania HTTP, pobiera dane z DB, wysyła do widoku" |
| **View** | `Views/Ksiazki/Index.cshtml` | "Tylko wyświetlanie — zero logiki biznesowej" |

Kluczowe zdanie: "Model nie wie o widoku, widok nie wie o bazie — to jest MVC."

---

## 3. Demo w przeglądarce — 2 min
Otwórz `http://localhost:5157`

1. **Autorzy** → Utwórz nowego autora → celowo zostaw pole puste → **pokaż walidację klienta** → wypełnij poprawnie → Zapisz
2. **Książki** → Utwórz książkę, przypisz autora → pokaż że `Autor` to obiekt, nie tekst (relacja!)
3. **Szukaj** → wpisz fragment tytułu → pokaż filtr po autorze
4. **Wypożyczenia** → Utwórz wypożyczenie → "trzeci model z relacją do Książki"

---

## 4. Testy + Docker — 1 min
W terminalu:
```bash
cd CyfrowaBiblioteka.Tests
dotnet test
```
"Wszystkie testy przechodzą — sprawdzam modele: Autor, Książka, Wypożyczenie"

Pokaż `Dockerfile` i `docker-compose.yml`:
"Jedna komenda `docker-compose up --build` — działa na każdym systemie"

---

## 5. Podsumowanie — 30 sek
"Projekt realizuje:
- wzorzec MVC (ASP.NET Core)
- 3 modele z relacjami (Książka → Autor, Wypożyczenie → Książka)
- CRUD, walidacja dwustronna, wyszukiwanie
- testy jednostkowe xUnit
- Docker"

---

## Zrealizowane punkty dodatkowe (6/8):
✅ Dwa dodatkowe modele z relacjami  
✅ Ostylowane tabele (Bootstrap 5)  
✅ Docker (Dockerfile + docker-compose)  
✅ Testy jednostkowe (xUnit)  
✅ Walidacja serwer + klient  
✅ Filtrowanie i wyszukiwanie  
❌ Zewnętrzne API  
❌ System logowania  
