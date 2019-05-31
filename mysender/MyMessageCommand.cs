using Jasper.CommandLine;
using myservice;
using Oakton;
using System;
using System.Collections.Generic;
using System.Text;

namespace mysender
{
    public class MyMessageCommand : OaktonCommand<JasperInput>
    {
        public override bool Execute(JasperInput input)
        {
            using (var runtime = input.BuildHost(StartMode.Full))
            {
                var m = new MyMessage { Id = Guid.NewGuid(), Message = "Test message" };
                runtime.Messaging.Publish(m);
            }

            return true;
        }
    }
}
