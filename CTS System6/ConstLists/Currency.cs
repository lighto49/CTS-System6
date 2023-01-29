using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.ConstLists
{
    public class Currency
    {
        public string Cur { get; set; }
        public List<Currency> currencies;

        public Currency()
        {
            currencies = new List<Currency>()
            {
                new Currency{ Cur="USD"},
                new Currency{ Cur="EGP"},
                new Currency{ Cur="AED"},
                new Currency{ Cur="SAR"},
                new Currency{ Cur="EUR"},
                new Currency{ Cur="KWD"},
            };
        }
        public IList<Currency> List()
        {
            return currencies;
        }
    }


}
