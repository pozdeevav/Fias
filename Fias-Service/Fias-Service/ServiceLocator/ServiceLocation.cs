using Castle.Windsor;
using Fias_Service.ConsumerService;

namespace Fias_Service.ServiceLocator
{
    public class ServiceLocation : IServiceLocation
    {
        public readonly WindsorContainer container;

        public ServiceLocation(WindsorContainer container)
        {
            this.container = container;
        }

        public IConsumerServ GetConsumerServ()
        {
            return container.Resolve<IConsumerServ>();
        }
    }
}
