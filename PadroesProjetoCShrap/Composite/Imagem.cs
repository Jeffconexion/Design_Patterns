// Composite pattern -- Real World example

using System;
using System.Collections.Generic;

namespace Composite.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// Composite Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Create a tree structure

            var root =
                new CompositeElement("Picture");

            root.Add(new PrimitiveElement("Red Line"));

            root.Add(new PrimitiveElement("Blue Circle"));

            root.Add(new PrimitiveElement("Green Box"));


            // Create a branch

            var comp =
                new CompositeElement("Two Circles");

            comp.Add(new PrimitiveElement("Black Circle"));

            comp.Add(new PrimitiveElement("White Circle"));

            root.Add(comp);


            // Add and remove a PrimitiveElement

            var pe =
                new PrimitiveElement("Yellow Line");

            root.Add(pe);

            root.Remove(pe);


            // Recursively display nodes

            root.Display(1);


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Component' Treenode
    /// </summary>
    internal abstract class DrawingElement
    {
        protected string _name;


        // Constructor

        public DrawingElement(string name)
        {
            _name = name;
        }


        public abstract void Add(DrawingElement d);

        public abstract void Remove(DrawingElement d);

        public abstract void Display(int indent);
    }


    /// <summary>
    /// The 'Leaf' class
    /// </summary>
    internal class PrimitiveElement : DrawingElement
    {
        // Constructor

        public PrimitiveElement(string name)
            : base(name)
        {
        }


        public override void Add(DrawingElement c)
        {
            Console.WriteLine(
                "Cannot add to a PrimitiveElement");
        }


        public override void Remove(DrawingElement c)
        {
            Console.WriteLine(
                "Cannot remove from a PrimitiveElement");
        }


        public override void Display(int indent)
        {
            Console.WriteLine(
                new String('-', indent) + " " + _name);
        }
    }


    /// <summary>
    /// The 'Composite' class
    /// </summary>
    internal class CompositeElement : DrawingElement
    {
        private readonly List<DrawingElement> elements =
            new List<DrawingElement>();


        // Constructor

        public CompositeElement(string name)
            : base(name)
        {
        }


        public override void Add(DrawingElement d)
        {
            elements.Add(d);
        }


        public override void Remove(DrawingElement d)
        {
            elements.Remove(d);
        }


        public override void Display(int indent)
        {
            Console.WriteLine(new String('-', indent) +
                              "+ " + _name);


            // Display each child element on this node

            foreach (DrawingElement d in elements)
            {
                d.Display(indent + 2);
            }
        }
    }
}