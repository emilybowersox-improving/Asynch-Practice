using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Asynch_Practice.ApiResponse;

namespace Asynch_Practice
{
    public class ApiData
    {

        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<int> GetRandomNumber()
        {
            var response = await _httpClient.GetAsync("https://seriouslyfundata.azurewebsites.net/api/generatearandomnumber");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            return Convert.ToInt32(responseString);
        }


        public async Task<string> GetChuckNorrisFact()
        {
            var response = await _httpClient.GetAsync("https://seriouslyfundata.azurewebsites.net/api/chucknorrisfact");
            response.EnsureSuccessStatusCode();

            string responseString = await response.Content.ReadAsStringAsync();
            var fact = Newtonsoft.Json.JsonConvert.DeserializeObject<ChuckNorrisFact>(responseString);

            return fact.Joke;
        }


        public async Task<List<Seleucid>> GetTheSeleucids()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://seriouslyfundata.azurewebsites.net/api/seleucids");
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            var seleucidResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<SeleucidResponse>(responseContent);

            return seleucidResponse.Seleucids;
        }





        /*       //from XML Teacher example
               public async Task<Teacher> GetATeacher()
               {
                   HttpResponseMessage response = await _httpClient.GetAsync("https://seriouslyfundata.azurewebsites.net/api/ateacher");
                   response.EnsureSuccessStatusCode();
                   string responseContent = await response.Content.ReadAsStringAsync();
                   using (var stringReader = new System.IO.StringReader(responseContent))
                   {
                       var serializer = new XmlSerializer(typeof(Teacher));
                       return serializer.Deserialize(stringReader) as Teacher;
                   }
               }*/

    }
}
