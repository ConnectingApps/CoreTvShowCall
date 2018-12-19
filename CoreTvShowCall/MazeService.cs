using System;
using System.Net.Http;
using System.Threading.Tasks;
using CoreTvShowCall.ExternalModels;
using Newtonsoft.Json;

namespace CoreTvShowCall
{
    public class MazeService : IMazeService
    {
        private readonly HttpClient _client;

        /// <summary>
        ///     Creates the CalculationService
        /// </summary>
        /// <param name="client"></param>
        public MazeService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://api.tvmaze.com/");
        }

        public async Task<RootObject> GetShowWithCast(int id)
        {
            var responseString = await _client.GetStringAsync($"shows/{id}?embed=cast");
            var result = JsonConvert.DeserializeObject<RootObject>(responseString);
            return result;
        }
    }
}