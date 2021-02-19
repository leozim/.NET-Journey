using FakeFood.Domain.CustomerContext.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeFood.Domain.CustomerContext.Entities
{
    public class Address
    {
        public Address() { }
        public Address(string street, string number, string complement,
                       string district, string city, string state,
                       string country, string zipCode, EAddressCategory addressCategory)
        {
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            AddressCategory = addressCategory;
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public EAddressCategory AddressCategory { get; private set; }
    }
}
