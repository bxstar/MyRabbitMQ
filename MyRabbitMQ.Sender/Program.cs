using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;

namespace MyRabbitMQ.Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "115.182.89.51", Port = 5672, UserName = "yrs", Password = "carlos", VirtualHost = "yrs" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);

                    string message = string.Format("Hello World {0}", DateTime.Now.ToShortTimeString());
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish("", "hello", null, body);
                    Console.WriteLine("[x] sent {0}", message);
                    Console.Read();
                };
            };

        }
    }
}
