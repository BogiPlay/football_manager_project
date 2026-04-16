using System;
using System.Data;
using FootballManager.Models;
using MySql.Data.MySqlClient;

namespace FootballManager.DataAccess
{
    public class LeaguesRepository
    {
        // ================= CRUD ЗА ЛИГИ =================

        public DataTable GetAllLeagues()
        {
            DataTable dt = new DataTable();
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = "SELECT id, name AS 'Име на лига', season AS 'Сезон' FROM leagues ORDER BY season DESC, name";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader()) { dt.Load(reader); }
                }
            }
            return dt;
        }

        public void AddLeague(League league)
        {
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = "INSERT INTO leagues (name, season) VALUES (@Name, @Season)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", league.Name);
                    command.Parameters.AddWithValue("@Season", league.Season);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateLeague(League league)
        {
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = "UPDATE leagues SET name = @Name, season = @Season WHERE id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", league.Name);
                    command.Parameters.AddWithValue("@Season", league.Season);
                    command.Parameters.AddWithValue("@Id", league.Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteLeague(int id)
        {
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = "DELETE FROM leagues WHERE id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // ================= УЧАСТНИЦИ В ЛИГАТА (МНОГО КЪМ МНОГО) =================

        // 1. Взима клубовете, които ВЕЧЕ УЧАСТВАТ в лигата
        public DataTable GetParticipants(int leagueId)
        {
            DataTable dt = new DataTable();
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = @"SELECT c.id, c.name AS 'Клуб', c.city AS 'Град'
                                 FROM clubs c
                                 JOIN league_teams lt ON c.id = lt.club_id
                                 WHERE lt.league_id = @LeagueId
                                 ORDER BY c.name";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LeagueId", leagueId);
                    connection.Open();
                    using (var reader = command.ExecuteReader()) { dt.Load(reader); }
                }
            }
            return dt;
        }

        // 2. Взима клубовете, които СА СВОБОДНИ за добавяне (НЕ УЧАСТВАТ в тази лига)
        public DataTable GetAvailableClubs(int leagueId)
        {
            DataTable dt = new DataTable();
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                // Използваме LEFT JOIN според изискванията на учителя
                string query = @"SELECT c.id, c.name 
                                 FROM clubs c
                                 LEFT JOIN league_teams lt ON c.id = lt.club_id AND lt.league_id = @LeagueId
                                 WHERE lt.league_id IS NULL
                                 ORDER BY c.name";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LeagueId", leagueId);
                    connection.Open();
                    using (var reader = command.ExecuteReader()) { dt.Load(reader); }
                }
            }
            return dt;
        }

        public void AddClubToLeague(int leagueId, int clubId)
        {
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = "INSERT INTO league_teams (league_id, club_id) VALUES (@LeagueId, @ClubId)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LeagueId", leagueId);
                    command.Parameters.AddWithValue("@ClubId", clubId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void RemoveClubFromLeague(int leagueId, int clubId)
        {
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = "DELETE FROM league_teams WHERE league_id = @LeagueId AND club_id = @ClubId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LeagueId", leagueId);
                    command.Parameters.AddWithValue("@ClubId", clubId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}