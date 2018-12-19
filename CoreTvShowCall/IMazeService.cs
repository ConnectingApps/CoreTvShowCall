using System.Threading.Tasks;
using CoreTvShowCall.ExternalModels;

namespace CoreTvShowCall
{
    public interface IMazeService
    {
        Task<RootObject> GetShowWithCast(int id);
    }
}