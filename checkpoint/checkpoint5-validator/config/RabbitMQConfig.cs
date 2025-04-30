using RabbitMQ.Client;

namespace checkpoint5_validator.config;

public class RabbitMQConfig
{
    public static IConnection GetConnection()
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            UserName = "user",
            Password = "password"
        };

        return factory.CreateConnection();
    }
}