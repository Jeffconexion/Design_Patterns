// Memento pattern -- Structural example

using System;

namespace Memento.Structural
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Memento Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            var o = new Originator();

            o.State = "On";


            // Store internal state

            var c = new Caretaker();

            c.Memento = o.CreateMemento();


            // Continue changing originator

            o.State = "Off";


            // Restore saved state

            o.SetMemento(c.Memento);


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Originator' class
    /// </summary>
    internal class Originator
    {
        private string _state;


        // Property

        public string State
        {
            get { return _state; }

            set
            {
                _state = value;

                Console.WriteLine("State = " + _state);
            }
        }


        // Creates memento

        public Memento CreateMemento()
        {
            return (new Memento(_state));
        }


        // Restores original state

        public void SetMemento(Memento memento)
        {
            Console.WriteLine("Restoring state...");

            State = memento.State;
        }
    }


    /// <summary>
    /// The 'Memento' class
    /// </summary>
    internal class Memento
    {
        private readonly string _state;


        // Constructor

        public Memento(string state)
        {
            _state = state;
        }


        // Gets or sets state

        public string State
        {
            get { return _state; }
        }
    }


    /// <summary>
    /// The 'Caretaker' class
    /// </summary>
    internal class Caretaker
    {
        // Gets or sets memento

        public Memento Memento { set; get; }
    }
}