// State pattern -- Structural example

using System;

namespace State.Structural
{
    /// <summary>
    /// MainApp startup class for Structural
    /// State Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Setup context in a state

            var c = new Context(new ConcreteStateA());


            // Issue requests, which toggles state

            c.Request();

            c.Request();

            c.Request();

            c.Request();


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'State' abstract class
    /// </summary>
    internal abstract class State
    {
        public abstract void Handle(Context context);
    }


    /// <summary>
    /// A 'ConcreteState' class
    /// </summary>
    internal class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateB();
        }
    }


    /// <summary>
    /// A 'ConcreteState' class
    /// </summary>
    internal class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateA();
        }
    }


    /// <summary>
    /// The 'Context' class
    /// </summary>
    internal class Context
    {
        private State _state;


        // Constructor

        public Context(State state)
        {
            State = state;
        }


        // Gets or sets the state

        public State State
        {
            get { return _state; }

            set
            {
                _state = value;

                Console.WriteLine("State: " +
                                  _state.GetType().Name);
            }
        }


        public void Request()
        {
            _state.Handle(this);
        }
    }
}