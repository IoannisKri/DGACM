using System;
using System.ComponentModel;
using Library.Domain;
using System.Diagnostics;
using static Library.Domain.Reservation;

namespace Library.Domain
{
    public static class Events
    {

        /*
        We can publish events to some message bus, and other components in our system subscribe to those messages.
        The subscribed systems can then execute reactive behavior, and make some changes in their domain models

        All properties in Event classes are of primitive types and not value objects.
        The reason for only using primitive types in events is because domain events, as mentioned before, are often used across systems.
        Events can be seen as our system published contract.
        */
        public class BookCreated
        {
            public Guid Id { get; set; }
            public string bookTitle { get; set; }
            public int quantity { get; set; }
            public string bookCategory { get; set; }
            public decimal bookPrice { get; set; }



        }

        public class BookQuantityUpdated
        {
            public Guid Id { get; set; }
            public int quantity { get; set; }
        }

        public class BookTitleUpdated
        {
            public Guid Id { get; set; }
            public string bookTitle { get; set; }
        }


        public class ReservationRequested
        {
            public Guid Id { get; set; }
            public Guid patronId { get; set; }

            public Price bookPrice { get; set; }
            public ReservationDate dateStart { get; set; }
            public ReservationDate dateEnd { get; set; }

            public Guid reservationId { get; set; }
        }
        public class ReservationPaid
        {
            public Guid Id { get; set; }

            public Price paidAmount { get; set; }
     

            public Guid reservationId { get; set; }
        }

        public class ReservationStateUpdated
        {
            public Guid Id { get; set; }

            public ReservationState state { get; set; }
        }





    }
}
