using Confluent.Kafka;

namespace FIASService.ConsumerConfiguration
{
    public interface IConsumerConfigure
    {
        ConsumerConfig GetConsumerConfig();

        ProducerConfig GetProducerConfig();
    }
}
