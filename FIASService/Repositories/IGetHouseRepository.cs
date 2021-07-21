using FIASLibary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIASService.Repositories
{
    public interface IGetHouseRepository
    {
        Dictionary<int, HouseModel> GetHouse(string Id);
    }
}
