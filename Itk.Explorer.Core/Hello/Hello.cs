using System.Diagnostics;

namespace Itk.Explorer.Core.Hello
{
    public readonly struct HelloEvent: IEvent
    {
        
    }

    public readonly struct GoodByeEvent : IEvent
    {
        
    }

    internal sealed class HelloService
    {
        public void HandleHelloEvent(HelloEvent e)
        {
            Trace.WriteLine("Received message from the outside world!");
        }

        public void HandleGoodByeEvent(GoodByeEvent e)
        {
            Trace.WriteLine("GoodBye Cruel World!");
        }
    }
}