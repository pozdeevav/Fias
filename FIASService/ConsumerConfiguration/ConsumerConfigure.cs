using Confluent.Kafka;

namespace FIASService.ConsumerConfiguration
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
