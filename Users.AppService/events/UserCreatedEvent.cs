using System;
using System.Collections.Generic;
using System.Text;

namespace Users.AppService.events
{
    public record UserCreatedEvent(
    Guid UserId,
    string Name,
    string Email
);
}
