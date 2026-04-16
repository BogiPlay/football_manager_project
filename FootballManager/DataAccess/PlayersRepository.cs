using System;
using System.Data;
using FootballManager.Models;
using MySql.Data.MySqlClient;

namespace FootballManager.DataAccess
{
    public class PlayersRepository
    {
        // Зареждане на клубове за падащите менюта (ComboBox)
        public DataTable GetClubsForDropdown()
        {
            DataTable dt = new DataTable();
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = "SELECT id, name FROM clubs ORDER BY name";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader()) { dt.Load(reader); }
                }
            }
            return dt;
        }

        // READ ALL + КОМБИНИРАНИ ФИЛТРИ
        public DataTable GetPlayers(int clubId, string position, string nameSearch)
        {
            DataTable dt = new DataTable();
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                // Заявка с LEFT JOIN заради "ON DELETE SET NULL"
                string query = @"SELECT p.id, p.first_name AS 'Име', p.last_name AS 'Фамилия', 
                                        IFNULL(c.name, 'Свободен агент') AS 'Клуб', 
                                        p.birth_date AS 'Дата на раждане', p.position AS 'Позиция', 
                                        p.nationality AS 'Националност', p.kit_number AS 'Номер', p.current_club_id
                                 FROM players p
                                 LEFT JOIN clubs c ON p.current_club_id = c.id
                                 WHERE 1=1 ";

                if (clubId > 0) query += " AND p.current_club_id = @ClubId";
                if (!string.IsNullOrEmpty(position) && position != "Всички") query += " AND p.position = @Position";

                // Търсенето проверява и първото, и фамилното име
                if (!string.IsNullOrEmpty(nameSearch)) query += " AND (p.first_name LIKE @NameSearch OR p.last_name LIKE @NameSearch)";

                query += " ORDER BY p.first_name, p.last_name";

                using (var command = new MySqlCommand(query, connection))
                {
                    if (clubId > 0) command.Parameters.AddWithValue("@ClubId", clubId);
                    if (!string.IsNullOrEmpty(position) && position != "Всички") command.Parameters.AddWithValue("@Position", position);
                    if (!string.IsNullOrEmpty(nameSearch)) command.Parameters.AddWithValue("@NameSearch", "%" + nameSearch + "%");

                    connection.Open();
                    using (var reader = command.ExecuteReader()) { dt.Load(reader); }
                }
            }
            return dt;
        }

        // CREATE
        public void AddPlayer(Player player)
        {
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = @"INSERT INTO players (first_name, last_name, birth_date, position, nationality, kit_number, current_club_id) 
                                 VALUES (@FirstName, @LastName, @BirthDate, @Position, @Nationality, @KitNumber, @CurrentClubId)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", player.FirstName);
                    command.Parameters.AddWithValue("@LastName", player.LastName);
                    command.Parameters.AddWithValue("@BirthDate", player.BirthDate);
                    command.Parameters.AddWithValue("@Position", player.Position);
                    command.Parameters.AddWithValue("@Nationality", string.IsNullOrEmpty(player.Nationality) ? DBNull.Value : player.Nationality);
                    command.Parameters.AddWithValue("@KitNumber", player.KitNumber);

                    // Ако е избран клуб (ID > 0), записваме го, иначе записваме NULL
                    command.Parameters.AddWithValue("@CurrentClubId", player.CurrentClubId > 0 ? player.CurrentClubId : DBNull.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // UPDATE
        public void UpdatePlayer(Player player)
        {
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = @"UPDATE players SET first_name = @FirstName, last_name = @LastName, birth_date = @BirthDate, 
                                 position = @Position, nationality = @Nationality, kit_number = @KitNumber, current_club_id = @CurrentClubId 
                                 WHERE id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", player.FirstName);
                    command.Parameters.AddWithValue("@LastName", player.LastName);
                    command.Parameters.AddWithValue("@BirthDate", player.BirthDate);
                    command.Parameters.AddWithValue("@Position", player.Position);
                    command.Parameters.AddWithValue("@Nationality", string.IsNullOrEmpty(player.Nationality) ? DBNull.Value : player.Nationality);
                    command.Parameters.AddWithValue("@KitNumber", player.KitNumber);
                    command.Parameters.AddWithValue("@CurrentClubId", player.CurrentClubId > 0 ? player.CurrentClubId : DBNull.Value);
                    command.Parameters.AddWithValue("@Id", player.Id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // DELETE
        public void DeletePlayer(int id)
        {
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = "DELETE FROM players WHERE id = @Id";
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