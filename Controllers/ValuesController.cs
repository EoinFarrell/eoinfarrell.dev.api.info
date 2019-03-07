using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace infoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<string> Get()
        {
            //return new string[] { "value1", "value2" };

            string baseUrl = @"https://raw.githubusercontent.com/EoinFarrell/cv/master/cv.json";

            using (HttpClient client = new HttpClient()){
                using (HttpRequestMessage request = new HttpRequestMessage()){
                    request.RequestUri = new Uri(baseUrl);
                    request.Method = HttpMethod.Get;
                    request.Headers.Add("Authorization", "token 498f41da7cf2f56ab8f3d485d09178d3c70af926");

                    using (HttpResponseMessage res = await client.SendAsync(request)){
                        using (HttpContent content = res.Content){
                            string data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                Console.WriteLine(data);
                                return data;

                            }
                        }
                    }
                }
            }

            return null;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
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
