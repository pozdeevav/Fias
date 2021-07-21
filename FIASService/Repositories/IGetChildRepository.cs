using FIASLibary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIASService.Repositories
{
    public interface IGetChildRepository
    {
        Dictionary<int, AdvancedSearchModel> GetChild(string Parent, string Division, string AO);
    }
}
