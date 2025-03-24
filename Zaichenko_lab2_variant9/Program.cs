using System;
using System.Linq;

public enum Size
{
    Pocket,
    Standard,
    Big
}

public class Person
{
    private string firstName;
    private string lastName;
    private DateTime birthDate;

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public DateTime BirthDate
    {
        get { return birthDate; }
        set { birthDate = value; }
    }

    public int BirthYear
    {
        get { return birthDate.Year; }
        set { birthDate = new DateTime(value, birthDate.Month, birthDate.Day); }
    }

    public Person(string firstName, string lastName, DateTime birthDate)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.birthDate = birthDate;
    }

    public Person()
    {
        this.firstName = "DefaultFirstName";
        this.lastName = "DefaultLastName";
        this.birthDate = DateTime.MinValue;
    }

    public override string ToString()
    {
        return $"{firstName} {lastName}, born on {birthDate.ToShortDateString()}";
    }

    public virtual string ToShortString()
    {
        return $"{firstName} {lastName}";
    }
}

public class Book
{
    public Person Author { get; set; }
    public string Title { get; set; }
    public Size Format { get; set; }
    public DateTime PublicationDate { get; set; }

    public Book(Person author, string title, DateTime publicationDate, Size format)
    {
        Author = author;
        Title = title;
        PublicationDate = publicationDate;
        Format = format;
    }

    public Book()
    {
        Author = new Person();
        Title = "DefaultTitle";
        PublicationDate = DateTime.MinValue;
        Format = Size.Standard;
    }

    public override string ToString()
    {
        return $"Author: {Author.ToShortString()}, Title: {Title}, Format: {Format}, Published: {PublicationDate.ToShortDateString()}";
    }
}

public class Publisher
{
    private string name;
    private string registrationAddress;
    private int registrationYear;
    private DateTime licenseExpiryDate;
    private Book[] books;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string RegistrationAddress
    {
        get { return registrationAddress; }
        set { registrationAddress = value; }
    }

    public int RegistrationYear
    {
        get { return registrationYear; }
        set { registrationYear = value; }
    }

    public DateTime LicenseExpiryDate
    {
        get { return licenseExpiryDate; }
        set { licenseExpiryDate = value; }
    }

    public Book[] Books
    {
        get { return books; }
        set { books = value; }
    }

    public Book LastPublishedBook
    {
        get
        {
            if (books == null || books.Length == 0)
                return null;
            return books[books.Length - 1];
        }
    }

    public Publisher(string name, string registrationAddres, DateTime licenseExpiryDate, int registrationYear)
    {
        this.name = name;
        this.registrationAddress = registrationAddres;
        this.licenseExpiryDate = licenseExpiryDate;
        this.registrationYear = registrationYear;
        this.books = new Book[0];
    }

    public Publisher()
    {
        this.name = "DefaultPublisher";
        this.registrationAddress = "DefaultAddress";
        this.registrationYear = 2000;
        this.licenseExpiryDate = new DateTime(2001, 01, 01);
        this.books = new Book[0];
    }

    public void AddBooks(params Book[] newBooks)
    {
        int oldLength = books.Length;
        Array.Resize(ref books, oldLength + newBooks.Length);
        Array.Copy(newBooks, 0, books, oldLength, newBooks.Length);
    }

    public override string ToString()
    {
        string bookList = books.Length > 0 ? string.Join(", ", books.Select(b => b.ToString())) : "No books";
        return $"Name: {name}, Address: {registrationAddress}, Registration Year: {registrationYear}, License Expiry: {licenseExpiryDate.ToShortDateString()}, Books: {bookList}";
    }

    public virtual string ToShortString()
    {
        return $"Name: {name}, Address: {registrationAddress}, Registration Year: {registrationYear}, License Expiry: {licenseExpiryDate.ToShortDateString()}, Number of Books: {books.Length}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // 1.Створити об'єкт типу Publisher, з використанням конструктора без параметрів, перетворити дані в текстовий вид за допомогою методу ToString() і вивести їх.
        Publisher publisher1 = new Publisher();
        Console.WriteLine(publisher1.ToString());

        // 2. Присвоїти нові значення всім властивостям створеного об’єкту, перетворити дані в текстовий вид за допомогою методу ToShortString() і вивести їх.
        publisher1.Name = "NewPublisher";
        publisher1.RegistrationAddress = "NewAddress";
        publisher1.RegistrationYear = 2025;
        publisher1.LicenseExpiryDate = new DateTime(2030, 12, 31);
        Console.WriteLine(publisher1.ToShortString());

        // 3.Створити об'єкт типу Publisher з використанням конструктора з параметрами, перетворити дані в текстовий вид за допомогою методу ToString() і вивести їх.
        Publisher publisher2 = new Publisher("ParamPublisher", "NewAddress", new DateTime(2040, 12, 31), 2027);
        Console.WriteLine(publisher2.ToString());

        // 4.За допомогою методу AddBooks (params Book[] ) додати елементи до списку книг другого об’єкту і вивести його дані з використанням методу ToString().
        Book book1 = new Book(new Person("Author1FirstName", "Author1LastName", new DateTime(1980, 1, 1)), "Book1Title", new DateTime(2020, 1, 1), Size.Standard);
        Book book2 = new Book(new Person("Author2FirstName", "Author2LastName", new DateTime(1990, 2, 2)), "Book2Title", new DateTime(2021, 2, 2), Size.Big);
        Book book3 = new Book(new Person("Author3FirstName", "Author3LastName", new DateTime(1990, 2, 2)), "Book2Title", new DateTime(2022, 3, 2), Size.Pocket);
        publisher2.AddBooks(book1, book2, book3);
        Console.WriteLine(publisher2.ToString());

        // 5.Вивести значення властивості, яка повертає посилання на останню видану книгу.
        Console.WriteLine($"Last Published Book: {publisher2.LastPublishedBook}");
    }
}