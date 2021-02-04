// Adapter pattern -- Structural example

using System;

namespace Adapter
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Adapter Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Create adapter and place a request

            Target target = new Adapter();

            target.Request();


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Target' class
    /// </summary>
    internal class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("Called Target Request()");
        }
    }


    /// <summary>
    /// The 'Adapter' class
    /// </summary>
    internal class Adapter : Target
    {
        private readonly Adaptee _adaptee = new Adaptee();


        public override void Request()
        {
            // Possibly do some other work

            //  and then call SpecificRequest

            _adaptee.SpecificRequest();
        }
    }


    /// <summary>
    /// The 'Adaptee' class
    /// </summary>
    internal class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Called SpecificRequest()");
        }
    }
}