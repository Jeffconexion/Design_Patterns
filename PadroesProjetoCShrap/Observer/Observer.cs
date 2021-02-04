using System;
using System.Collections.Generic;

namespace Observer.Structural
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Observer Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Configure Observer pattern

            var s = new ConcreteSubject();


            s.Attach(new ConcreteObserver(s, "X"));

            s.Attach(new ConcreteObserver(s, "Y"));

            s.Attach(new ConcreteObserver(s, "Z"));


            // Change subject and notify observers

            s.SubjectState = "ABC";

            s.Notify();


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Subject' abstract class
    /// </summary>
    internal abstract class Subject
    {
        private readonly List<Observer> _observers = new List<Observer>();


        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }


        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }


        public void Notify()
        {
            foreach (Observer o in _observers)
            {
                o.Update();
            }
        }
    }


    /// <summary>
    /// The 'ConcreteSubject' class
    /// </summary>
    internal class ConcreteSubject : Subject
    {
        // Gets or sets subject state

        public string SubjectState { get; set; }
    }


    /// <summary>
    /// The 'Observer' abstract class
    /// </summary>
    internal abstract class Observer
    {
        public abstract void Update();
    }


    /// <summary>
    /// The 'ConcreteObserver' class
    /// </summary>
    internal class ConcreteObserver : Observer
    {
        private readonly string _name;

        private string _observerState;

        private ConcreteSubject _subject;


        // Constructor

        public ConcreteObserver(
            ConcreteSubject subject, string name)
        {
            _subject = subject;

            _name = name;
        }


        // Gets or sets subject

        public ConcreteSubject Subject
        {
            get { return _subject; }

            set { _subject = value; }
        }

        public override void Update()
        {
            _observerState = _subject.SubjectState;

            Console.WriteLine("Observer {0}'s new state is {1}",
                              _name, _observerState);
        }
    }
}