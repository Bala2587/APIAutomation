using System.Collections.Generic;
using Xunit;
using RestSharp;
using Newtonsoft.Json;

namespace APIAutomation.Testcase
{
    public class GeocodingAPITestcases
    {
        [Fact]
        public void GetPostalcode()
        {
            RestClient client = new RestClient("http://api.zippopotam.us");
            RestRequest request = new RestRequest("us/20852", Method.Get);

            RestResponse response = client.Execute(request);
            var LocResponse = JsonConvert.DeserializeObject<locations>(response.Content);

            Assert.Matches(LocResponse.PostCode, "20852");
        }

        [Fact]
        public void GetPlacedetails()
        {
            RestClient client = new RestClient("http://api.zippopotam.us");
            RestRequest request = new RestRequest("us/20852", Method.Get);

            RestResponse response = client.Execute(request);
            var LocResponse = JsonConvert.DeserializeObject<locations>(response.Content);

            Assert.Matches(LocResponse.Place[0].State, "washington");
            Assert.Matches(LocResponse.Place[0].StateAbbreviation, "MD");

        }


        [Fact]
        public void GetAge()
        {
            RestClient client = new RestClient("http://api.zippopotam.us");
            RestRequest request = new RestRequest("us/20852", Method.Get);

            RestResponse response = client.Execute(request);
            var LocResponse = JsonConvert.DeserializeObject<locations>(response.Content);

            Assert.Matches(LocResponse.Place[0].State, "washington");
            Assert.Matches(LocResponse.Place[0].StateAbbreviation, "MD");

        }
    }



# region DTOClasses
    class locations
    {
        [JsonProperty("post code")]
        public string PostCode { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("country abbreviation")]
        public string CountryAbbreviation { get; set; }
        [JsonProperty("places")]
        public List<places> Place { get; set; }


    }

    class places
    {
        [JsonProperty("place name")]
        public string PlaceName { get; set; }
        [JsonProperty("longitude")]
        public string Longitude { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("state abbreviation")]
        public string StateAbbreviation { get; set; }
        [JsonProperty("latitude")]
        public string Latitude { get; set; }
    }
    #endregion DTOClasses
}
