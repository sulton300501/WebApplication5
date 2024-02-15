using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {


        [HttpGet]
        public string Get()
        {
            return "Malumotim boryapti";
           
        }


        [HttpPost]
        public string Post()
        {
            return "Malumotim boryapti";

        }

        [HttpPut]
        public string Update()
        {
            return "Malumotim boryapti";

        }

        [HttpDelete]
        public string Delete()
        {
            return "Malumotim boryapti";

        }



    }
}
