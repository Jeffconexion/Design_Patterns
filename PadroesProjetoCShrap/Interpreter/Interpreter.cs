// Interpreter pattern -- Structural example

using System;
using System.Collections;

namespace Interpreter.Structural
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Interpreter Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            var context = new Context();


            // Usually a tree

            var list = new ArrayList();


            // Populate 'abstract syntax tree'

            list.Add(new TerminalExpression());

            list.Add(new NonterminalExpression());

            list.Add(new TerminalExpression());

            list.Add(new TerminalExpression());


            // Interpret

            foreach (AbstractExpression exp in list)
            {
                exp.Interpret(context);
            }


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Context' class
    /// </summary>
    internal class Context
    {
    }


    /// <summary>
    /// The 'AbstractExpression' abstract class
    /// </summary>
    internal abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }


    /// <summary>
    /// The 'TerminalExpression' class
    /// </summary>
    internal class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Called Terminal.Interpret()");
        }
    }


    /// <summary>
    /// The 'NonterminalExpression' class
    /// </summary>
    internal class NonterminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Called Nonterminal.Interpret()");
        }
    }
}