// Iterator pattern -- Real World example

using System;
using System.Collections;

namespace Iterator.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// Iterator Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Build a collection

            var collection = new Collection();

            collection[0] = new Item("Item 0");

            collection[1] = new Item("Item 1");

            collection[2] = new Item("Item 2");

            collection[3] = new Item("Item 3");

            collection[4] = new Item("Item 4");

            collection[5] = new Item("Item 5");

            collection[6] = new Item("Item 6");

            collection[7] = new Item("Item 7");

            collection[8] = new Item("Item 8");


            // Create iterator

            var iterator = collection.CreateIterator();


            // Skip every other item

            iterator.Step = 2;


            Console.WriteLine("Iterating over collection:");


            for (Item item = iterator.First();
                 !iterator.IsDone;
                 item = iterator.Next())
            {
                Console.WriteLine(item.Name);
            }


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// A collection item
    /// </summary>
    internal class Item
    {
        private readonly string _name;


        // Constructor

        public Item(string name)
        {
            _name = name;
        }


        // Gets name

        public string Name
        {
            get { return _name; }
        }
    }


    /// <summary>
    /// The 'Aggregate' interface
    /// </summary>
    internal interface IAbstractCollection
    {
        Iterator CreateIterator();
    }


    /// <summary>
    /// The 'ConcreteAggregate' class
    /// </summary>
    internal class Collection : IAbstractCollection
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

            set { _items.Add(value); }
        }

        #region IAbstractCollection Members

        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

        #endregion
    }


    /// <summary>
    /// The 'Iterator' interface
    /// </summary>
    internal interface IAbstractIterator
    {
        bool IsDone { get; }

        Item CurrentItem { get; }
        Item First();

        Item Next();
    }


    /// <summary>
    /// The 'ConcreteIterator' class
    /// </summary>
    internal class Iterator : IAbstractIterator
    {
        private readonly Collection _collection;

        private int _current;

        private int _step = 1;


        // Constructor

        public Iterator(Collection collection)
        {
            _collection = collection;
        }

        public int Step
        {
            get { return _step; }

            set { _step = value; }
        }


        // Gets first item

        #region IAbstractIterator Members

        public Item First()
        {
            _current = 0;

            return _collection[_current] as Item;
        }


        // Gets next item

        public Item Next()
        {
            _current += _step;

            if (!IsDone)

                return _collection[_current] as Item;

            else

                return null;
        }


        // Gets or sets stepsize


        // Gets current iterator item

        public Item CurrentItem
        {
            get { return _collection[_current] as Item; }
        }


        // Gets whether iteration is complete

        public bool IsDone
        {
            get { return _current >= _collection.Count; }
        }

        #endregion
    }
}