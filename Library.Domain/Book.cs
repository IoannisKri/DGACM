
using System.ComponentModel;
using System.Diagnostics;
using Library.Domain;
using Library.Framework;

namespace Library.Domain
{

    public class Book : AggregateRoot<BookId>
    {

        public BookTitle bookTitle { get; private set; } //ValueObject
        public Quantity quantity { get; private set; } //ValueObject
        public HashSet<Reservation> reservations { get; private set; }

        protected Book(BookId id, BookTitle bookTitle, Quantity quantity)
        {


            Apply(new Events.BookCreated
            {
                Id = id,
                bookTitle = bookTitle,
                quantity = quantity.Value
            });
        }


        public static Book CreateBook(BookId id, BookTitle bookTitle, Quantity quantity)
        {
            return new Book(id, bookTitle, quantity);
        }


        public void UpdateBook(BookTitle bookTitle, Quantity quantity)
        {
            Apply(new Events.BookUpdated
            {
                Id = Id,
                bookTitle = bookTitle,
                quantity = quantity.Value
            });
        }



        protected override void When(object @event)
        {

            switch (@event)
            {
                case Events.BookCreated e:
                    // initialize the aggregate root
                    Id = new BookId(e.Id);
                    bookTitle = e.bookTitle.ToString();
                    quantity =  Quantity.FromInt(e.quantity);
                    reservations = new HashSet<Reservation> { }; 
                    break;
                case Events.BookUpdated e:
                    // initialize the aggregate root
                    bookTitle = e.bookTitle.ToString();
                    quantity = new Quantity(e.quantity);
                    break;

            }


        }


        protected override void EnsureValidState()
        {
            var valid =

        quantity> new Quantity(0;


            if (!valid)
                throw new InvalidEntityStateException(
                    this, $"State-checks failed");


        }





    }

}
