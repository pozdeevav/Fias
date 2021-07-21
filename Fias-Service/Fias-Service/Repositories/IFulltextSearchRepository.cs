using System.Collections.Generic;

namespace Fias_Service.Repositories
{
    public interface IFulltextSearchRepository
    {
        string FulltextSearch(List<string> query);
        string FulltextSearchInfo(string query);
        string FulltextSearchStead(string parent);
        string FulltextSearchHouse(string parent);
    }
}
