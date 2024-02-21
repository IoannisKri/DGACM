namespace Library.Tests;

using Library.Domain;

public class UnitTest1
{
    [Fact]
    public void BadStringInQuantity()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Quantity quantity = Quantity.FromString("notvalid");
        });


    }

    [Fact]
    public void ZeroStringInQuantity()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Quantity quantity = Quantity.FromString("0");
        });


    }

    [Fact]
    public void NegativeFromInt()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Quantity quantity = Quantity.FromInt(-1);
        });


    }

    [Fact]
    public void TooLongBookTitle()
    {
        Assert.Throws<System.ArgumentOutOfRangeException>(() =>
        {
            BookTitle title = BookTitle.FromString(new string('*', 101));
        });


    }


    [Fact]
    public void WrongPayment()
    {


        BookId bookId = new(Guid.NewGuid());
        BookTitle bookTitle = BookTitle.FromString("Amazing Book");
        BookCategory bookCategory = BookCategory.FromString("Drama");

        Quantity bookQuantity = Quantity.FromInt(3);
        Price bookPrice = Price.FromDecimal(10.5m);
        Book myBook = Book.CreateBook(bookId, bookTitle, bookQuantity, bookCategory, bookPrice);
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

        myBook.RequestReservation(starDate, endDate, patronId, reservationId);
        myBook.RequestReservation(starDate, endDate, patronId, reservationId2);
        myBook.RequestReservation(starDate, endDate, patronId, reservationId3);
        ReservationId reservationId4 = new(Guid.NewGuid());
        Price paidAmount = Price.FromDecimal(21.0m);
        //myBook.PayReservation(reservationId, paidAmount);

        Assert.Throws<System.ArgumentException>(() =>
        {
            myBook.PayReservation(reservationId, paidAmount);
        });



    }








    [Fact]
    public void TooManyReservations()
    {


        BookId bookId = new(Guid.NewGuid());
        BookTitle bookTitle = BookTitle.FromString("Amazing Book");
        BookCategory bookCategory = BookCategory.FromString("Drama");

        Quantity bookQuantity = Quantity.FromInt(3);
        Price bookPrice = Price.FromDecimal(10.5m);
        Book myBook = Book.CreateBook(bookId, bookTitle, bookQuantity, bookCategory, bookPrice);
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

        myBook.RequestReservation(starDate, endDate, patronId, reservationId);
        myBook.RequestReservation(starDate, endDate, patronId, reservationId2);
        myBook.RequestReservation(starDate, endDate, patronId, reservationId3);
        ReservationId reservationId4 = new(Guid.NewGuid());


        Assert.Throws<System.ArgumentException>(() =>
        {
            myBook.RequestReservation(starDate, endDate, patronId, reservationId4);
        });
       


    }








}
