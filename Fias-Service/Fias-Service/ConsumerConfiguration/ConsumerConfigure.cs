using Confluent.Kafka;
using Fias_Service.ConsumerConfiguration;

namespace Fias_Service.ConsumerConfiguration
{
    public class ConsumerConfigure : IConsumerConfigure
    {
        public ConsumerConfig GetConsumerConfig()
        {
            return new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "consumer-group"
            };
        }

        public ProducerConfig GetProducerConfig()
        {
            return new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };
        }
    }
}
