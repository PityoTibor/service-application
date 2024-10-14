using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class BookService
{
    private List<Book> _books;

    public BookService()
    {
        // JSON fájl elérési útja
        //string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "books.json");
        string filePath = @"C:\Users\ptibo\Documents\work\service-application\books.json";

        // Fájl beolvasása és deszerializálása a Book osztályba
        var json = File.ReadAllText(filePath);
        _books = JsonConvert.DeserializeObject<List<Book>>(json);
    }

    // Könyvek lekérése
    public List<Book> GetBooks()
    {
        return _books;
    }

    // Egy könyv lekérése ID alapján
    public Book GetBookById(int id)
    {
        return _books.Find(book => book.Id == id);
    }
}

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
}