// Prototype pattern -- Structural example

using System;

namespace Prototype.Structural
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Prototype Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Create two instances and clone each


            var p1 = new ConcretePrototype1("I");

            var c1 = (ConcretePrototype1) p1.Clone();

            Console.WriteLine("Cloned: {0}", c1.Id);


            var p2 = new ConcretePrototype2("II");

            var c2 = (ConcretePrototype2) p2.Clone();

            Console.WriteLine("Cloned: {0}", c2.Id);


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Prototype' abstract class
    /// </summary>
    internal abstract class Prototype
    {
        private readonly string _id;


        // Constructor

        public Prototype(string id)
        {
            _id = id;
        }


        // Gets id

        public string Id
        {
            get { return _id; }
        }


        public abstract Prototype Clone();
    }


    /// <summary>
    /// A 'ConcretePrototype' class
    /// </summary>
    internal class ConcretePrototype1 : Prototype
    {
        // Constructor

        public ConcretePrototype1(string id)
            : base(id)
        {
        }


        // Returns a shallow copy

        public override Prototype Clone()
        {
            return (Prototype) MemberwiseClone();
        }
    }


    /// <summary>
    /// A 'ConcretePrototype' class
    /// </summary>
    internal class ConcretePrototype2 : Prototype
    {
        // Constructor

        public ConcretePrototype2(string id)
            : base(id)
        {
        }


        // Returns a shallow copy

        public override Prototype Clone()
        {
            return (Prototype) MemberwiseClone();
        }
    }
}