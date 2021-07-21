using Fias_Service.Models;
using System.Collections.Generic;

namespace Fias_Service.Repositories
{
    public interface IGetChildRepository
    {
        Dictionary<int, ADDROBJModel> GetChild(string Parent, string Division, string AO);
    }
}
