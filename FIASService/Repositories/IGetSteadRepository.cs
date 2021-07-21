using FIASLibary.StandartModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIASService.Repositories
{
    public interface IGetSteadRepository
    {
        Dictionary<int, SteadModel> GetStead(string Parent);
    }
}
