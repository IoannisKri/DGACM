using System;

using Library.Framework;

namespace Library.Domain
{
    public class Price : Value<Price>
    {
        public decimal Amount { get; }

        private Price(decimal amount)

        {
            if (amount < 0)
                throw new ArgumentException(
                    "Price cannot be negative",
                    nameof(amount));
            else
                Amount = amount;
        }

        public new static Price FromDecimal(decimal amount) =>
            new Price(amount);

    }
}


