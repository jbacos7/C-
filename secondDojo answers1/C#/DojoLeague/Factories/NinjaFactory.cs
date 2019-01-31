// using System.Collections.Generic;
// using System.Data;
// using System.Linq;
// using Dapper;
// using MySql.Data.MySqlClient;
// using DojoLeague.Models;

// namespace DojoLeague.Factories

// public class NinjaFactory
//     {
//         private string connectionString;
//         public DojoFactory ()
//         {
//             connectionString = "server=localhost; userid=root; password=root;     port=3306; database=dojoleague; SslMode=None";
//         }
//         internal IDbConnection Connection
//         {
//             get 
//             {
//                 return new MySqlConnection(connectionString);
//             }
//         }
//         public IEnumerable<Dojo> GetAllDojos()
//         {
//             using (IDbConnection dbConnection = Connection )
//             {
//                 dbConnection.Open();
//                 return dbConnection.Query<Dojo>("SELECT * FROM dojos");
//                 //dojos is our table name in sql - assuming this is created in sql- do this ourselves 
//             }
//             //this Connection refers to what we named above ////////

//         }
//         public void AddDojo(Dojo newDojo)
//         {
//             using (IDbConnection dbConnection = Connection) 
//             {
//                 string query = $"INSERT INTO dojos (name, location, description, created_at, updated_at) VALUES (@DojoName, @DojoLocation, @DojoDescription, NOW(), NOW())";
//                 dbConnection.Open();
//                 dbConnection.Execute(query, newDojo);
//             }
//         }

//         public Dojo GetDojoById(int id){
//             using (IDbConnection dbConnection = Connection){
//                 string query = "SELECT * FROM dojos WHERE(Id=@Id)";
//                 dbConnection.Open();
//                 return dbConnection.Query<Dojo>(query, new{Id = id}).FirstOrDefault();
//             }
//         }
//         public void AddNinja(Ninja newNinja)
//         {
//             using (IDbConnection dbConnection = Connection) 
//             {
//                 string query = $"INSERT INTO ninjas (name, level, ninjadojo, description, created_at, updated_at) VALUES (@NinjaName, @NinjaLevel, @NinjaDojo, @NinjaDescription, NOW(), NOW())";
//                 dbConnection.Open();
//                 dbConnection.Execute(query, newNinja);
//             }
//         }

//     }
// }


