using Fleet.Care.Platform.Iam.Domain.Model.Events;
using Fleet.Care.Platform.Shared.Application.Internal.EventHandlers;

namespace Fleet.Care.Platform.Profiles.Application.Internal.EventHandlers;

public class UserRegisteredEventHandler(ILogger<UserRegisteredEventHandler> logger) : IEventHandler<UserRegisteredEvent>
{
    public Task Handle(UserRegisteredEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Processing UserRegisteredEvent for User ID {UserId} ({Username}) in Profiles context",
            domainEvent.UserId.Value, domainEvent.Username);
        return Task.CompletedTask;
    }
}