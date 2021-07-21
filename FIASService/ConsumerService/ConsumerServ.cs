using Confluent.Kafka;
using FIASLibary.Models;
using FIASLibary.StandartModels;
using FIASService.ConsumerConfiguration;
using FIASService.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FIASService.ConsumerService
{
    public class ConsumerServ : IConsumerServ
    {
        private readonly IConsumerConfigure consumerConfigure;
        private readonly IFulltextSearchRepository fulltextSearchRepository;
        private readonly IGetRootRepository getRootRepository;
        private readonly IGetChildRepository getChildRepository;
        private readonly IGetSteadRepository getSteadRepository;
        private readonly IGetInfoRepository getInfoRepository;
        private readonly IGetHouseRepository getHouseRepository;

        public ConsumerServ(IConsumerConfigure consumerConfigure, IFulltextSearchRepository fulltextSearchRepository, 
            IGetRootRepository getRootRepository, IGetChildRepository getChildRepository, IGetInfoRepository getInfoRepository, 
            IGetSteadRepository getSteadRepository, IGetHouseRepository getHouseRepository)
        {
            this.consumerConfigure = consumerConfigure;
            this.fulltextSearchRepository = fulltextSearchRepository;
            this.getRootRepository = getRootRepository;
            this.getChildRepository = getChildRepository;
            this.getSteadRepository = getSteadRepository;
            this.getInfoRepository = getInfoRepository;
            this.getHouseRepository = getHouseRepository;
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
                    FulltextSearchModel jsonFT = new FulltextSearchModel();

                    if (message.Value.Contains("getinfo") == true)
                    {
                        jsonInfo = Deserialize<GetInfoModel>(message.Value);
                        json.Search = jsonInfo.Search;
                    }
                    else if (message.Value.Contains("FulltextSearch") == true)
                    {
                        jsonFT = Deserialize<FulltextSearchModel>(message.Value);
                        json.Search = jsonFT.Search;
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
                                        querys.AddRange(jsonFT.Data.Split(new char[] { '&' }));

                                        for (int i = 0; i < querys.Count; i++)
                                        {
                                            querys[i].Replace('*', ' ');
                                        }

                                        Data = fulltextSearchRepository.FulltextSearch(querys);

                                        Id = jsonFT.Id;

                                        ResponseProduceFT(Id, Data);

                                        break;
                                    }
                                case "FulltextSearchInfo":
                                    {
                                        Data = fulltextSearchRepository.FulltextSearchInfo(jsonFT.Data);

                                        Id = jsonFT.Id;

                                        ResponseProduceFT(Id, Data);

                                        break;
                                    }
                                case "FulltextSearchStreets":
                                    {
                                        Data = fulltextSearchRepository.FulltextSearchStreets(jsonFT.Data);

                                        Id = jsonFT.Id;

                                        ResponseProduceFT(Id, Data);

                                        break;
                                    }
                                case "FulltextSearchStead":
                                    {
                                        Data = fulltextSearchRepository.FulltextSearchStead(jsonFT.Data);

                                        Id = jsonFT.Id;

                                        ResponseProduceFT(Id, Data);

                                        break;
                                    }
                                case "FulltextSearchHouse":
                                    {
                                        Data = fulltextSearchRepository.FulltextSearchHouse(jsonFT.Data);

                                        Id = jsonFT.Id;

                                        ResponseProduceFT(Id, Data);

                                        break;
                                    }
                                case "getroot":
                                    {
                                        Data = Serialize(getRootRepository.GetRoot(json.Division));

                                        Id = json.Id;

                                        GetRootProduce(Id, Data, json.Search);

                                        break;
                                    }
                                case "getchild":
                                    {
                                        Data = Serialize(getChildRepository.GetChild(json.Data, json.Division, json.AO));

                                        Id = message.Key;                                        

                                        GetChildProduce(Id, Data);

                                        break;
                                    }
                                case "getstead":
                                    {
                                        Data = Serialize(getSteadRepository.GetStead(json.Data));

                                        Id = message.Key;

                                        GetSteadProduce(Id, Data);

                                        break;
                                    }
                                case "gethouse":
                                    {
                                        Data = Serialize(getHouseRepository.GetHouse(json.Data));

                                        Id = message.Key;

                                        GetHouseProduce(Id, Data);

                                        break;
                                    }
                                case "getinfo":
                                    {
                                        Data = getInfoRepository.GetInfo(jsonInfo.Division, jsonInfo.Addrobj, jsonInfo.House, jsonInfo.Room);

                                        Id = message.Key;

                                        GetInfoProduce(Id, Data);

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

        public async void ResponseProduceFT(string Id, string Data)
        {
            var producerConfig = consumerConfigure.GetProducerConfig();

            using (var producer = new ProducerBuilder<string, string>(producerConfig).Build())
            {
                string request = string.Format("{{\"id\" : \"{0}\", \"data\" : {1} }}", Id, Data);
                await producer.ProduceAsync("fias-response", new Message<string, string> { Key = Id, Value = request });
            }
        }

        public async void GetRootProduce(string Id, string Data, string search)
        {
            var producerConfig = consumerConfigure.GetProducerConfig();

            using (var producer = new ProducerBuilder<string, string>(producerConfig).Build())
            {
                string request = string.Format("{{\"id\" : \"{0}\", \"data\" : {1}, \"search\" : \"{2}\" }}", Id, Data, search);
                await producer.ProduceAsync("fias-response", new Message<string, string> { Key = Id, Value = request });
            }
        }

        public async void GetChildProduce(string Id, string Data)
        {
            var producerConfig = consumerConfigure.GetConsumerConfig();

            using (var producer = new ProducerBuilder<string, string>(producerConfig).Build())
            {
                string request = string.Format("{{\"id\" : \"{0}\", \"data\" : {1} }}", Id, Data);
                await producer.ProduceAsync("fias-response", new Message<string, string> { Key = Id, Value = request });
            }
        }

        public async void GetSteadProduce(string Id, string Data)
        {
            var producerConfig = consumerConfigure.GetConsumerConfig();

            using (var producer = new ProducerBuilder<string, string>(producerConfig).Build())
            {
                string request = string.Format("{{\"id\" : \"{0}\", \"data\" : {1} }}", Id, Data);
                await producer.ProduceAsync("fias-response", new Message<string, string> { Key = Id, Value = request });
            }
        }

        public async void GetHouseProduce(string Id, string Data)
        {
            var producerConfig = consumerConfigure.GetConsumerConfig();

            using (var producer = new ProducerBuilder<string, string>(producerConfig).Build())
            {
                string request = string.Format("{{\"id\" : \"{0}\", \"data\" : {1} }}", Id, Data);
                await producer.ProduceAsync("fias-response", new Message<string, string> { Key = Id, Value = request });
            }
        }

        public async void GetInfoProduce(string Id, string Data)
        {
            var producerConfig = consumerConfigure.GetConsumerConfig();

            using (var producer = new ProducerBuilder<string, string>(producerConfig).Build())
            {
                string request = string.Format("{{\"id\" : \"{0}\", \"data\" : {1} }}", Id, Data);
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
