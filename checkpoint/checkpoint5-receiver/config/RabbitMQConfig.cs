using RabbitMQ.Client;

namespace checkpoint_5.config;

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