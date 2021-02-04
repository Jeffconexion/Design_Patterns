// Singleton pattern -- Real World example

using System;
using System.Collections.Generic;

namespace Singleton.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// Singleton Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            LoadBalancer b1 = LoadBalancer.GetLoadBalancer();

            LoadBalancer b2 = LoadBalancer.GetLoadBalancer();

            LoadBalancer b3 = LoadBalancer.GetLoadBalancer();

            LoadBalancer b4 = LoadBalancer.GetLoadBalancer();


            // Same instance?

            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }


            // Load balance 15 server requests

            LoadBalancer balancer = LoadBalancer.GetLoadBalancer();

            for (int i = 0; i < 15; i++)
            {
                string server = balancer.Server;

                Console.WriteLine("Dispatch Request to: " + server);
            }


            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Singleton' class
    /// </summary>
    internal class LoadBalancer
    {
        private static LoadBalancer _instance;


        // Lock synchronization object

        private static readonly object syncLock = new object();
        private readonly Random _random = new Random();
        private readonly List<string> _servers = new List<string>();


        // Constructor (protected)

        protected LoadBalancer()
        {
            // List of available servers

            _servers.Add("ServerI");

            _servers.Add("ServerII");

            _servers.Add("ServerIII");

            _servers.Add("ServerIV");

            _servers.Add("ServerV");

            _servers.Add("ServerVI");
        }


        // Simple, but effective random load balancer

        public string Server
        {
            get
            {
                int r = _random.Next(_servers.Count);

                return _servers[r];
            }
        }

        public static LoadBalancer GetLoadBalancer()
        {
            // Support multithreaded applications through

            // 'Double checked locking' pattern which (once

            // the instance exists) avoids locking each

            // time the method is invoked

            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new LoadBalancer();
                    }
                }
            }


            return _instance;
        }
    }
}