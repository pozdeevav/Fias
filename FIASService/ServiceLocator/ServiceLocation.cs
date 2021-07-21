using Castle.Windsor;
using FIASService.ConsumerService;

namespace FIASService.ServiceLocator
{
    public class ServiceLocation : IServiceLocation
    {
        public readonly WindsorContainer windsorContainer;

        public ServiceLocation(WindsorContainer windsorContainer)
        {
            this.windsorContainer = windsorContainer;
        }

        public IConsumerServ GetConsumerService()
        {
            return windsorContainer.Resolve<IConsumerServ>();
        }
    }
}
