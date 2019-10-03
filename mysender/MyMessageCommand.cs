using Jasper.CommandLine;
using myservice;
using Oakton;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Jasper.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Oakton.AspNetCore;

namespace mysender
{
    // This changes to NetCoreInput in Oakton.AspNetCore v2 when you go to netcoreapp3.0,
    // but that's tomorrow's problem
    public class MyMessageInput : AspNetCoreInput
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
            using (var host = input.BuildHost())
            {
                var messaging = host.Services.GetRequiredService<IMessagePublisher>();
                var m = new MyMessage { Id = Guid.NewGuid(), Message = $"#{input.MessageNumber}" };
                await messaging.Publish(m);
                MyResponseHandler.MyResponseEvent.WaitOne();
            }

            return true;
        }
    }
}
