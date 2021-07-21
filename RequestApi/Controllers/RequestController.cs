using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace RequestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : Controller
    {
        private readonly IProducer<string, string> producer;

        public RequestController(IProducer<string, string> producer)
        {
            this.producer = producer;
        }
        
        [HttpPost("fulltextsearch/{Parent}/{query}")]
        public async Task FulltextSearch(string Parent, string query)
        {
            string Id = Parent;

            Response.Headers.Add("Request-ID", Id);
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:51479");

            string request = string.Format("{{\"id\" : \"{0}\", \"search\" : \"{1}\", \"data\" : \"{2}\" }}", Id, "FulltextSearch", query);
            await producer.ProduceAsync("fias-request", new Message<string, string> { Key = Id, Value = request });
        }

        [HttpPost("fulltextsearchinfo/{Id}/{Parent}")]
        public async Task FulltextSearchInfo(string Id, string Parent)
        {
            Response.Headers.Add("Request-ID", Id);
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:51479");

            string request = string.Format("{{\"id\" : \"{0}\", \"search\" : \"{1}\", \"data\" : \"{2}\" }}", Id, "FulltextSearchInfo", Parent);
            await producer.ProduceAsync("fias-request", new Message<string, string> { Key = Id, Value = request });
        }

        [HttpPost("fulltextsearchstreets/{Id}/{Parent}")]
        public async Task FulltextSearchStreets(string Id, string Parent)
        {
            Response.Headers.Add("Request-ID", Id);
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:51479");

            string request = string.Format("{{\"id\" : \"{0}\", \"search\" : \"{1}\", \"data\" : \"{2}\" }}", Id, "FulltextSearchStreets", Parent);
            await producer.ProduceAsync("fias-request", new Message<string, string> { Key = Id, Value = request });
        }

        [HttpPost("fulltextsearchstead/{Id}/{Parent}")]
        public async Task FulltextSearchStead(string Id, string Parent)
        {
            Response.Headers.Add("Request-ID", Id);
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:51479");

            string request = string.Format("{{\"id\" : \"{0}\", \"search\" : \"{1}\", \"data\" : \"{2}\" }}", Id, "FulltextSearchStead", Parent);
            await producer.ProduceAsync("fias-request", new Message<string, string> { Key = Id, Value = request });
        }

        [HttpPost("fulltextsearchhouse/{Id}/{Parent}")]
        public async Task FulltextSearchHouse(string Id, string Parent)
        {
            Response.Headers.Add("Request-ID", Id);
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:51479");

            string request = string.Format("{{\"id\" : \"{0}\", \"search\" : \"{1}\", \"data\" : \"{2}\" }}", Id, "FulltextSearchHouse", Parent);
            await producer.ProduceAsync("fias-request", new Message<string, string> { Key = Id, Value = request });
        }

        [HttpPost("advancedsearch")]
        public async Task AdvancedSearch(string Id, [FromBody] dynamic Data)
        {
            Id = Guid.NewGuid().ToString();

            Response.Headers.Add("Request-ID", Id);

            string request = string.Format("{{\"id\" : \"{0}\", \"search\" : \"{1}\", \"data\" : {2} }}", Id, "AdvancedSearch", Data);
            await producer.ProduceAsync("fias-request", new Message<string, string> { Key = Id, Value = request });
        }

        [HttpPost("getroot/{Radio}/{Id}")]
        public async Task GetRoot(string Id, string Radio)
        {
            Response.Headers.Add("Get-Root-Key", Id);
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:51479");

            string request = string.Format("{{\"id\" : \"{0}\", \"search\" : \"{1}\", \"division\" : \"{2}\" }}", Id, "getroot", Radio);
            await producer.ProduceAsync("fias-request", new Message<string, string> { Key = Id, Value = request });
        }

        [HttpPost("getchild/{Id}/{Parent}/{Radio}/{AO}")]
        public async Task GetChild(string Id, string Parent, int Radio, string AO)
        {
            Response.Headers.Add("Get-Child-Key", Id);
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:51479");

            string request = string.Format("{{\"id\" : \"{0}\", \"search\" : \"{1}\", \"data\" : \"{2}\", \"division\" : \"{3}\", \"ao\" : \"{4}\" }}", Id, "getchild", Parent, Radio, AO);
            await producer.ProduceAsync("fias-request", new Message<string, string> { Key = Id, Value = request });
        }

        [HttpPost("getstead/{Id}/{Parent}")]
        public async Task GetStead(string Id, string Parent)
        {
            Id = Parent;

            Response.Headers.Add("Get-Child-Key", Id);
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:51479");

            string request = string.Format("{{\"id\" : \"{0}\", \"search\" : \"{1}\", \"data\" : \"{2}\" }}", Id, "getstead", Parent);
            await producer.ProduceAsync("fias-request", new Message<string, string> { Key = Id, Value = request });
        }

        [HttpPost("gethouse/{Id}/{Parent}")]
        public async Task GetHouse(string Id, string Parent)
        {
            Response.Headers.Add("Get-Child-Key", Id);
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:51479");

            string request = string.Format("{{\"id\" : \"{0}\", \"search\" : \"{1}\", \"data\" : \"{2}\" }}", Id, "gethouse", Parent);
            await producer.ProduceAsync("fias-request", new Message<string, string> { Key = Id, Value = request });
        }

        [HttpPost("getinfo/{Id}/{division}/{addrobj}/{house}/{room}")]
        public async Task GetInfo(string Id, string division, string addrobj, string house, string room)
        {
            Response.Headers.Add("Get-Info-Key", Id);
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:51479");

            string request = string.Format("{{\"id\" : \"{0}\", \"search\" : \"{1}\", \"division\" : \"{2}\", \"addrobj\" : \"{3}\", \"house\" : \"{4}\", \"room\" : \"{5}\" }}", Id, "getinfo", division, addrobj, house, room);
            await producer.ProduceAsync("fias-request", new Message<string, string> { Key = Id, Value = request });
        }
    }
}