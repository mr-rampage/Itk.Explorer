using System;
using Itk.Explorer.Core.Hello;
using Rampage.Messaging;
using Rampage.Messaging.Bus;
using Rampage.Messaging.Hub;

namespace Itk.Explorer.Core
{
    public interface IEvent
    {
        
    }
    public interface IEventBus
    {
        void Publish(IEvent message);
    }
    public sealed class EventBus: IEventBus, IDisposable
    {
        private readonly IHub<IEvent> _hub;
        private readonly IMessageBus<IEvent> _bus;

        private EventBus(IHub<IEvent> hub, IMessageBus<IEvent> bus)
        {
            _hub = hub;
            _bus = bus;
            _hub.Start(_bus);
        }

        public void Publish(IEvent message)
        {
            _bus.Publish(message);
        }
        
        public static IEventBus Create()
        {
            var hubNode = new HubNode<IEvent>()
                .Deploy(new ServiceNodeFactory<HelloService, IEvent>());
            return new EventBus(hubNode, new TaskMessageBus<IEvent>());
        }

        public void Dispose()
        {
            _hub.Stop();
        }
    }
}