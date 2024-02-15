using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Xml.Linq;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {







        [HttpGet]
        [Route("apiget")]
        public List<Experiment> Get()
        {
            const string CONNECTSTRING = "Server=127.0.0.1;Port=5432;Database=ulash;User Id=postgres;Password=sulton";

            NpgsqlConnection connection = new NpgsqlConnection(CONNECTSTRING);


            string query = "select * from person";

            return connection.Query<Experiment>(query).ToList();


        }



        [HttpPost]
        public ExperimentDTO CreateDataWithDapper(ExperimentDTO viewModel)
        {
            const string CONNECTSTRING = "Server=127.0.0.1;Port=5432;Database=ulash;User Id=postgres;Password=sulton";
            string query = "insert into person(name) values(@name)";

            NpgsqlConnection connection = new NpgsqlConnection(CONNECTSTRING);

            connection.Execute(query, new ExperimentDTO
            {
                Name = viewModel.Name
            });

            return viewModel;

        }

        [HttpPut]
        public ExperimentDTO UpdateDataWithDapper(int id ,ExperimentDTO viewModel)
        {
            const string CONNECTSTRING = "Server=127.0.0.1;Port=5432;Database=ulash;User Id=postgres;Password=sulton";
            string query = "update person set name=@name where id=@id";

            NpgsqlConnection connection = new NpgsqlConnection(CONNECTSTRING);

            connection.Execute(query, new ExperimentDTO
            {
                Name = viewModel.Name

            });

            return viewModel;

        }

        [HttpPatch]
        public int UpdateDataPatchWithDapper(int id, ExperimentDTO viewModel)
        {
            const string CONNECTSTRING = "Server=127.0.0.1;Port=5432;Database=ulash;User Id=postgres;Password=sulton";
            string query = "update person set name=@name where id=@id";

            NpgsqlConnection connection = new NpgsqlConnection(CONNECTSTRING);

            var x= connection.Execute(query, new 
            {
                Name = viewModel.Name ,
                Id = id

            });

            return x;

        }


        [HttpDelete]
        [HttpPatch]
        public int UpdateDataDeleteWithDapper(int id, ExperimentDTO viewModel)
        {
            const string CONNECTSTRING = "Server=127.0.0.1;Port=5432;Database=ulash;User Id=postgres;Password=sulton";
            string query = "delete from person where id=@id";

            NpgsqlConnection connection = new NpgsqlConnection(CONNECTSTRING);

            var x = connection.Execute(query, new
            {
               
                Id = id

            });

            return x;

        }









        [HttpGet]
        [Route("apigetBYname")]
        public List<Experiment> GetByName(string name)
        {
            const string CONNECTSTRING = "Server=127.0.0.1;Port=5432;Database=ulash;User Id=postgres;Password=sulton";

            NpgsqlConnection connection = new NpgsqlConnection(CONNECTSTRING);


            string query = "select * from person where name=@name" ;

            return connection.Query<Experiment>(query,new {Name=name}).ToList();


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
