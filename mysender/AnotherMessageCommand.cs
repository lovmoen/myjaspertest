using myservice;
using Oakton;
using System.Threading.Tasks;
using Jasper.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Oakton.AspNetCore;

namespace mysender
{
    public class AnotherMessageCommand : OaktonAsyncCommand<AspNetCoreInput>
    {
        public override async Task<bool> Execute(AspNetCoreInput input)
        {
            using (var host = input.BuildHost())
            {
                await host.StartAsync();
                var messaging = host.Services.GetRequiredService<IMessageContext>();
                var m = new AnotherMessage();
                await messaging.Publish(m);
                MyResponseHandler.MyResponseEvent.WaitOne();
                await host.StopAsync();
            }

            return true;
        }
    }
}
