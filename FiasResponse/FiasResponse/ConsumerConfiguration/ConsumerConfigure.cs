using Confluent.Kafka;
using ConsumerConfiguration;

namespace FiasResponse.ConsumerConfiguration
{
    public class ConsumerConfigure : IConsumerConfigure
    {
        public ConsumerConfig GetConsumerConfig()
        {
            return new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "consumer-group",
                //EnableAutoCommit = true,
                //AutoCommitIntervalMs = 1000,
                SessionTimeoutMs = 30000
            };
        }
    }
}
