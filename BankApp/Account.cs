using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankApp
{
    class Account
    {
        //Fields
        private string _accountNumber;
        private double _balance;
        private List<Transaction> _transactions;
        
        //Constructor jotta voi lisätä rnd tilin listaan 
        public Account(string accountNumber)
        {
            AccountNumber = accountNumber;
            _transactions = new List<Transaction>();
        }

        //Constructor
        public Account(string accountNumber, double balance, List<Transaction> transactions)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            _transactions = transactions;
        }

        public string AccountNumber { get => _accountNumber; set => _accountNumber = value; }
        public double Balance { get => _balance; set => _balance = value; }

        //Methods
        public bool AddTransaction(Transaction transaction)
        {
            bool res = false;

            _transactions.Add(transaction);
            double balanceBeforeTransaction = Balance;
            if (_transactions.Last().Equals(transaction))
            {
                Balance += transaction.Sum;
            }
            if (Balance - transaction.Sum == balanceBeforeTransaction)
            {
                res = true;
            }
            return res;
        }
        public List<Transaction> GetTransactionForTimeSpan(DateTime startTime, DateTime endTime)
        {
            List<Transaction> res = (from transaction in _transactions
                                     where transaction.Timestamp >= startTime && transaction.Timestamp <= endTime
                                     orderby transaction.Timestamp
                                     select transaction).ToList();
            return res;
        }
    }
}
