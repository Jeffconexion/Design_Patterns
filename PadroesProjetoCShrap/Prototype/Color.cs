// Prototype pattern -- Real World example

using System;
using System.Collections.Generic;

namespace Prototype.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// Prototype Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            var colormanager = new ColorManager();


            // Initialize with standard colors

            colormanager["red"] = new Color(255, 0, 0);

            colormanager["green"] = new Color(0, 255, 0);

            colormanager["blue"] = new Color(0, 0, 255);


            // User adds personalized colors

            colormanager["angry"] = new Color(255, 54, 0);

            colormanager["peace"] = new Color(128, 211, 128);

            colormanager["flame"] = new Color(211, 34, 20);

            colormanager["orange"] = new Color(100, 33, 47); 


            // User clones selected colors

            var color1 = (Color) colormanager["red"].Clone() ;

            var color2 = colormanager["peace"].Clone() as Color;

            var color3 = colormanager["flame"].Clone() as Color;

            var color4 = colormanager["orange"].Clone() as Color;


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Prototype' abstract class
    /// </summary>
    internal abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }


    /// <summary>
    /// The 'ConcretePrototype' class
    /// </summary>
    internal class Color : ColorPrototype
    {
        private readonly int _blue;
        private readonly int _green;
        private readonly int _red;


        // Constructor

        public Color(int red, int green, int blue)
        {
            _red = red;

            _green = green;

            _blue = blue;
        }


        // Create a shallow copy

        public override ColorPrototype Clone()
        {
            Console.WriteLine(
                "Cloning color RGB: {0,3},{1,3},{2,3}",
                _red, _green, _blue);


            return MemberwiseClone() as ColorPrototype;
        }
    }


    /// <summary>
    /// Prototype manager
    /// </summary>
    internal class ColorManager
    {
        private readonly Dictionary<string, ColorPrototype> _colors =
            new Dictionary<string, ColorPrototype>();


        // Indexer

        public ColorPrototype this[string key]
        {
            get { return _colors[key]; }

            set { _colors.Add(key, value); }
        }
    }
}