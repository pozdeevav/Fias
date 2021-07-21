using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Fias_Service.ConsumerConfiguration;
using Fias_Service.ConsumerService;
using Fias_Service.Repositories;
using Fias_Service.ServiceLocator;
using System.ServiceProcess;

namespace Fias_Service
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main()
        {
            WindsorContainer container = new WindsorContainer();
            InitContainer(container);
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1(/*new ServiceLocation(container*/)
            };
            ServiceBase.Run(ServicesToRun);
        }

        private static void InitContainer(WindsorContainer container)
        {
            container.Register(Component.For<IConsumerServ>().ImplementedBy<ConsumerServ>());

            container.Register(Component.For<IConsumerConfigure>().ImplementedBy<ConsumerConfigure>());

            container.Register(Component.For<IFulltextSearchRepository>().ImplementedBy<FulltextSearchRepository>());

            container.Register(Component.For<IGetChildRepository>().ImplementedBy<GetChildRepository>());

            container.Register(Component.For<IGetHouseRepository>().ImplementedBy<GetHouseRepository>());

            container.Register(Component.For<IGetInfoRepository>().ImplementedBy<GetInfoRepository>());

            container.Register(Component.For<IGetRootRepository>().ImplementedBy<GetRootRepository>());

            container.Register(Component.For<IGetSteadRepository>().ImplementedBy<GetSteadRepository>());
            
            container.Register(Component.For<IServiceLocation>().ImplementedBy<ServiceLocation>());
        }
    }
}
