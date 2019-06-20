using Jasper.CommandLine;
using myservice;
using Oakton;
using System.Threading.Tasks;

namespace mysender
{
    public class AnotherMessageCommand : OaktonAsyncCommand<JasperInput>
    {
        public override async Task<bool> Execute(JasperInput input)
        {
            using (var runtime = input.BuildHost(StartMode.Full))
            {
                var m = new AnotherMessage();
                await runtime.Messaging.Publish(m);
                MyResponseHandler.MyResponseEvent.WaitOne();
            }

            return true;
        }
    }
}
