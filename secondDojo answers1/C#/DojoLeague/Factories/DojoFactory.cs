using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using DojoLeague.Models;

namespace DojoLeague.Factories

{
    public class DojoFactory
    {
        private string connectionString;
        public DojoFactory ()
        {
            connectionString = "server=localhost; userid=root; password=root;     port=3306; database=dojoleague; SslMode=None";
        }
        internal IDbConnection Connection
        {
            get 
            {
                return new MySqlConnection(connectionString);
            }
        }
        public IEnumerable<Dojo> GetAllDojos()
        {
            using (IDbConnection dbConnection = Connection )
            {
                dbConnection.Open();
                return dbConnection.Query<Dojo>("SELECT * FROM dojos");
                //dojos is our table name in sql - assuming this is created in sql- do this ourselves 
            }
            //this Connection refers to what we named above ////////

        }
        public void AddDojo(Dojo newDojo)
        {
            using (IDbConnection dbConnection = Connection) 
            {
                string query = $"INSERT INTO dojos (name, location, description, created_at, updated_at) VALUES (@DojoName, @DojoLocation, @DojoDescription, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, newDojo);
            }
        }

        public Dojo GetDojoById(int id)
        {
            using (IDbConnection dbConnection = Connection){
                string query = "SELECT * FROM dojos WHERE(Id=@Id)";
                dbConnection.Open();
                return dbConnection.Query<Dojo>(query, new {Id = id}).FirstOrDefault();
            }
        }

        public Dojo GetNinjaById(int id) 
        {
            using (IDbConnection dbConnection = Connection) 
            {
                dbConnection.Open();
                string query = @" SELECT * FROM dojos WHERE dojo_id = @Id; SELECT * FROM ninjas WHERE dojo_id = @Id;
                ";

                using (var many = dbConnection.QueryMultiple(query, new {Id = id})) {
                    var dojo = many.Read<Dojo>().Single();
                    dojo.ninjas = many.Read<Ninja>().ToList();
                    return dojo;
                }
            }
        }

        public void AddNinja(Ninja newNinja, int dojo_id)
        {
            using (IDbConnection dbConnection = Connection) 
            {
                string query = $"INSERT INTO ninjas (name, level, description, dojo_id, created_at, updated_at) VALUES (@NinjaName, @NinjaLevel, @NinjaDescription,{newNinja.dojo.Id}, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, newNinja);
            }
        }
        public IEnumerable<Ninja> GetAllNinjas() {
            using (IDbConnection dbConnection = Connection) 
            {
                string query = "SELECT * FROM ninjas JOIN dojos ON ninjas.dojo_id = dojos.id";
                dbConnection.Open();
                var ninjas = dbConnection.Query<Ninja, Dojo, Ninja>(query, (ninja, dojo) => { ninja.dojo = dojo; return ninja; });
                return ninjas;
            }

        }
    }
}


