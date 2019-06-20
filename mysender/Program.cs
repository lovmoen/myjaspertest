using Jasper;
using System;

namespace mysender
{
    class Program
    {
        static int Main(string[] args)
        {
            return JasperHost.Run(args, _ =>
            {
                _.Publish.AllMessagesTo("tcp://localhost:8567");
                _.Transports.LightweightListenerAt(8568);
            });
        }
    }
}
