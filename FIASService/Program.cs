using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FIASService.ConsumerConfiguration;
using FIASService.ConsumerService;
using FIASService.Repositories;
using FIASService.ServiceLocator;
using System.ServiceProcess;

namespace FIASService
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main()
        {
            WindsorContainer windsorContainer = new WindsorContainer();
            InitContainer(windsorContainer);
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1(new ServiceLocation(windsorContainer))
            };
            ServiceBase.Run(ServicesToRun);
        }

        private static void InitContainer(WindsorContainer windsorContainer)
        {
            windsorContainer.Register(Component.For<IConsumerServ>().ImplementedBy<ConsumerServ>());

            windsorContainer.Register(Component.For<IConsumerConfigure>().ImplementedBy<ConsumerConfigure>());

            windsorContainer.Register(Component.For<IFulltextSearchRepository>().ImplementedBy<FulltextSearchRepository>());

            windsorContainer.Register(Component.For<IGetRootRepository>().ImplementedBy<GetRootRepository>());

            windsorContainer.Register(Component.For<IGetChildRepository>().ImplementedBy<GetChildRepository>());

            windsorContainer.Register(Component.For<IGetSteadRepository>().ImplementedBy<GetSteadRepository>());

            windsorContainer.Register(Component.For<IGetHouseRepository>().ImplementedBy<GetHouseRepository>());

            windsorContainer.Register(Component.For<IGetInfoRepository>().ImplementedBy<GetInfoRepository>());

            windsorContainer.Register(Component.For<IServiceLocation>().ImplementedBy<ServiceLocation>());
        }
    }
}
