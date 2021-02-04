// Strategy pattern -- Structural example

using System;

namespace Strategy.Structural
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Strategy Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            Context context;


            // Three contexts following different strategies

            context = new Context(new ConcreteStrategyA());

            context.ContextInterface();


            context = new Context(new ConcreteStrategyB());

            context.ContextInterface();


            context = new Context(new ConcreteStrategyC());

            context.ContextInterface();


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Strategy' abstract class
    /// </summary>
    internal abstract class Strategy
    {
        public abstract void AlgorithmInterface();
    }


    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    internal class ConcreteStrategyA : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
                "Called ConcreteStrategyA.AlgorithmInterface()");
        }
    }


    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    internal class ConcreteStrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
                "Called ConcreteStrategyB.AlgorithmInterface()");
        }
    }


    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    internal class ConcreteStrategyC : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
                "Called ConcreteStrategyC.AlgorithmInterface()");
        }
    }


    /// <summary>
    /// The 'Context' class
    /// </summary>
    internal class Context
    {
        private readonly Strategy _strategy;


        // Constructor

        public Context(Strategy strategy)
        {
            _strategy = strategy;
        }


        public void ContextInterface()
        {
            _strategy.AlgorithmInterface();
        }
    }
}