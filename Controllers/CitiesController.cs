using CitiesAPI_D.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CITIESAPI_D.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController
    {
        [HttpGet()]
        public List<City> GetAll()
        {
            string url = "http://localhost:7206/api/cities";
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            List<City> city = new List<City>();
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = @reader.ReadToEnd();

                city = Newtonsoft.Json.JsonConvert.DeserializeObject<List<City>>(responseFromServer);
            }

            // Close the response.
            response.Close();
            return city;
        }
    }
}
