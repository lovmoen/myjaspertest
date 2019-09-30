using Jasper;
using System;
using System.Threading.Tasks;

namespace mysender
{
    class Program
    {
        static Task<int> Main(string[] args)
        {
            return JasperHost.Run(args, _ =>
            {
                _.Publish.AllMessagesTo("durable://localhost:8567");
                _.Transports.LightweightListenerAt(8568);
            });
        }
    }
}
