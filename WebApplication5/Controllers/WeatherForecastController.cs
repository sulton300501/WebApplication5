using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Xml.Linq;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {


        [HttpGet]
        [Route("apiget")]
        public string Get()
        {
            return "Malumotim boryapti";
           
        }


        [HttpPost]
        public string Create(string name,string age)
        {
            const string CONNECTSTRING = "Server=127.0.0.1;Port=5432;Database=ulash;User Id=postgres;Password=sulton";

            NpgsqlConnection connection = new NpgsqlConnection(CONNECTSTRING);

            connection.Open();

            string query = "insert into person(name) values('ajajaja')";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            int a = command.ExecuteNonQuery();

            return "malumot yaratildi";


        }

        [HttpPut]
        public string Update(int id , string name)
        {
            const string CONNECTSTRING = "Server=127.0.0.1;Port=5432;Database=ulash;User Id=postgres;Password=sulton";

            NpgsqlConnection connection = new NpgsqlConnection(CONNECTSTRING);

            connection.Open();

            string query = "update person set name=@name where id=@id";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);

            int a = command.ExecuteNonQuery();

            return "Update boldi";

        }

        [HttpDelete]
        public string Delete(int id)
        {
            const string CONNECTSTRING = "Server=127.0.0.1;Port=5432;Database=ulash;User Id=postgres;Password=sulton";

            NpgsqlConnection connection = new NpgsqlConnection(CONNECTSTRING);

            connection.Open();

            string query = "delete from person where id=@id";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();



            return "Delete boldi";

        }
      



    }
}
