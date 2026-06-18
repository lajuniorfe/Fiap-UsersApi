using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Users.AppService.events
{
    public class RabbitMqPublisher: IRabbitMqPublisher
    {
        private readonly IConnection _connection;

        public  RabbitMqPublisher()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnectionAsync().Result;
        }

        public async Task PublishAsync<T>(string queue, T message)
        {
            using var channel = await _connection.CreateChannelAsync();

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            await channel.BasicPublishAsync(
                exchange: "",
                routingKey: queue,
                body: body);
        }
    }
}
