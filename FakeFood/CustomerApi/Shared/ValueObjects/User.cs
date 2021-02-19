using FakeFood.CustomerApi.Shared.Enums;
using System;

namespace FakeFood.CustomerApi.Shared.ValueObjects
{
    public class User
    {
        public User(DateTime birthday, string username,
                    Password password, Email address,
                    string phone)
        {
            Birthday = birthday.Date;
            Username = username;
            Password = password;
            Address = address;
            Phone = phone;
        }

        public DateTime Birthday { get; private set; }
        public string Username { get; private set; }
        public Password Password { get; private set; }
        public ERole Role { get; private set;}
        public Email Address { get; private set; }
        public string Phone { get; private set; }

        public void DefineRole(ERole role)
        {
            Role = role;
        }
    }
}
