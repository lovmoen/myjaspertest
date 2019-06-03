using System;
using Jasper;
using Jasper.CommandLine;
using Jasper.Persistence.Marten;
using Microsoft.Extensions.Configuration;

namespace myservice
{
    internal class JasperConfig : JasperRegistry
    {
        public JasperConfig()
        {
            Include<MartenBackedPersistence>();

            Settings.ConfigureMarten((context, marten) =>
            {
                marten.Connection(context.Configuration.GetConnectionString("my_conn_str"));
            });

            Transports.DurableListenerAt(8567);
            Publish.AllMessagesTo("tcp://localhost:8568");
        }
    }
}
