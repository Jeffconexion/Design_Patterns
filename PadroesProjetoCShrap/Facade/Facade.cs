// Facade pattern -- Structural example

using System;

namespace Facade.Structural
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Facade Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main()
        {
            var facade = new Facade();


            facade.MethodA();

            facade.MethodB();


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Subsystem ClassA' class
    /// </summary>
    internal class SubSystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine(" SubSystemOne Method");
        }
    }


    /// <summary>
    /// The 'Subsystem ClassB' class
    /// </summary>
    internal class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine(" SubSystemTwo Method");
        }
    }


    /// <summary>
    /// The 'Subsystem ClassC' class
    /// </summary>
    internal class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine(" SubSystemThree Method");
        }
    }


    /// <summary>
    /// The 'Subsystem ClassD' class
    /// </summary>
    internal class SubSystemFour
    {
        public void MethodFour()
        {
            Console.WriteLine(" SubSystemFour Method");
        }
    }


    /// <summary>
    /// The 'Facade' class
    /// </summary>
    internal class Facade
    {
        private readonly SubSystemFour _four;
        private readonly SubSystemOne _one;

        private readonly SubSystemThree _three;
        private readonly SubSystemTwo _two;


        public Facade()
        {
            _one = new SubSystemOne();

            _two = new SubSystemTwo();

            _three = new SubSystemThree();

            _four = new SubSystemFour();
        }


        public void MethodA()
        {
            Console.WriteLine("\nMethodA() ---- ");

            _one.MethodOne();

            _two.MethodTwo();

            _four.MethodFour();
        }


        public void MethodB()
        {
            Console.WriteLine("\nMethodB() ---- ");

            _two.MethodTwo();

            _three.MethodThree();
        }
    }
}