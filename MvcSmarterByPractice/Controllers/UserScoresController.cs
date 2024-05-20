using Microsoft.AspNetCore.Mvc;
using MvcSmarterByPractice.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MvcSmarterByPractice.Controllers
{
    public class UserScoresController : Controller
    {

        [HttpGet]
        [Route("~/api/UserScores/")]
        public IActionResult Index()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5049");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = client.GetAsync("api/UserScores").Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    return Ok(responseMessage.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    return BadRequest("opps Somthign is wong...Check Uri");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
                {

                }
            }
            finally { }
        }
        
    }
}
