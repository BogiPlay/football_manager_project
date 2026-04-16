using System;
using System.Data;
using FootballManager.Models;
using MySql.Data.MySqlClient;

namespace FootballManager.DataAccess
{
    public class ClubsRepository
    {
        // READ ALL
        public DataTable GetAllClubs()
        {
            DataTable dt = new DataTable();
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = "SELECT id, name, city, stadium, founded_year FROM clubs ORDER BY id";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        // CREATE
        public void AddClub(Club club)
        {
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = "INSERT INTO clubs (name, city, stadium, founded_year) VALUES (@Name, @City, @Stadium, @FoundedYear)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", club.Name);
                    command.Parameters.AddWithValue("@City", club.City);
                    command.Parameters.AddWithValue("@Stadium", club.Stadium);
                    command.Parameters.AddWithValue("@FoundedYear", club.FoundedYear);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // UPDATE
        public void UpdateClub(Club club)
        {
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = "UPDATE clubs SET name = @Name, city = @City, stadium = @Stadium, founded_year = @FoundedYear WHERE id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", club.Name);
                    command.Parameters.AddWithValue("@City", club.City);
                    command.Parameters.AddWithValue("@Stadium", club.Stadium);
                    command.Parameters.AddWithValue("@FoundedYear", club.FoundedYear);
                    command.Parameters.AddWithValue("@Id", club.Id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // DELETE
        public void DeleteClub(int id)
        {
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = "DELETE FROM clubs WHERE id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}