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
            //ProtoBuf测试代码
            //var person = new Person
            //{
            //    id = 1,
            //    name = "First",
            //    email = "yurongsheng@163.com"
            //};
            //using (var file = System.IO.File.Create(@"D:\Person.bin"))
            //{
            //    ProtoBuf.Serializer.Serialize(file, person);
            //}


            string queueName = "360";


            var factory = new ConnectionFactory() { HostName = "115.182.89.51", Port = 5672, UserName = "sem", Password = "shiqi2014", VirtualHost = "sem" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, false, null);

                    string message = string.Format("Hello World {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish("", queueName, null, body);
                    Console.WriteLine("[x] sent {0}", message);
                    Console.Read();
                };
            };

        }
    }
}
