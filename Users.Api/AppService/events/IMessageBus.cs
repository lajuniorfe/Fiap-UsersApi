using System;
using System.Collections.Generic;
using System.Text;

namespace Users.AppService.events
{
    public interface IMessageBus
    {
        Task PublishAsync<T>(string queueName, T message);
    }
}
