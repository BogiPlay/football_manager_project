using FootballManager.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using FootballManager.Models;

namespace FootballManager.DataAccess
{
    public class StandingsRepository
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

        // ОСНОВЕН АЛГОРИТЪМ ЗА ИЗЧИСЛЯВАНЕ НА КЛАСИРАНЕТО
        public List<Standing> CalculateStandings(int leagueId)
        {
            var standingsDict = new Dictionary<int, Standing>();

            using (var connection = Db.GetConnection() as MySqlConnection)
            {
                connection.Open();

                // СТЪПКА 1: Взимаме всички участници в тази лига (първоначално всички са с 0 точки)
                string queryTeams = @"SELECT c.id, c.name FROM clubs c
                                      JOIN league_teams lt ON c.id = lt.club_id
                                      WHERE lt.league_id = @LeagueId";
                using (var cmdTeams = new MySqlCommand(queryTeams, connection))
                {
                    cmdTeams.Parameters.AddWithValue("@LeagueId", leagueId);
                    using (var reader = cmdTeams.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int clubId = reader.GetInt32("id");
                            standingsDict[clubId] = new Standing
                            {
                                ClubId = clubId,
                                ClubName = reader.GetString("name")
                            };
                        }
                    }
                }

                // СТЪПКА 2: Взимаме само ИЗИГРАНИТЕ мачове за тази лига
                string queryMatches = @"SELECT home_club_id, away_club_id, home_goals, away_goals
                                        FROM matches
                                        WHERE league_id = @LeagueId AND status = 'Played'";
                using (var cmdMatches = new MySqlCommand(queryMatches, connection))
                {
                    cmdMatches.Parameters.AddWithValue("@LeagueId", leagueId);
                    using (var reader = cmdMatches.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int homeId = reader.GetInt32("home_club_id");
                            int awayId = reader.GetInt32("away_club_id");
                            int homeGoals = reader.GetInt32("home_goals");
                            int awayGoals = reader.GetInt32("away_goals");

                            // Ако отборите не са в речника (например изтрити), прескачаме
                            if (!standingsDict.ContainsKey(homeId) || !standingsDict.ContainsKey(awayId)) continue;

                            var homeTeam = standingsDict[homeId];
                            var awayTeam = standingsDict[awayId];

                            // Обновяваме изиграните мачове и головете
                            homeTeam.MatchesPlayed++;
                            awayTeam.MatchesPlayed++;

                            homeTeam.GoalsFor += homeGoals;
                            homeTeam.GoalsAgainst += awayGoals;

                            awayTeam.GoalsFor += awayGoals;
                            awayTeam.GoalsAgainst += homeGoals;

                            // Пресмятаме точките и победите/загубите
                            if (homeGoals > awayGoals) // Победа за домакина
                            {
                                homeTeam.Wins++;
                                homeTeam.Points += 3;
                                awayTeam.Losses++;
                            }
                            else if (homeGoals < awayGoals) // Победа за госта
                            {
                                awayTeam.Wins++;
                                awayTeam.Points += 3;
                                homeTeam.Losses++;
                            }
                            else // Равенство
                            {
                                homeTeam.Draws++;
                                awayTeam.Draws++;
                                homeTeam.Points += 1;
                                awayTeam.Points += 1;
                            }
                        }
                    }
                }
            }

            // СТЪПКА 3: Сортиране според изискванията на Учителя
            // 1. Точки (низходящ), 2. Голова разлика (низходящ), 3. Вкарани голове (низходящ)
            var sortedStandings = standingsDict.Values
                .OrderByDescending(s => s.Points)
                .ThenByDescending(s => s.GoalDifference)
                .ThenByDescending(s => s.GoalsFor)
                .ToList();

            // СТЪПКА 4: Задаване на точната позиция (1-во място, 2-ро място...)
            for (int i = 0; i < sortedStandings.Count; i++)
            {
                sortedStandings[i].Position = i + 1;
            }

            return sortedStandings;
        }
    }
}