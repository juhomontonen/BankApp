using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankApp
{
    class Bank
    {
        //fields
        private string _name;
        private List<Account> _accounts;

        internal List<Account> Accounts { get => _accounts; set => _accounts = value; }

        //Constructor
        public Bank(string name, List<Account> accounts)
        {
            _name = name;
            Accounts = accounts;
        }

        //Overload constructor
        public Bank(string name)
        {
            _name = name;
            Accounts = new List<Account>();
        }

        //methods
        public string CreateAccount()
        {
            Random rnd = new Random();
            string rndAccount = "FI";

            for (int i = 0; i < 16; i++)
            {
                rndAccount += rnd.Next(0, 10);
            }
            Accounts.Add(new Account(rndAccount));
            return rndAccount;
        }

        public bool AddTransactionForCustomer(string accountNumber, Transaction transaction)
        {
            return (from account in Accounts
                    where account.AccountNumber == accountNumber
                    select account).First().AddTransaction(transaction);
        }

        //Get account info
        public double GetBalanceForCustomer (string accountNumber)
        {
            return (from account in Accounts
                    where account.AccountNumber == accountNumber
                    select account).FirstOrDefault().Balance;
        }
        // Printtaa tapahtumat ajalta
        public List<Transaction> GetTransactionsForCustomerForTimeSpan(string accountNumber,
            DateTime startTime, DateTime endTime)
        {
            return Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber)
                .GetTransactionForTimeSpan(startTime, endTime);

            //toinen tapa tehdä
            //return (from account in _accounts
            //        where account.AccountNumber == accountNumber
            //        select account).FirstOrDefault().GetTransactionsForTimeSpan(startTime, endTime);
        }

    }
}
