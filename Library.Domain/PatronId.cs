
using Library.Framework;

namespace Library.Domain
{
    public class PatronId : Value<PatronId>
    {
        private readonly Guid Value;
        public PatronId(Guid value)
        {
            if (value == default) // default makes sure that guid is valid
                throw new ArgumentException(
                 "Identity must be specified", nameof(value));
            Value = value;

        }
        //Implicit conversion allows us to simplify the assignments between entity properties and event properties significantly, although they are of incompatible types.

        public static implicit operator Guid(PatronId self) => self.Value;

        public static implicit operator PatronId(string value)
            => new PatronId(Guid.Parse(value));


    }
}


