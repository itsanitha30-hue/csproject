using System;
using System.Collections.Generic;

public class Book
{
    public string Title;
    public string Author;
    public int BookID; 

    public void set1(string Title, string Author, int BookID)
    {
        this.Title = Title;
        this.Author = Author;
        this.BookID = BookID;
    }

    // Method to display book information
    public void DisplayInfo()
    {
        Console.WriteLine($"Book ID: {this.BookID}");
        Console.WriteLine($"Title: {this.Title}");
        Console.WriteLine($"Author: {this.Author}");
        Console.WriteLine();
    }
}

// Person class
public class Person
{
    // Attributes
    public string Name;
    public int Age;
    public int PersonID;

    // Constructor
    public void set2(string Name, int Age, int PersonID)
    {
        this.Name = Name;
        this.Age = Age;
        this.PersonID = PersonID;
    }
    public void get1()
    {
        Console.WriteLine("Person Name:"+this.Name);
        Console.WriteLine("Person Age:"+this.Age);
        Console.WriteLine("PersonID:"+this.PersonID);
    }
}

public class Librarian : Person
{
    public int EmployeeID;//additional attribute

    public void set2(string Name,int Age,int PersonID,int EmployeeID)
        {
            this.Name = Name;
            this.Age = Age;
            this.PersonID = PersonID;
            this.EmployeeID=EmployeeID;
        }
        public void get2()
    {
        Console.WriteLine("Person Name:"+this.Name);
        Console.WriteLine("Person Age:"+this.Age);
        Console.WriteLine("PersonID:"+this.PersonID);
        Console.WriteLine("EmployeeID:"+this.EmployeeID);
    
    }

    // Methods specific to Librarian
    public void IssueBook(Book book, Person user)
    {
        Console.WriteLine($"Librarian {Name} is issuing book {book.Title} to {user.Name}.");
        // Logic to issue book
    }

    public void ReturnBook(Book book, Person user)
    {
        Console.WriteLine($"Librarian {Name} is returning book {book.Title} from {user.Name}.");
        // Logic to return book
    }
}

// Library class
public class Library
{
    public string LibraryName { get; set; }
    public int LibraryID { get; set; }
    private List<Book> books;
    private Librarian librarian;
    public Library(string libraryName, int libraryID, Librarian librarian)
    {
        LibraryName = libraryName;
        LibraryID = libraryID;
        this.librarian = librarian;
        books = new List<Book>();
    }
    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"Book '{book.Title}' added to the library.");
    }
    public void RemoveBook(int bookID)
    {
        Book bookToRemove = books.Find(b => b.BookID == bookID);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine($"Book with ID {bookID} removed from the library.");
        }
        else
        {
            Console.WriteLine($"Book with ID {bookID} not found in the library.");
        }
    }

    public void ViewBooks()
    {
        Console.WriteLine($"Books available in library '{LibraryName}':");
        foreach (var book in books)
        {
            book.DisplayInfo();
        }
    }

    // Method to search for a book by title
    public void SearchBook(string title)
    {
        Book foundBook = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (foundBook != null)
        {
            Console.WriteLine($"Book '{title}' found in library '{LibraryName}':");
            foundBook.DisplayInfo();
        }
        else
        {
            Console.WriteLine($"Book '{title}' not found in library '{LibraryName}'.");
        }
    }

    // Method to list issued books
    public void ListIssuedBooks()
    {
        // Logic to list issued books
        Console.WriteLine("List of issued books:");
        // Example implementation
    }
}

class Program
{
    static void Main()
    {
        // Create a librarian
        Librarian librarian = new Librarian();
        librarian.set2("Hussnain",25,35401,5586);

        // Create a library
        Library library = new Library("National Library", 1001, librarian);

        // Add some books to the library
        Book book1 = new Book();
        Book book2 = new Book();
        book1.set1(" Pale Fire","Vladimir Nabokov",101);
        book2.set1(" The Fault in Our Stars","John Green",102);
        library.AddBook(book1);
        library.AddBook(book2);

        // View all books in the library
        library.ViewBooks();

        // Search for a book
        library.SearchBook("Bang-e-Dara");

        // Issue a book
        Person user = new Person();
        user.set2("Hashim",27,35405);
        library.ListIssuedBooks();  // Example list issued books before issuing
        librarian.IssueBook(book1, user);
        library.ListIssuedBooks();  // Example list issued books after issuing

        // Return a book
        librarian.ReturnBook(book1, user);
        library.ListIssuedBooks();  // Example list issued books after returning
    }
}