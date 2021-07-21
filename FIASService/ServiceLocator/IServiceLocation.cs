using FIASService.ConsumerService;

namespace FIASService.ServiceLocator
{
    public interface IServiceLocation
    {
        IConsumerServ GetConsumerService();
    }
}
