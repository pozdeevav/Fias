using Confluent.Kafka;

namespace ResponseApi.ConsumerConfiguration
{
    public class ConsumerConfigure : IConsumerConfigure
    {
        public ConsumerConfig GetConsumerConfig()
        {
            return new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "consumer-group",
                EnableAutoCommit = true
            };
        }
    }
}
