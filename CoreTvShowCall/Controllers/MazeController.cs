using System.Threading.Tasks;
using CoreTvShowCall.InternalModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreTvShowCall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MazeController : ControllerBase
    {
        private readonly IMazeService _mazeService;

        public MazeController(IMazeService mazeService)
        {
            _mazeService = mazeService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Show>> Get(int id)
        {
            var externalResult = await _mazeService.GetShowWithCast(id);
            var internalModel = DataMapper.MapToExternal(externalResult);
            return Ok(internalModel);
        }
    }
}