using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using AndersonGeneralApp.Models;
using System.Threading.Tasks;

namespace AndersonGeneralApp
{
    public class RoomRepository
    {
        public List<Room> GetAllRooms()
        {
            MySqlConnection conn = new MySqlConnection(System.IO.File.ReadAllText("ConnectionString.txt"));
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id, number, is_occupied, is_cleaned FROM room;";

            using (conn)
            {
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Room> rooms = new List<Room>();
                while (reader.Read())
                {
                    Room currentRoom = new Room();

                    currentRoom.Id = reader.GetInt32("id");
                    currentRoom.Number = reader.GetInt32("number");
                    currentRoom.Is_occupied = reader.GetBoolean("is_occupied");
                    currentRoom.Is_cleaned = reader.GetBoolean("is_cleaned");

                    rooms.Add(currentRoom);


                }
                return rooms;
            }
        }
        public List<Room> GetAvailableRooms()
        {
            MySqlConnection conn = new MySqlConnection(System.IO.File.ReadAllText("ConnectionString.txt"));
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id, number, is_occupied, is_cleaned FROM room where is_occupied=0 and is_cleaned=1 ;";

            using (conn)
            {
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Room> rooms = new List<Room>();
                while (reader.Read())
                {
                    Room currentRoom = new Room();

                    currentRoom.Id = reader.GetInt32("id");
                    currentRoom.Number = reader.GetInt32("number");
                    currentRoom.Is_occupied = reader.GetBoolean("is_occupied");
                    currentRoom.Is_cleaned = reader.GetBoolean("is_cleaned");

                    rooms.Add(currentRoom);

                }
                return rooms;
            }
        }
        public List<Room> GetDirtyRooms()
        {
            MySqlConnection conn = new MySqlConnection(System.IO.File.ReadAllText("ConnectionString.txt"));
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id, number, is_occupied, is_cleaned FROM room where is_occupied=0 and is_cleaned=0 ;";

            using (conn)
            {
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                List<Room> rooms = new List<Room>();
                while (reader.Read())
                {
                    Room currentRoom = new Room();

                    currentRoom.Id = reader.GetInt32("id");
                    currentRoom.Number = reader.GetInt32("number");
                    currentRoom.Is_occupied = reader.GetBoolean("is_occupied");
                    currentRoom.Is_cleaned = reader.GetBoolean("is_cleaned");

                    rooms.Add(currentRoom);
                }
                return rooms;
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
            cmd.Parameters.AddWithValue("number", newRoom.Number);

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
                                ", Is_cleaned = @is_cleaned " +
                                "WHERE id = @id;";
            cmd.Parameters.AddWithValue("number", room.Number);
            cmd.Parameters.AddWithValue("is_occupied", room.Is_occupied);
            cmd.Parameters.AddWithValue("is_cleaned", room.Is_cleaned);
            cmd.Parameters.AddWithValue("id", room.Id);
            
            using (conn)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
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
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                List<Room> rooms = new List<Room>();

                if (reader.Read())
                {
                    Room room = new Room();

                    room.Id = reader.GetInt32("id");
                    room.Number = reader.GetInt32("number");
                    room.Is_occupied = reader.GetBoolean("is_occupied");
                    room.Is_cleaned = reader.GetBoolean("is_cleaned");

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
