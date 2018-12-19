using System.Threading.Tasks;
using CoreTvShowCall.EntityModels;
using CoreTvShowCall.InternalModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CoreTvShowCall
{
    public class MazeRepository : IMazeRepository
    {
        private readonly StoreContext _context;

        public MazeRepository(StoreContext context)
        {
            _context = context;
        }

        public Task<ShowStore> FindData(int id)
        {
            return _context.ShowStores.FirstOrDefaultAsync(a => a.ExternalIdentifier == id);
        }

        public Task<int> SaveShow(Show show)
        {
            var output = JsonConvert.SerializeObject(show);
            var toSave = new ShowStore
            {
                ExternalIdentifier = show.Id,
                Data = output
            };
            _context.ShowStores.Add(toSave);
            return _context.SaveChangesAsync();
        }
    }
}