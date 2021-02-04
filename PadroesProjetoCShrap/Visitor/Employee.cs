// Visitor pattern -- Real World example

using System;
using System.Collections.Generic;

namespace Visitor.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// Visitor Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Setup employee collection

            var e = new Employees();

            e.Attach(new Clerk());

            e.Attach(new Director());

            e.Attach(new President());


            // Employees are 'visited'

            e.Accept(new IncomeVisitor());

            e.Accept(new VacationVisitor());

            e.Accept(new FaltasVisitor());


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Visitor' interface
    /// </summary>
    internal interface IVisitor
    {
        void Visit(Element element);
    }


    /// <summary>
    /// A 'ConcreteVisitor' class
    /// </summary>
    internal class IncomeVisitor : IVisitor
    {
        #region IVisitor Members

        public void Visit(Element element)
        {
            var employee = element as Employee;


            // Provide 10% pay raise

            employee.Income *= 1.10;

            Console.WriteLine("{0} {1}'s new income: {2:C}",
                              employee.GetType().Name, employee.Name,
                              employee.Income);
        }

        #endregion
    }

    /// <summary>
    /// A 'ConcreteVisitor' class
    /// </summary>
    internal class FaltasVisitor : IVisitor
    {
        #region IVisitor Members

        public void Visit(Element element)
        {
            var employee = element as Employee;

            employee.Income = employee.Income - (employee.Income / 30 * employee.Faltas);

            Console.WriteLine("{0} {1}'s new income: {2:C}",
                              employee.GetType().Name, employee.Name,
                              employee.Income);
        }

        #endregion
    }


    /// <summary>
    /// A 'ConcreteVisitor' class
    /// </summary>
    internal class VacationVisitor : IVisitor
    {
        #region IVisitor Members

        public void Visit(Element element)
        {
            var employee = element as Employee;


            // Provide 3 extra vacation days

            Console.WriteLine("{0} {1}'s new vacation days: {2}",
                              employee.GetType().Name, employee.Name,
                              employee.VacationDays);
        }

        #endregion
    }


    /// <summary>
    /// The 'Element' abstract class
    /// </summary>
    internal abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }


    /// <summary>
    /// The 'ConcreteElement' class
    /// </summary>
    internal class Employee : Element
    {
        // Constructor

        public Employee(string name, double income,
                        int vacationDays)
        {
            Name = name;

            Income = income;

            VacationDays = vacationDays;
        }


        public int Faltas { get; set; }

        // Gets or sets the name

        public string Name { get; set; }


        // Gets or sets income

        public double Income { get; set; }


        // Gets or sets number of vacation days

        public int VacationDays { get; set; }


        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }


    /// <summary>
    /// The 'ObjectStructure' class
    /// </summary>
    internal class Employees
    {
        private readonly List<Employee> _employees = new List<Employee>();


        public void Attach(Employee employee)
        {
            _employees.Add(employee);
        }


        public void Detach(Employee employee)
        {
            _employees.Remove(employee);
        }


        public void Accept(IVisitor visitor)
        {
            foreach (Employee e in _employees)
            {
                e.Accept(visitor);
            }

            Console.WriteLine();
        }
    }


    // Three employee types


    internal class Clerk : Employee
    {
        // Constructor

        public Clerk()
            : base("Hank", 25000.0, 14)
        {
        }
    }


    internal class Director : Employee
    {
        // Constructor

        public Director()
            : base("Elly", 35000.0, 16)
        {
        }
    }


    internal class President : Employee
    {
        // Constructor

        public President()
            : base("Dick", 45000.0, 21)
        {
        }
    }
}