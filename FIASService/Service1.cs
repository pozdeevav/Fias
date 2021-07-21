using FIASService.ServiceLocator;
using System.ServiceProcess;
using System.Threading;

namespace FIASService
{
    public partial class Service1 : ServiceBase
    {
        private readonly IServiceLocation serviceLocation;

        public Service1(IServiceLocation serviceLocation)
        {
            this.serviceLocation = serviceLocation;
        }

        protected override void OnStart(string[] args)
        {
            Thread ConsumerThread = new Thread(new ThreadStart(serviceLocation.GetConsumerService().Consume));
            ConsumerThread.Start();
        }

        protected override void OnStop()
        {
        }
    }
}
