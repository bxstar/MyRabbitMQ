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

            //使用exchange的配置模式，和使用队列名的简单路由模式
            string exchangeName = "ex_taobao_spider_samesimilar_item";
            //string queueName = "360";


            var factory = new ConnectionFactory() { HostName = "115.182.89.51", Port = 5672, UserName = "sem", Password = "shiqi2014", VirtualHost = "sem" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchangeName, "fanout", true);
                    //channel.QueueDeclare(queueName, false, false, false, null);

                    //string message = string.Format("Hello World {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    string message = string.Format("{0},{1}", "1盒包邮亨氏黑米红枣婴儿营养米粉6个月宝宝辅食米糊2段3段400g", "tb7181392");

                    var body = Encoding.UTF8.GetBytes(message);

                    //channel.BasicPublish("", queueName, null, body);
                    channel.BasicPublish(exchangeName, "", null, body);
                    Console.WriteLine("[x] sent {0}", message);
                    Console.Read();
                };
            };

        }
    }
}
