using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankApp
{
    class Transaction
    {
        //Fields
        private double _sum;
        private DateTime _timeStamp;

        //Constructor
        public Transaction(double sum, DateTime timestamp)
        {
            Sum = sum;
            Timestamp = timestamp;
        }

        public double Sum { get => _sum; set => _sum = value; }
        public DateTime Timestamp { get => _timeStamp; set => _timeStamp = value; }
    }
}
