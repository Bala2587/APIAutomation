using System.Collections.Generic;
using Xunit;
using RestSharp;
using Newtonsoft.Json;
using System.Net;

namespace APIAutomation.Testcase
{
    public class PeopleActivityTestcases
    {
        [Fact]
        public void GetRandomActivity()
        {
            RestClient client = new RestClient("http://www.boredapi.com/api/activity/");
            RestRequest request = new RestRequest();

            RestResponse response = client.Execute(request);
            var BoredResponse = JsonConvert.DeserializeObject<Bored>(response.Content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void GetActivityBasedonKey()
        {
            RestClient client = new RestClient("http://www.boredapi.com/api/activity/");
            
            RestRequest request = new RestRequest();
            //RestRequest request = new RestRequest("?key=5881028", Method.Get);
            request.Method = Method.Get;
            request.AddParameter("key", "5881028");
            

            RestResponse response = client.Execute(request);
            var BoredResponse = JsonConvert.DeserializeObject<Bored>(response.Content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Matches(BoredResponse.type, "education");
            Assert.Matches(BoredResponse.key, "5881028");
        }
    }



    #region DTOclass
    class Bored
    {
        [JsonProperty("activity")]
        public string activity { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("participants")]
        public string participants { get; set; }
        [JsonProperty("key")]
        public string key { get; set; }
    }
    #endregion DTOclass
}
