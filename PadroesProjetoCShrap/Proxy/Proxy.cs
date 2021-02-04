using System;

namespace Proxy.Structural
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Proxy Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Create proxy and request a service

            var proxy = new Proxy();

            proxy.Request();


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Subject' abstract class
    /// </summary>
    internal abstract class Subject
    {
        public abstract void Request();
    }


    /// <summary>
    /// The 'RealSubject' class
    /// </summary>
    internal class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("Called RealSubject.Request()");
        }
    }


    /// <summary>
    /// The 'Proxy' class
    /// </summary>
    internal class Proxy : Subject
    {
        private RealSubject _realSubject;


        public override void Request()
        {
            // Use 'lazy initialization'

            if (_realSubject == null)
            {
                _realSubject = new RealSubject();
            }


            _realSubject.Request();
        }
    }
}