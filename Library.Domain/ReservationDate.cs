

using Library.Framework;
using System.ComponentModel;

namespace Library.Domain
{
    public class ReservationDate : Value<ReservationDate>
    {
        /*
        Define a factory method (FromString) that takes a string parameter (title) and returns a new instance of the class initialized with the value.
        This is a common pattern used in domain-driven design (DDD) to provide a clear and expressive way of creating instances of value objects or entities.
        The use of the => syntax and the "target-typed new" feature helps keep the code concise and readable.
         */
        public static ReservationDate FromString(string date) => new ReservationDate(date);
        public DateTime Value { get; }

        public ReservationDate(string value)
        {
            DateTime parsedDate = DateTime.Parse(value);
            if (parsedDate < DateTime.Now)
                throw new ArgumentException("Date cannot be in the past");

            Value = parsedDate;
        }


        public static implicit operator string(ReservationDate reservationDate) =>
                  reservationDate.Value.ToString();




        public static implicit operator ReservationDate(string value)
            => new ReservationDate(value);

        public override string ToString() => Value.ToString();


    }
}

