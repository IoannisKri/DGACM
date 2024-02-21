// See https://aka.ms/new-console-template for more information
using Library.Domain;


BookId bookId = new(Guid.NewGuid());
BookTitle bookTitle = BookTitle.FromString("Amazing Book");
Quantity bookQuantity = Quantity.FromInt(5);
Book myBook = Book.CreateBook(bookId, bookTitle, bookQuantity);
Console.WriteLine("Hello, World!");
