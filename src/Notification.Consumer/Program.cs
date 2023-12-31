﻿using System.Text;
using Infrastructure.Notification;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory
{
    HostName = RabbitMqOptions.HostName,
    Port = RabbitMqOptions.Port
};

var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
channel.QueueDeclare(RabbitMqOptions.QueueName, false, false, false, null);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (sender, args) =>
{
    var body = args.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"Received message: {message}");
};

channel.BasicConsume(RabbitMqOptions.QueueName, true, consumer);

Console.WriteLine("Listening for notifications...");

Console.ReadLine();