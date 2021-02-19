using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeFood.CustomerApi.Shared.ValueObjects
{
    public class Email
    {
        public Email(string address)
        {
            Address = address;
        }
        public string Address { get; private set; }

        public void DefineEmailAddress(string address)
        {
            Address = address;
        }
    }
}
