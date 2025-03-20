using System;
using System.Linq;

// Перелічуваний тип для формату книги
enum Size { Pocket, Standard, Big }

// Клас Person, що містить інформацію про автора
class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    public Person(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}, born {BirthDate.ToShortDateString()}";
    }
}

// Клас Book, що містить інформацію про книгу
class Book
{
    public Person Author { get; set; }
    public string Title { get; set; }
    public Size Format { get; set; }
    public DateTime PublishDate { get; set; }

    public Book(Person author, string title, DateTime publishDate, Size format)
    {
        Author = author;
        Title = title;
        PublishDate = publishDate;
        Format = format;
    }

    public override string ToString()
    {
        return $"Book: {Title}, Author: {Author}, Format: {Format}, Published: {PublishDate.ToShortDateString()}";
    }
}

// Клас Publisher, що містить інформацію про видавництво
class Publisher
{
    public string Name { get; set; }
    public string Address { get; set; }
    public int RegistrationYear { get; set; }
    public DateTime LicenseExpiration { get; set; }
    public Book[] Books { get; private set; } = new Book[0];

    public Publisher(string name, string address, int registrationYear, DateTime licenseExpiration)
    {
        Name = name;
        Address = address;
        RegistrationYear = registrationYear;
        LicenseExpiration = licenseExpiration;
    }

    public void AddBooks(params Book[] newBooks)
    {
        Books = Books.Concat(newBooks).ToArray();
    }

    public Book LastPublishedBook => Books.Length > 0 ? Books.OrderByDescending(b => b.PublishDate).FirstOrDefault() : null;

    public override string ToString()
    {
        string booksInfo = Books.Length > 0 ? string.Join("\n", Books.Select(b => b.ToString())) : "No books published yet";
        return $"Publisher: {Name}, Address: {Address}, Registered: {RegistrationYear}, License valid until: {LicenseExpiration.ToShortDateString()}\nBooks:\n{booksInfo}";
    }

    public string ToShortString()
    {
        return $"Publisher: {Name}, Address: {Address}, Registered: {RegistrationYear}, License valid until: {LicenseExpiration.ToShortDateString()}, Books count: {Books.Length}";
    }
}

class Program
{
    static void Main()
    {
        // Створення об'єкта видавництва
        Publisher publisher = new Publisher("ABC Publishing", "123 Main St", 1995, new DateTime(2030, 12, 31));
        Console.WriteLine(publisher);

        // Оновлення даних видавництва
        publisher.Name = "XYZ Publishing";
        publisher.Address = "456 Elm St";
        publisher.RegistrationYear = 2000;
        publisher.LicenseExpiration = new DateTime(2040, 12, 31);
        Console.WriteLine(publisher.ToShortString());

        // Створення об'єкта видавництва з параметрами
        Publisher newPublisher = new Publisher("New Age Books", "789 Pine St", 2010, new DateTime(2025, 12, 31));
        Console.WriteLine(newPublisher);

        // Додавання книг
        Person author = new Person("John", "Doe", new DateTime(1980, 5, 22));
        Book book1 = new Book(author, "C# Programming", new DateTime(2022, 6, 15), Size.Standard);
        Book book2 = new Book(author, "Advanced C#", new DateTime(2023, 1, 10), Size.Big);
        newPublisher.AddBooks(book1, book2);
        Console.WriteLine(newPublisher);

        // Виведення останньої книги
        Console.WriteLine($"Last Published Book: {newPublisher.LastPublishedBook}");
    }
}
