// See https://aka.ms/new-console-template for more information
using Library.Domain;


BookId bookId = new(Guid.NewGuid());
BookTitle bookTitle = BookTitle.FromString("Amazing Book");
BookCategory bookCategory = BookCategory.FromString("Drama");

Quantity bookQuantity = Quantity.FromInt(3);
Price bookPrice = Price.FromDecimal(10.5m);
Book myBook = Book.CreateBook(bookId, bookTitle, bookQuantity,bookCategory,bookPrice);
//myBook.UpdateBookQuantity(Quantity.FromInt(2));

PatronId patronId = new(Guid.NewGuid());

ReservationDate starDate = ReservationDate.FromString("2025/02/20");
ReservationDate endDate = ReservationDate.FromString("2025/02/24");

ReservationDate starDate1 = ReservationDate.FromString("2025/02/22");
ReservationDate endDate1 = ReservationDate.FromString("2025/02/25");


ReservationDate starDate2 = ReservationDate.FromString("2025/02/21");
ReservationDate endDate2 = ReservationDate.FromString("2025/02/26");
ReservationId reservationId = new(Guid.NewGuid());

ReservationId reservationId2 = new(Guid.NewGuid());
ReservationId reservationId3 = new(Guid.NewGuid());

myBook.RequestReservation(starDate, endDate,patronId, reservationId);
myBook.RequestReservation(starDate, endDate, patronId, reservationId2);
myBook.RequestReservation(starDate, endDate, patronId, reservationId3);


int unpaidConfirmedReservations = (from res in myBook.reservations where res.dateEnd.Value>= ReservationDate.FromString("2025/02/23").Value && res.dateStart.Value <= ReservationDate.FromString("2025/02/24").Value select res).Count();

//Console.WriteLine(unpaidConfirmedReservations);

//Price paidAmount = Price.FromDecimal(21.0m);
//myBook.PayReservation(reservationId, paidAmount);
ReservationId reservationId4 = new(Guid.NewGuid());

//myBook.RequestReservation(starDate, endDate, patronId, reservationId4);


Patron patron = Patron.CreatePatron(patronId, "ioannis");
patron.AddReservation(reservationId3);

Console.WriteLine("Hello, World!");
