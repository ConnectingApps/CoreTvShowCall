using System;
using System.Net.Http;
using System.Threading.Tasks;
using CoreTvShowCall.InternalModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreTvShowCall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MazeController : ControllerBase
    {
        private readonly IMazeService _mazeService;
        private readonly IMazeRepository _repository;

        public MazeController(IMazeService mazeService , IMazeRepository repository)
        {
            _mazeService = mazeService;
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Show>> Get(int id)
        {
            var previousResult = await _repository.FindData(id);
            if (previousResult != null)
            {
                Show deserializedProduct = JsonConvert.DeserializeObject<Show>(previousResult.Data);
                return Ok(deserializedProduct);
            }
            try
            {
                var externalResult = await _mazeService.GetShowWithCast(id);
                var internalModel = DataMapper.MapToExternal(externalResult);
                try
                {
                    await _repository.SaveShow(internalModel); // As required we should "persists the data in storage"
                }
                catch (Exception e)
                {
                    // If not saved successfully we can get it via the rest api anyway
                    Console.WriteLine(e);
                }
                return Ok(internalModel);
            }
            catch (HttpRequestException e)
            {
                if (e.Message.Contains("404"))
                {
                    return NotFound(e.Message);
                }
                Console.WriteLine(e);
                throw;
            }
        }
    }
}