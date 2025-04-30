using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;
using checkpoint_5.config;

namespace checkpoint_5;

public class FruitsSender
{
    public void Send()
    {
        using var connection = RabbitMQConfig.GetConnection();
        using var channel = connection.CreateModel();

        string exchangeName = "topic_exchange";
        string queueName = "receiver1.queue";
        string routingKey = "frutas.epoca";
        
        channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Topic);
        
        channel.QueueDeclare(
            queue: queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );
        
        channel.QueueBind(
            queue: queueName,
            exchange: exchangeName,
            routingKey: routingKey
        );
        
        var message = new
        {
            Nome = "Manga",
            Descricao = "Fruta tropical, doce e suculenta.",
            DataHora = DateTime.Now
        };

        var messageBody = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
        
        channel.BasicPublish(
            exchange: exchangeName,
            routingKey: routingKey,
            basicProperties: null,
            body: messageBody
        );

        Console.WriteLine($"[Sender1] Mensagem enviada: {JsonSerializer.Serialize(message)}");
    }
}