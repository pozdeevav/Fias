using FIASLibary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FIASService.Repositories
{
    public interface IFulltextSearchRepository
    {
        string FulltextSearch(List<string> query);
        string FulltextSearchInfo(string query);
        string FulltextSearchStreets(string parent);
        string FulltextSearchStead(string parent);
        string FulltextSearchHouse(string parent);
    }
}
