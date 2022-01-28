using System;
using System.Collections.Generic;

namespace MoneyExample.Core
{
    public class Bank
    {
        Dictionary<(string, string), int> rates = new Dictionary<(string, string), int>();

        public Bank()
        {
        }

        public Money Reduce(Money source, string to)
        {
            return source.Reduce(this, to);
        }

        public void AddRate(String from, String to, int rate)
        {
            rates[(from, to)] = rate;
        }

        public int? Rate(String from, String to)
        {
            if (from.Equals(to)) return 1;
            return rates[(from, to)];
        }
    }
}