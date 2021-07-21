using Fias_Service.ConsumerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fias_Service.ServiceLocator
{
    public interface IServiceLocation
    {
        IConsumerServ GetConsumerServ();
    }
}
