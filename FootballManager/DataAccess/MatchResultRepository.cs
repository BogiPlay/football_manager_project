using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace FootballManager.DataAccess
{
    public class MatchResultRepository
    {
        // 1. Взимане на мачовете за падащото меню
        public DataTable GetMatchesForDropdown()
        {
            DataTable dt = new DataTable();
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = @"SELECT m.id, 
                                        CONCAT(hc.name, ' vs ', ac.name, ' (Кръг ', m.round_no, ')') AS match_name,
                                        m.home_club_id, m.away_club_id, m.home_goals, m.away_goals, m.status
                                 FROM matches m
                                 JOIN clubs hc ON m.home_club_id = hc.id
                                 JOIN clubs ac ON m.away_club_id = ac.id
                                 ORDER BY m.round_no ASC, m.match_date ASC";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader()) { dt.Load(reader); }
                }
            }
            return dt;
        }

        // 2. Взимане на играчите САМО ОТ ДВАТА ОТБОРА в мача
        public DataTable GetPlayersForMatch(int matchId)
        {
            DataTable dt = new DataTable();
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                // Този JOIN гарантира, че играчът е в отбора домакин ИЛИ гост
                string query = @"SELECT p.id, 
                                        CONCAT(p.first_name, ' ', p.last_name, ' (', c.name, ')') AS player_name,
                                        p.current_club_id
                                 FROM players p
                                 JOIN matches m ON (p.current_club_id = m.home_club_id OR p.current_club_id = m.away_club_id)
                                 JOIN clubs c ON p.current_club_id = c.id
                                 WHERE m.id = @MatchId
                                 ORDER BY c.name, p.first_name";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MatchId", matchId);
                    connection.Open();
                    using (var reader = command.ExecuteReader()) { dt.Load(reader); }
                }
            }
            return dt;
        }

        // 3. Извличане на всички събития (Обединени за показване в таблицата)
        public DataTable GetMatchEvents(int matchId)
        {
            DataTable dt = new DataTable();
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                string query = @"
                    SELECT goal_minute AS 'Минута', CONCAT(p.first_name, ' ', p.last_name) AS 'Играч', 'Гол' AS 'Събитие'
                    FROM goals g JOIN players p ON g.player_id = p.id WHERE g.match_id = @MatchId
                    UNION ALL
                    SELECT card_minute, CONCAT(p.first_name, ' ', p.last_name), CONCAT('Картон: ', card_type)
                    FROM cards c JOIN players p ON c.player_id = p.id WHERE c.match_id = @MatchId
                    UNION ALL
                    SELECT foul_minute, CONCAT(p.first_name, ' ', p.last_name), CONCAT('Фал: ', foul_type)
                    FROM fouls f JOIN players p ON f.player_id = p.id WHERE f.match_id = @MatchId
                    ORDER BY `Минута` ASC";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MatchId", matchId);
                    connection.Open();
                    using (var reader = command.ExecuteReader()) { dt.Load(reader); }
                }
            }
            return dt;
        }

        // 4. Добавяне на събитие и АВТОМАТИЧНО ОБНОВЯВАНЕ НА РЕЗУЛТАТА
        public void AddEvent(int matchId, int playerId, int clubId, string eventType, int minute)
        {
            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string insertQuery = "";
                        // Определяме в коя таблица да запишем според избрания тип събитие
                        if (eventType == "Гол")
                            insertQuery = "INSERT INTO goals (match_id, player_id, club_id, goal_minute) VALUES (@M, @P, @C, @Min)";
                        else if (eventType == "Жълт картон")
                            insertQuery = "INSERT INTO cards (match_id, player_id, card_type, card_minute) VALUES (@M, @P, 'Yellow', @Min)";
                        else if (eventType == "Червен картон")
                            insertQuery = "INSERT INTO cards (match_id, player_id, card_type, card_minute) VALUES (@M, @P, 'Red', @Min)";
                        else if (eventType == "Фал")
                            insertQuery = "INSERT INTO fouls (match_id, player_id, foul_type, foul_minute) VALUES (@M, @P, 'Обикновен фал', @Min)";

                        using (var cmd = new MySqlCommand(insertQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@M", matchId);
                            cmd.Parameters.AddWithValue("@P", playerId);
                            cmd.Parameters.AddWithValue("@C", clubId);
                            cmd.Parameters.AddWithValue("@Min", minute);
                            cmd.ExecuteNonQuery();
                        }

                        // Ако събитието е ГОЛ, автоматично пресмятаме резултата!
                        if (eventType == "Гол")
                        {
                            string updateScoreQuery = @"
                                UPDATE matches m
                                SET home_goals = (SELECT COUNT(*) FROM goals WHERE match_id = m.id AND club_id = m.home_club_id),
                                    away_goals = (SELECT COUNT(*) FROM goals WHERE match_id = m.id AND club_id = m.away_club_id),
                                    status = 'Played'
                                WHERE id = @M";
                            using (var cmdScore = new MySqlCommand(updateScoreQuery, connection, transaction))
                            {
                                cmdScore.Parameters.AddWithValue("@M", matchId);
                                cmdScore.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Грешка при запис на събитие: " + ex.Message);
                    }
                }
            }
        }
    }
}