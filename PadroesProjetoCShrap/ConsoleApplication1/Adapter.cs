// Adapter pattern -- Structural example

using System;

namespace Adapter.Structural
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

            Alvo alvo = new Adapter();

            alvo.Request();


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Alvo' class
    /// </summary>
    internal class Alvo
    {
        public virtual void Request()
        {
            Console.WriteLine("Called Alvo Request()");
        }
    }


    /// <summary>
    /// The 'Adapter' class
    /// </summary>
    internal class Adapter : Alvo
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