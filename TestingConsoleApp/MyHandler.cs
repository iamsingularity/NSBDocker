using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

namespace TestingConsoleApp
{
    public class MyHandler : IHandleMessages<MyMessage>
    {
        static ILog logger = LogManager.GetLogger<MyHandler>();

        public Task Handle(MyMessage message, IMessageHandlerContext context)
        {
            logger.Info("Hello from MyHandler");
            return Task.FromResult(0);
        }
    }
}