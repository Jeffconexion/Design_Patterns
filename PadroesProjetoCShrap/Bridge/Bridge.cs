// Bridge pattern -- Structural example

using System;

namespace Bridge.Structural
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Bridge Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            Abstraction ab = new RefinedAbstraction();


            // Set implementation and call

            ab.Implementor = new ConcreteImplementorA();

            ab.Operation();


            // Change implemention and call

            ab.Implementor = new ConcreteImplementorB();

            ab.Operation();


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Abstraction' class
    /// </summary>
    internal class Abstraction
    {
        protected Implementor implementor;


        // Property

        public Implementor Implementor
        {
            set { implementor = value; }
        }


        public virtual void Operation()
        {
            implementor.Operation();
        }
    }


    /// <summary>
    /// The 'Implementor' abstract class
    /// </summary>
    internal abstract class Implementor
    {
        public abstract void Operation();
    }


    /// <summary>
    /// The 'RefinedAbstraction' class
    /// </summary>
    internal class RefinedAbstraction : Abstraction
    {
        public override void Operation()
        {
            implementor.Operation();
        }
    }


    /// <summary>
    /// The 'ConcreteImplementorA' class
    /// </summary>
    internal class ConcreteImplementorA : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorA Operation");
        }
    }


    /// <summary>
    /// The 'ConcreteImplementorB' class
    /// </summary>
    internal class ConcreteImplementorB : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorB Operation");
        }
    }
}