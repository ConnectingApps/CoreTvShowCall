using System;
using System.Collections.Generic;
using System.Linq;
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

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Show>> Get(int id)
        {
            var externalResult = await _mazeService.GetShowWithCast(id);
            var internalModel = DataMapper.MapToExternal(externalResult);
            return Ok(internalModel);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
