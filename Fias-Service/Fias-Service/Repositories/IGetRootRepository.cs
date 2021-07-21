using Fias_Service.Models;
using System.Collections.Generic;

namespace Fias_Service.Repositories
{
    public interface IGetRootRepository
    {
        Dictionary<int, ADDROBJModel> GetRoot(string Division);
    }
}
