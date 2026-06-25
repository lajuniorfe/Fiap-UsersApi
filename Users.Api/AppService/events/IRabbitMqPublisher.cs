using System;
using System.Collections.Generic;
using System.Text;

namespace Users.AppService.events
{
    public interface IRabbitMqPublisher
    {
        Task PublishAsync<T>(string queue, T message);
    }
}
