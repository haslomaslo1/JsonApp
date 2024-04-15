using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;

namespace Biblioteka
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> ksiazki;
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine("Wybierz opcję:");
                Console.WriteLine("1. Dodaj nową książkę");
                Console.WriteLine("2. Wyświetl wszystkie książki");
                Console.WriteLine("3. Zapisz i wyjdź");

                string choice = Console.ReadLine();

                string json = File.ReadAllText("ksiazki.json");
                ksiazki = JsonSerializer.Deserialize<List<Book>>(json);

                switch (choice)
                {
                    case "1":
                        AddBook(ksiazki);
                        break;
                    case "2":
                        WyswietlBooks(ksiazki);
                        break;
                    case "3":
                        repeat = false;             
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                        break;
                }
            }
        }

        static void AddBook(List<Book> ksiazki)
        {
            Console.Write("Tytuł: ");
            string title = Console.ReadLine();
            Console.Write("Autor: ");
            string author = Console.ReadLine();
            Console.Write("RokWydania: ");
            int releasedate = Convert.ToInt32(Console.ReadLine());
            Console.Write("Gatunek: ");
            string genre = Console.ReadLine();

            ksiazki.Add(new Book { Tytul = title, Autor = author, RokWydania = releasedate, Gatunek = genre });
            string json = File.ReadAllText("ksiazki.json");
            string jsonD = JsonSerializer.Serialize<List<Book>>(ksiazki);
            File.WriteAllText("ksiazki.json", jsonD);
            Console.WriteLine("Książka dodana!");
        }

        static void WyswietlBooks(List<Book> books)
        {
            for (int i = 0; i < books.Count; i++)
            {
                Book book = books[i];
                Console.WriteLine($"ID: {book.Id}, Tytuł: {book.Tytul}, Autor: {book.Autor}, RokWydania: {book.RokWydania}, Gatunek: {book.Gatunek}");
            }
        }

     
    }

    public class Book
    {
        public int Id { get; set; }
        public string Tytul { get; set; }
        public string Autor { get; set; }
        public int RokWydania { get; set; }
        public string Gatunek { get; set; }
    }
}