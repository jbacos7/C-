using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using LostWoods.Models;

namespace LostWoods.Factories

{
    public class WoodsFactory
    {
        private string connectionString;
        public WoodsFactory ()
        {
            connectionString = "server=localhost; userid=root; password=root; port=3306; database=lostwoods; SslMode=None";
        }
        internal IDbConnection Connection
        {
            get 
            {
                return new MySqlConnection(connectionString);
            }
        }
        public IEnumerable<Woods> GetAllWoods()
        //this Woods is from the Models name
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Woods>("SELECT * FROM woods");
                //woods is our table name in sql - assuming this is created in sql- do this ourselves 
            }
            //this Connection refers to what we named above ////////
        }
        public void AddNew(Woods newTrail)
        {
            using (IDbConnection dbConnection = Connection) 
            {
                string query = $"INSERT INTO woods (name, length, elevation, description, latitude, longitude, created_at, updated_at) VALUES (@Name, @Length, @Elevation, @Description, @Latitude, @Longitude, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, newTrail);
            }
        }

    }
}