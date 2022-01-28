using System;
using System.Collections.Generic;

namespace MoneyExample.Core
{
    public class Money 
    {

        public int Amount { get; set; }
        public String Currency { get; set; }

        public Money(int amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money operator *(Money multiplier, int multiplicant)
        => new Money(multiplier.Amount*multiplicant,multiplier.Currency);

        public static Money operator +(Money augend, Money addend)
        {
            if (augend.Currency.Equals(addend.Currency)) {
                return new Money(augend.Amount + addend.Amount, augend.Currency);
            } else
            {
                return null;
            }
        }
        

        public static Money Dollar(int amount) => new Money(amount, "USD");
        public static Money Franc(int amount) => new Money(amount, "CHF");

        public override bool Equals(object obj)
        {
            return obj is Money money &&
                   Amount == money.Amount &&
                   Currency == money.Currency;
        }

        public override int GetHashCode()
        {
            var hashCode = -259941593;
            hashCode = hashCode * -1521134295 + Amount.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Currency);
            return hashCode;
        }

        internal Money Reduce(Bank bank, string to)
        {
            var rate = bank.Rate(Currency, to);
            if (rate == null) return null;
            return new Money(Amount / rate.Value, to);
        }


    }
}
