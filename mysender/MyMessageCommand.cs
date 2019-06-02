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
    public class MyMessageCommand : OaktonCommand<JasperInput>
    {
        private static ManualResetEvent _event = new ManualResetEvent(false);

        public override bool Execute(JasperInput input)
        {
            ExecuteAsync(input);
            _event.WaitOne();

            return true;
        }

        private static async void ExecuteAsync(JasperInput input)
        {
            using (var runtime = input.BuildHost(StartMode.Full))
            {
                var m = new MyMessage { Id = Guid.NewGuid(), Message = "Test message" };
                await runtime.Messaging.Publish(m);
                await Task.Delay(1000);
                _event.Set();
            }
        }
    }
}
