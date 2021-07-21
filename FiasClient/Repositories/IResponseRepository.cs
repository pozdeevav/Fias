using FiasClient.Models;
using System.Collections.Generic;

namespace FiasClient.Repositories
{
    public interface IResponseRepository
    {
        Dictionary<int, AddrobjModel>.ValueCollection GetRoot(string Id);
    }
}
