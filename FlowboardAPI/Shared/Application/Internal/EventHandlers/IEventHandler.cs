using FlowboardAPI.Shared.Domain.Model.Events;
using Cortex.Mediator.Notifications;

namespace FlowboardAPI.Shared.Application.Internal.EventHandlers;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
}