using Confluent.Kafka;
using Fias_Service.ConsumerConfiguration;
using Fias_Service.Models;
using Fias_Service.Repositories;
using Fias_Service.StandartModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fias_Service.ConsumerService
{
    public class ConsumerServ : IConsumerServ
    {
        private readonly IFulltextSearchRepository fulltextSearchRepository;
        private readonly IGetChildRepository getChildRepository;
        private readonly IGetHouseRepository getHouseRepository;
        private readonly IGetInfoRepository getInfoRepository;
        private readonly IGetRootRepository getRootRepository;
        private readonly IGetSteadRepository getSteadRepository;
        private readonly IConsumerConfigure consumerConfigure;

        public ConsumerServ(IFulltextSearchRepository fulltextSearchRepository, IGetChildRepository getChildRepository, 
            IGetHouseRepository getHouseRepository, IGetInfoRepository getInfoRepository, IGetRootRepository getRootRepository,
            IGetSteadRepository getSteadRepository, IConsumerConfigure consumerConfigure)
        {
            this.fulltextSearchRepository = fulltextSearchRepository;
            this.getChildRepository = getChildRepository;
            this.getHouseRepository = getHouseRepository;
            this.getInfoRepository = getInfoRepository;
            this.getRootRepository = getRootRepository;
            this.getSteadRepository = getSteadRepository;
            this.consumerConfigure = consumerConfigure;
        }

        public void Consume()
        {
            var consumerConfig = consumerConfigure.GetConsumerConfig();
            var producerConfig = consumerConfigure.GetProducerConfig();

            using (var consumer = new ConsumerBuilder<string, string>(consumerConfig).Build())
            {
                consumer.Subscribe("fias-request");

                while (true)
                {
                    var con = consumer.Consume();
                    var message = con.Message;

                    string Data = "";
                    string Id = "";

                    GetInfoModel jsonInfo = new GetInfoModel();
                    GetModel json = new GetModel();
                    FulltextSearchModel jsonFt = new FulltextSearchModel();

                    if (message.Value.Contains("getinfo") == true)
                    {
                        jsonInfo = Deserialize<GetInfoModel>(message.Value);
                        json.Search = jsonInfo.Search;
                    }
                    else if (message.Value.Contains("FulltextSearch") == true)
                    {
                        jsonFt = Deserialize<FulltextSearchModel>(message.Value);
                        json.Search = jsonFt.Search;
                    }
                    else
                    {
                        json = Deserialize<GetModel>(message.Value);
                    }

                    try
                    {
                        switch (json.Search)
                        {
                            case "FulltextSearch":
                                {
                                    List<string> querys = new List<string>();
                                    querys.AddRange(jsonFt.Data.Split(new char[] { '&' }));

                                    Data = fulltextSearchRepository.FulltextSearch(querys);

                                    Id = jsonFt.Id;

                                    ProduceResponse(Id, Data);

                                    break;
                                }
                            case "FulltextSearchInfo":
                                {
                                    Data = fulltextSearchRepository.FulltextSearchInfo(jsonFt.Data);

                                    Id = jsonFt.Id;

                                    ProduceResponse(Id, Data);

                                    break;
                                }
                            case "FulltextSearchStead":
                                {
                                    Data = fulltextSearchRepository.FulltextSearchStead(jsonFt.Data);

                                    Id = jsonFt.Id;

                                    ProduceResponse(Id, Data);

                                    break;
                                }
                            case "FulltextSearchHouse":
                                {
                                    Data = fulltextSearchRepository.FulltextSearchHouse(jsonFt.Data);

                                    Id = jsonFt.Id;

                                    ProduceResponse(Id, Data);

                                    break;
                                }
                        }
                    }
                    catch (Exception e)
                    {
                        return;
                    }

                }
            }
        }

        public async void ProduceResponse(string Id, string Data)
        {
            var producerConfig = consumerConfigure.GetProducerConfig();

            using (var producer = new ProducerBuilder<string, string>(producerConfig).Build())
            {
                string request = string.Format("{{\"id\" : \"{0}\", \"data\" : \"{1}\"}}");
                await producer.ProduceAsync("fias-response", new Message<string, string> { Key = Id, Value = request });
            }
        }

        public TResult Deserialize<TResult>(string obj)
        {
            return JsonConvert.DeserializeObject<TResult>(obj);
        }

        public string Serialize<TParam>(TParam obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
