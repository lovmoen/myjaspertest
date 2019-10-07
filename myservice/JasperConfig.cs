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

            Transports.LightweightListenerAt(9998);

            Publish.Message<MyResponse>().To("tcp://localhost:9999");

            Handlers.Worker("myqueue")
                //.IsDurable()
                .HandlesMessage<YetAnotherMessage>();
        }
    }
}
