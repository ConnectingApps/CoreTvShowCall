using System.IO;
using System.Linq;
using CoreTvShowCall.ExternalModels;
using Newtonsoft.Json;
using Xunit;

namespace CoreTvShowCallTest
{
    public class RootObjectTest
    {
        [Theory]
        [InlineData("CallResult.json", 1979)]
        public void RootObjectSerialisationTest(string contentFromRestCall, int birthYearFirstPerson)
        {
            var textFromCall = File.ReadAllText(contentFromRestCall);
            var output = JsonConvert.DeserializeObject<RootObject>(textFromCall);
            Assert.False(string.IsNullOrEmpty(output.url));
            Assert.False(string.IsNullOrEmpty(output._embedded.cast.First().person.birthday));
            Assert.False(string.IsNullOrEmpty(output._embedded.cast.Last().person.name));
            // ReSharper disable once PossibleInvalidOperationException, has been checked with data model
            Assert.Equal(birthYearFirstPerson,output._embedded.cast.First().person.GetBirthDate().Value.Year);
        }
    }
}