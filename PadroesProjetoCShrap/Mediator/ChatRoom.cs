using System;
using System.Collections.Generic;

namespace Mediator.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// Mediator Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Create chatroom

            var chatroom = new Chatroom();


            // Create participants and register them

            Participant George = new Beatle("George");

            Participant Paul = new Beatle("Paul");

            Participant Ringo = new Beatle("Ringo");

            Participant John = new Beatle("John");

            Participant Yoko = new NonBeatle("Yoko");


            chatroom.Register(George);

            chatroom.Register(Paul);

            chatroom.Register(Ringo);

            chatroom.Register(John);

            chatroom.Register(Yoko);


            // Chatting participants

            Yoko.Send("John", "Hi John!");

            Paul.Send("Ringo", "All you need is love");

            Ringo.Send("George", "My sweet Lord");

            Paul.Send("John", "Can't buy me love");

            John.Send("Yoko", "My sweet love");


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Mediator' abstract class
    /// </summary>
    internal abstract class AbstractChatroom
    {
        public abstract void Register(Participant participant);

        public abstract void Send(
            string from, string to, string message);
    }


    /// <summary>
    /// The 'ConcreteMediator' class
    /// </summary>
    internal class Chatroom : AbstractChatroom
    {
        private readonly Dictionary<string, Participant> _participants =
            new Dictionary<string, Participant>();


        public override void Register(Participant participant)
        {
            if (!_participants.ContainsValue(participant))
            {
                _participants[participant.Name] = participant;
            }


            participant.Chatroom = this;
        }


        public override void Send(
            string from, string to, string message)
        {
            Participant participant = _participants[to];


            if (participant != null)
            {
                participant.Receive(from, message);
            }
        }
    }


    /// <summary>
    /// The 'AbstractColleague' class
    /// </summary>
    internal class Participant
    {
        private readonly string _name;
        private Chatroom _chatroom;


        // Constructor

        public Participant(string name)
        {
            _name = name;
        }


        // Gets participant name

        public string Name
        {
            get { return _name; }
        }


        // Gets chatroom

        public Chatroom Chatroom
        {
            set { _chatroom = value; }

            get { return _chatroom; }
        }


        // Sends message to given participant

        public void Send(string to, string message)
        {
            _chatroom.Send(_name, to, message);
        }


        // Receives message from given participant

        public virtual void Receive(
            string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'",
                              from, Name, message);
        }
    }


    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>
    internal class Beatle : Participant
    {
        // Constructor

        public Beatle(string name)
            : base(name)
        {
        }


        public override void Receive(string from, string message)
        {
            Console.Write("To a Beatle: ");

            base.Receive(from, message);
        }
    }


    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>
    internal class NonBeatle : Participant
    {
        // Constructor

        public NonBeatle(string name)
            : base(name)
        {
        }


        public override void Receive(string from, string message)
        {
            Console.Write("To a non-Beatle: ");

            base.Receive(from, message);
        }
    }
}