using System;
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
        public void AddRoomToDatabase(Room newRoom)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO room (id, number) " +
                               "VALUES (@id, @number)";
            cmd.Parameters.AddWithValue("id", newRoom.Id);
            cmd.Parameters.AddWithValue("number", newRoom.number);

            using (conn)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteRoomFromDatabase(int id)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE from ROOM WHERE ID = @ID;";
            cmd.Parameters.AddWithValue("ID", id);

            using (conn)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateRoom(Room room)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE room " +
                                "SET Number = @number, Is_occupied = @is_occupied " +
                                "SET Number = @number, Is_cleaned = @is_cleaned " +
                                "WHERE id = @id;";
            cmd.Parameters.AddWithValue("number", room.Number);
            cmd.Parameters.AddWithValue("is_occupied", room.Is_occupied);
            cmd.Parameters.AddWithValue("is_cleaned", room.Is_cleaned);
        }
        public Room GetRoom(int id)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id, number, is_occupied, is_cleaned " +
                                "FROM room " +
                                "WHERE id = @id";
            cmd.Parameters.AddWithValue("id", id);

            using (conn)
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                List<Room> room = new List<Room>();

                if (reader.Read())
                {
                    Room room = new Room();

                    room.Id = reader.GetInt32("id");
                    room.Number = reader.GetInt32("number");
                    room.Is_occupied = reader.GetInt32("is_occupied");
                    room.Is_cleaned = reader.GetInt32("is_cleaned");

                    return room;
                }
                else
                {
                    return null;
                }
            }

        }
    }
}
