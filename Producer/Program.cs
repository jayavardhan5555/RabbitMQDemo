// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using System.Text;

Console.WriteLine("Hello, World!");

var factory = new ConnectionFactory() { HostName = "localhost" };

using(var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare("BasicTest", false, false, false, null);
    string msg = "Getting started with .Net core rabbitmq 9012";

    var body = Encoding.UTF8.GetBytes(msg);

    channel.BasicPublish("", "BasicTest", null, body);
    Console.WriteLine("sent msg {0}...", msg);
}

Console.WriteLine("Enter to exit producer");
Console.ReadLine();