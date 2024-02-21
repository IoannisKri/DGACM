using System;
using System.ComponentModel;
using Library.Domain;
using System.Diagnostics;

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
        }

        public class BookUpdated
        {
            public Guid Id { get; set; }
            public string bookTitle { get; set; }
            public int quantity { get; set; }
        }

        

    }
}
