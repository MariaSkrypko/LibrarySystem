using System;
using System.Linq;
using LibraryModel;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new LibraryContext())
            {
              
                var author = new Author
                {
                    FirstName = "J.K.",
                    LastName = "Rowling",
                    MiddleName = "Katherine",
                    BirthDate = new DateTime(1965, 7, 31)
                };

                var book = new Book
                {
                    Title = "Harry Potter and the Sorcerer's Stone",
                    Year = 1997,
                    PublisherCode = "978-1-4088-5569-5",
                    PublisherType = "ISBN",
                    PublisherCountry = "UK",
                    PublisherCity = "London",
                    Authors = new[] { author }
                };

                context.Books.Add(book);
                context.SaveChanges();
                Console.WriteLine($"Book '{book.Title}' by {author.FirstName} {author.LastName} added.");

                // Пример добавления читателя
                var reader = new Reader
                {
                    Login = "reader1",
                    Password = "password1",
                    Email = "reader1@mail.com",
                    FirstName = "John",
                    LastName = "Doe",
                    DocumentType = "Passport",
                    DocumentNumber = "1234567890"
                };

                context.Readers.Add(reader);
                context.SaveChanges();
                Console.WriteLine($"Reader '{reader.FirstName} {reader.LastName}' added.");

               
                var borrowedBook = new BorrowedBook
                {
                    BookId = book.BookId,
                    ReaderId = reader.ReaderId,
                    BorrowedDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(30)
                };

                context.BorrowedBooks.Add(borrowedBook);
                context.SaveChanges();
                Console.WriteLine($"Book '{book.Title}' borrowed by {reader.FirstName} {reader.LastName}.");

              
                var books = context.Books.ToList();
                Console.WriteLine("\nAll books:");
                foreach (var b in books)
                {
                    Console.WriteLine($"Title: {b.Title}, Year: {b.Year}, Authors: {string.Join(", ", b.Authors.Select(a => a.FirstName + " " + a.LastName))}");
                }

               
                var authorBooks = context.Books
                    .Where(b => b.Authors.Any(a => a.FirstName == "J.K." && a.LastName == "Rowling"))
                    .ToList();

                Console.WriteLine("\nBooks by J.K. Rowling:");
                foreach (var b in authorBooks)
                {
                    Console.WriteLine($"Title: {b.Title}");
                }

             
                var readers = context.Readers.ToList();
                Console.WriteLine("\nReaders:");
                foreach (var r in readers)
                {
                    Console.WriteLine($"Reader: {r.FirstName} {r.LastName}, Email: {r.Email}");
                }

               
                var borrowedBooks = context.BorrowedBooks
                    .Where(b => b.ReturnedDate == null)  
                    .OrderBy(b => b.DueDate) 
                    .ToList();

                Console.WriteLine("\nBorrowed books (to be returned):");
                foreach (var borrowed in borrowedBooks)
                {
                    var bookInfo = context.Books.Find(borrowed.BookId);
                    Console.WriteLine($"Book: {bookInfo.Title}, Reader: {borrowed.Reader.FirstName} {borrowed.Reader.LastName}, Return Date: {borrowed.DueDate}");
                }
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
