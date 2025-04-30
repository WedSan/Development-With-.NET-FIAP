using System.Text;
using System.Text.Json;
using checkpoint_5.config;
using RabbitMQ.Client;

namespace checkpoint_5;

public class UserSender
{
    public void Send()
    {
        using var connection = RabbitMQConfig.GetConnection();
        using var channel = connection.CreateModel();

        string exchangeName = "topic_exchange";
        string routingKey = "usuario.dados";

        channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Topic);

        var message = new
        {
            NomeCompleto = "João da Silva",
            Endereco = "Rua das Flores, 123",
            RG = "12.345.678-9",
            CPF = "123.456.789-00",
            DataRegistro = DateTime.Now
        };

        var messageBody = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

        channel.BasicPublish(
            exchange: exchangeName,
            routingKey: routingKey,
            basicProperties: null,
            body: messageBody
        );

        Console.WriteLine($"[Sender2] Mensagem enviada: {JsonSerializer.Serialize(message)}");
    }
}