using FiasClient.Models;

namespace FiasClient.Repositories
{
    public interface IFulltextSearchRepository
    {
        string FulltextSearch(FulltextSearchModel searchModel);
    }
}
