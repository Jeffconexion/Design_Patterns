using System;
using System.Collections.Generic;

namespace Factory.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// Factory Method Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Note: constructors call Factory Method

            var documents = new Document[3];


            documents[0] = new Resume();

            documents[1] = new Report();

            documents[2] = new TCC();

            // Display document pages

            foreach (Document document in documents)
            {
                Console.WriteLine("\n" + document.GetType().Name + "--");

                foreach (Page page in document.Pages)
                {
                    Console.WriteLine(" " + page.GetType().Name);
                }
            }


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Product' abstract class
    /// </summary>
    internal abstract class Page
    {
    }


    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    internal class SkillsPage : Page
    {
    }


    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    internal class EducationPage : Page
    {
    }


    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    internal class ExperiencePage : Page
    {
    }


    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    internal class IntroductionPage : Page
    {
    }


    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    internal class ResultsPage : Page
    {
    }


    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    internal class ConclusionPage : Page
    {
    }


    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    internal class SummaryPage : Page
    {
    }


    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    internal class BibliographyPage : Page
    {
    }


    /// <summary>
    /// The 'Creator' abstract class
    /// </summary>
    internal abstract class Document
    {
        private readonly List<Page> _pages = new List<Page>();


        // Constructor calls abstract Factory method

        public Document()
        {
            CreatePages();
        }


        public List<Page> Pages
        {
            get { return _pages; }
        }


        // Factory Method

        public abstract void CreatePages();
    }


    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    internal class Resume : Document
    {
        // Factory Method implementation

        public override void CreatePages()
        {
            Pages.Add(new SkillsPage());

            Pages.Add(new EducationPage());

            Pages.Add(new ExperiencePage());
        }
    }


    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    internal class Report : Document
    {
        // Factory Method implementation

        public override void CreatePages()
        {
            Pages.Add(new IntroductionPage());

            Pages.Add(new ResultsPage());

            Pages.Add(new ConclusionPage());

            Pages.Add(new SummaryPage());

            Pages.Add(new BibliographyPage());
        }
    }

    internal class TCC : Document
    {
        public override void CreatePages()
        {
            Pages.Add( new SummaryPage() );
            Pages.Add( new IntroductionPage() );
            Pages.Add( new ResultsPage()); 
            Pages.Add( new ConclusionPage()); 
        }
    }
}