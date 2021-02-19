using FakeFood.Domain.CustomerContext.Enums;
using FakeFood.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeFood.Domain.CustomerContext.Commands.CustomerCommands
{
    public class CreateCustomerCommand : ICommand
    {
        public CreateCustomerCommand() { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Username { get; set; }
        public string Secret { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string MyProperty { get; set; }
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
