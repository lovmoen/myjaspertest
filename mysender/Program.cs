using Jasper;
using System;
using System.Threading.Tasks;
using myservice;

namespace mysender
{
    class Program
    {
        static Task<int> Main(string[] args)
        {
            return JasperHost.Run(args, _ =>
            {
                _.Publish.AllMessagesTo("tcp://localhost:9998");
                _.Transports.LightweightListenerAt(9999);
            });
        }
    }
}
