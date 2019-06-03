using Jasper.CommandLine;
using myservice;
using Oakton;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mysender
{
    public class MyMessageInput : JasperInput
    {
        [Description("Message number")]
        public int MessageNumber { get; set; }
    }

    public class MyMessageCommand : OaktonAsyncCommand<MyMessageInput>
    {
        public MyMessageCommand()
        {
            Usage("Send message with given number").Arguments(x => x.MessageNumber);
        }

        public override async Task<bool> Execute(MyMessageInput input)
        {
            using (var runtime = input.BuildHost(StartMode.Full))
            {
                var m = new MyMessage { Id = Guid.NewGuid(), Message = $"#{input.MessageNumber}" };
                await runtime.Messaging.Publish(m);
                MyResponseHandler.MyResponseEvent.WaitOne();
            }

            return true;
        }
    }
}
