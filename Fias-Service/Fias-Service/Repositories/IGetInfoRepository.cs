namespace Fias_Service.Repositories
{
    public interface IGetInfoRepository
    {
        string GetInfo(string Division, string addrobj, string house, string room);
    }
}
