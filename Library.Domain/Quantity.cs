

namespace Library.Domain
{
    public record Quantity
    {
        /*
        Define a factory method (FromString) that takes a string parameter (title) and returns a new instance of the class initialized with the value.
        This is a common pattern used in domain-driven design (DDD) to provide a clear and expressive way of creating instances of value objects or entities.
        The use of the => syntax and the "target-typed new" feature helps keep the code concise and readable.
         */
        public static Quantity FromString(string quantity) => new Quantity(quantity);
        public static Quantity FromInt(int quantity) => new Quantity(quantity);

        public int Value { get; }

        public Quantity(string value)
        {
            if (value == "")
                throw new ArgumentException("Book Quantity cannot be an empty string.");
            bool isConvertible = false;
            int myInt = 0;

            isConvertible = int.TryParse(value, out myInt);

            if (isConvertible && Convert.ToInt32(value) > 0) 
            
                Value = Convert.ToInt32(value);
            
            else
                throw new ArgumentException("Provided Quantity is not valid");

        }

        public Quantity(int value)
        {
            if (value > 0)
                
                Value = value;
            else
                throw new ArgumentException("Provided Quantity is not valid");

        }

    }
}

