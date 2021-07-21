using Confluent.Kafka;

namespace ResponseApi.ConsumerConfiguration
{
    public interface IConsumerConfigure
    {
        ConsumerConfig GetConsumerConfig();
    }
}
