// Facade pattern -- Real World example

using System;

namespace Facade.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// Facade Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Facade

            var mortgage = new Mortgage();


            // Evaluate mortgage eligibility for customer

            var customer = new Customer("Ann McKinsey");

            bool eligible = mortgage.IsEligible(customer, 125000);


            Console.WriteLine("\n" + customer.Name +
                              " has been " + (eligible ? "Approved" : "Rejected"));


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Subsystem ClassA' class
    /// </summary>
    internal class Bank
    {
        public bool HasSufficientSavings(Customer c, int amount)
        {
            Console.WriteLine("Check bank for " + c.Name);

            return true;
        }
    }


    /// <summary>
    /// The 'Subsystem ClassB' class
    /// </summary>
    internal class Credit
    {
        public bool HasGoodCredit(Customer c)
        {
            Console.WriteLine("Check credit for " + c.Name);

            return true;
        }
    }


    /// <summary>
    /// The 'Subsystem ClassC' class
    /// </summary>
    internal class Loan
    {
        public bool HasNoBadLoans(Customer c)
        {
            Console.WriteLine("Check loans for " + c.Name);

            return true;
        }
    }


    /// <summary>
    /// Customer class
    /// </summary>
    internal class Customer
    {
        private readonly string _name;


        // Constructor

        public Customer(string name)
        {
            _name = name;
        }


        // Gets the name

        public string Name
        {
            get { return _name; }
        }
    }


    /// <summary>
    /// The 'Facade' class
    /// </summary>
    internal class Mortgage
    {
        private readonly Bank _bank = new Bank();

        private readonly Credit _credit = new Credit();
        private readonly Loan _loan = new Loan();


        public bool IsEligible(Customer cust, int amount)
        {
            Console.WriteLine("{0} applies for {1:C} loan\n",
                              cust.Name, amount);


            bool eligible = true;


            // Check creditworthyness of applicant

            if (!_bank.HasSufficientSavings(cust, amount))
            {
                eligible = false;
            }

            else if (!_loan.HasNoBadLoans(cust))
            {
                eligible = false;
            }

            else if (!_credit.HasGoodCredit(cust))
            {
                eligible = false;
            }


            return eligible;
        }
    }
}