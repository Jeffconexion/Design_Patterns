using System;

namespace Proxy.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// Proxy Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Create math proxy

            var proxy = new MathProxy();


            // Do the math

            Console.WriteLine("4 + 2 = " + proxy.Add(4, 2));

            Console.WriteLine("4 - 2 = " + proxy.Sub(4, 2));

            Console.WriteLine("4 * 2 = " + proxy.Mul(4, 2));

            Console.WriteLine("4 / 2 = " + proxy.Div(4, 2));


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Subject interface
    /// </summary>
    public interface IMath
    {
        double Add(double x, double y);

        double Sub(double x, double y);

        double Mul(double x, double y);

        double Div(double x, double y);
    }


    /// <summary>
    /// The 'RealSubject' class
    /// </summary>
    internal class Math : IMath
    {
        #region IMath Members

        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }

        public double Mul(double x, double y)
        {
            return x*y;
        }

        public double Div(double x, double y)
        {
            return x/y;
        }

        #endregion
    }


    /// <summary>
    /// The 'Proxy Object' class
    /// </summary>
    internal class MathProxy : IMath
    {
        private readonly Math _math = new Math();

        #region IMath Members

        public double Add(double x, double y)
        {
            return _math.Add(x, y);
        }

        public double Sub(double x, double y)
        {
            return _math.Sub(x, y);
        }

        public double Mul(double x, double y)
        {
            return _math.Mul(x, y);
        }

        public double Div(double x, double y)
        {
            return _math.Div(x, y);
        }

        #endregion
    }
}