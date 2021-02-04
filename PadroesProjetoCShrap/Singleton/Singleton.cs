// Singleton pattern -- Structural example

using System;

namespace Singleton.Structural
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Singleton Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Constructor is protected -- cannot use new

            Singleton s1 = Singleton.Instance();

            Singleton s2 = Singleton.Instance();


            // Test for same instance

            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Singleton' class
    /// </summary>
    internal class Singleton
    {
        private static Singleton _instance;


        // Constructor is 'protected'

        protected Singleton()
        {
        }


        public static Singleton Instance()
        {
            // Uses lazy initialization.

            // Note: this is not thread safe.

            if (_instance == null)
            {
                _instance = new Singleton();
            }


            return _instance;
        }
    }
}