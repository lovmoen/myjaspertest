using Jasper;

namespace myservice
{
    internal class JasperConfig : JasperRegistry
    {
        public JasperConfig()
        {
            Transports.LightweightListenerAt(8567);

            Publish.Message<MyResponse>().To("tcp://localhost:8568");

            Handlers.Worker("myqueue")
                .HandlesMessage<YetAnotherMessage>();
        }
    }
}
