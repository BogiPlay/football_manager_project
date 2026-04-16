using FootballManager.DataAccess;
using FootballManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FootballManager.BusinessLogic
{
    public class ScheduleService
    {
        private ScheduleRepository _repository;

        public ScheduleService()
        {
            _repository = new ScheduleRepository();
        }

        public DataTable GetLeaguesForDropdown() => _repository.GetLeaguesForDropdown();

        public DataTable GetScheduleDisplay(int leagueId) => _repository.GetScheduleDisplay(leagueId);

        // Основният метод за бизнес логика
        public void GenerateAndSaveSchedule(int leagueId, DateTime startDate)
        {
            // 1. Проверка дали вече има програма
            if (_repository.HasSchedule(leagueId))
                throw new InvalidOperationException("Това първенство вече има генерирана програма!");

            // 2. Взимане на участниците
            List<int> teamIds = _repository.GetLeagueTeamIds(leagueId);

            // 3. Валидация за минимален брой участници
            if (teamIds.Count < 2)
                throw new InvalidOperationException("Необходими са поне 2 отбора в лигата за генериране на програма!");

            // 4. Генериране на мачовете
            List<Match> schedule = GenerateRoundRobin(leagueId, teamIds, startDate);

            // 5. Записване в базата
            _repository.SaveSchedule(schedule);
        }

        // ================= АЛГОРИТЪМ ЗА ГЕНЕРИРАНЕ =================
        // Вече е private метод в Service слоя, скрит от UI-а
        private List<Match> GenerateRoundRobin(int leagueId, List<int> teams, DateTime startDate)
        {
            List<Match> matches = new List<Match>();

            if (teams.Count % 2 != 0) teams.Add(-1);

            int numTeams = teams.Count;
            int numDays = numTeams - 1;
            int halfSize = numTeams / 2;

            for (int round = 0; round < numDays; round++)
            {
                for (int i = 0; i < halfSize; i++)
                {
                    int home = teams[i];
                    int away = teams[numTeams - 1 - i];

                    if (home != -1 && away != -1)
                    {
                        // Първи полусезон (Домакинство)
                        matches.Add(new Match
                        {
                            LeagueId = leagueId,
                            RoundNo = round + 1,
                            HomeClubId = home,
                            AwayClubId = away,
                            MatchDate = startDate.AddDays(round * 7)
                        });

                        // Втори полусезон (Гостуване)
                        matches.Add(new Match
                        {
                            LeagueId = leagueId,
                            RoundNo = round + 1 + numDays,
                            HomeClubId = away,
                            AwayClubId = home,
                            MatchDate = startDate.AddDays((round + numDays) * 7)
                        });
                    }
                }

                // Завъртане на отборите
                int lastTeam = teams[teams.Count - 1];
                teams.RemoveAt(teams.Count - 1);
                teams.Insert(1, lastTeam);
            }

            return matches.OrderBy(m => m.RoundNo).ToList();
        }
    }
}