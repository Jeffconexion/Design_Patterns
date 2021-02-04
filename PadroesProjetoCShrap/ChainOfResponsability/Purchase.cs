using System;

namespace Chain.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// Chain of Responsibility Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Setup Chain of Responsibility

            Approver larry = new Director();

            Approver sam = new VicePresident();

            Approver tammy = new President();


            larry.SetSuccessor(sam);

            sam.SetSuccessor(tammy);


            // Generate and process purchase requests

            var p = new Purchase(2034, 350.00, "Assets");

            larry.ProcessRequest(p);


            p = new Purchase(2035, 32590.10, "Project X");

            larry.ProcessRequest(p);


            p = new Purchase(2036, 122100.00, "Project Y");

            larry.ProcessRequest(p);


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Handler' abstract class
    /// </summary>
    internal abstract class Approver
    {
        protected Approver successor;


        public void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }


        public abstract void ProcessRequest(Purchase purchase);
    }


    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    internal class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                                  GetType().Name, purchase.Number);
            }

            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }


    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    internal class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 25000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                                  GetType().Name, purchase.Number);
            }

            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }


    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    internal class President : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                                  GetType().Name, purchase.Number);
            }

            else
            {
                Console.WriteLine(
                    "Request# {0} requires an executive meeting!",
                    purchase.Number);
            }
        }
    }


    /// <summary>
    /// Class holding request details
    /// </summary>
    internal class Purchase
    {
        // Constructor

        public Purchase(int number, double amount, string purpose)
        {
            Number = number;

            Amount = amount;

            Purpose = purpose;
        }


        // Gets or sets purchase number

        public int Number { get; set; }


        // Gets or sets purchase amount

        public double Amount { get; set; }


        // Gets or sets purchase purpose

        public string Purpose { get; set; }
    }
}