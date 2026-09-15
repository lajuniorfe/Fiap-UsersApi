using Azure.Messaging.ServiceBus;
using System.Text;
using System.Text.Json;

namespace Users.AppService.events
{
    public class ServiceBusMessageBus: IMessageBus
    {
        private readonly ServiceBusClient _client;
        public  ServiceBusMessageBus(IConfiguration configuration)
        {
            var connectionString =
                configuration["ServiceBusConnection"]
                ?? throw new InvalidOperationException(
                    "ServiceBusConnection não configurada.");

            _client = new ServiceBusClient(connectionString);
        }

        public async Task PublishAsync<T>(string queueName, T message)
        {
            var sender = _client.CreateSender(queueName);

            var json = JsonSerializer.Serialize(message);

            var serviceBusMessage = new ServiceBusMessage(json)
            {
                ContentType = "application/json"
            };

            await sender.SendMessageAsync(serviceBusMessage);

            await sender.DisposeAsync();

        }
    }
}
