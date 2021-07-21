using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fias_Service.ConsumerConfiguration
{
    public interface IConsumerConfigure
    {
        ConsumerConfig GetConsumerConfig();

        ProducerConfig GetProducerConfig();
    }
}
