// Factory Method pattern -- Structural example

using System;

namespace Factory.Structural
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Factory Method Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // An array of creators

            var creators = new Creator[2];


            creators[0] = new ConcreteCreatorA();

            creators[1] = new ConcreteCreatorB();


            // Iterate over creators and create products

            foreach (Creator creator in creators)
            {
                Product product = creator.FactoryMethod();

                Console.WriteLine("Created {0}",
                                  product.GetType().Name);
            }


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Product' abstract class
    /// </summary>
    internal abstract class Product
    {
    }


    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    internal class ConcreteProductA : Product
    {
    }


    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    internal class ConcreteProductB : Product
    {
    }


    /// <summary>
    /// The 'Creator' abstract class
    /// </summary>
    internal abstract class Creator
    {
        public abstract Product FactoryMethod();
    }


    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    internal class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }


    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    internal class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }
}