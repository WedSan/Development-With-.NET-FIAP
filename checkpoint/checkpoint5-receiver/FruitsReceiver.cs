using System.Text;
using checkpoint_5.config;
using RabbitMQ.Client.Events;

namespace checkpoint_5;

public class FruitsReceiver
{
    public void Receive()
    {
        using var connection = RabbitMQConfig.GetConnection();
        using var channel = connection.CreateModel();

        string queueName = "receiver1.queue";

        channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            Console.WriteLine($"[Receiver1] Mensagem recebida: {message}");
        };

        channel.BasicConsume(
            queue: queueName,
            autoAck: true, 
            consumerTag: "", 
            noLocal: false, 
            exclusive: false, 
            arguments: null, 
            consumer: consumer 
        );

        Console.WriteLine("[Receiver1] Aguardando mensagens...");
        Console.ReadLine();
    }
}
