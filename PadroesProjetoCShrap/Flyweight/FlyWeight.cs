using System;
using System.Collections;

namespace Flyweight.Structural
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Flyweight Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Arbitrary extrinsic state

            int extrinsicstate = 22;


            var factory = new FlyweightFactory();


            // Work with different flyweight instances

            Flyweight fx = factory.GetFlyweight("X");

            fx.Operation(--extrinsicstate);


            Flyweight fy = factory.GetFlyweight("Y");

            fy.Operation(--extrinsicstate);


            Flyweight fz = factory.GetFlyweight("Z");

            fz.Operation(--extrinsicstate);


            var fu = new
                UnsharedConcreteFlyweight();


            fu.Operation(--extrinsicstate);


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'FlyweightFactory' class
    /// </summary>
    internal class FlyweightFactory
    {
        private readonly Hashtable flyweights = new Hashtable();


        // Constructor

        public FlyweightFactory()
        {
            flyweights.Add("X", new ConcreteFlyweight());

            flyweights.Add("Y", new ConcreteFlyweight());

            flyweights.Add("Z", new ConcreteFlyweight());
        }


        public Flyweight GetFlyweight(string key)
        {
            return ((Flyweight) flyweights[key]);
        }
    }


    /// <summary>
    /// The 'Flyweight' abstract class
    /// </summary>
    internal abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }


    /// <summary>
    /// The 'ConcreteFlyweight' class
    /// </summary>
    internal class ConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("ConcreteFlyweight: " + extrinsicstate);
        }
    }


    /// <summary>
    /// The 'UnsharedConcreteFlyweight' class
    /// </summary>
    internal class UnsharedConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("UnsharedConcreteFlyweight: " +
                              extrinsicstate);
        }
    }
}