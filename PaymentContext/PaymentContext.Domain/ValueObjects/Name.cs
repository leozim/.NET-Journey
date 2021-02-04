using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        private const int MIN_CHARACTERS_FOR_NAME = 3;
        private const int MAX_CHARACTERS_FOR_NAME = 40;

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, MIN_CHARACTERS_FOR_NAME, "Name.FirstName", $"Nome deve conter pelo menos {MIN_CHARACTERS_FOR_NAME} caracteres.")
                .HasMinLen(LastName, MIN_CHARACTERS_FOR_NAME, "Name.LastName", $"Sobrenome deve conter pelo menos {MIN_CHARACTERS_FOR_NAME} caracteres.")
                .HasMaxLen(LastName, MAX_CHARACTERS_FOR_NAME, "Name.LastName", $"Sobrenome deve conter pelo menos {MAX_CHARACTERS_FOR_NAME} caracteres.")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
