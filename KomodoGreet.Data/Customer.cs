using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreet.Data
{
    public struct Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string CityAndState { get; set; }
        public int ZipCode { get; set; }

        public CustomerType Type { get; set; }
        public Customer(string first, string last, string address, string cityAndState, int zip, CustomerType type)
        {
            FirstName = first;
            LastName = last;
            Address = address;
            CityAndState = cityAndState;
            ZipCode = zip;
            Type = type;
        }
    }

    public enum CustomerType
    {
        Past,
        Potential,
        Current
    }
}
