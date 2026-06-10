INSERT INTO Autor (Imie, Nazwisko) VALUES ('Adam', 'Mickiewicz');
INSERT INTO Autor (Imie, Nazwisko) VALUES ('Henryk', 'Sienkiewicz');
INSERT INTO Autor (Imie, Nazwisko) VALUES ('Bolesław', 'Prus');
INSERT INTO Autor (Imie, Nazwisko) VALUES ('Stanisław', 'Lem');

INSERT INTO Ksiazka (Tytul, RokWydania, Gatunek, AutorId) VALUES ('Pan Tadeusz', 1834, 'Epos', 1);
INSERT INTO Ksiazka (Tytul, RokWydania, Gatunek, AutorId) VALUES ('Dziady', 1823, 'Dramat', 1);
INSERT INTO Ksiazka (Tytul, RokWydania, Gatunek, AutorId) VALUES ('Quo Vadis', 1896, 'Powieść historyczna', 2);
INSERT INTO Ksiazka (Tytul, RokWydania, Gatunek, AutorId) VALUES ('Krzyżacy', 1900, 'Powieść historyczna', 2);
INSERT INTO Ksiazka (Tytul, RokWydania, Gatunek, AutorId) VALUES ('Lalka', 1890, 'Powieść', 3);
INSERT INTO Ksiazka (Tytul, RokWydania, Gatunek, AutorId) VALUES ('Solaris', 1961, 'Science fiction', 4);
INSERT INTO Ksiazka (Tytul, RokWydania, Gatunek, AutorId) VALUES ('Cyberiada', 1965, 'Science fiction', 4);

INSERT INTO Wypozyczenie (OsobaWypozyczajaca, DataWypozyczenia, DataZwrotu, KsiazkaId) VALUES ('Jan Kowalski', '2025-01-10', '2025-01-24', 1);
INSERT INTO Wypozyczenie (OsobaWypozyczajaca, DataWypozyczenia, DataZwrotu, KsiazkaId) VALUES ('Anna Nowak', '2025-02-15', NULL, 3);
INSERT INTO Wypozyczenie (OsobaWypozyczajaca, DataWypozyczenia, DataZwrotu, KsiazkaId) VALUES ('Piotr Wiśniewski', '2025-03-01', '2025-03-15', 5);
INSERT INTO Wypozyczenie (OsobaWypozyczajaca, DataWypozyczenia, DataZwrotu, KsiazkaId) VALUES ('Maria Zielińska', '2025-04-20', NULL, 6);
