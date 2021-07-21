using Confluent.Kafka;

namespace ConsumerConfiguration
{
    public interface IConsumerConfigure
    {
        ConsumerConfig GetConsumerConfig();
    }
}
