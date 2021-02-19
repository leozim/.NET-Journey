using FakeFood.CustomerApi.Shared.Entities;
using FakeFood.CustomerApi.Shared.Enums;
using FakeFood.CustomerApi.Shared.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace FakeFood.Domain.CustomerContext.Entities
{
    public class Customer : Entity
    {
        private readonly IList<Address> _addresses;
        
        public Customer() { }
        
        public Customer(Name name, User user)
        {
            Name = name;
            User = user;
            User.DefineRole(ERole.Customer);
            _addresses = new List<Address>();
        }
        
        public Name Name { get; private set; }
        public User User { get; private set; }
        
        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();
        
        public void AddAddress(Address address)
        {
            _addresses.Add(address);
        }
    }
}
