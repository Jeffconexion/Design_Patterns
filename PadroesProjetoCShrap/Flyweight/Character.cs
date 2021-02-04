using System;
using System.Collections.Generic;

namespace Flyweight.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// Flyweight Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Build a document with text

            string document = "AAZFFZBBZFB";

            char[] chars = document.ToCharArray();


            var factory = new CharacterFactory();


            // extrinsic state

            int pointSize = 10;


            // For each character use a flyweight object

            foreach (char c in chars)
            {
                pointSize++;

                Character character = factory.GetCharacter(c);

                character.Display(pointSize);
            }


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'FlyweightFactory' class
    /// </summary>
    internal class CharacterFactory
    {
        private readonly Dictionary<char, Character> _characters =
            new Dictionary<char, Character>();


        public Character GetCharacter(char key)
        {
            // Uses "lazy initialization"

            Character character = null;

            if (_characters.ContainsKey(key))
            {
                character = _characters[key];
            }

            else
            {
                switch (key)
                {
                    case 'A':
                        character = new CharacterA();
                        break;

                    case 'B':
                        character = new CharacterB();
                        break;

                    case 'F':
                        character = new CharacterF();
                        break;
                    //...

                    case 'Z':
                        character = new CharacterZ();
                        break;
                }

                _characters.Add(key, character);
            }

            return character;
        }
    }


    /// <summary>
    /// The 'Flyweight' abstract class
    /// </summary>
    internal abstract class Character
    {
        protected int ascent;

        protected int descent;
        protected int height;

        protected int pointSize;
        protected char symbol;

        protected int width;


        public abstract void Display(int pointSize);
    }


    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    internal class CharacterA : Character
    {
        // Constructor

        public CharacterA()
        {
            symbol = 'A';

            height = 100;

            width = 120;

            ascent = 70;

            descent = 0;
        }


        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;

            Console.WriteLine(symbol +
                              " (pointsize " + this.pointSize + ")");
        }
    }


    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    internal class CharacterB : Character
    {
        // Constructor

        public CharacterB()
        {
            symbol = 'B';

            height = 100;

            width = 140;

            ascent = 72;

            descent = 0;
        }


        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;

            Console.WriteLine(symbol +
                              " (pointsize " + this.pointSize + ")");
        }
    }


    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    internal class CharacterF : Character
    {
        // Constructor
        
        public CharacterF()
        {
            symbol = 'F';

            height = 90;

            width = 140;

            ascent = 72;

            descent = 0;
        }


        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;

            Console.WriteLine(symbol +
                              " (pointsize " + this.pointSize + ")");
        }
    }
    // ... C, D, E, etc.


    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    internal class CharacterZ : Character
    {
        // Constructor

        public CharacterZ()
        {
            symbol = 'Z';

            height = 100;

            width = 100;

            ascent = 68;

            descent = 0;
        }


        public override void Display(int pointSize)
        {
            this.pointSize = pointSize;

            Console.WriteLine(symbol +
                              " (pointsize " + this.pointSize + ")");
        }
    }
}