using Jasper.Messaging;
using System;

namespace myservice
{
    public class AnotherMessageHandler
    {
        public void Handle(AnotherMessage message, IMessageContext bus)
        {
            // If Schedule() is called instead of ScheduleSend(), the YetAnotherMessage handler is never called.
            //bus.Schedule(new YetAnotherMessage(), TimeSpan.FromSeconds(10));

            // When ScheduleSend() is called, the YetAnotherMessage handler is invoked after the prescribed 10 seconds.
            bus.ScheduleSend(new YetAnotherMessage(), TimeSpan.FromSeconds(10));
        }

        public object Handle(YetAnotherMessage message)
        {
            return new MyResponse { Id = Guid.NewGuid(), Response = "YetAnotherMessage handled" };
        }
    }
}
