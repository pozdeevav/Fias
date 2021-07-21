using Confluent.Kafka;
using FIASLibary.Models;
using FIASLibary.StandartModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ResponseApi.ConsumerConfiguration;
using System;
using System.Collections.Generic;

namespace ResponseApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResponseController : Controller
    {
        private readonly IConsumerConfigure consumerConfigure;

        public ResponseController(IConsumerConfigure consumerConfigure)
        {
            this.consumerConfigure = consumerConfigure;
        }

        [HttpGet("fulltextsearch/{Id}")]
        public string Fulltextsearch(string Id)
        {
            var consumerConfig = consumerConfigure.GetConsumerConfig();

            using (var consumer = new ConsumerBuilder<string, string>(consumerConfig).Build())
            {
                consumer.Subscribe("fias-response");

                while (true)
                {
                    var con = consumer.Consume();
                    var message = con.Message;

                    try
                    {
                        if (message.Key == Id)
                        {
                            var json = message.Value;

                            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:51479");

                            return json;
                        }
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
            }
        }

        [HttpGet("getfulltextinfo/{Id}")]
        public string GetFulltextInfo(string Id)
        {
            var consumerConfig = consumerConfigure.GetConsumerConfig();

            using (var consumer = new ConsumerBuilder<string, string>(consumerConfig).Build())
            {
                consumer.Subscribe("fias-response");

                while (true)
                {
                    var con = consumer.Consume();
                    var message = con.Message;

                    try
                    {
                        if (message.Key == Id)
                        {
                            var json = message.Value;

                            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:51479");

                            return json;
                        }
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
            }
        }

        [HttpGet("getroot/{Id}")]
        public string GetRoot(string Id)
        {
            var consumerConfig = consumerConfigure.GetConsumerConfig();

            using (var consumer = new ConsumerBuilder<string, string>(consumerConfig).Build())
            {
                consumer.Subscribe("fias-response");

                while (true)
                {
                    var con = consumer.Consume();
                    var message = con.Message;

                    try
                    {
                        if (message.Key == Id)
                        {
                            var json = message.Value;

                            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:51479");

                            return json;
                        }
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
            }
        }

        [HttpGet("getchild/{Id}")]
        public string GetChild(string Id)
        {
            var consumerConfig = consumerConfigure.GetConsumerConfig();

            using (var consumer = new ConsumerBuilder<string, string>(consumerConfig).Build())
            {
                consumer.Subscribe("fias-response");

                while (true)
                {
                    var con = consumer.Consume();
                    var message = con.Message;

                    try
                    {
                        if (message.Key == Id)
                        {
                            var json = message.Value;

                            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:51479");

                            return json;
                        }
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
            }
        }

        [HttpGet("getstead/{Id}")]
        public string GetStead(string Id)
        {
            var consumerConfig = consumerConfigure.GetConsumerConfig();

            using (var consumer = new ConsumerBuilder<string, string>(consumerConfig).Build())
            {
                consumer.Subscribe("fias-response");

                while (true)
                {
                    var con = consumer.Consume();
                    var message = con.Message;

                    try
                    {
                        if (message.Key == Id)
                        {
                            var json = message.Value;

                            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:51479");

                            return json;
                        }
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
            }
        }

        [HttpGet("gethouse/{Id}")]
        public string GetHouse(string Id)
        {
            var consumerConfig = consumerConfigure.GetConsumerConfig();

            using (var consumer = new ConsumerBuilder<string, string>(consumerConfig).Build())
            {
                consumer.Subscribe("fias-response");

                while (true)
                {
                    var con = consumer.Consume();
                    var message = con.Message;

                    try
                    {
                        if (message.Key == Id)
                        {
                            var json = message.Value;

                            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:51479");

                            return json;
                        }
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
            }
        }

        [HttpGet("getinfo/{Id}")]
        public string GetInfo(string Id)
        {
            var consumerConfig = consumerConfigure.GetConsumerConfig();

            using (var consumer = new ConsumerBuilder<string, string>(consumerConfig).Build())
            {
                consumer.Subscribe("fias-response");

                while (true)
                {
                    var con = consumer.Consume();
                    var message = con.Message;

                    try
                    {
                        if (message.Key == Id)
                        {
                            var json = message.Value;

                            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:51479");

                            return json;
                        }
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
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