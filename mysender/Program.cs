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
                _.Publish.AllMessagesTo("durable://localhost:8567");
            });
        }
    }
}
