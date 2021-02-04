// Template Method pattern -- Real World example

using System;
using System.Data;
using System.Data.OleDb;

namespace TemplateMethod.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// Template Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            DataAccessObject daoCategories = new Categories();

            daoCategories.Run();


            DataAccessObject daoProducts = new Products();

            daoProducts.Run();


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'AbstractClass' abstract class
    /// </summary>
    internal abstract class DataAccessObject
    {
        protected string connectionString;

        protected DataSet dataSet;


        public virtual void Connect()
        {
            // Make sure mdb is available to app

            connectionString =
                "provider=Microsoft.JET.OLEDB.4.0; " +
                "data source=..\\..\\..\\db1.mdb";
        }


        public abstract void Select();

        public abstract void Process();


        public virtual void Disconnect()
        {
            connectionString = "";
        }


        // The 'Template Method'

        public void Run()
        {
            Connect();

            Select();

            Process();

            Disconnect();
        }
    }


    /// <summary>
    /// A 'ConcreteClass' class
    /// </summary>
    internal class Categories : DataAccessObject
    {
        public override void Select()
        {
            string sql = "select CategoryName from Categories";

            var dataAdapter = new OleDbDataAdapter(
                sql, connectionString);


            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "Categories");
        }


        public override void Process()
        {
            Console.WriteLine("Categories ---- ");


            DataTable dataTable = dataSet.Tables["Categories"];

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["CategoryName"]);
            }

            Console.WriteLine();
        }
    }


    /// <summary>
    /// A 'ConcreteClass' class
    /// </summary>
    internal class Products : DataAccessObject
    {
        public override void Select()
        {
            string sql = "select ProductName from Products";

            var dataAdapter = new OleDbDataAdapter(
                sql, connectionString);


            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "Products");
        }


        public override void Process()
        {
            Console.WriteLine("Products ---- ");

            DataTable dataTable = dataSet.Tables["Products"];

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["ProductName"]);
            }

            Console.WriteLine();
        }
    }
}