using MySql.Data.MySqlClient;
using System.Collections.Generic;
namespace AndersonGeneralApp
{
    public class RoomRepository
    {
        public List<string> GetAllClasses()
        {
            MySqlConnection conn = new MySqlConnection(System.IO.File.ReadAllText("ConnectionString.txt"));
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT number FROM room;";

            using (conn)
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<string> results = new List<string>();
                while (reader.Read())
                {
                    results.Add(reader.GetString("number"));
                }
                return results;
            }
        }
    }
}
