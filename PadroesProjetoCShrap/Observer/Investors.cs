using System;
using System.Collections.Generic;

namespace Observer.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// Observer Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Create IBM stock and attach investors

            var ibm = new IBM("IBM", 120.00);

            ibm.Attach(new Investor("Sorros"));

            ibm.Attach(new Investor("Berkshire"));

            ibm.Attach(new Investor("Dósea"));


            // Fluctuating prices will notify investors

            ibm.Price = 120.10;

            ibm.Price = 121.00;

            ibm.Price = 120.50;

            ibm.Price = 120.75;


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Subject' abstract class
    /// </summary>
    internal abstract class Stock
    {
        private readonly List<IInvestor> _investors = new List<IInvestor>();
        private readonly string _symbol;

        private double _price;


        // Constructor

        public Stock(string symbol, double price)
        {
            _symbol = symbol;

            _price = price;
        }

        public double Price
        {
            get { return _price; }

            set
            {
                if (_price != value)
                {
                    _price = value;

                    Notify();
                }
            }
        }


        // Gets the symbol

        public string Symbol
        {
            get { return _symbol; }
        }


        public void Attach(IInvestor investor)
        {
            _investors.Add(investor);
        }


        public void Detach(IInvestor investor)
        {
            _investors.Remove(investor);
        }


        public void Notify()
        {
            foreach (IInvestor investor in _investors)
            {
                investor.Update(this);
            }


            Console.WriteLine("");
        }


        // Gets or sets the price
    }


    /// <summary>
    /// The 'ConcreteSubject' class
    /// </summary>
    internal class IBM : Stock
    {
        // Constructor

        public IBM(string symbol, double price)
            : base(symbol, price)
        {
        }
    }


    /// <summary>
    /// The 'Observer' interface
    /// </summary>
    internal interface IInvestor
    {
        void Update(Stock stock);
    }


    /// <summary>
    /// The 'ConcreteObserver' class
    /// </summary>
    internal class Investor : IInvestor
    {
        private readonly string _name;


        // Constructor

        public Investor(string name)
        {
            _name = name;
        }


        // Gets or sets the stock

        public Stock Stock { get; set; }

        #region IInvestor Members

        public void Update(Stock stock)
        {
            Console.WriteLine("Notified {0} of {1}'s " +
                              "change to {2:C}", _name, stock.Symbol, stock.Price);
        }

        #endregion
    }
}