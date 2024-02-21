
using System.ComponentModel;
using System.Diagnostics;
using Library.Domain;
using Library.Framework;

namespace Library.Domain
{

    public class Book : AggregateRoot<BookId>
    {
        public BookCategory bookCategory { get; private set; } //ValueObject

        public BookTitle bookTitle { get; private set; } //ValueObject
        public Quantity quantity { get; private set; } //ValueObject
        public HashSet<Reservation> reservations { get; private set; }
        public Price BookPrice { get; private set; }

        protected Book(BookId id, BookTitle bookTitle, Quantity quantity, BookCategory bookCategory, Price bookPrice)
        {


            Apply(new Events.BookCreated
            {
                Id = id,
                bookTitle = bookTitle,
                bookCategory = bookCategory,
                bookPrice = bookPrice.Amount,
                quantity = quantity.Value
            });
        }


        public static Book CreateBook(BookId id, BookTitle bookTitle, Quantity quantity, BookCategory bookCategory, Price bookPrice)
        {
            return new Book(id, bookTitle, quantity, bookCategory, bookPrice);
        }



        public void UpdateBookQuantity(Quantity quantity)
        {
            Apply(new Events.BookQuantityUpdated
            {
                Id = Id,
                quantity = quantity.Value
            });
        }

        public void UpdateBookTitle(BookTitle bookTitle)
        {
            Apply(new Events.BookTitleUpdated
            {
                Id = Id,
                bookTitle = bookTitle
            });
        }

        
            public void RequestReservation(ReservationDate dateStart,  ReservationDate dateEnd, PatronId patronId, ReservationId reservationId)
            {
                Apply(new Events.ReservationRequested
                {
                    Id = Id,
                    dateStart = dateStart,
                    dateEnd = dateEnd,
                    patronId = patronId,
                    reservationId = reservationId,
                    bookPrice = BookPrice

                });
            }



        public void PayReservation(ReservationId reservationId, Price paidAmount)
        {
            try
            {
                Reservation reservation = (from res in reservations where res.Id == reservationId && paidAmount.Amount == res.totalReservationCost select res).First();
                reservation.state = Reservation.ReservationState.Confirmed;
                reservation.isPaid = true;
                Apply(new Events.ReservationPaid
                {
                    Id = Id,
                    reservationId = reservationId,
                    paidAmount = paidAmount

                });


            }
            catch (Exception e)
            {
                throw new ArgumentException("Paid price doesnt match requested price");
            }
            


                

        }



        protected override void When(object @event)
        {
            Reservation reservation;

            switch (@event)
            {
                case Events.BookCreated e:
                    // initialize the aggregate root
                    Id = new BookId(e.Id);
                    bookTitle = e.bookTitle.ToString();
                    bookCategory = e.bookCategory.ToString();
                    BookPrice = Price.FromDecimal(e.bookPrice);
                    quantity = Quantity.FromInt(e.quantity);

                    reservations = new HashSet<Reservation> { };
                    break;
                case Events.BookQuantityUpdated e:
                    quantity = new Quantity(e.quantity);
                    break;

                case Events.BookTitleUpdated e:
                    bookTitle = e.bookTitle.ToString();
                    break;

                case Events.ReservationRequested e:

                    reservation = new Reservation(Apply);
                    ApplyToEntity(reservation, e);
                    reservations.Add(reservation);
                    break;
                case Events.ReservationPaid e:
                    reservation = new Reservation(Apply);
                    ApplyToEntity(reservation, e);
                    break;


            }


        }


        protected override void EnsureValidState()
        {
            bool totalReservationsCapReached = (from res in reservations where res.dateEnd.Value >= ReservationDate.FromString("2024/02/23").Value && res.dateStart.Value <= ReservationDate.FromString("2024/02/24").Value select res).Count()==quantity.Value;

            var valid = quantity.Value >= 0 && totalReservationsCapReached;
            if (!valid)
                throw new InvalidEntityStateException(
                    this, $"State-checks failed");


        }





    }

}
