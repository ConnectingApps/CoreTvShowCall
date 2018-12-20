using System.IO;
using System.Linq;
using CoreTvShowCall;
using CoreTvShowCall.ExternalModels;
using Newtonsoft.Json;
using Xunit;

namespace CoreTvShowCallTest
{
    public class DataMapperTest
    {
        [Theory]
        [InlineData("CallResult.json", "Under the Dome")]
        public void TestMapToExternal(string fileName, string showName)
        {
            var fileContent = File.ReadAllText(fileName);
            var externalData = JsonConvert.DeserializeObject<RootObject>(fileContent);
            var internalData = DataMapper.MapToExternal(externalData);
            Assert.Equal(showName, internalData.Name);
        }
    }
}