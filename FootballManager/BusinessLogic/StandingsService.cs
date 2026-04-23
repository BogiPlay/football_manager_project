using FootballManager.DataAccess;
using FootballManager.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace FootballManager.BusinessLogic
{
    public class StandingsService
    {
        private StandingsRepository _repository;

        public StandingsService()
        {
            _repository = new StandingsRepository();
        }

        public DataTable GetLeaguesForDropdown()
        {
            return _repository.GetLeaguesForDropdown();
        }

        public List<Standing> CalculateStandings(int leagueId)
        {
            if (leagueId <= 0)
                throw new ArgumentException("Невалидна лига!");

            // Извикваме базата, която извършва самите SQL пресмятания (точки, голова разлика и сортиране)
            return _repository.CalculateStandings(leagueId);
        }
    }
}