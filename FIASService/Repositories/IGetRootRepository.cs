using FIASLibary.Models;
using System.Collections.Generic;

namespace FIASService.Repositories
{
    public interface IGetRootRepository
    {
        Dictionary<int, AdvancedSearchModel> GetRoot(string Division);
    }
}
