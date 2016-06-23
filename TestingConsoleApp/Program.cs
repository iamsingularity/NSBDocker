using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

namespace TestingConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(Main).Wait();

            //Console.ReadLine();
        }

        static async Task Main()
        {
            // Wait for rabbit queue to come up
            await Task.Delay(5000);

            var loggerDefinition = LogManager.Use<ConsoleLoggerDefinition>();
            loggerDefinition.Level(LogLevel.Info);

            var endpointConfiguration = new EndpointConfiguration("Samples.SelfHosting");

            endpointConfiguration.LicensePath(@"License.xml");

            endpointConfiguration.UseSerialization<JsonSerializer>();
            var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
            transport.ConnectionString("host=rabbit");
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            endpointConfiguration.SendFailedMessagesTo("error");

            var endpointInstance = await Endpoint.Start(endpointConfiguration);
            try
            {
                var myMessage = new MyMessage();
                await endpointInstance.SendLocal(myMessage);
                await Task.Delay(5000);
            }
            finally
            {
                await endpointInstance.Stop();
            }
        }
    }
}