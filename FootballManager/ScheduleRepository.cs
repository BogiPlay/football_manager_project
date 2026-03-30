using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace FootballManager
{
    public class ScheduleRepository
    {
        // Взимане на всички лиги за падащото меню
        public DataTable GetLeaguesForDropdown()
        {
            DataTable dt = new DataTable();
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = "SELECT id, CONCAT(name, ' (', season, ')') AS league_info FROM leagues ORDER BY season DESC, name";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader()) { dt.Load(reader); }
                }
            }
            return dt;
        }

        // Взимане на ID-тата на всички участници в дадена лига
        public List<int> GetLeagueTeamIds(int leagueId)
        {
            List<int> teams = new List<int>();
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = "SELECT club_id FROM league_teams WHERE league_id = @LeagueId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LeagueId", leagueId);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            teams.Add(reader.GetInt32("club_id"));
                        }
                    }
                }
            }
            return teams;
        }

        // Проверка дали вече има генерирана програма за тази лига
        public bool HasSchedule(int leagueId)
        {
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = "SELECT COUNT(*) FROM matches WHERE league_id = @LeagueId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LeagueId", leagueId);
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        // Запазване на масива от мачове в базата (с ТРАНЗАКЦИЯ)
        public void SaveSchedule(List<Match> schedule)
        {
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = @"INSERT INTO matches (league_id, round_no, home_club_id, away_club_id, match_date) 
                                         VALUES (@LeagueId, @RoundNo, @HomeClubId, @AwayClubId, @MatchDate)";

                        using (var command = new MySqlCommand(query, connection, transaction))
                        {
                            // Подготвяме параметрите предварително за по-бързо изпълнение
                            command.Parameters.Add("@LeagueId", MySqlDbType.Int32);
                            command.Parameters.Add("@RoundNo", MySqlDbType.Int32);
                            command.Parameters.Add("@HomeClubId", MySqlDbType.Int32);
                            command.Parameters.Add("@AwayClubId", MySqlDbType.Int32);
                            command.Parameters.Add("@MatchDate", MySqlDbType.DateTime);

                            foreach (var match in schedule)
                            {
                                command.Parameters["@LeagueId"].Value = match.LeagueId;
                                command.Parameters["@RoundNo"].Value = match.RoundNo;
                                command.Parameters["@HomeClubId"].Value = match.HomeClubId;
                                command.Parameters["@AwayClubId"].Value = match.AwayClubId;
                                command.Parameters["@MatchDate"].Value = match.MatchDate;

                                command.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit(); // Запазваме всички мачове накуп!
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Грешка при запис на програмата: " + ex.Message);
                    }
                }
            }
        }

        // Извличане на програмата за визуализация
        public DataTable GetScheduleDisplay(int leagueId)
        {
            DataTable dt = new DataTable();
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = @"SELECT m.round_no AS 'Кръг', 
                                        hc.name AS 'Домакин', 
                                        ac.name AS 'Гост', 
                                        m.match_date AS 'Дата',
                                        m.status AS 'Статус'
                                 FROM matches m
                                 JOIN clubs hc ON m.home_club_id = hc.id
                                 JOIN clubs ac ON m.away_club_id = ac.id
                                 WHERE m.league_id = @LeagueId
                                 ORDER BY m.round_no ASC, m.match_date ASC";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LeagueId", leagueId);
                    connection.Open();
                    using (var reader = command.ExecuteReader()) { dt.Load(reader); }
                }
            }
            return dt;
        }
    }
}