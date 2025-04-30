using System.Text;
using System.Text.Json;
using checkpoint5_validator.config;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace checkpoint_5;

public class Validator
{
        public void Validate()
    {
        using var connection = RabbitMQConfig.GetConnection();
        using var channel = connection.CreateModel();

        string exchangeName = "topic_exchange";
        string queueName = "validation_queue";
        
        channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Topic);
        
        channel.QueueDeclare(
            queue: queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );
        
        channel.QueueBind(queue: queueName, exchange: exchangeName, routingKey: "frutas.epoca");
        channel.QueueBind(queue: queueName, exchange: exchangeName, routingKey: "usuario.dados");

        // Consumidor configurado
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var routingKey = ea.RoutingKey;

            Console.WriteLine($"[Validation] Mensagem recebida: {message}");
            
            bool isValid = false;
            if (routingKey == "frutas.epoca")
            {
                isValid = ValidateFruit(message);
            }
            else if (routingKey == "usuario.dados")
            {
                isValid = ValidateUser(message);
            }
            
            if (isValid)
            {
                string destinationRoutingKey = routingKey == "frutas.epoca" ? "receiver1.queue" : "receiver2.queue";

                channel.BasicPublish(
                    exchange: exchangeName,
                    routingKey: destinationRoutingKey,
                    basicProperties: null,
                    body: body
                );

                Console.WriteLine($"[Validation] Mensagem válida e enviada para {destinationRoutingKey}.");
            }
            else
            {
                Console.WriteLine($"[Validation] Mensagem inválida descartada: {message}");
            }
        };

        channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

        Console.WriteLine("[Validation] Aguardando mensagens...");
        Console.ReadLine();
    }
        
    private bool ValidateFruit(string message)
    {
        try
        {
            var fruta = JsonSerializer.Deserialize<Fruit>(message);
            if (string.IsNullOrEmpty(fruta.Nome) || string.IsNullOrEmpty(fruta.Descricao))
            {
                Console.WriteLine("[Validation] Mensagem de frutas inválida: Campos obrigatórios ausentes.");
                return false;
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Validation] Erro ao validar mensagem de frutas: {ex.Message}");
            return false;
        }
    }
    
    private bool ValidateUser(string message)
    {
        try
        {
            var usuario = JsonSerializer.Deserialize<User>(message);
            if (string.IsNullOrEmpty(usuario.NomeCompleto) || string.IsNullOrEmpty(usuario.CPF))
            {
                Console.WriteLine("[Validation] Mensagem de usuário inválida: Campos obrigatórios ausentes.");
                return false;
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Validation] Erro ao validar mensagem de usuário: {ex.Message}");
            return false;
        }
    }
}

public class Fruit
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public DateTime DataHora { get; set; }
}

public class User
{
    public string NomeCompleto { get; set; }
    public string Endereco { get; set; }
    public string RG { get; set; }
    public string CPF { get; set; }
    public DateTime DataRegistro { get; set; }
}