using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var endTime = DateTime.Today;
            var time = new TimeSpan(24 * 30 * 6, 0, 0);
            var startTIme = endTime.Date - time;

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("BankApp v1.0\n");
            Bank bank1 = new Bank("Ankkalinnan pankki");

            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer("Aku", "Ankka", bank1.CreateAccount()));
            customers.Add(new Customer("Roope", "Ankka", bank1.CreateAccount()));
            customers.Add(new Customer("Hannu", "Hanhi", bank1.CreateAccount()));

            //asiakkaiden tulostus
            for(int i = 0; i < customers.Count; i++)
            {
                PrintBalance(bank1, customers[i]);
            }

            //tilitapahtumien lisääminen 
            for(int i = 0; i <200; i++)
            {
                Random rnd = new Random();
                bank1.AddTransactionForCustomer(customers[rnd.Next(0,3)].AccountNumber,
                new Transaction(rnd.Next(-100000,1000000) , new DateTime(rnd.Next(2016,2019), rnd.Next(1,12), rnd.Next(1, 28))));
            }

            Console.WriteLine($"\nTilitapahtumat viimeisen kuuden kuukauden ajalta: {startTIme.ToShortDateString()}-" +
                            $"{endTime.ToShortDateString()}\n");

            //tilitapahtumien tulostus
            for (int i = 0; i < customers.Count; i++)
            {
                PrintTransactions(bank1.GetTransactionsForCustomerForTimeSpan(customers[i].AccountNumber,
                startTIme, endTime), customers[i]);
            }

            //asiakkaiden tulostus uudestaan jotta nähdään päivittynyt saldo
            for (int i = 0; i < customers.Count; i++)
            {
                PrintBalance(bank1, customers[i]);
            }

            Console.WriteLine("\n<Press any key to exit>");
            Console.ReadLine();
        }
        //Asiakkaan ja tilitapahtumien tulostus

        public static void PrintBalance(Bank bank, Customer customer)
        {
            var balance = bank.GetBalanceForCustomer(customer.AccountNumber);
            Console.WriteLine("{0} - balance: {1}{2:0.00}",
                customer.ToString(), balance >= 0 ? "+" : "", balance);

            //toinen tapa tehdä
            //if (balance >= 0)
            //    Console.WriteLine($"{customer.ToString()} - balance: + {balance:C}");
            //else
            //    Console.WriteLine($"{customer.ToString()} - balance: {balance:C}");
        }

        //tapahtumien tulostus
        public static void PrintTransactions(List<Transaction> transactions, Customer customer)
        {
            Console.WriteLine($"Tilitapahtumat {customer.FirstName} {customer.LastName}:");

            for (int i = 0; i < transactions.Count(); i++)
            {
                Console.WriteLine("{0}\t{1}{2:0.00}",
                    transactions[i].Timestamp.ToShortDateString(),
                transactions[i].Sum >= 0 ? "+" : "",
                    transactions[i].Sum);
            }
            Console.WriteLine("\n");
        }
        //toinen tapa tehdä
        //if (transactions[i].Sum > 0)
        //Console.WriteLine($"{transactions[i].TimeStamp.ToShortDateString()}\t" +
        //                    $"{transactions.[i].Sum:F}");  
    }
}

