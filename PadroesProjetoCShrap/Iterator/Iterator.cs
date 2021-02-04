// Iterator pattern -- Structural example

using System;
using System.Collections;

namespace Iterator.Structural
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Iterator Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            var a = new ConcreteAggregate();

            a[0] = "Item A";

            a[1] = "Item B";

            a[2] = "Item C";

            a[3] = "Item D";


            // Create Iterator and provide aggregate

            var i = a.CreateIterator();


            Console.WriteLine("Iterating over collection:");


            object item = i.First();

            while (item != null)
            {
                Console.WriteLine(item);

                item = i.Next();
            }


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Aggregate' abstract class
    /// </summary>
    internal abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }


    /// <summary>
    /// The 'ConcreteAggregate' class
    /// </summary>
    internal class ConcreteAggregate : Aggregate
    {
        private readonly ArrayList _items = new ArrayList();


        // Gets item count

        public int Count
        {
            get { return _items.Count; }
        }


        // Indexer

        public object this[int index]
        {
            get { return _items[index]; }

            set { _items.Insert(index, value); }
        }

        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }
    }


    /// <summary>
    /// The 'Iterator' abstract class
    /// </summary>
    internal abstract class Iterator
    {
        public abstract object First();

        public abstract object Next();

        public abstract bool IsDone();

        public abstract object CurrentItem();
    }


    /// <summary>
    /// The 'ConcreteIterator' class
    /// </summary>
    internal class ConcreteIterator : Iterator
    {
        private readonly ConcreteAggregate _aggregate;

        private int _current;


        // Constructor

        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            _aggregate = aggregate;
        }


        // Gets first iteration item

        public override object First()
        {
            return _aggregate[0];
        }


        // Gets next iteration item

        public override object Next()
        {
            object ret = null;

            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }


            return ret;
        }


        // Gets current iteration item

        public override object CurrentItem()
        {
            return _aggregate[_current];
        }


        // Gets whether iterations are complete

        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }
    }
}