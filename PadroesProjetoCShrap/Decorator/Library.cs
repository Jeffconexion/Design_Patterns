// Decorator pattern -- Real World example

using System;
using System.Collections.Generic;

namespace Decorator.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// Decorator Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Create book

            var book = new Book("Worley", "Inside ASP.NET", 10);

            book.Display();


            // Create video

            var video = new Video("Spielberg", "Jaws", 23, 92);

            video.Display();


            // Make video borrowable, then borrow and display

            Console.WriteLine("\nMaking video borrowable:");


            var borrowvideo = new Borrowable(video);

            borrowvideo.BorrowItem("Customer #1");

            borrowvideo.BorrowItem("Customer #2");


            borrowvideo.Display();


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Component' abstract class
    /// </summary>
    internal abstract class LibraryItem
    {
        // Property

        public int NumCopies { get; set; }


        public abstract void Display();
    }


    /// <summary>
    /// The 'ConcreteComponent' class
    /// </summary>
    internal class Book : LibraryItem
    {
        private readonly string _author;

        private readonly string _title;


        // Constructor

        public Book(string author, string title, int numCopies)
        {
            _author = author;

            _title = title;

            NumCopies = numCopies;
        }


        public override void Display()
        {
            Console.WriteLine("\nBook ------ ");

            Console.WriteLine(" Author: {0}", _author);

            Console.WriteLine(" Title: {0}", _title);

            Console.WriteLine(" # Copies: {0}", NumCopies);
        }
    }


    /// <summary>
    /// The 'ConcreteComponent' class
    /// </summary>
    internal class Video : LibraryItem
    {
        private readonly string _director;

        private readonly int _playTime;
        private readonly string _title;


        // Constructor

        public Video(string director, string title,
                     int numCopies, int playTime)
        {
            _director = director;

            _title = title;

            NumCopies = numCopies;

            _playTime = playTime;
        }


        public override void Display()
        {
            Console.WriteLine("\nVideo ----- ");

            Console.WriteLine(" Director: {0}", _director);

            Console.WriteLine(" Title: {0}", _title);

            Console.WriteLine(" # Copies: {0}", NumCopies);

            Console.WriteLine(" Playtime: {0}\n", _playTime);
        }
    }


    /// <summary>
    /// The 'Decorator' abstract class
    /// </summary>
    internal abstract class Decorator : LibraryItem
    {
        protected LibraryItem libraryItem;


        // Constructor

        public Decorator(LibraryItem libraryItem)
        {
            this.libraryItem = libraryItem;
        }


        public override void Display()
        {
            libraryItem.Display();
        }
    }


    /// <summary>
    /// The 'ConcreteDecorator' class
    /// </summary>
    internal class Borrowable : Decorator
    {
        protected List<string> borrowers = new List<string>();


        // Constructor

        public Borrowable(LibraryItem libraryItem)
            : base(libraryItem)
        {
        }


        public void BorrowItem(string name)
        {
            borrowers.Add(name);

            libraryItem.NumCopies--;
        }


        public void ReturnItem(string name)
        {
            borrowers.Remove(name);

            libraryItem.NumCopies++;
        }


        public override void Display()
        {
            base.Display();


            foreach (string borrower in borrowers)
            {
                Console.WriteLine(" borrower: " + borrower);
            }
        }
    }
}