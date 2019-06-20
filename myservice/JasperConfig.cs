using Jasper;
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

            Transports.LightweightListenerAt(8567);

            Publish.Message<MyResponse>().To("tcp://localhost:8568");

            Handlers.Worker("myqueue")
                .IsDurable()
                .HandlesMessage<YetAnotherMessage>();
        }
    }
}
