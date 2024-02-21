

namespace Library.Domain
{
    public record BookTitle
    {
        /*
        Define a factory method (FromString) that takes a string parameter (title) and returns a new instance of the class initialized with the value.
        This is a common pattern used in domain-driven design (DDD) to provide a clear and expressive way of creating instances of value objects or entities.
        The use of the => syntax and the "target-typed new" feature helps keep the code concise and readable.
         */
        public static BookTitle FromString(string bookTitle) => new BookTitle(bookTitle);
        public string Value { get; }

        public BookTitle(string value)
        {
            if (value.Length > 100)
                throw new ArgumentOutOfRangeException(
                    "Book Title cannot be longer that 100 characters",
                    nameof(value)); // just ensuring that book titles remain witihn a meaningful size
            if (value == "")
                throw new ArgumentException("Book Title cannot be an empty string.");
            Value = value;
        }

        public static implicit operator string(BookTitle email) =>
            email.Value;


    }
}

