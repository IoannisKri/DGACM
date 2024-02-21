
using Library.Framework;

namespace Library.Domain
{
    public class BookId : Value<BookId>
    {
        private readonly Guid Value;
        public BookId(Guid value)
        {
            if (value == default) // default makes sure that guid is valid
                throw new ArgumentException(
                 "Identity must be specified", nameof(value));
            Value = value;

        }
        //Implicit conversion allows us to simplify the assignments between entity properties and event properties significantly, although they are of incompatible types.

        public static implicit operator Guid(BookId self) => self.Value;

        public static implicit operator BookId(string value)
            => new BookId(Guid.Parse(value));


    }
}


