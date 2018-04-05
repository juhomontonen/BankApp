using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    class Customer
    {
        //fields
        private string _firstName;
        private string _lastName;
        private string _accountNumber;
        
        //Constructor
        public Customer(string firstName, string lastName, string accountNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            AccountNumber = accountNumber;
        }

        public string AccountNumber { get => _accountNumber; set => _accountNumber = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }

        //Override Tostring
        public override string ToString()
        {
            return ($"Etunimi {FirstName}, " +
                $"Sukunimi {LastName}, " +
                $"Tilinumero {AccountNumber}\n");
        }
    }

}
