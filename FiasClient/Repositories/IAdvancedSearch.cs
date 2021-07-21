using FiasClient.Models;

namespace FiasClient.Repositories
{
    public interface IAdvancedSearch
    {
        string AdvSearchRoot(string Id);

        string AdvSearchInfo(string Id, string Division, string addrobj, string house, string room);
    }
}
