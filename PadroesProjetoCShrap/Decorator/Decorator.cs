// Decorator pattern -- Structural example

using System;

namespace Decorator.Structural
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Decorator Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Create ConcreteComponent and two Decorators

            var c = new ConcreteComponent();

            var d1 = new ConcreteDecoratorA();

            var d2 = new ConcreteDecoratorB();


            // Link decorators

            d1.SetComponent(c);

            d2.SetComponent(d1);


            d2.Operation();


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Component' abstract class
    /// </summary>
    internal abstract class Component
    {
        public abstract void Operation();
    }


    /// <summary>
    /// The 'ConcreteComponent' class
    /// </summary>
    internal class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent.Operation()");
        }
    }


    /// <summary>
    /// The 'Decorator' abstract class
    /// </summary>
    internal abstract class Decorator : Component
    {
        protected Component component;


        public void SetComponent(Component component)
        {
            this.component = component;
        }


        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }


    /// <summary>
    /// The 'ConcreteDecoratorA' class
    /// </summary>
    internal class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation();

            Console.WriteLine("ConcreteDecoratorA.Operation()");
        }
    }


    /// <summary>
    /// The 'ConcreteDecoratorB' class
    /// </summary>
    internal class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();

            AddedBehavior();

            Console.WriteLine("ConcreteDecoratorB.Operation()");
        }


        private void AddedBehavior()
        {
        }
    }
}