using Jasper.Messaging;
using System;
using System.Threading.Tasks;

namespace myservice
{
    public class AnotherMessageHandler
    {
        public async Task Handle(AnotherMessage message, IMessageContext bus)
        {
            // If Schedule() is called instead of ScheduleSend(), the YetAnotherMessage handler is never called.
            //await bus.Schedule(new YetAnotherMessage(), TimeSpan.FromSeconds(10));

            // When ScheduleSend() is called, the YetAnotherMessage handler is invoked immediately.
            await bus.ScheduleSend(new YetAnotherMessage {TimeStamp = DateTime.UtcNow}, TimeSpan.FromSeconds(10));
        }

        public object Handle(YetAnotherMessage message)
        {
            return new MyResponse { Id = Guid.NewGuid(), Response = $"YetAnotherMessage created at {message.TimeStamp} handled at {DateTime.UtcNow}" };
        }
    }
}
