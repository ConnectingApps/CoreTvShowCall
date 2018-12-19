using System.Threading.Tasks;
using CoreTvShowCall.EntityModels;
using CoreTvShowCall.InternalModels;

namespace CoreTvShowCall
{
    public interface IMazeRepository
    {
        Task<ShowStore> FindData(int id);
        Task<int> SaveShow(Show show);
    }
}