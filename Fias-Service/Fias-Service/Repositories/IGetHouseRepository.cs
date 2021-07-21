using Fias_Service.Models;
using System.Collections.Generic;

namespace Fias_Service.Repositories
{
    public interface IGetHouseRepository
    {
        Dictionary<int, HouseModel> GetHouse(string Id);
    }
}
