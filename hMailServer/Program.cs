﻿using System;
using hMailServer.Core;
using hMailServer.Core.Protocols.SMTP;

namespace hMailServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<ISession> connectionFactory = () => 
                new SmtpServerSession(new NullCommandHandler(), new SmtpServerSessionConfiguration());

            var serverConfiguration = new ServerConfiguration()
                {
                    Port = 25
                };

            var smtpServer = new Server(connectionFactory, serverConfiguration);
            
            var runTask = smtpServer.RunAsync();

            Console.WriteLine("Server running Press Enter to exit...");
            Console.ReadLine();

            var stopTask = smtpServer.StopAsync();

            Console.WriteLine("Shutting down");
            
            Console.WriteLine("Server ");
        }

    }
}
