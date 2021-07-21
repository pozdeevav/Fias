using Fias_Service.Models;
using System.Collections.Generic;

namespace Fias_Service.Repositories
{
    public interface IGetSteadRepository
    {
        Dictionary<int, SteadModel> GetStead(string Parent);
    }
}
