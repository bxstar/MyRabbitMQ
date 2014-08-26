using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MyRabbitMQ.Consumer
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


            //Person newPerson;
            //using (var file = System.IO.File.OpenRead(@"D:\Person.bin"))
            //{
            //    newPerson = ProtoBuf.Serializer.Deserialize<Person>(file);
            //}
            //Console.WriteLine("id:{0},name:{1},email:{2}", newPerson.id, newPerson.name, newPerson.email);

            string queueName = "taobao_spider_samesimilar_item";

            var factory = new ConnectionFactory() { HostName = "115.182.89.51", Port = 5672, UserName = "sem", Password = "shiqi2014", VirtualHost = "sem" };

            //使用localhost在本地作为guest访问的写法
            //var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //删除队列
                    //var result = channel.QueueDelete(queueName);

                    //消费队列
                    channel.QueueDeclare(queueName, false, false, false, null);

                    var consumer = new QueueingBasicConsumer(channel);
                    string strConsumeResult = channel.BasicConsume(queueName, true, consumer);

                    Console.WriteLine("[*] Waiting for message." + "To exit press CTRL+C");

                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine("[x] Received {0}", message);
                    }
                }
            }

        }
    }
}
