using System;
using System.Diagnostics;

namespace Itk.Explorer.Core.Hello
{
    public readonly struct HelloEvent: IEvent
    {
        
    }

    public readonly struct ReplyEvent : IEvent
    {
        
    }

    public readonly struct GoodByeEvent : IEvent
    {
        
    }

    internal sealed class ReplyService
    {
        public void HandleReplyEvent(ReplyEvent e)
        {
            Trace.WriteLine("Hi There!");
        }
    }

    internal sealed class HelloService
    {
        private readonly Action<IEvent> _dispatcher;

        public HelloService(Action<IEvent> dispatcher)
        {
            _dispatcher = dispatcher;
        }
        public void HandleHelloEvent(HelloEvent e)
        {
            Trace.WriteLine("Received message from the outside world!");
            _dispatcher(new ReplyEvent());
        }

        public void HandleGoodByeEvent(GoodByeEvent e)
        {
            Trace.WriteLine("GoodBye Cruel World!");
        }
    }
}