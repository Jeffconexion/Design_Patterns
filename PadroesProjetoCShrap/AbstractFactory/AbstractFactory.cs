using System;

namespace Abstract.Structural
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Abstract Factory Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main()
        {
            // Abstract factory #1

            AbstractFactory factory1 = new ConcreteFactory1();

            var client1 = new Client(factory1);

            client1.Run();


            // Abstract factory #2

            AbstractFactory factory2 = new ConcreteFactory2();

            var client2 = new Client(factory2);

            client2.Run();


            // Wait for user input

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'AbstractFactory' abstract class
    /// </summary>
    internal abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();

        public abstract AbstractProductB CreateProductB();
    }


    /// <summary>
    /// The 'ConcreteFactory1' class
    /// </summary>
    internal class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }


    /// <summary>
    /// The 'ConcreteFactory2' class
    /// </summary>
    internal class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }


    /// <summary>
    /// The 'AbstractProductA' abstract class
    /// </summary>
    internal abstract class AbstractProductA
    {
    }


    /// <summary>
    /// The 'AbstractProductB' abstract class
    /// </summary>
    internal abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA a);
    }


    /// <summary>
    /// The 'ProductA1' class
    /// </summary>
    internal class ProductA1 : AbstractProductA
    {
    }


    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    internal class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(GetType().Name +
                              " interacts with " + a.GetType().Name);
        }
    }


    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    internal class ProductA2 : AbstractProductA
    {
    }


    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    internal class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(GetType().Name +
                              " interacts with " + a.GetType().Name);
        }
    }


    /// <summary>
    /// The 'Client' class. Interaction environment for the products.
    /// </summary>
    internal class Client
    {
        private readonly AbstractProductA _abstractProductA;

        private readonly AbstractProductB _abstractProductB;


        // Constructor

        public Client(AbstractFactory factory)
        {
            _abstractProductB = factory.CreateProductB();

            _abstractProductA = factory.CreateProductA();
        }


        public void Run()
        {
            _abstractProductB.Interact(_abstractProductA);
        }
    }
}