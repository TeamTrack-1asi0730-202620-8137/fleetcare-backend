using Cortex.Mediator.Notifications;
using Fleet.Care.Platform.Shared.Domain.Model.Events;

namespace Fleet.Care.Platform.Shared.Application.Internal.EventHandlers;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
}