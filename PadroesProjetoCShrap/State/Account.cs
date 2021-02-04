// State pattern -- Real World example

using System;

namespace State.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// State Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Open a new account

            var account = new Account("Jim Johnson");


            // Apply financial transactions

            account.Deposit(500.0);

            account.Deposit(300.0);

            account.Deposit(550.0);

            account.PayInterest();

            account.Withdraw(2000.00);

            account.Withdraw(1100.00);


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'State' abstract class
    /// </summary>
    internal abstract class State
    {
        protected Account account;

        protected double balance;


        protected double interest;

        protected double lowerLimit;

        protected double upperLimit;


        // Properties

        public Account Account
        {
            get { return account; }

            set { account = value; }
        }


        public double Balance
        {
            get { return balance; }

            set { balance = value; }
        }


        public abstract void Deposit(double amount);

        public abstract void Withdraw(double amount);

        public abstract void PayInterest();
    }


    /// <summary>
    /// A 'ConcreteState' class
    /// <remarks>
    /// Red indicates that account is overdrawn
    /// </remarks>
    /// </summary>
    internal class RedState : State
    {
        private double _serviceFee;


        // Constructor

        public RedState(State state)
        {
            balance = state.Balance;

            account = state.Account;

            Initialize();
        }


        private void Initialize()
        {
            // Should come from a datasource

            interest = 0.0;

            lowerLimit = -100.0;

            upperLimit = 0.0;

            _serviceFee = 15.00;
        }


        public override void Deposit(double amount)
        {
            balance += amount;

            StateChangeCheck();
        }


        public override void Withdraw(double amount)
        {
            amount = amount - _serviceFee;

            Console.WriteLine("No funds available for withdrawal!");
        }


        public override void PayInterest()
        {
            // No interest is paid
        }


        private void StateChangeCheck()
        {
            if (balance > upperLimit)
            {
                account.State = new SilverState(this);
            }
        }
    }


    /// <summary>
    /// A 'ConcreteState' class
    /// <remarks>
    /// Silver indicates a non-interest bearing state
    /// </remarks>
    /// </summary>
    internal class SilverState : State
    {
        // Overloaded constructors


        public SilverState(State state) :
            this(state.Balance, state.Account)
        {
        }


        public SilverState(double balance, Account account)
        {
            this.balance = balance;

            this.account = account;

            Initialize();
        }


        private void Initialize()
        {
            // Should come from a datasource

            interest = 0.0;

            lowerLimit = 0.0;

            upperLimit = 1000.0;
        }


        public override void Deposit(double amount)
        {
            balance += amount;

            StateChangeCheck();
        }


        public override void Withdraw(double amount)
        {
            balance -= amount;

            StateChangeCheck();
        }


        public override void PayInterest()
        {
            balance += interest*balance;

            StateChangeCheck();
        }


        private void StateChangeCheck()
        {
            if (balance < lowerLimit)
            {
                account.State = new RedState(this);
            }

            else if (balance > upperLimit)
            {
                account.State = new GoldState(this);
            }
        }
    }


    /// <summary>
    /// A 'ConcreteState' class
    /// <remarks>
    /// Gold indicates an interest bearing state
    /// </remarks>
    /// </summary>
    internal class GoldState : State
    {
        // Overloaded constructors

        public GoldState(State state)
            : this(state.Balance, state.Account)
        {
        }


        public GoldState(double balance, Account account)
        {
            this.balance = balance;

            this.account = account;

            Initialize();
        }


        private void Initialize()
        {
            // Should come from a database

            interest = 0.05;

            lowerLimit = 1000.0;

            upperLimit = 10000000.0;
        }


        public override void Deposit(double amount)
        {
            balance += amount;

            StateChangeCheck();
        }


        public override void Withdraw(double amount)
        {
            balance -= amount;

            StateChangeCheck();
        }


        public override void PayInterest()
        {
            balance += interest*balance;

            StateChangeCheck();
        }


        private void StateChangeCheck()
        {
            if (balance < 0.0)
            {
                account.State = new RedState(this);
            }

            else if (balance < lowerLimit)
            {
                account.State = new SilverState(this);
            }
        }
    }


    /// <summary>
    /// The 'Context' class
    /// </summary>
    internal class Account
    {
        private string _owner;
        private State _state;


        // Constructor

        public Account(string owner)
        {
            // New accounts are 'Silver' by default

            _owner = owner;

            _state = new SilverState(0.0, this);
        }


        // Properties

        public double Balance
        {
            get { return _state.Balance; }
        }


        public State State
        {
            get { return _state; }

            set { _state = value; }
        }


        public void Deposit(double amount)
        {
            _state.Deposit(amount);

            Console.WriteLine("Deposited {0:C} --- ", amount);

            Console.WriteLine(" Balance = {0:C}", Balance);

            Console.WriteLine(" Status = {0}",
                              State.GetType().Name);

            Console.WriteLine("");
        }


        public void Withdraw(double amount)
        {
            _state.Withdraw(amount);

            Console.WriteLine("Withdrew {0:C} --- ", amount);

            Console.WriteLine(" Balance = {0:C}", Balance);

            Console.WriteLine(" Status = {0}\n",
                              State.GetType().Name);
        }


        public void PayInterest()
        {
            _state.PayInterest();

            Console.WriteLine("Interest Paid --- ");

            Console.WriteLine(" Balance = {0:C}", Balance);

            Console.WriteLine(" Status = {0}\n",
                              State.GetType().Name);
        }
    }

}